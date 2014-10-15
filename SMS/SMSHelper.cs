using GlobeLabsApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS
{
    public class SMSHelper
    {
        const string APP_ID = "";
        const string APP_SECRET = "";
        const string SHORTCODE = "";

        private GlobeLabs api = null;

        public SMSHelper() {
            api = new GlobeLabs("");
        }

        public string SendSMS(string number, string message) { 
            List<string> nbs = new List<string>();
            nbs.Add(number);
            SmsPayload payload = new SmsPayload(){
                Message = message,
                Numbers = nbs
            };
            var result = api.PushSms(SHORTCODE, payload);
            return result.Status.StatusCode.ToString();
        }


    }
}
