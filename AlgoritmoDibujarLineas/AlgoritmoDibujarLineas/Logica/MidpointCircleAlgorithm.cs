using System.Collections.Generic;
using System.Drawing;
using System.Linq; // Agregado para usar .Reverse()

namespace AlgoritmoDibujarLineas.Logica
{
    public static class MidpointCircleAlgorithm
    {
        private static void PlotPoints(List<Point> points, int centerX, int centerY, int x, int y)
        {
            // La lista 'points' debe ser una secuencia ordenada para que la animación
            // y el LineGraphicsHandler los dibuje correctamente.

            // 1. Obtener los 8 puntos simétricos respecto al centro (centerX, centerY)
            // Se añaden en el orden más intuitivo para el recorrido de un octante completo,
            // que luego será usado por el LineGraphicsHandler para el zoom.

            // Octante 1 (0° a 45°): (x, y) y (y, x) en el cuadrante superior derecho.
            points.Add(new Point(centerX + x, centerY - y)); // Q4 (cerca del eje X)
            points.Add(new Point(centerX + y, centerY - x)); // Q4 (cerca del eje Y)

            // Octante 2: Q1
            points.Add(new Point(centerX - x, centerY - y)); // Q3 (cerca del eje X)
            points.Add(new Point(centerX - y, centerY - x)); // Q3 (cerca del eje Y)

            // Octante 3: Q2
            points.Add(new Point(centerX + x, centerY + y)); // Q1 (cerca del eje X)
            points.Add(new Point(centerX + y, centerY + x)); // Q1 (cerca del eje Y)

            // Octante 4: Q3
            points.Add(new Point(centerX - x, centerY + y)); // Q2 (cerca del eje X)
            points.Add(new Point(centerX - y, centerY + x)); // Q2 (cerca del eje Y)


            /* NOTA: El orden anterior puede repetirse si x=y, pero la clave es que 
             * LineGraphicsHandler (al usar el zoom y DrawLinePixels) dibujará todos los puntos
             * que estén en la lista hasta el índice actual (currentPointIndex).
             * Para la animación, la secuencia debe ser consistente. La forma más sencilla
             * es generar los 8 puntos en cada paso de Midpoint y dejar que el LineGraphicsHandler
             * gestione el dibujo del set completo de puntos.
            */

            // **Reemplazo la lógica de PlotPoints con una versión más sencilla y clara
            // que asegura que los 8 puntos se añadan en cada iteración.**
            // (Tu lógica original estaba bien para la generación, pero el orden es clave para la animación).

            // Tu lógica original:
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

            // Opcional: Eliminar puntos duplicados que se generan cuando x=y o en los ejes.
            // Para la animación y el zoom, generalmente es mejor dejarlos, pero si el rendimiento es clave:
            // return points.Distinct().ToList();

            return points;
        }
    }
}