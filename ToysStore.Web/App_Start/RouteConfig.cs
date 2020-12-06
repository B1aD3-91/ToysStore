using System.Web.Mvc;
using System.Web.Routing;

namespace ToysStore.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "",
                url: "Toy",
                defaults: new { controller = "Toy", action = "Catalog", category = (string)null, page = 1 }
                );
            routes.MapRoute(
                name: "",
                url: "Toy/{page}",
                defaults: new { controller = "Toy", action = "Catalog", category = (string)null },
                constraints: new {page = @"\d+"}
                );
            routes.MapRoute(
                name: "",
                url: "Toy/{category}",
                defaults: new { controller = "Toy", action = "Catalog", page = 1 }
                );
            routes.MapRoute(
                name: "",
                url: "Toy/{category}/{page}",
                defaults: new { controller = "Toy", action = "Catalog"},
                constraints: new {page = @"\d+"}
                );
            routes.MapRoute(
                name: "",
                url: "Partial/SearchResult/{s}",
                defaults: new { controller = "Partial", action = "SearchResult" }
                );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Main", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
