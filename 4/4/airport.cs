using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    class airport
    {
        private string nameAirport;
        private int numberOfSeats;
        private ticket Ticket=new ticket();
        private static airport Airport = null;

        private airport() { }
        public void SetAirportName()
        {
            nameAirport =  Console.ReadLine();
        }
        public void SetNumberOfSeats()
        {
            while (!int.TryParse(Console.ReadLine(), out numberOfSeats) ||
                numberOfSeats > int.MaxValue || numberOfSeats < 0) Console.WriteLine("Введите корректное значение");
        }
        public void SetnumberOfTicketsSold()
        {
            Ticket.SetnumberOfTicketsSold();
        }
        public void SetPriceTicket()
        {
            Ticket.SetPriceTicket();
        }
        public string TotalCostAllTickets()
        {
            return Ticket.TotalCostAllTickets();
        }
        public void UpPrice()
        {
            Ticket.UpPrice();
        }
        public void DownPrice()
        {
            Ticket.DownPrice();
        }
        public string NameAirport
        {
            get { return nameAirport; }
        }
        public int NumberOfSeats
        {
            get { return numberOfSeats; }
        }
        public int NumberOfTicketsSold
        {
            get { return Ticket.NumberOfTicketsSold; }
        }
        public int PriceTicket
        {
            get { return Ticket.PriceTicket; }
        }
        public static airport Initialize()
        {
            if (Airport == null) Airport = new airport();
            return Airport;
        }
    }
}
