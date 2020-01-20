using System;
using System.Collections.Generic;
using System.Globalization;

namespace Administration_App.Classes
{
    public class LiveChat
    {
        // -- For active  users
        public string uFirst_Name { get; private set; }
        public string u_Status { get; private set; }
        public List<LiveChat> active_Users { get; private set; }

        // -- For chat window
        public string u_Name_Sender { get; private set; }
        public string msg_Date { get; private set; }
        public string msg_Time { get; private set; }
        public string message_Txt { get; private set; }
        public string sender_Status { get; private set; }
        public List<LiveChat> messages { get; private set; }



        public void Refresh_Users()
        {
            active_Users = DataBasePlayground.Request_Active_Users();
        }
        public void Refresh_Messages()
        {
            messages = DataBasePlayground.Request_Messages(DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
        }

        public string ActiveUser
        {
            get
            {
                if (u_Status == "admin")
                {
                    return $"\u2022 {this.uFirst_Name}(admin)";
                }
                else
                {
                    return $"\u2022 {this.uFirst_Name}";
                }
            }
        }
    }
}

