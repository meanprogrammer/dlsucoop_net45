<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="True" CodeBehind="Registration.aspx.cs" Inherits="WebsiteTrial.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <label for="registrationtype">Registration Type</label>
            <select class="form-control input-md" id="registrationtype">
                <option value="">--SELECT--</option>
                <option value="Employee">Employee</option>
                <option value="External">External</option>
            </select>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <label for="empid">Employee ID</label>
            <input id="empid" class="form-control input-md" type="text" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <label for="firstname">First Name</label>
            <input type="text" class="form-control input-md" id="firstname" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <label for="lastname">Last Name</label>
            <input id="lastname" class="form-control input-md" type="text" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <label for="middlename">Middle Name</label>
            <input id="middlename" class="form-control input-md" type="text" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <label for="registrantemail">Email Address</label>
            <input id="registrantemail" class="form-control input-md" type="text" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <label for="registrantaddress">Address</label>
            <textarea id="registrantaddress" class="form-control input-md" rows="3" cols="30" ></textarea>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <label></label>
            <input />
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <label for="registrantpassword">Password</label>
            <input type="password" class="form-control input-md" id="registrantpassword" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <label for="retyperegistrantpassword">Re-type Password</label>
            <input type="password" class="form-control input-md" id="retyperegistrantpassword" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <label for="college">College</label>
            <select id="college" class="form-control input-md" >
                <option value="">--SELECT--</option>
            </select>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <label for="department">Department</label>
            <select id="department" class="form-control input-md" >
                <option value="">--SELECT--</option>
            </select>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <label for="memberstatus">Member Status</label>
            <select id="memberstatus" class="form-control input-md" >
                <option value="">--SELECT--</option>
            </select>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <label for="datehired">Date Hired</label>
            <input id="datehired" class="form-control input-md" type="text" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
              <label for="mobilenumber">Mobile Number</label>
            <input id="mobilenumber" class="form-control input-md" type="text" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
              <label for="birthdate">Mobile Number</label>
            <input id="birthdate" class="form-control input-md" type="text" />
        </div>
    </div>
     <table class="table table-override">
         <tr>
             <td colspan="3">
                 <h2>Registration<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
                 </asp:ScriptManager>
                 </h2></td>
         </tr>
         <tr>
             <td>
                 Emp. Number:</td>
             <td>
                 <asp:TextBox ID="tbEmpNum" runat="server" CssClass="form-control input-md" Width="200px"></asp:TextBox>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td>
                 Name:</td>
             <td>
                 <asp:TextBox ID="tbName" runat="server" CssClass="form-control input-md" Width="200px"></asp:TextBox>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td>
                 La Salle Portal<br />
                 Email Address:</td>
             <td>
                 <asp:TextBox ID="tbEmail" runat="server" CssClass="form-control input-md" Width="200px" 
                     AutoPostBack="True" ontextchanged="tbEmail_TextChanged"></asp:TextBox>
                 <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                     <ContentTemplate>
                         <asp:Label ID="lblEmailNote" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label>
                     </ContentTemplate>
                     <Triggers>
                         <asp:AsyncPostBackTrigger ControlID="tbEmail" EventName="TextChanged" />
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
                 <asp:TextBox ID="tbAddress" runat="server" class="form-control input-md" Height="70px" TextMode="MultiLine" 
                     Width="200px"></asp:TextBox>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
         <%--<tr>
             <td>
                 &nbsp;</td>
             <td>
                 <asp:TextBox ID="TextBox12" runat="server" Height="70px" class="form-control input-md" TextMode="MultiLine" 
                     Width="200px" Visible="False"></asp:TextBox>
             </td>
             <td>
                 &nbsp;</td>
         </tr>--%>
<%--         <tr>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
         </tr>--%>
         <tr>
             <td>
                 Password:</td>
             <td>
                 <asp:TextBox ID="tbPassword" runat="server" CssClass="form-control input-md" 
                     Width="200px" TextMode="Password" AutoPostBack="True" 
                     ontextchanged="tbPassword_TextChanged"></asp:TextBox>
                 <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                     <ContentTemplate>
                         <asp:Label ID="lblPassNote" runat="server" ForeColor="Red" Font-Size="X-Small"></asp:Label>
                     </ContentTemplate>
                     <Triggers>
                         <asp:AsyncPostBackTrigger ControlID="tbPassword" EventName="TextChanged" />
                     </Triggers>
                 </asp:UpdatePanel>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td>
                 Confirm Password:</td>
             <td>
                 <asp:TextBox ID="tbConfirm" runat="server" CssClass="form-control input-md" 
                     Width="200px" TextMode="Password" AutoPostBack="True" 
                     ontextchanged="tbConfirm_TextChanged"></asp:TextBox>
                 <asp:UpdatePanel ID="UpdatePanel3" runat="server" RenderMode="Inline" 
                     UpdateMode="Conditional">
                     <ContentTemplate>
                         <asp:Label ID="lblPassNote2" runat="server" ForeColor="Red" Font-Size="X-Small"></asp:Label>
                     </ContentTemplate>
                     <Triggers>
                         <asp:AsyncPostBackTrigger ControlID="tbConfirm" EventName="TextChanged" />
                     </Triggers>
                 </asp:UpdatePanel>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
        <%-- <tr>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
         </tr>--%>
         <tr>
             <td>
                 College:</td>
             <td>
                 <asp:DropDownList ID="DDCollege" runat="server" class="form-control" Width="200px" 
                     AutoPostBack="True" onselectedindexchanged="DDCollege_SelectedIndexChanged">
                 </asp:DropDownList>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td>
                 Department:</td>
             <td>
                 <asp:UpdatePanel ID="UpdatePanel4" runat="server">
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
                 <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                     <ContentTemplate>
                         <asp:Calendar ID="Calendar1" runat="server" 
                             onselectionchanged="Calendar1_SelectionChanged" Visible="False">
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
                 <asp:TextBox ID="tbPhone" runat="server" CssClass="form-control input-md" 
                     Width="200px"></asp:TextBox>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td>
                 Birthday:</td>
             <td>
                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                     <ContentTemplate>
                         <asp:Calendar ID="Calendar2" runat="server" 
                             onselectionchanged="Calendar2_SelectionChanged" Visible="False">
                         </asp:Calendar>
                         <asp:TextBox ID="txtbirthday" runat="server" CssClass="form-control input-md" 
                             Width="200px" style="display:inline !important;">mm/dd/yyyy</asp:TextBox>
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
                         <asp:Label ID="lblConfirmNote" runat="server" ForeColor="Red" 
                             Font-Size="X-Small"></asp:Label>
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
                 <asp:Button ID="btnRegister" runat="server" 
                     CssClass="btn btn-success" Text="Register" 
                     onclick="btnRegister_Click" />
             </td>
             <td>
                 &nbsp;</td>
         </tr>
     </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">

</asp:Content>
