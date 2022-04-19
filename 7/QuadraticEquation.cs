using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7
{
    class QuadraticEquation
    {
        double[] arr=new double[3];
        public double this[int index]
        {
            set
            {
                arr[index] = value;
            }

            get
            {
                return arr[index];
            }
        }
        private string toString(double x)
        {
            return "x = " + x.ToString();
        }
        private string toString(double x1, double x2)
        {
            return "x1 = " + x1.ToString() + "\nx2 = " + x2.ToString();
        }
        public QuadraticEquation(double a, double b, double c)
        {
            arr[0] = a;
            arr[1] = b;
            arr[2] = c;
        }
        public QuadraticEquation(double a)
        {
            arr[0] = a;
        }
        public string findX()
        {
            double d = arr[1] * arr[1] - 4 * arr[0] * arr[2];
            if (d < 0) return "false";
            if (arr[0] == 0) return "a == 0";
            double x1 = (-arr[1] + Math.Sqrt(d)) / 2 / arr[0], x2 = (-arr[1] - Math.Sqrt(d)) / 2 / arr[0];
            if (x1 == x2) return toString(x1);
            return toString(x1, x2);
        }

        // + - / *
        public static QuadraticEquation operator +(QuadraticEquation equation1, QuadraticEquation equation2)
        {
            return new QuadraticEquation(equation1.arr[0] + equation2.arr[0], equation1.arr[1] + equation2.arr[1], equation1.arr[2] + equation2.arr[2]);
        }
        public static QuadraticEquation operator -(QuadraticEquation equation1, QuadraticEquation equation2)
        {
            return new QuadraticEquation(equation1.arr[0] - equation2.arr[0], equation1.arr[1] - equation2.arr[1], equation1.arr[2] - equation2.arr[2]);
        }
        public static QuadraticEquation operator /(QuadraticEquation equation1, QuadraticEquation equation2)
        {
            return new QuadraticEquation(equation1.arr[0] / equation2.arr[0], equation1.arr[1] / equation2.arr[1], equation1.arr[2] / equation2.arr[2]);
        }
        public static QuadraticEquation operator *(QuadraticEquation equation1, QuadraticEquation equation2)
        {
            return new QuadraticEquation(equation1.arr[0] * equation2.arr[0], equation1.arr[1] * equation2.arr[1], equation1.arr[2] * equation2.arr[2]);
        }

        // < > == !=
        public static bool operator <(QuadraticEquation equation1, QuadraticEquation equation2)
        {
            return equation1.arr[0] < equation2.arr[0] && equation1.arr[1] < equation2.arr[1] && equation1.arr[2] < equation2.arr[2];
        }
        public static bool operator >(QuadraticEquation equation1, QuadraticEquation equation2)
        {
            return equation1.arr[0] > equation2.arr[0] && equation1.arr[1] > equation2.arr[1] && equation1.arr[2] > equation2.arr[2];
        }
        public static bool operator ==(QuadraticEquation equation1, QuadraticEquation equation2)
        {
            return equation1.arr[0] == equation2.arr[0] && equation1.arr[1] == equation2.arr[1] && equation1.arr[2] == equation2.arr[2];
        }
        public static bool operator !=(QuadraticEquation equation1, QuadraticEquation equation2)
        {
            return equation1.arr[0] != equation2.arr[0] && equation1.arr[1] != equation2.arr[1] && equation1.arr[2] != equation2.arr[2];
        }

        // ++ --
        public static QuadraticEquation operator ++(QuadraticEquation equation)
        {
            equation.arr[0] += 1;
            equation.arr[1] += 1;
            equation.arr[2] += 1;
            return equation;
        }
        public static QuadraticEquation operator --(QuadraticEquation equation)
        {
            equation.arr[0] -= 1;
            equation.arr[1] -= 1;
            equation.arr[2] -= 1;
            return equation;
        }

        //true false
        public static bool operator true(QuadraticEquation equation)
        {
            if (equation.arr[0] > 0 && equation.arr[1] > 0 && equation.arr[2] > 0) return true;
            else return false;
        }
        public static bool operator false(QuadraticEquation equation)
        {
            if (equation.arr[0] <= 0 && equation.arr[1] <= 0 && equation.arr[2] <= 0) return true;
            else return false;
        }

        //type conversions
        public static implicit operator QuadraticEquation(double a)
        {
            return new QuadraticEquation(a);
        }
        public static explicit operator double(QuadraticEquation counter)
        {
            return counter.arr[0];
        }
    }
}
