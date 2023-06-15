using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7
{
    internal class IntegralSin
    {
        public delegate void timeDelegate(long time);
        public delegate void processDelegate(int process, int id, int top);
        public event timeDelegate? getTime;
        public event processDelegate? getProcess;

        private Semaphore semaphore = new Semaphore(2, 2);
        static object locker = new object();

        public double Integral(int top)
        {
            semaphore.WaitOne();

            Stopwatch time = new Stopwatch();
            time.Start();

            double sin = 0;
            double step = 0.00001;
            int process = 0;

            for (double i = 0; i <= 1; i += step)
            {
                sin += Math.Sin(i);

                if (i * 100 > process)
                {
                    process = Convert.ToInt32(i * 100);
                    lock (locker)
                        getProcess?.Invoke(process, Thread.CurrentThread.ManagedThreadId, top);
                }
            }

            time.Stop();
            lock (locker)
                getTime?.Invoke(time.ElapsedMilliseconds);

            semaphore.Release();

            return sin * step;
        }
    }
}