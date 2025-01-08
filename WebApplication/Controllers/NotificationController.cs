using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notification.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Notification.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController : ControllerBase
    {
        private static System.Timers.Timer aTimer;
        private static List<Models.Notification> inMemoryNotifications = new List<Models.Notification>();

        [HttpPost]
        public void GetListOfNotification(List<Models.Notification> notificationItems)
        {
            foreach(Models.Notification item in notificationItems)
            {
                inMemoryNotifications.Add(item);
            }

        }

        //[HttpGet]
        public ActionResult<string> GetNotifications()
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("data: [");

            foreach (Models.Notification item in inMemoryNotifications)
            {
                sb.Append(JsonSerializer.Serialize(item));
                sb.Append(",");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append("]");
            sb.Append("\n\n");

            return Content(sb.ToString(), "text/event-stream");

        }

        [HttpGet]
        public async Task Get()
        {
            var response = Response;
            response.Headers.Add("Content-Type", "text/event-stream");
            response.Headers.Add("Access-Control-Allow-Origin", "*");

            while(true)
            {
                if(inMemoryNotifications.Count > 0 )
                {
                    foreach (Models.Notification item in inMemoryNotifications)
                    {
                        string dataToBeSent = JsonSerializer.Serialize(item);

                        await response.WriteAsync($"data: {dataToBeSent}\r\r");
                        response.Body.Flush();
                        await Task.Delay(5 * 1000);
                    }
                    inMemoryNotifications.Clear();
                }
                else
                {
                    await response.WriteAsync($"data: wait\r\r");
                    response.Body.Flush();
                    await Task.Delay(5 * 1000);
                }
                
            }

        }
    }

}
