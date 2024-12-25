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
    public partial class TTNHANVIEN : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        public string nv;
        public TTNHANVIEN()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
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

        private void TTNHANVIEN_Load(object sender, EventArgs e)
        {
            cn.Open();
            cm = new SqlCommand("SELECT MaNV,TenNV,NgaySinh,ChucVu,GioiTinh,CCCD,SDT,DiaChi,HinhAnh FROM NhanVien WHERE TenNV = @TenNV", cn);
            cm.Parameters.AddWithValue("@TenNV", nv);
            dr = cm.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                string maNV = dr["MaNV"].ToString();
                string ngaysinh = dr["NgaySinh"].ToString();
                string chucvu = dr["ChucVu"].ToString();
                string gioitinh = dr["GioiTinh"].ToString();
                string cccd = dr["CCCD"].ToString();
                string sdt = dr["SDT"].ToString();
                string diachi = dr["DiaChi"].ToString();
                labMaNV.Text = maNV;
                txtTenNV.Text = nv;
                txtNgaysinh.Text = ngaysinh;
                txtChucvu.Text = chucvu;
                txtGioitinh.Text = gioitinh;
                txtCCCD.Text = cccd;
                txtSDT.Text = sdt;
                txtDiaChi.Text = diachi;
                byte[] imageData = (byte[])dr["HinhAnh"];
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    anh.Image = Image.FromStream(ms);
                }
            }
            else
            {
                MessageBox.Show("khong co du lieu");
            }
            dr.Close();
        }
    }
}
