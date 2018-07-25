using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Task1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.LowercaseUrls = true;

            routes.MapRoute(
                name: "CreateGame",
                url: "{controller}/new",
                defaults: new { controller = "Games", action = "NewGame"});

            routes.MapRoute(
                name: "UpdateGame",
                url: "{controller}/update",
                defaults: new { controller = "Games", action = "UpdateGame" });

            routes.MapRoute(
                name: "GameInfo",
                url: "game/{key}",
                defaults: new { controller = "Games", action = "GameInfo" });

            routes.MapRoute(
                name: "GameList",
                url: "games",
                defaults: new { controller = "Games", action = "List" });

            routes.MapRoute(
                name: "DeleteGame",
                url: "{controller}/remove",
                defaults: new { controller = "Games", action = "RemoveGame" });

            routes.MapRoute(
                name: "SetGameComment",
                url: "game/{gamekey}/newcomment",
                defaults: new { controller = "Games", action = "SetComment"});

            routes.MapRoute(
                name: "GetCommentsForGame",
                url: "game/{gamekey}/comments",
                defaults: new { controller = "Games", action = "GetComments"});

            routes.MapRoute(
                name: "DownloadGame",
                url: "game/{gamekey}/download",
                defaults: new { controller = "Games", action = "DownloadGame" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
