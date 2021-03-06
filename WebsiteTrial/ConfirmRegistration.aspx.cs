﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using DataHelper;

namespace WebsiteTrial
{
    public partial class ConfirmRegistration : Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            DataAccess da = new DataAccess();
            if (base.Request.QueryString["user"] != null && base.Request.QueryString["confirmationCode"] != null)
            {
                string confirmCode = base.Request.QueryString["confirmationCode"].ToString();
                string empNo = base.Request.QueryString["user"].ToString();
                da.ConfirmUser(empNo, confirmCode);
                this.Literal1.Text = "<h3>Registration confirmed. Please login at the Home Page. <a href='Default.aspx'>Click Here</a></h3>";
                //base.Response.Redirect("~/Message.aspx?msg=");
            }
            da.Dispose();
            //base.Response.Redirect("~/Default.aspx");
        }
    }
}