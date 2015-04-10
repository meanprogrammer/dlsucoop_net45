using ASPNETChatControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteTrial
{
    public partial class MemberLogout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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