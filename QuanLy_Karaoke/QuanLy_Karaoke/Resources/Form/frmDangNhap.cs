using Bunifu.UI.WinForms;
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
    public partial class frmDangNhap : Form
    {
        ConnectDB c = new ConnectDB();
        public frmDangNhap()
        {
            InitializeComponent();
            bunifuFormDock1.SubscribeControlToDragEvents(bunifuPictureBox1);
        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tb_MatKhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
       frmCaiDat th = new frmCaiDat();
        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            try
            {

               string lenh = "exec SP_AuthoLogin '"+tb_TenTK.Text+"','"+tb_MatKhau.Text+"'";
              object ma=  c.trave(lenh);
                int code = Convert.ToInt32(ma);
                if (code == 1)
                {
                    MessageBox.Show("Chào mừng bạn đăng nhập");

                    th.Message = tb_TenTK.Text;
                    th.ShowDialog();
                    this.Hide();
                    
                }
                else if (code == 0)
                {
                    MessageBox.Show("Chào mừng bạn đăng nhập ADMIN");
                    th.Message = tb_TenTK.Text;
                    frmTrangChu ad = new frmTrangChu();
                     ad.ShowDialog();
                    this.Hide();

                }
                else if (code == 2)
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tb_MatKhau.Text = "";
                  tb_TenTK.Text = "";
                   tb_TenTK.Focus();
                }
                else
                {
                    MessageBox.Show("Tài khoản không tồn tại !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tb_MatKhau.Text = "";
                    tb_TenTK.Text = "";
                    tb_TenTK.Focus();
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       public void frmDangNhap_Load(object sender, EventArgs e)
        {
            tb_TenTK.Focus();
            tb_TenTK.Text = "";
            tb_MatKhau.Text="";
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            tb_MatKhau.PasswordChar = (char)0;
        }


        private void ck_Show_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_Show.Checked)
            {
               tb_MatKhau.PasswordChar = (char)0;
            }
            else
            {
               tb_MatKhau.PasswordChar = '*';
            }
        }

        private void tb_TenTK_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tb_TenTK.Text))
            {
                e.Cancel = true;
                tb_TenTK.Focus();
                errorProvider1.SetError(tb_TenTK, "Hãy nhập tên đăng nhập trước!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tb_TenTK, null);
            }
        }
    }
}
