using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataHelper;

namespace WebsiteTrial
{
    public partial class ViewAttachment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(Request["transId"]))
            {
                int id = int.Parse(Request["transId"]);
                using (DataAccess da = new DataAccess())
                {
                    LoanApplication la = da.GetOneLoanApplication(id);
                    if (la != null)
                    {
                        string fn = Path.GetFileName(la.PayslipPath);
                        string virtiualpath = string.Format(@"~/Uploads/{0}/{1}", la.EmpNo, fn);
                        Response.Redirect(virtiualpath);
                    }
                }
            }
        }
    }
}