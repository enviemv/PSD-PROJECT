using System;
using System.Web.Security;

namespace GymMe.Pages.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            if (Membership.ValidateUser(Username.Text, Password.Text))
            {
                FormsAuthentication.SetAuthCookie(Username.Text, RememberMe.Checked);
                Response.Redirect("~/Home.aspx");
            }
            else
            {
                FailureText.Text = "Invalid username or password.";
            }
        }
    }
}
