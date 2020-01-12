using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fcm.Models;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using FirebaseAdmin.Messaging;

namespace Fcm.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            //var ress = FirebaseApp.Create(new AppOptions()
            //{
            //    Credential = GoogleCredential.FromFile(@"C:\Users\Admin\Desktop\testfirebase.json")
            //});
            ////var dd = GoogleCredential.FromFile(@"C:\Users\Admin\Desktop\testfirebase.json");
            //var registrationToken = "AAAApX7oWLA:APA91bGnogQP371gZ-e1n5Ib07yD8m-yB0AQRGTm1GlGTtYTp5RbWFoCSS0XHV0haey0PTjOEKxB8iBD6-W2R3sj4HS6xHiFTpHqCuKW7Q5uIvyF_j37rXY6-Smia8Tzdj4cSBD28Tc9";
            //var message = new Message()
            //{
            //    Data = new Dictionary<string, string>()
            //    {
            //        { "score", "850" },
            //        { "time", "2:45" },
            //    },
            //    Token = "",
            //    Notification = new Notification()
            //    {
                    
            //    },
            //    //Webpush = new WebpushConfig()
            //    //{
            //    //    Notification = new WebpushNotification() { },
            //    //}
            //};
            //string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);

            try
            {
                var res = new FCMPushNotification().SendNotification();
                return Json(res);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        public async Task<IActionResult> Index1()
        {
            try
            {
                var res = await new FCMPushNotification().NotifyAsync();
                return Json(res);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
