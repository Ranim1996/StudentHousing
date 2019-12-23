using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantForm.Classes
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

        public List<Event> events { get; private set; }

        public void GetAllEvents()
        {
            events = DataBasePlayground.GetAllRequests();
        }

    }
}
