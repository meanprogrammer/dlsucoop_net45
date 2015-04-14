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
    }
}