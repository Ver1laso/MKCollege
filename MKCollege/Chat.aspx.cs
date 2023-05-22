using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MKCollege
{
    public partial class Chat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
    public class ChatHub : Hub
    {
        public void SendMessage(string message)
        {
            string user = Context.User.Identity.Name; // Get the currently authenticated user
            Clients.All.receiveMessage(user, message);
        }
    }
}