using DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteTrial
{
    public partial class LoanReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            using (DataAccess da = new DataAccess())
            {
                List<LoanReportDTO> dtos = da.FilterLoanReport(this.StartDateCalendar.SelectedDate.Date,
                    this.EndDateCalendar.SelectedDate.Date, 
                    this.EmployeeCheckBox.Checked, 
                    this.NonEmployeeCheckBox.Checked);
                this.GridView1.DataSource = dtos;
                this.GridView1.DataBind();
            }
        }
    }
}