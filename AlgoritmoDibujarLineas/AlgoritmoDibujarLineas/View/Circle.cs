using AlgoritmoDibujarLineas.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AlgoritmoDibujarLineas.View
{
    public partial class Circle : Form
    {
        private MidpointCircleController controller;
        private List<Point> puntos = new List<Point>();

        public Circle()
        {
            InitializeComponent();
            controller = new MidpointCircleController();

            btnGraficar.Click += BtnGraficar_Click;
            btnLimpiar.Click += BtnLimpiar_Click;
            panelCanvas.Paint += PanelCanvas_Paint;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void BtnGraficar_Click(object sender, EventArgs e)
        {
            try
            {
                int r = int.Parse(txtRadio.Text);

                int xc = panelCanvas.Width / 2;
                int yc = panelCanvas.Height / 2;

                puntos = controller.CalcularCircunferencia(xc, yc, r);

                panelCanvas.Invalidate();
            }
            catch
            {
                MessageBox.Show("Ingrese un valor numérico válido para el radio.");
            }
        }
        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            puntos.Clear();
            panelCanvas.Invalidate();
        }
        private void PanelCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach (Point p in puntos)
            {
                g.FillRectangle(Brushes.Blue, p.X, p.Y, 2, 2);
            }
        }

    }
}
