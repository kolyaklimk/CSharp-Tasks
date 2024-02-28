using System;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(() => Server.Listener());
            Task.Run(() => Attack.Run());
            Console.ReadLine();
        }
    }
}
