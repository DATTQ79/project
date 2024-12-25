using Microsoft.Office.Interop.Excel;
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
    public partial class TKDOANHTHU : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        
        public TKDOANHTHU()
        {
            InitializeComponent();
            labThang.Visible = false;
            cmbThang.Visible = false;
            labQuy.Visible = false;
            cmbQuy.Visible = false;
            InitializeDatabaseConnection();
           
        }

        private void cmbLon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLon.SelectedItem.ToString() == "Tháng")
            {
                labThang.Visible=true;
                cmbThang.Visible = true;
                labQuy.Visible=false;
                cmbQuy.Visible = false;
            }
            else if (cmbLon.SelectedItem.ToString() == "Quý")
            {
                labQuy.Visible = true;
                cmbQuy.Visible = true;
                labThang.Visible = false;
                cmbThang.Visible = false;
            }
            else
            {
                labThang.Visible = false;
                cmbThang.Visible = false;
                labQuy.Visible = false;
                cmbQuy.Visible = false;
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
        
        private void cmbThang_Click(object sender, EventArgs e)
        {
            int count = 0;
            int sum = 0;

            cn.Open();
            string thang = cmbThang.Text;
            string nam = cmbNam.Text;
            cm = new SqlCommand("SELECT TongTien FROM HoaDon WHERE MONTH(NgayLap) = @Thang AND YEAR(NgayLap) = @Nam", cn);
            cm.Parameters.AddWithValue("@Thang", thang);
            cm.Parameters.AddWithValue("@Nam", nam);
            SqlDataReader dr = cm.ExecuteReader();

            while (dr.Read())
            {
                int tt = Convert.ToInt32(dr["TongTien"]);
                sum += tt;
                count++; // Increment the count for each invoice
            }

            dr.Close();
            cn.Close();

            // Display total sum and count
            labTongtien.Text = sum.ToString();
            labSoHD.Text = count.ToString();
        }

       

        private void cmbQuy_Click(object sender, EventArgs e)
        {
            int count = 0;
            int sum = 0;

            cn.Open();
            string quy = cmbQuy.Text;
            string nam = cmbNam.Text;
            cm = new SqlCommand("SELECT TongTien FROM HoaDon WHERE DATEPART(QUARTER, NgayLap) = @Quy AND YEAR(NgayLap) = @Nam", cn);
            cm.Parameters.AddWithValue("@Quy", quy);
            cm.Parameters.AddWithValue("@Nam", nam);
            SqlDataReader dr = cm.ExecuteReader();

            while (dr.Read())
            {
                int tt = Convert.ToInt32(dr["TongTien"]);
                sum += tt;
                count++; // Increment the count for each invoice
            }

            dr.Close();
            cn.Close();

            // Display total sum and count
            labTongtien.Text = sum.ToString();
            labSoHD.Text = count.ToString();
        }

        private void cmbNam_Click(object sender, EventArgs e)
        {
            int count = 0;
            int sum = 0;

            cn.Open();
            string nam = cmbNam.Text;
            cm = new SqlCommand("SELECT TongTien FROM HoaDon WHERE YEAR(NgayLap) = @Nam", cn);
            cm.Parameters.AddWithValue("@Nam", nam);
            SqlDataReader dr = cm.ExecuteReader();

            while (dr.Read())
            {
                int tt = Convert.ToInt32(dr["TongTien"]);
                sum += tt;
                count++; // Increment the count for each invoice
            }

            dr.Close();
            cn.Close();

            // Display total sum and count
            labTongtien.Text = sum.ToString();
            labSoHD.Text = count.ToString();
        }

        private void TKDOANHTHU_Load(object sender, EventArgs e)
        {

        }
    }
}
