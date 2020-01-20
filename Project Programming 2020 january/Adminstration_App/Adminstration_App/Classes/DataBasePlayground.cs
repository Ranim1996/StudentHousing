using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Dapper; 
using System.Data;
using System.Windows.Forms;

//here is an app config line
// <connectionStrings><add name = "loginsDB" connectionString ="Data Source=###.###.###.###,1433;Network Library=DBMSSOCN;Initial Catalog=projecDataDemo;User ID=YourLogin;Password=yourpass;" />  </connectionStrings>

//connectionstrings for the database
//connectionString ="Server=LAPTOP-MU1CJV5F\SQLEXPRESS,1433;Database=projecDataDemo;User Id=YourLogin;Password=yourpass;"
//connectionString ="Server=mssql.fhict.local;Database=dbi434121;User Id = dbi434121; Password=#;"
//connectionString ="Data Source=192.168.88.253,1433;Network Library=DBMSSOCN;Initial Catalog=projecDataDemo;User ID=YourLogin;Password=yourpass;"

//* tables --->UNKOWN FOR NOW

// this file is at stage beta 1.0 
namespace Administration_App.Classes
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
        public void AddPerson(int id, string uname, string upass, string fname, string lname, string status, string room)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConStr("loginsDB")))
            {
                connection.Execute($"INSERT INTO logins (ID, u_Name, u_Pass, uFirst_Name, uLast_Name, u_Status, u_Room) VALUES ({ id } , '{ uname }', '{ upass }', '{ fname }', '{ lname }', '{ status }', '{ room }');");
                connection.Execute($"INSERT INTO Copy (ID, u_Name, u_Pass, uFirst_Name, uLast_Name, u_Status, u_Room) VALUES ({ id } , '{ uname }', '{ upass }', '{ fname }', '{ lname }', '{ status }', '{ room }');");
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
                connection.Execute($"UPDATE loginsCopy SET u_Name = { uname }, u_Pass = { upass }, uFirst_Name = { fname }, uLast_Name = { lname }, u_Status = { status }, u_Room = { room } WHERE u_Name = { old_uname };");
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
                connection.Execute($"INSERT INTO requests (ID, pWSR, Topic, Date, Time, Place, Description, Status) VALUES ({ id } , '{ name }', '{ topic }', '{ date }', '{ time }', '{ place }', '{ des }', 'ToBeRead');");
                connection.Execute($"INSERT INTO requestsCopy (ID, pWSR, Topic, Date, Time, Place, Description, Status) VALUES ({ id } , '{ name }', '{ topic }', '{ date }', '{ time }', '{ place }', '{ des }', 'ToBeRead');");
            }
        }
        // -- admin exclusive
        public static void AddRequestAdmin(int id, string name, string topic, string date, string time, string place, string des)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConStr("loginsDB")))
            {
                connection.Execute($"INSERT INTO requests (ID, pWSR, Topic, Date, Time, Place, Description, Status) VALUES ({ id } , '{ name }', '{ topic }', '{ date }', '{ time }', '{ place }', '{ des }', 'Approved');");
                connection.Execute($"INSERT INTO requestsCopy (ID, pWSR, Topic, Date, Time, Place, Description, Status) VALUES ({ id } , '{ name }', '{ topic }', '{ date }', '{ time }', '{ place }', '{ des }', 'Approved');");
            }
        }
        public static void UpdateRequest(int id, string status)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConStr("loginsDB")))
            {
                connection.Execute($"UPDATE requests SET Status = '{ status }' WHERE ID = '{ id }';");
                connection.Execute($"UPDATE requestsCopy SET Status = '{ status }' WHERE ID = '{ id }';");
            }
        }
        public static void DeleteRequest(int id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConStr("loginsDB")))
            {
                connection.Execute($"DELETE FROM requests WHERE ID='{ id }';");
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
                connection.Execute($"INSERT INTO reports (ID, pWSR, cleanFacilities ,troublesWithTenant, garbageDisposal, unannouncedParties, other, cleanFacilitiesTxt ,troublesWithTenantTxt, garbageDisposalTxt, unannaouncedPartiesTxt, otherTxt, Status, Date) VALUES ({ id } , '{ pwsr }' , { cleanF } , { trbT } , { grbD } , { unanP } , { oth } , '{ cleanFT }' , '{ trbTT }' , '{ grbDT }' , '{ unanPT }' , '{ othT }', 'ToBeRead', '{ date }');");
                connection.Execute($"INSERT INTO reportsCopy ( ID, pWSR, cleanFacilities ,troublesWithTenant, garbageDisposal, unannouncedParties, other, cleanFacilitiesTxt ,troublesWithTenantTxt, garbageDisposalTxt, unannaouncedPartiesTxt, otherTxt, Status, Date) VALUES ({ id } ,'{ pwsr }' , { cleanF } , { trbT } , { grbD } , { unanP } , { oth } , '{ cleanFT }' , '{ trbTT }' , '{ grbDT }' , '{ unanPT }' , '{ othT }', 'ToBeRead', '{ date }');");
            }
        }
        public static void UpdateReport(int id, string status)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConStr("loginsDB")))
            {
                connection.Execute($"UPDATE reports SET Status = '{ status }' WHERE ID = '{ id }';");
                connection.Execute($"UPDATE reportsCopy SET Status = '{ status }' WHERE ID = '{ id }';");
            }
        }
        public static void DeleteReport(int id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConStr("loginsDB")))
            {
                connection.Execute($"DELETE FROM reports WHERE ID='{ id }';");
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
        public static void AddAnnouncement(int id, string user, string topic, string text, string date1, string date2, string status)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConStr("loginsDB")))
            {
                connection.Execute($"INSERT INTO announcements (ID, pWSA, Topic, Text, DateA, DateE, Status) VALUES ({ id } , '{user}', '{ topic }', '{ text }', '{ date1 }', '{ date2 }', '{ status }' );");
                connection.Execute($"INSERT INTO announcementsCopy (ID, pWSA, Topic, Text, DateA, DateE, Status) VALUES ({ id } , '{user}', '{ topic }', '{ text }', '{ date1 }', '{ date2 }', '{ status }' );");
            }
        }
        //--------------------------------------------------------------------------

        // ---  CHAT ROOM TAB ---
        // -- Active Users --
        public static List<LiveChat> Request_Active_Users()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConStr("loginsDB")))
            {
                return connection.Query<LiveChat>($"SELECT u_Name FROM logins WHERE u_Active = 'true';").ToList();
            }
        }
        public static List<LiveChat> Request_Messages(string todaysDate)
        {
            string[] date = todaysDate.Split('/');
            string ystrDay = "";
            if(Convert.ToInt32(date[0]) != 1)
            {
                ystrDay = (Convert.ToInt32(date[0]) - 1).ToString() + "/" + date[1] + "/" + date[2];
            }
            else if(Convert.ToInt32(date[1]) == 1)
            {
                ystrDay = "31/12/" + (Convert.ToInt32(date[2]) - 1).ToString(); 
            }
            else if(Convert.ToInt32(date[1]) == 3 || Convert.ToInt32(date[1]) == 5 || Convert.ToInt32(date[1]) == 7 || Convert.ToInt32(date[1]) == 10 || Convert.ToInt32(date[1]) == 12)
            {
                if (Convert.ToInt32(date[1]) == 3)
                {
                    if(Convert.ToInt32(date[2]) % 4 == 0)
                    {
                        if(Convert.ToInt32(date[2]) != 100)
                        {
                            ystrDay = "29/" + (Convert.ToInt32(date[1]) - 1).ToString() + "/" + date[2];
                        }
                        else if(Convert.ToInt32(date[2]) % 400 == 0)
                        {
                            ystrDay = "29/" + (Convert.ToInt32(date[1]) - 1).ToString() + "/" + date[2];
                        }
                        else
                        {
                            ystrDay = "28/" + (Convert.ToInt32(date[1]) - 1).ToString() + "/" + date[2];
                        }
                    }
                }
                else
                {
                    ystrDay = "30/" + (Convert.ToInt32(date[1]) - 1).ToString() + "/" + date[2];
                }
            }
            
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConStr("loginsDB")))
            {
                return connection.Query<LiveChat>($"SELECT uFirst_Name FROM liveChat WHERE msg_Date IN ('{ todaysDate }', '{ ystrDay }');").ToList();
            }
        }
        //---------------------------------------------------------------------------------------

        // --- Functions ---
        private static string ConStr(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        // -- if we want to make a lil update we can use that but its just a refrence
        // -- also this will only used in the copy database

        public static int GetID(string databC)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConStr("loginsDB")))
            {
                return connection.ExecuteScalar<int>($"SELECT COUNT(*) FROM { databC };") + 1;
            }
        }


    }
}
