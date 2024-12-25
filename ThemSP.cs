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
    public partial class ThemSP : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        public ThemSP()
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
            cm = new SqlCommand("INSERT INTO SanPham VALUES(@MaSP,@TenSP,@NSX,@LoaiSP,@XuatSu,@Gia,@SoLuong,@HinhAnh,@NgaySX)", cn);

            cm.Parameters.AddWithValue("@MaSP", txtMasp.Text);
            cm.Parameters.AddWithValue("@TenSP", txtTensp.Text);
            cm.Parameters.AddWithValue("@NSX", cmbNSX.SelectedItem.ToString());
            cm.Parameters.AddWithValue("@LoaiSP", cmbLoaisp.SelectedItem.ToString());
            cm.Parameters.AddWithValue("@XuatSu", cmbXuatsu.SelectedItem.ToString());
            cm.Parameters.AddWithValue("@Gia", txtGia.Text);
            cm.Parameters.AddWithValue("@NgaySX", dtpNgaySX.Value);
            cm.Parameters.AddWithValue("@SoLuong", menberSL.Text);
            cm.Parameters.AddWithValue("@HinhAnh", b);

            cm.ExecuteNonQuery();

            MessageBox.Show("Thêm thành công!");
            SANPHAM1 formSP = Application.OpenForms["SANPHAM1"] as SANPHAM1;
            if (formSP != null)
            {
                formSP.RefreshEmployeeList();
            }
            cn.Close();
            this.Close();
        }

        private void txthan_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtHH_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
