using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using ASPNETChatControl;
using DataHelper;

namespace WebsiteTrial
{
    public partial class AdminLoanApplication : Page
    {
        private static int months = 0;
        private new static string ID = "";
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!System.Convert.ToBoolean(this.Session["AdminLogged"]))
            {
                base.Response.Redirect("~/AdminLog.aspx");
                return;
            }
            if (ChatControl.CurrentChatSession != null)
            {
                ChatControl.StopSession();
            }
            ChatControl.StartSession("Admin", "Admin", null);
            if (!base.IsPostBack)
            {
                this.GetDataApp();
                this.GetData();
            }
            if (this.GVLoan.Rows.Count > 0)
            {
                this.Panel2.Visible = true;
                this.GVLoan.Visible = true;
                this.Label2.Visible = false;
                return;
            }
            this.Panel1.Visible = false;
            this.Panel2.Visible = false;
            this.GVLoan.Visible = false;
            this.Label2.Visible = true;
        }
        private void GetDataApp()
        {
            using (DataAccess da = new DataAccess())
            {
                this.GVLoan.DataSource = da.getLoanApplication();
                this.GVLoan.DataBind();
            }
        }
        private void GetData()
        {
        }
        private void getDateString(string months)
        {
            this.tbDue.Text = this.getDue(months);
        }
        protected void btnTrans_Click(object sender, System.EventArgs e)
        {
            string x = System.DateTime.Now.ToString();
            System.DateTime y = System.Convert.ToDateTime(x);
            string ID = this.GVLoan.SelectedDataKey.Value.ToString();
            using (DataAccess da = new DataAccess())
            {
                da.approve(System.Convert.ToInt32(ID), y, System.Convert.ToDateTime(this.tbDue.Text));
            }
            this.lblStatus.Text = "Transaction : " + ID + " Approved";
            this.GetData();
            this.GetDataApp();
        }
        private string getDue(string months)
        {
            int z = System.Convert.ToInt32(months);
            System.DateTime x = System.DateTime.Now.AddMonths(z);
            return this.GetNearestPayDay(x);
        }
        private string GetNearestPayDay(System.DateTime d)
        {
            string date;
            if (d.Day >= 15 && d.Day < 30)
            {
                date = d.Month + "/30/" + d.Year;
            }
            else
            {
                date = d.Month + "/15/" + d.Year;
            }
            return date;
        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            using (DataAccess da = new DataAccess())
            {
                if (this.TextBox1.Text != "")
                {
                    this.GVLoan.DataSource = da.getLoanApplication(this.DropDownList1.SelectedValue, this.TextBox1.Text);
                }
                else
                {
                    this.GVLoan.DataSource = da.getLoanApplication();
                }
                this.GVLoan.DataBind();
            }
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (this.Calendar1.Visible)
            {
                this.Calendar1.Visible = false;
                return;
            }
            this.Calendar1.Visible = true;
        }
        protected void Calendar1_SelectionChanged(object sender, System.EventArgs e)
        {
            if (this.Calendar1.SelectedDate >= System.DateTime.Now.AddMonths(AdminLoanApplication.months))
            {
                this.tbDue.Text = this.Calendar1.SelectedDate.ToShortDateString();
            }
        }
        protected void GVLoan_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            AdminLoanApplication.ID = this.GVLoan.SelectedDataKey.Value.ToString();
            System.Collections.Generic.List<string> details = new System.Collections.Generic.List<string>();
            this.lblTransactionID.Text = AdminLoanApplication.ID;
            using (DataAccess da = new DataAccess())
            {
                details = da.GetTransactionDetails(AdminLoanApplication.ID);
                this.lblMaker.Text = da.GetEmployeeName(details[9]);
                this.lblCoMaker.Text = da.GetEmployeeName(details[0]);
                this.lblCoMaker2.Text = da.GetEmployeeName(details[1]);
            }
            this.lblReason.Text = details[3];
            AdminLoanApplication.months = System.Convert.ToInt32(details[5]);
            this.getDateString(details[5]);
            this.Panel1.Visible = true;
        }
        protected void btnTrans0_Click(object sender, System.EventArgs e)
        {
            using (DataAccess da = new DataAccess())
            {
                da.DeclineLoan(this.GVLoan.SelectedDataKey.Value.ToString());
            }
        }
    }
}