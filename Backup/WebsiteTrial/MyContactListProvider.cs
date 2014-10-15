using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASPNETChatControl.Extensibility;

namespace WebsiteTrial
{
    public class MyContactListProvider : ContactListProvider
    {
        public override System.Collections.Generic.Dictionary<string, string> GetContactsByUserId(string userId)
        {
            return base.GetContactsByUserId(userId);
        }
    }
}