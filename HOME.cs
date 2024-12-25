using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTNNhom10
{
    public partial class HOME : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        bool isThoat = true;
        public string taikhoan1;
        public HOME()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
        }
        private Form curren;
        private void OpenChilForm(Form chilform)
        {
            if (curren != null)
            {
                curren.Close();
            }
            curren = chilform;
            chilform.TopLevel = false;
            chilform.FormBorderStyle = FormBorderStyle.None;
            chilform.Dock = DockStyle.Fill;
            panel_Body.Controls.Add(chilform);
            panel_Body.Tag = chilform;
            chilform.BringToFront();
            chilform.Show();
        }

        private void btnCaNhan_Click(object sender, EventArgs e)
        {
            CANHAN cn = new CANHAN();
            cn.tk1 = taikhoan1;
            OpenChilForm(cn);
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            BANHANG bn = new BANHANG();
            bn.name = taikhoan1;
            bn.cv = labChucVu.Text;
            OpenChilForm(bn);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            OpenChilForm(new NHANVIEN());
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            OpenChilForm(new KHACHHANG());
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            OpenChilForm(new SANPHAM());
        }

        private void btnTroGiup_Click(object sender, EventArgs e)
        {
            OpenChilForm(new TROGIUP());
        }
        private void InitializeDatabaseConnection()
        {
            try
            {
                string connectionString = new Connection().myConnection();
                cn = new SqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {

            isThoat = false;
            Login f = new Login();
            f.Show();
            this.Close();
        }

        private void HOME_Load(object sender, EventArgs e)
        {
            cn.Open();
            cm = new SqlCommand("SELECT TenNV,ChucVu,HinhAnh FROM NhanVien WHERE TaiKhoan = @TaiKhoan", cn);
            cm.Parameters.AddWithValue("@TaiKhoan", taikhoan1);
            dr = cm.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                string hoTen = dr["TenNV"].ToString();
                string chucVu = dr["ChucVu"].ToString();
                lebTen.Text = hoTen;
                labChucVu.Text = chucVu;
                byte[] imageData = (byte[])dr["HinhAnh"];
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    anh.Image = Image.FromStream(ms);
                }
                if (chucVu != "Qu?n lý")
                {
                    btnKhachHang.Enabled = false;
                    btnNhanVien.Enabled = false;
                }
            }
            
            else
            {
                MessageBox.Show("khong co du lieu");
            }
            dr.Close();
        }

        private void panel_Body_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
