using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.CodeDom;

namespace MKCollege
{
    public partial class Search : System.Web.UI.Page
    {
        private const string COURSESPAGENAME = "coursePage.aspx";

        public string outputText;
        protected void Page_Load(object sender, EventArgs e)
        {
            outputText = "Note: Delimit skill search with comma, max 3 skills.";
        }

        public void runSearch(object sender, EventArgs e)
        {
            //Initialise ouput text.
            outputText = "";

            //Initialise other properties.
            string qstring;
            SqlCommand myCommand;
            SqlDataReader myReader;

            // Pull data from form.
            string searchText = Request.Form["searchText"].ToLower();
            string searchType = Request.Form["searchType"];

            strip_spaces(ref searchText);

            // Connect to DB.
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = @"Data Source=mkconnect.database.windows.net;Initial Catalog=MKConnect;User ID=MKConnect;Password=Connectmk3";
            conn.Open();


            // Branch based off of searchType.
            switch (searchType)
            {
                case "Mentors":

                    //Write query for getting Mentors.
                    qstring = "SELECT FirstName + ' ' + LastName AS Name, Email FROM Users WHERE IsMentor = 1";

                    //Conditionally search by first name, last or email.
                    add_search(ref qstring, searchText, @"AND (LOWER(FirstName) LIKE '%" + searchText + "%' OR LOWER(LastName) LIKE '%" + searchText + "%' OR LOWER(Email) LIKE '%" + searchText +"%')");

                    //Ex. query.
                    myCommand = new SqlCommand(qstring, conn);
                    myReader = myCommand.ExecuteReader();

                    if (myReader.HasRows)
                    {
                        //Output table start, with header and style def.
                        outputText = @"<table style=""width: 100%; table-layout: fixed;"">
                                    <col width = ""20%"" />
                                    <col width = ""80%"" />
                                    <tr>
                                        <th>Mentor Name</th>
                                        <th>Email</th>
                                    </tr>";

                        //Output items from query.
                        while (myReader.Read())
                        {
                            outputText += @"<tr><td>" + myReader["Name"].ToString() + @"</td>";
                            outputText += @"<td>" + myReader["Email"].ToString() + @"</td></tr>";
                        }

                        //End Table. 
                        outputText += @"</table>";
                    }
                    else
                    {
                        outputText = "No results.";
                    }

                    break;

                case "Courses By Name":
                case "Courses By Skill":
                    //Query courses table, getting specified fields.
                    //courseName, Description, skilltags, mentor, length and availability.
                    qstring = @"SELECT courseName, Description, ISNULL(skillTag_1, ' ') AS Skill1, ISNULL(skillTag_2, ' ') AS Skill2, ISNULL(skillTag_3, ' ') AS Skill3, Mentor, Length, Availability FROM Courses";

                    if (searchType.Equals("Courses By Name"))
                    {
                        //Courses by name: conditionally search by name.
                        add_search(ref qstring, searchText, "WHERE LOWER(courseName) LIKE '%" + searchText + "%'");
                    }
                    else
                    {
                        //Search by Skill.
                        
                        //Get array of search items delim by ','
                        string[] search_item_arr = searchText.Split(new char[] { ',' });

                        //There are three cases: 1 skill input by user, 2 or 3.

                        //1 Item
                        add_search_courses_sk(ref qstring, search_item_arr[0], true);

                        //1+
                        if (search_item_arr.Length > 1)
                        {
                            //2 Items
                            add_search_courses_sk(ref qstring, search_item_arr[1], false, true);

                            //3 Items
                            if (search_item_arr.Length > 2)
                            {
                                add_search_courses_sk(ref qstring, search_item_arr[2], false, true);
                            }
                        }

                    }
                    
                    //Ex. query.
                    myCommand = new SqlCommand(qstring, conn);
                    myReader = myCommand.ExecuteReader();

                    if (myReader.HasRows)
                    {
                        //Output table start.
                        outputText = @"<table style=""width: 100%; table-layout: fixed; font-size:smaller;"">
                                    <tr>
                                        <th>Course Title</th>
                                        <th>Description</th>
                                        <th>Skills</th>
                                        <th>Mentor</th>
                                        <th>Length</th>
                                        <th>Availability</th>
                                    </tr>";

                        //Populate table from resultset.
                        while (myReader.Read())
                        {
                            outputText += @"<tr>";

                            String[] skills = { "Skill1", "Skill2", "Skill3" };
                            String[] fields = { "courseName", "Description", skills[0], skills[1], skills[2], "Mentor", "Length", "Availability" };



                            foreach (string field in fields)
                            {
                                //TODO: Use switch... case... instead of convulted if else below.
                                
                                //When displaying skills, we will concat. them with ', ' delimiting.
                                if (skills.Contains(field))
                                {
                                    if (field == skills[2])
                                    {
                                        add_skills( ref outputText, myReader, skills);
                                    }
                                    
                                }
                                else
                                {
                                    if ( field == fields[0]) //courseName
                                    {
                                        add_coursename(ref outputText, myReader[field].ToString());
                                    }
                                    else
                                    {
                                        outputText += @"<td>" + myReader[field].ToString() + @"</td>";
                                    }
                                    
                                }
                            }

                            outputText += @"</tr>";
                        }

                        //End Table. 
                        outputText += @"</table>";
                    }
                    else
                    {
                        outputText = "No results.";
                    }

                    break;
            }

            

        }

        //Helper methods.

        //Add condition to query when user has entered search text..
        private void add_search( ref string query_string, string search_text, string condition)
        {
            query_string += !search_text.Equals("") ? " " + condition: "";
        }

        //Search by skills conditionally added to query when user has entered search text.
        private void add_search_courses_sk( ref string query_string, string search_text, bool isWhere = false, bool isAnd = false)
        {   
            if (isWhere && isAnd)
            {
                throw new Exception("add_search_courses_sk cannot take both WHERE and AND requirement!");
            }
            else if (isWhere)
            {
                add_search(ref query_string, search_text, "WHERE");
            }
            else if (isAnd)
            {
                add_search(ref query_string, search_text, "AND");
            }

            add_search(ref query_string, search_text, "( LOWER(skillTag_1) LIKE '%" + search_text + "%' OR LOWER(skillTag_2) LIKE '%" + search_text + "%' OR LOWER(skillTag_3) = '%" + search_text + "%' )");
            

        }

        public void strip_spaces( ref string text )
        {
            text = text.Replace(" ", "");
        }

        private void add_skills(ref string outputHere, SqlDataReader theReader, string[] fields)
        {
            List<string> outputList = new List<string>();
            string outputSkills = "";

            foreach (string field in fields)
            {
                outputList.Add(theReader[field].ToString().Replace(" ", ""));
            }


            foreach (string field in fields)
            {
                if (theReader[field].ToString().Replace(" ", "") != "")
                {
                    if (outputSkills == "")
                    {
                        outputSkills += theReader[field].ToString().Replace(" ", "");
                    }
                    else
                    {
                        outputSkills += ", " + theReader[field].ToString().Replace(" ", "");
                    }


                }

            }

            outputHere += @"<td>" + outputSkills + @"</td>";
        }

        //Give output for coursename with link to course page.
        private void add_coursename( ref string outputThis, string courseName)
        {   
            outputThis += @"<td><a href=";

            outputThis += "\"" + COURSESPAGENAME + "?courseName=" + courseName + "\"";

            outputThis += @" >" + courseName + @"</a></td>";
        }

    }
}