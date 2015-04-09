<%@ Page Title="" Language="C#" MasterPageFile="~/Administration.Master" AutoEventWireup="true" CodeBehind="PayShareCapitals.aspx.cs" Inherits="WebsiteTrial.PayShareCapitals" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <a href="AdminPage.aspx">Return to Admin</a>
    <h2 class="no-padding">Member's Share Capital</h2>
    <div class="row">
        <div class="col-md-4">
            <label for="EmployeeDropDownList">Employee</label>
            <asp:DropDownList CssClass="form-control" ID="EmployeeDropDownList" runat="server"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" CssClass="validation-message" runat="server" ErrorMessage="Employee is Required." ControlToValidate="EmployeeDropDownList"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-4">
            <label for="ShareCapitalTextBox">Share Capital Amount</label>
            <asp:TextBox ID="ShareCapitalTextBox" CssClass="form-control input-md" ClientIDMode="Static" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Share is required." ControlToValidate="ShareCapitalTextBox" CssClass="validation-message" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ShareCapitalTextBox" CssClass="validation-message" Display="Dynamic" ErrorMessage="Value must be money." Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
        </div>
        <div class="col-md-4">
            &nbsp;
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <asp:Button ID="SaveShareCapitalButton" runat="server" CssClass="btn btn-success btn-size" Text="Save" OnClick="SaveShareCapitalButton_Click" />
            
        </div>
        <div class="col-md-8">
            &nbsp;
        </div>
    </div>
</asp:Content>
