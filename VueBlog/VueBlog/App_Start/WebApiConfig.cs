using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using VueBlog.Filters;

namespace VueBlog
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
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            _RegisterFilters(config);
        }

        private static void _RegisterFilters(HttpConfiguration config)
        {
            config.Filters.Add(new DbUpdateConcurrencyExceptionFilter());
        }
    }
}
