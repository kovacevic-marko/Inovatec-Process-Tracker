using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IPTDataAccess;
using System.Data.SqlClient;

namespace IPTWebAPI.Controllers
{
    public class ClientServicesListController : ApiController
    {
        public IEnumerable<Client> Get()
        {
            using (IPTDBEntities entities = new IPTDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                List<Client> temp = new List<Client>();
                temp= entities.Clients.ToList();
                foreach (var item in temp)
                {
                    //var query = from Cs in entities.ClientServices
                    //          join S in entities.Services on Cs.ServiceID equals S.ServiceID;
                    SqlParameter param1 = new SqlParameter("@ClientID", item.ClientID);
                    var pom= entities.Database.SqlQuery<GetServicesForClientID_Result>("GetServicesForClientID @ClientID", param1).ToList();
                    
                    foreach (var s in pom)
                    {
                        ClientService pom1 = new ClientService();
                        pom1.ClientID = s.ClientID;
                        pom1.ServiceID = s.ServiceID;
                        pom1.ServiceName = s.ServiceName;
                        pom1.URL = s.URL;
                        item.ClientServices.Add(pom1);
                    }
                }
                return temp;
            }
        }
    }
}
