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
    public partial class Registration2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.college();
                this.department();
            }
        }

        protected void RegistrationTypeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.RegistrationTypeDropDownList.SelectedIndex == 1) {
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
            using (DataAccess da = new DataAccess())
            {
                    //if ())
                    
                        //if (MessageParse.IsValidEmail(this.tbEmail.Text)) //&& MessageParse.IsLaSalleEmail(this.tbEmail.Text))
                        
                                System.Collections.Generic.List<string> employee = new System.Collections.Generic.List<string>();
                                //employee.Add(this.tbName.Text);
                                employee.Add(this.tbEmpNum.Text);
                                employee.Add(this.tbEmail.Text);
                                employee.Add(this.tbPassword.Text);
                                employee.Add(this.DDCollege.Text);
                                employee.Add(this.DDDepartment.Text);
                                employee.Add(this.DDStatus.Text);
                                employee.Add(this.Calendar3.SelectedDate.ToShortDateString());
                                employee.Add(this.tbAddress.Text);
                                employee.Add(this.Calendar1.SelectedDate.ToShortDateString());
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

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            using (DataAccess da = new DataAccess())
            {
                args.IsValid = (!da.EmployeeNumberExist(this.tbEmpNum.Text) && !da.NewRegistrationExist(this.tbEmpNum.Text, this.tbEmail.Text, this.tbPhone.Text.Trim()));
            }
            
        }
    }
}