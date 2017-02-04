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
    public partial class hatirlatma_duzenle : Form
    {
        public hatirlatma_duzenle(string idc)
        {
            InitializeComponent();
            k_id = idc;
        }
        string k_id;
        bool durum;
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
        private void hatirlatma_duzenle_Load(object sender, EventArgs e)
        {
            OleDbCommand cm = new OleDbCommand("Select * from hatirlatma where kullanici_id = @id", cn);
            cm.Parameters.AddWithValue("@id", Convert.ToInt32(k_id));
            OleDbDataAdapter da = new OleDbDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbox_konu.DataSource = dt;
            cbox_konu.ValueMember = "hatirlatma_id";
            cbox_konu.DisplayMember = "konu";
            durum = true;


        }

        private void cbox_konu_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (durum)
            {
                OleDbCommand cm = new OleDbCommand("Select * from hatirlatma where hatirlatma_id = @id", cn);
                cm.Parameters.AddWithValue("@id", cbox_konu.SelectedValue);
                OleDbDataAdapter da = new OleDbDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dt_saat.Text = dt.Rows[0]["cikis_saat"].ToString();
                dt_tarih.Text = dt.Rows[0]["cikis_tarih"].ToString();
            }


        }

        private void chk_ackapa_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_ackapa.Checked == true)
            {
                cbox_konu.DropDownStyle = ComboBoxStyle.DropDown;
            }
            else
            {
                cbox_konu.DropDownStyle = ComboBoxStyle.DropDownList;
            }

        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            baglanti_kontrol();
            try
            {
                OleDbCommand cm = new OleDbCommand("update hatirlatma set konu = @konu , cikis_tarih = @c_tarih , cikis_saat = @c_saat where hatirlatma_id = @id", cn);
                cm.Parameters.AddWithValue("@konu", cbox_konu.Text);
                cm.Parameters.AddWithValue("@c_saat", dt_saat.Text);
                cm.Parameters.AddWithValue("@c_tarih", dt_tarih.Text);
                cm.Parameters.AddWithValue("@id", cbox_konu.SelectedValue);
                cn.Open();
                cm.ExecuteNonQuery();
                cm.Clone();
                MessageBox.Show("Güncelleme işlemi başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata Metni : " + ex.Message);
            }

        }

     

    }
}
