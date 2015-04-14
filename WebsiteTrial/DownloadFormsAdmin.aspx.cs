using DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebsiteTrial.Helper;

namespace WebsiteTrial
{
    public partial class DownloadFormsAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionHelper.EnsureAdminLogged();
            using (DataAccess da = new DataAccess())
            {
                this.DownlodablesGridView.DataSource = da.getAllDownloadables();
                this.DownlodablesGridView.DataBind();
            }
        }
    }
}