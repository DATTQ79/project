namespace BTNNhom10
{
    partial class SANPHAM
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
            this.menuSP = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTKSP = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_Body = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSP,
            this.menuTKSP});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1082, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuSP
            // 
            this.menuSP.Name = "menuSP";
            this.menuSP.Size = new System.Drawing.Size(93, 24);
            this.menuSP.Text = "Sản phẩm ";
            this.menuSP.Click += new System.EventHandler(this.menuSP_Click);
            // 
            // menuTKSP
            // 
            this.menuTKSP.Name = "menuTKSP";
            this.menuTKSP.Size = new System.Drawing.Size(84, 24);
            this.menuTKSP.Text = "Thống kê";
            this.menuTKSP.Click += new System.EventHandler(this.menuTKSP_Click);
            // 
            // panel_Body
            // 
            this.panel_Body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Body.Location = new System.Drawing.Point(0, 28);
            this.panel_Body.Name = "panel_Body";
            this.panel_Body.Size = new System.Drawing.Size(1082, 625);
            this.panel_Body.TabIndex = 5;
            // 
            // SANPHAM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 653);
            this.Controls.Add(this.panel_Body);
            this.Controls.Add(this.menuStrip1);
            this.Name = "SANPHAM";
            this.Text = "SANPHAM";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuSP;
        private System.Windows.Forms.ToolStripMenuItem menuTKSP;
        private System.Windows.Forms.Panel panel_Body;
    }
}