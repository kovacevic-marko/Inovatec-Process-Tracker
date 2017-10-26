using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IPT_Probni_Servis.Controllers
{
    [RoutePrefix("api/test_service")]
    public class test_serviceController : ApiController
    {
        //static List<string> status = new List<string>()
        //{
        //    "Servis_je_aktivan"
        //};
        //public IEnumerable<string> Get()
        //{
           
        //    return status;
        
        //}
        public bool Get()
        {
            return true;
        }
    }
}
