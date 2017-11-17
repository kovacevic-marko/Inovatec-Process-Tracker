using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using IPTDataAccess;
using System.IO;
using System.Configuration;

namespace IPTCommon
{
    public static class WebCommunication
    {
        public static int GetStatusCode(string URL)
        {
            int statusCode = -1;

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(URL);
                var response = (HttpWebResponse)request.GetResponse();
                statusCode = (int)response.StatusCode;
            }
            catch (WebException)
            {
                statusCode = -1;
            }
            catch (Exception)
            {
                statusCode = -2;
            }

            return statusCode;
        }


        public static string GetApplicationInfo(string appId)
        {
            string app = null;
            try
            {
                string user = ConfigurationManager.AppSettings["Username"];
                string pass = ConfigurationManager.AppSettings["Password"];
                string url = ConfigurationManager.AppSettings["url"];
                string URL = "http://172.24.2.51:" + appId;
                var request = (HttpWebRequest)WebRequest.Create(URL);
               // request.Credentials = new NetworkCredential(user, pass);
                var response = (HttpWebResponse)request.GetResponse();                
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    app = reader.ReadToEnd();                    
                }

            }
            catch (WebException)
            {
                app = "webException uhvacen";
            }
            catch (Exception)
            {
                //app = "Neki drugi exception";
                throw;
            }
            return app;
        }

        public static void SendEmail(MailMessage mailMessage, EmailNotification notification)
        {
            SmtpClient smtpClient = new SmtpClient();

            Task task = Task.Factory.StartNew(() =>
            {
                mailMessage.From = new MailAddress("iptservicespraksa@gmail.com");
                mailMessage.Subject = "Servis promena statusa obavestenje";


                smtpClient.Send(mailMessage);
                using (IPTDBEntities entities = new IPTDBEntities())
                {
                    entities.EmailNotifications.Attach(notification);
                    notification.IsSent = true;
                    notification.SentOn = DateTime.Now;
                    entities.SaveChanges();
                }

            }
            );

        }
    }
}
