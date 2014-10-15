using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web.Script.Serialization;
using DataHelper;

namespace SMSSync
{
    class Program
    {
        static void Main(string[] args)
        {
            ReceiveSMS rs = new ReceiveSMS();
            DataAccess da = new DataAccess();

            WebClient wc = new WebClient();
            string raw = wc.DownloadString("http://smsreg.net63.net/msgs.php");
            int startindex = raw.IndexOf("<!");

            raw = raw.Remove(startindex);
            JavaScriptSerializer js = new JavaScriptSerializer();
            var result = js.Deserialize<List<Dictionary<string, string>>>(raw);

            foreach (var item in result)
            {
                var msg = item["Message"];
                var number = FormatPhoneNumber(item["SenderAddress"]);
                rs.RaiseCallbackEvent(number, msg);
            }
        }

        private static string FormatPhoneNumber(string rawNumber) {
            if (rawNumber.IndexOf("tel:") >= 0)
            {
                rawNumber = rawNumber.Remove(rawNumber.IndexOf("tel:"), 4);
            }

            if (rawNumber.StartsWith("+"))
            {
                rawNumber = rawNumber.Remove(0, 1);
            }

            if (rawNumber.StartsWith("63"))
            {
                rawNumber = rawNumber.Remove(0, 2);
            }

            return rawNumber;
        }
    }
}
