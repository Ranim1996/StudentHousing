using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Dapper; 
using System.Data;

//here is an app config line
// <connectionStrings><add name = "loginsDB" connectionString ="Data Source=###.###.###.###,1433;Network Library=DBMSSOCN;Initial Catalog=projecDataDemo;User ID=YourLogin;Password=yourpass;" />  </connectionStrings>

//connectionstrings for the database
//connectionString ="Server=LAPTOP-MU1CJV5F\SQLEXPRESS,1433;Database=projecDataDemo;User Id=YourLogin;Password=yourpass;"
//connectionString ="Server=mssql.fhict.local;Database=dbi434121;User Id = dbi434121; Password=#;"
//connectionString ="Data Source=192.168.88.253,1433;Network Library=DBMSSOCN;Initial Catalog=projecDataDemo;User ID=YourLogin;Password=yourpass;"

//6 tables --->logins, tasks, reports/their copies

// this file is at stage beta 1.0 
namespace TenantForm.Classes
{
    
    public class DataBasePlayground
    {
        
        // --- LOGINS ---
        //MAIN ---> funct
        public List<Person> GetAllPeople()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConStr("loginsDB")))
            {
                return connection.Query<Person>($"SELECT * FROM logins;").ToList();
            }
        }

        //MAIN ---> meth
        public void AddPerson(int id, string uname, string upass, string fname, string lname)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConStr("loginsDB")))
            {
                connection.Execute($"INSERT INTO logins VALUES ({ id }, { uname }, { upass }, { fname }, { lname });");
                connection.Execute($"INSERT INTO loginsCopy VALUES ({ id }, { uname }, { upass }, { fname }, { lname });");
            }
        }

        public void DeletePerson(string uname)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConStr("loginsDB")))
            {
                connection.Execute($"DELETE FROM logins WHERE u_Name='{ uname }';");
            }
        }

        public void UpdatePerson(string old_uname, int id, string uname, string upass, string fname, string lname)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConStr("loginsDB")))
            {
                connection.Execute($"UPDATE logins SET ID = { id }, u_Name = { uname }, u_Pass = { upass }, uFirst_Name = { fname }, uLast_Name = { lname } WHERE u_Name = { old_uname };");
                connection.Execute($"UPDATE loginsCopy SET ID = { id }, u_Name = { uname }, u_Pass = { upass }, uFirst_Name = { fname }, uLast_Name = { lname } WHERE u_Name = { old_uname };");
            }
        }
        // ------------------------------------------------------------------------------------------------------






        // --- TASKS ---
        // --- MAIN ---> func
        public List<Person> GetAllTasks()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConStr("loginsDB")))
            {
                return connection.Query<Person>($"SELECT * FROM tasks;").ToList();
            }
        }
        // --- MAIN ---> meth
        public void AddTask(int id, string uname, string upass, string fname, string lname)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConStr("loginsDB")))
            {
                connection.Execute($"INSERT INTO logins VALUES ({ id }, { uname }, { upass }, { fname }, { lname });");
                connection.Execute($"INSERT INTO loginsCopy VALUES ({ id }, { uname }, { upass }, { fname }, { lname });");
            }
        }


        //functions
        private string ConStr(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
