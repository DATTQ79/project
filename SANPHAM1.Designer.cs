namespace BTNNhom10
{
    partial class SANPHAM1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTimruou = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.fpannel_Body = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtTimruou);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1082, 78);
            this.panel1.TabIndex = 7;
            // 
            // txtTimruou
            // 
            this.txtTimruou.Location = new System.Drawing.Point(266, 31);
            this.txtTimruou.Name = "txtTimruou";
            this.txtTimruou.Size = new System.Drawing.Size(176, 22);
            this.txtTimruou.TabIndex = 5;
            this.txtTimruou.TextChanged += new System.EventHandler(this.txtTimruou_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(172, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tìm kiếm :";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(20, 3);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(124, 72);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // fpannel_Body
            // 
            this.fpannel_Body.AutoScroll = true;
            this.fpannel_Body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpannel_Body.Location = new System.Drawing.Point(0, 78);
            this.fpannel_Body.Name = "fpannel_Body";
            this.fpannel_Body.Size = new System.Drawing.Size(1082, 575);
            this.fpannel_Body.TabIndex = 8;
            // 
            // SANPHAM1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 653);
            this.Controls.Add(this.fpannel_Body);
            this.Controls.Add(this.panel1);
            this.Name = "SANPHAM1";
            this.Text = "SANPHAM1";
            this.Load += new System.EventHandler(this.SANPHAM1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTimruou;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.FlowLayoutPanel fpannel_Body;
    }
}