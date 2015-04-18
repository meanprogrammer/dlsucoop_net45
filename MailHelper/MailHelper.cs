using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Net;
using System.Configuration;
namespace Mail
{
	public class MailHelper : IDisposable
	{
		private string _pass;
		private string _passSMS;
		private bool _disposed;
		private Random random = new Random();
		private MailMessage mail;
		private Attachment file;
		private SmtpClient smtp;
		private string URL;

        private string mailAddress = ConfigurationManager.AppSettings.Get("emailUser");
        private string mailPassword = ConfigurationManager.AppSettings.Get("emailPass");

		public string CurrentURL
		{
			get
			{
				return this.URL;
			}
		}
		public string Pass
		{
			get
			{
				return this._pass;
			}
		}
		public string PassSMS
		{
			get
			{
				return this._passSMS;
			}
		}
		public MailHelper()
		{
            this.mail = new MailMessage();
            this.smtp = new SmtpClient("smtp.mailgun.org");
            this.smtp.UseDefaultCredentials = false;
            this.smtp.EnableSsl = true;
            NetworkCredential basicCredential = new NetworkCredential(mailAddress, mailPassword);
            this.smtp.Credentials = basicCredential;
            this.smtp.Port = 587;
            this.smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
			this.URL = this.GetURL();
		}
		private string GenerateRandomAlphaNumeric(int length)
		{
			string element = "ABCDEFGHIJKLMNPQRSTUVWXYZ0123456789";
			return new string((
				from s in Enumerable.Repeat<string>(element, length)
				select s[this.random.Next(s.Length)]).ToArray<char>());
		}
		public void SendMailMessage(string from, string to, string subject, string body)
		{
            //this.mail.From = new MailAddress(from);
            //this.mail.To.Add(to);
            //this.mail.Subject = subject;
            //this.mail.Body = body;
            //this.smtp.Send(this.mail);

            this.mail = new MailMessage();
            using (SmtpClient server = new SmtpClient("smtp.mailgun.org"))
            {
                server.UseDefaultCredentials = false;
                server.EnableSsl = true;
                NetworkCredential basicCredential = new NetworkCredential(this.mailAddress, this.mailPassword);
                server.Credentials = basicCredential;
                server.Port = 587;
                server.DeliveryMethod = SmtpDeliveryMethod.Network;

                this.mail.From = new MailAddress(from);
                this.mail.To.Add(to);
                this.mail.Subject = subject;
                this.mail.Body = body;
                if (ConfigurationManager.AppSettings.Get("allowemail") == "true")
                {
                    server.Send(this.mail);
                }
            }
		}

        public void SendMailMessage(string from, string to, string subject, string body, bool isBodyHtml)
        {
            //this.mail.From = new MailAddress(from);
            //this.mail.To.Add(to);
            //this.mail.Subject = subject;
            //this.mail.Body = body;
            //this.smtp.Send(this.mail);

            this.mail = new MailMessage();
            using (SmtpClient server = new SmtpClient("smtp.mailgun.org"))
            {
                server.UseDefaultCredentials = false;
                server.EnableSsl = true;
                NetworkCredential basicCredential = new NetworkCredential(this.mailAddress, this.mailPassword);
                server.Credentials = basicCredential;
                server.Port = 587;
                server.DeliveryMethod = SmtpDeliveryMethod.Network;

                this.mail.From = new MailAddress(from);
                this.mail.To.Add(to);
                this.mail.Subject = subject;
                this.mail.Body = body;
                this.mail.IsBodyHtml = isBodyHtml;
                if (ConfigurationManager.AppSettings.Get("allowemail") == "true")
                {
                    server.Send(this.mail);
                }
            }
        }
		public void RefreshSMTP()
		{
			this.smtp.Dispose();
            this.smtp.UseDefaultCredentials = false;
            this.smtp.EnableSsl = true;
            NetworkCredential basicCredential = new NetworkCredential(mailAddress, mailPassword);
            this.smtp.Credentials = basicCredential;
            this.smtp.Port = 587;
			this.mail.To.Clear();
		}
		public void SendMailMessage(string body)
		{
			using (StreamWriter streamWriter = new StreamWriter("C:\\ConfirmLink.txt", true))
			{
				streamWriter.WriteLine(body);
				streamWriter.Dispose();
			}
		}
		public string MakeEmailBody(string empNo)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("You have registered to DLSU-D Coop portal. To confirm your email address, please click the link below.");
			stringBuilder.AppendLine("");
			this._pass = Membership.GeneratePassword(35, 0);
			stringBuilder.AppendLine(string.Concat(new string[]
			{
				this.URL,
				"ConfirmRegistration.aspx?user=",
				empNo,
				"&confirmationCode=",
				HttpUtility.UrlEncode(this._pass)
			}));
			return stringBuilder.ToString();
		}
		public string MakeEmailBodyLoanConfirmationMaker(List<string> details, List<string> names, int transactionID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("Hi " + names[0]);
			stringBuilder.AppendLine("");
			stringBuilder.AppendLine("You have made an Application for a Loan");
			stringBuilder.AppendLine("Loan Application Details");
			stringBuilder.AppendLine("Transaction Number: " + transactionID);
			stringBuilder.AppendLine("Type Of Loan: " + details[1]);
			stringBuilder.AppendLine("Reason: " + details[2]);
			stringBuilder.AppendLine("Amount: " + details[3]);
			stringBuilder.AppendLine("Months To Pay: " + details[4]);
			if (names.Count >= 2)
			{
				stringBuilder.AppendLine("CoMaker: " + names[1]);
			}
			if (names.Count == 3)
			{
				stringBuilder.AppendLine("CoMaker2: " + names[2]);
			}
			this._passSMS = this.GenerateRandomAlphaNumeric(6);
			stringBuilder.AppendLine("Confirmation Code: " + this._passSMS);
			this._pass = Membership.GeneratePassword(35, 0);
			stringBuilder.AppendLine("");
			stringBuilder.AppendLine("REMINDER: PLEASE READ THE ATTACHED FILE/S CLICKING THE LINK WILL MEAN THAT YOU AGREE TO THE TERMS OF AGREEMENT WRITTEN ON THE FILES INCLUDED.");
			stringBuilder.AppendLine("Please confirm your application by clicking the link below");
			stringBuilder.AppendLine(string.Concat(new object[]
			{
				this.URL,
				"ConfirmLoan.aspx?trans=",
				transactionID,
				"&confirmationCode=",
				HttpUtility.UrlEncode(this._pass)
			}));
			return stringBuilder.ToString();
		}
		public string MakeEmailBodyLoanConfirmationCoMaker(List<string> details, List<string> names, int transactionID, string sendTo, bool coMaker2)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("Hi " + sendTo);
			stringBuilder.AppendLine("");
			stringBuilder.AppendLine("You have been made as a coMaker by " + names[0] + " for an Application for a Loan");
			stringBuilder.AppendLine("");
			stringBuilder.AppendLine("Loan Application Details");
			stringBuilder.AppendLine("Transaction Number: " + transactionID);
			stringBuilder.AppendLine("Type Of Loan: " + details[1]);
			stringBuilder.AppendLine("Reason: " + details[2]);
			stringBuilder.AppendLine("Amount: " + details[3]);
			stringBuilder.AppendLine("Months To Pay: " + details[4]);
			if (names.Count >= 2)
			{
				stringBuilder.AppendLine("CoMaker: " + names[1]);
			}
			if (names.Count == 3)
			{
				stringBuilder.AppendLine("CoMaker2: " + names[2]);
			}
			this._passSMS = this.GenerateRandomAlphaNumeric(6);
			stringBuilder.AppendLine("Confirmation Code: " + this._passSMS);
			stringBuilder.AppendLine("");
			stringBuilder.AppendLine("REMINDER: PLEASE READ THE ATTACHED FILE/S CLICKING THE LINK WILL MEAN THAT YOU AGREE TO THE TERMS OF AGREEMENT WRITTEN ON THE FILES INCLUDED.");
			stringBuilder.AppendLine("Please confirm your application by clicking the link below");
			this._pass = Membership.GeneratePassword(35, 0);
			if (!coMaker2)
			{
				stringBuilder.AppendLine(string.Concat(new object[]
				{
					this.URL,
					"ConfirmLoan.aspx?trans=",
					transactionID,
					"&confirmationCode=",
					HttpUtility.UrlEncode(this._pass),
					"&coMaker=1"
				}));
			}
			else
			{
				stringBuilder.AppendLine(string.Concat(new object[]
				{
					this.URL,
					"ConfirmLoan.aspx?trans=",
					transactionID,
					"&confirmationCode=",
					HttpUtility.UrlEncode(this._pass),
					"&coMaker=2"
				}));
			}
			stringBuilder.AppendLine("");
		
			return stringBuilder.ToString();
		}
		public void AttachFile(string filePath)
		{
			this.file = new Attachment(filePath);
			this.mail.Attachments.Add(this.file);
		}
		public void ClearAttachment()
		{
            this.mail.Attachments.Dispose();
			this.mail.Attachments.Clear();
		}
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
		protected void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.smtp.Dispose();
				this.mail.Dispose();
			}
			if (this.file != null)
			{
				this.file.Dispose();
			}
			this._disposed = true;
		}
		private string GetURL()
		{
			string text = null;
			HttpContext current = HttpContext.Current;
			if (current != null)
			{
				text = string.Format("{0}://{1}{2}{3}", new object[]
				{
					current.Request.Url.Scheme,
					current.Request.Url.Host,
					string.Empty, //(current.Request.Url.Port == 80) ? string.Empty : (":" + current.Request.Url.Port),
					current.Request.ApplicationPath
				});
			}
			if (!text.EndsWith("/"))
			{
				text += "/";
			}
			return text;
		}
	}
}
