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
    public partial class BANHANG : Form
    {
        public string name;
        public string cv;
        public BANHANG()
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
            panelBody.Controls.Add(chilform);
            panelBody.Tag = chilform;
            chilform.BringToFront();
            chilform.Show();
        }

        private void menuTaoHD_Click(object sender, EventArgs e)
        {
            TAOHD thd = new TAOHD();
            thd.ten = name;
            OpenChilForm(thd);

        }

        private void menuHDdatao_Click(object sender, EventArgs e)
        {
            OpenChilForm(new HDDATAO());
        }

        private void menuThongke_Click(object sender, EventArgs e)
        {
            OpenChilForm(new TKDOANHTHU());
        }
        private void SelectToolStripMenuItem()
        {

            ToolStripItem[] items = menuStrip1.Items.Find("menuTaoHD", true);

            // Kiểm tra xem mục đã được tìm thấy hay không
            if (items.Length > 0 && items[0] is ToolStripMenuItem menuItem)
            {
                
                menuItem.PerformClick();
            }
        }

        private void BANHANG_Load(object sender, EventArgs e)
        {
            if (cv != "Qu?n lý")
            {
                menuThongke.Enabled = false;
            }
        }
    }
}
