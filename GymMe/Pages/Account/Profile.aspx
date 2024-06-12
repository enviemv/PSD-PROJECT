<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="GymMe.Pages.Account.Profile" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Profile</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Update Profile</h2>
            <asp:Label ID="UsernameLabel" runat="server" Text="Username: " />
            <asp:TextBox ID="Username" runat="server" ReadOnly="true"></asp:TextBox><br />
            <asp:Label ID="EmailLabel" runat="server" Text="Email: " />
            <asp:TextBox ID="Email" runat="server"></asp:TextBox><br />
            <asp:Label ID="GenderLabel" runat="server" Text="Gender: " />
            <asp:TextBox ID="Gender" runat="server"></asp:TextBox><br />
            <asp:Label ID="DOBLabel" runat="server" Text="Date of Birth: " />
            <asp:TextBox ID="DOB" runat="server"></asp:TextBox><br />
            <asp:Button ID="UpdateProfileButton" runat="server" Text="Update Profile" OnClick="UpdateProfileButton_Click" /><br /><br />

            <h2>Change Password</h2>
            <asp:Label ID="OldPasswordLabel" runat="server" Text="Old Password: " />
            <asp:TextBox ID="OldPassword" runat="server" TextMode="Password"></asp:TextBox><br />
            <asp:Label ID="NewPasswordLabel" runat="server" Text="New Password: " />
            <asp:TextBox ID="NewPassword" runat="server" TextMode="Password"></asp:TextBox><br />
            <asp:Button ID="ChangePasswordButton" runat="server" Text="Change Password" OnClick="ChangePasswordButton_Click" />
        </div>
    </form>
</body>
</html>
