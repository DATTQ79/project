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
    public partial class SUASP : Form
    {
        SqlConnection cn;
        private string employeeID;

        public string EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }
        public SUASP()
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
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
            }
        }
        private void LoadEmployeeData()
        {
            try
            {
                // Open connection and execute SQL query to retrieve employee data
                cn.Open();
                SqlCommand cm = new SqlCommand("SELECT * FROM SanPham WHERE TenSP = @tenSP", cn);
                cm.Parameters.AddWithValue("@tenSP", employeeID);

                SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    // Populate form fields with retrieved data
                    labMaSp.Text = dr["MaSP"].ToString();
                    txtTensp.Text = dr["TenSP"].ToString();
                    txtNSX.Text = dr["NSX"].ToString();
                    txtLoaisp.Text = dr["LoaiSP"].ToString();
                    txtXuatsu.Text = dr["XuatSu"].ToString();
                    txtGia.Text = dr["Gia"].ToString();
                    txtNgaySX.Text = dr["NgaySX"].ToString();
                    menberSL.Text = dr["Soluong"].ToString();
                   

                    // Display employee image
                    byte[] imageData = (byte[])dr["HinhAnh"];
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên cần sửa.");
                    this.Close(); // Close the form if employee data is not found
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin nhân viên: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            try
            {
                // Open connection and execute SQL update command
                cn.Open();
                SqlCommand cm = new SqlCommand("UPDATE SanPham SET Gia = @gia, SoLuong = @soluong WHERE TenSP = @tenSP", cn);
        
                cm.Parameters.AddWithValue("@gia", txtGia.Text);
                cm.Parameters.AddWithValue("@soluong", menberSL.Text);
                cm.Parameters.AddWithValue("@tenSP", employeeID);

                int rowsAffected = cm.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật thông tin sản phẩm thành công!");
                    this.Close(); // Close the form after successful update
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật thông tin sản phẩm.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi cập nhật thông tin sản phẩm: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void SUASP_Load(object sender, EventArgs e)
        {
            LoadEmployeeData();
        }
    }
}
