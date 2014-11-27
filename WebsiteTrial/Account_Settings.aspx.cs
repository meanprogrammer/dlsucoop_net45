using DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteTrial
{
    public partial class Account_Settings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.college();
                this.department();
                this.LoadDetails();
            }
        }

        private void LoadDetails()
        { 
            if (System.Convert.ToBoolean(this.Session["Logged"]))
            {
                var empNo = this.Session["EmpNo"].ToString();
                using (DataAccess da = new DataAccess())
                {
                    User u = da.GetEmployeeDetailsLinq(empNo);
                    this.tbEmpNum.Text = u.EmpNo;
                    this.tbEmail.Text = u.Email;
                    this.DDCollege.Text = u.College;
                    this.DDDepartment.Text = u.Dept;
                    this.DDStatus.Text = u.MemberStatus;
                    this.Calendar3.SelectedDate = Convert.ToDateTime(u.DateHired);
                    this.txtdatehired.Text = this.Calendar3.SelectedDate.ToShortDateString();
                    this.tbAddress.Text = u.Address;
                    this.Calendar1.SelectedDate = Convert.ToDateTime(u.Birthday);
                    this.txtbirthday.Text = this.Calendar1.SelectedDate.ToShortDateString();
                    this.tbFirstName.Text = u.FirstName;
                    this.tbLastName.Text = u.LastName;
                    this.tbMiddleName.Text = u.MiddleName;
                    this.tbPhone.Text = u.PhoneNumber;
                    this.ATMTextbox.Text = u.ATMAccountNo;
                    this.TINNoTextbox.Text = u.TINNo;
                    this.SSSNoTextBox.Text = u.SSSNo;
                    this.GenderDropDownList.Text = u.Gender;
                    this.CivilStatusDropDownList.Text = u.CivilStatus;
                    this.FatherNameTextBox.Text = u.FatherName;
                    this.FatherOccupationTextBox.Text = u.FatherOccupation;
                    this.MotherNameTextBox.Text = u.MotherName;
                    this.MotherOccupationTextBox.Text = u.MotherOccupation;
                    this.LegalSpouseTextBox.Text = u.LegalSpouse;
                    this.SpouseOccupationTextBox.Text = u.SpouseEmployer;
                    this.BusinessNameTextBox.Text = u.BusinessName;
                    this.BusinessAddressTextBox.Text = u.BusinessAddress;
                    this.OtherSourceOfIncomeTextBox.Text = u.OtherSourceOfIncome;
                    this.ICENameTextBox.Text = u.EmergencyName;
                    this.ICEAddressTextBox.Text = u.EmergencyAddress;
                    this.ICEContactNumberTextBox.Text = u.EmergencyNumber;

                    
                }
            }
        }

        public void department()
        {
            using (DataAccess da = new DataAccess())
            {
                this.DDDepartment.DataSource = da.getDepartment(System.Convert.ToInt32(this.DDCollege.SelectedValue));
                this.DDDepartment.DataTextField = "DepartmentName";
                this.DDDepartment.DataValueField = "DepartmentID";
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

        protected void DDCollege_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.department();
        }


        protected void Calendar3_SelectionChanged(object sender, EventArgs e)
        {
            this.txtdatehired.Text = this.Calendar3.SelectedDate.ToShortDateString();
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            this.txtbirthday.Text = this.Calendar1.SelectedDate.ToShortDateString();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            var empNo = this.Session["EmpNo"].ToString();
            using (DataAccess da = new DataAccess())
            {
                User u = new User();
                u.EmpNo = this.tbEmpNum.Text;
                u.Email = this.tbEmail.Text;
                u.College = this.DDCollege.SelectedValue;
                u.Dept = this.DDDepartment.SelectedValue;
                u.MemberStatus = this.DDStatus.SelectedValue;
                u.DateHired = this.Calendar3.SelectedDate;
                u.Address = this.tbAddress.Text;
                u.Birthday = this.Calendar1.SelectedDate;
                u.FirstName = this.tbFirstName.Text;
                u.LastName = this.tbLastName.Text;
                u.MiddleName = this.tbMiddleName.Text;
                u.PhoneNumber = this.tbPhone.Text;
                u.ATMAccountNo = this.ATMTextbox.Text;
                u.TINNo = this.TINNoTextbox.Text;
                u.SSSNo = this.SSSNoTextBox.Text;
                u.Gender = this.GenderDropDownList.SelectedValue;
                u.CivilStatus = this.CivilStatusDropDownList.SelectedValue;
                u.FatherName = this.FatherNameTextBox.Text;
                u.FatherOccupation = this.FatherOccupationTextBox.Text;
                u.MotherName = this.MotherNameTextBox.Text;
                u.MotherOccupation = this.MotherOccupationTextBox.Text;
                u.LegalSpouse =  this.LegalSpouseTextBox.Text;
                u.SpouseEmployer = this.SpouseOccupationTextBox.Text;
                u.BusinessName = this.BusinessNameTextBox.Text;
                u.BusinessAddress = this.BusinessAddressTextBox.Text;
                u.OtherSourceOfIncome = this.OtherSourceOfIncomeTextBox.Text;
                u.EmergencyName = this.ICENameTextBox.Text;
                u.EmergencyAddress = this.ICEAddressTextBox.Text;
                u.EmergencyNumber = this.ICEContactNumberTextBox.Text;

                bool result = da.UpdateUserDetailsLinq(u);
            }
        }
    }
}