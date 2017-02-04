using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections;

namespace ajanda
{
    public partial class ic_sifre_degistir : Form
    {
        public ic_sifre_degistir(string id)
        {
            InitializeComponent();
            k_id = id;
        }
        string k_id, sifre;
       
        OleDbConnection cn = new OleDbConnection(vt.connection);
        ArrayList nickler = new ArrayList();
        /// <summary>
        /// Açık kalan veri tabanı bağlantılarını kapatır.
        /// </summary>
        public void baglanti_kontrol()
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }
        /// <summary>
        /// Daha önceden giriş yapmış kullanıcının diğer bilgilerine erişir.
        /// </summary>
        void kullanici_liste()
        {
            OleDbCommand cm = new OleDbCommand("Select * from kullanici where id=@id", cn);
            cm.Parameters.AddWithValue("@id", Convert.ToInt32(k_id));
            OleDbDataAdapter da = new OleDbDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            sifre = dt.Rows[0]["kullanici_sifre"].ToString();
            
        }
        void kullanici_kontrol()
        {
            nickler.Clear();
            OleDbCommand cmkontrol = new OleDbCommand("Select * from kullanici", cn);
            OleDbDataAdapter dakontrol = new OleDbDataAdapter(cmkontrol);
            DataTable dtkontrol = new DataTable();
            dakontrol.Fill(dtkontrol);

            for (int i = 0; i < dtkontrol.Rows.Count; i++)
            {
                nickler.Add(dtkontrol.Rows[i]["kullanici_ad"].ToString());
            }
        }

        private void ic_sifre_degistir_Load(object sender, EventArgs e)
        {
            
            
          
           
        }
        bool kontrol;
        private void btn_degistir_Click(object sender, EventArgs e)
        {
            kullanici_liste();
            kullanici_kontrol();
            string nickdeger;
            for (int i = 0; i < nickler.Count; i++)
			{
                nickdeger = nickler[i].ToString();
			 if (nickdeger == txt_yeni.Text)
	            {
	            	 kontrol = true;
                     break;
	            }
             else
             {
                 kontrol = false;
             }
	         }

            if ( txt_mevcut.Text == sifre)
            {
                if (kontrol == true)
                {
                    MessageBox.Show("Daha önceden var olan bir kullanıcı adı şeçtiniz.");
                }
                else
                {
                    try
                    {
                        baglanti_kontrol();                        
                        OleDbCommand cm = new OleDbCommand("Update kullanici set kullanici_ad=@ad where kullanici_id = @id", cn);
                        cm.Parameters.AddWithValue("@ad", txt_yeni.Text);
                        cm.Parameters.AddWithValue("@id", Convert.ToInt32(k_id));
                        cn.Open();
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Kullanıcı adınız başarıyla değiştirilmiştir.");
                        this.Dispose();
                        this.Close();
                        
                        vt.cikis_kontrol = true;
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Hata oluştu :" + ex.Message);
                    }
                }
                
               
            }
            else
            {
                MessageBox.Show("Girilen şifrede hata var lütfen tekrar deneyiniz.");
            }
        }

      
    }
}
