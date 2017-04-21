namespace ajanda
{
    partial class hatirlatma
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(hatirlatma));
            this.dt_tarih = new System.Windows.Forms.DateTimePicker();
            this.lbl_tarih = new System.Windows.Forms.Label();
            this.lbl_saat = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rtxt_hatirlatma = new System.Windows.Forms.RichTextBox();
            this.btn_ata = new System.Windows.Forms.Button();
            this.lb_trh = new System.Windows.Forms.Label();
            this.tmr_saat = new System.Windows.Forms.Timer(this.components);
            this.dt_saat = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // dt_tarih
            // 
            this.dt_tarih.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_tarih.Location = new System.Drawing.Point(55, 162);
            this.dt_tarih.Name = "dt_tarih";
            this.dt_tarih.Size = new System.Drawing.Size(200, 20);
            this.dt_tarih.TabIndex = 28;
            // 
            // lbl_tarih
            // 
            this.lbl_tarih.AutoSize = true;
            this.lbl_tarih.Location = new System.Drawing.Point(205, 9);
            this.lbl_tarih.Name = "lbl_tarih";
            this.lbl_tarih.Size = new System.Drawing.Size(67, 13);
            this.lbl_tarih.TabIndex = 25;
            this.lbl_tarih.Text = "Tarih Buraya";
            // 
            // lbl_saat
            // 
            this.lbl_saat.AutoSize = true;
            this.lbl_saat.Location = new System.Drawing.Point(135, 9);
            this.lbl_saat.Name = "lbl_saat";
            this.lbl_saat.Size = new System.Drawing.Size(64, 13);
            this.lbl_saat.TabIndex = 24;
            this.lbl_saat.Text = "Saat buraya";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Saat = ";
            // 
            // rtxt_hatirlatma
            // 
            this.rtxt_hatirlatma.Location = new System.Drawing.Point(3, 31);
            this.rtxt_hatirlatma.Name = "rtxt_hatirlatma";
            this.rtxt_hatirlatma.Size = new System.Drawing.Size(269, 96);
            this.rtxt_hatirlatma.TabIndex = 22;
            this.rtxt_hatirlatma.Text = "";
            // 
            // btn_ata
            // 
            this.btn_ata.Location = new System.Drawing.Point(154, 133);
            this.btn_ata.Name = "btn_ata";
            this.btn_ata.Size = new System.Drawing.Size(101, 23);
            this.btn_ata.TabIndex = 21;
            this.btn_ata.Text = "Ata";
            this.btn_ata.UseVisualStyleBackColor = true;
            this.btn_ata.Click += new System.EventHandler(this.btn_ata_Click);
            // 
            // lb_trh
            // 
            this.lb_trh.AutoSize = true;
            this.lb_trh.Location = new System.Drawing.Point(9, 168);
            this.lb_trh.Name = "lb_trh";
            this.lb_trh.Size = new System.Drawing.Size(40, 13);
            this.lb_trh.TabIndex = 29;
            this.lb_trh.Text = "Tarih =";
            // 
            // tmr_saat
            // 
            this.tmr_saat.Enabled = true;
            this.tmr_saat.Tick += new System.EventHandler(this.tmr_saat_Tick);
            // 
            // dt_saat
            // 
            this.dt_saat.CustomFormat = "h:m:s";
            this.dt_saat.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_saat.Location = new System.Drawing.Point(55, 136);
            this.dt_saat.Name = "dt_saat";
            this.dt_saat.ShowUpDown = true;
            this.dt_saat.Size = new System.Drawing.Size(76, 20);
            this.dt_saat.TabIndex = 31;
            this.dt_saat.Value = new System.DateTime(2015, 6, 14, 23, 29, 26, 0);
            // 
            // hatirlatma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 188);
            this.Controls.Add(this.dt_saat);
            this.Controls.Add(this.lb_trh);
            this.Controls.Add(this.dt_tarih);
            this.Controls.Add(this.lbl_tarih);
            this.Controls.Add(this.lbl_saat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtxt_hatirlatma);
            this.Controls.Add(this.btn_ata);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "hatirlatma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "hatirlatma";
            this.Load += new System.EventHandler(this.hatirlatma_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dt_tarih;
        private System.Windows.Forms.Label lbl_tarih;
        private System.Windows.Forms.Label lbl_saat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtxt_hatirlatma;
        private System.Windows.Forms.Button btn_ata;
        private System.Windows.Forms.Label lb_trh;
        private System.Windows.Forms.Timer tmr_saat;
        private System.Windows.Forms.DateTimePicker dt_saat;
    }
}