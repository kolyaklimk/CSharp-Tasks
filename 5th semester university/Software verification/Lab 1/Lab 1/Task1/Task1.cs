using System;

namespace Lab_1.Task1
{
    public static class Task1
    {
        public static void StartTask()
        {
            Console.WriteLine(GenerateString());
        }

        public static string GenerateString()
        {
            Random rand = new Random();
            return $"Hello, world!\nAndhiagain!\n{new string('!', rand.Next(5, 50))}";
        }
    }
}