<%@ Page Title="" Language="C#" MasterPageFile="~/Account.Master" AutoEventWireup="true" CodeBehind="Account_Settings_ne.aspx.cs" Inherits="WebsiteTrial.Account_Settings_ne" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Account Settings</h3>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <div class="row">
        <div class="col-md-12">
            <label for="RelativeEmpDropDownList">Relative Employee</label>
            <asp:DropDownList ID="RelativeEmpDropDownList" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:DropDownList>
            <asp:CompareValidator ID="CompareValidator4" runat="server" ValueToCompare="0" ControlToValidate="RelativeEmpDropDownList" ErrorMessage="Select your relative." Operator="NotEqual" CssClass="validation-message"></asp:CompareValidator>
        </div>

    </div>
    <div class="row">
        <div class="col-md-12">
            <label for="tbFirstName2">First Name <span style="color: red; margin-top: 22px;">*</span></label>
            <asp:TextBox ID="tbFirstName2" runat="server" CssClass="form-control input-md"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="validation-message" ID="RequiredFieldValidator14" runat="server" ErrorMessage="First name is required." ControlToValidate="tbFirstName2"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <label for="tbLastName2">Last Name <span style="color: red; margin-top: 22px;">*</span></label>
            <asp:TextBox ID="tbLastName2" runat="server" CssClass="form-control input-md"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="validation-message" ID="RequiredFieldValidator15" runat="server" ErrorMessage="Last name is required." ControlToValidate="tbLastName2"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <label for="tbMiddleName2">Middle Name</label>
            <asp:TextBox ID="tbMiddleName2" runat="server" CssClass="form-control input-md"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <label for="tbEmail">Email Address  <span style="color: red; margin-top: 22px;">*</span></label>

            <asp:TextBox ID="tbEmail2" runat="server" CssClass="form-control input-md"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" CssClass="validation-message" runat="server" ErrorMessage="Email is Required." ControlToValidate="tbEmail2" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbEmail2" CssClass="validation-message" Display="Dynamic" ErrorMessage="Email address is invalid." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <label for="tbAddress">Address <span style="color: red; margin-top: 22px;">*</span></label>
            <asp:TextBox ID="tbAddress2" runat="server" class="form-control input-md" Height="70px" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" CssClass="validation-message" runat="server" ErrorMessage="Address is Required." ControlToValidate="tbAddress2"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-md-9">
            <label for="tbPhone2">Mobile Number <span style="color: red; margin-top: 22px;">*</span></label>
            <asp:TextBox ID="tbPhone2" runat="server" CssClass="form-control input-md" MaxLength="10"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" CssClass="validation-message" runat="server" ErrorMessage="Mobile Number is Required." ControlToValidate="tbPhone2" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-3">
            <span>Format: 915XXXXXXX</span>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <label for="txtbirthday">Birthdate  <span style="color: red; margin-top: 22px;">*</span></label>
            <div class="row">

                <div class="col-md-3">
                    <asp:DropDownList ID="NEBdayMonthDropDownList" runat="server" AppendDataBoundItems="true" CssClass="form-control">
                        <asp:ListItem Text="--SELECT--" Value="" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" CssClass="validation-message" runat="server" ErrorMessage="Select Month." ControlToValidate="NEBdayMonthDropDownList" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="NEBdayDayDropDownList" runat="server" AppendDataBoundItems="true" CssClass="form-control">
                        <asp:ListItem Text="--SELECT--" Value="" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" CssClass="validation-message" runat="server" ErrorMessage="Select Date." ControlToValidate="NEBdayDayDropDownList" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="NEBdayYearDropDownList" runat="server" AppendDataBoundItems="true" CssClass="form-control">
                        <asp:ListItem Text="--SELECT--" Value="" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator24" CssClass="validation-message" runat="server" ErrorMessage="Select Year." ControlToValidate="NEBdayYearDropDownList" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-3">
                    &nbsp;
                                       
                </div>
            </div>

        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-12">
            <asp:Button ID="btnRegister" runat="server" CssClass="btn btn-success" Text="Update" OnClick="btnRegister_Click" />
        </div>
    </div>
</asp:Content>
