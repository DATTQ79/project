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
    public partial class Login : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        
        public Login()
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
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                string tk = txtUsename.Text;
                string mk = txtPassword.Text;
                cm = new SqlCommand("SELECT * FROM NhanVien WHERE TaiKhoan = @username AND MatKhau = @password", cn);
                cm.Parameters.AddWithValue("@username", tk);
                cm.Parameters.AddWithValue("@password", mk);

                dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    string chucVu = dr["ChucVu"].ToString();
                    HOME h = new HOME();
                    h.taikhoan1 = txtUsename.Text;
                    h.ShowDialog();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại");
                }
               ;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
            finally
            {
                if (dr != null)
                    dr.Close();
                if (cn != null && cn.State == System.Data.ConnectionState.Open)
                    cn.Close();
            }
           
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        
        private void Login_Load(object sender, EventArgs e)
        {
             
        }
    }
}
