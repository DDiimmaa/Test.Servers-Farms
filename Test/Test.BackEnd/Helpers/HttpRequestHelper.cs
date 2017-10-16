using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Test.BackEnd.Helpers
{
    public static class HttpRequestHelper
    {
        public static async Task<string> GetServerPage(string url)
        {
            Thread.Sleep(3000);

            if (string.IsNullOrWhiteSpace(url))
                return File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath("~/serverStubInfo.html"));

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(url))
            using (HttpContent content = response.Content)
            {
                return await content.ReadAsStringAsync();
            }
        }
    }
}