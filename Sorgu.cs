using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Drawing.Printing;

namespace ajanda
{
    public partial class Sorgu : Form
    {
        public Sorgu(string retrieve,string kullanici,string id)
        {
            InitializeComponent();
            kontrol = retrieve;
            ad = kullanici;
            k_id = id;
        }
     
        string k_id;
        string ad;
        string kontrol;
        void baglanti_kontrol() 
        {
            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }
        }
        void tumunuListele() 
        {

            OleDbCommand cm = new OleDbCommand("SELECT kisiler_id,Ad,Soyad,Telefon,Telefon_2,Adres,Mail,Tarih FROM kisiler where kullanici_id = @id ", baglanti);
            cm.Parameters.AddWithValue("@id",Convert.ToInt32(k_id));
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cm);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[7].Visible = false;

        }
        void tarihListele()
        {
            OleDbCommand cm = new OleDbCommand("SELECT kisiler_id,Ad,Soyad,Telefon,Telefon_2,Adres,Mail,Tarih FROM kisiler where Tarih between @tarih1 and @tarih2 and kullanici_id = @id", baglanti);
            cm.Parameters.AddWithValue("@tarih1", dateTimePicker1.Value);
            cm.Parameters.AddWithValue("@tarih2", dateTimePicker2.Value);
            cm.Parameters.AddWithValue("@id", Convert.ToInt32(k_id));
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cm);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
      

           
        
        OleDbConnection baglanti = new OleDbConnection(vt.connection);
        private void Sorgu_Load(object sender, EventArgs e)
        {
          
             tumunuListele();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbCommand cm = new OleDbCommand("SELECT kisiler_id,Ad,Soyad,Telefon,Telefon_2,Adres,Mail,Tarih FROM kisiler where Ad = @ad or Soyad = @soyad ", baglanti);
            cm.Parameters.AddWithValue("@ad",textBox1.Text);
            cm.Parameters.AddWithValue("@soyad",textBox1.Text);
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cm);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[7].Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                tumunuListele();
            }
            else
            {
                try
                {
                    OleDbCommand cm = new OleDbCommand("SELECT kisiler_id,Ad,Soyad,Telefon,Telefon_2,Adres,Mail,Tarih FROM kisiler where (Ad  like + '%' +@ad+ '%'  or Soyad like +'%' +@soyad +'%') and kullanici_id = @id", baglanti);
                    cm.Parameters.AddWithValue("@ad", textBox1.Text);
                    cm.Parameters.AddWithValue("@soyad", textBox1.Text);
                    cm.Parameters.AddWithValue("@id", Convert.ToInt32(k_id));
                    DataTable dt = new DataTable();
                    OleDbDataAdapter da = new OleDbDataAdapter(cm);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
            
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[7].Visible = false;
                }
                catch (Exception)
                {

                    MessageBox.Show("Veri tabanı hatası : ","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
              
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            tarihListele();


        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            tarihListele();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
           
            
            if (e.KeyCode == Keys.Enter)
            {
                
                if (MessageBox.Show("Kaydetmek istiyormusunuz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataGridViewRow row = dataGridView1.SelectedRows[0];

                    OleDbCommand cm = new OleDbCommand("update kisiler set Ad = @ad , Soyad=@soyad,Telefon = @tel,Telefon_2 = @tel2,Adres = @adres,Mail = @mail,Tarih = @tarih where kisiler_id = @id", baglanti);
                    cm.Parameters.AddWithValue("@ad", row.Cells["Ad"].Value.ToString());
                    cm.Parameters.AddWithValue("@soyad", row.Cells["Soyad"].Value.ToString());
                    cm.Parameters.AddWithValue("@tel", row.Cells["Telefon"].Value.ToString());
                    cm.Parameters.AddWithValue("@tel2", row.Cells["Telefon_2"].Value.ToString());
                    cm.Parameters.AddWithValue("@adres", row.Cells["Adres"].Value.ToString());
                    cm.Parameters.AddWithValue("@mail", row.Cells["Mail"].Value.ToString());
                    cm.Parameters.AddWithValue("@tarih", row.Cells["Tarih"].Value.ToString());
                    cm.Parameters.AddWithValue("@id", Convert.ToInt32(row.Cells["kisiler_id"].Value));




                    baglanti.Open();
                    cm.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Kayıt başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
          
                
            }
        }

        private void araEkranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            

            AraEkran ara = new AraEkran(kontrol,ad,k_id);
            ara.StartPosition = FormStartPosition.CenterScreen;
            ara.Show();
        }

        private void dışaAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OleDbCommand cm = new OleDbCommand("select * from kisiler", baglanti);
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(cm);
            da.Fill(ds);
            ds.WriteXml(@"C:/ajanda.xml");
            openFileDialog1.ShowDialog();

            if (MessageBox.Show(openFileDialog1.FileName + "  adresindeki belgeyi mail olarak göndermek istermisiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {


                mail.eposta("deneme", openFileDialog1.FileName);
            }
            else
            {
                MessageBox.Show("İşlem iptal edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

       
          
            
            
        

        private void kayıtSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Silme sil = new Silme(ad,kontrol,k_id);
            sil.Show();
            sil.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
        }

      


        int i;
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font baslik = new System.Drawing.Font("Arial", 13, FontStyle.Bold);
            Font altbaslik = new System.Drawing.Font("Arial", 12, FontStyle.Regular);

            System.Drawing.Printing.PageSettings p = printDocument1.DefaultPageSettings;
            int x = 135, y = 135, say = dataGridView1.Rows.Count-1;

            e.Graphics.DrawLine(new Pen(Color.Black, 2), p.Margins.Left, 125, p.PaperSize.Width - p.Margins.Right, 125);
            e.Graphics.DrawString("Ad", baslik, Brushes.Black, 130, 130);
            e.Graphics.DrawString("Soyad", baslik, Brushes.Black, 300, 130);
            e.Graphics.DrawString("Telefon", baslik, Brushes.Black, 460, 130);
           
            e.Graphics.DrawLine(new Pen(Color.Black, 2), p.Margins.Left, 153, p.PaperSize.Width - p.Margins.Right, 153);

            for (i = 0; i < say; i++)
            {
                x += 25;
                e.Graphics.DrawString(i.ToString() + " " + dataGridView1.Rows[i].Cells[1].Value.ToString(), altbaslik, Brushes.Black, 130, x);
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[2].Value.ToString(), altbaslik, Brushes.Black, 300, x);
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[3].Value.ToString(), altbaslik, Brushes.Black, 460, x);
                e.Graphics.DrawLine(new Pen(Color.Black, 1), p.Margins.Left, x + 20, p.PaperSize.Width - p.Margins.Right, x + 20);
                

                if ((x + y + 20) > (p.PaperSize.Height + 80 - p.Margins.Bottom + 80))
                {
                    e.HasMorePages = true;
                    break;
                }
            }
            e.Graphics.DrawLine(new Pen(Color.Black, 1), p.Margins.Left, 125, p.Margins.Left, x + 20);
            e.Graphics.DrawLine(new Pen(Color.Black, 1), p.Margins.Left + 175, 125, p.Margins.Left + 175, x + 20);
            e.Graphics.DrawLine(new Pen(Color.Black, 1), p.Margins.Left + 335, 125, p.Margins.Left + 335, x + 20);
            e.Graphics.DrawLine(new Pen(Color.Black, 1), p.Margins.Left + 625, 125, p.Margins.Left + 625, x + 20);

            if (i >= say)
            {
                e.HasMorePages = false;
                i = 0;
            }
            }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 1 )
	        {
                if (MessageBox.Show("Rehberinizdeki kişileri yazdırmak istiyormusunuz?","Soru",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
                {
                    printDocument1.Print();
                }
                
	        }
            else
            {
                MessageBox.Show("Rehberinizde kayıtlı kişilere sahip olmadığınızdan bu işlemi gerçekleştiremezsiniz.", "Uyarı", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
               

            
        }

            
        }

      
   
     

       

        
    }

