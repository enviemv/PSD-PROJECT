using System;
using System.Linq;
using System.Web.Security;
using GymMe.Models;

namespace GymMe.Pages
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var userRole = Roles.IsUserInRole("Admin") ? "Admin" : "Customer";
                UserRoleLabel.Text = $"Current User Role: {userRole}";

                if (userRole == "Admin")
                {
                    using (var context = new ApplicationDbContext())
                    {
                        var customerRole = "Customer";
                        var customers = context.Users
                            .Where(u => Roles.GetRolesForUser(u.UserName).Contains(customerRole))
                            .Select(u => new
                            {
                                u.Id,
                                u.UserName,
                                u.DateOfBirth,
                                u.Gender
                            }).ToList();

                        CustomersGridView.DataSource = customers;
                        CustomersGridView.DataBind();
                    }
                }
            }
        }
    }
}
