using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataHelper;

namespace WebsiteTrial
{
    public partial class RegSMS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string accessToken = Request.QueryString["access_token"];
            string subcriberNumber = Request.QueryString["subscriber_number"];

            using (DataAccess da = new DataAccess())
            {
                da.SaveAccessToken(accessToken, subcriberNumber);
                da.SaveDump(string.Format("{0}-{1}", accessToken, subcriberNumber));
            }
        }
    }
}