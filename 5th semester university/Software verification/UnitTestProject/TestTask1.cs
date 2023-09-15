using Lab_1.Task1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class TestTask1
    {
        [TestMethod]
        public void TestTask1_1TestGenerateStringContainsHelloWorld()
        {
            string result = Task1.GenerateString();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("Hello, world!"));
        }

        [TestMethod]
        public void TestGenerateStringContainsAndhiagain()
        {
            string result = Task1.GenerateString();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("Andhiagain!"));
        }

        [TestMethod]
        public void TestGenerateStringExclamationCountInRange()
        {
            int minCharacters = 5;
            int maxCharacters = 50;

            string result = Task1.GenerateString();

            Assert.IsNotNull(result);

            string[] lines = result.Split('\n');
            string lastLine = lines[2].Trim();
            int exclamationCount = lastLine.Length;
            Assert.IsTrue(exclamationCount >= minCharacters && exclamationCount <= maxCharacters);
        }
    }
}
