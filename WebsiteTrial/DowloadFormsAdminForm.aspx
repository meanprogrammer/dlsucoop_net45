<%@ Page Title="" Language="C#" MasterPageFile="~/Administration.Master" AutoEventWireup="true" CodeBehind="DowloadFormsAdminForm.aspx.cs" Inherits="WebsiteTrial.DowloadFormsAdminForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <a href="DownloadFormsAdmin.aspx">Return to list</a>
    <h2 class="no-padding">Downloadable Form</h2>
    <div class="row">
        <div class="col-md-6">
            <label>Form Text</label>
            <asp:TextBox ID="FormTextTextBox" runat="server" CssClass="form-control input-md"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="FormTextTextBox"></asp:RequiredFieldValidator>

        </div>
        <div class="col-md-6">
            <label>Form Url</label>
            <asp:TextBox ID="FormUrlTextBox" runat="server" CssClass="form-control input-md"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="FormUrlTextBox"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Button ID="SaveButton" runat="server" Text="Save" CssClass="btn btn-md btn-success btn-size" OnClick="SaveButton_Click" />
        </div>
    </div>
</asp:Content>
