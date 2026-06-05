using Microsoft.Reporting.WinForms;
//using Microsoft.Reporting.WinForms;

namespace SPApplication.Report
{
    partial class ViewReportW
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
            this.rVAttendance = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rVAttendance
            // 
            this.rVAttendance.LocalReport.ReportEmbeddedResource = "SPApplication.Report.HRReports.DailyAttendance_RDLC.rdlc";
            this.rVAttendance.Location = new System.Drawing.Point(12, 12);
            this.rVAttendance.Name = "rVAttendance";
            this.rVAttendance.Size = new System.Drawing.Size(1160, 637);
            this.rVAttendance.TabIndex = 0;
            // 
            // ViewReportW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.rVAttendance);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ViewReportW";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Viewer";
            this.Load += new System.EventHandler(this.ViewReportW_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rVAttendance;

        //ReportViewer rVAttendance;
    }
}