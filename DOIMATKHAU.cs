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
    public partial class DOIMATKHAU : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        public string tk2;
        public DOIMATKHAU()
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

        private void btnDMK_Click(object sender, EventArgs e)
        {
            if (txtMKM.Text != txtXNMK.Text)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp.");
                return;
            }

            try
            {
                cn.Open();

                // Use parameterized queries to prevent SQL injection
                cm = new SqlCommand("SELECT COUNT(*) FROM NhanVien WHERE TaiKhoan = @username AND MatKhau = @currentPassword", cn);
                cm.Parameters.AddWithValue("@username", tk2);
                cm.Parameters.AddWithValue("@currentPassword", txtMKHH.Text);

                int userCount = (int)cm.ExecuteScalar();

                if (userCount == 1)
                {
                    cm = new SqlCommand("UPDATE NhanVien SET MatKhau = @newPassword WHERE TaiKhoan = @username AND MatKhau = @currentPassword", cn);
                    cm.Parameters.AddWithValue("@newPassword", txtMKM.Text);

                    int rowsAffected = cm.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Đổi mật khẩu thành công.", "Thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Đổi mật khẩu không thành công.", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu hiện tại không đúng.", "Thông báo", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
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
