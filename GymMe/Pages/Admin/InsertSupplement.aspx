<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="InsertSupplement.aspx.cs" Inherits="GymMe.Admin.InsertSupplement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Insert Supplement</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Insert New Supplement</h2>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger" />

    <asp:Label ID="NameLabel" runat="server" Text="Name:"></asp:Label>
    <asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox><br />

    <asp:Label ID="ExpiryDateLabel" runat="server" Text="Expiry Date:"></asp:Label>
    <asp:TextBox ID="ExpiryDateTextBox" runat="server"></asp:TextBox><br />

    <asp:Label ID="PriceLabel" runat="server" Text="Price:"></asp:Label>
    <asp:TextBox ID="PriceTextBox" runat="server"></asp:TextBox><br />

    <asp:Label ID="TypeIDLabel" runat="server" Text="Type ID:"></asp:Label>
    <asp:TextBox ID="TypeIDTextBox" runat="server"></asp:TextBox><br />

    <asp:Button ID="InsertButton" runat="server" Text="Insert" OnClick="InsertButton_Click" />
</asp:Content>
