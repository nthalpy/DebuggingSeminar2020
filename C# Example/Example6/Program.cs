using System;

namespace Example6
{
    internal interface IShape
    {
        void Expand(int delta);
    }

    internal static class Program
    {
        private static void Main()
        {
            Circle c = new Circle(3);

            ProcessShape(c);

            Console.WriteLine(c.Radius);
        }

        public static void ProcessShape(IShape shape)
        {
            Console.WriteLine($"Expanding Shape {shape.GetType().FullName}");

            shape.Expand(1);
        }
    }
}
