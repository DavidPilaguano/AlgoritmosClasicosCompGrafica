using System;
using System.Drawing;
using System.Windows.Forms;

namespace AlgoritmoDibujarLineas.Logica
{
    internal class DDA_Controller
    {
        public void DrawLineDDA(Bitmap bmp, int x0, int y0, int x1, int y1, Color color)
        {
            if (bmp == null)
            {
                MessageBox.Show("ERROR");
                return;
            }

            int dx = x1 - x0;
            int dy = y1 - y0;

            int steps = Math.Max(Math.Abs(dx), Math.Abs(dy));
            if (steps == 0)
            {
                if (x0 >= 0 && x0 < bmp.Width && y0 >= 0 && y0 < bmp.Height)
                    bmp.SetPixel(x0, y0, color);
                return;
            }

            float xInc = dx / (float)steps;
            float yInc = dy / (float)steps;

            float x = x0;
            float y = y0;

            for (int i = 0; i <= steps; i++)
            {
                int xi = (int)Math.Round(x);
                int yi = (int)Math.Round(y);

                if (xi >= 0 && xi < bmp.Width && yi >= 0 && yi < bmp.Height)
                    bmp.SetPixel(xi, yi, color);

                x += xInc;
                y += yInc;
            }
        }
    }
}
