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

    public partial class THONGKESP : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable dt = new DataTable();
        public THONGKESP()
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
          
            cm = new SqlCommand("SELECT * FROM SanPham", cn);
            adapter.SelectCommand = cm;
            dt.Clear();
            adapter.Fill(dt);
            hienthi.DataSource = dt;
     
        }
        private void THONGKESP_Load(object sender, EventArgs e)
        {
            cn.Open();
            loatdata();
            cn.Close();

        }

        private void timSP_TextChanged(object sender, EventArgs e)
        {
            string name = timSP.Text.Trim();
            if (name == "")
            {
                THONGKESP_Load(sender, e);
            }
            else
            {

                cm = new SqlCommand("SELECT * FROM SanPham WHERE MaSP LIKE '%" + name + "%' OR TenSP LIKE '%" + name + "%'", cn);
                adapter.SelectCommand = cm;
                dt.Clear();
                adapter.Fill(dt);
                hienthi.DataSource = dt;
            }
        }
    }
}
