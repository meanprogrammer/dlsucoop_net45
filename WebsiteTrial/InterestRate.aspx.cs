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
                 
                using (DataAccess da = new DataAccess())
                {
                    this.LoanTypeDropDownList.DataSource = da.GetLoanTypes();
                    this.LoanTypeDropDownList.DataBind();
                }
            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            using (DataAccess da = new DataAccess())
            {
                bool result = da.UpdateInterestRate(
                    Convert.ToDouble(this.InterestRateTextBox.Text),
                    Convert.ToInt32(this.LoanTypeDropDownList.SelectedValue));

                if (result == true)
                {

                    this.GridView1.DataSource = da.GetLoanAmountMatrix();
                    this.GridView1.DataBind();

                    this.LoanTypeDropDownList.SelectedIndex = -1;
                    this.InterestRateTextBox.Text = string.Empty;
                }
            }
        }

        protected void LoanTypeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (DataAccess da = new DataAccess())
            {
                int selected = Convert.ToInt32(this.LoanTypeDropDownList.SelectedValue);
                LoanAmountMatrix lam = da.GetOneLoanMatrixByType(selected);
                if (lam != null)
                {
                    this.InterestRateTextBox.Text = lam.Interest.ToString();
                }
            }
        }
    }
}