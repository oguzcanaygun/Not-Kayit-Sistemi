using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Not_Kayıt_Sistemi
{
    public partial class FrmOgrenciDetay : Form
    {
        public FrmOgrenciDetay()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-MMJ5V6P;Initial Catalog=DbNotKayıt;Integrated Security=True");

        public string no;

        private void FrmOgrenciDetay_Load(object sender, EventArgs e)
        {
            LblNo.Text = no;

            conn.Open();
            SqlCommand command = new SqlCommand("select * from TBLDERS where OGRNUMARA=@p1",conn);
            command.Parameters.AddWithValue("@p1",no);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                LblName.Text = dr[2].ToString() +" "+ dr[3].ToString();
                LblExm1.Text = dr[4].ToString();
                LblExm2.Text = dr[5].ToString();
                LblExm3.Text = dr[6].ToString();
                LblAvg.Text = dr[7].ToString();
                label8.Text = dr[8].ToString();
            }
            conn.Close();
            if (label8.Text == "True")
            {
                LblSitutation.Text = "Succes";
            }
            if (label8.Text == "False")
            {
                LblSitutation.Text = "Failed";
            }
        }
    }
}
