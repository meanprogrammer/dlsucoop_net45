using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using DataHelper;
using System.Web.UI.WebControls;
using SMS;

namespace WebsiteTrial
{
    public partial class AdminPage : Page
    {
        DataAccess da = new DataAccess();
        Messages msg = new Messages();
        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.Session["AdminLogged"] = true;
            if (!System.Convert.ToBoolean(this.Session["AdminLogged"]))
            {
                base.Response.Redirect("~/AdminLogin.aspx");
                return;
            }
            if (!base.IsPostBack)
            {
                this.GetDataApp();
                this.GetData();
            }
            this.tbDue.Text = "NOT AVAILABLE";
        }
        private void GetDataApp()
        {
            this.GVLoan.DataSource = da.GetAllUnconfirmedUsers();
            this.GVLoan.DataBind();
        }
        private void GetData()
        {
            //this.DDTrans.DataTextField = "TransactionID";
            //this.DDTrans.DataValueField = "NoOfMonths";
            //this.DDTrans.DataBind();
            this.UnapprovedLoanGridView.DataSource = da.GetAllUnapprovedLoan();
            this.UnapprovedLoanGridView.DataBind();
        }
        private void getDateString()
        {
            this.tbDue.Text = this.getDue();
        }
        protected void btnTrans_Click(object sender, System.EventArgs e)
        {
            string x = System.DateTime.Now.ToString();
            System.Convert.ToDateTime(x);
            System.Convert.ToDateTime(this.getDue());
            this.lblStatus.Text = "Transaction : " + this.DDTrans.SelectedItem.ToString() + " Approved";
            this.GetData();
            this.GetDataApp();
        }
        protected void DDTrans_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.getDateString();
        }
        private string getDue()
        {
            int z = System.Convert.ToInt32(this.DDTrans.SelectedValue);
            return System.DateTime.Now.AddMonths(z).ToShortDateString();
        }

        protected void SendDeficitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("SendDeficitEmail.aspx", true);
        }

        protected void PaymentButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Payment.aspx", true);
        }

        protected void UnapprovedLoanGridView_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Approve")
            {
                GridViewRow r = this.UnapprovedLoanGridView.Rows[int.Parse(e.CommandArgument.ToString())];
                var id = r.Cells[0].Text;
                var noOfMonths = r.Cells[5].Text;
                var empNo = r.Cells[1].Text;
                da.approve(int.Parse(id), DateTime.Now, DateTime.Now.AddMonths(int.Parse(noOfMonths)));
                //string x = System.DateTime.Now.ToString();
                //System.Convert.ToDateTime(x);
                //System.Convert.ToDateTime(this.getDue());
                //this.lblStatus.Text = "Transaction : " + this.DDTrans.SelectedItem.ToString() + " Approved";
                var phoneNo = da.GetPhoneNumber(empNo);
                List<string> tDetails = da.GetTransactionDetails(id);
                var name = da.GetEmployeeName(empNo);
                msg.SendSMS(phoneNo, msg.BuildLoanApprovedMessage(tDetails, name));
                this.GetData();
                this.GetDataApp();
            }

            if (e.CommandName == "Decline")
            { 
                GridViewRow r = this.UnapprovedLoanGridView.Rows[int.Parse(e.CommandArgument.ToString())];
                var id = r.Cells[0].Text;
                var empNo = r.Cells[1].Text;
                List<string> tDetails = da.GetTransactionDetails(id);
                da.DeclineLoan(id);
                var phoneNo = da.GetPhoneNumber(empNo);
                msg.SendSMS(phoneNo, "Loan Declined!");
                this.GetData();
                this.GetDataApp();
            }
        }
    }
}