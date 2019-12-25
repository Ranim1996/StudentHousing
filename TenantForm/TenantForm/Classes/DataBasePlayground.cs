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
        public void AddPerson(string uname, string upass, string fname, string lname, string status, string room)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConStr("loginsDB")))
            {
                connection.Execute($"INSERT INTO logins (u_Name, u_Pass, uFirst_Name, uLast_Name, u_Status, u_Room) VALUES ({ uname }, { upass }, { fname }, { lname }, { status }, { room });");
            }
        }

        public void DeletePerson(string uname)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConStr("loginsDB")))
            {
                connection.Execute($"DELETE FROM logins WHERE u_Name='{ uname }';");
            }
        }

        public void UpdatePerson(string old_uname, int id, string uname, string upass, string fname, string lname, string status, string room)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConStr("loginsDB")))
            {
                connection.Execute($"UPDATE logins SET u_Name = { uname }, u_Pass = { upass }, uFirst_Name = { fname }, uLast_Name = { lname }, u_Status = { status }, u_Room = { room } WHERE u_Name = { old_uname };");
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
        public static void AddRequest(string name, string topic, string date, string time, string place, string des)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConStr("loginsDB")))
            {
                connection.Execute($"INSERT INTO requests (pWSR, Topic, Date, Time, Place, Description, Status) VALUES ('{ name }', '{ topic }', '{ date }', '{ time }', '{ place }', '{ des }', 'ToBeRead');");
            }
        }
        public static void UpdateRequest(int id, string status)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConStr("loginsDB")))
            {
                connection.Execute($"UPDATE requests SET Status = '{ status }' WHERE ID = '{ id }';)");
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
        public static void AddReport(string pwsr, int cleanF, int trbT, int grbD, int unanP, int oth, string cleanFT, string trbTT, string grbDT, string unanPT, string othT, string date)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConStr("loginsDB")))
            {
                connection.Execute($"INSERT INTO reports (pWSR, cleanFacilities ,troublesWithTenant, garbageDisposal, unnanouncedParties, other, cleanFacilitiesTxt ,troublesWithTenantTxt, garbageDisposalTxt, unnanouncedPartiesTxt, otherTxt, Status, Date) VALUES ('{ pwsr }' , { cleanF } , { trbT } , { grbD } , { unanP } , { oth } , '{ cleanFT }' , '{ trbTT }' , '{ grbDT }' , '{ unanPT }' , '{ othT }', 'ToBeRead', '{ date }');");
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
                connection.Execute($"DELETE FROM announcements WHERE ID = '{ id }'");
            }
        }
        //--------------------------------------------------------------------------

        // --- Functions ---
        private static string ConStr(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        // -- if we want to make a lil update we can use that but its just a refrence
        // -- also this will only used in the copy database

        public int GetID(string databC)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConStr("loginsDB")))
            {
                return connection.ExecuteScalar<int>($"SELECT COUNT(*) FROM { databC };");
            }
        }


    }
}
