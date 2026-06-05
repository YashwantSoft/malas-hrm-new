namespace SPApplication.Transaction
{
    partial class CheckESSLAttendance
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
            this.dtpOutDateTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpInDateTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnESSLData = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHours = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dtpOutDateTime
            // 
            this.dtpOutDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOutDateTime.Location = new System.Drawing.Point(131, 74);
            this.dtpOutDateTime.Name = "dtpOutDateTime";
            this.dtpOutDateTime.Size = new System.Drawing.Size(208, 23);
            this.dtpOutDateTime.TabIndex = 11325;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 15);
            this.label3.TabIndex = 11326;
            this.label3.Text = "Out Date and Time";
            // 
            // dtpInDateTime
            // 
            this.dtpInDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInDateTime.Location = new System.Drawing.Point(131, 47);
            this.dtpInDateTime.Name = "dtpInDateTime";
            this.dtpInDateTime.Size = new System.Drawing.Size(208, 23);
            this.dtpInDateTime.TabIndex = 11323;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 15);
            this.label2.TabIndex = 11324;
            this.label2.Text = "In Date and Time";
            // 
            // btnESSLData
            // 
            this.btnESSLData.BackColor = System.Drawing.Color.Navy;
            this.btnESSLData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnESSLData.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnESSLData.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnESSLData.ForeColor = System.Drawing.Color.White;
            this.btnESSLData.Location = new System.Drawing.Point(687, 77);
            this.btnESSLData.Name = "btnESSLData";
            this.btnESSLData.Size = new System.Drawing.Size(75, 30);
            this.btnESSLData.TabIndex = 11336;
            this.btnESSLData.Text = "ESSL Data";
            this.btnESSLData.UseVisualStyleBackColor = false;
            this.btnESSLData.Click += new System.EventHandler(this.btnESSLData_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Navy;
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(768, 77);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 11334;
            this.btnClear.Text = "C&lear";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Navy;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(848, 77);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 11335;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(131, 103);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(208, 23);
            this.txtDuration.TabIndex = 11344;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 11345;
            this.label1.Text = "Duration";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 15);
            this.label4.TabIndex = 11347;
            this.label4.Text = "Hours";
            // 
            // txtHours
            // 
            this.txtHours.Location = new System.Drawing.Point(131, 132);
            this.txtHours.Name = "txtHours";
            this.txtHours.Size = new System.Drawing.Size(208, 23);
            this.txtHours.TabIndex = 11346;
            // 
            // CheckESSLAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(944, 430);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtHours);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.btnESSLData);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dtpOutDateTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpInDateTime);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CheckESSLAttendance";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.SQLAttendance_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpOutDateTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpInDateTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnESSLData;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHours;
    }
}