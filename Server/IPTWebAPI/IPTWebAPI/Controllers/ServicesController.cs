using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IPTDataAccess;

namespace IPTWebAPI.Controllers
{
    public class ServicesController : ApiController
    {
        public IEnumerable<ServicesInfo> Get()
        { 
            using(InovatecDBEntities entities=new InovatecDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.ServicesInfoes.ToList();
            }
        }
    }
}
