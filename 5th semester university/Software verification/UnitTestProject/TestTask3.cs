using Lab_1.Task3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class TestTask3
    {
        [TestMethod]
        public void TestCheckData_ValidInput()
        {
            string input = "5,0";
            double result = Task3.CheckData(input);
            Assert.AreEqual(5.0, result);
        }

        [TestMethod]
        public void TestCheckData_InvalidInput()
        {
            string input = "invalid";
            double result = Task3.CheckData(input);
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestCheckData_NegativeInput()
        {
            string input = "-5.0";
            double result = Task3.CheckData(input);
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestGetS_ValidInput()
        {
            double a = 5.0;
            double b = 2.0;
            string result = Task3.GetS(a, b);
            Assert.AreEqual("10", result);
        }

        [TestMethod]
        public void TestGetS_Error()
        {
            double a = double.MaxValue;
            double b = 2.0;
            string result = Task3.GetS(a, b);
            Assert.AreNotEqual("Error", result);
        }
    }
}
