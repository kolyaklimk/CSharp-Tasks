using System;

namespace Lab_3
{
    public class Triangle
    {
        const int TR_EQUILATERAL = 1; // равносторонний
        const int TR_ISOSCELES = 2;   // равнобедренный
        const int TR_ORDYNARY = 4;    // обычный
        const int TR_RECTANGULAR = 8; // прямоугольный

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
            int final_state = 0;

            if ((a * a + b * b == c * c) || (b * b + c * c == a * a) || (a * a + c * c == b * c))
            {
                final_state = final_state | TR_RECTANGULAR; // прямоугольный
            }

            if (a == b && b == c && a == c)
            {
                final_state = final_state | TR_EQUILATERAL; // равносторонний
            }

            if (a == b || b == c || a == c)
            {
                final_state = final_state | TR_ISOSCELES; // равнобедренный
            }

            if (final_state == 0)
            {
                return TR_ORDYNARY; // обычный
            }
            else
            {
                return final_state; // комбинация признаков
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
