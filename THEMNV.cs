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
    public partial class THEMNV : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        public THEMNV()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
        }

        private void btnTaianh_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = ofd.Filter = "JPG files (*.jpg)|*.jpg|A11 files (*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = ofd.FileName;
            }
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
        byte[] InmageToBytes(Image img)
        {
            MemoryStream m = new MemoryStream();
            img.Save(m, System.Drawing.Imaging.ImageFormat.Png);
            return m.ToArray();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            byte[] b = InmageToBytes(pictureBox1.Image);

            cn.Open();
            cm = new SqlCommand("INSERT INTO NhanVien VALUES(@MaNV,@TenNV,@NgaySinh,@GioiTinh,@CCCD,@SDT,@DiaChi,@ChucVu,@HinhAnh,@TaiKhoan,@MatKhau)", cn);

            cm.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
            cm.Parameters.AddWithValue("@TenNV", txtTenNV.Text);
            cm.Parameters.AddWithValue("@NgaySinh", dtpNgaysinh.Value);
            cm.Parameters.AddWithValue("@GioiTinh", cmbGioitinh.SelectedItem.ToString());
            cm.Parameters.AddWithValue("@CCCD", txtCCCD.Text);
            cm.Parameters.AddWithValue("@SDT", txtSDT.Text);
            cm.Parameters.AddWithValue("@DiaChi", txtDiachi.Text);
            cm.Parameters.AddWithValue("@ChucVu", cmbChucvu.SelectedItem.ToString());
            cm.Parameters.AddWithValue("@HinhAnh",b);
            cm.Parameters.AddWithValue("@TaiKhoan", txtTaiKhoan.Text);
            cm.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text);

            cm.ExecuteNonQuery();

            MessageBox.Show("Thêm thành công!");
            NHANVIEN1 formNV = Application.OpenForms["NHANVIEN1"] as NHANVIEN1;
            if (formNV != null)
            {
                formNV.RefreshEmployeeList();
            }
            cn.Close();
            this.Close();
        }

    }
}
