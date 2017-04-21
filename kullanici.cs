using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Net.Mail;

namespace ajanda
{
    public partial class kullanici_islem : Form
    {
        public kullanici_islem()
        {
            InitializeComponent();
        }
        void mailgonder() 
        
        {

            OleDbCommand cm = new OleDbCommand("select * from kullanici where kullanici_ad = @ad and mail = @mail", baglanti);
            cm.Parameters.AddWithValue("@ad",textBox3.Text);
            cm.Parameters.AddWithValue("@mail",textBox5.Text);
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cm);
            da.Fill(dt);
            
            if (dt.Rows.Count == 0)
            {
                 MessageBox.Show("Verilen bilgilerde hata bulundu lütfen bilgileri kontrol edin ve tekrar deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    string sifre = dt.Rows[0]["kullanici_sifre"].ToString();
                    MailMessage mesaj = new MailMessage();
                    SmtpClient client = new SmtpClient();
                    client.Host = "pop.mynet.com";
                    client.Port = 587;
           
                    client.Credentials = new System.Net.NetworkCredential("axaxaxaxaxax@mynet.com", "123456789");
                    mesaj.To.Add(new MailAddress(dt.Rows[0]["mail"].ToString()));
                    mesaj.From = new MailAddress("axaxaxaxaxax@mynet.com");
                    mesaj.Subject = "Ajanda yazılımı için şifreniz";
                    mesaj.Body = sifre;
                    client.Send(mesaj);
                    MessageBox.Show("Şifreniz Başarı ile gönderildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Gönderme işlemi sırasında bir hata oluştu " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
          
        
        }
        bool k_kontrol;
        OleDbConnection baglanti = new OleDbConnection(vt.connection);
        private void button1_Click(object sender, EventArgs e)
        {
            k_kontrol = false;
            OleDbCommand cmk = new OleDbCommand("Select * from kullanici",baglanti);
            OleDbDataAdapter da = new OleDbDataAdapter(cmk);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["kullanici_ad"].ToString()== textBox1.Text)
                {
                    k_kontrol = true;
                } 
            }

            if (k_kontrol == true)
            {
                MessageBox.Show("Verilen kullanıcı adı şuan kullanımdadır lütfen başka bir ad deneyiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (textBox2.Text == textBox4.Text && textBox1.Text != "" && textBox4.Text != "" && textBox6.Text != "" && textBox2.Text != "")
                {
                    if (MessageBox.Show("İşleme devam etmek istiyormusunuz?.", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        OleDbCommand cm = new OleDbCommand("insert into kullanici (kullanici_ad,kullanici_sifre,yetki,mail,durum) values (@ad,@sifre,0,@mail,@dürüm)", baglanti);
                        cm.Parameters.AddWithValue("@ad", textBox1.Text);
                        cm.Parameters.AddWithValue("@sifre", textBox2.Text);
                        cm.Parameters.AddWithValue("@mail", textBox6.Text);
                        cm.Parameters.AddWithValue("@dürüm", "1");

                        baglanti.Open();
                        cm.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show(textBox1.Text + " isimli yeni kullanıcı başarı ile kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("İşlem iptal edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Şifrelerde uyumsuzluk var lütfen şifre bilginizi kontrol ediniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
     
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProgressBar1.Style = ProgressBarStyle.Marquee;
            backgroundWorker1.RunWorkerAsync();

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            lbl_durum.Text = "Lütfen Bekleyin ...";
            mailgonder();
            

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgressBar1.Style = ProgressBarStyle.Blocks;
            lbl_durum.Text = "Tamamlandı.";
            
        }

    }
}
