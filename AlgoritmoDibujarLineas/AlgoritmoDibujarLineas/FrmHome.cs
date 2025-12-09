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

        private void boundaryFillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            BoundaryFillView boundaryFillView = new BoundaryFillView();
            boundaryFillView.MdiParent = this;
            boundaryFillView.Dock = DockStyle.Fill;
            boundaryFillView.Show();
        }
        private void floodFillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            FloodFillView floodFillView = new FloodFillView();
            floodFillView.MdiParent = this;
            floodFillView.Dock = DockStyle.Fill;
            floodFillView.Show();
        }
        private void ScanFillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            ScanLineFillView scanFillView = new ScanLineFillView();
            scanFillView.MdiParent = this;
            scanFillView.Dock = DockStyle.Fill;
            scanFillView.Show();
        }

        private void cohenSutherlandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            CohenSutherlandView cohenSutherlandView = new CohenSutherlandView();
            cohenSutherlandView.MdiParent = this;
            cohenSutherlandView.Dock = DockStyle.Fill;
            cohenSutherlandView.Show();
        }
        private void NicholasFongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            NichollLeeNichollView nicholasFongView = new NichollLeeNichollView();
            nicholasFongView.MdiParent = this;
            nicholasFongView.Dock = DockStyle.Fill;
            nicholasFongView.Show();
        }
        private void liangBarskyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            LiangBarskyView liangBarskyView = new LiangBarskyView();
            liangBarskyView.MdiParent = this;
            liangBarskyView.Dock = DockStyle.Fill;
            liangBarskyView.Show();
        }
        private void vattaniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            VattiView vattiView = new VattiView();
            vattiView.MdiParent = this;
            vattiView.Dock = DockStyle.Fill;
            vattiView.Show();
        }
        private void sutherlandHodgemanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            SutherlandHodgmanView sutherlandHodgemanView = new SutherlandHodgmanView();
            sutherlandHodgemanView.MdiParent = this;
            sutherlandHodgemanView.Dock = DockStyle.Fill;
            sutherlandHodgemanView.Show();
        }

        private void sutherlandHodgemanToolStripMenuItem_Click4(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            SutherlandHodgmanView sutherlandHodgemanView = new SutherlandHodgmanView();
            sutherlandHodgemanView.MdiParent = this;
            sutherlandHodgemanView.Dock = DockStyle.Fill;
            sutherlandHodgemanView.Show();
        }
        private void weilerAthertonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            WeilerAthertonView weilerAthertonView = new WeilerAthertonView();
            weilerAthertonView.MdiParent = this;
            weilerAthertonView.Dock = DockStyle.Fill;
            weilerAthertonView.Show();
        }
    }
}
