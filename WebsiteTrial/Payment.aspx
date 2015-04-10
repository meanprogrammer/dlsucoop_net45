<%@ Page Title="" Language="C#" MasterPageFile="~/Administration.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="WebsiteTrial.Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <a href="AdminPage.aspx">Return to Main</a>
    <h2 class="no-padding">Loan Payment</h2>
    <div class="row">
        <div class="col-md-6">
            <label>Employee</label>
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
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Select a loan to pay." ControlToValidate="LoansRadioButtonList" CssClass="validation-message" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>

    </div>
    <br />
    <div class="row">
        <div class="col-md-6">
            <asp:Literal ID="ResultLiteral" runat="server"></asp:Literal>
        </div>
        <div class="col-md-6">
            &nbsp;
        </div>
    </div>

    <div class="row">
        <div class="col-md-6">
            <label>Payment Amount</label>
            <asp:TextBox ID="PayAmountTextBox" class="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="PayAmountTextBox" CssClass="validation-message" Display="Dynamic" ErrorMessage="Amount is required."></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="PayAmountTextBox" CssClass="validation-message" Display="Dynamic" ErrorMessage="Must be money." Operator="DataTypeCheck" Type="Currency"></asp:CompareValidator>
        </div>
        <div class="col-md-6">
            &nbsp;
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <label>Note</label>
            <asp:TextBox ID="NoteTextBox" runat="server" class="form-control"
                TextMode="MultiLine"></asp:TextBox>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-12">
            <asp:Button ID="PayButton" runat="server" class="btn btn-success" OnClick="PayButton_Click" Text="Save Payment"
                />
        </div>
    </div>

    <br />
    <br />

</asp:Content>
