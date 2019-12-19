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
        public LogIn()
        {
            InitializeComponent();
        }

        Person ps = new Person();

        private void LogIn_Load(object sender, EventArgs e)
        {
            ps.GetAllPeople();
            
        }

        // -- list containing all the people --- it is in the isntance of the class 
        //private List<Person> people;

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
