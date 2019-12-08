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
        private List<Person> ppl;
       
        public Form1()
        {
            InitializeComponent();
            //test ---> WORKING
            //DataBasePlayground db = new DataBasePlayground();
            //ppl = db.GetAllPeople();
            //MessageBox.Show(ppl[0].u_Name);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateDayPanel(42);
            DisplayCurrentDate();
        }
        
        /*
        //function for adding the event from the database to the specific day
        private void AddAppointmentToFlDay(int startDayAtFlNumber)
        {
            DateTime startDate = new DateTime(currentDate.Year, currentDate.Month, 1);

            //the sql information
            String sql = $"SELECT * FROM ... WHERE ... #{startDate.ToShortDateString()}# ";

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
    }
}
