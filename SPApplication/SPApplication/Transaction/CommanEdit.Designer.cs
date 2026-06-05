namespace SPApplication.Transaction
{
    partial class CommanEdit
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
            this.cmbComman = new System.Windows.Forms.ComboBox();
            this.lblComman = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.cbOverTimeApplicable = new System.Windows.Forms.CheckBox();
            this.cbFlexibleHours = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cmbComman
            // 
            this.cmbComman.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComman.FormattingEnabled = true;
            this.cmbComman.Location = new System.Drawing.Point(247, 62);
            this.cmbComman.Name = "cmbComman";
            this.cmbComman.Size = new System.Drawing.Size(330, 23);
            this.cmbComman.TabIndex = 11429;
            // 
            // lblComman
            // 
            this.lblComman.AutoSize = true;
            this.lblComman.Location = new System.Drawing.Point(72, 65);
            this.lblComman.Name = "lblComman";
            this.lblComman.Size = new System.Drawing.Size(53, 15);
            this.lblComman.TabIndex = 11428;
            this.lblComman.Text = "Location";
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.Blue;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(717, 30);
            this.lblHeader.TabIndex = 11430;
            this.lblHeader.Text = "Update Record";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(442, 91);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 11432;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(361, 91);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 11431;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(199, 91);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 11434;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(280, 91);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 11433;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(247, 38);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(330, 23);
            this.cmbLocation.TabIndex = 11436;
            this.cmbLocation.Visible = false;
            this.cmbLocation.SelectionChangeCommitted += new System.EventHandler(this.cmbLocation_SelectionChangeCommitted);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(72, 41);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(53, 15);
            this.lblLocation.TabIndex = 11435;
            this.lblLocation.Text = "Location";
            this.lblLocation.Visible = false;
            // 
            // cbOverTimeApplicable
            // 
            this.cbOverTimeApplicable.AutoSize = true;
            this.cbOverTimeApplicable.Location = new System.Drawing.Point(247, 64);
            this.cbOverTimeApplicable.Name = "cbOverTimeApplicable";
            this.cbOverTimeApplicable.Size = new System.Drawing.Size(143, 19);
            this.cbOverTimeApplicable.TabIndex = 11437;
            this.cbOverTimeApplicable.Text = "Over Time Applicable";
            this.cbOverTimeApplicable.UseVisualStyleBackColor = true;
            this.cbOverTimeApplicable.Visible = false;
            // 
            // cbFlexibleHours
            // 
            this.cbFlexibleHours.AutoSize = true;
            this.cbFlexibleHours.Location = new System.Drawing.Point(247, 64);
            this.cbFlexibleHours.Name = "cbFlexibleHours";
            this.cbFlexibleHours.Size = new System.Drawing.Size(105, 19);
            this.cbFlexibleHours.TabIndex = 11438;
            this.cbFlexibleHours.Text = "Flexible Hours";
            this.cbFlexibleHours.UseVisualStyleBackColor = true;
            this.cbFlexibleHours.Visible = false;
            // 
            // CommanEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(717, 154);
            this.ControlBox = false;
            this.Controls.Add(this.cbFlexibleHours);
            this.Controls.Add(this.cbOverTimeApplicable);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.cmbComman);
            this.Controls.Add(this.lblComman);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CommanEdit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.CommanEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbComman;
        private System.Windows.Forms.Label lblComman;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.CheckBox cbOverTimeApplicable;
        private System.Windows.Forms.CheckBox cbFlexibleHours;
    }
}