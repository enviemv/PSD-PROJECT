using System;
using GymMe.Models;

namespace GymMe.Admin
{
    public partial class InsertSupplement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                Response.Redirect("~/Pages/Account/Login.aspx");
            }
        }

        protected void InsertButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                using (var context = new ApplicationDbContext())
                {
                    var supplement = new MsSupplement
                    {
                        SupplementName = NameTextBox.Text,
                        SupplementExpiryDate = DateTime.Parse(ExpiryDateTextBox.Text),
                        SupplementPrice = decimal.Parse(PriceTextBox.Text),
                        SupplementTypeID = int.Parse(TypeIDTextBox.Text)
                    };

                    context.Supplements.Add(supplement);
                    context.SaveChanges();

                    Response.Redirect("~/Pages/Admin/ManageSupplement.aspx");
                }
            }
        }
    }
}
