using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.EnterpriseServices;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace MKCollege
{
    public partial class coursePage : System.Web.UI.Page
    {
        public string courseName, description, length, capacity, mentor, userID;
        public string[] skill;

        public bool isEnrolled;

        protected void Page_Load(object sender, EventArgs e)
        {
            get_example_course();

            //Get course name from url.
            courseName = Request.Params["courseName"];


            //Initialise other properties.
            string qstring;
            SqlCommand myCommand;
            SqlDataReader myReader;

            // Connect to DB.
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = @"Data Source=mkconnect.database.windows.net;Initial Catalog=MKConnect;User ID=MKConnect;Password=Connectmk3";
            conn.Open(); 

            //query
            qstring = @"SELECT courseName, Description, ISNULL(skillTag_1, ' ') AS Skill1, ISNULL(skillTag_2, ' ') AS Skill2, ISNULL(skillTag_3, ' ') AS Skill3, Mentor, Length, Availability FROM Courses WHERE courseName='" + courseName + "'";

            //Ex. query.
            myCommand = new SqlCommand(qstring, conn);
            myReader = myCommand.ExecuteReader();

            String[] skills = { "Skill1", "Skill2", "Skill3" };
            String[] fields = { "courseName", "Description", skills[0], skills[1], skills[2], "Mentor", "Length", "Availability" };

            while(myReader.Read())
            {
                if (myReader.HasRows)
                {
                    foreach (string field in fields)
                    {
                        switch (field)
                        {
                            case "courseName":
                                courseName = myReader[field].ToString();
                                break;
                            case "Description":
                                description = myReader[field].ToString();
                                break;
                            case "Skill1":
                                skill[0] = make_skill(myReader[field].ToString());
                                break;
                            case "Skill2":
                                skill[1] = make_skill(myReader[field].ToString());
                                break;
                            case "Skill3":
                                skill[2] = make_skill(myReader[field].ToString());
                                break;
                            case "Mentor":
                                mentor = myReader[field].ToString();
                                break;
                            case "Length":
                                length = myReader[field].ToString();
                                break;
                            case "Availability":
                                if (Int32.Parse(  myReader[field].ToString().Replace(" ", "") )>0)
                                {
                                    capacity = myReader[field].ToString();
                                }
                                else
                                {
                                    capacity = "Full";
                                }
                                break;
                        }
                    }

                }
            }

            

            conn.Close();
        }

        private void get_example_course()
        {
            courseName = "Spanish with Jose";
            skill = new string[3];

            skill[0] = @"<label class=""badge rounded-pill bg-warning"">Spanish</label>";
            skill[1] = @"<label class=""badge rounded-pill bg-warning"">Dealing with Jose</label>";
            skill[2] = @"";

            description = "A course where you are taken through the beautiful spanish language, including speaking, listening, reading and writing, in just a few weeks with native speaker and all round nice guy Jose Santana.";
            length = "idk";
            capacity = "10";
            mentor = "Jose P. Santana";

            isEnrolled = false;
        }

        public string make_skill(string label)
        {
            return ( label.Replace(" ", "") != "") ? @"<label class=""badge rounded-pill bg-warning"">" + label + @"</label>" : "";
        }

        public void runEnrol(object sender, EventArgs e)
        {
            //Initialise other properties.
            string qstring;
            SqlCommand myCommand;
            SqlDataReader myReader;

            // Connect to DB.
            SqlConnection conn = new SqlConnection();

            //Course name
            //Get course name from url.
            courseName = Request.Params["courseName"];

            conn.ConnectionString = @"Data Source=mkconnect.database.windows.net;Initial Catalog=MKConnect;User ID=MKConnect;Password=Connectmk3";
            conn.Open();

            //query
            qstring = @"SELECT courseID, Availability, Mentor FROM Courses WHERE courseName='" + courseName + "'";

            //Ex. query.
            myCommand = new SqlCommand(qstring, conn);
            myReader = myCommand.ExecuteReader();
            bool shallEnrol = false;
            userID = "1";
            string courseID;


            while (myReader.Read())
            {
                if (myReader.HasRows)
                {
                    if (Int32.Parse(myReader["availibility"].ToString()) >0)
                    {
                        shallEnrol = true;
                        courseID = myReader["courseID"].ToString();
                    }
                }
            }

            if (shallEnrol)
            {
                //query
                qstring = @"INSERT INTO Enrolled(courseName, Mentor, userID) VALUES( '" + courseName + "', '" + mentor +"', '" + userID + "')";

                //Ex. query.
                myCommand = new SqlCommand(qstring, conn);
                myCommand.ExecuteScalar();
            }

        }

        public void runWithdraw(object sender, EventArgs e)
        {

        }
    }
}