﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPTXamarinForms.Models
{
    class ServiceLogModel
    {
        public int LogID { get; set; }
        public int ClientServiceID { get; set; }
        public DateTime LogDate { get; set; }
        public int StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public string Error { get; set; }
    }
}
