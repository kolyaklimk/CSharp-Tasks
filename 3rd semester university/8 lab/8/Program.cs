using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using _8.Service;
using _8.Entities;
using LoremNET;

namespace Source
{
    public class Program
    {
        static IProgress<string> progress = new Progress<string>(s => Console.WriteLine(s));
        
        //рандом для создания объектов
        static Random random = new Random();

        static async Task Main(string[] args)
        {
            Computers[] computers = new Computers[1000];
                        
            // заполнение данными
            for (int i = 0; i < 1000; i++)
            {
                int rand = random.Next((int)1e5);
                computers[i] = new Computers(rand, Lorem.Words(100), (rand/(i+1))%2==0);
            }

            string fileName = "file.json";
            MyStreamService<Computers> streamService = new MyStreamService<Computers>();

            streamService.createNotify += (progress, id) =>
            {
                for (int i = 0; i <= 100; i += 10)
                {
                    progress?.Report(new string($"Thread {id}: {i} %"));
                }
            };

            MemoryStream stream = new MemoryStream();
                        
            Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId + " starts working");

            var task = streamService.WriteToStreamAsync(stream, computers, progress);

            await Task.Delay(100);

            var task2 = streamService.CopyFromStreamAsync(stream, fileName, progress);

            await Task.WhenAll(task2);

            int count = await streamService.GetStatisticsAsync(fileName, x => x.suitableBrand);
            Console.WriteLine(count);

        }
    }
}