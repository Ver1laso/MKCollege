using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace MKCollege
{
    public partial class Search : System.Web.UI.Page
    {
        public string outputText;
        protected void Page_Load(object sender, EventArgs e)
        {
            outputText = "No results.";

        }

        public void runSearch(object sender, EventArgs e)
        {
            //Initialise ouput text.
            outputText = "";
            
            // Pull data from form.
            string searchText = Request.Form["searchText"];
            string searchType = Request.Form["searchType"];

            // Connect to DB.
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=C:\USERS\MUHAMMAD.HASAN\SOURCE\REPOS\VER1LASO\MKCOLLEGE\MKCOLLEGE\APP_DATA\SEARCHTEST.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
            conn.Open();

            


            // Branch based off of searchType.
            switch (searchType)
            {
                case "Mentors":

                    string qstring = "SELECT [First Name] + ' ' + [Last Name] AS Name, Email FROM Users WHERE IsMentor = 1";

                    SqlCommand myCommand = new SqlCommand(qstring, conn);
                    SqlDataReader myReader = myCommand.ExecuteReader();

                    outputText = @"<table style=""width: 100%; table-layout: fixed;"">
                                    <col width = ""20%"" />
                                    <col width = ""80%"" />
                                    <tr>
                                        <th>Mentor Name</th>
                                        <th>Email</th>
                                    </tr>";

                    while (myReader.Read())
                    {
                        outputText += @"<tr><td>" + myReader["Name"].ToString() + @"</td>";
                        outputText += @"<td>" + myReader["Email"].ToString() + @"</td></tr>";
                    }

                    break;
                case "Courses":


                    break;
                case "Skills":


                    break;
            }

            //End table.
            outputText += @"</table>";

            

        }
    }
}