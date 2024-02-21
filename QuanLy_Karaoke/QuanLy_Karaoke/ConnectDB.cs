using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLy_Karaoke
{
    class ConnectDB
    {
        string KetnoiSQL;
        SqlConnection cnn;
        SqlDataAdapter da;
        DataSet ds;
        public ConnectDB()
        {

            //KetnoiSQL = "server="+ kndb.server +";database="+ kndb.db +";UID ="+ kndb.uid +";PWD="+ kndb.pwd +";";
            KetnoiSQL = @"Data Source=DESKTOP-FINT84M\SQLEXPRESS;Initial Catalog=NMCNPM;Integrated Security=True";
            cnn = new SqlConnection(KetnoiSQL);
        }
        public DataTable thuchien(string SQLstr)
        {
            da = new SqlDataAdapter(SQLstr, KetnoiSQL);
            ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];

        }
        public void thuchienlenh(string strsql)
        {
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }


                SqlCommand cmn = new SqlCommand(strsql, cnn);
                cmn.ExecuteNonQuery();

                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
                //MessageBox.Show("Thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ");
            }
        }
        public object trave(string lenh)
        {
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            SqlCommand sp = new SqlCommand(lenh, cnn);
            object c = sp.ExecuteScalar();
            return c;
        }
        public DataTable lenh(string SQLstr, string ten)
        {
            da = new SqlDataAdapter(SQLstr, cnn);
            ds = new DataSet();
            da.Fill(ds, ten);
            return ds.Tables[ten];

        }
        public object Giatri(string lenh)
        {
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            SqlCommand sp = new SqlCommand(lenh, cnn);
            object c = sp.ExecuteScalar();
            return c;
        }

    }
}
