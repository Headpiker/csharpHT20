namespace Grupp9
{
    partial class Form1
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
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.cbFrekvens = new System.Windows.Forms.ComboBox();
            this.cbKategori = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lvPodcasts = new System.Windows.Forms.ListView();
            this.columnHeaderTitel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnAntalAvsnitt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderFrekvens = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderKategori = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnNyPodd = new System.Windows.Forms.Button();
            this.btnTaBortPodd = new System.Windows.Forms.Button();
            this.lbAvsnitt = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnNyKategori = new System.Windows.Forms.Button();
            this.btnUppdateraKategori = new System.Windows.Forms.Button();
            this.rtbAvsnittInfo = new System.Windows.Forms.RichTextBox();
            this.btnUppdateraPodd = new System.Windows.Forms.Button();
            this.btnTaBortKategori = new System.Windows.Forms.Button();
            this.txtPoddNamn = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbValdKategori = new System.Windows.Forms.TextBox();
            this.lbKategorier = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(18, 272);
            this.txtUrl.Margin = new System.Windows.Forms.Padding(4);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(226, 22);
            this.txtUrl.TabIndex = 0;
            // 
            // cbFrekvens
            // 
            this.cbFrekvens.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFrekvens.FormattingEnabled = true;
            this.cbFrekvens.Location = new System.Drawing.Point(281, 272);
            this.cbFrekvens.Margin = new System.Windows.Forms.Padding(4);
            this.cbFrekvens.Name = "cbFrekvens";
            this.cbFrekvens.Size = new System.Drawing.Size(160, 24);
            this.cbFrekvens.TabIndex = 1;
            // 
            // cbKategori
            // 
            this.cbKategori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKategori.FormattingEnabled = true;
            this.cbKategori.Location = new System.Drawing.Point(462, 272);
            this.cbKategori.Margin = new System.Windows.Forms.Padding(4);
            this.cbKategori.Name = "cbKategori";
            this.cbKategori.Size = new System.Drawing.Size(160, 24);
            this.cbKategori.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 249);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "URL:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 252);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Uppdateringsfrekvens";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(459, 252);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Kategori";
            // 
            // lvPodcasts
            // 
            this.lvPodcasts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTitel,
            this.columnAntalAvsnitt,
            this.columnHeaderFrekvens,
            this.columnHeaderKategori});
            this.lvPodcasts.HideSelection = false;
            this.lvPodcasts.Location = new System.Drawing.Point(16, 14);
            this.lvPodcasts.Margin = new System.Windows.Forms.Padding(4);
            this.lvPodcasts.Name = "lvPodcasts";
            this.lvPodcasts.Size = new System.Drawing.Size(607, 230);
            this.lvPodcasts.TabIndex = 6;
            this.lvPodcasts.UseCompatibleStateImageBehavior = false;
            this.lvPodcasts.View = System.Windows.Forms.View.Details;
            this.lvPodcasts.SelectedIndexChanged += new System.EventHandler(this.lvPodcasts_SelectedIndexChanged);
            // 
            // columnHeaderTitel
            // 
            this.columnHeaderTitel.Text = "Titel";
            this.columnHeaderTitel.Width = 200;
            // 
            // columnAntalAvsnitt
            // 
            this.columnAntalAvsnitt.Text = "Avsnitt";
            this.columnAntalAvsnitt.Width = 70;
            // 
            // columnHeaderFrekvens
            // 
            this.columnHeaderFrekvens.Text = "Frekvens";
            this.columnHeaderFrekvens.Width = 80;
            // 
            // columnHeaderKategori
            // 
            this.columnHeaderKategori.Text = "Kategori";
            this.columnHeaderKategori.Width = 100;
            // 
            // btnNyPodd
            // 
            this.btnNyPodd.Location = new System.Drawing.Point(301, 329);
            this.btnNyPodd.Margin = new System.Windows.Forms.Padding(4);
            this.btnNyPodd.Name = "btnNyPodd";
            this.btnNyPodd.Size = new System.Drawing.Size(100, 28);
            this.btnNyPodd.TabIndex = 7;
            this.btnNyPodd.Text = "Ny...";
            this.btnNyPodd.UseVisualStyleBackColor = true;
            this.btnNyPodd.Click += new System.EventHandler(this.btnNyPodd_Click);
            // 
            // btnTaBortPodd
            // 
            this.btnTaBortPodd.Location = new System.Drawing.Point(524, 329);
            this.btnTaBortPodd.Margin = new System.Windows.Forms.Padding(4);
            this.btnTaBortPodd.Name = "btnTaBortPodd";
            this.btnTaBortPodd.Size = new System.Drawing.Size(100, 28);
            this.btnTaBortPodd.TabIndex = 9;
            this.btnTaBortPodd.Text = "Ta bort...";
            this.btnTaBortPodd.UseVisualStyleBackColor = true;
            this.btnTaBortPodd.Click += new System.EventHandler(this.btnTaBortPodd_Click);
            // 
            // lbAvsnitt
            // 
            this.lbAvsnitt.FormattingEnabled = true;
            this.lbAvsnitt.ItemHeight = 16;
            this.lbAvsnitt.Location = new System.Drawing.Point(16, 402);
            this.lbAvsnitt.Margin = new System.Windows.Forms.Padding(4);
            this.lbAvsnitt.Name = "lbAvsnitt";
            this.lbAvsnitt.Size = new System.Drawing.Size(607, 196);
            this.lbAvsnitt.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(683, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Kategorier";
            // 
            // btnNyKategori
            // 
            this.btnNyKategori.Location = new System.Drawing.Point(693, 302);
            this.btnNyKategori.Margin = new System.Windows.Forms.Padding(4);
            this.btnNyKategori.Name = "btnNyKategori";
            this.btnNyKategori.Size = new System.Drawing.Size(108, 28);
            this.btnNyKategori.TabIndex = 14;
            this.btnNyKategori.Text = "Ny...";
            this.btnNyKategori.UseVisualStyleBackColor = true;
            this.btnNyKategori.Click += new System.EventHandler(this.btnNyKategori_Click);
            // 
            // btnUppdateraKategori
            // 
            this.btnUppdateraKategori.Location = new System.Drawing.Point(836, 302);
            this.btnUppdateraKategori.Margin = new System.Windows.Forms.Padding(4);
            this.btnUppdateraKategori.Name = "btnUppdateraKategori";
            this.btnUppdateraKategori.Size = new System.Drawing.Size(108, 28);
            this.btnUppdateraKategori.TabIndex = 15;
            this.btnUppdateraKategori.Text = "Uppdatera";
            this.btnUppdateraKategori.UseVisualStyleBackColor = true;
            // 
            // rtbAvsnittInfo
            // 
            this.rtbAvsnittInfo.Location = new System.Drawing.Point(675, 375);
            this.rtbAvsnittInfo.Margin = new System.Windows.Forms.Padding(4);
            this.rtbAvsnittInfo.Name = "rtbAvsnittInfo";
            this.rtbAvsnittInfo.ReadOnly = true;
            this.rtbAvsnittInfo.Size = new System.Drawing.Size(495, 226);
            this.rtbAvsnittInfo.TabIndex = 16;
            this.rtbAvsnittInfo.Text = "";
            // 
            // btnUppdateraPodd
            // 
            this.btnUppdateraPodd.Location = new System.Drawing.Point(416, 329);
            this.btnUppdateraPodd.Margin = new System.Windows.Forms.Padding(4);
            this.btnUppdateraPodd.Name = "btnUppdateraPodd";
            this.btnUppdateraPodd.Size = new System.Drawing.Size(100, 28);
            this.btnUppdateraPodd.TabIndex = 17;
            this.btnUppdateraPodd.Text = "Uppdatera";
            this.btnUppdateraPodd.UseVisualStyleBackColor = true;
            // 
            // btnTaBortKategori
            // 
            this.btnTaBortKategori.Location = new System.Drawing.Point(1006, 302);
            this.btnTaBortKategori.Margin = new System.Windows.Forms.Padding(4);
            this.btnTaBortKategori.Name = "btnTaBortKategori";
            this.btnTaBortKategori.Size = new System.Drawing.Size(100, 28);
            this.btnTaBortKategori.TabIndex = 18;
            this.btnTaBortKategori.Text = "Ta bort...";
            this.btnTaBortKategori.UseVisualStyleBackColor = true;
            this.btnTaBortKategori.Click += new System.EventHandler(this.btnTaBortKategori_Click);
            // 
            // txtPoddNamn
            // 
            this.txtPoddNamn.Location = new System.Drawing.Point(16, 329);
            this.txtPoddNamn.Margin = new System.Windows.Forms.Padding(4);
            this.txtPoddNamn.Name = "txtPoddNamn";
            this.txtPoddNamn.Size = new System.Drawing.Size(228, 22);
            this.txtPoddNamn.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 306);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "Namn:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 379);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 17);
            this.label6.TabIndex = 22;
            this.label6.Text = "Podcast # : Avsnitt";
            // 
            // tbValdKategori
            // 
            this.tbValdKategori.Location = new System.Drawing.Point(685, 263);
            this.tbValdKategori.Name = "tbValdKategori";
            this.tbValdKategori.Size = new System.Drawing.Size(482, 22);
            this.tbValdKategori.TabIndex = 23;
            // 
            // lbKategorier
            // 
            this.lbKategorier.FormattingEnabled = true;
            this.lbKategorier.ItemHeight = 16;
            this.lbKategorier.Location = new System.Drawing.Point(685, 40);
            this.lbKategorier.Name = "lbKategorier";
            this.lbKategorier.Size = new System.Drawing.Size(481, 196);
            this.lbKategorier.TabIndex = 24;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 623);
            this.Controls.Add(this.lbKategorier);
            this.Controls.Add(this.tbValdKategori);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPoddNamn);
            this.Controls.Add(this.btnTaBortKategori);
            this.Controls.Add(this.btnUppdateraPodd);
            this.Controls.Add(this.rtbAvsnittInfo);
            this.Controls.Add(this.btnUppdateraKategori);
            this.Controls.Add(this.btnNyKategori);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbAvsnitt);
            this.Controls.Add(this.btnTaBortPodd);
            this.Controls.Add(this.btnNyPodd);
            this.Controls.Add(this.lvPodcasts);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbKategori);
            this.Controls.Add(this.cbFrekvens);
            this.Controls.Add(this.txtUrl);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Prenumerera på dina favoritpodcasts";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.ComboBox cbFrekvens;
        private System.Windows.Forms.ComboBox cbKategori;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lvPodcasts;
        private System.Windows.Forms.Button btnNyPodd;
        private System.Windows.Forms.Button btnTaBortPodd;
        private System.Windows.Forms.ListBox lbAvsnitt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnNyKategori;
        private System.Windows.Forms.Button btnUppdateraKategori;
        private System.Windows.Forms.RichTextBox rtbAvsnittInfo;
        private System.Windows.Forms.Button btnUppdateraPodd;
        private System.Windows.Forms.Button btnTaBortKategori;
        private System.Windows.Forms.TextBox txtPoddNamn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColumnHeader columnAntalAvsnitt;
        private System.Windows.Forms.ColumnHeader columnHeaderTitel;
        private System.Windows.Forms.ColumnHeader columnHeaderFrekvens;
        private System.Windows.Forms.ColumnHeader columnHeaderKategori;
        private System.Windows.Forms.TextBox tbValdKategori;
        private System.Windows.Forms.ListBox lbKategorier;
    }
}

