<%@ Page Title="" Language="C#" MasterPageFile="~/Account.Master" AutoEventWireup="true" CodeBehind="UserShareCapital.aspx.cs" Inherits="WebsiteTrial.UserShareCapital" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Share Capital</h3>
    <div class="row">
        <div class="col-md-12">
            <label for="TextBox1">Share Capital</label>
            <asp:TextBox ID="TextBox1" ClientIDMode="Static" runat="server" CssClass="form-control input-md"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary btn-md" Text="Save" OnClick="Button1_Click" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
