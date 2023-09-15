using Lab_1.Task5;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace UnitTestProject
{
    [TestClass]
    public class TestTask5
    {
        private const string TestDirectoryPath = @"C:\TestDirectory";

        [TestMethod]
        public void TestDirectoryExists_DirectoryExists()
        {
            Directory.CreateDirectory(TestDirectoryPath);
            bool result = Task5.DirectoryExists(TestDirectoryPath);
            Assert.IsTrue(result);
            Directory.Delete(TestDirectoryPath);
        }

        [TestMethod]
        public void TestDirectoryExists_DirectoryDoesNotExist()
        {
            string nonExistentDirectoryPath = @"C:\NonExistentDirectory";
            bool result = Task5.DirectoryExists(nonExistentDirectoryPath);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestExtensionExists_ExtensionExists()
        {
            string extension = "txt";
            bool result = Task5.ExtensionExists(extension);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestExtensionExists_ExtensionDoesNotExist()
        {
            string extension = "";
            bool result = Task5.ExtensionExists(extension);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestFind_FilesFound()
        {
            Directory.CreateDirectory(TestDirectoryPath);
            string testFilePath = Path.Combine(TestDirectoryPath, "test.txt");
            File.WriteAllText(testFilePath, "Test content");

            try
            {
                string result = Task5.Find(TestDirectoryPath, "txt");

                Assert.IsFalse(result.Contains(testFilePath));
            }
            finally
            {
                File.Delete(testFilePath);
                Directory.Delete(TestDirectoryPath);
            }
        }

        [TestMethod]
        public void TestFind_NoFilesFound()
        {
            Directory.CreateDirectory(TestDirectoryPath);

            try
            {
                using (StringWriter sw = new StringWriter())
                {
                    Console.SetOut(sw);
                    Task5.Find(TestDirectoryPath, "txt");
                    string consoleOutput = sw.ToString();

                    Assert.IsTrue(consoleOutput.Length == 0);
                }
            }
            finally
            {
                Directory.Delete(TestDirectoryPath);
            }
        }
    }
}
