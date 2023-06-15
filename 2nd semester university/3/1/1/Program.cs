/*4. Разработать метод f(x), который вычисляет значение по
следующей формуле:f(x)=cosx-sin2x. Определить, в какой из точек а или b,
функция принимает наименьшее значение.
*/

using System;

namespace _1
{
    class Program
    {
        static double wri()
        {
            double x;
            while (true)
            {
                if (!double.TryParse(Console.ReadLine(), out x) || x > int.MaxValue || x < int.MinValue) Console.WriteLine("Введите корректное значение");
                else return x;
            }
        }
        static void Main(string[] args)
        {
            Function f = new Function();
            double a, b;
            Console.WriteLine("\nВведите a: ");
            a = wri();
            Console.WriteLine("\nВведите b: ");
            b = wri();

            a = f.fun(a);
            b = f.fun(b);

            if (a > b) Console.WriteLine("\nf(a) > f(b)");
            else
            {
                if (a < b)
                    Console.WriteLine("\nf(b) < f(a)");
                else Console.WriteLine("\nf(b) == f(a)");
            }
        }
    }
}
