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
        private void DataBindDates(DropDownList list)
        {
            list.DataTextField = "Text";
            list.DataValueField = "Value";
            list.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string empNo = Session["EmpNo"].ToString();

                bool isEmployee = false;
                using (DataAccess da = new DataAccess())
                {
                    isEmployee = da.IsEmployee(empNo);
                }

                if (isEmployee == false)
                {
                    Response.Redirect("Account_Settings_ne.aspx");
                }
             

                this.college();
                this.department();
                this.LoadDetails();

                this.DateHiredDateDropdownlist.DataSource = GetDays();
                DataBindDates(DateHiredDateDropdownlist);

                this.DateHiredMonthDropdownlist.DataSource = GetMonths();
                DataBindDates(DateHiredMonthDropdownlist);

                this.DateHiredYearDropdownlist.DataSource = GetYears();
                DataBindDates(DateHiredYearDropdownlist);

                this.EmpBdateMonthDropdownlist.DataSource = GetMonths();
                DataBindDates(EmpBdateMonthDropdownlist);

                this.EmpBdateDateDropdownlist.DataSource = GetDays();
                DataBindDates(EmpBdateDateDropdownlist);

                this.EmpBdateYearDropDownList.DataSource = GetYears();
                DataBindDates(EmpBdateYearDropDownList);
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

                    this.EmpBdateDateDropdownlist.Text = u.Birthday.Value.Date.Day.ToString();
                    this.EmpBdateMonthDropdownlist.Text = u.Birthday.Value.Date.Month.ToString();
                    this.EmpBdateYearDropDownList.Text = u.Birthday.Value.Date.Year.ToString();

                    this.DateHiredDateDropdownlist.Text = u.DateHired.Value.Date.Day.ToString();
                    this.DateHiredMonthDropdownlist.Text = u.DateHired.Value.Date.Month.ToString();
                    this.DateHiredYearDropdownlist.Text = u.DateHired.Value.Date.Year.ToString();

                    //this.Calendar3.SelectedDate = Convert.ToDateTime(u.DateHired);
                    //this.txtdatehired.Text = this.Calendar3.SelectedDate.ToShortDateString();
                    this.tbAddress.Text = u.Address;
                    //this.Calendar1.SelectedDate = Convert.ToDateTime(u.Birthday);
                    //this.txtbirthday.Text = this.Calendar1.SelectedDate.ToShortDateString();
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

                int dh_month = Convert.ToInt32(this.DateHiredMonthDropdownlist.SelectedValue);
                int dh_day = Convert.ToInt32(this.DateHiredDateDropdownlist.SelectedValue);
                int dh_year = Convert.ToInt32(this.DateHiredYearDropdownlist.SelectedValue);
                DateTime dh = new DateTime(dh_year, dh_month, dh_day);

                u.DateHired = dh;

                int bd_month = Convert.ToInt32(this.EmpBdateMonthDropdownlist.SelectedValue);
                int bd_day = Convert.ToInt32(this.EmpBdateDateDropdownlist.SelectedValue);
                int bd_year = Convert.ToInt32(this.EmpBdateYearDropDownList.SelectedValue);
                DateTime bd = new DateTime(bd_year, bd_month, bd_day);

                u.Birthday = bd;

                u.Address = this.tbAddress.Text;
                
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

                if (result) 
                { 

                }
            }
        }

        private List<DateMonthDTO> GetMonths()
        {
            List<DateMonthDTO> col = new List<DateMonthDTO>();
            col.Add(new DateMonthDTO("January", "1"));
            col.Add(new DateMonthDTO("February", "2"));
            col.Add(new DateMonthDTO("March", "3"));
            col.Add(new DateMonthDTO("April", "4"));
            col.Add(new DateMonthDTO("May", "5"));
            col.Add(new DateMonthDTO("June", "6"));
            col.Add(new DateMonthDTO("July", "7"));
            col.Add(new DateMonthDTO("August", "8"));
            col.Add(new DateMonthDTO("September", "9"));
            col.Add(new DateMonthDTO("October", "10"));
            col.Add(new DateMonthDTO("November", "11"));
            col.Add(new DateMonthDTO("December", "12"));
            return col;
        }

        private List<DateMonthDTO> GetDays()
        {
            List<DateMonthDTO> col = new List<DateMonthDTO>();
            for (int i = 1; i <= 31; i++)
            {
                col.Add(new DateMonthDTO(i.ToString(), i.ToString()));
            }
            return col;
        }

        private List<DateMonthDTO> GetYears()
        {
            List<DateMonthDTO> col = new List<DateMonthDTO>();
            for (int i = 2014; i >= 1900; i--)
            {
                col.Add(new DateMonthDTO(i.ToString(), i.ToString()));
            }
            return col;
        }
    }
}