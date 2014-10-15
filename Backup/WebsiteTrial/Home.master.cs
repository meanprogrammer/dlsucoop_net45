using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using DataHelper;
using System.Web.UI.WebControls;

namespace WebsiteTrial
{
    public partial class Home : MasterPage
    {
        private static int count = 1;
        protected void Page_Load(object sender, System.EventArgs e)
        {
        }
        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            using (DataAccess da = new DataAccess())
            {
                if (Home.count == 3)
                {
                    this.EmpLogin.Enabled = false;
                }
                if (da.EmployeeNumberExistAndConfirmed(this.EmpLogin.UserName.ToString()))
                {
                    bool confirm = da.retrieveUserPass(this.EmpLogin.UserName.ToString(), this.EmpLogin.Password.ToString());
                    if (confirm)
                    {
                        base.Session["Logged"] = true;
                        base.Session["EmpNo"] = this.EmpLogin.UserName.ToString();
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