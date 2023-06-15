using System;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            string date;
            DateService da = new DateService();
            Console.WriteLine("Формат: День/Месяц/Год\n");
            while (true)
            {
                date = Console.ReadLine();
                if (date.Length != 10)
                {
                    Console.WriteLine("Введите корректное значение");
                    continue;
                }
                else if (da.GetDay(date)) break;
            }
            int day = int.Parse(date.Substring(0, 2));
            int month = int.Parse(date.Substring(3, 2));
            int year = int.Parse(date.Substring(6, 4));
            
            da.GetDaysSpan(day, month, year);
        }
    }
}
