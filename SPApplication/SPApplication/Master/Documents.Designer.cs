namespace SPApplication.Master
{
    partial class Documents
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.cmbDocumentName = new System.Windows.Forms.ComboBox();
            this.lblTotalItemCount = new System.Windows.Forms.Label();
            this.dgvFiles = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lbEstablishmentDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDocumentsFor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddDocuments = new System.Windows.Forms.Button();
            this.clmSrNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDocumentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDocumentPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmView = new System.Windows.Forms.DataGridViewLinkColumn();
            this.clmDelete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.clmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(-1, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1251, 30);
            this.lblHeader.TabIndex = 246;
            this.lblHeader.Text = "T T DB";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(180, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 15);
            this.label7.TabIndex = 11530;
            this.label7.Text = "Selected File";
            // 
            // txtFileName
            // 
            this.txtFileName.BackColor = System.Drawing.Color.White;
            this.txtFileName.Location = new System.Drawing.Point(289, 91);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(646, 23);
            this.txtFileName.TabIndex = 11529;
            // 
            // cmbDocumentName
            // 
            this.cmbDocumentName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocumentName.FormattingEnabled = true;
            this.cmbDocumentName.Location = new System.Drawing.Point(289, 66);
            this.cmbDocumentName.Name = "cmbDocumentName";
            this.cmbDocumentName.Size = new System.Drawing.Size(622, 23);
            this.cmbDocumentName.TabIndex = 11528;
            // 
            // lblTotalItemCount
            // 
            this.lblTotalItemCount.AutoSize = true;
            this.lblTotalItemCount.Location = new System.Drawing.Point(14, 132);
            this.lblTotalItemCount.Name = "lblTotalItemCount";
            this.lblTotalItemCount.Size = new System.Drawing.Size(69, 15);
            this.lblTotalItemCount.TabIndex = 11527;
            this.lblTotalItemCount.Text = "Total Count";
            // 
            // dgvFiles
            // 
            this.dgvFiles.AllowUserToAddRows = false;
            this.dgvFiles.AllowUserToDeleteRows = false;
            this.dgvFiles.AllowUserToResizeColumns = false;
            this.dgvFiles.AllowUserToResizeRows = false;
            this.dgvFiles.BackgroundColor = System.Drawing.Color.White;
            this.dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmSrNo,
            this.clmDocumentName,
            this.clmDocumentPath,
            this.clmFileName,
            this.clmView,
            this.clmDelete,
            this.clmId});
            this.dgvFiles.GridColor = System.Drawing.SystemColors.Info;
            this.dgvFiles.Location = new System.Drawing.Point(12, 148);
            this.dgvFiles.Name = "dgvFiles";
            this.dgvFiles.ReadOnly = true;
            this.dgvFiles.RowHeadersVisible = false;
            this.dgvFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvFiles.Size = new System.Drawing.Size(1226, 450);
            this.dgvFiles.TabIndex = 11525;
            this.dgvFiles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFiles_CellClick);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Location = new System.Drawing.Point(1084, 112);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 11524;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(180, 70);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(96, 15);
            this.label18.TabIndex = 11526;
            this.label18.Text = "Document Name";
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.Blue;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.ForeColor = System.Drawing.Color.White;
            this.btnBrowse.Location = new System.Drawing.Point(951, 64);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(65, 26);
            this.btnBrowse.TabIndex = 11523;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(289, 33);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(126, 23);
            this.dtpDate.TabIndex = 11531;
            // 
            // lbEstablishmentDate
            // 
            this.lbEstablishmentDate.AutoSize = true;
            this.lbEstablishmentDate.Location = new System.Drawing.Point(182, 37);
            this.lbEstablishmentDate.Name = "lbEstablishmentDate";
            this.lbEstablishmentDate.Size = new System.Drawing.Size(32, 15);
            this.lbEstablishmentDate.TabIndex = 11532;
            this.lbEstablishmentDate.Text = "Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(466, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 11534;
            this.label1.Text = "Documents of";
            // 
            // txtDocumentsFor
            // 
            this.txtDocumentsFor.BackColor = System.Drawing.Color.White;
            this.txtDocumentsFor.Location = new System.Drawing.Point(550, 33);
            this.txtDocumentsFor.Name = "txtDocumentsFor";
            this.txtDocumentsFor.ReadOnly = true;
            this.txtDocumentsFor.Size = new System.Drawing.Size(385, 23);
            this.txtDocumentsFor.TabIndex = 11533;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 11536;
            this.label2.Text = "Selected File Path";
            // 
            // txtFilePath
            // 
            this.txtFilePath.BackColor = System.Drawing.Color.White;
            this.txtFilePath.Location = new System.Drawing.Point(289, 116);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(646, 23);
            this.txtFilePath.TabIndex = 11535;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Location = new System.Drawing.Point(1163, 112);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 11537;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Location = new System.Drawing.Point(588, 603);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 11538;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Location = new System.Drawing.Point(1163, 33);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 11539;
            this.btnDelete.Text = "Clear";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            // 
            // btnAddDocuments
            // 
            this.btnAddDocuments.BackColor = System.Drawing.Color.Blue;
            this.btnAddDocuments.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddDocuments.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddDocuments.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDocuments.ForeColor = System.Drawing.Color.White;
            this.btnAddDocuments.Location = new System.Drawing.Point(915, 67);
            this.btnAddDocuments.Name = "btnAddDocuments";
            this.btnAddDocuments.Size = new System.Drawing.Size(20, 20);
            this.btnAddDocuments.TabIndex = 11540;
            this.btnAddDocuments.Text = "+";
            this.btnAddDocuments.UseVisualStyleBackColor = false;
            this.btnAddDocuments.Click += new System.EventHandler(this.btnAddDocuments_Click);
            // 
            // clmSrNo
            // 
            this.clmSrNo.HeaderText = "Sr.No";
            this.clmSrNo.Name = "clmSrNo";
            this.clmSrNo.ReadOnly = true;
            this.clmSrNo.Width = 50;
            // 
            // clmDocumentName
            // 
            this.clmDocumentName.HeaderText = "Document Name";
            this.clmDocumentName.Name = "clmDocumentName";
            this.clmDocumentName.ReadOnly = true;
            this.clmDocumentName.Width = 300;
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
            this.clmFileName.Width = 500;
            // 
            // clmView
            // 
            this.clmView.HeaderText = "View";
            this.clmView.Name = "clmView";
            this.clmView.ReadOnly = true;
            this.clmView.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmView.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmView.Width = 60;
            // 
            // clmDelete
            // 
            this.clmDelete.HeaderText = "Delete";
            this.clmDelete.Name = "clmDelete";
            this.clmDelete.ReadOnly = true;
            this.clmDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmDelete.Width = 60;
            // 
            // clmId
            // 
            this.clmId.HeaderText = "Id";
            this.clmId.Name = "clmId";
            this.clmId.ReadOnly = true;
            this.clmId.Visible = false;
            // 
            // Documents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1250, 637);
            this.ControlBox = false;
            this.Controls.Add(this.btnAddDocuments);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDocumentsFor);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lbEstablishmentDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.cmbDocumentName);
            this.Controls.Add(this.lblTotalItemCount);
            this.Controls.Add(this.dgvFiles);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Documents";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Documents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.ComboBox cmbDocumentName;
        private System.Windows.Forms.Label lblTotalItemCount;
        private System.Windows.Forms.DataGridView dgvFiles;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lbEstablishmentDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDocumentsFor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAddDocuments;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSrNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDocumentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDocumentPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFileName;
        private System.Windows.Forms.DataGridViewLinkColumn clmView;
        private System.Windows.Forms.DataGridViewLinkColumn clmDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmId;
    }
}