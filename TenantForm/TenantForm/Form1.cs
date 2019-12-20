using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TenantForm;
using TenantForm.Classes;

namespace TenantForm
{
    public partial class Form1 : Form
    {
        //the list with announcemets is in this instance
        Announcements ann = new Announcements();
        //holds the calendar
        Calendar cal = new Calendar();

        //variables for time managment
        private int hours = 0;
        private int minutes = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // --- Calendar Tab ---
            cal.GenerateDayPanel(42,flDays);
            cal.DisplayCurrentDate();
            tbDateRequest.Text = dateTimePicker1.Value.ToString("dd/MM/yyyy");

            // --- Announcements Tab ---
            // --- READY 
            //ann.GetAllAnnouncements();
        }
          
        // --- Calendar Tab ---
        private void btnPrevMonth_Click(object sender, EventArgs e)
        {
            cal.PrevMonth();
        }

        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            cal.NextMonth();
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            cal.Today();
        }
        //-------------------------------------------------------------------------------------------


        // --- Make a Request Tab ---
        private void trackBarHour_Scroll(object sender, EventArgs e)
        {
            hours = trackBarHour.Value;
            tbTimeRequest.Text = hours.ToString("00") + ":" + minutes.ToString("00");
            //tbTimeRequest.Text = $"{hours}:{minutes}";
        }

        private void trackBarMin_Scroll(object sender, EventArgs e)
        {
            minutes = trackBarMin.Value;
            tbTimeRequest.Text = hours.ToString("00") + ":" + minutes.ToString("00");
            //tbTimeRequest.Text = $"{hours}:{minutes}";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            tbDateRequest.Text = dateTimePicker1.Value.ToString("dd/MM/yyyy");
        }

        private void btnMakeRequest_Click(object sender, EventArgs e)
        {
            if(tbTopicRequest.Text == "" || tbPlace.Text == "")
            {
                MessageBox.Show("Please fill the whole form!");
            }
            else
            {
                string topic = tbTopicRequest.Text;
                string place = tbPlace.Text;
                string date = tbDateRequest.Text;
                string time = tbTimeRequest.Text;
                string des = richTBDescriptionReq.Text;

                DialogResult dialogResult = MessageBox.Show("Are you sure you want to send this request?", "Warning!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //query
                    DataBasePlayground.AddRequest(/* <DEMO> */ 1234, "abv" /* </DEMO>*/, topic, date, time, place, des);
                    Clean_Request_Tab();

                }
                else if (dialogResult == DialogResult.No)
                {
                    //do nothing ---> may be changed later
                }

            }

        }

        private void Clean_Request_Tab()
        {
            tbTopicRequest.Text = "";
            tbDateRequest.Text = DateTime.Now.ToString("dd/MM/yyyy");
            tbTimeRequest.Text = "00:00";
            hours = 0;
            minutes = 0;
            tbPlace.Text = "";
            richTBDescriptionReq.Text = "";
            trackBarHour.Value = 0;
            trackBarMin.Value = 0;
            dateTimePicker1.Value = DateTime.Now;
        }

        //----------------------------------------------------------------------------------------------------------------------------





        // --- Make a Complain TAB ---
        private void btMakeComplain_Click(object sender, EventArgs e)
        {
            if (!cbCleanFacilities.Checked&&!cbTroublesWithTenant.Checked&&!cbGarbageDisposal.Checked&&!cbUnnanouncedParties.Checked&&!cbOther.Checked)
            {
                MessageBox.Show("There is no specified complain!");
            }
            else
            {
                // -- constructor 
                int clean_Facilities = 0;
                int troubles_Tenant = 0;
                int garbage_Dispolsal = 0;
                int unnanounced_Parties = 0;
                int Other = 0;


                string clean_FacilitiesTxt = tbCleanFacilities.Text;
                string troubles_TenantTxt = tbTroublesWithTenant.Text;
                string garbage_DispolsalTxt = tbGarbageDisplosal.Text;
                string unnanounced_PartiesTxt = tbUnnanouncedParties.Text;
                string OtherTxt = tbOther.Text;

                string date = DateTime.Now.ToString("dd/MM/yyyy");
               

                if (cbCleanFacilities.Checked)
                {
                    clean_Facilities = 1;
                }
                else
                {
                    clean_FacilitiesTxt = string.Empty;
                }
                if (cbTroublesWithTenant.Checked)
                {
                    troubles_Tenant = 1;
                }
                else
                {
                    troubles_TenantTxt = string.Empty;
                }
                if (cbGarbageDisposal.Checked)
                {
                    garbage_Dispolsal = 1;
                }
                else
                {
                    garbage_DispolsalTxt = string.Empty;
                }
                if (cbUnnanouncedParties.Checked)
                {
                    unnanounced_Parties = 1;
                }
                else
                {
                    unnanounced_PartiesTxt = string.Empty;
                }
                if (cbOther.Checked)
                {
                    Other = 1;
                }
                else
                {
                    OtherTxt = string.Empty;
                }


                DialogResult dialogResult = MessageBox.Show("Are you sure you want to send this complain?", "Warning!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //query
                    DataBasePlayground.AddReport(/* <DEMO> */ 1234, "abv" /* </DEMO>*/, clean_Facilities, troubles_Tenant, garbage_Dispolsal, unnanounced_Parties, Other, clean_FacilitiesTxt, troubles_TenantTxt, garbage_DispolsalTxt, unnanounced_PartiesTxt, OtherTxt, date);
                    Clean_Complain_Tab();
                    
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do nothing ---> may be changed later
                }
                
            }

        }
        
        private void Clean_Complain_Tab()
        {
            // -- checkboxes
            cbCleanFacilities.Checked = false;
            cbTroublesWithTenant.Checked = false;
            cbGarbageDisposal.Checked = false;
            cbUnnanouncedParties.Checked = false;
            cbOther.Checked = false;

            // -- textboxes
            tbCleanFacilities.Text = "";
            tbTroublesWithTenant.Text = "";
            tbGarbageDisplosal.Text = "";
            tbUnnanouncedParties.Text = "";
            tbOther.Text = "";
        }
        //---------------------------------------------------------------------------------------------------

        // --- Announcements Tab ---
        private void metroTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(metroTabControl1.SelectedIndex == 3)
            {
                //data base not connected
                //Check and Update the 
                //ExpDateChecker();
                //StatusChecker();
                //ann.GetAllAnnouncements();
                // experimental
                //listboxAnn.DataSource = null;
                //listboxAnn.DataSource = ann.AllAnnouncements;
                //listboxAnn.DisplayMember = "ListBoxTxt";

            }
        }

        private void ExpDateChecker()
        {

            int i = 0;
            //gets the date Today
            string[] dateToday = DateTime.Now.ToString("dd/MM/yyyy").Split('/');

            while (i<ann.AllAnnouncements.Count)
            {
                //gets the date fir expiration(i doubt that its written like that)
                string[] dateAnnE = ann.AllAnnouncements[i].DateE.Split('/');

                if (Convert.ToInt32(dateAnnE[2]) == Convert.ToInt32(dateToday[2]))
                {
                    if(Convert.ToInt32(dateAnnE[1]) == Convert.ToInt32(dateToday[1]))
                    {
                        if(Convert.ToInt32(dateAnnE[0]) < Convert.ToInt32(dateToday[0]))
                        {
                            ann.SetStatus(i, "Expired");
                        }
                    }
                    else if(Convert.ToInt32(dateAnnE[1]) < Convert.ToInt32(dateToday[1]))
                    {
                        ann.SetStatus(i, "Expired");
                    }
                }
                else if (Convert.ToInt32(dateAnnE[2]) < Convert.ToInt32(dateToday[2]))
                {
                    ann.SetStatus(i, "Expired");
                }
                i++;
            }
        }

        private void StatusChecker()
        {
            int i = 0;

            while(i < ann.AllAnnouncements.Count)
            {
                if(ann.AllAnnouncements[i].Status == "Expired")
                {
                    DataBasePlayground.ExpirationRemover(ann.AllAnnouncements[i].ID);
                }
            }
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------

    }
}
