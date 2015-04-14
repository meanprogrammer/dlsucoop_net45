using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataHelper.DataHelper;
using WebsiteTrial.Helper;

namespace WebsiteTrial
{
    public partial class NAAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionHelper.EnsureAdminLogged();
            if (!Page.IsPostBack)
            {
                NewsAnnoucementData data = new NewsAnnoucementData();
                this.GridView1.DataSource = data.GetTopTen();
                this.GridView1.DataBind();
            }
        }
    }
}