using DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteTrial
{
    public partial class Registration2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.college();
                this.department();
            }
        }

        protected void RegistrationTypeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.RegistrationTypeDropDownList.SelectedIndex == 1) {
                this.RegistrationMultiView.ActiveViewIndex = 0;
            }
            else if (this.RegistrationTypeDropDownList.SelectedIndex == 2)
            {
                this.RegistrationMultiView.ActiveViewIndex = 1;
            }
            else
            {
                this.RegistrationMultiView.ActiveViewIndex = -1;
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


        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            if (!this.Calendar2.Visible)
            {
                this.Calendar2.Visible = true;
                return;
            }
            this.Calendar2.Visible = false;
        }
        protected void Calendar2_SelectionChanged(object sender, System.EventArgs e)
        {
            this.txtbirthday.Text = this.Calendar2.SelectedDate.ToShortDateString();
            this.Calendar2.Visible = false;
        }

        protected void Calendar3_SelectionChanged(object sender, EventArgs e)
        {
            this.txtdatehired.Text = this.Calendar3.SelectedDate.ToShortDateString();
        }
    }
}