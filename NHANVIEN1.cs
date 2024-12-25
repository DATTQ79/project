using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BTNNhom10
{
    public partial class NHANVIEN1 : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;

        private Panel pn;

        public NHANVIEN1()
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            THEMNV nv = new THEMNV();
            nv.Show();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Implement functionality for editing employee details
        }

        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            try
            {
                using (var ms = new System.IO.MemoryStream(byteArrayIn))
                {
                    return Image.FromStream(ms);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chuyển đổi hình ảnh: " + ex.Message);
                return null;
            }
        }
       /* private void getdata()
        {
            fpannel_Body.Controls.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT * FROM NhanVien", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                CreateEmployeePanel(dr);
            }
            dr.Close(); // Close the SqlDataReader
            cn.Close(); // Close the SqlConnection
        }
       */
        private void CreateEmployeePanel(SqlDataReader dr)
        {
            Panel panel = new Panel();
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Size = new Size(700, 150); // Điều chỉnh kích thước của mỗi panel chứa thông tin của một nhân viên

            string maNV = dr["MaNV"].ToString();

            Label maNVLabel = new Label();
            maNVLabel.Text = "Mã NV: " + maNV;
            maNVLabel.Location = new Point(10, 10);
            maNVLabel.AutoSize = true;
            panel.Controls.Add(maNVLabel);

            // Label cho Tên NV
            Label tenNVLabel = new Label();
            tenNVLabel.Text = "Tên NV: " + dr["TenNV"].ToString();
            tenNVLabel.Location = new Point(10, 35);
            tenNVLabel.AutoSize = true;
            panel.Controls.Add(tenNVLabel);

            // Label cho Ngày Sinh
            Label ngaySinhLabel = new Label();
            ngaySinhLabel.Text = "Ngày Sinh: " + dr["NgaySinh"].ToString();
            ngaySinhLabel.Location = new Point(10, 60);
            ngaySinhLabel.AutoSize = true;
            panel.Controls.Add(ngaySinhLabel);

            // Label cho Giới Tính
            Label gioiTinhLabel = new Label();
            gioiTinhLabel.Text = "Giới Tính: " + dr["GioiTinh"].ToString();
            gioiTinhLabel.Location = new Point(10, 85);
            gioiTinhLabel.AutoSize = true;
            panel.Controls.Add(gioiTinhLabel);

            // Label cho CCCD
            Label cccdLabel = new Label();
            cccdLabel.Text = "CCCD: " + dr["CCCD"].ToString();
            cccdLabel.Location = new Point(250, 10);
            cccdLabel.AutoSize = true;
            panel.Controls.Add(cccdLabel);

            // Label cho SĐT
            Label sdtLabel = new Label();
            sdtLabel.Text = "SĐT: " + dr["SDT"].ToString();
            sdtLabel.Location = new Point(250, 35);
            sdtLabel.AutoSize = true;
            panel.Controls.Add(sdtLabel);

            // Label cho Địa Chỉ
            Label diaChiLabel = new Label();
            diaChiLabel.Text = "Địa Chỉ: " + dr["DiaChi"].ToString();
            diaChiLabel.Location = new Point(250, 60);
            diaChiLabel.AutoSize = true;
            panel.Controls.Add(diaChiLabel);

            // Label cho Chức Vụ
            Label chucVuLabel = new Label();
            chucVuLabel.Text = "Chức Vụ: " + dr["ChucVu"].ToString();
            chucVuLabel.Location = new Point(250, 85);
            chucVuLabel.AutoSize = true;
            panel.Controls.Add(chucVuLabel);

            // PictureBox cho Hình Ảnh
            PictureBox pictureBox = new PictureBox();
            byte[] imageData = (byte[])dr["HinhAnh"];
            pictureBox.Image = ByteArrayToImage(imageData);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Size = new Size(120, 120);
            pictureBox.Location = new Point(450, 10); // Điều chỉnh vị trí của PictureBox
            panel.Controls.Add(pictureBox);

            Button suaButton = new Button();
            suaButton.Text = "Sửa";
            suaButton.Location = new Point(600, 50);
            suaButton.Click += (sender, e) =>
            {
               
                OpenEditForm(maNVLabel.Text);
            };
            panel.Controls.Add(suaButton);

            // Thêm nút "Xóa"
            Button xoaButton = new Button();
            xoaButton.Text = "Xóa";
            xoaButton.Location = new Point(600, 100);
            xoaButton.Click += (sender, e) =>
            {
                // Xử lý sự kiện xóa thông tin nhân viên
               MessageBox.Show("Delete button clicked for employee: " + maNV);
                if (ConfirmDelete(maNV))
                {
                    DeleteEmployee(maNV);
                }
            };
            panel.Controls.Add(xoaButton);

            // Thêm panel chứa thông tin của một nhân viên vào FlowLayoutPanel
            fpannel_Body.Controls.Add(panel);

        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            string name = txtTim.Text.Trim();

            if (name == "")
            {
                NHANVIEN1_Load(sender, e);
            }
            else
            {
                fpannel_Body.Controls.Clear();
                cn.Open();
                cm = new SqlCommand("SELECT * FROM NhanVien WHERE MaNV LIKE @name OR TenNV LIKE @name", cn);
                cm.Parameters.AddWithValue("@name", "%" + name + "%");
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    CreateEmployeePanel(dr);
                }
                dr.Close();
                cn.Close();
            }
        }
        private bool ConfirmDelete(string maNV)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return (result == DialogResult.Yes);
        }

        // Hàm xóa nhân viên
        private void DeleteEmployee(string maNV)
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("DELETE FROM NhanVien WHERE MaNV = @maNV", cn);
                cm.Parameters.AddWithValue("@maNV", maNV);
                int rowsAffected = cm.ExecuteNonQuery();
                Console.WriteLine("Rows affected: " + rowsAffected); // Debug print
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Đã xóa nhân viên thành công!");
                    RefreshEmployeeList(); // Refresh the employee list after successful deletion
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên để xóa.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message);
            }
            finally
            {
                cn.Close(); // Close the SqlConnection
            }
        }
        

        // Hàm mở form để sửa thông tin nhân viên
        private void OpenEditForm(string maNV)
        {
            if (fpannel_Body.Controls.Count > 0)
            {
                // Look for the selected panel
                foreach (Control control in fpannel_Body.Controls)
                {
                    if (control is Panel panel && panel.BorderStyle == BorderStyle.FixedSingle)
                    {
                        Label maNVLabel = panel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Text.StartsWith("Mã NV:"));
                        if (maNVLabel != null)
                        {
                            string[] parts = maNVLabel.Text.Split(':');
                            if (parts.Length == 2)
                            {
                                string employeeID = parts[1].Trim(); // Extract employee ID

                                // Open the SUATTNV form for editing with the selected employee ID
                                SUATTNV editForm = new SUATTNV();
                                editForm.EmployeeID = employeeID;
                                editForm.ShowDialog();
                                RefreshEmployeeList(); // Refresh the employee list after editing
                                return; // Exit the loop once the selected panel is found
                            }
                        }
                    }
                }
                // If no panel with selected status is found
                MessageBox.Show("Vui lòng chọn nhân viên để sửa.");
            }
            else
            {
                MessageBox.Show("Không có nhân viên nào để sửa.");
            }
        }
        public void RefreshEmployeeList()
        {
            try
            {
                fpannel_Body.Controls.Clear();
                // Ensure the connection is closed before attempting to reopen
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
                cn.Open();
                cm = new SqlCommand("SELECT * FROM NhanVien", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    CreateEmployeePanel(dr);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi làm mới danh sách nhân viên: " + ex.Message);
            }
            finally
            {
                if (dr != null && !dr.IsClosed)
                {
                    dr.Close();
                }
                if (cn != null && cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }

        private void NHANVIEN1_Load(object sender, EventArgs e)
        {
            RefreshEmployeeList();
        }
    }
}
