using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlgoritmoDibujarLineas.Controller;
namespace AlgoritmoDibujarLineas.view
{
    public partial class Bresenham_s_Line : Form
    {
        Bitmap bmp;
        Bresenham_Controller bresenham = new Bresenham_Controller();

        public Bresenham_s_Line()
        {
            InitializeComponent();

        }
        private void Bresenham_s_Line_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
        }
        private void btnDraw_Click(object sender, EventArgs e)
        {
            try
            {
                int x0 = int.Parse(txtX0.Text);
                int y0 = int.Parse(txtY0.Text);
                int x1 = int.Parse(txtX1.Text);
                int y1 = int.Parse(txtY1.Text);

                bresenham.DrawLineBresenham(bmp, x0, y0, x1, y1, Color.Blue);
                pictureBox1.Refresh();
            }
            catch
            {
                MessageBox.Show("Invalid input. Please enter numbers only.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
            }
            pictureBox1.Refresh();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

