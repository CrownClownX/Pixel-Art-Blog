﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Pixel_Art_Blog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: null,
                url: "contact",
                defaults: new {controller = "contact", action = "index"}
            );

            routes.MapRoute(
                name: null,
                url: "posts{page}/{categoryId}",
                defaults: new { controller = "post", action = "AllPosts", categoryId = UrlParameter.Optional, page = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: null,
                url: "about",
                defaults: new { controller = "post", action = "about" }
            );

            routes.MapRoute(
                name: null,
                url: "post{id}",
                defaults: new { controller = "post", action = "post", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: null,
                url: "index",
                defaults: new { controller = "post", action = "index" }
            );

            routes.MapRoute(
                name: null,
                url: "admin",
                defaults: new { controller = "Admin", action = "AdminPanel"}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Post", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
