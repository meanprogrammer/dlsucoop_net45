<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="AdminPage2.aspx.cs" Inherits="WebsiteTrial.AdminPage2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Approved Loan Applications"></asp:Label>
        <asp:GridView ID="gvLoan" runat="server" Height="133px" Width="480px">
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
