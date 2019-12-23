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

//* tables --->UNKOWN FOR NOW

// this file is at stage beta 1.0 
namespace TenantForm.Classes
{
    
    public class DataBasePlayground
    {
        
        // --- LOGINS ---
        //MAIN ---> funct
        public static List<Person> GetAllPeople() // -- list containing all people registered
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
                //connection.Execute($"INSERT INTO loginsCopy VALUES ({ id }, { uname }, { upass }, { fname }, { lname });");
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
                //connection.Execute($"UPDATE loginsCopy SET ID = { id }, u_Name = { uname }, u_Pass = { upass }, uFirst_Name = { fname }, uLast_Name = { lname } WHERE u_Name = { old_uname };");
            }
        }
        // ------------------------------------------------------------------------------------------------------






        // --- REQUESTS/EVENTS ---
        // --- MAIN ---> func
        public static List<Event> GetAllRequests()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConStr("loginsDB")))
            {
                return connection.Query<Event>($"SELECT * FROM requests;").ToList();
            }
        }
        // --- MAIN ---> meth
        public static void AddRequest(int id, string name, string topic, string date, string time, string place, string des)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConStr("loginsDB")))
            {
                connection.Execute($"INSERT INTO requests VALUES ({ id }, '{ name }', '{ topic }', '{ date }', '{ time }', '{ place }', '{ des }', 'ToBeRead');");
                //connection.Execute($"INSERT INTO loginsCopy VALUES ({ id }, { uname }, { upass }, { fname }, { lname });");
            }
        }
        //-------------------------------------------------------

        // --- REPORTS ---
        // --- MAIN ---
        public static List<Report> GetAllReports ()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConStr("loginsDB")))
            {
                return connection.Query<Report>($"SELECT * FROM reports;").ToList();
            }
        }
        public static void AddReport(int id, string pwsr, int cleanF, int trbT, int grbD, int unanP, int oth, string cleanFT, string trbTT, string grbDT, string unanPT, string othT, string date)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConStr("loginsDB")))
            {
                connection.Execute($"INSERT INTO reports VALUES ({ id } , '{ pwsr }' , { cleanF } , { trbT } , { grbD } , { unanP } , { oth } , '{ cleanFT }' , '{ trbTT }' , '{ grbDT }' , '{ unanPT }' , '{ othT }', 'ToBeRead', '{ date }');");
                // copy
                //(ID, pWSRequest, cleanFacilities, troublesWithTenant, garbageDisposal, unnanouncedParties, other, cleanFacilitiesTxt, troublesWithTenantTxt, garbageDispolsalTxt, unnanouncedPartiesTxt, otherTxt)

            }
        }
        //---------------------------------------------------------------

        // --- ANNOUNCEMETNS ---
        // --- MAIN ---
        public static List<Announcements> GetAllAnnouncements()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConStr("loginsDB")))
            {
                return connection.Query<Announcements>($"SELECT * FROM announcements;").ToList();
            }
        }
        public static void ExpirationRemover(int id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConStr("loginsDB")))
            {
                connection.Execute($"DELETE what you want(which is expired)");
            }
        }
        //--------------------------------------------------------------------------

        // --- Functions ---
        private static string ConStr(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }


       
    }
}
