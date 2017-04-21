namespace ajanda
{
    partial class not_duzenle
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
            this.r_text_konu = new System.Windows.Forms.RichTextBox();
            this.lbl_baslik = new System.Windows.Forms.Label();
            this.txt_baslik = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_guncelle
            // 
            this.btn_guncelle.Location = new System.Drawing.Point(12, 226);
            this.btn_guncelle.Name = "btn_guncelle";
            this.btn_guncelle.Size = new System.Drawing.Size(75, 23);
            this.btn_guncelle.TabIndex = 0;
            this.btn_guncelle.Text = "Güncelle";
            this.btn_guncelle.UseVisualStyleBackColor = true;
            // 
            // r_text_konu
            // 
            this.r_text_konu.Location = new System.Drawing.Point(12, 55);
            this.r_text_konu.Name = "r_text_konu";
            this.r_text_konu.Size = new System.Drawing.Size(260, 165);
            this.r_text_konu.TabIndex = 2;
            this.r_text_konu.Text = "Buraya konu";
            // 
            // lbl_baslik
            // 
            this.lbl_baslik.AutoSize = true;
            this.lbl_baslik.Location = new System.Drawing.Point(12, 28);
            this.lbl_baslik.Name = "lbl_baslik";
            this.lbl_baslik.Size = new System.Drawing.Size(41, 13);
            this.lbl_baslik.TabIndex = 3;
            this.lbl_baslik.Text = "Başlık :";
            // 
            // txt_baslik
            // 
            this.txt_baslik.Location = new System.Drawing.Point(59, 25);
            this.txt_baslik.Name = "txt_baslik";
            this.txt_baslik.Size = new System.Drawing.Size(175, 20);
            this.txt_baslik.TabIndex = 4;
            this.txt_baslik.Text = "Buraya seçilienin başlığı gelicek";
            // 
            // not_duzenle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.txt_baslik);
            this.Controls.Add(this.lbl_baslik);
            this.Controls.Add(this.r_text_konu);
            this.Controls.Add(this.btn_guncelle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "not_duzenle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Not Düzenle";
            this.Load += new System.EventHandler(this.not_duzenle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_guncelle;
        private System.Windows.Forms.RichTextBox r_text_konu;
        private System.Windows.Forms.Label lbl_baslik;
        private System.Windows.Forms.TextBox txt_baslik;
    }
}