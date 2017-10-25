using IPTDataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace IPTSakupljac
{
    public class Program
    {
        static void Main(string[] args)
        {
            new Sakupljanje(1000);
            while (true)
            {
                Console.ReadKey();
            }
        }
    }
}
