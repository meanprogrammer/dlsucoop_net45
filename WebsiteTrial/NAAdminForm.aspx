<%@ Page Title="" Language="C#" MasterPageFile="~/Administration.Master" AutoEventWireup="true" CodeBehind="NAAdminForm.aspx.cs" Inherits="WebsiteTrial.NAAdminForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>News and Announcement Admin</h3>
    <div class="row">
        <div class="col-md-12">
            <label>Title</label>
            <asp:TextBox ID="TitleTextBox" CssClass="form-control input-md" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            Content
            <asp:TextBox ID="ContentTextBox" CssClass="form-control input-md" runat="server" Columns="60" Rows="10" TextMode="MultiLine"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Button ID="SaveButton" CssClass="btn btn-success btn-size" runat="server" Text="Save" OnClick="SaveButton_Click" />&nbsp;<asp:Button ID="CancelButton" runat="server" CssClass="btn btn-default btn-size" Text="Cancel" />
        </div>
    </div>
</asp:Content>
