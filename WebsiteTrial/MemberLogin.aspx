<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="MemberLogin.aspx.cs" Inherits="WebsiteTrial.MemberLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-success" style="margin: 0 auto; width: 300px; margin-top: 20px;">
        <div class="panel-heading">Login</div>
        <div class="panel-body">
            <asp:Login ID="EmpLogin" runat="server"
                OnAuthenticate="Login1_Authenticate"
                UserNameLabelText="Employee Number:"
                UserNameRequiredErrorMessage="Employee Number is required.">
                <LayoutTemplate>
                    <table cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                        <tr>
                            <td>
                                <table cellpadding="0">
                                    <%--                            <tr>
                                <td align="center" colspan="2">
                                    Log In</td>
                            </tr>--%>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Employee Number:</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>

                                        <td>
                                            <asp:TextBox ID="UserName" runat="server" CssClass="form-control input-md" Style="display: inline !important;"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server"
                                                ControlToValidate="UserName" ErrorMessage="Employee Number is required."
                                                ToolTip="Employee Number is required." ValidationGroup="EmpLogin">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="Password" runat="server" CssClass="form-control input-md"
                                                TextMode="Password" Style="display: inline !important;"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server"
                                                ControlToValidate="Password" ErrorMessage="Password is required."
                                                ToolTip="Password is required." ValidationGroup="EmpLogin">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" valign="middle">
                                            <asp:CheckBox ID="RememberMe" runat="server" Text="&nbsp;Remember me." />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" style="color: Red;">
                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="2">
                                            <asp:Button ID="LoginButton" runat="server" class="btn btn-success" CommandName="Login" Text="Log In"
                                                ValidationGroup="EmpLogin" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <TextBoxStyle CssClass="form-control input-md" />
            </asp:Login>
                <span class="style6">Forgot your password?</span>
    <a href="RetrievePassword.aspx">Click Here!</a>
        </div>
    </div>

    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
