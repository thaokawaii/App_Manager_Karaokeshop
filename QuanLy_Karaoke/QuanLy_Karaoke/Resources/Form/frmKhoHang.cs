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
    public partial class frmKhoHang : Form
    {
        ConnectDB c = new ConnectDB();
        BLL_KhoHang bll = new BLL_KhoHang();
        public frmKhoHang()
        {
            InitializeComponent();
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void taiMH()
        {
            string lenh = "select MAMH as N'Mã hàng',LOAIHANG.TENLOAI as N'Tên loại',TENMH as N'Tên MH',DVT,GIABAN as N'Giá',SLTON as N'Số lượng tồn' from MATHANG,LOAIHANG where MATHANG.MALOAI=LOAIHANG.MALOAI";
            dataGridView_MH.DataSource = c.lenh(lenh, "MATHANG");
            bingding();


        }
        private void frmKhoHang_Load(object sender, EventArgs e)
        {

            taiMH();
            taiCombobox_DVT();
            taiCombobox_loai();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
        public void taiCombobox_DVT()
        {
            string[] p = { "Chai", "lon","Đĩa","Bịch","Con" };
            foreach (string h in p)
            {
               comboBox_dvt.Items.Add(h);
            }
           comboBox_dvt.SelectedItem = 0;
        }
        public void taiCombobox_loai()
        {
            string lenh = "select * from LOAIHANG";
          comboBox_maLoai.DataSource = c.lenh(lenh, "LOAIHANG");
            comboBox_maLoai.DisplayMember = "TENLOAI";
            comboBox_maLoai.ValueMember = "MALOAI";
        }    
        public void bingding()
        {
            txt_maHang.DataBindings.Clear();
            txt_ten.DataBindings.Clear();
            txt_gia.DataBindings.Clear();
            txt_slTon.DataBindings.Clear();
            comboBox_dvt.DataBindings.Clear();
            comboBox_maLoai.DataBindings.Clear();
            txt_maHang.DataBindings.Add("Text",dataGridView_MH.DataSource, "Mã hàng");
            txt_ten.DataBindings.Add("Text",dataGridView_MH.DataSource, "Tên MH");
            txt_gia.DataBindings.Add("Text",dataGridView_MH.DataSource, "Giá");
            txt_slTon.DataBindings.Add("Text", dataGridView_MH.DataSource, "Số lượng tồn");
            comboBox_dvt.DataBindings.Add("Text", dataGridView_MH.DataSource, "DVT");
            //comboBox_maLoai.DataBindings.Add("Text", dataGridView_MH.DataSource, "Tên loại");
        }
       

        private void btn_t_Click(object sender, EventArgs e)
        {
            string ma = "SELECT CONCAT('MH', RIGHT(CONCAT('00',ISNULL(SUBSTRING(max(MAMH),3,2),0) + 1),2)) from MATHANG where MAMH like 'MH%'";
            object M = c.trave(ma);
            string p = M.ToString();
            txt_maHang.Text = p;
            try
            {
                if (bll.ThemSP(txt_ten.Text,txt_slTon.Text,txt_gia.Text,txt_maHang.Text,comboBox_maLoai.SelectedValue.ToString(),comboBox_dvt.Text))
                {
                   
                    string lenh = "INSERT INTO MATHANG values('" + p + "','" + comboBox_maLoai.SelectedValue.ToString() + "',N'" + txt_ten.Text + "',N'" + comboBox_dvt.Text + "'," + txt_slTon.Text + "," + txt_gia.Text + ")";
                    c.thuchienlenh(lenh);
                    taiMH();
                    MessageBox.Show("Thành công");
                }
                else
                {
                    MessageBox.Show("Không đúng quy định");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void button_x_Click(object sender, EventArgs e)
        {
            try
            {
                if (bll.KiemTraKhoa(txt_maHang.Text) == true)
                {


                    string lenh = "DELETE  MATHANG  where MAMH='" + txt_maHang.Text + "'";
                    c.thuchienlenh(lenh);
                    taiMH();
                    MessageBox.Show("Thành công");
                }
                else
                {
                    MessageBox.Show("Không có sản phẩm cần xóa");
                }    
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi khóa ngoại");
            }
        }

        private void btn_s_Click(object sender, EventArgs e)
        {
            try
            {
                string lenh = "UPDATE  MATHANG set TENMH=N'"+txt_ten.Text+"',MALOAI='"+comboBox_maLoai.SelectedValue.ToString()+"',DVT=N'"+comboBox_dvt.Text+"',SLTON="+txt_slTon.Text+",GIABAN="+txt_gia.Text+" where MAMH='" + txt_maHang.Text + "'";
                c.thuchienlenh(lenh);
                taiMH();
                MessageBox.Show("Thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khóa ngoại");
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            if (bll.Check_txtFind(tb_TimKiem.Text))
            {
                string lenh = "select MAMH as N'Mã hàng',MALOAI as N'Mã loại',TENMH as N'Tên MH',DVT,GIABAN as N'Giá',SLTON as N'Số lượng tồn' from MATHANG WHERE TENMH like N'%" + tb_TimKiem.Text + "%'";
                dataGridView_MH.DataSource = c.lenh(lenh, "MATHANG");
                bingding();
            }
           
        }

        private void tb_TimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
         
            //if(bll.Check_txtFind(e.KeyChar))
            //{
            //    e.Handled = false;
            //}
            //else
            //{
            //    e.Handled = true;
            //}
        }
    }
}
