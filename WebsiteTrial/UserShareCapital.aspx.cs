using DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteTrial
{
    public partial class UserShareCapital : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string empNo = Session["empNo"].ToString();
            using (DataAccess da = new DataAccess())
            {
                ShareCapital sc = da.GetShareCapital(empNo);
                if (sc != null)
                {
                    this.TextBox1.Text = sc.ShareCapital1.ToString();
                    this.TextBox1.Enabled = false;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string empNo = Session["empNo"].ToString();
            using (DataAccess da = new DataAccess())
            {
                da.SaveShareCapital2(empNo, double.Parse(TextBox1.Text));
            }
        }
    }
}