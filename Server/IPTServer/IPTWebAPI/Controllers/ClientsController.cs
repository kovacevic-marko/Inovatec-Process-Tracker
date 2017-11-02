using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IPTDataAccess;

namespace IPTWebAPI.Controllers
{
    public class ClientsController : ApiController
    {
        public IEnumerable<Client> Get()
        {
            using (IPTDBEntities entities = new IPTDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.Clients.ToList();
            }
        }
    }
}
