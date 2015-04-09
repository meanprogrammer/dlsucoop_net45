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
        private string GetCurrentPageName()
        {
            string sPath = Request.Url.AbsolutePath;
            System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
            string sRet = oInfo.Name;
            return sRet;
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            /*
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
            }*/
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
    }
}