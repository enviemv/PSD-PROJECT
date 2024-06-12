using System;
using System.Web.Security;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GymMe.Pages.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            MembershipCreateStatus status;
            Membership.CreateUser(Username.Text, Password.Text, Email.Text, null, null, true, out status);

            if (status == MembershipCreateStatus.Success)
            {
                FormsAuthentication.SetAuthCookie(Username.Text, createPersistentCookie: false);
                Response.Redirect("~/Home.aspx");
            }
            else
            {
                ErrorMessage.Text = GetErrorMessage(status);
            }
        }

        private string GetErrorMessage(MembershipCreateStatus status)
        {
            switch (status)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "Username already exists.";
                case MembershipCreateStatus.DuplicateEmail:
                    return "A username for that email address already exists.";
                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid.";
                case MembershipCreateStatus.InvalidEmail:
                    return "The email address provided is invalid.";
                case MembershipCreateStatus.InvalidAnswer:
                    return "The security answer provided is invalid.";
                case MembershipCreateStatus.InvalidQuestion:
                    return "The security question provided is invalid.";
                case MembershipCreateStatus.InvalidUserName:
                    return "The username provided is invalid.";
                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error.";
                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled.";
                default:
                    return "An unknown error occurred.";
            }
        }
    }
}
