using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Fcm
{
    public class FCMPushNotification
    {
        public FCMPushNotification()
        {
            SERVER_API_KEY = "AAAApX7oWLA:APA91bGnogQP371gZ-e1n5Ib07yD8m-yB0AQRGTm1GlGTtYTp5RbWFoCSS0XHV0haey0PTjOEKxB8iBD6-W2R3sj4HS6xHiFTpHqCuKW7Q5uIvyF_j37rXY6-Smia8Tzdj4cSBD28Tc9";
        }
        string SERVER_API_KEY = "";
        //
        string SENDER_ID = "710798760112";
        //string SENDER_ID = "AIzaSyAuztXRsa-quJErb_xFwiFdPWY8rHlB2rM";
        //

        public string SendMessage2()
        {
            //string serverKey = "Your Server key";

                var result = "-1";
                var webAddr = "https://fcm.googleapis.com/fcm/send";

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Headers.Add("Authorization:key=" + SERVER_API_KEY);
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\"to\": \""+ SERVER_API_KEY +"\",\"data\": {\"message\": \"This is a Firebase Cloud Messaging Topic Message!\",}}";
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }

                 return result;
            
        }
        public string SendNotificationFromFirebaseCloud3()
        {
            var result = "-1";
            var webAddr = "https://fcm.googleapis.com/fcm/send";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Headers.Add("Authorization:key=" + SERVER_API_KEY);
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"to\": \"/topics/news\",\"notification\": {\"body\": \"New news added in application!\",\"title\":\"" + "هدر" + "\",}}";
                streamWriter.Write(json);
                streamWriter.Flush();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }

        public string SendNotificationFromFirebaseCloud4()
        {
            var result = "-1";
            var webAddr = "https://fcm.googleapis.com/fcm/send";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, "key="+SERVER_API_KEY);
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string strNJson = @"{
                    ""to"": ""/topics/ServiceNow"",
                    ""data"": {
                        ""ShortDesc"": ""This is sample"",
                        ""IncidentNo"": ""INC0010438"",
                        ""Description"": ""This is sample""
  },
  ""notification"": {
                ""title"": ""ServiceNow"",
    ""text"": ""Click me to open an Activity!"",
""sound"":""default""
  }
        }";
                streamWriter.Write(strNJson);
                streamWriter.Flush();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }

        public string SendNotification()
        {
            //SERVER_API_KEY = "BJku9945yLXHOKLKT28zvv3W_s65QGwexD6FiBJme4nrHqvnbFjwt1T1_bHaI6qDHSoTelpctYhd4jidpAW-P4s";
            //var value = message;
            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "post";
            //serverKey - Key from Firebase cloud messaging server  
            tRequest.Headers.Add(string.Format("Authorization:key={0}", SERVER_API_KEY));
            //Sender Id - From firebase project setting  
            tRequest.Headers.Add(string.Format("Sender:id={0}", SENDER_ID));
            tRequest.ContentType = "application/json";
            var payload = new
            {
                to = "eDz9rn-hhaM:APA91bERzuBsTr8lAXVCB8Com0I7Es6RV5L-VvGJlo7_6o9UzVDef3KwUyqjkL7f_5yHBKm4IGAaPvGIqTPHPKgR4Qodd4dfe39le7N-BTUVt_mSvjzMp4XMM8a1TFjWt4CsfHqXEBDa",
                // مقدار توکن پس از اینیشالایز
                //priority = "high",
                //content_available = true,
                notification = new
                {
                    body = "این متن نمونه است amin rostami",
                    title = "درخواست از Fcm",
                    badge = 1
                },
                data = new
                {
                    stock = "GOOG",
                    open = "829.62",
                    close = "635.67"
                }
            };
            //var payload = new
            //{
            //    token = SERVER_API_KEY,
            //    data = new
            //    {
            //        Nick = "Mario",
            //        body = "great match!",
            //        Room = "PortugalVSDenmark"
            //    }
            //};

            string postbody = JsonConvert.SerializeObject(payload).ToString();
            Byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
            tRequest.ContentLength = byteArray.Length;
            using (Stream dataStream = tRequest.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
                using (WebResponse tResponse = tRequest.GetResponse())
                {
                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
                    {
                        if (dataStreamResponse != null) using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                string sResponseFromServer = tReader.ReadToEnd();
                                return sResponseFromServer;
                                //result.Response = sResponseFromServer;
                            }
                    }
                }
            }
            return "";
        }


        public string SendNotification2()
        {
            //SERVER_API_KEY = "BJku9945yLXHOKLKT28zvv3W_s65QGwexD6FiBJme4nrHqvnbFjwt1T1_bHaI6qDHSoTelpctYhd4jidpAW-P4s";
            //var value = message;
            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "post";
            //serverKey - Key from Firebase cloud messaging server  
            tRequest.Headers.Add(string.Format("Authorization:key={0}", SERVER_API_KEY));
            //Sender Id - From firebase project setting  
            tRequest.Headers.Add(string.Format("Sender:id={0}", SENDER_ID));
            tRequest.ContentType = "application/json";
            var payload = new
            {
                to = SERVER_API_KEY,
                //priority = "high",
                //content_available = true,
                notification = new
                {
                    body = "این متن نمونه است",
                    title = "Test",
                    badge = 1
                },
                data = new
                {
                    stock = "GOOG",
                    open = "829.62",
                    close = "635.67"
                }
            };
            //var payload = new
            //{
            //    token = SERVER_API_KEY,
            //    data = new
            //    {
            //        Nick = "Mario",
            //        body = "great match!",
            //        Room = "PortugalVSDenmark"
            //    }
            //};

            string postbody = JsonConvert.SerializeObject(payload).ToString();
            Byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
            tRequest.ContentLength = byteArray.Length;
            using (Stream dataStream = tRequest.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
                using (WebResponse tResponse = tRequest.GetResponse())
                {
                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
                    {
                        if (dataStreamResponse != null) using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                string sResponseFromServer = tReader.ReadToEnd();
                                return sResponseFromServer;
                                //result.Response = sResponseFromServer;
                            }
                    }
                }
            }
            return "";
        }

        public async Task<string> NotifyAsync()
        {
            // Get the server key from FCM console
            var serverKey = string.Format("key={0}", SERVER_API_KEY);

            // Get the sender id from FCM console
            var senderId = string.Format("id={0}", SENDER_ID);

            serverKey = SERVER_API_KEY;
            senderId = SENDER_ID;

            var data = new
            {
                to = "GpQm/Cjx893zOTaKz1fgYPY+5iNt7qzuA+r/aIIQR4pcLh08CiusxEqGMKSz1Nd+WcT4/JQ2bZGQoNyLMe+zGQ==", // Recipient device token
                //111416461746004401948
                //                             100327861111783830931
                notification = new { title = "هدر", body = "تست" }
            };
            //var data = new
            //{
            //    Nick = "Mario",
            //    body = "great match!",
            //    Room = "PortugalVSDenmark"
            //};

            // Using Newtonsoft.Json
            var jsonBody = JsonConvert.SerializeObject(data);

            using (var httpRequest = new HttpRequestMessage(HttpMethod.Post, "https://fcm.googleapis.com/fcm/send"))
            {
                httpRequest.Headers.TryAddWithoutValidation("Authorization", serverKey);
                httpRequest.Headers.TryAddWithoutValidation("Sender", senderId);
                httpRequest.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                using (var httpClient = new HttpClient())
                {
                    var result = await httpClient.SendAsync(httpRequest);

                    return await result.Content.ReadAsStringAsync();
                    //if (result.IsSuccessStatusCode)
                    //{
                    //}
                }
            }
            return false.ToString();
        }
    }
}
