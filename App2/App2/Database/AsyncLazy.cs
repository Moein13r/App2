using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace App2.Database
{
    internal class AsyncLazy<T>
    {
        readonly Lazy<Task<T>> instance;
        public AsyncLazy(Func<T> task)
        {
            instance = new Lazy<Task<T>>(() => Task.Run(task));
        }
        public AsyncLazy(Func<Task<T>>task)
        {
            instance = new Lazy<Task<T>>(() => Task.Run(task));
        }
        public TaskAwaiter<T> GetAwaiter()
        {
            return instance.Value.GetAwaiter();
        }
    }   
}
