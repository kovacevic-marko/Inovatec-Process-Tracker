using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace IPTTestAPI.Controllers
{
    public class Response400Controller : ApiController
    {
        public HttpStatusCode Get()
        {
            Random rand = new Random();
            Thread.Sleep(rand.Next(5000));
            return HttpStatusCode.BadRequest;
        }
    }
}
