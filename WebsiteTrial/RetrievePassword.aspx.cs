using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Mail;
using DataHelper;
using System.Web.UI.WebControls;

namespace WebsiteTrial
{
    public partial class RetrievePassword : Page
    {
        private static int count = 1;
        protected void Page_Load(object sender, System.EventArgs e)
        {
        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
                
                using (DataAccess da = new DataAccess())
                {
                    if (da.EmployeeNumberExist(this.TextBox1.Text))
                    {
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append("Your Password is: " + da.GetPassword(this.TextBox1.Text));
                        using (MailHelper mail = new MailHelper())
                        {
                            mail.SendMailMessage("no_reply@dlsudcoop.com", da.GetEmployeeEmail(this.TextBox1.Text), "Password Recovery", sb.ToString());
                        }
                        this.alertmessage.InnerText = "Your password has been sent to your email.";
                        this.AlertDiv.Attributes["class"] = "alert alert-success";
                    }
                    else
                    {
                        this.alertmessage.InnerText = "Employee number does not exist in our database.";
                        this.AlertDiv.Attributes["class"] = "alert alert-danger";
                    }
                    return;
                }

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            using (DataAccess da = new DataAccess())
            {
                if (RetrievePassword.count == 3)
                {
                    this.EmpLogin.Enabled = false;
                }
                if (da.EmployeeNumberExistAndConfirmed(this.EmpLogin.UserName.ToString()))
                {
                    bool confirm = da.retrieveUserPass(this.EmpLogin.UserName.ToString(), this.EmpLogin.Password.ToString());
                    if (confirm)
                    {
                        this.Session["Logged"] = true;
                        this.Session["EmpNo"] = this.EmpLogin.UserName.ToString();
                        base.Response.Redirect("~/Home_Logged.aspx");
                    }
                    else
                    {
                        this.EmpLogin.FailureText = "Invalid Employee Number or Bad Password";
                    }
                }
            }
        }
    }
}