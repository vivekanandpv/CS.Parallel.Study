using System;
using System.Collections.Generic;
using System.Linq;

namespace CS.Parallel.Study
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  PLINQ is effectual after IEnumerable.AsParallel()
            //  The extension methods for PLINQ come from ParallelEnumerable static class
            //  https://learn.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.any?view=net-7.0

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);
            queue.Enqueue(7);
            queue.Enqueue(8);
            queue.Enqueue(9);
            queue.Enqueue(10);

            //  PLINQ applies partition/collation strategy
            //  Threading is handled internally by PLINQ
            List<int> newList = queue.AsParallel().Select(n => n * 1).ToList();
        }
    }
}
