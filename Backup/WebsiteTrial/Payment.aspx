<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="WebsiteTrial.Payment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
    
        <table class="table table-override" style="width:50% !important;">
            <tr>
                <td>
                    Employee</td>
                <td>
                    <asp:DropDownList ID="EmpDropDownList" class="form-control" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="EmpDropDownList_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
                        <asp:RadioButtonList ID="LoansRadioButtonList" class="form-control" runat="server">
                    </asp:RadioButtonList>
        <br />
        <table class="table table-override" style="width:50% !important;">
        <tr>
        <td>
        Payment Amount:</td>
        <td>
        <asp:TextBox ID="PayAmountTextBox" class="form-control" runat="server"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td>
            Note</td>
        <td>
            <asp:TextBox ID="NoteTextBox" runat="server" class="form-control" Height="143px" 
                TextMode="MultiLine" Width="190px"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:Button ID="PayButton" runat="server" class="btn btn-success" onclick="PayButton_Click" Text="Pay" 
                Width="82px" />
        </td>
        </tr>
        <tr>
        <td colspan="2">
            <asp:Literal ID="ResultLiteral" runat="server"></asp:Literal>
            </td>
        </tr>
        </table>


        <br />
        <a href="AdminPage.aspx" class="btn btn-danger btn-sm">Return to Main</a>
    </div>

    
    </form>
</body>
</html>
