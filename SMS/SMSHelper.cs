using GlobeLabsApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS
{
    public class SMSHelper
    {
        /*
        const string APP_ID = "ekz5qSALXAzhMoT6XBcXMKh75zrqSBbb";
        const string APP_SECRET = "9e6fc50f715cedbe655c285fbd6efe53033112251ab3b3776424dfc18cdf88a6";
        const string SHORTCODE = "21580262";
        */

        const string APP_ID = "pMMGCL5RKpu4Rik9R7cRaxuGzMXMCM7z";
        const string APP_SECRET = "db0260bd73db0f582d9be6d8fd14dcf00371b92de411faa5c04838cafc93a38d";
        const string SHORTCODE = "21583300";

        private GlobeLabs api = null;
        private SMSDataHelper data = null;
        public SMSHelper() {
            api = new GlobeLabs(APP_ID, APP_SECRET);
            data = new SMSDataHelper();
        }

        public string SendSMS(string number, string message) { 
            List<string> nbs = new List<string>();
            nbs.Add(number);
            SmsPayload payload = new SmsPayload(){
                Message = message,
                Numbers = nbs
            };

            string at = data.GetAccessToken(number);
            if (!string.IsNullOrEmpty(at)) {
                api.AccessToken = at;
            }

            var result = api.PushSms(SHORTCODE, payload);
            return result.Status.StatusCode.ToString();
        }

        public string AuthorizeNumber(string code) {
            AuthResult result = api.Authorize(code);
            if (result != null) { 

            }
            return string.Empty;
        }


    }
}
