using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantForm.Classes
{
    class Task // something like an event also
    {
        public int tID { get; set; }
        public string Title { get; set; }
        public string place { get; set; }
        public string time { get; set; }
        public string assignPerson { get; set; }
        public string initiator { get; set; }
        public string description { get; set; }
    }
}
