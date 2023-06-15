using _153504_KLIMKOVICH_Lab5.Collections;
using System;

namespace _153504_KLIMKOVICH_Lab5.Entities
{
    public class Register
    {
        public delegate void Delegate(string message);
        public static event Delegate ChangeDirection;
        public static event Delegate ChangePassanger;

        MyCustomCollection<Direction> directions = new MyCustomCollection<Direction>();
        MyCustomCollection<Passenger> passengers = new MyCustomCollection<Passenger>();
        public void WriteNewDirection(string name)
        {
            ChangeDirection?.Invoke("ChangeDirection");
            Direction temp = new Direction();
            temp.direction = name;
            directions.Add(temp);
        }

        public void NewPassaner(string name, int price, int indexDirection)
        {
            ChangePassanger?.Invoke("ChangePassanger");
            int count = passengers.Count;
            for (int a = 0; a < count; a++)
            {
                if (passengers[a].passport == name)
                {
                    passengers[a].BuyTicket( price, directions[indexDirection].direction);
                    return;
                }
            }
            Passenger temp = new Passenger();
            temp.passport = name;
            temp.ticket = new MyCustomCollection<Ticket>();
            passengers.Add(temp);
            passengers[passengers.Count - 1].BuyTicket(price, directions[indexDirection].direction);
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
