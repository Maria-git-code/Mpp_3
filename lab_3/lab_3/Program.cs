using System;
using System.Threading;

namespace lab_3
{
    class Program
    {
        private static Mutex mutex = new Mutex();
        static void Main(string[] args)
        {
           
            for(int i = 0; i < 5; i++)
            {
                Thread thread = new Thread(print);
                thread.Start();
            }
            Console.ReadLine();
        }

        public static void print()
        {
            mutex.Lock();
            Console.WriteLine("Start thread " + Thread.CurrentThread.ManagedThreadId);
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine("thread " + Thread.CurrentThread.ManagedThreadId + " step " + i);
                Thread.Sleep(100);
            }
            Console.WriteLine("Finish thread " + Thread.CurrentThread.ManagedThreadId);
            mutex.Unlock();
        }
    }
}