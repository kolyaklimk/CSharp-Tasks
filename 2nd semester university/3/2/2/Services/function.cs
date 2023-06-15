using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Services
{
    class function
    {
        bool n = true;
        public void fun(double z)
        {
            if (z >= 0)
            {
                z = Math.Sin(z);
                n = false;
            }
            z = 2 / 3.0 * Math.Pow(Math.Sin(z * Math.PI / 180),2) - 3 / 4.0 * Math.Pow(Math.Cos(z * Math.PI / 180),2);
            if (n) Console.WriteLine("\nX = Z, ТК Z < 0\n");
            else Console.WriteLine("\nX = SIN(Z), ТК Z >= 0\n");
            Console.WriteLine("Y = " + z);
        }
    }
}
