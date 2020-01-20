using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using TenantForm.Classes;

namespace TenantForm
{
    public partial class LogIn : Form
    {
        //instance of the class that contains all of the people
        Person ps = new Person();

        //creds
        private string uname;
        private string urfname;
        private string urlname;
        private string room;
        private string stat;

        //delegates
        public delegate void AccessTransfer(string name, string rFname, string rLname, string room, string stat);
        public static event AccessTransfer InformationPass;

        public LogIn()
        {
            InitializeComponent();
        }
        private void LogIn_Load(object sender, EventArgs e)
        {
            ps.GetAllPeople();
        }

        // -- indicator if the form is properly accessed
        private bool AccessGranted = false;

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string pass = Sequrity.Hashing(textBox2.Text); // -- All passwords in the Database are hashed
            bool usr_found = false;
          
            foreach(Person person in ps.AllPeople)
            {
                if(person.u_Name == name)
                {
                    usr_found = true;

                    if(person.u_Pass == pass)
                    {
                        AccessGranted = true;
                        uname = person.u_Name;
                        urfname = person.uFirst_Name;
                        urlname = person.uLast_Name;
                        room = person.u_Room;
                        stat = person.u_Status;
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
                InformationPass(uname, urfname, urlname, room, stat);
                form.Show();
                this.Close();
            }
           
        }
        private void LogIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!AccessGranted)
            {
                Application.Exit();
            }
        }
    }
}
