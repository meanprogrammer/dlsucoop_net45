using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using DataHelper;
using SMS;
using Mail;

namespace WebsiteTrial
{
    public partial class Loan : Page
    {
        private string EmpNo;
        private bool valid = true;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (System.Convert.ToBoolean(this.Session["Logged"]))
            {
                this.EmpNo = this.Session["EmpNo"].ToString();
                if (this.UserHasLoan(this.EmpNo))
                {
                    base.Response.Redirect("~/Message.aspx?msg=ALERT: You still have a pending loan application.");
                    return;
                }
            }
            else
            {
                base.Response.Redirect("~/Default.aspx");
            }

            if (!Page.IsPostBack)
            { 
                using(DataAccess da = new DataAccess())
	            {
                    this.DDType.DataSource = da.GetLoanTypes();
                    this.DDType.DataTextField = "Type";
                    this.DDType.DataValueField = "RecordID";
                    this.DDType.DataBind();
	            }
                
            }
        }
        private void CheckIfSameEmpNo()
        {
            this.valid = true;
            if (this.tbCoMaker.Text != "" && this.EmpNo == this.tbCoMaker.Text)
            {
                this.lblCoMaker.Text = "*";
                this.valid = false;
            }
            if (this.tbCoMaker2.Text != "" && (this.EmpNo == this.tbCoMaker2.Text || this.tbCoMaker2.Text == this.tbCoMaker.Text))
            {
                this.lblCoMaker2.Text = "*";
                this.valid = false;
            }
        }
        private bool UserHasLoan(string emp)
        {
            using (DataAccess da = new DataAccess())
            {
                if (da.HasLoanApplication(emp))
                {
                    da.Dispose();
                    return true;
                }
            }
            return false;
        }
        protected void tbAmount_TextChanged(object sender, System.EventArgs e)
        {
            double num;
            bool numeric = double.TryParse(this.tbAmount.Text, out num);
            this.lblNoteMoney.Text = "";
            if (!numeric)
            {
                this.lblNoteMoney.Text = "Input must be numeric.";
                this.valid = false;
                return;
            }
            this.valid = true;
        }
        protected void tbMonths_TextChanged(object sender, System.EventArgs e)
        {
            int num;
            bool numeric = int.TryParse(this.tbMonths.Text, out num);
            this.lblNoteMonth.Text = "";
            if (!numeric)
            {
                this.lblNoteMonth.Text = "Input must be numeric.";
                this.valid = false;
                return;
            }
            this.valid = true;
        }
        protected void tbCoMaker_TextChanged(object sender, System.EventArgs e)
        {
            this.valid = false;
            this.lblCoMaker.Text = "";
            if (this.EmpNo != this.tbCoMaker.Text)
            {
                using (DataAccess da = new DataAccess())
                {
                    if (da.EmployeeNumberExistAndConfirmed(this.tbCoMaker.Text))
                    {
                        if (da.HasLoanApplication(this.tbCoMaker.Text))
                        {
                            this.lblCoMaker.Text = "CoMaker still has a loan application.";
                        }
                        else
                        {
                            this.valid = true;
                        }
                    }
                    else
                    {
                        this.lblCoMaker.Text = "CoMaker Employee number does not exist.";
                    }
                    goto IL_A2;
                }
            }
            this.lblCoMaker2.Text = "This is your Employee number.";
        IL_A2:
            if (this.tbCoMaker.Text == "")
            {
                this.lblCoMaker.Text = "";
                this.valid = true;
            }
        }
        protected void tbCoMaker2_TextChanged(object sender, System.EventArgs e)
        {
            this.valid = false;
            this.lblCoMaker2.Text = "";
            if (this.EmpNo != this.tbCoMaker2.Text)
            {
                using (DataAccess da = new DataAccess())
                {
                    if (da.EmployeeNumberExistAndConfirmed(this.tbCoMaker2.Text))
                    {
                        if (da.HasLoanApplication(this.tbCoMaker2.Text))
                        {
                            this.lblCoMaker.Text = "CoMaker still has a loan application.";
                        }
                        else
                        {
                            this.valid = false;
                        }
                    }
                    else
                    {
                        this.lblCoMaker.Text = "CoMaker Employee number does not exist.";
                    }
                    goto IL_A2;
                }
            }
            this.lblCoMaker2.Text = "This is your Employee number.";
        IL_A2:
            if (this.tbCoMaker2.Text == "")
            {
                this.lblCoMaker2.Text = "";
                this.valid = true;
            }
        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            DataAccess da = new DataAccess();
            Messages msgObj = new Messages();
            if (this.tbReason.Text == "" || this.tbMonths.Text == "" || this.tbAmount.Text == "")
            {
                this.valid = false;
            }
            System.Collections.Generic.List<string> msgDetails = new System.Collections.Generic.List<string>();
            if (this.valid)
            {
                msgDetails.Add(this.EmpNo);
                msgDetails.Add(this.DDType.Text);
                msgDetails.Add(this.tbReason.Text);
                msgDetails.Add(this.tbAmount.Text);
                msgDetails.Add(this.tbMonths.Text);
                if (this.tbCoMaker.Text != "")
                {
                    msgDetails.Add(this.tbCoMaker.Text);
                }
                if (this.tbCoMaker2.Text != "")
                {
                    msgDetails.Add(this.tbCoMaker2.Text);
                }
                string coMakerSMSConfirm = "";
                string coMakerConfirm = "";
                string coMaker2SMSConfirm = "";
                string coMaker2Confirm = "";
                System.Collections.Generic.List<string> names = new System.Collections.Generic.List<string>();
                names.Add(da.GetEmployeeName(msgDetails[0]));
                if (msgDetails.Count >= 6)
                {
                    names.Add(da.GetEmployeeName(msgDetails[5]));
                    if (msgDetails.Count == 7)
                    {
                        names.Add(da.GetEmployeeName(msgDetails[6]));
                    }
                }
                int LastTransactionID = da.GetLastTransactionID();
                AttachmentHelper.CreatePrommisoryDocument(base.Server.MapPath("~/Files/OriginalFiles/Promissory.doc"), base.Server.MapPath("~/Files/Promissory") + LastTransactionID + ".pdf", msgDetails, names);
                //Commented
                AttachmentHelper.CreateDeductionDocument(base.Server.MapPath("~/Files/OriginalFiles/Deduction.doc"), base.Server.MapPath("~/Files/Deduction") + LastTransactionID + ".pdf", msgDetails, names[0]);
                //Commented
                MailHelper mail = new MailHelper();
                //Commented
                mail.AttachFile(base.Server.MapPath("~/Files/Promissory") + LastTransactionID + ".pdf");
                string message;
                if (msgDetails.Count >= 6)
                {
                    if (msgDetails.Count == 7)
                    {
                        message = mail.MakeEmailBodyLoanConfirmationCoMaker(msgDetails, names, LastTransactionID, names[2], true);
                        mail.SendMailMessage("dlsudmailer@gmail.com", da.GetEmployeeEmail(msgDetails[6]), "DLSU-D Notification Email", message);
                        mail.RefreshSMTP();
                        coMaker2SMSConfirm = mail.PassSMS;
                        coMaker2Confirm = mail.Pass;
                        msgObj.SendSMS(da.GetPhoneNumber(msgDetails[6]), msgObj.NotifyCoMaker(names[2]));
                    }
                    message = mail.MakeEmailBodyLoanConfirmationCoMaker(msgDetails, names, LastTransactionID, names[1], false);
                    mail.SendMailMessage("dlsudmailer@gmail.com", da.GetEmployeeEmail(msgDetails[5]), "DLSU-D Notification Email", message);
                    mail.RefreshSMTP();
                    coMakerSMSConfirm = mail.PassSMS;
                    coMakerConfirm = mail.Pass;
                    msgObj.SendSMS(da.GetPhoneNumber(msgDetails[5]), msgObj.NotifyCoMaker(names[1]));
                }
                mail.AttachFile(base.Server.MapPath("~/Files/Deduction") + LastTransactionID + ".pdf");
                message = mail.MakeEmailBodyLoanConfirmationMaker(msgDetails, names, LastTransactionID);
                mail.SendMailMessage("dlsudmailer@gmail.com", da.GetEmployeeEmail(msgDetails[0]), "DLSU-D Notification Email", message);
                //Commented
                string makerSMSConfirm = mail.PassSMS;
                string makerConfirm = mail.Pass;
                da.InsertLoanApplication(msgDetails, makerSMSConfirm, makerConfirm, coMakerSMSConfirm, coMakerConfirm, coMaker2SMSConfirm, coMaker2Confirm);
                //Commented
                mail.Dispose();
                //Commented
                base.Response.Redirect("~\\Message.aspx?msg=You have applied for a loan. Please check your email for the confirmation link.");
                return;
            }
            this.lblConfirmNote.Text = "Check inputs";
        }
    }
}