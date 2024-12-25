namespace BTNNhom10
{
    partial class BANHANG
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
            this.panelBody = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuTaoHD = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHDdatao = new System.Windows.Forms.ToolStripMenuItem();
            this.menuThongke = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBody
            // 
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(0, 30);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(1082, 623);
            this.panelBody.TabIndex = 6;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTaoHD,
            this.menuHDdatao,
            this.menuThongke});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1082, 30);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuTaoHD
            // 
            this.menuTaoHD.Name = "menuTaoHD";
            this.menuTaoHD.Size = new System.Drawing.Size(112, 26);
            this.menuTaoHD.Text = "Tạo Hóa Đơn";
            this.menuTaoHD.Click += new System.EventHandler(this.menuTaoHD_Click);
            // 
            // menuHDdatao
            // 
            this.menuHDdatao.Name = "menuHDdatao";
            this.menuHDdatao.Size = new System.Drawing.Size(135, 26);
            this.menuHDdatao.Text = "Hóa Đơn Đã Tạo";
            this.menuHDdatao.Click += new System.EventHandler(this.menuHDdatao_Click);
            // 
            // menuThongke
            // 
            this.menuThongke.Name = "menuThongke";
            this.menuThongke.Size = new System.Drawing.Size(158, 26);
            this.menuThongke.Text = "Thống Kê DoanhThu";
            this.menuThongke.Click += new System.EventHandler(this.menuThongke_Click);
            // 
            // BANHANG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 653);
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.menuStrip1);
            this.Name = "BANHANG";
            this.Text = "BANHANG";
            this.Load += new System.EventHandler(this.BANHANG_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuTaoHD;
        private System.Windows.Forms.ToolStripMenuItem menuHDdatao;
        private System.Windows.Forms.ToolStripMenuItem menuThongke;
    }
}