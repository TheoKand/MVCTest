﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_TestBed
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Goals",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Goals", action = "Index", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "jQueryAjax",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "jQueryAjax", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}