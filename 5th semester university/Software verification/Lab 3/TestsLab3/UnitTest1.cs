﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab_3;

namespace TriangleTests
{
    [TestClass]
    public class TriangleTest
    {
        private double parameterA, parameterB, parameterC;

        [TestMethod]
        public void CheckTriangle_Correct_tst()
        {
            parameterA = 15;
            parameterB = 12;
            parameterC = 14;
            Triangle triangle = new Triangle(parameterA, parameterB, parameterC);
            Assert.IsTrue(triangle.CheckTriangle());
        }

        [TestMethod]
        public void CheckTriangle_Zero_A_tst()
        {
            parameterA = 0;
            parameterB = 12;
            parameterC = 14;
            Triangle triangle = new Triangle(parameterA, parameterB, parameterC);
            Assert.IsFalse(triangle.CheckTriangle());
        }

        [TestMethod]
        public void CheckTriangle_Zero_B_tst()
        {
            parameterA = 15;
            parameterB = 0;
            parameterC = 14;
            Triangle triangle = new Triangle(parameterA, parameterB, parameterC);
            Assert.IsFalse(triangle.CheckTriangle());
        }

        [TestMethod]
        public void CheckTriangle_Zero_C_tst()
        {
            parameterA = 15;
            parameterB = 12;
            parameterC = 0;
            Triangle triangle = new Triangle(parameterA, parameterB, parameterC);
            Assert.IsFalse(triangle.CheckTriangle());
        }

        [TestMethod]
        public void CheckTriangle_Negative_A_tst()
        {
            parameterA = -15;
            parameterB = 12;
            parameterC = 14;
            Triangle triangle = new Triangle(parameterA, parameterB, parameterC);
            Assert.IsFalse(triangle.CheckTriangle());
        }

        [TestMethod]
        public void CheckTriangle_Negative_B_tst()
        {
            parameterA = 15;
            parameterB = -12;
            parameterC = 14;
            Triangle triangle = new Triangle(parameterA, parameterB, parameterC);
            Assert.IsFalse(triangle.CheckTriangle());
        }

        [TestMethod]
        public void CheckTriangle_Negative_C_tst()
        {
            parameterA = 15;
            parameterB = 12;
            parameterC = -14;
            Triangle triangle = new Triangle(parameterA, parameterB, parameterC);
            Assert.IsFalse(triangle.CheckTriangle());
        }

        [TestMethod]
        public void CheckTriangle_Three_More_C_tst()
        {
            parameterA = 15;
            parameterB = 12;
            parameterC = 14;
            Triangle triangle = new Triangle(parameterA, parameterB, parameterC);
            Assert.IsTrue(triangle.CheckTriangle());
        }

        [TestMethod]
        public void CheckTriangle_Three_More_B_tst()
        {
            parameterA = 15;
            parameterB = 14;
            parameterC = 12;
            Triangle triangle = new Triangle(parameterA, parameterB, parameterC);
            Assert.IsTrue(triangle.CheckTriangle());
        }

        [TestMethod]
        public void CheckTriangle_Three_More_A_tst()
        {
            parameterA = 14;
            parameterB = 15;
            parameterC = 12;
            Triangle triangle = new Triangle(parameterA, parameterB, parameterC);
            Assert.IsTrue(triangle.CheckTriangle());
        }

        [TestMethod]
        public void CheckTriangle_Three_Less_C_tst()
        {
            parameterA = 1;
            parameterB = 2;
            parameterC = 14;
            Triangle triangle = new Triangle(parameterA, parameterB, parameterC);
            Assert.IsFalse(triangle.CheckTriangle());
        }

        [TestMethod]
        public void CheckTriangle_Three_Less_B_tst()
        {
            parameterA = 5;
            parameterB = 12;
            parameterC = 1;
            Triangle triangle = new Triangle(parameterA, parameterB, parameterC);
            Assert.IsFalse(triangle.CheckTriangle());
        }

        [TestMethod]
        public void CheckTriangle_Three_Less_A_tst()
        {
            parameterA = 15;
            parameterB = 1;
            parameterC = 1;
            Triangle triangle = new Triangle(parameterA, parameterB, parameterC);
            Assert.IsFalse(triangle.CheckTriangle());
        }

        [TestMethod]
        public void CheckTriangle_Three_Equal_C_tst()
        {
            parameterA = 5;
            parameterB = 5;
            parameterC = 10;
            Triangle triangle = new Triangle(parameterA, parameterB, parameterC);
            Assert.IsFalse(triangle.CheckTriangle());
        }

        [TestMethod]
        public void CheckTriangle_Three_Equal_B_tst()
        {
            parameterA = 5;
            parameterB = 10;
            parameterC = 5;
            Triangle triangle = new Triangle(parameterA, parameterB, parameterC);
            Assert.IsFalse(triangle.CheckTriangle());
        }

        [TestMethod]
        public void CheckTriangle_Three_Equal_A_tst()
        {
            parameterA = 10;
            parameterB = 5;
            parameterC = 5;
            Triangle triangle = new Triangle(parameterA, parameterB, parameterC);
            Assert.IsFalse(triangle.CheckTriangle());
        }

        [TestMethod]
        public void DetectTriangle_Restangular_1_tst()
        {
            parameterA = 3;
            parameterB = 4;
            parameterC = 5;
            Triangle triangle = new Triangle(parameterA, parameterB, parameterC);
            Assert.AreEqual(triangle.DetectTriangle(), 8);
        }

        [TestMethod]
        public void DetectTriangle_Restangular_2_tst()
        {
            parameterA = 5;
            parameterB = 4;
            parameterC = 3;
            Triangle triangle = new Triangle(parameterA, parameterB, parameterC);
            Assert.AreEqual(triangle.DetectTriangle(), 8);
        }

        [TestMethod]
        public void DetectTriangle_Restangular_3_tst()
        {
            parameterA = 2;
            parameterB = 5;
            parameterC = 4;
            Triangle triangle = new Triangle(parameterA, parameterB, parameterC);
            Assert.AreEqual(triangle.DetectTriangle(), 8);
        }

        [TestMethod]
        public void DetectTriangle_Equilateral_tst()
        {
            parameterA = 2;
            parameterB = 2;
            parameterC = 2;
            Triangle triangle = new Triangle(parameterA, parameterB, parameterC);
            Assert.AreEqual(triangle.DetectTriangle(), 0);
        }

        [TestMethod]
        public void DetectTriangle_Isosceles_1_tst()
        {
            parameterA = 2;
            parameterB = 2;
            parameterC = 3;
            Triangle triangle = new Triangle(parameterA, parameterB, parameterC);
            Assert.AreEqual(triangle.DetectTriangle(), 2);
        }

        [TestMethod]
        public void DetectTriangle_Isosceles_2_tst()
        {
            parameterA = 3;
            parameterB = 2;
            parameterC = 2;
            Triangle triangle = new Triangle(parameterA, parameterB, parameterC);
            Assert.AreEqual(triangle.DetectTriangle(), 2);
        }

        [TestMethod]
        public void DetectTriangle_Isosceles_3_tst()
        {
            parameterA = 2;
            parameterB = 3;
            parameterC = 2;
            Triangle triangle = new Triangle(parameterA, parameterB, parameterC);
            Assert.AreEqual(triangle.DetectTriangle(), 2);
        }

        [TestMethod]
        public void DetectTriangle_Isosceles_Restangular_tst()
        {
            parameterA = 2;
            parameterB = 2;
            parameterC = 2 * System.Math.Sqrt(2);
            Triangle triangle = new Triangle(parameterA, parameterB, parameterC);
            Assert.AreEqual(triangle.DetectTriangle(), 0);
        }

        [TestMethod]
        public void DetectTriangle_Ordinary_tst()
        {
            parameterA = 1;
            parameterB = 3;
            parameterC = 8 * System.Math.Sqrt(2);
            Triangle triangle = new Triangle(parameterA, parameterB, parameterC);
            Assert.AreEqual(triangle.DetectTriangle(), 4);
        }

        [TestMethod]
        public void CheckTriangle_Three_Positive_Integers_tst()
        {
            parameterA = 3;
            parameterB = 4;
            parameterC = 5;
            Triangle triangle = new Triangle(parameterA, parameterB, parameterC);
            Assert.IsTrue(triangle.CheckTriangle());
        }

        [TestMethod]
        public void CheckTriangle_One_Zero_Side_tst()
        {
            parameterA = 0;
            parameterB = 4;
            parameterC = 5;
            Triangle triangle = new Triangle(parameterA, parameterB, parameterC);
            Assert.IsFalse(triangle.CheckTriangle());
        }

        [TestMethod]
        public void CheckTriangle_All_Negative_Sides_tst()
        {
            parameterA = -3;
            parameterB = -4;
            parameterC = -5;
            Triangle triangle = new Triangle(parameterA, parameterB, parameterC);
            Assert.IsFalse(triangle.CheckTriangle());
        }

        [TestMethod]
        public void CheckTriangle_All_Sides_Equal_tst()
        {
            parameterA = 7;
            parameterB = 7;
            parameterC = 7;
            Triangle triangle = new Triangle(parameterA, parameterB, parameterC);
            Assert.IsTrue(triangle.CheckTriangle());
        }

        [TestMethod]
        public void CheckTriangle_Sum_Of_Two_Sides_Equal_To_Third_tst()
        {
            parameterA = 3;
            parameterB = 4;
            parameterC = 7;
            Triangle triangle = new Triangle(parameterA, parameterB, parameterC);
            Assert.IsFalse(triangle.CheckTriangle());
        }

        [TestMethod]
        public void CheckTriangle_All_Sides_Infinity_tst()
        {
            double infinity = double.PositiveInfinity;
            parameterA = infinity;
            parameterB = infinity;
            parameterC = infinity;
            Triangle triangle = new Triangle(parameterA, parameterB, parameterC);
            Assert.IsFalse(triangle.CheckTriangle());
        }

        [TestMethod]
        public void CheckTriangle_Sum_Of_Two_Sides_Less_Than_Third_tst()
        {
            parameterA = 10;
            parameterB = 5;
            parameterC = 2;
            Triangle triangle = new Triangle(parameterA, parameterB, parameterC);
            Assert.IsFalse(triangle.CheckTriangle());
        }

        [TestMethod]
        public void CheckTriangle_One_Side_NaN_tst()
        {
            double nan = double.NaN;
            parameterA = 5;
            parameterB = 12;
            parameterC = nan;
            Triangle triangle = new Triangle(parameterA, parameterB, parameterC);
            Assert.IsFalse(triangle.CheckTriangle());
        }
    }
}
