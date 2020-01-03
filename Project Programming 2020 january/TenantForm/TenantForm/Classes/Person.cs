using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TenantForm.Classes
{
    public class Person
    {
        public int ID { get; private set; }
        public string u_Name { get; private set; }
        public string u_Pass { get; private set; }
        public string uFirst_Name { get; private set; }
        public string uLast_Name { get; private set; }
        public string u_Status { get; private set; }
        public string u_Room { get; private set; }


        public List<Person> AllPeople
        {
            get;
            private set;
        }
        public void GetAllPeople()
        {
            try
            {
                AllPeople = DataBasePlayground.GetAllPeople();
            }
            catch
            {
                MessageBox.Show("Connection to the server wasn't possible!");
                AllPeople = new List<Person>();
            }
        }
        //https://stackoverflow.com/questions/14171794/how-to-retrieve-data-from-a-sql-server-database-in-c ---> ako si ebe maikata koda
    }
}
