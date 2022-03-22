using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Function
    {
        public double fun(double x)
        {
            return Math.Cos(x * Math.PI / 180) - Math.Sin(2 * x * Math.PI / 180);
        }
    }
}
