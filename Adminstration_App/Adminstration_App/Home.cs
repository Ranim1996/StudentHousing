using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Administration_App.Classes;

namespace Adminstration_App
{
    public partial class Home : Form
    {
        //credentials for the guy using the form
        private string user_Name;
        private string user_FirstName;
        private string user_LastName;

        //wild card
        bool close = true;

        //the list with announcemets is in this instance
        Announcements ann = new Announcements();
        Announcements objAnn; // used as a variable in the announcements tab
        //holds the calendar
        Administration_App.Classes.Calendar cal = new Administration_App.Classes.Calendar();
        //holds the events
        Event evn = new Event();
        Event objEvent; // -- holds a selected information
        private List<Event> ToBeReadEvents = new List<Event>(); // -- here are only events that are still in a request queue
        //holds the complains
        Report rep = new Report();
        Report objRep; // used as a variable in the complain tab


        //variables for time managment
        private int hours = 0;
        private int minutes = 0;


        // -- DateTimePicker for calendar --
        //DateTimePicker dateTimePicker1 = new DateTimePicker();


        public Home()
        {
            //delegate subscribtion
            Form1.InformationPass += SetUser;

            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            // --- Calendar Tab ---
            evn.GetAllEvents(); // -- Events (exclusively for admin settings builds up another list)
            cal.GenerateDayPanel(42, flowPanel);
            cal.DisplayCurrentDate(evn.AllEvents, lblMonthAndYear);

            // --- Complains Tab ---
            rep.GetAllReports();
            DisplayResetComplains();

            // --- Requests Tab --- // -- Events
            DisplayRefreshRequests();
            

            // --- Announcements Tab ---
            ann.GetAllAnnouncements();
            DisplayRefreshAnn();

        }
        //delegate void
        private void SetUser(string name, string rFname, string rLname, string room)
        {
            user_Name = name;
            user_FirstName = rFname;
            user_LastName = rLname;

            lbFName.Text = rFname;
            lbLName.Text = rLname;
            lbStatus.Text = room;
        }



        // --- Schedule Tab ---
        private void BtnPrev_Click(object sender, EventArgs e)
        {
            cal.PrevMonth(evn.AllEvents, lblMonthAndYear);
        }

        private void BtnToday_Click(object sender, EventArgs e)
        {
            cal.Today(evn.AllEvents, lblMonthAndYear);
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            cal.NextMonth(evn.AllEvents, lblMonthAndYear); ;
        }
        //--------------------
        // --- Create an Event Tab ---
        // -- Buttons
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        // -- Scrolls
        private void trackH_Scroll(object sender, EventArgs e)
        {
            hours = trackH.Value;
            UpdateTime();
        }
        private void trackM_Scroll(object sender, EventArgs e)
        {
            minutes = trackM.Value;
            UpdateTime();
        }
        //--funct
        private void UpdateTime()
        {
            tbTimeEvent.Text = hours.ToString("00") + ":" + minutes.ToString("00"); 
        }
        //--------------------------
        // --- View Complains Tab ---
        // --- Selection Changing ---> General workflow of the application
        // -- Main Listbox
        private void lbxComplains_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lbxComplains.SelectedIndex != -1)
            {
                comboComplains.Items.Clear();
                objRep = lbxComplains.SelectedItem as Report; // easier to be presented as an object for me
                
                // -- constructor -- comment(sadly there arent any enums for strings and i dont wanna make another class)
                if(objRep.cleanFacilities == 1)
                {
                    comboComplains.Items.Add("Cleaning");
                }
                if (objRep.troublesWithTenant == 1)
                {
                    comboComplains.Items.Add("Tenant Issues");
                }
                if (objRep.garbageDisposal == 1)
                {
                    comboComplains.Items.Add("Garbage Issues");
                }
                if (objRep.unannouncedParties == 1)
                {
                    comboComplains.Items.Add("Noise Issues");
                }
                if (objRep.other == 1)
                {
                    comboComplains.Items.Add("Other");
                }

                //some restrictions
                panelHeaderInfo.Visible = true;
                panelCoreInfo.Visible = false;
            }
            else
            {
                panelHeaderInfo.Visible = false;
            }
        }
        // -- Combo Box (Sub Menu)
        private void comboComplains_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboComplains.SelectedItem.ToString() == "Cleaning")
            {
                lbTopic.Text = "Cleaning";
                rtbDes.Text = objRep.cleanFacilitiesTxt;
                panelCoreInfo.Visible = true;
            }
            else if (comboComplains.SelectedItem.ToString() == "Tenant Issues")
            {
                lbTopic.Text = "Tenant Issues";
                rtbDes.Text = objRep.troublesWithTenantTxt;
                panelCoreInfo.Visible = true;
            }
            else if (comboComplains.SelectedItem.ToString() == "Garbage Issues")
            {
                lbTopic.Text = "Garbage Issues";
                rtbDes.Text = objRep.garbageDisposalTxt;
                panelCoreInfo.Visible = true;
            }
            else if (comboComplains.SelectedItem.ToString() == "Noise Issues")
            {
                lbTopic.Text = "Noise Issues";
                rtbDes.Text = objRep.unannouncedPartiesTxt;
                panelCoreInfo.Visible = true;
            }
            else if (comboComplains.SelectedItem.ToString() == "Other")
            {
                lbTopic.Text = "Other";
                rtbDes.Text = objRep.otherTxt;
                panelCoreInfo.Visible = true;
            }
            else
            {
                panelCoreInfo.Visible = false;
            }
        }
        // -- Buttons
        private void btChecked_Click(object sender, EventArgs e)
        {
            DataBasePlayground.DeleteRequest(objRep.ID);
            rep.GetAllReports();
            DisplayResetComplains();
            // --  dont think its needed to clean the field
        }
        // -- funct
        private void DisplayResetComplains()
        {
            lbxComplains.DataSource = null;
            lbxComplains.DataSource = rep.AllReports;
            lbxComplains.DisplayMember = "ListBoxTxt";
        }
        //-----------------------------------------
        // --- Request Tab ---
        // -- Main Listbox
        private void lbxRequestedEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lbxRequestedEvent.SelectedIndex != -1)
            {
                objEvent = lbxRequestedEvent.SelectedItem as Event;

                lbTopicEvent.Text = objEvent.Topic;
                lbpWSR.Text = objEvent.pWSR;
                lbDate_TimeEvent.Text = $"{objEvent.Date}  At  {objEvent.Time}";
                lbPlaceEvent.Text = objEvent.Place;
                rtbEvent.Text = objEvent.Description;

                panelREvent.Visible = true;
            }
            else
            {
                panelREvent.Visible = false;
            }
        }
        // -- Buttons
        private void BtnAccept_Click(object sender, EventArgs e)
        {
            DataBasePlayground.UpdateReport(objEvent.ID, "Approved");
            evn.GetAllEvents();
            DisplayRefreshRequests();
        }
        private void BtnReject_Click(object sender, EventArgs e)
        {
            DataBasePlayground.DeleteRequest(objEvent.ID);
            evn.GetAllEvents();
            DisplayRefreshRequests();
        }
        //--funct
        private void DisplayRefreshRequests()
        {
            lbxRequestedEvent.DataSource = null;
            lbxRequestedEvent.DataSource = ToBeReadEvents;
            lbxRequestedEvent.DisplayMember = "ListBoxTxt";
        }
        //----------------------------------------------
        // --- Announcements Tab ---
        // -- Make Announcements Part
        private void BtnPublish_Click(object sender, EventArgs e)
        {
            if(tbTopicAnn.Text == "" || rtbDesAnn.Text == "")
            {
                MessageBox.Show("The form is incomplete!");
            }
            else
            {
                if(DateChecker(DateTime.Now, dateTimePickerE.Value))
                {
                    DataBasePlayground.AddAnnouncement(user_Name, tbTopicAnn.Text, rtbDesAnn.Text, dateTimePickerA.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture), dateTimePickerE.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture), "Active");
                    DisplayRefreshAnn();
                }
                else
                {
                    MessageBox.Show("You cannot have an expiration date earlier than today!");
                }
            }
        }
        // -- View Made Announcements Part
        private void lbxAnouncement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lbxAnouncement.SelectedIndex != -1)
            {
                objAnn = lbxAnouncement.SelectedItem as Announcements;

                lbTopicAnn.Text = objAnn.Topic;
                lbpWSRAnn.Text = objAnn.pWSA;
                lbDateA.Text = objAnn.DateA;
                lbDateE.Text = objAnn.DateE;
                rtbAnnDes.Text = objAnn.Text;
            }
            else
            {
                pAnnDes.Visible = false;
            }
        }
        private void BtnDeleteAnoun_Click(object sender, EventArgs e) // -- NOT WORKING PROP
        {
            DataBasePlayground.DeleteRequest(objAnn.ID);
            DisplayRefreshAnn();
        }
        //--funct
        private bool DateChecker(DateTime date1, DateTime date2) // -- NEEDS TO BE FIXED (NOT WORKING)
        {
            if (date1.Year <= date2.Year)
            {
                if(date1.Month <= date2.Month)
                {
                    if(date1.Day <= date2.Day)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private void DisplayRefreshAnn()
        {
            lbxAnouncement.DataSource = null;
            lbxAnouncement.DataSource = ann.AllAnnouncements;
            lbxAnouncement.DisplayMember = "ListBoxTxt";
        }
        //-------------------------------------------------------------
        private void MbtnLogOut_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Dispose();
        }
        // ------------UKNOWN


        private void BtnAssign_Click(object sender, EventArgs e)
        {
            
            //if (string.IsNullOrWhiteSpace(tbxDate.Text) || string.IsNullOrWhiteSpace(tbxAssignTask.Text)
            //    || string.IsNullOrWhiteSpace(tbxStudentName.Text))
            //{
            //    MessageBox.Show("Please enter the data first! ");
            //}

            //else
            //{
            //    string date = Convert.ToString(tbxDate.Text);
            //    string task = Convert.ToString(tbxAssignTask.Text);

            //    int dateExists = ((Tasks.Concat(Tasks)).ToList()).IndexOf(date);
            //    int taskExists = ((Tasks.Concat(Tasks)).ToList()).IndexOf(task);

            //    if (dateExists == -1 || taskExists == -1)
            //    {

            //        foreach (Control c in this.Controls)
            //        {
            //            if (c is TextBox)
            //            {
            //                Tasks.Add((c as TextBox).Text);
            //            }
            //        }
            //        MessageBox.Show("The Task was assigned succesfully. ");
            //        tbxAssignTask.Text = "";
            //        tbxDate.Text = "";
            //        tbxStudentName.Text = "";
            //    }

            //    else
            //    {
            //        MessageBox.Show("The task you entered already exists!");
            //    }
            //}
               
        }
        //---------------------------------------------------------------------
        //---------------UNKNOWN
        

       

       

        

        

        private void BtnAddTime_Click(object sender, EventArgs e)
        {
            
        }

        













        //---------------------------------------------------------------------------------


    }
}
