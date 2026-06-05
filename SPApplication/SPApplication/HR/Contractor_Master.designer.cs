namespace SPApplication.HR
{
    partial class Contractor_Master
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
            this.lbContractorId = new System.Windows.Forms.Label();
            this.lbContractorName = new System.Windows.Forms.Label();
            this.lbRegisterNo = new System.Windows.Forms.Label();
            this.lbAddress = new System.Windows.Forms.Label();
            this.lbGSTIN = new System.Windows.Forms.Label();
            this.lbContactPerson = new System.Windows.Forms.Label();
            this.lbMobileNumber = new System.Windows.Forms.Label();
            this.lbJoiningDate = new System.Windows.Forms.Label();
            this.txtContractorId = new System.Windows.Forms.TextBox();
            this.txtContractorName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtRegisterNo = new System.Windows.Forms.TextBox();
            this.txtGSTIN = new System.Windows.Forms.TextBox();
            this.txtContactPerson = new System.Windows.Forms.TextBox();
            this.txtMobileNumber = new System.Windows.Forms.TextBox();
            this.dtpJoiningDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.lbSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
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
            this.lblHeader.Size = new System.Drawing.Size(1191, 30);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Contractor Master";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbContractorId
            // 
            this.lbContractorId.AutoSize = true;
            this.lbContractorId.Location = new System.Drawing.Point(31, 36);
            this.lbContractorId.Name = "lbContractorId";
            this.lbContractorId.Size = new System.Drawing.Size(81, 15);
            this.lbContractorId.TabIndex = 1;
            this.lbContractorId.Text = "Contractor ID";
            // 
            // lbContractorName
            // 
            this.lbContractorName.AutoSize = true;
            this.lbContractorName.Location = new System.Drawing.Point(31, 59);
            this.lbContractorName.Name = "lbContractorName";
            this.lbContractorName.Size = new System.Drawing.Size(100, 15);
            this.lbContractorName.TabIndex = 2;
            this.lbContractorName.Text = "Contractor Name";
            // 
            // lbRegisterNo
            // 
            this.lbRegisterNo.AutoSize = true;
            this.lbRegisterNo.Location = new System.Drawing.Point(460, 43);
            this.lbRegisterNo.Name = "lbRegisterNo";
            this.lbRegisterNo.Size = new System.Drawing.Size(69, 15);
            this.lbRegisterNo.TabIndex = 3;
            this.lbRegisterNo.Text = "Register No";
            // 
            // lbAddress
            // 
            this.lbAddress.AutoSize = true;
            this.lbAddress.Location = new System.Drawing.Point(31, 83);
            this.lbAddress.Name = "lbAddress";
            this.lbAddress.Size = new System.Drawing.Size(51, 15);
            this.lbAddress.TabIndex = 4;
            this.lbAddress.Text = "Address";
            // 
            // lbGSTIN
            // 
            this.lbGSTIN.AutoSize = true;
            this.lbGSTIN.Location = new System.Drawing.Point(460, 67);
            this.lbGSTIN.Name = "lbGSTIN";
            this.lbGSTIN.Size = new System.Drawing.Size(39, 15);
            this.lbGSTIN.TabIndex = 5;
            this.lbGSTIN.Text = "GSTIN";
            // 
            // lbContactPerson
            // 
            this.lbContactPerson.AutoSize = true;
            this.lbContactPerson.Location = new System.Drawing.Point(31, 187);
            this.lbContactPerson.Name = "lbContactPerson";
            this.lbContactPerson.Size = new System.Drawing.Size(90, 15);
            this.lbContactPerson.TabIndex = 6;
            this.lbContactPerson.Text = "Contact Person";
            // 
            // lbMobileNumber
            // 
            this.lbMobileNumber.AutoSize = true;
            this.lbMobileNumber.Location = new System.Drawing.Point(31, 211);
            this.lbMobileNumber.Name = "lbMobileNumber";
            this.lbMobileNumber.Size = new System.Drawing.Size(92, 15);
            this.lbMobileNumber.TabIndex = 7;
            this.lbMobileNumber.Text = "Mobile Number";
            // 
            // lbJoiningDate
            // 
            this.lbJoiningDate.AutoSize = true;
            this.lbJoiningDate.Location = new System.Drawing.Point(31, 235);
            this.lbJoiningDate.Name = "lbJoiningDate";
            this.lbJoiningDate.Size = new System.Drawing.Size(74, 15);
            this.lbJoiningDate.TabIndex = 8;
            this.lbJoiningDate.Text = "Joining Date";
            // 
            // txtContractorId
            // 
            this.txtContractorId.Location = new System.Drawing.Point(136, 32);
            this.txtContractorId.Name = "txtContractorId";
            this.txtContractorId.Size = new System.Drawing.Size(60, 23);
            this.txtContractorId.TabIndex = 9;
            // 
            // txtContractorName
            // 
            this.txtContractorName.Location = new System.Drawing.Point(136, 56);
            this.txtContractorName.Name = "txtContractorName";
            this.txtContractorName.Size = new System.Drawing.Size(226, 23);
            this.txtContractorName.TabIndex = 10;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(136, 80);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(226, 95);
            this.txtAddress.TabIndex = 11;
            // 
            // txtRegisterNo
            // 
            this.txtRegisterNo.Location = new System.Drawing.Point(638, 37);
            this.txtRegisterNo.Name = "txtRegisterNo";
            this.txtRegisterNo.Size = new System.Drawing.Size(226, 23);
            this.txtRegisterNo.TabIndex = 12;
            // 
            // txtGSTIN
            // 
            this.txtGSTIN.Location = new System.Drawing.Point(638, 61);
            this.txtGSTIN.Name = "txtGSTIN";
            this.txtGSTIN.Size = new System.Drawing.Size(226, 23);
            this.txtGSTIN.TabIndex = 13;
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.Location = new System.Drawing.Point(136, 181);
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.Size = new System.Drawing.Size(226, 23);
            this.txtContactPerson.TabIndex = 14;
            // 
            // txtMobileNumber
            // 
            this.txtMobileNumber.Location = new System.Drawing.Point(136, 205);
            this.txtMobileNumber.Name = "txtMobileNumber";
            this.txtMobileNumber.Size = new System.Drawing.Size(226, 23);
            this.txtMobileNumber.TabIndex = 15;
            // 
            // dtpJoiningDate
            // 
            this.dtpJoiningDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpJoiningDate.Location = new System.Drawing.Point(136, 229);
            this.dtpJoiningDate.Name = "dtpJoiningDate";
            this.dtpJoiningDate.Size = new System.Drawing.Size(102, 23);
            this.dtpJoiningDate.TabIndex = 16;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(409, 244);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(485, 244);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 18;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 317);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(583, 275);
            this.dataGridView1.TabIndex = 19;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(561, 244);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 20;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(638, 244);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 21;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Location = new System.Drawing.Point(11, 293);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(73, 15);
            this.lblTotalCount.TabIndex = 213;
            this.lblTotalCount.Text = "Total Count-";
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Location = new System.Drawing.Point(133, 291);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(47, 15);
            this.lbSearch.TabIndex = 214;
            this.lbSearch.Text = "Search ";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(184, 288);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 23);
            this.txtSearch.TabIndex = 215;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(638, 157);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(226, 23);
            this.textBox1.TabIndex = 223;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(638, 133);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(226, 23);
            this.textBox2.TabIndex = 222;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(638, 109);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(226, 23);
            this.textBox3.TabIndex = 221;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(638, 85);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(226, 23);
            this.textBox4.TabIndex = 220;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(460, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 219;
            this.label1.Text = "PTEC No.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(460, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 218;
            this.label2.Text = "PTRC No";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(460, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 15);
            this.label3.TabIndex = 217;
            this.label3.Text = "ESIC Establishment ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(460, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 15);
            this.label4.TabIndex = 216;
            this.label4.Text = "PF Establishment ID";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(638, 181);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(102, 23);
            this.dateTimePicker1.TabIndex = 225;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(460, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 15);
            this.label5.TabIndex = 224;
            this.label5.Text = "Contract Renewal Date";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(638, 205);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(192, 23);
            this.textBox5.TabIndex = 227;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(460, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 15);
            this.label6.TabIndex = 226;
            this.label6.Text = "Total Employee As Per License";
            // 
            // Contractor_Master
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1190, 598);
            this.ControlBox = false;
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lbSearch);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpJoiningDate);
            this.Controls.Add(this.txtMobileNumber);
            this.Controls.Add(this.txtContactPerson);
            this.Controls.Add(this.txtGSTIN);
            this.Controls.Add(this.txtRegisterNo);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtContractorName);
            this.Controls.Add(this.txtContractorId);
            this.Controls.Add(this.lbJoiningDate);
            this.Controls.Add(this.lbMobileNumber);
            this.Controls.Add(this.lbContactPerson);
            this.Controls.Add(this.lbGSTIN);
            this.Controls.Add(this.lbAddress);
            this.Controls.Add(this.lbRegisterNo);
            this.Controls.Add(this.lbContractorName);
            this.Controls.Add(this.lbContractorId);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Contractor_Master";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lbContractorId;
        private System.Windows.Forms.Label lbContractorName;
        private System.Windows.Forms.Label lbRegisterNo;
        private System.Windows.Forms.Label lbAddress;
        private System.Windows.Forms.Label lbGSTIN;
        private System.Windows.Forms.Label lbContactPerson;
        private System.Windows.Forms.Label lbMobileNumber;
        private System.Windows.Forms.Label lbJoiningDate;
        private System.Windows.Forms.TextBox txtContractorId;
        private System.Windows.Forms.TextBox txtContractorName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtRegisterNo;
        private System.Windows.Forms.TextBox txtGSTIN;
        private System.Windows.Forms.TextBox txtContactPerson;
        private System.Windows.Forms.TextBox txtMobileNumber;
        private System.Windows.Forms.DateTimePicker dtpJoiningDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label6;
    }
}