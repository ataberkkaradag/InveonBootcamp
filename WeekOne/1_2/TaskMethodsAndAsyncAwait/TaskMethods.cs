using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMethodsAndAsyncAwait
{
    internal class TaskMethods
    {
        public async Task TaskWhenAll()
        {
            var stopwatch = Stopwatch.StartNew();
            Task task1 = Task.Run(() => Task.Delay(2000));
            Console.WriteLine("Task 1 başladı");

            Task task2 = Task.Run(() => Task.Delay(5000));
            Console.WriteLine("Task 2 başladı");

            await Task.WhenAll(task1, task2);
            stopwatch.Stop();
            Console.WriteLine($"{stopwatch.ElapsedMilliseconds}");
            Console.WriteLine("Tasklar bitti");
        }

        public async Task TaskWaitAll()                   //WhenAll asenkronken Wait all senkron metotdur threadi blocklar
        {
            var stopwatch = Stopwatch.StartNew();
            Task task1 = Task.Run(() => Task.Delay(3000));
            Console.WriteLine("Task 1 başladı");

            Task task2 = Task.Run(() => Task.Delay(5000));
            Console.WriteLine("Task 2 başladı");

            Task.WaitAll(task1, task2);
            stopwatch.Stop();
            Console.WriteLine($"{stopwatch.ElapsedMilliseconds}");
            Console.WriteLine("Tasklar bitti");
        }

        public async Task TaskWhenAny()
        {
            var stopwatch = Stopwatch.StartNew();
            Task task1 = Task.Run(() => Task.Delay(3000));
            Console.WriteLine("Task 1 başladı");

            Task task2 = Task.Run(() => Task.Delay(5000));
            Console.WriteLine("Task 2 başladı");

            await Task.WhenAny(task1, task2);
            stopwatch.Stop();
            Console.WriteLine($"{stopwatch.ElapsedMilliseconds}");
            Console.WriteLine("Tasklardan biri yada fazlası bitti");
        }

        public async Task TaskFromResult()
        {
            Task<int> task = Task.FromResult(100 / 2);

            int result = await task;

            Console.WriteLine($"{result}");
        }



        public async Task TaskYield()
        {
            for (int i = 0; i < 3; i++)
            {
                await Task.Yield();
                Console.WriteLine($"Yielded i: {i}");
            }
        }
    }
}
