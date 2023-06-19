using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MKCollege
{
    public partial class contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string name = Request.Form["txtName"];
                string email = Request.Form["txtEmail"];
                string subject = Request.Form["txtSubject"];
                string message = Request.Form["txtMessage"];

                // Send email
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("your-email@example.com");
                mail.To.Add("recipient@example.com");
                mail.Subject = subject;
                mail.Body = $"Name: {name}\nEmail: {email}\n\n{message}";

                SmtpClient smtpClient = new SmtpClient("smtp.example.com", 587);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential("your-email@example.com", "your-password");
                smtpClient.EnableSsl = true;

                try
                {
                    smtpClient.Send(mail);
                    Response.Write("<script>alert('Your message has been sent.');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('An error occurred while sending your message.');</script>");
                }
            }
        }
    }
}