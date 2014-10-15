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
        </div>
    </div>
    </form>
</body>
</html>
