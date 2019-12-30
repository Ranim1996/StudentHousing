using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Administration_App.Classes; 

namespace Adminstration_App
{
    public partial class Form1 : Form
    {
        //instance of the class that contains all of the people
        Person ps = new Person();

        //creds
        private string uname;
        private string urfname;
        private string urlname;
        private string status;

        //delegates
        public delegate void AccessTransfer(string name, string rFname, string rLname, string room);
        public static event AccessTransfer InformationPass;


        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ps.GetAllPeople();
        }

        // -- indicator if the form is properly accessed
        private bool AccessGranted = false;


        private void BtnLogIn_Click(object sender, EventArgs e)
        {
            string name = tbxUserName.Text;
            string pass = Sequrity.Hashing(tbxPassword.Text); // -- All passwords in the Database are hashed
            bool usr_found = false;

            foreach (Person person in ps.AllPeople)
            {
                if (person.u_Name == name)
                {
                    usr_found = true;

                    if (person.u_Pass == pass)
                    {
                        AccessGranted = true;
                        uname = person.u_Name;
                        urfname = person.uFirst_Name;
                        urlname = person.uLast_Name;
                        status = person.u_Status;
                        break;
                    }
                    MessageBox.Show("Wrong Password!");
                    break;
                }
            }

            if (!usr_found)
            {
                MessageBox.Show("User has not been found!");
            }

            // -- here is the access point
            if (AccessGranted)
            {
                Form1 form = new Form1();
                InformationPass(uname, urfname, urlname, status);
                form.Show();
                this.Close();
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!AccessGranted)
            {
                Application.Exit();
            }

        }
    }
}
