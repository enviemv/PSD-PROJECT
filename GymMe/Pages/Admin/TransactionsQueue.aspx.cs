using System;
using System.Linq;
using System.Web.UI.WebControls;
using GymMe.Models;

namespace GymMe.Admin
{
    public partial class TransactionsQueue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
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
                var transactions = context.TransactionHeaders
                    .Select(t => new
                    {
                        t.TransactionID,
                        UserName = t.User.UserName,
                        t.TransactionDate,
                        t.Status
                    }).ToList();

                TransactionsGridView.DataSource = transactions;
                TransactionsGridView.DataBind();
            }
        }

        protected void TransactionsGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "HandleTransaction")
            {
                int transactionId = Convert.ToInt32(e.CommandArgument);
                HandleTransaction(transactionId);
            }
        }

        private void HandleTransaction(int transactionId)
        {
            using (var context = new ApplicationDbContext())
            {
                var transaction = context.TransactionHeaders.FirstOrDefault(t => t.TransactionID == transactionId);
                if (transaction != null && transaction.Status == "Unhandled")
                {
                    transaction.Status = "Handled";
                    context.SaveChanges();
                }
                LoadTransactions();
            }
        }
    }
}
