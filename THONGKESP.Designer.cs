namespace BTNNhom10
{
    partial class THONGKESP
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
            this.label1 = new System.Windows.Forms.Label();
            this.timSP = new System.Windows.Forms.TextBox();
            this.hienthi = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hienthi)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.timSP);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1082, 88);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tìm kiếm :";
            // 
            // timSP
            // 
            this.timSP.Location = new System.Drawing.Point(120, 34);
            this.timSP.Name = "timSP";
            this.timSP.Size = new System.Drawing.Size(235, 22);
            this.timSP.TabIndex = 8;
            this.timSP.TextChanged += new System.EventHandler(this.timSP_TextChanged);
            // 
            // hienthi
            // 
            this.hienthi.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.hienthi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hienthi.GridColor = System.Drawing.Color.White;
            this.hienthi.Location = new System.Drawing.Point(30, 146);
            this.hienthi.Name = "hienthi";
            this.hienthi.RowHeadersWidth = 51;
            this.hienthi.RowTemplate.Height = 24;
            this.hienthi.Size = new System.Drawing.Size(652, 439);
            this.hienthi.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(894, 574);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 38);
            this.button2.TabIndex = 7;
            this.button2.Text = "Xuất thống kê";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // THONGKESP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 653);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.hienthi);
            this.Controls.Add(this.panel1);
            this.Name = "THONGKESP";
            this.Text = "THONGKESP";
            this.Load += new System.EventHandler(this.THONGKESP_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hienthi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox timSP;
        private System.Windows.Forms.DataGridView hienthi;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
    }
}