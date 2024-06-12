<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="TransactionsQueue.aspx.cs" Inherits="GymMe.Admin.TransactionsQueue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Transactions Queue</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Transactions Queue</h2>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger" />

    <asp:GridView ID="TransactionsGridView" runat="server" AutoGenerateColumns="False" OnRowCommand="TransactionsGridView_RowCommand">
        <Columns>
            <asp:BoundField DataField="TransactionId" HeaderText="Transaction ID" />
            <asp:BoundField DataField="UserName" HeaderText="User" />
            <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:BoundField DataField="Status" HeaderText="Status" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="HandleButton" runat="server" CommandName="HandleTransaction" CommandArgument='<%# Eval("TransactionId") %>' Text="Handle" Visible='<%# Eval("Status").ToString() == "Unhandled" %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
