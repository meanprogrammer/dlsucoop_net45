using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using DataHelper;
using ASPNETChatControl;

namespace WebsiteTrial
{
    public partial class Account : MasterPage
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.Session["Logged"] = true;
            this.Session["empNo"] = "100023";

            string empNo = Session["EmpNo"].ToString();
            bool isEmployee = false;
            using (DataAccess da = new DataAccess())
            {
                isEmployee = da.IsEmployee(empNo);
            }

            if (isEmployee == true)
            {
                this.SettingsLinkButton.PostBackUrl = "~/Account_Settings.aspx";
            }
            else
            {
                this.SettingsLinkButton.PostBackUrl = "~/Account_Settings_ne.aspx";
            }
        }
        protected void LinkButton1_Click(object sender, System.EventArgs e)
        {
            try
            {
                ChatControl.StopSession();
            }
            finally
            {
                base.Session["Logged"] = false;
                base.Session["EmpNo"] = "";
            }
            base.Response.Redirect("~/Default.aspx");
        }
        protected void LinkButton2_Click(object sender, System.EventArgs e)
        {
            using (DataAccess da = new DataAccess())
            {
                if (!da.CompleteDetail(base.Session["EmpNo"].ToString()))
                {
                    base.Response.Redirect("~/Message.aspx?msg=Please complete your details in the account setting first before making a loan.");
                }
                base.Response.Redirect("~/Loan.aspx");
            }
        }
    }
}