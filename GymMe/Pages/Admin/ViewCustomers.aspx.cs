using System;
using System.Linq;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using GymMe.Models;

namespace GymMe.Admin
{
    public partial class ViewCustomers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                Response.Redirect("~/Pages/Account/Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadCustomers();
            }
        }

        private void LoadCustomers()
        {
            using (var context = new ApplicationDbContext())
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var customerRoleId = roleManager.FindByName("Customer").Id;

                var customers = context.Users
                    .Where(u => u.Roles.Any(r => r.RoleId == customerRoleId))
                    .Select(u => new
                    {
                        u.UserName,
                        u.UserEmail,
                        u.DateOfBirth,
                        u.Gender
                    }).ToList();

                CustomersGridView.DataSource = customers;
                CustomersGridView.DataBind();
            }
        }
    }
}
