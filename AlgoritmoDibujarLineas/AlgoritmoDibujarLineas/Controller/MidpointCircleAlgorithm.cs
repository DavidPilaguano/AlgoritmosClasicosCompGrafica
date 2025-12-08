using System.Collections.Generic;
using System.Drawing;

namespace AlgoritmoDibujarLineas.Controller
{
    public static class MidpointCircleAlgorithm
    {
        private static void PlotPoints(List<Point> points, int centerX, int centerY, int x, int y)
        {
            // Aplica la simetría de ocho vías para el dibujo
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

            // Parámetro de decisión inicial: P0 = 1 - r
            int p = 1 - radius;

            PlotPoints(points, centerX, centerY, x, y);

            while (x < y)
            {
                x++;
                if (p < 0)
                {
                    // Elegir E: p_next = p + 2x + 1
                    p = p + 2 * x + 1;
                }
                else
                {
                    // Elegir SE: p_next = p + 2x - 2y + 1
                    y--;
                    p = p + 2 * (x - y) + 1;
                }
                PlotPoints(points, centerX, centerY, x, y);
            }

            return points;
        }
    }
}