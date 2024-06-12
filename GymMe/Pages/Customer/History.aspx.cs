using System;
using System.Linq;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using GymMe.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GymMe.Customer
{
    public partial class History : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Pages/Account/Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadTransactions();
            }
        }

        private void LoadTransactions()
        {
            using (var context = new ApplicationDbContext())
            {
                var userId = User.Identity.GetUserId();
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var user = userManager.FindById(userId);

                if (userManager.IsInRole(userId, "Admin"))
                {
                    var transactions = context.TransactionHeaders.Select(t => new
                    {
                        t.TransactionID,
                        t.TransactionDate,
                        t.Status
                    }).ToList();

                    TransactionsGridView.DataSource = transactions;
                }
                else
                {
                    var transactions = context.TransactionHeaders.Where(t => t.User.Id == userId).Select(t => new
                    {
                        t.TransactionID,
                        t.TransactionDate,
                        t.Status
                    }).ToList();

                    TransactionsGridView.DataSource = transactions;
                }

                TransactionsGridView.DataBind();
            }
        }

        protected void TransactionsGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                int transactionId = Convert.ToInt32(e.CommandArgument);
                LoadTransactionDetails(transactionId);
            }
        }

        private void LoadTransactionDetails(int transactionId)
        {
            using (var context = new ApplicationDbContext())
            {
                var transactionDetails = context.TransactionDetails
                    .Where(td => td.TransactionID == transactionId)
                    .Select(td => new
                    {
                        td.SupplementID,
                        SupplementName = td.Supplement.SupplementName,
                        td.Quantity,
                        td.Supplement.SupplementPrice,
                        OrderDate = td.TransactionHeader.TransactionDate
                    }).ToList();

                TransactionDetailsGridView.DataSource = transactionDetails;
                TransactionDetailsGridView.DataBind();

                TransactionDetailsPanel.Visible = true;
            }
        }
    }
}
