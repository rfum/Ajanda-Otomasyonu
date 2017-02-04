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
using System.Collections;
namespace ajanda
{
    public partial class AraEkran : Form
    {
        public AraEkran(string retrieve, string kullanici, string id)
        {
            InitializeComponent();
            kontrol = retrieve;
            isim = kullanici;
            k_id = id;

        }

        string k_id;
        public string kontrol;
        public string isim;
        string mesaj;

        int satir_kontrol, dongu_kontrol, satir_sayisi;
        OleDbConnection cn = new OleDbConnection(vt.connection);
        /// <summary>
        /// Açık bağlantıları kapar
        /// </summary>
        /// 
        public void baglanti_kontrol()
        {

            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }
        void duyuru_yap()
        {


            baglanti_kontrol();
            //Diğer formdan gelen kullanıcı yetki noya göre yazı tipi belirleniyor
            if (kontrol == "2")
            {
                mesaj = "{\\rtf1\\ansi\\ansicpg1254\\deff0\\deflang1055{\\fonttbl{\\f0\\fnil\\fcharset162 Microsoft Sans Serif;}}{\\colortbl ;\\red255\\green0\\blue0;}\\viewkind4\\uc1\\pard\\cf1\\f0\\fs17 " + isim + ":" + " " + txt_duyuru.Text + "(" + DateTime.Today.Day + "/" + DateTime.Today.Month + "/" + DateTime.Today.Year + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ")" + "\\cf0\\par}";

            }
            if (kontrol == "0")
            {
                mesaj = "{\\rtf1\\ansi\\ansicpg1254\\deff0\\deflang1055{\\fonttbl{\\f0\\fnil\\fcharset162 Microsoft Sans Serif;}}{\\colortbl ;\\red0\\green0\\blue0;}\\viewkind4\\uc1\\pard\\cf1\\f0\\fs17 " + isim + ":" + " " + txt_duyuru.Text + "(" + DateTime.Today.Day + "/" + DateTime.Today.Month + "/" + DateTime.Today.Year + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ")" + "\\cf0\\par}";
            }
            if (kontrol == "1")
            {
                mesaj = "{\\rtf1\\ansi\\ansicpg1254\\deff0\\deflang1055{\\fonttbl{\\f0\\fnil\\fcharset162 Microsoft Sans Serif;}}{\\colortbl ;\\red0\\green0\\blue255;}\\viewkind4\\uc1\\pard\\cf1\\f0\\fs17 " + isim + ":" + " " + txt_duyuru.Text + "(" + DateTime.Today.Day + "/" + DateTime.Today.Month + "/" + DateTime.Today.Year + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ")" + "\\cf0\\par}";
            }
            OleDbCommand cm = new OleDbCommand("Insert into duyuru (konu,kullanici_id) values(@konu,@kullanici_id)", cn);
            cm.Parameters.AddWithValue("@konu", mesaj);
            cm.Parameters.AddWithValue("@kullanici_id", int.Parse(k_id));
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();

            mesaj = null;

        }

        /// <summary>
        /// Kullanıcı resmini getiren prosedür
        /// </summary>
        /// 
        public void kullanici_resmi_cekme()
        {

            OleDbCommand cm = new OleDbCommand("select * from kullanici where kullanici_id = @id", cn);
            cm.Parameters.AddWithValue("@id", Convert.ToInt16(k_id));
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cm);

            da.Fill(dt);
            lbl_kullanıcı.Text = dt.Rows[0]["kullanici_ad"].ToString();
            string resim = dt.Rows[0]["resim"].ToString();
            if (resim != "")
            {

                byte[] img = (byte[])dt.Rows[0]["resim"];


                MemoryStream ms = new MemoryStream(img);
                //int offset = 78;
                //ms.Seek(0, SeekOrigin.Begin);
                //ms.Write(img, offset, img.Length - offset);
                pictureBox1.Image = Image.FromStream(ms);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            }
        }
        /// <summary>
        /// Kullanıcı resmini degistiren prosedür
        /// </summary>
        /// 
        public void kullanici_resmi_degis()
        {
            baglanti_kontrol();
            try
            {
                o_dialog_foto.ShowDialog();
                OleDbCommand cm = new OleDbCommand("update kullanici set resim=@resim where kullanici_id=@id", cn);

                pictureBox1.Image = Image.FromFile(o_dialog_foto.FileName);
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                byte[] res = ms.ToArray();

                cm.Parameters.AddWithValue("@resim", res);
                cm.Parameters.AddWithValue("@id", Convert.ToInt32(k_id));

                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception)
            {


            }

        }
        /// <summary>
        /// Hatırlatmaları gride yükler
        /// </summary>
        public void hatirlatma_yukleme()
        {

            OleDbCommand cm = new OleDbCommand("Select hatirlatma_id,konu as  [Konu],cikis_tarih as[Hatırlatma Tarihi],cikis_saat as [Hatırlatma Saati],giris_tarih as  [Kayıt Tarihi],giris_saat as [Kayıt Saati] from hatirlatma where kullanici_id = @id", cn);
            cm.Parameters.AddWithValue("@id", Convert.ToInt32(k_id));
            OleDbDataAdapter da = new OleDbDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 0 )
            {
                grid_hatirlatma.Columns.Add("","");
                grid_hatirlatma.Rows.Add("Gösterilecek veri yok.");
                grid_hatirlatma.Enabled = false;
            }
            else
            {
                grid_hatirlatma.Enabled = true;
                grid_hatirlatma.DataSource = dt;
                grid_hatirlatma.Columns[0].Visible = false;
            }
           

        }
        /// <summary>
        /// Anlık tarih ve saat bilgisini saklar
        /// </summary>
        void tarih_saat()
        {
            lbl_tarih.Text= DateTime.Today.Day + "/" + DateTime.Today.Month + "/" + DateTime.Today.Year;
            lbl_saat.Text = DateTime.Today.Hour + ":" + DateTime.Today.Minute + ":" + DateTime.Today.Second;
            lbl_kullanıcı.Text = isim;
            kullanici_resmi_cekme();
            hatirlatma_yukleme();
        }
        /// <summary>
        /// Giriş ekranı açılırken var olan duyuruların listelenmesini sağlar
        /// </summary>
        void duyuru_yükleme()
        {
            OleDbCommand cm = new OleDbCommand("Select * from duyuru", cn);
            OleDbDataAdapter da = new OleDbDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            satir_sayisi = dt.Rows.Count;
            if (satir_sayisi == 0)
            {
                r_txt_duyuru.Text = "<Gösterilecek Duyuru Bulunmamaktadır>";

            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    r_txt_duyuru.SelectedRtf = dt.Rows[i]["konu"].ToString() + Environment.NewLine;
                }
            }
        }
        private void AraEkran_Load(object sender, EventArgs e)
        {
            duyuru_yükleme();
            tarih_saat();
            if (kontrol != "2")
            {
                menuStrip1.Items[2].Visible = false;
            }





        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 kaydet = new Form1(isim, k_id);
            kaydet.Show();
            kaydet.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sorgu sorgu = new Sorgu(kontrol, isim, k_id);
            sorgu.Show();
            sorgu.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
        }


        private void tmr_zaman_Tick(object sender, EventArgs e)
        {
            lbl_tarih.Text = DateTime.Today.Day + "/" + DateTime.Today.Month + "/" + DateTime.Today.Year;
            lbl_saat.Text = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
        }

        private void kişiEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1(isim, k_id);
            frm.Show();

        }

        private void kişileriAraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sorgu frm = new Sorgu(kontrol, isim, k_id);
            frm.Show();
        }





        private void kişileriDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OleDbCommand cm = new OleDbCommand("Select * from kisiler", cn);
            OleDbDataAdapter da = new OleDbDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Veri tabanında kayıt bulunmadığından dolayı bu kısım kullanılamaz haldedir.Lütfen veri girişi yapıp tekrardan deneyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                Silme frm = new Silme(isim, kontrol, k_id);
                frm.Show();

            }


        }

        private void AraEkran_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();

        }

        private void btn_deg_foto_Click(object sender, EventArgs e)
        {
            kullanici_resmi_degis();
        }



        private void kullanıcılarıDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kullanici_duzenle frm = new kullanici_duzenle();
            frm.Show();
        }





        private void notToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notdefteri frm = new notdefteri(k_id);
            frm.Show();

        }

        private void hatırlatmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hatirlatma frm = new hatirlatma(k_id);
            frm.Show();
        }

        private void tmr_duyuru_Tick(object sender, EventArgs e)
        {
            r_txt_duyuru.Clear();
            //duyuru command
            OleDbCommand cmd = new OleDbCommand("Select * from duyuru", cn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                r_txt_duyuru.SelectedRtf = dt.Rows[i]["konu"].ToString() + Environment.NewLine;
            }
            tmr_duyuru.Enabled = false;
            tmr_kontrol.Enabled = true;


        }

        private void tmr_kontrol_Tick(object sender, EventArgs e)
        {

            OleDbCommand cm = new OleDbCommand("Select * from duyuru", cn);
            OleDbDataAdapter da = new OleDbDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);

            satir_kontrol = dt.Rows.Count - satir_sayisi;
            if (satir_kontrol == 0)
            {

            }
            else
            {
                if (satir_sayisi < dt.Rows.Count)
                {
                    tmr_duyuru.Enabled = true;
                    satir_sayisi = dt.Rows.Count;
                    satir_kontrol = dt.Rows.Count - satir_sayisi;
                }
            }



        }
        bool panel = true;
        private void lbl_panel_Click(object sender, EventArgs e)
        {
            if (panel == false)
            {
                this.Size = new Size(664, 425);
                lbl_panel.Text = "Göster";
                panel = true;
            }
            else
            {
                this.Size = new Size(805, 425);
                lbl_panel.Text = "Gizle";
                panel = false;
            }
        }

        private void btn_deg_kullan_Click(object sender, EventArgs e)
        {

            ic_sifre_degistir frm = new ic_sifre_degistir(k_id);
            frm.Show();

        }

        private void tmr_cikiskontrol_Tick(object sender, EventArgs e)
        {

            if (vt.cikis_kontrol == true)
            {
                vt.cikis_kontrol = false;
                this.Dispose();
                this.Close();
                Giris frm = new Giris();
                frm.Show();
            }

            if (vt.hatirlatma_kontrol == true)
            {
                vt.hatirlatma_kontrol = false;
                OleDbCommand cm = new OleDbCommand("Select hatirlatma_id,konu as  [Konu],cikis_tarih as[Hatırlatma Tarihi],cikis_saat as [Hatırlatma Saati],giris_tarih as  [Kayıt Tarihi],giris_saat as [Kayıt Saati] from hatirlatma where kullanici_id = @id", cn);
                cm.Parameters.AddWithValue("@id",Convert.ToInt32(k_id));
                OleDbDataAdapter da = new OleDbDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                grid_hatirlatma.DataSource = dt;
                grid_hatirlatma.Enabled = true;
                grid_hatirlatma.Columns[0].Visible = false;
            }
        }

        private void btn_cikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkış yapmak istediğinize eminmisiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
                this.Close();
                Giris frm = new Giris();
                frm.Show();
            }


        }

        private void btn_deg_eposta_Click(object sender, EventArgs e)
        {
            ic_eposta_degistrime frm = new ic_eposta_degistrime(k_id);
            frm.Show();
        }

        private void btn_duyuru_Click(object sender, EventArgs e)
        {
            duyuru_yap();
        }

        private void txt_duyuru_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_duyuru_Click(sender, EventArgs.Empty);
            }
        }

     

        private void kişilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand cm = new OleDbCommand("select * from kisiler where kullanici_id = @id", cn);
                cm.Parameters.AddWithValue("@id", Convert.ToInt32(k_id));
                DataSet dt = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter(cm);
                da.Fill(dt);
                s_file_aktar.ShowDialog();
                dt.WriteXml(s_file_aktar.FileName);
            }
            catch (Exception)
            {
                MessageBox.Show("İşlem sırasında bir hata oluştu.Dosya yolunu doğru belirttiğinize emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }
            
            

        }
        /// <summary>
        /// Seçilen xml dosyasındaki veriyi içeri aktarır.
        /// </summary>
        void ice_aktar()
        {

            baglanti_kontrol();

            o_file_aktar.ShowDialog();
            System.Xml.XmlTextReader reader =
            new System.Xml.XmlTextReader(o_file_aktar.FileName);
            DataSet ds = new DataSet();
            
            try
            {
              
                ds.ReadXml(reader);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count != 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        baglanti_kontrol();
                        OleDbCommand cm = new OleDbCommand("insert into kisiler (Ad,Soyad,Telefon,Telefon_2,Adres,Mail,Tarih,kullanici_id) values(@ad,@soyad,@tel,@tel2,@adres,@mail,@tarih,@kullanici_id) ", cn);
                        cm.Parameters.AddWithValue("@ad", dt.Rows[i]["Ad"].ToString());
                        cm.Parameters.AddWithValue("@soyad", dt.Rows[i]["Soyad"].ToString());
                        cm.Parameters.AddWithValue("@tel", dt.Rows[i]["Telefon"].ToString());
                        cm.Parameters.AddWithValue("@tel2", dt.Rows[i]["Telefon_2"].ToString());
                        cm.Parameters.AddWithValue("@adres", dt.Rows[i]["Adres"].ToString());
                        cm.Parameters.AddWithValue("@mail", dt.Rows[i]["Mail"].ToString());
                        cm.Parameters.AddWithValue("@tarih", dt.Rows[i]["Tarih"].ToString());
                        cm.Parameters.AddWithValue("@kullanici_id", dt.Rows[i]["kullanici_id"]);

                        cn.Open();
                        cm.ExecuteNonQuery();
                        cn.Close();
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Belirtilen dosya boş olduğundan işlem yerine getirilemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
          



        }
        private void kişilerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            baglanti_kontrol();
            ice_aktar();

        }

        private void tmr_hatirlatma_Tick(object sender, EventArgs e)
        {
            
            string tarih = DateTime.Today.Day + "." + DateTime.Today.Month + "." + DateTime.Today.Year;
            string saat = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second ;
            OleDbCommand cm = new OleDbCommand("Select * from hatirlatma where kullanici_id = @id",cn);
            cm.Parameters.AddWithValue("@id",Convert.ToInt32(k_id));
            OleDbDataAdapter da = new OleDbDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                if (saat == dt.Rows[i]["cikis_saat"].ToString() && tarih == dt.Rows[i]["cikis_tarih"].ToString())
	         {
                 ni_altalma.BalloonTipTitle = "Hatırlatmanız var";
                 ni_altalma.BalloonTipText = dt.Rows[i]["konu"].ToString();
                 ni_altalma.ShowBalloonTip(15);
                 
	         }
              
            }
            
        }

       

        private void ni_altalma_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void AraEkran_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                ni_altalma.BalloonTipText = "Program hala çalışıyor...";
                ni_altalma.BalloonTipTitle = "Bilgi";
                ni_altalma.ShowBalloonTip(15);
                

            }
        }

        private void notToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            notarama frm = new notarama(k_id);
            frm.Show();
        }

        private void hatırlatmaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            hatirlatma_duzenle frm = new hatirlatma_duzenle(k_id);
            frm.Show();
        }






    }
}

