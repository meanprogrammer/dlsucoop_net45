<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="NewsAnnoucementView.aspx.cs" Inherits="WebsiteTrial.NewsAnnoucementView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">
            <asp:Label ID="TitleLabel" runat="server" Text="Label" Font-Size="X-Large"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Label ID="ContentLabel" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <a href="Default.aspx" class="btn btn-default btn-md">Return</a>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
