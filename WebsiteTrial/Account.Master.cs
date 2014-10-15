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