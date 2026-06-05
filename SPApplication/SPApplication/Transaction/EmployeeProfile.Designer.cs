namespace SPApplication.Transaction
{
    partial class EmployeeProfile
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.RichTextBox();
            this.rtbLeaveRecords = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnJobProfile = new System.Windows.Forms.Button();
            this.rtbStatusCount = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rtbTicketInfo = new System.Windows.Forms.RichTextBox();
            this.lblTicketInformation = new System.Windows.Forms.Label();
            this.lblTotalItemCount = new System.Windows.Forms.Label();
            this.dgvFiles = new System.Windows.Forms.DataGridView();
            this.clmSrNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDocumentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDocumentPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmView = new System.Windows.Forms.DataGridViewLinkColumn();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(-3, -1);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1199, 30);
            this.lblHeader.TabIndex = 267;
            this.lblHeader.Text = "Asset Master";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(600, 660);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 30);
            this.btnExit.TabIndex = 271;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(172, 660);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 270;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(93, 660);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 269;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(14, 660);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 268;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 15);
            this.label1.TabIndex = 11455;
            this.label1.Text = "Employee Details";
            // 
            // lblData
            // 
            this.lblData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(79)))));
            this.lblData.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData.ForeColor = System.Drawing.Color.White;
            this.lblData.Location = new System.Drawing.Point(13, 54);
            this.lblData.Name = "lblData";
            this.lblData.ReadOnly = true;
            this.lblData.Size = new System.Drawing.Size(368, 300);
            this.lblData.TabIndex = 11454;
            this.lblData.Text = "";
            // 
            // rtbLeaveRecords
            // 
            this.rtbLeaveRecords.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(79)))));
            this.rtbLeaveRecords.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbLeaveRecords.ForeColor = System.Drawing.Color.White;
            this.rtbLeaveRecords.Location = new System.Drawing.Point(403, 54);
            this.rtbLeaveRecords.Name = "rtbLeaveRecords";
            this.rtbLeaveRecords.Size = new System.Drawing.Size(250, 300);
            this.rtbLeaveRecords.TabIndex = 11457;
            this.rtbLeaveRecords.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(405, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 15);
            this.label2.TabIndex = 11458;
            this.label2.Text = "Leave and Comp Off ";
            // 
            // btnJobProfile
            // 
            this.btnJobProfile.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnJobProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJobProfile.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobProfile.ForeColor = System.Drawing.Color.White;
            this.btnJobProfile.Location = new System.Drawing.Point(494, 660);
            this.btnJobProfile.Name = "btnJobProfile";
            this.btnJobProfile.Size = new System.Drawing.Size(100, 30);
            this.btnJobProfile.TabIndex = 11459;
            this.btnJobProfile.Text = "Job Profile";
            this.btnJobProfile.UseVisualStyleBackColor = false;
            this.btnJobProfile.Click += new System.EventHandler(this.btnJobProfile_Click);
            // 
            // rtbStatusCount
            // 
            this.rtbStatusCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(79)))));
            this.rtbStatusCount.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbStatusCount.ForeColor = System.Drawing.Color.White;
            this.rtbStatusCount.Location = new System.Drawing.Point(667, 55);
            this.rtbStatusCount.Name = "rtbStatusCount";
            this.rtbStatusCount.Size = new System.Drawing.Size(250, 300);
            this.rtbStatusCount.TabIndex = 11460;
            this.rtbStatusCount.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(668, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 15);
            this.label3.TabIndex = 11461;
            this.label3.Text = "Employee Attendance";
            // 
            // rtbTicketInfo
            // 
            this.rtbTicketInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(79)))));
            this.rtbTicketInfo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbTicketInfo.ForeColor = System.Drawing.Color.White;
            this.rtbTicketInfo.Location = new System.Drawing.Point(931, 54);
            this.rtbTicketInfo.Name = "rtbTicketInfo";
            this.rtbTicketInfo.Size = new System.Drawing.Size(250, 300);
            this.rtbTicketInfo.TabIndex = 11462;
            this.rtbTicketInfo.Text = "";
            // 
            // lblTicketInformation
            // 
            this.lblTicketInformation.AutoSize = true;
            this.lblTicketInformation.Location = new System.Drawing.Point(936, 38);
            this.lblTicketInformation.Name = "lblTicketInformation";
            this.lblTicketInformation.Size = new System.Drawing.Size(107, 15);
            this.lblTicketInformation.TabIndex = 11463;
            this.lblTicketInformation.Text = "Ticket Information";
            // 
            // lblTotalItemCount
            // 
            this.lblTotalItemCount.AutoSize = true;
            this.lblTotalItemCount.Location = new System.Drawing.Point(1074, 370);
            this.lblTotalItemCount.Name = "lblTotalItemCount";
            this.lblTotalItemCount.Size = new System.Drawing.Size(69, 15);
            this.lblTotalItemCount.TabIndex = 11529;
            this.lblTotalItemCount.Text = "Total Count";
            // 
            // dgvFiles
            // 
            this.dgvFiles.AllowUserToAddRows = false;
            this.dgvFiles.AllowUserToDeleteRows = false;
            this.dgvFiles.AllowUserToResizeColumns = false;
            this.dgvFiles.AllowUserToResizeRows = false;
            this.dgvFiles.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFiles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmSrNo,
            this.clmId,
            this.clmDocumentName,
            this.clmDocumentPath,
            this.clmFileName,
            this.clmView});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFiles.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFiles.GridColor = System.Drawing.Color.White;
            this.dgvFiles.Location = new System.Drawing.Point(12, 387);
            this.dgvFiles.Name = "dgvFiles";
            this.dgvFiles.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFiles.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvFiles.RowHeadersVisible = false;
            this.dgvFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvFiles.Size = new System.Drawing.Size(1170, 267);
            this.dgvFiles.TabIndex = 11528;
            this.dgvFiles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFiles_CellClick);
            // 
            // clmSrNo
            // 
            this.clmSrNo.HeaderText = "Sr.No";
            this.clmSrNo.Name = "clmSrNo";
            this.clmSrNo.ReadOnly = true;
            this.clmSrNo.Width = 50;
            // 
            // clmId
            // 
            this.clmId.HeaderText = "Id";
            this.clmId.Name = "clmId";
            this.clmId.ReadOnly = true;
            this.clmId.Visible = false;
            // 
            // clmDocumentName
            // 
            this.clmDocumentName.HeaderText = "Document Name";
            this.clmDocumentName.Name = "clmDocumentName";
            this.clmDocumentName.ReadOnly = true;
            this.clmDocumentName.Width = 400;
            // 
            // clmDocumentPath
            // 
            this.clmDocumentPath.HeaderText = "Document Path";
            this.clmDocumentPath.Name = "clmDocumentPath";
            this.clmDocumentPath.ReadOnly = true;
            this.clmDocumentPath.Visible = false;
            this.clmDocumentPath.Width = 500;
            // 
            // clmFileName
            // 
            this.clmFileName.HeaderText = "FileName";
            this.clmFileName.Name = "clmFileName";
            this.clmFileName.ReadOnly = true;
            this.clmFileName.Width = 600;
            // 
            // clmView
            // 
            this.clmView.HeaderText = "View";
            this.clmView.LinkColor = System.Drawing.Color.White;
            this.clmView.Name = "clmView";
            this.clmView.ReadOnly = true;
            this.clmView.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmView.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmView.Width = 60;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 370);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 15);
            this.label4.TabIndex = 11530;
            this.label4.Text = "Documents List";
            // 
            // EmployeeProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1194, 694);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTotalItemCount);
            this.Controls.Add(this.dgvFiles);
            this.Controls.Add(this.lblTicketInformation);
            this.Controls.Add(this.rtbTicketInfo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtbStatusCount);
            this.Controls.Add(this.btnJobProfile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rtbLeaveRecords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EmployeeProfile";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.EmployeeProfile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox lblData;
        private System.Windows.Forms.RichTextBox rtbLeaveRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnJobProfile;
        private System.Windows.Forms.RichTextBox rtbStatusCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtbTicketInfo;
        private System.Windows.Forms.Label lblTicketInformation;
        private System.Windows.Forms.Label lblTotalItemCount;
        private System.Windows.Forms.DataGridView dgvFiles;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSrNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDocumentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDocumentPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFileName;
        private System.Windows.Forms.DataGridViewLinkColumn clmView;
    }
}