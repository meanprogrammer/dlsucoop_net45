using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataHelper;

namespace WebsiteTrial
{
    public partial class AdminLog : Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
        }
        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            using (DataAccess da = new DataAccess())
            {
                if (da.AdminLogin(this.AdminLoginControl.UserName, this.AdminLoginControl.Password))
                {
                    this.Session["AdminLogged"] = true;
                    base.Response.Redirect("~/AdminLoanApplication.aspx");
                }
                else
                {
                    this.AdminLoginControl.FailureText = "Invalid username and Password";
                }
            }
        }
    }
}