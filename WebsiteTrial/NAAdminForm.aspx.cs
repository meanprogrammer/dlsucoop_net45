using DataHelper.DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteTrial
{
    public partial class NAAdminForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            NewsAnnoucementData data = new NewsAnnoucementData();
            bool result = data.Save(this.TitleTextBox.Text.Trim(),
                        this.ContentTextBox.Text.Trim());
            if (result == true)
            { 

            }
        }
    }
}