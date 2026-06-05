namespace SPApplication
{
    partial class LoginWindow
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
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblContactDetails = new System.Windows.Forms.Label();
            this.pbProductLogo = new System.Windows.Forms.PictureBox();
            this.lblCopyRights = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lbHelp = new System.Windows.Forms.LinkLabel();
            this.pbClientLogo = new System.Windows.Forms.PictureBox();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClientLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblUserName.Location = new System.Drawing.Point(134, 127);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(83, 19);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "User Name";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblPassword.Location = new System.Drawing.Point(134, 191);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(74, 19);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(132, 148);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(338, 23);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserName_KeyDown);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(132, 212);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(338, 23);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Navy;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(264, 249);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Clear";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLogin.BackColor = System.Drawing.Color.Navy;
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLogin.CausesValidation = false;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogin.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogin.Location = new System.Drawing.Point(184, 249);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 30);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "&Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Navy;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(344, 249);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblContactDetails
            // 
            this.lblContactDetails.AutoSize = true;
            this.lblContactDetails.ForeColor = System.Drawing.Color.Navy;
            this.lblContactDetails.Location = new System.Drawing.Point(13, 359);
            this.lblContactDetails.Name = "lblContactDetails";
            this.lblContactDetails.Size = new System.Drawing.Size(19, 15);
            this.lblContactDetails.TabIndex = 11318;
            this.lblContactDetails.Text = "TT";
            this.lblContactDetails.Visible = false;
            // 
            // pbProductLogo
            // 
            this.pbProductLogo.Location = new System.Drawing.Point(13, 320);
            this.pbProductLogo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbProductLogo.Name = "pbProductLogo";
            this.pbProductLogo.Size = new System.Drawing.Size(77, 36);
            this.pbProductLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbProductLogo.TabIndex = 11317;
            this.pbProductLogo.TabStop = false;
            this.pbProductLogo.Visible = false;
            // 
            // lblCopyRights
            // 
            this.lblCopyRights.AutoSize = true;
            this.lblCopyRights.ForeColor = System.Drawing.Color.Navy;
            this.lblCopyRights.Location = new System.Drawing.Point(10, 375);
            this.lblCopyRights.Name = "lblCopyRights";
            this.lblCopyRights.Size = new System.Drawing.Size(19, 15);
            this.lblCopyRights.TabIndex = 11316;
            this.lblCopyRights.Text = "TT";
            this.lblCopyRights.Visible = false;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.ForeColor = System.Drawing.Color.Navy;
            this.lblVersion.Location = new System.Drawing.Point(490, 375);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(85, 15);
            this.lblVersion.TabIndex = 11320;
            this.lblVersion.Text = "Version 8.0.12";
            // 
            // lbHelp
            // 
            this.lbHelp.AutoSize = true;
            this.lbHelp.Location = new System.Drawing.Point(513, 354);
            this.lbHelp.Name = "lbHelp";
            this.lbHelp.Size = new System.Drawing.Size(32, 15);
            this.lbHelp.TabIndex = 11319;
            this.lbHelp.TabStop = true;
            this.lbHelp.Text = "Help";
            this.lbHelp.Visible = false;
            this.lbHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbHelp_LinkClicked_1);
            // 
            // pbClientLogo
            // 
            this.pbClientLogo.Location = new System.Drawing.Point(16, 13);
            this.pbClientLogo.Margin = new System.Windows.Forms.Padding(4);
            this.pbClientLogo.Name = "pbClientLogo";
            this.pbClientLogo.Size = new System.Drawing.Size(151, 51);
            this.pbClientLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbClientLogo.TabIndex = 11321;
            this.pbClientLogo.TabStop = false;
            this.pbClientLogo.Visible = false;
            // 
            // pbLogo
            // 
            this.pbLogo.Location = new System.Drawing.Point(245, 5);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(108, 102);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 11322;
            this.pbLogo.TabStop = false;
            // 
            // LoginWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(598, 398);
            this.ControlBox = false;
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.pbClientLogo);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lbHelp);
            this.Controls.Add(this.lblContactDetails);
            this.Controls.Add(this.pbProductLogo);
            this.Controls.Add(this.lblCopyRights);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLogin);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "LoginWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.LoginWindow_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginWindow_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbProductLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClientLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblContactDetails;
        private System.Windows.Forms.PictureBox pbProductLogo;
        private System.Windows.Forms.Label lblCopyRights;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.LinkLabel lbHelp;
        private System.Windows.Forms.PictureBox pbClientLogo;
        private System.Windows.Forms.PictureBox pbLogo;
    }
}

