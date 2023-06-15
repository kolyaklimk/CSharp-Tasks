using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    class DateService
    {
        public bool GetDay(string date)
        {
            DateTime dt;
            if (!DateTime.TryParse(date, out dt) || (date[2]>'0'&& date[2]<'9') || (date[5] > '0' && date[5] < '9'))
            {
                Console.WriteLine("Введите корректное значение");
                return false;
            }
            Console.WriteLine("\nДень недели: " + dt.ToString("dddd"));
            return true;
        }

        public void GetDaysSpan(int day, int month, int year)
        {
            DateTime dt = new DateTime(year, month, day);
            string str = dt.Subtract(DateTime.Today).ToString();
            if (str.Length>9) Console.WriteLine(Math.Abs(int.Parse(str.Substring(0, str.Length - 9))));
            else Console.WriteLine(0);
        }
    }
}
