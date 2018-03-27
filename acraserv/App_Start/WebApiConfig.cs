using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace acraserv
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{firstName}/{lastName}/{socCard}/{clientID}/{requestType}/{isTest}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
