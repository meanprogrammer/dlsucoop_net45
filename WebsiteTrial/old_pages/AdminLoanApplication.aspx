<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLogged.Master" AutoEventWireup="True" CodeBehind="AdminLoanApplication.aspx.cs" Inherits="WebsiteTrial.AdminLoanApplication" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style6
        {
            width: 100%;
        }
    .style7
    {
        width: 107px;
    }
    .style9
    {
        width: 214px;
    }
    .style10
    {
        width: 191px;
    }
    .style11
    {
        width: 145px;
    }
    .style12
    {
        width: 458px;
    }
    .style13
    {
        width: 30px;
    }
    .style15
    {
        width: 13px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label2" runat="server" Text="No Pending Applications" 
    ForeColor="Red" Visible="False"></asp:Label>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<br />
<asp:Panel ID="Panel2" runat="server">
    <table class="style6">
        <tr>
            <td class="style7">
                Search:</td>
            <td class="style9">
                <asp:TextBox ID="TextBox1" runat="server" Width="202px"></asp:TextBox>
            </td>
            <td class="style10">
                <asp:DropDownList ID="DropDownList1" runat="server" 
                Height="25px" Width="144px">
                    <asp:ListItem Value="TransactionID">Transaction ID</asp:ListItem>
                    <asp:ListItem Value="TypeOfLoan">Type Of Loan</asp:ListItem>
                    <asp:ListItem>Amount</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" 
                onclick="Button1_Click" Text="Go" Width="76px" />
            </td>
        </tr>
    </table>
</asp:Panel>
    <br />
    <div>
    <table  cellspacing="0" cellpadding="0" width="100%" style="width: 100%" border="0">
        <tr>
            <td>
<asp:GridView ID="GVLoan" runat="server" Height="100%" Width="100%" 
    CellPadding="4" ForeColor="#333333" style="margin-bottom: 0px" 
                    AutoGenerateSelectButton="True" DataKeyNames="TransactionID" 
                    onselectedindexchanged="GVLoan_SelectedIndexChanged">
    <AlternatingRowStyle BackColor="White" />
    <EditRowStyle BackColor="#7C6F57" />
    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#E3EAEB" />
    <SelectedRowStyle BackColor="#C5BBAF" BorderColor="Yellow" BorderStyle="Dashed" 
        Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#F8FAFA" />
    <SortedAscendingHeaderStyle BackColor="#246B61" />
    <SortedDescendingCellStyle BackColor="#D4DFE1" />
    <SortedDescendingHeaderStyle BackColor="#15524A" />
</asp:GridView>
            </td>
        </tr>
    </table>
    </div>
<asp:Panel ID="Panel1" runat="server" Visible="False">
    <br />
    <table class="style6">
        <tr>
            <td class="style11" colspan="3">
                Selected Transaction:</td>
            <td class="style12">
                <asp:Label ID="lblTransactionID" runat="server" 
                Text="Label"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style13">
                &nbsp;</td>
            <td class="style11" colspan="2">
                Other Details:</td>
            <td class="style12">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style13">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style15">
                Maker</td>
            <td class="style12">
                <asp:Label ID="lblMaker" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style13">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style15">
                CoMaker</td>
            <td class="style12">
                <asp:Label ID="lblCoMaker" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style13">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style15">
                CoMaker2:</td>
            <td class="style12">
                <asp:Label ID="lblCoMaker2" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style13">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style15">
                Reason:</td>
            <td class="style12">
                <asp:Label ID="lblReason" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style13">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style15">
                &nbsp;</td>
            <td class="style12">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style11" colspan="3">
                Due Date:</td>
            <td class="style12">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="tbDue" runat="server" 
                        AutoPostBack="True" Height="21px" ReadOnly="True" Width="186px"></asp:TextBox>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                        Height="25px" ImageUrl="~/images/calendar_icon.jpg" 
                        onclick="ImageButton1_Click" Width="20px" />
                        <asp:Calendar ID="Calendar1" runat="server" 
                        Height="177px" onselectionchanged="Calendar1_SelectionChanged" Visible="False" 
                        Width="197px"></asp:Calendar>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ImageButton1" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="Calendar1" EventName="SelectionChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style11" colspan="3">
                &nbsp;</td>
            <td class="style12">
                <asp:Label ID="lblStatus" runat="server" ForeColor="#009933"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style11" colspan="3">
                &nbsp;</td>
            <td class="style12">
                <asp:Button ID="btnTrans" runat="server" Height="29px" onclick="btnTrans_Click" 
        Text="Approve" Width="155px" />
                <asp:Button ID="btnTrans0" runat="server" Height="29px" 
                    onclick="btnTrans0_Click" Text="Decline" Width="155px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Panel>
<br />
<br />
<br />
<br />
<br />
<br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
