using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace WebsiteTrial.Helper
{
    public class SessionHelper
    {
        public static void EnsureAdminLogged() 
        {
            if (HttpContext.Current.Session["AdminLogged"] == null)
            {
                HttpContext.Current.Response.Redirect("~/AdminLogin.aspx");
            }
        }
    }
}