using System.Web.Routing;

namespace GymMe
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.Ignore("{resource}.axd/{*pathInfo}");

            routes.MapPageRoute("DefaultRoute", "", "~/Default.aspx");
            // Add additional routes as needed
        }
    }
}
