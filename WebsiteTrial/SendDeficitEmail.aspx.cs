using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Globalization;
using Mail;
using WebsiteTrial.Helper;

namespace WebsiteTrial
{
    public partial class SendDeficitEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionHelper.EnsureAdminLogged();
            if (!Page.IsPostBack)
            {
                DataHelper.DataAccess da = new DataHelper.DataAccess();
                this.UserDropDownList.DataSource = da.GetAllUsers();
                this.UserDropDownList.DataTextField = "Name";
                this.UserDropDownList.DataValueField = "EmpNo";
                this.UserDropDownList.DataBind();
            }

        }

        protected void PreviewButton_Click(object sender, EventArgs e)
        {
            if (!IsValid)
            {
                return;
            }
            StringBuilder b = new StringBuilder();
            b.AppendLine("FORM No.: DSD001");
            b.Append("<br />");
            b.Append("<br />");
            b.AppendLine(string.Format("Date: {0}", DateTime.Now.ToLongDateString()));
            b.Append("<br />");
            b.Append("<br />");
            b.Append("<br />");
            b.AppendLine(string.Format("TO: {0}", this.UserDropDownList.SelectedItem.Text));
            b.Append("<br />");
            b.AppendLine("FROM: Credit and Collection Committee");
            b.Append("<br />");
            b.Append("<br />");
            b.AppendLine("DEFICIT IN SALARY DEDUCTION");
            b.Append("<br />");
            b.Append("<br />");
            b.AppendFormat("This is to inform you that your dificit in the amount of {0} ONLY ({1}) as of {2} pay day, representing your {3}.",
                this.AmountWordsTextBox.Text, this.AmountTextBox.Text, DateTime.ParseExact(this.AsOfDateTextBox.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture).ToString("MMMM dd, yyyy", CultureInfo.InvariantCulture), this.DeductionForTextbox.Text);
            b.AppendFormat("<br />"); b.AppendFormat("<br />");
            b.AppendFormat("Kindly remit your cash payment on or before <strong>{0}</strong> to maintain your good credit standing with our cooperative.", DateTime.ParseExact(this.DeadlineTextBox.Text, "MM/dd/yyyy", null).ToString("MMMM dd, yyyy", CultureInfo.InvariantCulture));
            b.Append(" A deficit in any pay day shall result in the denial of any subsequent loan application. Your good standing status will only be");
            b.Append(" restored upon your showing of sufficient net pay for two (2) consecutive pay days.");
            b.AppendFormat("<br />"); b.AppendFormat("<br />");
            b.Append("Thank you very much.");
            this.PreviewLiteral.Text = b.ToString();
        }

        protected void SendButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataHelper.DataAccess da = new DataHelper.DataAccess();
                string email = da.GetEmployeeEmail(this.UserDropDownList.SelectedValue);
                /*var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("dlsudmailer@gmail.com", "Green1234")
                };
                
                

                MailMessage mm = new MailMessage();
                mm.From = new MailAddress("dlsudmailer@gmail.com");
                mm.To.Add(new MailAddress(email));
                mm.Body = this.PreviewLiteral.Text;
                mm.IsBodyHtml = true;
                mm.Subject = ;
                smtp.Send(mm);
                */

                MailHelper mh = new MailHelper();
                mh.SendMailMessage("dlsudmailer@gmail.com", email, "DEFICIT IN SALARY DEDUCTION", this.PreviewLiteral.Text, true);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}