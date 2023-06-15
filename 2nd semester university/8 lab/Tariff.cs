using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8
{
    class Tariff
    {
        public string name;
        IPrice ip;
        public Tariff(string Name, IPrice Ip)
        {
            name = Name;
            ip = Ip;
        }
        public int GetPrice()
        {
            return ip.GetPrice();
        }
    }
}
