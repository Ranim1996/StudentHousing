using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Administration_App.Classes
{
    public class Event//Requests
    {
        public int ID { get; private set; }
        public string pWSR { get; private set; }
        public string Topic { get;private set; }
        public string Date { get; private set; }
        public string Time { get; private set; }
        public string Place { get; private set; }
        public string Description { get; private set; }
        public string Status { get; private set; }

        public List<Event> AllEvents { get; private set; }
        // -- admin exclusive
        public List<Event> AllEventsRequested { get; private set; }

        public void GetAllEvents()
        {
            try
            {
                AllEvents = DataBasePlayground.GetAllRequests();
            }
            catch
            {
                MessageBox.Show("Connection to the server wasn't possible!");
                AllEvents = new List<Event>();
            }
            // -- admin exclusive
            AllEventsRequested = new List<Event>();
            foreach(Event evnt in AllEvents)
            {
                if(evnt.Status == "ToBeRead")
                {
                    AllEventsRequested.Add(evnt);
                }
            }
        }
        public string ListBoxTxt
        {
            get { return $"{Date}     {Topic}"; }
        }
    }
}
