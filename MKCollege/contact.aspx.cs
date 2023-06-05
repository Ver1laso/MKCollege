using System;
using System.Net.Mail;
using System.Collections.Generic;
using System.Data.SqlClient; // For working with SQL Server
using System.Configuration; // For accessing the connection string
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MKConnect
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Read user input
            string name = txtName.Text;
            string email = txtEmail.Text;
            string message = txtMessage.Text;

            // Send email
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add("your@email.com"); // Replace with your email address
                mail.Subject = "Contact Form Submission";
                mail.Body = $"Name: {name}\nEmail: {email}\n\nMessage: {message}";

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Send(mail);

                lblMessage.Text = "Your message has been sent.";
                lblMessage.Visible = true;

                // Clear form fields
                txtName.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtMessage.Text = string.Empty;
            }
            catch (Exception ex)
            {
                lblMessage.Text = "An error occurred while sending your message.";
                lblMessage.Visible = true;
            }
        }
    }
}
