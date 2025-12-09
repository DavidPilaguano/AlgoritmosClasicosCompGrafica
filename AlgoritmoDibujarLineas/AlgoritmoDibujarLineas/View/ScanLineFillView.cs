using AlgoritmoDibujarLineas.Logica;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AlgoritmoDibujarLineas.View
{
    public partial class ScanLineFillView : Form
    {
        private List<Point> _polygonVertices = new List<Point>();
        private List<Point> _filledPoints = new List<Point>();

        private Bitmap _drawingBitmap;
        private readonly LineGraphicsHandler _graphicsHandler = new LineGraphicsHandler();

        private Color _boundaryColor = Color.Black;
        private Color _fillColor = Color.Purple;
        private readonly Random _random = new Random();

        private int _currentPointIndex = 0;
        private int _minBmpX, _maxBmpX, _minBmpY, _maxBmpY;

        public ScanLineFillView()
        {
            // Se asume que InitializeComponent() existe y define drawingPanel, animationTimer, etc.
            InitializeComponent();

            LineGraphicsHandler.ShouldClearBackground = false;
            this.FormClosed += ScanLineFillView_FormClosed;

            this.Load += ScanLineFillView_Load;
            drawingPanel.Paint += DrawingPanel_Paint;

            animationTimer.Interval = 1;
            animationTimer.Tick += AnimationTimer_Tick;
        }

        private void ScanLineFillView_FormClosed(object sender, FormClosedEventArgs e)
        {
            LineGraphicsHandler.ShouldClearBackground = true;
        }

        private void ScanLineFillView_Load(object sender, EventArgs e)
        {
            InitializeDrawingBitmap();
        }


        private void InitializeDrawingBitmap()
        {
            if (drawingPanel.Width > 0 && drawingPanel.Height > 0)
            {
                _drawingBitmap?.Dispose();
                _drawingBitmap = new Bitmap(drawingPanel.Width, drawingPanel.Height);

                using (Graphics g = Graphics.FromImage(_drawingBitmap))
                {
                    g.Clear(Color.White);
                }

                _polygonVertices.Clear();
                ClearAnimationState();

                GenerateRandomPolygon();
                RedrawPolygonBoundary();
            }
        }

        private void GenerateRandomPolygon()
        {
            const int MinVertices = 5;
            const int MaxVertices = 10;

            int numVertices = _random.Next(MinVertices, MaxVertices + 1);
            int width = drawingPanel.Width;
            int height = drawingPanel.Height;

            // --- AJUSTES PARA POLÍGONOS MINÚSCULOS ---

            // Márgenes que definen el área central de trabajo.
            const int TotalMargin = 250; // Usaremos un solo margen grande para simplicidad
                                         // Esto deja un área central de (Width - 2*250)

            // El tamaño máximo de la figura se limitará al área restante.

            int minX = TotalMargin;
            int maxX = width - TotalMargin;
            int minY = TotalMargin;
            int maxY = height - TotalMargin;

            // ** CORRECCIÓN CLAVE: Verificar y reajustar los límites **
            // Si la diferencia entre los límites es demasiado pequeña o negativa, ajustamos.
            // Aseguramos que el rango sea de al menos 50 píxeles y que min < max.

            const int MinRange = 50;

            if (maxX - minX < MinRange)
            {
                // Si el área horizontal es demasiado pequeña, la centramos
                int center = width / 2;
                minX = center - MinRange / 2;
                maxX = center + MinRange / 2;
            }

            if (maxY - minY < MinRange)
            {
                // Si el área vertical es demasiado pequeña, la centramos
                int center = height / 2;
                minY = center - MinRange / 2;
                maxY = center + MinRange / 2;
            }

            // Asegurarse de que los límites estén dentro del panel:
            minX = Math.Max(0, minX);
            maxX = Math.Min(width, maxX);
            minY = Math.Max(0, minY);
            maxY = Math.Min(height, maxY);


            for (int i = 0; i < numVertices; i++)
            {
                // Generar puntos dentro del área central limitada
                // Nota: Random.Next(min, max) excluye max, lo cual es correcto.
                int x = _random.Next(minX, maxX);
                int y = _random.Next(minY, maxY);
                _polygonVertices.Add(new Point(x, y));
            }

            // ... (El resto del código para ordenar los vértices se mantiene igual) ...

            if (_polygonVertices.Count > 0)
            {
                Point center = new Point(
                    (int)_polygonVertices.Average(p => p.X),
                    (int)_polygonVertices.Average(p => p.Y)
                );

                _polygonVertices = _polygonVertices
                    .OrderBy(p => Math.Atan2(p.Y - center.Y, p.X - center.X))
                    .ToList();
            }
        }

        private void RedrawPolygonBoundary()
        {
            if (_drawingBitmap == null) return;

            using (Graphics g = Graphics.FromImage(_drawingBitmap))
            {
                if (!_filledPoints.Any())
                {
                    g.Clear(Color.White);
                }

                if (_polygonVertices.Count >= 3)
                {
                    using (Pen boundaryPen = new Pen(_boundaryColor, 2))
                    {
                        g.DrawPolygon(boundaryPen, _polygonVertices.ToArray());
                    }
                }

                using (SolidBrush brush = new SolidBrush(Color.Red))
                {
                    foreach (var p in _polygonVertices)
                    {
                        g.FillEllipse(brush, p.X - 3, p.Y - 3, 6, 6);
                    }
                }
            }
        }
        

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (_currentPointIndex < _filledPoints.Count)
            {
                // Determina cuántos puntos registrar por tick (lote)
                int step = Math.Max(1, _filledPoints.Count / 100);
                int newIndex = Math.Min(_filledPoints.Count, _currentPointIndex + step);

                // ** Registrar puntos en el historial **
                for (int i = _currentPointIndex; i < newIndex; i++)
                {
                    Point p = _filledPoints[i];
                    // Usamos AppendText para evitar reconstruir la caja de texto cada vez
                    txtPointsHistory.AppendText($"Punto: ({p.X}, {p.Y}){Environment.NewLine}");
                }

                _currentPointIndex = newIndex;
                lblCurrentPoint.Text = $"Puntos dibujados: {_currentPointIndex}/{_filledPoints.Count}";

                drawingPanel.Invalidate();
            }
            else
            {
                animationTimer.Stop();
                if (_filledPoints.Any())
                {
                    _minBmpX = _filledPoints.Min(p => p.X);
                    _maxBmpX = _filledPoints.Max(p => p.X);
                    _minBmpY = _filledPoints.Min(p => p.Y);
                    _maxBmpY = _filledPoints.Max(p => p.Y);
                    lblCurrentPoint.Text = $"¡Relleno Finalizado! Total: {_filledPoints.Count} puntos";
                }
                else
                {
                    lblCurrentPoint.Text = "Relleno Fallido (0 puntos).";
                }
                drawingPanel.Invalidate();
            }
        }

        private void ClearAnimationState()
        {
            _currentPointIndex = 0;
            animationTimer.Stop();
            _filledPoints.Clear();
            txtPointsHistory.Clear();
            lblCurrentPoint.Text = "Polígono listo.";
            _minBmpX = _maxBmpX = _minBmpY = _maxBmpY = 0;
        }


        private void btnFill_Click(object sender, EventArgs e)
        {
            if (_drawingBitmap == null || _polygonVertices.Count < 3)
            {
                MessageBox.Show("Polígono inválido.", "Error");
                return;
            }

            _drawingBitmap?.Dispose();
            _drawingBitmap = new Bitmap(drawingPanel.Width, drawingPanel.Height);

            ClearAnimationState();
            RedrawPolygonBoundary();

            try
            {
                // El algoritmo se ejecuta completamente (ScanLineFillAlgorithm.Fill debe devolver List<Point>)
                _filledPoints = ScanLineFillAlgorithm.Fill(
                    _polygonVertices,
                    _fillColor,
                    _drawingBitmap
                );

                if (_filledPoints.Count > 0)
                {
                    animationTimer.Start();
                }
                else
                {
                    lblCurrentPoint.Text = "Relleno Fallido (0 puntos).";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            InitializeDrawingBitmap();
            drawingPanel.Invalidate();
        }

        private void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            if (_drawingBitmap == null) return;

            Graphics g = e.Graphics;
            int width = drawingPanel.Width;
            int height = drawingPanel.Height;

            g.DrawImage(_drawingBitmap, 0, 0);

            _graphicsHandler.UpdateLineData(
                _filledPoints,
                _currentPointIndex,
                _minBmpX,
                _maxBmpX,
                _minBmpY,
                _maxBmpY
            );

            _graphicsHandler.Draw(g, width, height);
        }
    }
}