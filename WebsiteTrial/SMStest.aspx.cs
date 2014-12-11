using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS;

namespace WebsiteTrial
{
    public partial class SMStest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SMSHelper sms = new SMSHelper();
            sms.SendSMS("9155642343", "hey dude");
        }
    }
}