using AlgoritmoDibujarLineas.Logica;
 // Usamos Models, que es donde debe estar la lógica
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AlgoritmoDibujarLineas.View
{
    public partial class Mid_point_Circle_Generation_Algorithm : Form
    {
        // 1. ESTADO: Almacena los puntos generados por el Modelo.
        private List<Point> circlePoints = new List<Point>();

        public Mid_point_Circle_Generation_Algorithm()
        {
            // NO SE AÑADE NINGUNA LÍNEA AQUÍ, confiando en el diseñador.
            InitializeComponent();
        }

        // ----------------------------------------------------------------------
        // --- CONTROLADOR: Llama al Modelo ---
        // ----------------------------------------------------------------------
        private void drawButton_Click(object sender, EventArgs e)
        {
            // Validar la entrada del radio (asume txtRadio)
            if (!int.TryParse(txtRadio.Text, out int radius) || radius <= 0)
            {
                MessageBox.Show("Por favor, introduce un valor de radio entero positivo válido.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 1. Obtener el centro del área de dibujo (asume drawingPanel)
            int centerX = drawingPanel.Width / 2;
            int centerY = drawingPanel.Height / 2;

            // 2. LLAMAR AL MODELO
            circlePoints = MidpointCircleAlgorithm.GenerateCirclePoints(centerX, centerY, radius);

            // 3. Solicitar el repintado de la Vista
            drawingPanel.Invalidate();
        }

        // -------------------------------------------------------------
        // --- VISTA: Maneja el dibujo ---
        // -------------------------------------------------------------
        private void drawingPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen blackPen = new Pen(Color.Black);

            // Dibuja cada punto como un píxel (1x1)
            if (circlePoints != null && circlePoints.Count > 0)
            {
                foreach (Point p in circlePoints)
                {
                    g.DrawRectangle(blackPen, p.X, p.Y, 1, 1);
                }
            }
        }

        // Método de carga vacío, solo para completar la estructura:
        private void Mid_point_Circle_Generation_Algorithm_Load(object sender, EventArgs e)
        {
            // No se requiere código de inicialización aquí.
        }
    }
}