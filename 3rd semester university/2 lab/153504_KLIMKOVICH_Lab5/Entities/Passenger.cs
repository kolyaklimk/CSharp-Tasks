using _153504_KLIMKOVICH_Lab5.Collections;
using System;

namespace _153504_KLIMKOVICH_Lab5.Entities
{
    public class Passenger
    {
        public string passport { get; set; }
        public MyCustomCollection<Ticket> ticket;

        public delegate void DelegateBuyTicket(string message);
        public static event DelegateBuyTicket buyTicket;
        public void BuyTicket(int price, string direction)
        {
            buyTicket?.Invoke("BuyTicket");
            Ticket temp3 = new Ticket();
            temp3.price = price;
            temp3.direction = direction;
            this.ticket.Add(temp3);
        }
    }
}
