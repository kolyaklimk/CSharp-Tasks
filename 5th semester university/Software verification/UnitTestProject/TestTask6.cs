using Lab_1.Task6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace UnitTestProject
{
    [TestClass]
    public class TestTask6
    {

        private const string TestDirectoryPath = @"C:\TestDirectory";
        private const string TestUrl = "https://i.ibb.co/Px6bGqg/1.png";

        [TestMethod]
        public void TestDirectoryExists_DirectoryExists()
        {
            Directory.CreateDirectory(TestDirectoryPath);
            bool result = Task6.DirectoryExists(TestDirectoryPath);
            Assert.IsTrue(result);
            Directory.Delete(TestDirectoryPath);
        }

        [TestMethod]
        public void TestDirectoryExists_DirectoryDoesNotExist()
        {
            string nonExistentDirectoryPath = @"C:\NonExistentDirectory";
            bool result = Task6.DirectoryExists(nonExistentDirectoryPath);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestUrlExists_UrlExists()
        {
            bool result = Task6.UrlExists(TestUrl);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestUrlExists_UrlDoesNotExist()
        {
            string nonExistentUrl = "https://www.nonexistenturl.com";
            bool result = Task6.UrlExists(nonExistentUrl);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestDownload_DownloadSucceeds()
        {
            Directory.CreateDirectory(TestDirectoryPath);
            string filePath = Path.Combine(TestDirectoryPath, "file.png");

            try
            {
                Task6.Download(TestUrl, TestDirectoryPath);
                Assert.IsTrue(File.Exists(filePath));
            }
            finally
            {
                File.Delete(filePath);
                Directory.Delete(TestDirectoryPath);
            }
        }

        [TestMethod]
        public void TestDownload_DownloadFails()
        {
            string nonExistentUrl = "https://www.nonexistenturl.com";
            string filePath = Path.Combine(TestDirectoryPath, "downloaded_file.txt");
            Task6.Download(nonExistentUrl, TestDirectoryPath);
            Assert.IsFalse(File.Exists(filePath));
        }
    }
}
