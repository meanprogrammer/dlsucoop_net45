using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using DataHelper;
using SMS;
using Mail;
using System.Web.UI.WebControls;
using System.Text;

namespace WebsiteTrial
{
    public partial class Loan : Page
    {
        private string EmpNo;
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

                using (DataAccess da = new DataAccess())
                {
                    if (!da.CompleteDetail(base.Session["EmpNo"].ToString()))
                    {
                        base.Response.Redirect("~/Message.aspx?msg=Please complete your details in the account setting first before making a loan.");
                    }
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
                    this.DDType.DataTextField = "LoanType1";
                    this.DDType.DataValueField = "RecordID";
                    this.DDType.DataBind();

                    this.Comaker1DropDownList.DataSource = da.GetAllUsersWithEmptyExceptOne(this.EmpNo);
                    this.Comaker1DropDownList.DataTextField = "Name";
                    this.Comaker1DropDownList.DataValueField = "EmpNo";
                    this.Comaker1DropDownList.DataBind();

                    this.Comaker2DropDownList.DataSource = da.GetAllUsersWithEmptyExceptOne(this.EmpNo);
                    this.Comaker2DropDownList.DataTextField = "Name";
                    this.Comaker2DropDownList.DataValueField = "EmpNo";
                    this.Comaker2DropDownList.DataBind();

                    this.ShareCapitalTextBox.Text = da.GetTotalShareCapitals(this.EmpNo).ToString();
	            }
                
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
        
        protected void ShowAgreement_Click(object sender, System.EventArgs e)
        {

            if (!Page.IsValid)
            {
                return;
            }
            this.Panel1.Visible = true;
            this.Panel2.Visible = true;        
        }

        protected void DDType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DDType.SelectedIndex > 0)
            {
                using (DataAccess da = new DataAccess())
                {
                    this.AllowedAmountDropDownList.DataSource = da.GetLoanAmountMatrix(int.Parse(this.DDType.SelectedValue), this.EmpNo);
                    this.AllowedAmountDropDownList.DataTextField = "LoanAmount";
                    this.AllowedAmountDropDownList.DataValueField = "RecordID";
                    this.AllowedAmountDropDownList.DataBind();
                    this.AllowedAmountDropDownList.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--SELECT--", ""));
                    this.AllowedAmountDropDownList.SelectedIndex = -1;
                    this.MonthsToPayLabel.Text = string.Empty;
                    this.tbAmount.Text = string.Empty;
                    if (this.DDType.SelectedValue == "1" || this.DDType.SelectedValue == "10")
                    {
                        this.AllowedAmountDropDownList.Enabled = false;
                        this.amtlabel.Visible = true;
                        this.tbAmount.Visible = true;
                        this.MonthsToPayLabel.ReadOnly = false;
                    }
                    else
                    {
                        this.AllowedAmountDropDownList.Enabled = true;
                        this.amtlabel.Visible = false;
                        this.tbAmount.Visible = false;
                        this.MonthsToPayLabel.ReadOnly = true;
                    }
                }
            }
        }

        protected void AllowedAmountDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = this.AllowedAmountDropDownList.SelectedValue;
            if (string.IsNullOrEmpty(selected)) { this.MonthsToPayLabel.Text = string.Empty; return; }
            using (DataAccess da = new DataAccess())
            {
                LoanAmountMatrix lm = da.GetOneLoanMatrixById(int.Parse(selected));
                this.MonthsToPayLabel.Text = lm.MonthsPayable.ToString();
                this.ProcessingFeeTextBox.Text = lm.ProcessingFee.ToString();
            }
        }


        protected void ValidateLoanAmount(object source, ServerValidateEventArgs args)
        {
            StringBuilder b = new StringBuilder();

            using (DataAccess da = new DataAccess())
            {
                //args.IsValid = (!da.EmployeeNumberExist(this.tbEmpNum.Text) && !da.NewRegistrationExist(this.tbEmpNum.Text, this.tbEmail.Text, this.tbPhone.Text.Trim()));

                var selected = this.DDType.SelectedValue;
                if (!string.IsNullOrEmpty(selected))
                {
                    if (selected == "1")
                    {
                        double amount = 0f;
                        if (!double.TryParse(this.tbAmount.Text.Trim(), out amount))
                        {
                            args.IsValid = false;
                            b.AppendFormat("{0}{1}", "For regular loans, Amount is required.", Environment.NewLine);
                            this.CustomValidator1.ErrorMessage = b.ToString();
                            return;
                        }

                        double share = da.GetTotalShareCapitals(this.EmpNo);
                        double maxLoan = share * 3;

                        args.IsValid = maxLoan >= double.Parse(this.tbAmount.Text);

                        if (!args.IsValid) {
                            b.AppendFormat("{0}{1}", "Maximum loan is your total share x 3.", Environment.NewLine);
                        }

                        
                            if (string.IsNullOrEmpty(this.MonthsToPayLabel.Text.Trim()))
                            {
                                b.AppendFormat("{0}{1}", "Months to pay: Please enter between 1 and 18.", Environment.NewLine);
                                args.IsValid = false;
                                this.CustomValidator1.ErrorMessage = b.ToString();
                                return;
                            }

                            int mtp = 0;
                            if (int.TryParse(this.MonthsToPayLabel.Text, out mtp))
                            {
                                if (mtp <= 0 || mtp > 18)
                                {
                                    b.AppendFormat("{0}{1}", "Months to pay: Please enter between 1 and 18.", Environment.NewLine);
                                    args.IsValid = false;
                                }
                            }
                            else
                            {
                                b.AppendFormat("{0}{1}", "Months to pay: Please enter a valid digit.", Environment.NewLine);
                                args.IsValid = false;
                            }
                            CustomValidator2.ErrorMessage = b.ToString();
                        
                    }

                    if (selected == "10")
                    {
                        double share = da.GetTotalShareCapitals(this.EmpNo);
                        args.IsValid = share > 10000;
                        if (!args.IsValid) 
                        {
                            b.AppendFormat("{0}{1}", "To avail motorcycle loan, you must atleast paid 10,000 of share capital.", Environment.NewLine);
                        }

                        double amount = 0f;
                        if (!double.TryParse(this.tbAmount.Text.Trim(), out amount))
                        {
                            args.IsValid = false;
                            b.AppendFormat("{0}{1}", "For regular loans, Amount is required.", Environment.NewLine);
                        }
                    }
                    this.CustomValidator1.ErrorMessage = b.ToString();
                }

            }
        }

        protected void AcceptButton_Click(object sender, EventArgs e)
        {
            DataAccess da = new DataAccess();
            Messages msgObj = new Messages();

            System.Collections.Generic.List<string> msgDetails = new System.Collections.Generic.List<string>();

            bool filename = this.FileUpload1.HasFile;

                msgDetails.Add(this.EmpNo);
                msgDetails.Add(this.DDType.Text);
                msgDetails.Add(this.tbReason.Text);
                var amount = this.DDType.SelectedValue == "1" ? this.tbAmount.Text : this.AllowedAmountDropDownList.SelectedItem.Text; 
                msgDetails.Add(amount);
                msgDetails.Add(this.MonthsToPayLabel.Text);

                msgDetails.Add(this.Comaker1DropDownList.SelectedValue);
                msgDetails.Add(this.Comaker2DropDownList.SelectedValue);

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
                //base.Response.Redirect("~\\Message.aspx?msg=You have applied for a loan. Please check your email for the confirmation link.");
                //return;

                this.msgbox.InnerHtml = "You have applied for a loan. Please check your email for the confirmation link.";
                CancelButton_Click(sender, e);
                ClearControls();
        }

        private void ClearControls()
        {
            this.DDType.SelectedIndex = -1;
            this.tbAmount.Text = string.Empty;
            this.Comaker1DropDownList.SelectedIndex = -1;
            this.Comaker2DropDownList.SelectedIndex = -1;
            this.AllowedAmountDropDownList.SelectedIndex = -1;
            this.tbReason.Text = string.Empty;
            this.MonthsToPayLabel.Text = string.Empty;
            this.ProcessingFeeTextBox.Text = string.Empty;
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            this.Panel1.Visible = false;
            this.Panel2.Visible = false;
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            StringBuilder b = new StringBuilder();
            args.IsValid = true;
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            bool hasfile = this.FileUpload1.HasFile;
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            if (this.AgreementCheckBox.Checked == false)
            {
                this.msgbox.InnerHtml = "You must agree to Loan Agreement";
                this.msgbox.Attributes["class"] = "alert alert-danger";
                return;
            }

            DataAccess da = new DataAccess();
            Messages msgObj = new Messages();

            System.Collections.Generic.List<string> msgDetails = new System.Collections.Generic.List<string>();

            bool filename = this.FileUpload1.HasFile;

            msgDetails.Add(this.EmpNo);
            msgDetails.Add(this.DDType.Text);
            msgDetails.Add(this.tbReason.Text);
            var amount = this.DDType.SelectedValue == "1" ? this.tbAmount.Text : this.AllowedAmountDropDownList.SelectedItem.Text;
            msgDetails.Add(amount);
            msgDetails.Add(this.MonthsToPayLabel.Text);

            msgDetails.Add(this.Comaker1DropDownList.SelectedValue);
            msgDetails.Add(this.Comaker2DropDownList.SelectedValue);

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
            //base.Response.Redirect("~\\Message.aspx?msg=You have applied for a loan. Please check your email for the confirmation link.");
            //return;

            this.msgbox.InnerHtml = "You have applied for a loan. Please check your email for the confirmation link.";
            CancelButton_Click(sender, e);
            ClearControls();
        }
    }
}