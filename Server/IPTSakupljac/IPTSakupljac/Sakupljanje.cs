using IPTDataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace IPTSakupljac
{
    class Sakupljanje
    {
        private int interval;
        private Timer timer;
        private InovatecDBEntities entities;

        public Sakupljanje(int interval = 10000)
        {
            this.interval = interval;
            Init();
        }

        private void Init()
        {
            timer = new Timer(interval);
            entities = new InovatecDBEntities();
            timer.Start();
            timer.Elapsed += ProveraStanjaSvihServisa;
            timer.Elapsed += ProveraStanjaSvihAplikacija;
        }

        /************************************************************************
         * Funkcija koja proverava da li je servis na zadatoj adresi aktivan
         * ili ne i vraca true ili false, respektivno.
         * Potrebno je da GET hendler sa zadate adrese vrati "true" kao odgovor,
         * odnosno samo u tom slucaju ce servis biti posmatran kao aktivan.
         ************************************************************************/
        bool IsActive(string adresa)
        {
            bool answer = false;
            try
            {
                // kreiranje objekata za http komunikaciju
                WebRequest request = WebRequest.Create(adresa);
                WebResponse response = request.GetResponse();
                // pretvaranje odgovora u string
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                response.Close();

                if (responseFromServer == "true")
                    answer = true;
            }
            catch (WebException)
            {
                Console.WriteLine("Greska prilikom konekcije");
            }
            catch (Exception)
            {
                throw;
            }
            return answer;
        }

        // Hendler koji se pokrece pri okidanju tajmera
        public void ProveraStanjaSvihServisa(object sender, ElapsedEventArgs e)
        {
            foreach (var servis in entities.tb_service.ToList())
            {
                bool status = IsActive(servis.ipv4);
                UpisStanjaServisa(servis.id, status, DateTime.Now);
            }
        }

        void UpisStanjaServisa(int service_id, bool status, DateTime date)
        {
            tb_service_log novi_log = new tb_service_log
            {
                service_id = service_id,
                status = status,
                date = date
            };
            entities.tb_service_log.Add(novi_log);
            entities.SaveChanges();
        }
        public void ProveraStanjaSvihAplikacija(object sender, ElapsedEventArgs e)
        {
            foreach (var aplikacija in entities.tb_application.ToList())
            {
                bool aplikacija_aktivna = IsActive(aplikacija.ipv4);
                string status = "";

                //TODO 

                //Iplementirati Xml u string

                UpisStanjaAplikacije(aplikacija.id, status, DateTime.Now);
            }
        }
        void UpisStanjaAplikacije(int application_id, string status, DateTime date)
        {
            tb_application_log novi_log = new tb_application_log
            {
                application_id = application_id,
                status = status,
                date = date
            };
            entities.tb_application_log.Add(novi_log);
            entities.SaveChanges();
        }
    }
}
