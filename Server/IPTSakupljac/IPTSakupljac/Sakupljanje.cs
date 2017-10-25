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
        private List<tb_service> servisi;

        public Sakupljanje(int interval = 10000)
        {
            this.interval = interval;
            Init();
        }

        private void Init()
        {
            timer = new Timer(interval);
            entities = new InovatecDBEntities();
            servisi = new List<tb_service>();
            timer.Start();
            timer.Elapsed += ProveraStanjaSvihServisa;
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

        void UcitavanjeServisaIzBaze()
        {
            // TODO
        }

        // Hendler koji se pokrece pri okidanju tajmera
        public void ProveraStanjaSvihServisa(object sender, ElapsedEventArgs e)
        {
            // TODO

            // Console.WriteLine(IsActive("http://localhost:54231/api/test_service").ToString());
        }

        void UpisStanja(int service_id, bool status, DateTime date)
        {
            tb_service_log novi_log = new tb_service_log();
            novi_log.service_id = service_id;
            novi_log.status = status;
            novi_log.date = date;
            entities.tb_service_log.Add(novi_log);
            entities.SaveChanges();
        }
    }
}
