<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="WebsiteTrial.Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function PasswordLengthValidate(source, args) {
            if (args.Value.length < 6) // do check here
                args.IsValid = false;
            else
                args.IsValid = true;
        }



    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="RegistrationUpdatePanel" runat="server">
        <ContentTemplate>
            <div runat="server" clientidmode="Static" id="AlertDiv">
                <strong runat="server" clientidmode="Static" id="alertmessage"></strong>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <label for="RegistrationTypeDropDownList">Registration Type</label>
                    <asp:DropDownList ID="RegistrationTypeDropDownList" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="RegistrationTypeDropDownList_SelectedIndexChanged" Visible="False">
                        <asp:ListItem>--SELECT--</asp:ListItem>
                        <asp:ListItem>Employee</asp:ListItem>
                        <asp:ListItem>Non-Employee</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RadioButtonList ID="RegistrationRadioButtonList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RegistrationRadioButtonList_SelectedIndexChanged">
                        <asp:ListItem Selected="True">Employee</asp:ListItem>
                        <asp:ListItem Value="NonEmployee">Non-Employee</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="row" style="margin-top:20px;">
                <div class="col-md-12">
                    <asp:MultiView ID="RegistrationMultiView" runat="server">
                        <asp:View runat="server" ClientIDMode="Static" ID="EmployeeView">
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="tbEmpNum" Display="Dynamic" OnServerValidate="ValidateRegistration" ValidateEmptyText="True" CssClass="validation-message" ErrorMessage="Either Employee ID or Email address is already registered."></asp:CustomValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <label for="tbEmpNum">Employee ID <span style="color: red; margin-top: 22px;">*</span></label>
                                    <asp:TextBox ID="tbEmpNum" runat="server" CssClass="form-control input-md"></asp:TextBox>
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
                                    <asp:RequiredFieldValidator CssClass="validation-message"  ID="RequiredFieldValidator1" runat="server" ErrorMessage="First name is required." ControlToValidate="tbFirstName"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-5">
                                    <label for="tbLastName">Last Name <span style="color: red; margin-top: 22px;">*</span></label>
                                    <asp:TextBox ID="tbLastName" runat="server" CssClass="form-control input-md"></asp:TextBox>
                                    <asp:RequiredFieldValidator CssClass="validation-message"  ID="RequiredFieldValidator2" runat="server" ErrorMessage="Last name is required." ControlToValidate="tbLastName"></asp:RequiredFieldValidator>
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
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" CssClass="validation-message"  runat="server" ErrorMessage="Mobile Number is Required." ControlToValidate="tbPhone" Display="Dynamic"></asp:RequiredFieldValidator>   
                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="tbPhone" CssClass="validation-message" Display="Dynamic" ErrorMessage="Numeric only." Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
                                </div>
                                <div class="col-md-6">
                                    <label for="tbEmail">La Salle Portal Email Address  <span style="color: red; margin-top: 22px;">*</span></label>
                                    <asp:TextBox ID="tbEmail" runat="server" CssClass="form-control input-md"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="validation-message"  runat="server" ErrorMessage="Email is Required." ControlToValidate="tbEmail"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbEmail" CssClass="validation-message" Display="Dynamic" ErrorMessage="Email address is invalid." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <label for="tbAddress">Address <span style="color: red; margin-top: 22px;">*</span></label>
                                    <asp:TextBox ID="tbAddress" runat="server" class="form-control input-md" Height="70px" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="validation-message"  runat="server" ErrorMessage="Address is Required." ControlToValidate="tbAddress"></asp:RequiredFieldValidator>
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
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator25" CssClass="validation-message"  runat="server" ErrorMessage="Gender is Required." ControlToValidate="GenderDropDownList"></asp:RequiredFieldValidator>
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
                                    <label for="tbPassword">Password <span style="color: red; margin-top: 22px;">*</span></label>
                                    <asp:TextBox ID="tbPassword" runat="server" CssClass="form-control input-md"
                                        TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="validation-message"  runat="server" ErrorMessage="Password is Required." ControlToValidate="tbPassword" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="tbPassword" CssClass="validation-message" ErrorMessage="Password minimum length is 6." ValidateEmptyText="True" ValidationGroup="a" ClientValidationFunction="PasswordLengthValidate" Display="Dynamic"></asp:CustomValidator>
                                </div>
                                <div class="col-md-6">
                                    <label for="tbConfirm">Re-type Password <span style="color: red; margin-top: 22px;">*</span></label>
                                    <asp:TextBox ID="tbConfirm" runat="server" CssClass="form-control input-md"
                                        TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" CssClass="validation-message"  Display="Dynamic" runat="server" ErrorMessage="Password is Required." ControlToValidate="tbConfirm"></asp:RequiredFieldValidator>   
                                    <asp:CompareValidator ID="CompareValidator1" CssClass="validation-message" runat="server" Display="Dynamic" ErrorMessage="Password does not match." ControlToCompare="tbPassword" ControlToValidate="tbConfirm"></asp:CompareValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <label for="DDCollege">College <span style="color: red; margin-top: 22px;">*</span></label>
                                    <asp:DropDownList ID="DDCollege" runat="server" class="form-control"
                                        AutoPostBack="True" OnSelectedIndexChanged="DDCollege_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8"  CssClass="validation-message"  runat="server" ErrorMessage="College is Required." ControlToValidate="DDCollege"></asp:RequiredFieldValidator>   
                                </div>
                                <div class="col-md-6">
                                    <label for="DDDepartment">Department <span style="color: red; margin-top: 22px;">*</span></label>
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
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" CssClass="validation-message"  runat="server" ErrorMessage="Department is Required." ControlToValidate="DDDepartment"></asp:RequiredFieldValidator>   
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
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" CssClass="validation-message"  runat="server" ErrorMessage="Status is Required." ControlToValidate="DDStatus"></asp:RequiredFieldValidator>   
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
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11"  CssClass="validation-message"  runat="server" ErrorMessage="Select Month." ControlToValidate="DateHiredMonthDropdownlist" Display="Dynamic"></asp:RequiredFieldValidator>   
                                        </div>
                                        <div class="col-md-3">
                                            <asp:DropDownList ID="DateHiredDateDropdownlist" runat="server" AppendDataBoundItems="true"   CssClass="form-control">
                                                <asp:ListItem Text="--SELECT--" Value="" />
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" CssClass="validation-message"  runat="server" ErrorMessage="Select Date." ControlToValidate="DateHiredDateDropdownlist" Display="Dynamic"></asp:RequiredFieldValidator>   
                                        </div>
                                        <div class="col-md-3">
                                            <asp:DropDownList ID="DateHiredYearDropdownlist" runat="server" AppendDataBoundItems="true" CssClass="form-control">
                                                <asp:ListItem Text="--SELECT--" Value="" />
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator27" CssClass="validation-message"  runat="server" ErrorMessage="Select Year." ControlToValidate="DateHiredYearDropdownlist" Display="Dynamic"></asp:RequiredFieldValidator>   
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
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13"  CssClass="validation-message"  runat="server" ErrorMessage="Select Month." ControlToValidate="EmpBdateMonthDropdownlist" Display="Dynamic"></asp:RequiredFieldValidator>   
                                        </div>
                                        <div class="col-md-3">
                                            <asp:DropDownList ID="EmpBdateDateDropdownlist" runat="server" AppendDataBoundItems="true"   CssClass="form-control">
                                                <asp:ListItem Text="--SELECT--" Value="" />
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator28" CssClass="validation-message"  runat="server" ErrorMessage="Select Date." ControlToValidate="EmpBdateDateDropdownlist" Display="Dynamic"></asp:RequiredFieldValidator>   
                                        </div>
                                        <div class="col-md-3">
                                            <asp:DropDownList ID="EmpBdateYearDropDownList" runat="server" AppendDataBoundItems="true" CssClass="form-control">
                                                <asp:ListItem Text="--SELECT--" Value="" />
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator29" CssClass="validation-message"  runat="server" ErrorMessage="Select Year." ControlToValidate="EmpBdateYearDropDownList" Display="Dynamic"></asp:RequiredFieldValidator>   
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
                                    <asp:Button ID="btnRegister" runat="server" CssClass="btn btn-success" Text="Register" OnClick="btnRegister_Click"
                               />
                                </div>
                            </div>
                        </asp:View>
                        <asp:View runat="server" ClientIDMode="Static" ID="NonEmployeeView">
                            <h1>Non-Employee</h1>
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
                                    <asp:RequiredFieldValidator CssClass="validation-message"  ID="RequiredFieldValidator14" runat="server" ErrorMessage="First name is required." ControlToValidate="tbFirstName2"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <label for="tbLastName2">Last Name <span style="color: red; margin-top: 22px;">*</span></label>
                                    <asp:TextBox ID="tbLastName2" runat="server" CssClass="form-control input-md"></asp:TextBox>
                                    <asp:RequiredFieldValidator CssClass="validation-message"  ID="RequiredFieldValidator15" runat="server" ErrorMessage="Last name is required." ControlToValidate="tbLastName2"></asp:RequiredFieldValidator>
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
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" CssClass="validation-message"  runat="server" ErrorMessage="Email is Required." ControlToValidate="tbEmail2" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbEmail2" CssClass="validation-message" Display="Dynamic" ErrorMessage="Email address is invalid." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <label for="tbAddress">Address <span style="color: red; margin-top: 22px;">*</span></label>
                                    <asp:TextBox ID="tbAddress2" runat="server" class="form-control input-md" Height="70px" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" CssClass="validation-message"  runat="server" ErrorMessage="Address is Required." ControlToValidate="tbAddress2"></asp:RequiredFieldValidator>
                                </div>
                            </div> 
                            <div class="row">
                                <div class="col-md-12">
                                    <label for="tbPassword2">Password <span style="color: red; margin-top: 22px;">*</span></label>
                                    <asp:TextBox ID="tbPassword2" runat="server" CssClass="form-control input-md"
                                        TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" CssClass="validation-message"  runat="server" ErrorMessage="Password is Required." ControlToValidate="tbPassword2" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="CustomValidator3" runat="server" ControlToValidate="tbPassword2" CssClass="validation-message" ErrorMessage="Password minimum length is 6." ValidateEmptyText="True" ValidationGroup="a" ClientValidationFunction="PasswordLengthValidate" Display="Dynamic"></asp:CustomValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <label for="tbConfirm2">Re-type Password <span style="color: red; margin-top: 22px;">*</span></label>
                                    <asp:TextBox ID="tbConfirm2" runat="server" CssClass="form-control input-md"
                                        TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" CssClass="validation-message"  Display="Dynamic" runat="server" ErrorMessage="Password is Required." ControlToValidate="tbConfirm2"></asp:RequiredFieldValidator>   
                                    <asp:CompareValidator ID="CompareValidator3" CssClass="validation-message" runat="server" Display="Dynamic" ErrorMessage="Password does not match." ControlToCompare="tbPassword2" ControlToValidate="tbConfirm2"></asp:CompareValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-9">
                                    <label for="tbPhone2">Mobile Number <span style="color: red; margin-top: 22px;">*</span></label>
                                    <asp:TextBox ID="tbPhone2" runat="server" CssClass="form-control input-md" MaxLength="10"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" CssClass="validation-message"  runat="server" ErrorMessage="Mobile Number is Required." ControlToValidate="tbPhone2" Display="Dynamic"></asp:RequiredFieldValidator>   
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
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21"  CssClass="validation-message"  runat="server" ErrorMessage="Select Month." ControlToValidate="NEBdayMonthDropDownList" Display="Dynamic"></asp:RequiredFieldValidator>   
                                        </div>
                                        <div class="col-md-3">
                                            <asp:DropDownList ID="NEBdayDayDropDownList" runat="server" AppendDataBoundItems="true"   CssClass="form-control">
                                                <asp:ListItem Text="--SELECT--" Value="" />
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" CssClass="validation-message"  runat="server" ErrorMessage="Select Date." ControlToValidate="NEBdayDayDropDownList" Display="Dynamic"></asp:RequiredFieldValidator>   
                                        </div>
                                        <div class="col-md-3">
                                            <asp:DropDownList ID="NEBdayYearDropDownList" runat="server" AppendDataBoundItems="true" CssClass="form-control">
                                                <asp:ListItem Text="--SELECT--" Value="" />
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" CssClass="validation-message"  runat="server" ErrorMessage="Select Year." ControlToValidate="NEBdayYearDropDownList" Display="Dynamic"></asp:RequiredFieldValidator>   
                                        </div>
                                        <div class="col-md-3">
                                               &nbsp;
                                        </div>
                                    </div> 
                                    
                                </div>
                            </div>
                            <br />
                             <asp:Button ID="btnRegister2" runat="server"
                                CssClass="btn btn-success" Text="Register" OnClick="btnRegister2_Click" 
                               />
                        </asp:View>
                    </asp:MultiView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
