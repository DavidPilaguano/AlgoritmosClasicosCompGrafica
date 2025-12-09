using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoDibujarLineas.Logica
{
    public class MidpointCircleController
    {

        public List<Point> CalcularCircunferencia(int xc, int yc, int r)
        {
            List<Point> pixels = new List<Point>();

            int x = 0;
            int y = r;

            // p0 = 1 - r
            int p = 1 - r;

            AgregarOctetos(pixels, xc, yc, x, y);

            while (x < y)
            {
                x++;

                if (p < 0)
                {
                    // Punto medio dentro del círculo: Este
                    p = p + (2 * x) + 1;
                }
                else
                {
                    // Punto medio fuera o sobre el círculo: Sur-Este
                    y--;
                    p = p + (2 * (x - y)) + 1;
                }

                AgregarOctetos(pixels, xc, yc, x, y);
            }

            return pixels;
        }

        private void AgregarOctetos(List<Point> lista, int xc, int yc, int x, int y)
        {
            lista.Add(new Point(xc + x, yc + y));
            lista.Add(new Point(xc - x, yc + y));
            lista.Add(new Point(xc + x, yc - y));
            lista.Add(new Point(xc - x, yc - y));

            lista.Add(new Point(xc + y, yc + x));
            lista.Add(new Point(xc - y, yc + x));
            lista.Add(new Point(xc + y, yc - x));
            lista.Add(new Point(xc - y, yc - x));
        }
    }
}