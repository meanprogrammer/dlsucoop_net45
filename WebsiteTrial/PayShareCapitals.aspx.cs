using DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebsiteTrial.Helper;

namespace WebsiteTrial
{
    public partial class PayShareCapitals : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionHelper.EnsureAdminLogged();
            if (!Page.IsPostBack)
            {
                employee();
            }
        }

        private void employee()
        {
            using (DataAccess da = new DataAccess())
            {
                this.EmployeeDropDownList.DataSource = da.GetAllUsersWithEmpty();
                this.EmployeeDropDownList.DataTextField = "Name";
                this.EmployeeDropDownList.DataValueField = "EmpNo";
                this.EmployeeDropDownList.DataBind();
            }
        }

        protected void SaveShareCapitalButton_Click(object sender, EventArgs e)
        {
            double share = double.Parse(this.ShareCapitalTextBox.Text);
            using (DataAccess da = new DataAccess())
            {
                bool result = da.SaveShareCapital(this.EmployeeDropDownList.SelectedValue,
                                                    share);
            }
        }
    }
}