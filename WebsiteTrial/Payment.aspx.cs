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
    public partial class Payment : System.Web.UI.Page
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
                loans = da.GetUserActiveLoans(EmpDropDownList.SelectedValue);
                this.LoansRadioButtonList.DataSource = loans;
                this.LoansRadioButtonList.DataValueField = "TransactionID";
                this.LoansRadioButtonList.DataTextField = "Text";
                this.LoansRadioButtonList.DataBind();
            }
            this.ResultLiteral.Text = string.Empty;
            if(loans.Count == 0)
            {
                this.ResultLiteral.Text = "<h5>No loans to pay.</h5>";
            }
        }

        protected void PayButton_Click(object sender, EventArgs e)
        {
            var selectedLoan = this.LoansRadioButtonList.SelectedValue;

            if (string.IsNullOrEmpty(selectedLoan))
            {
                this.ResultLiteral.Text = "<h5 style='color:Red;'>Select a loan to pay.</h5>";
                return;
            }

            double payamount = 0;
            double.TryParse(this.PayAmountTextBox.Text, out payamount);

            if (payamount == 0) 
            {
                this.ResultLiteral.Text = "<h5 style='color:Red;'>pay must not be zero.</h5>";
                return;
            }

            if (payamount > da.GetOutStandingBalance(selectedLoan))
            {
                this.ResultLiteral.Text = "<div class=\"alert alert-danger\" role=\"alert\"><strong>Payment must not be greater than balance.</strong></div>";
                return;
            }


            bool result = da.Pay(selectedLoan, payamount, this.NoteTextBox.Text);
            if (result)
            {
                result = result && da.UpdateBalance(selectedLoan, payamount);
                da.UpdateLoanPayStatus(int.Parse(selectedLoan));
            }

            if (result)
            {
                this.ResultLiteral.Text = "<div class=\"alert alert-success\" role=\"alert\"><strong>Pay Success!</strong></div>";
                this.EmpDropDownList.SelectedIndex = 0;
                this.NoteTextBox.Text = string.Empty;
                this.PayAmountTextBox.Text = string.Empty;
                this.LoansRadioButtonList.Items.Clear();
            }
            else
            {
                this.ResultLiteral.Text = "<div class=\"alert alert-danger\" role=\"alert\"><strong>Pay Failed!</strong></div>";
            }
        }
    }
}