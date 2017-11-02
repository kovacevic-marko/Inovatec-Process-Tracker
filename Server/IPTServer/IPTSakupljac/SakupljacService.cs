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
    public partial class SakupljacService : ServiceBase
    {
        public SakupljacService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            new Sakupljanje(1000);
        }

        protected override void OnStop()
        {
        }
    }
}
