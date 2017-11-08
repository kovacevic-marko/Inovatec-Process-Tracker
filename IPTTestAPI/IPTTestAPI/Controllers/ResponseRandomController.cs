using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace IPTTestAPI.Controllers
{
    public class ResponseRandomController : ApiController
    {
        public HttpStatusCode Get()
        {
            Array values = Enum.GetValues(typeof(HttpStatusCode));
            Random rand = new Random();
            HttpStatusCode code = (HttpStatusCode)values.GetValue(rand.Next(values.Length));
            Thread.Sleep(rand.Next(5000));
            return code;
        }
    }
}
