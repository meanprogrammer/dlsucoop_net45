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
                    User details = da2.GetEmployeeDetailsLinq(this.Session["EmpNo"].ToString());
                    this.lblEmpNo.Text = details.EmpNo;
                    this.LastNameLabel.Text = details.LastName;
                    this.FirstNameLabel.Text = details.FirstName;
                    this.MILabel.Text = details.MiddleName;
                    this.lblEmail.Text = details.Email;
                    if (details.UserType.ToUpper() == "EMPLOYEE")
                    {
                        this.lblCollege.Text = da2.GetCollegeName(details.College);
                        this.lblDepartment.Text = da2.GetDepartmentName(details.College, details.Dept);
                        this.lblMemberStatus.Text = details.MemberStatus;
                        this.lblDateHired.Text = Convert.ToDateTime(details.DateHired).ToLongDateString();
                    }
                    this.lblPhoneNumber.Text = details.PhoneNumber;
                    this.Image2.ImageUrl = "~/Pictures/" + da2.GetImage(this.Session["EmpNo"].ToString());
                    this.DropDownList1.DataSource = da2.GetAllTransaction(details.EmpNo);
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