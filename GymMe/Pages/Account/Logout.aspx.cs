using System;
using System.Web;
using System.Web.Security;

namespace GymMe.Account
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            HttpContext.Current.Session.Abandon();
            Response.Redirect("~/Pages/Account/Login.aspx");
        }
    }
}
