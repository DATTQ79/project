using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTNNhom10
{
    public partial class NHANVIEN : Form
    {
        public NHANVIEN()
        {
            InitializeComponent();
            SelectToolStripMenuItem();
        }
        private Form curren;
        private void OpenChilForm(Form chilform)
        {
            if (curren != null)
            {
                curren.Close();
            }
            curren = chilform;
            chilform.TopLevel = false;
            chilform.FormBorderStyle = FormBorderStyle.None;
            chilform.Dock = DockStyle.Fill;
            panel_Body.Controls.Add(chilform);
            panel_Body.Tag = chilform;
            chilform.BringToFront();
            chilform.Show();
        }
        
        private void SelectToolStripMenuItem()
        {

            ToolStripItem[] items = menuStrip1.Items.Find("menuNhanvien", true);

            // Kiểm tra xem mục đã được tìm thấy hay không
            if (items.Length > 0 && items[0] is ToolStripMenuItem menuItem)
            {
                // Chọn mục
                menuItem.PerformClick();
            }
        }

        private void menuNhanvien_Click(object sender, EventArgs e)
        {
            OpenChilForm(new NHANVIEN1());
        }

        private void menuTK_Click(object sender, EventArgs e)
        {
            OpenChilForm(new THONGKENV());
        }
    }
}
