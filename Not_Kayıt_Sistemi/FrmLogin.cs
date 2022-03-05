using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Not_Kayıt_Sistemi
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmOgrenciDetay fr = new FrmOgrenciDetay();
            fr.no = maskedTextBox1.Text;
            fr.Show();
            
        }

        
private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == "9999")
            {
                FrmOgretmenDetay frm = new FrmOgretmenDetay();
                frm.Show();
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
    }
