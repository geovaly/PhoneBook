using System.Web.Mvc;
using System.Web.Routing;

namespace InterviewTest.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "",
                url: "PhoneBook",
                defaults: new { controller = "PhoneBook", action = "Index" }
            );

            routes.MapRoute(
                name: "",
                url: "PhoneBook/{action}",
                defaults: new { controller = "PhoneBook", action = "Index" }
            );
        }
    }
}
