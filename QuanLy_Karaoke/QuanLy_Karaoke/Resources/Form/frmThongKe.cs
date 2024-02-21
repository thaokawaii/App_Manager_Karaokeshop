using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLy_Karaoke
{
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {

            CrystalReport_TK rtp = new CrystalReport_TK();
            ParameterValues dy = new ParameterValues();
   
            ParameterDiscreteValue inm = new ParameterDiscreteValue();
         
            inm.Value = dateTimePicker_Tu.Value.ToString("MM/dd/yyyy");
         
            dy.Add(inm);
            
            rtp.DataDefinition.ParameterFields[0].ApplyCurrentValues(dy);
      
            crystalReportViewer1.ReportSource = rtp;
            crystalReportViewer1.Refresh();
        }

        private void btn_tK_Click(object sender, EventArgs e)
        {
            CrystalReport_TK rtp = new CrystalReport_TK();
            ParameterValues dy = new ParameterValues();
            ParameterValues d = new ParameterValues();
            ParameterDiscreteValue inm = new ParameterDiscreteValue();
            ParameterDiscreteValue i = new ParameterDiscreteValue();
            inm.Value = dateTimePicker_Tu.Value.ToString("MM/dd/yyyy");
            i.Value = dateTimePicker_den.Value.ToString("MM/dd/yyyy");
            dy.Add(inm);
            d.Add(i);
            rtp.DataDefinition.ParameterFields[0].ApplyCurrentValues(dy);
            rtp.DataDefinition.ParameterFields[1].ApplyCurrentValues(d);
            crystalReportViewer1.ReportSource = rtp;
            crystalReportViewer1.Refresh();
        }
    }
}
