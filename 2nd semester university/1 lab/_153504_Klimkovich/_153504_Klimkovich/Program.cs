using System;

namespace _153504_Klimkovich
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите 1-e число: ");
            double n1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите 2-е число: ");
            double n2 = Convert.ToInt32(Console.ReadLine());
            double task = n1 / n2;
            Console.WriteLine("\nчастное от деления чисел n1/n2 : ");
            Console.WriteLine(task);
        }
    }
}
