using System;
using System.Collections.Generic; // ¡Necesario para List<Point>!
using System.Drawing;
using System.Windows.Forms;

namespace AlgoritmoDibujarLineas.Logica
{
    internal class DDA_Controller
    {
        // CAMBIO: Ahora devuelve List<Point> y se llama CalculateLineDDA
        public List<Point> CalculateLineDDA(int x0, int y0, int x1, int y1)
        {
            List<Point> linePoints = new List<Point>();

            int dx = x1 - x0;
            int dy = y1 - y0;

            int steps = Math.Max(Math.Abs(dx), Math.Abs(dy));

            if (steps == 0)
            {
                linePoints.Add(new Point(x0, y0));
                return linePoints;
            }

            float xInc = dx / (float)steps;
            float yInc = dy / (float)steps;

            float x = x0;
            float y = y0;

            for (int i = 0; i <= steps; i++)
            {
                int xi = (int)Math.Round(x);
                int yi = (int)Math.Round(y);

                linePoints.Add(new Point(xi, yi));

                x += xInc;
                y += yInc;
            }

            return linePoints;
        }
    }
}