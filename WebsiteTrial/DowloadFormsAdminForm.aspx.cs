using DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteTrial
{
    public partial class DowloadFormsAdminForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["id"]))
                {
                    int id = int.Parse(Request["id"]);
                    using (DataAccess da = new DataAccess())
                    {
                        DownloadableForm df = da.getOneDownloadableForm(id);
                        if (df != null)
                        {
                            this.FormTextTextBox.Text = df.FormText;
                            this.FormUrlTextBox.Text = df.FormUrl;
                        }
                    }
                }
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                int id = int.Parse(Request["id"]);
                //update
                using (DataAccess da = new DataAccess())
                {
                    result = da.UpdateDownloadableForm(id, this.FormTextTextBox.Text.Trim(),
                        this.FormUrlTextBox.Text.Trim());

                }
            }
            else 
            {
                //insert
                using (DataAccess da = new DataAccess())
                {
                    result = da.SaveDownloadableForm(this.FormTextTextBox.Text.Trim(),
                        this.FormUrlTextBox.Text.Trim());

                }
            }
            
            if (result)
            {
                Response.Redirect("DownloadFormsAdmin.aspx");
            }
        }
    }
}