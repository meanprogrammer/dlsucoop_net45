using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMS;
using System.Xml;
using DataHelper;
using System.Web;
using Mail;

namespace SMSSync
{
    public class ReceiveSMS
    {
            HttpServerUtility Server
            {
                get { return HttpContext.Current.Server; }
            }
            private Messages msgObj;
            private MessageParse parseObj;
            private DataAccess da;
            public void RaiseCallbackEvent(string _number, string _message)
            {
                this.msgObj = new Messages();
                this.parseObj = new MessageParse();
                this.da = new DataAccess();
                //if (base.Request.InputStream != null && base.Request.InputStream.Length > 0L)
                //{
                //    XmlDocument xml = this.msgObj.ReceiveSMS(base.Request.InputStream);
                //    if (xml != null)
                //    {
                //XmlNodeList elemList = xml.GetElementsByTagName("param");
                string number = _number;//elemList[3].ChildNodes[1].InnerXml;
                string name = string.Empty;//elemList[0].ChildNodes[1].InnerXml;
                string xmlMessage = _message;//elemList[4].ChildNodes[1].InnerXml.Trim();
                string UDH = string.Empty;
                this.da.InsertMessage(name, number, xmlMessage, UDH);
                string Keyword = this.parseObj.GetCommand(xmlMessage).Trim();
                if (Keyword == "reg")
                {
                    this.RegisterUser(xmlMessage, number);
                }
                else
                {
                    if (Keyword == "loan")
                    {
                        this.LoanApplication(xmlMessage, number);
                    }
                    else
                    {
                        if (Keyword == "confirm")
                        {
                            this.ConfirmApplication(xmlMessage, number);
                        }
                        else
                        {
                            this.msgObj.SendSMS(number, Messages.WrongKeyword);
                        }
                    }
                }
                //    }
                //    else
                //    {
                //        this.Log("XML is empty");
                //    }
                //}
                //else
                //{
                //    this.Log("Stream is Empty");
                //}
                this.DisposeAll();
            }
            public string GetCallbackResult()
            {
                return "Done";
            }
            private void DisposeAll()
            {
                this.msgObj.Dispose();
                this.da.Dispose();
            }
            public void Log(string message)
            {
                using (System.IO.StreamWriter outfile = new System.IO.StreamWriter("D:\\Log.txt", true))
                {
                    outfile.WriteLine(message);
                    outfile.Dispose();
                }
            }
            private void RegisterUser(string xmlMessage, string number)
            {
                bool errorFound = false;
                System.Collections.Generic.List<string> msgDetails = this.parseObj.ProcessText(xmlMessage);
                if (msgDetails.Count == 4)
                {
                    if (this.da.NewRegistrationExist(msgDetails[1], msgDetails[2], number))
                    {
                        this.msgObj.SendSMS(number, Messages.PendingRegistration);
                        return;
                    }
                    if (MessageParse.IsValidEmail(msgDetails[2]) && MessageParse.IsLaSalleEmail(msgDetails[2]))
                    {
                        if (msgDetails[3].Length >= 6)
                        {
                            try
                            {
                                using (MailHelper mail = new MailHelper())
                                {
                                    this.da.SMSRegistrationInsert(msgDetails, number);
                                    mail.SendMailMessage("test@test.com", msgDetails[2], "Confirmation Link", mail.MakeEmailBody(msgDetails[1]));
                                    mail.SendMailMessage(mail.MakeEmailBody(msgDetails[1]));
                                    this.da.SMSRegistrationUpdateMailPass(msgDetails[1], mail.Pass);
                                    this.Log(this.msgObj.SuccessfulRegistrationMessage(msgDetails[0]));
                                    this.msgObj.SendSMS(number, this.msgObj.SuccessfulRegistrationMessage(msgDetails[0]));
                                }
                                goto IL_129;
                            }
                            catch (System.Exception ex)
                            {
                                this.Log(ex.Message);
                                goto IL_129;
                            }
                        }
                        errorFound = true;
                    }
                    else
                    {
                        errorFound = true;
                    }
                IL_129:
                    if (errorFound)
                    {
                        this.msgObj.SendSMS(number, Messages.RegistrationInstruction);
                        return;
                    }
                }
                else
                {
                    this.msgObj.SendSMS(number, Messages.RegistrationInstruction);
                }
            }
            private void LoanApplication(string xmlMessage, string number)
            {
                System.Collections.Generic.List<string> msgDetails = this.parseObj.ProcessText(xmlMessage);
                bool validMessage = true;
                if (!this.da.EmployeeNumberExistAndConfirmed(msgDetails[0]) || this.da.HasLoanApplication(msgDetails[0]))
                {
                    validMessage = false;
                }
                if (msgDetails.Count >= 6)
                {
                    if (!this.da.EmployeeNumberExistAndConfirmed(msgDetails[5]) || this.da.HasLoanApplication(msgDetails[5]) || msgDetails[0] == msgDetails[5])
                    {
                        validMessage = false;
                    }
                    if (msgDetails.Count == 7 && (!this.da.EmployeeNumberExistAndConfirmed(msgDetails[6]) || this.da.HasLoanApplication(msgDetails[6]) || msgDetails[0] == msgDetails[5] || msgDetails[0] == msgDetails[6] || msgDetails[5] == msgDetails[6]))
                    {
                        validMessage = false;
                    }
                }
                if (validMessage)
                {
                    string coMakerSMSConfirm = "";
                    string coMakerConfirm = "";
                    string coMaker2SMSConfirm = "";
                    string coMaker2Confirm = "";
                    System.Collections.Generic.List<string> names = new System.Collections.Generic.List<string>();
                    names.Add(this.da.GetEmployeeName(msgDetails[0]));
                    if (msgDetails.Count >= 6)
                    {
                        names.Add(this.da.GetEmployeeName(msgDetails[5]));
                        if (msgDetails.Count == 7)
                        {
                            names.Add(this.da.GetEmployeeName(msgDetails[6]));
                        }
                    }
                    int LastTransactionID = this.da.GetLastTransactionID();
                    AttachmentHelper.CreatePrommisoryDocument(this.Server.MapPath("~/Files/OriginalFiles/Promissory.doc"), this.Server.MapPath("~/Files/Promissory") + LastTransactionID + ".doc", msgDetails, names);
                    AttachmentHelper.CreateDeductionDocument(this.Server.MapPath("~/Files/OriginalFiles/Deduction.doc"), this.Server.MapPath("~/Files/Deduction") + LastTransactionID + ".doc", msgDetails, names[0]);
                    MailHelper mail = new MailHelper();
                    mail.AttachFile(this.Server.MapPath("~/Files/Promissory") + LastTransactionID + ".pdf");
                    string message;
                    if (msgDetails.Count >= 6)
                    {
                        if (msgDetails.Count == 7)
                        {
                            message = mail.MakeEmailBodyLoanConfirmationCoMaker(msgDetails, names, LastTransactionID, names[2], true);
                            mail.SendMailMessage("test@test.com", this.da.GetEmployeeEmail(msgDetails[6]), "TestWithFile", message);
                            mail.RefreshSMTP();
                            coMaker2SMSConfirm = mail.PassSMS;
                            coMaker2Confirm = mail.Pass;
                            this.msgObj.SendSMS(this.da.GetPhoneNumber(msgDetails[6]), this.msgObj.NotifyCoMaker(names[2]));
                        }
                        message = mail.MakeEmailBodyLoanConfirmationCoMaker(msgDetails, names, LastTransactionID, names[1], false);
                        mail.SendMailMessage("test@test.com", this.da.GetEmployeeEmail(msgDetails[5]), "TestWithFile", message);
                        mail.RefreshSMTP();
                        coMakerSMSConfirm = mail.PassSMS;
                        coMakerConfirm = mail.Pass;
                        this.msgObj.SendSMS(this.da.GetPhoneNumber(msgDetails[5]), this.msgObj.NotifyCoMaker(names[1]));
                    }
                    mail.AttachFile(this.Server.MapPath("~/Files/Deduction") + LastTransactionID + ".doc");
                    message = mail.MakeEmailBodyLoanConfirmationMaker(msgDetails, names, LastTransactionID);
                    mail.SendMailMessage("test@test.com", this.da.GetEmployeeEmail(msgDetails[0]), "TestWithFile", message);
                    string makerSMSConfirm = mail.PassSMS;
                    string makerConfirm = mail.Pass;
                    this.da.InsertLoanApplication(msgDetails, makerSMSConfirm, makerConfirm, coMakerSMSConfirm, coMakerConfirm, coMaker2SMSConfirm, coMaker2Confirm);
                    mail.Dispose();
                    this.msgObj.SendSMS(this.da.GetPhoneNumber(msgDetails[0]), this.msgObj.SuccessfulLoanMessage(names[0]));
                    return;
                }
                this.msgObj.SendSMS(number, Messages.LoanInstruction);
            }
            private void ConfirmApplication(string xmlMessage, string number)
            {
                System.Collections.Generic.List<string> msgDetails = this.parseObj.ProcessText(xmlMessage);
                if (!this.da.EmployeeNumberExist(msgDetails[0]))
                {
                    this.msgObj.SendSMS(number, Messages.ConfirmInstruction);
                    return;
                }
                if (this.da.ApplicationConfirmed(msgDetails[1]))
                {
                    this.msgObj.SendSMS(number, Messages.ConfirmInstruction);
                    return;
                }
                string role = this.da.GetRole(msgDetails[0], msgDetails[1]);
                if (role == "Maker")
                {
                    this.da.ConfirmLoan(msgDetails[1], msgDetails[2], false, false);
                    return;
                }
                if (role == "CoMaker")
                {
                    this.da.ConfirmLoan(msgDetails[1], msgDetails[2], true, false);
                    return;
                }
                if (role == "CoMaker2")
                {
                    this.da.ConfirmLoan(msgDetails[1], msgDetails[2], true, true);
                    return;
                }
                this.msgObj.SendSMS(number, Messages.ConfirmInstruction);
            }
    }
}
