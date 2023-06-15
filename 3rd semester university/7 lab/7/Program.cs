using System;
using System.Diagnostics;

namespace _7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IntegralSin sin = new IntegralSin();

            int top = 0;
            sin.getTime += (message) =>
            {
                Console.SetCursorPosition(0, top);
                Console.WriteLine("Поток " +
                    Thread.CurrentThread.ManagedThreadId +
                    ": Завершен с результатом: " +
                    message + "мс");
                top++;
            };

            sin.getProcess += (process, id, top) =>
            {
                string status = "Поток ";
                status += id.ToString() + ":[";

                for (int i = 0; i < 100; i++)
                {
                    if (i < process)
                    {
                        status += "=";
                    }
                    else if (i == process)
                    {
                        status += ">";
                    }
                    else
                    {
                        status += " ";
                    }
                }

                status += "] " + process.ToString() + "%";

                Console.SetCursorPosition(0, top);
                Console.WriteLine(status);
            };

            Thread myThread1 = new Thread(() => sin.Integral(5));
            myThread1.Priority = ThreadPriority.Highest;
            myThread1.Start();

            Thread myThread2 = new Thread(() => sin.Integral(6));
            myThread2.Priority = ThreadPriority.Lowest;
            myThread2.Start();

            Thread myThread3 = new Thread(() => sin.Integral(7));
            myThread3.Start();

            Thread myThread4 = new Thread(() => sin.Integral(8));
            myThread4.Start();

            Thread myThread5 = new Thread(() => sin.Integral(9));
            myThread5.Start();
            Console.ReadKey(false);
        }
    }
}