using System;

namespace _153504_KLIMKOVICH_Lab5.Entities
{
    public class Passenger
    {
        public string passport { get; set; }
        public List<Ticket> ticket=new List<Ticket>();
        public void BuyTicket(string direction,int price)
        {
            Ticket item = new Ticket();
            item.price = price;
            item.direction = direction;
            ticket.Add(item);
        }

    }
}
