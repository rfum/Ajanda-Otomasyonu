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
using System.Security.AccessControl;
using System.Security.Principal;

namespace ajanda
{
    public partial class not_duzenle : Form
    {
        public not_duzenle(int idc)
        {
            not_id = idc;
            InitializeComponent();
        }
        int not_id;
        OleDbConnection cn = new OleDbConnection(vt.connection);

        DataTable dt;
        /// <summary>
        /// Açık bağlantıları kapatır
        /// </summary>
        public void baglanti_kontrol()
        {

            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }
        private void not_duzenle_Load(object sender, EventArgs e)
        {
            OleDbCommand cm = new OleDbCommand("Select * from not_defteri where not_id = @id", cn);
            cm.Parameters.AddWithValue("@id", not_id);
            OleDbDataAdapter da = new OleDbDataAdapter(cm);
            dt = new DataTable();
            da.Fill(dt);

            StreamReader sr = new StreamReader(dt.Rows[0]["dosya_yolu"].ToString());
            r_text_konu.Text = sr.ReadToEnd();
            txt_baslik.Text = dt.Rows[0]["baslik"].ToString();





        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            baglanti_kontrol();

            string yol = Environment.CurrentDirectory + "\\notlar", tamyol = yol + "\\" + txt_baslik.Text + " " + dt.Rows[0]["kullanici_id"].ToString() + ".txt", tarih = DateTime.Today.Day + "/" + DateTime.Today.Month + "/" + DateTime.Today.Year;
            try
            {
                OleDbCommand cm = new OleDbCommand("Update not_defteri set  baslik = @baslik,dosya_yolu = @yol,tarih = @tarih where not_id = @id", cn);

                cm.Parameters.AddWithValue("@id", not_id);
                cm.Parameters.AddWithValue("@baslik", txt_baslik.Text);
                cm.Parameters.AddWithValue("@yol", tamyol);
                cm.Parameters.AddWithValue("@tarih", tarih);
                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();
                //
                FileInfo bilgi = new FileInfo(tamyol);
                FileSecurity fsec = bilgi.GetAccessControl();
                fsec.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, AccessControlType.Allow));

                bilgi.SetAccessControl(fsec);
                //
                StreamWriter notkayit = new StreamWriter(tamyol, true);

                notkayit.WriteLine(r_text_konu.Text + "-- Ekleme tarihi : " + "(" + tarih + ")--");
                notkayit.Close();
                this.Close();
                FileInfo dosya = new FileInfo(tamyol);
                dosya.Attributes = FileAttributes.Hidden;

                MessageBox.Show("Güncelleme işlemi başarılı");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata Mesajı : " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
