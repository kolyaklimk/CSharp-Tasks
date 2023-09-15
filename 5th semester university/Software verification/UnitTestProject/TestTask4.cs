using Lab_1.Task4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace UnitTestProject
{
    [TestClass]
    public class TestTask4
    {
        [TestMethod]
        public void TestGenerateHtml()
        {
            string result = Task4.GenerateHtml();
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
        }

        [TestMethod]
        public void TestCreateFile()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "file.html");

            Task4.CreateFile();

            Assert.IsTrue(File.Exists(filePath));

            File.Delete(filePath);
        }
    }
}
