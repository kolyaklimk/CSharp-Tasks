using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace _8.Service
{
    internal class MyStreamService<T>
    {
        public delegate void notify(IProgress<string> message, int id);
        public event notify? createNotify;

        Semaphore semaphore = new Semaphore(1, 1);

        // записывает коллекцию data в поток stream
        public async Task WriteToStreamAsync(Stream stream, IEnumerable<T> data, IProgress<string> progress)
        {
            // ожидаение получения свободного места
            semaphore.WaitOne();
                        
            Console.Write("Start writing. Thread: " + Thread.CurrentThread.ManagedThreadId + '\n');

            var p = new Progress<string>(m =>
            {
                Console.Write($"\r{m}");
            });

            createNotify?.Invoke(p, Thread.CurrentThread.ManagedThreadId);
            
            await JsonSerializer.SerializeAsync(stream, data);
            
            Console.Write("\nEnd writing. Thread: " + Thread.CurrentThread.ManagedThreadId + '\n');

            // освобождение места
            semaphore.Release();
        }

        //копирует информацию из потока stream в файл с именем fileName
        public async Task CopyFromStreamAsync(Stream stream, string fileName, IProgress<string> progress)
        {
            semaphore.WaitOne();

            Console.Write("Start reading. Thread: " + Thread.CurrentThread.ManagedThreadId + '\n');

            using (FileStream file = new FileStream(fileName, FileMode.Create))
            {
                stream.Position = 0;

                var p = new Progress<string>(m =>
                {
                    Console.Write($"\r{m}");
                });

                createNotify?.Invoke(p, Thread.CurrentThread.ManagedThreadId);

                await stream.CopyToAsync(file);
            }

            Console.Write("\nEnd reading. Thread: " + Thread.CurrentThread.ManagedThreadId + '\n');

            semaphore.Release();
        }

        // считывает объекты типа Т из файла с именем
        // filename и возвращает количество объектов,
        // удовлетворяющих условию filter
        public async Task<int> GetStatisticsAsync(string fileName, Func<T, bool> filter)
        {
            FileStream file = new FileStream(fileName, FileMode.Open);

            IEnumerable<T> temp = await JsonSerializer.DeserializeAsync<IEnumerable<T>>(file);

            return temp.Where(filter).Count();
        }
    }
}
