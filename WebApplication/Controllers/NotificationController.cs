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

        //public List<Models.Notification> GetListOfNotification()
        [HttpPost]
        public void GetListOfNotification(List<Models.Notification> notificationItems)
        {
            //Models.Notification notification = new Models.Notification();

            //notification.summary = "UCA Proxy service is down.";
            //notification.description = "The UCA Proxy service is down, hence Oceana operations may fail.";
            //notification.severity = 0;

            //inMemoryNotifications.Add(notification);


            //notification = new Models.Notification();

            //notification.summary = "CPU Utilization is 97%.";
            //notification.description = "High CPU Utilization. Please shutdown the server.";
            //notification.severity = 1;

            //inMemoryNotifications.Add(notification);

            //notification = new Models.Notification();

            //notification.summary = "License expiration is within 27 days.";
            //notification.description = "Renew your license within 27 days to continue using our services.";
            //notification.severity = 1;

            //inMemoryNotifications.Add(notification);

            //notification.summary = notificationItem.summary;
            //notification.description = notificationItem.description;
            //notification.severity = notificationItem.severity;

            foreach(Models.Notification item in notificationItems)
            {
                inMemoryNotifications.Add(item);
            }
            

            //return inMemoryNotifications;

        }

        //[HttpGet]
        public ActionResult<string> GetNotifications()
        {

            //List<Models.Notification> listOfNotifications = GetListOfNotification();

            StringBuilder sb = new StringBuilder();

            sb.Append("data: [");

            //foreach (Models.Notification item in listOfNotifications)
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
            //var response = Response;
            //response.Headers.Add("Content-Type", "text/event-stream");
            //response.Headers.Add("access-control-allow-origin", "*");

            //Models.Notification obj = new Models.Notification();

            //obj.summary = "UCA Proxy service is down.";
            //obj.description = "The UCA Proxy service is down, hence Oceana operations may fail.";
            //obj.severity = 1;

            //string dataToBeSent = JsonSerializer.Serialize(obj);

            //await response.WriteAsync($"data: {dataToBeSent}\r\r");

            //response.Body.Flush();
            //await Task.Delay(10 * 1000);

            //obj.summary = "CPU Utilization is 97%.";
            //obj.description = "High CPU Utilization. Please shutdown the server.";
            //obj.severity = 0;

            //dataToBeSent = JsonSerializer.Serialize(obj);

            //await response.WriteAsync($"data: {dataToBeSent}\r\r");

            //response.Body.Flush();
            //await Task.Delay(10 * 1000);

            //obj.summary = "License expiration is within 27 days.";
            //obj.description = "Renew your license within 27 days to continue using our services.";
            //obj.severity = 1;

            //dataToBeSent = JsonSerializer.Serialize(obj);

            //await response.WriteAsync($"data: {dataToBeSent}\r\r");

            //response.Body.Flush();

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