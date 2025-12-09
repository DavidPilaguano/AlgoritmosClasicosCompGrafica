using AlgoritmoDibujarLineas.Logica;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AlgoritmoDibujarLineas.View
{
    public partial class BoundaryFillView : Form
    {
        private List<Point> _filledPoints = new List<Point>();
        private Bitmap _drawingBitmap;
        private readonly LineGraphicsHandler _graphicsHandler = new LineGraphicsHandler();

        private Color _boundaryColor = Color.Red;
        private Color _fillColor = Color.Green;
        private readonly Random _random = new Random();

        // Variables de Animación y Límites para Autoajuste
        private int _currentPointIndex = 0;
        private int _minBmpX, _maxBmpX, _minBmpY, _maxBmpY;
        private Point _suggestedSeedPoint = Point.Empty;

        // Los componentes de la UI (txtPointsHistory, lblCurrentPoint, etc.)
        // NO se declaran aquí, ya que están en el archivo Designer.cs.

        public BoundaryFillView()
        {
            InitializeComponent();

            LineGraphicsHandler.ShouldClearBackground = false;
            this.FormClosed += BoundaryFillView_FormClosed;

            this.Load += BoundaryFillView_Load;
            drawingPanel.Paint += DrawingPanel_Paint;

            // Suponemos que animationTimer existe.
            animationTimer.Interval = 5;
            animationTimer.Tick += AnimationTimer_Tick;
        }

        private void BoundaryFillView_FormClosed(object sender, FormClosedEventArgs e)
        {
            LineGraphicsHandler.ShouldClearBackground = true;
        }

        private void BoundaryFillView_Load(object sender, EventArgs e)
        {
            InitializeDrawingBitmap();
        }

        // ----------------------------------------------------------------------------------
        // ## 🎨 Inicialización y Generación de Figuras Aleatorias con Semilla Random
        // ----------------------------------------------------------------------------------
        private void InitializeDrawingBitmap()
        {
            if (drawingPanel.Width > 0 && drawingPanel.Height > 0)
            {
                _drawingBitmap?.Dispose();
                _drawingBitmap = new Bitmap(drawingPanel.Width, drawingPanel.Height);

                using (Graphics g = Graphics.FromImage(_drawingBitmap))
                {
                    g.Clear(Color.White);

                    int shapeType = _random.Next(3);
                    int width = drawingPanel.Width;
                    int height = drawingPanel.Height;
                    int size = _random.Next(50, (int)Math.Min(width, height) / 3);

                    int randX = _random.Next(size + 10, width - size - 10);
                    int randY = _random.Next(size + 10, height - size - 10);

                    using (Pen boundaryPen = new Pen(_boundaryColor, 2))
                    {
                        switch (shapeType)
                        {
                            case 0: // Círculo
                                int radius = size / 2;
                                g.DrawEllipse(boundaryPen, randX - radius, randY - radius, size, size);
                                int randomAngle = _random.Next(360);
                                int randomDist = _random.Next(radius - 5);
                                int seedX = (int)(randX + randomDist * Math.Cos(randomAngle * Math.PI / 180));
                                int seedY = (int)(randY + randomDist * Math.Sin(randomAngle * Math.PI / 180));
                                _suggestedSeedPoint = new Point(seedX, seedY);
                                break;

                            case 1: // Rectángulo
                                g.DrawRectangle(boundaryPen, randX, randY, size, size);
                                int rectMinX = randX + 2;
                                int rectMaxX = randX + size - 2;
                                int rectMinY = randY + 2;
                                int rectMaxY = randY + size - 2;
                                seedX = _random.Next(rectMinX, rectMaxX);
                                seedY = _random.Next(rectMinY, rectMaxY);
                                _suggestedSeedPoint = new Point(seedX, seedY);
                                break;

                            case 2: // Triángulo
                                Point p1 = new Point(randX, randY);
                                Point p2 = new Point(randX + size, randY);
                                Point p3 = new Point(randX + size / 2, randY - size);
                                Point[] points = { p1, p2, p3 };
                                g.DrawPolygon(boundaryPen, points);
                                int triMidX = randX + size / 2;
                                int triMinY = randY - size + 5;
                                int triMaxY = randY - 5;
                                seedY = _random.Next(triMinY, triMaxY);
                                _suggestedSeedPoint = new Point(triMidX, seedY);
                                break;
                        }
                    }
                }

                ClearAnimationState();
            }
        }

        // ----------------------------------------------------------------------------------
        // ## ⏳ Gestión del Timer y Animación
        // ----------------------------------------------------------------------------------
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (_currentPointIndex < _filledPoints.Count)
            {
                Point p = _filledPoints[_currentPointIndex];

                // Usamos los controles definidos en el diseñador
                txtPointsHistory.AppendText($"Punto: ({p.X}, {p.Y}){Environment.NewLine}");
                lblCurrentPoint.Text = $"Rellenando: {_currentPointIndex + 1}/{_filledPoints.Count}";

                _drawingBitmap.SetPixel(p.X, p.Y, _fillColor);

                _currentPointIndex++;
                drawingPanel.Invalidate();
            }
            else
            {
                animationTimer.Stop();
                lblCurrentPoint.Text = "¡Relleno Finalizado!";
            }
        }

        private void ClearAnimationState()
        {
            _currentPointIndex = 0;
            animationTimer.Stop();
            txtPointsHistory.Clear();
            lblCurrentPoint.Text = "Listo para rellenar";
            _minBmpX = _maxBmpX = _minBmpY = _maxBmpY = 0;
        }

        // ----------------------------------------------------------------------------------
        // ## ▶️ Controladores de Botones
        // ----------------------------------------------------------------------------------

        private void btnFill_Click(object sender, EventArgs e)
        {
            if (_drawingBitmap == null) return;

            // La semilla se toma directamente del punto aleatorio generado
            int startX = _suggestedSeedPoint.X;
            int startY = _suggestedSeedPoint.Y;

            Bitmap tempBitmapForCalculation = (Bitmap)_drawingBitmap.Clone();

            try
            {
                _filledPoints = BoundaryFillAlgorithm.Fill(
                    startX,
                    startY,
                    _boundaryColor,
                    _fillColor,
                    tempBitmapForCalculation
                );
                tempBitmapForCalculation.Dispose();

                if (!_filledPoints.Any())
                {
                    MessageBox.Show($"El algoritmo no pudo rellenar. Semilla usada: ({startX}, {startY})", "Fallo de Relleno");
                    return;
                }

                // Calcular límites para el Autoajuste
                _minBmpX = _filledPoints.Min(p => p.X);
                _maxBmpX = _filledPoints.Max(p => p.X);
                _minBmpY = _filledPoints.Min(p => p.Y);
                _maxBmpY = _filledPoints.Max(p => p.Y);

                // Iniciar la animación
                ClearAnimationState();
                animationTimer.Start();
                drawingPanel.Invalidate();

            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show($"Error de límites: {ex.Message}");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            InitializeDrawingBitmap();
            ClearAnimationState();
            drawingPanel.Invalidate();
        }

        // ----------------------------------------------------------------------------------
        // ## 🖼️ Vista (Paint)
        // ----------------------------------------------------------------------------------

        private void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            if (_drawingBitmap == null) return;

            Graphics g = e.Graphics;
            int width = drawingPanel.Width;
            int height = drawingPanel.Height;

            // 1. Dibuja el Bitmap (Figura y píxeles animados)
            g.DrawImage(_drawingBitmap, 0, 0);

            // 2. Configurar y dibujar la cuadrícula/zoom
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