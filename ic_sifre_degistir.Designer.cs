namespace ajanda
{
    partial class ic_sifre_degistir
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
            this.txt_mevcut = new System.Windows.Forms.TextBox();
            this.txt_yeni = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_degistir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_mevcut
            // 
            this.txt_mevcut.Location = new System.Drawing.Point(125, 23);
            this.txt_mevcut.Name = "txt_mevcut";
            this.txt_mevcut.Size = new System.Drawing.Size(100, 20);
            this.txt_mevcut.TabIndex = 0;
            this.txt_mevcut.UseSystemPasswordChar = true;
            // 
            // txt_yeni
            // 
            this.txt_yeni.Location = new System.Drawing.Point(125, 53);
            this.txt_yeni.Name = "txt_yeni";
            this.txt_yeni.Size = new System.Drawing.Size(100, 20);
            this.txt_yeni.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mevcut Şifreniz : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Yeni Kullanıcı Adı : ";
            // 
            // btn_degistir
            // 
            this.btn_degistir.Location = new System.Drawing.Point(125, 79);
            this.btn_degistir.Name = "btn_degistir";
            this.btn_degistir.Size = new System.Drawing.Size(100, 23);
            this.btn_degistir.TabIndex = 6;
            this.btn_degistir.Text = "Değiştir";
            this.btn_degistir.UseVisualStyleBackColor = true;
            this.btn_degistir.Click += new System.EventHandler(this.btn_degistir_Click);
            // 
            // ic_sifre_degistir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 118);
            this.Controls.Add(this.btn_degistir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_yeni);
            this.Controls.Add(this.txt_mevcut);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ic_sifre_degistir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yeni Kullanıcı Adı";
            this.Load += new System.EventHandler(this.ic_sifre_degistir_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_mevcut;
        private System.Windows.Forms.TextBox txt_yeni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_degistir;
    }
}