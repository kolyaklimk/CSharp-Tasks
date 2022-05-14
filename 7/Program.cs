using System;

namespace _7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Урвнение1: ");
            QuadraticEquation equation1 = new QuadraticEquation(3, -14, -5);
            Console.WriteLine(equation1.findX());

            Console.WriteLine("\nУрвнение2: ");
            QuadraticEquation equation2 = new QuadraticEquation(4, -12, 9);
            Console.WriteLine(equation2.findX());

            QuadraticEquation equation3 = equation2 + equation1;
            Console.WriteLine("\n+ " + equation3[0] + " " + equation3[1] + " " + equation3[2]);

            equation3 = equation2 - equation1;
            Console.WriteLine("- " + equation3[0] +" "+ equation3[1] + " " + equation3[2]);

            equation3 = equation2 / equation1;
            Console.WriteLine("/ " + equation3[0] + " " + equation3[1] + " " + equation3[2]);

            equation3 = equation2 * equation1;
            Console.WriteLine("* " + equation3[0] + " " + equation3[1] + " " + equation3[2]);

            Console.WriteLine("\n++ " + ++equation3[0]);

            Console.WriteLine("-- " + --equation3[0]);

            Console.WriteLine("\n1 > 2 " + (equation1 > equation2));
            Console.WriteLine("1 < 2 " + (equation1 < equation2));
            Console.WriteLine("1 == 2 " + (equation1 == equation2));
            Console.WriteLine("1 != 2 " + (equation1 != equation2));

            if (equation1) Console.WriteLine("\nВсе значения уравнения1 положительны");
            else Console.WriteLine("\nНе все значения уравнения1 положительны");

            Console.WriteLine((char)equation1);
            Console.WriteLine((double)equation1);

        }
    }
}
//Int32.Parse(Console.ReadLine())