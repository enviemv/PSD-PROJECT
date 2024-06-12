using System;
using System.Linq;
using System.Web.UI;
using GymMe.Models;

namespace GymMe.Pages.Customer
{
    public partial class ViewSupplements : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.IsInRole("Customer"))
            {
                Response.Redirect("~/Account/Login.aspx");
            }

            if (!IsPostBack)
            {
                using (var context = new ApplicationDbContext())
                {
                    GridView1.DataSource = context.Supplements.Include("SupplementType").ToList();
                    GridView1.DataBind();
                }
            }
        }
    }
}
