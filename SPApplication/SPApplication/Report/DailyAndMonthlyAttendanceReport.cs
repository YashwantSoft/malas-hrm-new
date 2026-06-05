using BusinessLayerUtility;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPApplication.Report
{
    public partial class DailyAndMonthlyAttendanceReport : Form
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

        string ColumnNames_V = string.Empty, TableNames_V = string.Empty, OrderBy_V = string.Empty, GroupBy_V = string.Empty;

        public DailyAndMonthlyAttendanceReport()
        {
            InitializeComponent();
            objDL.Set_Report_Design(this, lblHeader, btnView, btnReport, btnClear, btnExit, BusinessResources.LBL_DAILY_ATTENDANCEREPORT);
            objRL.Fill_Status_CheckedListBox(clbStatus);
            //objRL.Fill_Department_CheckedListBox(clbDepartment);
            //objRL.Fill_Location_CheckedListBox(clbCompany);
            //objRL.Fill_Shifts_CheckedListBox(clbShift);
            objRL.Fill_Contractor_CheckedListBox(clbContractor);
            //objQL.Fill_Master_ComboBox(cmbEmployeeCategory, "categories");
            //objQL.Fill_Master_ComboBox(cmbEmployeeDesignation, "designationmaster");
            //objQL.Fill_Master_ComboBox(cmbEmployeeLocation, "locationmaster");
            //objQL.Fill_Master_ComboBox(cmbEmployementType, "employementtypemaster");
            Fill_ReportName();
            FillLocation();

            objQL.TuncateTables_Report();
        }

        int SearchId = 0;
        private void FillLocation()
        {
            SearchId = BusinessLayer.EmployeeLoginId_Static;

            if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR || BusinessLayer.UserType == BusinessResources.USER_TYPE_HROFFICER)
                objQL.WhereClause_V = "";
            else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER)
                objQL.WhereClause_V = " and lwd.PlantHeadId=" + SearchId + " ";
            else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_SENIOROFFICER)
                objQL.WhereClause_V = " and lwd.InchargeId=" + SearchId + " ";
            //else if (BusinessLayer.DesignationCategory == BusinessResources.USER_TYPE_OFFICER || BusinessLayer.DesignationCategory == BusinessResources.USER_TYPE_SUPERVISOR)
            //    FlagCheck = true;
            else
            {
                objRL.ShowMessage(38, 4);
                return;
            }

            //if (BusinessLayer.UserType == BusinessResources.USER_TYPE_INCHARGE)
            //    objQL.WhereClause_V = " and lwd.InchargeId=" + SearchId + " ";
            //else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER)
            //    objQL.WhereClause_V = " and lwd.PlantHeadId=" + SearchId + " ";
            //else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMIN)
            //    objQL.WhereClause_V = "";
            //else
            //{
            //    objRL.ShowMessage(38, 4);
            //    return;
            //}

            objQL.Fill_Location_By_EmployeeId(cmbLocation);

            //if (BusinessLayer.UserType == BusinessResources.USER_TYPE_INCHARGE)
            //{
            //    cmbLocation.Text = BusinessLayer.LocationName;
            //    FillDepartment();
            //    cmbLocation.Enabled = false;
            //    cmbDepartment.Text = BusinessLayer.Department;
            //}
            //else
            //{
            //    cmbLocation.Enabled = true;
            //    cmbLocation.SelectedIndex = -1;
            //    cmbDepartment.SelectedIndex = -1;
            //    FillGrid_AttendanceRecordMaster();
            //}
        }

        private void FillDepartment()
        {
            if (cmbLocation.SelectedIndex > -1)
            {
                LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
                //objRL.Fill_Department_CheckedListBox_By_Location(clbDepartment, LocationId);
                objPC.LocationId = LocationId;
                Fill_Department_By_GroupId();
            }
        }

        private void Fill_Department_By_GroupId()
        {
            DataSet ds = new DataSet();
            //objPC.LocationId = TableId;
            ds = objQL.SP_LocationWiseDepartment_Get_Department_By_LocationId();
            if (ds.Tables[0].Rows.Count > 0)
            {
                clbDepartment.DataSource = ds.Tables[0];
                clbDepartment.DisplayMember = "Department";
                clbDepartment.ValueMember = "DepartmentId";
            }
        }

        private void Fill_ReportName()
        {
            cmbReportName.Items.Clear();
            cmbReportName.Items.Add(BusinessResources.REPORT_EMPLOYEE_REPORT);
            cmbReportName.Items.Add(BusinessResources.REPORT_Monthly_Attendance_Basic_Report);
            cmbReportName.Items.Add(BusinessResources.REPORT_NAME_WAGES_REPORT);
            cmbReportName.Items.Add(BusinessResources.REPORT_Daily_Attendance_Report_Basic_Report);
            //cmbReportName.Items.Add(BusinessResources.REPORT_Daily_Attendance_Present_Basic_Reports);
            //cmbReportName.Items.Add(BusinessResources.REPORT_Daily_Attendance_Absent_Basic_Report);
            //cmbReportName.Items.Add(BusinessResources.REPORT_Daily_Attendance_Report_Detailed_Report);
            cmbReportName.Items.Add(BusinessResources.REPORT_Daily_Attendance_Report_Detailed_Summary_Report);
            cmbReportName.Items.Add(BusinessResources.REPORT_NAME_LATE_PUNCH_REPORT);
            cmbReportName.Items.Add(BusinessResources.REPORT_NAME_EARLY_PUNCH_REPORT);
            //cmbReportName.Items.Add(BusinessResources.REPORT_NAME_MISSED_PUNCHED_REPORT);
            //cmbReportName.Items.Add(BusinessResources.REPORT_Department_Summary_Report);
            //cmbReportName.Items.Add(BusinessResources.REPORT_Yearly_Summary_Report);
            cmbReportName.Items.Add(BusinessResources.REPORT_LEAVEREPORT);
            //cmbReportName.Items.Add(BusinessResources.REPORT_PUNCHMONITOR);
            //cmbReportName.Items.Add(BusinessResources.REPORT_Department_Wise_Designation_Wise_Count);
            //cmbReportName.Items.Add(BusinessResources.REPORT_Monthly_Attendance_Basic_Report);
        }

        private void Fill_ReportName_Old()
        {
            cmbReportName.Items.Clear();
            cmbReportName.Items.Add(BusinessResources.REPORT_EMPLOYEE_REPORT);
            cmbReportName.Items.Add(BusinessResources.REPORT_Monthly_Attendance_Basic_Report);
            cmbReportName.Items.Add(BusinessResources.REPORT_NAME_WAGES_REPORT);
            cmbReportName.Items.Add(BusinessResources.REPORT_Daily_Attendance_Report_Basic_Report);
            cmbReportName.Items.Add(BusinessResources.REPORT_Daily_Attendance_Present_Basic_Reports);
            cmbReportName.Items.Add(BusinessResources.REPORT_Daily_Attendance_Absent_Basic_Report);
            cmbReportName.Items.Add(BusinessResources.REPORT_Daily_Attendance_Report_Detailed_Report);
            cmbReportName.Items.Add(BusinessResources.REPORT_Daily_Attendance_Report_Detailed_Summary_Report);
            cmbReportName.Items.Add(BusinessResources.REPORT_NAME_LATE_PUNCH_REPORT);
            cmbReportName.Items.Add(BusinessResources.REPORT_NAME_EARLY_PUNCH_REPORT);
            cmbReportName.Items.Add(BusinessResources.REPORT_NAME_MISSED_PUNCHED_REPORT);
            cmbReportName.Items.Add(BusinessResources.REPORT_Department_Summary_Report);
            cmbReportName.Items.Add(BusinessResources.REPORT_Yearly_Summary_Report);
            cmbReportName.Items.Add(BusinessResources.REPORT_LEAVEREPORT);
            cmbReportName.Items.Add(BusinessResources.REPORT_PUNCHMONITOR);
            cmbReportName.Items.Add(BusinessResources.REPORT_Department_Wise_Designation_Wise_Count);
            //cmbReportName.Items.Add(BusinessResources.REPORT_Monthly_Attendance_Basic_Report);
        }

        private void DailyAttendanceReport_Load(object sender, EventArgs e)
        {
            ClearAll();
        }

        string RType = string.Empty;

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        int MNumber = 0;
        int YearC = 0;
        int Dt = 0;

        private void btnView_Click(object sender, EventArgs e)
        {
            ReportDataView objForm = new ReportDataView();
            objForm.ShowDialog(this);
        }

        private void ClearAll()
        {
            cmbDatePeriodType.SelectedIndex = -1;
            cmbMonth.SelectedIndex = -1;
            cmbYear.SelectedIndex = -1;
            cmbYear.Text = DateTime.Now.Year.ToString();
            cmbMonth.Text = Convert.ToString(objRL.GetMonthName(DateTime.Now.Month));
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearEmployeeAll()
        {
            EmployeeId = 0;
            rtbEmployeeDetails.Text = "";
            lbEmployee.DataSource = null;
            txtSearchEmployeeCode.Text = "";
            txtSearchEmployeeName.Text = "";
            //cmbEmployeeCategory.SelectedIndex = -1;
            //cmbEmployeeDesignation.SelectedIndex = -1;
            //cmbEmployeeLocation.SelectedIndex = -1;
            //cmbEmployementType.SelectedIndex = -1;
            Type_Visible(false);
            Date_Visible(false);

        }

        private void cbEmployee_CheckedChanged(object sender, EventArgs e)
        {
            //if (cbEmployee.Checked)
            //{
            //    gbEmployee.Enabled = true;
            //    cbSelectAllEmployee.Checked = true;
            //}
            //else
            //{
            //    cbSelectAllEmployee.Checked = false;
            //    ClearEmployee();
            //}
        }

        private void cbSelectAllEmployee_CheckedChanged(object sender, EventArgs e)
        {
            //if (cbSelectAllEmployee.Checked)
            //    objQL.Fill_Employee_ListBox(lbEmployee, txtSearchEmployeeName.Text, "All");
            //else
            //{
            //    rtbEmployeeDetails.Text = "";
            //    lbEmployee.DataSource = null;
            //}
        }

        int clbID = 0;

        string ContractorIn = string.Empty;
        string StatusIn = string.Empty;
        string DepartmentIn = string.Empty;
        string CompanyIn = string.Empty;
        string ShiftIn = string.Empty;
        string EmployeeIn = string.Empty;

        string EmployeeTable = " Employees E inner join ";
        string ContractorTable = " contractormaster CM on CM.ContractorId=E.ContractorId inner join ";
        string StatusQueryTable = string.Empty;
        string DepartmentTable = " departmentmaster D on D.DepartmentId=E.DepartmentId inner join ";
        string LocationTable = " LocationMaster L on L.LocationId=E.LocationId inner join ";
        string ShiftTable = string.Empty;
        string DesignationTable = " designationmaster DM on DM.DesignationId=E.DesignationId inner join ";
        string EmploymentMaster = " employementtypemaster ETM on ETM.EmployementTypeId=E.EmployementTypeId inner join ";
        string CategoryTable = " Categories CT on CT.CategoryId=E.CategoryId ";


        string INConcat = string.Empty;
        string statusname_C = string.Empty;

        private void GetStatus_Report()
        {
            INConcat = string.Empty;

            foreach (object itemChecked in clbStatus.CheckedItems)
            {
                DataRowView castedItem = itemChecked as DataRowView;
                string statusname = Convert.ToString(castedItem[2]);
                statusname_C = statusname;
                INConcat += @"'" + statusname_C.Trim() + "',";
            }

            if (INConcat.Length > 0)
            {
                INConcat = INConcat.Remove(INConcat.Length - 1);

                string concat = " IN (" + INConcat + ")";
                StatusIn = " and AMD.Status" + concat;
            }
        }

        private void Set_Status_Present_Absent(string TypePA)
        {
            if (!string.IsNullOrEmpty(TypePA))
            {

                for (int i = 0; i < clbStatus.Items.Count; i++)
                {
                    //clbStatus.SelectedItems[i] = false;
                    clbStatus.SetItemChecked(i, false);
                    
                }

                cbStatus.Checked = true;

                //foreach (object itemChecked in clbStatus.Items)
                //{
                //    //  objBL.Query = "select StatusId,Status,Description from StatusMaster where CancelTag=0";
                //    DataRowView castedItem = itemChecked as DataRowView;
                //    string comapnyName = Convert.ToString(castedItem["Description"]);
                //    //int? id = castedItem["StatusId"];

                //    if (comapnyName == TypePA)
                //    {

                        
                //        //int index = clbStatus.Items..IndexOf(TypePA);
                //        //clbStatus.SetItemChecked(
                //        clbStatus.SetItemChecked(index, true);
                //    }
                //}


                for (int i = 0; i < clbStatus.Items.Count; i++)
                {
                    int I = clbStatus.FindString(TypePA);
                    clbStatus.SetItemChecked(I, true);
                    break;
                    //string cItem = clbStatus.Text[i].ToString();
                    //if (cItem == TypePA)
                    //{
                    //    clbStatus.SetItemChecked(i, true);
                    //    break;
                    //}
                }

               
            }
        }

        private void GetID_CheckListBox_Report(CheckedListBox clb, string TableType)
        {
            INConcat = string.Empty;
            foreach (object itemChecked in clb.CheckedItems)
            {
                DataRowView castedItem = itemChecked as DataRowView;

                if (TableType == "status")
                {
                    string sName = Convert.ToString(castedItem[1]);
                    INConcat += "'" + sName.ToString() + "',";
                }
                else
                {
                    int? id;

                    if (TableType == "contractormaster")
                        id = Convert.ToInt32(castedItem[0]);
                    else
                        id = Convert.ToInt32(castedItem[1]);

                    clbID = (int)id;
                    INConcat += clbID.ToString() + ",";
                }
            }

            if (!string.IsNullOrEmpty(Convert.ToString(INConcat)))
            {
                INConcat = INConcat.Remove(INConcat.Length - 1);

                string concat = " IN (" + INConcat + ")";

                //if(TableType == "status")
                //    concat = " IN (" + INConcat + ")";
                //else
                //    concat = " IN (" + INConcat + ")";

                if (TableType == "contractormaster")
                    ContractorIn = " E.ContractorId" + concat;
                else if (TableType == "departmentmaster")
                    DepartmentIn = " E.DepartmentId" + concat;
                else if (TableType == "locationmaster")
                    CompanyIn = " E.LocationId" + concat;
                else if (TableType == "shifts")
                    ShiftIn = " shift.ShiftId" + concat;
                else if (TableType == "status")
                    StatusIn = " AMD.Status" + concat;
                else
                {

                }
            }
        }
        
        int AYear = 0, AMonth = 0;
        string AMonthColumn = string.Empty;
        string AYearColumn = string.Empty;
        string DateColumn = string.Empty;
        string StatusWorkingResigned = string.Empty;

        string ReportPeriod = string.Empty;
        string LocationIdS = string.Empty;

        private void Add_Query()
        {
            //ReportPeriod = string.Empty;
            ColumnNames_V = string.Empty; 
            TableNames_V = string.Empty; 
            OrderBy_V = string.Empty; 
            GroupBy_V = string.Empty;
            //OrderBy
            ContractorIn = string.Empty;
            StatusIn = string.Empty;
            DepartmentIn = string.Empty;
            CompanyIn = string.Empty;
            ShiftIn = string.Empty;
            EmployeeIn = string.Empty;
            AMonthColumn = string.Empty;
            AYearColumn = string.Empty;
            DateColumn = string.Empty;
            StatusWorkingResigned = string.Empty;

            //GetStatus_Report();
            if (cbContractor.Checked)
                GetID_CheckListBox_Report(clbContractor, "contractormaster");
            if (!cbSelectAllDepartment.Checked)
                GetID_CheckListBox_Report(clbDepartment, "departmentmaster");
            //if (cbCompany.Checked)
            //    GetID_CheckListBox_Report(clbCompany, "locationmaster");
            //if (cbShift.Checked)
            //    GetID_CheckListBox_Report(clbShift, "shifts");
            if (cbStatus.Checked)
                GetID_CheckListBox_Report(clbStatus, "status");
           
            if (EmployeeId != 0)
                EmployeeIn = " E.EmployeeCode = " + EmployeeId + "";

            if (cmbLocation.SelectedIndex >-1)
                LocationIdS = " E.LocationId=" + cmbLocation.SelectedValue + "";

            if (cmbDatePeriodType.SelectedIndex > -1)
            {
                if (cmbDatePeriodType.Text == "Monthly" && cmbMonth.SelectedIndex > -1 && cmbYear.SelectedIndex > -1)
                {
                    if (cmbMonth.SelectedIndex > -1)
                    {
                        AMonth = objRL.GetMonthNumber(cmbMonth.Text);
                        AMonthColumn = " AMonth=" + AMonth;
                    }

                    if (cmbYear.SelectedIndex > -1)
                    {
                        AYear = Convert.ToInt32(cmbYear.Text);
                        AYearColumn = " and AYear=" + AYear;
                    }

                    if(cmbReportName.Text == BusinessResources.REPORT_NAME_WAGES_REPORT)
                        DateColumn = AMonthColumn + AYearColumn;
                    else
                        DateColumn = " monthname(ARM.AttendanceDate)='" + cmbMonth.Text + "' and YEAR(ARM.AttendanceDate)='" + cmbYear.Text + "' ";

                    if (cmbReportName.Text == BusinessResources.REPORT_LEAVEREPORT)
                        DateColumn = " monthname(LA.EntryDate)='" + cmbMonth.Text + "' and YEAR(LA.EntryDate)='" + cmbYear.Text + "' ";

                    ReportPeriod = "Report Period Month Wise Month-" + cmbMonth.Text + " Year-" + cmbYear.Text;
                }
                else
                {
                    DateColumn = " ARM.AttendanceDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' ";

                    if (cmbReportName.Text == BusinessResources.REPORT_LEAVEREPORT)
                        DateColumn = " LA.LeaveStatus='Completed' and LA.FromDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' ";

                    ReportPeriod = "Report Period Date Wise From Date-" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATDDMMMYYYY) + " To Date-" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATDDMMMYYYY);
                }
            }

            if (cmbStatusEmployee.SelectedIndex > -1)
                StatusWorkingResigned = " E.Status='" + cmbStatusEmployee.Text + "' ";
            else
                StatusWorkingResigned = "";

            if (!string.IsNullOrEmpty(LocationIdS))
                LocationIdS += " and ";
            if (!string.IsNullOrEmpty(EmployeeIn))
                EmployeeIn +=" and ";
            if(!string.IsNullOrEmpty(ContractorIn))
                ContractorIn +=" and ";
            if(!string.IsNullOrEmpty(StatusIn))
                StatusIn +=" and ";
            if(!string.IsNullOrEmpty(DepartmentIn))
                DepartmentIn+=" and ";
            if(!string.IsNullOrEmpty(ShiftIn))
                ShiftIn += " and ";
            if(!string.IsNullOrEmpty(CompanyIn))
                CompanyIn+= " and ";
            if(!string.IsNullOrEmpty(AMonthColumn))
                AMonthColumn += " and ";
            if (!string.IsNullOrEmpty(DateColumn))
                DateColumn += " and ";
            if(!string.IsNullOrEmpty(StatusWorkingResigned))
                StatusWorkingResigned+= " and ";

            //WhereClause = " where " + DateColumn + EmployeeIn + ContractorIn + StatusIn + DepartmentIn + CompanyIn + ShiftIn + StatusWorkingResigned +" ";

            WhereClause = " where " + DateColumn + EmployeeIn + ContractorIn + StatusIn + DepartmentIn + LocationIdS + ShiftIn + StatusWorkingResigned + " ";
        }


        private void GenerateQuery()
        {
            DataSet ds = new DataSet();

            Add_Query();
            if (RType == "Daily")
            {
                MainQuery = objQL.ColumnNames_Report + objQL.TableNames_Report + WhereClause;

                //ColumnNames_V 	text,
                //TableNames_V 	text,
                //OrderBy_V		text,
                //GroupBy_V	
                objQL.WhereClause_V = WhereClause;
                objQL.OrderBy_V = "";
                objQL.GroupBy_V = "";
                ds = objQL.SP_Attendance_Report_Query();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewReportW objForm = new ViewReportW(ds, "");
                    objForm.Show();
                }
            }
            else
            {
                int MNumber = 0;
                int YearC = 0;
                int Dt = 0;
                int MonthDays = 0;

                MNumber = objRL.GetMonthNumber(Convert.ToString(cmbMonth.Text));
                YearC = Convert.ToInt32(cmbYear.Text);

                MonthDays = DateTime.DaysInMonth(YearC, MNumber);

                objQL.ColumnNames_Report = objQL.Employees_ColumnNames;
                objQL.TableNames_Report = objQL.Employees_Join_TableNames_Report;
                objQL.WhereClause_V = WhereClause;
                objQL.OrderBy_V = " order by E.EmployeeName asc";
                objQL.GroupBy_V = " ";
                ds = objQL.SP_Attendance_Report_Query();


                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        int EID = 0;
                        EID = Convert.ToInt32(ds.Tables[0].Rows[i]["EmployeeId"].ToString());
                        objPC.EmployeeName = ds.Tables[0].Rows[i]["Employee Name"].ToString();

                        TotalDuration = 0;
                        TotalOT = 0;
                        TotalAbsent = 0;
                        TotalDays = 0;
                        TotalLate = 0;
                        TotalPresent = 0;
                        int ReportTableId = 0;

                        DataSet dsID = new DataSet();
                        objPC.MonthNumber = MNumber;
                        objPC.MonthYear = YearC;
                        objPC.EmployeeId = EID;
                        dsID = objQL.SP_ReportData_Insert();
                        if (dsID.Tables[0].Rows.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(dsID.Tables[0].Rows[0][0].ToString())))
                                ReportTableId = Convert.ToInt32(dsID.Tables[0].Rows[0][0].ToString());
                            Dt = 1;
                            string SetDate = YearC + "/" + MNumber + "/" + Dt.ToString();

                            DataSet dsMonth = new DataSet();
                            objPC.AttendanceDate = Convert.ToDateTime(SetDate);
                            objPC.EmployeeId = EID;

                            dsMonth = objQL.SP_AttendanceLog__By_EmployeeId_Date();


                            if (dsMonth.Tables[0].Rows.Count > 0)
                            {
                                //ReportTableId = 0;
                                //Insert Report Data


                                for (int k = 0; k < dsMonth.Tables[0].Rows.Count; k++)
                                {
                                    DateTime dtAttendanceDate;
                                    dtAttendanceDate = Convert.ToDateTime(dsMonth.Tables[0].Rows[k]["AttendanceDate"].ToString());

                                    int ATDate = Convert.ToInt32(dtAttendanceDate.Date.Day);

                                    //'½P'
                                    //'WOP'
                                    //'WO'
                                    //'P'
                                    //'A'

                                    In_DB = string.Empty; Out_DB = string.Empty; Duration_DB = 0; Status_DB = string.Empty; OT_DB = 0; Lt_DB = 0;
                                    PresentDays = 0; AbsentDays = 0;

                                    if (!string.IsNullOrEmpty(Convert.ToString(dsMonth.Tables[0].Rows[k]["StatusCode"].ToString())))
                                        Status_DB = Convert.ToString(dsMonth.Tables[0].Rows[k]["StatusCode"].ToString());

                                    if (Status_DB == "'½P")
                                    {
                                        Duration_DB = 0.5;
                                        PresentDays = 0.5;
                                    }
                                    else if (Status_DB == "WOP" || Status_DB == "P")
                                    {
                                        PresentDays = 1;
                                    }
                                    else if (Status_DB == "WO") // || Status_DB == "'½P")
                                    {
                                        In_DB = "0";
                                        Out_DB = "0";
                                        Duration_DB = 0;
                                        PresentDays = 1;
                                    }
                                    else if (Status_DB == "A") // || Status_DB == "'½P")
                                    {
                                        In_DB = "0";
                                        Out_DB = "0";
                                        Duration_DB = 0;
                                        PresentDays = 0;
                                        AbsentDays = 1;
                                    }
                                    else
                                    {

                                    }

                                    if (!string.IsNullOrEmpty(Convert.ToString(dsMonth.Tables[0].Rows[k]["InTime"].ToString())))
                                        In_DB = Convert.ToString(dsMonth.Tables[0].Rows[k]["InTime"].ToString());
                                    if (!string.IsNullOrEmpty(Convert.ToString(dsMonth.Tables[0].Rows[k]["OutTime"].ToString())))
                                        Out_DB = Convert.ToString(dsMonth.Tables[0].Rows[k]["OutTime"].ToString());
                                    if (!string.IsNullOrEmpty(Convert.ToString(dsMonth.Tables[0].Rows[k]["Duration"].ToString())))
                                        Duration_DB = Convert.ToDouble(dsMonth.Tables[0].Rows[k]["Duration"].ToString());

                                    if (!string.IsNullOrEmpty(Convert.ToString(dsMonth.Tables[0].Rows[k]["LateBy"].ToString())))
                                    {
                                        Lt_DB = Convert.ToDouble(dsMonth.Tables[0].Rows[k]["LateBy"].ToString());
                                        if (Lt_DB > 0)
                                            TotalLate += 1;
                                    }

                                    if (!string.IsNullOrEmpty(Convert.ToString(dsMonth.Tables[0].Rows[k]["OverTime"].ToString())))
                                        OT_DB = Convert.ToDouble(dsMonth.Tables[0].Rows[k]["OverTime"].ToString());

                                    //Out_DB = string.Empty; 
                                    //Duration_DB = 0;
                                    //Status_DB = string.Empty; 
                                    //OT_DB = 0; 
                                    //Lt_DB = 0;

                                    TotalDuration += Duration_DB;
                                    TotalOT += OT_DB;
                                    TotalAbsent += AbsentDays;
                                    TotalPresent += PresentDays;

                                    string UpdateColumns = string.Empty;

                                    C_In1 = "In" + ATDate + "='" + In_DB + "',";
                                    C_Out1 = "Out" + ATDate + "='" + Out_DB + "',";
                                    C_Duration1 = "Duration" + ATDate + "='" + Duration_DB.ToString() + "',";
                                    C_Status1 = "Status" + ATDate + "='" + Status_DB + "',";
                                    C_OT1 = "OT" + ATDate + "='" + OT_DB.ToString() + "',";
                                    C_LT1 = "LT" + ATDate + "='" + Lt_DB + "'  ";

                                    UpdateColumns = C_In1 + C_Out1 + C_Duration1 + C_Status1 + C_OT1 + C_LT1;

                                    objPC.ColumnNames = "update reportdata set " + UpdateColumns + " where Id=" + ReportTableId + " and CancelTag=0";
                                    Result = objQL.SP_ReportData_Insert_Update();
                                    //ReportTableId
                                }
                                objPC.ReportTableId = ReportTableId;
                                objPC.TotalDays = MonthDays.ToString();
                                objPC.TotalPresent = TotalPresent.ToString();
                                objPC.TotalAbsent = TotalAbsent.ToString();
                                objPC.TotalDuration = TotalDuration.ToString();
                                objPC.TotalOT = TotalOT.ToString();
                                objPC.TotalLate = TotalLate.ToString();
                                Result = objQL.SP_ReportData_Update_Total_Values();
                            }
                        }
                    }
                }
            }
        }

        string C_MonthNumber = string.Empty, C_MonthYear = string.Empty, C_EmpId = string.Empty, C_In1 = string.Empty, C_Out1 = string.Empty, C_Duration1 = string.Empty, C_Status1 = string.Empty, C_OT1 = string.Empty, C_LT1 = string.Empty;

        double Duration_DB = 0, OT_DB = 0, TotalDuration = 0, TotalDays = 0, TotalPresent = 0, TotalAbsent = 0, TotalOT = 0, TotalLate = 0, PresentDays = 0, Lt_DB = 0, AbsentDays = 0;
        string In_DB = string.Empty, Out_DB = string.Empty, Status_DB = string.Empty;

        string MainQuery = string.Empty;
        string WhereClause = string.Empty;

        private void GetReport()
        {
            ColumnNames_V = string.Empty; TableNames_V = string.Empty; OrderBy_V = string.Empty; GroupBy_V = string.Empty;

            MNumber = objRL.GetMonthNumber(Convert.ToString("August"));
            YearC = Convert.ToInt32(2022);
            Dt = 01;

            string SetDate = YearC + "/" + MNumber + "/" + Dt.ToString();

            DataSet ds = new DataSet();
            objPC.AttendanceDate = Convert.ToDateTime(SetDate);
            ds = objQL.SP_MonthlyAttendanceReport();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ViewReportW objForm = new ViewReportW(ds, "");
                objForm.Show();
            }

            //New Query
            //SET @s = CONCAT('select ', v_ColumnNames, ' from ' , v_TableNames,v_OrderBy,v_GroupBy);  
            //PREPARE stmt FROM @s; 
            //EXECUTE stmt;

            ds = objQL.SP_Report_Query();

            if (ds.Tables[0].Rows.Count > 0)
            {
                ViewReportW objForm = new ViewReportW(ds, "");
                objForm.Show();
            }
        }

        string ReportName = string.Empty;

        private bool Validation()
        {
            bool FlagReturn = false;
            objEP.Clear();

            if (cmbReportName.SelectedIndex == -1)
            {
                cmbReportName.Focus();
                objEP.SetError(cmbReportName, "Select Report Name");
                FlagReturn = true;
            }
            else if (cmbReportType.SelectedIndex == -1)
            {
                cmbReportType.Focus();
                objEP.SetError(cmbReportType, "Select ReportT ype");
                FlagReturn = true;
            }
            else
                FlagReturn = false;

            if (!FlagReturn)
            {
                if (cmbReportType.Text == "Employee Wise")
                {
                    if (EmployeeId == 0)
                    {
                        lbEmployee.Focus();
                        objEP.SetError(lbEmployee, "Select Employee");
                        FlagReturn = true;
                    }
                    else
                        FlagReturn = false;
                }
                else if (cmbReportType.Text == "Location And Department Wise")
                {
                    if (cmbLocation.SelectedIndex == -1)
                    {
                        cmbLocation.Focus();
                        objEP.SetError(cmbLocation, "Select Location");
                        FlagReturn = true;
                    }
                    else if (clbDepartment.CheckedItems.Count == 0)
                    {
                        clbDepartment.Focus();
                        objEP.SetError(clbDepartment, "Select Department");
                        FlagReturn = true;
                    }
                    else
                        FlagReturn = false;
                }
                else
                    FlagReturn = false;
            }

            if (!FlagReturn)
            {
                if (ReportName == BusinessResources.REPORT_Department_Wise_Designation_Wise_Count)
                    FlagReturn = false;
                else
                {
                    //if (!FlagReturn)
                    //{
                    //    if (cmbLocation.SelectedIndex == -1)
                    //    {
                    //        cmbLocation.Focus();
                    //        objEP.SetError(cmbLocation, "Select Location");
                    //        FlagReturn = true;
                    //    }
                    //    else
                    //        FlagReturn = false;
                    //}
                    if (cmbReportName.Text != BusinessResources.REPORT_EMPLOYEE_REPORT)
                    {
                        if (!FlagReturn)
                        {
                            if (cmbDatePeriodType.SelectedIndex == -1)
                            {
                                cmbDatePeriodType.Focus();
                                objEP.SetError(cmbDatePeriodType, "Select Report Type");
                                FlagReturn = true;
                            }
                            else
                                FlagReturn = false;
                        }
                        if (!FlagReturn)
                        {
                            if (cmbDatePeriodType.Text == "Monthly")
                            {
                                if (cmbMonth.SelectedIndex == -1)
                                {
                                    cmbMonth.Focus();
                                    objEP.SetError(cmbMonth, "Select Month");
                                    FlagReturn = true;
                                }
                                else
                                    FlagReturn = false;

                                if (!FlagReturn)
                                {
                                    if (cmbYear.SelectedIndex == -1)
                                    {
                                        cmbYear.Focus();
                                        objEP.SetError(cmbYear, "Select Year");
                                        FlagReturn = true;
                                    }
                                    else
                                        FlagReturn = false;
                                }
                            }
                            //else if (cmbDatePeriodType.Text == "Yearly")
                            //{
                            //    if (cmbYear.SelectedIndex == -1)
                            //    {
                            //        cmbYear.Focus();
                            //        objEP.SetError(cmbYear, "Select Year");
                            //        FlagReturn = true;
                            //    }
                            //    else
                            //        FlagReturn = false;
                            //}
                            else
                            {
                                FlagReturn = false;
                            }
                        }
                    }
                }
            }
            return FlagReturn;
        }

        public double SumTime(Nullable<TimeSpan> time)
        {
            if (time == null)
                return 0;
            return time.Value.TotalMilliseconds;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (!Validation())
            {
                Get_Report_Check_ReportName();
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }

            //ReportName = string.Empty;
            //if (cmbReportType.SelectedIndex > -1)
            //{
            //    ReportName = cmbReportType.Text;
            //    GenerateQuery();
            //}
            //GetReport();
        }

        string WhereClause_BR = string.Empty, ColumnNames_BR = string.Empty, TableNames_BR = string.Empty;

        private void Get_Report_Check_ReportName()
        {
            
            ReportName = string.Empty;

           // WhereClause_BR = string.Empty; ColumnNames_BR = string.Empty; TableNames_BR = string.Empty;

            if (cmbReportName.SelectedIndex > -1)
            {
                ReportName = cmbReportName.Text;

                //Add_Query();

                //Date Wise
                //Department Wise
                //Grade Wise
                //Team Wise
                //Category Wise
                //Employment Type Wise
                //Location Wise
                //Designation Wise

                //Daily Attendance Present (Basic Reports)
                //Daily Attendance Report (Detailed Summary Report)
                //Daily Attendance Report (Basic Report)
                //Daily Attendance Report (Detailed Summary Report)
                //Memo
                //Department Summary Report
                //Daily Attendance Absent (Basic Report)
                //Yearly Summary Report
                //Daily Attendance Report (Detailed Report)

                //if (ReportName == BusinessResources.REPORT_EMPLOYEE_REPORT)
                //{
                //    string EmpStatus = string.Empty;
                //    if (cmbStatusEmployee.SelectedIndex > -1)
                //        ReportPeriod = cmbStatusEmployee.Text + " Employee Report";

                //    ColumnNames_BR = BusinessResources.Employees_Column;
                //    TableNames_BR = BusinessResources.Employee_Table;
                //    WhereClause_BR = BusinessResources.Employees_Where;
                //    OrderBy = " order by E.EmployeeName asc ";
                //}
                //else if (ReportName == BusinessResources.REPORT_NAME_WAGES_REPORT)
                //{
                //    ColumnNames_BR = BusinessResources.attendancemonthlydata_column;
                //    TableNames_BR = BusinessResources.attendancemonthlydata_Tables;
                //    WhereClause_BR = BusinessResources.attendancemonthlydata_Where;
                //    OrderBy = " order by E.EmployeeName asc ";
                //}
                //else if (ReportName == BusinessResources.REPORT_Daily_Attendance_Report_Basic_Report)
                //{
                //    ColumnNames_BR = BusinessResources.AttendanceRecord_Column;
                //    TableNames_BR = BusinessResources.AttendanceRecord_Table;
                //    WhereClause_BR = BusinessResources.AttendanceRecord_Where;
                //    OrderBy = " order by ARM.AttendanceDate asc ";
                //}
                //else if (ReportName == BusinessResources.REPORT_Daily_Attendance_Present_Basic_Reports)
                //{
                //    Set_Status_Present_Absent("P");
                //    ColumnNames_BR = BusinessResources.AttendanceRecord_Column;
                //    TableNames_BR = BusinessResources.AttendanceRecord_Table;
                //    WhereClause_BR = BusinessResources.AttendanceRecord_Where;
                //    OrderBy = " order by ARM.AttendanceDate asc ";
                //}
                //else if (ReportName == BusinessResources.REPORT_Daily_Attendance_Absent_Basic_Report)
                //{
                //    Set_Status_Present_Absent("A");
                //    ColumnNames_BR = BusinessResources.AttendanceRecord_Column;
                //    TableNames_BR = BusinessResources.AttendanceRecord_Table;
                //    WhereClause_BR = BusinessResources.AttendanceRecord_Where;
                //    OrderBy = " order by ARM.AttendanceDate asc ";
                //}
                //else if (ReportName == BusinessResources.REPORT_NAME_LATE_PUNCH_REPORT)
                //{
                    
                //}
                //else if (ReportName == BusinessResources.REPORT_NAME_EARLY_PUNCH_REPORT)
                //{
                   
                //}
                //else if (ReportName == BusinessResources.REPORT_NAME_MISSED_PUNCHED_REPORT)
                //{
                    
                //}
                //else if (ReportName == BusinessResources.REPORT_Daily_Attendance_Report_Detailed_Report)
                //{
                //    //attendancemonthlydata_column
                //    //attendancemonthlydata_Tables
                //    WhereClause = WhereClause + BusinessResources.AttendanceRecord_Where;
                //    objQL.ColumnNames_Report = BusinessResources.AttendanceRecord_Column;
                //    objQL.TableNames_Report = BusinessResources.AttendanceRecord_Table;
                //    OrderBy = " order by ARM.AttendanceDate asc ";
                //    MainQuery = objQL.ColumnNames_Report + objQL.TableNames_Report + WhereClause;
                //}
                //else if (ReportName == BusinessResources.REPORT_Daily_Attendance_Report_Detailed_Summary_Report)
                //{
                     
                //}
                //else
                //{

                //}

                //if (ReportName == BusinessResources.REPORT_NAME_WAGES_REPORT)
                //{
                    
                //}
                //else if (ReportName == BusinessResources.REPORT_Daily_Attendance_Report_Basic_Report)
                //{
                    
                //}
                //else if (ReportName == BusinessResources.REPORT_NAME_LOCATION_DEPARTMENT)
                //{
                  
                //}
                //else if (ReportName == BusinessResources.REPORT_EMPLOYEE_REPORT)
                //{
                   
                //}


                //WhereClause_BR = string.Empty; ColumnNames_BR = string.Empty; TableNames_BR = string.Empty;

                //MainQuery = objQL.ColumnNames_Report + objQL.TableNames_Report + WhereClause;
                Add_Query();

                DataSet ds = new DataSet();

                if (ReportName == BusinessResources.REPORT_Department_Summary_Report || ReportName == BusinessResources.REPORT_Yearly_Summary_Report)
                {
                    //Department Summary Report
                    //string[] StatusArray = { "½P", "A", "A(OD)", "H", "H½P", "HA", "HP", "P", "P(OD)", "WO", "WO½P", "WOP" };

                    if (!cbSelectAllDepartment.Checked)
                    {
                        foreach (object itemChecked in clbDepartment.Items)
                        {
                            DataRowView castedItem = itemChecked as DataRowView;
                            int? DepartmentId1 = Convert.ToInt32(castedItem[1]);
                            int DID = (int)DepartmentId1;
                            Fill_Department_Summary_Report(DID);
                             
                        }
                    }
                    else
                    {
                        foreach (object itemChecked in clbDepartment.CheckedItems)
                        {
                            DataRowView castedItem = itemChecked as DataRowView;
                            int? DepartmentId1 = Convert.ToInt32(castedItem[1]);
                            int DID = (int)DepartmentId1;
                            Fill_Department_Summary_Report(DID);
                        }
                    }

                    objPC.AMonth = AMonth;
                    objPC.AYear = AYear;
                    ds = objQL.SP_DepartmentSummaryReport_GetReport();
                }
                else if (ReportName == BusinessResources.REPORT_LEAVEREPORT)
                {
                    WhereClause = WhereClause + WhereClause_BR;
                    objQL.ColumnNames_Report = ColumnNames_BR;
                    objQL.TableNames_Report = TableNames_BR;
                    objQL.WhereClause_V = WhereClause;
                    objQL.OrderBy_V = OrderBy;
                    objQL.GroupBy_V = "";
                    ds = objQL.SP_Attendance_Report_Query();
                }
                else if (ReportName == BusinessResources.REPORT_PUNCHMONITOR)
                {
                    WhereClause = WhereClause + WhereClause_BR;
                    objQL.ColumnNames_Report = ColumnNames_BR;
                    objQL.TableNames_Report = TableNames_BR;
                    objQL.WhereClause_V = WhereClause;
                    objQL.OrderBy_V = OrderBy;
                    objQL.GroupBy_V = "";
                    ds = objQL.SP_Attendance_Report_Query();
                }
                else if (ReportName == BusinessResources.REPORT_Department_Wise_Designation_Wise_Count)
                {
                    Get_Department_Wise_Designation_AttendanceCount();

                    objPC.ReportType = cmbDatePeriodType.Text;
                    objPC.FromDate = dtpFromDate.Value;
                    objPC.ToDate = dtpToDate.Value;
                    objPC.AMonth = AMonth;
                    objPC.AYear = AYear;
                    ds = objQL.SP_TempDepartmentWiseDesignationAttendanceReport_Report();
                    
                    //WhereClause = WhereClause + WhereClause_BR;
                    //objQL.ColumnNames_Report = ColumnNames_BR;
                    //objQL.TableNames_Report = TableNames_BR;
                    //objQL.WhereClause_V = WhereClause;
                    //objQL.OrderBy_V = OrderBy;
                    //objQL.GroupBy_V = "";
                    //ds = objQL.SP_Attendance_Report_Query();
                }
                else if (ReportName == BusinessResources.REPORT_NAME_WAGES_REPORT)
                {
                    WhereClause = WhereClause + WhereClause_BR;
                    objQL.ColumnNames_Report = ColumnNames_BR;
                    objQL.TableNames_Report = TableNames_BR;
                    objQL.WhereClause_V = WhereClause;
                    objQL.OrderBy_V = OrderBy;
                    objQL.GroupBy_V = "";
                    ds = objQL.SP_Attendance_Report_Query();
                }
                else
                {
                    WhereClause = WhereClause + WhereClause_BR;
                    objQL.ColumnNames_Report = ColumnNames_BR;
                    objQL.TableNames_Report = TableNames_BR;
                    objQL.WhereClause_V = WhereClause;
                    objQL.OrderBy_V = OrderBy;
                    objQL.GroupBy_V = "";
                    ds = objQL.SP_Attendance_Report_Query();
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (cmbStatusEmployee.SelectedIndex > -1)
                        ReportPeriod = cmbStatusEmployee.Text + " Employee Report";

                    objQL.ReportPeriod = ReportPeriod;
                    ViewReportW objForm = new ViewReportW(ds, ReportName);
                    objForm.Show();
                }
                else
                {
                    objRL.ShowMessage(35, 4);
                    return;
                }
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }

        private void Fill_Department_Summary_Report(int DeptId)
        {
            //DepartmentSummaryReportId bigint AI PK 
            //AMonth int 
            //AYear int 
            //LocationId int 
            //DepartmentId int 
            //TotalP int 
            //TotalA int 
            //TotalH int 
            //TotalHP int 
            //TotalWO int 
            //TotalWOP int 
            //TotalOnLeave int 
            //TotalONOD int 
            //TotalOnOT int 
            //TotalLateComming int 
            //TotalEarlyGoing int 
            //TotalMissedInPunch int 
            //TotalMissedOutPunch int 
            //TotalEmployee int 

            TotalP = 0; TotalA = 0; TotalH = 0; TotalHP = 0; TotalWO = 0; TotalWOP = 0; TotalONOD = 0;
            TotalOnOT = 0; TotalLateComming = 0; TotalEarlyGoing = 0; TotalMissedInPunch = 0; TotalMissedOutPunch = 0;

            DataSet dsCount = new DataSet();

            string[] StatusArray = { "P", "A", "H", "HP", "WO", "WOP", "P(OD)" };  //"½P", "A(OD)", "H½P", "HA", "P(OD)", "WO½P", };

            for (int i = 0; i < StatusArray.Length; i++)
            {
                string ConditionValue = StatusArray[i].ToString();

                WhereClause = " where "  + BusinessResources.AttendanceRecord_Where + " and AMD.Status='" + ConditionValue + "' and"+ DateColumn + " E.DepartmentId=" + DeptId + "";

                objBL.Query = "select count(AMD.AttendanceRecordId) from " + BusinessResources.AttendanceRecord_Table + " " + WhereClause + "";
                dsCount = objBL.ReturnDataSet();

                if (dsCount.Tables[0].Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(dsCount.Tables[0].Rows[0][0].ToString())))
                    {
                        if (ConditionValue == "P")
                            TotalP = Convert.ToInt32(dsCount.Tables[0].Rows[0][0].ToString());
                        else if (ConditionValue == "A")
                            TotalA = Convert.ToInt32(dsCount.Tables[0].Rows[0][0].ToString());
                        else if (ConditionValue == "H")                                             
                            TotalH = Convert.ToInt32(dsCount.Tables[0].Rows[0][0].ToString());
                        else if (ConditionValue == "HP")
                            TotalHP = Convert.ToInt32(dsCount.Tables[0].Rows[0][0].ToString());
                        else if (ConditionValue == "WO")
                            TotalWO = Convert.ToInt32(dsCount.Tables[0].Rows[0][0].ToString());
                        else if (ConditionValue == "WOP")
                            TotalWOP = Convert.ToInt32(dsCount.Tables[0].Rows[0][0].ToString());
                        else if (ConditionValue == "P(OD)")
                            TotalONOD = Convert.ToInt32(dsCount.Tables[0].Rows[0][0].ToString());
                        else
                        {

                        }
                    }
                }
            }

            string[] OtherStatusArray = { "OverTime", "LateBy", "EarlyBy", "MissedInPunch", "MissedOutPunch" };

            for (int i = 0; i < OtherStatusArray.Length; i++)
            {
                string ConditionValue = OtherStatusArray[i].ToString();

                //WhereClause = " where " + BusinessResources.AttendanceRecord_Where + " and AMD.Status='" + ConditionValue + "' and E.DepartmentId=" + DeptId + "";

                WhereClause = " where " + BusinessResources.AttendanceRecord_Where + " and AMD." + ConditionValue + " > 0  and"+ DateColumn + " E.DepartmentId=" + DeptId + "";
                
                objBL.Query = "select count(AMD.AttendanceRecordId) from " + BusinessResources.AttendanceRecord_Table + " " + WhereClause + "";
                
                dsCount = objBL.ReturnDataSet();

                if (dsCount.Tables[0].Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(dsCount.Tables[0].Rows[0][0].ToString())))
                    {
                        if (ConditionValue == "OverTime")
                            TotalOnOT = Convert.ToInt32(dsCount.Tables[0].Rows[0][0].ToString());
                        else if (ConditionValue == "LateBy")
                            TotalLateComming = Convert.ToInt32(dsCount.Tables[0].Rows[0][0].ToString());
                        else if (ConditionValue == "EarlyBy")
                            TotalEarlyGoing = Convert.ToInt32(dsCount.Tables[0].Rows[0][0].ToString());
                        else if (ConditionValue == "MissedInPunch")
                            TotalMissedInPunch = Convert.ToInt32(dsCount.Tables[0].Rows[0][0].ToString());
                        else if (ConditionValue == "MissedOutPunch")
                            TotalMissedOutPunch = Convert.ToInt32(dsCount.Tables[0].Rows[0][0].ToString());
                        else
                        {

                        }
                    }
                }
            }

            objQL.TuncateTables_Report();

            DataSet dsCount1 = new DataSet();
            objBL.Query = "insert into DepartmentSummaryReport(AMonth,AYear,DepartmentId,TotalP,TotalA,TotalH,TotalHP,TotalWO,TotalWOP,TotalOnLeave,TotalONOD,TotalOnOT,TotalLateComming,TotalEarlyGoing,TotalMissedInPunch,TotalMissedOutPunch,TotalEmployee) value(" + AMonth + "," + AYear + "," + DeptId + "," + TotalP + "," + TotalA + "," + TotalH + "," + TotalHP + "," + TotalWO + "," + TotalWOP + "," + TotalOnLeave + "," + TotalONOD + "," + TotalOnOT + "," + TotalLateComming + "," + TotalEarlyGoing + "," + TotalMissedInPunch + "," + TotalMissedOutPunch + "," + TotalEmployee + ") ";
            int R = objBL.Function_ExecuteNonQuery();
        }

        int LocationId = 0, DepartmentId = 0, TotalP = 0, TotalA = 0, TotalH = 0, TotalHP = 0, TotalWO = 0, TotalWOP = 0, TotalOnLeave = 0, TotalONOD = 0, TotalOnOT = 0, TotalLateComming = 0, TotalEarlyGoing = 0, TotalMissedInPunch = 0, TotalMissedOutPunch = 0, TotalEmployee = 0;

        private void Fill_Department_SelectAll(CheckedListBox clb, CheckBox cbSelectAll)
        {
            for (int i = 0; i < clb.Items.Count; i++)
            {
                if (cbSelectAll.Checked)
                    clb.SetItemChecked(i, true);
                else
                    clb.SetItemChecked(i, false);
            }
        }

        private void GB_Settings(GroupBox gb, CheckedListBox clb, CheckBox cb, CheckBox cbSelectAll)
        {
            if (cb.Checked)
            {
                gb.Enabled = true;

                for (int i = 0; i < clb.Items.Count; i++)
                {
                    if (cbSelectAll.Checked)
                        clb.SetItemChecked(i, true);
                    else
                        clb.SetItemChecked(i, false);
                }
            }
            else
            {
                cbSelectAll.Checked = false;
                gb.Enabled = false;
                for (int i = 0; i < clb.Items.Count; i++)
                {
                    clb.SetItemChecked(i, false);
                }
            }
        }



        private void cbStatus_CheckedChanged(object sender, EventArgs e)
        {
            GB_Settings(gbStatus, clbStatus, cbStatus, cbSelectAllStatus);
        }

        private void cbContractor_CheckedChanged(object sender, EventArgs e)
        {
            GB_Settings(gbContractor, clbContractor, cbContractor, cbSelectAllContractor);
        }

        //private void cbDepartment_CheckedChanged(object sender, EventArgs e)
        //{
        //    GB_Settings(gbDepartment, clbDepartment, cbDepartment, cbSelectAllDepartment);
        //}

        //private void cbShift_CheckedChanged(object sender, EventArgs e)
        //{
        //    GB_Settings(gbShift, clbShift, cbShift, cbSelectAllShift);
        //}

        //private void cbCompany_CheckedChanged(object sender, EventArgs e)
        //{
        //    GB_Settings(gbCompany, clbCompany, cbCompany, cbSelectAllCompany);
        //}

        private void cbSelectAllContractor_CheckedChanged(object sender, EventArgs e)
        {
            GB_Settings(gbContractor, clbContractor, cbContractor, cbSelectAllContractor);
        }

        private void cbSelectAllStatus_CheckedChanged(object sender, EventArgs e)
        {
            GB_Settings(gbStatus, clbStatus, cbStatus, cbSelectAllStatus);
        }

        private void cbSelectAllDepartment_CheckedChanged(object sender, EventArgs e)
        {
            //GB_Settings(gbDepartment, clbDepartment, cbSelectAllDepartment, cbSelectAllDepartment);

            Fill_Department_SelectAll(clbDepartment, cbSelectAllDepartment);
        }

        private void cbSelectAllCompany_CheckedChanged(object sender, EventArgs e)
        {
            //GB_Settings(gbCompany, clbCompany, cbCompany, cbSelectAllCompany);
        }

        private void cbSelectAllShift_CheckedChanged(object sender, EventArgs e)
        {
            //GB_Settings(gbShift, clbShift, cbShift, cbSelectAllShift);
        }

        int EmployeeId = 0;
        private void ClearEmployee()
        {
            EmployeeId = 0;
            txtSearchEmployeeCode.Text = "";
            // txtSearchEmployeeName.Text = "";
            lbEmployee.DataSource = null;
            rtbEmployeeDetails.Text = "";
        }

        private void txtSearchEmployeeName_TextChanged(object sender, EventArgs e)
        {
            ClearEmployee();

            if (txtSearchEmployeeName.Text != "")
                objQL.Fill_Employee_ListBox(lbEmployee, txtSearchEmployeeName.Text, "Text");
            else
                objQL.Fill_Employee_ListBox(lbEmployee, txtSearchEmployeeName.Text, "All");
        }

        private void txtSearchEmployeeCode_TextChanged(object sender, EventArgs e)
        {
            if(txtSearchEmployeeCode.Text =="")
                objQL.Fill_Employee_ListBox(lbEmployee, txtSearchEmployeeName.Text, "All");
        }

        private void txtSearchEmployeeCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtSearchEmployeeCode.Text != "")
                {
                    rtbEmployeeDetails.Text = "";
                    lbEmployee.DataSource = null;
                    lbEmployee.Visible = false;
                    EmployeeId = Convert.ToInt32(txtSearchEmployeeCode.Text);
                    Fill_Employee_Information();
                }
                else
                {
                    objQL.Fill_Employee_ListBox(lbEmployee, txtSearchEmployeeName.Text, "All");
                }
            }
        }


        private void Get_Employee()
        {
            if (lbEmployee.SelectedIndex > -1)
            {
                rtbEmployeeDetails.Text = "";
                EmployeeId = Convert.ToInt32(lbEmployee.SelectedValue.ToString());
                Fill_Employee_Information();
            }
        }

        private void Fill_Employee_Information()
        {
            if (EmployeeId > 0)
            {
                objQL.Fill_Employee_RichTextBox(rtbEmployeeDetails, EmployeeId);
                lbEmployee.Visible = false;
                rtbEmployeeDetails.Visible = true;
                cbToday.Focus();
            }
            else
            {
                rtbEmployeeDetails.Text = "";
                rtbEmployeeDetails.Visible = true;
            }
        }

        private void lbEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Get_Employee();
        }

        private void lbEmployee_Click(object sender, EventArgs e)
        {
            Get_Employee();
        }

        private void Set_ReportType()
        {
            if (cmbDatePeriodType.SelectedIndex > -1)
            {
                Date_Visible(false);
                Month_Visible(false);
                //Year_Visible(false);

              

                RType = cmbDatePeriodType.Text;
                if (RType == "Monthly")
                {
                    gbMonthYear.Visible = true;
                    //lblMonth.Visible = true;
                    //cmbMonth.Visible = true;
                    //cmbYear.Visible = true;

                    //lblFromDate.Visible = false;
                    //dtpFromDate.Visible = false;
                    //lblToDate.Visible = false;
                    //dtpToDate.Visible = false;
                    //cbToday.Visible = false;

                }
                else if (RType == "Daily")
                {
                    gbDatePeriodType.Visible = true;

                    //lblMonth.Visible = false;
                    //cmbMonth.Visible = false;
                    //cmbYear.Visible = false;

                    //lblFromDate.Visible = true;
                    //dtpFromDate.Visible = true;
                    //lblToDate.Visible = true;
                    //dtpToDate.Visible = true;
                    //cbToday.Visible = true;
                }
                else
                {
                    //Date_Visible(false);
                    //Month_Visible(false);
                    //Year_Visible(true);
                }
            }
        }

        //string RType = string.Empty;

        private void cmbDatePeriodType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Set_ReportType();
        }

        private void cmbReportName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Set_ReportNameSelection();
        }

        private void CheckBox_Enable_TrueFalse(CheckBox cb, bool tf)
        {
            if (tf)
                cb.Enabled = true;
            else
                cb.Enabled = false;
        }

        private void Date_Visible(bool tf)
        {
            if (tf)
            {
                gbDatePeriodType.Visible = true;

                //lblFromDate.Visible = true;
                //dtpFromDate.Visible = true;
                //lblToDate.Visible = true;
                //dtpToDate.Visible = true;
                //cbToday.Visible = true;
            }
            else
            {
                gbDatePeriodType.Visible = false;

                //lblFromDate.Visible = false;
                //dtpFromDate.Visible = false;
                //lblToDate.Visible = false;
                //dtpToDate.Visible = false;
                //cbToday.Visible = false;
            }
        }

        private void Type_Visible(bool tf)
        {
            if (tf)
            {
                lblDatePeriodType.Visible = true;
                cmbDatePeriodType.Visible = true;
            }
            else
            {
                cmbDatePeriodType.SelectedIndex = -1;
                lblDatePeriodType.Visible = false;
                cmbDatePeriodType.Visible = false;
            }
        }

        private void LocationAndDepartment_Visible(bool tf)
        {
            cmbLocation.SelectedIndex = -1;
            CheckListBox_Clear(clbDepartment);

            if (tf)
            {
                gbLocationAndDepartment.Visible = true;
            }
            else
            {
                gbLocationAndDepartment.Visible = false;
            }
        }

        private void Contractor_Visible(bool tf)
        {
            cbContractor.Checked = false;
            cbSelectAllContractor.Checked = false;
            CheckListBox_Clear(clbContractor);
            gbContractor.Visible = false;

            if (tf)
            {
                cbContractor.Visible = true;
                gbContractor.Visible = true;
            }
            else
            {
                cbContractor.Visible = false;
                gbContractor.Visible = false;
            }
        }

        private void Status_Visible(bool tf)
        {
            cbStatus.Checked = false;
            cbSelectAllStatus.Checked = false;
            CheckListBox_Clear(clbStatus);
            gbStatus.Visible = false;

            if (tf)
            {
                cbStatus.Visible = true;
                gbStatus.Visible = true;
            }
            else
            {
                cbStatus.Visible = false;
                gbStatus.Visible = false;
            }
        }

        private void Employee_Visible(bool tf)
        {
            EmployeeId = 0;
            txtSearchEmployeeCode.Text = "";
            txtSearchEmployeeName.Text = "";
            rtbEmployeeDetails.Text = "";
            objQL.Fill_Employee_ListBox(lbEmployee, txtSearchEmployeeName.Text, "All");

            if (tf)
            {
                gbSearchEmployee.Visible = true;
            }
            else
            {
                gbSearchEmployee.Visible = false;
            }
        }

        private void CheckListBox_Clear(CheckedListBox clb)
        {
            for (int i = clb.Items.Count - 1; i >= 0; i--)
            {
                clb.SetItemChecked(i, false);
            }
        }

        private void Report_Type(string AddString)
        {
            cmbReportType.Items.Clear();
            cmbReportType.SelectedIndex = -1;

            if (!string.IsNullOrEmpty(Convert.ToString(AddString)))
            {
                if (AddString == "SingleE")
                    cmbReportType.Items.Add("Employee Wise");
                else if (AddString == "SingleLD")
                    cmbReportType.Items.Add("Location And Department Wise");
                else if (AddString == "Both")
                {
                    cmbReportType.Items.Add("Employee Wise");
                    cmbReportType.Items.Add("Location And Department Wise");
                }
                else
                {
                    cmbReportType.Items.Clear();
                    cmbReportType.SelectedIndex = -1;
                }
            }
        }

        private void EmployeeStatus_Visible(bool tf)
        {
            if (tf)
            {
                lblStatusEmployee.Visible = true;
                cmbStatusEmployee.Visible = true;
            }
            else
            {
                cmbStatusEmployee.SelectedIndex = -1;
                lblStatusEmployee.Visible = false;
                cmbStatusEmployee.Visible = false;
            }
        }

        private void Month_Visible(bool tf)
        {
            if (tf)
            {
                gbMonthYear.Visible = true;
                //lblMonth.Visible = true;
                //cmbMonth.Visible = true;
                //cmbYear.Visible = true;
            }
            else
            {
                gbMonthYear.Visible = false;

                //cmbMonth.SelectedIndex = -1;
                //lblMonth.Visible = false;
                //cmbMonth.Visible = false;
                //cmbYear.Visible = false;
            }
        }

        private void Year_Visible(bool tf)
        {
            //if (tf)
            //{
            //    lblYear.Visible = true;
            //    cmbYear.Visible = true;
            //}
            //else
            //{
            //    lblYear.Visible = false;
            //    cmbYear.SelectedIndex = -1;
            //    cmbYear.Visible = false;
            //}
        }

        string OrderBy = string.Empty;
        string WhereAdditional = string.Empty;

        private void Set_ReportNameSelection()
        {
            WhereAdditional = string.Empty;

            if (cmbReportName.SelectedIndex > -1)
            {
                ReportPeriod = string.Empty; WhereClause_BR = string.Empty; ColumnNames_BR = string.Empty; TableNames_BR = string.Empty;
                ReportName = cmbReportName.Text;
                //cmbReportName.Items.Clear();
                //cmbReportName.Items.Add(BusinessResources.REPORT_EMPLOYEE_REPORT);
                //cmbReportName.Items.Add(BusinessResources.REPORT_NAME_WAGES_REPORT);
                //cmbReportName.Items.Add(BusinessResources.REPORT_Daily_Attendance_Report_Basic_Report);
                //cmbReportName.Items.Add(BusinessResources.REPORT_Daily_Attendance_Present_Basic_Reports);
                //cmbReportName.Items.Add(BusinessResources.REPORT_Daily_Attendance_Absent_Basic_Report);
                //cmbReportName.Items.Add(BusinessResources.REPORT_Daily_Attendance_Report_Detailed_Report);
                //cmbReportName.Items.Add(BusinessResources.REPORT_Daily_Attendance_Report_Detailed_Summary_Report);
                //cmbReportName.Items.Add(BusinessResources.REPORT_NAME_LATE_PUNCH_REPORT);
                //cmbReportName.Items.Add(BusinessResources.REPORT_NAME_EARLY_PUNCH_REPORT);
                //cmbReportName.Items.Add(BusinessResources.REPORT_NAME_MISSED_PUNCHED_REPORT);

                //CheckBox_Enable_TrueFalse(cbStatus, true);
                EmployeeStatus_Visible(false);
                Report_Type("Both");

                if (ReportName == BusinessResources.REPORT_EMPLOYEE_REPORT)
                {
                    Report_Type("SingleLD");
                    Type_Visible(false);
                    Date_Visible(false);
                    Month_Visible(false);
                    //Year_Visible(false);
                    EmployeeStatus_Visible(true);
                    CheckBox_Enable_TrueFalse(cbStatus, false);
                    Status_Visible(false);
                    
                    Employee_Visible(false);
                    ColumnNames_BR = BusinessResources.Employees_Column;
                    TableNames_BR = BusinessResources.Employee_Table;
                    WhereClause_BR = BusinessResources.Employees_Where;
                    OrderBy = " order by E.EmployeeName asc ";
                }
                else if (ReportName == BusinessResources.REPORT_NAME_WAGES_REPORT)
                {
                    EmployeeStatus_Visible(false);
                    Type_Visible(true);
                    Month_Visible(true);
                    //Year_Visible(true);
                    Date_Visible(false);

                    Status_Visible(false);

                    ColumnNames_BR = BusinessResources.attendancemonthlydata_column;
                    TableNames_BR = BusinessResources.attendancemonthlydata_Tables;
                    WhereClause_BR = BusinessResources.attendancemonthlydata_Where;
                    OrderBy = " order by E.EmployeeName asc ";
                }
                //BusinessResources.REPORT_Daily_Attendance_Report_Basic_Report
                //BusinessResources.REPORT_Daily_Attendance_Present_Basic_Reports
                //BusinessResources.REPORT_Daily_Attendance_Absent_Basic_Report
                else if (ReportName == BusinessResources.REPORT_Daily_Attendance_Report_Basic_Report || ReportName == BusinessResources.REPORT_Daily_Attendance_Present_Basic_Reports || ReportName == BusinessResources.REPORT_Daily_Attendance_Absent_Basic_Report || ReportName == BusinessResources.REPORT_NAME_LATE_PUNCH_REPORT || ReportName == BusinessResources.REPORT_NAME_EARLY_PUNCH_REPORT || ReportName == BusinessResources.REPORT_NAME_MISSED_PUNCHED_REPORT || ReportName == BusinessResources.REPORT_Monthly_Attendance_Basic_Report)
                {
                    EmployeeStatus_Visible(false);
                    Type_Visible(true);
                    Month_Visible(false);
                   // Year_Visible(false);
                    Date_Visible(true);
                    Status_Visible(true);

                    if (ReportName == BusinessResources.REPORT_Daily_Attendance_Present_Basic_Reports)
                        Set_Status_Present_Absent("P");

                    if (ReportName == BusinessResources.REPORT_Daily_Attendance_Absent_Basic_Report)
                        Set_Status_Present_Absent("A");

                    //if (ReportName == BusinessResources.REPORT_NAME_LATE_PUNCH_REPORT)
                    //    WhereAdditional = " and AMD .LateBy > 0 ";

                    //if (ReportName == BusinessResources.REPORT_NAME_EARLY_PUNCH_REPORT)
                    //    WhereAdditional = " and AMD.EarlyBy > 0 ";

                    if (ReportName == BusinessResources.REPORT_NAME_LATE_PUNCH_REPORT)
                        WhereAdditional = " and AMD.LateBy > 10 and E.FlexibleHoursFlag=0 ";

                    if (ReportName == BusinessResources.REPORT_NAME_EARLY_PUNCH_REPORT)
                        WhereAdditional = " and AMD.EarlyBy > 10 and E.FlexibleHoursFlag=0 ";

                    if (ReportName == BusinessResources.REPORT_NAME_MISSED_PUNCHED_REPORT)
                        WhereAdditional = " and AMD.MissedOutPunch=1 ";

                    ColumnNames_BR = BusinessResources.AttendanceRecord_Column;
                    TableNames_BR = BusinessResources.AttendanceRecord_Table;
                    WhereClause_BR = BusinessResources.AttendanceRecord_Where + WhereAdditional;
                    OrderBy = " order by ARM.AttendanceDate asc ";
                    //OrderBy = " order by E.EmployeeCode asc ";
                }

                //else if (ReportName == BusinessResources.REPORT_Daily_Attendance_Present_Basic_Reports)
                //{
                //    ColumnNames_BR = BusinessResources.AttendanceRecord_Column;
                //    TableNames_BR = BusinessResources.AttendanceRecord_Table;
                //    WhereClause_BR = BusinessResources.AttendanceRecord_Where;
                //    OrderBy = " order by ARM.AttendanceDate asc ";
                //}
                //else if (ReportName == BusinessResources.REPORT_Daily_Attendance_Absent_Basic_Report)
                //{
                //    Set_Status_Present_Absent("A");
                //    ColumnNames_BR = BusinessResources.AttendanceRecord_Column;
                //    TableNames_BR = BusinessResources.AttendanceRecord_Table;
                //    WhereClause_BR = BusinessResources.AttendanceRecord_Where;
                //    OrderBy = " order by ARM.AttendanceDate asc ";
                //}
                //else if (ReportName == BusinessResources.REPORT_NAME_LATE_PUNCH_REPORT)
                //{

                //}
                //else if (ReportName == BusinessResources.REPORT_NAME_EARLY_PUNCH_REPORT)
                //{

                //}
                //else if (ReportName == BusinessResources.REPORT_NAME_MISSED_PUNCHED_REPORT)
                //{

                //}
                else if (ReportName == BusinessResources.REPORT_Daily_Attendance_Report_Detailed_Report)
                {
                    EmployeeStatus_Visible(false);
                    Type_Visible(true);
                    Month_Visible(false);
                   // Year_Visible(false);
                    Date_Visible(true);

                    ColumnNames_BR = BusinessResources.AttendanceRecord_Column;
                    TableNames_BR = BusinessResources.AttendanceRecord_Table;
                    WhereClause_BR = BusinessResources.AttendanceRecord_Where;
                    OrderBy = " order by ARM.AttendanceDate asc ";

                    ////attendancemonthlydata_column
                    ////attendancemonthlydata_Tables
                    //WhereClause = WhereClause + BusinessResources.AttendanceRecord_Where;
                    //objQL.ColumnNames_Report = BusinessResources.AttendanceRecord_Column;
                    //objQL.TableNames_Report = BusinessResources.AttendanceRecord_Table;
                  
                    //MainQuery = objQL.ColumnNames_Report + objQL.TableNames_Report + WhereClause;
                }
                else if (ReportName == BusinessResources.REPORT_Daily_Attendance_Report_Detailed_Summary_Report)
                {
                    EmployeeStatus_Visible(false);
                    Type_Visible(true);
                    Month_Visible(false);
                   // Year_Visible(false);
                    Date_Visible(true);

                    ColumnNames_BR = BusinessResources.AttendanceRecord_Column;
                    TableNames_BR = BusinessResources.AttendanceRecord_Table;
                    WhereClause_BR = BusinessResources.AttendanceRecord_Where;

                    //WhereClause = WhereClause + BusinessResources.AttendanceRecord_Where;
                    //objQL.ColumnNames_Report = BusinessResources.AttendanceRecord_Column;
                    //objQL.TableNames_Report = BusinessResources.AttendanceRecord_Table;
                    OrderBy = " order by ARM.AttendanceDate asc ";
                }
                else if (ReportName == BusinessResources.REPORT_Department_Summary_Report || ReportName == BusinessResources.REPORT_Yearly_Summary_Report)
                {
                    EmployeeStatus_Visible(false);
                    Type_Visible(true);
                    Month_Visible(false);
                   // Year_Visible(false);
                    Date_Visible(true);

                    CheckBox_Enable_TrueFalse(cbStatus, false);
                    CheckBox_Enable_TrueFalse(cbContractor, false);
                    //CheckBox_Enable_TrueFalse(cbShift, false);

                    ColumnNames_BR = BusinessResources.AttendanceRecord_Column;
                    TableNames_BR = BusinessResources.AttendanceRecord_Table;
                    WhereClause_BR = BusinessResources.AttendanceRecord_Where;
                    OrderBy = " order by ARM.AttendanceDate asc ";
                }
                else if (ReportName == BusinessResources.REPORT_LEAVEREPORT)
                {
                    cbStatus.Checked = false;
                    cbStatus.Enabled = false;
                    //cbShift.Checked = false;
                    //cbShift.Enabled = false;

                    CheckBox_Enable_TrueFalse(cbStatus, false);
                    //CheckBox_Enable_TrueFalse(cbContractor, false);
                    //CheckBox_Enable_TrueFalse(cbShift, false);

                    Type_Visible(true);
                    //Month_Visible(true);
                    //Year_Visible(true);
                    //Date_Visible(true);

                    ColumnNames_BR = BusinessResources.LeaveApplication_Column;
                    TableNames_BR = BusinessResources.LeaveApplication_Table;
                    WhereClause_BR = BusinessResources.LeaveApplication_Where;
                    OrderBy = " order by LA.EntryDate asc ";

            //" Select
            //    LA.LeaveApplicationId,
            //    LA.EntryDate as 'Date',
            //    LA.EmployeeId,
            //    E.LocationId,
            //    LM.LocationName,
            //    E.DepartmentId,
            //    DM.Department,
            //    E.EmployeeName as 'Employee Name',
            //    DES.Designation,
            //    LA.FromDate as 'From Date',
            //    LA.ToDate as 'To Date',
            //    LA.TotalDays as 'Total Days',
            //    LT.LeaveTypeFName as 'Leave Type',
            //    LA.LeaveReason as 'Leave Reason',
            //    LA.LeaveStatus as 'Leave Status',
            //    E.TotalLeave,
            //    E.TotalLeave,
            //    LA.LeaveTypeId
            //from
            //    LeaveApplication LA inner join 
            //    leavetypes LT on LT.LeaveTypeId=LA.LeaveTypeId inner join
            //    Employees E on E.EmployeeId=LA.EmployeeId inner join 
            //    DepartmentMaster DM on DM.DepartmentId=E.DepartmentId inner join
            //    DesignationMaster DES on DES.DesignationId=E.DesignationId inner join
            //    LocationMaster LM on LM.LocationId=E.LocationId
            //where 
            //    LA.CancelTag=0 and
            //    LT.CancelTag=0 and
            //    E.CancelTag=0 and
            //    DM.CancelTag=0 and
            //    DES.CancelTag=0 and
            //    LM.CancelTag=0 
                }
                else if (ReportName == BusinessResources.REPORT_PUNCHMONITOR)
                {
                    EmployeeStatus_Visible(false);
                    Type_Visible(true);
                    //Month_Visible(true);
                    //Year_Visible(true);
                    //Date_Visible(false);

                    ColumnNames_BR = BusinessResources.PunchRecord_Columns;
                    TableNames_BR = BusinessResources.PunchRecord_Table;
                    WhereClause_BR = BusinessResources.PunchRecord_Where;
                    OrderBy = " order by ARM.AttendanceDate asc ";
                }
                else if (ReportName == BusinessResources.REPORT_Department_Wise_Designation_Wise_Count)
                {
                    EmployeeStatus_Visible(false);
                    Type_Visible(true);
                    Month_Visible(false);
                   // Year_Visible(false);
                    Date_Visible(false);
                   // CheckBox_Enable_TrueFalse(cbEmployee, false);
                    CheckBox_Enable_TrueFalse(cbContractor, false);
                    CheckBox_Enable_TrueFalse(cbStatus, false);
                    //CheckBox_Enable_TrueFalse(cbDepartment, false);
                    //CheckBox_Enable_TrueFalse(cbCompany, false);
                    //CheckBox_Enable_TrueFalse(cbShift, false);

                    ColumnNames_BR = BusinessResources.attendancemonthlydata_column;
                    TableNames_BR = BusinessResources.attendancemonthlydata_Tables;
                    WhereClause_BR = BusinessResources.attendancemonthlydata_Where;
                    OrderBy = " order by E.EmployeeName asc ";
                }
                else
                {
                    EmployeeStatus_Visible(false);
                    Type_Visible(false);
                    Date_Visible(false);
                    Month_Visible(false);
                    //Year_Visible(false);
                    EmployeeStatus_Visible(false);
                    //CheckBox_Enable_TrueFalse(cbEmployee, true);
                    CheckBox_Enable_TrueFalse(cbContractor, true);
                    CheckBox_Enable_TrueFalse(cbStatus, true);
                    //CheckBox_Enable_TrueFalse(cbDepartment, true);
                    //CheckBox_Enable_TrueFalse(cbCompany, true);
                    //CheckBox_Enable_TrueFalse(cbShift, true);
                }


                //--------------------------------------------------------------------------

                //if (cmbReportName.Text == BusinessResources.REPORT_EMPLOYEE_REPORT)
                //{
                    
                //}
                //else if (cmbReportName.Text == BusinessResources.REPORT_NAME_WAGES_REPORT)
                //{
                   
                //}
                //else if (cmbReportName.Text == BusinessResources.REPORT_Daily_Attendance_Report_Basic_Report)
                //{
                    
                //}
                //else if (cmbReportName.Text == BusinessResources.REPORT_NAME_LOCATION_DEPARTMENT)
                //{
                //    Type_Visible(true);
                //    Month_Visible(false);
                //    Date_Visible(true);
                //}
                //else
                //{
                //    Type_Visible(false);
                //    Date_Visible(false);
                //    EmployeeStatus_Visible(false);
                //}
            }
        }

        int DesignationId=0;
        private void Get_Department_Wise_Designation_AttendanceCount()
        {
            //Get All Department 1st
            DataSet ds = new DataSet();
            objPC.Department = "";
            objPC.SearchFlag = false;
            ds = objQL.SP_DepartmentMaster_FillGrid();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["DepartmentId"].ToString())))
                        DepartmentId = Convert.ToInt32(ds.Tables[0].Rows[i]["DepartmentId"].ToString());

                    DataSet dsDesignation = new DataSet();
                    objPC.Designation = "";
                    objPC.SearchFlag = false;
                    dsDesignation = objQL.SP_DesignationMaster_FillGrid();
                    if (dsDesignation.Tables[0].Rows.Count > 0)
                    {
                        for (int j = 0; j < dsDesignation.Tables[0].Rows.Count; j++)
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(dsDesignation.Tables[0].Rows[j]["DesignationId"].ToString())))
                                DesignationId = Convert.ToInt32(dsDesignation.Tables[0].Rows[j]["DesignationId"].ToString());

                             
                           string RepQuery="select Count(*) from "; // attendancerecordmaster ARM attendancerecord AML inner join Employees e on e.EmployeeId=ar.EmployeeId inner join "+
                                        //"designationmaster dm on dm.DesignationId=e.DesignationId  where AMD.Status='P' and dm.Designation='INCHARGE'"; 
                           objBL.Query= RepQuery+  BusinessResources.AttendanceRecord_Table + WhereClause + BusinessResources.AttendanceRecord_Where + " and E.DesignationId="+DesignationId+" and E.DepartmentId="+DepartmentId+"";

                           DataSet dsQ = new DataSet();
                           dsQ = objBL.ReturnDataSet();

                           if (dsQ.Tables[0].Rows.Count > 0)
                           {
                               if (!string.IsNullOrEmpty(Convert.ToString(dsQ.Tables[0].Rows[0][0].ToString())))
                                   objPC.TotalPresent = Convert.ToString(dsQ.Tables[0].Rows[0][0].ToString());
                               else
                                   objPC.TotalPresent = "0";
                           }

                           objPC.TempDepartmentWiseDesignationAttendanceReportId = 0;
                           objPC.ReportType = cmbDatePeriodType.Text;
                           objPC.FromDate = dtpFromDate.Value;
                           objPC.FromDate = dtpFromDate.Value;
                           objPC.AMonth = AMonth; // cmbMonth.Text;
                           objPC.AYear = AYear; // cmbYear.Text;
                           objPC.DepartmentId = DepartmentId;
                           objPC.DesignationId = DesignationId;
                           //objPC.TotalPresent =
                            objQL.SP_TempDepartmentWiseDesignationAttendanceReport_Insert();
                        }
                    }
                }
            }
        }

        private void cmbLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
           // FillDepartment1();
            objRL.FillDepartment_CheckListBox(cmbLocation, clbDepartment);
        }

        private void FillDepartment1()
        {
            clbDepartment.DataSource = null;
            if (cmbLocation.SelectedIndex > -1)
            {
                LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
                objPC.LocationId = LocationId;
                objPC.InchargeId = BusinessLayer.EmployeeLoginId_Static;
                objQL.WhereClause_V = string.Empty;

                if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR || BusinessLayer.UserType == BusinessResources.USER_TYPE_HROFFICER)
                    objQL.WhereClause_V = " and lwd.LocationId=" + objPC.LocationId + " ";
                else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER)
                    objQL.WhereClause_V = " and lwd.LocationId=" + objPC.LocationId + " ";
                else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_SENIOROFFICER)
                    objQL.WhereClause_V = " and lwd.InchargeId=" + SearchId + "  and lwd.LocationId=" + objPC.LocationId + " ";
                //else if (BusinessLayer.DesignationCategory == BusinessResources.USER_TYPE_OFFICER || BusinessLayer.DesignationCategory == BusinessResources.USER_TYPE_SUPERVISOR)
                //    FlagCheck = true;
                else
                {

                }

                //if (BusinessLayer.UserType == BusinessResources.USER_TYPE_INCHARGE)
                //    objQL.WhereClause_V = " and lwd.InchargeId=" + SearchId + "  and lwd.LocationId=" + objPC.LocationId + " ";
                //else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER)
                //    objQL.WhereClause_V = " and lwd.PlantHeadId=" + SearchId + " and lwd.LocationId=" + objPC.LocationId + " ";
                //else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMIN)
                //    objQL.WhereClause_V = " and lwd.LocationId=" + objPC.LocationId + " ";
                //else
                //{
                //    objRL.ShowMessage(38, 4);
                //    return;
                //}

                objQL.Fill_Department_By_EmployeeId_CheckListBox(clbDepartment);

                //if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMIN) // && BusinessLayer.UserType != BusinessResources.USER_TYPE_OFFICER)
                //{

                //    //objQL.WhereClause_V = " and lwd.HRId=" + BusinessLayer.EmployeeLoginId_Static + "";
                //    if (BusinessLayer.UserType == BusinessResources.USER_TYPE_PLANTHEAD)
                //        objPC.SearchType = BusinessResources.USER_TYPE_PLANTHEAD;
                //    else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_INCHARGE)
                //        objPC.SearchType = BusinessResources.USER_TYPE_INCHARGE;
                //    else
                //        objPC.SearchType = BusinessResources.USER_TYPE_INCHARGE;

                //    objQL.SP_ApprovalLevel_Get_Department_By_LocationId_InchargeId(cmbDepartment);
                //}
                //    //objPC.SearchType = BusinessResources.USER_TYPE_ADMIN;

                //else
                //{
                //    FillDepartmentAdmin();
                //}
            }
        }

        private void cbToday_CheckedChanged(object sender, EventArgs e)
        {
            dtpFromDate.Value = DateTime.Now.Date;
            dtpToDate.Value = DateTime.Now.Date;

            if (cbToday.Checked)
            {
                dtpFromDate.Enabled = false;
                dtpToDate.Enabled = false;
            }
            else
            {
                dtpFromDate.Enabled = true;
                dtpToDate.Enabled = true;
            }
        }

        private void cmbReportType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbReportType.SelectedIndex > -1)
            {
                if (cmbReportType.Text == "Employee Wise")
                {
                    Employee_Visible(true);
                    LocationAndDepartment_Visible(false);
                    Contractor_Visible(false);
                    Status_Visible(true);
                }
                else
                {
                    Employee_Visible(false);
                    LocationAndDepartment_Visible(true);
                    Contractor_Visible(true);
                    Status_Visible(true);
                }
            }
        }
    }
}
