using System;
using System.Collections.Generic;
using System.Globalization;

namespace TenantForm.Classes
{
    public class LiveChat
    {
        // -- For active  users
        public string u_Name { get; private set; }
        public List<LiveChat> active_Users { get; private set; }

        // -- For chat window
        public string u_Name_Sender { get; private set; }
        public string msg_Date { get; private set; }
        public string msg_Time { get; private set; }
        public string message_Txt { get; private set; }
        public List<LiveChat> messages { get; private set; }

        public LiveChat()
        {
            active_Users = DataBasePlayground.Request_Active_Users();
            messages = DataBasePlayground.Request_Messages(DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
        }

    }
}


