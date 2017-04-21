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
    public partial class Silme : Form
    {
        public Silme(string kullanici,string retrieve,string id)
        {
            InitializeComponent();
            ad = kullanici;
            kontrol = retrieve;
            k_id = id;

        }
        
        string ad,kontrol,k_id;
        OleDbConnection baglanti = new OleDbConnection(vt.connection);
        /// <summary>
        /// Ajandadaki kişileri listeler
        /// </summary>
        void listele()
        {

            OleDbCommand cm = new OleDbCommand("SELECT kisiler_id,Ad,Soyad,Telefon,Telefon_2,Adres,Mail,Tarih FROM kisiler where kullanici_id = @id", baglanti);
            cm.Parameters.AddWithValue("@id", Convert.ToInt32(k_id));
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cm);
            da.Fill(dt);
            comboBox1.ValueMember = "kisiler_id";
            comboBox1.DisplayMember = "Ad";
            comboBox1.DataSource = dt;
            if (dt.Rows.Count != 0)
            {
                comboBox1.Text = dt.Rows[0]["Ad"].ToString();
                txtSoyad.Text = dt.Rows[0]["Soyad"].ToString();
                txtAdres.Text = dt.Rows[0]["Adres"].ToString();
                txtTel.Text = dt.Rows[0]["Telefon"].ToString();
                txtTel2.Text = dt.Rows[0]["Telefon_2"].ToString();
                txtMail.Text = dt.Rows[0]["Mail"].ToString();
                txtTarih.Text = dt.Rows[0]["Tarih"].ToString();
       
            }
            else
            {
                MessageBox.Show("Veri tabanında kayıt olmadığından bu kısma erişemezsiniz.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }
        }
        
        private void Silme_Load(object sender, EventArgs e)
        {

            listele();
           
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            OleDbCommand cm = new OleDbCommand("SELECT kisiler_id,Ad,Soyad,Telefon,Telefon_2,Adres,Mail,Tarih FROM kisiler where Ad = @ad ", baglanti); 
            cm.Parameters.AddWithValue("@ad", comboBox1.Text);
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cm);
            da.Fill(dt);
          

            txtSoyad.Text = dt.Rows[0]["Soyad"].ToString();
            txtAdres.Text = dt.Rows[0]["Adres"].ToString();
            txtTel.Text = dt.Rows[0]["Telefon"].ToString();
            txtTel2.Text = dt.Rows[0]["Telefon_2"].ToString();
            txtMail.Text = dt.Rows[0]["Mail"].ToString();
            txtTarih.Text = dt.Rows[0]["Tarih"].ToString();
        
        }

     

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.DropDownStyle = ComboBoxStyle.DropDown;
            }
        }
        /// <summary>
        /// Güncelleme işlemini ypar
        /// </summary>
        void guncelle() 
        {
            if (MessageBox.Show("Kaydetmek istiyormusunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {


                OleDbCommand cm = new OleDbCommand("update kisiler set Ad = @ad , Soyad=@soyad,Telefon = @tel,Telefon_2 = @tel2,Adres = @adres,Mail = @mail,Tarih = @tarih where kisiler_id = @id", baglanti);
                cm.Parameters.AddWithValue("@ad", comboBox1.Text);
                cm.Parameters.AddWithValue("@soyad", txtSoyad.Text);
                cm.Parameters.AddWithValue("@tel", txtTel.Text);
                cm.Parameters.AddWithValue("@tel2", txtTel2.Text);
                cm.Parameters.AddWithValue("@adres", txtAdres.Text);
                cm.Parameters.AddWithValue("@mail", txtMail.Text);
                cm.Parameters.AddWithValue("@tarih", txtTarih.Text);
                cm.Parameters.AddWithValue("@id", comboBox1.SelectedValue);

                baglanti.Open();
                cm.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            guncelle();
          
        }

      
        private void btn_Sil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bu kişiyi rehberden silmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                OleDbCommand cm = new OleDbCommand("delete from kisiler where kisiler_id= @id", baglanti);
                cm.Parameters.AddWithValue("@id", comboBox1.SelectedValue);
                baglanti.Open();
                cm.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Silme işlemi başarılı");
            }
        }
   
    }
}
