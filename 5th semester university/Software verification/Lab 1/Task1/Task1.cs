using Lab_1.Other;
using System;

namespace Lab_1.Task1
{
    public static class Task1
    {
        public static void StartTask()
        {
            MyConsole.printTasks(1);
            Console.WriteLine(GenerateString());
        }

        public static string GenerateString()
        {
            Random rand = new Random();
            return $"Hello, world!\nAndhiagain!\n{new string('!', rand.Next(5, 50))}";
        }
    }
}