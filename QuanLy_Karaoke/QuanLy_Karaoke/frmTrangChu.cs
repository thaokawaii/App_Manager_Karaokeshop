using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLy_Karaoke
{
    public partial class frmTrangChu : Form
    {
        public frmTrangChu()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            bunifuFormDock1.SubscribeControlToDragEvents(bunifuShadowPanel1);
            
        }

        private void btn_TrangChu_Click(object sender, EventArgs e)
        {
            pictureBox1.Top = ((Control)sender).Top;
        }

        private void btn_PhongHat_Click(object sender, EventArgs e)
        {
            pictureBox1.Top = ((Control)sender).Top;
        }

        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {
            pictureBox1.Top = ((Control)sender).Top;
        }

        private void btn_KhachHang_Click(object sender, EventArgs e)
        {
            pictureBox1.Top = ((Control)sender).Top;
        }

        private void btn_KhoHang_Click(object sender, EventArgs e)
        {
            pictureBox1.Top = ((Control)sender).Top;
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            pictureBox1.Top = ((Control)sender).Top;
        }

        private void btn_CaiDat_Click(object sender, EventArgs e)
        {
            pictureBox1.Top = ((Control)sender).Top;
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else 
                WindowState = FormWindowState.Normal;
        }

        private void bunifuShadowPanel2_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
           
        }
    }
}
