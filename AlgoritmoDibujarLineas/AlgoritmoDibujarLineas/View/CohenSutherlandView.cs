using System;
using System.Drawing;
using System.Windows.Forms;
using AlgoritmoDibujarLineas.Logica; // Asegúrate de que este namespace es correcto

namespace AlgoritmoDibujarLineas.View
{
    public partial class CohenSutherlandView : Form
    {
        // Línea original
        private PointF _pOriginal1 = new PointF(50, 450);
        private PointF _pOriginal2 = new PointF(550, 50);

        // Ventana de recorte (Viewport)
        private RectangleF _clippingWindow;

        public CohenSutherlandView()
        {
            InitializeComponent();
            this.Load += CohenSutherlandView_Load;
            drawingPanel.Paint += DrawingPanel_Paint;
        }

        private void CohenSutherlandView_Load(object sender, EventArgs e)
        {
            // Definir la ventana de recorte en el centro
            float w = drawingPanel.Width;
            float h = drawingPanel.Height;

            // Ventana de 300x200 píxeles, centrada
            float clipWidth = 300;
            float clipHeight = 200;

            _clippingWindow = new RectangleF(
                (w - clipWidth) / 2,        // X Mínimo
                (h - clipHeight) / 2,       // Y Mínimo
                clipWidth,                  // Ancho
                clipHeight                  // Alto
            );

            // Generar una línea de ejemplo (o podrías generarla aleatoriamente)
            var random = new Random();
            _pOriginal1 = new PointF(random.Next(0, (int)w), random.Next(0, (int)h));
            _pOriginal2 = new PointF(random.Next(0, (int)w), random.Next(0, (int)h));

            drawingPanel.Invalidate();
        }

        private void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // 1. Dibujar la Ventana de Recorte
            using (Pen clipPen = new Pen(Color.Red, 2))
            {
                g.DrawRectangle(clipPen, _clippingWindow.X, _clippingWindow.Y, _clippingWindow.Width, _clippingWindow.Height);
            }

            // 2. Dibujar la Línea Original (color tenue o punteado)
            using (Pen originalPen = new Pen(Color.Gray, 1))
            {
                originalPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                g.DrawLine(originalPen, _pOriginal1, _pOriginal2);
            }

            // 3. Aplicar el Algoritmo de Recorte 
            ClippingResult result = LineClippers.CohenSutherlandClip(
                _pOriginal1,
                _pOriginal2,
                _clippingWindow.Left,
                _clippingWindow.Top,
                _clippingWindow.Right,
                _clippingWindow.Bottom
            );

            // 4. Dibujar el Resultado Recortado
            if (result.IsVisible)
            {
                using (Pen clippedPen = new Pen(Color.Blue, 3))
                {
                    g.DrawLine(clippedPen, result.P1, result.P2);
                }

                // Marcar los puntos recortados (opcional)
                g.FillEllipse(Brushes.Green, result.P1.X - 3, result.P1.Y - 3, 6, 6);
                g.FillEllipse(Brushes.Green, result.P2.X - 3, result.P2.Y - 3, 6, 6);
            }

            // Puedes añadir etiquetas aquí para mostrar qué algoritmo se está usando.
            g.DrawString("Algoritmo: Cohen-Sutherland", new Font("Arial", 10), Brushes.Black, 10, 10);

            // 
        }

        // Este método permite cambiar la línea y forzar el redibujo
        private void btnGenerateNewLine_Click(object sender, EventArgs e)
        {
            float w = drawingPanel.Width;
            float h = drawingPanel.Height;
            var random = new Random();
            _pOriginal1 = new PointF(random.Next(0, (int)w), random.Next(0, (int)h));
            _pOriginal2 = new PointF(random.Next(0, (int)w), random.Next(0, (int)h));
            drawingPanel.Invalidate();
        }
    }
}