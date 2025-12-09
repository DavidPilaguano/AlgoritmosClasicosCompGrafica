using System;
using System.Collections.Generic;
using System.Drawing;

namespace AlgoritmoDibujarLineas.Logica
{
    public class MidpointLineController
    {
        public List<Point> GenerarLinea(int x0, int y0, int x1, int y1)
        {
            List<Point> puntos = new List<Point>();

            int dx = x1 - x0;
            int dy = y1 - y0;

            int incX = dx >= 0 ? 1 : -1;
            int incY = dy >= 0 ? 1 : -1;

            dx = Math.Abs(dx);
            dy = Math.Abs(dy);

            int x = x0;
            int y = y0;

            // ——————————————
            // RUTA DOMINANTE EN X
            // ——————————————
            if (dx > dy)
            {
                int d = 2 * dy - dx;
                int incE = 2 * dy;          // Movimiento horizontal
                int incNE = 2 * (dy - dx);  // Movimiento diagonal

                puntos.Add(new Point(x, y));

                while (x != x1)
                {
                    x += incX;

                    if (d <= 0)
                    {
                        d += incE;
                    }
                    else
                    {
                        y += incY;
                        d += incNE;
                    }

                    puntos.Add(new Point(x, y));
                }
            }
            else
            {
                // ——————————————
                // RUTA DOMINANTE EN Y
                // ——————————————
                int d = 2 * dx - dy;
                int incE = 2 * dx;
                int incNE = 2 * (dx - dy);

                puntos.Add(new Point(x, y));

                while (y != y1)
                {
                    y += incY;

                    if (d <= 0)
                    {
                        d += incE;
                    }
                    else
                    {
                        x += incX;
                        d += incNE;
                    }

                    puntos.Add(new Point(x, y));
                }
            }

            return puntos;
        }
    }
}
