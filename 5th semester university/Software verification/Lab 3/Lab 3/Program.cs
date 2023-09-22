using System;

namespace Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle tr = new Triangle(1.0, 2.0, 2.0);
            Console.WriteLine(tr.CheckTriangle());
            Console.WriteLine(tr.GetMessage());
            Console.WriteLine(tr.DetectTriangle());
            Console.ReadKey();
        }
    }
}
