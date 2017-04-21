namespace ajanda
{
    partial class Giris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Giris));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_kullanici = new System.Windows.Forms.TextBox();
            this.txt_sifre = new System.Windows.Forms.TextBox();
            this.chck_sifre = new System.Windows.Forms.CheckBox();
            this.link_kullanici = new System.Windows.Forms.LinkLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.vtDurum = new System.Windows.Forms.ToolStripStatusLabel();
            this.btn_giris = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kullanıcı Adı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Şifre";
            // 
            // txt_kullanici
            // 
            this.txt_kullanici.Location = new System.Drawing.Point(96, 27);
            this.txt_kullanici.Name = "txt_kullanici";
            this.txt_kullanici.Size = new System.Drawing.Size(100, 20);
            this.txt_kullanici.TabIndex = 2;
            this.txt_kullanici.Text = "root";
            this.txt_kullanici.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // txt_sifre
            // 
            this.txt_sifre.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txt_sifre.Location = new System.Drawing.Point(96, 62);
            this.txt_sifre.Name = "txt_sifre";
            this.txt_sifre.Size = new System.Drawing.Size(100, 20);
            this.txt_sifre.TabIndex = 3;
            this.txt_sifre.Text = "123";
            this.txt_sifre.UseSystemPasswordChar = true;
            this.txt_sifre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // chck_sifre
            // 
            this.chck_sifre.AutoSize = true;
            this.chck_sifre.Location = new System.Drawing.Point(116, 94);
            this.chck_sifre.Name = "chck_sifre";
            this.chck_sifre.Size = new System.Drawing.Size(88, 17);
            this.chck_sifre.TabIndex = 5;
            this.chck_sifre.Text = "Şifreyi Göster";
            this.chck_sifre.UseVisualStyleBackColor = true;
            this.chck_sifre.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // link_kullanici
            // 
            this.link_kullanici.AutoSize = true;
            this.link_kullanici.Location = new System.Drawing.Point(157, 138);
            this.link_kullanici.Name = "link_kullanici";
            this.link_kullanici.Size = new System.Drawing.Size(86, 13);
            this.link_kullanici.TabIndex = 6;
            this.link_kullanici.TabStop = true;
            this.link_kullanici.Text = "Kullanıcı İşlemleri";
            this.link_kullanici.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vtDurum});
            this.statusStrip1.Location = new System.Drawing.Point(0, 160);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(243, 37);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // vtDurum
            // 
            this.vtDurum.Image = global::ajanda.Properties.Resources.database_green;
            this.vtDurum.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.vtDurum.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.vtDurum.Name = "vtDurum";
            this.vtDurum.Size = new System.Drawing.Size(66, 32);
            this.vtDurum.Text = "Hazır";
            // 
            // btn_giris
            // 
            this.btn_giris.Location = new System.Drawing.Point(29, 90);
            this.btn_giris.Name = "btn_giris";
            this.btn_giris.Size = new System.Drawing.Size(75, 23);
            this.btn_giris.TabIndex = 4;
            this.btn_giris.Text = "Giriş";
            this.btn_giris.UseVisualStyleBackColor = true;
            this.btn_giris.Click += new System.EventHandler(this.button1_Click);
            // 
            // Giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 197);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.link_kullanici);
            this.Controls.Add(this.chck_sifre);
            this.Controls.Add(this.btn_giris);
            this.Controls.Add(this.txt_sifre);
            this.Controls.Add(this.txt_kullanici);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Giris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giris";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Giris_FormClosing);
            this.Load += new System.EventHandler(this.Giris_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_kullanici;
        private System.Windows.Forms.TextBox txt_sifre;
        private System.Windows.Forms.Button btn_giris;
        private System.Windows.Forms.CheckBox chck_sifre;
        private System.Windows.Forms.LinkLabel link_kullanici;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel vtDurum;
    }
}