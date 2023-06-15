using _153504_KLIMKOVICH_Lab5.Entities;
using static System.Collections.Specialized.BitVector32;

namespace _153504_KLIMKOVICH_Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal logs= new Journal();
            //logs.Events();
            Register register = new Register();
            Register.ChangePassanger += logs.Events;
            Register.ChangeDirection += (string message) => Console.WriteLine(message);
            register.WriteNewDirection("Minsk-Moscow");
            register.WriteNewDirection("Minsk-Brest");
            register.WriteNewDirection("Minsk-Gomel");
            register.NewPassaner("124SAFD2314", 15, 1);
            register.NewPassaner("124SAFD2314", 125, 0);
            register.NewPassaner("424SAFD6124", 125, 1);
            Console.WriteLine("\nAll tickets price of 124SAFD2314: " + register.AllPrices(0).ToString());
            Console.WriteLine("\nAll passengers (passports) of Minsk-Brest:\n" + register.FindAllPassengerOfDirection("Minsk-Brest"));
            logs.PrintLogs();
        }
    }
}