using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Routing;
using Taschenrechner.api.Controller;

namespace Taschenrechner.API {

    public static class WebApiConfig {

        public static void Register(HttpConfiguration config) {
            // Web API configuration and services

            // Web API routes
            var cors = new EnableCorsAttribute("http://localhost:4200", "*", "*");
            cors.SupportsCredentials = true;
            config.EnableCors(cors);


            config.MapHttpAttributeRoutes();

            RouteTable.Routes.MapHttpRoute(
                name: "Taschenrechner",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            ).RouteHandler = new SessionStateRouteHandler();
        }
    }
}