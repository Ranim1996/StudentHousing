using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Administration_App.Classes
{
    public class Announcements
    {
        public int ID { get; private set; }
        public string pWSA { get; private set; }
        public string Topic { get; private set; }
        public string Text { get; private set; }
        public string DateA { get; private set; }
        public string DateE { get; private set; }
        public string Status { get; private set; }

        public List<Announcements> AllAnnouncements
        { get; private set; }

        public void GetAllAnnouncements()
        {
            try
            {
                AllAnnouncements = DataBasePlayground.GetAllAnnouncements();
            }
            catch
            {
                MessageBox.Show("Connection to the server wasn't possible!");
                AllAnnouncements = new List<Announcements>();
            }
            
        }

        public void SetStatus(int i,string status)
        {
            AllAnnouncements[i].Status = status;
        }

        public string ListBoxTxt
        {
            get { return $"{ DateA }   { Topic }   { pWSA }"; }
        }
    }
}
