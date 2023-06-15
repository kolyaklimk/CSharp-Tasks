using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    class ticket
    {
        private int priceTicket;
        private int numberOfTicketsSold;
        public ticket() { }
        
        private ticket(int priceTicket)
        {
            this.priceTicket = priceTicket;
        }
        private ticket(int priceTicket, int numberOfTicketsSold)
        {
            this.priceTicket = priceTicket;
            this.numberOfTicketsSold = numberOfTicketsSold;
        }
        
        public void SetnumberOfTicketsSold()
        {
            while (!int.TryParse(Console.ReadLine(), out numberOfTicketsSold) || 
                numberOfTicketsSold > int.MaxValue || numberOfTicketsSold < 0) Console.WriteLine("Введите корректное значение");
        }
        public void SetPriceTicket()
        {
            while (!int.TryParse(Console.ReadLine(), out priceTicket) || 
                priceTicket > int.MaxValue || priceTicket < 0) Console.WriteLine("Введите корректное значение");
        }
        public string TotalCostAllTickets()
        {
            return (priceTicket * numberOfTicketsSold).ToString();
        }
        public void UpPrice()
        {
            int buf;
            while (!int.TryParse(Console.ReadLine(), out buf) ||
                buf > int.MaxValue || buf < 0) Console.WriteLine("Введите корректное значение");
            priceTicket += buf;
        }
        public void DownPrice()
        {
            int buf;
            while (!int.TryParse(Console.ReadLine(), out buf) ||
                buf > priceTicket || buf < 0) Console.WriteLine("Введите корректное значение");
            priceTicket -= buf;
        }
        public int PriceTicket
        {
            get { return priceTicket; }
        }
        public int NumberOfTicketsSold
        {
            get { return numberOfTicketsSold; }
        }
    }
}
