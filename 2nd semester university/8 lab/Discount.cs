using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8
{
    class Discount: IPrice
    {
        private int price, discount;
        public Discount(int p, int d)
        {
            price = p;
            discount = d;
        }
        public int GetPrice()
        {
            return price - discount;
        }
    }
}
