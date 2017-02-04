namespace ajanda
{
    partial class hatirlatma_duzenle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_guncelle = new System.Windows.Forms.Button();
            this.chk_ackapa = new System.Windows.Forms.CheckBox();
            this.cbox_konu = new System.Windows.Forms.ComboBox();
            this.dt_tarih = new System.Windows.Forms.DateTimePicker();
            this.dt_saat = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_guncelle
            // 
            this.btn_guncelle.Location = new System.Drawing.Point(149, 105);
            this.btn_guncelle.Name = "btn_guncelle";
            this.btn_guncelle.Size = new System.Drawing.Size(75, 23);
            this.btn_guncelle.TabIndex = 19;
            this.btn_guncelle.Text = "Güncelle";
            this.btn_guncelle.UseVisualStyleBackColor = true;
            this.btn_guncelle.Click += new System.EventHandler(this.btn_guncelle_Click);
            // 
            // chk_ackapa
            // 
            this.chk_ackapa.AutoSize = true;
            this.chk_ackapa.Location = new System.Drawing.Point(230, 15);
            this.chk_ackapa.Name = "chk_ackapa";
            this.chk_ackapa.Size = new System.Drawing.Size(15, 14);
            this.chk_ackapa.TabIndex = 18;
            this.chk_ackapa.UseVisualStyleBackColor = true;
            // 
            // cbox_konu
            // 
            this.cbox_konu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_konu.FormattingEnabled = true;
            this.cbox_konu.Location = new System.Drawing.Point(112, 12);
            this.cbox_konu.Name = "cbox_konu";
            this.cbox_konu.Size = new System.Drawing.Size(112, 21);
            this.cbox_konu.TabIndex = 17;
            // 
            // dt_tarih
            // 
            this.dt_tarih.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_tarih.Location = new System.Drawing.Point(112, 44);
            this.dt_tarih.Name = "dt_tarih";
            this.dt_tarih.Size = new System.Drawing.Size(112, 20);
            this.dt_tarih.TabIndex = 16;
            // 
            // dt_saat
            // 
            this.dt_saat.CustomFormat = "h:m:s";
            this.dt_saat.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_saat.Location = new System.Drawing.Point(112, 73);
            this.dt_saat.Name = "dt_saat";
            this.dt_saat.ShowUpDown = true;
            this.dt_saat.Size = new System.Drawing.Size(112, 20);
            this.dt_saat.TabIndex = 15;
            this.dt_saat.Value = new System.DateTime(2015, 6, 14, 23, 29, 26, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Hatırlatma Saati";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Hatırlatma Tarihi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Konu";
            // 
            // hatirlatma_duzenle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 137);
            this.Controls.Add(this.btn_guncelle);
            this.Controls.Add(this.chk_ackapa);
            this.Controls.Add(this.cbox_konu);
            this.Controls.Add(this.dt_tarih);
            this.Controls.Add(this.dt_saat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "hatirlatma_duzenle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Düzenle";
            this.Load += new System.EventHandler(this.hatirlatma_duzenle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_guncelle;
        private System.Windows.Forms.CheckBox chk_ackapa;
        private System.Windows.Forms.ComboBox cbox_konu;
        private System.Windows.Forms.DateTimePicker dt_tarih;
        private System.Windows.Forms.DateTimePicker dt_saat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}