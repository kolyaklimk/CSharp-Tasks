using System;
using System.Collections.Generic;

namespace _8
{
    class Program
    {
        static void Main(string[] args)
        {
            Airport airport = new Airport();
            airport.addTariffDiscount("Moscow", 3100, 400);
            airport.addTariffNoDiscount("Minsk", 1200);
            airport.addTariffDiscount("Brest", 12820, 950);
            Console.WriteLine(airport.searchMaxPrice());
        }
    }
}

