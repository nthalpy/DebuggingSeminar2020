using System;
using System.Collections.Generic;
using System.Drawing;

namespace Example1
{
    internal static class Program
    {
        private static void Main()
        {
            List<Point> points = new List<Point>
            {
                new Point(0, 0),
                new Point(2, 0),
                new Point(0, 2)
            };

            Translate(points, 2, 3);

            for (int idx = 0; idx < points.Count; idx++)
                Console.WriteLine($"Point #{idx + 1}: ({points[idx].X}, {points[idx].Y})");
        }

        /// <summary>
        /// points 안의 Point들을 dx, dy만큼 이동시킨다.
        /// </summary>
        /// <param name="points">이동할 Point 객체들의 list</param>
        /// <param name="dx">Point.X의 변화량</param>
        /// <param name="dy">Point.Y의 변화량</param>
        private static void Translate(List<Point> points, int dx, int dy)
        {
            for (int idx = 0; idx < points.Count; idx++)
            {
                Point p = points[idx];

                p.X += dx;
                p.Y += dy;
            }
        }
    }
}
