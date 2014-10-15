using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASPNETChatControl;

namespace WebsiteTrial
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, System.EventArgs e)
        {
            ChatControl.ContactListProvider = new MyContactListProvider();
        }
        protected void Session_Start(object sender, System.EventArgs e)
        {
        }
        protected void Application_BeginRequest(object sender, System.EventArgs e)
        {
        }
        protected void Application_AuthenticateRequest(object sender, System.EventArgs e)
        {
        }
        protected void Application_Error(object sender, System.EventArgs e)
        {
        }
        protected void Session_End(object sender, System.EventArgs e)
        {
        }
        protected void Application_End(object sender, System.EventArgs e)
        {
        }
    }
}