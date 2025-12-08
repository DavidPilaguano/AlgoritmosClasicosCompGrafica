using AlgoritmoDibujarLineas.Controller;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AlgoritmoDibujarLineas.View
{
    public partial class bresenhamsCircleGenerationAlgorithm : Form
    {
        private List<Point> circlePoints = new List<Point>();

        public bresenhamsCircleGenerationAlgorithm()
        {
            InitializeComponent();
            this.drawingPanel.Paint += new PaintEventHandler(DrawingPanel_Paint);
        }

        // --- CONTROLADOR: Método que genera los datos al hacer click ---
        private void drawButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtRadio.Text, out int radius) || radius <= 0)
            {
                MessageBox.Show("Por favor, introduce un valor de radio entero positivo válido.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Sale del método si la entrada es inválida
            }

            // 1. Definir el centro como el centro del Panel
            int centerX = drawingPanel.Width / 2;
            int centerY = drawingPanel.Height / 2;

            // Verificación opcional para evitar que el círculo se salga del panel
            if (radius > centerX || radius > centerY)
            {
                MessageBox.Show("El radio es demasiado grande para el tamaño del panel.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Opcionalmente, puedes reducir el radio aquí: radius = Math.Min(centerX, centerY) - 5;
            }

            // 2. Llamar al Modelo (Algoritmo)
            circlePoints = BresenhamCircleAlgorithm.GenerateCirclePoints(centerX, centerY, radius);

            // 3. Forzar el repintado de la Vista
            drawingPanel.Invalidate();
        }

        // --- VISTA/DIBUJO: Evento Paint (Igual que antes) ---
        private void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen blackPen = new Pen(Color.Black);

            if (circlePoints != null && circlePoints.Count > 0)
            {
                foreach (Point p in circlePoints)
                {
                    // Dibuja un píxel (1x1)
                    g.DrawRectangle(blackPen, p.X, p.Y, 1, 1);
                }
            }
        }
    }
}