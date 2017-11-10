using IPTDataAccess;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Timers;

namespace IPTSakupljac
{
    class Sakupljanje
    {
        //private IPTDBEntities db;
        private int interval;
        private Timer timer;

        public Sakupljanje()
        {
            this.interval = Properties.Settings.Default.TimerInterval;
            Init();
        }

        private void Init()
        {
            //db = new IPTDBEntities();
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
                    List<ClientService> listClientServices;
                    using (var db = new IPTDBEntities())
                    {
                        listClientServices = db.ClientServices.ToList();
                    }
                    foreach (var ClientService in listClientServices)
                    {
                        taskovi.Add(Task.Factory.StartNew(() =>
                        {
                            // Provera statusa servisa
                            string error = null;
                            int? statusCode = null;
                            string statusDescription = null;
                            try
                            {
                                var request = (HttpWebRequest)WebRequest.Create(ClientService.URL);
                                request.Timeout = Properties.Settings.Default.WebRequestTimeout;
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

                            // Dovlacenje poslednjeg loga iz baze
                            ServiceLog poslednjiLog = null;
                            using (var db = new IPTDBEntities())
                            {
                                var log = db.GetLatestServiceLog(ClientService.ID).FirstOrDefault();
                                if (log != null)
                                {
                                    poslednjiLog = new ServiceLog
                                    {
                                        LogID = log.LogID,
                                        ClientServiceID = log.ClientServiceID,
                                        OfflineFrom = log.OfflineFrom,
                                        OfflineTo = log.OfflineTo,
                                        StatusCode = log.StatusCode,
                                        StatusDescription = log.StatusDescription,
                                        Error = log.Error
                                    };
                                }
                            }

                            // Slucaj kada je servis aktivan, StatusCode pocinje cifrom 2
                            if (statusCode != null && statusCode.ToString().StartsWith("2"))
                            {
                                if (poslednjiLog != null && poslednjiLog.OfflineTo == null)
                                {
                                    using (var db = new IPTDBEntities())
                                    {
                                        db.ServiceLogs.Attach(poslednjiLog);
                                        poslednjiLog.OfflineTo = DateTime.Now;
                                        db.SaveChanges();
                                    }
                                }
                            }
                            // Svi ostali slucajevi - servis nije aktivan
                            else
                            {
                                DateTime dateTime = DateTime.Now;
                                // Ako se razlog neaktivnosti servisa promenio,
                                // interval neaktivnosti se zatvara i
                                // zapocinje novi neaktivni interval od istog trenutka
                                if (poslednjiLog != null &&
                                        (poslednjiLog.StatusCode != statusCode ||
                                        poslednjiLog.StatusDescription != statusDescription ||
                                        poslednjiLog.Error != error)
                                   )
                                {
                                    using (var db = new IPTDBEntities())
                                    {
                                        db.ServiceLogs.Attach(poslednjiLog);
                                        poslednjiLog.OfflineTo = dateTime;
                                        db.SaveChanges();
                                    }

                                }
                                // Novi log se kreira ako nema poslednjeg loga, 
                                // ako poslednji log ima vreme zavrsetka offline perioda ili
                                // ako se razlog neaktivnosti servisa promenio
                                if (poslednjiLog == null || poslednjiLog.OfflineTo != null)
                                {
                                    ServiceLog noviLog = new ServiceLog
                                    {
                                        ClientServiceID = ClientService.ID,
                                        OfflineFrom = dateTime,
                                        OfflineTo = null,
                                        StatusCode = statusCode,
                                        StatusDescription = statusDescription,
                                        Error = error
                                    };
                                    using (var db = new IPTDBEntities())
                                    {
                                        db.ServiceLogs.Add(noviLog);
                                        db.SaveChanges();
                                    }

                                    // OVDE DODATI SLANJE EMAIL-A
                                }
                            }
                        }));
                    }
                    Task.WaitAll(taskovi.ToArray());
                });
            }
            catch (Exception ex)
            {
                //throw;
                string sSource;
                string sLog;
                string sEvent;

                sSource = "IPTSakupljacService";
                sLog = "Application";
                sEvent = ex.Message;

                if (!EventLog.SourceExists(sSource))
                    EventLog.CreateEventSource(sSource, sLog);

                EventLog.WriteEntry(sSource, sEvent);
            }
            finally
            {
                timer.Start();
            }

        }
    }
}
