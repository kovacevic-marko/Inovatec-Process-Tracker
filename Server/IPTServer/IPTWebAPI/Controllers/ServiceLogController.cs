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
    public class ServiceLogController : ApiController
    {
        public IEnumerable<GetServiceLog_Result> Get(int id)
        {
            using (IPTDBEntities entities=new IPTDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                SqlParameter param1 = new SqlParameter("@id", id);
                return entities.Database.SqlQuery<GetServiceLog_Result>("GetServiceLog @id", param1).ToList();
            }
        }
    }
}
