using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SMS
{
    public class SMSDataHelper
    {
        Database db;
        public SMSDataHelper() {
            db = DatabaseFactory.CreateDatabase("default");
        }

        public string GetAccessToken(string subscriberNumber) {
            DbCommand cmd = db.GetSqlStringCommand(
                            string.Format("SELECT AccessToken FROM AccessTokens WHERE SubscriberNumber = '{0}'",
                            subscriberNumber));
            var at = db.ExecuteScalar(cmd).ToString();
            return at;
        }
    }
}
