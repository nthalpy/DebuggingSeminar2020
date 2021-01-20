using System;
using System.Collections;
using System.Collections.Generic;

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
            List<Circle> circles = new List<Circle>()
            {
                new Circle(1),
                new Circle(2),
                new Circle(3),
                new Circle(4),
            };

            Expand(circles);

            foreach (Circle c in circles)
                Console.WriteLine(c.Radius);
        }

        public static void Expand(IList shapes)
        {
            foreach (Object elem in shapes)
            {
                if (elem is IShape shape)
                    shape.Expand(1);
            }
        }
    }
}
