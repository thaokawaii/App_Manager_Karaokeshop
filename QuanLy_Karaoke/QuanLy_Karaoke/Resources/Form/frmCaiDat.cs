using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLy_Karaoke
{
    public partial class frmCaiDat : Form
    {
        ConnectDB c = new ConnectDB();
        public frmCaiDat()
        {
            InitializeComponent();
        }
        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        public void taiPhong()
        {
            //this.dataGridView_phong.DefaultCellStyle.ForeColor = Color.Blue;
            //this.dataGridView_phong.DefaultCellStyle.BackColor = Color.Beige;
            this.dataGridView_phong.DefaultCellStyle.Font = new Font("Times New Roman", 10);
            string lenh = "select MAPHONG as N'Mã phòng',TENPH as N'Tên phòng',TINHTRANG as N'Tình Trạng',LOAIPHONG.TENLOAIPH N'Tên loại' from PHONG,LOAIPHONG where PHONG.MALOAI=LOAIPHONG.MALOAI";
            dataGridView_phong.DataSource = c.lenh(lenh, "PHONG");
            bingdingPH();
        }
        public void bingdingPH()
        {
            txt_maPh.DataBindings.Clear();
            txt_tenPh.DataBindings.Clear();
            txt_loaiPh.DataBindings.Clear();
            txt_tinhTrang.DataBindings.Clear();
            txt_maPh.DataBindings.Add("Text", dataGridView_phong.DataSource, "Mã phòng");
            txt_tenPh.DataBindings.Add("Text",dataGridView_phong.DataSource,"Tên phòng");
            txt_loaiPh.DataBindings.Add("Text", dataGridView_phong.DataSource, "Tên loại");
            txt_tinhTrang.DataBindings.Add("Text", dataGridView_phong.DataSource,"Tình trạng");

        }
        public void taiMH()
        {
            string lenh = "select MAMH as N'Mã hàng',MALOAI as N'Mã loại',TENMH as N'Tên MH',DVT,GIABAN as N'Giá' from MATHANG";
            dataGridView_MH.DataSource = c.lenh(lenh, "MATHANG");
            bingdingMH();
        }
        public void bingdingMH()
        {
            txt_maMh.DataBindings.Clear();
            txt_TenMh.DataBindings.Clear();
            txt_dvt.DataBindings.Clear();
            txt_gia.DataBindings.Clear();
            txt_maMh.DataBindings.Add("Text", dataGridView_MH.DataSource, "Mã hàng");
            txt_TenMh.DataBindings.Add("Text", dataGridView_MH.DataSource, "Tên MH");
            txt_dvt.DataBindings.Add("Text", dataGridView_MH.DataSource, "DVT");
            txt_gia.DataBindings.Add("Text", dataGridView_MH.DataSource, "Giá");
;
        }
        public void taiKH()
        {
            string lenh = "select * from KHACHHANG";
            comboBox_KH.DataSource = c.lenh(lenh, "KHACHHANG");
            comboBox_KH.ValueMember = "MAKH";
            comboBox_KH.DisplayMember = "TEN";
        }
        public void NhanVien()
        {
            string lenh = "SELECT MANV FROM NHANVIEN where TENDN='" + _message + "'";
            object name = c.Giatri(lenh);
            if (name != null)
            {
                label2.Text = name.ToString();
            }
            else
            {
                label2.Text = "NV04";
            }    

        }
        public string  maPhieu()
        {
            string lenh = "SELECT CONCAT('PT', RIGHT(CONCAT('00',ISNULL(SUBSTRING(max(MAPHIEU),3,2),0) + 1),2)) from PHIEUTHUE where MAPHIEU like 'PT%'";
           object kq = c.trave(lenh);
            string K = kq.ToString();
            return K;
        }
        public string maHD()
        {
            string lenh = "SELECT CONCAT('HD', RIGHT(CONCAT('00',ISNULL(SUBSTRING(max(MAHD),3,2),0) + 1),2)) from HOADON where MAHD like 'HD%'";
            object kq = c.trave(lenh);
            string K = kq.ToString();
            return K;
        }
        //public void taiCombobox_maHD()
        //{
        //    string lenh = "select * from HOADON where TINHTRANG like 'Chua%'";
        //    comboBox_mahd.DataSource = c.lenh(lenh, "HOADON");
        //    comboBox_mahd.DisplayMember = "MAHD";
          
        //}
        public void themHoaDon()
        {
            string lenh = "Insert into HOADON VALUES('"+comboBox_mahd.Text+"','"+ comboBox_KH.SelectedValue.ToString() + "','"+label2.Text+"',GETDATE(),0,0,0,0,N'Chưa thanh toán')";
            c.thuchienlenh(lenh);

        }
        public void themPhieuThue()
        {
            string h = maPhieu();
            string lenh = "Insert into PHIEUTHUE values('" + h + "','" + txt_maPh.Text + "',GETDATE())";
            c.thuchienlenh(lenh);

        }

        public void themChiTietPT()
        {
            string h = maPhieu();
            string lenh = "Insert into CTPHIEUTHUE values('" + txt_maPhieu.Text + "','" + comboBox_mahd.Text+ "',getdate(),getdate())";

            c.thuchienlenh(lenh);
        }
        public void themCTHD()
        {
            string lenh = "INSERT INTO CHITIETHD VALUES('"+comboBox_mahd.Text+"','"+txt_maMh.Text+"',"+numericUpDown1.Value+",0)";
            c.thuchienlenh(lenh);
        }
        public void ten()
        {
           dataGridView_MH.Columns[0].HeaderText = "Mã HD";
            dataGridView_MH.Columns[1].HeaderText = "Mã MH";
            dataGridView_MH.Columns[2].HeaderText = "Số lượng";
            dataGridView_MH.Columns[3].HeaderText = "Mã MH";
        }
        public void taiCTHD()
        {
            string lenh = "select MAHD as N'MÃ HD',TENMH as N'Tên hàng',SL as N'Số lượng',CHITIETHD.DONGIA as N'Giá bán'  from CHITIETHD,MATHANG WHERE CHITIETHD.MAMH=MATHANG.MAMH and MAHD='" + comboBox_mahd.Text+"'";
           dataGridView_CTHoaDon.DataSource = c.lenh(lenh, "CHITIETHD");
            bingding_CTHD()

;            
        }
        public void bingding_CTHD()
        {
            textBox_TENHH.DataBindings.Clear();
            textBox_SLHH.DataBindings.Clear();
            textBox_TENHH.DataBindings.Add("Text", dataGridView_CTHoaDon.DataSource, "MÃ HD");
            textBox_SLHH.DataBindings.Add("Text", dataGridView_CTHoaDon.DataSource, "Tên hàng");
        }
        void bingdingCTHD()
        {
            txt_maMh.DataBindings.Clear();
            txt_TenMh.DataBindings.Clear();
            numericUpDown1.DataBindings.Clear();
            txt_gia.DataBindings.Clear();
            txt_TenMh.DataBindings.Add("Text", dataGridView_CTHoaDon.DataSource, "Tên hàng");
            numericUpDown1.DataBindings.Add("Text", dataGridView_CTHoaDon.DataSource, "Số lượng");
            txt_gia.DataBindings.Add("Text",dataGridView_CTHoaDon.DataSource,"Giá bán");
        }
        private void frmCaiDat_Load(object sender, EventArgs e)
        {
            taiPhong();
            taiMH();
            taiKH();
            NhanVien();
            txt_maPhieu.Text = maPhieu();
            //comboBox_mahd.Text = maHD();
            //taiCombobox_maHD();
            ten();
            ph();
          


        }

        private void btn_chon_Click(object sender, EventArgs e)
        {
            string lenh = "exec KTPhong '"+txt_maPh.Text+"'";
            object t = c.trave(lenh);
           int kq = Convert.ToInt32(t);
            try
            {
                if (kq == 0)
                {

                    string h = "select HOADON.MAHD from HOADON,PHIEUTHUE,CTPHIEUTHUE,PHONG where HOADON.MAHD = CTPHIEUTHUE.MAHD and CTPHIEUTHUE.MAPHIEU = PHIEUTHUE.MAPHIEU and PHIEUTHUE.MAPHONG = PHONG.MAPHONG AND PHONG.MAPHONG = '" + txt_maPh.Text + "'and HOADON.TINHTRANG=N'Chưa thanh toán'";
                    object k = c.trave(h);
                    string p = k.ToString(); 
                    string h1 = "select PHIEUTHUE.MAPHIEU from HOADON,PHIEUTHUE,CTPHIEUTHUE,PHONG where HOADON.MAHD = CTPHIEUTHUE.MAHD and CTPHIEUTHUE.MAPHIEU = PHIEUTHUE.MAPHIEU and PHIEUTHUE.MAPHONG = PHONG.MAPHONG AND PHONG.MAPHONG = '" + txt_maPh.Text + "' and HOADON.TINHTRANG=N'Chưa thanh toán'";
                    object k1 = c.trave(h1);
                    string p1 = k1.ToString();
                    txt_maPhieu.Text = p1;
                    comboBox_mahd.Text = p;
                    Gio();
                    taiCTHD();

                }
                else
                {
                    txt_maPhieu.Text = maPhieu();
                    comboBox_mahd.Text = maHD();
                    themPhieuThue();
                    themHoaDon();
                    themChiTietPT();
                    MessageBox.Show("Thành công");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string lenh = "select count(MAMH) from CHITIETHD where MAHD='"+comboBox_mahd.Text+"' and MAMH='"+txt_maMh.Text+"'";
            object kq = c.trave(lenh);
            int p = Convert.ToInt32(kq);
            if (p == 1)
            {
                string lenh1 = " update CHITIETHD set SL = "+numericUpDown1.Value+" where MAMH = '"+txt_maMh.Text+"' and MAHD = '"+comboBox_mahd.Text+"'";
                c.thuchienlenh(lenh1);
                taiCTHD();
            }
            else
            {
                themCTHD();
                taiCTHD();
            }
        }
        public void cnTTPh()
        {
            
        }
        private void btn_InHD_Click(object sender, EventArgs e)
        {
           HoaDon m = new HoaDon();
            m.Message = comboBox_mahd.Text;
            m.ShowDialog();
            this.Show();
        }
   

        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Xác nhận thanh toán", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {

            try
            {
                string lenh1 = "update CTPHIEUTHUE set GIODI = GETDATE() where MAPHIEU = (SELECT CTPHIEUTHUE.MAPHIEU from PHIEUTHUE,CTPHIEUTHUE where PHIEUTHUE.MAPHIEU = CTPHIEUTHUE.MAPHIEU and CTPHIEUTHUE.MAPHIEU = '"+txt_maPhieu.Text+"')";
                c.thuchienlenh(lenh1);
                    string MM = "exec CapNhatHD'" + txt_maPhieu.Text + "','" + comboBox_mahd.Text + "'";
                    c.thuchienlenh(MM);
                    string lenh2 = "update PHONG set TINHTRANG = N'Trống' where MAPHONG = (select PHONG.MAPHONG from PHONG,PHIEUTHUE,CTPHIEUTHUE,HOADON where PHONG.MAPHONG = PHIEUTHUE.MAPHONG and PHIEUTHUE.MAPHIEU = CTPHIEUTHUE.MAPHIEU and CTPHIEUTHUE.MAHD = HOADON.MAHD and HOADON.MAHD = '" + comboBox_mahd.Text + "')";
                c.thuchienlenh(lenh2);
                    string lenh3 = "update HOADON SET TONGTIEN=(TIENPHONG+TIENDV) where MAHD='"+comboBox_mahd.Text+"'";
                    c.thuchienlenh(lenh3);
                MessageBox.Show("Thành công"); 
                   
                }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi");
            }
                
            }

        }

      
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            comboBox_TT.Items.Clear();
            frmCaiDat_Load(sender, e);
            dataGridView_CTHoaDon.Columns.Clear();
          
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            frmDangNhap d = new frmDangNhap();
            DialogResult dg = MessageBox.Show("Bạn muốn đăng xuất", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                //Application.Exit();
                d.frmDangNhap_Load(sender, e);
                d.Show();
                this.Hide();
                //d.ShowDialog();
              
            }
         
           
           

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ThongTinNV th = new ThongTinNV();
            th.Message = label2.Text;
            th.ShowDialog();
        }
        public void ph()
        {
            string[] p = { "Trống", "Đã thuê" };
            foreach (string h in p)
            {
               comboBox_TT.Items.Add(h);
            }
           comboBox_TT.SelectedItem = 0;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string lenh = "select MAPHONG as N'Mã phòng',TENPH as N'Tên phòng',TINHTRANG as N'Tình Trạng',LOAIPHONG.TENLOAIPH N'Tên loại' from PHONG,LOAIPHONG where PHONG.MALOAI=LOAIPHONG.MALOAI and TINHTRANG=N'"+comboBox_TT.SelectedItem.ToString()+"'";
            dataGridView_phong.DataSource = c.lenh(lenh, "PHONG");
            bingdingPH();
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            string lenh = "select MAMH as N'Mã hàng',MALOAI as N'Mã loại',TENMH as N'Tên MH',DVT,GIABAN as N'Giá' from MATHANG WHERE  TENMH like N'"+comboBox_MH.Text+"%'";
            dataGridView_MH.DataSource = c.lenh(lenh,"MATHANG");
            bingdingMH();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            kh.ShowDialog();
        }
        bool drap = false;
        Point star_point = new Point(0, 0);

        private void frmCaiDat_MouseDown(object sender, MouseEventArgs e)
        {
            drap = true;
            star_point = new Point(e.X, e.Y);
        }

        private void frmCaiDat_MouseMove(object sender, MouseEventArgs e)
        {
            if(drap)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - star_point.X, p.Y - star_point.Y);
            }    
        }

        private void frmCaiDat_MouseUp(object sender, MouseEventArgs e)
        {
            drap = false;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            drap = true;
            star_point = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drap)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - star_point.X, p.Y - star_point.Y);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            drap = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           try
            {
                string lenh = "DELETE CHITIETHD WHERE MAHD='"+textBox_TENHH.Text+"' and MAMH=(select CHITIETHD.MAMH from MATHANG,CHITIETHD where MATHANG.MAMH=CHITIETHD.MAMH and TENMH=N'"+textBox_SLHH.Text+"' group by CHITIETHD.MAMH)";
                c.thuchienlenh(lenh);
                MessageBox.Show("Thành công");
                taiCTHD();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Thất bại");
            }
        }

        public void Gio()
        {
            string lenh = "select GIODI from CTPHIEUTHUE WHERE MAPHIEU='" + txt_maPhieu.Text + "' and MAHD='" + comboBox_mahd.Text + "'";
            object kq = c.trave(lenh);
            DateTime h = Convert.ToDateTime(kq);
            dateTimePicker_di.Value = h;
            string lenh2 = "select GIODEN from CTPHIEUTHUE WHERE MAPHIEU='" + txt_maPhieu.Text + "' and MAHD='" + comboBox_mahd.Text + "'";
            object kq2 = c.trave(lenh2);
            DateTime h2 = Convert.ToDateTime(kq2);
          dateTimePicker_den.Value = h2;
        }
    }
}
