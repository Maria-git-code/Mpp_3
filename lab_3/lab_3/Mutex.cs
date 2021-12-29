using System;
using System.Threading;

namespace lab_3
{
    public class Mutex
    {
        private int _lockThreadId ;

        public void Lock()
        {
            while(Interlocked.CompareExchange(ref _lockThreadId, Thread.CurrentThread.ManagedThreadId, 0) != 0)
            {
                Thread.Sleep(100);
            }
        }

        public void Unlock()
        {
            Interlocked.CompareExchange(ref _lockThreadId, 0, Thread.CurrentThread.ManagedThreadId);
        }
    }
}