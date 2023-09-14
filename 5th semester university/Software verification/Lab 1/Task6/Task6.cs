using Lab_1.Other;
using System;
using System.IO;
using System.Net.Http;

namespace Lab_1.Task6
{
    public static class Task6
    {
        public static void StartTask()
        {
            MyConsole.printTasks(6);
            Work();
        }

        public static bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        public static bool UrlExists(string url)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = httpClient.GetAsync(url).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static void Download(string url, string path)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = httpClient.GetAsync(url).Result;

                    string exists = "";

                    if (response.IsSuccessStatusCode)
                    {
                        exists = response.Content.Headers.ContentType.MediaType.Split('/')[1];
                    }
                    else
                    {
                        exists = "txt";
                    }

                    string fileName = $"file.{exists}";

                    string fullPath = Path.Combine(path, fileName);

                    int a = 0;
                    while (File.Exists(fullPath))
                    {
                        fullPath = Path.Combine(path, a++ + "_" + fileName);
                    }

                    using (var stream = response.Content.ReadAsStreamAsync().Result)
                    {
                        // Теперь у вас есть поток данных, который можно сохранить в файл
                        using (var fileStream = File.Create(fullPath)) // Замените на свой путь и имя файла
                        {
                            stream.CopyTo(fileStream);
                        }
                    }
                }
            }
            catch
            {
            }
        }

        public static void Work()
        {
            string url;
            while (true)
            {
                Console.WriteLine("Print url:");
                url = Console.ReadLine();
                if (UrlExists(url))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Error, try again");
                }
            }

            string path;
            while (true)
            {
                Console.WriteLine("Print directory path (For example: c:/dir1/dir2/ ) :");
                path = Console.ReadLine();
                if (DirectoryExists(path))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Error, try again");
                }
            }

            Download(url, path);
            Console.WriteLine("Done");
        }
    }
}
