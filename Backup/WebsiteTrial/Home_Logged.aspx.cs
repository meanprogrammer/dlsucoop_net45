using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using DataHelper;
using ASPNETChatControl;

namespace WebsiteTrial
{
    public partial class Home_Logged : Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (System.Convert.ToBoolean(this.Session["Logged"]))
            {
                string image = "";
                string ID = "";
                string name = "";
                using (DataAccess da = new DataAccess())
                {
                    image = "~/Pictures/" + da.GetImage(this.Session["EmpNo"].ToString());
                    ID = this.Session["EmpNo"].ToString();
                    name = da.GetEmployeeName(ID);
                    this.IDHiddenField.Value = ID;
                }
                if (ChatControl.CurrentChatSession != null)
                {
                    ChatControl.StopSession();
                }
                ChatControl.StartSession(ID, name, image);
                if (base.IsPostBack)
                {
                    return;
                }
                this.Label1.Visible = false;
                using (DataAccess da2 = new DataAccess())
                {
                    System.Collections.Generic.List<string> details = da2.GetEmployeeDetails(this.Session["EmpNo"].ToString());
                    this.lblEmpNo.Text = details[0];
                    this.lblName.Text = details[1];
                    this.lblEmail.Text = details[2];
                    this.lblCollege.Text = da2.GetCollegeName(details[3]);
                    this.lblDepartment.Text = da2.GetDepartmentName(details[3], details[4]);
                    this.lblMemberStatus.Text = details[5];
                    this.lblDateHired.Text = details[6];
                    this.lblPhoneNumber.Text = details[7];
                    this.Image2.ImageUrl = "~/Pictures/" + da2.GetImage(this.Session["EmpNo"].ToString());
                    this.DropDownList1.DataSource = da2.GetAllTransaction(details[0]);
                    this.DropDownList1.DataTextField = "TransactionID";
                    this.DropDownList1.DataValueField = "TransactionID";
                    this.DropDownList1.DataBind();
                    if (this.DropDownList1.Items.Count > 0)
                    {
                        this.SetTransactionDetails();
                    }
                    else
                    {
                        this.Panel2.Visible = false;
                    }
                    return;
                }
            }
            base.Response.Redirect("~/Default.aspx");
        }
        protected void GridView1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
        }
        protected void LinkButton1_Click(object sender, System.EventArgs e)
        {
        }
        protected void btnSave_Click(object sender, System.EventArgs e)
        {
            string name = this.FileUpload1.PostedFile.FileName;
            this.FileUpload1.PostedFile.SaveAs(base.Server.MapPath("~/Pictures/") + this.Session["EmpNo"].ToString() + name);
            using (DataAccess da = new DataAccess())
            {
                string path = da.GetImage(this.Session["EmpNo"].ToString());
                if (path != "")
                {
                    System.IO.File.Delete(base.Server.MapPath("~/Pictures/") + path);
                }
                da.SaveImage(this.Session["EmpNo"].ToString() + name, this.Session["EmpNo"].ToString());
                this.Image2.ImageUrl = "~/Pictures/" + da.GetImage(this.Session["EmpNo"].ToString());
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.SetTransactionDetails();
        }
        private void SetTransactionDetails()
        {
            using (DataAccess da = new DataAccess())
            {
                System.Collections.Generic.List<string> detail = da.GetTransactionDetails(this.DropDownList1.SelectedValue);
                this.Maker.Text = da.GetEmployeeName(detail[9]);
                this.CoMaker1.Text = da.GetEmployeeName(detail[0]);
                this.CoMaker2.Text = da.GetEmployeeName(detail[1]);
                this.TypeOfLoan.Text = detail[2];
                this.Reason.Text = detail[3];
                this.Amount.Text = detail[4];
                this.Months.Text = detail[5];
                this.DateApproved.Text = detail[6];
                this.DateDue.Text = detail[7];
                if (!System.Convert.ToBoolean(detail[8]))
                {
                    this.Label1.Visible = false;
                }
                this.Panel2.Visible = true;
            }
        }
    }
}