using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using _153504_KLIMKOVICH_Lab5.Collections;

namespace _153504_KLIMKOVICH_Lab5.Entities
{
    internal class Journal
    {
        private MyCustomCollection<string> logs = new MyCustomCollection<string>();
        public void Events(string msg)
        {
            //Register.ChangeDirection += message => logs.Add(message);
            //Register.ChangePassanger += message => logs.Add(message);
            //Passenger.buyTicket += message => logs.Add(message);
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
