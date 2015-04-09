using DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteTrial
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            using (DataAccess da = new DataAccess())
            {
                if (da.AdminLogin(this.AdminLoginControl.UserName, this.AdminLoginControl.Password))
                {
                    this.Session["AdminLogged"] = true;
                    base.Response.Redirect("~/AdminPage.aspx");
                }
                else
                {
                    this.AdminLoginControl.FailureText = "Invalid username and Password";
                }
            }
        }

    }
}