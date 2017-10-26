using IPTDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IPTWebAPI.Controllers
{
    public class ApplicationsController : ApiController
    {
        public IEnumerable<tb_application> Get()
        {
            using (InovatecDBEntities entities = new InovatecDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.tb_application.ToList();
            }
        }
    }
}
