using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MKCollege
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["MKConnectDatabase"].ConnectionString;
                    SqlConnection connection = new SqlConnection(connectionString);
                    SqlCommand command = new SqlCommand("SELECT * FROM Users", connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet data = new DataSet();
                    adapter.Fill(data);
                    GridView1.DataSource = data;
                    GridView1.DataBind();
                }
            }

    }
}