using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Routing.Constraints;

namespace Empeek.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.MapHttpAttributeRoutes();
            
            config.Routes.MapHttpRoute(
                null, 
                "api/user{id}/", 
                new { controller = "Users" }, 
                new { id = @"\d+" });

            config.Routes.MapHttpRoute(
                null, 
                "api/user{id}/reverse", 
                new { controller = "Users", page = 1, sortReverse = true }, 
                new { id = @"\d+" });

            config.Routes.MapHttpRoute(
                null, 
                "api/user{id}/page{page}", 
                new { controller = "Users" }, 
                new { id = @"\d+" });

            config.Routes.MapHttpRoute(
                null, 
                "api/user{id}/page{page}/reverse", 
                new { controller = "Users", sortReverse = true }, 
                new { id = @"\d+" });

            config.Routes.MapHttpRoute(
                null, 
                "api/{controller}/delete/{id}");

            config.Routes.MapHttpRoute(
                null, 
                "api/{controller}/reverse", 
                new { sortReverse = true });

            config.Routes.MapHttpRoute
                (null, 
                "api/{controller}/page{page}");

            config.Routes.MapHttpRoute(
                null, 
                "api/{controller}/page{page}/reverse", 
                new { sortReverse = true });

            config.Routes.MapHttpRoute(
                "DefaultApi", 
                "api/{controller}/{id}", 
                new { id = RouteParameter.Optional });

        }
    }
}
