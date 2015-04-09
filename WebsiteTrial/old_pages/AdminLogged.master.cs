using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using ASPNETChatControl;

namespace WebsiteTrial
{
    public partial class AdminLogged : MasterPage
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
                base.Session["AdminLogged"] = false;
                base.Response.Redirect("~/AdminLog.aspx");
            }
        }
    }
}