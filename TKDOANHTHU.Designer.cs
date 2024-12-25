namespace BTNNhom10
{
    partial class TKDOANHTHU
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.labTongtien = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labSoHD = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.cmbNam = new System.Windows.Forms.ComboBox();
            this.cmbQuy = new System.Windows.Forms.ComboBox();
            this.cmbThang = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labQuy = new System.Windows.Forms.Label();
            this.labThang = new System.Windows.Forms.Label();
            this.cmbLon = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.labTongtien);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(110, 193);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(542, 191);
            this.panel2.TabIndex = 35;
            // 
            // labTongtien
            // 
            this.labTongtien.AutoSize = true;
            this.labTongtien.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTongtien.Location = new System.Drawing.Point(285, 71);
            this.labTongtien.Name = "labTongtien";
            this.labTongtien.Size = new System.Drawing.Size(48, 42);
            this.labTongtien.TabIndex = 1;
            this.labTongtien.Text = "   ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(45, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(205, 42);
            this.label7.TabIndex = 0;
            this.label7.Text = "Tổng tiền :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCoral;
            this.panel1.Controls.Add(this.labSoHD);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(111, 406);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(541, 193);
            this.panel1.TabIndex = 34;
            // 
            // labSoHD
            // 
            this.labSoHD.AutoSize = true;
            this.labSoHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labSoHD.Location = new System.Drawing.Point(307, 68);
            this.labSoHD.Name = "labSoHD";
            this.labSoHD.Size = new System.Drawing.Size(48, 42);
            this.labSoHD.TabIndex = 1;
            this.labSoHD.Text = "   ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(44, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(242, 42);
            this.label5.TabIndex = 0;
            this.label5.Text = "Số hóa đơn :";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button2.Location = new System.Drawing.Point(921, 572);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 45);
            this.button2.TabIndex = 33;
            this.button2.Text = "Xuất thống kê";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // cmbNam
            // 
            this.cmbNam.FormattingEnabled = true;
            this.cmbNam.Items.AddRange(new object[] {
            "2021",
            "2022",
            "2023",
            "2024"});
            this.cmbNam.Location = new System.Drawing.Point(449, 89);
            this.cmbNam.Name = "cmbNam";
            this.cmbNam.Size = new System.Drawing.Size(87, 24);
            this.cmbNam.TabIndex = 31;
            this.cmbNam.Click += new System.EventHandler(this.cmbNam_Click);
            // 
            // cmbQuy
            // 
            this.cmbQuy.FormattingEnabled = true;
            this.cmbQuy.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cmbQuy.Location = new System.Drawing.Point(309, 89);
            this.cmbQuy.Name = "cmbQuy";
            this.cmbQuy.Size = new System.Drawing.Size(53, 24);
            this.cmbQuy.TabIndex = 30;
            this.cmbQuy.Click += new System.EventHandler(this.cmbQuy_Click);
            // 
            // cmbThang
            // 
            this.cmbThang.FormattingEnabled = true;
            this.cmbThang.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cmbThang.Location = new System.Drawing.Point(170, 89);
            this.cmbThang.Name = "cmbThang";
            this.cmbThang.Size = new System.Drawing.Size(62, 24);
            this.cmbThang.TabIndex = 29;
            this.cmbThang.Click += new System.EventHandler(this.cmbThang_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(399, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 16);
            this.label4.TabIndex = 28;
            this.label4.Text = "Năm";
            // 
            // labQuy
            // 
            this.labQuy.AutoSize = true;
            this.labQuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labQuy.Location = new System.Drawing.Point(259, 92);
            this.labQuy.Name = "labQuy";
            this.labQuy.Size = new System.Drawing.Size(34, 16);
            this.labQuy.TabIndex = 27;
            this.labQuy.Text = "Quý";
            // 
            // labThang
            // 
            this.labThang.AutoSize = true;
            this.labThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labThang.Location = new System.Drawing.Point(107, 92);
            this.labThang.Name = "labThang";
            this.labThang.Size = new System.Drawing.Size(51, 16);
            this.labThang.TabIndex = 26;
            this.labThang.Text = "Tháng";
            // 
            // cmbLon
            // 
            this.cmbLon.FormattingEnabled = true;
            this.cmbLon.Items.AddRange(new object[] {
            "Tháng",
            "Quý"});
            this.cmbLon.Location = new System.Drawing.Point(179, 36);
            this.cmbLon.Name = "cmbLon";
            this.cmbLon.Size = new System.Drawing.Size(163, 24);
            this.cmbLon.TabIndex = 25;
            this.cmbLon.SelectedIndexChanged += new System.EventHandler(this.cmbLon_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "Thống kê theo :";
            // 
            // TKDOANHTHU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1082, 653);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cmbNam);
            this.Controls.Add(this.cmbQuy);
            this.Controls.Add(this.cmbThang);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labQuy);
            this.Controls.Add(this.labThang);
            this.Controls.Add(this.cmbLon);
            this.Controls.Add(this.label1);
            this.Name = "TKDOANHTHU";
            this.Text = "TKDOANHTHU";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Load += new System.EventHandler(this.TKDOANHTHU_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labTongtien;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labSoHD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cmbNam;
        private System.Windows.Forms.ComboBox cmbQuy;
        private System.Windows.Forms.ComboBox cmbThang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labQuy;
        private System.Windows.Forms.Label labThang;
        private System.Windows.Forms.ComboBox cmbLon;
        private System.Windows.Forms.Label label1;
    }
}