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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace BTNNhom10
{
    public partial class CANHAN : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        public string tk1;
        string maNV;
        public CANHAN()
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
        private void CANHAN_Load(object sender, EventArgs e)
        {
            cn.Open();
            cm = new SqlCommand("SELECT MaNV,TenNV,ChucVu,HinhAnh FROM NhanVien WHERE TaiKhoan = @TaiKhoan", cn);
            cm.Parameters.AddWithValue("@TaiKhoan", tk1);
            dr = cm.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                string hoTen = dr["TenNV"].ToString();
                string chucVu = dr["ChucVu"].ToString();
                labTen.Text = hoTen;
                labchucvu.Text = chucVu;
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
            cn.Close();
        }

        private void btnTTCaNhan_Click(object sender, EventArgs e)
        {
            TTNHANVIEN ttnv  = new TTNHANVIEN();
            ttnv.nv = labTen.Text;
            ttnv.ShowDialog();
        }

        private void btnDMK_Click(object sender, EventArgs e)
        {
            DOIMATKHAU dmk = new DOIMATKHAU();
            dmk.tk2 = tk1;
            dmk.ShowDialog();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {

            int count = 0;
            int sum = 0;
            int sumsl = 0;

            string ngaymo = dtpNgaymo.Value.ToString("yyyy-MM-dd");
            string ngayket = dtpNgayket.Value.ToString("yyyy-MM-dd");

            try
            {
                cn.Open();

                // Get the MaNV for the current user
                string maNV = "";
                using (SqlCommand cm = new SqlCommand("SELECT MaNV FROM NhanVien WHERE TaiKhoan = @TaiKhoan", cn))
                {
                    cm.Parameters.AddWithValue("@TaiKhoan", tk1);
                    using (SqlDataReader dr1 = cm.ExecuteReader())
                    {
                        if (dr1.Read())
                        {
                            maNV = dr1["MaNV"].ToString();
                        }
                    }
                }

                if (!string.IsNullOrEmpty(maNV))
                {
                    // Get the invoice data
                    using (SqlCommand cm = new SqlCommand(
                        "SELECT TongTien, SoLuong FROM HoaDon JOIN ChiTietHD ON HoaDon.MaHD = ChiTietHD.MaHD " +
                        "WHERE (HoaDon.NgayLap BETWEEN @ngaymo AND @ngayket) AND MaNV = @maNV", cn))
                    {
                        cm.Parameters.AddWithValue("@ngaymo", ngaymo);
                        cm.Parameters.AddWithValue("@ngayket", ngayket);
                        cm.Parameters.AddWithValue("@maNV", maNV);

                        using (SqlDataReader dr2 = cm.ExecuteReader())
                        {
                            while (dr2.Read())
                            {
                                int tt = Convert.ToInt32(dr2["TongTien"]);
                                int sl = Convert.ToInt32(dr2["SoLuong"]);
                                sum += tt;
                                sumsl += sl;
                                count++;
                            }
                        }
                    }
                }

                // Update the labels with the computed values
                labSoHd.Text = count.ToString();
                labSosp.Text = sumsl.ToString();
                labTongtien.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
        }
    }
}
