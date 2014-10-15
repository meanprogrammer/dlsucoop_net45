using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using DataHelper;

namespace WebsiteTrial
{
    public partial class AdminPage2 : Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            using (DataAccess da = new DataAccess())
            {
                this.gvLoan.DataSource = da.getApproved();
                this.gvLoan.DataBind();
            }
        }
    }
}