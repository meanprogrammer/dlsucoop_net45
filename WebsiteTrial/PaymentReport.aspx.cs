using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataHelper;
using WebsiteTrial.Helper;

namespace WebsiteTrial
{
    public partial class PaymentReport : System.Web.UI.Page
    {
        DataHelper.DataAccess da = new DataHelper.DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionHelper.EnsureAdminLogged();
            if (!Page.IsPostBack)
            {
                this.EmpDropDownList.DataSource = da.GetAllUsersWithEmpty();
                this.EmpDropDownList.DataTextField = "Name";
                this.EmpDropDownList.DataValueField = "EmpNo";
                this.EmpDropDownList.DataBind();
            }
        }

        protected void EmpDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<SelectLoanDTO> loans = new List<SelectLoanDTO>();
            if (EmpDropDownList.SelectedValue != "0")
            {
                loans = da.GetUserLoans(EmpDropDownList.SelectedValue);
                this.LoansRadioButtonList.DataSource = loans;
                this.LoansRadioButtonList.DataValueField = "TransactionID";
                this.LoansRadioButtonList.DataTextField = "Text";
                this.LoansRadioButtonList.DataBind();
            }
            this.ResultLiteral.Text = string.Empty;
            if (loans.Count == 0)
            {
                this.ResultLiteral.Text = "<h5>No loans to view.</h5>";
            }
            this.ReportGridView.DataSource = new List<LoanPaymentReport>();
            this.ReportGridView.DataBind();
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {

            var selectedLoan = this.LoansRadioButtonList.SelectedValue;

            if (string.IsNullOrEmpty(selectedLoan))
            {
                this.ResultLiteral.Text = "<h5 style='color:Red;'>Select a loan to view.</h5>";
                return;
            }
            using (DataAccess da = new DataAccess())
            {
                this.ReportGridView.DataSource = da.GetLoanPaymentReport(
                    int.Parse(this.LoansRadioButtonList.SelectedValue)
                    );
                this.ReportGridView.DataBind();
            }

        }
    }
}