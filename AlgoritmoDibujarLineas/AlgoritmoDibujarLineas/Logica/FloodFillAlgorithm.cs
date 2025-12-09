using System.Collections.Generic;
using System.Drawing;

namespace AlgoritmoDibujarLineas.Logica
{
    public static class FloodFillAlgorithm
    {
        public static List<Point> Fill(int startX, int startY, Color fillColor, Bitmap canvas)
        {
            var filledPoints = new List<Point>();
            var q = new Queue<Point>();

            if (canvas == null) return filledPoints;

            int width = canvas.Width;
            int height = canvas.Height;

            if (startX < 0 || startX >= width || startY < 0 || startY >= height)
            {
                return filledPoints;
            }

           
            Color targetColor = canvas.GetPixel(startX, startY);

            
            if (targetColor.ToArgb() == fillColor.ToArgb())
            {
                return filledPoints;
            }

            q.Enqueue(new Point(startX, startY));

            while (q.Count > 0)
            {
                Point p = q.Dequeue();
                int x = p.X;
                int y = p.Y;

                
                if (x < 0 || x >= width || y < 0 || y >= height)
                {
                    continue;
                }

                Color pixelColor = canvas.GetPixel(x, y);

               
                if (pixelColor.ToArgb() == targetColor.ToArgb())
                {
                    filledPoints.Add(p);
                    canvas.SetPixel(x, y, fillColor);

                    
                    q.Enqueue(new Point(x + 1, y));
                    q.Enqueue(new Point(x - 1, y));
                    q.Enqueue(new Point(x, y + 1));
                    q.Enqueue(new Point(x, y - 1));
                }
            }
            return filledPoints;
        }
    }
}