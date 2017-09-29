using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WeaponDesign.WebSite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.jpg/{*pathInfo}");
            routes.RouteExistingFiles = false;
            routes.MapRoute(
                name: "Default",
                url: "{action}/{id}",
                defaults: new { controller = "WeaponDesign", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
