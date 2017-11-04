using IPTDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Timers;

namespace IPTSakupljac
{
    class Sakupljanje
    {
        private IPTDBEntities db;
        private int interval;
        private Timer timer;

        public Sakupljanje()
        {
            this.interval = Properties.Settings.Default.TimerInterval;
            Init();
        }

        private void Init()
        {
            db = new IPTDBEntities();
            timer = new Timer(interval);
            timer.Start();
            timer.Elapsed += ProveraStanjaSvihServisa;
        }

        public void ProveraStanjaSvihServisa(object sender, ElapsedEventArgs e)
        {
            try
            {
                timer.Stop();
                Task.Factory.StartNew(() => 
                {
                    List<Task> taskovi = new List<Task>();
                    foreach (var ClientService in db.ClientServices.ToList())
                    {
                        taskovi.Add(Task.Factory.StartNew( () => 
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
                            catch (Exception ex)
                            {
                                error = ex.Message;
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
                                db.ServiceLogs.Add(noviLog);
                                db.SaveChanges();
                            }
                        }));
                    }
                    Task.WaitAll(taskovi.ToArray());
                });
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                timer.Start();
            }

        }
    }
}
