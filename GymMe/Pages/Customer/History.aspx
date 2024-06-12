<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="GymMe.Customer.History" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Transaction History</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Transaction History</h2>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger" />

    <asp:GridView ID="TransactionsGridView" runat="server" AutoGenerateColumns="False" OnRowCommand="TransactionsGridView_RowCommand">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" />
            <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:BoundField DataField="Status" HeaderText="Status" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="ViewDetailsButton" runat="server" CommandName="ViewDetails" CommandArgument='<%# Eval("TransactionID") %>' Text="View Details" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Panel ID="TransactionDetailsPanel" runat="server" Visible="False">
        <h3>Transaction Details</h3>
        <asp:GridView ID="TransactionDetailsGridView" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="SupplementID" HeaderText="Supplement ID" />
                <asp:BoundField DataField="SupplementName" HeaderText="Supplement Name" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                <asp:BoundField DataField="SupplementPrice" HeaderText="Price" DataFormatString="{0:C}" />
                <asp:BoundField DataField="OrderDate" HeaderText="Order Date" DataFormatString="{0:yyyy-MM-dd}" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
</asp:Content>
