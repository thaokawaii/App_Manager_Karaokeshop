
namespace QuanLy_Karaoke
{
    partial class ThongTinNV
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txt_ten = new System.Windows.Forms.TextBox();
            this.txt_tenDn = new System.Windows.Forms.TextBox();
            this.txt_MK = new System.Windows.Forms.TextBox();
            this.txt_Mkmoi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_mkNL = new System.Windows.Forms.TextBox();
            this.button_XN = new System.Windows.Forms.Button();
            this.button_Thoát = new System.Windows.Forms.Button();
            this.ck_Show = new System.Windows.Forms.CheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(895, 100);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(197, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(493, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "THÔNG TIN TÀI KHOẢN";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.09302F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.90697F));
            this.tableLayoutPanel1.Controls.Add(this.txt_ten, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txt_tenDn, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txt_MK, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txt_Mkmoi, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txt_mkNL, 1, 4);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(216, 106);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(430, 269);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // txt_ten
            // 
            this.txt_ten.Location = new System.Drawing.Point(141, 3);
            this.txt_ten.Name = "txt_ten";
            this.txt_ten.Size = new System.Drawing.Size(217, 30);
            this.txt_ten.TabIndex = 0;
            // 
            // txt_tenDn
            // 
            this.txt_tenDn.Location = new System.Drawing.Point(141, 55);
            this.txt_tenDn.Name = "txt_tenDn";
            this.txt_tenDn.Size = new System.Drawing.Size(217, 30);
            this.txt_tenDn.TabIndex = 1;
            // 
            // txt_MK
            // 
            this.txt_MK.Location = new System.Drawing.Point(141, 107);
            this.txt_MK.Name = "txt_MK";
            this.txt_MK.PasswordChar = '*';
            this.txt_MK.Size = new System.Drawing.Size(217, 30);
            this.txt_MK.TabIndex = 2;
            // 
            // txt_Mkmoi
            // 
            this.txt_Mkmoi.Location = new System.Drawing.Point(141, 166);
            this.txt_Mkmoi.Name = "txt_Mkmoi";
            this.txt_Mkmoi.PasswordChar = '*';
            this.txt_Mkmoi.Size = new System.Drawing.Size(217, 30);
            this.txt_Mkmoi.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Họ tên:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tên đăng nhập:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 22);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mật khẩu:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 22);
            this.label5.TabIndex = 7;
            this.label5.Text = "Mật khẩu mới:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 22);
            this.label6.TabIndex = 8;
            this.label6.Text = "Nhập lại:";
            // 
            // txt_mkNL
            // 
            this.txt_mkNL.Location = new System.Drawing.Point(141, 226);
            this.txt_mkNL.Name = "txt_mkNL";
            this.txt_mkNL.PasswordChar = '*';
            this.txt_mkNL.Size = new System.Drawing.Size(217, 30);
            this.txt_mkNL.TabIndex = 4;
            this.txt_mkNL.Validating += new System.ComponentModel.CancelEventHandler(this.txt_mkNL_Validating);
            // 
            // button_XN
            // 
            this.button_XN.BackColor = System.Drawing.Color.DarkTurquoise;
            this.button_XN.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_XN.Location = new System.Drawing.Point(289, 406);
            this.button_XN.Name = "button_XN";
            this.button_XN.Size = new System.Drawing.Size(105, 39);
            this.button_XN.TabIndex = 1;
            this.button_XN.Text = "Xác nhận";
            this.button_XN.UseVisualStyleBackColor = false;
            this.button_XN.Click += new System.EventHandler(this.button_XN_Click);
            // 
            // button_Thoát
            // 
            this.button_Thoát.BackColor = System.Drawing.Color.DarkTurquoise;
            this.button_Thoát.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Thoát.Location = new System.Drawing.Point(492, 406);
            this.button_Thoát.Name = "button_Thoát";
            this.button_Thoát.Size = new System.Drawing.Size(105, 39);
            this.button_Thoát.TabIndex = 2;
            this.button_Thoát.Text = "Thoát";
            this.button_Thoát.UseVisualStyleBackColor = false;
            this.button_Thoát.Click += new System.EventHandler(this.button_Thoát_Click);
            // 
            // ck_Show
            // 
            this.ck_Show.AutoSize = true;
            this.ck_Show.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_Show.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ck_Show.Location = new System.Drawing.Point(667, 352);
            this.ck_Show.Name = "ck_Show";
            this.ck_Show.Size = new System.Drawing.Size(65, 23);
            this.ck_Show.TabIndex = 3;
            this.ck_Show.Text = "Hiện";
            this.ck_Show.UseVisualStyleBackColor = true;
            this.ck_Show.CheckedChanged += new System.EventHandler(this.ck_Show_CheckedChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ThongTinNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 543);
            this.Controls.Add(this.ck_Show);
            this.Controls.Add(this.button_Thoát);
            this.Controls.Add(this.button_XN);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ThongTinNV";
            this.Text = "ThongTinNV";
            this.Load += new System.EventHandler(this.ThongTinNV_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txt_ten;
        private System.Windows.Forms.TextBox txt_tenDn;
        private System.Windows.Forms.TextBox txt_MK;
        private System.Windows.Forms.TextBox txt_Mkmoi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_mkNL;
        private System.Windows.Forms.Button button_XN;
        private System.Windows.Forms.Button button_Thoát;
        private System.Windows.Forms.CheckBox ck_Show;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}