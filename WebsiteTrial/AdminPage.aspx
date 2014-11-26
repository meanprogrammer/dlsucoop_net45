<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="AdminPage.aspx.cs" Inherits="WebsiteTrial.AdminPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
    <div class="container">
        <asp:Label ID="Label1" runat="server" Text="Credit Committee "></asp:Label>
        <br />
        <br />
        Loan approval.<br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Unconfirmed Users:"></asp:Label>
    
    <asp:GridView ID="GVLoan" runat="server" Height="112px" Width="409px" 
        CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" BorderColor="Yellow" BorderStyle="Dashed" 
            Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
    <br />
    <asp:Label ID="Label3" runat="server" 
        Text="Expected Due Date if Approved Today: "></asp:Label>
    <asp:TextBox ID="tbDue" runat="server" AutoPostBack="True" 
        ReadOnly="True" Width="186px" CssClass="form-control input-md"></asp:TextBox>
    <br />
    <asp:DropDownList ID="DDTrans" runat="server" AutoPostBack="True" Height="34px" 
        onselectedindexchanged="DDTrans_SelectedIndexChanged" Width="256px" 
        CssClass="form-control">
    </asp:DropDownList>
    <asp:Label ID="lblStatus" runat="server"></asp:Label>
    <br />
    <asp:GridView ID="UnapprovedLoanGridView" runat="server" 
        AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
        onrowcommand="UnapprovedLoanGridView_RowCommand" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="TransactionID" />
            <asp:BoundField DataField="EmpNo" HeaderText="EmpNo" />
            <asp:BoundField DataField="TypeOfLoan" HeaderText="TypeOfLoan" />
            <asp:BoundField DataField="Reason" HeaderText="Reason" />
            <asp:BoundField DataField="Amount" HeaderText="Amount" />
            <asp:BoundField DataField="NoOfMonths" HeaderText="NoOfMonths" />
            <asp:BoundField DataField="CoMakerEmpNo" HeaderText="CoMakerEmpNo" />
            <asp:BoundField DataField="CoMaker2EmpNo" HeaderText="CoMaker2EmpNo" />
            <asp:ButtonField ButtonType="Button" CommandName="Approve" Text="Approve" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:TextBox ID="ReasonTextbox" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:ButtonField ButtonType="Button" CommandName="Decline" Text="Decline" />
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
    <br />
    <asp:Button ID="btnTrans" runat="server" Height="29px" onclick="btnTrans_Click" 
        Text="Approve" Width="155px" CssClass="btn btn-success" />
    <br />
    <br />
    <asp:Button ID="SendDeficitButton" runat="server" 
        onclick="SendDeficitButton_Click" Text="Send Deficit Email" 
        CssClass="btn btn-success" />
    <asp:Button ID="PaymentButton" runat="server" onclick="PaymentButton_Click" 
        Text="Payment" CssClass="btn btn-success" />
    <asp:HyperLink ID="HyperLink1" CssClass="btn btn-default btn-md" NavigateUrl="~/ShareCapitals.aspx" runat="server">Share Capitals</asp:HyperLink>
&nbsp;<br />
</div>
    </form>
</body>
</html>
