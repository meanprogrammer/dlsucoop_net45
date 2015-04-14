<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="True" CodeBehind="RetrievePassword.aspx.cs" Inherits="WebsiteTrial.RetrievePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div runat="server" clientidmode="Static" id="AlertDiv">
                <strong runat="server" clientidmode="Static" id="alertmessage"></strong>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <label>Employee Number</label>
            <asp:TextBox ID="TextBox1" class="form-control input-lg" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="validation-message" Display="Dynamic" ErrorMessage="*" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-12">
            <asp:Button ID="Button1" runat="server" class="btn btn-success" OnClick="Button1_Click"
                Text="Retrieve Password" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
