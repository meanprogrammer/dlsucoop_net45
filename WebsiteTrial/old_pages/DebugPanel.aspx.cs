using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataHelperDebug;
using System.Web.UI;

namespace WebsiteTrial
{
    public partial class DebugPanel : Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            this.Panel1.Visible = true;
        }
        protected void Button2_Click(object sender, System.EventArgs e)
        {
            using (DataAccessDebug da = new DataAccessDebug())
            {
                da.DeleteAllUsers();
                da.DeleteAllTransactions();
            }
        }
        protected void Button3_Click(object sender, System.EventArgs e)
        {
            base.Response.Redirect("~/Default.aspx");
        }
    }
}