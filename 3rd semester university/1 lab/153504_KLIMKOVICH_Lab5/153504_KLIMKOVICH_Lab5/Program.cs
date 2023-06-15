/*2. Предметная область: Вокзал.
Касса вокзала имеет список тарифов на различные направления. При
покупке билета регистрируются паспортные данные пассажира. Пассажир
покупает билеты на различные направления.
Система должна:
 позволять вводить данные о тарифах;
 позволять вводить паспортные данные пассажира и регистрировать
покупку билета;
 рассчитывать стоимость купленных пассажиром билетов;
 после ввода наименования направления, выводить список всех пассажиров,
купивших на него билет;
*/
using _153504_KLIMKOVICH_Lab5.Entities;

namespace _153504_KLIMKOVICH_Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Register register = new Register();
            register.writeNewDirection("Minsk-Moscow");
            register.writeNewDirection("Minsk-Brest");
            register.writeNewDirection("Minsk-Gomel");
            register.newPassaner("124SAFD2314", 15, 1);
            register.newPassaner("124SAFD2314", 125, 0);
            register.newPassaner("424SAFD6124", 125, 1);
            Console.WriteLine("All tickets price of 124SAFD2314: " + register.AllPrices(0).ToString());
            Console.WriteLine("\nAll passengers (passports) of Minsk-Brest:\n" + register.findAllPassengerOfDirection("Minsk-Brest"));
        }
    }
}