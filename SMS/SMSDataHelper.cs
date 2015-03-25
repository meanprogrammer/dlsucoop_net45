using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataHelper;

namespace SMS
{
    public class SMSDataHelper
    {
        //Database db;
        public SMSDataHelper() {
            //db = DatabaseFactory.CreateDatabase("default");
        }

        public string GetAccessToken(string subscriberNumber) {
            /*
            DbCommand cmd = db.GetSqlStringCommand(
                            string.Format("SELECT AccessToken FROM AccessTokens WHERE SubscriberNumber = '{0}'",
                            subscriberNumber));
            var at = db.ExecuteScalar(cmd).ToString();
            return at;
             * */
            AccessToken accessToken = null;
            using (MessagesDataContext context = new MessagesDataContext()) 
            {
                var result = from at in context.AccessTokens
                             join emp in context.Users on at.EmpNo equals emp.EmpNo
                             select at as AccessToken;
                //accessToken = context.AccessTokens.FirstOrDefault(c => c. == subscriberNumber);
                accessToken = result.FirstOrDefault();
            }

            if (accessToken == null) return string.Empty;

            return accessToken.AccessToken1;
        }
    }
}
