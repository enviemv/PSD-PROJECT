using System;
using System.Web.Profile;
using System.Web.Security;
using System.Web.UI.WebControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GymMe.Pages.Account
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUserProfile();
            }
        }

        protected void LoadUserProfile()
        {
            MembershipUser user = Membership.GetUser(User.Identity.Name);
            if (user != null)
            {
                Username.Text = user.UserName;
                Email.Text = user.Email;

                // Assuming you have custom profile properties
                var profile = ProfileBase.Create(user.UserName);
                Gender.Text = profile.GetPropertyValue("Gender").ToString();
                DOB.Text = profile.GetPropertyValue("DateOfBirth").ToString();
            }
        }

        protected void UpdateProfileButton_Click(object sender, EventArgs e)
        {
            MembershipUser user = Membership.GetUser(User.Identity.Name);
            if (user != null)
            {
                user.Email = Email.Text;
                Membership.UpdateUser(user);

                var profile = ProfileBase.Create(user.UserName);
                profile.SetPropertyValue("Gender", Gender.Text);
                profile.SetPropertyValue("DateOfBirth", DOB.Text);
                profile.Save();
            }
        }

        protected void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            MembershipUser user = Membership.GetUser(User.Identity.Name);
            if (user != null && Membership.ValidateUser(user.UserName, OldPassword.Text))
            {
                user.ChangePassword(OldPassword.Text, NewPassword.Text);
            }
        }
    }
}
