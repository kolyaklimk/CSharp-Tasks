using _153504_KLIMKOVICH_Lab5.Collections;

namespace _153504_KLIMKOVICH_Lab5.Entities
{
    public class Passenger
    {
        public string passport { get; set; }
        public MyCustomCollection<Ticket> ticket;
        public void BuyTicket(int price, string direction)
        {
            Ticket temp3 = new Ticket();
            temp3.price = price;
            temp3.direction = direction;
            this.ticket.Add(temp3);
        }
    }
}
