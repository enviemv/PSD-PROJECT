using System;
using System.Linq;
using GymMe.Models;

namespace GymMe.Admin
{
    public partial class UpdateSupplement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                Response.Redirect("~/Pages/Account/Login.aspx");
            }

            if (!IsPostBack)
            {
                int supplementId = int.Parse(Request.QueryString["SupplementID"]);
                LoadSupplement(supplementId);
            }
        }

        private void LoadSupplement(int supplementId)
        {
            using (var context = new ApplicationDbContext())
            {
                var supplement = context.Supplements.FirstOrDefault(s => s.SupplementID == supplementId);
                if (supplement != null)
                {
                    NameTextBox.Text = supplement.SupplementName;
                    ExpiryDateTextBox.Text = supplement.SupplementExpiryDate.ToString("yyyy-MM-dd");
                    PriceTextBox.Text = supplement.SupplementPrice.ToString();
                    TypeIDTextBox.Text = supplement.SupplementTypeID.ToString();
                }
            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                int supplementId = int.Parse(Request.QueryString["SupplementID"]);
                using (var context = new ApplicationDbContext())
                {
                    var supplement = context.Supplements.FirstOrDefault(s => s.SupplementID == supplementId);
                    if (supplement != null)
                    {
                        supplement.SupplementName = NameTextBox.Text;
                        supplement.SupplementExpiryDate = DateTime.Parse(ExpiryDateTextBox.Text);
                        supplement.SupplementPrice = decimal.Parse(PriceTextBox.Text);
                        supplement.SupplementTypeID = int.Parse(TypeIDTextBox.Text);

                        context.SaveChanges();

                        Response.Redirect("~/Pages/Admin/ManageSupplement.aspx");
                    }
                }
            }
        }
    }
}
