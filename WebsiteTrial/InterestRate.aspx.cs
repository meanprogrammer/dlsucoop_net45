using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataHelper;

namespace WebsiteTrial
{
    public partial class InterestRate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                using (DataAccess da = new DataAccess())
                {
                    this.GridView1.DataSource = da.GetLoanAmountMatrix();
                    this.GridView1.DataBind();
                }
            }
        }
    }
}