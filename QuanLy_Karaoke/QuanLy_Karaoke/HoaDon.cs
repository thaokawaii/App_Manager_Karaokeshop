using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace QuanLy_Karaoke
{
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();
        }
        string p;
    
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        private string _message;
        

        private void crystalReportViewer1_Load_1(object sender, EventArgs e)
        {
            p = _message;
            CrystalReport1  rtp = new CrystalReport1();
            ParameterValues dy = new ParameterValues();
            ParameterDiscreteValue inm = new ParameterDiscreteValue();
            inm.Value = p;
            dy.Add(inm);
            rtp.DataDefinition.ParameterFields[0].ApplyCurrentValues(dy);
            crystalReportViewer1.ReportSource = rtp;
            crystalReportViewer1.Refresh();

        }


        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
