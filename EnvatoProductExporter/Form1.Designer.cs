
namespace EnvatoProductExporter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BuIdUpload = new System.Windows.Forms.Button();
            this.ofdIds = new System.Windows.Forms.OpenFileDialog();
            this.idListBox = new System.Windows.Forms.ListBox();
            this.BuGetInfo = new System.Windows.Forms.Button();
            this.pBarInfo = new System.Windows.Forms.ProgressBar();
            this.BuExportExcel = new System.Windows.Forms.Button();
            this.items = new System.Windows.Forms.ListBox();
            this.BuStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BuIdUpload
            // 
            this.BuIdUpload.Location = new System.Drawing.Point(12, 12);
            this.BuIdUpload.Name = "BuIdUpload";
            this.BuIdUpload.Size = new System.Drawing.Size(120, 23);
            this.BuIdUpload.TabIndex = 1;
            this.BuIdUpload.Text = "ID Yükle";
            this.BuIdUpload.UseVisualStyleBackColor = true;
            this.BuIdUpload.Click += new System.EventHandler(this.BuIdUpload_Click);
            // 
            // ofdIds
            // 
            this.ofdIds.DefaultExt = "xlsx,.xls";
            this.ofdIds.FileName = "Excel Id Liste";
            this.ofdIds.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdIds_FileOk);
            // 
            // idListBox
            // 
            this.idListBox.FormattingEnabled = true;
            this.idListBox.ItemHeight = 15;
            this.idListBox.Location = new System.Drawing.Point(12, 41);
            this.idListBox.Name = "idListBox";
            this.idListBox.Size = new System.Drawing.Size(120, 394);
            this.idListBox.TabIndex = 2;
            // 
            // BuGetInfo
            // 
            this.BuGetInfo.Location = new System.Drawing.Point(138, 12);
            this.BuGetInfo.Name = "BuGetInfo";
            this.BuGetInfo.Size = new System.Drawing.Size(76, 23);
            this.BuGetInfo.TabIndex = 3;
            this.BuGetInfo.Text = "Başla";
            this.BuGetInfo.UseVisualStyleBackColor = true;
            this.BuGetInfo.Click += new System.EventHandler(this.BuGetInfo_Click);
            // 
            // pBarInfo
            // 
            this.pBarInfo.Location = new System.Drawing.Point(302, 12);
            this.pBarInfo.Name = "pBarInfo";
            this.pBarInfo.Size = new System.Drawing.Size(396, 23);
            this.pBarInfo.TabIndex = 4;
            // 
            // BuExportExcel
            // 
            this.BuExportExcel.Location = new System.Drawing.Point(704, 12);
            this.BuExportExcel.Name = "BuExportExcel";
            this.BuExportExcel.Size = new System.Drawing.Size(84, 23);
            this.BuExportExcel.TabIndex = 6;
            this.BuExportExcel.Text = "Excel\'e Aktar";
            this.BuExportExcel.UseVisualStyleBackColor = true;
            this.BuExportExcel.Click += new System.EventHandler(this.BuExportExcel_Click);
            // 
            // items
            // 
            this.items.FormattingEnabled = true;
            this.items.ItemHeight = 15;
            this.items.Location = new System.Drawing.Point(138, 41);
            this.items.Name = "items";
            this.items.Size = new System.Drawing.Size(650, 394);
            this.items.TabIndex = 7;
            // 
            // BuStop
            // 
            this.BuStop.Location = new System.Drawing.Point(220, 12);
            this.BuStop.Name = "BuStop";
            this.BuStop.Size = new System.Drawing.Size(76, 23);
            this.BuStop.TabIndex = 8;
            this.BuStop.Text = "Bitir";
            this.BuStop.UseVisualStyleBackColor = true;
            this.BuStop.Click += new System.EventHandler(this.BuStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BuStop);
            this.Controls.Add(this.items);
            this.Controls.Add(this.BuExportExcel);
            this.Controls.Add(this.pBarInfo);
            this.Controls.Add(this.BuGetInfo);
            this.Controls.Add(this.idListBox);
            this.Controls.Add(this.BuIdUpload);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Envato Ürün Bilgisi Getirme Aracı";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BuIdUpload;
        private System.Windows.Forms.OpenFileDialog ofdIds;
        private System.Windows.Forms.ListBox idListBox;
        private System.Windows.Forms.Button BuGetInfo;
        private System.Windows.Forms.ProgressBar pBarInfo;
        private System.Windows.Forms.Button BuExportExcel;
        private System.Windows.Forms.ListBox items;
        private System.Windows.Forms.Button BuStop;
    }
}

