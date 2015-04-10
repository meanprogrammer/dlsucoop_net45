<%@ Page Title="" Language="C#" MasterPageFile="~/Account.Master" AutoEventWireup="True" CodeBehind="Message.aspx.cs" Inherits="WebsiteTrial.Message" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ui-state-error ui-corner-all" style="padding: 0 .7em;"> 
		<p style="font-weight:normal;font-family: Verdana;">
            &nbsp;</p>
        <p style="font-weight:normal;font-family: Verdana;">
            <asp:Label ID="Label1" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
        </p>
    </div>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table class="style5" align="center">
    <tr>
        <td>                
             <div>
                <h2 class="text_effect">Login</h2>
                   <table class="style1">
                       <tr>
                            <td id="login" align="center" class="aligncenter">
                                  Username:</td>
                       </tr>
                        <tr>
                            <td class="aligncenter">
                                <asp:TextBox ID="txtusername" runat="server" CssClass="textbox_ctrl"></asp:TextBox>
                             </td>
                       </tr>
                       <tr>
                            <td class="aligncenter">
                               Password:</td>
                       </tr>
                       <tr>
                            <td class="aligncenter">
                                 <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" 
                                     CssClass="textbox_ctrl"></asp:TextBox>
                             </td>
                       </tr>
                       <tr>
                          <td class="aligncenter">
                              <asp:Label ID="lblerror" runat="server" CssClass="aligncenter" 
                                   style="color: #FF0000"></asp:Label>
                             <br />
                              <asp:Button ID="btnlogin" runat="server" BackColor="#009900" 
                                  CssClass="btn_login" ForeColor="Black" Height="27px" Text="Login" 
                                   Width="118px" EnableViewState="False" BorderStyle="None" />
                              <br />
                          </td>
                       </tr>
                       <tr>
                           <td>
                              No account yet? Signup
                               <asp:HyperLink ID="HyperLink1" runat="server" 
                                   NavigateUrl="~/Registration.aspx" >here.</asp:HyperLink>&nbsp;
                           </td>
                       </tr>
                   </table>
              </div>
                               
         </td>
    </tr>
</table>
</asp:Content>--%>