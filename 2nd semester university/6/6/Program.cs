using System;

namespace _6
{
    class Program
    {
        static void Main(string[] args)
        {
            composition Composition = new composition("мленький стакан", "Молоко");
            Composition.milliliters = 100;
            Composition.Volume = 200;
            Сocktail cocktail = new Сocktail("большой стакан","Молоко", 23);
            cocktail.amount = 3;
            cocktail.milliliters = 100;
            cocktail.Volume = 200;

            Console.WriteLine("\n\n===============================================");
            Console.WriteLine("Перегрузка метода родителя");
            Console.WriteLine("cocktail.Print()");
            cocktail.Print();
            Console.WriteLine("cocktail.Print(int)");
            cocktail.Print(3);

            Console.WriteLine("\n\n===============================================");
            Console.WriteLine("Виртуальный метод");
            Console.WriteLine("Composition.PrintInfo()");
            Composition.PrintInfo();
            Console.WriteLine("\ncocktail.PrintInfo()");
            cocktail.PrintInfo();

            Console.WriteLine("\n\n===============================================");
            Console.WriteLine("Скрытие метода");
            Console.WriteLine("public new void PrintClassCup()");
            Composition.PrintClassCup();

            Console.WriteLine("\n\n===============================================");
            Console.WriteLine("Абстрактные методы");
            Console.WriteLine("milliliters = " + cocktail.milliliters);
            Console.WriteLine("public abstract void increase(int buf)");
            cocktail.increase(43);
            Console.WriteLine("milliliters = " + cocktail.milliliters);
            Console.WriteLine("public abstract void decrease(int buf)");
            cocktail.decrease(67);
            Console.WriteLine("milliliters = " + cocktail.milliliters);
        }
    }
}
