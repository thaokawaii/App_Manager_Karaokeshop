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
    public partial class frmTongQuan : Form
    {
        public frmTongQuan()
        {
            InitializeComponent();
        }
        ConnectDB c = new ConnectDB();
        public void taiNV()
        {
            string lenh = "select MANV as N'Mã',TENNV as N'Tên',DIACHI as N'Địa chỉ',SDT,CMT,GIOITINH as 'Giới tính',NGAYSINH as N'Ngày sinh',NGAYVL as N'Ngày vào làm',TENDN as N'Tên DN',MATKHAU as N'Mật khẩu' FROM NHANVIEN";
          dataGridView_NV.DataSource=c.lenh(lenh,"NHANVIEN");
            bingdingNV();
        }
        public void bingdingNV()
        {
            txt_maNV.DataBindings.Clear();
            txt_TenNV.DataBindings.Clear();
            txt_CMT.DataBindings.Clear();
            txt_DC.DataBindings.Clear();
            txt_SDT.DataBindings.Clear();
            txt_TenDN.DataBindings.Clear();
            txt_matKhau.DataBindings.Clear();
            comboBox_GT.DataBindings.Clear();
            dateTimePicker_NgaySinh.DataBindings.Clear();
            dateTimePicker_NgayVL.DataBindings.Clear();
            txt_maNV.DataBindings.Add("Text", dataGridView_NV.DataSource, "Mã");
            txt_TenNV.DataBindings.Add("Text", dataGridView_NV.DataSource, "Tên");
            txt_CMT.DataBindings.Add("Text", dataGridView_NV.DataSource, "CMT");
            txt_SDT.DataBindings.Add("Text",dataGridView_NV.DataSource,"SDT");
            txt_DC.DataBindings.Add("Text", dataGridView_NV.DataSource, "Địa chỉ");
            txt_TenDN.DataBindings.Add("Text", dataGridView_NV.DataSource, "Tên DN");
            txt_matKhau.DataBindings.Add("Text", dataGridView_NV.DataSource, "Mật khẩu");
            comboBox_GT.DataBindings.Add("Text", dataGridView_NV.DataSource, "Giới tính");
            dateTimePicker_NgaySinh.DataBindings.Add("Text", dataGridView_NV.DataSource, "Ngày sinh");
            dateTimePicker_NgayVL.DataBindings.Add("Text", dataGridView_NV.DataSource, "Ngày vào làm");
        }
        private void frmTongQuan_Load(object sender, EventArgs e)
        {
            taiNV();
        }
    }
}
