//16. существует ли треугольник с длинами сторон a, b, c.

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
                if (!double.TryParse(Console.ReadLine(), out x) || x <= 0 || x > int.MaxValue) Console.WriteLine("Введите корректное значение");
                else return x;
            }
        }



        static void Main(string[] args)
        {
            double a, b, c;
            int n = 1;
            Console.WriteLine("Cуществует ли треугольник с длинами сторон a, b, c");
            while (true)
            {
                switch (n)
                {
                    case 1:
                        Console.WriteLine("\nВведите сторону a: ");
                        a = wri();
                        Console.WriteLine("\nВведите сторону b: ");
                        b = wri();
                        Console.WriteLine("\nВведите сторону c: ");
                        c = wri();


                        if (c < a + b && a < c + b && b < a + c) Console.WriteLine("\nТреугольник существует");
                        else Console.WriteLine("\nТреугольник не существует");

                        while (true)
                        {
                            Console.WriteLine("\n1 - Продолжить\n2 - Закончить\n");
                            if (!int.TryParse(Console.ReadLine(), out n) || n < 1 || n > 2) Console.WriteLine("Введите корректное значение\n");
                            else break;
                        }
                        break;
                    case 2: return;
                }

            }
        }
    }
}
