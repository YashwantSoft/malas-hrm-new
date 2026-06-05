namespace SPApplication.ListForms
{
    partial class DataBackup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataBackup));
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnBackuData = new System.Windows.Forms.Button();
            this.btnSyncToCloud = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDailyBackupLastDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCloudBackup = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.Blue;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(0, -2);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1139, 38);
            this.lblHeader.TabIndex = 178;
            this.lblHeader.Text = "Data Backup";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBackuData
            // 
            this.btnBackuData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBackuData.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBackuData.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackuData.ForeColor = System.Drawing.Color.White;
            this.btnBackuData.Location = new System.Drawing.Point(1050, 63);
            this.btnBackuData.Name = "btnBackuData";
            this.btnBackuData.Size = new System.Drawing.Size(75, 30);
            this.btnBackuData.TabIndex = 180;
            this.btnBackuData.Text = "Backup Data";
            this.btnBackuData.UseVisualStyleBackColor = true;
            this.btnBackuData.Click += new System.EventHandler(this.btnBackuData_Click);
            // 
            // btnSyncToCloud
            // 
            this.btnSyncToCloud.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSyncToCloud.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSyncToCloud.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSyncToCloud.ForeColor = System.Drawing.Color.White;
            this.btnSyncToCloud.Location = new System.Drawing.Point(1050, 268);
            this.btnSyncToCloud.Name = "btnSyncToCloud";
            this.btnSyncToCloud.Size = new System.Drawing.Size(75, 30);
            this.btnSyncToCloud.TabIndex = 181;
            this.btnSyncToCloud.Text = "Sync To Cloud";
            this.btnSyncToCloud.UseVisualStyleBackColor = true;
            this.btnSyncToCloud.Click += new System.EventHandler(this.btnSyncToCloud_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 106);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1114, 42);
            this.progressBar1.TabIndex = 182;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(12, 310);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(1114, 42);
            this.progressBar2.TabIndex = 183;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 17);
            this.label1.TabIndex = 184;
            this.label1.Text = "To safeguard your data, take your backup  daily.";
            // 
            // lblDailyBackupLastDate
            // 
            this.lblDailyBackupLastDate.AutoSize = true;
            this.lblDailyBackupLastDate.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDailyBackupLastDate.Location = new System.Drawing.Point(23, 74);
            this.lblDailyBackupLastDate.Name = "lblDailyBackupLastDate";
            this.lblDailyBackupLastDate.Size = new System.Drawing.Size(172, 17);
            this.lblDailyBackupLastDate.TabIndex = 185;
            this.lblDailyBackupLastDate.Text = "Last data backup taken on :";
            this.lblDailyBackupLastDate.Visible = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(23, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(631, 71);
            this.label3.TabIndex = 187;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 17);
            this.label4.TabIndex = 186;
            this.label4.Text = "Data Backup Sync to Cloud";
            // 
            // lblCloudBackup
            // 
            this.lblCloudBackup.AutoSize = true;
            this.lblCloudBackup.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCloudBackup.Location = new System.Drawing.Point(23, 275);
            this.lblCloudBackup.Name = "lblCloudBackup";
            this.lblCloudBackup.Size = new System.Drawing.Size(172, 17);
            this.lblCloudBackup.TabIndex = 188;
            this.lblCloudBackup.Text = "Last data backup taken on :";
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(1051, 363);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(74, 30);
            this.btnExit.TabIndex = 189;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // DataBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1137, 402);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblCloudBackup);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblDailyBackupLastDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnSyncToCloud);
            this.Controls.Add(this.btnBackuData);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DataBackup";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataBackupProcess";
            this.Load += new System.EventHandler(this.DataBackup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnBackuData;
        private System.Windows.Forms.Button btnSyncToCloud;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDailyBackupLastDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCloudBackup;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Timer timer1;
    }
}