using System;
using System.Linq;

namespace Example2
{
    internal static class Program
    {
        private static void Main()
        {
            int[] original = new int[] { 1, 2, 3, 4, 5, 1, 2, 3, 4, 5 };
            int[] removeTarget = new int[] { 1, 4 };

            int[] result = original.Except(removeTarget).ToArray();

            Console.WriteLine($"{result.Length} elements has remained.");
        }
    }
}
