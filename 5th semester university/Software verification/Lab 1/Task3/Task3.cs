using Lab_1.Other;
using System;

namespace Lab_1.Task3
{
    public static class Task3
    {

        public static void StartTask()
        {
            MyConsole.printTasks(3);
            ReadConsole();
        }

        public static double CheckData(string text)
        {
            double a;
            if (!double.TryParse(text, out a))
            {
                return -1;
            }
            if (a <= 0)
            {
                return -1;
            }

            return a;
        }

        public static string GetS(double a, double b)
        {
            try
            {
                var s = a * b;
                return s.ToString();
            }
            catch
            {
                return "Error";
            }
        }

        public static void ReadConsole()
        {
            double a;
            while (true)
            {
                Console.WriteLine("Print a:");
                var text = Console.ReadLine();
                a = CheckData(text);
                if (a != -1)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Error, try again");
                }
            }

            double b;
            while (true)
            {
                Console.WriteLine("Print b:");
                var text = Console.ReadLine();
                b = CheckData(text);
                if (b != -1)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Error, try again");
                }
            }

            Console.WriteLine($"S = {GetS(a, b)}");
        }
    }
}
