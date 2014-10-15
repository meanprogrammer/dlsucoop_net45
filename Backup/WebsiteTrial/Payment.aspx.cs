using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataHelper;

namespace WebsiteTrial
{
    public partial class Payment : System.Web.UI.Page
    {
        DataHelper.DataAccess da = new DataHelper.DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.EmpDropDownList.DataSource = da.GetAllUsers();
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
            double payamount = 0;
            double.TryParse(this.PayAmountTextBox.Text, out payamount);
            bool result = da.Pay(selectedLoan, payamount, this.NoteTextBox.Text);
            if (result)
            {
                result = result && da.UpdateBalance(selectedLoan, payamount);

            }

            if (result)
            {
                this.ResultLiteral.Text = "<h5 style='color:Green;'>Pay Success!</h5>";
                this.EmpDropDownList.SelectedIndex = 0;
                this.NoteTextBox.Text = string.Empty;
                this.PayAmountTextBox.Text = string.Empty;
                this.LoansRadioButtonList.Items.Clear();
            }
            else
            {
                this.ResultLiteral.Text = "<h5 style='color:Red;'>Pay failed!</h5>";
            }
        }
    }
}