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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using COMExcel = Microsoft.Office.Interop.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace BTNNhom10
{
    public partial class FORMTHANHTOAN : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        public string maSP;
        public string tenSP;
        public string gia;
        public string sl;
        public string thanhtien;
        public string date;
        public string maHD;
        public string maNV;
        public string maKH;
        public string tenKH;
        public string tt;
        public FORMTHANHTOAN()
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
        private void FORMTHANHTOAN_Load(object sender, EventArgs e)
        {
            labngaylap.Text = date;
            labMaHD.Text = maHD;
            labMaNV.Text = maNV;
            labMaKH.Text = maKH;
            labTenKH.Text = tenKH;
            labTongtien.Text = tt;
        }

        private void tientra_TextChanged(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(tientra.Text) && int.TryParse(tientra.Text, out int KD))
            {
                int kt = int.Parse(tt);
                int tralai = KD -kt;

                labTralai.Text = tralai.ToString();
            }
        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            cn.Open();
            cm = new SqlCommand("UPDATE HoaDon SET TongTien = '" + labTongtien.Text + "' WHERE MaHD = '"+ labMaHD.Text + "'", cn);
            cm.ExecuteNonQuery();
            MessageBox.Show("thanh toan thanh cong ");
            ExportToTextFile();
            this.Close();
            cn.Close();
        }
        private void ExportToTextFile()
        {
            try
            {
                string directoryPath = @"D:\HoaDon";
                string fileName = $"Invoice_{maHD}.pdf";
                string filePath = Path.Combine(directoryPath, fileName);

           
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                Document document = new Document();
                PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));

              
                document.Open();

             
                Paragraph invoiceInfo = new Paragraph();
                invoiceInfo.Alignment = Element.ALIGN_CENTER;
                invoiceInfo.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16f);
                invoiceInfo.Add($"HÓA ĐƠN BÁN HÀNG\n\n");
                invoiceInfo.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12f);
                invoiceInfo.Add($"Mã hóa đơn: {maHD}\n");
                invoiceInfo.Add($"Ngày lập: {date}\n");
                invoiceInfo.Add($"Mã nhân viên: {maNV}\n");
                invoiceInfo.Add($"Mã khách hàng: {maKH}\n");
                invoiceInfo.Add($"Tên khách hàng: {tenKH}\n\n");
                document.Add(invoiceInfo);

              
                PdfPTable table = new PdfPTable(5);
                table.HorizontalAlignment = Element.ALIGN_CENTER;
                table.WidthPercentage = 100;
                table.SpacingBefore = 10f;
                table.SpacingAfter = 10f;

                PdfPCell cell = new PdfPCell(new Phrase("Thông tin sản phẩm", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12f)));
                cell.Colspan = 5;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);

                table.AddCell("Mã SP");
                table.AddCell("Tên SP");
                table.AddCell("Đơn giá");
                table.AddCell("Số lượng");
                table.AddCell("Thành tiền");

                SqlCommand cmChiTietHD = new SqlCommand("SELECT * FROM ChiTietHD WHERE MaHD = @MaHD", cn);
                cmChiTietHD.Parameters.AddWithValue("@MaHD", maHD);
                SqlDataReader dr = cmChiTietHD.ExecuteReader();

                while (dr.Read())
                {
                    table.AddCell(dr["MaSP"].ToString());
                    table.AddCell(dr["TenSP"].ToString());
                    table.AddCell(dr["Gia"].ToString());
                    table.AddCell(dr["SoLuong"].ToString());
                    table.AddCell(dr["ThanhTien"].ToString());
                }

                document.Add(table);

            
                Paragraph total = new Paragraph();
                total.Alignment = Element.ALIGN_RIGHT;
                total.Add($"Tổng tiền: {tt}");
                document.Add(total);

               
                document.Close();

                MessageBox.Show($"Xuất hóa đơn thành công: {filePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất hóa đơn: " + ex.Message);
            }
        }
    }
}
