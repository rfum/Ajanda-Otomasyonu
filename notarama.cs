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
    public partial class notarama : Form
    {
        public notarama(string id)
        {
            InitializeComponent();
            k_id = id;
        }
        string k_id;
        OleDbConnection cn = new OleDbConnection(vt.connection);
        /// <summary>
        /// Kullanıcıların daha önceden kaydettiği notların ismine göre arama yapar
        /// </summary>
        void arabuton() 
        {
            
            OleDbCommand cmdoldurma = new OleDbCommand("select not_id,baslik as [Başlık] , tarih as [Tarih],kullanici_id from not_defteri where baslik like  '%' & @baslik & '%' and  kullanici_id = @id", cn);
            cmdoldurma.Parameters.AddWithValue("@baslik", text_Notara.Text);
            cmdoldurma.Parameters.AddWithValue("@id",Convert.ToInt32(k_id));
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmdoldurma);
            da.Fill(dt);
            

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Aradığınız not kaydı bulunamadı");

            }
            else
            {
                grid_notara.DataSource = dt;
                grid_notara.Columns[0].Visible = false;
                grid_notara.Columns[3].Visible = false;
                

            }
        }
        private void btn_ara_Click(object sender, EventArgs e)
        {
            arabuton();
            
          
        }

        private void grid_notara_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = grid_notara.SelectedRows[0]; //üzerine tıklanan notun id'si alındı
            try
            {
                int id = Convert.ToInt32(satir.Cells["not_id"].Value);
                not_duzenle frm = new not_duzenle(id); //id diğer forma gitti(duzenleme formuna)
                frm.Show();
            }
            catch (Exception)
            {
                
               
            }
           


        }

        private void text_Notara_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_ara_Click(sender, EventArgs.Empty);

            }
        }

        private void notarama_Load(object sender, EventArgs e)
        {
            OleDbCommand cm = new OleDbCommand("select not_id,kullanici_id ,dosya_yolu,baslik as [Başlık] , tarih as [Tarih] from not_defteri where kullanici_id = @id",cn);
            cm.Parameters.AddWithValue("@id",Convert.ToInt16(k_id));
            OleDbDataAdapter da = new OleDbDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid_notara.DataSource = dt;
            grid_notara.Columns[0].Visible = false;
            grid_notara.Columns[1].Visible = false;
            grid_notara.Columns[2].Visible = false;
        }
    }
}
