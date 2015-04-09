using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using DataHelper;

namespace WebsiteTrial
{
    public partial class AdminApprovedLoan : Page
    {
        private new string ID;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (System.Convert.ToBoolean(this.Session["AdminLogged"]))
            {
                using (DataAccess da = new DataAccess())
                {
                    this.gvLoan.DataSource = da.getApproved();
                    this.gvLoan.DataBind();
                }
                this.Panel1.Visible = false;
                return;
            }
            base.Response.Redirect("~/AdminLog.aspx");
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.DropDownList1.SelectedIndex == 1 || this.DropDownList1.SelectedIndex == 2)
            {
                this.Calendar1.Visible = true;
                return;
            }
            this.Calendar1.Visible = false;
        }
        protected void Calendar1_SelectionChanged(object sender, System.EventArgs e)
        {
            this.TextBox1.Text = this.Calendar1.SelectedDate.ToShortDateString();
        }
        protected void Button2_Click(object sender, System.EventArgs e)
        {
            using (DataAccess da = new DataAccess())
            {
                if (this.TextBox1.Text != "")
                {
                    if (this.DropDownList1.SelectedIndex == 1 || this.DropDownList1.SelectedIndex == 2)
                    {
                        this.gvLoan.DataSource = da.getApproved(this.DropDownList1.SelectedValue, System.Convert.ToDateTime(this.TextBox1.Text));
                    }
                    else
                    {
                        this.gvLoan.DataSource = da.getApproved(this.DropDownList1.SelectedValue, this.TextBox1.Text);
                    }
                }
                else
                {
                    this.gvLoan.DataSource = da.getApproved();
                }
                this.gvLoan.DataBind();
            }
        }
        protected void gvLoan_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.ID = this.gvLoan.SelectedDataKey.Value.ToString();
            System.Collections.Generic.List<string> details = new System.Collections.Generic.List<string>();
            this.lblTransactionID.Text = this.ID;
            using (DataAccess da = new DataAccess())
            {
                details = da.GetTransactionDetails(this.ID);
                this.lblMaker.Text = da.GetEmployeeName(details[9]);
                this.lblCoMaker.Text = da.GetEmployeeName(details[0]);
                this.lblCoMaker2.Text = da.GetEmployeeName(details[1]);
            }
            this.lblReason.Text = details[3];
            this.lblTypeOfLoan.Text = details[2];
            this.lblAmount.Text = details[4];
            this.lblNoOfMonths.Text = details[5];
            this.lblDateApproved.Text = details[6];
            this.lblDateDue.Text = details[7];
            this.Panel1.Visible = true;
        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.ID = this.gvLoan.SelectedDataKey.Value.ToString();
                using (DataAccess da = new DataAccess())
                {
                    da.LoanDone(this.ID);
                }
            }
            finally
            {
                using (DataAccess da2 = new DataAccess())
                {
                    this.gvLoan.DataSource = da2.getApproved();
                    this.gvLoan.DataBind();
                }
            }
        }
    }
}