using System;
using System.Drawing;
using System.Windows.Forms;
using AlgoritmoDibujarLineas.Logica;

namespace AlgoritmoDibujarLineas.View
{
    public partial class NichollLeeNichollView : Form
    {
        private PointF _pOriginal1 = new PointF();
        private PointF _pOriginal2 = new PointF();

        private RectangleF _clippingWindow;
        private Random _random = new Random();

        public NichollLeeNichollView()
        {
            InitializeComponent();
            this.Load += ClippingView_Load;
            drawingPanel.Paint += DrawingPanel_Paint;
        }

        private void ClippingView_Load(object sender, EventArgs e)
        {
            float w = drawingPanel.Width;
            float h = drawingPanel.Height;

            float clipWidth = 300;
            float clipHeight = 200;

            _clippingWindow = new RectangleF(
                (w - clipWidth) / 2,
                (h - clipHeight) / 2,
                clipWidth,
                clipHeight
            );

            GenerateRandomLine();
            drawingPanel.Invalidate();
        }

        private void GenerateRandomLine()
        {
            float w = drawingPanel.Width;
            float h = drawingPanel.Height;

            _pOriginal1 = new PointF(_random.Next(0, (int)w), _random.Next(0, (int)h));
            _pOriginal2 = new PointF(_random.Next(0, (int)w), _random.Next(0, (int)h));
        }

        private void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using (Pen clipPen = new Pen(Color.Red, 2))
            {
                g.DrawRectangle(clipPen, _clippingWindow.X, _clippingWindow.Y, _clippingWindow.Width, _clippingWindow.Height);
            }

            using (Pen originalPen = new Pen(Color.Gray, 1))
            {
                originalPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                g.DrawLine(originalPen, _pOriginal1, _pOriginal2);
            }

            ClippingResult result = LineClippers.NichollLeeNichollClip(
                _pOriginal1,
                _pOriginal2,
                _clippingWindow.Left,
                _clippingWindow.Top,
                _clippingWindow.Right,
                _clippingWindow.Bottom
            );

            if (result.IsVisible)
            {
                using (Pen clippedPen = new Pen(Color.Blue, 3))
                {
                    g.DrawLine(clippedPen, result.P1, result.P2);
                }

                g.FillEllipse(Brushes.Green, result.P1.X - 3, result.P1.Y - 3, 6, 6);
                g.FillEllipse(Brushes.Green, result.P2.X - 3, result.P2.Y - 3, 6, 6);
            }

            g.DrawString("Algoritmo: Nicholl-Lee-Nicholl", new Font("Arial", 10), Brushes.Black, 10, 10);
        }

        private void BtnGenerateNewLine_Click(object sender, EventArgs e)
        {
            GenerateRandomLine();
            drawingPanel.Invalidate();
        }
    }
}