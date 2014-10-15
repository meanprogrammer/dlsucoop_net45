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
            if (this.TextBox1.Text != "")
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
                        base.Response.Redirect("~/Messsage.aspx?msg=Your password has been sent to your email");
                    }
                    else
                    {
                        this.Label1.Text = "Employee number does not exist in our database.";
                    }
                    return;
                }
            }
            this.Label1.Text = "Please type your employee number.";
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