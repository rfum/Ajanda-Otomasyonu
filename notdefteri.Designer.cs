namespace ajanda
{
    partial class notdefteri
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
            this.r_text_not = new System.Windows.Forms.RichTextBox();
            this.btn_not_ekle = new System.Windows.Forms.Button();
            this.text_Baslik = new System.Windows.Forms.TextBox();
            this.lbl_baslik = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // r_text_not
            // 
            this.r_text_not.Location = new System.Drawing.Point(12, 34);
            this.r_text_not.Name = "r_text_not";
            this.r_text_not.Size = new System.Drawing.Size(391, 271);
            this.r_text_not.TabIndex = 0;
            this.r_text_not.Text = "";
            // 
            // btn_not_ekle
            // 
            this.btn_not_ekle.Location = new System.Drawing.Point(328, 6);
            this.btn_not_ekle.Name = "btn_not_ekle";
            this.btn_not_ekle.Size = new System.Drawing.Size(75, 23);
            this.btn_not_ekle.TabIndex = 1;
            this.btn_not_ekle.Text = "Kaydet";
            this.btn_not_ekle.UseVisualStyleBackColor = true;
            this.btn_not_ekle.Click += new System.EventHandler(this.btn_not_ekle_Click);
            // 
            // text_Baslik
            // 
            this.text_Baslik.Location = new System.Drawing.Point(72, 8);
            this.text_Baslik.Name = "text_Baslik";
            this.text_Baslik.Size = new System.Drawing.Size(100, 20);
            this.text_Baslik.TabIndex = 3;
            // 
            // lbl_baslik
            // 
            this.lbl_baslik.AutoSize = true;
            this.lbl_baslik.Location = new System.Drawing.Point(12, 11);
            this.lbl_baslik.Name = "lbl_baslik";
            this.lbl_baslik.Size = new System.Drawing.Size(35, 13);
            this.lbl_baslik.TabIndex = 4;
            this.lbl_baslik.Text = "Başlık";
            // 
            // notdefteri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 321);
            this.Controls.Add(this.lbl_baslik);
            this.Controls.Add(this.text_Baslik);
            this.Controls.Add(this.btn_not_ekle);
            this.Controls.Add(this.r_text_not);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "notdefteri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Not Defteri";
            this.Load += new System.EventHandler(this.notdefteri_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox r_text_not;
        private System.Windows.Forms.Button btn_not_ekle;
        private System.Windows.Forms.TextBox text_Baslik;
        private System.Windows.Forms.Label lbl_baslik;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}