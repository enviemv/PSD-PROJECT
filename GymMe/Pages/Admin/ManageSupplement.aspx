<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageSupplement.aspx.cs" Inherits="GymMe.Admin.ManageSupplement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Manage Supplements</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Manage Supplements</h2>
    <asp:GridView ID="SupplementsGridView" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="SupplementID" HeaderText="ID" />
            <asp:BoundField DataField="SupplementName" HeaderText="Name" />
            <asp:BoundField DataField="SupplementExpiryDate" HeaderText="Expiry Date" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:BoundField DataField="SupplementPrice" HeaderText="Price" />
            <asp:BoundField DataField="SupplementTypeName" HeaderText="Type" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="InsertButton" runat="server" Text="Insert Supplement" PostBackUrl="~/Pages/Admin/InsertSupplement.aspx" />
</asp:Content>
