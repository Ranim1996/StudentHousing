using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adminstration_App
{
    public partial class Home : Form
    {
        List<String> Tasks = new List<string>();
        List<String> Events = new List<string>();
        private List<FlowLayoutPanel> listFlDay = new List<FlowLayoutPanel>();
        private DateTime currentDate = DateTime.Today;

        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            GenerateDayPanel(42);
            DisplayCurrentDate();
        }

        private void GenerateDayPanel(int totalDays)
        {
            flowPanel.Controls.Clear();
            listFlDay.Clear();
            for (int i = 1; i <= totalDays; i++)
            {
                FlowLayoutPanel fl = new FlowLayoutPanel();
                fl.Name = $"flDay{i}";
                fl.Size = new Size(130, 90);
                fl.BackColor = Color.White;
                fl.BorderStyle = BorderStyle.FixedSingle;
                fl.AutoScroll = true;
                flowPanel.Controls.Add(fl);
                listFlDay.Add(fl);
            }
        }

        private void MbtnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void BtnAssign_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(tbxDate.Text) || string.IsNullOrWhiteSpace(tbxAssignTask.Text)
                || string.IsNullOrWhiteSpace(tbxStudentName.Text))
            {
                MessageBox.Show("Please enter the data first! ");
            }

            else
            {
                string date = Convert.ToString(tbxDate.Text);
                string task = Convert.ToString(tbxAssignTask.Text);

                int dateExists = ((Tasks.Concat(Tasks)).ToList()).IndexOf(date);
                int taskExists = ((Tasks.Concat(Tasks)).ToList()).IndexOf(task);

                if (dateExists == -1 || taskExists == -1)
                {

                    foreach (Control c in this.Controls)
                    {
                        if (c is TextBox)
                        {
                            Tasks.Add((c as TextBox).Text);
                        }
                    }
                    MessageBox.Show("The Task was assigned succesfully. ");
                    tbxAssignTask.Text = "";
                    tbxDate.Text = "";
                    tbxStudentName.Text = "";
                }

                else
                {
                    MessageBox.Show("The task you entered already exists!");
                }
            }
               
        }

        private void BtnChooseDate_Click(object sender, EventArgs e)
        {
            tbxDate.Text = monthCalendar1.SelectionStart.ToString();
        }


        private void BtnPlaceanEvent_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxPlaceanEvent.Text) || string.IsNullOrWhiteSpace(tbxDate.Text))
            {
                MessageBox.Show("Enter data first!");
            }
            else
            {
                MessageBox.Show("The event is created succesfully.");
                tbxDate.Text = "";
                tbxPlaceanEvent.Text = "";
            }
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lbxRequestedEvent.Items.ToString()))
            {
                MessageBox.Show("Error!!");
            }
            else
            {
                MessageBox.Show("Do not forget to place it in the schedule.");
                lbxRequestedEvent.Items.Clear();
            }
        }

        private void BtnReject_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lbxRequestedEvent.Items.ToString()))
            {
                MessageBox.Show("Error!!");
            }
            else
            {
                MessageBox.Show("The event is rejected.");
                lbxRequestedEvent.Items.Clear();
            }
        }

        private void BtnPublish_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxPublishAnouncement.Text)
                || string.IsNullOrWhiteSpace(tbxExpireDate.Text))
            {
                MessageBox.Show("Enter the content of the event first!");
            }
            else
            {
                lbxAnouncement.Items.Add(tbxPublishAnouncement.Text + " " + tbxExpireDate.Text);
                MessageBox.Show("Request is sent succesfully.");
                tbxPublishAnouncement.Text = "";
                tbxExpireDate.Text = "";
            }
        }

        private void BtnDeleteAnoun_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(lbxAnouncement);
            selectedItems = lbxAnouncement.SelectedItems;

            if (lbxAnouncement.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                    lbxAnouncement.Items.Remove(selectedItems[i]);
            }
            else
            {
                MessageBox.Show("Select something first!");
            }
        }

        private void BtnAddTime_Click(object sender, EventArgs e)
        {
            DateTime StartDate;
            StartDate = DateTime.Now;
            tbxExpireDate.Text = StartDate.AddDays(trbarExpireDate.Value).ToShortDateString();
        }

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

        private void AddLabelDayToFlDay(int startDayAtFlNumber, int totalDaysInMonth)
        {
            foreach (FlowLayoutPanel fl in listFlDay)
            {
                fl.Controls.Clear();
                fl.Tag = 0;
                fl.BackColor = Color.White;
            }
            for (int i = 1; i <= totalDaysInMonth; i++)
            {
                Label lbl = new Label();
                lbl.Name = $"lblDay{i}";
                lbl.AutoSize = false;
                lbl.TextAlign = ContentAlignment.MiddleRight;
                lbl.Size = new Size(122, 80);
                lbl.Text = i.ToString();
                lbl.Font = new Font("Arial", 10);
                listFlDay[(i - 1) + (startDayAtFlNumber - 1)].Tag = i;
                listFlDay[(i - 1) + (startDayAtFlNumber - 1)].Controls.Add(lbl);

                //change the color of today
                if (new DateTime(currentDate.Year, currentDate.Month, i) == DateTime.Today)
                {
                    listFlDay[(i - 1) + (startDayAtFlNumber - 1)].BackColor = Color.Bisque;
                }

            }
        }

        private void Today()
        {
            currentDate = DateTime.Today;
            DisplayCurrentDate();
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

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            PrevMonth();
        }

        private void BtnToday_Click(object sender, EventArgs e)
        {
            Today();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            NextMonth();
        }
    }
}
