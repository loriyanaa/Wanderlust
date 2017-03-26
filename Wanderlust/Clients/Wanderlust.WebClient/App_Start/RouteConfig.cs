using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Wanderlust.WebClient
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.LowercaseUrls = true;

            routes.MapRoute(
                name: "GetImages",
                url: "profile/getprofileimages",
                defaults: new { controller = "Profile", action = "GetProfileImages" }
            );

            routes.MapRoute(
                name: "UpdateInfo",
                url: "profile/updateuserinfo",
                defaults: new { controller = "Profile", action = "UpdateUserInfo" }
            );

            routes.MapRoute(
                name: "Traveller",
                url: "profile/{id}",
                defaults: new { controller = "Profile", action = "Index" },
                constraints: new { id = "(?!editprofile).*" }

            );

            routes.MapRoute(
                name: "Profile",
                url: "profile",
                defaults: new { controller = "Profile", action = "UserProfile" }
            );

            routes.MapRoute(
                name: "Post",
                url: "post/{id}",
                defaults: new { controller = "Posts", action = "PostDetails" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
