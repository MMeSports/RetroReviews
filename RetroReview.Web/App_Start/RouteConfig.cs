using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RetroReview.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
              name: "AdminDeleteUser",
              url: "admin/deleteuser/{guid}",
              defaults: new { controller = "Admin", action = "DeleteUser" }
          );

            routes.MapRoute(
              name: "GameReviews",
              url: "reviews/game/{name}",
              defaults: new { controller = "Reviews", action = "Game" }
          );

            routes.MapRoute(
              name: "AdminReview",
              url: "{controller}/reviews/{action}/{id}",
              defaults: new { controller = "Admin", action = "Index" }
          );

            routes.MapRoute(
			  name: "Platforms",
			  url: "{controller}/Platforms/{name}",
			  defaults: new { controller = "Reviews", action = "Platforms" }
		  );
			routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
