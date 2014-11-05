<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Registration2.aspx.cs" Inherits="WebsiteTrial.Registration2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            <div class="row">
                <div class="col-md-12">
                    <asp:MultiView ID="RegistrationMultiView" runat="server">
                        <asp:View runat="server" ClientIDMode="Static" ID="EmployeeView">
                            <div class="row">
                                <div class="col-md-12">
                                    <label for="tbEmpNum">Employee ID <span style="color: red; margin-top: 22px;">*</span></label>
                                    <asp:TextBox ID="tbEmpNum" runat="server" CssClass="form-control input-md"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Employee ID is required." ControlToValidate="tbEmpNum"></asp:RequiredFieldValidator>
                                </div>
                                
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <label for="tbFirstName">First Name <span style="color: red; margin-top: 22px;">*</span></label>
                                    <asp:TextBox ID="tbFirstName" runat="server" CssClass="form-control input-md"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="First name is required." ControlToValidate="tbFirstName"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <label for="tbLastName">Last Name <span style="color: red; margin-top: 22px;">*</span></label>
                                    <asp:TextBox ID="tbLastName" runat="server" CssClass="form-control input-md"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Last name is required." ControlToValidate="tbLastName"></asp:RequiredFieldValidator>
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
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Email is Required." ControlToValidate="tbEmail"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <label for="tbAddress">Address <span style="color: red; margin-top: 22px;">*</span></label>
                                    <asp:TextBox ID="tbAddress" runat="server" class="form-control input-md" Height="70px" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Address is Required." ControlToValidate="tbAddress"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <label for="tbPassword">Password <span style="color: red; margin-top: 22px;">*</span></label>
                                    <asp:TextBox ID="tbPassword" runat="server" CssClass="form-control input-md"
                                        TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Password is Required." ControlToValidate="tbPassword"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <label for="tbConfirm">Re-type Password <span style="color: red; margin-top: 22px;">*</span></label>
                                    <asp:TextBox ID="tbConfirm" runat="server" CssClass="form-control input-md"
                                        TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Display="Dynamic" runat="server" ErrorMessage="Password is Required." ControlToValidate="tbConfirm"></asp:RequiredFieldValidator>   
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" ErrorMessage="Password does not match." ControlToCompare="tbPassword" ControlToValidate="tbConfirm"></asp:CompareValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <label for="DDCollege">College <span style="color: red; margin-top: 22px;">*</span></label>
                                    <asp:DropDownList ID="DDCollege" runat="server" class="form-control"
                                        AutoPostBack="True" OnSelectedIndexChanged="DDCollege_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="College is Required." ControlToValidate="DDCollege"></asp:RequiredFieldValidator>   
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
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Department is Required." ControlToValidate="DDDepartment"></asp:RequiredFieldValidator>   
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
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Status is Required." ControlToValidate="DDStatus"></asp:RequiredFieldValidator>   
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <label for="txtdatehired">Date Hired <span style="color: red; margin-top: 22px;">*</span></label>
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
                                    <asp:TextBox ID="txtdatehired" runat="server" CssClass="form-control input-md">mm/dd/yyyy</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Date hired is Required." ControlToValidate="txtdatehired"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <label for="tbPhone">Mobile Number <span style="color: red; margin-top: 22px;">*</span></label>
                                    <asp:TextBox ID="tbPhone" runat="server" CssClass="form-control input-md"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Mobile Number is Required." ControlToValidate="tbPhone"></asp:RequiredFieldValidator>   
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <label for="txtbirthday">Birthdate  <span style="color: red; margin-top: 22px;">*</span></label>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:Calendar ID="Calendar2" runat="server"
                                                OnSelectionChanged="Calendar2_SelectionChanged" Visible="False" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
                                                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                                                <OtherMonthDayStyle ForeColor="#999999" />
                                                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                                <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                                                <TodayDayStyle BackColor="#CCCCCC" />
                                            </asp:Calendar>
                                            <asp:TextBox ID="txtbirthday" runat="server" CssClass="form-control input-md"
                                                Style="display: inline !important;">mm/dd/yyyy</asp:TextBox>
                                            <asp:ImageButton ID="ImageButton2" runat="server" Height="25px"
                                                ImageUrl="~/images/calendar_icon.jpg" OnClick="ImageButton2_Click"
                                                Width="20px" CausesValidation="False" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ImageButton2" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="Calendar2" EventName="SelectionChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="BirthDate is Required." ControlToValidate="txtbirthday"></asp:RequiredFieldValidator>   
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
