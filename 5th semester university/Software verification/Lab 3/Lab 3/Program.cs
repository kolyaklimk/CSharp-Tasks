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

    public class Triangle
    {
        const int TrEquilateral = 1; // равносторонний
        const int TrIsosceles = 2;   // равнобедренный
        const int TrOrdinary = 4;    // обычный
        const int TrRectangular = 8; // прямоугольный

        private double a;
        private double b;
        private double c;

        private string message;

        public Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.message = "";
        }

        public string GetMessage()
        {
            return this.message;
        }

        public bool CheckTriangle()
        {
            if (a <= 0)
            {
                this.message = "a<=0";
                return false;
            }

            if (b <= 0)
            {
                this.message = "b<=0";
                return false;
            }

            if (c <= 0)
            {
                this.message = "c<=0";
                return false;
            }

            if (a + b <= c)
            {
                this.message = "a+b<=c";
                return false;
            }

            if (a + c <= b)
            {
                this.message = "a+c<=b";
                return false;
            }

            if (b + c <= a)
            {
                this.message = "b+c<=a";
                return false;
            }

            return true;
        }

        public int DetectTriangle()
        {
            int finalState = 0;

            if ((a * a + b * b == c * c) || (b * b + c * c == a * a) || (a * a + c * c == b * c))
            {
                finalState = finalState | TrRectangular; // прямоугольный
            }

            if (a == b && b == c && a == c)
            {
                finalState = finalState | TrEquilateral; // равносторонний
            }

            if (a == b || b == c || a == c)
            {
                finalState = finalState | TrIsosceles; // равнобедренный
            }

            if (finalState == 0)
            {
                return TrOrdinary; // обычный
            }
            else
            {
                return finalState; // комбинация признаков
            }
        }

        public double GetSquare()
        {
            double p;

            p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
    }
}
