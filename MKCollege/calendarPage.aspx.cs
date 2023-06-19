using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.Page;

namespace MKCollege
{
    public partial class calenderPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod]
        public static string GetEvents()
        {
            // Replace this with your own logic to fetch events from the database or any other source
            var events = new List<CalendarEvent>();

            // Add sample events for demonstration
            events.Add(new CalendarEvent
            {
                title = "Event 1",
                start = new DateTime(2023, 5, 24),
                end = new DateTime(2023, 5, 25)
            });

            events.Add(new CalendarEvent
            {
                title = "Event 2",
                start = new DateTime(2023, 5, 31),
                end = new DateTime(2023, 6, 7)
            });

            var jsonSerializer = new JavaScriptSerializer();
            var json = jsonSerializer.Serialize(events);

            return json;
        }

        public class CalendarEvent
        {
            public string title { get; set; }
            public DateTime start { get; set; }
            public DateTime end { get; set; }
        }
    }
}