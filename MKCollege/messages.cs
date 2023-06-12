using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MKCollege
{
    public class Message
    {
        public string SenderID { get; set; }
        public string RecipientID { get; set; }
        public string Subject { get; set; }
        public string MessageText { get; set; }
        public DateTime sentDate { get; set; }

        public Message(string fromUser, string toUser, string subject, string content)
        {
            SenderID = fromUser;
            RecipientID = toUser;
            Subject = subject;
            MessageText = content;
            sentDate = DateTime.Now;
        }
    }
}