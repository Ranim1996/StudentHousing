using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace TenantForm.Classes
{
    public class Calendar
    {
        //list with dates and thir info
        public List<FlowLayoutPanel> listFlDay { get; private set; }

        //current date
        private DateTime currentDate = DateTime.Today;

        public Calendar()
        {
            listFlDay = new List<FlowLayoutPanel>();

        }

        // -- functions --
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

        // -- methods --
        //used in the buttons
        public void PrevMonth(List<Event> ls)
        {
            currentDate = currentDate.AddMonths(-1);
            DisplayCurrentDate(ls);
        }
        public void NextMonth(List<Event> ls)
        {
            currentDate = currentDate.AddMonths(1);
            DisplayCurrentDate(ls);
        }
        public void Today(List<Event> ls)
        {
            currentDate = DateTime.Today;
            DisplayCurrentDate(ls);
        }
        public void DisplayCurrentDate(List<Event> list)
        { 
            //lblMonthAndYear.Text = currentDate.ToString("MMMM, yyyy");
            int firstDayAtFlNumber = GetFirstDayOfWeekOfCurrentDate();
            int totalDay = GetTotalDaysOfCurrentDate();
            AddLabelDayToFlDay(firstDayAtFlNumber, totalDay, list);

            //when the database will work with this form, call the function below
            // AddAppointmentToFlDay(firstDayAtFlNumber);
        }
        // -- MAIN methods --
        public void GenerateDayPanel(int totalDays,FlowLayoutPanel flDays)
        {
            flDays.Controls.Clear();
            listFlDay.Clear();
            for (int i = 1; i <= totalDays; i++)
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

        // -- modified part
        public void AddLabelDayToFlDay(int startDayAtFlNumber, int totalDaysInMonth, List<Event> events)
        {
            //needs to be adjusted ---> WORK IN PROGGRESS
            string[] date = DateTime.Now.ToString("dd/MM/yyyy").Split('/');

            foreach (FlowLayoutPanel fl in listFlDay)
            {
                fl.Controls.Clear();
                fl.Tag = 0;
                fl.BackColor = Color.White;
            }
            for (int i = 1; i <= totalDaysInMonth; i++)
            {
                string topic = "";
                string time = "";
                string info = "";// -- experimental

                // -- label date
                Label lbl = new Label();
                lbl.Name = $"lblDay{i}";
                lbl.AutoSize = false;
                lbl.TextAlign = ContentAlignment.MiddleRight;
                lbl.Size = new Size(120, 23);
                lbl.Text = i.ToString();
                lbl.Font = new Font("Arial", 10);

                // -- beta -- modified part
                List<Event> listForTheDay = new List<Event>();

                foreach (Event evnts in events)
                {
                    string[] dateEvent = evnts.Date.Split('/');

                    if((dateEvent[2] == date[2]) && (dateEvent[1] == date[1]) && (Convert.ToInt32(dateEvent[0]) == i))
                    {
                        listForTheDay.Add(evnts);
                    }   
                }

                // constructor
                // -- modified part ---> topic and event info
                int y = 0;
                foreach(Event eOfDay in listForTheDay)
                {
                    Label lblInfo = new Label();
                    lblInfo.Name = $"lblInfo{i}{y}";
                    lblInfo.AutoSize = false;
                    lblInfo.TextAlign = ContentAlignment.MiddleCenter;
                    lblInfo.Size = new Size(120, 23);
                    lblInfo.Text = $"{eOfDay.Time}     {eOfDay.Topic}"; // topic
                    lblInfo.Font = new Font("Arial", 10);
                    listFlDay[(i - 1) + (startDayAtFlNumber - 1)].Tag = i;
                    listFlDay[(i - 1) + (startDayAtFlNumber - 1)].Controls.Add(lblInfo);
                    y++;
                }
                
                

                //change the color of today
                if (new DateTime(currentDate.Year, currentDate.Month, i) == DateTime.Today)
                {
                    listFlDay[(i - 1) + (startDayAtFlNumber - 1)].BackColor = Color.Bisque;
                }

            }
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

      
    }
}
