using System;

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
