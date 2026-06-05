using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLayerUtility;
using System.IO;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
using SPApplication;
using SPApplication.Report;

namespace SPApplication
{
    public partial class ReportList : Form
    {
        public ReportList()
        {
            InitializeComponent();
            objDL.Set_List_Design(lblHeader, btnExit, lbReportList, BusinessResources.LBL_HEADER_REPORTLIST);
        }

        //private const int CS_DropShadow = 0x00020000;
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ClassStyle |= CS_DropShadow;
        //        return cp;
        //    }
        //}

        BusinessLayer objBL = new BusinessLayer();
        ErrorProvider objEP = new ErrorProvider();
        RedundancyLogics objRL = new RedundancyLogics(); DesignLayer objDL = new DesignLayer();
        ToolTip objTT = new ToolTip();

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void PrintAppointmentReport()
        {

        }

        private void Select_Report()
        {
            if (lbReportList.Items.Count > 0)
            {
                //Appointment Report
                //Fee Pending Report
                //Bill Collection Report
                //Expenses Report
                //Profit and Loss Account Report
                //Patient Information Report
                //Provisional Diagnosis Report
                //Birthday and Aniversary Report

                if (lbReportList.Text == "Attendance Report")
                {
                    DailyAndMonthlyAttendanceReport objForm = new DailyAndMonthlyAttendanceReport();
                    objForm.ShowDialog(this);
                }
                else if (lbReportList.Text == "Leave Report")
                {
                    LeaveReport objForm = new LeaveReport();
                    objForm.ShowDialog(this);
                }
                else
                    MessageBox.Show("Enter Valid selection");
            }
        }
        private void lbReportList_Click(object sender, EventArgs e)
        {
            Select_Report();
        }

        private void ReportList_Load(object sender, EventArgs e)
        {
             
        }

        private void lbReportList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Select_Report();
        }

        private void lbReportList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
