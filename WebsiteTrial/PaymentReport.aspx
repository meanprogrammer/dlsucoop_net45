<%@ Page Title="" Language="C#" MasterPageFile="~/Administration.Master" AutoEventWireup="true" CodeBehind="PaymentReport.aspx.cs" Inherits="WebsiteTrial.PaymentReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <a href="AdminPage.aspx">Return to Main</a>
    <h2 class="no-padding">Payment Report</h2>
    <div class="row">
        <div class="col-md-6">
            <label>Employee/User ID</label>
            <asp:DropDownList ID="EmpDropDownList" class="form-control" runat="server" AutoPostBack="True"
                OnSelectedIndexChanged="EmpDropDownList_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Select a member." ControlToValidate="EmpDropDownList" CssClass="validation-message"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-6">
            &nbsp;
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:RadioButtonList ID="LoansRadioButtonList" class="form-control" runat="server">
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Select a loan to view report." ControlToValidate="LoansRadioButtonList" CssClass="validation-message" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>

    </div>
    <br />
    <div class="row">
        <div class="col-md-12">
            <asp:Button ID="SearchButton" runat="server" Text="Search" CssClass="btn btn-md btn-primary" OnClick="SearchButton_Click" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <asp:Literal ID="ResultLiteral" runat="server"></asp:Literal>
        </div>
        <div class="col-md-6">
            &nbsp;
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="ReportGridView" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="TransactionID" HeaderText="TransactionID " />
                    <asp:BoundField DataField="LoanType" HeaderText="Loan Type " />
                    <asp:BoundField DataField="Lastname" HeaderText="Lastname " />
                    <asp:BoundField DataField="Firstname" HeaderText="Firstname " />
                    <asp:BoundField DataField="MI" HeaderText="MI " />
                    <asp:BoundField DataField="LoanDate" HeaderText="Loan Date " />
                    <asp:BoundField DataField="LoanAmount" HeaderText="Amount " />
                    <asp:BoundField DataField="PayAmount" HeaderText="Pay Amount " />
                    <asp:BoundField DataField="PayDate" HeaderText="Pay Date" />
                    <asp:BoundField DataField="Balance" HeaderText="Balance " />
                </Columns>
            </asp:GridView>
            </div>
    </div>
</asp:Content>
