using System.Web.Http;
using ETPPractice.Models;

namespace ETPPractice
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;
            config.Formatters.Insert(0, new BrowserJsonFormatter(json));
        }
    }
}
