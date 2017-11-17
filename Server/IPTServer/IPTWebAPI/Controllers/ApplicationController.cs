using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IPTCommon;

namespace IPTWebAPI.Controllers
{
    public class ApplicationController : ApiController
    {
        public Object Get(string appId)
        {
            return WebCommunication.GetApplicationInfo(appId);
        }
    }
}
