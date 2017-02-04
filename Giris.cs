using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using Microsoft.VisualBasic;

namespace ajanda
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
          
        }
        string id;
        public string kontrol;
        public string kullanici;
        public string permission 
        {
            get { return kontrol; }
            set {kontrol = value;}
        }
      
        void giris() 
        {

            try
            {
                using (OleDbConnection baglanti = new OleDbConnection(vt.connection))
                {

                    OleDbCommand cm = new OleDbCommand("select * from kullanici where kullanici_ad = @ad and kullanici_sifre = @sifre", baglanti);
                    cm.Parameters.AddWithValue("@ad", txt_kullanici.Text);
                    cm.Parameters.AddWithValue("@sifre", txt_sifre.Text);
                    DataTable dt = new DataTable();
                    OleDbDataAdapter da = new OleDbDataAdapter(cm);
                    da.Fill(dt);
                    if (dt.Rows[0]["durum"].ToString() == "1")
                    {
                      
                        if (dt.Rows[0]["yetki"].ToString() == "0")
                            {
                                permission = "0";

                            }
                            else if (dt.Rows[0]["yetki"].ToString() == "1")
                            {


                                permission = "1";

                            }
                            else
                            {
                                permission = "2";
                            }
                            kullanici = dt.Rows[0]["kullanici_ad"].ToString();
                            id = dt.Rows[0]["kullanici_id"].ToString();


                            AraEkran ara = new AraEkran(permission, kullanici, id);
                            ara.Show();


                            this.Hide();


                        
                    }
                    else
                    {
                        MessageBox.Show("Hesabınız yasaklılar listesindedir.Giriş yetkiniz yok.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }



                }
            }
            catch (Exception)
            {

                MessageBox.Show("Kullanıcı adı yada şifre hatalı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            giris();
        }

        private void Giris_FormClosing(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (chck_sifre.Checked == true)
            {
                txt_sifre.UseSystemPasswordChar = false;
            }
            else
            {
                txt_sifre.UseSystemPasswordChar = true;
            }
        }


        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, EventArgs.Empty);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

             if (e.KeyData == Keys.Enter)
            {
                button1_Click(sender,EventArgs.Empty);
            }
        }

    

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            kullanici_islem k_islem = new kullanici_islem();
            k_islem.Show();
        }
       
        private void Giris_Load(object sender, EventArgs e)
        {
            git : 
            OleDbConnection cn = new OleDbConnection(vt.connection);
        
            try
            {
                cn.Open();
                vtDurum.Image = new Bitmap(Properties.Resources.database_green);
                vtDurum.Text = "Hazır";
                txt_kullanici.Enabled = true;
                txt_sifre.Enabled = true;
                btn_giris.Enabled = true;
                link_kullanici.Enabled = true;
                chck_sifre.Enabled = true;
            }
            catch (OleDbException ex)
            {
                vtDurum.Image = new Bitmap(Properties.Resources.database_red);
                vtDurum.Text = "Hata";
                txt_kullanici.Enabled = false;
                txt_sifre.Enabled = false;
                btn_giris.Enabled = false;
                link_kullanici.Enabled = false;
                chck_sifre.Enabled = false;
                if (ex.ErrorCode == -2147217843)
                {
                    
                  vt.sifre =  Interaction.InputBox("Parola", "Veri tabanına erişim için parolayı girin");
                  vt.connection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\ajanda.accdb ; Jet OLEDB:Database Password=" + vt.sifre + ";";
                  OleDbConnection cn1 = new OleDbConnection(vt.connection);
                  try
                  {
                      cn1.Open();
                      if (cn1.State == ConnectionState.Open)
                      {
                          goto git;
                      }
                    
                  }
                  catch (Exception)
                  {

                     MessageBox.Show("Parola hatalı","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                      
                  }
                   
                  
                }

            }
            
           
        }

        private void Giris_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

    }
}
