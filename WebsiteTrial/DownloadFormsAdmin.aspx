<%@ Page Title="" Language="C#" MasterPageFile="~/Administration.Master" AutoEventWireup="true" CodeBehind="DownloadFormsAdmin.aspx.cs" Inherits="WebsiteTrial.DownloadFormsAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <a href="AdminPage.aspx">Return to Main</a>
    <h2 class="no-padding">Downloadable Forms</h2>
    <div class="row">
        <div class="com-md-12">
            <asp:GridView ID="DownlodablesGridView" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered">
                <Columns>
                    <asp:HyperLinkField DataNavigateUrlFields="RecordID" DataNavigateUrlFormatString="DowloadFormsAdminForm.aspx?id={0}" Text="Edit" />
                    <asp:BoundField DataField="FormText" HeaderText="Form" />
                    <asp:BoundField DataField="FormUrl" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <a href="DowloadFormsAdminForm.aspx" class="btn btn-success btn-md btn-size">Add New</a>
        </div>
    </div>
</asp:Content>
