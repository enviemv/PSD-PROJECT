<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="GymMe.Pages.Account.Register" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label>
            <asp:TextBox ID="Username" runat="server"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="Email" runat="server"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
            <asp:Label ID="Label4" runat="server" Text="Confirm Password:"></asp:Label>
            <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:Label ID="Label5" runat="server" Text="Gender:"></asp:Label>
            <asp:DropDownList ID="Gender" runat="server">
                <asp:ListItem Text="Select Gender" Value="" />
                <asp:ListItem Text="Male" Value="Male" />
                <asp:ListItem Text="Female" Value="Female" />
            </asp:DropDownList>
            <asp:Label ID="Label6" runat="server" Text="Date of Birth:"></asp:Label>
            <asp:TextBox ID="DOB" runat="server"></asp:TextBox>
            <asp:Button ID="RegisterButton" runat="server" Text="Register" OnClick="RegisterButton_Click" />
            <asp:Label ID="ErrorMessage" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
