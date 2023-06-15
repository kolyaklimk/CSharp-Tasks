/*4. Предметная область: Аэропорт-Билет. В классе хранить
информацию о названии аэропорта, стоимости билета (стоимость одинаковая),
общее число мест во всех самолетах, число проданных билетов. Реализовать
метод для подсчета общей стоимости всех проданных билетов. Реализовать
возможность изменения (увеличения и уменьшения) стоимости билета.
*/

using System;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1;
            airport Airport=airport.Initialize();
            while (true)
            {
                switch (n)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Введите название аэропорта: ");
                        Airport.SetAirportName();
                        Console.Clear();
                        Console.WriteLine("Введите стоимость билета: ");
                        Airport.SetPriceTicket();
                        Console.Clear();
                        Console.WriteLine("Введите общее число мест во всех самолетах: ");
                        Airport.SetNumberOfSeats();
                        Console.Clear();
                        Console.WriteLine("Введите число проданных билетов: ");
                        Airport.SetnumberOfTicketsSold();
                        n = 5;
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Стоимость билета:" + Airport.PriceTicket);
                        Console.WriteLine("\nВведите на сколько увеличить стоимость билета: ");
                        Airport.UpPrice();
                        n = 5;
                        break;
                    case 3: 
                        Console.Clear();
                        Console.WriteLine("Стоимость билета:" + Airport.PriceTicket);
                        Console.WriteLine("\nВведите на сколько уменьшить стоимость билета: ");
                        Airport.DownPrice();
                        n = 5;
                        break;
                    case 4:
                        return;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Данные:\nНазвание аэропорта:" + Airport.NameAirport +
                            "\nСтоимость билета:" + Airport.PriceTicket +
                            "\nОбщее число мест во всех самолетах:" + Airport.NumberOfSeats +
                            "\nЧисло проданных билетов:" + Airport.NumberOfTicketsSold +
                            "\nОбщей стоимости всех проданных билетов:" + Airport.TotalCostAllTickets());
                       Console.WriteLine("\n\n1 - заново\n2 - увеличить стоимость билета\n3 - уменьшить стоимость билета\n4 - выйти");
                        while (!int.TryParse(Console.ReadLine(), out n) || n > 4 || n < 1) Console.WriteLine("Введите корректное значение");
                        break;
                }
            }
        }
    }
}
