using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IPTDataAccess;
using System.Data.SqlClient;
using IPTCommon;

namespace IPTWebAPI.Controllers
{
    public class ServiceStatusController : ApiController
    {
        public int Get(int id)
        {
            using (IPTDBEntities entities=new IPTDBEntities())
            {
                //SqlParameter  param1 = new SqlParameter("@id", id);
                //string rezultat = entities.Database.SqlQuery<string>("GetServiceUrl @id", param1).ToString();
                var url = (from c in entities.ClientServices
                           where c.ID == id
                           select c.URL).Single();

                return WebCommunication.GetStatusCode(url);
            }
        }
    }
}
