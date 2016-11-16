using System.Web.Http;
using ETPPractice.Models;

namespace ETPPractice
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Formatters.Insert(0, new BrowserJsonFormatter(config.Formatters.JsonFormatter.SerializerSettings));
        }
    }
}
