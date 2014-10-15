using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using DataHelper;

namespace WebsiteTrial
{
    public partial class ConfirmLoan : Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (base.Request.QueryString["trans"] != null && base.Request.QueryString["confirmationCode"] != null)
            {
                DataAccess da = new DataAccess();
                string confirmCode = base.Request.QueryString["confirmationCode"].ToString();
                string trans = base.Request.QueryString["trans"].ToString();
                if (base.Request.QueryString.Count == 3)
                {
                    string coMakerNumber = base.Request.QueryString["coMaker"].ToString();
                    if (coMakerNumber == "1")
                    {
                        da.ConfirmLoan(trans, confirmCode, true, false);
                    }
                    else
                    {
                        da.ConfirmLoan(trans, confirmCode, true, true);
                    }
                }
                else
                {
                    da.ConfirmLoan(trans, confirmCode, false, false);
                }
                da.Dispose();
                base.Response.Redirect("~/Message.aspx?msg=Loan confirmed.");
            }
            base.Response.Redirect("~/Default.aspx");
        }
    }
}