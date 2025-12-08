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
            this.circuloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circuloToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bresenhamsCircleGenerationAlgorithmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.midpointCircleGenerationAlgorithmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.midPointLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lienasToolStripMenuItem,
            this.circuloToolStripMenuItem});
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
            // midPointLineToolStripMenuItem
            // 
            this.midPointLineToolStripMenuItem.Name = "midPointLineToolStripMenuItem";
            this.midPointLineToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.midPointLineToolStripMenuItem.Text = "MidPointLine";
            this.midPointLineToolStripMenuItem.Click += new System.EventHandler(this.midPointLineToolStripMenuItem_Click);
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
    }
}