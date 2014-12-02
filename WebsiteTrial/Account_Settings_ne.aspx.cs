using DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteTrial
{
    public partial class Account_Settings_ne : System.Web.UI.Page
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
                this.relatedEmployee();

                using (DataAccess da = new DataAccess())
                {
                    this.RelativeEmpDropDownList.Text = da.RelatedEmployee(Session["empNo"].ToString());
                    this.RelativeEmpDropDownList.Enabled = false;
                }

                this.NEBdayDayDropDownList.DataSource = GetDays();
                DataBindDates(NEBdayDayDropDownList);

                this.NEBdayMonthDropDownList.DataSource = GetMonths();
                DataBindDates(NEBdayMonthDropDownList);

                this.NEBdayYearDropDownList.DataSource = GetYears();
                DataBindDates(NEBdayYearDropDownList);
                
                this.LoadDetails();
            }
        }

        private void relatedEmployee()
        {
            using (DataAccess da = new DataAccess())
            {
                this.RelativeEmpDropDownList.DataSource = da.GetEligibleRelativeUsers();
                this.RelativeEmpDropDownList.DataTextField = "Name";
                this.RelativeEmpDropDownList.DataValueField = "EmpNo";
                this.RelativeEmpDropDownList.DataBind();
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
                    this.tbEmail2.Text = u.Email;
                    this.NEBdayDayDropDownList.Text = u.Birthday.Value.Date.Day.ToString();
                    this.NEBdayMonthDropDownList.Text = u.Birthday.Value.Date.Month.ToString();
                    this.NEBdayYearDropDownList.Text = u.Birthday.Value.Date.Year.ToString();
                    this.tbAddress2.Text = u.Address;
                    this.tbFirstName2.Text = u.FirstName;
                    this.tbLastName2.Text = u.LastName;
                    this.tbMiddleName2.Text = u.MiddleName;
                    this.tbPhone2.Text = u.PhoneNumber;
                }
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            var empNo = this.Session["EmpNo"].ToString();
            using (DataAccess da = new DataAccess())
            {
                User u = new User();
                u.EmpNo = empNo;
                u.Email = this.tbEmail2.Text;

                int bd_month = Convert.ToInt32(this.NEBdayMonthDropDownList.SelectedValue);
                int bd_day = Convert.ToInt32(this.NEBdayDayDropDownList.SelectedValue);
                int bd_year = Convert.ToInt32(this.NEBdayYearDropDownList.SelectedValue);
                DateTime bd = new DateTime(bd_year, bd_month, bd_day);            

                u.Birthday = bd;

                u.Address = this.tbAddress2.Text;
                
                u.FirstName = this.tbFirstName2.Text;
                u.LastName = this.tbLastName2.Text;
                u.MiddleName = this.tbMiddleName2.Text;
                u.PhoneNumber = this.tbPhone2.Text;

                bool result = da.UpdateUserDetailsLinq(u);
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