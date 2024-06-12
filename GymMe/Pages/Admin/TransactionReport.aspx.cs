using System;
using System.Linq;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using GymMe.Models;

namespace GymMe.Admin
{
    public partial class ViewTransactionReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                Response.Redirect("~/Pages/Account/Login.aspx");
            }

            if (!IsPostBack)
            {
                GenerateReport();
            }
        }

        private void GenerateReport()
        {
            using (var context = new ApplicationDbContext())
            {
                var transactions = context.TransactionHeaders
                    .Select(t => new
                    {
                        t.TransactionID,
                        UserName = t.User.UserName,
                        t.TransactionDate,
                        t.Status,
                        SubTotal = t.TransactionDetails.Sum(td => td.Quantity * td.Supplement.SupplementPrice)
                    }).ToList();

                var dataTable = new DataTable();
                dataTable.Columns.Add("TransactionID", typeof(int));
                dataTable.Columns.Add("UserName", typeof(string));
                dataTable.Columns.Add("TransactionDate", typeof(DateTime));
                dataTable.Columns.Add("Status", typeof(string));
                dataTable.Columns.Add("SubTotal", typeof(decimal));

                foreach (var transaction in transactions)
                {
                    dataTable.Rows.Add(transaction.TransactionID, transaction.UserName, transaction.TransactionDate, transaction.Status, transaction.SubTotal);
                }

                var grandTotal = transactions.Sum(t => t.SubTotal);

                var report = new ReportDocument();
                report.Load(Server.MapPath("~/Reports/SalesReport.rpt"));
                report.SetDataSource(dataTable);

                CrystalReportViewer1.ReportSource = report;
                CrystalReportViewer1.RefreshReport();
            }
        }
    }
}
