using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantForm.Classes
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
            AllAnnouncements = DataBasePlayground.GetAllAnnouncements();
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
