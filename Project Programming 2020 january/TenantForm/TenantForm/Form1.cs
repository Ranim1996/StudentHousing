using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TenantForm;
using System.Globalization;
using TenantForm.Classes;

namespace TenantForm
{
    public partial class Form1 : Form
    {
        //credentials for the guy using the form
        private string user_Name;
        private string user_FirstName;
        private string user_LastName;
        private string user_Status;

        //wild card
        bool close = true;

        //the list with announcemets is in this instance
        Announcements ann = new Announcements();
        //holds the calendar
        TenantForm.Classes.Calendar cal = new TenantForm.Classes.Calendar();
        //holds the events
        Event evn = new Event();
        // -- functionality only for the IDGenerator
        Report rep = new Report();
        //chat
        LiveChat chat = new LiveChat();
        

        //variables for time managment
        private int hours = 0;
        private int minutes = 0;

        

        public Form1()
        {
            //subscribe to the delegate
            LogIn.InformationPass += SetUser;

            InitializeComponent();

           
        }

        // -- when the form loads
        private void Form1_Load(object sender, EventArgs e)
        {
            // --- Calendar Tab ---
            evn.GetAllEvents(); // -- Events
            cal.GenerateDayPanel(42,flDays);
            cal.DisplayCurrentDate(evn.AllEvents, lblMonthAndYear);
            metroTabControl1.SelectedIndex = 0;

            // --- Date pre-load
            tbDateRequest.Text = dateTimePicker1.Value.ToString("dd/MM/yyyy");

            // --- Announcements Tab --- 
            ann.GetAllAnnouncements();

            // --- Chat App ---
            chat.Refresh_Messages();
            chat.Refresh_Users();
            DataBasePlayground.UpdateStatus(true, user_Name);
        }
        // delegate void
        private void SetUser(string name, string rFname, string rLname, string room, string stat)
        {
            user_Name = name;
            user_FirstName = rFname;
            user_LastName = rLname;
            user_Status = stat; 

            lbFname.Text = rFname;
            lbLname.Text = rLname;
            lbRoom.Text = room;
        }
        // ---Main Form Index Refresher ---
        private void metroTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroTabControl1.SelectedIndex == 0) // -- calendar
            {
                evn.GetAllEvents();
                cal.GenerateDayPanel(42, flDays);
                cal.DisplayCurrentDate(evn.AllEvents, lblMonthAndYear);
                timer1.Stop();
            }
            else if (metroTabControl1.SelectedIndex == 3) // -- announcements
            {
                ExpDateChecker();
                StatusChecker();
                ann.GetAllAnnouncements();
                listboxAnn.DataSource = null;
                listboxAnn.DataSource = ann.AllAnnouncements;
                listboxAnn.DisplayMember = "ListBoxTxt";
                timer1.Stop();

            }
            else if(metroTabControl1.SelectedIndex == 4)
            {
                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }
        }
        //---------------------------------------------------------------------

        // --- Calendar Tab ---
        private void btnPrevMonth_Click(object sender, EventArgs e)
        {
            cal.PrevMonth(evn.AllEvents, lblMonthAndYear);
        }

        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            cal.NextMonth(evn.AllEvents, lblMonthAndYear);
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            cal.Today(evn.AllEvents, lblMonthAndYear);
        }
        //-------------------------------------------------------------------------------------------


        // --- Make a Request Tab ---
        private void trackBarHour_Scroll(object sender, EventArgs e)
        {
            hours = trackBarHour.Value;
            tbTimeRequest.Text = hours.ToString("00") + ":" + minutes.ToString("00");
        }

        private void trackBarMin_Scroll(object sender, EventArgs e)
        {
            minutes = trackBarMin.Value;
            tbTimeRequest.Text = hours.ToString("00") + ":" + minutes.ToString("00");
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
                    DataBasePlayground.AddRequest(DataBasePlayground.GetID("requestsCopy"), user_Name, topic, date, time, place, des);
                    Clean_Request_Tab();
                    MessageBox.Show("The request has been sent!");
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
                    DataBasePlayground.AddReport(DataBasePlayground.GetID("reportsCopy"), user_Name, clean_Facilities, troubles_Tenant, garbage_Dispolsal, unnanounced_Parties, Other, clean_FacilitiesTxt, troubles_TenantTxt, garbage_DispolsalTxt, unnanounced_PartiesTxt, OtherTxt, date);
                    Clean_Complain_Tab();
                    MessageBox.Show("The complain has been sent!");
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
        // -- Exparation checkers
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
                i++;
            }
        }

        // --- LiveChat ---
        private void btnSendMessageChat_Click(object sender, EventArgs e)
        {
            if(rtbxMesaageChat.Text == "")
            {
                MessageBox.Show("Cannot send a hollow message!");
            }
            else if(rtbxMesaageChat.Text.Contains("'"))
            {
                MessageBox.Show("Message cannot contain (') character!");
            }
            else
            {
                DataBasePlayground.SendMessage(user_FirstName, DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture), DateTime.Now.ToString("hh:mm", CultureInfo.InvariantCulture), rtbxMesaageChat.Text, user_Status);
                UpdateMessages();
                rtbxMesaageChat.Text = "";
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateActiveUsers();
            UpdateMessages();
        }


        // -- funct
        private void UpdateActiveUsers()
        {
            chat.Refresh_Users();
            lbxActiveUsers.DataSource = null;
            lbxActiveUsers.DataSource = chat.active_Users;
            lbxActiveUsers.DisplayMember = "ActiveUser";
        }
        private void UpdateMessages()
        {
            chat.Refresh_Messages();
            
            string newWindow = "";
            foreach(LiveChat m in chat.messages)
            {
                newWindow += m.u_Name_Sender + ": " + m.message_Txt + '\n';
                //if(m.message_Txt.Length <= 60)
                //{

                //}
                //else
                //{
                //    string final_string = "";
                //    int intervals = m.message_Txt.Length / 60;
                //    for(int i = 0; i<intervals; i++)
                //    {

                //    }
                //}

            }
            rtbM.Text = "";
            rtbM.Text = newWindow;
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(close)
            {
                DataBasePlayground.UpdateStatus(false, user_Name);
                Application.Exit();
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            LogIn log = new LogIn();
            log.Show();
            close = false;
            // -- 
            this.Dispose();

        }

      

        /*private void BtnSendMessageChat_Click(object sender, EventArgs e)
        {
            if (rtbxMesaageChat.Text != null && (rbtnStudent.Checked || rbtnAdmin.Checked))
            {
                MessageBox.Show("The message is sent.");
            }
            else
            {
                MessageBox.Show("Something is missing!");
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            ds.Clear();//clear data first
            da.Fill(ds);//fill new data
        }*/

    }
}
