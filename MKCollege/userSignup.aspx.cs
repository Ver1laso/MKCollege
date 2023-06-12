using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace MKCollege
{
    public partial class userSignup : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["MKConnectDatabase"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            Button1.Click += new EventHandler(this.SignUpBtn_Click);
        }

        // Sign up button click event
        void SignUpBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Users(FirstName, LastName, Email, DOB, IsMentor) VALUES (@FirstName, @LastName, @Email, @DOB, @IsMentor); SELECT SCOPE_IDENTITY();", con);
                    cmd.Parameters.AddWithValue("@FirstName", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@LastName", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", TextBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@DOB", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@IsMentor", false);

                    int insertedUserId = Convert.ToInt32(cmd.ExecuteScalar());

                    HttpCookie IdCookie = new HttpCookie("Id");
                    IdCookie.Value = insertedUserId.ToString();
                    Response.Cookies.Add(IdCookie);

                    Response.Write("<script>alert('Sign Up Successful.');</script>");
                    Response.Redirect("userProfile.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}
