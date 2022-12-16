using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CS.Parallel.Study
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  .NET's Task Parallel Library provides Parallel class
            //  for data parallelization requirements

            //  For range based iteration
            System.Threading.Tasks.Parallel.For(1, 10, n =>
            {
                Console.WriteLine($"Running Parallel.For; Thread Id: {Thread.CurrentThread.ManagedThreadId}");
            });

            //  For collection based iteration
            System.Threading.Tasks.Parallel.ForEach(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, n =>
            {
                Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}, Number: {n}");
            });
        }
    }
}
