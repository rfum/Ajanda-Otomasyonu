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
    public partial class ic_eposta_degistrime : Form
    {
        public ic_eposta_degistrime(string id)
        {
            InitializeComponent();
            k_id = id;
        }
        string k_id,sifre;
        ArrayList epostalar = new ArrayList();
        OleDbConnection cn = new OleDbConnection(vt.connection);
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
        /// <summary>
        /// Girilien e postanın önceden alınıp alınmadığını kontrol eder
        /// </summary>
        void mail_kontrol()
        {
            epostalar.Clear();
            OleDbCommand cmkontrol = new OleDbCommand("Select * from kullanici", cn);
            OleDbDataAdapter dakontrol = new OleDbDataAdapter(cmkontrol);
            DataTable dtkontrol = new DataTable();
            dakontrol.Fill(dtkontrol);

            for (int i = 0; i < dtkontrol.Rows.Count; i++)
            {
                epostalar.Add(dtkontrol.Rows[i]["mail"].ToString());
            }
        }
        bool kontrol;
        private void btn_degistir_Click(object sender, EventArgs e)
        {
            kullanici_liste();
            mail_kontrol();
            string epostadeger;
            for (int i = 0; i < epostalar.Count; i++)
            {
                epostadeger = epostalar[i].ToString();
                if (epostadeger == txt_eposta.Text)
                {
                    kontrol = true;
                    break;
                }
                else
                {
                    kontrol = false;
                }
            }

            if (txt_sifre.Text == sifre)
            {
                if (kontrol == true)
                {
                    MessageBox.Show("Daha önceden var olan bir E-Posta adresi şeçtiniz.");
                }
                else
                {
                    try
                    {
                        baglanti_kontrol();
                        OleDbCommand cm = new OleDbCommand("Update kullanici set mail=@mail where kullanici_id = @id", cn);
                        cm.Parameters.AddWithValue("@mail", txt_eposta.Text);
                        cm.Parameters.AddWithValue("@id", Convert.ToInt32(k_id));
                        cn.Open();
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("E-posta adresiniz başarıyla değiştirilmiştir.");
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

        private void ic_eposta_degistrime_Load(object sender, EventArgs e)
        {

        }

    }
}
