<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="True" CodeBehind="Registration_old.aspx.cs" Inherits="WebsiteTrial.Registration_old" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Registration</h2>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <div class="row">
        <div class="col-lg-11">
            <label for="RegistrationTypeDropDownList">Registration Type</label>
            <asp:DropDownList ID="RegistrationTypeDropDownList" runat="server" CssClass="form-control">
                <asp:ListItem>--SELECT--</asp:ListItem>
                <asp:ListItem>Employee</asp:ListItem>
                <asp:ListItem>External</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-md-1">
            <h2 style="color:red;margin-top:22px;">*</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-11">
            <label for="tbEmpNum">Employee ID</label>
            <asp:TextBox ID="tbEmpNum" runat="server" CssClass="form-control input-md"></asp:TextBox>
        </div>
        <div class="col-md-1">
            <h2 style="color:red;margin-top:22px;display:none;">*</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-11">
            <label for="tbFirstName">First Name</label>
            <asp:TextBox ID="tbFirstName" runat="server" CssClass="form-control input-md"></asp:TextBox>
        </div>
        <div class="col-md-1">
            <h2 style="color:red;margin-top:22px;">*</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-11">
            <label for="tbLastName">Last Name</label>
            <asp:TextBox ID="tbLastName" runat="server" CssClass="form-control input-md"></asp:TextBox>
        </div>
        <div class="col-md-1">
            <h2 style="color:red;margin-top:22px;">*</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-11">
            <label for="tbMiddleName">Middle Name</label>
            <asp:TextBox ID="tbMiddleName" runat="server" CssClass="form-control input-md"></asp:TextBox>
        </div>
        <div class="col-md-1">
            <h2 style="color:red;margin-top:22px;display:none;">*</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-11">
            <label for="tbEmail">La Salle Portal Email Address:</label>
            <asp:TextBox ID="tbEmail" runat="server" CssClass="form-control input-md" 
                     AutoPostBack="True" ontextchanged="tbEmail_TextChanged"></asp:TextBox>
                 <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                     <ContentTemplate>
                         <asp:Label ID="lblEmailNote" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label>
                     </ContentTemplate>
                     <Triggers>
                         <asp:AsyncPostBackTrigger ControlID="tbEmail" EventName="TextChanged" />
                     </Triggers>
                 </asp:UpdatePanel>
        </div>
        <div class="col-md-1">
            <h2 style="color:red;margin-top:22px;">*</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-11">
            <label for="tbAddress">Address</label>
             <asp:TextBox ID="tbAddress" runat="server" class="form-control input-md" Height="70px" TextMode="MultiLine" 
                     ></asp:TextBox>
        </div>
        <div class="col-md-1">
            <h2 style="color:red;margin-top:22px;">*</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-11">
            <label for="tbPassword">Password</label>
            <asp:TextBox ID="tbPassword" runat="server" CssClass="form-control input-md"
                 TextMode="Password" AutoPostBack="True"
                OnTextChanged="tbPassword_TextChanged"></asp:TextBox>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:Label ID="lblPassNote" runat="server" ForeColor="Red" Font-Size="X-Small"></asp:Label>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="tbPassword" EventName="TextChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <div class="col-md-1">
            <h2 style="color:red;margin-top:22px;">*</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-11">
            <label for="tbConfirm">Re-type Password</label>
            <asp:TextBox ID="tbConfirm" runat="server" CssClass="form-control input-md"
                TextMode="Password" AutoPostBack="True"
                OnTextChanged="tbConfirm_TextChanged"></asp:TextBox>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server" RenderMode="Inline"
                UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Label ID="lblPassNote2" runat="server" ForeColor="Red" Font-Size="X-Small"></asp:Label>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="tbConfirm" EventName="TextChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
         <div class="col-md-1">
            <h2 style="color:red;margin-top:22px;">*</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-11">
            <label for="DDCollege">College</label>
            <asp:DropDownList ID="DDCollege" runat="server" class="form-control" 
                     AutoPostBack="True" onselectedindexchanged="DDCollege_SelectedIndexChanged">
             </asp:DropDownList>
        </div>
         <div class="col-md-1">
            <h2 style="color:red;margin-top:22px;">*</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <label for="DDDepartment">Department</label>
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                     <ContentTemplate>
                         <asp:DropDownList ID="DDDepartment" class="form-control" runat="server" >
                         </asp:DropDownList>
                     </ContentTemplate>
                     <Triggers>
                         <asp:AsyncPostBackTrigger ControlID="DDCollege" 
                             EventName="SelectedIndexChanged" />
                     </Triggers>
             </asp:UpdatePanel>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <label for="DDStatus">Member Status</label>
             <asp:DropDownList ID="DDStatus" runat="server" class="form-control" >
                     <asp:ListItem>Probationary</asp:ListItem>
                     <asp:ListItem>Part Time</asp:ListItem>
                     <asp:ListItem>Full Time</asp:ListItem>
                 </asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <label for="txtdatehired">Date Hired</label>
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                <ContentTemplate>
                    <asp:Calendar ID="Calendar1" runat="server"
                        OnSelectionChanged="Calendar1_SelectionChanged" Visible="False"></asp:Calendar>
                    <asp:TextBox ID="txtdatehired" runat="server" CssClass="form-control input-md"
                         Style="display: inline !important;">mm/dd/yyyy</asp:TextBox>
                    <asp:ImageButton ID="ImageButton1" runat="server" Height="25px"
                        ImageUrl="~/images/calendar_icon.jpg" OnClick="ImageButton1_Click"
                        Width="20px" />
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ImageButton1" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="Calendar1" EventName="SelectionChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <label for="tbPhone">Mobile Number</label>
            <asp:TextBox ID="tbPhone" runat="server" CssClass="form-control input-md"
                 ></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <label for="txtbirthday">Mobile Number</label>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Calendar ID="Calendar2" runat="server"
                        OnSelectionChanged="Calendar2_SelectionChanged" Visible="False"></asp:Calendar>
                    <asp:TextBox ID="txtbirthday" runat="server" CssClass="form-control input-md"
                         Style="display: inline !important;">mm/dd/yyyy</asp:TextBox>
                    <asp:ImageButton ID="ImageButton2" runat="server" Height="25px"
                        ImageUrl="~/images/calendar_icon.jpg" OnClick="ImageButton2_Click"
                        Width="20px" />
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ImageButton2" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="Calendar2" EventName="SelectionChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>

    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblConfirmNote" runat="server" ForeColor="Red"
                Font-Size="X-Small"></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Button ID="btnRegister" runat="server"
        CssClass="btn btn-success" Text="Register"
        OnClick="btnRegister_Click" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">

</asp:Content>
