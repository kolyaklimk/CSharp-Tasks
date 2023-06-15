using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6
{
    sealed class Сocktail : composition
    {
        public Сocktail(string Form, string CompositionOfСocktail, int Price) : base(Form, CompositionOfСocktail)
        {
            Console.WriteLine("Создан класс 'Сocktail'\ncup <- composition <- Сocktail");
            price = Price;
        }
        public int price;
        public int amount = 1;
        public override void PrintInfo()
        {
            //base.PrintInfo();
            Console.WriteLine("Общая стоимость: " + price * amount);
        }
    }
}
