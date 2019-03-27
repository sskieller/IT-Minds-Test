using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace StringIssue
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Filling array: ");
            var strings = Enumerable.Range(0, 40000).Select(s => s.ToString());
            var enumerable = strings.ToList();
            const int runTimes = 5;

            long avgPercent = 0;

            for (var i = 0; i < runTimes; i++)
            {
                var oldTime = PrintFunctionTimes(enumerable, StringHelpers.OldMergeStrings);
                Thread.Sleep(100);
                var newTime = PrintFunctionTimes(enumerable, StringHelpers.MergeStrings);
                Thread.Sleep(50);

                avgPercent += (oldTime / newTime * 100);
            }

            Console.WriteLine($"MergeString is on average {avgPercent / runTimes}% faster than OldMergeString");

            Console.ReadLine();
        }

        public static long PrintFunctionTimes(
            IEnumerable<string> strings, Func<IEnumerable<string>, string> myFunc)
        {
            Console.WriteLine($"Executing String-Helper method {myFunc.Method.Name}: ");

            var sw = new Stopwatch();

            sw.Start();
            var output = myFunc(strings);
            sw.Stop();

            Console.WriteLine($"Length: {output.Length}");
            Console.WriteLine("Elapsed time: " + sw.ElapsedMilliseconds);
            Console.WriteLine("Elapsed time in ticks: " + sw.ElapsedTicks);

            return sw.ElapsedTicks;
        }
    }
}