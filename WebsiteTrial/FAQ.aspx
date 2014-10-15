<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="WebsiteTrial.FAQ" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style type="text/css">
        .style6
        {
            line-height: 107%;
            font-size: 11.0pt;
            font-family: Calibri, sans-serif;
            margin-left: .5in;
            margin-right: 0in;
            margin-top: 0in;
            margin-bottom: .0001pt;
        }
        .style7
        {
            line-height: 107%;
            font-size: 11.0pt;
            font-family: Calibri, sans-serif;
            margin-left: .5in;
            margin-right: 0in;
            margin-top: 0in;
            margin-bottom: 8.0pt;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Frequently Asked Questions</h2>
   <ol>
    <li>Loan balances (All types of Loans).</li>
    <li>Maturity date of Loans.</li>
    <li>About 60% renew (Member must have covered at least 60% of their existing loan.)</li>
    <li>About loans that is available for the member.</li>
    <li>Saving Deposit of members. </li>
    <li>
           
               <span>How to become a member?</span>
               <br />
               <span> To become a member at dlsud cooperative you need to fill up the biodata form, 
               and then wait for the schedule of the seminar.</span>
   </li>
   <li>
        <span>What are the requirements in loan application?</span><br />
        <ul>
            <li>1 month payslip</li>
            <li>2 co-maker</li>
        </ul>
   </li>
   </ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="panel panel-success">
  <div class="panel-heading">Login</div>
  <div class="panel-body">
     <asp:Login ID="EmpLogin" runat="server" 
    onauthenticate="Login1_Authenticate" 
        UserNameLabelText="Employee Number:" 
        UserNameRequiredErrorMessage="Employee Number is required.">
        <LayoutTemplate>
            <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
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
                                    <asp:TextBox ID="UserName" runat="server" CssClass="form-control input-md" style="display:inline !important;width:150px;"></asp:TextBox>
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
                                        TextMode="Password" style="display:inline !important;width:150px;"></asp:TextBox>
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
                                <td align="center" colspan="2" style="color:Red;">
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
  </div>
</div>
    <span class="style6">Forgot your password?</span>
    <a href="RetrievePassword.aspx" class="btn btn-danger">Click Here!</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
