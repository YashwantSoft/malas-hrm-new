namespace SPApplication.HR
{
    partial class Approval_Level_Master
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
            this.lbUnitNumber = new System.Windows.Forms.Label();
            this.lbApproval1 = new System.Windows.Forms.Label();
            this.lbFinalApproval = new System.Windows.Forms.Label();
            this.txtUnitNumber = new System.Windows.Forms.TextBox();
            this.txtApproval1 = new System.Windows.Forms.TextBox();
            this.txtFinalApproval = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lbSearch = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(-1, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(600, 30);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Approval Level Master";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbUnitNumber
            // 
            this.lbUnitNumber.AutoSize = true;
            this.lbUnitNumber.Location = new System.Drawing.Point(127, 36);
            this.lbUnitNumber.Name = "lbUnitNumber";
            this.lbUnitNumber.Size = new System.Drawing.Size(76, 15);
            this.lbUnitNumber.TabIndex = 1;
            this.lbUnitNumber.Text = "Unit Number";
            // 
            // lbApproval1
            // 
            this.lbApproval1.AutoSize = true;
            this.lbApproval1.Location = new System.Drawing.Point(127, 59);
            this.lbApproval1.Name = "lbApproval1";
            this.lbApproval1.Size = new System.Drawing.Size(67, 15);
            this.lbApproval1.TabIndex = 2;
            this.lbApproval1.Text = "Approval 1";
            // 
            // lbFinalApproval
            // 
            this.lbFinalApproval.AutoSize = true;
            this.lbFinalApproval.Location = new System.Drawing.Point(127, 82);
            this.lbFinalApproval.Name = "lbFinalApproval";
            this.lbFinalApproval.Size = new System.Drawing.Size(88, 15);
            this.lbFinalApproval.TabIndex = 3;
            this.lbFinalApproval.Text = "Final Approval";
            // 
            // txtUnitNumber
            // 
            this.txtUnitNumber.Location = new System.Drawing.Point(218, 31);
            this.txtUnitNumber.Name = "txtUnitNumber";
            this.txtUnitNumber.ReadOnly = true;
            this.txtUnitNumber.Size = new System.Drawing.Size(82, 23);
            this.txtUnitNumber.TabIndex = 0;
            this.txtUnitNumber.TabStop = false;
            // 
            // txtApproval1
            // 
            this.txtApproval1.Location = new System.Drawing.Point(218, 55);
            this.txtApproval1.Name = "txtApproval1";
            this.txtApproval1.Size = new System.Drawing.Size(254, 23);
            this.txtApproval1.TabIndex = 0;
            this.txtApproval1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtApproval1_KeyDown);
            // 
            // txtFinalApproval
            // 
            this.txtFinalApproval.Location = new System.Drawing.Point(218, 79);
            this.txtFinalApproval.Name = "txtFinalApproval";
            this.txtFinalApproval.Size = new System.Drawing.Size(254, 23);
            this.txtFinalApproval.TabIndex = 1;
            this.txtFinalApproval.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFinalApproval_KeyDown);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(175, 138);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(297, 23);
            this.txtSearch.TabIndex = 6;
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Location = new System.Drawing.Point(123, 141);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(47, 15);
            this.lbSearch.TabIndex = 220;
            this.lbSearch.Text = "Search ";
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Location = new System.Drawing.Point(9, 143);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(73, 15);
            this.lblTotalCount.TabIndex = 219;
            this.lblTotalCount.Text = "Total Count-";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(374, 105);
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
            this.btnDelete.Location = new System.Drawing.Point(299, 105);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(224, 105);
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
            this.btnSave.Location = new System.Drawing.Point(149, 105);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 162);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(583, 424);
            this.dataGridView1.TabIndex = 7;
            // 
            // Approval_Level_Master
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(598, 598);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lbSearch);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtFinalApproval);
            this.Controls.Add(this.txtApproval1);
            this.Controls.Add(this.txtUnitNumber);
            this.Controls.Add(this.lbFinalApproval);
            this.Controls.Add(this.lbApproval1);
            this.Controls.Add(this.lbUnitNumber);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Approval_Level_Master";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lbUnitNumber;
        private System.Windows.Forms.Label lbApproval1;
        private System.Windows.Forms.Label lbFinalApproval;
        private System.Windows.Forms.TextBox txtUnitNumber;
        private System.Windows.Forms.TextBox txtApproval1;
        private System.Windows.Forms.TextBox txtFinalApproval;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}