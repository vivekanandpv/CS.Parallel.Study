using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CS.Parallel.Study
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  PFX provides IProducerConsumerCollection<T> for producer-consumer purposes
            //  This is implemented by 3 classes
            //  ConcurrentBag
            //  ConcurrentStack
            //  ConcurrentQueue

            //  These classes allow concurrent reads and writes

            //  https://learn.microsoft.com/en-us/dotnet/api/system.collections.concurrent.iproducerconsumercollection-1?view=net-7.0

            //  For the classic case of Producer-consumer, PFX offers BlockingCollection<T>,
            //  which wraps around any class that implements IProducerConsumerCollection<T>.
            //  When you call TryTake(), instead of returning false, this collection blocks
            //  till the point the value is available.
            IProducerConsumerCollection<int> backingStore = new ConcurrentQueue<int>();
            

            BlockingCollection<int> blockingCollection = new BlockingCollection<int>(backingStore);

            var producer = Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(1000);

                    //  This is to demonstrate the delayed production
                    //  is waited by the consumer
                    if (i == 7)
                    {
                        Thread.Sleep(5000);
                    }

                    blockingCollection.TryAdd(i);
                }

                //  This way we conclude the producer side
                blockingCollection.CompleteAdding();
            });

            var consumer = Task.Run(() =>
            {
                //  Through the GetConsumingEnumerable() this iterator blocks till
                //  the next element is available
                foreach (var i in blockingCollection.GetConsumingEnumerable())
                {
                    Console.WriteLine($"Consumed: {i}");
                }
            });
            
            producer.Wait();
            consumer.Wait();
        }
    }
}
