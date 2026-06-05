using BusinessLayerUtility;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace SPApplication.Report
{
    public partial class ViewReportW : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        int TableId = 0, Result = 0;
        bool FlagDelete = false;
        bool FlagUpdate = false;

        string ReportName = string.Empty;

        public ViewReportW()
        {
            InitializeComponent();
        }

        public ViewReportW(DataSet ds, string ReportName_Check)
        {
            InitializeComponent();
            ReportName = ReportName_Check;
            FillReport(ds);
        }

        string ReportPath = string.Empty;
        string ReportDS = string.Empty,ReportDS1 = string.Empty,ReportDS_CompanyComman = string.Empty;
        string RDLC_ReportName = string.Empty;
        string ReportConcatPath = string.Empty;

        bool ParameterFlag = false;

        string rpReportName = string.Empty, rpReportDate = string.Empty, rpReportPeriod = string.Empty, rpReportBy = string.Empty;

        private void FillReport(DataSet ds)
        {
            ParameterFlag = false;
            rpReportName = string.Empty; rpReportDate = string.Empty; rpReportPeriod = string.Empty; rpReportBy = string.Empty;

            rpReportName = "Report Name: " + ReportName;
            rpReportDate = "Date: " + DateTime.Now.Date.ToString("dd/MMM/yyyy");
            rpReportPeriod = objQL.ReportPeriod;
            rpReportBy = BusinessLayer.UserName_Full_Static;

            ReportDS_CompanyComman = string.Empty;

            DataSet dsCompanyComman = new DataSet();
            dsCompanyComman = objQL.SP_CompanyProfile_Report();
            
            DataSet ds1 = new DataSet();
            objPC.LocationName="";
            objPC.SearchFlag = false;
            ds1= objQL.SP_LocationMaster_FillGrid();
            
            ReportConcatPath = string.Empty;
            ReportConcatPath = objRL.GetPath_WithoutServer("RdlcPath");

            if (ds.Tables[0].Rows.Count > 0)
            {
                ReportDS_CompanyComman = "dsCompanyComman";
                
                //BusinessResources.REPORT_EMPLOYEE_REPORT
                //BusinessResources.REPORT_NAME_WAGES_REPORT
                //BusinessResources.REPORT_Daily_Attendance_Report_Basic_Report
                //BusinessResources.REPORT_Daily_Attendance_Present_Basic_Reports
                //BusinessResources.REPORT_Daily_Attendance_Absent_Basic_Report
                //BusinessResources.REPORT_Daily_Attendance_Report_Detailed_Report
                //BusinessResources.REPORT_Daily_Attendance_Report_Detailed_Summary_Report
                //BusinessResources.REPORT_NAME_LATE_PUNCH_REPORT
                //BusinessResources.REPORT_NAME_EARLY_PUNCH_REPORT
                //BusinessResources.REPORT_NAME_MISSED_PUNCHED_REPORT

                if (ReportName == BusinessResources.REPORT_EMPLOYEE_REPORT)
                {
                    ParameterFlag = true;
                    ReportDS = "dsEmployee";
                    RDLC_ReportName = "EmployeeReport.rdlc";
                }
                else if (ReportName == BusinessResources.REPORT_NAME_WAGES_REPORT)
                {
                    ParameterFlag = true;
                    ReportDS = "dsWages";
                    ReportDS1 = "LocationDSW";
                    RDLC_ReportName = "MonthlyWagesReport.rdlc";
                }
                else if (ReportName == BusinessResources.REPORT_Daily_Attendance_Report_Basic_Report)
                {
                    ParameterFlag = true;
                    //ReportDS = "dsDailyRecords";
                    ReportDS = "dsAttendanceLocationDepartment";
                    //RDLC_ReportName = "Daily.rdlc";
                    RDLC_ReportName = "AttendanceLocationDepartmentWise.rdlc";
                }
                else if (ReportName == BusinessResources.REPORT_Daily_Attendance_Present_Basic_Reports)
                {
                    ParameterFlag = true;
                    ReportDS = "dsAttendanceLocationDepartment";
                    RDLC_ReportName = "AttendanceLocationDepartmentWise.rdlc";
                }
                else if (ReportName == BusinessResources.REPORT_Daily_Attendance_Absent_Basic_Report)
                {
                    ParameterFlag = true;
                    ReportDS = "dsAttendanceLocationDepartment";
                    RDLC_ReportName = "AttendanceLocationDepartmentWise.rdlc";
                }
                else if (ReportName == BusinessResources.REPORT_NAME_LATE_PUNCH_REPORT)
                {
                    ParameterFlag = true;
                    ReportDS = "dsAttendanceLocationDepartment";
                    RDLC_ReportName = "AttendanceLocationDepartmentWise.rdlc";
                }
                else if (ReportName == BusinessResources.REPORT_NAME_EARLY_PUNCH_REPORT)
                {
                    ParameterFlag = true;
                    ReportDS = "dsAttendanceLocationDepartment";
                    RDLC_ReportName = "AttendanceLocationDepartmentWise.rdlc";
                }
                else if (ReportName == BusinessResources.REPORT_NAME_MISSED_PUNCHED_REPORT)
                {
                    ParameterFlag = true;
                    ReportDS = "dsAttendanceLocationDepartment";
                    RDLC_ReportName = "AttendanceLocationDepartmentWise.rdlc";
                }
                else if (ReportName == BusinessResources.REPORT_Daily_Attendance_Report_Detailed_Report)
                {
                    ParameterFlag = true;
                    ReportDS = "dsDailyRecords";
                    RDLC_ReportName = "Daily.rdlc";
                }
                else if (ReportName == BusinessResources.REPORT_Daily_Attendance_Report_Detailed_Summary_Report)
                {
                    ParameterFlag = true;
                    ReportDS = "dsDailyRecords";
                    RDLC_ReportName = "Daily.rdlc";
                }
                else if (ReportName == BusinessResources.REPORT_Department_Summary_Report)
                {
                    ParameterFlag = true;
                    ReportDS = "dsDepartmentSummaryReport";
                    RDLC_ReportName = "DepartmentSummaryReport.rdlc";
                }
                else if (ReportName == BusinessResources.REPORT_LEAVEREPORT)
                {
                    ParameterFlag = true;
                    ReportDS = "dsLeaveApplication";
                    RDLC_ReportName = "LeaveReport.rdlc";
                }
                else if (ReportName == BusinessResources.REPORT_COMPOFF)
                {
                    ParameterFlag = true;
                    ReportDS = "dsCompOff";
                    RDLC_ReportName = "CompOffReport.rdlc";
                }
                else if (ReportName == BusinessResources.REPORT_PUNCHMONITOR)
                {
                    ParameterFlag = true;
                    ReportDS = "dsPunchRecords";
                    RDLC_ReportName = "PunchRecordReport.rdlc";
                }
                else if (ReportName == BusinessResources.REPORT_Department_Wise_Designation_Wise_Count)
                {
                    ParameterFlag = true;
                    ReportDS = "dsDepartmentDesignationCount";
                    RDLC_ReportName = "DepartmentWiseDesignation.rdlc";
                }
                else if (ReportName == BusinessResources.REPORT_Monthly_Attendance_Basic_Report)
                {
                    ParameterFlag = true;
                    ReportDS = "dsAttendanceRecord";
                    RDLC_ReportName = "TestSubReport.rdlc";
                }
                else if (ReportName == "MEMO")
                {
                    ParameterFlag = false;
                    ReportDS = "dsMemo";
                    RDLC_ReportName = "MemoReport.rdlc";
                }
                else
                {

                }

                ReportConcatPath += RDLC_ReportName;

                // string exeFolder = Application.StartupPath;
                //string reportPath = Path.Combine(exeFolder, @"D:\BitBucketProjects\Malas Fruit\SPApplication\SPApplication\Report\HRReports\MonthlyWagesReport.rdlc");

                rVAttendance.Visible = true;
               // rVAttendance.ProcessingMode = ProcessingMode.Local;
                //this.rVAttendance.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                this.rVAttendance.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                rVAttendance.LocalReport.ReportPath = ReportConcatPath;
                //this.rVAttendance.LocalReport.ReportEmbeddedResource = ReportConcatPath;

                ReportDataSource rds = new ReportDataSource(ReportDS, ds.Tables[0]);
                ReportDataSource rds1 = new ReportDataSource(ReportDS1, ds1.Tables[0]);
                ReportDataSource rds2 = new ReportDataSource(ReportDS_CompanyComman, dsCompanyComman.Tables[0]);
                //ReportDataSource rds2 = new ReportDataSource(ReportDS1, ds1.Tables[0]);

                rVAttendance.LocalReport.DataSources.Clear();

                //rpReportName = "Report Name: "+ReportName;
                //rpReportDate = "Date: " + DateTime.Now.Date.ToString("dd/MMM/yyyy");
                //rpReportPeriod = objQL.ReportPeriod;
                //rpReportBy =
               // ParameterFlag = false;

                if (ParameterFlag)
                {
                    ReportParameter[] parameters = new ReportParameter[4];
                    parameters[0] = new ReportParameter("rpReportName", rpReportName);
                    parameters[1] = new ReportParameter("rpReportDate", rpReportDate);
                    parameters[2] = new ReportParameter("rpReportPeriod", rpReportPeriod);
                    parameters[3] = new ReportParameter("rpReportBy", rpReportBy);

                    //parameters[0] = new ReportParameter("rpReportName", "Daily Attendance Report");
                    ////parameters[x] = new ReportParameter("namex", valuex);
                    //An error occurred during local report processing.

                    rVAttendance.LocalReport.SetParameters(parameters);
                }

                if (ReportName == "MEMO")
                {
                    ReportParameter[] parameters = new ReportParameter[3];
                    parameters[0] = new ReportParameter("rpReportName", rpReportName);
                    //parameters[1] = new ReportParameter("rpReportDate", rpReportDate);
                    parameters[1] = new ReportParameter("rpReportBy", rpReportBy);
                    parameters[2] = new ReportParameter("rpMemoCount", "1");
                    rVAttendance.LocalReport.SetParameters(parameters);
                }

                //ReportParameter[] parameters = new ReportParameter[1];
                //parameters[0] = new ReportParameter("rpReportName", rpReportName);
                //rVAttendance.LocalReport.SetParameters(parameters);

                rVAttendance.LocalReport.DataSources.Add(rds);
                rVAttendance.LocalReport.DataSources.Add(rds1);

                rVAttendance.LocalReport.DataSources.Add(rds2);
                //rVAttendance.LocalReport.DataSources.Add(rds2);

              
                rVAttendance.LocalReport.Refresh();
                rVAttendance.RefreshReport();
                
                //string exeFolder = Application.StartupPath;
                //string reportPath = Path.Combine(exeFolder, @"D:\BitBucketProjects\Malas Fruit\SPApplication\SPApplication\Report\HRReports\DailyAttendance_RDLC.rdlc");

                //rVAttendance.Visible = true;
                //rVAttendance.ProcessingMode = ProcessingMode.Local;
                //rVAttendance.LocalReport.ReportPath = reportPath;
                //ReportDataSource rds = new ReportDataSource("dsAttendance", ds.Tables[0]);
                //rVAttendance.LocalReport.DataSources.Clear();
                //ReportParameter[] parameters = new ReportParameter[1];
                //parameters[0] = new ReportParameter("rpReportName", "Daily Attendance Report");
                ////parameters[x] = new ReportParameter("namex", valuex);
        
                //rVAttendance.LocalReport.SetParameters(parameters);
                //rVAttendance.LocalReport.DataSources.Add(rds);
                //rVAttendance.LocalReport.Refresh();
                //rVAttendance.RefreshReport();
            }
        }

        private void ViewReportW_Load(object sender, EventArgs e)
        {
            this.Text = ReportName.ToString();
            //this.rVAttendance.RefreshReport();
        }

        private void Report()
        {

        }
    }
}
