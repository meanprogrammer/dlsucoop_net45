using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataHelper;

namespace WebsiteTrial
{
    public partial class Table : System.Web.UI.Page
    {
        DataAccess da;
        protected void Page_Load(object sender, EventArgs e)
        {
            da = new DataAccess();
        }

        protected void TruncateLoanButton_Click(object sender, EventArgs e)
        {
            da.TruncateLoanApplicationTable();
        }

        protected void TruncateUnconfirmedLoanButton_Click(object sender, EventArgs e)
        {
            da.TruncateUnconfirmedLoanTable();
        }

        protected void TruncateMSGSButton_Click(object sender, EventArgs e)
        {
            da.TruncateMSGSTable();
        }

        protected void TruncatePaymentsButton_Click(object sender, EventArgs e)
        {
            da.TruncatePaymentsTable();
        }
    }
}