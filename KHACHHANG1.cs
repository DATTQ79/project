using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTNNhom10
{
    public partial class KHACHHANG1 : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable dt = new DataTable();
        public KHACHHANG1()
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
            cm = new SqlCommand("SELECT * FROM KhachHang", cn);
            adapter.SelectCommand = cm;
            dt.Clear();
            adapter.Fill(dt);
            dgvKhachhang.DataSource = dt;
        }
       

        private void KHACHHANG1_Load(object sender, EventArgs e)
        {
            cn.Open();
            loatdata();
            cn.Close();
        }

        private void dgvKhachhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvKhachhang.CurrentRow.Index;
            labMa.Text = dgvKhachhang.Rows[i].Cells[0].Value.ToString();
            txtHoten.Text = dgvKhachhang.Rows[i].Cells[1].Value.ToString();
            dtpNgaysinh.Text = dgvKhachhang.Rows[i].Cells[2].Value.ToString();
            cmbGioitinh.Text = dgvKhachhang.Rows[i].Cells[3].Value.ToString();
            txtSDT.Text = dgvKhachhang.Rows[i].Cells[4].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            cn.Open();
            cm = new SqlCommand("DELETE FROM KhachHang WHERE MaKH = '"+labMa.Text+"'",cn);
            cm.ExecuteNonQuery();
            loatdata();
            cn.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            cn.Open();
            cm = new SqlCommand("UPDATE KhachHang SET TenKH = '"+txtHoten.Text+"', NgaySinh = '"+dtpNgaysinh.Text+"', GioiTinh = '"+cmbGioitinh.Text+"', SDT = '"+txtSDT.Text +"' WHERE MaKH = '"+labMa.Text +"'", cn);
            cm.ExecuteNonQuery();
            loatdata();
            cn.Close();

        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
