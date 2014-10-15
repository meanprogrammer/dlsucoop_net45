using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace WebsiteTrial
{
    public partial class Message : Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.Label1.Text = base.Request.QueryString["msg"].ToString();
        }
    }
}