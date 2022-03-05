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
    public partial class FrmOgretmenDetay : Form
    {
        public FrmOgretmenDetay()
        {
            InitializeComponent();
        }

        DbNotKayıtEntities db = new DbNotKayıtEntities();
        
        private void label12_Click(object sender, EventArgs e)
        {

        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-MMJ5V6P;Initial Catalog=DbNotKayıt;Integrated Security=True");
        private void FrmOgretmenDetay_Load(object sender, EventArgs e)
        {
            
            // TODO: This line of code loads data into the 'dbNotKayıtDataSet.TBLDERS' table. You can move, or remove it, as needed.
            this.tBLDERSTableAdapter.Fill(this.dbNotKayıtDataSet.TBLDERS);
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand("insert into TBLDERS (OGRNUMARA,OGRAD,OGRSOYAD) values (@p1,@p2,@p3)",conn);
            command.Parameters.AddWithValue("@p1",MskdTxtBxNumber.Text);
            command.Parameters.AddWithValue("@p2",Txtname.Text);
            command.Parameters.AddWithValue("@p3",TxtLstName.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("Student Succesfully Added", "Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.tBLDERSTableAdapter.Fill(this.dbNotKayıtDataSet.TBLDERS);
            conn.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string situ;
            double avg, ex1, ex2, ex3;
            ex1 = Convert.ToDouble(TxtEx1.Text);
            ex2 = Convert.ToDouble(TxtEx2.Text);
            ex3 = Convert.ToDouble(TxtEx3.Text);
            avg = (ex1 + ex2 + ex3) / 3;
            LblAVG.Text = avg.ToString();

            if (avg >= 50)
            {
                situ = "True";
            }
            else
            {
                situ = "False";
            }
            

            conn.Open();
            SqlCommand command = new SqlCommand("update TBLDERS set OGRS1=@p1,OGRS2=@p2,OGRS3=@p3,ORTALAMA=@p5,DURUM=@p6 where OGRNUMARA=@p4", conn);
            command.Parameters.AddWithValue("@p1", TxtEx1.Text);
            command.Parameters.AddWithValue("@p2", TxtEx2.Text);
            command.Parameters.AddWithValue("@p3", TxtEx3.Text);
            command.Parameters.AddWithValue("@p4", MskdTxtBxNumber.Text);
            command.Parameters.AddWithValue("@p5",decimal.Parse(LblAVG.Text));
            command.Parameters.AddWithValue("@p6",situ);
            command.ExecuteNonQuery();
            conn.Close();
            this.tBLDERSTableAdapter.Fill(this.dbNotKayıtDataSet.TBLDERS);
            MessageBox.Show("Student Succesfully Updated", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Lblpass.Text = db.TBLDERS.Count(x =>x.DURUM == true).ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MskdTxtBxNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            Txtname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtLstName.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtEx1.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtEx2.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            TxtEx3.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            LblAVG.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            
        }

 
    }
}
