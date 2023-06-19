using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MKCollege
{
    public partial class userProfile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["MKConnectDatabase"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string query = "SELECT FirstName, LastName, Email, DOB FROM Users WHERE UserID = @userId"; // Replace with your actual query

                using (SqlConnection connection = new SqlConnection(strcon))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    { var usercookieid = Request.Cookies["Id"].Value;
                        int userIdInt = Int32.Parse(usercookieid);
                        command.Parameters.AddWithValue("@userId", userIdInt); // Replace with your actual parameter value

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            TextBox1.Text = reader["FirstName"].ToString();
                            TextBox3.Text = reader["DOB"].ToString();
                            TextBox8.Text = reader["LastName"].ToString();
                            TextBox5.Text = reader["Email"].ToString();

                        }
                        reader.Close();
                    }
                }
            }
        }
    }
}
     
         
