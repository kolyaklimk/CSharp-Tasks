//18-й вариант

using System;

namespace _2
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
            double x, y;
            int n = 1;
            while (true)
            {
                switch (n)
                {
                    case 1:
                        Console.WriteLine("\nВведите X: ");
                        x = wri();
                        Console.WriteLine("\nВведите Y: ");
                        y = wri();

                        if (Math.Pow(x, 2) + Math.Pow(y, 2) < 100 && y < Math.Abs(x))
                            Console.WriteLine("\nДа");
                        else
                        {
                            if (y > Math.Abs(x) || Math.Pow(x, 2) + Math.Pow(y, 2) > 100)
                                Console.WriteLine("\nНет");
                            else Console.WriteLine("\nНа границе");
                        }

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
