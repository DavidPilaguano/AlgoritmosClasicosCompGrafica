using System.Collections.Generic;
using System.Drawing;

// Puedes poner esto en el namespace AlgoritmoDibujarLineas.Logica
public class BasicGraphicsHandler
{
    private List<Point> _points = new List<Point>();
    private Color _fillColor = Color.Green;
    private const int GridSpacing = 1;

    public void UpdateData(List<Point> points, Color fillColor)
    {
        _points = points;
        _fillColor = fillColor;
    }

    public void Draw(Graphics g, int width, int height)
    {
        // NO HAY g.Clear(Color.White)

        DrawGrid(g, width, height);
        DrawFillPoints(g); // Dibuja los puntos (aunque la vista ya los haya dibujado en el Bitmap)
    }

    private void DrawGrid(Graphics g, int width, int height)
    {
        using (Pen gridPen = new Pen(Color.LightGray, 0.1f))
        {
            for (int x = 0; x < width; x += GridSpacing)
            {
                g.DrawLine(gridPen, x, 0, x, height);
            }
            for (int y = 0; y < height; y += GridSpacing)
            {
                g.DrawLine(gridPen, 0, y, width, y);
            }
        }
    }

    private void DrawFillPoints(Graphics g)
    {
        using (Brush fillBrush = new SolidBrush(_fillColor))
        {
            foreach (var p in _points)
            {
                g.FillRectangle(fillBrush, p.X, p.Y, 1, 1);
            }
        }
    }
}