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
        private List<FlowLayoutPanel> listFlDay = new List<FlowLayoutPanel>();
        
        private DateTime currentDate = DateTime.Today;
        //private List<Person> ppl;

        private int hours = 0;
        private int minutes = 0;

        //the list with announcemets is in this instance
        Announcements ann = new Announcements();


        public Form1()
        {
            InitializeComponent();
            //test ---> WORKING
            //DataBasePlayground db = new DataBasePlayground();
            //ppl = db.GetAllPeople();
            //MessageBox.Show(ppl[0].u_Name);
            //DateTime appDay = DateTime.Parse(row("AppDate"));
            //LinkLabel link = new LinkLabel();
            //DataRow
            // ---> UNNCECESSARY 
            //LogIn ls = new LogIn();
            //ls.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateDayPanel(42);
            DisplayCurrentDate();
            tbDateRequest.Text = dateTimePicker1.Value.ToString("dd/MM/yyyy");

            // --- Announcements Tab ---
            // when the data base is ready
            //ann.GetAllAnnouncements();
        }
        
        /*
        //function for adding the event from the database to the specific day
        private void AddAppointmentToFlDay(int startDayAtFlNumber)
        {
            //-------

            //the date of today is stored in the startDate variable and after that, with the sql variable it searches in the database
            //for the startDate variable 
            DateTime startDate = new DateTime(currentDate.Year, currentDate.Month, 1);
            String sql = $"SELECT * FROM ... WHERE ... #{startDate.ToShortDateString()}# ";

            //---------
            //the connection with the dataBase
            // the function from the database form is called

             DataTable dt = QueryAsDataTable(sql);


            //Display the events in the right day 
            foreach(DataRow row in dt.Rows)
            {
                DateTime appDay = DateTime.Parse(row("AppDate"));
                LinkLabel link = new LinkLabel();
                link.Name = $"link{row("ID")}";
                link.Text = row("Task");
                listFlDay[ (appDay.Day - 1) + (startDayAtFlNumber - 1)].Controls.Add(link);
            }
        }
        */

        // -------- Function which has to be used in the database form ------//
        /*
         * 
         * public DataTable QueryAsDataTable(String sql)
         * {
         *      OleDbDataAdapter(sql, cn)  da;
         *      DataSet ds;
         *      da.Fill(ds, "result");
         *      return ds.Tables("result");    
         * }
         */

        private int GetFirstDayOfWeekOfCurrentDate()
        {
            DateTime firstDayOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
            return Convert.ToInt32(firstDayOfMonth.DayOfWeek + 1);
        }

        private int GetTotalDaysOfCurrentDate()
        {
            DateTime firstDayOfCurrentDate = new DateTime(currentDate.Year, currentDate.Month, 1);
            return firstDayOfCurrentDate.AddMonths(1).AddDays(-1).Day;
        }
        
        private void DisplayCurrentDate()
        {
            lblMonthAndYear.Text = currentDate.ToString("MMMM, yyyy");
            int firstDayAtFlNumber = GetFirstDayOfWeekOfCurrentDate();
            int totalDay = GetTotalDaysOfCurrentDate();
            AddLabelDayToFlDay(firstDayAtFlNumber, totalDay);

            //when the database will work with this form, call the function below
            // AddAppointmentToFlDay(firstDayAtFlNumber);
        }

        private void PrevMonth()
        {
            currentDate = currentDate.AddMonths(-1);
            DisplayCurrentDate();
        }
        private void NextMonth()
        {
            currentDate = currentDate.AddMonths(1);
            DisplayCurrentDate();
        }

        private void GenerateDayPanel(int totalDays)
        {
            flDays.Controls.Clear();
            listFlDay.Clear();
            for(int i = 1; i <= totalDays; i++)
            {
                FlowLayoutPanel fl = new FlowLayoutPanel();
                fl.Name = $"flDay{i}";
                fl.Size = new Size(130, 90);
                fl.BackColor = Color.White;
                fl.BorderStyle = BorderStyle.FixedSingle;
                fl.AutoScroll = true;
                flDays.Controls.Add(fl);
                listFlDay.Add(fl);
            }
        }

        private void Today()
        {
            currentDate = DateTime.Today;
            DisplayCurrentDate();
        }

        private void AddLabelDayToFlDay(int startDayAtFlNumber, int totalDaysInMonth)
        {
            foreach(FlowLayoutPanel fl in listFlDay)
            {
                fl.Controls.Clear();
                fl.Tag = 0;
                fl.BackColor = Color.White;
            }
            for(int i = 1; i <= totalDaysInMonth; i++)
            {
                Label lbl = new Label();
                lbl.Name = $"lblDay{i}";
                lbl.AutoSize = false;
                lbl.TextAlign = ContentAlignment.MiddleRight;
                lbl.Size = new Size(120, 23);
                lbl.Text = i.ToString();
                lbl.Font = new Font("Arial", 10);
                listFlDay[(i - 1) + (startDayAtFlNumber - 1)].Tag = i;
                listFlDay[ (i - 1) + (startDayAtFlNumber - 1) ].Controls.Add(lbl);

                //change the color of today
                if(new DateTime(currentDate.Year, currentDate.Month, i) == DateTime.Today)
                {
                    listFlDay[(i - 1) + (startDayAtFlNumber - 1)].BackColor = Color.Bisque;
                }

            }
        }

        private void btnPrevMonth_Click(object sender, EventArgs e)
        {
            PrevMonth();
        }

        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            NextMonth();
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            Today();
        }



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
