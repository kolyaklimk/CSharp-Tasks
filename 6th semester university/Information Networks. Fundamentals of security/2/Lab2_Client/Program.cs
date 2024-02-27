using Lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2_Client
{
    static class Program
    {
        static void Main()
        {
            var _client = new Client();
            var task = Task.Run(() => _client.Connection());
            try
            {
                _client.LogOn("kolyaklimk");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            
            task.Wait();
        }
    }
}