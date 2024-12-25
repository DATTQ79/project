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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace BTNNhom10
{
    public partial class TAOHD : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable dt = new DataTable();
        double thanhtien;
        public string ten;
        public TAOHD()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            DataTable dz = new DataTable(); // Khởi tạo DataTable mới
            InitializeDataTables(dz);

        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            THEMKH themKH = new THEMKH();
            themKH.temp = cmbSDT.Text;
            themKH.Show();
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

        private void cmbSDT_Click(object sender, EventArgs e)
        {
            string selectedPhoneNumber = cmbSDT.Text;

            cn.Open();

            cm = new SqlCommand("SELECT MaKH, TenKH, GioiTinh, NgaySinh FROM KhachHang WHERE SDT = @SDT", cn);

            cm.Parameters.AddWithValue("@SDT", selectedPhoneNumber);

            using (dr = cm.ExecuteReader())
            {
                if (dr.Read())
                {
                    labMaKH.Text = dr["MaKH"].ToString();
                    labTenKH.Text = dr["TenKH"].ToString();
                    labGioiTinh.Text = dr["GioiTinh"].ToString();
                    labNgaySinh.Text = dr["NgaySinh"].ToString();
                }
            }
            cn.Close();
        }
        public string GenerateInvoice()
        {
            string invoiceNumber = "HD-" + DateTime.Now.ToString("yyyyMMddHHmmss");
            return invoiceNumber;

        }
        public string NT()
        {
            string nt = DateTime.Now.ToString("dd/MM/yyyy");
            return nt;
        }


        private void btnTaoHD_Click(object sender, EventArgs e)
        {
            cn.Open();

            cm = new SqlCommand("SELECT MaNV,TenNV FROM NhanVien WHERE TaiKhoan = @TaiKhoan", cn);
            cm.Parameters.AddWithValue("@TaiKhoan", ten);
            using (dr = cm.ExecuteReader())
            {
                if (dr.Read())
                {
                    string manv = dr["MaNV"].ToString();
                    string tennv = dr["TenNV"].ToString();
                    labMaNV.Text = manv;
                    labTenNV.Text = tennv;
                }
            }

            string invoice = GenerateInvoice();
            labMaHD.Text = invoice;
            string ntv = NT();
            labNgayTao.Text = ntv;
            cn.Close();


            cn.Open();
            cm = new SqlCommand("SELECT MaSP,TenSP,NSX,XuatSu,Gia,HinhAnh FROM SanPham", cn);
            adapter.SelectCommand = cm;
            dt.Clear();
            adapter.Fill(dt);
            htSanpham.DataSource = dt;
            cn.Close();

            // Kiểm tra xem MaKH có được chọn hay không
            if (!string.IsNullOrEmpty(labMaKH.Text))
            {
                cn.Open();
                cm = new SqlCommand("INSERT INTO HoaDon VALUES(@MaHD, @MaNV, @MaKH, @NgayLap, @TongTien)", cn);
                cm.Parameters.AddWithValue("@MaHD", labMaHD.Text);
                cm.Parameters.AddWithValue("@MaNV", labMaNV.Text);
                cm.Parameters.AddWithValue("@MaKH", labMaKH.Text);
                cm.Parameters.AddWithValue("@NgayLap", DateTime.Now);
                cm.Parameters.AddWithValue("@TongTien", menberSL.Text);

                cm.ExecuteNonQuery();
                cn.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng trước khi tạo hóa đơn!");
            }
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
        private void htSanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < htSanpham.Rows.Count - 1)
            {
                DataGridViewRow selectedRow = htSanpham.Rows[e.RowIndex];
                byte[] imageData = (byte[])selectedRow.Cells["HinhAnh"].Value;
                pictureBox.Image = ByteArrayToImage(imageData);
            }
        }

        public string XV()
        {
            string nt = DateTime.Now.ToString("HHmmss");
            return nt;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            
            if (htSanpham.SelectedRows.Count > 0 && htSanpham.DataSource != null)
            {
                int rowIndex = htSanpham.SelectedRows[0].Index;
                string maSP = htSanpham.Rows[rowIndex].Cells["MaSP"].Value.ToString();
                string tenSP = htSanpham.Rows[rowIndex].Cells["TenSP"].Value.ToString();
                int gia;
                int.TryParse(htSanpham.Rows[rowIndex].Cells["Gia"].Value.ToString(), out gia);
                int soLuong = Convert.ToInt32(menberSL.Text);

                thanhtien = gia * soLuong;
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
                string tg = XV();
                cn.Open();
                cm = new SqlCommand("INSERT INTO ChiTietHD VALUES(@MaHD, @MaSP, @TenSP, @Gia, @SoLuong, @ThanhTien,@tg)", cn);
                cm.Parameters.AddWithValue("@MaHD", labMaHD.Text);
                cm.Parameters.AddWithValue("@MaSP", maSP); // Thêm tham số @MaSP
                cm.Parameters.AddWithValue("@TenSP", tenSP);
                cm.Parameters.AddWithValue("@Gia", gia);
                cm.Parameters.AddWithValue("@SoLuong", soLuong);
                cm.Parameters.AddWithValue("@ThanhTien", thanhtien);
                cm.Parameters.AddWithValue("@tg", tg);
                cm.ExecuteNonQuery();
                cn.Close();
            }
            DataTable mc = new DataTable();
            string maHD = labMaHD.Text;
            cn.Open();
            cm = new SqlCommand("SELECT MaSP, TenSP, Gia, SoLuong, ThanhTien,tg FROM ChiTietHD WHERE MaHD = @MaHD", cn);
            cm.Parameters.AddWithValue("@MaHD", maHD);
            mc.Clear();
            adapter.SelectCommand = cm;
            adapter.Fill(mc);
            HtttHoadon.DataSource = mc;
            cn.Close();
        }

        private void InitializeDataTables(DataTable dataTable)
        {
            // Khởi tạo cấu trúc của bảng DataTable
            dataTable.Columns.Add("MaSP", typeof(string));
            dataTable.Columns.Add("TenSP", typeof(string));
            dataTable.Columns.Add("Gia", typeof(int)); // Giả sử Gia là kiểu số nguyên, điều chỉnh kiểu dữ liệu nếu cần
            dataTable.Columns.Add("SoLuong", typeof(int)); // Giả sử SoLuong là kiểu số nguyên, điều chỉnh kiểu dữ liệu nếu cần
            dataTable.Columns.Add("ThanhTien", typeof(double)); // Giả sử ThanhTien là kiểu số thực, điều chỉnh kiểu dữ liệu nếu cần
        }


        private void timruou_TextChanged(object sender, EventArgs e)
        {
            string name = timruou.Text.Trim();
            if (name == "")
            {
                TAOHD_Load(sender, e);
            }
            else
            {

                cm = new SqlCommand("SELECT * FROM SanPham WHERE MaSP LIKE '%" + name + "%' OR TenSP LIKE '%" + name + "%'", cn);
                adapter.SelectCommand = cm;
                dt.Clear();
                adapter.Fill(dt);
                htSanpham.DataSource = dt;
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (HtttHoadon.SelectedRows.Count > 0 && HtttHoadon.DataSource != null)
            {
                int rowIndex = HtttHoadon.SelectedRows[0].Index;
                string tg = HtttHoadon.Rows[rowIndex].Cells["tg"].Value.ToString();
                DataTable mc = new DataTable();
                cm = new SqlCommand("DELETE FROM ChiTietHD WHERE tg = @tg", cn);
                cm.Parameters.AddWithValue("@tg", tg);
                adapter.SelectCommand = cm;
                adapter.Fill(mc);
                HtttHoadon.Rows.RemoveAt(rowIndex);
                cn.Close();
            }
        }

   

        private void HtttHoadon_DataSourceChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }
        private void TinhTongTien()
        {
            double tong = 0;
            foreach (DataGridViewRow row in HtttHoadon.Rows)
            {
                // Kiểm tra xem dòng đó có được hiển thị và không phải là dòng mới
                if (!row.IsNewRow && row.Visible)
                {
                    // Lấy giá trị của cột "ThanhTien"
                    if (double.TryParse(row.Cells["ThanhTien"].Value.ToString(), out double cellValue))
                    {
                        // Thêm giá trị vào tổng
                        tong += cellValue;
                    }
                }
                // Kiểm tra xem giá trị của hàng đã bị xóa
            }
            labtongtien.Text = tong.ToString();
        }

        private void HtttHoadon_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            TinhTongTien();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }


        private void btnthanhtoan_Click(object sender, EventArgs e)
        {
            FORMTHANHTOAN tp = new FORMTHANHTOAN();
            tp.date = labNgayTao.Text;
            tp.maHD = labMaHD.Text;
            tp.maNV = labMaNV.Text;
            tp.maKH = labMaKH.Text;
            tp.tenKH = labTenKH.Text;
            tp.tt = labtongtien.Text;
            
            tp.ShowDialog();
           
        }

        private void TAOHD_Load(object sender, EventArgs e)
        {

        }
    
    }
}
