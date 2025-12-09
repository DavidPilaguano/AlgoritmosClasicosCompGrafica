using System.Collections.Generic;
using System.Drawing;
using System.Linq; // Agregado para usar .Reverse()

namespace AlgoritmoDibujarLineas.Logica
{
    public static class MidpointCircleAlgorithm
    {
        private static void PlotPoints(List<Point> points, int centerX, int centerY, int x, int y)
        {
            
            points.Add(new Point(centerX + x, centerY - y)); 
            points.Add(new Point(centerX + y, centerY - x)); 

            // Octante 2: Q1
            points.Add(new Point(centerX - x, centerY - y)); 
            points.Add(new Point(centerX - y, centerY - x));

            // Octante 3: Q2
            points.Add(new Point(centerX + x, centerY + y));
            points.Add(new Point(centerX + y, centerY + x)); 

            // Octante 4: Q3
            points.Add(new Point(centerX - x, centerY + y)); 
            points.Add(new Point(centerX - y, centerY + x)); 


           
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

            // Añadir el punto inicial (y sus 8 simetrías)
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

                // Añadir los 8 puntos generados en el paso actual
                PlotPoints(points, centerX, centerY, x, y);
            }

           

            return points;
        }
    }
}