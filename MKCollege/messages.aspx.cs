using System;
using System.Collections.Generic;
using System.Data.SqlClient; // For working with SQL Server
using System.Configuration; // For accessing the connection string
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MKCollege
{
    public class Message
    {
        public int ID { get; set; }
        public int SenderID { get; set; }
        public int ReceiverID { get; set; }
        public string MessageText { get; set; }
        public DateTime SentDate { get; set; }
    }

    public partial class messages : System.Web.UI.Page
    {
        protected string connectionString = ConfigurationManager.ConnectionStrings["mkconnect.database.windows.net"].ConnectionString;
        protected DropDownList ddlUsers;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Fetch the initial 10 messages from the database
            List<Message> messages = GetMessageHistoryByPage(1, 10);

            // Bind the messages to a repeater or any other control to display them in the UI
            messageRepeater.DataSource = messages;
            messageRepeater.DataBind();

            int page = 1; // Declare and assign a default value for 'page'

            if (!IsPostBack)
            {
                if (Request.QueryString["page"] != null)
                {
                    page = Convert.ToInt32(Request.QueryString["page"]);
                }

                // Fetch the messages based on the page number
                messages = GetMessageHistoryByPage(page, 10);

                // Bind the messages to a repeater or any other control to display them in the UI
                messageRepeater.DataSource = messages;
                messageRepeater.DataBind();
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            // Get the sender and receiver IDs
            int senderID = GetLoggedInUserID();
            int receiverID = GetReceiverUserID();

            // Get the message text from the input field
            string messageText = txtMessage.Text;

            // Save the message to the database
            SaveMessage(senderID, receiverID, messageText);

            // Clear the input field
            txtMessage.Text = string.Empty;

            // Refresh the UI to display the new message
            int page = 1; // Display the first page
            List<Message> messages = GetMessageHistoryByPage(page, 10);
            messageRepeater.DataSource = messages;
            messageRepeater.DataBind();
        }

        private List<Message> GetMessageHistoryByPage(int page, int pageSize)
        {
            // Calculate the start index of messages based on the page number and page size
            int startIndex = (page - 1) * pageSize;

            // Implement your logic to retrieve the message history for a specific page from the database
            // You can modify the SQL query to fetch the messages based on the startIndex and pageSize

            List<Message> messages = new List<Message>();

            // Example code using ADO.NET
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM (SELECT ROW_NUMBER() OVER (ORDER BY SentDate DESC) AS RowNum, * FROM Messages) AS T " +
                               "WHERE RowNum > @StartIndex AND RowNum <= @EndIndex";

                int endIndex = startIndex + pageSize;

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StartIndex", startIndex);
                    command.Parameters.AddWithValue("@EndIndex", endIndex);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Message message = new Message
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                SenderID = Convert.ToInt32(reader["SenderID"]),
                                ReceiverID = Convert.ToInt32(reader["ReceiverID"]),
                                MessageText = reader["MessageText"].ToString(),
                                SentDate = Convert.ToDateTime(reader["SentDate"])
                            };

                            messages.Add(message);
                        }
                    }
                }
            }

            return messages;
        }

        private void SaveMessage(int senderID, int receiverID, string messageText)
        {
            // Implement your logic to save the message to the database
            // You can use ADO.NET, an ORM (Object-Relational Mapping) framework like Entity Framework,
            // or any other data access approach based on your project setup and requirements.

            // Example code using ADO.NET

            // Establish a database connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // SQL query to insert the message into the database
                string query = "INSERT INTO Messages (SenderID, ReceiverID, MessageText, SentDate) " +
                               "VALUES (@SenderID, @ReceiverID, @MessageText, @SentDate)";

                // Create a SqlCommand object
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@SenderID", senderID);
                    command.Parameters.AddWithValue("@ReceiverID", receiverID);
                    command.Parameters.AddWithValue("@MessageText", messageText);
                    command.Parameters.AddWithValue("@SentDate", DateTime.Now);

                    // Execute the query
                    command.ExecuteNonQuery();
                }
            }
        }

        private int GetLoggedInUserID()
        {
            // Implement your logic to retrieve the logged-in user ID
            // This can vary depending on your authentication mechanism (e.g., Forms Authentication, Identity, etc.)

            // Example code
            int userID = 0;

            // Retrieve the user ID from the current session or any other authentication context
            if (Session["UserID"] != null)
            {
                userID = Convert.ToInt32(Session["UserID"]);
            }

            return userID;
        }

        private int GetReceiverUserID()
        {
            // Implement your logic to retrieve the receiver user ID
            // This can vary based on how you identify the receiver (e.g., username, selected user, etc.)

            // Example code
            int receiverID = 0;

            // Retrieve the receiver ID based on your specific logic
            // For example, if you have a dropdown list of users and the receiver is selected:
            if (ddlUsers.SelectedValue != null)
            {
                receiverID = Convert.ToInt32(ddlUsers.SelectedValue);
            }

            return receiverID;
        }
    }
}
