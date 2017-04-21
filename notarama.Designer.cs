namespace ajanda
{
    partial class notarama
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
            this.btn_ara = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.text_Notara = new System.Windows.Forms.TextBox();
            this.grid_notara = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_notara)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_ara
            // 
            this.btn_ara.Location = new System.Drawing.Point(130, 17);
            this.btn_ara.Name = "btn_ara";
            this.btn_ara.Size = new System.Drawing.Size(75, 23);
            this.btn_ara.TabIndex = 0;
            this.btn_ara.Text = "Ara";
            this.btn_ara.UseVisualStyleBackColor = true;
            this.btn_ara.Click += new System.EventHandler(this.btn_ara_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.text_Notara);
            this.groupBox1.Controls.Add(this.btn_ara);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 51);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Başlığı Girin";
            // 
            // text_Notara
            // 
            this.text_Notara.Location = new System.Drawing.Point(6, 19);
            this.text_Notara.Name = "text_Notara";
            this.text_Notara.Size = new System.Drawing.Size(100, 20);
            this.text_Notara.TabIndex = 1;
            this.text_Notara.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_Notara_KeyDown);
            // 
            // grid_notara
            // 
            this.grid_notara.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grid_notara.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_notara.Location = new System.Drawing.Point(12, 69);
            this.grid_notara.Name = "grid_notara";
            this.grid_notara.ReadOnly = true;
            this.grid_notara.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_notara.Size = new System.Drawing.Size(222, 180);
            this.grid_notara.TabIndex = 2;
            this.grid_notara.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_notara_CellDoubleClick);
            // 
            // notarama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 261);
            this.Controls.Add(this.grid_notara);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "notarama";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arama";
            this.Load += new System.EventHandler(this.notarama_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_notara)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_ara;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox text_Notara;
        private System.Windows.Forms.DataGridView grid_notara;
    }
}