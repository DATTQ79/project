using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTNNhom10
{
    public partial class HDDATAO : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable dt = new DataTable();
        public HDDATAO()
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

        void loatdata()
        {
            
            cm = new SqlCommand("SELECT * FROM HoaDon", cn);
            adapter.SelectCommand = cm;
            dt.Clear();
            adapter.Fill(dt);
            hienthiHD.DataSource = dt;
        }
        private void hienthiHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void HDDATAO_Load(object sender, EventArgs e)
        {
           
            loatdata();
            
        }

        private void hienthiHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (hienthiHD.SelectedRows.Count > 0 && hienthiHD.DataSource != null)
            {
                DataTable dx = new DataTable();
                int rowIndex = hienthiHD.SelectedRows[0].Index;
                string maHD = hienthiHD.Rows[rowIndex].Cells["MaHD"].Value.ToString();

                try
                {
                   
                    cm = new SqlCommand("SELECT ChiTietHD.MaSP, ChiTietHD.TenSP, ChiTietHD.Gia, ChiTietHD.SoLuong, ChiTietHD.ThanhTien FROM ChiTietHD INNER JOIN HoaDon ON ChiTietHD.MaHD = HoaDon.MaHD WHERE HoaDon.MaHD = @MaHD", cn);
                    cm.Parameters.AddWithValue("@MaHD", maHD);
                    adapter.SelectCommand = cm;
                    adapter.Fill(dx);
                    HDchitiet.DataSource = dx;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                

            }
        }

        private void hienthiHD_Click(object sender, EventArgs e)
        {
            if (hienthiHD.SelectedRows.Count > 0 && hienthiHD.DataSource != null)
            {
                int rowIndex = hienthiHD.SelectedRows[0].Index;
         
                labmaHD.Text = hienthiHD.Rows[rowIndex].Cells["MaHD"].Value.ToString();
                labmaKH.Text = hienthiHD.Rows[rowIndex].Cells["MaKH"].Value.ToString();
                labNgaytao.Text = hienthiHD.Rows[rowIndex].Cells["NgayLap"].Value.ToString();
                labTongtien.Text = hienthiHD.Rows[rowIndex].Cells["TongTien"].Value.ToString();
                string maNV = hienthiHD.Rows[rowIndex].Cells["MaNV"].Value.ToString();
                
                try
                {
                    cn.Open();
                    SqlDataReader dr;
                    cm = new SqlCommand("SELECT NhanVien.TenNV FROM NhanVien INNER JOIN HoaDon ON NhanVien.MaNV = HoaDon.MaNV WHERE HoaDon.MaNV = @MaNV", cn);
                    cm.Parameters.AddWithValue("@MaNV", maNV);
                    dr = cm.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        string hoTen = dr["TenNV"].ToString();
                        labNhanvien.Text = hoTen;
                    }
                    dr.Close();

                    cm = new SqlCommand("SELECT KhachHang.TenKH, KhachHang.NgaySinh, KhachHang.SDT FROM KhachHang INNER JOIN HoaDon ON KhachHang.MaKH = HoaDon.MaKH WHERE HoaDon.MaKH = @MaKH", cn);
                    cm.Parameters.AddWithValue("@MaKH", labmaKH.Text);
                    dr = cm.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        string hoten = dr["TenKH"].ToString();
                        string ngaysinh = dr["NgaySinh"].ToString();
                        string SDT = dr["SDT"].ToString();
                        labtenKH.Text = hoten;
                        labNgaysinh.Text = ngaysinh;
                        labSDT.Text = SDT;
                    }
                    else
                    {
                        MessageBox.Show("khong co du lieu");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                cn.Close();
            }

        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            string name = txtTim.Text.Trim();
            if (name == "")
            {
                HDDATAO_Load(sender, e);
            }
            else
            {

                cm = new SqlCommand("SELECT * FROM HoaDon WHERE MaHD LIKE '%" + name + "%' OR NgayLap LIKE '%" + name + "%'", cn);
                adapter.SelectCommand = cm;
                dt.Clear();
                adapter.Fill(dt);
                hienthiHD.DataSource = dt;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            cn.Open();
            cm = new SqlCommand("DELETE FROM HoaDon WHERE MaHD = '" + labmaHD.Text + "'", cn);
            cm.ExecuteNonQuery();
            loatdata();
            cn.Close();
        }
    }
}
