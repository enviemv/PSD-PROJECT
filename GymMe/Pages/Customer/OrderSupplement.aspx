<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="OrderSupplement.aspx.cs" Inherits="GymMe.Customer.OrderSupplement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Order Supplements</h2>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger" />

    <asp:GridView ID="SupplementsGridView" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Supplement Name" />
            <asp:BoundField DataField="ExpiryDate" HeaderText="Expiry Date" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
            <asp:BoundField DataField="TypeName" HeaderText="Type" />
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="QuantityTextBox" runat="server" Width="50px"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="OrderButton" runat="server" Text="Order" CommandArgument='<%# Eval("SupplementId") %>' OnClick="OrderButton_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Button ID="ClearCartButton" runat="server" Text="Clear Cart" OnClick="ClearCartButton_Click" />
    <asp:Button ID="CheckoutButton" runat="server" Text="Checkout" OnClick="CheckoutButton_Click" />
</asp:Content>
