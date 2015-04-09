<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Downloads.aspx.cs" Inherits="WebsiteTrial.Downloads" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h2>Downloadable forms</h2>

    <asp:GridView ID="DownlodablesGridView" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered">
        <Columns>
            <asp:BoundField DataField="FormText" HeaderText="Form" />
            <asp:HyperLinkField DataNavigateUrlFields="FormUrl" Text="pdf" />
        </Columns>
    </asp:GridView>
<%--<table class="table table-bordered table-striped">
        <thead>
            <tr>
                <th>Forms</th>
                <th>Download</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>Biodata</td>
                <td><a href="http://www.dlsud.edu.ph/Offices/DLSUDDC/assets/docs/BIODATA.pdf" target="_new">pdf</a></td>
            </tr>
            <tr>
                <td>Authority for Salary Deduction</td>
                <td><a href="http://www.dlsud.edu.ph/Offices/DLSUDDC/assets/docs/DLSU-D DC_Authority_for_Salary_Deduction.pdf" target="_new">pdf</a></td>
            </tr>
            <tr>
                <td>Brochure</td>
                <td><a href="http://www.dlsud.edu.ph/Offices/DLSUDDC/assets/docs/brochure.pdf" target="_new">pdf</a></td>
            </tr>
            <tr>
                <td>DLSU-D DC Data Form</td>
                <td><a href="http://www.dlsud.edu.ph/Offices/DLSUDDC/assets/docs/DLSU-D_DC_Data_Form.pdf" target="_new">pdf</a></td>
            </tr>
            <tr>
                <td>DLSU-D FDC Loan Application Form</td>
                <td><a href="http://www.dlsud.edu.ph/Offices/DLSUDDC/assets/docs/DLSU-D_DC_Loan_Application_Form.pdf" target="_new">pdf</a></td>
            </tr>
            <tr>
                <td>DLSU-D Promisory Note</td>
                <td><a href="http://www.dlsud.edu.ph/Offices/DLSUDDC/assets/docs/DLSU-D_DC_Promissory_Note.pdf" target="_new">pdf</a></td>
            </tr>
            <tr>
                <td>DLSU-D FDC Subscription Slip</td>
                <td><a href="http://www.dlsud.edu.ph/Offices/DLSUDDC/assets/docs/DLSU-D_DC_Subscription_Slip.pdf" target="_new">pdf</a></td>
            </tr>
            <tr>
                <td>DLSU-D Withrawal Slip</td>
                <td><a href="http://www.dlsud.edu.ph/Offices/DLSUDDC/assets/docs/DLSU-D_DC_Withdrawal_Slip_for.pdf" target="_new">pdf</a></td>
            </tr>
        </tbody>
    </table>--%>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
