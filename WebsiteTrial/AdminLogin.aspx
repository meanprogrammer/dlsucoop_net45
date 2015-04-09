<%@ Page Title="" Language="C#" MasterPageFile="~/Administration.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="WebsiteTrial.AdminLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-success" style="margin: 0 auto; width: 300px; margin-top: 20px;">
        <div class="panel-heading">Login</div>
        <div class="panel-body">
            <asp:Login ID="AdminLoginControl" runat="server"
                OnAuthenticate="Login1_Authenticate" >
                <LayoutTemplate>
                    <div class="row">
                        <div class="col-md-12" style="background-color:white;">
                            <label>Username</label>
                            <asp:TextBox ID="UserName" class="form-control input-md" runat="server" Style="display: inline !important; width: 250px;"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server"
                                                ControlToValidate="UserName" ErrorMessage="User Name is required."
                                                ToolTip="User Name is required." ValidationGroup="AdminLoginControl">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12" style="background-color:white;">
                            <label>Password</label>
                     <asp:TextBox ID="Password" class="form-control input-md" runat="server" TextMode="Password" Style="display: inline !important; width: 250px;"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server"
                                                ControlToValidate="Password" ErrorMessage="Password is required."
                                                ToolTip="Password is required." ValidationGroup="AdminLoginControl">*</asp:RequiredFieldValidator>
                            </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12" style="background-color:white;">
                            <asp:CheckBox ID="RememberMe" runat="server" Text="&nbsp;Remember me next time." />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12" style="background-color:white;">
                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12" style="background-color:white;">
                               <asp:Button ID="LoginButton" runat="server" class="btn btn-success btn-lg" CommandName="Login" Text="Log In"
                                                ValidationGroup="AdminLoginControl" /> 
                        </div>
                    </div>
                </LayoutTemplate>
            </asp:Login>
        </div>
    </div>
    <br />
</asp:Content>
