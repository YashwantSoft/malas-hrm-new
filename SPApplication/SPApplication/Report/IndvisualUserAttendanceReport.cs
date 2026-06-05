using BusinessLayerUtility;
using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPApplication.Transaction
{
    public partial class IndvisualUserAttendanceReport : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();
        AttendanceLogics objAL = new AttendanceLogics();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0;

        string EmpDesignation = string.Empty;
        string EmpDepartment = string.Empty;

        int SearchId = 0, LocationId = 0;

        public IndvisualUserAttendanceReport()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnReport, btnClear, btnView, btnExit, BusinessResources.LBL_HEADER_USERATTENDANCE);
            rtbStatusCount.ForeColor = objDL.GetForeColor();
            rtbStatusCount.BackColor = objDL.GetBackgroundColor();
            btnReport.Text = BusinessResources.BTN_VIEW;
            ClearAll();
            FillEmployees_Combobox();
            SearchId = BusinessLayer.EmployeeLoginId_Static;
            objRL.FillLocation(cmbLocation, cmbDepartment);
        }


        public IndvisualUserAttendanceReport(int EmployeeId_F)
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnReport, btnClear, btnView, btnExit, BusinessResources.LBL_HEADER_USERATTENDANCE);
            rtbStatusCount.ForeColor = objDL.GetForeColor();
            rtbStatusCount.BackColor = objDL.GetBackgroundColor();
            btnReport.Text = BusinessResources.BTN_VIEW;
            ClearAll();
            FillEmployees_Combobox();
            objRL.FillLocation(cmbLocation, cmbDepartment);
            Fill_EmployeeDetails_Report();
            dtpFromDate.Value = objPC.FromDate;
            dtpToDate.Value = objPC.ToDate;
            Fill_Grid_AttendanceRecord();
        }
         
        private void UserAttendance_Load(object sender, EventArgs e)
        {

        }

        private void FillLocation()
        {
            //ADMINISTRATOR     BusinessResources.USER_TYPE_ADMINISTRATOR
            //HR OFFICER        BusinessResources.USER_TYPE_HROFFICER
            //MANAGER           BusinessResources.USER_TYPE_MANAGER
            //SENIOR OFFICER    BusinessResources.USER_TYPE_SENIOROFFICER
            //OFFICER           BusinessResources.USER_TYPE_OFFICER
            //SUPERVISOR        BusinessResources.USER_TYPE_SUPERVISOR
            //TRAINEE           BusinessResources.USER_TYPE_TRAINEE
            //WORKER            BusinessResources.USER_TYPE_WORKER

            bool FlagCheck = false;
            cmbLocation.Enabled = true;
            cmbDepartment.Enabled = true;
            cmbEmployeeName.Enabled = true;
            FlagCheck = false;

            if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR || BusinessLayer.UserType == BusinessResources.USER_TYPE_HROFFICER)
                objQL.WhereClause_V = "";
            else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER)
                objQL.WhereClause_V = " and lwd.PlantHeadId=" + SearchId + " ";
            else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_SENIOROFFICER)
                objQL.WhereClause_V = " and lwd.InchargeId=" + SearchId + " ";
            else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_OFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_SUPERVISOR)
                FlagCheck = true;
            else
            {
                objRL.ShowMessage(38, 4);
                return;
            }

            if (!FlagCheck)
            {
                objQL.Fill_Location_By_EmployeeId(cmbLocation);

                if (BusinessLayer.UserType == BusinessResources.USER_TYPE_SENIOROFFICER) // || BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR || BusinessLayer.DesignationCategory == BusinessResources.USER_TYPE_HROFFICER || BusinessLayer.DesignationCategory == BusinessResources.USER_TYPE_MANAGER)
                {
                    cmbLocation.Text = BusinessLayer.LocationName;
                    FillDepartment();
                    //cmbLocation.Enabled = false;
                    cmbDepartment.Text = BusinessLayer.Department;
                }
                else
                {
                    cmbLocation.Enabled = true;
                    cmbLocation.SelectedIndex = -1;
                    cmbDepartment.SelectedIndex = -1;
                }
            }
            else
            {
                cmbLocation.Enabled = false;
                cmbDepartment.Enabled = false;
                cmbEmployeeName.Enabled = false;
                objRL.Fill_Location_ComboBox(cmbLocation);
                cmbLocation.Text = BusinessLayer.LocationName;
                objPC.LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
                objRL.Fill_Department_ComboBox_By_Location(cmbDepartment, Convert.ToInt32(cmbLocation.SelectedValue));
                cmbDepartment.Text = BusinessLayer.Department;
                cmbEmployeeName.Text = BusinessLayer.UserName_Full_Static;
            }
             
        }

        private void FillDepartment()
        {
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
                //    objQL.WhereClause_V = " and lwd.LocationId=" + objPC.LocationId + " ";
                //else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMIN)
                //    objQL.WhereClause_V = " and lwd.LocationId=" + objPC.LocationId + " ";
                //else
                //{
                //    objRL.ShowMessage(38, 4);
                //    return;
                //}
                objQL.Fill_Department_By_EmployeeId(cmbDepartment);
            }
        }

        private void FillEmployees_Combobox()
        {
            if (!string.IsNullOrEmpty(Convert.ToString(BusinessLayer.Designation)) && !string.IsNullOrEmpty(Convert.ToString(BusinessLayer.Department)))
            {
                cmbEmployeeName.Enabled = true;
                cmbEmployeeName.SelectedIndex = -1;
                EmpDesignation = string.Empty;
                EmpDesignation = BusinessLayer.Designation.ToString();
                EmpDepartment = BusinessLayer.Department.ToString();
                objPC.DepartmentId = BusinessLayer.DepartmentId;

                if (BusinessLayer.UserType == BusinessResources.USER_TYPE_OFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_SUPERVISOR)
                {
                    objQL.SP_Employees_ComboBox_By_Department(cmbEmployeeName);
                    cmbEmployeeName.Text = BusinessLayer.UserName_Full_Static.ToString();
                    cmbEmployeeName.Enabled = false;
                    Fill_EmployeeDetails();
                }
                else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_SENIOROFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_SUPERVISOR)
                {
                    objQL.SP_Employees_ComboBox_By_Department(cmbEmployeeName);
                }
                else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_HROFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR)
                {
                    objQL.Fill_Master_ComboBox(cmbEmployeeName, "employees");
                    //cmbEmployeeName.Text = BusinessLayer.UserName_Full_Static.ToString();
                    Fill_EmployeeDetails();
                }
                else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER)
                {
                    //8,17,5076,23,41,19,55,100001,100002
                    if (BusinessLayer.UserName_Static == "8" || BusinessLayer.UserName_Static == "17" || BusinessLayer.UserName_Static == "19" || BusinessLayer.UserName_Static == "23" || BusinessLayer.UserName_Static == "41" || BusinessLayer.UserName_Static == "55" || BusinessLayer.UserName_Static == "5076" || BusinessLayer.UserName_Static == "100001" || BusinessLayer.UserName_Static == "100002")
                    {
                        objQL.SP_Employees_ComboBox_By_Department(cmbEmployeeName);
                        cmbEmployeeName.Text = BusinessLayer.UserName_Full_Static.ToString();
                        cmbEmployeeName.Enabled = false;
                        Fill_EmployeeDetails();
                    }
                    //BusinessLayer.Designation
                }
                else
                {

                }
            }
        }

        int TotalHalfDay = 0, TotalLeave = 0,TotalPresent = 0, TotalAbsent = 0;
        string checkStatus = string.Empty, LeaveName = string.Empty;
        string ConcatTotal = string.Empty;

        int TotalMP = 0;
        double TotalA = 0, TotalWO = 0, TotalWOP = 0, TotalH = 0, TotalP = 0, TotalHD = 0, TotalHP = 0, TotalL = 0, TotalCO = 0, TotalCOU = 0;

        //1	A	Absent	
        //2	WO	Weekly off	
        //3	WOP	Weekly off Present	
        //4	H	Holiday	
        //5	P	Present	
        //6	HD	Half Day
        //7	HP	Holiday Present	
        //8	L	Leave
        //9	CO	Comp off
        //10 COU Comp off Used

        private void Get_Count_All()
        {
            //Casual Leave
            //Paid Leave
            //Sick Leave
            //Marraige Leave
            //Compensation Off
            //Medical Leave
            //Compensation Off Used
            //Revert Leave
            //Maternity Leave

            //1	A	Absent	
            //2	WO	Weekly off	
            //3	WOP	Weekly off Present	
            //4	H	Holiday	
            //5	P	Present	
            //6	HD	Half Day
            //7	HP	Holiday Present	
            //8	L	Leave
            //9	CO	Comp off
            //10 COU Comp off Used

            rtbStatusCount.Text = "";
            checkStatus = string.Empty; LeaveName = string.Empty; ConcatTotal = string.Empty;

            TotalMP = 0; TotalA = 0; TotalWO = 0; TotalWOP = 0; TotalH = 0; TotalP = 0; TotalHD = 0; TotalHP = 0; TotalL = 0; TotalCO = 0; TotalCOU = 0;

            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    TotalMP += objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[i].Cells["clmMissedOutPunch"].Value)));

                    if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[i].Cells["clmStatus"].Value)))
                    {
                        checkStatus = Convert.ToString(dataGridView1.Rows[i].Cells["clmStatus"].Value.ToString());

                        //1	A	Absent	
                        //2	WO	Weekly off	
                        //3	WOP	Weekly off Present	
                        //4	H	Holiday	
                        //5	P	Present	
                        //6	HD	Half Day
                        //7	HP	Holiday Present	
                        //8	L	Leave
                        //9	CO	Comp off
                        //10 COU

                        if (checkStatus == "A")
                            TotalA += 1;
                            //TotalA++;
                        else if (checkStatus == "WO")
                            TotalWO += 1;
                            //TotalWO++;
                        else if (checkStatus == "WOP")
                            TotalWOP += 1;
                            //TotalWOP++;
                        else if (checkStatus == "H")
                            TotalH += 1;
                            //TotalH++;
                        else if (checkStatus == "P")
                            TotalP += 1;
                            //TotalP++;
                        else if (checkStatus == "HD")
                        {
                            TotalHD += 1;
                            //TotalA += 0.5;
                            //TotalHD += 0.5;
                        }
                        //TotalHD++;
                        else if (checkStatus == "HP")
                        {
                            TotalHP += 1;
                            //TotalHP++;
                        }
                        else if (checkStatus == "L")
                            TotalL += 1;
                        //TotalL++;
                        else if (checkStatus == "CO")
                            TotalCO += 1;
                        //TotalCO++;
                        else if (checkStatus == "COU")
                            TotalCOU += 1;
                        //TotalCOU++;
                        else
                        {

                        }
                    }

                    //if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[i].Cells["clmLeave"].Value)))
                    //{
                    //   LeaveName= Convert.ToString(dataGridView1.Rows[i].Cells["clmLeave"].Value);
                    //   if (LeaveName != "NA")
                    //       TotalLeave++;
                    //}
                }
                ConcatTotal = "Total Count-" + dataGridView1.Rows.Count.ToString() + System.Environment.NewLine +
                               "Present-" + TotalP.ToString() + System.Environment.NewLine +
                               "Absent-" + TotalA.ToString() + System.Environment.NewLine +
                               "Half Days-" + TotalHD.ToString() + System.Environment.NewLine +
                               "Weekly off-" + TotalWO.ToString() + System.Environment.NewLine +
                               "Weekly off Present-" + TotalWOP.ToString() + System.Environment.NewLine +
                               "Holiday Present-" + TotalHP.ToString() + System.Environment.NewLine +
                               "Comp off-" + TotalCO.ToString() + System.Environment.NewLine +
                               "Comp off Used-" + TotalCOU.ToString() + System.Environment.NewLine +
                               "Leaves-" + TotalL.ToString() + System.Environment.NewLine +
                               "Total OT Hours-" + OTHoursTotal.ToString() + System.Environment.NewLine +
                               "Total Hours-" + TotalHoursCount.ToString() + System.Environment.NewLine +
                               "Holiday-" + TotalH.ToString() + System.Environment.NewLine +
                               "Missed Punch-" + TotalMP.ToString();
                //lblStatusCount.Text = ConcatTotal.ToString();
                rtbStatusCount.Text = ConcatTotal.ToString();
            }
        }

        string WhereClass_Date_Holiday =string.Empty, MainQuery = string.Empty, WhereClass_Date = string.Empty, WhereClause = string.Empty, OrderBy = string.Empty;

        private void Get_Count_All_New()
        {
            //Get_Holiday();
            TotalMP = 0;
           ConcatTotal = "";
           WhereClass_Date_Holiday = string.Empty;
            MainQuery = string.Empty;
            WhereClass_Date = string.Empty;
            WhereClause = string.Empty;
            OrderBy = string.Empty;

            objPC.FromDate = dtpFromDate.Value;
            objPC.ToDate = dtpToDate.Value;

            WhereClass_Date = " and ARM.AttendanceDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";

            //WhereClass_Date = " and ARM.AttendanceDate between '" + objPC.AttendanceDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + objPC.AttendanceDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";

            WhereClass_Date_Holiday += " and H.HolidayDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";

            //WhereClass_Date_Holiday += " and Month(H.HolidayDate)=" + objPC.AttendanceDate + " and Year(H.HolidayDate)=" + objPC.AttendanceDate + "";
             
            //"(SELECT MasterName FROM employeeseffect ee WHERE ee.EmployeeId = e.EmployeeId AND ee.CancelTag = 0 AND ee.EffectType = 'Location and Department' " + WhereClause_Effective + " ORDER BY ee.FromDate DESC LIMIT 1) AS Location," +
            //"(SELECT MasterName1 FROM employeeseffect ee WHERE ee.EmployeeId = e.EmployeeId AND ee.CancelTag = 0 AND ee.EffectType = 'Location and Department' " + WhereClause_Effective + " ORDER BY ee.FromDate DESC LIMIT 1) AS Department," +
            //"(SELECT MasterName FROM employeeseffect ee WHERE ee.EmployeeId = e.EmployeeId AND ee.CancelTag = 0 AND ee.EffectType = 'Contractor' " + WhereClause_Effective + " ORDER BY ee.FromDate DESC LIMIT 1) AS Roll," +


            MainQuery = "SELECT " +
                        "e.EmployeeId," +
                        "(SELECT MasterName FROM employeeseffect ee WHERE ee.EmployeeId = e.EmployeeId AND ee.CancelTag = 0 AND ee.EffectType = 'Location and Department' and ee.FromDate <= e.DateOfExit ORDER BY ee.FromDate DESC LIMIT 1) AS Location," +
                        "(SELECT MasterName1 FROM employeeseffect ee WHERE ee.EmployeeId = e.EmployeeId AND ee.CancelTag = 0 AND ee.EffectType = 'Location and Department' and ee.FromDate <= e.DateOfExit ORDER BY ee.FromDate DESC LIMIT 1) AS Department," +
                        "(SELECT MasterName FROM employeeseffect ee WHERE ee.EmployeeId = e.EmployeeId AND ee.CancelTag = 0 AND ee.EffectType = 'Contractor' and ee.FromDate <= e.DateOfExit ORDER BY ee.FromDate DESC LIMIT 1) AS Roll," +
                        "e.EmployeeCode as 'Employee Code'," +
                        "e.EmployeeName as 'Employee Name'," +
                        "SUM(CASE WHEN a.Status='P' THEN 1 WHEN a.Status='HD' THEN 0.5 ELSE 0 END) AS 'Present Days'," +
                        "SUM(CASE WHEN a.Status = 'L' THEN 1 ELSE 0 END) AS 'Leaves Days'," +
                        "SUM(CASE WHEN a.Status = 'SL' THEN 1 ELSE 0 END) AS 'Special Leaves'," +
                        "(select Count(H.HolidayId) from HolidayMaster H inner join HolidayLocation HL on H.HolidayId = HL.HolidayId where H.CancelTag = 0 and HL.CancelTag = 0 and HL.LocationId=e.LocationId " + WhereClass_Date_Holiday + " and H.HolidayDate >= e.DOJ and H.HolidayDate <= e.DateOfExit and H.HolidayDay NOT IN(c.CategoryFName)) as 'Holiday'," +
                        "CASE WHEN e.OverTimeApplicable = 0 THEN SUM(CASE WHEN a.Status = 'HP' THEN 1 ELSE 0 END) ELSE 0  END AS 'Holiday Present'," +
                        //"(SUM(CASE WHEN a.Status IN('P', 'L', 'H') THEN 1 WHEN a.Status='HD' THEN 0.5  ELSE 0 END) + (select Count(H.HolidayId) from HolidayMaster H join HolidayLocation HL on H.HolidayId=HL.HolidayId where H.CancelTag=0 and HL.CancelTag = 0 and HL.LocationId=e.LocationId "+ WhereClass_Date_Holiday + " and H.HolidayDate >= e.DOJ and H.HolidayDate <= e.DateOfExit and H.HolidayDay NOT IN(c.CategoryFName)) ) AS 'Salary Days'," +

                        //"(SUM(CASE WHEN a.Status IN('P','L','COU','SL') THEN 1 WHEN a.Status='HD' THEN 0.5  ELSE 0 END) + (select Count(H.HolidayId) from HolidayMaster H join HolidayLocation HL on H.HolidayId=HL.HolidayId where HL.LocationId=e.LocationId " + WhereClass_Date_Holiday + " and H.CancelTag=0 and HL.CancelTag = 0 and  H.HolidayDate >= e.DOJ and H.HolidayDate <= e.DateOfExit) ) AS 'Salary Days'," +
                        "(SUM(CASE WHEN a.Status IN('P','L','COU','SL') THEN 1 WHEN a.Status='HD' THEN 0.5  ELSE 0 END)) + (select Count(H.HolidayId) from HolidayMaster H join HolidayLocation HL on H.HolidayId=HL.HolidayId where HL.LocationId=e.LocationId " + WhereClass_Date_Holiday + " and H.CancelTag=0 and HL.CancelTag=0 and H.HolidayDate >= e.DOJ and H.HolidayDate <= e.DateOfExit and H.HolidayDay NOT IN(c.CategoryFName)) AS 'Salary Days'," +

                        "SUM(CASE WHEN a.Status NOT IN('WO', 'WOP', 'HP') THEN a.OverTime ELSE 0 END) AS 'Regular Overtime'," +
                        "SUM(CASE WHEN a.Status = 'WOP' THEN a.OverTime ELSE 0 END) AS 'WO OT hrs.'," +
                        "SUM(CASE WHEN a.Status = 'HP' THEN a.OverTime ELSE 0 END) AS 'Holiday OT Hours'," +
                        "SUM(CASE WHEN a.Status IN('P','WO', 'WOP', 'HP') THEN a.OverTime ELSE 0 END) AS 'Total OT Hrs.'," +
                        "SUM(CASE WHEN a.Status = 'A' THEN 1 ELSE 0 END) AS 'Absent'," +
                        "SUM(CASE WHEN a.Status = 'CO' THEN 1 ELSE 0 END) AS 'Comp Off Days'," +
                        "SUM(CASE WHEN a.Status = 'COU' THEN 1 ELSE 0 END) AS 'Comp Off Used'," +
                        "SUM(CASE WHEN a.Status = 'WO' THEN 1 ELSE 0 END) AS 'Weekly Off'," +
                        "SUM(CASE WHEN a.Status = 'WOP' THEN 1 ELSE 0 END) AS 'Weekly Off Present'," +
                        "MAX(DAY(LAST_DAY(ARM.AttendanceDate))) AS 'Total Days'," +
                        " SUM(a.TotalDuration) AS 'Total Hours'," +
                        " CASE WHEN e.FlexibleHoursFlag = 1 THEN SUM(CASE WHEN a.Status = 'P' THEN 1 ELSE 0 END) *8.5 ELSE SUM(CASE WHEN a.Status = 'P' THEN 1 ELSE 0 END) *8 END AS 'Total Workable Hours'," +
                        " ROUND((CAST(SUM(CASE WHEN a.Status IN('P', 'L', 'H', 'HP') THEN 1 ELSE 0 END) AS FLOAT) / NULLIF(MAX(DAY(LAST_DAY(ARM.AttendanceDate))), 0)) * 100, 2) AS 'Attendance Percent'" +
                        " FROM employees e" +
                        " JOIN attendancerecord a ON e.EmployeeId = a.EmployeeId" +
                        " JOIN attendancerecordmaster ARM ON a.AttendanceRecordMasterId = ARM.AttendanceRecordMasterId" +
                        " JOIN categories c ON c.CategoryId = e.CategoryId " +
                        " WHERE e.CancelTag=0 and a.CancelTag=0 and ARM.CancelTag=0 and c.CancelTag=0 " +
                        " and e.EmployeeCode NOT IN" +
                        "(100001,100004,50002,50003,50004,50005,50006,50007,50008,50009,50010,50011,50013,50014,50015,50016,50017,50018,50019,50020,50012,50021,50022,50023,50024,50025,50026,50027,50028) " +
                        " and E.EmployeeId="+objPC.EmployeeId+" and ARM.FinancialYearId = " + objPC.FinancialYearId + " " +
                        " " + WhereClause + WhereClass_Date + "" +
                        " GROUP BY e.EmployeeId, e.EmployeeCode, e.EmployeeName ORDER BY e.EmployeeCode asc ";

            //"(50002,50003,50004,50005,50006,50007,50008,50009,50010,50011,50012,50013,50014,50015,50016,50017,50018,50019,50020,100001,100002,100003,100004) " +
            System.Data.DataTable dt = new System.Data.DataTable();
            objBL.Query = MainQuery;
            dt = objBL.ReturnDataTable();

            if (dt.Rows.Count > 0)
            {
                ConcatTotal = "Present-\t\t\t" + objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Present Days"])) + System.Environment.NewLine +
                               "Leaves-\t\t\t" + objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Leaves Days"])) + System.Environment.NewLine +
                               "Special Leaves-\t\t" + objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Special Leaves"])) + System.Environment.NewLine +
                               "Holiday-\t\t\t" + objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Holiday"])) + System.Environment.NewLine +
                               "Holiday Present-\t\t" + objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Holiday Present"])) + System.Environment.NewLine +
                               "Salary Days-\t\t" + objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Salary Days"])) + System.Environment.NewLine +
                               "Regular Overtime-\t" + objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Regular Overtime"])) + System.Environment.NewLine +
                               "WO OT hrs.-\t\t" + objRL.CheckNullString(Convert.ToString(dt.Rows[0]["WO OT hrs."])) + System.Environment.NewLine +
                               "Total OT Hrs.-\t\t" + objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Total OT Hrs."])) + System.Environment.NewLine +
                               "Absent-\t\t\t" + objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Absent"])) + System.Environment.NewLine +
                               "Comp Off Days-\t\t" + objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Comp Off Days"])) + System.Environment.NewLine +
                               "Comp Off Used-\t\t" + objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Comp Off Used"])) + System.Environment.NewLine +
                               "Weekly Off-\t\t" + objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Weekly Off"])) + System.Environment.NewLine +
                               "Weekly off Present-\t" + objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Weekly Off Present"])) + System.Environment.NewLine +
                               "Total Days-\t\t" + objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Total Days"])) + System.Environment.NewLine +
                               "Total Hours-\t\t" + objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Total Hours"])) + System.Environment.NewLine +
                               "Total Workable Hours-\t" + objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Total Workable Hours"])) + System.Environment.NewLine +
                               //"Attendance Percent-" + objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Attendance Percent"])) + System.Environment.NewLine +
                               "Attendance Percent-\t" + objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Attendance Percent"])) + System.Environment.NewLine +
                               "Missed Punch-\t\t" + TotalMP.ToString();
                //lblStatusCount.Text = ConcatTotal.ToString();
                rtbStatusCount.Text = ConcatTotal.ToString();
            }
        }

        private void Fill_EmployeeDetails()
        {
            if (cmbEmployeeName.SelectedIndex > -1)
            {
                DataSet ds = new DataSet();
                objPC.EmployeeId = Convert.ToInt32(cmbEmployeeName.SelectedValue);
                ds = objQL.SP_Employees_By_EmployeeId();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Code"].ToString())))
                        txtEmployeeCode.Text = ds.Tables[0].Rows[0]["Code"].ToString();
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Designation"].ToString())))
                        txtDesignation.Text = ds.Tables[0].Rows[0]["Designation"].ToString();
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Department"].ToString())))
                        cmbDepartment.Text = ds.Tables[0].Rows[0]["Department"].ToString();
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["FlexibleHoursFlag"].ToString())))
                        objPC.FlexibleHoursFlag = objRL.CheckNullString_ReturnInt(Convert.ToString(ds.Tables[0].Rows[0]["FlexibleHoursFlag"]));
                }
            }
        }

        private void Fill_EmployeeDetails_Report()
        {
            if (objPC.EmployeeId >0)
            {
                DataSet ds = new DataSet();
                //objPC.EmployeeId = Convert.ToInt32(cmbEmployeeName.SelectedValue);
                ds = objQL.SP_Employees_By_EmployeeId();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Location Name"].ToString())))
                        cmbLocation.Text = ds.Tables[0].Rows[0]["Location Name"].ToString();
                    objRL.FillDepartment(cmbLocation, cmbDepartment);
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Department"].ToString())))
                        cmbDepartment.Text = ds.Tables[0].Rows[0]["Department"].ToString();
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Employee Name"].ToString())))
                        cmbEmployeeName.Text = ds.Tables[0].Rows[0]["Employee Name"].ToString();

                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Code"].ToString())))
                        txtEmployeeCode.Text = ds.Tables[0].Rows[0]["Code"].ToString();
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Designation"].ToString())))
                        txtDesignation.Text = ds.Tables[0].Rows[0]["Designation"].ToString();
                }
            }
        }

        private void ClearAll()
        {
            objEP.Clear();
            cmbLocation.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            cmbEmployeeName.SelectedIndex = -1;
            txtDesignation.Text = "";
            txtEmployeeCode.Text = "";
            dtpFromDate.Value = DateTime.Now.Date;
            dtpToDate.Value = DateTime.Now.Date;
            cbToday.Checked = true;
            OTHoursTotal = 0;
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Fill_Grid_AttendanceRecord();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        int SrNo = 1;
        double LateBy = 0, EarlyBy=0,TotalDurationDuration =0,TotalHoursCount=0;
        DateTime dtInTime, dtOutTime;

        private void Fill_Grid_AttendanceRecord()
        {
            OTHoursTotal = 0; TotalDurationDuration = 0;
            TotalHoursCount = 0;
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = null;

            if (objPC.EmployeeId != 0)
            {
                //lblData.Text = objPC.AttendanceData.ToString();
                //cmbAttendanceStatus.Text = objPC.ApprovalStatus;

                //if (cmbAttendanceStatus.SelectedIndex > -1)
                //    SetStatusColor();

                System.Data.DataTable ds = new System.Data.DataTable();
                objPC.FromDate = dtpFromDate.Value;
                objPC.ToDate= dtpToDate.Value;
                
                //objPC.EmployeeId = Convert.ToInt32(cmbEmployeeName.SelectedValue); // BusinessLayer.EmployeeLoginId_Static;
                 
                ds = objQL.SP_AttendanceRecord_FillGrid_By_BetweenDates();

                if (ds.Rows.Count > 0)
                {
                    OTHoursTotal = 0;
                   // lblTotalCount.Text = "Total Count: " + ds.Rows.Count.ToString();

                    objPC.OverTimeApplicable = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[0]["OverTimeApplicable"])));
                    objPC.FlexibleHoursFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[0]["FlexibleHoursFlag"])));

                    SrNo = 1;
                    for (int i = 0; i < ds.Rows.Count; i++)
                    {
                        //0 AR.AttendanceRecordId,
                        //1 AR.AttendanceRecordMasterId,
                        //2 AR.AttendanceHistoryId,
                        //3 AR.EsslAttendanceLogsId,
                        //4 AR.EmployeeId, 
                        //5 E.EmployeeName,
                        //6 E.EmployeeCode,
                        //7 AR.ShiftId, 
                        //8 S.ShiftSName,
                        //9 AR.ShiftGroupId,
                        //10 AR.InTime,
                        //11 AR.OutTime,
                        //12 AR.Duration,
                        //13AR.OverTime,
                        //14 AR.TotalDuration,
                        //15 AR.Status,
                        //16 AR.LateBy,
                        //17 AR.EarlyBy,
                        //18 AR.MissedInPunch,
                        //19 AR.MissedOutPunch,
                        //20 AR.ChangeDepartmentFlag,
                        //21 AR.ChangeDepartmentId,
                        //22 AR.ChangeLocationtId,
                        //23 AR.IsOnLeave,
                        //24 AR.LeaveTypeId,
                        //25 AR.LeaveDuration,
                        //26 AR.WeeklyOff,
                        //27 AR.Holiday,
                        //28 AR.LeaveRemarks,
                        //29 AR.PunchRecords,
                        //30 AR.LossOfHours,
                        //31 AR.Present,
                        //32 AR.Absent,
                        //33 AR.Remarks

                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells["clmSrNo"].Value = SrNo.ToString();
                        dataGridView1.Rows[i].Cells["clmAttendanceRecordId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["AttendanceRecordId"])); //ds.Rows[i]["AttendanceRecordId"].ToString();

                        //if (Convert.ToString(ds.Rows[i]["AttendanceRecordId"].ToString()) == "838")
                        //    MessageBox.Show("Found");

                        dataGridView1.Rows[i].Cells["clmAttendanceRecordMasterId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["AttendanceRecordMasterId"])); //ds.Rows[i]["AttendanceRecordMasterId"].ToString();
                        dataGridView1.Rows[i].Cells["clmEsslAttendanceLogsId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EsslAttendanceLogsId"])); //ds.Rows[i]["EsslAttendanceLogsId"].ToString();

                        DateTime dtAttendanceDate = Convert.ToDateTime(ds.Rows[i]["AttendanceDate"].ToString());
                        dataGridView1.Rows[i].Cells["clmAttendanceDate"].Value = dtAttendanceDate.ToString(BusinessResources.DATEFORMATDDMMMYYYY);

                        dataGridView1.Rows[i].Cells["clmEmployeeId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EmployeeId"])); //ds.Rows[i]["EmployeeId"].ToString();
                        dataGridView1.Rows[i].Cells["clmEmployeeName"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EmployeeName"])); //ds.Rows[i]["EmployeeName"].ToString();
                        dataGridView1.Rows[i].Cells["clmEmployeeCode"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EmployeeCode"])); //ds.Rows[i]["EmployeeCode"].ToString();

                        dataGridView1.Rows[i].Cells["clmShiftId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftId"])); //ds.Rows[i]["ShiftId"].ToString();
                        dataGridView1.Rows[i].Cells["clmShift"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftSName"])); //ds.Rows[i]["ShiftSName"].ToString();
                        dataGridView1.Rows[i].Cells["clmShiftGroupId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftGroupId"]));

                        dtInTime = Convert.ToDateTime(ds.Rows[i]["InTime"].ToString());
                        dtOutTime = Convert.ToDateTime(ds.Rows[i]["OutTime"].ToString());

                        dataGridView1.Rows[i].Cells["clmInTime"].Value = dtInTime.ToString("HH:mm");
                        dataGridView1.Rows[i].Cells["clmOutTime"].Value = dtOutTime.ToString("HH:mm");

                        //objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftId"])));
                        dataGridView1.Rows[i].Cells["clmShiftDuration"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftDurationHours"])); // objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftDuration"])); //ds.Rows[i]["ShiftId"].ToString();


                        dataGridView1.Rows[i].Cells["clmDuration"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Duration"])); //Convert.ToString(ds.Rows[i]["Duration"].ToString());
                        dataGridView1.Rows[i].Cells["clmOverTime"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["OverTime"]));
                        dataGridView1.Rows[i].Cells["clmTotalDuration"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["TotalDuration"]));

                        TimeSpan TD = TimeSpan.Parse(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["TotalDuration"])));
                        TotalDurationDuration = Math.Round(TD.TotalHours);
                        TotalHoursCount += TotalDurationDuration;

                        double TotalDuration = 0;
                        if (objPC.FlexibleHoursFlag == 1)
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[i]["TotalDuration"])))
                            {
                                //TimeSpan TD = TimeSpan.Parse(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["TotalDuration"])));
                                //TotalDuration = Math.Round(TD.TotalHours);

                                //TotalDuration = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["TotalDuration"])));
                                if (TotalDurationDuration < 8.30)
                                    objRL.Set_Error_Color(dataGridView1, i, "clmTotalDuration", Color.FromName(BusinessResources.LS_Error_Color));
                                else
                                    objRL.Set_Error_Color(dataGridView1, i, "clmTotalDuration", Color.White);
                            }
                        }

                        dataGridView1.Rows[i].Cells["clmStatus"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Status"]));

                        dataGridView1.Rows[i].Cells["clmLateBy"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LateBy"]));
                        dataGridView1.Rows[i].Cells["clmEarlyBy"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EarlyBy"]));
                        dataGridView1.Rows[i].Cells["clmMissedInPunch"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["MissedInPunch"]));
                        dataGridView1.Rows[i].Cells["clmMissedOutPunch"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["MissedInPunch"]));

                        dataGridView1.Rows[i].Cells["clmChangeDepartmentFlag"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentFlag"]));
                        dataGridView1.Rows[i].Cells["clmChangeDepartmentId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentId"]));
                        dataGridView1.Rows[i].Cells["clmChangeLocationId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeLocationtId"]));

                        objPC.LeaveType = string.Empty;
                        objAL.LeaveDetailsEmployees();

                        if (objPC.LeaveTypeId == 0)
                        {
                            objPC.LeaveTypeId = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LeaveTypeId"])));
                            objRL.GetLeaveDetailsEmployees_ByLeaveId();
                            dataGridView1.Rows[i].Cells["clmLeave"].Value = objPC.LeaveType.ToString();
                            dataGridView1.Rows[i].Cells["clmLeaveTypeId"].Value = objPC.LeaveTypeId.ToString();
                        }

                        dataGridView1.Rows[i].Cells["clmLeaveTypeId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LeaveTypeId"]));
                        dataGridView1.Rows[i].Cells["clmLeaveDuration"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LeaveDuration"]));
                        //dataGridView1.Rows[i].Cells["clmWeeklyOff"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["WeeklyOff"]));

                        //dataGridView1.Rows[i].Cells["clmHoliday"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Holiday"]));
                        //dataGridView1.Rows[i].Cells["clmLeaveRemarks"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LeaveRemarks"]));
                        dataGridView1.Rows[i].Cells["clmPunchRecords"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["PunchRecords"]));
                        dataGridView1.Rows[i].Cells["clmLossOfHours"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LossOfHours"]));
                        dataGridView1.Rows[i].Cells["clmRemarksGrid"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Remarks"]));

                        //Leave Working
                        objPC.EmployeeId = Convert.ToInt32(ds.Rows[i]["EmployeeId"].ToString());
                        //objPC.CheckDate = objPC.AttendanceDate;


                        dataGridView1.Rows[i].Cells["clmChangeDepartmentFlag"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentFlag"]));
                        objPC.ChangeDepartmentFlag = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentFlag"])));

                        if (objPC.ChangeDepartmentFlag == 1)
                        {
                            objPC.ChangeLocationtId = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeLocationtId"])));
                            objPC.ChangeDepartmentId = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentId"])));


                            dataGridView1.Rows[i].Cells["clmChangeLocation"].Value = objRL.Fill_Location_By_LocationId(objPC.ChangeLocationtId);
                            dataGridView1.Rows[i].Cells["clmDepartmentChange"].Value = objRL.Fill_Department_By_DepartmentId(objPC.ChangeDepartmentId);
                        }

                        objPC.LateBy = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LateBy"])));
                        dataGridView1.Rows[i].Cells["clmLateBy"].Value = objPC.LateBy.ToString();

                        if (objPC.LateBy > 0)
                        {
                            if (objPC.FlexibleHoursFlag == 0)
                            {
                                objRL.Set_Error_Color(dataGridView1, i, "clmInTime", Color.FromName(BusinessResources.LS_Error_Color));
                                objRL.Set_Error_Color(dataGridView1, i, "clmLateBy", Color.FromName(BusinessResources.LS_Error_Color));
                            }
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells["clmLateBy"].Value = "0";
                            objRL.Set_Error_Color(dataGridView1, i, "clmInTime", Color.White);
                            objRL.Set_Error_Color(dataGridView1, i, "clmLateBy", Color.White);
                        }

                        objPC.EarlyBy = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EarlyBy"])));
                        dataGridView1.Rows[i].Cells["clmEarlyBy"].Value = objPC.EarlyBy.ToString();
                        if (objPC.EarlyBy > 0)
                        {
                            if (objPC.FlexibleHoursFlag == 0)
                            {
                                objRL.Set_Error_Color(dataGridView1, i, "clmOutTime", Color.FromName(BusinessResources.LS_Error_Color));
                                objRL.Set_Error_Color(dataGridView1, i, "clmEarlyBy", Color.FromName(BusinessResources.LS_Error_Color));
                            }
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells["clmEarlyBy"].Value = "0";
                            objRL.Set_Error_Color(dataGridView1, i, "clmOutTime", Color.White);
                            objRL.Set_Error_Color(dataGridView1, i, "clmEarlyBy", Color.White);
                        }

                        //dtpAttendanceDate.Value = objPC.AttendanceDate;
                         
                        //if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[i]["LateBy"].ToString())))
                        //{
                        //    LateBy = Convert.ToDouble(ds.Rows[i]["LateBy"].ToString());
                        //    dataGridView1.Rows[i].Cells["clmLateBy"].Value = LateBy.ToString();
                        //    if (LateBy > 10)
                        //    {
                        //        objRL.Set_Error_Color(dataGridView1, i, "clmInTime", Color.FromName(BusinessResources.LS_Error_Color));
                        //        objRL.Set_Error_Color(dataGridView1, i, "clmLateBy", Color.FromName(BusinessResources.LS_Error_Color));
                        //        //dataGridView1.Rows[i].Cells[""].Style.BackColor = Color.Yellow;
                        //        //dataGridView1.Rows[i].Cells[""].Style.BackColor = Color.Yellow;
                        //    }
                        //    else
                        //    {
                        //        dataGridView1.Rows[i].Cells["clmLateBy"].Value = "0";
                        //        objRL.Set_Error_Color(dataGridView1, i, "clmInTime", Color.White);
                        //        objRL.Set_Error_Color(dataGridView1, i, "clmLateBy", Color.White);
                        //    }
                        //}

                        //if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[i]["EarlyBy"].ToString())))
                        //{
                        //    EarlyBy = Convert.ToDouble(ds.Rows[i]["EarlyBy"].ToString());
                        //    dataGridView1.Rows[i].Cells["clmEarlyBy"].Value = EarlyBy.ToString();
                        //    if (EarlyBy > 10)
                        //    {
                        //        objRL.Set_Error_Color(dataGridView1, i, "clmOutTime", Color.FromName(BusinessResources.LS_Error_Color));
                        //        objRL.Set_Error_Color(dataGridView1, i, "clmEarlyBy", Color.FromName(BusinessResources.LS_Error_Color));

                        //        //dataGridView1.Rows[i].Cells["clmOutTime"].Style.BackColor = Color.Yellow;
                        //        //dataGridView1.Rows[i].Cells["clmEarlyBy"].Style.BackColor = Color.Yellow;
                        //    }
                        //    else
                        //    {
                        //        dataGridView1.Rows[i].Cells["clmEarlyBy"].Value = "0";
                        //        objRL.Set_Error_Color(dataGridView1, i, "clmOutTime", Color.White);
                        //        objRL.Set_Error_Color(dataGridView1, i, "clmEarlyBy", Color.White);
                        //    }
                        //}

                        //if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[i]["LateComming"].ToString())))
                        //    dataGridView1.Rows[i].Cells["clmLateComming"].Value = Convert.ToString(ds.Rows[i]["LateComming"].ToString());

                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[i]["MissedInPunch"].ToString())))
                        {
                            string MIP = ds.Rows[i]["MissedInPunch"].ToString();
                            dataGridView1.Rows[i].Cells["clmMissedInPunch"].Value = MIP.ToString();

                            if (Convert.ToInt32(MIP) != 0) // == "Yes")
                                objRL.Set_Error_Color(dataGridView1, i, "clmMissedInPunch", Color.FromName(BusinessResources.LS_Error_Color));
                            else
                                objRL.Set_Error_Color(dataGridView1, i, "clmMissedInPunch", Color.White);
                        }

                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[i]["MissedOutPunch"].ToString())))
                        {
                            string MIP = ds.Rows[i]["MissedOutPunch"].ToString();
                            dataGridView1.Rows[i].Cells["clmMissedOutPunch"].Value = MIP.ToString();

                            if (Convert.ToInt32(MIP) != 0) //"Yes")
                                objRL.Set_Error_Color(dataGridView1, i, "clmMissedOutPunch", Color.FromName(BusinessResources.LS_Error_Color));
                            else
                                objRL.Set_Error_Color(dataGridView1, i, "clmMissedInPunch", Color.White);
                        }
                        SrNo++;


                        TOT = TimeSpan.Zero;
                        TOT = TimeSpan.Parse(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["OverTime"])));
                        OTHoursTotal += TOT.Hours;
                    }
                    //Get_Count_All();
                    Get_Count_All_New();
                }
            }
        }

        TimeSpan TOT = TimeSpan.Zero;
        double OTHoursTotal = 0;

        private void cmbLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            objRL.FillDepartment(cmbLocation, cmbDepartment);

            //FillDepartment();
            //if (cmbLocation.SelectedIndex > -1)
            //    objRL.FillDepartment(cmbLocation, cmbDepartment);
        }

        private void cmbDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
           // ClearAll_Location_Department();
            //FillEmployees();
            FillEmployee_Fixed();
        }

        private void ClearAll_Location_Department()
        {
            cmbEmployeeName.SelectedIndex = -1;
            txtEmployeeCode.Text = "";
            txtDesignation.Text = "";

            dtpFromDate.Value = DateTime.Now.Date;
            dtpToDate.Value = DateTime.Now.Date;
         
        }

        private void FillEmployee_Fixed()
        {
            //FillEmployees_Combobox();
            ClearAll_Location_Department();

            if (cmbLocation.SelectedIndex > -1 && cmbDepartment.SelectedIndex > -1)
            {
                objQL.WhereClause_V = " and E.LocationId=" + cmbLocation.SelectedValue + "  and E.DepartmentId=" + cmbDepartment.SelectedValue + " "; // and DM.DesignationCategory NOT IN('" + BusinessResources.USER_TYPE_TRAINEE + "')";
                objQL.SP_Employees_Get_By_All(cmbEmployeeName);

                if (BusinessLayer.UserType == BusinessResources.USER_TYPE_OFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_SUPERVISOR)
                {
                    cmbEmployeeName.Enabled = false;
                    cmbEmployeeName.Text = BusinessLayer.UserName_Full_Static;
                    //objRL.Fill_EmployeeDetails();
                    Fill_EmployeeDetails();
                }
                //objRL.FillEmployees();
            }
        }

        private void FillEmployees()
        {
            if (cmbLocation.SelectedIndex > -1 && cmbDepartment.SelectedIndex > -1)
            {
                objQL.WhereClause_V = string.Empty;
                LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
                objPC.LocationId = LocationId;

                objQL.WhereClause_V = " and E.LocationId=" + cmbLocation.SelectedValue + "  and E.DepartmentId=" + cmbDepartment.SelectedValue + "";
                objQL.SP_Employees_Get_By_All(cmbEmployeeName);
            }
        }

        private void cmbEmployeeName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_EmployeeDetails();
        }

        private void btnView_Click(object sender, EventArgs e)
        {

        }

    }
}
