using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using IPTDataAccess;
using System.Threading.Tasks;
using IPTCommon;

namespace IPTWebAPI.Controllers
{
    public class ClientServiceController : ApiController
    {
        public IEnumerable<ClientServicesModel> Get(int ClientId)
        {
            using (IPTDBEntities entities = new IPTDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                SqlParameter param1 = new SqlParameter("@ClientID", ClientId);
                var rezultat= entities.Database.SqlQuery<GetServicesForClientID_Result>("GetServicesForClientID @ClientID", param1).ToList();
                List<ClientServicesModel> lista = new List<ClientServicesModel>();
                List<Task> tasks = new List<Task>();
                foreach (var r in rezultat)
                {
                    ClientServicesModel cs = new ClientServicesModel();
                    cs.CLientServiceId = r.ID;
                    cs.ServiceName = r.ServiceName;
                    cs.ServiceStatus = -1;
                    tasks.Add(Task.Factory.StartNew(() => 
                    {
                        cs.ServiceStatus = WebCommunication.GetStatusCode(r.URL);
                    }));
                    lista.Add(cs);
                }
                Task.WaitAll(tasks.ToArray(), 2000);

                return lista;
            }
        }

    }
}