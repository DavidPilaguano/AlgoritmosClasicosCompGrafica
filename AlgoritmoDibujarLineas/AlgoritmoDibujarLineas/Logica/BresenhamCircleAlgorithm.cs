using System.Collections.Generic;
using System.Drawing;

namespace AlgoritmoDibujarLineas.Logica
{
    public static class BresenhamCircleAlgorithm
    {
        private static void PlotPoints(List<Point> points, int centerX, int centerY, int x, int y)
        {
            points.Add(new Point(centerX + x, centerY + y));
            points.Add(new Point(centerX - x, centerY + y));
            points.Add(new Point(centerX + x, centerY - y));
            points.Add(new Point(centerX - x, centerY - y));

            points.Add(new Point(centerX + y, centerY + x));
            points.Add(new Point(centerX - y, centerY + x));
            points.Add(new Point(centerX + y, centerY - x));
            points.Add(new Point(centerX - y, centerY - x));
        }

        public static List<Point> GenerateCirclePoints(int centerX, int centerY, int radius)
        {
            var points = new List<Point>();
            int x = 0;
            int y = radius;
            int d = 3 - 2 * radius;

            PlotPoints(points, centerX, centerY, x, y);

            while (x < y)
            {
                x++;
                if (d < 0)
                {
                    d = d + 4 * x + 6;
                }
                else
                {
                    y--;
                    d = d + 4 * (x - y) + 10;
                }
                PlotPoints(points, centerX, centerY, x, y);
            }

            return points;
        }
    }
}