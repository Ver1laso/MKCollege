﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MKCollege
{
    public partial class messages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve messages from the database
                List<Message> messages = GetMessageList();

                // Bind the messages to the repeater control
                messageRepeater.DataSource = messages;
                messageRepeater.DataBind();
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string fromUser = "Your fromUser value"; // Replace with the actual value
            string toUser = "Your toUser value"; // Replace with the actual value
            string subject = Request.Form["txtSubject"];
            string message = Request.Form["txtMessage"];

            // Create a new message object
            Message newMessage = new Message(fromUser, toUser, subject, message);

            // Save the message to the database
            SaveMessage(newMessage);

            // Redirect to the message listing page
            Response.Redirect("messages.aspx");
        }

        private List<Message> GetMessageList()
        {
            List<Message> messages = new List<Message>();

            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT SenderID, Subject, ReceivedDate FROM Messages";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string fromUser = reader.GetString(0);
                            string subject = reader.GetString(1);
                            DateTime receivedDate = reader.GetDateTime(2);

                            Message message = new Message(fromUser, subject, receivedDate);
                            messages.Add(message);
                        }
                    }
                }
            }

            return messages;
        }

        private void SaveMessage(Message message)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mkconnect.database.windows.net"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Messages (SenderID, RecipientID, MessageText, sentDate) " +
                               "VALUES (@FromUser, @ToUser, @Subject, @Content, @SentDate)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FromUser", message.SenderID);
                    command.Parameters.AddWithValue("@ToUser", message.RecipientID);
                    command.Parameters.AddWithValue("@Subject", message.Subject);
                    command.Parameters.AddWithValue("@Content", message.MessageText);
                    command.Parameters.AddWithValue("@SentDate", message.sentDate);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}