using IPTDataAccess;
using System;
using System.Linq;
using System.Net;
using System.Timers;
using System.Xml.Linq;

namespace IPTSakupljac
{
    class Sakupljanje
    {
        private int interval;
        private Timer timer;
        private IPTDBEntities entities;

        public Sakupljanje(int interval = 10000)
        {
            this.interval = interval;
            Init();
        }

        private void Init()
        {
            timer = new Timer(interval);
            entities = new IPTDBEntities();
            timer.Start();
            timer.Elapsed += ProveraStanjaSvihServisa;
        }
        
        public void ProveraStanjaSvihServisa(object sender, ElapsedEventArgs e)
        {
            foreach (var ClientService in entities.ClientServices.ToList())
            {
            	string error = null;
            	int? statusCode = null;
            	string statusDescription = null;
            	try
            	{
            		var request = (HttpWebRequest)WebRequest.Create(ClientService.URL);
                	var response = (HttpWebResponse)request.GetResponse();
                	statusCode = (int)response.StatusCode;
                	statusDescription = response.StatusDescription;
            	}
            	catch (WebException we)
            	{
            		error = we.Message;
            	}	
                catch (Exception)
                {
                	error = "Nepoznat exception";
                }

                ServiceLog noviLog = new ServiceLog
                {
                	ClientServiceID = ClientService.ID,
                	LogDate = DateTime.Now,
                	StatusCode = statusCode,
                	StatusDescription = statusDescription,
                	Error = error
                };

                if (error != null)
                {
                    entities.ServiceLogs.Add(noviLog);
                	entities.SaveChanges();
                }
            }
        }
    }
}