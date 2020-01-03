using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TenantForm.Classes
{ 
    public class Report
    {   
        // -- the boolians are in <int> to safe space
        public int ID { get; private set; }
        public int cleanFacilities { get; private set; }
        public int troublesWithTenant { get; private set; }
        public int garbageDisposal { get; private set; }
        public int unannouncedParties { get; private set; }
        public int other { get; private set; }
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
            try
            {
                AllReports = DataBasePlayground.GetAllReports();
            }
            catch
            {
                MessageBox.Show("Connection to the server wasn't possible!");
                AllReports = new List<Report>();
            }
            
        }

        public string ListBoxTxt
        {
            get
            {
                string finalMark = "";

                if(cleanFacilities == 1)
                {
                    finalMark += "     Cleaning";
                }
                if (troublesWithTenant == 1)
                {
                    finalMark += "     Tenant Issues";
                }
                if(garbageDisposal == 1)
                {
                    finalMark += "     Garbage Issues";
                }
                if(unannouncedParties == 1)
                {
                    finalMark += "     Noise Issues";
                }
                if(other == 1)
                {
                    finalMark += "     Other";
                }
                   
                return $"{ Date }   { finalMark }"; 
            }
        }
    }
}
