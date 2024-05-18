using System.Collections.Generic;

namespace Notification.Models
{
    public class Notification
    {
        public string summary { get; set; }
        public string description { get; set; }
        public int severity { get; set; }
    }

    public class EventData
    {
        public List<Models.Notification> data { get; set; }
    }
}