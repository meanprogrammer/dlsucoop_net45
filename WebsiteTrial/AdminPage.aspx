<%@ Page Title="" Language="C#" MasterPageFile="~/Administration.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="WebsiteTrial.AdminPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
        <div class="row">
            <div class="col-md-12">

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
                        <asp:HyperLinkField DataNavigateUrlFields="TransactionID" DataNavigateUrlFormatString="ViewAttachment.aspx?transId={0}" HeaderText="Attachment" Text="Attachment" Target="_blank" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <br />
        <!--
    <asp:Button ID="btnTrans" runat="server" Height="29px" onclick="btnTrans_Click" 
        Text="Approve" Width="155px" CssClass="btn btn-success" />-->
        <br />
        <br />
        <asp:Button ID="SendDeficitButton" runat="server"
            OnClick="SendDeficitButton_Click" Text="Deficit Email"
            CssClass="btn btn-success" />
        <asp:Button ID="PaymentButton" runat="server" OnClick="PaymentButton_Click"
            Text="Payment" CssClass="btn btn-success btn-size" />
        <asp:HyperLink ID="HyperLink1" CssClass="btn btn-default btn-md" NavigateUrl="~/PayShareCapitals.aspx" runat="server">Share Capitals</asp:HyperLink>
        &nbsp;
        <asp:HyperLink ID="HyperLink2" CssClass="btn btn-default btn-md btn-size" NavigateUrl="~/DownloadFormsAdmin.aspx" runat="server">Forms</asp:HyperLink>
        <asp:HyperLink ID="HyperLink3" CssClass="btn btn-default btn-md" NavigateUrl="~/NAAdmin.aspx" runat="server">News and Announcement</asp:HyperLink>
        <br />
    </div>
</asp:Content>
