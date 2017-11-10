using System;
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
        public DateTime OfflineFrom { get; set; }
        public Nullable<DateTime> OfflineTo { get; set; }
        public Nullable<int> StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public string Error { get; set; }
    }
}
