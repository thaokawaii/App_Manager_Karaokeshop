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
    public partial class ThongTinNV : Form
    {
        ConnectDB c = new ConnectDB();
        public ThongTinNV()
        {
            InitializeComponent();
        }
        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        public void ThongTin()
        {
            string ten = _message;
            string lenh = "select TENNV FROM NHANVIEN where MANV='"+ten+"'";
            object p= c.trave(lenh);
            string kq = p.ToString();
            txt_ten.Text = kq;
            string lenh1 = "select TENDN FROM NHANVIEN where MANV='" + ten + "'";
            object p1 = c.trave(lenh1);
            string kq1 = p1.ToString();
           txt_tenDn.Text = kq1;
            string lenh2 = "select MATKHAU FROM NHANVIEN where MANV='" + ten + "'";
            object p2 = c.trave(lenh2);
            string kq2 = p2.ToString();
          txt_MK.Text = kq2;
        }

        private void ThongTinNV_Load(object sender, EventArgs e)
        {
            ThongTin();
        }

        private void button_Thoát_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn muốn thoát", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
               
                this.Close();
            }
        }

        private void ck_Show_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_Show.Checked)
            {
               txt_MK.PasswordChar = (char)0;
                txt_Mkmoi.PasswordChar = (char)0;
                txt_mkNL.PasswordChar = (char)0;
            }
            else
            {
                txt_MK.PasswordChar = '*';
                txt_Mkmoi.PasswordChar = '*';
                txt_mkNL.PasswordChar = '*';
              
            }
        }

        private void button_XN_Click(object sender, EventArgs e)
        {
            try
            {
                string lenh = "Update NHANVIEN set MATKHAU='" + txt_Mkmoi.Text + "' where TENDN='" + txt_tenDn.Text + "'";
                c.thuchienlenh(lenh);
                MessageBox.Show("Thành công");
            }
            catch
            {
                MessageBox.Show("Thất bại");
            }
           

        }

        private void txt_mkNL_Validating(object sender, CancelEventArgs e)
        {
            if (txt_Mkmoi.Text!=txt_mkNL.Text)
            {
                e.Cancel = true;
                button_XN.Enabled = false;
                txt_mkNL.Focus();
                errorProvider1.SetError(txt_mkNL, "Mật khẩu không đúng");
            }
            else
            {
                e.Cancel = false;
              
                button_XN.Enabled = true;
                errorProvider1.SetError(txt_mkNL, null);
            }
        }
    }
}
