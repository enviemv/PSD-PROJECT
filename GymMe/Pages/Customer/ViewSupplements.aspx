<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewSupplements.aspx.cs" Inherits="GymMe.Pages.Customer.ViewSupplements" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Supplements</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Supplement Name" />
                    <asp:BoundField DataField="ExpiryDate" HeaderText="Expiry Date" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                    <asp:BoundField DataField="SupplementType.TypeName" HeaderText="Type" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
