using Lab_1.Task2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class TestTask2
    {
        [TestMethod]
        public void TestCheckData_ValidInput()
        {
            string input = "John Doe 30";

            Human result = Task2.CheckData(input);

            Assert.IsNotNull(result);
            Assert.AreEqual("John", result.Name);
            Assert.AreEqual("Doe", result.Surname);
            Assert.AreEqual(30, result.Age);
        }

        [TestMethod]
        public void TestCheckData_InvalidInput()
        {
            string input = "InvalidInput";

            Human result = Task2.CheckData(input);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestLowAge()
        {
            List<Human> humans = new List<Human>
            {
                new Human { Name = "Alice", Surname = "Johnson", Age = 25 },
                new Human { Name = "Bob", Surname = "Smith", Age = 30 },
                new Human { Name = "Charlie", Surname = "Brown", Age = 20 }
            };

            int result = Task2.LowAge(humans);

            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void TestHightAge()
        {
            List<Human> humans = new List<Human>
            {
                new Human { Name = "Alice", Surname = "Johnson", Age = 25 },
                new Human { Name = "Bob", Surname = "Smith", Age = 30 },
                new Human { Name = "Charlie", Surname = "Brown", Age = 20 }
            };

            int result = Task2.HightAge(humans);

            Assert.AreEqual(30, result);
        }

        [TestMethod]
        public void TestAverageAge()
        {
            List<Human> humans = new List<Human>
            {
                new Human { Name = "Alice", Surname = "Johnson", Age = 25 },
                new Human { Name = "Bob", Surname = "Smith", Age = 30 },
                new Human { Name = "Charlie", Surname = "Brown", Age = 20 }
            };

            double result = Task2.AverageAge(humans);

            Assert.AreEqual(25.0, result);
        }
    }
}
