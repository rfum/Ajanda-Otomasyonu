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

namespace ajanda
{
    public partial class notdefteri : Form
    {
        public notdefteri (string id)
        {
            k_id = id;
            InitializeComponent();
        }
        /// <summary>
        /// Kullanıcıların yeni kayıt eklemesini sağlar.
        /// </summary>
        void eklebuton() 
        {
            OleDbCommand cmid = new OleDbCommand("select * from not_defteri",baglanti);
            OleDbDataAdapter da = new OleDbDataAdapter(cmid);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string baslik = text_Baslik.Text;
            saveFileDialog1.FileName = baslik + " " + k_id + ".txt";
            
            string startupPath = Environment.CurrentDirectory + "\\notlar";
          string tamyol = startupPath + "\\" + saveFileDialog1.FileName;

            if (baslik == "")
            {
                MessageBox.Show("Başlık boş geçilemez.");
            }
            else
            {
                if (!File.Exists(tamyol))
                {


                    OleDbCommand cm = new OleDbCommand("insert into  not_defteri (kullanici_id,baslik,dosya_yolu,tarih) values(@kul,@baslik,@dosya,@tarih)", baglanti);
                    cm.Parameters.AddWithValue("@kul", k_id);
                    cm.Parameters.AddWithValue("@baslik", baslik);
                    cm.Parameters.AddWithValue("@dosya", tamyol);
                    cm.Parameters.AddWithValue("@tarih",DateTime.Now);
                    baglanti.Open();
                    cm.ExecuteNonQuery();
                    baglanti.Close();

                    MessageBox.Show("Not Kaydedildi");

                    StreamWriter notkayit = new StreamWriter(startupPath + "\\" + saveFileDialog1.FileName);
                    notkayit.WriteLine(r_text_not.Text);
                    notkayit.Close();
                    this.Close();
                    FileInfo dosya = new FileInfo(tamyol);
                    dosya.Attributes = FileAttributes.Hidden;
                }
                else
                {
                    MessageBox.Show("Aynı nottan başka bir tane daha var");
                }



            }
        }
        string k_id;
        OleDbConnection baglanti = new OleDbConnection(vt.connection);
        private void notdefteri_Load(object sender, EventArgs e)
        {
            //klasörün varlığının kontrolü eğer yoksa yeni klasör ekleniyor
            string startupPath = Environment.CurrentDirectory + "\\notlar";
            if (Directory.Exists(startupPath))
            {
                
            }
            else
            {
                Directory.CreateDirectory(startupPath);
                DirectoryInfo dir = new DirectoryInfo(startupPath);
                dir.Attributes = FileAttributes.Hidden;
                
              
            }
        
            
        }


        private void btn_not_ekle_Click(object sender, EventArgs e)
        {
            eklebuton();            
        }
    }
}
