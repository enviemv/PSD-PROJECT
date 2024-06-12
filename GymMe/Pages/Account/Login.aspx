<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GymMe.Pages.Account.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="FailureText" runat="server" ForeColor="Red"></asp:Label>
            <asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label>
            <asp:TextBox ID="Username" runat="server"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
            <asp:CheckBox ID="RememberMe" runat="server" Text="Remember Me" />
            <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" />
            <asp:HyperLink ID="RegisterLink" runat="server" NavigateUrl="~/Account/Register.aspx">Register</asp:HyperLink>
        </div>
    </form>
</body>
</html>
