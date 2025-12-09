using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System;
using System.Collections.Generic;

public class LineGraphicsHandler
{
    // Variables internas que almacenarán los datos del formulario
    private List<Point> _linePoints;
    private int _currentPointIndex;
    private int _minBmpX, _maxBmpX, _minBmpY, _maxBmpY;
    private const int GridSpacing = 1;

    public LineGraphicsHandler()
    {
        _linePoints = new List<Point>();
    }

    // Método público para recibir los datos de dibujo del formulario
    public void UpdateLineData(List<Point> points, int currentIndex, int minX, int maxX, int minY, int maxY)
    {
        _linePoints = points;
        _currentPointIndex = currentIndex;
        _minBmpX = minX;
        _maxBmpX = maxX;
        _minBmpY = minY;
        _maxBmpY = maxY;
    }

    // --- Método Principal de Dibujo ---
    public void Draw(Graphics g, int width, int height)
    {
        // 1. Calcular Zoom y Traslación
        var transform = CalculateAutoZoomAndPan(width, height);

        // 2. Aplicar Transformación y Limpiar
        ApplyTransformations(g, width, height, transform.OffsetX, transform.OffsetY, transform.ZoomFactor);

        // 3. Dibujar Cuadrícula y Ejes
        DrawGridAndAxes(g, width, height, transform.ZoomFactor);

        // 4. Dibujar los Cuadrantes Iluminados
        DrawLinePixels(g, width, height);

        // 5. Restablecer la Transformación
        g.ResetTransform();
    }

    // --- Estructura para almacenar los resultados del cálculo ---
    private class TransformData
    {
        public int ZoomFactor { get; set; } =1;
        public float OffsetX { get; set; } = 0f;
        public float OffsetY { get; set; } = 0f;
    }

    private TransformData CalculateAutoZoomAndPan(int width, int height)
    {
        var transform = new TransformData { ZoomFactor = 10 };

        if (!_linePoints.Any()) return transform;

        const int Margin = 20;
        int lineRangeX = (_maxBmpX - _minBmpX) + Margin;
        int lineRangeY = (_maxBmpY - _minBmpY) + Margin;

        if (lineRangeX < 1) lineRangeX = 1;
        if (lineRangeY < 1) lineRangeY = 1;

        int zoomX = width / lineRangeX;
        int zoomY = height / lineRangeY;
        transform.ZoomFactor = Math.Max(1, Math.Min(zoomX, zoomY));

        float lineCenterX = (_minBmpX + _maxBmpX) / 2.0f;
        float lineCenterY = (_minBmpY + _maxBmpY) / 2.0f;
        float viewCenterX = width / 2.0f;
        float viewCenterY = height / 2.0f;

        transform.OffsetX = viewCenterX - (lineCenterX * transform.ZoomFactor);
        transform.OffsetY = viewCenterY - (lineCenterY * transform.ZoomFactor);

        return transform;
    }

    private void ApplyTransformations(Graphics g, int width, int height, float offsetX, float offsetY, int zoomFactor)
    {
        g.ResetTransform();
        g.Clear(Color.White);

        g.TranslateTransform(offsetX, offsetY);
        g.ScaleTransform(zoomFactor, zoomFactor);
    }

    private void DrawLinePixels(Graphics g, int width, int height)
    {
        using (Brush blueBrush = new SolidBrush(Color.Blue))
        {
            for (int i = 0; i < _currentPointIndex && i < _linePoints.Count; i++)
            {
                Point p = _linePoints[i];
                // Dibuja un cuadrado de 1x1 que será escalado por g.ScaleTransform
                g.FillRectangle(blueBrush, p.X, p.Y, 1, 1);
            }
        }
    }

    private void DrawGridAndAxes(Graphics g, int width, int height, int currentZoom)
    {
        // Rango de la cuadrícula basado en los límites de la línea + margen
        int startX = Math.Min(_minBmpX, width / 2) - 5;
        int endX = Math.Max(_maxBmpX, width / 2) + 5;
        int startY = Math.Min(_minBmpY, height / 2) - 5;
        int endY = Math.Max(_maxBmpY, height / 2) + 5;

        int bmpCenterX = width / 2;
        int bmpCenterY = height / 2;

        // --- 1. Cuadrícula ---
        // Grosor ajustado inversamente al zoom para que se vea constante en pantalla
        using (Pen gridPen = new Pen(Color.LightGray, 1.0f / currentZoom))
        {
            for (int x = startX; x <= endX; x += GridSpacing)
            {
                g.DrawLine(gridPen, x, startY, x, endY);
            }
            for (int y = startY; y <= endY; y += GridSpacing)
            {
                g.DrawLine(gridPen, startX, y, endX, y);
            }
        }

        // --- 2. Ejes Cartesiano ---
        using (Pen axisPen = new Pen(Color.Black, 2.0f / currentZoom))
        {
            if (bmpCenterX >= startX && bmpCenterX <= endX)
            {
                g.DrawLine(axisPen, bmpCenterX, startY, bmpCenterX, endY);
            }
            if (bmpCenterY >= startY && bmpCenterY <= endY)
            {
                g.DrawLine(axisPen, startX, bmpCenterY, endX, bmpCenterY);
            }
        }
    }
}