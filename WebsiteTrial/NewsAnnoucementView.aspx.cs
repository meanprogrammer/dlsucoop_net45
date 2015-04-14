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
    public partial class NewsAnnoucementView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["id"]))
                {
                    int id = int.Parse(Request["id"]);
                    NewsAnnoucementData data = new NewsAnnoucementData();
                    NewsAndAnnouncement na = data.GetOneNewsAndAnnoucement(id);
                    if (na != null)
                    {
                        this.TitleLabel.Text = na.Title;
                        this.ContentLabel.Text = na.Content;
                    }
                }
            }
        }
    }
}