using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using GymMe.Models;

namespace GymMe
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Pages/Account/Login.aspx");
            }
            else
            {
                PopulateNavigationBar();
            }
        }

        private void PopulateNavigationBar()
        {
            using (var context = new ApplicationDbContext())
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = userManager.FindById(HttpContext.Current.User.Identity.GetUserId());

                if (user != null)
                {
                    var roles = user.Roles
                        .Join(context.Roles, ur => ur.RoleId, r => r.Id, (ur, r) => r.Name)
                        .ToList();

                    string userRole = roles.FirstOrDefault();

                    MainMenu.Items.Clear();

                    if (userRole == "Admin")
                    {
                        MainMenu.Items.Add(new MenuItem { Text = "Home", NavigateUrl = "~/Pages/Home.aspx" });
                        MainMenu.Items.Add(new MenuItem { Text = "Manage Supplement", NavigateUrl = "~/Pages/Admin/ManageSupplement.aspx" });
                        MainMenu.Items.Add(new MenuItem { Text = "Order Queue", NavigateUrl = "~/Pages/Admin/OrderQueue.aspx" });
                        MainMenu.Items.Add(new MenuItem { Text = "Profile", NavigateUrl = "~/Pages/Account/Profile.aspx" });
                        MainMenu.Items.Add(new MenuItem { Text = "Transaction Report", NavigateUrl = "~/Pages/Admin/TransactionReport.aspx" });
                    }
                    else if (userRole == "Customer")
                    {
                        MainMenu.Items.Add(new MenuItem { Text = "Order Supplement", NavigateUrl = "~/Pages/Customer/OrderSupplement.aspx" });
                        MainMenu.Items.Add(new MenuItem { Text = "History", NavigateUrl = "~/Pages/Customer/History.aspx" });
                        MainMenu.Items.Add(new MenuItem { Text = "Profile", NavigateUrl = "~/Pages/Account/Profile.aspx" });
                    }

                    MainMenu.Items.Add(new MenuItem { Text = "Logout", NavigateUrl = "~/Pages/Account/Logout.aspx" });
                }
            }
        }
    }
}
