﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MartCo.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "AllProducts",
            //    url: "Products/all",
            //    defaults: new { controller = "Product", action = "ProductTable" }
            //    );

            routes.MapRoute(
        name: "AllProducts",
        url: "Products/all",
        defaults: new
        {
            controller = "Product",
            action = "ProductTable"
        });


                routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
