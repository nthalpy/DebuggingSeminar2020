using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Example5
{
    internal static class Program
    {
        private static void Main()
        {
            const int threadNumber = 8;
            const int samplePerThread = 200000;
            const int randomMaxValue = 128;
            Random rd = new Random();

            int[] distribution = new int[randomMaxValue];

            // 빠른 반복을 위해 thread를 사용
            List<Thread> threads = new List<Thread>();
            for (int idx = 0; idx < threadNumber; idx++)
            {
                Thread thr = new Thread(() =>
                {
                    for (int iter = 0; iter < samplePerThread; iter++)
                    {
                        int val = rd.Next() % randomMaxValue;
                        distribution[val]++;
                    }
                });

                thr.Start();
                threads.Add(thr);
            }

            foreach (Thread thr in threads)
                thr.Join();

            for (int val = 0; val < distribution.Length; val++)
            {
                double percentage = 100.0 * distribution[val] / (samplePerThread * threadNumber);
                Console.WriteLine($"{val,3}: {distribution[val],6} ({percentage}%)");
            }

            Console.WriteLine($"Sum: {distribution.Sum()} ({100.0 * distribution.Sum() / (samplePerThread * threadNumber)}%)");
        }
    }
}
