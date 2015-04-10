<%@ Page Title="" Language="C#" MasterPageFile="~/Account.Master" AutoEventWireup="True" CodeBehind="Account_Settings_old.aspx.cs" Inherits="WebsiteTrial.Account_Settings_old" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style6
        {
            height: 26px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table class="table table-override">
         <tr>
             <td>
                 Emp. #:</td>
             <td>
                 <asp:TextBox ID="txtEmpNo" runat="server" CssClass="form-control input-md" Width="200px" 
                     ReadOnly="True"></asp:TextBox>
             </td>
             <td>
                 <asp:ScriptManager ID="ScriptManager1" runat="server">
                 </asp:ScriptManager>
             </td>
         </tr>
         <tr>
             <td class="style6">
                 Name:</td>
             <td class="style6">
                 <asp:TextBox ID="txtName" runat="server" CssClass="form-control input-md" Width="200px"></asp:TextBox>
             </td>
             <td class="style6">
                 </td>
         </tr>
         <tr>
             <td>
                 La Salle Portal<br />
                 Email Address:</td>
             <td>
                 <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control input-md" Width="200px" 
                     ontextchanged="txtEmail_TextChanged"></asp:TextBox>
                 <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                     <ContentTemplate>
                         <asp:Label ID="Label6" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label>
                     </ContentTemplate>
                     <Triggers>
                         <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
                         <asp:AsyncPostBackTrigger ControlID="txtEmail" EventName="TextChanged" />
                     </Triggers>
                 </asp:UpdatePanel>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td>
                 Address1:</td>
             <td>
                 <asp:TextBox ID="txtAddress" runat="server" class="form-control" Height="70px" TextMode="MultiLine" 
                     Width="200px"></asp:TextBox>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td>
                 &nbsp;</td>
             <td>
                 <br />
                 <br />
                 <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Change Password</asp:LinkButton>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td colspan="2">
                 <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                     <ContentTemplate>
                         <asp:Panel ID="Panel1" runat="server" Visible="False">
                             Old Password:<asp:TextBox ID="txtOldPass0" runat="server" 
                                 CssClass="form-control input-md" Width="200px" TextMode="Password"></asp:TextBox>
                             <asp:Label ID="Label4" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label>
                             <br />
                             New Password:
                             <asp:TextBox ID="txtNewPass0" runat="server" CssClass="form-control input-md" 
                                 Width="200px" TextMode="Password"></asp:TextBox>
                             <br />
                             Confirm Password:
                             <asp:TextBox ID="txtConfirm0" runat="server" CssClass="form-control input-md" 
                                 Width="200px" ontextchanged="txtConfirm0_TextChanged" TextMode="Password"></asp:TextBox>
                             <br />
                             <asp:Label ID="Label3" runat="server" ForeColor="Red" Font-Size="X-Small"></asp:Label>
                         </asp:Panel>
                     </ContentTemplate>
                     <Triggers>
                         <asp:AsyncPostBackTrigger ControlID="LinkButton1" EventName="Click" />
                     </Triggers>
                 </asp:UpdatePanel>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td>
                 College:</td>
             <td>
                 <asp:DropDownList ID="DDCollege" runat="server" class="form-control" Width="200px" 
                     onselectedindexchanged="DDCollege_SelectedIndexChanged" 
                     AutoPostBack="True">
                 </asp:DropDownList>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td>
                 Department:</td>
             <td>
                 <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                     <ContentTemplate>
                         <asp:DropDownList ID="DDDepartment" class="form-control" runat="server" Width="200px">
                         </asp:DropDownList>
                     </ContentTemplate>
                     <Triggers>
                         <asp:AsyncPostBackTrigger ControlID="DDCollege" 
                             EventName="SelectedIndexChanged" />
                     </Triggers>
                 </asp:UpdatePanel>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td>
                 Member Status:</td>
             <td>
                 <asp:DropDownList ID="DDStatus" runat="server" class="form-control" Width="200px">
                     <asp:ListItem>Probationary</asp:ListItem>
                     <asp:ListItem>Part Time</asp:ListItem>
                     <asp:ListItem>Full Time</asp:ListItem>
                 </asp:DropDownList>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td>
                 Date Hired:</td>
             <td>
                 <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                     <ContentTemplate>
                         <asp:Calendar ID="Calendar1" runat="server" 
                             onselectionchanged="Calendar1_SelectionChanged" Visible="False" 
                             BackColor="White" BorderColor="#999999" CellPadding="4" 
                             DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" 
                             Height="180px" Width="200px">
                             <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                             <NextPrevStyle VerticalAlign="Bottom" />
                             <OtherMonthDayStyle ForeColor="#808080" />
                             <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                             <SelectorStyle BackColor="#CCCCCC" />
                             <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                             <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                             <WeekendDayStyle BackColor="#FFFFCC" />
                         </asp:Calendar>
                         <asp:TextBox ID="txtdatehired" runat="server" CssClass="form-control input-md" 
                             Width="200px" style="display:inline !important;">mm/dd/yyyy</asp:TextBox>
                         <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" 
                             ImageUrl="~/images/calendar_icon.jpg" onclick="ImageButton1_Click" 
                             Width="20px" />
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
             <td>
                 Mobile Number:</td>
             <td>
                 <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control input-md" 
                     Width="200px" ontextchanged="txtPhone_TextChanged" ></asp:TextBox>
                 <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                     <ContentTemplate>
                         <asp:Label ID="Label7" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label>
                     </ContentTemplate>
                 </asp:UpdatePanel>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td>
                 Birthday:</td>
             <td>
                 <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                     <ContentTemplate>
                         <asp:Calendar ID="Calendar2" runat="server" 
                             onselectionchanged="Calendar2_SelectionChanged" Visible="False" 
                             BackColor="White" BorderColor="#999999" CellPadding="4" 
                             DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" 
                             Height="180px" Width="200px">
                             <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                             <NextPrevStyle VerticalAlign="Bottom" />
                             <OtherMonthDayStyle ForeColor="#808080" />
                             <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                             <SelectorStyle BackColor="#CCCCCC" />
                             <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                             <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                             <WeekendDayStyle BackColor="#FFFFCC" />
                         </asp:Calendar>
                         <asp:TextBox ID="txtbirthday" runat="server" CssClass="form-control input-md" 
                             Width="200px"  style="display:inline !important;">mm/dd/yyyy</asp:TextBox>
                         <asp:ImageButton ID="ImageButton2" runat="server" Height="25px" 
                             ImageUrl="~/images/calendar_icon.jpg" onclick="ImageButton2_Click" 
                             Width="20px" />
                     </ContentTemplate>
                     <Triggers>
                         <asp:AsyncPostBackTrigger ControlID="ImageButton2" EventName="Click" />
                         <asp:AsyncPostBackTrigger ControlID="Calendar2" EventName="SelectionChanged" />
                     </Triggers>
                 </asp:UpdatePanel>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td>
                 &nbsp;</td>
             <td>
                 <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                     <ContentTemplate>
                         <asp:Label ID="Label5" runat="server" ForeColor="#009933"></asp:Label>
                     </ContentTemplate>
                 </asp:UpdatePanel>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td>
                 &nbsp;</td>
             <td>
                 <asp:Button ID="Button1" runat="server" BorderStyle="None" 
                     CssClass="btn btn-success" Height="27px" Text="Save" Width="120px" 
                     onclick="Button1_Click" />
             </td>
             <td>
                 &nbsp;</td>
         </tr>
     </table>
</asp:Content>

