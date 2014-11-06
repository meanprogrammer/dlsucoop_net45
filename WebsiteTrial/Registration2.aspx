<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Registration2.aspx.cs" Inherits="WebsiteTrial.Registration2" %>

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
            <div class="row">
                <div class="col-md-12">
                    <label for="RegistrationTypeDropDownList">Registration Type</label>
                    <asp:DropDownList ID="RegistrationTypeDropDownList" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="RegistrationTypeDropDownList_SelectedIndexChanged">
                        <asp:ListItem>--SELECT--</asp:ListItem>
                        <asp:ListItem>Employee</asp:ListItem>
                        <asp:ListItem>Non-Employee</asp:ListItem>
                    </asp:DropDownList>
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
                                <div class="col-md-12">
                                    <label for="tbEmpNum">Employee ID <span style="color: red; margin-top: 22px;">*</span></label>
                                    <asp:TextBox ID="tbEmpNum" runat="server" CssClass="form-control input-md"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="validation-message" runat="server" ErrorMessage="Employee ID is required." ControlToValidate="tbEmpNum"></asp:RequiredFieldValidator>
                                </div>
                                
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <label for="tbFirstName">First Name <span style="color: red; margin-top: 22px;">*</span></label>
                                    <asp:TextBox ID="tbFirstName" runat="server" CssClass="form-control input-md"></asp:TextBox>
                                    <asp:RequiredFieldValidator CssClass="validation-message"  ID="RequiredFieldValidator1" runat="server" ErrorMessage="First name is required." ControlToValidate="tbFirstName"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <label for="tbLastName">Last Name <span style="color: red; margin-top: 22px;">*</span></label>
                                    <asp:TextBox ID="tbLastName" runat="server" CssClass="form-control input-md"></asp:TextBox>
                                    <asp:RequiredFieldValidator CssClass="validation-message"  ID="RequiredFieldValidator2" runat="server" ErrorMessage="Last name is required." ControlToValidate="tbLastName"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <label for="tbMiddleName">Middle Name</label>
                                    <asp:TextBox ID="tbMiddleName" runat="server" CssClass="form-control input-md"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
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
                                <div class="col-md-12">
                                    <label for="tbPassword">Password <span style="color: red; margin-top: 22px;">*</span></label>
                                    <asp:TextBox ID="tbPassword" runat="server" CssClass="form-control input-md"
                                        TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="validation-message"  runat="server" ErrorMessage="Password is Required." ControlToValidate="tbPassword" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="tbPassword" CssClass="validation-message" ErrorMessage="Password minimum length is 6." ValidateEmptyText="True" ValidationGroup="a" ClientValidationFunction="PasswordLengthValidate" Display="Dynamic"></asp:CustomValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <label for="tbConfirm">Re-type Password <span style="color: red; margin-top: 22px;">*</span></label>
                                    <asp:TextBox ID="tbConfirm" runat="server" CssClass="form-control input-md"
                                        TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" CssClass="validation-message"  Display="Dynamic" runat="server" ErrorMessage="Password is Required." ControlToValidate="tbConfirm"></asp:RequiredFieldValidator>   
                                    <asp:CompareValidator ID="CompareValidator1" CssClass="validation-message" runat="server" Display="Dynamic" ErrorMessage="Password does not match." ControlToCompare="tbPassword" ControlToValidate="tbConfirm"></asp:CompareValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <label for="DDCollege">College <span style="color: red; margin-top: 22px;">*</span></label>
                                    <asp:DropDownList ID="DDCollege" runat="server" class="form-control"
                                        AutoPostBack="True" OnSelectedIndexChanged="DDCollege_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8"  CssClass="validation-message"  runat="server" ErrorMessage="College is Required." ControlToValidate="DDCollege"></asp:RequiredFieldValidator>   
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
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
                                        <div class="col-md-6">
                                            <asp:Calendar ID="Calendar3" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" OnSelectionChanged="Calendar3_SelectionChanged" Width="200px">
                                                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                                <NextPrevStyle VerticalAlign="Bottom" />
                                                <OtherMonthDayStyle ForeColor="#808080" />
                                                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                                <SelectorStyle BackColor="#CCCCCC" />
                                                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                                <WeekendDayStyle BackColor="#FFFFCC" />
                                            </asp:Calendar>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:TextBox ID="txtdatehired" runat="server" CssClass="form-control input-md" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" CssClass="validation-message" runat="server" ErrorMessage="Date hired is Required." ControlToValidate="txtdatehired"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-9">
                                    <label for="tbPhone">Mobile Number <span style="color: red; margin-top: 22px;">*</span></label>
                                    <asp:TextBox ID="tbPhone" runat="server" CssClass="form-control input-md" MaxLength="10"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" CssClass="validation-message"  runat="server" ErrorMessage="Mobile Number is Required." ControlToValidate="tbPhone" Display="Dynamic"></asp:RequiredFieldValidator>   
                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="tbPhone" CssClass="validation-message" Display="Dynamic" ErrorMessage="Numeric only." Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                                </div>
                                <div class="col-md-3">
                                    <span>Format: 915XXXXXXX</span>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <label for="txtbirthday">Birthdate  <span style="color: red; margin-top: 22px;">*</span></label>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" OnSelectionChanged="Calendar1_SelectionChanged" Width="200px">
                                                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                                <NextPrevStyle VerticalAlign="Bottom" />
                                                <OtherMonthDayStyle ForeColor="#808080" />
                                                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                                <SelectorStyle BackColor="#CCCCCC" />
                                                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                                <WeekendDayStyle BackColor="#FFFFCC" />
                                            </asp:Calendar>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:TextBox ID="txtbirthday" CssClass="form-control input-md" runat="server" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div> 
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" CssClass="validation-message"  runat="server" ErrorMessage="BirthDate is Required." ControlToValidate="txtbirthday"></asp:RequiredFieldValidator>   
                                </div>
                            </div>
                            <asp:Button ID="btnRegister" runat="server"
                                CssClass="btn btn-success" Text="Register" OnClick="btnRegister_Click"
                               />
                        </asp:View>
                        <asp:View runat="server" ClientIDMode="Static" ID="NonEmployeeView">
                            <h1>Non-Employee</h1>
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
