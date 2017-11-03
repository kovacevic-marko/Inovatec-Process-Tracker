using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace IPTSakupljac
{
    public partial class IPTSakupljacService : ServiceBase
    {
        public IPTSakupljacService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            new Sakupljanje();
        }

        protected override void OnStop()
        {
        }
    }
}
