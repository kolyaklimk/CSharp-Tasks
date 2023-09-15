using Lab_1.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lab_1.Task2
{
    public class Human
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }

    public static class Task2
    {
        public static void StartTask()
        {
            MyConsole.PrintTasks(2);
            ReadConsole();
        }

        public static Human CheckData(string text)
        {
            var splitText = text.Split(' ');
            int age;

            if (splitText.Length != 3)
            {
                return null;
            }
            if (!int.TryParse(splitText[2], out age))
            {
                return null;
            }
            if (age <= 0 || age > 100)
            {
                return null;
            }

            Regex regex = new Regex("^[a-zA-Z]+$");
            if (!regex.IsMatch(splitText[0]) || !regex.IsMatch(splitText[1]))
            {
                return null;
            }

            return new Human()
            {
                Name = splitText[0],
                Surname = splitText[1],
                Age = age,
            };
        }

        public static int LowAge(List<Human> list)
        {
            if (list.Count == 0)
                return -1;

            return list.OrderBy(h => h.Age).FirstOrDefault().Age;
        }

        public static int HightAge(List<Human> list)
        {
            if (list.Count == 0)
                return -1;

            return list.OrderByDescending(h => h.Age).FirstOrDefault().Age;
        }

        public static double AverageAge(List<Human> list)
        {
            if (list.Count == 0)
                return -1;

            return Math.Round(list.Average(h => h.Age), 2);
        }

        public static void ReadConsole()
        {
            Console.WriteLine("Print \"Surname Name Age\", or '$' to stop.");
            List<Human> humans = new List<Human>();
            while (true)
            {
                var text = Console.ReadLine();

                if (text == "$")
                    break;

                var human = CheckData(text);
                if (human == null)
                {
                    Console.WriteLine("Error, try again");
                }
                else
                {
                    humans.Add(human);
                }
            }

            Console.WriteLine(
                $"LowAge: {MyConsole.GetDouble(LowAge(humans))}; " +
                $"HightAge: {MyConsole.GetDouble(HightAge(humans))}; " +
                $"AverageAge: {MyConsole.GetDouble(AverageAge(humans))}");
        }
    }
}
