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
    public partial class frmKhachHang : Form
    {
        ConnectDB c = new ConnectDB();
        public frmKhachHang()
        {
            InitializeComponent();
        }
        public void tai_KH()
        {
            string lenh = "select MAKH as N'Mã KH',TEN as N'Họ tên',SDT ,DIACHI as N'Địa chỉ',TONGTIEN as N'Tổng tiền' from KHACHHANG";
            dataGridView_KH.DataSource = c.lenh(lenh, "KHACHHANG");
            bingding();

        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            tai_KH();
        }
        public void bingding()
        {
            txt_maKH.DataBindings.Clear();
            txt_tenKh.DataBindings.Clear();
            txt_sdt.DataBindings.Clear();
            txt_diaChi.DataBindings.Clear();
            txt_tongTien.DataBindings.Clear();
            txt_maKH.DataBindings.Add("Text", dataGridView_KH.DataSource, "Mã KH");
            txt_tenKh.DataBindings.Add("Text", dataGridView_KH.DataSource, "Họ tên");
            txt_sdt.DataBindings.Add("Text", dataGridView_KH.DataSource, "SDT");
            txt_diaChi.DataBindings.Add("Text", dataGridView_KH.DataSource, "Địa chỉ");
            txt_tongTien.DataBindings.Add("Text", dataGridView_KH.DataSource, "Tổng tiền");

        }


        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                string lenh0 = "SELECT CONCAT('KH', RIGHT(CONCAT('00',ISNULL(SUBSTRING(max(MAKH),3,2),0) + 1),2)) from KHACHHANG where MAKH like 'KH%'";
                object k = c.trave(lenh0);
                string ma = k.ToString();
                txt_maKH.Text = ma;
                string lenh = "Insert INTO KHACHHANG VALUES('" + ma + "',N'" + txt_tenKh.Text + "','" + txt_sdt.Text + "',N'" + txt_diaChi.Text + "',0)";
                c.thuchienlenh(lenh);

                MessageBox.Show("Thành công");
                tai_KH();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {

            try
            {
              
                string lenh = "DELETE  KHACHHANG  WHERE MAKH='"+txt_maKH.Text+"'";
                c.thuchienlenh(lenh);

                MessageBox.Show("Thành công");
                tai_KH();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            try
            {

                string lenh = "UPDATE  KHACHHANG SET TEN=N'"+txt_tenKh.Text+"',SDT='"+txt_sdt.Text+"',DIACHI=N'"+txt_diaChi.Text+"' where MAKH='" + txt_maKH.Text + "'";
                c.thuchienlenh(lenh);

                MessageBox.Show("Thành công");
                tai_KH();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void txt_tenKh_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txt_tenKh_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_tenKh.Text))
            {
                e.Cancel = true;
                txt_tenKh.Focus();
                errorProvider1.SetError(txt_tenKh, "Hãy nhập tên đăng nhập trước!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txt_tenKh, null);
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            string lenh = "select MAKH as N'Mã KH',TEN as N'Họ tên',SDT ,DIACHI as N'Địa chỉ',TONGTIEN as N'Tổng tiền' from KHACHHANG where TEN like N'%"+tb_TimKiem.Text+"%' ";
            dataGridView_KH.DataSource = c.lenh(lenh, "KHACHHANG");
            bingding();
        }
    }
}
