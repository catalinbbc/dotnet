namespace DemoSum
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Numerics;
    using System.Threading;

    internal class Program
    {
        static CountdownEvent _countdown;
        public static void Main(string[] args)
        {
            var arraySize = 50000000; // 50 000 000
            var array = BuildAnArray(arraySize);

            int nrThreads = 4;
            BigInteger totalSum = 0;
            int dataSplitAt = arraySize / nrThreads;
            _countdown = new CountdownEvent(nrThreads);

            var stopwatch = Stopwatch.StartNew();
            ArrayProcessor[] arrayProcessors = new ArrayProcessor[nrThreads];
            for (int i = 0; i < nrThreads; i++)
            {
                arrayProcessors[i] = new ArrayProcessor(array, dataSplitAt * i, dataSplitAt);
                new Thread(arrayProcessors[i].CalculateSum).Start();
            }

            _countdown.Wait();   // Blocks until Signal has been called nrThreads times

            for (int i = 0; i < nrThreads; i++)
            {
                totalSum += arrayProcessors[i].Sum;
            }


            stopwatch.Stop();

            Console.WriteLine($"Elapsed time: {stopwatch.Elapsed.TotalMilliseconds} ms");
            Console.WriteLine($"Sum: {totalSum}");
        }

        public static int[] BuildAnArray(int size)
        {
            var array = new int[size];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }

            return array;
        }
    }
}
