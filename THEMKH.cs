using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTNNhom10
{
    public partial class THEMKH : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        public THEMKH()
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
        private void btnThem_Click(object sender, EventArgs e)
        {
            cn.Open();
            cm = new SqlCommand("INSERT INTO KhachHang VALUES(@MaKH,@TenKH,@NgaySinh,@GioiTinh,@SDT)", cn);

            cm.Parameters.AddWithValue("@MaKH", txtMaKH.Text);
            cm.Parameters.AddWithValue("@TenKH", txtTenKH.Text);
            cm.Parameters.AddWithValue("@NgaySinh", dtpNgaysinh.Value);
            cm.Parameters.AddWithValue("@GioiTinh", cmbGioitinh.SelectedItem.ToString());
            cm.Parameters.AddWithValue("@SDT", txtSDT.Text);

            cm.ExecuteNonQuery();

            MessageBox.Show("Thêm khách hàng thành công!");
            cn.Close();
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
           this.Close();
        }
        public string temp;
        private void THEMKH_Load(object sender, EventArgs e)
        {
            txtSDT.Text = temp;
        }
    }
}
