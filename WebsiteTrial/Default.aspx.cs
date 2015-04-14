using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataHelper;
using DataHelper.DataHelper;

namespace WebsiteTrial
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (System.Convert.ToBoolean(this.Session["Logged"]))
                {
                    base.Response.Redirect("~/Home_Logged.aspx");
                    return;
                }
                NewsAnnoucementData na = new NewsAnnoucementData();
                this.GridView1.DataSource = na.GetTopTen();
                this.GridView1.DataBind();
            }
            else
            {
                this.Session["Logged"] = false;
            }
        }
        
    }
}