using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
namespace DataHelper
{
	public class MessageParse
	{
		private static bool invalid = false;
		public string GetCommand(string pMessage)
		{
			int length = pMessage.IndexOf(" ");
			string a = pMessage.Substring(0, length).ToLower();
			string result;
			if (a == "reg" || a == "register" || a == "registration")
			{
				result = "reg";
			}
			else
			{
				if (a == "loan" || a == "lon" || a == "laon")
				{
					result = "loan";
				}
				else
				{
					if (a == "confirm" || a == "cnfirm" || a == "confrm" || a == "cnfrm")
					{
						result = "confirm";
					}
					else
					{
						result = "none";
					}
				}
			}
			return result;
		}
		public List<string> ProcessText(string pMessage)
		{
			if (pMessage.ElementAt(pMessage.Length - 1).ToString() == "/" || pMessage.ElementAt(pMessage.Length - 1).ToString() == "\\")
			{
				pMessage.Remove(pMessage.Length - 1);
			}
			List<string> list = new List<string>();
			string text = "";
			bool flag = true;
			for (int i = 0; i < pMessage.Length; i++)
			{
				if (!flag)
				{
					if (pMessage.ElementAt(i).ToString() == "\\" || pMessage.ElementAt(i).ToString() == "/")
					{
						list.Add(text);
						text = "";
					}
					else
					{
						if (i == pMessage.Length - 1)
						{
							text += pMessage.ElementAt(i).ToString();
							list.Add(text);
						}
						else
						{
							text += pMessage.ElementAt(i).ToString();
						}
					}
				}
				if (pMessage.ElementAt(i).ToString() == " ")
				{
					flag = false;
				}
			}
			return list;
		}
		public static bool IsValidEmail(string strIn)
		{
			MessageParse.invalid = false;
			bool result;
			if (string.IsNullOrEmpty(strIn))
			{
				result = false;
			}
			else
			{
				strIn = Regex.Replace(strIn, "(@)(.+)$", new MatchEvaluator(MessageParse.DomainMapper));
				result = (!MessageParse.invalid && Regex.IsMatch(strIn, "^(?(\")(\"[^\"]+?\"@)|(([0-9a-z]((\\.(?!\\.))|[-!#\\$%&'\\*\\+/=\\?\\^`\\{\\}\\|~\\w])*)(?<=[0-9a-z])@))(?(\\[)(\\[(\\d{1,3}\\.){3}\\d{1,3}\\])|(([0-9a-z][-\\w]*[0-9a-z]*\\.)+[a-z0-9]{2,17}))$", RegexOptions.IgnoreCase));
			}
			return result;
		}
		private static string DomainMapper(Match match)
		{
			IdnMapping idnMapping = new IdnMapping();
			string text = match.Groups[2].Value;
			try
			{
				text = idnMapping.GetAscii(text);
			}
			catch (ArgumentException)
			{
				MessageParse.invalid = true;
			}
			return match.Groups[1].Value + text;
		}
		public static bool IsLaSalleEmail(string strIn)
		{
			int num = strIn.IndexOf("@");
			string text = "";
			for (int i = num + 1; i < strIn.Length; i++)
			{
				text += strIn.ElementAt(i).ToString();
			}
			return text == "dlsud.edu.ph";
		}
	}
}
