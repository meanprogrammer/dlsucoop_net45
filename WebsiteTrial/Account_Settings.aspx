<%@ Page Title="" Language="C#" MasterPageFile="~/Account.Master" AutoEventWireup="true" CodeBehind="Account_Settings.aspx.cs" Inherits="WebsiteTrial.Account_Settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Account Settings</h3>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <div class="row">
        <div class="col-md-6">
            <label for="tbEmpNum">Employee ID <span style="color: red; margin-top: 22px;">*</span></label>
            <asp:TextBox ID="tbEmpNum" runat="server" CssClass="form-control input-md" ReadOnly="True"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="validation-message" runat="server" ErrorMessage="Employee ID is required." ControlToValidate="tbEmpNum"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-6">
            <label for="ATMTextbox">ATM Account No</label>
            <asp:TextBox ID="ATMTextbox" CssClass="form-control input-md" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" CssClass="validation-message" runat="server" ErrorMessage="ATM # is required." ControlToValidate="ATMTextbox"></asp:RequiredFieldValidator>
        </div>

    </div>
    <div class="row">
        <div class="col-md-5">
            <label for="tbFirstName">First Name <span style="color: red; margin-top: 22px;">*</span></label>
            <asp:TextBox ID="tbFirstName" runat="server" CssClass="form-control input-md"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="validation-message" ID="RequiredFieldValidator1" runat="server" ErrorMessage="First name is required." ControlToValidate="tbFirstName"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-5">
            <label for="tbLastName">Last Name <span style="color: red; margin-top: 22px;">*</span></label>
            <asp:TextBox ID="tbLastName" runat="server" CssClass="form-control input-md"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="validation-message" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Last name is required." ControlToValidate="tbLastName"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-2">
            <label for="tbMiddleName">Middle Name</label>
            <asp:TextBox ID="tbMiddleName" runat="server" CssClass="form-control input-md"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <label for="tbPhone">Mobile Number <span style="color: red; margin-top: 22px;">*</span></label><span>Format: 915XXXXXXX</span>
            <asp:TextBox ID="tbPhone" runat="server" CssClass="form-control input-md" MaxLength="10"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" CssClass="validation-message" runat="server" ErrorMessage="Mobile Number is Required." ControlToValidate="tbPhone" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="tbPhone" CssClass="validation-message" Display="Dynamic" ErrorMessage="Numeric only." Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
        </div>
        <div class="col-md-6">
            <label for="tbEmail">La Salle Portal Email Address  <span style="color: red; margin-top: 22px;">*</span></label>
            <asp:TextBox ID="tbEmail" runat="server" CssClass="form-control input-md"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="validation-message" runat="server" ErrorMessage="Email is Required." ControlToValidate="tbEmail"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbEmail" CssClass="validation-message" Display="Dynamic" ErrorMessage="Email address is invalid." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <label for="tbAddress">Address <span style="color: red; margin-top: 22px;">*</span></label>
            <asp:TextBox ID="tbAddress" runat="server" class="form-control input-md" Height="70px" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="validation-message" runat="server" ErrorMessage="Address is Required." ControlToValidate="tbAddress"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <label for="TINNoTextbox">TIN No.</label>
            <asp:TextBox ID="TINNoTextbox" CssClass="form-control input-md" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <label for="SSSNoTextBox">SSS No.</label>
            <asp:TextBox ID="SSSNoTextBox" CssClass="form-control input-md" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <label for="GenderDropDownList">Gender</label>
            <asp:DropDownList ID="GenderDropDownList" CssClass="form-control input-md" runat="server">
                <asp:ListItem Value="">--SELECT--</asp:ListItem>
                <asp:ListItem Value="Male" Text="Male" />
                <asp:ListItem Value="Female" Text="Female" />
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" CssClass="validation-message" runat="server" ErrorMessage="Gender is Required." ControlToValidate="GenderDropDownList"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <label for="CivilStatusDropDownList">Civil Status</label>
            <asp:DropDownList ID="CivilStatusDropDownList" CssClass="form-control input-md" runat="server">
                <asp:ListItem Value="">--SELECT--</asp:ListItem>
                <asp:ListItem Value="Single" Text="Single" />
                <asp:ListItem Value="Married" Text="Married" />
                <asp:ListItem Value="Divorced" Text="Divorced" />
                <asp:ListItem Value="Widowed" Text="Widowed" />
            </asp:DropDownList>
        </div>
        <div class="col-md-8">
            &nbsp;
                               
       
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <label for="FatherNameTextBox">Father's Name</label>
            <asp:TextBox ID="FatherNameTextBox" CssClass="form-control input-md" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-6">
            <label for="FatherOccupationTextBox">Occupation</label>
            <asp:TextBox ID="FatherOccupationTextBox" CssClass="form-control input-md" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <label for="MotherNameTextBox">Mother's Name</label>
            <asp:TextBox ID="MotherNameTextBox" CssClass="form-control input-md" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-6">
            <label for="MotherOccupationTextBox">Occupation</label>
            <asp:TextBox ID="MotherOccupationTextBox" CssClass="form-control input-md" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <label for="LegalSpouseTextBox">Legal Spouse</label>
            <asp:TextBox ID="LegalSpouseTextBox" CssClass="form-control input-md" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-6">
            <label for="SpouseOccupationTextBox">Occupation</label>
            <asp:TextBox ID="SpouseOccupationTextBox" CssClass="form-control input-md" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <label for="DDCollege">College <span style="color: red; margin-top: 22px;">*</span></label>
            <asp:DropDownList ID="DDCollege" runat="server" class="form-control"
                AutoPostBack="True" OnSelectedIndexChanged="DDCollege_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" CssClass="validation-message" runat="server" ErrorMessage="College is Required." ControlToValidate="DDCollege"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-6">
            <label for="DDDepartment">Department <span style="color: red; margin-top: 22px;">*</span></label>
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="DDDepartment" class="form-control" runat="server">
                    </asp:DropDownList>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="DDCollege"
                        EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" CssClass="validation-message" runat="server" ErrorMessage="Department is Required." ControlToValidate="DDDepartment"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <label for="DDStatus">Member Status <span style="color: red; margin-top: 22px;">*</span></label>
            <asp:DropDownList ID="DDStatus" runat="server" class="form-control">
                <asp:ListItem>Probationary</asp:ListItem>
                <asp:ListItem>Part Time</asp:ListItem>
                <asp:ListItem>Full Time</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" CssClass="validation-message" runat="server" ErrorMessage="Status is Required." ControlToValidate="DDStatus"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <label for="txtdatehired">Date Hired <span style="color: red; margin-top: 22px;">*</span></label>
            <div class="row">

                <div class="col-md-3">
                    <asp:DropDownList ID="DateHiredMonthDropdownlist" runat="server" AppendDataBoundItems="true" CssClass="form-control">
                        <asp:ListItem Text="--SELECT--" Value="" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" CssClass="validation-message" runat="server" ErrorMessage="Select Month." ControlToValidate="DateHiredMonthDropdownlist" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="DateHiredDateDropdownlist" runat="server" AppendDataBoundItems="true" CssClass="form-control">
                        <asp:ListItem Text="--SELECT--" Value="" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator26" CssClass="validation-message" runat="server" ErrorMessage="Select Date." ControlToValidate="DateHiredDateDropdownlist" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="DateHiredYearDropdownlist" runat="server" AppendDataBoundItems="true" CssClass="form-control">
                        <asp:ListItem Text="--SELECT--" Value="" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator27" CssClass="validation-message" runat="server" ErrorMessage="Select Year." ControlToValidate="DateHiredYearDropdownlist" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-3">
                    &nbsp;
                                       
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <label for="txtbirthday">Birthdate  <span style="color: red; margin-top: 22px;">*</span></label>
            <div class="row">

                <div class="col-md-3">
                    <asp:DropDownList ID="EmpBdateMonthDropdownlist" runat="server" AppendDataBoundItems="true" CssClass="form-control">
                        <asp:ListItem Text="--SELECT--" Value="" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" CssClass="validation-message" runat="server" ErrorMessage="Select Month." ControlToValidate="EmpBdateMonthDropdownlist" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="EmpBdateDateDropdownlist" runat="server" AppendDataBoundItems="true" CssClass="form-control">
                        <asp:ListItem Text="--SELECT--" Value="" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator28" CssClass="validation-message" runat="server" ErrorMessage="Select Date." ControlToValidate="EmpBdateDateDropdownlist" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="EmpBdateYearDropDownList" runat="server" AppendDataBoundItems="true" CssClass="form-control">
                        <asp:ListItem Text="--SELECT--" Value="" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator29" CssClass="validation-message" runat="server" ErrorMessage="Select Year." ControlToValidate="EmpBdateYearDropDownList" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-3">
                    &nbsp;
                                       
                </div>
            </div>
        </div>
    </div>

    <h4>If in business,</h4>
    <div class="row">
        <div class="col-md-6">
            <label for="BusinessNameTextBox">Business Name</label>
            <asp:TextBox ID="BusinessNameTextBox" CssClass="form-control input-md" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-6">
            <label for="BusinessAddressTextBox">Business Address</label>
            <asp:TextBox ID="BusinessAddressTextBox" CssClass="form-control input-md" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <label for="OtherSourceOfIncomeTextBox">Other source of income</label>
            <asp:TextBox ID="OtherSourceOfIncomeTextBox" CssClass="form-control input-md" runat="server"></asp:TextBox>
        </div>
    </div>
    <h4>In case of emergency notify:</h4>
    <div class="row">
        <div class="col-md-6">
            <label for="ICENameTextBox">Name</label>
            <asp:TextBox ID="ICENameTextBox" CssClass="form-control input-md" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-6">
            <label for="ICEAddressTextBox">Address</label>
            <asp:TextBox ID="ICEAddressTextBox" CssClass="form-control input-md" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <label for="ICEContactNumberTextBox">Contact #</label>
            <asp:TextBox ID="ICEContactNumberTextBox" CssClass="form-control input-md" runat="server"></asp:TextBox>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-12">
            <asp:Button ID="btnRegister" runat="server" CssClass="btn btn-success" Text="Update" OnClick="btnRegister_Click" />
        </div>
    </div>
</asp:Content>
