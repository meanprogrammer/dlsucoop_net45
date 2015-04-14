using DataHelper.DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataHelper;

namespace WebsiteTrial
{
    public partial class NAAdminForm : System.Web.UI.Page
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
                        this.TitleTextBox.Text = na.Title;
                        this.ContentTextBox.Text = na.Content;
                    }
                }
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            NewsAnnoucementData data = new NewsAnnoucementData();
            bool result = false;
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                int id = int.Parse(Request["id"]);
                result = data.Update(id, this.TitleTextBox.Text.Trim(),
                       this.ContentTextBox.Text.Trim());
            }
            else
            {
                result = data.Save(this.TitleTextBox.Text.Trim(),
                       this.ContentTextBox.Text.Trim());
            }
           
            if (result == true)
            {
                Response.Redirect("~/NAAdmin.aspx");
            }
        }
    }
}