using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using DataHelper;
using Mail;
using SMS;

namespace WebsiteTrial
{
    public partial class Registration : Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.college();
                this.department();
            }
        }
        protected void DDCollege_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.department();
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
        protected void btnRegister_Click(object sender, System.EventArgs e)
        {
            using (DataAccess da = new DataAccess())
            {
                if (this.tbPassword.Text == this.tbConfirm.Text && this.tbEmpNum.Text != "" && this.tbLastName.Text != "" && this.tbFirstName.Text != "" && this.tbPassword.Text.Length >= 6)
                {
                    long phone;
                    bool x = long.TryParse(this.tbPhone.Text, out phone);
                    if (!da.EmployeeNumberExist(this.tbEmpNum.Text) && !da.NewRegistrationExist(this.tbEmpNum.Text, this.tbEmail.Text, phone.ToString()))
                    {
                        if (MessageParse.IsValidEmail(this.tbEmail.Text)) //&& MessageParse.IsLaSalleEmail(this.tbEmail.Text))
                        {
                            if (x && this.tbPhone.Text.Length <= 13)
                            {
                                System.Collections.Generic.List<string> employee = new System.Collections.Generic.List<string>();
                                //employee.Add(this.tbName.Text);
                                employee.Add(this.tbEmpNum.Text);
                                employee.Add(this.tbEmail.Text);
                                employee.Add(this.tbPassword.Text);
                                employee.Add(this.DDCollege.Text);
                                employee.Add(this.DDDepartment.Text);
                                employee.Add(this.DDStatus.Text);
                                employee.Add(this.Calendar1.SelectedDate.ToShortDateString());
                                employee.Add(this.tbAddress.Text);
                                employee.Add(this.Calendar2.SelectedDate.ToShortDateString());
                                string number = this.tbPhone.Text;
                                using (MailHelper mail = new MailHelper())
                                {
                                    da.SMSRegistrationInsert(employee, number);
                                    //Commented
                                    mail.SendMailMessage("dlsudmailer@gmail.com", this.tbEmail.Text, "Confirmation Link", mail.MakeEmailBody(this.tbEmpNum.Text));
                                    //mail.SendMailMessage(mail.MakeEmailBody(this.tbEmpNum.Text));
                                    da.SMSRegistrationUpdateMailPass(this.tbEmpNum.Text, mail.Pass);
                                    //Commented
                                    Messages msgObj = new Messages();
                                    //Commented
                                    msgObj.SendSMS(number, msgObj.SuccessfulRegistrationMessage(employee[0]));
                                    //Commented
                                    msgObj.Dispose();
                                }
                                base.Response.Redirect("~/Message.aspx?msg=You have registered to DLSU-D Coop. Please check you email for the confirmation link.");
                            }
                            else
                            {
                                this.lblConfirmNote.Text = "Invalid Characters in mobile number";
                            }
                        }
                        else
                        {
                            this.lblEmailNote.Text = "Email must be a valid La Salle Dasmariñas Email Address.";
                        }
                    }
                    else
                    {
                        this.lblConfirmNote.Text = "Employee Exist";
                    }
                }
                else
                {
                    this.lblPassNote.Text = "*";
                    this.lblPassNote2.Text = "*";
                    this.lblConfirmNote.Text = "Password Does not match";
                }
            }
        }
        protected void Calendar1_SelectionChanged(object sender, System.EventArgs e)
        {
            this.txtdatehired.Text = this.Calendar1.SelectedDate.ToShortDateString();
            this.Calendar1.Visible = false;
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (!this.Calendar1.Visible)
            {
                this.Calendar1.Visible = true;
                return;
            }
            this.Calendar1.Visible = false;
        }
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
        }
        protected void tbConfirm_TextChanged(object sender, System.EventArgs e)
        {
            if (this.tbConfirm.Text != this.tbPassword.Text)
            {
                this.lblPassNote2.Text = "Password Does not match";
                return;
            }
            this.lblPassNote2.Text = "";
        }
        protected void tbPassword_TextChanged(object sender, System.EventArgs e)
        {
            if (this.tbPassword.Text.Length < 6)
            {
                this.lblPassNote.Text = "Passwords must be at least 6 characters";
                return;
            }
            this.lblPassNote.Text = "";
        }
        protected void tbEmail_TextChanged(object sender, System.EventArgs e)
        {
            this.lblEmailNote.Text = "";
            if (!MessageParse.IsValidEmail(this.tbEmail.Text) || !MessageParse.IsLaSalleEmail(this.tbEmail.Text))
            {
                this.lblEmailNote.Text = "Email must be a valid La Salle Dasmariñas Email Address.";
            }
        }
    }
}