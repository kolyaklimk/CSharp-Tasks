//6-й вариант
using _2.Services;

using System;
namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            double z;
            function f = new function();
            Console.WriteLine("\nВведите Z: ");
            while (true)
            {
                if (!double.TryParse(Console.ReadLine(), out z) || z > int.MaxValue || z < int.MinValue) Console.WriteLine("Введите корректное значение");
                else break;
            }
            f.fun(z);
        }
    }
}
