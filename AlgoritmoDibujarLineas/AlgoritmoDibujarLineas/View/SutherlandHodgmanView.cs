using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AlgoritmoDibujarLineas.Logica;

namespace AlgoritmoDibujarLineas.View
{
    public partial class SutherlandHodgmanView : Form
    {
        private List<PointF> _polygonVertices;
        private RectangleF _clippingWindow;
        private Random _random = new Random();

        public SutherlandHodgmanView()
        {
            InitializeComponent();
            this.Load += ClippingView_Load;
            drawingPanel.Paint += DrawingPanel_Paint;
        }

        private void ClippingView_Load(object sender, EventArgs e)
        {
            float w = drawingPanel.Width;
            float h = drawingPanel.Height;

            float clipWidth = 350;
            float clipHeight = 350;

            _clippingWindow = new RectangleF(
                (w - clipWidth) / 2,
                (h - clipHeight) / 2,
                clipWidth,
                clipHeight
            );

            GenerateRandomPolygon(w, h);
            drawingPanel.Invalidate();
        }

        private void GenerateRandomPolygon(float w, float h)
        {
            _polygonVertices = new List<PointF>();
            const int numVertices = 5;
            const int margin = 50;

            for (int i = 0; i < numVertices; i++)
            {
                float x = _random.Next(margin, (int)w - margin);
                float y = _random.Next(margin, (int)h - margin);
                _polygonVertices.Add(new PointF(x, y));
            }
        }

        private void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using (Pen clipPen = new Pen(Color.Red, 2))
            {
                g.DrawRectangle(clipPen, _clippingWindow.X, _clippingWindow.Y, _clippingWindow.Width, _clippingWindow.Height);
            }

            if (_polygonVertices != null && _polygonVertices.Count > 0)
            {
                using (Pen originalPen = new Pen(Color.Gray, 1))
                {
                    g.DrawPolygon(originalPen, _polygonVertices.ToArray());
                }

                List<PointF> clippedVertices = PolygonClippers.SutherlandHodgmanClip(
                    _polygonVertices,
                    _clippingWindow.Left,
                    _clippingWindow.Top,
                    _clippingWindow.Right,
                    _clippingWindow.Bottom
                );

                if (clippedVertices.Count > 2)
                {
                    using (SolidBrush clippedBrush = new SolidBrush(Color.FromArgb(120, Color.Blue)))
                    using (Pen clippedPen = new Pen(Color.Blue, 2))
                    {
                        g.FillPolygon(clippedBrush, clippedVertices.ToArray());
                        g.DrawPolygon(clippedPen, clippedVertices.ToArray());
                    }
                }
            }

            g.DrawString("Algoritmo: Sutherland-Hodgman", new Font("Arial", 10), Brushes.Black, 10, 10);
        }

        private void BtnGenerateNewPolygon_Click(object sender, EventArgs e)
        {
            GenerateRandomPolygon(drawingPanel.Width, drawingPanel.Height);
            drawingPanel.Invalidate();
        }
    }
}