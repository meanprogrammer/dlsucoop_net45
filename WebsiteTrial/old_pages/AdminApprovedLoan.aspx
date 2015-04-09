<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLogged.Master" AutoEventWireup="True" CodeBehind="AdminApprovedLoan.aspx.cs" Inherits="WebsiteTrial.AdminApprovedLoan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style6
        {
            width: 100%;
        }
        .style8
        {
            width: 515px;
        }
        .style9
        {
            width: 121px;
        }
        .style10
        {
            width: 129px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Approved Loan Applications"></asp:Label>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />
    <table class="style6">
        <tr>
            <td>
                Search:
            </td>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Width="233px"></asp:TextBox>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Calendar1" EventName="SelectionChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="style10">
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                    Height="16px" onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                    Width="117px">
                    <asp:ListItem Value="TransactionID">Transaction ID</asp:ListItem>
                    <asp:ListItem Value="DateApproved">Date Approved</asp:ListItem>
                    <asp:ListItem>Date Due</asp:ListItem>
                    <asp:ListItem>EmpNo</asp:ListItem>
                    <asp:ListItem Value="Co Maker">CoMaker</asp:ListItem>
                    <asp:ListItem>Co Maker 2</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td colspan="2">
                <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Go" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9">
                &nbsp;</td>
            <td class="style9">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Calendar ID="Calendar1" runat="server" 
                            onselectionchanged="Calendar1_SelectionChanged" Visible="False">
                        </asp:Calendar>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DropDownList1" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td colspan="2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="7">
<asp:GridView ID="gvLoan" runat="server" CellPadding="4" ForeColor="#333333" 
    GridLines="None" Height="100%" Width="100%" AutoGenerateSelectButton="True" 
                    DataKeyNames="TransactionID" 
                    onselectedindexchanged="gvLoan_SelectedIndexChanged">
    <AlternatingRowStyle BackColor="White" />
    <EditRowStyle BackColor="#7C6F57" />
    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#E3EAEB" />
    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#F8FAFA" />
    <SortedAscendingHeaderStyle BackColor="#246B61" />
    <SortedDescendingCellStyle BackColor="#D4DFE1" />
    <SortedDescendingHeaderStyle BackColor="#15524A" />
</asp:GridView>
            </td>
        </tr>
    </table>
    <asp:Panel ID="Panel1" runat="server">
        <table class="style6">
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style8">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" 
                Text="TransactionID"></asp:Label>
                </td>
                <td class="style8">
                    <asp:Label ID="lblTransactionID" runat="server" 
                Text="Label"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Maker"></asp:Label>
                </td>
                <td class="style8">
                    <asp:Label ID="lblMaker" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="CoMaker"></asp:Label>
                </td>
                <td class="style8">
                    <asp:Label ID="lblCoMaker" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="CoMaker2"></asp:Label>
                </td>
                <td class="style8">
                    <asp:Label ID="lblCoMaker2" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" 
                Text="Type Of Loan"></asp:Label>
                </td>
                <td class="style8">
                    <asp:Label ID="lblTypeOfLoan" runat="server" 
                Text="Label"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Amount"></asp:Label>
                </td>
                <td class="style8">
                    <asp:Label ID="lblAmount" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label9" runat="server" Text="Reason"></asp:Label>
                </td>
                <td class="style8">
                    <asp:Label ID="lblReason" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    No. Of Months</td>
                <td class="style8">
                    <asp:Label ID="lblNoOfMonths" runat="server" 
                Text="Label"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label10" runat="server" 
                Text="DateApproved"></asp:Label>
                </td>
                <td class="style8">
                    <asp:Label ID="lblDateApproved" runat="server" 
                Text="Label"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label11" runat="server" Text="Date Due"></asp:Label>
                </td>
                <td class="style8">
                    <asp:Label ID="lblDateDue" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style8">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style8">
                    <asp:Button ID="Button1" runat="server" 
                Text="Loan Done" onclick="Button1_Click" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
<br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
