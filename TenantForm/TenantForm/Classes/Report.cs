using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantForm.Classes
{
    public class Report
    {   
        public int ID { get; private set; }
        public string cleanFacilities { get; private set; }
        public string troublesWithTenant { get; private set; }
        public string garbageDisposal { get; private set; }
        public string unannouncedParties { get; private set; }
        public string other { get; private set; }
        public string cleanFacilitiesTxt { get; private set; }
        public string troublesWithTenantTxt { get; private set; }
        public string garbageDisposalTxt { get; private set; }
        public string unannouncedPartiesTxt { get; private set; }
        public string otherTxt { get; private set; }
        public string Status { get; private set; }
        public string Date { get; private set; }


        public List<Report> AllReports
        {
            get;
            private set;
        }
        public void GetAllReports()
        {
            AllReports = DataBasePlayground.GetAllReports();
        }






    }
}
