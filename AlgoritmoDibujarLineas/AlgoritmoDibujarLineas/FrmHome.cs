using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlgoritmoDibujarLineas.view;
using AlgoritmoDibujarLineas.View;


namespace AlgoritmoDibujarLineas
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
        }

        private void dDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            GCDDA gCDDA = new GCDDA();
            gCDDA.MdiParent = this;
            gCDDA.Dock = DockStyle.Fill;    
            gCDDA.Show();
                
        }

        private void bresenhamLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            Bresenham_s_Line bresenhamForm = new Bresenham_s_Line();
            bresenhamForm.MdiParent = this;
            bresenhamForm.Dock = DockStyle.Fill;
            bresenhamForm.Show();
        }

        private void circuloToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            Circle circleForm = new Circle();
            circleForm.MdiParent = this;
            circleForm.Dock = DockStyle.Fill;
            circleForm.Show();
        }

        private void bresenhamsCircleGenerationAlgorithmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            bresenhamsCircleGenerationAlgorithm bresenhamCircleForm = new bresenhamsCircleGenerationAlgorithm();
            bresenhamCircleForm.MdiParent = this;
            bresenhamCircleForm.Dock = DockStyle.Fill;
            bresenhamCircleForm.Show();
        }

        private void midpointCircleGenerationAlgorithmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            Mid_point_Circle_Generation_Algorithm mid_Point_Circle_Generation_Algorithm = new Mid_point_Circle_Generation_Algorithm();
            mid_Point_Circle_Generation_Algorithm.MdiParent = this;
            mid_Point_Circle_Generation_Algorithm.Dock= DockStyle.Fill;
            mid_Point_Circle_Generation_Algorithm.Show();
        }

        private void midPointLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            Mid_pointLineGeneration mid_PointLineGeneration = new Mid_pointLineGeneration();
            mid_PointLineGeneration.MdiParent = this;
            mid_PointLineGeneration.Dock = DockStyle.Fill;
            mid_PointLineGeneration.Show();
        }
    }
}
