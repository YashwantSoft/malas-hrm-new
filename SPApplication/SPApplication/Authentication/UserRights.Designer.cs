namespace SPApplication.Authentication
{
    partial class UserRights
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lbSearch = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.clbEmployee = new System.Windows.Forms.CheckedListBox();
            this.clbMenu = new System.Windows.Forms.CheckedListBox();
            this.cbAdd = new System.Windows.Forms.CheckBox();
            this.cbEdit = new System.Windows.Forms.CheckBox();
            this.cbDelete = new System.Windows.Forms.CheckBox();
            this.cbView = new System.Windows.Forms.CheckBox();
            this.cbApproval = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbSelectAll = new System.Windows.Forms.CheckBox();
            this.cbSelectAllMenuList = new System.Windows.Forms.CheckBox();
            this.cbSelectAllEmployee = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.cmbUserType = new System.Windows.Forms.ComboBox();
            this.lbLocation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(1, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1197, 30);
            this.lblHeader.TabIndex = 22;
            this.lblHeader.Text = "Database";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 369);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1173, 317);
            this.dataGridView1.TabIndex = 11259;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(884, 340);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 23);
            this.txtSearch.TabIndex = 11256;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Location = new System.Drawing.Point(831, 344);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(47, 15);
            this.lbSearch.TabIndex = 11255;
            this.lbSearch.Text = "Search ";
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Location = new System.Drawing.Point(16, 351);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(73, 15);
            this.lblTotalCount.TabIndex = 11254;
            this.lblTotalCount.Text = "Total Count-";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(676, 335);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 11251;
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
            this.btnDelete.Location = new System.Drawing.Point(600, 335);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 11250;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(448, 335);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 11248;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // clbEmployee
            // 
            this.clbEmployee.FormattingEnabled = true;
            this.clbEmployee.Location = new System.Drawing.Point(16, 91);
            this.clbEmployee.Name = "clbEmployee";
            this.clbEmployee.Size = new System.Drawing.Size(388, 238);
            this.clbEmployee.TabIndex = 11262;
            // 
            // clbMenu
            // 
            this.clbMenu.FormattingEnabled = true;
            this.clbMenu.Location = new System.Drawing.Point(435, 91);
            this.clbMenu.Name = "clbMenu";
            this.clbMenu.Size = new System.Drawing.Size(388, 238);
            this.clbMenu.TabIndex = 11263;
            // 
            // cbAdd
            // 
            this.cbAdd.AutoSize = true;
            this.cbAdd.Location = new System.Drawing.Point(861, 134);
            this.cbAdd.Name = "cbAdd";
            this.cbAdd.Size = new System.Drawing.Size(47, 19);
            this.cbAdd.TabIndex = 11264;
            this.cbAdd.Text = "Add";
            this.cbAdd.UseVisualStyleBackColor = true;
            this.cbAdd.CheckedChanged += new System.EventHandler(this.cbAdd_CheckedChanged);
            // 
            // cbEdit
            // 
            this.cbEdit.AutoSize = true;
            this.cbEdit.Location = new System.Drawing.Point(861, 159);
            this.cbEdit.Name = "cbEdit";
            this.cbEdit.Size = new System.Drawing.Size(47, 19);
            this.cbEdit.TabIndex = 11265;
            this.cbEdit.Text = "Edit";
            this.cbEdit.UseVisualStyleBackColor = true;
            this.cbEdit.CheckedChanged += new System.EventHandler(this.cbEdit_CheckedChanged);
            // 
            // cbDelete
            // 
            this.cbDelete.AutoSize = true;
            this.cbDelete.Location = new System.Drawing.Point(861, 184);
            this.cbDelete.Name = "cbDelete";
            this.cbDelete.Size = new System.Drawing.Size(60, 19);
            this.cbDelete.TabIndex = 11266;
            this.cbDelete.Text = "Delete";
            this.cbDelete.UseVisualStyleBackColor = true;
            this.cbDelete.CheckedChanged += new System.EventHandler(this.cbDelete_CheckedChanged);
            // 
            // cbView
            // 
            this.cbView.AutoSize = true;
            this.cbView.Location = new System.Drawing.Point(861, 209);
            this.cbView.Name = "cbView";
            this.cbView.Size = new System.Drawing.Size(52, 19);
            this.cbView.TabIndex = 11267;
            this.cbView.Text = "View";
            this.cbView.UseVisualStyleBackColor = true;
            this.cbView.CheckedChanged += new System.EventHandler(this.cbView_CheckedChanged);
            // 
            // cbApproval
            // 
            this.cbApproval.AutoSize = true;
            this.cbApproval.Location = new System.Drawing.Point(861, 234);
            this.cbApproval.Name = "cbApproval";
            this.cbApproval.Size = new System.Drawing.Size(76, 19);
            this.cbApproval.TabIndex = 11268;
            this.cbApproval.Text = "Approval";
            this.cbApproval.UseVisualStyleBackColor = true;
            this.cbApproval.CheckedChanged += new System.EventHandler(this.cbApproval_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 15);
            this.label1.TabIndex = 11269;
            this.label1.Text = "Employee Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(438, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 11270;
            this.label5.Text = "Menu List";
            // 
            // cbSelectAll
            // 
            this.cbSelectAll.AutoSize = true;
            this.cbSelectAll.Location = new System.Drawing.Point(861, 92);
            this.cbSelectAll.Name = "cbSelectAll";
            this.cbSelectAll.Size = new System.Drawing.Size(76, 19);
            this.cbSelectAll.TabIndex = 11271;
            this.cbSelectAll.Text = "Select All";
            this.cbSelectAll.UseVisualStyleBackColor = true;
            this.cbSelectAll.CheckedChanged += new System.EventHandler(this.cbSelectAll_CheckedChanged);
            // 
            // cbSelectAllMenuList
            // 
            this.cbSelectAllMenuList.AutoSize = true;
            this.cbSelectAllMenuList.Location = new System.Drawing.Point(742, 70);
            this.cbSelectAllMenuList.Name = "cbSelectAllMenuList";
            this.cbSelectAllMenuList.Size = new System.Drawing.Size(76, 19);
            this.cbSelectAllMenuList.TabIndex = 11272;
            this.cbSelectAllMenuList.Text = "Select All";
            this.cbSelectAllMenuList.UseVisualStyleBackColor = true;
            this.cbSelectAllMenuList.CheckedChanged += new System.EventHandler(this.cbSelectAllMenuList_CheckedChanged);
            // 
            // cbSelectAllEmployee
            // 
            this.cbSelectAllEmployee.AutoSize = true;
            this.cbSelectAllEmployee.Location = new System.Drawing.Point(328, 70);
            this.cbSelectAllEmployee.Name = "cbSelectAllEmployee";
            this.cbSelectAllEmployee.Size = new System.Drawing.Size(76, 19);
            this.cbSelectAllEmployee.TabIndex = 11273;
            this.cbSelectAllEmployee.Text = "Select All";
            this.cbSelectAllEmployee.UseVisualStyleBackColor = true;
            this.cbSelectAllEmployee.CheckedChanged += new System.EventHandler(this.cbSelectAllEmployee_CheckedChanged);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(524, 335);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 11249;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cmbUserType
            // 
            this.cmbUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserType.FormattingEnabled = true;
            this.cmbUserType.Location = new System.Drawing.Point(126, 33);
            this.cmbUserType.Name = "cmbUserType";
            this.cmbUserType.Size = new System.Drawing.Size(278, 23);
            this.cmbUserType.TabIndex = 11274;
            this.cmbUserType.SelectionChangeCommitted += new System.EventHandler(this.cmbUserType_SelectionChangeCommitted);
            // 
            // lbLocation
            // 
            this.lbLocation.AutoSize = true;
            this.lbLocation.Location = new System.Drawing.Point(6, 37);
            this.lbLocation.Name = "lbLocation";
            this.lbLocation.Size = new System.Drawing.Size(118, 15);
            this.lbLocation.TabIndex = 11275;
            this.lbLocation.Text = "User Type / Category";
            // 
            // UserRights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1198, 698);
            this.ControlBox = false;
            this.Controls.Add(this.cmbUserType);
            this.Controls.Add(this.lbLocation);
            this.Controls.Add(this.cbSelectAllEmployee);
            this.Controls.Add(this.cbSelectAllMenuList);
            this.Controls.Add(this.cbSelectAll);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbApproval);
            this.Controls.Add(this.cbView);
            this.Controls.Add(this.cbDelete);
            this.Controls.Add(this.cbEdit);
            this.Controls.Add(this.cbAdd);
            this.Controls.Add(this.clbMenu);
            this.Controls.Add(this.clbEmployee);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lbSearch);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UserRights";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.UserRights_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckedListBox clbEmployee;
        private System.Windows.Forms.CheckedListBox clbMenu;
        private System.Windows.Forms.CheckBox cbAdd;
        private System.Windows.Forms.CheckBox cbEdit;
        private System.Windows.Forms.CheckBox cbDelete;
        private System.Windows.Forms.CheckBox cbView;
        private System.Windows.Forms.CheckBox cbApproval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbSelectAll;
        private System.Windows.Forms.CheckBox cbSelectAllMenuList;
        private System.Windows.Forms.CheckBox cbSelectAllEmployee;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ComboBox cmbUserType;
        private System.Windows.Forms.Label lbLocation;
    }
}