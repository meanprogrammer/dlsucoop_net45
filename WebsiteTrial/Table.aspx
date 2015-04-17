<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Table.aspx.cs" Inherits="WebsiteTrial.Table" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="width:350px;">
            <asp:Button ID="TruncateLoanButton" runat="server" 
                CssClass="btn btn-lg btn-primary btn-block" onclick="TruncateLoanButton_Click" 
                Text="Truncate LoanApplication table" />
            <asp:Button ID="TruncateUnconfirmedLoanButton" runat="server" 
                CssClass="btn btn-lg btn-primary btn-block" onclick="TruncateUnconfirmedLoanButton_Click" 
                Text="Truncate UnconfirmedLoan table" />
                            <asp:Button ID="TruncateMSGSButton" runat="server" 
                CssClass="btn btn-lg btn-primary btn-block"
                Text="Truncate MSGS table" onclick="TruncateMSGSButton_Click" />
                            <asp:Button ID="TruncatePaymentsButton" runat="server" 
                CssClass="btn btn-lg btn-primary btn-block" 
                Text="Truncate Payments table" onclick="TruncatePaymentsButton_Click" />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Delete except me" />
        </div>
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
