﻿using System.Web.Mvc;
using System.Web.Routing;

namespace Web
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapMvcAttributeRoutes();
        }
    }
}