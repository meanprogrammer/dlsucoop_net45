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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.college();
                this.department();
                this.relatedEmployee();
            }
            else
            {
                if (this.RegistrationTypeDropDownList.SelectedIndex == 1)
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

                if (this.RegistrationTypeDropDownList.SelectedIndex == 2)
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

        /*
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            if (!this.Calendar2.Visible)
            {
                this.Calendar2.Visible = true;
                return;
            }
            this.Calendar2.Visible = false;
        }
        protected void Calendar2_SelectionChanged(object sender, System.EventArgs e)
        {
            this.txtbirthday.Text = this.Calendar2.SelectedDate.ToShortDateString();
            this.Calendar2.Visible = false;
        }*/

        protected void Calendar3_SelectionChanged(object sender, EventArgs e)
        {
            this.txtdatehired.Text = this.Calendar3.SelectedDate.ToShortDateString();
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            this.txtbirthday.Text = this.Calendar1.SelectedDate.ToShortDateString();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            using (DataAccess da = new DataAccess())
            {
                //if ())

                //if (MessageParse.IsValidEmail(this.tbEmail.Text)) //&& MessageParse.IsLaSalleEmail(this.tbEmail.Text))

                System.Collections.Generic.List<string> employee = new System.Collections.Generic.List<string>();
                //employee.Add(this.tbName.Text);

                /*
                employee.Add("oldname");
                employee.Add(this.tbEmpNum.Text);
                employee.Add(this.tbEmail.Text);
                employee.Add(this.tbPassword.Text);
                employee.Add(this.DDCollege.Text);
                employee.Add(this.DDDepartment.Text);
                employee.Add(this.DDStatus.Text);
                employee.Add(this.Calendar3.SelectedDate.ToShortDateString());
                employee.Add(this.tbAddress.Text);
                employee.Add(this.Calendar1.SelectedDate.ToShortDateString());
                employee.Add(this.tbFirstName.Text);
                employee.Add(this.tbLastName.Text);
                employee.Add(this.tbMiddleName.Text);
                employee.Add(this.RegistrationTypeDropDownList.SelectedValue);
                 * */
                string number = this.tbPhone.Text;

                Dictionary<string, string> values = new Dictionary<string, string>();
                values.Add(ColumnKeys.EMP_NO, this.tbEmpNum.Text);
                values.Add(ColumnKeys.EMAIL, this.tbEmail.Text);
                values.Add(ColumnKeys.PASSWORD, this.tbPassword.Text);
                values.Add(ColumnKeys.COLLEGE, this.DDCollege.Text);
                values.Add(ColumnKeys.DEPARTMENT, this.DDDepartment.Text);
                values.Add(ColumnKeys.EMP_STATUS, this.DDStatus.Text);
                values.Add(ColumnKeys.DATE_HIRED, this.Calendar3.SelectedDate.ToShortDateString());
                values.Add(ColumnKeys.ADDRESS, this.tbAddress.Text);
                values.Add(ColumnKeys.BIRTHDATE, this.Calendar1.SelectedDate.ToShortDateString());
                values.Add(ColumnKeys.FIRSTNAME, this.tbFirstName.Text);
                values.Add(ColumnKeys.LASTNAME, this.tbLastName.Text);
                values.Add(ColumnKeys.MIDDLENAME, this.tbMiddleName.Text);
                values.Add(ColumnKeys.REG_TYPE, this.RegistrationTypeDropDownList.SelectedValue);
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

                /*
[ATMAccountNo] [nvarchar](50) NULL,
[TINNo] [nvarchar](50) NULL,
[SSSNo] [nvarchar](50) NULL,
[Gender] [nvarchar](10) NULL,
[CivilStatus] [nvarchar](20) NULL,
[FatherName] [nvarchar](50) NULL,
[FatherOccupation] [nvarchar](50) NULL,
[MotherName] [nvarchar](50) NULL,
[MotherOccupation] [nvarchar](50) NULL,
[LegalSpouse] [nvarchar](50) NULL,
[SpouseEmployer] [nvarchar](50) NULL,
[BusinessName] [nvarchar](50) NULL,
[BusinessAddress] [nvarchar](150) NULL,
[OtherSourceOfIncome] [nvarchar](250) NULL,
[EmergencyName] [nvarchar](50) NULL,
[EmergencyAddress] [nvarchar](50) NULL,
[EmergencyNumber] [nvarchar](50) NULL
*/


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
                base.Response.Redirect("~/Message.aspx?msg=You have registered to DLSU-D Coop. Please check you email for the confirmation link.");

                /*}
                else
                {
                    this.lblEmailNote.Text = "Email must be a valid La Salle Dasmariñas Email Address.";
                }
            }
            else
            {
                this.lblConfirmNote.Text = "Employee Exist";
            }*/
            }
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

                string number = this.tbPhone2.Text;

                Dictionary<string, string> values = new Dictionary<string, string>();
                values.Add(ColumnKeys.EMP_NO, da.GetLastNonEmployeeID());
                values.Add(ColumnKeys.EMAIL, this.tbEmail2.Text);
                values.Add(ColumnKeys.PASSWORD, this.tbPassword2.Text);
                values.Add(ColumnKeys.ADDRESS, this.tbAddress2.Text);
                values.Add(ColumnKeys.BIRTHDATE, this.Calendar2.SelectedDate.ToShortDateString());
                values.Add(ColumnKeys.FIRSTNAME, this.tbFirstName2.Text);
                values.Add(ColumnKeys.LASTNAME, this.tbLastName2.Text);
                values.Add(ColumnKeys.MIDDLENAME, this.tbMiddleName2.Text);
                values.Add(ColumnKeys.REG_TYPE, this.RegistrationTypeDropDownList.SelectedValue);
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
                base.Response.Redirect("~/Message.aspx?msg=You have registered to DLSU-D Coop. Please check you email for the confirmation link.");

                /*}
                else
                {
                    this.lblEmailNote.Text = "Email must be a valid La Salle Dasmariñas Email Address.";
                }
            }
            else
            {
                this.lblConfirmNote.Text = "Employee Exist";
            }*/
            }
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            this.txtbirthday2.Text = this.Calendar2.SelectedDate.ToShortDateString();
        }
    }
}