using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using DataHelper;
using System.Data;
using System.Drawing;
using System.Globalization;

namespace WebsiteTrial
{
    public partial class Account_Settings : Page
    {
        private string EmpNo;
        private string col;
        private string dept;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (System.Convert.ToBoolean(this.Session["Logged"]))
            {
                this.EmpNo = this.Session["EmpNo"].ToString();
                if (base.IsPostBack)
                {
                    return;
                }
                this.college();
                this.department();
                using (DataAccess da = new DataAccess())
                {
                    DataTable dt = da.GetAllEmployeeDetails(this.EmpNo);
                    this.txtEmpNo.Text = dt.Rows[0]["EmpNo"].ToString();
                    this.txtName.Text = dt.Rows[0]["Name"].ToString();
                    this.txtEmail.Text = dt.Rows[0]["Email"].ToString();
                    this.txtAddress.Text = dt.Rows[0]["Address"].ToString();
                    this.txtbirthday.Text = dt.Rows[0]["Birthday"].ToString();
                    this.Calendar1.SelectedDate = System.Convert.ToDateTime(this.txtbirthday.Text);
                    this.col = dt.Rows[0]["College"].ToString();
                    this.dept = dt.Rows[0]["Dept"].ToString();
                    this.DDCollege.SelectedIndex = System.Convert.ToInt32(this.col) - 1;
                    this.department();
                    this.DDDepartment.SelectedIndex = System.Convert.ToInt32(this.dept) - 1;
                    if (dt.Rows[0]["MemberStatus"].ToString() == "Probationary")
                    {
                        this.DDStatus.SelectedIndex = 0;
                    }
                    else
                    {
                        if (dt.Rows[0]["MemberStatus"].ToString().Contains("Part"))
                        {
                            this.DDStatus.SelectedIndex = 1;
                        }
                        else
                        {
                            this.DDStatus.SelectedIndex = 2;
                        }
                    }
                    this.txtPhone.Text = dt.Rows[0]["PhoneNumber"].ToString();
                    this.txtdatehired.Text = dt.Rows[0]["DateHired"].ToString();
                    this.Calendar2.SelectedDate = DateTime.ParseExact(this.txtdatehired.Text, "dd/MM/yyyy", null);//System.Convert.ToDateTime(this.txtdatehired.Text, CultureInfo.InvariantCulture);
                    return;
                }
            }
            base.Response.Redirect("~/Default.aspx");
        }
        protected void DDCollege_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.department();
        }
        public void department()
        {
            using (DataAccess da = new DataAccess())
            {
                this.DDDepartment.DataSource = da.getDepartment(System.Convert.ToInt32(this.DDCollege.SelectedValue));
                this.DDDepartment.DataTextField = "DepartmentName";
                this.DDDepartment.DataBind();
            }
        }
        public void college()
        {
            using (DataAccess da = new DataAccess())
            {
                this.DDCollege.DataSource = da.getColleges();
                this.DDCollege.DataTextField = "CollegeName";
                this.DDCollege.DataValueField = "CollegeID";
                this.DDCollege.DataBind();
            }
        }
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            this.Calendar2.Visible = true;
        }
        protected void Calendar2_SelectionChanged(object sender, System.EventArgs e)
        {
            this.txtbirthday.Text = this.Calendar2.SelectedDate.ToShortDateString();
            this.Calendar2.Visible = false;
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            this.Calendar1.Visible = true;
        }
        protected void Calendar1_SelectionChanged(object sender, System.EventArgs e)
        {
            this.txtdatehired.Text = this.Calendar1.SelectedDate.ToShortDateString();
            this.Calendar1.Visible = false;
        }
        protected void LinkButton1_Click(object sender, System.EventArgs e)
        {
            if (!this.Panel1.Visible)
            {
                this.Panel1.Visible = true;
                return;
            }
            this.Panel1.Visible = false;
        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            bool Done = false;
            this.Label3.Text = "";
            this.Label4.Text = "";
            this.Label5.Text = "";
            this.Label6.Text = "";
            this.Label7.Text = "";
            using (DataAccess da = new DataAccess())
            {
                if (this.Panel1.Visible)
                {
                    if (da.retrieveUserPass(this.EmpNo, this.txtOldPass0.Text))
                    {
                        if (this.txtNewPass0.Text.Length >= 6)
                        {
                            if (this.txtNewPass0.Text == this.txtConfirm0.Text)
                            {
                                da.UpdatePass(this.EmpNo, this.txtNewPass0.Text);
                                Done = true;
                            }
                            else
                            {
                                this.Label3.Text = "Passwords does not match";
                            }
                        }
                        else
                        {
                            this.Label3.Text = "Must be at least 6 characters";
                        }
                    }
                    else
                    {
                        this.Label4.Text = "input does not match old password";
                    }
                }
                if (this.txtName.Text != "" && this.txtEmail.Text != "" && this.txtAddress.Text != "" && this.txtbirthday.Text != "" && this.txtPhone.Text != "" && this.txtdatehired.Text != "")
                {
                    if (MessageParse.IsValidEmail(this.txtEmail.Text) && MessageParse.IsLaSalleEmail(this.txtEmail.Text))
                    {
                        long Phone;
                        bool valid = long.TryParse(this.txtPhone.Text, out Phone);
                        if (valid)
                        {
                            System.Collections.Generic.List<string> details = new System.Collections.Generic.List<string>();
                            details.Add(this.EmpNo);
                            details.Add(this.txtName.Text);
                            details.Add(this.txtEmail.Text);
                            details.Add(this.txtAddress.Text);
                            details.Add(this.Calendar2.SelectedDate.ToShortDateString());
                            if (this.DDCollege.Text != "")
                            {
                                details.Add(this.DDCollege.Text);
                            }
                            else
                            {
                                details.Add(this.col);
                            }
                            if (this.DDDepartment.Text != "")
                            {
                                details.Add(this.DDDepartment.Text);
                            }
                            else
                            {
                                details.Add(this.dept);
                            }
                            details.Add(this.txtPhone.Text);
                            details.Add(this.DDStatus.Text);
                            details.Add(this.Calendar1.SelectedDate.ToShortDateString());
                            da.UpdateUserDetails(details);
                            Done = true;
                        }
                        else
                        {
                            this.Label7.Text = "Mobile number must be numeric";
                        }
                    }
                    else
                    {
                        this.Label6.Text = "Email must be valid La Salle mail";
                    }
                }
                else
                {
                    this.Label5.ForeColor = Color.Red;
                    this.Label5.Text = "All fields are required";
                }
                if (Done)
                {
                    this.Label5.ForeColor = Color.Green;
                    this.Label5.Text = "Update Complete";
                }
            }
        }
        protected void txtConfirm0_TextChanged(object sender, System.EventArgs e)
        {
            if (this.txtNewPass0.Text != this.txtConfirm0.Text)
            {
                this.Label3.Text = "Passwords does not match";
                return;
            }
            this.Label3.Text = "";
        }
        protected void txtEmail_TextChanged(object sender, System.EventArgs e)
        {
            if (MessageParse.IsValidEmail(this.txtEmail.Text) && MessageParse.IsLaSalleEmail(this.txtEmail.Text))
            {
                this.Label6.Text = "";
                return;
            }
            this.Label6.Text = "Email must be valid La Salle mail";
        }
        protected void txtPhone_TextChanged(object sender, System.EventArgs e)
        {
            long Phone;
            if (!long.TryParse(this.txtPhone.Text, out Phone))
            {
                this.Label7.Text = "Mobile number must be numeric";
                return;
            }
            this.Label7.Text = "";
        }
    }
}