﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QDB
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Search1",
                "Quotes/Search",
                new { controller = "Quotes", action = "Search" }
            );

            routes.MapRoute(
                "Search",
                "Quotes/Search/{query}",
                new { controller = "Quotes", action = "Search", query = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Submit",
                "Quote/Submit",
                new { controller = "Quote", action = "Submit" }
            );

            routes.MapRoute(
                "Submit2",
                "Quote/Submit/{quote}",
                new { controller = "Quote", action = "Submit", quote = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Quote",
                "Quote/{id}",
                new { controller = "Quote", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            //RouteDebug.RouteDebugger.RewriteRoutesForTesting(RouteTable.Routes);
        }
    }
}