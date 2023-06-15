using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8
{
    class NoDiscount : IPrice
    {
        private int price;
        public NoDiscount(int p)
        {
            price = p;
        }
        public int GetPrice()
        {
            return price;
        }
    }
}
