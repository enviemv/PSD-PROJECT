<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewCustomers.aspx.cs" Inherits="GymMe.Admin.ViewCustomers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>View Customers</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Customers</h2>
    <asp:GridView ID="CustomersGridView" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="UserName" HeaderText="User Name" />
            <asp:BoundField DataField="UserEmail" HeaderText="Email" />
            <asp:BoundField DataField="DateOfBirth" HeaderText="Date of Birth" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:BoundField DataField="Gender" HeaderText="Gender" />
        </Columns>
    </asp:GridView>
</asp:Content>
