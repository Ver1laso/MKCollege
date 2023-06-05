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

    public partial class userSignup : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["MKConnectDatabase"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        // sign up button click event
        protected void Button1_Click(object sender, EventArgs e)
        {
            {
                signUpNewMember();
            }
        }

        // user defined method
        void signUpNewMember()
        {
            //Response.Write("<script>alert('Testing');</script>");
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO Users(FirstName, LastName, Email, DOB, IsMentor) Values(@FirstName, @LastName, @Email, @DOB, @IsMentor)", con);
                cmd.Parameters.AddWithValue("@FirstName", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@LastName", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@DOB", TextBox3.Text);
                cmd.Parameters.AddWithValue("@IsMentor", false);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}