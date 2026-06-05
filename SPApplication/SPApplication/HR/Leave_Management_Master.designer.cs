namespace SPApplication.HR
{
    partial class Leave_Management_Master
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
            this.txtEmployeName = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lbSearch = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtBalanceLeave = new System.Windows.Forms.TextBox();
            this.txtTotalLeave = new System.Windows.Forms.TextBox();
            this.txtUnitNumber = new System.Windows.Forms.TextBox();
            this.txtUnitID = new System.Windows.Forms.TextBox();
            this.lbBalanaceLeave = new System.Windows.Forms.Label();
            this.lbEmployeName = new System.Windows.Forms.Label();
            this.lbTotalLeave = new System.Windows.Forms.Label();
            this.lbUnitNumber = new System.Windows.Forms.Label();
            this.lbUnitID = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEmployeName
            // 
            this.txtEmployeName.Location = new System.Drawing.Point(235, 80);
            this.txtEmployeName.Name = "txtEmployeName";
            this.txtEmployeName.ReadOnly = true;
            this.txtEmployeName.Size = new System.Drawing.Size(226, 23);
            this.txtEmployeName.TabIndex = 0;
            this.txtEmployeName.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(175, 189);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 23);
            this.txtSearch.TabIndex = 6;
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Location = new System.Drawing.Point(123, 193);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(47, 15);
            this.lbSearch.TabIndex = 262;
            this.lbSearch.Text = "Search ";
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Location = new System.Drawing.Point(11, 196);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(73, 15);
            this.lblTotalCount.TabIndex = 261;
            this.lblTotalCount.Text = "Total Count-";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(374, 154);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 5;
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
            this.btnDelete.Location = new System.Drawing.Point(299, 154);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 216);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(583, 370);
            this.dataGridView1.TabIndex = 7;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(224, 154);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 3;
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
            this.btnSave.Location = new System.Drawing.Point(149, 154);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtBalanceLeave
            // 
            this.txtBalanceLeave.Location = new System.Drawing.Point(235, 128);
            this.txtBalanceLeave.Name = "txtBalanceLeave";
            this.txtBalanceLeave.Size = new System.Drawing.Size(226, 23);
            this.txtBalanceLeave.TabIndex = 1;
            // 
            // txtTotalLeave
            // 
            this.txtTotalLeave.Location = new System.Drawing.Point(235, 104);
            this.txtTotalLeave.Name = "txtTotalLeave";
            this.txtTotalLeave.Size = new System.Drawing.Size(226, 23);
            this.txtTotalLeave.TabIndex = 0;
            this.txtTotalLeave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTotalLeave_KeyDown);
            // 
            // txtUnitNumber
            // 
            this.txtUnitNumber.Location = new System.Drawing.Point(235, 56);
            this.txtUnitNumber.Name = "txtUnitNumber";
            this.txtUnitNumber.ReadOnly = true;
            this.txtUnitNumber.Size = new System.Drawing.Size(226, 23);
            this.txtUnitNumber.TabIndex = 0;
            this.txtUnitNumber.TabStop = false;
            // 
            // txtUnitID
            // 
            this.txtUnitID.Location = new System.Drawing.Point(235, 32);
            this.txtUnitID.Name = "txtUnitID";
            this.txtUnitID.ReadOnly = true;
            this.txtUnitID.Size = new System.Drawing.Size(60, 23);
            this.txtUnitID.TabIndex = 0;
            this.txtUnitID.TabStop = false;
            // 
            // lbBalanaceLeave
            // 
            this.lbBalanaceLeave.AutoSize = true;
            this.lbBalanaceLeave.Location = new System.Drawing.Point(138, 131);
            this.lbBalanaceLeave.Name = "lbBalanaceLeave";
            this.lbBalanaceLeave.Size = new System.Drawing.Size(87, 15);
            this.lbBalanaceLeave.TabIndex = 246;
            this.lbBalanaceLeave.Text = "Balance Leave ";
            // 
            // lbEmployeName
            // 
            this.lbEmployeName.AutoSize = true;
            this.lbEmployeName.Location = new System.Drawing.Point(138, 83);
            this.lbEmployeName.Name = "lbEmployeName";
            this.lbEmployeName.Size = new System.Drawing.Size(87, 15);
            this.lbEmployeName.TabIndex = 244;
            this.lbEmployeName.Text = "Employe Name";
            // 
            // lbTotalLeave
            // 
            this.lbTotalLeave.AutoSize = true;
            this.lbTotalLeave.Location = new System.Drawing.Point(138, 107);
            this.lbTotalLeave.Name = "lbTotalLeave";
            this.lbTotalLeave.Size = new System.Drawing.Size(67, 15);
            this.lbTotalLeave.TabIndex = 243;
            this.lbTotalLeave.Text = "Total Leave";
            // 
            // lbUnitNumber
            // 
            this.lbUnitNumber.AutoSize = true;
            this.lbUnitNumber.Location = new System.Drawing.Point(138, 59);
            this.lbUnitNumber.Name = "lbUnitNumber";
            this.lbUnitNumber.Size = new System.Drawing.Size(75, 15);
            this.lbUnitNumber.TabIndex = 242;
            this.lbUnitNumber.Text = "Unit number";
            // 
            // lbUnitID
            // 
            this.lbUnitID.AutoSize = true;
            this.lbUnitID.Location = new System.Drawing.Point(138, 35);
            this.lbUnitID.Name = "lbUnitID";
            this.lbUnitID.Size = new System.Drawing.Size(45, 15);
            this.lbUnitID.TabIndex = 241;
            this.lbUnitID.Text = "Unit ID";
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(-1, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(600, 30);
            this.lblHeader.TabIndex = 240;
            this.lblHeader.Text = "Leave Management Master";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 239;
            // 
            // Leave_Management_Master
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(598, 598);
            this.ControlBox = false;
            this.Controls.Add(this.txtEmployeName);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lbSearch);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtBalanceLeave);
            this.Controls.Add(this.txtTotalLeave);
            this.Controls.Add(this.txtUnitNumber);
            this.Controls.Add(this.txtUnitID);
            this.Controls.Add(this.lbBalanaceLeave);
            this.Controls.Add(this.lbEmployeName);
            this.Controls.Add(this.lbTotalLeave);
            this.Controls.Add(this.lbUnitNumber);
            this.Controls.Add(this.lbUnitID);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Leave_Management_Master";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEmployeName;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtBalanceLeave;
        private System.Windows.Forms.TextBox txtTotalLeave;
        private System.Windows.Forms.TextBox txtUnitNumber;
        private System.Windows.Forms.TextBox txtUnitID;
        private System.Windows.Forms.Label lbBalanaceLeave;
        private System.Windows.Forms.Label lbEmployeName;
        private System.Windows.Forms.Label lbTotalLeave;
        private System.Windows.Forms.Label lbUnitNumber;
        private System.Windows.Forms.Label lbUnitID;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label label1;
    }
}