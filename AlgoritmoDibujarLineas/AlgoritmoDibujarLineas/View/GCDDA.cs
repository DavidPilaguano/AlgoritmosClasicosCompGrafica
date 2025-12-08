using System;
using System.Drawing;
using System.Windows.Forms;
using AlgoritmoDibujarLineas.Controller;

namespace AlgoritmoDibujarLineas.view
{
    public partial class GCDDA : Form
    {
        Bitmap canvas;
        Graphics g;
        private DDA_Controller dda;
        public GCDDA()
        {
            InitializeComponent();
            dda = new DDA_Controller();
        }

        private void GCDDA_Load(object sender, EventArgs e)
        {
            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            g = Graphics.FromImage(canvas);
            g.Clear(Color.White);

            pictureBox1.Image = canvas;
        }

        // Funcion no utilizada
        private void groupBox1_Enter(object sender, EventArgs e)
        {


        }


        private void btnDraw_Click(object sender, EventArgs e)
        {
            if (canvas == null)
            {
                MessageBox.Show("Canvas is null — Load event not running.");
                return;
            }

            int x0 = int.Parse(txtX0.Text);
            int y0 = int.Parse(txtY0.Text);
            int x1 = int.Parse(txtX1.Text);
            int y1 = int.Parse(txtY1.Text);

            dda.DrawLineDDA(canvas, x0, y0, x1, y1, Color.Black);
            pictureBox1.Invalidate();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            if (g == null) return;

            g.Clear(Color.White);
            pictureBox1.Invalidate();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}