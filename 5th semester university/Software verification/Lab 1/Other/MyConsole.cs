using System;

namespace Lab_1.Other
{
    public static class MyConsole
    {
        public static void printTasks(int a)
        {
            Console.WriteLine('\n'+new string('=', 50));
            Console.WriteLine($"Task{a}:\n");
        }
    }
}
