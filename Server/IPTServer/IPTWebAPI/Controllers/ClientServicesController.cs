using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using IPTDataAccess;
namespace IPTWebAPI.Controllers
{
    public class ClientServiceController : ApiController
    {
        public IEnumerable<GetServicesForClientID_Result> Get(int ClientId)
        {
            using (IPTDBEntities entities = new IPTDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                SqlParameter param1 = new SqlParameter("@ClientID", ClientId);
                return entities.Database.SqlQuery<GetServicesForClientID_Result>("GetServicesForClientID @ClientID", param1).ToList();
            }
        }

    }
}