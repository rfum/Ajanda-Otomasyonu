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
using System.IO;

namespace ajanda
{
    public partial class kullanici_guncelle_sil : Form
    {
        public kullanici_guncelle_sil(string id)
        {
            InitializeComponent();
            k_id = id;
        }
        string k_id;
        OleDbConnection cn = new OleDbConnection(vt.connection);
        /// <summary>
        /// Açık veritabanı bağlantısını kapatır.
        /// </summary>
        void baglanti_kontrol() 
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }
        /// <summary>
        /// Seçilen kullanıcının bilgilerinin doldurulmasını sağlar
        /// </summary>
        byte[] img;
        DataTable dt;
        void listele() 
        {
            string resim;
            string yetki,durum;
            ArrayList yetkidizi = new ArrayList();
            yetkidizi.Add("Standart Kullanıcı");
            yetkidizi.Add("Admin");
            yetkidizi.Add("Super Admin");
            ArrayList durumdizi = new ArrayList();
            durumdizi.Add("Yasaklı");
            durumdizi.Add("Aktif");
          
            OleDbCommand cm = new OleDbCommand("Select * from kullanici where kullanici_id=@id ", cn);
            cm.Parameters.AddWithValue("@id", k_id);
            OleDbDataAdapter da = new OleDbDataAdapter(cm);
            dt = new DataTable();
            da.Fill(dt);
            
            txt_ad.Text = dt.Rows[0]["kullanici_ad"].ToString();
            txt_sifre.Text = dt.Rows[0]["kullanici_sifre"].ToString();
            txt_mail.Text = dt.Rows[0]["mail"].ToString();
            yetki = dt.Rows[0]["yetki"].ToString();
            resim = dt.Rows[0]["resim"].ToString();
            if (resim != "")
            {
                img = (byte[])dt.Rows[0]["resim"];
                MemoryStream ms = new MemoryStream(img);
                pbox_resim.Image = Image.FromStream(ms);
                pbox_resim.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            durum = dt.Rows[0]["durum"].ToString();
            cmbx_yetki.DataSource = yetkidizi;
            cmbx_durum.DataSource = durumdizi;

            switch (yetki)
            {
                case "0": cmbx_yetki.SelectedIndex= 0; break;
                case "1": cmbx_yetki.SelectedIndex= 1; break;
                case "2": cmbx_yetki.SelectedIndex= 2;
                    btn_sil.Enabled = false;
                    cmbx_durum.Enabled = false;
                    cmbx_yetki.Enabled = false;
                    break;
            }
            switch (durum)
            {
                case "0": cmbx_durum.SelectedIndex = 0; break;
                case "1": cmbx_durum.SelectedIndex = 1; break;
            }
            
            
        }
        private void kullanici_guncelle_sil_Load(object sender, EventArgs e)
        {
          listele();
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            baglanti_kontrol();
            try
            {
                OleDbCommand cm = new OleDbCommand("Update kullanici set kullanici_ad = @ad ,kullanici_sifre = @sifre , yetki = @yetki , mail = @mail , durum = @durum  where kullanici_id=@id", cn);
                cm.Parameters.AddWithValue("@ad", txt_ad.Text);
                cm.Parameters.AddWithValue("@sifre", txt_sifre.Text);
                cm.Parameters.AddWithValue("@yetki", cmbx_yetki.SelectedIndex);
                cm.Parameters.AddWithValue("@mail", txt_mail.Text);
                cm.Parameters.AddWithValue("@durum", cmbx_durum.SelectedIndex);
                cm.Parameters.AddWithValue("@id", Convert.ToInt32(k_id));
              
                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();

                MessageBox.Show("Güncelleme işlemi başarılı.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                vt.guncel_kontrol = true;
                this.Dispose();
                this.Close();
               
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata oluştu : "+ex.Message,"Önemli Hata!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
               
            }
         
     

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txt_sifre.UseSystemPasswordChar = false;
            }
            else
            {
                txt_sifre.UseSystemPasswordChar = true;
            }
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            baglanti_kontrol();
            if (MessageBox.Show("Bu kullanıcıyı silmek istediğinize eminmisiniz? Dikkat ! Bu işlem geri alınaMAz.", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {


                try
                {
                    OleDbCommand cm = new OleDbCommand("Delete from kullanici where kullanici_id=@id", cn);
                    cm.Parameters.AddWithValue("@id", Convert.ToInt32(k_id));
                    cn.Open();
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Silme işlemi başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vt.guncel_kontrol = true;
                    this.Dispose();
                    this.Close();

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Hata oluştu : " + ex.Message, "Önemli Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        byte[] res;
        private void pbox_resim_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                o_file_degistir.ShowDialog();
                OleDbCommand cm = new OleDbCommand("update kullanici set resim=@resim where kullanici_id=@id", cn);

                pbox_resim.Image = Image.FromFile(o_file_degistir.FileName);
                Bitmap bmp = new Bitmap(pbox_resim.Image);
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                res = ms.ToArray();

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

       
    }
}
