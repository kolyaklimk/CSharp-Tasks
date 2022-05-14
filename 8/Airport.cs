using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8
{
    class Airport
    {
        List<Tariff> tariff = new List<Tariff>();
        public void addTariffDiscount(string name, int price, int discount)
        {
            tariff.Add(new Tariff(name, new Discount(price, discount)));
        }
        public void addTariffNoDiscount(string name, int price)
        {
            tariff.Add(new Tariff(name, new NoDiscount(price)));
        }
        public string searchMaxPrice()
        {
            int price = 0;
            string temp = "-";
            if (tariff.Count() > 0)
            {
                price = tariff[0].GetPrice();
                temp = tariff[0].name + ", Price: " + price.ToString();
                foreach (Tariff t in tariff)
                {
                    if (t.GetPrice() > price)
                    {
                        price = t.GetPrice();
                        temp = t.name + ", Price: " + t.GetPrice().ToString();
                    }
                }
            }
            return temp;
        }
    }
}
