
namespace EnvatoItemGetter
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TbToken = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PbItem = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LbEnvatoItems = new System.Windows.Forms.ListBox();
            this.LbIds = new System.Windows.Forms.ListBox();
            this.BuLoadId = new System.Windows.Forms.Button();
            this.IdListFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.BuStart = new System.Windows.Forms.Button();
            this.BuStop = new System.Windows.Forms.Button();
            this.BuExport = new System.Windows.Forms.Button();
            this.BuErrorListExport = new System.Windows.Forms.Button();
            this.EnvatoItemSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TbToken
            // 
            this.TbToken.Location = new System.Drawing.Point(92, 31);
            this.TbToken.Name = "TbToken";
            this.TbToken.Size = new System.Drawing.Size(675, 20);
            this.TbToken.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Envato Api Key";
            // 
            // PbItem
            // 
            this.PbItem.Location = new System.Drawing.Point(15, 415);
            this.PbItem.Name = "PbItem";
            this.PbItem.Size = new System.Drawing.Size(773, 23);
            this.PbItem.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TbToken);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(773, 73);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ayarlar";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LbEnvatoItems);
            this.groupBox2.Controls.Add(this.LbIds);
            this.groupBox2.Location = new System.Drawing.Point(15, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(773, 285);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Veriler";
            // 
            // LbEnvatoItems
            // 
            this.LbEnvatoItems.FormattingEnabled = true;
            this.LbEnvatoItems.Location = new System.Drawing.Point(144, 19);
            this.LbEnvatoItems.Name = "LbEnvatoItems";
            this.LbEnvatoItems.Size = new System.Drawing.Size(623, 251);
            this.LbEnvatoItems.TabIndex = 1;
            // 
            // LbIds
            // 
            this.LbIds.FormattingEnabled = true;
            this.LbIds.Location = new System.Drawing.Point(9, 19);
            this.LbIds.Name = "LbIds";
            this.LbIds.Size = new System.Drawing.Size(120, 251);
            this.LbIds.TabIndex = 0;
            // 
            // BuLoadId
            // 
            this.BuLoadId.Location = new System.Drawing.Point(15, 95);
            this.BuLoadId.Name = "BuLoadId";
            this.BuLoadId.Size = new System.Drawing.Size(129, 23);
            this.BuLoadId.TabIndex = 5;
            this.BuLoadId.Text = "Idleri Yükle";
            this.BuLoadId.UseVisualStyleBackColor = true;
            this.BuLoadId.Click += new System.EventHandler(this.BuLoadId_Click);
            // 
            // IdListFileDialog
            // 
            this.IdListFileDialog.DefaultExt = "xlsx";
            this.IdListFileDialog.FileName = "idler";
            this.IdListFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            this.IdListFileDialog.Title = "İd Listesini Seçin";
            // 
            // BuStart
            // 
            this.BuStart.Location = new System.Drawing.Point(159, 95);
            this.BuStart.Name = "BuStart";
            this.BuStart.Size = new System.Drawing.Size(126, 23);
            this.BuStart.TabIndex = 6;
            this.BuStart.Text = "Botu Başlat";
            this.BuStart.UseVisualStyleBackColor = true;
            this.BuStart.Click += new System.EventHandler(this.BuStart_Click);
            // 
            // BuStop
            // 
            this.BuStop.Location = new System.Drawing.Point(291, 95);
            this.BuStop.Name = "BuStop";
            this.BuStop.Size = new System.Drawing.Size(126, 23);
            this.BuStop.TabIndex = 7;
            this.BuStop.Text = "Botu Durdur";
            this.BuStop.UseVisualStyleBackColor = true;
            this.BuStop.Click += new System.EventHandler(this.BuStop_Click);
            // 
            // BuExport
            // 
            this.BuExport.Location = new System.Drawing.Point(656, 95);
            this.BuExport.Name = "BuExport";
            this.BuExport.Size = new System.Drawing.Size(126, 23);
            this.BuExport.TabIndex = 8;
            this.BuExport.Text = "Excele Aktar";
            this.BuExport.UseVisualStyleBackColor = true;
            this.BuExport.Click += new System.EventHandler(this.BuExport_Click);
            // 
            // BuErrorListExport
            // 
            this.BuErrorListExport.Location = new System.Drawing.Point(524, 95);
            this.BuErrorListExport.Name = "BuErrorListExport";
            this.BuErrorListExport.Size = new System.Drawing.Size(126, 23);
            this.BuErrorListExport.TabIndex = 9;
            this.BuErrorListExport.Text = "Hatalı ID Listesi";
            this.BuErrorListExport.UseVisualStyleBackColor = true;
            this.BuErrorListExport.Click += new System.EventHandler(this.BuErrorListExport_Click);
            // 
            // EnvatoItemSaveDialog
            // 
            this.EnvatoItemSaveDialog.DefaultExt = "csv";
            this.EnvatoItemSaveDialog.FileName = "EnvatoItems";
            this.EnvatoItemSaveDialog.Filter = "CSV File|*.csv;";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BuErrorListExport);
            this.Controls.Add(this.BuExport);
            this.Controls.Add(this.BuStop);
            this.Controls.Add(this.BuStart);
            this.Controls.Add(this.BuLoadId);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.PbItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ENVATO Item Getter  ---- shaesk.com";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TbToken;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar PbItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox LbIds;
        private System.Windows.Forms.ListBox LbEnvatoItems;
        private System.Windows.Forms.Button BuLoadId;
        private System.Windows.Forms.OpenFileDialog IdListFileDialog;
        private System.Windows.Forms.Button BuStart;
        private System.Windows.Forms.Button BuStop;
        private System.Windows.Forms.Button BuExport;
        private System.Windows.Forms.Button BuErrorListExport;
        private System.Windows.Forms.SaveFileDialog EnvatoItemSaveDialog;
    }
}

