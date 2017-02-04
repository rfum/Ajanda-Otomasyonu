using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ajanda
{
    public partial class Form1 : Form
    {
        public Form1(string kullanici,string id)
        {
            InitializeComponent();
            ad = kullanici;
            k_id = id;
        }
        string k_id;
        public string ad;
        OleDbConnection cn = new OleDbConnection(vt.connection);
        /// <summary>
        /// Açık kalan veri tabanı bağlantılarını kapatır.
        /// </summary>
       public  void baglanti_kontrol()
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
   
            dateTimePicker1.Checked = false;

            
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                baglanti_kontrol();
                OleDbCommand cm = new OleDbCommand("insert into  kisiler (Ad,Soyad,Telefon,Telefon_2,Adres,Mail,kullanici_id,Tarih) values (@ad,@soyad,@tel,@tel2,@adres,@mail,@ku_id,@tarih)", cn);
                
                cm.Parameters.AddWithValue("@ad", textBox1.Text);
                cm.Parameters.AddWithValue("@soyad", textBox2.Text);
                cm.Parameters.AddWithValue("@tel", textBox3.Text);
                cm.Parameters.AddWithValue("@tel2", textBox4.Text);
                cm.Parameters.AddWithValue("@adres", textBox5.Text);
                cm.Parameters.AddWithValue("@mail", textBox6.Text);
            
                cm.Parameters.AddWithValue("@ku_id" ,k_id);
                cm.Parameters.AddWithValue("@tarih", dateTimePicker1.Value);

                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Kayıt başarılı!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
       
         

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
         
            dateTimePicker1.Checked = false;
        }

        private void araEkranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AraEkran ara = new AraEkran("",ad,k_id);
            ara.Show();
            ara.StartPosition = FormStartPosition.CenterScreen;
        }

 
    }
}
