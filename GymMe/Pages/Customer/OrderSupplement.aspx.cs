using System;
using System.Linq;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using GymMe.Models;

namespace GymMe.Customer
{
    public partial class OrderSupplement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated || User.IsInRole("Admin"))
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
                    s.SupplementExpiryDate,
                    s.SupplementPrice,
                    s.SupplementType.SupplementTypeName
                }).ToList();

                SupplementsGridView.DataSource = supplements;
                SupplementsGridView.DataBind();
            }
        }

        protected void OrderButton_Click(object sender, EventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                var userId = User.Identity.GetUserId();
                var user = context.Users.Find(userId);

                foreach (GridViewRow row in SupplementsGridView.Rows)
                {
                    var checkBox = (CheckBox)row.FindControl("SelectCheckBox");
                    if (checkBox != null && checkBox.Checked)
                    {
                        var supplementId = int.Parse(SupplementsGridView.DataKeys[row.RowIndex].Value.ToString()); // Corrected line
                        var quantityTextBox = (TextBox)row.FindControl("QuantityTextBox");
                        int quantity;
                        if (int.TryParse(quantityTextBox.Text, out quantity) && quantity > 0)
                        {
                            var cart = new MsCart
                            {
                                UserID = int.Parse(userId), // Corrected line
                                SupplementID = supplementId,
                                Quantity = quantity
                            };

                            context.Carts.Add(cart);
                        }
                    }
                }

                context.SaveChanges();
            }
        }

        protected void CheckoutButton_Click(object sender, EventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                var userId = User.Identity.GetUserId();
                var user = context.Users.Find(userId);

                var cartItems = context.Carts.Where(c => c.UserID == int.Parse(userId)).ToList();

                var transactionHeader = new TransactionHeader
                {
                    UserID = int.Parse(userId), // Corrected line
                    TransactionDate = DateTime.Now,
                    Status = "Unhandled"
                };

                context.TransactionHeaders.Add(transactionHeader);
                context.SaveChanges();

                foreach (var cartItem in cartItems)
                {
                    var transactionDetail = new TransactionDetail
                    {
                        TransactionID = transactionHeader.TransactionID,
                        SupplementID = cartItem.SupplementID,
                        Quantity = cartItem.Quantity
                    };

                    context.TransactionDetails.Add(transactionDetail);
                    context.Carts.Remove(cartItem);
                }

                context.SaveChanges();

                Response.Redirect("~/Pages/Customer/History.aspx");
            }
        }

        protected void ClearCartButton_Click(object sender, EventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                var userId = User.Identity.GetUserId();
                var user = context.Users.Find(userId);

                var cartItems = context.Carts.Where(c => c.UserID == int.Parse(userId)).ToList();

                foreach (var cartItem in cartItems)
                {
                    context.Carts.Remove(cartItem);
                }

                context.SaveChanges();
            }
        }
    }
}
