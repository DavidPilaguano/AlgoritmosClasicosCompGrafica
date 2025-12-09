namespace AlgoritmoDibujarLineas
{
    partial class FrmHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.lienasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dDAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bresenhamLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.midPointLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circuloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circuloToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bresenhamsCircleGenerationAlgorithmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.midpointCircleGenerationAlgorithmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rellenoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boundaryFillViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.floodFillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cortarLineasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cohenSutherlandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nicholToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recorteDePoligonosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vattiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weilerAthertonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sutherlandHodgmanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lienasToolStripMenuItem,
            this.circuloToolStripMenuItem,
            this.rellenoToolStripMenuItem,
            this.cortarLineasToolStripMenuItem,
            this.recorteDePoligonosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1270, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // lienasToolStripMenuItem
            // 
            this.lienasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dDAToolStripMenuItem,
            this.bresenhamLineToolStripMenuItem,
            this.midPointLineToolStripMenuItem});
            this.lienasToolStripMenuItem.Name = "lienasToolStripMenuItem";
            this.lienasToolStripMenuItem.Size = new System.Drawing.Size(76, 29);
            this.lienasToolStripMenuItem.Text = "Lineas";
            // 
            // dDAToolStripMenuItem
            // 
            this.dDAToolStripMenuItem.Name = "dDAToolStripMenuItem";
            this.dDAToolStripMenuItem.Size = new System.Drawing.Size(232, 34);
            this.dDAToolStripMenuItem.Text = "DDA";
            this.dDAToolStripMenuItem.Click += new System.EventHandler(this.dDAToolStripMenuItem_Click);
            // 
            // bresenhamLineToolStripMenuItem
            // 
            this.bresenhamLineToolStripMenuItem.Name = "bresenhamLineToolStripMenuItem";
            this.bresenhamLineToolStripMenuItem.Size = new System.Drawing.Size(232, 34);
            this.bresenhamLineToolStripMenuItem.Text = "BresenhamLine";
            this.bresenhamLineToolStripMenuItem.Click += new System.EventHandler(this.bresenhamLineToolStripMenuItem_Click);
            // 
            // midPointLineToolStripMenuItem
            // 
            this.midPointLineToolStripMenuItem.Name = "midPointLineToolStripMenuItem";
            this.midPointLineToolStripMenuItem.Size = new System.Drawing.Size(232, 34);
            this.midPointLineToolStripMenuItem.Text = "MidPointLine";
            this.midPointLineToolStripMenuItem.Click += new System.EventHandler(this.midPointLineToolStripMenuItem_Click);
            // 
            // circuloToolStripMenuItem
            // 
            this.circuloToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.circuloToolStripMenuItem1,
            this.bresenhamsCircleGenerationAlgorithmToolStripMenuItem,
            this.midpointCircleGenerationAlgorithmToolStripMenuItem});
            this.circuloToolStripMenuItem.Name = "circuloToolStripMenuItem";
            this.circuloToolStripMenuItem.Size = new System.Drawing.Size(82, 29);
            this.circuloToolStripMenuItem.Text = "Circulo";
            // 
            // circuloToolStripMenuItem1
            // 
            this.circuloToolStripMenuItem1.Name = "circuloToolStripMenuItem1";
            this.circuloToolStripMenuItem1.Size = new System.Drawing.Size(436, 34);
            this.circuloToolStripMenuItem1.Text = "Circulo";
            this.circuloToolStripMenuItem1.Click += new System.EventHandler(this.circuloToolStripMenuItem1_Click);
            // 
            // bresenhamsCircleGenerationAlgorithmToolStripMenuItem
            // 
            this.bresenhamsCircleGenerationAlgorithmToolStripMenuItem.Name = "bresenhamsCircleGenerationAlgorithmToolStripMenuItem";
            this.bresenhamsCircleGenerationAlgorithmToolStripMenuItem.Size = new System.Drawing.Size(436, 34);
            this.bresenhamsCircleGenerationAlgorithmToolStripMenuItem.Text = "Bresenham\'s Circle Generation Algorithm";
            this.bresenhamsCircleGenerationAlgorithmToolStripMenuItem.Click += new System.EventHandler(this.bresenhamsCircleGenerationAlgorithmToolStripMenuItem_Click);
            // 
            // midpointCircleGenerationAlgorithmToolStripMenuItem
            // 
            this.midpointCircleGenerationAlgorithmToolStripMenuItem.Name = "midpointCircleGenerationAlgorithmToolStripMenuItem";
            this.midpointCircleGenerationAlgorithmToolStripMenuItem.Size = new System.Drawing.Size(436, 34);
            this.midpointCircleGenerationAlgorithmToolStripMenuItem.Text = "Mid-point Circle Generation Algorithm";
            this.midpointCircleGenerationAlgorithmToolStripMenuItem.Click += new System.EventHandler(this.midpointCircleGenerationAlgorithmToolStripMenuItem_Click);
            // 
            // rellenoToolStripMenuItem
            // 
            this.rellenoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.boundaryFillViewToolStripMenuItem,
            this.floodFillToolStripMenuItem,
            this.scanLineToolStripMenuItem});
            this.rellenoToolStripMenuItem.Name = "rellenoToolStripMenuItem";
            this.rellenoToolStripMenuItem.Size = new System.Drawing.Size(85, 29);
            this.rellenoToolStripMenuItem.Text = "Relleno";
            // 
            // boundaryFillViewToolStripMenuItem
            // 
            this.boundaryFillViewToolStripMenuItem.Name = "boundaryFillViewToolStripMenuItem";
            this.boundaryFillViewToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.boundaryFillViewToolStripMenuItem.Text = "BoundaryFillView";
            this.boundaryFillViewToolStripMenuItem.Click += new System.EventHandler(this.boundaryFillToolStripMenuItem_Click);
            // 
            // floodFillToolStripMenuItem
            // 
            this.floodFillToolStripMenuItem.Name = "floodFillToolStripMenuItem";
            this.floodFillToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.floodFillToolStripMenuItem.Text = "Flood Fill";
            this.floodFillToolStripMenuItem.Click += new System.EventHandler(this.floodFillToolStripMenuItem_Click);
            // 
            // scanLineToolStripMenuItem
            // 
            this.scanLineToolStripMenuItem.Name = "scanLineToolStripMenuItem";
            this.scanLineToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.scanLineToolStripMenuItem.Text = "Scan-Line";
            this.scanLineToolStripMenuItem.Click += new System.EventHandler(this.ScanFillToolStripMenuItem_Click);
            // 
            // cortarLineasToolStripMenuItem
            // 
            this.cortarLineasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cohenSutherlandToolStripMenuItem,
            this.nicholToolStripMenuItem,
            this.liangToolStripMenuItem});
            this.cortarLineasToolStripMenuItem.Name = "cortarLineasToolStripMenuItem";
            this.cortarLineasToolStripMenuItem.Size = new System.Drawing.Size(130, 29);
            this.cortarLineasToolStripMenuItem.Text = "Cortar Lineas";
            // 
            // cohenSutherlandToolStripMenuItem
            // 
            this.cohenSutherlandToolStripMenuItem.Name = "cohenSutherlandToolStripMenuItem";
            this.cohenSutherlandToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.cohenSutherlandToolStripMenuItem.Text = "CohenSutherland";
            this.cohenSutherlandToolStripMenuItem.Click += new System.EventHandler(this.cohenSutherlandToolStripMenuItem_Click);
            // 
            // nicholToolStripMenuItem
            // 
            this.nicholToolStripMenuItem.Name = "nicholToolStripMenuItem";
            this.nicholToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.nicholToolStripMenuItem.Text = "Nichol";
            this.nicholToolStripMenuItem.Click += new System.EventHandler(this.NicholasFongToolStripMenuItem_Click);
            // 
            // liangToolStripMenuItem
            // 
            this.liangToolStripMenuItem.Name = "liangToolStripMenuItem";
            this.liangToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.liangToolStripMenuItem.Text = "Liang";
            this.liangToolStripMenuItem.Click += new System.EventHandler(this.liangBarskyToolStripMenuItem_Click);
            // 
            // recorteDePoligonosToolStripMenuItem
            // 
            this.recorteDePoligonosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vattiToolStripMenuItem,
            this.weilerAthertonToolStripMenuItem,
            this.sutherlandHodgmanToolStripMenuItem});
            this.recorteDePoligonosToolStripMenuItem.Name = "recorteDePoligonosToolStripMenuItem";
            this.recorteDePoligonosToolStripMenuItem.Size = new System.Drawing.Size(196, 29);
            this.recorteDePoligonosToolStripMenuItem.Text = "Recorte de Poligonos";
            // 
            // vattiToolStripMenuItem
            // 
            this.vattiToolStripMenuItem.Name = "vattiToolStripMenuItem";
            this.vattiToolStripMenuItem.Size = new System.Drawing.Size(280, 34);
            this.vattiToolStripMenuItem.Text = "Vatti";
            this.vattiToolStripMenuItem.Click += new System.EventHandler(this.vattaniToolStripMenuItem_Click);
            // 
            // weilerAthertonToolStripMenuItem
            // 
            this.weilerAthertonToolStripMenuItem.Name = "weilerAthertonToolStripMenuItem";
            this.weilerAthertonToolStripMenuItem.Size = new System.Drawing.Size(280, 34);
            this.weilerAthertonToolStripMenuItem.Text = "WeilerAtherton";
            this.weilerAthertonToolStripMenuItem.Click += new System.EventHandler(this.weilerAthertonToolStripMenuItem_Click);
            // 
            // sutherlandHodgmanToolStripMenuItem
            // 
            this.sutherlandHodgmanToolStripMenuItem.Name = "sutherlandHodgmanToolStripMenuItem";
            this.sutherlandHodgmanToolStripMenuItem.Size = new System.Drawing.Size(280, 34);
            this.sutherlandHodgmanToolStripMenuItem.Text = "SutherlandHodgman";
            this.sutherlandHodgmanToolStripMenuItem.Click += new System.EventHandler(this.sutherlandHodgemanToolStripMenuItem_Click4);
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 749);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1292, 805);
            this.MinimumSize = new System.Drawing.Size(1292, 805);
            this.Name = "FrmHome";
            this.Text = "FrmHome";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem lienasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dDAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bresenhamLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem circuloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem circuloToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bresenhamsCircleGenerationAlgorithmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem midpointCircleGenerationAlgorithmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem midPointLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rellenoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boundaryFillViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem floodFillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cortarLineasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cohenSutherlandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nicholToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recorteDePoligonosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vattiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weilerAthertonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sutherlandHodgmanToolStripMenuItem;
    }
}