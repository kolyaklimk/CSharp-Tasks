using System;

namespace Lab_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1.Task1.StartTask();
            Task2.Task2.StartTask();
            Task3.Task3.StartTask();
            Task4.Task4.StartTask();
            Console.WriteLine("\n\n");
            while (true)
            {
                Console.ReadLine();
            }
        }
    }
}
