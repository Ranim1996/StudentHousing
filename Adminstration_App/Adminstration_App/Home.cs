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

        public Home()
        {
            InitializeComponent();
        }

        private void MbtnLogOut_Click(object sender, EventArgs e)
        {
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
            if (string.IsNullOrWhiteSpace(tbxPublishAnouncement.Text))
            {
                MessageBox.Show("Enter the content of the event first!");
            }
            else
            {
                MessageBox.Show("Request is sent succesfully.");
                tbxPublishAnouncement.Text = "";
            }
        }
    }
}
