﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Microsoft.AspNet.SignalR;

namespace MKCollege
{
    public class chat:Hub
    {

        public void Send(string name, string message) 
        {
            Clients.All.sendMessage(name, message);
        }



    }
}