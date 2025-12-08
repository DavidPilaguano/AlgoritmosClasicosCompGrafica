using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AlgoritmoDibujarLineas.Controller;

namespace AlgoritmoDibujarLineas.View
{
    public partial class Mid_pointLineGeneration : Form
    {
        private MidpointLineController controller;

        public Mid_pointLineGeneration()
        {
            InitializeComponent();
            controller = new MidpointLineController();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                // Tomar inputs
                int x0 = int.Parse(txtX0.Text);
                int y0 = int.Parse(txtY0.Text);
                int x1 = int.Parse(txtX1.Text);
                int y1 = int.Parse(txtY1.Text);

                // Calcular puntos
                List<Point> puntos = controller.GenerarLinea(x0, y0, x1, y1);

                // Crear bitmap
                Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                Graphics g = Graphics.FromImage(bmp);

                // Dibujar puntos
                foreach (var p in puntos)
                {
                    if (p.X >= 0 && p.X < bmp.Width && p.Y >= 0 && p.Y < bmp.Height)
                        bmp.SetPixel(p.X, p.Y, Color.Black);
                }

                // Mostrar imagen
                pictureBox1.Image = bmp;
            }
            catch
            {
                MessageBox.Show("Por favor ingresa valores válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
