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
    public partial class frmDatPhong : Form
    {
        public frmDatPhong()
        {
            InitializeComponent();
        }
        ConnectDB c = new ConnectDB();
        private void bunifuButton1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_Them_Click(object sender, EventArgs e)
        {

        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {

        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {

        }

        private void bunifuShadowPanel1_ControlAdded(object sender, ControlEventArgs e)
        {

        }
        public void bingdingPhong()
        {
            txt_maPh.DataBindings.Clear();
            txt_tenPH.DataBindings.Clear();
            comboBox_maLoai.DataBindings.Clear();
            comboBox_TinhTrang.DataBindings.Clear();
            txt_maPh.DataBindings.Add("Text", dataGridView_phong.DataSource, "Mã phòng");
            txt_tenPH.DataBindings.Add("Text",dataGridView_phong.DataSource,"Tên phòng");
            comboBox_maLoai.DataBindings.Add("Text", dataGridView_phong.DataSource, "Tên loại");
            comboBox_TinhTrang.DataBindings.Add("Text", dataGridView_phong.DataSource, "Tình trạng");
        }
        public void bingdingLoaiPh()
        {
            txt_maLoai.DataBindings.Clear();
            txt_tenLoai.DataBindings.Clear();
            txt_giaThue.DataBindings.Clear();
            txt_maLoai.DataBindings.Add("Text",dataGridView_loaiPH.DataSource,"Mã loại");
            txt_tenLoai.DataBindings.Add("Text",dataGridView_loaiPH.DataSource,"Tên loại");
            txt_giaThue.DataBindings.Add("Text", dataGridView_loaiPH.DataSource,"Giá thuê");
        }
      public  void taiLoaiPh()
        {
          
            string lenh = "SELECT MALOAI as N'Mã loại',TENLOAIPH as N'Tên loại',GIATHUE as N'Giá thuê' from LOAIPHONG";
            dataGridView_loaiPH.DataSource = c.lenh(lenh, "LOAIPHONG");
            bingdingLoaiPh();
        }
        public void taiPhong()
        {
            this.dataGridView_phong.DefaultCellStyle.Font = new Font("Times New Roman", 10);
            string lenh = "select MAPHONG as N'Mã phòng',TENPH as N'Tên phòng',TINHTRANG as N'Tình trạng',LOAIPHONG.TENLOAIPH N'Tên loại' from PHONG,LOAIPHONG where PHONG.MALOAI=LOAIPHONG.MALOAI";
            dataGridView_phong.DataSource = c.lenh(lenh, "PHONG");
            bingdingPhong();
            
        }
        public void taiComboboxLoai()
        {
            string lenh = "SELECT * FROM LOAIPHONG";
            comboBox_maLoai.DataSource = c.lenh(lenh,"LOAIPHONG");
            comboBox_maLoai.DisplayMember = "TENLOAIPH";
            comboBox_maLoai.ValueMember = "MALOAI";

        }
        private void frmDatPhong_Load(object sender, EventArgs e)
        {
            taiPhong();
            taiLoaiPh();
            taiComboboxLoai();
        }

        private void button_them_Click(object sender, EventArgs e)
        {
            try
            {
                string lenh0 = "SELECT CONCAT('LP', RIGHT(CONCAT('00',ISNULL(SUBSTRING(max(MALOAI),3,2),0) + 1),2)) from LOAIPHONG where MALOAI like 'LP%'";
                object k = c.trave(lenh0);
                string ma = k.ToString();
                txt_maLoai.Text = ma;
                string lenh = "INSERT INTO LOAIPHONG VALUES ('" + ma + "',N'" + txt_tenLoai.Text + "'," + txt_giaThue.Text + ")";
                c.thuchienlenh(lenh);
                MessageBox.Show("Thành công");
                taiLoaiPh();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi ");
            }
        }

        private void button_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                string lenh = "DELETE LOAIPHONG WHERE MALOAI='" + txt_maLoai.Text + "'";
                c.thuchienlenh(lenh);
                MessageBox.Show("Thành công");
                taiLoaiPh(); ;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi khóa");
            }
        }

        private void button_sua_Click(object sender, EventArgs e)
        {
            try
            {
                string lenh = "UPDATE LOAIPHONG SET TENLOAIPH=N'"+txt_tenLoai.Text+"',GIATHUE="+txt_giaThue.Text+" WHERE MALOAI='" + txt_maLoai.Text + "'";
                c.thuchienlenh(lenh);
                MessageBox.Show("Thành công");
                taiLoaiPh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btn_th_Click(object sender, EventArgs e)
        {
            try
            {
                string lenh0 = "SELECT CONCAT('PH', RIGHT(CONCAT('00',ISNULL(SUBSTRING(max(MAPHONG),3,2),0) + 1),2)) from PHONG where MAPHONG like 'PH%'";
                object k = c.trave(lenh0);
                string ma = k.ToString();
                txt_maPh.Text = ma;
                string lenh = "INSERT INTO PHONG VALUES('"+ma+"','"+comboBox_maLoai.SelectedValue.ToString()+"',N'Trống',N'"+txt_tenPH.Text+"')";
                c.thuchienlenh(lenh);
                MessageBox.Show("Thành công");
                taiPhong();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btn_x_Click(object sender, EventArgs e)
        {
            try
            {
              
                string lenh = "DELETE PHONG WHERE MAPHONG='"+txt_maPh.Text+"'";
                c.thuchienlenh(lenh);
                MessageBox.Show("Thành công");
                taiPhong();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btn_s_Click(object sender, EventArgs e)
        {
            try
            {

                string lenh = "UPDATE PHONG set MALOAI='"+comboBox_maLoai.SelectedValue.ToString()+"',TENPH=N'"+txt_tenPH.Text+"' WHERE MAPHONG='" + txt_maPh.Text + "'";
                c.thuchienlenh(lenh);
                MessageBox.Show("Thành công");
                taiPhong();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi");
            }
        }
    }
}
