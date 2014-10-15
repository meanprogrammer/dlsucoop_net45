<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendDeficitEmail.aspx.cs" Inherits="WebsiteTrial.SendDeficitEmail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <title></title>
    <link href="css/jquery-ui-1.9.2.custom.min.css" rel="stylesheet" type="text/css" />
    <script src="js/modal/jquery-1.8.3.js" type="text/javascript"></script>
    <script src="js/modal/jquery-ui-1.9.2.custom.min.js" type="text/javascript"></script>
    <script>
        $(document).ready(function () {
            $('#AsOfDateTextBox').datepicker({ dateFormat: "mm/dd/yy" });
            $('#DeadlineTextBox').datepicker();
        });
    </script>
    <style type="text/css">
        .style1
        {
            width: 9px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Send Deficit Email</h1>
        <table class="table table-override" style="width:600px !important;">
            <tr>
                <td>Select User</td>
                <td>
                    <asp:DropDownList ID="UserDropDownList" class="form-control" runat="server">
                    </asp:DropDownList>
                </td>
                <td></td>
                <td></td>
                <td class="style1">&nbsp;</td>
            </tr>
            <tr>
                <td>Amount in Words:</td>
                <td colspan="3">
                    <asp:TextBox ID="AmountWordsTextBox" CssClass="form-control input-md" runat="server"></asp:TextBox>
                </td>
                <td class="style1">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="AmountWordsTextBox" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Amount:</td>
                <td colspan="3">
                    <asp:TextBox ID="AmountTextBox" CssClass="form-control input-md" runat="server"></asp:TextBox>
                </td>
                <td class="style1">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="AmountTextBox" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Deduction For</td>
                <td colspan="3">
                    <asp:TextBox ID="DeductionForTextbox" CssClass="form-control input-md" runat="server"></asp:TextBox>
                </td>
                <td class="style1">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="DeductionForTextbox" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>As Of Date</td>
                <td colspan="3">
                    <asp:TextBox ID="AsOfDateTextBox" CssClass="form-control input-md" runat="server" ClientIDMode="Static"></asp:TextBox>
                </td>
                <td class="style1">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="AsOfDateTextBox" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Deadline</td>
                <td colspan="3">
                    <asp:TextBox ID="DeadlineTextBox" CssClass="form-control input-md" runat="server" ClientIDMode="Static"></asp:TextBox>
                </td>
                <td class="style1">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="DeadlineTextBox" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <asp:Button ID="PreviewButton" runat="server" class="btn btn-success" Text="Preview" 
            onclick="PreviewButton_Click" />
        &nbsp;<asp:Button ID="SendButton" runat="server" class="btn btn-success" onclick="SendButton_Click" 
            Text="Send" />
        <br />
        <div style="width:600px;">
            <asp:Literal ID="PreviewLiteral" runat="server"></asp:Literal>
        </div>
        <br />
        <a href="AdminPage.aspx" class="btn btn-default">Return to Main</a>
    </div>
    </form>
</body>
</html>
