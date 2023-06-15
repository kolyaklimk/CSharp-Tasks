using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6
{
    class composition : cup
    {
        public string compositionOfСocktail;
        public int milliliters;

        public composition(string Form, string CompositionOfСocktail) : base(Form)
        {
            Console.WriteLine("Создан класс 'composition'\ncup <- composition");
            compositionOfСocktail = CompositionOfСocktail;
        }

        //перегрузка
        public void Print(int buf)
        {
            Console.WriteLine("Повтор " + buf + " раз");
            for (int a = 0; a < buf; a++)
            {
                Console.WriteLine("CompositionOfСocktail: " + compositionOfСocktail + "Milliliters: " + milliliters);
            }
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine("Volume - milliliters = " + (Volume - milliliters));
        }
        public override void increase(int buf)
        {
            milliliters += buf;
        }
        public override void decrease(int buf)
        {
            milliliters -= buf;
        }
        public new void PrintClassCup()
        {
            Console.WriteLine("(скрытие метода) Тут дожен быть класс 'cup', но это 'composition'");
        }
    }
}
