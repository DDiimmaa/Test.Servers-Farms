using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Test.FrontEnd.Models;

namespace Test.FrontEnd.Controllers
{
    public class SettingsController : BaseController
    {
        // GET: Settings
        public ActionResult Index(string angularModuleName = "app")
        {
            var settings = new
            {
                WebApiBaseUrl = GetAppSetting<string>("WebAPIUrlAddress"),
            };

            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var settingsJson = JsonConvert.SerializeObject(settings, Formatting.Indented, serializerSettings);

            var settingsVm = new WebConfigSettingsViewModel
            {
                SettingsJson = settingsJson,
                AngularModuleName = angularModuleName
            };

            Response.ContentType = "text/javascript";
            return View(settingsVm);
        }
    }
}