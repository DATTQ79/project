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
    public partial class SUATTNV : Form
    {
        SqlConnection cn;
        private string employeeID;

        public string EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }

        public SUATTNV()
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
                SqlCommand cm = new SqlCommand("SELECT * FROM NhanVien WHERE MaNV = @maNV", cn);
                cm.Parameters.AddWithValue("@maNV", employeeID);

                SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    // Populate form fields with retrieved data
                    labMaNv.Text = dr["MaNV"].ToString();
                    txtTenNV.Text = dr["TenNV"].ToString();
                    dtpNgaysinh.Value = Convert.ToDateTime(dr["NgaySinh"]);
                    cmbGioitinh.Text = dr["GioiTinh"].ToString();
                    txtCCCD.Text = dr["CCCD"].ToString();
                    txtSDT.Text = dr["SDT"].ToString();
                    txtDiachi.Text = dr["DiaChi"].ToString();
                    cmbChucvu.Text = dr["ChucVu"].ToString();

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

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                // Open connection and execute SQL update command
                cn.Open();
                SqlCommand cm = new SqlCommand("UPDATE NhanVien SET TenNV = @tenNV, NgaySinh = @ngaySinh, GioiTinh = @gioiTinh, CCCD = @cccd, SDT = @sdt, DiaChi = @diaChi, ChucVu = @chucVu WHERE MaNV = @maNV", cn);
                cm.Parameters.AddWithValue("@tenNV", txtTenNV.Text);
                cm.Parameters.AddWithValue("@ngaySinh", dtpNgaysinh.Value);
                cm.Parameters.AddWithValue("@gioiTinh", cmbGioitinh.Text);
                cm.Parameters.AddWithValue("@cccd", txtCCCD.Text);
                cm.Parameters.AddWithValue("@sdt", txtSDT.Text);
                cm.Parameters.AddWithValue("@diaChi", txtDiachi.Text);
                cm.Parameters.AddWithValue("@chucVu", cmbChucvu.Text);
                cm.Parameters.AddWithValue("@maNV", employeeID);

                int rowsAffected = cm.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật thông tin nhân viên thành công!");
                    this.Close(); // Close the form after successful update
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật thông tin nhân viên.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi cập nhật thông tin nhân viên: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void SUATTNV_Load(object sender, EventArgs e)
        {
            LoadEmployeeData();
        }
    }
}
