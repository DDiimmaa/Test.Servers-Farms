using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using Test.Models;

namespace Test.BackEnd.Helpers
{
    public static class ExtendObject<T> where T : class
    {
        private const string propertyPattern = @"^([A-z\s_]*?)(?=[:=])";
        private const string replacePropertyPattern = @"(?:[A-z\\s_]*?)[:=]";

        public static void ExtendFromHtmlBody(ref T obj, string html)
        {
            if (string.IsNullOrWhiteSpace(html))
                return;

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            HtmlNode node = doc.DocumentNode.SelectSingleNode("//body");

            var propertyValuePairs = node.InnerHtml.Split(new string[] {"<br>", "<br/>", "<b>", "</b>" }, StringSplitOptions.RemoveEmptyEntries);

            var reg = new Regex(propertyPattern);
            var reg2 = new Regex(replacePropertyPattern);
            foreach (string pair in propertyValuePairs)
            {
                var str = pair.Replace("\\r", string.Empty).Replace("\\n", string.Empty).Trim();
                if(string.IsNullOrWhiteSpace(str))
                    continue;

                string someProperty = Regex.Replace(reg.Match(str).Value.Replace('\\', '_'), @"\s", string.Empty);
                string valueOfProperty = reg2.Replace(str,string.Empty).Trim();
                obj.GetType().GetProperty(someProperty)?.SetValue(obj, ConvertFunction(valueOfProperty, obj.GetType().GetProperty(someProperty)?.PropertyType), null);
            }
        }

        private static object ConvertFunction(string text, Type type)
        {
            try
            {
                TypeConverter tc = TypeDescriptor.GetConverter(type);
                return tc.ConvertFromString(null, CultureInfo.InvariantCulture, text);
            }
            catch (Exception ex)
            {
                return new object();
            }
        }
    }
}