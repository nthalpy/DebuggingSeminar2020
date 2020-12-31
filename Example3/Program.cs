using System;

namespace Example3
{
    internal class Program
    {
        private static void Main()
        {
            Random rd = new Random();

            for (int idx = 0; idx < 100; idx++)
            {
                float x = (float)rd.NextDouble();
                float y = (float)rd.NextDouble();

                float expected = Mult(x, y);

                if (expected != x * y)
                    Console.WriteLine($"Not matching! X:{x}, Y:{y}");
            }
        }

        private static float Mult(float x, float y)
        {
            return x * y;
        }
    }
}
