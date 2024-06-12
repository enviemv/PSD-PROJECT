using System;
using System.Linq;
using System.Web.UI.WebControls;
using GymMe.Models;

namespace GymMe.Admin
{
    public partial class ManageSupplement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                Response.Redirect("~/Pages/Account/Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadSupplements();
            }
        }

        private void LoadSupplements()
        {
            using (var context = new ApplicationDbContext())
            {
                var supplements = context.Supplements.Select(s => new
                {
                    s.SupplementID,
                    s.SupplementName,
                    SupplementExpiryDate = s.SupplementExpiryDate,  // Correct property name
                    s.SupplementPrice,
                    s.SupplementType.SupplementTypeName
                }).ToList();

                SupplementsGridView.DataSource = supplements;
                SupplementsGridView.DataBind();
            }
        }
    }
}
