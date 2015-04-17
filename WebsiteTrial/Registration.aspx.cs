using DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mail;
using SMS;

namespace WebsiteTrial
{
    public partial class Registration : System.Web.UI.Page
    {
        private void DataBindDates(DropDownList list)
        {
            list.DataTextField = "Text";
            list.DataValueField = "Value";
            list.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.college();
                this.department();
                this.relatedEmployee();
                this.NEBdayDayDropDownList.DataSource = GetDays();
                DataBindDates(NEBdayDayDropDownList);

                this.NEBdayMonthDropDownList.DataSource = GetMonths();
                DataBindDates(NEBdayMonthDropDownList);

                this.NEBdayYearDropDownList.DataSource = GetYears();
                DataBindDates(NEBdayYearDropDownList);

                this.DateHiredDateDropdownlist.DataSource = GetDays();
                DataBindDates(DateHiredDateDropdownlist);

                this.DateHiredMonthDropdownlist.DataSource = GetMonths();
                DataBindDates(DateHiredMonthDropdownlist);

                this.DateHiredYearDropdownlist.DataSource = GetYears();
                DataBindDates(DateHiredYearDropdownlist);

                this.EmpBdateMonthDropdownlist.DataSource = GetMonths();
                DataBindDates(EmpBdateMonthDropdownlist);

                this.EmpBdateDateDropdownlist.DataSource = GetDays();
                DataBindDates(EmpBdateDateDropdownlist);

                this.EmpBdateYearDropDownList.DataSource = GetYears();
                DataBindDates(EmpBdateYearDropDownList);

                this.RegistrationRadioButtonList.SelectedIndex = 0;
                this.RegistrationMultiView.ActiveViewIndex = 0;
            }
            else
            {
                if (this.RegistrationRadioButtonList.SelectedIndex == 0)
                {
                    if (!(String.IsNullOrEmpty(this.tbPassword.Text.Trim())))
                    {
                        this.tbPassword.Attributes["value"] = this.tbPassword.Text;
                    }

                    if (!(String.IsNullOrEmpty(this.tbConfirm.Text.Trim())))
                    {
                        this.tbConfirm.Attributes["value"] = this.tbConfirm.Text;
                    }
                }

                if (this.RegistrationRadioButtonList.SelectedIndex == 1)
                {
                    if (!(String.IsNullOrEmpty(this.tbPassword2.Text.Trim())))
                    {
                        this.tbPassword2.Attributes["value"] = this.tbPassword2.Text;
                    }

                    if (!(String.IsNullOrEmpty(this.tbConfirm2.Text.Trim())))
                    {
                        this.tbConfirm2.Attributes["value"] = this.tbConfirm2.Text;
                    }
                }
            }
        }

        private void relatedEmployee()
        {
            using (DataAccess da = new DataAccess())
            {
                this.RelativeEmpDropDownList.DataSource = da.GetEligibleRelativeUsers();
                this.RelativeEmpDropDownList.DataTextField = "Name";
                this.RelativeEmpDropDownList.DataValueField = "EmpNo";
                this.RelativeEmpDropDownList.DataBind();
            }
        }

        protected void RegistrationTypeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.RegistrationTypeDropDownList.SelectedIndex == 1)
            {
                this.RegistrationMultiView.ActiveViewIndex = 0;
            }
            else if (this.RegistrationTypeDropDownList.SelectedIndex == 2)
            {
                this.RegistrationMultiView.ActiveViewIndex = 1;
            }
            else
            {
                this.RegistrationMultiView.ActiveViewIndex = -1;
            }
        }

        public void department()
        {
            using (DataAccess da = new DataAccess())
            {
                this.DDDepartment.DataSource = da.getDepartment(System.Convert.ToInt32(this.DDCollege.SelectedValue));
                this.DDDepartment.DataTextField = "DepartmentName";
                this.DDDepartment.DataValueField = "DepartmentID";
                this.DDDepartment.DataBind();
            }
        }
        public void college()
        {
            using (DataAccess da = new DataAccess())
            {
                this.DDCollege.DataSource = da.getColleges();
                this.DDCollege.DataTextField = "CollegeName";
                this.DDCollege.DataValueField = "CollegeID";
                this.DDCollege.DataBind();
            }
        }

        protected void DDCollege_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.department();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            using (DataAccess da = new DataAccess())
            {
                try
                {
                    //if (MessageParse.IsValidEmail(this.tbEmail.Text)) //&& MessageParse.IsLaSalleEmail(this.tbEmail.Text))
                    System.Collections.Generic.List<string> employee = new System.Collections.Generic.List<string>();

                    string number = this.tbPhone.Text;

                    Dictionary<string, string> values = new Dictionary<string, string>();
                    values.Add(ColumnKeys.EMP_NO, this.tbEmpNum.Text);
                    values.Add(ColumnKeys.EMAIL, this.tbEmail.Text);
                    values.Add(ColumnKeys.PASSWORD, this.tbPassword.Text);
                    values.Add(ColumnKeys.COLLEGE, this.DDCollege.Text);
                    values.Add(ColumnKeys.DEPARTMENT, this.DDDepartment.Text);
                    values.Add(ColumnKeys.EMP_STATUS, this.DDStatus.Text);

                    int dh_month = Convert.ToInt32(this.DateHiredMonthDropdownlist.SelectedValue);
                    int dh_day = Convert.ToInt32(this.DateHiredDateDropdownlist.SelectedValue);
                    int dh_year = Convert.ToInt32(this.DateHiredYearDropdownlist.SelectedValue);
                    DateTime dh = new DateTime(dh_year, dh_month, dh_day);
                    values.Add(ColumnKeys.DATE_HIRED, dh.ToShortDateString());
                    values.Add(ColumnKeys.ADDRESS, this.tbAddress.Text);

                    int bd_month = Convert.ToInt32(this.EmpBdateMonthDropdownlist.SelectedValue);
                    int bd_day = Convert.ToInt32(this.EmpBdateDateDropdownlist.SelectedValue);
                    int bd_year = Convert.ToInt32(this.EmpBdateYearDropDownList.SelectedValue);
                    DateTime bd = new DateTime(bd_year, bd_month, bd_day);

                    values.Add(ColumnKeys.BIRTHDATE, bd.ToShortDateString());
                    values.Add(ColumnKeys.FIRSTNAME, this.tbFirstName.Text);
                    values.Add(ColumnKeys.LASTNAME, this.tbLastName.Text);
                    values.Add(ColumnKeys.MIDDLENAME, this.tbMiddleName.Text);
                    values.Add(ColumnKeys.REG_TYPE, RegistrationRadioButtonList.SelectedIndex == 0 ? "Employee" : "Non-Employee");
                    values.Add(ColumnKeys.MOBILE, number);
                    values.Add(ColumnKeys.ATMNO, this.ATMTextbox.Text);
                    values.Add(ColumnKeys.TINNO, this.TINNoTextbox.Text);
                    values.Add(ColumnKeys.SSSNO, this.SSSNoTextBox.Text);
                    values.Add(ColumnKeys.GENDER, this.GenderDropDownList.SelectedValue);
                    values.Add(ColumnKeys.CIVILSTATUS, this.CivilStatusDropDownList.SelectedValue);
                    values.Add(ColumnKeys.FATHERNAME, this.FatherNameTextBox.Text);
                    values.Add(ColumnKeys.FATHER_OCC, this.FatherOccupationTextBox.Text);
                    values.Add(ColumnKeys.MOTHERNAME, this.MotherNameTextBox.Text);
                    values.Add(ColumnKeys.MOTHER_OCC, this.MotherOccupationTextBox.Text);
                    values.Add(ColumnKeys.SPOUSE, this.LegalSpouseTextBox.Text);
                    values.Add(ColumnKeys.SPOUSE_EMP, this.SpouseOccupationTextBox.Text);
                    values.Add(ColumnKeys.BUSINESSNAME, this.BusinessNameTextBox.Text);
                    values.Add(ColumnKeys.BUSINESSADD, this.BusinessAddressTextBox.Text);
                    values.Add(ColumnKeys.OTHERSOURCE, this.OtherSourceOfIncomeTextBox.Text);
                    values.Add(ColumnKeys.EMERGENCYNAME, this.ICENameTextBox.Text);
                    values.Add(ColumnKeys.EMERGENCYADD, this.ICEAddressTextBox.Text);
                    values.Add(ColumnKeys.EMERGENCYNO, this.ICEContactNumberTextBox.Text);

                    using (MailHelper mail = new MailHelper())
                    {
                        da.SaveEmployeeRegistrationLinq(values);
                        //da.SMSRegistrationInsert(employee, number);
                        //Commented
                        mail.SendMailMessage("dlsudmailer@gmail.com", this.tbEmail.Text, "Confirmation Link", mail.MakeEmailBody(this.tbEmpNum.Text));
                        //mail.SendMailMessage(mail.MakeEmailBody(this.tbEmpNum.Text));
                        da.SMSRegistrationUpdateMailPass(this.tbEmpNum.Text, mail.Pass);
                        //Commented
                        Messages msgObj = new Messages();
                        //Commented
                        msgObj.SendSMS(number, msgObj.SuccessfulRegistrationMessage(string.Format("{0},{1} {2}", values[ColumnKeys.LASTNAME], values[ColumnKeys.FIRSTNAME], values[ColumnKeys.MIDDLENAME])));
                        //Commented
                        msgObj.Dispose();
                    }
                    ClearEmployee();
                    this.alertmessage.InnerText = "You have registered to DLSU-D Coop. Please check you email for the confirmation link.";
                    this.AlertDiv.Attributes["class"] = "alert alert-success";
                }
                catch (Exception ex)
                {
                    this.alertmessage.InnerText = ex.Message;
                    this.AlertDiv.Attributes["class"] = "alert alert-danger";
                }
            }
        }

        private void ClearEmployee()
        {
            foreach (var item in this.RegistrationMultiView.Views[0].Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = string.Empty;
                }

                if (item is DropDownList)
                {
                    ((DropDownList)item).SelectedIndex = -1;
                }
            }
            this.tbPassword.Attributes["value"] = string.Empty;
            this.tbConfirm.Attributes["value"] = string.Empty;
        }

        private void ClearNonEmployee()
        {
            foreach (var item in this.RegistrationMultiView.Views[1].Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = string.Empty;
                }

                if (item is DropDownList)
                {
                    ((DropDownList)item).SelectedIndex = -1;
                }
            }
            this.tbPassword2.Attributes["value"] = string.Empty;
            this.tbConfirm2.Attributes["value"] = string.Empty;
        }

        protected void ValidateRegistration(object source, ServerValidateEventArgs args)
        {
            using (DataAccess da = new DataAccess())
            {
                args.IsValid = (!da.EmployeeNumberExist(this.tbEmpNum.Text) && !da.NewRegistrationExist(this.tbEmpNum.Text, this.tbEmail.Text, this.tbPhone.Text.Trim()));
            }
        }

        protected void btnRegister2_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            using (DataAccess da = new DataAccess())
            {
                //if (MessageParse.IsValidEmail(this.tbEmail.Text)) //&& MessageParse.IsLaSalleEmail(this.tbEmail.Text))

                try
                {


                    string number = this.tbPhone2.Text;

                    Dictionary<string, string> values = new Dictionary<string, string>();
                    values.Add(ColumnKeys.EMP_NO, da.GetLastNonEmployeeID());
                    values.Add(ColumnKeys.EMAIL, this.tbEmail2.Text);
                    values.Add(ColumnKeys.PASSWORD, this.tbPassword2.Text);
                    values.Add(ColumnKeys.ADDRESS, this.tbAddress2.Text);

                    int month = Convert.ToInt32(this.NEBdayMonthDropDownList.SelectedItem.Value);
                    int day = Convert.ToInt32(this.NEBdayDayDropDownList.SelectedValue);
                    int year = Convert.ToInt32(this.NEBdayYearDropDownList.SelectedValue);

                    DateTime dt = new DateTime(year, month, day);

                    values.Add(ColumnKeys.BIRTHDATE, dt.ToShortDateString());
                    values.Add(ColumnKeys.FIRSTNAME, this.tbFirstName2.Text);
                    values.Add(ColumnKeys.LASTNAME, this.tbLastName2.Text);
                    values.Add(ColumnKeys.MIDDLENAME, this.tbMiddleName2.Text);
                    values.Add(ColumnKeys.REG_TYPE, this.RegistrationRadioButtonList.SelectedIndex == 0 ? "Employee" : "Non-Employee");
                    values.Add(ColumnKeys.MOBILE, number);
                    values.Add(ColumnKeys.RELATIVE_ID, this.RelativeEmpDropDownList.SelectedValue);

                    using (MailHelper mail = new MailHelper())
                    {
                        da.SMSRegistrationInsertNonEmployeeLinq(values);
                        //Commented
                        mail.SendMailMessage("dlsudmailer@gmail.com", this.tbEmail2.Text, "Confirmation Link", mail.MakeEmailBody(values[ColumnKeys.EMP_NO]));
                        //mail.SendMailMessage(mail.MakeEmailBody(this.tbEmpNum.Text));
                        da.SMSRegistrationUpdateMailPass(values[ColumnKeys.EMP_NO], mail.Pass);
                        //Commented
                        Messages msgObj = new Messages();
                        //Commented
                        msgObj.SendSMS(number, msgObj.SuccessfulRegistrationMessage(values[ColumnKeys.EMP_NO]));
                        //Commented
                        msgObj.Dispose();


                    }
                    ClearNonEmployee();
                    //base.Response.Redirect("~/Message.aspx?msg=You have registered to DLSU-D Coop. Please check you email for the confirmation link.");
                    this.alertmessage.InnerText = "You have registered to DLSU-D Coop. Please check you email for the confirmation link." +
                                                    string.Format("Your non-employee id is {0}.", values[ColumnKeys.EMP_NO]);
                    this.AlertDiv.Attributes["class"] = "alert alert-success";
                }
                catch (Exception ex)
                {
                    this.alertmessage.InnerText = ex.Message;
                    this.AlertDiv.Attributes["class"] = "alert alert-danger";                
                }
            }
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            //this.txtbirthday2.Text = this.Calendar2.SelectedDate.ToShortDateString();
        }

        private List<DateMonthDTO> GetMonths()
        {
            List<DateMonthDTO> col = new List<DateMonthDTO>();
            col.Add(new DateMonthDTO("January", "1"));
            col.Add(new DateMonthDTO("February", "2"));
            col.Add(new DateMonthDTO("March", "3"));
            col.Add(new DateMonthDTO("April", "4"));
            col.Add(new DateMonthDTO("May", "5"));
            col.Add(new DateMonthDTO("June", "6"));
            col.Add(new DateMonthDTO("July", "7"));
            col.Add(new DateMonthDTO("August", "8"));
            col.Add(new DateMonthDTO("September", "9"));
            col.Add(new DateMonthDTO("October", "10"));
            col.Add(new DateMonthDTO("November", "11"));
            col.Add(new DateMonthDTO("December", "12"));
            return col;
        }

        private List<DateMonthDTO> GetDays()
        {
            List<DateMonthDTO> col = new List<DateMonthDTO>();
            for (int i = 1; i <= 31; i++)
            {
                col.Add(new DateMonthDTO(i.ToString(), i.ToString()));
            }
            return col;
        }

        private List<DateMonthDTO> GetYears()
        {
            List<DateMonthDTO> col = new List<DateMonthDTO>();
            for (int i = 2014; i >= 1900; i--)
            {
                col.Add(new DateMonthDTO(i.ToString(), i.ToString()));
            }
            return col;
        }

        protected void RegistrationRadioButtonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.RegistrationRadioButtonList.SelectedIndex == 0)
            {
                this.RegistrationMultiView.ActiveViewIndex = 0;
            }
            else if (this.RegistrationRadioButtonList.SelectedIndex == 1)
            {
                this.RegistrationMultiView.ActiveViewIndex = 1;
            }
            else
            {
                this.RegistrationMultiView.ActiveViewIndex = -1;
            }
        }
    }
}