using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace _153504_KLIMKOVICH_Lab5.Entities
{
    public class Register
    {
        public delegate void RegisterHandler(string message);
        public event RegisterHandler? ChangeDirection;
        public event RegisterHandler? ChangePassanger;

        Dictionary<string, Direction> directions = new Dictionary<string, Direction>();
        List<Passenger> passengers = new List<Passenger>();

        public void WriteNewDirection(string name,int price)
        {
            Direction temp = new Direction();
            temp.direction = name;
            temp.price = price;
            directions.Add(name, temp);
            ChangeDirection?.Invoke("ChangeDirection");
        }

        public void NewPassaner(string name, string direction)
        {
            for (int a = 0; a < passengers.Count(); a++)
            {
                if (passengers[a].passport == name)
                {
                    passengers[a].BuyTicket(directions[direction].direction, directions[direction].price);
                    return;
                }
            }
            passengers.Add(new Passenger());
            passengers[passengers.Count() - 1].passport = name;
            passengers[passengers.Count() - 1].BuyTicket(directions[direction].direction, directions[direction].price);
            ChangePassanger?.Invoke("ChangePassanger");
        }
        public int AllPrices(int indexPassenger)
        {
            int allPrice = 0;
            int count = passengers[indexPassenger].ticket.Count;
            for (int a = count - 1; a >= 0; a--)
            {
                allPrice += passengers[indexPassenger].ticket[a].price;
            }
            return allPrice;
        }
        public void AllDirections()
        {
            foreach (var pair in directions.OrderBy(pair => pair.Value.price))
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value.price);
            }
        }
        public int AllCost()
        {
            int allCost = 0;
            for(int a = 0; a < passengers.Count; a++)
            {
                for(int b = 0; b < passengers[a].ticket.Count; b++)
                {
                    allCost += passengers[a].ticket[b].price;
                }
            }
            return allCost;
        }
        public string NameOfMaxCost()
        {
            string name = "";
            int maxPrice=0;
            for (int a = 0; a < passengers.Count; a++)
            {
                int bufPrice = 0;
                for (int b = 0; b < passengers[a].ticket.Count; b++)
                {
                    bufPrice += passengers[a].ticket[b].price;
                }
                if (bufPrice > maxPrice) name = passengers[a].passport;
            }
            return name;
        }
        public int CountMoreThenX(int buf)
        {
            int count = 0;
            for (int a = 0; a < passengers.Count; a++)
            {
                int bufPrice = passengers[a].ticket.Sum(x => x.price);
                if (bufPrice > buf) count++;
            }
            return count;
        }
        public void SumOfDirections(int a)
        {
            if (a > passengers.Count) return;
            var pass = passengers[a].ticket
                .GroupBy(t => t.direction)
                .Select(g => (g.Key, g.Sum(t => t.price)));
            foreach (var direction in pass)
            {
                Console.WriteLine("Direction " + direction.Key.ToString() + ": " + direction.Item2);
            }
        }
        public string FindAllPassengerOfDirection(string nameDirection)
        {
            int count = passengers.Count;
            string str = "";
            for (int a = count - 1; a >= 0; a--)
            {
                int count2 = passengers[a].ticket.Count;
                for (int b = count2 - 1; b >= 0; b--)
                {
                    if (passengers[a].ticket[b].direction == nameDirection)
                    {
                        str += passengers[a].passport + '\n';
                    }
                }
            }
            return str;
        }
    }
}
