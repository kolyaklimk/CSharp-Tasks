using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _153504_KLIMKOVICH_Lab5.Entities
{
    internal class Journal
    {
        private List<string> logs = new List<string>();
        public void Events(string msg)
        {
            logs.Add(msg);
        }
        public void PrintLogs()
        {
            Console.WriteLine("=============LOGS===============");
            foreach (var log in logs)
            {
                Console.WriteLine(log);
            }
            Console.WriteLine("================================");
        }
    }
}
