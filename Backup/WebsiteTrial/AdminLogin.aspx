<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="AdminLogin.aspx.cs" Inherits="WebsiteTrial.AdminLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="panel panel-success" style="margin:0 auto;width:300px;margin-top:20px;">
  <div class="panel-heading">Login</div>
  <div class="panel-body">
        <asp:Login ID="AdminLoginControl" runat="server" 
            onauthenticate="Login1_Authenticate">
            <LayoutTemplate>
                <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;" width="100%">
                    <tr>
                        <td>
                            <table cellpadding="0">
<%--                                <tr>
                                    <td align="center" colspan="2">
                                        Log In</td>
                                </tr>--%>
                                <tr>
                                                                    <td>
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                                    </td>
                                </tr>
                                <tr>

                                    <td colspan="2">
                                        <asp:TextBox ID="UserName" class="form-control input-md" runat="server" style="display:inline !important;width:250px;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                            ControlToValidate="UserName" ErrorMessage="User Name is required." 
                                            ToolTip="User Name is required." ValidationGroup="AdminLoginControl">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                                                    <td colspan="2">
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                    </td>
                                </tr>
                                <tr>

                                    <td>
                                        <asp:TextBox ID="Password" class="form-control input-md" runat="server" TextMode="Password" style="display:inline !important;width:250px;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                            ControlToValidate="Password" ErrorMessage="Password is required." 
                                            ToolTip="Password is required." ValidationGroup="AdminLoginControl">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:CheckBox ID="RememberMe" runat="server" Text="&nbsp;Remember me next time." />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="color:Red;">
                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        <asp:Button ID="LoginButton" runat="server" class="btn btn-success btn-lg" CommandName="Login" Text="Log In" 
                                            ValidationGroup="AdminLoginControl" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:Login>
  </div>
</div>
    </div>
    </form>
</body>
</html>
