using System;
using System.IO;
using System.Xml;
using System.Net;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
namespace SMS
{
	public class Messages : IDisposable
	{
		private Stream str;
		private bool _disposed;
		private static string instruction = "There is an error on your registration. To Register, type in: Reg<space>Name/EmployeeNo/DLSUD-Email/Password(6 Chars)";
		private static string _loanInstruction = "Cannot process you application. To Apply for a loan type in: Loan<space>EmployeeNo/LoanType/Reason/Amount/No Of Months/CoMaker(if any)";
		private static string _pendingRegistration = "Cannot process. You have a pending registration which is awaiting your confirmation. Please check your email address for the confirmation link. Thank You!";
		private static string _confirm = "Cannot process confirmation. To Confirm a transaction typeIn: Confirm EmpNo/TransactionNumber/ConfirmationCode";
		private static string _wrongKeyword = "Keyword not recognized. Recognized keywords are REG, LOAN and CONFIRM.";
		public static string RegistrationInstruction
		{
			get
			{
				return Messages.instruction;
			}
		}
		public static string ConfirmInstruction
		{
			get
			{
				return Messages._confirm;
			}
		}
		public static string WrongKeyword
		{
			get
			{
				return Messages._wrongKeyword;
			}
		}
		public static string PendingRegistration
		{
			get
			{
				return Messages._pendingRegistration;
			}
		}
		public static string LoanInstruction
		{
			get
			{
				return Messages._loanInstruction;
			}
		}
		public string SuccessfulRegistrationMessage(string name)
		{
			return "Hi " + name + ", you have been registered to DLSU-D Cooperative. Please check your email for the confirmation link";
		}

		public string SuccessfulLoanMessage(string name)
		{
			return "Hi " + name + ", you have applied for a loan to DLSU-D Cooperative. Please check your email for the confirmation link";
		}
		public string NotifyCoMaker(string name)
		{
			return "Hi " + name + ", you have been made as a co-maker for a loan application at DLSU-D Cooperative. Please check your email for the confirmation link";
		}
		public XmlDocument ReceiveSMS(Stream s)
		{
			this.str = s;
			XmlDocument result;
			try
			{
				this.str.Position = 0L;
				int num = Convert.ToInt32(this.str.Length);
				byte[] array = new byte[num];
				int num2 = this.str.Read(array, 0, num);
				string text = "";
				for (int i = 0; i < num; i++)
				{
					text += Convert.ToChar(array[i]);
				}
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(text);
				this.str.Dispose();
				result = xmlDocument;
				return result;
			}
			catch (Exception ex)
			{
				using (StreamWriter streamWriter = new StreamWriter("D:\\Log.txt", true))
				{
					streamWriter.WriteLine(ex.Message);
					streamWriter.Dispose();
				}
			}
			result = null;
			return result;
		}
		public void SendSMS(string pNumber, string pMessage)
		{
            //Platform platform = new Platform();
            //string text = platform.sendSMS("28fq0krip", "21738612", pNumber, pMessage, "1", "", "", "0");
            //using (StreamWriter streamWriter = new StreamWriter("D:\\Log.txt", true))
            //{
            //    streamWriter.WriteLine("Message Sent at: " + DateTime.Now.ToString());
            //    streamWriter.Dispose();
            //}
            //if (text == null)
            //{
            //    Console.WriteLine("[No response]");
            //}
            //else
            //{
            //    Console.WriteLine("Try");
            //}

            if (string.IsNullOrEmpty(pNumber))
            {
                throw new ArgumentNullException("subscriber number");
            }

            if (string.IsNullOrEmpty(pMessage))
            {
                throw new ArgumentNullException("message");
            }

            if (ConfigurationManager.AppSettings.Get("allowsms") == "true")
            {
                //WebClient wc = new WebClient();
                //string url = string.Format("http://smsreg.net63.net/send.php?subscriber_number={0}&message={1}", pNumber, pMessage);
                //string result = wc.DownloadString(url);

                SMSHelper sms = new SMSHelper();
                sms.SendSMS(pNumber, pMessage);
            }
		}
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
		protected virtual void Dispose(bool disposing)
		{
			if (!this._disposed)
			{
				if (disposing)
				{
					if (this.str != null)
					{
						this.str.Dispose();
					}
					Console.WriteLine("Object disposed.");
				}
				this.str = null;
				this._disposed = true;
			}
		}

        public string BuildLoanApprovedMessage(List<string> tDetails, string name)
        {
            StringBuilder text = new StringBuilder();
            text.AppendFormat("Hi {0}, ", name);
            text.AppendFormat("Your loan has been approved amounting to P {0}.", tDetails[4]);
            text.AppendFormat("Payable in  {0} months", tDetails[5]);
            return text.ToString();
        }
    }
}
