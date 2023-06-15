using _153504_KLIMKOVICH_Lab5.Entities;
using static System.Collections.Specialized.BitVector32;

namespace _153504_KLIMKOVICH_Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal logs= new Journal();
            Register register = new Register();
            Passenger pas = new Passenger();
            register.ChangePassanger += logs.Events;
            register.ChangeDirection += logs.Events;
            register.WriteNewDirection("Minsk-Moscow",223);
            register.WriteNewDirection("Minsk-Brest",43);
            register.WriteNewDirection("Minsk-Gomel",765);
            register.NewPassaner("124SAFD2314","Minsk-Moscow");
            register.NewPassaner("124SAFD2314", "Minsk-Moscow");
            register.NewPassaner("424SAFD6144", "Minsk-Gomel");
            register.NewPassaner("424SAFD6164", "Minsk-Brest");
            register.NewPassaner("624SAFD6124", "Minsk-Brest");
            register.NewPassaner("124SAFD2314", "Minsk-Gomel");
            Console.WriteLine("All tickets price of 124SAFD2314: " + register.AllPrices(0).ToString());
            Console.WriteLine("\nAll passengers (passports) of Minsk-Brest:\n" + register.FindAllPassengerOfDirection("Minsk-Brest"));
            Console.WriteLine("All directions:"); 
            register.AllDirections();
            Console.WriteLine("\nAll cost: " + register.AllCost().ToString());
            Console.WriteLine("\nName of max price: " + register.NameOfMaxCost());
            Console.WriteLine("\nCount more then 111: " + register.CountMoreThenX(111).ToString());
            Console.WriteLine("\nSum of directions of passenger 1:");
            register.SumOfDirections(0);
            Console.WriteLine("\nSum of directions of passenger 3:");
            register.SumOfDirections(2);
            logs.PrintLogs();
        }
    }
}