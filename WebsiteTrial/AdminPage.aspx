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

            <h2>Loan approval.</h2>

            <h4>Unconfirmed Users</h4>
            <div class="row">
                <div class="col-md-6">
                    <asp:GridView ID="GVLoan" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="EmpNo" HeaderText="Employee No.">
                                <ItemStyle Width="200px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DateRegistered" HeaderText="Date Registered">
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                        </Columns>
                        <SelectedRowStyle BorderColor="Yellow" BorderStyle="Dashed" />
                    </asp:GridView>
                </div>
                <div class="col-md-6">
                    &nbsp;
                </div>
            </div>
            <br />
            <asp:Label ID="Label3" runat="server"
                Text="Expected Due Date if Approved Today: " Visible="False"></asp:Label>
            <asp:TextBox ID="tbDue" runat="server" AutoPostBack="True"
                ReadOnly="True" Width="186px" CssClass="form-control input-md" Visible="False"></asp:TextBox>
            <br />
            <asp:DropDownList ID="DDTrans" runat="server" AutoPostBack="True" Height="34px"
                OnSelectedIndexChanged="DDTrans_SelectedIndexChanged" Width="256px"
                CssClass="form-control" Visible="False">
            </asp:DropDownList>
            <asp:Label ID="lblStatus" runat="server"></asp:Label>
            <br />
            <h4>Unapproved Loans</h4>
            <div class="row"><div class="col-md-12">
            
            <asp:GridView ID="UnapprovedLoanGridView" runat="server"
                AutoGenerateColumns="False"
                OnRowCommand="UnapprovedLoanGridView_RowCommand" CssClass="table table-striped table-bordered" EmptyDataText="No Loans to approve.">
                <Columns>
                    <asp:BoundField DataField="TransactionID" HeaderText="TransactionID" />
                    <asp:BoundField DataField="EmpNo" HeaderText="EmpNo" />
                    <asp:BoundField DataField="TypeOfLoan" HeaderText="TypeOfLoan" />
                    <asp:BoundField DataField="Reason" HeaderText="Reason" />
                    <asp:BoundField DataField="Amount" HeaderText="Amount" />
                    <asp:BoundField DataField="NoOfMonths" HeaderText="NoOfMonths" />
                    <asp:BoundField DataField="CoMakerEmpNo" HeaderText="CoMakerEmpNo" />
                    <asp:BoundField DataField="CoMaker2EmpNo" HeaderText="CoMaker2EmpNo" />
                    <asp:ButtonField ButtonType="Button" CommandName="Approve" Text="Approve">
                        <ControlStyle CssClass="btn btn-primary btn-md" />
                    </asp:ButtonField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:TextBox ID="ReasonTextbox" runat="server"></asp:TextBox>
                        </ItemTemplate>
                        <ControlStyle CssClass="form-control input-md" Width="200px" />
                    </asp:TemplateField>
                    <asp:ButtonField ButtonType="Button" CommandName="Decline" Text="Decline">
                        <ControlStyle CssClass="btn btn-md btn-danger" />
                    </asp:ButtonField>
                </Columns>
            </asp:GridView>
                </div></div>
            <br />
            <!--
    <asp:Button ID="btnTrans" runat="server" Height="29px" onclick="btnTrans_Click" 
        Text="Approve" Width="155px" CssClass="btn btn-success" />-->
            <br />
            <br />
            <asp:Button ID="SendDeficitButton" runat="server"
                OnClick="SendDeficitButton_Click" Text="Send Deficit Email"
                CssClass="btn btn-success" />
            <asp:Button ID="PaymentButton" runat="server" OnClick="PaymentButton_Click"
                Text="Payment" CssClass="btn btn-success" />
            <asp:HyperLink ID="HyperLink1" CssClass="btn btn-default btn-md" NavigateUrl="~/PayShareCapitals.aspx" runat="server">Share Capitals</asp:HyperLink>
            &nbsp;<br />
        </div>
    </form>
</body>
</html>
