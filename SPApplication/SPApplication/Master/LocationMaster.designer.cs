namespace SPApplication.HR
{
    partial class LocationMaster
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtMobileNumber = new System.Windows.Forms.TextBox();
            this.txtContactPerson = new System.Windows.Forms.TextBox();
            this.txtExtensionNo = new System.Windows.Forms.TextBox();
            this.txtLocationName = new System.Windows.Forms.TextBox();
            this.txtLocationId = new System.Windows.Forms.TextBox();
            this.lbDiscription = new System.Windows.Forms.Label();
            this.lbMobileNumber = new System.Windows.Forms.Label();
            this.lbContactPerson = new System.Windows.Forms.Label();
            this.lbExtensionNo = new System.Windows.Forms.Label();
            this.lbUnitID = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.lbSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lbLocation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(387, 180);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 8;
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
            this.btnDelete.Location = new System.Drawing.Point(308, 180);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(142, 81);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(442, 23);
            this.txtDescription.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 241);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(596, 353);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(229, 180);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(150, 180);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtMobileNumber
            // 
            this.txtMobileNumber.Location = new System.Drawing.Point(142, 129);
            this.txtMobileNumber.Name = "txtMobileNumber";
            this.txtMobileNumber.Size = new System.Drawing.Size(260, 23);
            this.txtMobileNumber.TabIndex = 3;
            this.txtMobileNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMobileNumber_KeyPress);
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.Location = new System.Drawing.Point(142, 105);
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.Size = new System.Drawing.Size(260, 23);
            this.txtContactPerson.TabIndex = 2;
            // 
            // txtExtensionNo
            // 
            this.txtExtensionNo.Location = new System.Drawing.Point(142, 153);
            this.txtExtensionNo.Name = "txtExtensionNo";
            this.txtExtensionNo.Size = new System.Drawing.Size(59, 23);
            this.txtExtensionNo.TabIndex = 4;
            this.txtExtensionNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtExtensionNo_KeyPress);
            // 
            // txtLocationName
            // 
            this.txtLocationName.Location = new System.Drawing.Point(142, 57);
            this.txtLocationName.Name = "txtLocationName";
            this.txtLocationName.Size = new System.Drawing.Size(442, 23);
            this.txtLocationName.TabIndex = 0;
            // 
            // txtLocationId
            // 
            this.txtLocationId.BackColor = System.Drawing.Color.White;
            this.txtLocationId.Location = new System.Drawing.Point(142, 33);
            this.txtLocationId.Name = "txtLocationId";
            this.txtLocationId.ReadOnly = true;
            this.txtLocationId.Size = new System.Drawing.Size(60, 23);
            this.txtLocationId.TabIndex = 54;
            this.txtLocationId.TabStop = false;
            // 
            // lbDiscription
            // 
            this.lbDiscription.AutoSize = true;
            this.lbDiscription.Location = new System.Drawing.Point(48, 85);
            this.lbDiscription.Name = "lbDiscription";
            this.lbDiscription.Size = new System.Drawing.Size(68, 15);
            this.lbDiscription.TabIndex = 53;
            this.lbDiscription.Text = "Discription";
            // 
            // lbMobileNumber
            // 
            this.lbMobileNumber.AutoSize = true;
            this.lbMobileNumber.Location = new System.Drawing.Point(48, 133);
            this.lbMobileNumber.Name = "lbMobileNumber";
            this.lbMobileNumber.Size = new System.Drawing.Size(92, 15);
            this.lbMobileNumber.TabIndex = 52;
            this.lbMobileNumber.Text = "Mobile Number";
            // 
            // lbContactPerson
            // 
            this.lbContactPerson.AutoSize = true;
            this.lbContactPerson.Location = new System.Drawing.Point(48, 109);
            this.lbContactPerson.Name = "lbContactPerson";
            this.lbContactPerson.Size = new System.Drawing.Size(90, 15);
            this.lbContactPerson.TabIndex = 51;
            this.lbContactPerson.Text = "Contact Person";
            // 
            // lbExtensionNo
            // 
            this.lbExtensionNo.AutoSize = true;
            this.lbExtensionNo.Location = new System.Drawing.Point(48, 157);
            this.lbExtensionNo.Name = "lbExtensionNo";
            this.lbExtensionNo.Size = new System.Drawing.Size(78, 15);
            this.lbExtensionNo.TabIndex = 50;
            this.lbExtensionNo.Text = "Extension No";
            // 
            // lbUnitID
            // 
            this.lbUnitID.AutoSize = true;
            this.lbUnitID.Location = new System.Drawing.Point(48, 37);
            this.lbUnitID.Name = "lbUnitID";
            this.lbUnitID.Size = new System.Drawing.Size(68, 15);
            this.lbUnitID.TabIndex = 46;
            this.lbUnitID.Text = "Location ID";
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(-1, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(614, 30);
            this.lblHeader.TabIndex = 45;
            this.lblHeader.Text = "Location Master";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 44;
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Location = new System.Drawing.Point(11, 224);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(73, 15);
            this.lblTotalCount.TabIndex = 91;
            this.lblTotalCount.Text = "Total Count-";
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Location = new System.Drawing.Point(154, 217);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(47, 15);
            this.lbSearch.TabIndex = 93;
            this.lbSearch.Text = "Search ";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(207, 213);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 23);
            this.txtSearch.TabIndex = 9;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lbLocation
            // 
            this.lbLocation.AutoSize = true;
            this.lbLocation.Location = new System.Drawing.Point(48, 61);
            this.lbLocation.Name = "lbLocation";
            this.lbLocation.Size = new System.Drawing.Size(87, 15);
            this.lbLocation.TabIndex = 49;
            this.lbLocation.Text = "Location Name";
            // 
            // LocationMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(613, 598);
            this.ControlBox = false;
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lbSearch);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtMobileNumber);
            this.Controls.Add(this.txtContactPerson);
            this.Controls.Add(this.txtExtensionNo);
            this.Controls.Add(this.txtLocationName);
            this.Controls.Add(this.txtLocationId);
            this.Controls.Add(this.lbDiscription);
            this.Controls.Add(this.lbMobileNumber);
            this.Controls.Add(this.lbContactPerson);
            this.Controls.Add(this.lbExtensionNo);
            this.Controls.Add(this.lbLocation);
            this.Controls.Add(this.lbUnitID);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LocationMaster";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.LocationMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtMobileNumber;
        private System.Windows.Forms.TextBox txtContactPerson;
        private System.Windows.Forms.TextBox txtExtensionNo;
        private System.Windows.Forms.TextBox txtLocationName;
        private System.Windows.Forms.TextBox txtLocationId;
        private System.Windows.Forms.Label lbDiscription;
        private System.Windows.Forms.Label lbMobileNumber;
        private System.Windows.Forms.Label lbContactPerson;
        private System.Windows.Forms.Label lbExtensionNo;
        private System.Windows.Forms.Label lbUnitID;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lbLocation;
    }
}