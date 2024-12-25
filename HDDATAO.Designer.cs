namespace BTNNhom10
{
    partial class HDDATAO
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
            this.label11 = new System.Windows.Forms.Label();
            this.HDchitiet = new System.Windows.Forms.DataGridView();
            this.hienthiHD = new System.Windows.Forms.DataGridView();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labTongtien = new System.Windows.Forms.Label();
            this.labNgaytao = new System.Windows.Forms.Label();
            this.labNhanvien = new System.Windows.Forms.Label();
            this.labSDT = new System.Windows.Forms.Label();
            this.labNgaysinh = new System.Windows.Forms.Label();
            this.labtenKH = new System.Windows.Forms.Label();
            this.labmaKH = new System.Windows.Forms.Label();
            this.btnInHD = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labmaHD = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HDchitiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hienthiHD)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.HDchitiet);
            this.panel2.Controls.Add(this.hienthiHD);
            this.panel2.Controls.Add(this.txtTim);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(278, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(804, 653);
            this.panel2.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(287, 359);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(178, 20);
            this.label11.TabIndex = 6;
            this.label11.Text = "CHI TIẾT HÓA ĐƠN";
            // 
            // HDchitiet
            // 
            this.HDchitiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HDchitiet.Location = new System.Drawing.Point(26, 396);
            this.HDchitiet.Name = "HDchitiet";
            this.HDchitiet.ReadOnly = true;
            this.HDchitiet.RowHeadersWidth = 51;
            this.HDchitiet.RowTemplate.Height = 24;
            this.HDchitiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.HDchitiet.Size = new System.Drawing.Size(708, 238);
            this.HDchitiet.TabIndex = 5;
            // 
            // hienthiHD
            // 
            this.hienthiHD.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.hienthiHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hienthiHD.Location = new System.Drawing.Point(23, 59);
            this.hienthiHD.Name = "hienthiHD";
            this.hienthiHD.ReadOnly = true;
            this.hienthiHD.RowHeadersWidth = 51;
            this.hienthiHD.RowTemplate.Height = 24;
            this.hienthiHD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.hienthiHD.Size = new System.Drawing.Size(712, 284);
            this.hienthiHD.TabIndex = 4;
            this.hienthiHD.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.hienthiHD_CellClick);
            this.hienthiHD.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.hienthiHD_CellContentClick);
            this.hienthiHD.Click += new System.EventHandler(this.hienthiHD_Click);
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(127, 12);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(178, 22);
            this.txtTim.TabIndex = 2;
            this.txtTim.TextChanged += new System.EventHandler(this.txtTim_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(31, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 16);
            this.label10.TabIndex = 1;
            this.label10.Text = "Tìm kiếm:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labTongtien);
            this.panel1.Controls.Add(this.labNgaytao);
            this.panel1.Controls.Add(this.labNhanvien);
            this.panel1.Controls.Add(this.labSDT);
            this.panel1.Controls.Add(this.labNgaysinh);
            this.panel1.Controls.Add(this.labtenKH);
            this.panel1.Controls.Add(this.labmaKH);
            this.panel1.Controls.Add(this.btnInHD);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labmaHD);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 653);
            this.panel1.TabIndex = 4;
            // 
            // labTongtien
            // 
            this.labTongtien.AutoSize = true;
            this.labTongtien.Location = new System.Drawing.Point(127, 463);
            this.labTongtien.Name = "labTongtien";
            this.labTongtien.Size = new System.Drawing.Size(13, 16);
            this.labTongtien.TabIndex = 18;
            this.labTongtien.Text = "  ";
            // 
            // labNgaytao
            // 
            this.labNgaytao.AutoSize = true;
            this.labNgaytao.Location = new System.Drawing.Point(127, 402);
            this.labNgaytao.Name = "labNgaytao";
            this.labNgaytao.Size = new System.Drawing.Size(13, 16);
            this.labNgaytao.TabIndex = 17;
            this.labNgaytao.Text = "  ";
            // 
            // labNhanvien
            // 
            this.labNhanvien.AutoSize = true;
            this.labNhanvien.Location = new System.Drawing.Point(127, 343);
            this.labNhanvien.Name = "labNhanvien";
            this.labNhanvien.Size = new System.Drawing.Size(13, 16);
            this.labNhanvien.TabIndex = 16;
            this.labNhanvien.Text = "  ";
            // 
            // labSDT
            // 
            this.labSDT.AutoSize = true;
            this.labSDT.Location = new System.Drawing.Point(137, 282);
            this.labSDT.Name = "labSDT";
            this.labSDT.Size = new System.Drawing.Size(13, 16);
            this.labSDT.TabIndex = 15;
            this.labSDT.Text = "  ";
            // 
            // labNgaysinh
            // 
            this.labNgaysinh.AutoSize = true;
            this.labNgaysinh.Location = new System.Drawing.Point(137, 222);
            this.labNgaysinh.Name = "labNgaysinh";
            this.labNgaysinh.Size = new System.Drawing.Size(13, 16);
            this.labNgaysinh.TabIndex = 14;
            this.labNgaysinh.Text = "  ";
            // 
            // labtenKH
            // 
            this.labtenKH.AutoSize = true;
            this.labtenKH.Location = new System.Drawing.Point(157, 172);
            this.labtenKH.Name = "labtenKH";
            this.labtenKH.Size = new System.Drawing.Size(13, 16);
            this.labtenKH.TabIndex = 13;
            this.labtenKH.Text = "  ";
            // 
            // labmaKH
            // 
            this.labmaKH.AutoSize = true;
            this.labmaKH.Location = new System.Drawing.Point(137, 126);
            this.labmaKH.Name = "labmaKH";
            this.labmaKH.Size = new System.Drawing.Size(13, 16);
            this.labmaKH.TabIndex = 12;
            this.labmaKH.Text = "  ";
            // 
            // btnInHD
            // 
            this.btnInHD.Location = new System.Drawing.Point(160, 533);
            this.btnInHD.Name = "btnInHD";
            this.btnInHD.Size = new System.Drawing.Size(92, 34);
            this.btnInHD.TabIndex = 10;
            this.btnInHD.Text = "In hóa đơn";
            this.btnInHD.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(29, 533);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 34);
            this.btnXoa.TabIndex = 9;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 463);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 16);
            this.label9.TabIndex = 8;
            this.label9.Text = "Tổng tiền :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 402);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "Ngày tạo HD :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 343);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Nhân viên :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 282);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Số điện thoại :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ngày sinh :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tên khách hàng :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã khách hàng :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã hóa đơn :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "CHI TIẾT SẢN PHẨM";
            // 
            // labmaHD
            // 
            this.labmaHD.AutoSize = true;
            this.labmaHD.Location = new System.Drawing.Point(127, 77);
            this.labmaHD.Name = "labmaHD";
            this.labmaHD.Size = new System.Drawing.Size(13, 16);
            this.labmaHD.TabIndex = 11;
            this.labmaHD.Text = "  ";
            // 
            // HDDATAO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 653);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "HDDATAO";
            this.Text = "HDDATAO";
            this.Load += new System.EventHandler(this.HDDATAO_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HDchitiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hienthiHD)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView HDchitiet;
        private System.Windows.Forms.DataGridView hienthiHD;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnInHD;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labTongtien;
        private System.Windows.Forms.Label labNgaytao;
        private System.Windows.Forms.Label labNhanvien;
        private System.Windows.Forms.Label labSDT;
        private System.Windows.Forms.Label labNgaysinh;
        private System.Windows.Forms.Label labtenKH;
        private System.Windows.Forms.Label labmaKH;
        private System.Windows.Forms.Label labmaHD;
    }
}