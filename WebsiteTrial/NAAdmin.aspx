<%@ Page Title="" Language="C#" MasterPageFile="~/Administration.Master" AutoEventWireup="true" CodeBehind="NAAdmin.aspx.cs" Inherits="WebsiteTrial.NAAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="GridView1" CssClass="table table-bordered table-striped" runat="server" EmptyDataText="No news and announcement." AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Title" ItemStyle-Width="20%" >
<ItemStyle Width="20%"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Content" HeaderText="Content" />
            <asp:HyperLinkField DataNavigateUrlFields="RecordID" DataNavigateUrlFormatString="~/NAAdminForm.aspx?id={0}" Text="Edit" />
        </Columns>
    </asp:GridView>
    <div class="row">
        <div class="col-md-12">
            <a href="NAAdminForm.aspx" class="btn btn-default">Add News/Announcement</a>
        </div>
    </div>
</asp:Content>
