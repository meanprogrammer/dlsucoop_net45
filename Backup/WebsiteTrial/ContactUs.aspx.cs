using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataHelper;

namespace WebsiteTrial
{
    public partial class ContactUs : System.Web.UI.Page
    {
        private static int count = 1;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            using (DataAccess da = new DataAccess())
            {
                if (ContactUs.count == 3)
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