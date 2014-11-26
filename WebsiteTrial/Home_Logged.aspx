<%@ Page Title="" Language="C#" MasterPageFile="~/Account.Master" AutoEventWireup="True" CodeBehind="Home_Logged.aspx.cs" Inherits="WebsiteTrial.Home_Logged" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/modal/jquery-1.8.3.js" type="text/javascript"></script>
    <style type="text/css">
        .style6
        {
            width: 100%;
        }
        .style7
        {
            height: 20px;
        }
        .style8
        {
            width: 196px;
        }
        .style10
        {
            font-size: 18pt;
        }
        .style12
        {
            font-size: 18pt;
            color: #333333;
        }
    .style13
    {
    }
    .style14
    {
        width: 463px;
    }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#viewprintable').click(function () {
                var id = $('#IDHiddenField').val();
                window.open("Report.aspx?id="+id, "_blank", "toolbar=no, scrollbars=yes, resizable=no");
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="style12"><strong style="color: #333333">Welcome, </strong> 
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
</p>
<div class="panel panel-success">
  <div class="panel-heading">Employee's Information</div>
  <div class="panel-body">
    <table class="style6">
        <tr>
            <td rowspan="9" class="style8">
                <asp:Image ID="Image2" runat="server" Height="176px" ImageAlign="AbsMiddle" />
            </td>
            <td> </td>
        </tr>
        <tr>
            <td class="style7">
                Emp #:
                <asp:Label ID="lblEmpNo" runat="server"></asp:Label>
            </td>
            <td class="style7">
                </td>
        </tr>
        <tr>
            <td class="style7">
                Lastname:
                <asp:Label ID="LastNameLabel" runat="server"></asp:Label>
&nbsp;Firstname:
                <asp:Label ID="FirstNameLabel" runat="server"></asp:Label>
&nbsp;MI:
                <asp:Label ID="MILabel" runat="server"></asp:Label>
            </td>
            <td class="style7">
                </td>
        </tr>
        <tr>
            <td>
                Email Address:
                <asp:Label ID="lblEmail" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                College:
                <asp:Label ID="lblCollege" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Department:
                <asp:Label ID="lblDepartment" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Member Status:
                <asp:Label ID="lblMemberStatus" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Date Hired:
                <asp:Label ID="lblDateHired" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Mobile Number:
                <asp:Label ID="lblPhoneNumber" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        </table>

          </div>
</div>
<div class="row" style="margin-bottom:10px;">
    <div class="col-md-6"><asp:FileUpload ID="FileUpload1" runat="server" /></div>
    <div class="col-md-6"><asp:Button ID="btnSave" class="btn btn-success" runat="server" onclick="btnSave_Click" 
    Text="Save Image" /></div>
</div>
<div class="panel panel-success">
      <div class="panel-heading">Transaction History</div>
  <div class="panel-body">
    <asp:Panel ID="Panel2" runat="server">
        <table class="style6">
            <tr>
                <td class="style13">
                    Transactions:</td>
                <td class="style14">
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style13">
                    &nbsp;</td>
                <td class="style14">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style13" colspan="3">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <strong style="color: #333333">
                            <asp:Panel ID="Panel1" runat="server">
                                <table class="style6">
                                    <tr>
                                        <td class="style13">
                                            Maker:</td>
                                        <td class="style14">
                                            <strong style="color: #333333">
                                            <asp:Label ID="Maker" runat="server" Text="Label"></asp:Label>
                                            </strong>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="style13">
                                            Co Maker:<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            </asp:UpdatePanel>
                                        </td>
                                        <td class="style14">
                                            <asp:Label ID="CoMaker1" runat="server" Text="Label"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="style13">
                                            Co Maker 2:</td>
                                        <td class="style14">
                                            <asp:Label ID="CoMaker2" runat="server" Text="Label"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="style13">
                                            Type Of Loan:</td>
                                        <td class="style14">
                                            <asp:Label ID="TypeOfLoan" runat="server" Text="Label"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="style13">
                                            Reason:</td>
                                        <td class="style14">
                                            <asp:Label ID="Reason" runat="server" Text="Label"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="style13">
                                            Amount:</td>
                                        <td class="style14">
                                            <asp:Label ID="Amount" runat="server" Text="Label"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="style13">
                                            No Of Months:</td>
                                        <td class="style14">
                                            <asp:Label ID="Months" runat="server" Text="Label"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="style13">
                                            Date Approved:</td>
                                        <td class="style14">
                                            <asp:Label ID="DateApproved" runat="server" Text="Label"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="style13">
                                            Date Due:</td>
                                        <td class="style14">
                                            <asp:Label ID="DateDue" runat="server" Text="Label"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="style13">
                                            &nbsp;</td>
                                        <td class="style14">
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="style13" colspan="2">
                                            <asp:Label ID="Label1" runat="server" Font-Size="X-Small" ForeColor="Red" 
                                                Text="This transaction is not yet confirmed. Please check you email for the confirmation link." 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            </strong>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="DropDownList1" 
                                EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                <br />
                </td>
            </tr>
        </table>
    </asp:Panel>
    </div>
    </div>
        <div id="divider">
            <h2 class="style10">&nbsp;</h2>
        </div>
        <a id="viewprintable" style="cursor:pointer;">View Printable Version</a>
    <asp:HiddenField ID="IDHiddenField" runat="server" ClientIDMode="Static" />
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPlaceHolder3">
      </asp:Content>

