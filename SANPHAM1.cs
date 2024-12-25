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
    public partial class SANPHAM1 : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        public SANPHAM1()
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
            ThemSP them = new ThemSP();
            them.Show();
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
        private void getdata()
        {
            fpannel_Body.Controls.Clear();
            if (cn.State != ConnectionState.Closed)
            {
                cn.Close();
            }
            cn.Open();
            cm = new SqlCommand("SELECT * FROM SanPham", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                CreateEmployeePanel(dr);
            }
            dr.Close(); // Close the SqlDataReader
            cn.Close();

            // Close the SqlConnection
        }
        private void CreateEmployeePanel(SqlDataReader dr)
        {

            string tenSP = dr["TenSP"].ToString();
            Panel panel = new Panel();
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Size = new Size(200, 250); // Increased height to accommodate buttons

            PictureBox pictureBox = new PictureBox();
            byte[] imageData = (byte[])dr["HinhAnh"];
            pictureBox.Image = ByteArrayToImage(imageData);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Size = new Size(120, 120);
            pictureBox.Location = new Point(40, 20);
            panel.Controls.Add(pictureBox);

            Label nameLabel = new Label();
            nameLabel.Text = "Tên: " + tenSP;
            nameLabel.Location = new Point(60, 150);
            panel.Controls.Add(nameLabel);

            Label giaLabel = new Label();
            giaLabel.Text = "Giá: " + dr["Gia"].ToString();
            giaLabel.Location = new Point(60, 180);
            panel.Controls.Add(giaLabel);

            Button suaButton = new Button();
            suaButton.Text = "Sửa";
            suaButton.Size = new Size(60, 30);
            suaButton.Location = new Point(20, 210);
            suaButton.Click += (sender, e) =>
            {

                OpenEditForm(tenSP);
            };
            panel.Controls.Add(suaButton);

            Button xoaButton = new Button();
            xoaButton.Text = "Xóa";
            xoaButton.Size = new Size(60, 30);
            xoaButton.Location = new Point(100, 210);
            xoaButton.Click += (sender, e) =>
            {
                // Xử lý sự kiện xóa thông tin nhân viên
                MessageBox.Show("Delete button clicked for employee: " + tenSP);
                if (ConfirmDelete(tenSP))
                {
                    DeleteEmployee(tenSP);
                }
            };
            panel.Controls.Add(xoaButton);

            // Hide the buttons initially
            suaButton.Visible = false;
            xoaButton.Visible = false;

            // Event handler for panel click to toggle button visibility
            panel.Click += (sender, e) =>
            {
                // Toggle button visibility
                suaButton.Visible = !suaButton.Visible;
                xoaButton.Visible = !xoaButton.Visible;
            };

            // Add panel to the FlowLayoutPanel
            fpannel_Body.Controls.Add(panel);

        }
        private bool ConfirmDelete(string tenSP)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return (result == DialogResult.Yes);
        }

        // Hàm xóa nhân viên
        private void DeleteEmployee(string tenSP)
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("DELETE FROM SanPham WHERE TenSP = @TenSP", cn);
                cm.Parameters.AddWithValue("@tenSP", tenSP);
                int rowsAffected = cm.ExecuteNonQuery();
                Console.WriteLine("Rows affected: " + rowsAffected); // Debug print
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Đã xóa sản phẩm thành công!");
                    RefreshEmployeeList(); // Refresh the employee list after successful deletion
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm để xóa.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("sản phẩm đang được bán ","Thông báo",MessageBoxButtons.OK);
            }
            finally
            {
                cn.Close(); // Close the SqlConnection
            }
        }

        
        private void OpenEditForm(string tenSP)
        {
            if (fpannel_Body.Controls.Count > 0)
            {
                bool productFound = false;
                // Look for the selected panel
                foreach (Control control in fpannel_Body.Controls)
                {
                    if (control is Panel panel && panel.BorderStyle == BorderStyle.FixedSingle)
                    {
                        Label nameLabel = panel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Text.StartsWith("Tên:"));
                        if (nameLabel != null)
                        {
                            string[] parts = nameLabel.Text.Split(':');
                            if (parts.Length == 2)
                            {
                                string productName = parts[1].Trim(); // Extract product name
                                if (productName == tenSP)
                                {
                                    productFound = true;
                                    // Open the SUASP form for editing with the selected product name
                                    SUASP editForm = new SUASP();
                                    editForm.EmployeeID = tenSP; // Pass product name as ID
                                    editForm.ShowDialog();
                                    getdata(); // Refresh the product list after editing
                                    break; // Exit the loop once the selected panel is found
                                }
                            }
                        }
                    }
                }
                if (!productFound)
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Không có sản phẩm nào để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void RefreshEmployeeList()
        {
            fpannel_Body.Controls.Clear();
            getdata();
        }

        private void SANPHAM1_Load(object sender, EventArgs e)
        {
            getdata();
        }

        private void txtTimruou_TextChanged(object sender, EventArgs e)
        {
            string name = txtTimruou.Text.Trim();

            if (name == "")
            {
                SANPHAM1_Load(sender, e);
            }
            else
            {
                fpannel_Body.Controls.Clear();
                cn.Open();
                cm = new SqlCommand("SELECT * FROM SanPham WHERE TenSP LIKE @name OR Gia LIKE @name", cn);
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
    }
}
