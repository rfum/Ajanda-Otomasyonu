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
    public partial class kullanici_duzenle : Form
    {
        public kullanici_duzenle()
        {
            InitializeComponent();
        }

        int k_id;
        OleDbConnection cn = new OleDbConnection(vt.connection);
        /// <summary>
        /// admin için kullanıcı listeleme
        /// </summary>
        void listele()
        {
            OleDbCommand cm = new OleDbCommand("Select kullanici_id , kullanici_ad as [Kullanıcı Adı] , yetki as [Yetki] , resim as [Resim],mail as [E-Posta],durum as [Durum] from kullanici",cn);
            OleDbDataAdapter da = new OleDbDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid_düzenleme.DataSource = dt;
            grid_düzenleme.Columns[0].Visible = false;
            
        }
        /// <summary>
        /// admin için kullanıcı arama
        /// </summary>
        void arama() 
        {
            OleDbCommand cm = new OleDbCommand("Select * from kullanici where kullanici_ad like '%' & @kullanici_adi & '%'",cn);
            cm.Parameters.AddWithValue("@kullanici_adi", txt_arama.Text);
            OleDbDataAdapter da = new OleDbDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid_düzenleme.DataSource = dt;

        }
        private void kullanici_duzenle_Load(object sender, EventArgs e)
        {
            listele();
         
        }

        private void button7_Click(object sender, EventArgs e)
        {
            arama();
        }

   

        private void grid_düzenleme_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow id = grid_düzenleme.SelectedRows[0];
            k_id = Convert.ToInt32(id.Cells[0].Value.ToString());
            kullanici_guncelle_sil frm = new kullanici_guncelle_sil(k_id.ToString());
            frm.Show();
        }

        private void tmr_kontrol_Tick(object sender, EventArgs e)
        {
           
            if (vt.guncel_kontrol == true)
            {
                vt.guncel_kontrol = false;
                listele();
            }
        }

    }
}
