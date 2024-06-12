using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;

namespace GymMe
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Uncomment the following line if you have Web API configuration
            // GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
        }
    }
}
