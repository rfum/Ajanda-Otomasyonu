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
    public partial class hatirlatma : Form
    {
        public hatirlatma(string id)
        {
            InitializeComponent();
            k_id = id;
        }
        string k_id;
        string tarih = DateTime.Today.Day + "." + DateTime.Today.Month + "." + DateTime.Today.Year;
        string saat = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
        DataTable dt;
        bool durum;
        OleDbConnection cn = new OleDbConnection(vt.connection);
        /// <summary>
        /// Açık veritabanı bağlantılarını kapatır
        /// </summary>
        void baglanti_kontrol()
        {

            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }

        }

        /// <summary>
        /// hatırlatma kaydını yapar.
        /// </summary>
        void hatirlatma_kayit()
        {
            OleDbCommand cmliste = new OleDbCommand("Select * from hatirlatma where kullanici_id = @id", cn);
            cmliste.Parameters.AddWithValue("@id", Convert.ToInt32(k_id));
            OleDbDataAdapter da = new OleDbDataAdapter(cmliste);

            dt = new DataTable();
            da.Fill(dt);
            if (rtxt_hatirlatma.Text != "")
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["konu"].ToString() == rtxt_hatirlatma.Text)
                    {
                        durum = true;
                        break;
                    }
                    else
                    {
                        durum = false;
                    }

                }

                if (durum == true)
                {

                }
                else
                {
                    try
                    {
                        OleDbCommand cm = new OleDbCommand("Insert into hatirlatma (kullanici_id,konu,giris_tarih,cikis_tarih,giris_saat,cikis_saat) values (@id,@konu,@giris_t,@cikis_t,@giris_s,@cikis_s)", cn);
                        cm.Parameters.AddWithValue("@id", Convert.ToInt32(k_id));
                        cm.Parameters.AddWithValue("@konu", rtxt_hatirlatma.Text);
                        cm.Parameters.AddWithValue("@giris_t", tarih);
                        cm.Parameters.AddWithValue("@cikis_t", dt_tarih.Text);
                        cm.Parameters.AddWithValue("@giris_s", saat);
                        cm.Parameters.AddWithValue("@cikis_s", dt_saat.Text);
                        cn.Open();
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Atama işlemi başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        rtxt_hatirlatma.Text = "";
                        dt_saat.Text = "";
                        vt.hatirlatma_kontrol = true;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }

            }
            else
            {
                MessageBox.Show("Hatırlatma Boş geçilemez.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void hatirlatma_Load(object sender, EventArgs e)
        {
            //Tarih
            lbl_tarih.Text = tarih;

        }

        private void tmr_saat_Tick(object sender, EventArgs e)
        {
            //Saat
            lbl_saat.Text = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
        }

        private void btn_ata_Click(object sender, EventArgs e)
        {
            baglanti_kontrol();
            hatirlatma_kayit();
        }



    }
}
