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
    public class LatestServiceStatusForIDController : ApiController
    {
        public IEnumerable<Boolean> Get()
        {
            using (InovatecDBEntities entities = new InovatecDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                SqlParameter param1 = new SqlParameter("@id", 1);
                return entities.Database.SqlQuery<Boolean>("GetLatestServiceLogByID @id", param1).ToList();
            }
        }

        public IEnumerable<Boolean> Get(int serviceId)
        {
            using(InovatecDBEntities entities=new InovatecDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                SqlParameter param1 = new SqlParameter("@id", serviceId);
                return entities.Database.SqlQuery<Boolean>("GetLatestServiceLogByID @id", param1).ToList();
            }
        }
    }
}
