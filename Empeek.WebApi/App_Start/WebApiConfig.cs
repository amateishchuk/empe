using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Empeek.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Remove XML formatter
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute("UserPetsPagination", "api/userId{id}/page{page}", new { controller = "Users" });

            config.Routes.MapHttpRoute("UserPetsDefaultPagination", "api/userId{id}", new { controller = "Users" });

            config.Routes.MapHttpRoute("UsersPagination", "api/{controller}/page{page}");

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}");
        }
    }
}
