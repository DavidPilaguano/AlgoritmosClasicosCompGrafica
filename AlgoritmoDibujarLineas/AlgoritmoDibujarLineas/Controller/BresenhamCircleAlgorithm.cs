using System.Collections.Generic;
using System.Drawing;

namespace AlgoritmoDibujarLineas.Controller
{
    public static class BresenhamCircleAlgorithm
    {
        // Función auxiliar para dibujar los 8 puntos simétricos
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
            // Parámetro de decisión inicial de Bresenham
            int d = 3 - 2 * radius;

            // Primer punto
            PlotPoints(points, centerX, centerY, x, y);

            while (x < y)
            {
                x++;
                if (d < 0)
                {
                    // Elegimos el pixel E (Este)
                    d = d + 4 * x + 6;
                }
                else
                {
                    // Elegimos el pixel SE (Sureste)
                    y--;
                    d = d + 4 * (x - y) + 10;
                }
                PlotPoints(points, centerX, centerY, x, y);
            }

            return points;
        }
    }
}