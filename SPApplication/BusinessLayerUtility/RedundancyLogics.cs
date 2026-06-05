using BusinessLayerUtility;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using System.Windows.Forms;
//using static System.Windows.Forms.AxHost;

namespace BusinessLayerUtility
{
    public class RedundancyLogics
    {
        BusinessLayer objBL = new BusinessLayer();
        ToolTip objTT = new ToolTip();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        public static string Sex_Static;
        public static double SerumCreatinine;

        public static string EmailAddress_Static;
        public static string EmailPassword_Static;

        public static string SystemDateFormat;
        public static string DateFormatMMDDYYYY = BusinessResources.DATEFORMATMMDDYYYY; //"MM/dd/yyyy";

        private static bool dcflagclick;
        private static string setstringdoubleclick;

        public string RL_ExcelFormatPath = "";
        public string RL_DestinationPath = "";

        public string Form_ReportFileName = "";
        public string Form_DestinationReportFilePath = "";
        public string Form_ExcelFileName = "";
        public bool isPDF = false;

        string CurrentDate_String = DateTime.Now.Date.ToString("dd-MM-yyyy");
        public string SetDateFormat_ForReport = "dd-MM-yyyy";

        public string SetDateFormat = BusinessResources.DATEFORMATMMDDYYYY;

        public static int patientid;

        public string Salutation = "", LastName = "", EmailAddress = "", FileRackNo = "", DoctorName = "", Sex = "", OutputLabel = "";

        public string[] StatusArray = { "½P", "A", "A(OD)", "H", "H½P", "HA", "HP", "P", "P(OD)", "WO", "WO½P", "WOP" };

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

        public int ConvertToMinutes(string TimeO)
        {
            int totalMinutes = 0;
            TimeSpan ts = TimeSpan.Parse(TimeO);
            return totalMinutes = (int)ts.TotalMinutes;
        }

        public void ReportTypeOptions(ComboBox cmb)
        {
            cmb.Items.Clear();
            cmb.Items.Add("Today");
            cmb.Items.Add("This Week");
            cmb.Items.Add("Last Week");
            cmb.Items.Add("This Month");
            cmb.Items.Add("Last Month");
            cmb.Items.Add("This Year");
            cmb.Items.Add("Last Year");
            //Today
            //This Week
            //Last Week
            //This Month
            //Last Month
            //This Year
            //Last Year
        }


        public string InvertedText(string ValueText)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(ValueText)))
                return ValueText.Replace("'", "''");
            else
                return ValueText = "";
        }

        public void Get_EmployeeId_By_EmployeeCode(int EID)
        {
            objPC.EmployeeId = 0;
            DataTable dt = new DataTable();
            objBL.Query = "select EmployeeId from employees where CancelTag=0 and EmployeeCode=" + EID + " ";
            dt = objBL.ReturnDataTable();
            if (dt.Rows.Count > 0)
                objPC.EmployeeId = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(dt.Rows[0]["EmployeeId"])));
        }

        public DateTime Convert_To_Time(string ValueText)
        {
            DateTime dateTime1=DateTime.Now; 
            DateTime baseDate = new DateTime(1899, 12, 30);
            double Value1 = 0;
            if (!string.IsNullOrEmpty(Convert.ToString(ValueText)))
            {
                Value1 = Convert.ToDouble(Convert.ToString(ValueText));
                dateTime1 = baseDate.AddDays(Value1);
            }
            return dateTime1;
        }

        public void CheckBox_Checked(string YN, CheckBox cb)
        {
            if (YN == "Yes")
                cb.Checked = true;
            else
                cb.Checked = false;
        }
        public void CheckBox_Checked_ByZeroOne(int YN, CheckBox cb)
        {
            if (YN == 1)
                cb.Checked = true;
            else
                cb.Checked = false;
        }
        public void GetTotalMemo_By_Subject()
        {
            objPC.MemoCount = 0;

            DataSet ds = new DataSet();
            objBL.Query = "select MemoTemplateMasterId,MemoSubject from memotemplatemaster where LetterType='Memo' and MemoSubject='"+objPC.MemoSubject+"' order by MemoSubject asc";
            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    objPC.MemoTemplateMasterId = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["MemoTemplateMasterId"])));
                    Get_Memo_Count_By_EmployeeId_MemoId();
                }
            }
        }
        public void CheckBox_Checked_TextBox2EnableTrue(CheckBox cb, TextBox t1, TextBox t2)
        {
            if (cb.Checked)
            {
                t1.Enabled = true;
                t2.Enabled = true;
            }
            else
            {
                t1.Enabled = false;
                t2.Enabled = false;
            }
        }
        public void CheckBox_SetString(ref string YN, CheckBox cb)
        {
            if (cb.Checked)
                YN = "Yes";
            else
                YN = "No";
        }

        // Get Masters List Box

        List<string> TableColumnList = new List<string>();
        string CName = string.Empty;
        public void GetColumnNames(string TName)
        {
            objBL.Connect();
            DataTable schema = null;
            using (var con = new MySql.Data.MySqlClient.MySqlConnection(objBL.conString))
            {
                using (var schemaCommand = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM " + TName + "", con))
                {
                    con.Open();
                    using (var reader = schemaCommand.ExecuteReader(CommandBehavior.SchemaOnly))
                    {
                        schema = reader.GetSchemaTable();
                    }
                }
            }

            for (int i = 0; i < schema.Rows.Count; i++)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(schema.Rows[i]["ColumnName"])))
                {
                    CName = schema.Rows[i]["ColumnName"].ToString();
                    TableColumnList.Add(CName);
                }
            }

            Column_Object_Set();

            //foreach (DataRow col in schema.Rows)
            //{
            //    //TableColumnList.Add(col.Field<String>("ColumnName"));
            //    string CName = col.Field<String>("ColumnName");
            //    //A1 = col.Field<String>("ColumnName");
            //    //MessageBox.Show("ColumnName={0}", col.Field<String>("ColumnName"));

            //    //TableColumnList.Add(A1);
            //    // Console.WriteLine("ColumnName={0}", col.Field<String>("ColumnName"));
            //}
        }

        string ColumnNamesQuery = string.Empty;
        string ColumnObject = string.Empty;
        public void Column_Object_Set()
        {
            ColumnNamesQuery = string.Empty;
            ColumnObject = "AR.";

            if (TableColumnList.Count > 0)
            {
                for (int i = 0; i < TableColumnList.Count; i++)
                {
                    ColumnNamesQuery += ColumnObject + TableColumnList[i] + ",";
                }

                if (!string.IsNullOrEmpty(Convert.ToString(ColumnNamesQuery)))
                    ColumnNamesQuery = ColumnNamesQuery.Remove(ColumnNamesQuery.Length - 1);
            }
        }

        // Get Masters List Box
        public void Fill_Status_CheckedListBox(CheckedListBox clb)
        {
            clb.DataSource = null;
            DataSet ds = new DataSet();
            objBL.Query = "select StatusId,Status,Description from StatusMaster where CancelTag=0";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                clb.DataSource = ds.Tables[0];
                clb.DisplayMember = "Description";
                clb.ValueMember = "StatusId";
            }
        }

        public void Fill_Status_ComboBox(ComboBox cmb)
        {
            cmb.DataSource = null;
            DataSet ds = new DataSet();
            objBL.Query = "select StatusId,Status,Description from StatusMaster where CancelTag=0";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "Status";
                cmb.ValueMember = "StatusId";
                cmb.SelectedIndex = -1;
            }
        }

        public void Get_Designation_By_DesignationId(int DesignationId)
        {
            DataSet ds = new DataSet();
            objBL.Query = "select DesignationId,Designation from designationmaster where CancelTag=0 and DesignationId=" + DesignationId + "";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Designation"].ToString())))
                    objPC.Designation = ds.Tables[0].Rows[0]["Designation"].ToString();
                else
                    objPC.Designation = "";
            }
        }

        public void Get_Designation_Details_By_DesignationId(int DesignationId)
        {
            DataSet ds = new DataSet();
            objBL.Query = "select DesignationId,Designation,Grade,DesignationCategory,Leaves,OvertimeFlag from designationmaster where CancelTag=0 and DesignationId=" + DesignationId + "";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                objPC.Designation = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Designation"]));
                objPC.DesignationCategory = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["DesignationCategory"]));
                objPC.OvertimeFlag = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["OvertimeFlag"])));
                objPC.Leaves = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Leaves"])));

            }
        }

        public void Fill_Department_CheckedListBox(CheckedListBox clb)
        {
            clb.DataSource = null;
            DataSet ds = new DataSet();
            objBL.Query = "select DepartmentId,Department from departmentmaster where CancelTag=0 order by Department asc";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                clb.DataSource = ds.Tables[0];
                clb.DisplayMember = "Department";
                clb.ValueMember = "DepartmentId";
            }
        }

        //public int Get_Department_ID_By_DepartmentName(string DepartmentName_F)
        //{
        //    int DepartmentId=0;
        //    DataSet ds = new DataSet();
        //    objBL.Query = "select DepartmentId,Department from departmentmaster where CancelTag=0 and Department='"+DepartmentName_F+"'";
        //    ds = objBL.ReturnDataSet();
        //    if (ds.Tables[0].Rows.Count > 0)
        //        DepartmentId = Convert.ToInt32(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Department"])));

        //    return DepartmentId;
        //}

        //public int Get_DesignationId_By_DesignationName(string Designation_F)
        //{
        //    int DesignationId = 0;
        //    DataSet ds = new DataSet();
        //    objBL.Query = "select DesignationId,Designation from designationmaster where CancelTag=0 and Designation='" + Designation_F + "'";
        //    ds = objBL.ReturnDataSet();
        //    if (ds.Tables[0].Rows.Count > 0)
        //        DesignationId = Convert.ToInt32(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Designation"])));

        //    return DesignationId;
        //}

        public int LocationId_Dept = 0, DepartmentId_Dept = 0;
        public string DepartmentName_Depat = string.Empty;

        public void Get_Department_ID_Name(string DeptIDName, string SearchBy)
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            ds = objQL.SP_DepartmentMaster_ById(DeptIDName, SearchBy);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["DepartmentId"].ToString())))
                    DepartmentId_Dept = Convert.ToInt32(ds.Tables[0].Rows[0]["DepartmentId"].ToString());
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Department"].ToString())))
                    DepartmentName_Depat = Convert.ToString(ds.Tables[0].Rows[0]["Department"].ToString());
            }
        }

        public void Fill_Department_CheckedListBox_By_Location(CheckedListBox clb, int LocationId)
        {
            clb.DataSource = null;
            DataSet ds = new DataSet();
            objBL.Query = "select DepartmentId,Department from departmentmaster where CancelTag=0 and LocationId=" + LocationId + "";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                clb.DataSource = ds.Tables[0];
                clb.DisplayMember = "Department";
                clb.ValueMember = "DepartmentId";
            }
        }
        public string Fill_Department_By_DepartmentId(int DepartmentId)
        {
            string DName = string.Empty;

            DataSet ds = new DataSet();
            objBL.Query = "select DepartmentId,Department from departmentmaster where CancelTag=0 and DepartmentId=" + DepartmentId + "";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Department"])))
                    DName = Convert.ToString(ds.Tables[0].Rows[0]["Department"].ToString());
            }

            return DName;
        }
        public void Fill_Status_For_Manpower(ComboBox cmb)
        {
            string StatusNames = string.Empty;

            if (BusinessLayer.UserType == BusinessResources.USER_TYPE_SENIOROFFICER)
                StatusNames = " and AttendanceStatus IN('" + BusinessResources.LS_Pending + "','" + BusinessResources.LS_InchargeApproved + "','" + BusinessResources.LS_Remarks + "')";
            else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER || BusinessLayer.UserType == BusinessResources.USER_TYPE_PLANTHEAD)
                StatusNames = " and AttendanceStatus IN('" + BusinessResources.LS_Pending + "','" + BusinessResources.LS_ManagerApproved + "','" + BusinessResources.LS_Remarks + "','" + BusinessResources.LS_Reject + "')";
            else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_HROFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR)
                StatusNames = " and AttendanceStatus IN('" + BusinessResources.LS_HRApproved + "','" + BusinessResources.LS_ManagerApproved + "','" + BusinessResources.LS_InchargeApproved + "','" + BusinessResources.LS_Completed + "','" + BusinessResources.LS_Pending + "','" + BusinessResources.LS_Remarks + "','" + BusinessResources.LS_Reject + "')";
            else
                StatusNames = "";
             
            DataSet ds = new DataSet();
            objBL.Query = "select AttendanceStatusId,AttendanceStatus from attendancestatusmaster where CancelTag=0 " + StatusNames + " and AttendanceStatus NOT IN('Error','HR Approved','Incharge Approved','Manager Approved') order by AttendanceStatus asc";
            ds = objBL.ReturnDataSet();
            // ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "AttendanceStatus";
                cmb.ValueMember = "AttendanceStatusId";
                cmb.SelectedIndex = -1;
            }
        }
        public void Fill_Approval_Status(ComboBox cmb)
        {
            string StatusNames = string.Empty;

            if (BusinessLayer.UserType == BusinessResources.USER_TYPE_SENIOROFFICER)
                StatusNames = " and AttendanceStatus IN('" + BusinessResources.LS_InchargeApproved + "','" + BusinessResources.LS_Remarks + "')";
            else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER || BusinessLayer.UserType == BusinessResources.USER_TYPE_PLANTHEAD)
                //StatusNames = " and AttendanceStatus IN('" + BusinessResources.LS_Pending + "','" + BusinessResources.LS_ManagerApproved + "','" + BusinessResources.LS_Remarks + "','" + BusinessResources.LS_Reject + "')";
            StatusNames = " and AttendanceStatus IN('" + BusinessResources.LS_ManagerApproved + "','" + BusinessResources.LS_Remarks + "','" + BusinessResources.LS_Reject + "')";
            else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_HROFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR)
                StatusNames = " and AttendanceStatus IN('" + BusinessResources.LS_HRApproved + "','" + BusinessResources.LS_ManagerApproved + "','" + BusinessResources.LS_InchargeApproved + "','" + BusinessResources.LS_Completed + "','" + BusinessResources.LS_Pending + "','" + BusinessResources.LS_Remarks + "','" + BusinessResources.LS_Reject + "')";
            else
                StatusNames = "";


            //if (BusinessLayer.UserType == BusinessResources.USER_TYPE_INCHARGE)
            //    StatusNames = " and AttendanceStatus IN('" + BusinessResources.LS_HRApproved + "','" + BusinessResources.LS_InchargeApproved + "','" + BusinessResources.LS_Pending + "','" + BusinessResources.LS_Remarks + "')";
            //else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER || BusinessLayer.UserType == BusinessResources.USER_TYPE_PLANTHEAD)
            //    StatusNames = " and AttendanceStatus IN('" + BusinessResources.LS_HRApproved + "','" + BusinessResources.LS_ManagerApproved + "','" + BusinessResources.LS_Pending + "','" + BusinessResources.LS_Remarks + "','" + BusinessResources.LS_Reject + "')";
            //else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMIN)
            //    StatusNames = " and AttendanceStatus IN('" + BusinessResources.LS_HRApproved + "','" + BusinessResources.LS_ManagerApproved + "','" + BusinessResources.LS_InchargeApproved + "','" + BusinessResources.LS_Completed + "','" + BusinessResources.LS_Pending + "','" + BusinessResources.LS_Remarks + "','" + BusinessResources.LS_Reject + "')";
            //else
            //    StatusNames = "";

            DataSet ds = new DataSet();
            objBL.Query = "select AttendanceStatusId,AttendanceStatus from attendancestatusmaster where CancelTag=0 " + StatusNames + " order by AttendanceStatus asc";
            ds = objBL.ReturnDataSet();
            // ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "AttendanceStatus";
                cmb.ValueMember = "AttendanceStatusId";
                cmb.SelectedIndex = -1;
            }

            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Department"])))
            //        DName = Convert.ToString(ds.Tables[0].Rows[0]["Department"].ToString());
            //}

            //return DName;

            //cmbAttendanceStatus.Items.Clear();
            //cmbAttendanceStatus.Enabled = true;
            //if (BusinessLayer.UserType == BusinessResources.USER_TYPE_INCHARGE)
            //{
            //    cmbAttendanceStatus.Items.Add(BusinessResources.LS_InchargeApproved);
            //    cmbAttendanceStatus.Items.Add(BusinessResources.LS_Pending);
            //    cmbAttendanceStatus.Items.Add(BusinessResources.LS_Remarks);
            //    GridViewReadOnly_EnableTrueFalse(true);
            //}
            //else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER || BusinessLayer.UserType == BusinessResources.USER_TYPE_PLANTHEAD)
            //{
            //    cmbAttendanceStatus.Items.Add(BusinessResources.LS_ManagerApproved);
            //    cmbAttendanceStatus.Items.Add(BusinessResources.LS_Pending);
            //    cmbAttendanceStatus.Items.Add(BusinessResources.LS_Remarks);
            //    cmbAttendanceStatus.Items.Add(BusinessResources.LS_Reject);
            //    GridViewReadOnly_EnableTrueFalse(true);
            //}
            //else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMIN)
            //{
            //    cmbAttendanceStatus.Items.Add(BusinessResources.LS_HRApproved);
            //    cmbAttendanceStatus.Items.Add(BusinessResources.LS_ManagerApproved);
            //    cmbAttendanceStatus.Items.Add(BusinessResources.LS_InchargeApproved);
            //    cmbAttendanceStatus.Items.Add(BusinessResources.LS_Completed);
            //    cmbAttendanceStatus.Items.Add(BusinessResources.LS_Pending);
            //    cmbAttendanceStatus.Items.Add(BusinessResources.LS_Remarks);
            //    cmbAttendanceStatus.Items.Add(BusinessResources.LS_Reject);
            //    GridViewReadOnly_EnableTrueFalse(false);
            //}
            //else
            //    cmbAttendanceStatus.Items.Clear();
        }
        public void Fill_LeaveType(ComboBox cmb, bool lType)
        {
            string WClause = string.Empty;

            if (lType)
                WClause = " LeaveTypeFName NOT IN('Compensation Off','Compensation Off Used')";
            else
                WClause = " LeaveTypeFName IN('Compensation Off','Compensation Off Used')";

            DataSet ds = new DataSet();
            objBL.Query = "select * from leavetypes where " + WClause + " and CancelTag=0"; // LeaveTypeFName IN('Compensation Off','Compensation Off Used')";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "LeaveTypeFName";
                cmb.ValueMember = "LeaveTypeId";
                cmb.SelectedIndex = -1;
            }
        }

        //public void Fill_LeaveType_CompOff(ComboBox cmb)
        //{
        //    DataSet ds = new DataSet();
        //    objBL.Query = "select * from leavetypes where LeaveTypeFName NOT IN('Compensation Off','Compensation Off Used')";
        //    ds = objBL.ReturnDataSet();
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        cmb.DataSource = ds.Tables[0];
        //        cmb.DisplayMember = "LeaveTypeFName";
        //        cmb.ValueMember = "LeaveTypeId";
        //        cmb.SelectedIndex = -1;
        //    }
        //}

        public void FillLocation(ComboBox cmbLocation, ComboBox cmbDepartment)
        {
            //ADMINISTRATOR     BusinessResources.USER_TYPE_ADMINISTRATOR
            //CLEANER           BusinessResources.USER_TYPE_CLEANER
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

            objQL.WhereClause_V = string.Empty;

            if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR || BusinessLayer.UserType == BusinessResources.USER_TYPE_HROFFICER)
                objQL.WhereClause_V = "";
            else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER)
            {
                //8,17,5076,23,41,19,55,100001,100002
                if (BusinessLayer.UserName_Static == "3" || BusinessLayer.UserName_Static == "8" || BusinessLayer.UserName_Static == "17" || BusinessLayer.UserName_Static == "19" || BusinessLayer.UserName_Static == "23" || BusinessLayer.UserName_Static == "41" || BusinessLayer.UserName_Static == "55" || BusinessLayer.UserName_Static == "5076" || BusinessLayer.UserName_Static == "100001" || BusinessLayer.UserName_Static == "100002")
                {
                    FlagCheck = true;
                    Fill_Location_ComboBox(cmbLocation);
                    cmbLocation.Text = BusinessLayer.LocationName;
                    objPC.LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
                    Fill_Department_ComboBox_By_Location(cmbDepartment, Convert.ToInt32(cmbLocation.SelectedValue));
                    cmbDepartment.Text = BusinessLayer.Department;
                    objPC.DepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue);
                    cmbLocation.Enabled = false;
                    cmbDepartment.Enabled = false;
                }
                else
                    objQL.WhereClause_V = " and lwd.PlantHeadId=" + BusinessLayer.EmployeeLoginId_Static + " ";
            }
            else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_SENIOROFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER)
                objQL.WhereClause_V = " and lwd.InchargeId=" + BusinessLayer.EmployeeLoginId_Static + " ";
            else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_OFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_SUPERVISOR)
            {
                FlagCheck = true;
                Fill_Location_ComboBox(cmbLocation);
                cmbLocation.Text = BusinessLayer.LocationName;
                objPC.LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
                Fill_Department_ComboBox_By_Location(cmbDepartment, Convert.ToInt32(cmbLocation.SelectedValue));
                cmbDepartment.Text = BusinessLayer.Department;
                objPC.DepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue);
                cmbLocation.Enabled = false;
                cmbDepartment.Enabled = false;
            }
            //else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER)
            //{
               
            //}
            else
            {
                ShowMessage(38, 4);
                return;
            }

            if (!FlagCheck)
            {
                objQL.Fill_Location_By_EmployeeId(cmbLocation);
                cmbLocation.Enabled = true;
                cmbLocation.SelectedIndex = -1;
                cmbDepartment.SelectedIndex = -1;
            }

            //if (BusinessLayer.UserType == BusinessResources.USER_TYPE_OFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_SUPERVISOR)
            //{
            //    cmbLocation.Text = BusinessLayer.LocationName;
            //    FillDepartment(cmbLocation, cmbDepartment);
            //    cmbDepartment.Text = BusinessLayer.Department;
            //    cmbLocation.Enabled = false;
            //    cmbDepartment.Enabled = false;
            //}
            //else
            //{
            //    cmbLocation.Enabled = true;
            //    cmbLocation.SelectedIndex = -1;
            //    cmbDepartment.SelectedIndex = -1;
            //}


            //if (!FlagCheck)
            //{

            //}
            //else
            //{
            //    cmbLocation.Enabled = false;
            //    cmbDepartment.Enabled = false;
            //    ////cmbEmployeeName.Enabled = false;
            //    //objRL.Fill_Location_ComboBox(cmbLocation);
            //    //cmbLocation.Text = BusinessLayer.LocationName;
            //    //objPC.LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
            //    //objRL.Fill_Department_ComboBox_By_Location(cmbDepartment, Convert.ToInt32(cmbLocation.SelectedValue));
            //    //cmbDepartment.Text = BusinessLayer.Department;
            //    //cmbEmployeeName.Text = BusinessLayer.UserName_Full_Static;
            //}
        }
        public void FillDepartment(ComboBox cmbLocation, ComboBox cmbDepartment)
        {
            if (cmbLocation.SelectedIndex > -1)
            {
                objQL.WhereClause_V = string.Empty;
                objPC.LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
                objPC.InchargeId = BusinessLayer.EmployeeLoginId_Static;
                objQL.WhereClause_V = string.Empty;


                if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR || BusinessLayer.UserType == BusinessResources.USER_TYPE_HROFFICER)
                    objQL.WhereClause_V = " and lwd.LocationId=" + objPC.LocationId + " ";
                else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER)
                    objQL.WhereClause_V = " and lwd.PlantHeadId=" + BusinessLayer.EmployeeLoginId_Static + " and lwd.LocationId=" + objPC.LocationId + " ";
                else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_SENIOROFFICER)
                    objQL.WhereClause_V = " and lwd.InchargeId=" + BusinessLayer.EmployeeLoginId_Static + " and lwd.LocationId=" + objPC.LocationId + " ";
                else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_OFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_SUPERVISOR)
                    objQL.WhereClause_V = " and lwd.LocationId=" + objPC.LocationId + " ";
                //objQL.WhereClause_V = " and lwd.InchargeId=" + BusinessLayer.EmployeeLoginId_Static + " and lwd.LocationId=" + objPC.LocationId + " ";
                else
                {
                    ShowMessage(38, 4);
                    return;
                }
                objQL.Fill_Department_By_EmployeeId(cmbDepartment);
            }
        }
        public void FillDepartment_CheckListBox(ComboBox cmbLocation, CheckedListBox cmbDepartment)
        {
            if (cmbLocation.SelectedIndex > -1)
            {
                objQL.WhereClause_V = string.Empty;
                objPC.LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
                objPC.InchargeId = BusinessLayer.EmployeeLoginId_Static;
                objQL.WhereClause_V = string.Empty;

                if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR || BusinessLayer.UserType == BusinessResources.USER_TYPE_HROFFICER)
                    objQL.WhereClause_V = " and lwd.LocationId=" + objPC.LocationId + " ";
                else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER)
                    objQL.WhereClause_V = " and lwd.PlantHeadId=" + BusinessLayer.EmployeeLoginId_Static + " and lwd.LocationId=" + objPC.LocationId + " ";
                else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_SENIOROFFICER)
                    objQL.WhereClause_V = " and lwd.InchargeId=" + BusinessLayer.EmployeeLoginId_Static + " and lwd.LocationId=" + objPC.LocationId + " ";
                else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_OFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_SUPERVISOR)
                    objQL.WhereClause_V = " and lwd.LocationId=" + objPC.LocationId + " ";
                //objQL.WhereClause_V = " and lwd.InchargeId=" + BusinessLayer.EmployeeLoginId_Static + " and lwd.LocationId=" + objPC.LocationId + " ";
                else
                {
                    ShowMessage(38, 4);
                    return;
                }
                objQL.Fill_Department_By_EmployeeId_CheckListBox(cmbDepartment);
            }
        }

        //public void FillEmployees_Combobox()
        //{
        //    if (BusinessLayer.UserType == BusinessResources.USER_TYPE_HROFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR)
        //    {

        //    }

        //    if (!string.IsNullOrEmpty(Convert.ToString(BusinessLayer.Designation)) && !string.IsNullOrEmpty(Convert.ToString(BusinessLayer.Department)))
        //    {
        //        cmbEmployeeName.Enabled = true;

        //        EmpDesignation = string.Empty;
        //        EmpDesignation = BusinessLayer.Designation.ToString();
        //        EmpDepartment = BusinessLayer.Department.ToString();
        //        objPC.DepartmentId = BusinessLayer.DepartmentId;

        //        if (BusinessLayer.UserType == BusinessResources.USER_TYPE_OFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_SUPERVISOR)
        //        {
        //            objQL.SP_Employees_ComboBox_By_Department(cmbEmployeeName);
        //            cmbEmployeeName.Text = BusinessLayer.UserName_Full_Static.ToString();
        //            cmbEmployeeName.Enabled = false;
        //            Fill_EmployeeDetails();
        //        }
        //        else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_SENIOROFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_SUPERVISOR)
        //        {
        //            objQL.SP_Employees_ComboBox_By_Department(cmbEmployeeName);
        //        }
        //        else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_HROFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR)
        //        {
        //            objQL.Fill_Master_ComboBox(cmbEmployeeName, "employees");
        //            //cmbEmployeeName.Text = BusinessLayer.UserName_Full_Static.ToString();
        //            Fill_EmployeeDetails();
        //        }
        //        else
        //        {

        //        }


        //        //if (EmpDesignation == BusinessResources.USER_TYPE_INCHARGE || EmpDesignation == BusinessResources.USER_TYPE_OFFICER || EmpDesignation == BusinessResources.USER_TYPE_PLANTHEAD || EmpDesignation == BusinessResources.USER_TYPE_MANAGER)
        //        //{
        //        //    objQL.SP_Employees_ComboBox_By_Department(cmbEmployeeName);

        //        //    //objQL.SP_Employees_Get_By_All(BusinessResources.SearchBy_DesignationId, objPC.DepartmentId.ToString(), cmbEmployeeName, "");

        //        //    if (EmpDesignation == BusinessResources.USER_TYPE_OFFICER || EmpDesignation == BusinessResources.USER_TYPE_MANAGER)
        //        //    {
        //        //        objQL.Fill_Master_ComboBox(cmbEmployeeName, "employees");
        //        //        cmbEmployeeName.Text = BusinessLayer.UserName_Full_Static.ToString();
        //        //        Fill_EmployeeDetails();
        //        //        cmbEmployeeName.Enabled = false;
        //        //    }
        //        //    else
        //        //    {
        //        //        cmbEmployeeName.Enabled = true;
        //        //    }
        //        //}
        //    }
        //}                     

        public void Set_Employee_Profile_Rich_Text_Box(RichTextBox rtb)
        {
            objPC.EmployeeProfile = string.Empty;

            objPC.EmployeeProfile = "Official Information " + "\n" +
                                    "Employee Code:\t\t" + objPC.EmployeeCode + "\n" +
                                    "Employee Name:\t\t" + objPC.EmployeeName + "\n" +
                                    "Location:\t\t" + objPC.LocationName + "\n" +
                                    "Department:\t\t" + objPC.DepartmentName + "\n" +
                                    "Designation:\t\t" + objPC.Designation + "\n" +
                                    //"Date of Joining:\t\t" + objPC.DOJ.ToString(BusinessResources.DATEFORMATDDMMMYYYY) + "\n" +
                                    "Job Profile:\t\t" + objPC.JobProfile + "\n" +
                                    //"Roll:\t\t\t" + objPC.ContractorName + "\n" +
                                    //"Weekly Off:\t\t" + objPC.WeeklyOff1Value + "\n" +
                                    //"Shift Group:\t\t" + objPC.ShiftGroup + "\n" +
                                    "Official Email ID:\t\t" + objPC.OfficialEmailID + "\n" +
                                    //"Category:\t\t" + objPC.CategoryName + "\n" +
                                    //"Employment Type:\t" + objPC.EmployementType + "\n" +
                                    "PF Member ID No:\t" + objPC.PFMemberIDNo + "\n" +
                                    "UAN Number:\t\t" + objPC.UANNumber + "\n" +
                                    "LWFL IN No:\t\t" + objPC.LWFLINNo + "\n" +
                                    "ESIC No:\t\t\t" + objPC.ESICNo + "\n" +
                                    //"Over Time Applicable:\t" + objPC.OverTimeApplicableYesNo + "\n" +
                                    //"Flexible Hours:\t\t" + objPC.FlexibleHoursFlagYesNo + "\n\n" +
                                    "Personal Information " + "\n" +
                                    "Address:\t\t" + objPC.Address + "\n" +
                                    "Mobile Number:\t\t" + objPC.MobileNumber + "\n" +
                                    "Personal Email ID:\t" + objPC.PersonalEmailID + "\n" +
                                    "Date of Birth:\t\t" + objPC.DOB.ToString(BusinessResources.DATEFORMATDDMMMYYYY) + "\n" +
                                    "Aadhar Card Number:\t" + objPC.AadharCardNumber;
            rtb.Text = objPC.EmployeeProfile.ToString();
        }

        public void Fill_EmployeeDetails()
        {
            if (objPC.EmployeeId > 0)
            {
                objPC.EmployeeCode = 0;
                objPC.Designation = "";
                objPC.SalaryAnualNetSalary = "";
                objPC.SalaryMonthlyNetSalary = "";
                objPC.WeeklyOff1Value = "";

                objPC.DOJ = DateTime.Now.Date;

                DataSet ds = new DataSet();
                ds = objQL.SP_Employees_By_EmployeeId();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    objPC.LocationName = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Location Name"]));
                    objPC.DepartmentName = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Department"]));

                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Code"].ToString())))
                        objPC.EmployeeCode = Convert.ToInt32(ds.Tables[0].Rows[0]["Code"].ToString());
                    
                    //if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Employee Name"].ToString())))
                    //    objPC.EmployeeName = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Employee Name"]));

                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Designation"].ToString())))
                        objPC.Designation = ds.Tables[0].Rows[0]["Designation"].ToString();

                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["SalaryAnualNetSalary"].ToString())))
                        objPC.SalaryAnualNetSalary = ds.Tables[0].Rows[0]["SalaryAnualNetSalary"].ToString();
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["SalaryMonthlyNetSalary"].ToString())))
                        objPC.SalaryMonthlyNetSalary = ds.Tables[0].Rows[0]["SalaryMonthlyNetSalary"].ToString();
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["DOJ"].ToString())))
                        objPC.DOJ = Convert.ToDateTime(ds.Tables[0].Rows[0]["DOJ"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["DateOfExit"].ToString())))
                        objPC.DateOfExit = Convert.ToDateTime(ds.Tables[0].Rows[0]["DateOfExit"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["DOR"].ToString())))
                        objPC.DOR = Convert.ToDateTime(ds.Tables[0].Rows[0]["DOR"]);
                   
                    objPC.EmpInital = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["EmpInital"]));
                    objPC.EmployeeName = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Employee Name"]));

                    objPC.Address = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Address"]));

                    objPC.WeeklyOff1Value = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["WeeklyOff1Value"]));

                    objPC.ShiftGroupId = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["ShiftGroupId"])));
                    objPC.CategoryId = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["CategoryId"])));

                    objPC.LocationId = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["LocationId"])));
                    objPC.DepartmentId = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["DepartmentId"])));


                    //for Profile
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["DOB"].ToString())))
                        objPC.DOB = Convert.ToDateTime(ds.Tables[0].Rows[0]["DOB"]);

                    objPC.MobileNumber = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Mobile No"]));
                    objPC.AadharCardNumber = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Aadhar Card Number"]));
                    objPC.PANCardNumber= CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["PAN Card Number"]));

                    objPC.OfficialEmailID = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Official Email"]));
                    objPC.PersonalEmailID = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Personal Email"]));

                    objPC.ContractorName = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Contractor Name"]));
                    objPC.EmployementType = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Employement Type"]));

                    objPC.JobProfile = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["JobProfile"]));
                    Get_Job_Profile_FileName();
                    
                    //objPC.JobProfileFileName = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["JobProfile"]));

                    objPC.CategoryName = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Category F Name"]));

                    objPC.PFMemberIDNo = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["PFMemberIDNo"]));
                    objPC.UANNumber = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["UANNumber"]));
                    objPC.ESICNo = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["ESICNo"]));
                    objPC.LWFLINNo = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["LWFLINNo"]));

                    objPC.ShiftGroup = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["ShiftGroupFName"]));
                    objPC.OverTimeApplicable =CheckNullString_ReturnInt(Convert.ToString(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["OverTimeApplicable"]))));

                    if (objPC.OverTimeApplicable == 1)
                        objPC.OverTimeApplicableYesNo = "Yes";
                    else
                        objPC.OverTimeApplicableYesNo = "No";

                    objPC.FlexibleHoursFlag = CheckNullString_ReturnInt(Convert.ToString(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["FlexibleHoursFlag"]))));

                    if (objPC.FlexibleHoursFlag == 1)
                        objPC.FlexibleHoursFlagYesNo = "Yes";
                    else
                        objPC.FlexibleHoursFlagYesNo = "No";

                    //objPC.LWFLINNo = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["LWFLINNo"]));
                }
            }
        }

        public void Fill_EmployeeDetails_By_EmployeeCode()
        {
            if (objPC.EmployeeCode > 0)
            {
                objPC.EmployeeId = 0;
                objPC.Designation = "";
                objPC.SalaryAnualNetSalary = "";
                objPC.SalaryMonthlyNetSalary = "";
                objPC.WeeklyOff1Value = "";

                objPC.DOJ = DateTime.Now.Date;

                DataSet ds = new DataSet();
                ds = objQL.SP_Employees_By_EmployeeId();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    objPC.EmployeeId=CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["EmployeeId"])));
                    objPC.LocationName = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Location Name"]));
                    objPC.DepartmentName = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Department"]));

                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Code"].ToString())))
                        objPC.EmployeeCode = Convert.ToInt32(ds.Tables[0].Rows[0]["Code"].ToString());

                    //if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Employee Name"].ToString())))
                    //    objPC.EmployeeName = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Employee Name"]));

                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Designation"].ToString())))
                        objPC.Designation = ds.Tables[0].Rows[0]["Designation"].ToString();

                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["SalaryAnualNetSalary"].ToString())))
                        objPC.SalaryAnualNetSalary = ds.Tables[0].Rows[0]["SalaryAnualNetSalary"].ToString();
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["SalaryMonthlyNetSalary"].ToString())))
                        objPC.SalaryMonthlyNetSalary = ds.Tables[0].Rows[0]["SalaryMonthlyNetSalary"].ToString();
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["DOJ"].ToString())))
                        objPC.DOJ = Convert.ToDateTime(ds.Tables[0].Rows[0]["DOJ"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["DateOfExit"].ToString())))
                        objPC.DateOfExit = Convert.ToDateTime(ds.Tables[0].Rows[0]["DateOfExit"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["DOR"].ToString())))
                        objPC.DOR = Convert.ToDateTime(ds.Tables[0].Rows[0]["DOR"]);

                    objPC.EmpInital = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["EmpInital"]));
                    objPC.EmployeeName = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Employee Name"]));

                    objPC.Address = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Address"]));

                    objPC.WeeklyOff1Value = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["WeeklyOff1Value"]));

                    objPC.ShiftGroupId = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["ShiftGroupId"])));
                    objPC.CategoryId = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["CategoryId"])));

                    objPC.LocationId = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["LocationId"])));
                    objPC.DepartmentId = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["DepartmentId"])));


                    //for Profile
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["DOB"].ToString())))
                        objPC.DOB = Convert.ToDateTime(ds.Tables[0].Rows[0]["DOB"]);

                    objPC.MobileNumber = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Mobile No"]));
                    objPC.AadharCardNumber = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Aadhar Card Number"]));
                    objPC.PANCardNumber = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["PAN Card Number"]));

                    objPC.OfficialEmailID = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Official Email"]));
                    objPC.PersonalEmailID = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Personal Email"]));

                    objPC.ContractorName = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Contractor Name"]));
                    objPC.EmployementType = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Employement Type"]));

                    objPC.JobProfile = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["JobProfile"]));
                    Get_Job_Profile_FileName();

                    //objPC.JobProfileFileName = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["JobProfile"]));

                    objPC.CategoryName = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Category F Name"]));

                    objPC.PFMemberIDNo = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["PFMemberIDNo"]));
                    objPC.UANNumber = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["UANNumber"]));
                    objPC.ESICNo = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["ESICNo"]));
                    objPC.LWFLINNo = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["LWFLINNo"]));

                    objPC.ShiftGroup = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["ShiftGroupFName"]));
                    objPC.OverTimeApplicable = CheckNullString_ReturnInt(Convert.ToString(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["OverTimeApplicable"]))));

                    if (objPC.OverTimeApplicable == 1)
                        objPC.OverTimeApplicableYesNo = "Yes";
                    else
                        objPC.OverTimeApplicableYesNo = "No";

                    objPC.FlexibleHoursFlag = CheckNullString_ReturnInt(Convert.ToString(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["FlexibleHoursFlag"]))));

                    if (objPC.FlexibleHoursFlag == 1)
                        objPC.FlexibleHoursFlagYesNo = "Yes";
                    else
                        objPC.FlexibleHoursFlagYesNo = "No";

                    //objPC.LWFLINNo = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["LWFLINNo"]));
                }
            }
        }

        public void Get_Job_Profile_FileName()
        {
            if (!string.IsNullOrEmpty(Convert.ToString(objPC.JobProfile)))
            {
                DataTable dt = new DataTable();
                objBL.Query = "select JobProfileId,JobProfile,JobProfileFileName from jobprofilemaster where CancelTag=0 and JobProfile='" + objPC.JobProfile + "'";
                dt= objBL.ReturnDataTable();
                if (dt.Rows.Count > 0)
                {
                    objPC.JobProfileFileName = CheckNullString(Convert.ToString(dt.Rows[0]["JobProfileFileName"]));
                }
            }
        }


        //public void FillEmployees(ComboBox cmbEmployeeName)
        //{
        //    if (cmbLocation.SelectedIndex > -1 && cmbDepartment.SelectedIndex > -1)
        //    {
        //        objQL.WhereClause_V = string.Empty;
        //        LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
        //        objPC.LocationId = LocationId;

        //        objQL.WhereClause_V = " and E.LocationId=" + cmbLocation.SelectedValue + "  and E.DepartmentId=" + cmbDepartment.SelectedValue + "";
        //        objQL.SP_Employees_Get_By_All(cmbEmployeeName);
        //    }
        //}

        //double TotalLeaves = 0, TotalLeavesAssigned = 0;
        //double BalanceLeavePrevious = 0;
        //double CasualLeave_Count = 0, PaidLeave_Count = 0, SickLeave_Count = 0;


        string QueryColumn = string.Empty;
        string CheckBy = string.Empty;

        string LeaveTypes_Check = string.Empty;

        public void Get_Leaves_Count_All()
        {
            LeaveTypes_Check = string.Empty;

            objPC.SpecialLeave_Count = 0;
            objPC.OpeningLeave_Count = 0;
            objPC.TotalLeave_Count = 0;
            objPC.Balance_Count = 0;
            objPC.PaidLeave_Count = 0;
            objPC.CurrentLeave_Count = 0;
            //objPC.CompOff_Count = 0;
            //objPC.CompOffUsed_Count = 0;
            //objPC.CompOffBalance_Count = 0;
            objPC.TotalApplicableLeave_Count = 0;
            objPC.EnjoyLeave_Count = 0;
            objPC.RevertLeave_Count = 0;
            //Casual Leave
            //Paid Leave
            //Sick Leave
            //NA
            //Marraige Leave
            //Compensation Off
            //Medical
            //Compensation Off Used
            //Revert Leave

            DataSet dsEmpLeaves = new DataSet();
            //objBL.Query = "select TotalLeave,OpeningLeave,BalanceLeave from Employees where CancelTag=0 and EmployeeId=" + objPC.EmployeeId + "";
            objBL.Query = "select OpeningLeave,CurrentLeave,TotalApplicableLeave,EnjoyLeave,BalanceLeave from employees where CancelTag=0 and EmployeeId=" + objPC.EmployeeId + " "; // and FinancialYearId="+objPC.FinancialYearId+" 

            dsEmpLeaves = objBL.ReturnDataSet();
            if (dsEmpLeaves.Tables[0].Rows.Count > 0)
            {
                objPC.OpeningLeave_Count = CheckNullString_ReturnDouble(CheckNullString(Convert.ToString(dsEmpLeaves.Tables[0].Rows[0]["OpeningLeave"])));
                objPC.CurrentLeave_Count = CheckNullString_ReturnDouble(CheckNullString(Convert.ToString(dsEmpLeaves.Tables[0].Rows[0]["CurrentLeave"])));
                objPC.TotalApplicableLeave_Count = CheckNullString_ReturnDouble(CheckNullString(Convert.ToString(dsEmpLeaves.Tables[0].Rows[0]["TotalApplicableLeave"])));
                objPC.EnjoyLeave_Count = CheckNullString_ReturnDouble(CheckNullString(Convert.ToString(dsEmpLeaves.Tables[0].Rows[0]["EnjoyLeave"])));
                objPC.Balance_Count = CheckNullString_ReturnDouble(CheckNullString(Convert.ToString(dsEmpLeaves.Tables[0].Rows[0]["BalanceLeave"])));
                Get_Special_Leave_Count();
                //objPC.SpecialLeave_Count = CheckNullString_ReturnDouble(CheckNullString(Convert.ToString(dsEmpLeaves.Tables[0].Rows[0]["OpeningLeave"])));
            }

            DataSet ds = new DataSet();
            objBL.Query = "select * from leavetypes where CancelTag=0";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                objPC.EnjoyLeave_Count = 0; objPC.RevertLeave_Count = 0; objPC.CompOffBalance_Count = 0; objPC.CompOff_Count = 0; objPC.CompOffUsed_Count = 0; objPC.SearchFlag = false;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    double TCount = 0;
                    LeaveTypes_Check = CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["LeaveTypeFName"]));

                    if (LeaveTypes_Check != "")
                    {
                        DataSet dsCount = new DataSet();
                        objBL.Query = string.Empty;
                        //if (objPC.SearchFlagLeaveCompOff)
                        //{
                        //    if (LeaveTypes_Check == "Compensation Off")
                        //        objBL.Query = "select COALESCE(COUNT(CompOffApplicationId),0) from compoffapplication LA inner join leavetypes LT on LT.LeaveTypeId=LA.LeaveTypeId where LA.CancelTag=0 and LT.CancelTag=0 and LA.EmployeeId=" + objPC.EmployeeId + " and LT.LeaveTypeFName='" + LeaveTypes_Check + "' and LA.CompStatus='" + BusinessResources.LS_Completed + "' and YEAR(LA.EntryDate)=" + DateTime.Now.Date.Year + " ";
                        //    if (LeaveTypes_Check == "Compensation Off Used")
                        //        objBL.Query = "select COALESCE(COUNT(CompOffApplicationId),0) from compoffapplication LA inner join leavetypes LT on LT.LeaveTypeId=LA.LeaveTypeId where LA.CancelTag=0 and LT.CancelTag=0 and LA.EmployeeId=" + objPC.EmployeeId + " and LA.CompOffUsedFlag=1 and LA.CompStatus='" + BusinessResources.LS_Completed + "' and YEAR(LA.EntryDate)=" + DateTime.Now.Date.Year + " ";
                        //}
                        //else
                        //if (LeaveTypes_Check == "Revert Leave")
                        //    //objBL.Query = "select COALESCE(SUM(TotalDays),0) from LeaveApplication LA inner join leavetypes LT on LT.LeaveTypeId=LA.LeaveTypeId where LA.CancelTag=0 and LT.CancelTag=0 and LA.EmployeeId=" + objPC.EmployeeId + " and LA.LeaveStatus='" + BusinessResources.LS_Completed + "' and LA.IsRevertLeave=1 and LA.IsRevertLeave=0 and YEAR(LA.EntryDate) IN (2024,2025) "; //LA.EntryDate = year(" + DateTime.Now.Date.Year + ");"; // and YEAR(LA.EntryDate)=" + DateTime.Now.Date.Year + "
                        //    objBL.Query = "select COALESCE(SUM(TotalDays),0) from LeaveApplication LA inner join leavetypes LT on LT.LeaveTypeId=LA.LeaveTypeId where LA.CancelTag=0 and LT.CancelTag=0 and LA.EmployeeId=" + objPC.EmployeeId + " and LA.LeaveStatus='" + BusinessResources.LS_Completed + "' and LA.IsRevertLeave=1 and LA.IsRevertLeave=0 and LA.FinancialYearId=" + objPC.FinancialYearId + " "; // YEAR(LA.EntryDate) IN (2024,2025) "; //LA.EntryDate = year(" + DateTime.Now.Date.Year + ");"; // and YEAR(LA.EntryDate)=" + DateTime.Now.Date.Year + "
                        //else
                        //    objBL.Query = "select COALESCE(SUM(TotalDays),0) from LeaveApplication LA inner join leavetypes LT on LT.LeaveTypeId=LA.LeaveTypeId where LA.CancelTag=0 and LT.CancelTag=0 and LA.EmployeeId=" + objPC.EmployeeId + " and LT.LeaveTypeFName='" + LeaveTypes_Check + "' and LA.LeaveStatus='" + BusinessResources.LS_Completed + "' and LA.IsRevertLeave=0 and LA.FinancialYearId=" + objPC.FinancialYearId + " "; //and YEAR(LA.EntryDate) IN (2024,2025) "; //=" + DateTime.Now.Date.Year + " "; //LA.EntryDate = year(" + DateTime.Now.Date.Year + ");";

                        if (LeaveTypes_Check == "Revert Leave")
                            //objBL.Query = "select COALESCE(SUM(TotalDays),0) from LeaveApplication LA inner join leavetypes LT on LT.LeaveTypeId=LA.LeaveTypeId where LA.CancelTag=0 and LT.CancelTag=0 and LA.EmployeeId=" + objPC.EmployeeId + " and LA.LeaveStatus='" + BusinessResources.LS_Completed + "' and LA.IsRevertLeave=1 and LA.IsRevertLeave=0 and YEAR(LA.EntryDate) IN (2024,2025) "; //LA.EntryDate = year(" + DateTime.Now.Date.Year + ");"; // and YEAR(LA.EntryDate)=" + DateTime.Now.Date.Year + "
                            objBL.Query = "select COALESCE(Count(*),0) from LeaveApplication LA inner join leavetypes LT on LT.LeaveTypeId=LA.LeaveTypeId where LA.CancelTag=0 and LT.CancelTag=0 and LA.EmployeeId=" + objPC.EmployeeId + " and LA.ApprovalStatusId=2 and LA.IsRevertLeave=1 and LA.IsRevertLeave=0 and LA.FinancialYearId=" + objPC.FinancialYearId + " "; // YEAR(LA.EntryDate) IN (2024,2025) "; //LA.EntryDate = year(" + DateTime.Now.Date.Year + ");"; // and YEAR(LA.EntryDate)=" + DateTime.Now.Date.Year + "
                        else
                            objBL.Query = "select COALESCE(Count(*),0) from LeaveApplication LA inner join leavetypes LT on LT.LeaveTypeId=LA.LeaveTypeId where LA.CancelTag=0 and LT.CancelTag=0 and LA.EmployeeId=" + objPC.EmployeeId + " and LT.LeaveTypeFName='" + LeaveTypes_Check + "' and LA.ApprovalStatusId=2 and LA.IsRevertLeave=0 and LA.FinancialYearId=" + objPC.FinancialYearId + " "; //and YEAR(LA.EntryDate) IN (2024,2025) "; //=" + DateTime.Now.Date.Year + " "; //LA.EntryDate = year(" + DateTime.Now.Date.Year + ");";

                        //objBL.Query = "select COALESCE(SUM(TotalDays),0) from LeaveApplication LA inner join leavetypes LT on LT.LeaveTypeId=LA.LeaveTypeId where LA.CancelTag=0 and LT.CancelTag=0 and LA.EmployeeId=" + objPC.EmployeeId + " and LT.LeaveTypeFName='" + LeaveTypes_Check + "' and LA.LeaveStatus='" + BusinessResources.LS_Completed + "' and LA.IsRevertLeave=0 and YEAR(LA.EntryDate) IN (2024,2025) "; //=" + DateTime.Now.Date.Year + " "; //LA.EntryDate = year(" + DateTime.Now.Date.Year + ");";

                        //objBL.Query = "select COALESCE(SUM(TotalDays),0) from LeaveApplication LA inner join leavetypes LT on LT.LeaveTypeId=LA.LeaveTypeId where LA.CancelTag=0 and LT.CancelTag=0 and LA.EmployeeId=" + objPC.EmployeeId + " and LT.LeaveTypeFName='" + LeaveTypes_Check + "' and LA.LeaveStatus='" + BusinessResources.LS_HRApproved + "'";

                        if (!string.IsNullOrEmpty(Convert.ToString(objBL.Query)))
                        {
                            dsCount = objBL.ReturnDataSet();
                            if (dsCount.Tables[0].Rows.Count > 0)
                            {
                                if (!string.IsNullOrEmpty(Convert.ToString(dsCount.Tables[0].Rows[0][0].ToString())))
                                {
                                    TCount = Convert.ToDouble(dsCount.Tables[0].Rows[0][0].ToString());

                                    if (LeaveTypes_Check == "Casual Leave" || LeaveTypes_Check == "Paid Leave" || LeaveTypes_Check == "Sick Leave" || LeaveTypes_Check == "Marraige Leave" || LeaveTypes_Check == "Medical Leave" || LeaveTypes_Check == "Maternity Leave")
                                        objPC.EnjoyLeave_Count += TCount;

                                    //if (LeaveTypes_Check == "Compensation Off")
                                    //    objPC.CompOff_Count = TCount;

                                    if (LeaveTypes_Check == "Compensation Off Used")
                                        objPC.CompOffUsed_Count = TCount;

                                     if (LeaveTypes_Check == "Revert Leave")
                                         objPC.RevertLeave_Count += TCount;
                                }
                            }
                        }
                        else
                            TCount = 0;
                    }
                }
            }

            objPC.Balance_Count = objPC.TotalApplicableLeave_Count - objPC.EnjoyLeave_Count;
            //objPC.CompOffBalance_Count = objPC.CompOff_Count - objPC.CompOffUsed_Count;

            objBL.Query = "update employees set EnjoyLeave='" + objPC.EnjoyLeave_Count + "',BalanceLeave='" + objPC.Balance_Count + "',CompOff=" + Convert.ToInt32(objPC.CompOff_Count) + ",CompOffUsed=" + Convert.ToInt32(objPC.CompOffUsed_Count) + ",CompOffBalance=" + Convert.ToInt32(objPC.CompOffBalance_Count) + " where CancelTag=0 and EmployeeId=" + objPC.EmployeeId + "";
            Result = objBL.Function_ExecuteNonQuery();
        }

        private void Get_Special_Leave_Count()
        {
            DataSet ds = new DataSet();
            //objBL.Query = "select Sum(TotalDays) from leaveapplication where CancelTag=0 and LeaveTypeId=5 and EmployeeId=" + objPC.EmployeeId + "";
            objBL.Query = "select Count(*) from leaveapplication where CancelTag=0 and LeaveTypeId=5 and EmployeeId=" + objPC.EmployeeId + "";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count >0)
            {
                objPC.SpecialLeave_Count = CheckNullString_ReturnInt(Convert.ToString(ds.Tables[0].Rows[0][0]));
            }
        }

        public void Get_CompOff_Count_All()
        {
            LeaveTypes_Check = string.Empty;
             
            objPC.CompOff_Count = 0;
            objPC.CompOffUsed_Count = 0;
            objPC.CompOffBalance_Count = 0;
            objPC.CompOffExpired_Count = 0;

            //Casual Leave
            //Paid Leave
            //Sick Leave
            //NA
            //Marraige Leave
            //Compensation Off
            //Medical
            //Compensation Off Used
            //Revert Leave

            DataSet ds = new DataSet();
            objBL.Query = "select * from leavetypes where CancelTag=0 and LeaveTypeFName IN('Compensation Off','Compensation Off Used') ";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                objPC.CompOffBalance_Count = 0; objPC.CompOff_Count = 0; objPC.CompOffUsed_Count = 0; objPC.SearchFlag = false;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    double TCount = 0;
                    LeaveTypes_Check = CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["LeaveTypeFName"]));

                    if (LeaveTypes_Check != "")
                    {
                        DataSet dsCount = new DataSet();
                        objBL.Query = string.Empty;
                        if (objPC.SearchFlagLeaveCompOff)
                        {
                            if (LeaveTypes_Check == "Compensation Off")
                                //objBL.Query = "select COALESCE(COUNT(CompOffApplicationId),0) from compoffapplication LA inner join leavetypes LT on LT.LeaveTypeId=LA.LeaveTypeId where LA.CancelTag=0 and LT.CancelTag=0 and LA.EmployeeId=" + objPC.EmployeeId + " and LT.LeaveTypeFName='" + LeaveTypes_Check + "' and LA.CompStatus='" + BusinessResources.LS_Completed + "' and YEAR(LA.EntryDate)=" + DateTime.Now.Date.Year + " ";
                            //objBL.Query = "select COALESCE(COUNT(CompOffApplicationId),0) from compoffapplication LA inner join leavetypes LT on LT.LeaveTypeId=LA.LeaveTypeId where LA.CancelTag=0 and LT.CancelTag=0 and LA.EmployeeId=" + objPC.EmployeeId + " and LT.LeaveTypeFName='" + LeaveTypes_Check + "' and YEAR(LA.EntryDate)=" + DateTime.Now.Date.Year + " ";
                            objBL.Query = "select COALESCE(COUNT(CompOffApplicationId),0) from compoffapplication LA inner join leavetypes LT on LT.LeaveTypeId=LA.LeaveTypeId where LA.CancelTag=0 and LT.CancelTag=0 and LA.EmployeeId=" + objPC.EmployeeId + " and LT.LeaveTypeFName='" + LeaveTypes_Check + "' and FinancialYearId=" +objPC.FinancialYearId + " ";
                            if (LeaveTypes_Check == "Compensation Off Used")
                                //objBL.Query = "select COALESCE(COUNT(CompOffApplicationId),0) from compoffapplication LA inner join leavetypes LT on LT.LeaveTypeId=LA.LeaveTypeId where LA.CancelTag=0 and LT.CancelTag=0 and LA.EmployeeId=" + objPC.EmployeeId + " and LA.CompOffUsedFlag=1 and LA.CompStatus='" + BusinessResources.LS_Completed + "' and YEAR(LA.EntryDate)=" + DateTime.Now.Date.Year + " ";
                            objBL.Query = "select COALESCE(COUNT(CompOffApplicationId),0) from compoffapplication LA inner join leavetypes LT on LT.LeaveTypeId=LA.LeaveTypeId where LA.CancelTag=0 and LT.CancelTag=0 and LA.EmployeeId=" + objPC.EmployeeId + " and LA.CompOffUsedFlag=1 and FinancialYearId=" + objPC.FinancialYearId + "  ";
                        }

                        if (!string.IsNullOrEmpty(Convert.ToString(objBL.Query)))
                        {
                            dsCount = objBL.ReturnDataSet();
                            if (dsCount.Tables[0].Rows.Count > 0)
                            {
                                if (!string.IsNullOrEmpty(Convert.ToString(dsCount.Tables[0].Rows[0][0].ToString())))
                                {
                                    TCount = Convert.ToDouble(dsCount.Tables[0].Rows[0][0].ToString());
                                     
                                    if (LeaveTypes_Check == "Compensation Off")
                                        objPC.CompOff_Count = TCount;

                                    if (LeaveTypes_Check == "Compensation Off Used")
                                        objPC.CompOffUsed_Count = TCount;
                                }
                            }
                        }
                        else
                            TCount = 0;
                    }
                }

                if (objPC.SearchFlagLeaveCompOff)
                {
                    //Expried CompOff
                    // int ExpiredCount = 0;
                    DataSet dsExpired = new DataSet();
                    //objBL.Query = "select COALESCE(COUNT(CompOffApplicationId),0) from compoffapplication LA inner join leavetypes LT on LT.LeaveTypeId=LA.LeaveTypeId where LA.CancelTag=0 and LT.CancelTag=0 and LA.EmployeeId=" + objPC.EmployeeId + " and LA.CompStatus='" + BusinessResources.LS_Completed + "' and YEAR(LA.EntryDate)=" + DateTime.Now.Date.Year + " and ExpiredFlag=1 ";
                    objBL.Query = "select COALESCE(COUNT(CompOffApplicationId),0) from compoffapplication LA inner join leavetypes LT on LT.LeaveTypeId=LA.LeaveTypeId where LA.CancelTag=0 and LT.CancelTag=0 and LA.EmployeeId=" + objPC.EmployeeId + " and FinancialYearId=" + objPC.FinancialYearId + " and IsCompOffExpired=1 ";
                    dsExpired = objBL.ReturnDataSet();
                    if (dsExpired.Tables[0].Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(dsExpired.Tables[0].Rows[0][0].ToString())))
                        {
                            objPC.CompOffExpired_Count = Convert.ToInt32(dsExpired.Tables[0].Rows[0][0].ToString());
                        }
                    }
                }
            }
            objPC.CompOffBalance_Count = (objPC.CompOff_Count - objPC.CompOffUsed_Count)- objPC.CompOffExpired_Count;

            //Update Employee Master Comp Off

            objBL.Query = "update Employees set CompOff=" + objPC.CompOff_Count + ",CompOffUsed=" + objPC.CompOffUsed_Count + ",CompOffExpired=" + objPC.CompOffExpired_Count + ",CompOffBalance=" + objPC.CompOffBalance_Count + " where EmployeeId=" + objPC.EmployeeId + " and CancelTag=0";
            Result= objBL.Function_ExecuteNonQuery();

        }

        public void Get_Comp_Off_Count_By_EmployeeId()
        {
            objPC.CompOffUsed_Count = 0;
            objPC.CompOff_Count = 0;
            objPC.CompOffUsedBalance_Count = 0;

            //if (LeaveTypes_Check == "Compensation Off")
            DataSet dsCount = new DataSet();
            objBL.Query = "select COALESCE(COUNT(CompOffApplicationId),0) from compoffapplication LA inner join leavetypes LT on LT.LeaveTypeId=LA.LeaveTypeId where LA.CancelTag=0 and LT.CancelTag=0 and LA.EmployeeId=" + objPC.EmployeeId + " and LT.LeaveTypeFName='Compensation Off' and LA.CompStatus='" + BusinessResources.LS_Completed + "'";
            dsCount = objBL.ReturnDataSet();
            if (dsCount.Tables[0].Rows.Count > 0)
                if (!string.IsNullOrEmpty(Convert.ToString(dsCount.Tables[0].Rows[0][0].ToString())))
                    objPC.CompOff_Count = Convert.ToDouble(dsCount.Tables[0].Rows[0][0].ToString());

            DataSet dsCountUsed = new DataSet();
            objBL.Query = "select COALESCE(COUNT(CompOffApplicationId),0) from compoffapplication LA inner join leavetypes LT on LT.LeaveTypeId=LA.LeaveTypeId where LA.CancelTag=0 and LT.CancelTag=0 and LA.EmployeeId=" + objPC.EmployeeId + " and LT.LeaveTypeFName='Compensation Off' and LA.CompOffUsedFlag=1 and LA.CompUsedStatus='" + BusinessResources.LS_Completed + "'";
            dsCountUsed = objBL.ReturnDataSet();
            if (dsCountUsed.Tables[0].Rows.Count > 0)
                if (!string.IsNullOrEmpty(Convert.ToString(dsCountUsed.Tables[0].Rows[0][0].ToString())))
                    objPC.CompOffUsed_Count = Convert.ToDouble(dsCountUsed.Tables[0].Rows[0][0].ToString());

            objPC.CompOffUsedBalance_Count = objPC.CompOff_Count - objPC.CompOffUsed_Count;
        }



        public void Fill_Leave_RichTextBox(RichTextBox rtb)
        {
            string GetYearValue = Get_Financial_Year();

            string ValueText = string.Empty;
            rtb.Text = "";

            if (objPC.Balance_Count < 0)
                objPC.Balance_Count = 0;

            if (objPC.CompOffBalance_Count < 0)
                objPC.CompOffBalance_Count = 0;

            ValueText =  GetYearValue+ "\n" +
                        "Paid Leaves  " + "\n" +
                        "Opening Leaves-" + objPC.OpeningLeave_Count + "\n" +
                        "Current Leaves-" + objPC.CurrentLeave_Count + "\n" +
                        "Total Applicable Leaves-" + objPC.TotalApplicableLeave_Count + "\n" + "\n" +
                        "Leaves Enjoy-" + objPC.EnjoyLeave_Count + "\n" +
                        "Balance Leaves-" + objPC.Balance_Count + "\n\n" +

                        "Special Leaves-" + objPC.SpecialLeave_Count + "\n\n" +

                        "Revert Days-" + objPC.RevertLeave_Count + "\n\n" +

                        "Compoff" + "\n" +
                        "Comp Off-" + objPC.CompOff_Count + "\n" +
                        "Comp Used-" + objPC.CompOffUsed_Count + "\n" +
                        "Comp Expired-" + objPC.CompOffExpired_Count + "\n" +


                        "Balance Comp Off-" + objPC.CompOffBalance_Count;

            rtb.Text = ValueText;
        }

        public string Fill_Location_By_LocationId(int LocationId)
        {
            string LName = string.Empty;

            DataSet ds = new DataSet();
            objBL.Query = "select LocationId,LocationName from locationmaster where CancelTag=0 and LocationId=" + LocationId + "";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["LocationName"])))
                    LName = Convert.ToString(ds.Tables[0].Rows[0]["LocationName"].ToString());
            }
            return LName;
        }

        public void Get_Auto_Shift_Details(DataSet ds)
        {
            //Imp
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (objPC.OutTime.TimeOfDay < objPC.InTime.TimeOfDay)
                {
                    objPC.TotalDuration_TS = objPC.OutTime.TimeOfDay.Add(new TimeSpan(24, 0, 0)).Subtract(objPC.InTime.TimeOfDay);
                }
                else
                {
                    objPC.TotalDuration_TS = objPC.OutTime.TimeOfDay.Subtract(objPC.InTime.TimeOfDay);
                }

                //objPC.TotalDuration_TS = objPC.OutTime.TimeOfDay.Subtract(objPC.InTime.TimeOfDay);
                objPC.TotalDuration = string.Format("{0}:{1}", objPC.TotalDuration_TS.Hours, objPC.TotalDuration_TS.Minutes);

                objPC.GraceTime_String = string.Empty;

                objPC.BeginTime_Shift_String = string.Empty;
                objPC.EndTime_Shift_String = string.Empty;

                objPC.GraceTime_String = GetPath_WithoutServer("GraceTime"); // "00:45";
                objPC.InTime_Emp_String = objPC.InTime.ToString(BusinessResources.TimeFormat_HHMM);                   //"HH:mm");
                objPC.InTime_Emp_TS = TimeSpan.Parse(objPC.InTime_Emp_String);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["BeginTime"])))
                        objPC.BeginTime_Shift_String = Convert.ToString(ds.Tables[0].Rows[i]["BeginTime"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["EndTime"])))
                        objPC.EndTime_Shift_String = Convert.ToString(ds.Tables[0].Rows[i]["EndTime"]);

                    objPC.InTime_Shift_TS = TimeSpan.Parse(objPC.BeginTime_Shift_String);
                    objPC.OutTime_Shift_TS = TimeSpan.Parse(objPC.EndTime_Shift_String);

                    objPC.GraceCalculaton_TS = TimeSpan.Parse(objPC.GraceTime_String);
                    objPC.GraceLess_TS = objPC.InTime_Shift_TS - objPC.GraceCalculaton_TS;
                    objPC.GracePlus_TS = objPC.InTime_Shift_TS + objPC.GraceCalculaton_TS;

                    objPC.ShiftId = 0;

                    //{13:01:00} In Time
                    //{09:45:00} with Grace Value

                    if ((objPC.InTime_Emp_TS >= objPC.GraceLess_TS) && (objPC.InTime_Emp_TS <= objPC.GracePlus_TS))
                    {
                        //MessageBox.Show("Matched");

                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["ShiftId"])))
                        {
                            objPC.ShiftId = Convert.ToInt32(ds.Tables[0].Rows[i]["ShiftId"].ToString());
                            objPC.ShiftDuration = Convert.ToString(ds.Tables[0].Rows[i]["ShiftDuration"].ToString());

                            objPC.ShiftDuration_Int = Convert.ToInt32(objPC.ShiftDuration);

                            objPC.ShiftName = Convert.ToString(ds.Tables[0].Rows[i]["ShiftFName"].ToString());

                            objPC.BeginTime_Shift_DT = Convert.ToDateTime(ds.Tables[0].Rows[i]["BeginTime"].ToString());
                            objPC.EndTime_Shift_DT = Convert.ToDateTime(ds.Tables[0].Rows[i]["EndTime"].ToString());

                            TimeSpan spWorkMin = TimeSpan.FromMinutes(objPC.ShiftDuration_Int);
                            string workHours = spWorkMin.ToString(@"hh\:mm");

                            objPC.ShiftHours_TS = TimeSpan.Parse(Convert.ToString(workHours));
                            objPC.Duration = workHours;
                            break;
                        }
                    }
                    //string CheckTime = EmpShiftInTime.ToString("HH:mm");

                    //string CheckTimeP = EmpShiftInTime.ToString("HH:mm");

                    //TSBeginTimeTime = TimeSpan.Parse(SBeginTimeTime);
                    //TimeSpan TSBeginTimeTime1 = TimeSpan.Parse(CheckTimeM);

                    //TSBeginTimeTime = TSBeginTimeTime - TSBeginTimeTime1;
                    ////TSBeginTimeTime = TSBeginTimeTime - TSBeginTimeTime1;

                    //TSEndTimeTime = TimeSpan.Parse(SEndTimeTime);
                    //TSEndTimeTime = TSBeginTimeTime + TSBeginTimeTime1;
                    ////TimeSpan TSEndTimeTime = TimeSpan.Parse(SEndTimeTime);
                    ////TimeSpan TSEndTimeTime = TimeSpan.Parse(SEndTimeTime);

                    ////TimeSpan ShiftInTime = new TimeSpan(10, 0, 0); //10 o'clock
                    ////TimeSpan ShiftOutTime = new TimeSpan(12, 0, 0); //12 o'clock
                    //TimeSpan EmpInTime;

                    //EmpInTime = TimeSpan.Parse(CheckTime.ToString());
                }
            }
        }

        string WhereClause = string.Empty;


        //public void Get_Shift_Details_by_ShiftName()
        //{
        //    DataSet ds = new DataSet();
        //    string S = string.Empty;
        //   // objPC.ShiftName = ShiftName;
        //    objPC.SearchFlag = true;
        //    ds = objQL.SP_Shifts_FillGrid();
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        objPC.ShiftName = Convert.ToString(ds.Tables[0].Rows[0]["ShiftFName"].ToString());

        //        objPC.BeginTime_Shift_DT = Convert.ToDateTime(ds.Tables[0].Rows[0]["BeginTime"].ToString());
        //        objPC.EndTime_Shift_DT = Convert.ToDateTime(ds.Tables[0].Rows[0]["EndTime"].ToString());

        //        S = Convert.ToString(ds.Tables[0].Rows[0]["ShiftDuration"].ToString());

        //        int cI = Convert.ToInt32(S);

        //        TimeSpan spWorkMin = TimeSpan.FromMinutes(cI);
        //        string workHours = spWorkMin.ToString(@"hh\:mm");
        //        objPC.ShiftHours_TS = TimeSpan.Parse(Convert.ToString(workHours));
        //        //Console.WriteLine(workHours);

        //        //cI = cI / 60;
        //        //ShiftHours_V = TimeSpan.Parse(Convert.ToString(cI));

        //        //ShiftHours_V = TimeSpan.Parse(objPC.ShiftHours_TS);

        //        //ShiftHours_V = TimeSpan.Parse(Convert.ToString(ds.Tables[0].Rows[0]["Break1"].ToString()));
        //        //ShiftHours_S = string.Format("{0}", ShiftHours_V.Hours);
        //        //ShiftMins_S = string.Format("{0}", ShiftHours_V.Minutes);

        //        objPC.ShiftDuration = workHours;
        //    }
        //}

        public string Get_Hours_Format(string Duration_InMin)
        {
            string ReturnHoursFormat = string.Empty;
            //Duration_InMin = "8";
            TimeSpan WorkingMinutes_TS = TimeSpan.FromMinutes(Convert.ToDouble(Duration_InMin));
            //string workHours = WorkingMinutes_TS.ToString(@"hh\:mm");
            ReturnHoursFormat = WorkingMinutes_TS.ToString(BusinessResources.HOURS_FORMAT);
            return ReturnHoursFormat;
        }

        //public void Get_Shift_Details(int ShiftId)
        //{
        //    string S = string.Empty;
        //    objPC.ShiftName = string.Empty;

        //    DataSet ds = new DataSet();
        //    ds = objQL.SP_Shifts_FillGrid_ById(ShiftId);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        objPC.ShiftName = Convert.ToString(ds.Tables[0].Rows[0]["ShiftFName"].ToString());

        //        objPC.BeginTime_Shift_DT = Convert.ToDateTime(ds.Tables[0].Rows[0]["BeginTime"].ToString());
        //        objPC.EndTime_Shift_DT = Convert.ToDateTime(ds.Tables[0].Rows[0]["EndTime"].ToString());

        //        S = Convert.ToString(ds.Tables[0].Rows[0]["ShiftDuration"].ToString());

        //        int cI = Convert.ToInt32(S);

        //        TimeSpan spWorkMin = TimeSpan.FromMinutes(cI);
        //        string workHours = spWorkMin.ToString(@"hh\:mm");
        //        objPC.ShiftHours_TS = TimeSpan.Parse(Convert.ToString(workHours));
        //        //Console.WriteLine(workHours);

        //        //cI = cI / 60;
        //        //ShiftHours_V = TimeSpan.Parse(Convert.ToString(cI));

        //        //ShiftHours_V = TimeSpan.Parse(objPC.ShiftHours_TS);

        //        //ShiftHours_V = TimeSpan.Parse(Convert.ToString(ds.Tables[0].Rows[0]["Break1"].ToString()));
        //        //ShiftHours_S = string.Format("{0}", ShiftHours_V.Hours);
        //        //ShiftMins_S = string.Format("{0}", ShiftHours_V.Minutes);

        //        objPC.ShiftDuration = workHours;
        //    }
        //}



        //public TimeSpan TotalDuration_Working, ShiftHours, OTHours, OTMins, ShiftHours_V;

        //public string OTHours_S = string.Empty, OTMins_S = string.Empty,ShiftHours_S=string.Empty, ShiftMins_S=string.Empty;

        //public string GetEmployeeDuration_BetweenDates(DateTime dt1, DateTime dt2)
        //{
        //    string TotalWorkingD = string.Empty;
        //    TotalDuration_Working = dt1.Subtract(dt2);

        //    //TotalDuration_Working = dt1 - dt2;
        //    TotalWorkingD = string.Format("{0}:{1}", TotalDuration_Working.Hours, TotalDuration_Working.Minutes);
        //    return TotalWorkingD;

        //    //TimeSpan time = TimeSpan.Parse(A);

        //    //string A = span.ToString();

        //    //String.Format("{0} days, {1} hours, {2} minutes, {3} seconds",
        //    //    span.Days, span.Hours, span.Minutes, span.Seconds);

        //    //TotalDuration_Working = 0;
        //    //var hours = (dt2 - dt1).TotalHours;

        //    //string WH= dt2.Subtract(dt1).TotalHours.ToString();

        //    //TotalDuration_Working = Convert.ToDouble(Math.Round(Convert.ToDouble((dt2.Subtract(dt1).TotalHours).ToString()), 2));

        //    //TimeSpan HoursMy = TimeSpan.Parse(Convert.ToString(ShiftHours)); 
        //}

        //public void OT_Calculations()
        //{
        //    try
        //    {
        //        objPC.OverTime = "00:00";
        //        double OTHoursCal = 0, OTMinCal = 0;
        //        string ConHours = string.Empty;

        //        //OT Logics
        //        //OT = TotalHours - ShiftHours

        //        //Total Duration - Shift Hours
        //        //Out Punch - Shift End Time
        //        objPC.OutTime_TS = objPC.OutTime.TimeOfDay.Add(new TimeSpan(24, 0, 0));

        //        if(objPC.OTFormula == "Total Duration - Shift Hours")
        //            objPC.OTHours_TS = objPC.TotalDuration_TS - objPC.ShiftHours_TS;
        //        else
        //            objPC.OTHours_TS = objPC.OutTime_TS - objPC.OutTime_Shift_TS;

        //        TimeSpan OTMinutes_Span = TimeSpan.FromMinutes(objPC.OTHours_TS.Minutes);
        //        TimeSpan OTHours_Span = TimeSpan.FromHours(objPC.OTHours_TS.Hours);

        //        OTHoursCal = Math.Round(Convert.ToDouble(objPC.OTHours_TS.Hours), 0);
        //        OTMinCal = Math.Round(Convert.ToDouble(objPC.OTHours_TS.Minutes), 0);

        //        if (OTHoursCal > 22)
        //        {
        //            OTHoursCal = 22;
        //        }

        //        if (OTHoursCal > 0)
        //        {
        //            if (OTMinCal > 31)
        //                OTHoursCal += 1;
        //        }
        //        else
        //        {
        //            if (OTMinCal > 31)
        //                OTHoursCal = 1;
        //            else
        //                OTHoursCal = 0;
        //        }
        //        ConHours = OTHoursCal + ":00";
        //        TimeSpan OTHoursMy = TimeSpan.Parse(ConHours);
        //        objPC.OverTime = ConHours.ToString();

        //        objPC.DurationOTHours_Double = OTHoursCal + objPC.DurationHours_Double;
        //        objPC.TotalDuration_TS = TimeSpan.FromHours(objPC.DurationOTHours_Double);
        //        objPC.TotalDuration = objPC.TotalDuration_TS.ToString();

        //        int ID = objPC.ESSLEmployeeId; //.EsslAttendanceLogsId; //ESSLLog-2474042 // .EmployeeCode; //EmployeeCode=663 // ESSLEmployeeId= 8079 Date- 17/08/2023 INTime-17/08/2023 1:01:57 PM // OutTime-18/08/2023 12:58:16 PM 
        //    }
        //    catch (Exception ex1)
        //    {
        //        MessageBox.Show(ex1.ToString());
        //    }
        //    finally
        //    {
        //        GC.Collect();
        //    }


        //    ////OTM = Math.Round(Convert.ToDouble(CalculateOT_Span.TotalMinutes), 0);

        //    //if (OTM > 31)
        //    //{
        //    //    OTMins_S = OTM.ToString();

        //    //    TimeSpan OTHoursMy = TimeSpan.Parse("01:00");
        //    //    OTHours_S = OTHoursMy.ToString();
        //    //}


        //    //int precision = 2; // Specify how many digits past the decimal point
        //    //TimeSpan t1 = new TimeSpan(19365678); // sample input value

        //    //const int TIMESPAN_SIZE = 7; // it always has seven digits
        //    //// convert the digitsToShow into a rounding/truncating mask
        //    //int factor = (int)Math.Pow(10, (TIMESPAN_SIZE - precision));

        //    //MessageBox.Show("Input: " + t1);
        //    //TimeSpan truncatedTimeSpan = new TimeSpan(t1.Ticks - (t1.Ticks % factor));
        //    //MessageBox.Show("Truncated: " + truncatedTimeSpan);
        //    //TimeSpan roundedTimeSpan =
        //    //    new TimeSpan(((long)Math.Round((1.0 * t1.Ticks / factor)) * factor));
        //    //MessageBox.Show("Rounded: " + roundedTimeSpan);


        //    // TimeSpan spWorkMin2 = TimeSpan.FromHours(9);
        //    // //double totalHours = (today - twoDaysAgo).TotalHours;


        //    // OTHours_S = string.Empty; OTMins_S = string.Empty;

        //    //// DateTime dt1 = Convert.ToDateTime(ShiftHours_V);

        //    // string ShiftDuration = string.Empty;

        //    // ShiftDuration = Convert.ToString(ShiftHours_V);

        //    // ShiftDuration = Convert.ToString(ShiftHours_V.Hours);

        //    //// double d = Convert.ToDouble(ShiftHours_V);

        //    // //TimeSpan HoursMy = TimeSpan.Parse(Convert.ToString(ShiftHours));
        //    // TimeSpan spWorkMin = TimeSpan.FromMinutes(540);

        //    // OTMins = TotalDuration_Working - spWorkMin;

        //    // TimeSpan spWorkMin1 = TimeSpan.FromMinutes(OTMins.Minutes);

        //    // string a = Convert.ToString(spWorkMin1.Hours);

        //    // OTHours_S = string.Format("{0}", spWorkMin1.Hours);
        //    // OTMins_S = string.Format("{0}", OTMins.Minutes);

        //    //OTHours = 0; OTMins = 0;
        //    ////TotalDuration_Working = Convert.ToDouble(Math.Round(Convert.ToDouble((dt2.Subtract(dt1).TotalHours).ToString()), 2));
        //    //OTMins = Math.Round(Convert.ToDouble(TotalDuration_Working - ShiftHours), 2);
        //    //OTHours = Math.Round(Convert.ToDouble((TotalDuration_Working - ShiftHours) / 60), 2);
        //}



        public void GetLeaveDetailsEmployees_ByLeaveId()
        {

            objPC.LeaveType = "";
            if (objPC.LeaveTypeId != 0)
            {
                DataSet ds = new DataSet();
                objBL.Query = "select * from leavetypes where LeaveTypeId=" + objPC.LeaveTypeId + "";
                ds = objBL.ReturnDataSet();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //objPC.LeaveTypeId = Convert.ToInt32(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["LeaveTypeId"])));
                    objPC.LeaveType = Convert.ToString(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["LeaveTypeFName"])));
                }
            }
        }

        public void Calculate_Time_Differance(string StartTime, string EndTime)
        {
            TimeSpan BTIme = TimeSpan.Parse(StartTime);
            TimeSpan ETIme = TimeSpan.Parse(objPC.EndTime);
            TimeSpan interval = ETIme - BTIme;
            objPC.TimeIntervalMinutes = Convert.ToString(interval.TotalMinutes);
            objPC.TimeIntervalHours = Convert.ToString(interval.TotalHours);

            if (interval.Hours > 0)
                objPC.ShiftDurationHours = Get_Hours_Format(Convert.ToString(interval.TotalMinutes));
            else
                objPC.ShiftDurationHours = "00:00";
        }

        public void SetStatusColor(ComboBox cmb, RichTextBox lbl)
        {
            if (cmb.SelectedIndex > -1)
            {
                string AStatus = cmb.Text;

                if (AStatus == BusinessResources.LS_Pending)
                    lbl.BackColor = Color.FromName(BusinessResources.LS_Pending_Color);
                else if (AStatus == BusinessResources.LS_ManagerApproved)
                    lbl.BackColor = Color.FromName(BusinessResources.LS_Manager_Color);
                else if (AStatus == BusinessResources.LS_HRApproved)
                    lbl.BackColor = Color.FromName(BusinessResources.LS_HRApproved_Color);
                else if (AStatus == BusinessResources.LS_Remarks)
                    lbl.BackColor = Color.FromName(BusinessResources.LS_Remarks_Color);
                else if (AStatus == BusinessResources.LS_Reject)
                    lbl.BackColor = Color.FromName(BusinessResources.LS_Reject_Color);
                else if (AStatus == BusinessResources.LS_InchargeApproved)
                    lbl.BackColor = Color.FromName(BusinessResources.LS_InchargeApproved_Color);
                else if (AStatus == BusinessResources.LS_Completed)
                    lbl.BackColor = Color.FromName(BusinessResources.LS_Completed_Color);
                else
                {
                    lbl.BackColor = Color.White;
                    //string hex = BusinessResources.BACKGROUND_COLOUR;
                    //Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
                    //Myrow.DefaultCellStyle.BackColor = _color;
                }
            }
        }


        public double LateEarlyBy = 0;
        public bool CheckLateEarlyMarking(DateTime dtInOutTime, string Type)
        {
            bool ReturnFlag = false;
            // If Coming Late Flag Set
            // Lateby   = InTime - ShiftBiginTime;
            // EarlyBy  = OutTime - ShiftEndTime;

            if (Type == "Late")
            {
                LateEarlyBy = Convert.ToDouble(Math.Round(Convert.ToDouble(dtInOutTime.Subtract(objPC.BeginTime_Shift_DT).Minutes.ToString())));

                if (LateEarlyBy > 0)
                    ReturnFlag = true;
                else
                    ReturnFlag = false;
            }
            else
            {
                LateEarlyBy = Convert.ToDouble(Math.Round(Convert.ToDouble(objPC.EndTime_Shift_DT.Subtract(dtInOutTime).Minutes.ToString())));

                if (LateEarlyBy < 0)
                    ReturnFlag = true;
                else
                    ReturnFlag = false;
            }

            return ReturnFlag;
        }




        //public void Get_Shift_Group_Details(int ShiftGroupId)
        //{
        //    string S = string.Empty;

        //    DataSet ds = new DataSet();
        //   // ds = objQL.(ShiftGroupId);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        S = Convert.ToString(ds.Tables[0].Rows[0]["Break1"].ToString());

        //        ShiftBeginTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["BeginTime"].ToString());
        //        ShiftEndTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["EndTime"].ToString());

        //        int cI = Convert.ToInt32(S);

        //        TimeSpan spWorkMin = TimeSpan.FromMinutes(cI);
        //        string workHours = spWorkMin.ToString(@"hh\:mm");
        //        ShiftHours_V = TimeSpan.Parse(Convert.ToString(workHours));
        //        //Console.WriteLine(workHours);

        //        //cI = cI / 60;
        //        //ShiftHours_V = TimeSpan.Parse(Convert.ToString(cI));

        //        //ShiftHours_V = TimeSpan.Parse(S);

        //        //ShiftHours_V = TimeSpan.Parse(Convert.ToString(ds.Tables[0].Rows[0]["Break1"].ToString()));
        //        //ShiftHours_S = string.Format("{0}", ShiftHours_V.Hours);
        //        //ShiftMins_S = string.Format("{0}", ShiftHours_V.Minutes);

        //        ShiftHours_S = workHours;
        //    }
        //}

        //public string ErrorType = string.Empty;

        public void Set_Error_Color(DataGridView dgv, int RowIndex, string ColumnName, Color cl)
        {
            // if(ErrorType == BusinessResources.LS_Error_Color)
            dgv.Rows[RowIndex].Cells[ColumnName].Style.BackColor = cl; //Color.FromName(BusinessResources.LS_Error_Color);
            //else
            //  dgv.Rows[RowIndex].Cells[ColumnName].Style.BackColor = Color.Red;

            //dgv.Rows[RowIndex].Cells["clmEarlyBy"].Style.BackColor = Color.Yellow;
        }

        public void Fill_Department_ComboBox_By_Location(ComboBox clb, int LocationId)
        {
            clb.DataSource = null;
            DataSet ds = new DataSet();
            ds = objQL.SP_LocationWiseDepartment_Get_Department_By_LocationId();
            if (ds.Tables[0].Rows.Count > 0)
            {
                clb.DataSource = ds.Tables[0];
                clb.DisplayMember = "Department";
                clb.ValueMember = "DepartmentId";
                clb.SelectedIndex = -1;
            }

            //clb.DataSource = null;
            ////DataSet ds = new DataSet();
            //objBL.Query = "select DepartmentId,Department from departmentmaster where CancelTag=0 and LocationId=" + LocationId + "";
            //ds = objBL.ReturnDataSet();
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    clb.DataSource = ds.Tables[0];
            //    clb.DisplayMember = "Department";
            //    clb.ValueMember = "DepartmentId";
            //    clb.SelectedIndex = -1;
            //}
        }

        public void Fill_Department_CheckedListBox_By_Location_Asset(CheckedListBox clb)
        {
            clb.DataSource = null;
            DataSet ds = new DataSet();
            ds = objQL.SP_LocationWiseDepartment_Get_Department_By_LocationId();
            if (ds.Tables[0].Rows.Count > 0)
            {
                clb.DataSource = ds.Tables[0];
                clb.DisplayMember = "Department";
                clb.ValueMember = "DepartmentId";
                clb.SelectedIndex = -1;
            }

            //clb.DataSource = null;
            ////DataSet ds = new DataSet();
            //objBL.Query = "select DepartmentId,Department from departmentmaster where CancelTag=0 and LocationId=" + LocationId + "";
            //ds = objBL.ReturnDataSet();
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    clb.DataSource = ds.Tables[0];
            //    clb.DisplayMember = "Department";
            //    clb.ValueMember = "DepartmentId";
            //    clb.SelectedIndex = -1;
            //}
        }

        public void Fill_Department_ComboBox_By_Location_Incharge_A(ComboBox clb, int LocationId)
        {
            clb.DataSource = null;
            DataSet ds = new DataSet();
            objBL.Query = "select DepartmentId,Department from departmentmaster where CancelTag=0 and LocationId=" + LocationId + "";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                clb.DataSource = ds.Tables[0];
                clb.DisplayMember = "Department";
                clb.ValueMember = "DepartmentId";
                clb.SelectedIndex = -1;
            }
        }

        public void Fill_Location_CheckedListBox(CheckedListBox clb)
        {
            clb.DataSource = null;
            DataSet ds = new DataSet();
            objBL.Query = "select LocationId,LocationName from locationmaster where CancelTag=0 ";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                clb.DataSource = ds.Tables[0];
                clb.DisplayMember = "LocationName";
                clb.ValueMember = "LocationId";
            }
        }

        public void Fill_Location_CheckedListBox_HolidayMaster(CheckedListBox clb)
        {
            clb.DataSource = null;
            DataSet ds = new DataSet();
            objBL.Query = "select LocationId,LocationName from locationmaster where CancelTag=0 and LocationName NOT IN('Default','All','OTHER') ";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                clb.DataSource = ds.Tables[0];
                clb.DisplayMember = "LocationName";
                clb.ValueMember = "LocationId";
            }
        }

        public void Fill_Location_ComboBox(ComboBox cmb)
        {
            cmb.DataSource = null;
            DataSet ds = new DataSet();
            objBL.Query = "select LocationId,LocationName from locationmaster where CancelTag=0 ";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "LocationName";
                cmb.ValueMember = "LocationId";
                cmb.SelectedIndex = -1;
            }
        }

        public void Fill_Shift_ComboBox(ComboBox cmb)
        {
            cmb.DataSource = null;
            DataSet ds = new DataSet();
            objBL.Query = "select ShiftId,ShiftFName from shifts where CancelTag=0 ";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "ShiftFName";
                cmb.ValueMember = "ShiftId";
                cmb.SelectedIndex = -1;
            }
        }

        public void Fill_Shifts_CheckedListBox(CheckedListBox clb)
        {
            clb.DataSource = null;
            DataSet ds = new DataSet();
            objBL.Query = "select ShiftId,ShiftFName from shifts where CancelTag=0 ";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                clb.DataSource = ds.Tables[0];
                clb.DisplayMember = "ShiftFName";
                clb.ValueMember = "ShiftId";
            }
        }

        public void Fill_Contractor_CheckedListBox(CheckedListBox clb)
        {
            clb.DataSource = null;
            DataSet ds = new DataSet();
            objBL.Query = "select ContractorId,ContractorName from contractormaster where CancelTag=0 ";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                clb.DataSource = ds.Tables[0];
                clb.DisplayMember = "ContractorName";
                clb.ValueMember = "ContractorId";
            }
        }

        public void Fill_Contractor_IN_Attendance(ComboBox cmb)
        {
            cmb.DataSource = null;
            DataSet ds = new DataSet();
            objBL.Query = "select ContractorId,ContractorName from contractormaster where CancelTag=0 ";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "ContractorName";
                cmb.ValueMember = "ContractorId";
                cmb.SelectedIndex = -1;
            }
        }

       public void Fill_Memo_Template(ComboBox cmb)
        {
            cmb.DataSource = null;
            DataSet ds = new DataSet();
            objBL.Query = "select MemoTemplateMasterId,MemoSubject from memotemplatemaster where LetterType='Memo' order by MemoSubject asc";
            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
            {
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "MemoSubject";
                cmb.ValueMember = "MemoTemplateMasterId";
                cmb.SelectedIndex = -1;
            }
        }

       

        public void Get_LocationId_By_Department_LocationWiseDepartment()
        {
            DataSet ds = new DataSet();
            objBL.Query = "select * from locationwisedepartment where DepartmentId=" + objPC.DepartmentId + " and CancelTag=0 ";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                objPC.LocationId = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["LocationId"])));
            }
        }

        public string GetMonthName(int Month)
        {
            //January
            //February
            //March
            //April
            //May
            //June
            //July
            //August
            //September
            //October
            //November
            //December
            string MonthName = string.Empty;
            switch (Month)
            {
                case 1:
                    MonthName = "January";
                    break;
                case 2:
                    MonthName = "February";
                    break;
                case 3:
                    MonthName = "March";
                    break;
                case 4:
                    MonthName = "April";
                    break;
                case 5:
                    MonthName = "May";
                    break;
                case 6:
                    MonthName = "June";
                    break;
                case 7:
                    MonthName = "July";
                    break;
                case 8:
                    MonthName = "August";
                    break;
                case 9:
                    MonthName = "September";
                    break;
                case 10:
                    MonthName = "October";
                    break;
                case 11:
                    MonthName = "November";
                    break;
                case 12:
                    MonthName = "December";
                    break;
            }
            return MonthName;
        }

        public int GetMonthNumber(string Month)
        {
            //January
            //February
            //March
            //April
            //May
            //June
            //July
            //August
            //September
            //October
            //November
            //December
            int MonthNumber = 0;
            switch (Month)
            {
                case "January":
                    MonthNumber = 01;
                    break;
                case "February":
                    MonthNumber = 02;
                    break;
                case "March":
                    MonthNumber = 03;
                    break;
                case "April":
                    MonthNumber = 04;
                    break;
                case "May":
                    MonthNumber = 05;
                    break;
                case "June":
                    MonthNumber = 06;
                    break;
                case "July":
                    MonthNumber = 07;
                    break;
                case "August":
                    MonthNumber = 08;
                    break;
                case "September":
                    MonthNumber = 09;
                    break;
                case "October":
                    MonthNumber = 10;
                    break;
                case "November":
                    MonthNumber = 11;
                    break;
                case "December":
                    MonthNumber = 12;
                    break;
            }

            return MonthNumber;
        }

        public void ReportException(string FilePath, Exception exName)
        {
            //[System.Runtime.InteropServices.COMException] = {"The specified file is read only. (Exception from HRESULT: 0x80071779)"}
            //ABC = exName.Message.ToString();

            string ABC = exName.GetType().ToString();

            if (!string.IsNullOrEmpty(Convert.ToString(ABC)))
            {
                if (ABC == "System.Runtime.InteropServices.COMException")
                    ShowMessage(23, 4);

                foreach (Process clsProcess in Process.GetProcesses())
                    if (clsProcess.ProcessName.Equals("EXCEL"))  //Process Excel?
                        clsProcess.Kill();
            }
        }

        public string StringFormatSet(string Value1, string Value2)
        {
            return String.Format("{0}\t{1}", Value1, Value2);
        }

        public string SetStringDoubleClick
        {
            get { return setstringdoubleclick; }
            set { setstringdoubleclick = value; }
        }

        public bool DCFlagClick
        {
            get { return dcflagclick; }
            set { dcflagclick = value; }
        }

        public bool ReturnSystemDateFormat()
        {
            SystemDateFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
            if (SystemDateFormat != "dd/MM/yyyy")
                return true;
            else
                return true;
        }

        //public bool ReturnSystemDateFormat()
        //{
        //    SystemDateFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
        //    if (SystemDateFormat != "dd/MM/yyyy")
        //        return false;
        //    else
        //        return true;
        //}

        public string ReturnDateInFormat(DateTime dt)
        {
            string dtString = string.Empty;
            return dt.ToString(BusinessResources.DATEFORMATDDMMMYYYY);
        }

        public void EmailValidations()
        {
            objBL.Query = "select ID,EmailId,Password from EmailCredentials where CancelTag=0";
            DataSet ds = new DataSet();
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["EmailId"].ToString()) && !string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Password"].ToString()))
                {
                    //TableID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"].ToString());
                    EmailAddress_Static = ds.Tables[0].Rows[0]["EmailId"].ToString();
                    EmailPassword_Static = ds.Tables[0].Rows[0]["Password"].ToString();
                }
            }
        }

        public void Fill_UOM(ComboBox cmb)
        {
            objBL.Query = "select ID,UnitOfMessurement from UOM where CancelTag=0";
            objBL.FillComboBox(cmb, "UnitOfMessurement", "ID");
        }

        private string MessageString(int MsgValue)
        {
            string MsgString = "";

            switch (MsgValue)
            {
                case 1:
                    MsgString = "Success";
                    break;
                case 2:
                    MsgString = "Warning";
                    break;
                case 3:
                    MsgString = "Question";
                    break;
                case 4:
                    MsgString = "Error";
                    break;
                case 5:
                    MsgString = "Stop";
                    break;
                case 6:
                    MsgString = "Hand";
                    break;
                case 7:
                    MsgString = "Saved Successfully";
                    break;
                case 8:
                    MsgString = "Updated Successfully";
                    break;
                case 9:
                    MsgString = "Deleted Successfully";
                    break;
                case 10:
                    MsgString = "Password changed successfully.";
                    break;
                case 11:
                    MsgString = "Error occured in change password.";
                    break;
                case 12:
                    MsgString = "Already exist.";
                    break;
                case 13:
                    MsgString = "Enter only numeric value.";
                    break;
                case 14:
                    MsgString = "Enter only text value.";
                    break;
                case 15:
                    MsgString = "Enter only text and numeric value.";
                    break;
                case 16:
                    MsgString = "Enter only decimal value.";
                    break;
                case 17:
                    MsgString = "Enter appropriate values";
                    break;
                case 18:
                    MsgString = "E-mail address format is not correct.";
                    break;
                case 19:
                    MsgString = "Enter user name or password";
                    break;
                case 20:
                    MsgString = "Invalid user name or password";
                    break;
                case 21:
                    MsgString = "Please enter correct system date e.g. dd/MM/yyyy";
                    break;
                case 22:
                    MsgString = "Report Generated Successfully";
                    break;
                case 23:
                    MsgString = "Enter Fee details";
                    break;
                case 24:
                    MsgString = "You do not have access for this.";
                    break;
                case 25:
                    MsgString = "Can not delete the patient record as there are OPD records for this patient.";
                    break;
                case 26:
                    MsgString = "Database backup generated successfully.";
                    break;
                case 27:
                    MsgString = "Please close any open reports and try again.";
                    break;
                case 28:
                    MsgString = "The product is not licensed to install on this machine, please contact your administrator.";
                    break;
                case 29:
                    MsgString = "Server is not found.";
                    break;
                case 30:
                    MsgString = "Appointments cleared successfully.";
                    break;
                case 31:
                    MsgString = "Appointment used by other doctor can you select other.";
                    break;
                case 32:
                    MsgString = "Please enter the correct password.";
                    break;
                case 33:
                    MsgString = "Patient's is already exists for today. " + DateTime.Now.Date.ToString("dd/MMM/yyyy") + "";
                    break;
                case 34:
                    MsgString = "ESSL Data Imported Successfully.";
                    break;
                case 35:
                    MsgString = "Records are not found.";
                    break;
                case 36:
                    MsgString = "Enter valid date";
                    break;
                case 37:
                    MsgString = "Total Leave(Days) should be less than Balance leave.";
                    break;
                case 38:
                    MsgString = "User type is not valid - " + BusinessLayer.UserType + "";
                    break;
                case 39:
                    MsgString = "Total-" + objPC.NewEmpCount + " New Employee Added in Employee Master, please check its location and Department. Then add Attendance";
                    break;
                case 40:
                    MsgString = "Select only 1 ";
                    break;
                case 41:
                    MsgString = "Download Template Successfully. Path- " + objPC.DocumentPath + "";
                    break;
                case 42:
                    MsgString = "Template file already exist in given path. Please check - " + objPC.DocumentPath + "";
                    break;
                case 43:
                    MsgString = "File already exists.";
                    break;
                case 44:
                    MsgString = "Excel Attendance Saved Successfully.";
                    break;
                case 45:
                    MsgString = "Recalculated Successfully";
                    break;
                case 46:
                    MsgString = "Leave Balance Not available";
                    break;
                case 47:
                    MsgString = "Remarks Added Successfully";
                    break;
                case 48:
                    MsgString = "Software is not updated, After login please go to Setting->Update Wizard and download updated version";
                    break;
                case 49:
                    MsgString = "Comp off already expired. Please contact to HR department";
                    break;
                case 50:
                    MsgString = "Database Changes Successfully Saved";
                    break;
                case 51:
                    MsgString = "Status is Completed. You do not have permission to Save this Record.";
                    break;
                case 52:
                    MsgString = "Status is Pending. You do not have permission to Save this Record.";
                    break;
                case 53:
                    MsgString = "HR not approved this attendance";
                    break;
                case 54:
                    MsgString = "The selected date is a holiday or weekly off. Please enter a valid date.";
                    break;
                case 55:
                    MsgString = "Attendance alrady exists. Please enter another date";
                    break;
                case 56:
                    MsgString = "The selected date is not a holiday or weekly off. Please enter a valid date.";
                    break;
            }

            return MsgString;
        }

        string MString = "", CapString = "";

        public void ShowMessage(int MsgValue, int CapValue)
        {
            MString = ""; CapString = "";
            MString = MessageString(MsgValue);
            CapString = MessageString(CapValue);

            if (CapString == "Success")
                MessageBox.Show(MString, CapString, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            else if (CapString == "Warning")
                MessageBox.Show(MString, CapString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (CapString == "Question")
                MessageBox.Show(MString, CapString, MessageBoxButtons.OK, MessageBoxIcon.Question);
            else if (CapString == "Error")
                MessageBox.Show(MString, CapString, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (CapString == "Stop")
                MessageBox.Show(MString, CapString, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else
                MessageBox.Show(MString, CapString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        public void ErrorMessge(string MsgValue)
        {
            MString = MsgValue;
            CapString = MessageString(4);
            MessageBox.Show(MString, CapString, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public DialogResult Delete_Record_Show_Message()
        {
            DialogResult dr;
            return dr = MessageBox.Show("Do you want to delete this record?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        public DialogResult Approve_Show_Message()
        {
            DialogResult dr;
            return dr = MessageBox.Show("Do you want to approve this attendance?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        public DialogResult Clear_AppointmentList_Show_Message()
        {
            DialogResult dr;
            return dr = MessageBox.Show("Do you want to clear appointments list?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        public void NumericValue(object sender, KeyPressEventArgs e, TextBox tb)
        {
            if (tb.Text.Length == 0)
            {
                if (e.KeyChar == 32)
                    e.Handled = true;
                else
                    e.Handled = false;
            }
            if (!(char.IsDigit(e.KeyChar)) && !char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == 32 && tb.Text.Length != 0)
                    e.Handled = false;
                else
                {
                    e.Handled = true;
                    ShowMessage(13, 4);
                }
            }
        }

        public void TxtValue(object sender, KeyPressEventArgs e, TextBox tb)
        {

            if (tb.Text.Length == 0)
            {
                if (e.KeyChar == 32)
                    e.Handled = true;
                else
                    e.Handled = false;
            }
            if (!(char.IsLetter(e.KeyChar)) && !char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == 32 && tb.Text.Length != 0)
                    e.Handled = false;
                else
                {
                    e.Handled = true;
                    ShowMessage(14, 4);
                }
            }
        }

        public void TxtNumericValue(object sender, KeyPressEventArgs e, TextBox tb)
        {
            int a = tb.SelectionStart;
            if (a == 0)
            {
                if (e.KeyChar == 32)
                    e.Handled = true;
                else
                    e.Handled = false;
            }
            if (!(char.IsLetter(e.KeyChar)) && !(char.IsDigit(e.KeyChar)) && !(char.IsControl(e.KeyChar)) && !(e.KeyChar == 46))
            {
                if (e.KeyChar == 32 && a != 0)
                    e.Handled = false;
                else
                {
                    e.Handled = true;
                    ShowMessage(15, 4);
                }
            }
        }

        public void FloatValue(object sender, KeyPressEventArgs e, TextBox tb)
        {
            if (tb.Text.Length == 0)
            {
                if (e.KeyChar == 32)
                    e.Handled = true;
                else
                    e.Handled = false;
            }
            if (!(char.IsDigit(e.KeyChar)) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                ShowMessage(16, 4);
            }
            if (tb.Text.Contains(".") && e.KeyChar == 46)
            {
                e.Handled = true;
            }
        }

        public void MobileNumber_KeyPress(object sender, KeyPressEventArgs e, TextBox tb)
        {
            if (tb.Text.Length == 0)
            {
                if (e.KeyChar == 32)
                    e.Handled = true;
                else
                    e.Handled = false;
            }
            if (!(char.IsDigit(e.KeyChar)) && !char.IsControl(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != '+')
            {
                e.Handled = true;
                ShowMessage(16, 4);
            }
        }

        public string Return_Remove_Space(string strName)
        {
            strName = strName.Replace(" ", "");
            return strName;
        }

        public string RegNumber = "";

        public void Return_Registration_Number(string DoctorName)
        {
            RegNumber = "";
            DataSet ds = new DataSet();
            objBL.Query = "select ID,DoctorName,Address,MobileNumber,Gender,RegistrationNumber,Qualification,Specialists from Doctor where DoctorName='" + DoctorName + "' and CancelTag=0";
            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["RegistrationNumber"].ToString()))
                    RegNumber = ds.Tables[0].Rows[0]["RegistrationNumber"].ToString();
            }
        }

        public void Fill_Occupation(ComboBox cmb)
        {
            objBL.Query = "select ID,OccupationCaption from Occupation where CancelTag=0";
            objBL.FillComboBox(cmb, "OccupationCaption", "ID");
        }

        //public string Return_Date_String_DDMMYYYY(DateTime dt)
        //{
        //    string ReturnDate;
        //    ReturnDate = dt.ToString("dd-MM-yyyy");
        //    return ReturnDate;
        //}

        //public string Return_Date_String_MMDDYYYY(DateTime dt)
        //{
        //    string ReturnDate;
        //    ReturnDate = dt.ToString(RedundancyLogics.SystemDateFormat);
        //    return ReturnDate;
        //}

        //public DateTime Return_Date_DDMMYYYY(string DateString)
        //{
        //    DateTime ReturnDate;
        //    string DDMMYYYY_String = DateTime.ParseExact(DateString, "dd/MM/yyyy", null).ToString(RedundancyLogics.SystemDateFormat);
        //    ReturnDate = Convert.ToDateTime(DDMMYYYY_String);
        //    return ReturnDate;
        //}

        //public DateTime Return_Date_MMDDYYYY(string DateString)
        //{
        //    DateTime ReturnDate;
        //    string MMDDYYYY_String = DateTime.ParseExact(DateString, RedundancyLogics.SystemDateFormat, null).ToString("dd/MM/yyyy");
        //    ReturnDate = Convert.ToDateTime(MMDDYYYY_String);
        //    return ReturnDate;
        //}

        //public string Return_Date_String_DDMMYYYY_withTime(DateTime dt)
        //{
        //    string ReturnDate;
        //    ReturnDate = dt.ToString("dd-MM-yyyy hh:mm:ss tt");
        //    return ReturnDate;
        //}

        //public DateTime AllDate(string DateString)
        //{
        //    return DateTime.Parse(DateString, new CultureInfo("en-CA"));
        //}

        public string GetServerPath()
        {
            string RPath = "";
            RPath = ConfigurationManager.AppSettings["ServerPath"];
            return RPath;
        }

        public string GetPath(string KeyName)
        {
            string RPath = "";
            RPath = ConfigurationManager.AppSettings["ServerPath"];

            if (!string.IsNullOrEmpty(RPath))
                RPath = RPath + ConfigurationManager.AppSettings[KeyName];

            return RPath;
        }

        public string GetDocumentsPath()
        {
            string RPath = "";
            RPath = ConfigurationManager.AppSettings["ServerPath"];

            if (!string.IsNullOrEmpty(RPath))
                RPath = RPath + ConfigurationManager.AppSettings["DocumentsPath"];

            return RPath;
        }

        public string GetPath_DocumentsMain(int Id)
        {
            //return objRL.GetServerPath() + BusinessResources.ASSETDOCUMENTS + AssetMasterId + "\\";
            if (!string.IsNullOrEmpty(Convert.ToString(objPC.FormName)))
                return GetDocumentsPath() + objPC.FormName + "\\" + Id + "\\";
            else
                return "";
        }

        public string GetPath_WithoutServer(string KeyName)
        {
            string RPath = "";

            if (!string.IsNullOrEmpty(KeyName))
                RPath = ConfigurationManager.AppSettings[KeyName];

            return RPath;
        }

        public double BMI_Value_RL = 0, eGFRValue_RL = 0;
        public int CalculateYear_Age_RL = 0;

        public void CalculateBMI_Value(string Weight_F, string Height_F)
        {
            double HeightValue = 0, WeightValue = 0;

            if (Weight_F != "" && Height_F != "")
            {
                HeightValue = 0; WeightValue = 0;
                double.TryParse(Height_F, out HeightValue);
                double.TryParse(Weight_F, out WeightValue);
                HeightValue = HeightValue / 100;
                BMI_Value_RL = (WeightValue / (HeightValue * HeightValue));
                BMI_Value_RL = Math.Round(BMI_Value_RL, 2);

                if (Sex_Static == "Female")
                {
                    if (RedundancyLogics.SerumCreatinine != 0)
                        eGFRValue_RL = Convert.ToDouble(Convert.ToDouble((140 - Convert.ToInt32(CalculateYear_Age_RL)) * WeightValue) / (72 * RedundancyLogics.SerumCreatinine)) * 0.85;
                    else
                        eGFRValue_RL = 0;
                }
                else
                {
                    if (RedundancyLogics.SerumCreatinine != 0)
                        eGFRValue_RL = Convert.ToDouble(Convert.ToDouble((140 - Convert.ToInt32(CalculateYear_Age_RL)) * WeightValue) / (72 * RedundancyLogics.SerumCreatinine));
                    else
                        eGFRValue_RL = 0;
                }

                if (eGFRValue_RL != 0)
                    eGFRValue_RL = Math.Round(eGFRValue_RL, 2);
                else
                    eGFRValue_RL = 0;
            }
        }

        public int ReturnMaxID(string TableName)
        {
            int Maxid = 0;
            DataSet ds = new DataSet();
            objQL.TableName = TableName;
            ds = objQL.SP_SelectAll_Data_By_TableName();

            //objBL.Query = "select Max(ID) from " + TableName + "";
            //DataSet ds = new DataSet();
            //ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0][0].ToString()))
                    Maxid = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            Maxid += 1;
            return Maxid;
        }

        public int ReturnMaxID_Fix(string TableName, string columnName)
        {
            int Maxid = 0;
            objBL.Query = "select Max(" + columnName + ") from " + TableName + "";
            DataSet ds = new DataSet();
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0][0].ToString()))
                    Maxid = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());

            return Maxid;
        }

        public int ReturnMaxID_Increase(string TableName, string columnName)
        {
            int Maxid = 0;
            objBL.Query = "select Max(" + columnName + ") from " + TableName + "";
            DataSet ds = new DataSet();
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0][0].ToString()))
                    Maxid = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            Maxid += 1;
            return Maxid;
        }

        public void Fill_Staff(string Desgnation, ComboBox cmb)
        {
            DataSet ds = new DataSet();
            objBL.Query = "select S.ID,S.DesignationId,S.FullName,S.Gender,S.DOB,S.Age,S.BloodGroup,S.CurrentAddress,S.AsAbove,S.PermenentAddress,S.MobileNo1,S.MobileNo2,S.EmailId,S.Qualification,S.RegNo,S.Speciality,S.Experience,S.DateOfJoining from Staff S inner join DesignationMaster D on D.ID=S.DesignationId where S.CancelTag=0 and D.Designation='" + Desgnation + "'";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "FullName";
                cmb.ValueMember = "ID";
            }
        }

        public int Fill_Staff_DesignationID(string Designation)
        {
            int DesignationId = 0;

            DataSet ds = new DataSet();
            objQL.Designation = Designation.ToString();
            ds = objQL.SP_DesignationMaster_By_Designation();

            //objBL.Query = "select ID,Designation from DesignationMaster where CancelTag=0 and Designation='" + Desgnation + "'";
            //ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
                DesignationId = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            else
                DesignationId = 0;

            return DesignationId;
        }

        public void Fill_Company(ComboBox cmb)
        {
            objBL.Query = "select ID,CompanyName from CompanyMaster where CancelTag=0";
            objBL.FillComboBox(cmb, "CompanyName", "ID");
        }

        public void Get_Company_Name()
        {
            DataSet ds = new DataSet();
            objBL.Query = "select CompanyId,CompanyName from companyprofile where CancelTag=0";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
                objPC.CompanyName = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]));
        }

        public void ClearExcelPath()
        {
            RL_ExcelFormatPath = "";
            RL_DestinationPath = "";
            Form_ReportFileName = "";
            Form_DestinationReportFilePath = "";
            Form_ExcelFileName = "";
            isPDF = false;
        }

        public bool DocumentFlag = false;  
        public void Path_Comman()
        {
            if (isPDF)
            {
                if (!string.IsNullOrEmpty(Form_ExcelFileName))
                {
                    //DocumentFlag = true;  
                    //string myExeDir = AppDomain.CurrentDomain.BaseDirectory + "ExcelFormat\\";

                    string myExeDir = AppDomain.CurrentDomain.BaseDirectory + BusinessResources.FORMATPATH;
                    //RL_ExcelFormatPath = BusinessLayer.FormatPath + Form_ExcelFileName;
                    RL_ExcelFormatPath = myExeDir + Form_ExcelFileName;

                    //RL_ExcelFormatPath = GetPath("ExcelFormat") + Form_ExcelFileName;
                    FileInfo objFIExcel = new FileInfo(RL_ExcelFormatPath);

                    if (!DocumentFlag)
                        RL_DestinationPath = GetPath("ReportPath") + Form_DestinationReportFilePath + CurrentDate_String + @"\";
                    else
                    {
                        objPC.FormName = "EmployeeMaster";
                        RL_DestinationPath = GetPath_DocumentsMain(objPC.EmployeeId);
                        //RL_DestinationPath = GetPath("ReportPath") + Form_DestinationReportFilePath + CurrentDate_String + @"\";
                        objPC.FormName = "Letter";
                    }

                    DirectoryInfo DI = new DirectoryInfo(RL_DestinationPath);
                    DI.Create();

                    if (!DocumentFlag)
                        RL_DestinationPath += Form_ReportFileName +"-"+ CurrentDate_String + ".xlsx";
                    else
                        RL_DestinationPath += Form_ReportFileName + ".xlsx";

                    FileInfo objFIDelete = new FileInfo(RL_DestinationPath);

                    if (objFIDelete.Exists == true)
                        objFIDelete.Delete();
                    objFIExcel.CopyTo(RL_DestinationPath);
                }
            }
            else
            {
                RL_DestinationPath = GetPath("ReportPath") + Form_DestinationReportFilePath + CurrentDate_String + @"\";
                DirectoryInfo DI = new DirectoryInfo(RL_DestinationPath);
                DI.Create();
            }
        }

        public string String_To_Date(string CDate)
        {
            DateTime dt = Convert.ToDateTime(CDate);
            return dt.ToString(SetDateFormat);
        }

        public string Date_To_String(DateTime dt)
        {
            string dtString = string.Empty;
            return dt.ToString("dd/MM/yyyy HH:mm");
        }

        public void DeleteExcelFile()
        {
            if (!string.IsNullOrEmpty(RL_DestinationPath))
            {
                FileInfo fiDelete = new FileInfo(RL_DestinationPath);
                fiDelete.Delete();
            }
        }

        public string PDFFilePath = "";


        //public AutoCompleteStringCollection AC_BP()
        //{
        //    OleDbDataReader cmd = new SqlCommand("SELECT FirstName FROM Employees", con);
        //    ob.Open();
        //    OleDbDataReader reader = cmd.ExecuteReader();
        //    AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
        //    while (reader.Read())
        //    {
        //        MyCollection.Add(reader.GetString(0));
        //    }
        //    txtFirstName.AutoCompleteCustomSource = MyCollection;
        //    con.Close();
        //}

        public string CheckNullString(string ValueS)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(ValueS)))
                return ValueS;
            else
                return "";
        }

        public int CheckNullString_ReturnInt(string ValueS)
        {
            //ValueS = "1";
            if (!string.IsNullOrEmpty(Convert.ToString(ValueS)))
                return Convert.ToInt32(ValueS);
            else
                return 0;
        }

        public double CheckNullString_ReturnDouble(string ValueS)
        {
            //ValueS = "1";
            if (!string.IsNullOrEmpty(Convert.ToString(ValueS)))
                return Convert.ToDouble(ValueS);
            else
                return 0;
        }
        public void Get_CategoriesDetails_By_Id()
        {
            DataSet ds = new DataSet();
            ds = objQL.SP_Categories_By_CategoryId();
            if (ds.Tables[0].Rows.Count > 0)
            {
                objPC.CategoryFName = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["CategoryFName"]));
                objPC.CategorySName = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["CategorySName"]));
                objPC.OTFormula = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["OTFormula"]));
                objPC.MinOT = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["MinOT"]));
                objPC.MaxOT = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["MaxOT"])));
                objPC.MaxOTMin = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["MaxOTMin"]));
                objPC.ConsiderOnlyFirstAndLastPunchInAttCalculations = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["ConsiderOnlyFirstAndLastPunchInAttCalculations"])));
                objPC.GraceTimeForLateComingMins = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["GraceTimeForLateComingMins"]));
                objPC.NeglectLastInPunchForMissedOutPunch = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["NeglectLastInPunchForMissedOutPunch"])));
                objPC.GraceTimeForEarlyGoingMins = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["GraceTimeForEarlyGoingMins"]));
                objPC.WeeklyOff1 = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["WeeklyOff1"])));
                objPC.WeeklyOff1Value = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["WeeklyOff1Value"]));
                objPC.WeeklyOff2 = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["WeeklyOff2"])));
                objPC.WeeklyOff2Value = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["WeeklyOff2Value"]));
                objPC.FirstR = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["1st"])));
                objPC.SecondR = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["2nd"])));
                objPC.ThirdR = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["3rd"])));
                objPC.ForthR = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["4th"])));
                objPC.FiveR = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["5th"])));
                objPC.ConsiderEarlyComingPunch = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["ConsiderEarlyComingPunch"])));
                objPC.ConsiderLateGoingPunch = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["ConsiderLateGoingPunch"])));
                objPC.DeductBreakHoursFormWorkDuration = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["DeductBreakHoursFormWorkDuration"])));
                objPC.CalculateHalfDayifWorkDurationIsLessThan = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["CalculateHalfDayifWorkDurationIsLessThan"])));
                objPC.CalculateHalfDayifWorkDurationIsLessThanMins = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["CalculateHalfDayifWorkDurationIsLessThanMins"]));
                objPC.CalculationAbsentIfWorkDurationIsLessThan = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["CalculationAbsentIfWorkDurationIsLessThan"])));
                objPC.CalculationAbsentIfWorkDurationIsLessThanMins = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["CalculationAbsentIfWorkDurationIsLessThanMins"]));
                objPC.OnPartialDayCalculateHalfDayifWorkDurationisLessThan = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["OnPartialDayCalculateHalfDayifWorkDurationisLessThan"])));
                objPC.OnPartialDayCalculateHalfDayifWorkDurationisLessThanMins = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["OnPartialDayCalculateHalfDayifWorkDurationisLessThanMins"]));
                objPC.OnPartialDayCalculateAbsentDayifWorkDurationislessThan = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["OnPartialDayCalculateAbsentDayifWorkDurationislessThan"])));
                objPC.OnPartialDayCalculateAbsentDayifWorkDurationislessThanMins = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["OnPartialDayCalculateAbsentDayifWorkDurationislessThanMins"]));
                objPC.MarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["MarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent"])));
                objPC.MarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["MarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent"])));
                objPC.MWOHAbsentifBothPrefixandSuffixDayisAbsent = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["MWOHAbsentifBothPrefixandSuffixDayisAbsent"])));
                objPC.Mark = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Mark"])));
                objPC.MarkValue = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["MarkValue"]));
                objPC.AbsentWhenLateForValue = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["AbsentWhenLateForValue"]));
                objPC.MarkHalfDayifLateBy = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["MarkHalfDayifLateBy"])));
                objPC.MarkHalfDayifLateByMins = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["MarkHalfDayifLateByMins"]));
                objPC.MarkHalfDayifEarlyGoingBy = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["MarkHalfDayifEarlyGoingBy"])));
                objPC.MarkHalfDayifEarlyGoingByMins = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["MarkHalfDayifEarlyGoingByMins"]));
            }
        }

        //CommanMaster Save_Update_Delete

        public string ColumnNameCM = string.Empty, CommanValue = string.Empty;
        public int Result = 0, CommanMasterId = 0;

        public bool CheckExistCM()
        {
            DataSet ds = new DataSet();
            objBL.Query = "select CommanMasterId from commanmaster where CancelTag=0 and " + ColumnNameCM + "='" + CommanValue + "'";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][0])))
                    CommanMasterId = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());

                return true;
            }
            else
                return false;
        }

        public int Save_CommanMaster()
        {
            //Insert 
            Result = 0;
            if (CommanMasterId == 0)
                objBL.Query = "insert into commanmaster(" + ColumnNameCM + ") values('" + CommanValue + "')";
            else
                objBL.Query = "update commanmaster set " + ColumnNameCM + "='" + CommanValue + "' where CancelTag=0 and CommanMasterId=" + CommanMasterId + ")";

            Result = objBL.Function_ExecuteNonQuery();

            return Result;
        }

        public void FillGrid_Comman(DataGridView dgv)
        {
            DataSet ds = new DataSet();
            objBL.Query = "select CommanMasterId," + ColumnNameCM + " from commanmaster where " + ColumnNameCM + " NOT IN('') and CancelTag=0";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgv.DataSource = ds.Tables[0];
                dgv.Columns[0].Visible = false;
                dgv.Columns[1].Width = 500;
            }
        }

        public void Fill_ComboBox_Comman(ComboBox cmb)
        {
            cmb.DataSource = null;
            DataSet ds = new DataSet();
            //objBL.Query = "select CommanMasterId," + ColumnNameCM + " from commanmaster where CancelTag=0";
            //objBL.Query = "select CommanMasterId," + ColumnNameCM + " from commanmaster where " + ColumnNameCM + " IS NOT NULL OR Trim(" + ColumnNameCM + ")='' and CancelTag=0 order by " + ColumnNameCM + " asc";
            objBL.Query = "select CommanMasterId," + ColumnNameCM + " from commanmaster where " + ColumnNameCM + " NOT IN('') and CancelTag=0 order by " + ColumnNameCM + " asc"; // IS NOT NULL OR Trim(" + ColumnNameCM + ")='' and CancelTag=0 order by " + ColumnNameCM + " asc";

            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmb.DataSource = ds.Tables[0];
                cmb.ValueMember = "CommanMasterId"; // ds.Tables[0].Rows[0][0].ToString();
                cmb.DisplayMember = ColumnNameCM;  //ds.Tables[0].Rows[0][1].ToString(); //.Columns[0].Visible = false;
                cmb.SelectedIndex = -1;
            }
        }

        public void Fill_Employee_TimeOffice_Ticket(ComboBox cmb)
        {
            cmb.DataSource = null;
            DataSet ds = new DataSet();
            objBL.Query = "SELECT EmployeeId,EmployeeName FROM employees where DepartmentId IN(41,58) and CancelTag=0 and Status='WORKING';";
            //objBL.Query = "select CommanMasterId," + ColumnNameCM + " from commanmaster where " + ColumnNameCM + " IS NOT NULL OR Trim(" + ColumnNameCM + ")='' and CancelTag=0 order by " + ColumnNameCM + " asc";
            //objBL.Query = "select CommanMasterId," + ColumnNameCM + " from commanmaster where " + ColumnNameCM + " NOT IN('') and CancelTag=0 order by " + ColumnNameCM + " asc"; // IS NOT NULL OR Trim(" + ColumnNameCM + ")='' and CancelTag=0 order by " + ColumnNameCM + " asc";

            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmb.DataSource = ds.Tables[0];
                cmb.ValueMember = "EmployeeId"; // ds.Tables[0].Rows[0][0].ToString();
                cmb.DisplayMember = "EmployeeName";  //ds.Tables[0].Rows[0][1].ToString(); //.Columns[0].Visible = false;
                cmb.SelectedIndex = -1;
            }
        }

        public void Fill_Financial_Year(ComboBox cmb)
        {
            cmb.DataSource = null;
            DataSet ds = new DataSet();
            //objBL.Query = "select FinancialYearId,FinancialYear from financialyearmaster where CancelTag=0 and PrimaryFlag=1 ";
            objBL.Query = "select FinancialYearId,FinancialYear from financialyearmaster where CancelTag=0 order by FinancialYearId desc"; // and PrimaryFlag=1 ";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmb.DataSource = ds.Tables[0];
                cmb.ValueMember = "FinancialYearId"; // ds.Tables[0].Rows[0][0].ToString();
                cmb.DisplayMember = "FinancialYear";  //ds.Tables[0].Rows[0][1].ToString(); //.Columns[0].Visible = false;
                //cmb.SelectedIndex = 1;
            }
        }

        public string Get_Financial_Year()
        {
            string FinancialYear = string.Empty;
             
            DataSet ds = new DataSet();
            //objBL.Query = "select FinancialYearId,FinancialYear from financialyearmaster where CancelTag=0 and PrimaryFlag=1 ";
            objBL.Query = "select FinancialYearId,FinancialYear from financialyearmaster where CancelTag=0 order by FinancialYearId desc"; // and PrimaryFlag=1 ";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
                FinancialYear = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["FinancialYear"]));
            else
                FinancialYear = "-";

            return FinancialYear;
        }

        public string MenuIn = string.Empty;
        public void Fill_CheckListBox_Comman(CheckedListBox clb)
        {
            clb.DataSource = null;
            DataSet ds = new DataSet();
            objBL.Query = "select CommanMasterId," + ColumnNameCM + " from commanmaster where " + ColumnNameCM + " IS NOT NULL and CancelTag=0 " + MenuIn + " order by " + ColumnNameCM + " asc";

            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                clb.DataSource = ds.Tables[0];
                clb.ValueMember = "CommanMasterId"; // ds.Tables[0].Rows[0][0].ToString();
                clb.DisplayMember = ColumnNameCM;  //ds.Tables[0].Rows[0][1].ToString(); //.Columns[0].Visible = false;
                clb.SelectedIndex = -1;
            }
        }

        public void ClearAll_CommanMaster()
        {
            ColumnNameCM = string.Empty;
            CommanValue = string.Empty;
            Result = 0;
            CommanMasterId = 0;
        }

        public void Fill_Employee_ListBox1(ListBox lb)
        {
            using (MySqlConnection con = objBL.ReturnConnection())
            {
                con.Open();

                string query = "SELECT EmployeeId, EmployeeName FROM employees ORDER BY EmployeeName ASC";

                using (MySqlDataAdapter da = new MySqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    lb.DataSource = dt;
                    lb.DisplayMember = "EmployeeName"; // shown in listbox
                    lb.ValueMember = "EmployeeId";     // hidden value
                }
            }
        }

        public void Fill_Employee_ListBox(ListBox lb, string SearchText, string SearchType)
        {
            lb.DataSource = null; OrderBy = string.Empty;
            DataTable dt = new DataTable();

            MainQuery = "select EmployeeId,EmployeeName,EmployeeCode, CONCAT(EmployeeName,'- Code-',EmployeeCode) as 'ConcatEmpNameCode'  from employees where CancelTag=0";

            if (SearchType == "Text")
                WhereClause = " and EmployeeName like '%" + SearchText + "%'";

            OrderBy = " order by EmployeeName asc";
            objBL.Query = MainQuery + WhereClause + OrderBy;

            dt = objBL.ReturnDataTable();
             
            if (dt.Rows.Count > 0)
            {
                lb.Visible = true;
                lb.DataSource = dt;
                lb.DisplayMember = "ConcatEmpNameCode"; // shown in listbox
                lb.ValueMember = "EmployeeId";     // hidden value
            }
        }
        public void Fill_Employee_Details_RichTextBox(RichTextBox rtb, int EID)
        {
            rtb.Text = "";
            DataTable dt = new DataTable();
            //objBL.Query = @"SELECT EmployeeId, EmployeeCode, EmployeeName  FROM employees  WHERE EmployeeId = " + EID + " and CancelTag=0 ";
            objBL.Query = @"SELECT E.EmployeeId,E.EmployeeCode,E.EmployeeName,E.MobileNo,DM.Designation,L.LocationName,D.Department,C.CategoryFName FROM employees E inner join locationmaster L on L.LocationId = E.LocationId inner join departmentmaster D on D.DepartmentId = E.DepartmentId inner join designationmaster DM on DM.DesignationId = E.DesignationId inner join categories C on C.CategoryId=E.CategoryId where C.CancelTag=0 and E.EmployeeId = " + EID + " and E.CancelTag = 0 and L.CancelTag = 0 and D.CancelTag = 0 and DM.CancelTag = 0 ";

            dt = objBL.ReturnDataTable();
            if (dt.Rows.Count > 0)
            {
                rtb.AppendText(
                            "Employee Name \t: " + CheckNullString(Convert.ToString(dt.Rows[0]["EmployeeName"])) + "\n" +
                            "EmployeeCode  \t: " + CheckNullString(Convert.ToString(dt.Rows[0]["EmployeeCode"])) + "\n" +
                            "Designation   \t: " + CheckNullString(Convert.ToString(dt.Rows[0]["Designation"])) + "\n" +
                            "Location      \t: " + CheckNullString(Convert.ToString(dt.Rows[0]["LocationName"])) + "\n" +
                            "Department    \t: " + CheckNullString(Convert.ToString(dt.Rows[0]["Department"])) + "\n" +
                            "Mobile        \t: " + CheckNullString(Convert.ToString(dt.Rows[0]["MobileNo"])) + "\n" +
                            "Weekly Off    \t: " + CheckNullString(Convert.ToString(dt.Rows[0]["CategoryFName"])) + "\n" +
                            "EmployeeId    \t: " + CheckNullString(Convert.ToString(dt.Rows[0]["EmployeeId"])) 
                        );
            }
        }

        public void Fill_Employees_CheckedListBox(CheckedListBox clb)
        {
            DataSet ds = new DataSet();
            objBL.Query = "select EmployeeId,EmployeeCode,ESSLEmployeeId,EmpInital,EmployeeName, CONCAT(EmployeeName,'- Code-',EmployeeCode) as 'ConcatEmp' from Employees where CancelTag=0 and EmployeeId IN(select EmployeeId from Login where CancelTag=0) order by EmployeeName asc";
            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
            {
                clb.DataSource = ds.Tables[0];
                clb.DisplayMember = "ConcatEmp";
                clb.ValueMember = "EmployeeId";
            }
        }

        public void Fill_Employees_CheckedListBox_By_UserType(CheckedListBox clb,string UserType)
        {
            clb.DataSource = null;
            DataSet ds = new DataSet();
            objBL.Query = "select EmployeeId,EmployeeCode,ESSLEmployeeId,EmpInital,EmployeeName, CONCAT(EmployeeName,'- Code-',EmployeeCode) as 'ConcatEmp' from Employees where CancelTag=0 and EmployeeId IN(select L.EmployeeId from Login L inner join UserTypeMaster UTM on UTM.UserTypeId=L.UserTypeId where L.CancelTag=0 and UTM.CancelTag=0 and UTM.UserType='"+UserType+"') order by EmployeeName asc";
            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
            {
                clb.DataSource = ds.Tables[0];
                clb.DisplayMember = "ConcatEmp";
                clb.ValueMember = "EmployeeId";
            }
        }

        public DataSet Fill_LoginWindow_Employee_ReturnDS()
        {
            DataSet ds = new DataSet();
            objBL.Query = "select EmployeeId,EmployeeCode,ESSLEmployeeId,EmpInital,EmployeeName,CONCAT(EmployeeName,'- Code-',EmployeeCode) as 'ConcatEmp' from Employees where CancelTag=0 and EmployeeId IN(select EmployeeId from Login where CancelTag=0) order by EmployeeCode asc";
            ds = objBL.ReturnDataSet();
            return ds;
        }

        public void Get_UserRightsDetails()
        {
            DataSet ds = new DataSet();
            objBL.Query = "select UserRightsId,EmployeeId,MenuName,AddFlag,EditFlag,DeleteFlag,ViewFlag,ApprovalFlag from userrights where EmployeeId=" + BusinessLayer.EmployeeLoginId_Static + " and MenuName='" + objPC.MenuName + "'";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                objPC.UserRightsId = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["UserRightsId"])));
                objPC.MenuName = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["MenuName"]));
                objPC.AddFlag = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["AddFlag"])));
                objPC.EditFlagUR = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["EditFlag"])));
                objPC.DeleteFlagUR = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["DeleteFlag"])));
                objPC.ViewFlag = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["ViewFlag"])));
                objPC.ApprovalFlag = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["ApprovalFlag"])));
            }
        }

        public void Get_UserRights_By_MenuName(string MName)
        {
            DataSet ds = new DataSet();
            objBL.Query = "select UserRightsId,EmployeeId,MenuName,AddFlag,EditFlag,DeleteFlag,ViewFlag,ApprovalFlag from userrights where EmployeeId=" + BusinessLayer.EmployeeLoginId_Static + " and MenuName='" + MName + "'";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                objPC.UserRightsId = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["UserRightsId"])));
                objPC.MenuName = CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["MenuName"]));
                objPC.AddFlag = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["AddFlag"])));
                objPC.EditFlagUR = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["EditFlag"])));
                objPC.DeleteFlagUR = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["DeleteFlag"])));
                objPC.ViewFlag = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["ViewFlag"])));
                objPC.ApprovalFlag = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["ApprovalFlag"])));
            }
        }

        public void Get_Incharge_Senior_OfficerId()
        {
            objPC.InchargeId = 0;
            if (objPC.LocationId > 0 && objPC.DepartmentId > 0)
            {
                DataTable dt = new DataTable();
                objBL.Query = "select LWDU.*,E.EmployeeName as 'InchargeName',E1.EmployeeName as 'PlantHeadName',E2.EmployeeName as 'HRName' from locationwisedepartmentusers LWDU inner join " +
                              " Employees E on E.EmployeeId=LWDU.InchargeId inner join " +
                              " Employees E1 on E1.EmployeeId=LWDU.PlantHeadId inner join " +
                              " Employees E2 on E2.EmployeeId=LWDU.HRId " +
                              " where LWDU.LocationId=" + objPC.LocationId + " and LWDU.DepartmentId=" + objPC.DepartmentId + "";
                dt = objBL.ReturnDataTable();

                if (dt.Rows.Count > 0)
                {
                    objPC.InchargeId = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(dt.Rows[0]["InchargeId"])));
                    objPC.PlantHeadId = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(dt.Rows[0]["PlantHeadId"])));
                    objPC.HRId = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(dt.Rows[0]["HRId"])));

                    objPC.InchargeName = CheckNullString(Convert.ToString(dt.Rows[0]["InchargeName"]));
                    objPC.PlantHeadName = CheckNullString(Convert.ToString(dt.Rows[0]["PlantHeadName"]));
                    objPC.HRName = CheckNullString(Convert.ToString(dt.Rows[0]["HRName"]));
                }


                if (objPC.InchargeId == 0)
                {
                    objPC.InchargeId = BusinessLayer.EmployeeLoginId_Static;
                    objPC.InchargeName = BusinessLayer.UserName_Full_Static;
                }
                if (objPC.PlantHeadId == 0)
                {
                    objPC.PlantHeadId = BusinessLayer.EmployeeLoginId_Static;
                    objPC.PlantHeadName = BusinessLayer.UserName_Full_Static;
                }
                if (objPC.HRId == 0)
                {
                    objPC.HRId = BusinessLayer.EmployeeLoginId_Static;
                    objPC.HRName = BusinessLayer.UserName_Full_Static;
                }
            }
        }

        //14-09-2024 Edited
        public void Get_Incharge_Senior_OfficerId_for_memo()
        {
            string PlantHead_T = string.Empty, Incharge_T = string.Empty;

            objPC.InchargeId = 0;
            if (objPC.LocationId > 0 && objPC.DepartmentId > 0)
            {
                DataTable dtPlantHead = new DataTable();
                objBL.Query = "select E.EmployeeName " +
                              " from Employees E inner join designationmaster DM on DM.DesignationId=E.DesignationId " +
                              " where and E.Status='WORKING' and E.LocationId=" + objPC.LocationId + " and DM.Designation='PLANT HEAD'";
                dtPlantHead = objBL.ReturnDataTable();

                if (dtPlantHead.Rows.Count > 0)
                {
                    //objPC.InchargeId = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(dt.Rows[0]["InchargeId"])));
                    //objPC.PlantHeadId = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(dt.Rows[0]["PlantHeadId"])));
                    //objPC.HRId = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(dt.Rows[0]["HRId"])));

                    //objPC.InchargeName = CheckNullString(Convert.ToString(dt.Rows[0]["InchargeName"]));
                    objPC.PlantHeadName = CheckNullString(Convert.ToString(dtPlantHead.Rows[0]["EmployeeName"]));
                    //objPC.HRName = CheckNullString(Convert.ToString(dt.Rows[0]["HRName"]));
                }

                DataTable dtIncharge = new DataTable();
                objBL.Query = "select E.EmployeeName " +
                              " from Employees E inner join designationmaster DM on DM.DesignationId=E.DesignationId " +
                              " where E.LocationId=" + objPC.LocationId + " and E.DepartmentId=" + objPC.DepartmentId + " and DM.Designation='INCHARGE'";
                dtIncharge = objBL.ReturnDataTable();

                if (dtIncharge.Rows.Count > 0)
                {
                    objPC.InchargeName = CheckNullString(Convert.ToString(dtIncharge.Rows[0]["EmployeeName"]));
                }

                DataTable dt = new DataTable();
                objBL.Query = "select LWDU.*,E.EmployeeName as 'InchargeName',E1.EmployeeName as 'PlantHeadName',E2.EmployeeName as 'HRName' from locationwisedepartmentusers LWDU inner join " +
                              " Employees E on E.EmployeeId=LWDU.InchargeId inner join " +
                              " Employees E1 on E1.EmployeeId=LWDU.PlantHeadId inner join " +
                              " Employees E2 on E2.EmployeeId=LWDU.HRId " +
                              " where LWDU.LocationId=" + objPC.LocationId + " and LWDU.DepartmentId=" + objPC.DepartmentId + "";
                dt = objBL.ReturnDataTable();

                if (dt.Rows.Count > 0)
                {
                    //objPC.InchargeId = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(dt.Rows[0]["InchargeId"])));
                    //objPC.PlantHeadId = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(dt.Rows[0]["PlantHeadId"])));
                    objPC.HRId = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(dt.Rows[0]["HRId"])));

                    //objPC.InchargeName = CheckNullString(Convert.ToString(dt.Rows[0]["InchargeName"]));
                    //objPC.PlantHeadName = CheckNullString(Convert.ToString(dt.Rows[0]["PlantHeadName"]));
                    objPC.HRName = CheckNullString(Convert.ToString(dt.Rows[0]["HRName"]));
                }


                //if (objPC.InchargeId == 0)
                //{
                //    objPC.InchargeId = BusinessLayer.EmployeeLoginId_Static;
                //    objPC.InchargeName = BusinessLayer.UserName_Full_Static;
                //}
                //if (objPC.PlantHeadId == 0)
                //{
                //    objPC.PlantHeadId = BusinessLayer.EmployeeLoginId_Static;
                //    objPC.PlantHeadName = BusinessLayer.UserName_Full_Static;
                //}
                if (objPC.HRId == 0)
                {
                    objPC.HRId = BusinessLayer.EmployeeLoginId_Static;
                    objPC.HRName = BusinessLayer.UserName_Full_Static;
                }
            }
        }

        public string WhereClasuse_CompOff_Comman1()
        {
            if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR || BusinessLayer.UserType == BusinessResources.USER_TYPE_HROFFICER)
                WhereClause = " ";
            else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER)
                WhereClause = " and E.LocationId IN (select LocationId from locationwisedepartmentusers where PlantHeadId=" + BusinessLayer.EmployeeLoginId_Static + ") and E.DepartmentId IN (select DepartmentId from locationwisedepartmentusers where PlantHeadId=" + BusinessLayer.EmployeeLoginId_Static + ") ";
            else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_SENIOROFFICER)
                WhereClause = " and E.LocationId IN (select LocationId from locationwisedepartmentusers where InchargeId=" + BusinessLayer.EmployeeLoginId_Static + ") and E.DepartmentId IN (select DepartmentId from locationwisedepartmentusers where InchargeId=" + BusinessLayer.EmployeeLoginId_Static + ") ";
            else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_OFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_SUPERVISOR)
                WhereClause = " and E.EmployeeId=" + BusinessLayer.EmployeeLoginId_Static + " ";
            else
                WhereClause = " ";

            return WhereClause;
        }

        //New Code Changes 
        public string WhereClasuse_CompOff_Comman()
        {
            if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR || BusinessLayer.UserType == BusinessResources.USER_TYPE_HROFFICER)
                WhereClause = " ";
            else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER)
            {
                WhereClause = " and LWDU.PlantHeadId=" + BusinessLayer.EmployeeLoginId_Static;

                if (objPC.FlagC == 0)
                {
                    //8,17,5076,23,41,19,55,100001,100002
                    if (BusinessLayer.UserName_Static == "8" || BusinessLayer.UserName_Static == "17" || BusinessLayer.UserName_Static == "19" || BusinessLayer.UserName_Static == "23" || BusinessLayer.UserName_Static == "41" || BusinessLayer.UserName_Static == "55" || BusinessLayer.UserName_Static == "5076" || BusinessLayer.UserName_Static == "100001" || BusinessLayer.UserName_Static == "100002")
                        WhereClause = " and E.EmployeeId=" + BusinessLayer.EmployeeLoginId_Static + " ";
                }
            }
            else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_SENIOROFFICER)
                WhereClause = " and LWDU.InchargeId=" + BusinessLayer.EmployeeLoginId_Static;// + ") and E.DepartmentId IN (select DepartmentId from locationwisedepartmentusers where InchargeId=" + BusinessLayer.EmployeeLoginId_Static + ") ";
            else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_OFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_SUPERVISOR)
                WhereClause = " and E.EmployeeId=" + BusinessLayer.EmployeeLoginId_Static + " ";
            else
                WhereClause = " ";

            return WhereClause;
        }

        public void SetApprovalStatusColor(RichTextBox rtb)
        {
            if (!string.IsNullOrEmpty(objPC.ApprovalStatus))
            {
                if (objPC.ApprovalStatus == BusinessResources.LS_Pending)
                    rtb.BackColor = Color.FromName(BusinessResources.LS_Pending_Color);
                else if (objPC.ApprovalStatus == BusinessResources.LS_HRApproved)
                    rtb.BackColor = Color.FromName(BusinessResources.LS_HRApproved_Color);
                else if (objPC.ApprovalStatus == BusinessResources.LS_InchargeApproved)
                    rtb.BackColor = Color.FromName(BusinessResources.LS_InchargeApproved_Color);
                else if (objPC.ApprovalStatus == BusinessResources.LS_ManagerApproved)
                    rtb.BackColor = Color.FromName(BusinessResources.LS_Manager_Color);
                else if (objPC.ApprovalStatus == BusinessResources.LS_Completed)
                    rtb.BackColor = Color.FromName(BusinessResources.LS_Completed_Color);
                else if (objPC.ApprovalStatus == BusinessResources.LS_Remarks)
                    rtb.BackColor = Color.FromName(BusinessResources.LS_Remarks_Color);
                else if (objPC.ApprovalStatus == BusinessResources.LS_Reject)
                    rtb.BackColor = Color.FromName(BusinessResources.LS_Reject_Color);
                else if (objPC.ApprovalStatus == BusinessResources.LS_Error)
                    rtb.BackColor = Color.FromName(BusinessResources.LS_Error_Color);
                else
                    rtb.BackColor = Color.White;
            }
        }

        //Asset Master

        public void CommanAssetMaster(ComboBox cmb, string ColumnName1)
        {
            //objBL.Query = "select ID," + ColumnName + " from HDDSSDMaster where " + ColumnName + " IS NOT NULL OR Trim(" + ColumnName + ")='' and CancelTag=0 order by ID asc";
            objBL.Query = "select CommanAssetMasterId," + ColumnName1 + " from commanassetmaster where " + ColumnName1 + " NOT IN('') and CancelTag=0 order by " + ColumnName1 + " asc"; // " + ColumnName1 + " IS NOT NULL OR Trim(" + ColumnName1 + ")='' and CancelTag=0 order by " + ColumnName1 + " asc";
            //Designation wise Records
            //
            objBL.FillComboBox(cmb, ColumnName1, "CommanAssetMasterId");
            cmb.SelectedIndex = -1;
        }

        public void Fill_AssetTypeMaster(ComboBox cmb)
        {
            objBL.Query = "select AssetTypeId,AssetType from assettypemaster where CancelTag=0 order by AssetType asc";
            objBL.FillComboBox(cmb, "AssetType", "AssetTypeId");
            cmb.SelectedIndex = -1;
        }

        public void Fill_OSMaster(ComboBox cmb)
        {
            objBL.Query = "select OSMasterId,OSName from osmaster where CancelTag=0 order by OSName asc";
            objBL.FillComboBox(cmb, "OSName", "OSMasterId");
            cmb.SelectedIndex = -1;
        }

        public void Fill_CheckListBox_Softwares(CheckedListBox clb)
        {
            // clb.Items.Clear();
            clb.DataSource = null;
            DataSet ds = new DataSet();
            objBL.Query = "select CommanAssetMasterId,Softwares from commanassetmaster where Softwares NOT IN('') order by Softwares asc";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                //clb.Visible = true;
                clb.DataSource = ds.Tables[0];
                clb.DisplayMember = "Softwares";
                clb.ValueMember = "CommanAssetMasterId";
                //clb.SelectedIndex = -1;
            }
        }

        public void Fill_MakeMaster(ComboBox cmb)
        {
            objBL.Query = "select MakeId,MakeName from makemaster where CancelTag=0 order by MakeName asc";
            objBL.FillComboBox(cmb, "MakeName", "MakeId");
            cmb.SelectedIndex = -1;
        }

        public DialogResult Report_Record_Show_Message()
        {
            DialogResult dr;
            return dr = MessageBox.Show("Do you want to print QR Code?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        //Ticket

        public List<int> EmplCode_L = new List<int>();

        public void Fill_EmployeeName_AssignTo_CodeWise(ComboBox cmb)
        {
            string ECode = string.Empty;
            if (EmplCode_L.Count > 0)
            {
                for (int i = 0; i < EmplCode_L.Count; i++)
                {
                    ECode += "'" + EmplCode_L[i].ToString() + "',";
                }
                ECode = ECode.Remove(ECode.Length - 1);

                ECode = "and UserName IN(" + ECode + ")";
                objBL.Query = "select ID,UserType,Department,EmployeeName,UserName from Login where CancelTag=0 and UserType NOT IN('HOD') and Department IN('IT') " + ECode + "";
                objBL.FillComboBox(cmb, "EmployeeName", "ID");
                cmb.SelectedIndex = -1;
            }
        }

        public void Fill_Department_Ticket(ComboBox cmb)
        {
            string SetDepartment = string.Empty;

            if (BusinessLayer.Department == "TIME OFFICE")
            {
                if (BusinessLayer.Department == "TIME OFFICE" && BusinessLayer.UserType == BusinessResources.USER_TYPE_OFFICER)
                     SetDepartment = "'TIME OFFICE', 'INFORMATION TECHNOLOGY'";
                else
                    SetDepartment = "'INFORMATION TECHNOLOGY'";
            }
            else if (BusinessLayer.Department == "INFORMATION TECHNOLOGY")
                SetDepartment = "'TIME OFFICE'";
            else
                SetDepartment = "'TIME OFFICE', 'INFORMATION TECHNOLOGY'";

            if(objPC.ViewTicketFlag)
                SetDepartment = "'TIME OFFICE', 'INFORMATION TECHNOLOGY'";
             
            objBL.Query = "select DepartmentId,Department from departmentmaster where CancelTag=0 and Department IN(" + SetDepartment + ")";
            objBL.FillComboBox(cmb, "Department", "DepartmentId");
            cmb.SelectedIndex = -1;
        }

        //public string Get_OS_Name()
        //{
        //    var name = (from x in new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().Cast<ManagementObject>() select x.GetPropertyValue("Caption")).FirstOrDefault();
        //    return name != null ? name.ToString() : "Unknown";
        //}

        public string Get_System_CommanDetails(string TableName, string ColumnName)
        {
            string manufacturer = string.Empty;
            try
            {
                //Query WMI for manufacturer
                ObjectQuery query = new ObjectQuery("SELECT * FROM " + TableName + "");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                ManagementObjectCollection collection = searcher.Get();
                DateTime installDate = DateTime.MinValue;

                foreach (ManagementObject obj in collection)
                {
                    manufacturer = obj[ColumnName].ToString();

                    if(TableName == BusinessResources.A_Win32_ComputerSystem && ColumnName == BusinessResources.A_TotalPhysicalMemory)
                    {
                        ulong memoryBytes = (ulong)obj[BusinessResources.A_TotalPhysicalMemory];
                        double memoryGB = memoryBytes / (1024.0 * 1024.0 * 1024.0);
                        memoryGB = Math.Round(memoryGB, 0);
                        manufacturer = memoryGB + " GB";

                        RAMType = GetRAMType();
                        //string formFactor = obj["FormFactor"].ToString();

                        //string ramType = GetRamType(memoryType, formFactor);
                    }
                    else if (TableName == BusinessResources.A_Win32_OperatingSystem && ColumnName == BusinessResources.A_InstallDate)
                    {
                        if (!string.IsNullOrEmpty(manufacturer) && manufacturer.Length >= 8)
                        {
                            // InstallDate is in the format: yyyymmddhhmmss.mmmmmmsUUU
                            int year = int.Parse(manufacturer.Substring(0, 4));
                            int month = int.Parse(manufacturer.Substring(4, 2));
                            int day = int.Parse(manufacturer.Substring(6, 2));
                            installDate = new DateTime(year, month, day);
                            manufacturer = installDate.ToString(BusinessResources.DATEFORMATDDMMMYYYY);
                        }
                    }
                    else if (TableName == BusinessResources.A_Win32_ComputerSystem && ColumnName == BusinessResources.A_PCSystemType)
                    {
                        string type = obj["PCSystemType"].ToString();
                        string model = obj["Model"].ToString();

                        if (type == "2")
                        {
                            manufacturer = "Laptop";
                        }
                        else if (type == "3")
                        {
                            manufacturer = "Desktop";
                        }
                    }
                    else
                    {

                    }
                }

                return manufacturer;
            }
            catch (ManagementException e)
            {
                return manufacturer;
                //Console.WriteLine("An error occurred while querying WMI: " + e.Message);
            }
            catch (Exception ex)
            {
                return manufacturer;
                //Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public string Get_System_Data(string Column1, string Column2)
        {
            string ReturnConfiguration = string.Empty;
            //Serial Number
            if (Column1 == BusinessResources.A_Win32_BIOS && Column2 == BusinessResources.A_SerialNumber)
                ReturnConfiguration = Get_System_CommanDetails(BusinessResources.A_Win32_BIOS, BusinessResources.A_SerialNumber); // "Win32_BIOS" "SerialNumber" //Get Serial Number
            //DeviceManufracturer
            else if (Column1 == BusinessResources.A_Win32_ComputerSystem && Column2 == BusinessResources.A_Manufacturer)
                ReturnConfiguration = Get_System_CommanDetails(BusinessResources.A_Win32_ComputerSystem, BusinessResources.A_Manufacturer); // "Win32_ComputerSystem" "Manufacturer"
            //Processor
            else if (Column1 == BusinessResources.A_Processor)
            {
                var key = Registry.LocalMachine.OpenSubKey(@"HARDWARE\DESCRIPTION\System\CentralProcessor\0\");
                var processorName = key.GetValue("ProcessorNameString");
                ReturnConfiguration = processorName.ToString();
                //ReturnConfiguration = Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER");
            }
            //RAM
            else if (Column1 == BusinessResources.A_Win32_ComputerSystem && Column2 == BusinessResources.A_TotalPhysicalMemory)
                ReturnConfiguration = Get_System_CommanDetails(BusinessResources.A_Win32_ComputerSystem, BusinessResources.A_TotalPhysicalMemory); // "Win32_ComputerSystem" "TotalPhysicalMemory"
            //Motherboard Serial Number
            else if (Column1 == BusinessResources.A_Win32_BaseBoard && Column2 == BusinessResources.A_SerialNumber)
                ReturnConfiguration = Get_System_CommanDetails(BusinessResources.A_Win32_BaseBoard, BusinessResources.A_SerialNumber); // "Win32_BaseBoard" "SerialNumber" //Motherboard Serial Number
            //Device ID
            else if (Column1 == BusinessResources.A_Win32_ComputerSystemProduct && Column2 == BusinessResources.A_UUID)
                ReturnConfiguration = Get_System_CommanDetails(BusinessResources.A_Win32_ComputerSystemProduct, BusinessResources.A_UUID); // "Win32_ComputerSystemProduct" "UUID" //Device ID
            //Product Id
            else if (Column1 == BusinessResources.A_Win32_OperatingSystem && Column2 == BusinessResources.A_SerialNumber)
                ReturnConfiguration = Get_System_CommanDetails(BusinessResources.A_Win32_OperatingSystem, BusinessResources.A_SerialNumber); // "Win32_OperatingSystem" "SerialNumber" ////Product Id
            //OS Name (Edition)
            else if (Column1 == BusinessResources.A_Win32_OperatingSystem && Column2 == BusinessResources.A_Caption)
                ReturnConfiguration = Get_System_CommanDetails(BusinessResources.A_Win32_OperatingSystem, BusinessResources.A_Caption); // "Win32_OperatingSystem" "Caption" //Edition OS Name
            //InstallDate
            else if (Column1 == BusinessResources.A_Win32_OperatingSystem && Column2 == BusinessResources.A_InstallDate)
                ReturnConfiguration = Get_System_CommanDetails(BusinessResources.A_Win32_OperatingSystem, BusinessResources.A_InstallDate); //"Win32_OperatingSystem" "Caption" //Installed Date     //  Get_OS_Installed(); // Get_System_CommanDetails(BusinessResources.A_Win32_OperatingSystem, BusinessResources.A_Caption); // "Win32_ComputerSystemProduct" "A_UUID" //Edition OS Name
            //HDD Type
            else if (Column1 == BusinessResources.A_Win32_DiskDrive && Column2 == BusinessResources.A_InterfaceType)
                ReturnConfiguration = Get_System_CommanDetails(BusinessResources.A_Win32_DiskDrive, BusinessResources.A_InterfaceType); //"Win32_OperatingSystem" "Caption" //Installed Date     //  Get_OS_Installed(); // Get_System_CommanDetails(BusinessResources.A_Win32_OperatingSystem, BusinessResources.A_Caption); // "Win32_ComputerSystemProduct" "A_UUID" //Edition OS Name
            //Desktop/Laptop AssetType
            else if (Column1 == BusinessResources.A_Win32_ComputerSystem && Column2 == BusinessResources.A_PCSystemType)
                ReturnConfiguration = Get_System_CommanDetails(BusinessResources.A_Win32_ComputerSystem, BusinessResources.A_PCSystemType); //"Win32_ComputerSystem" "PCSystemType" //Installed Date     //  Get_OS_Installed(); // Get_System_CommanDetails(BusinessResources.A_Win32_OperatingSystem, BusinessResources.A_Caption); // "Win32_ComputerSystemProduct" "A_UUID" //Edition OS Name
            //Model No.
            else if (Column1 == BusinessResources.A_Win32_ComputerSystem && Column2 == BusinessResources.A_Model)
                ReturnConfiguration = Get_System_CommanDetails(BusinessResources.A_Win32_ComputerSystem, BusinessResources.A_Model); //"Win32_ComputerSystem" "PCSystemType" //Installed Date     //  Get_OS_Installed(); // Get_System_CommanDetails(BusinessResources.A_Win32_OperatingSystem, BusinessResources.A_Caption); // "Win32_ComputerSystemProduct" "A_UUID" //Edition OS Name
            else
            {

            }
            return ReturnConfiguration;
        }

        public string Get_AssetType()
        {
            string ReturnAssetType = string.Empty;
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");

                foreach (ManagementObject obj in searcher.Get())
                {
                    string type = obj["PCSystemType"].ToString();
                    string model = obj["Model"].ToString();

                    if (type == "2")
                    {
                        ReturnAssetType = "Laptop";
                    }
                    else if (type == "3")
                    {
                        ReturnAssetType = "Desktop";
                    }

                    //Console.WriteLine("Model: " + model);
                }
            }
            catch (Exception e)
            {
                //ReturnAssetTypeConsole.WriteLine("An error occurred: " + e.Message);
            }

            return ReturnAssetType;
        }

        public static string[] GetInstalledPrograms()
        {
            
            string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(uninstallKey))
            {
                if (key != null)
                {
                    string[] subKeyNames = key.GetSubKeyNames();
                    string[] installedPrograms = new string[subKeyNames.Length];
                    for (int i = 0; i < subKeyNames.Length; i++)
                    {
                        using (RegistryKey subKey = key.OpenSubKey(subKeyNames[i]))
                        {
                            string displayName = subKey.GetValue("DisplayName") as string;
                            if (!string.IsNullOrEmpty(displayName))
                            {
                                installedPrograms[i] = displayName;
                            }
                        }
                    }
                    return installedPrograms;
                }
            }
            return new string[0];
        }

        public string Get_OS_Installed()
        {
            string OSI = string.Empty;

            string[] installedPrograms = GetInstalledPrograms();
            foreach (string program in installedPrograms)
            {
                OSI = program;
            }

            return OSI;
        }

        public static string GetOSFriendlyName(string content)
        {
            //Win32_OperatingSystem
            //Win32_PhysicalMemory
            //Win32_BIOS
            //

            string result = string.Empty;
            //ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Caption FROM " + content + "");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM " + content + "");
            foreach (ManagementObject os in searcher.Get())
            {
                result = os["Caption"].ToString();

                //string MF = os["Manufacturer"].ToString();

                //string MF1 = os["Model"].ToString();
                //string MF2 = os["Model"].ToString();
                //string MF3 = os["Model"].ToString();


                //Model 
                break;
            }
            return result;
        }

        //Win32_PhysicalMemory

        public string GetRAMType()
        {
            string RAMType = string.Empty;
            try
            {
                // Query WMI for total physical memory
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_PhysicalMemory");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                ManagementObjectCollection collection = searcher.Get();

                foreach (ManagementObject obj in collection)
                {
                    string memoryType = obj["MemoryType"].ToString();
                    RAMType = TypeString(Convert.ToInt32(memoryType));

                    string formFactor = obj["FormFactor"].ToString();
                    string Capacity = obj["Capacity"].ToString();

                    ulong memoryBytes = (ulong)obj["Capacity"];

                   // ulong memoryBytes = (ulong) Capacity;//];
                    double memoryGB = memoryBytes / (1024.0 * 1024.0 * 1024.0);
                    memoryGB = Math.Round(memoryGB, 0);

                    //queryObj["Capacity"]);
                   // RAMType= TypeString(Convert.ToInt32(memoryType)); // GetRamType(memoryType, formFactor);
            
                }
                return RAMType;
            }
            catch (ManagementException e)
            {
                //Console.WriteLine("An error occurred while querying WMI: " + e.Message);
                return RAMType;
            }
            catch (Exception ex)
            {
                return RAMType;
                //Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        private static string TypeString(int type)
        {
            string outValue = string.Empty;

            switch (type)
            {
                case 0x0: outValue = "Unknown"; break;
                case 0x1: outValue = "Other"; break;
                case 0x2: outValue = "DRAM"; break;
                case 0x3: outValue = "Synchronous DRAM"; break;
                case 0x4: outValue = "Cache DRAM"; break;
                case 0x5: outValue = "EDO"; break;
                case 0x6: outValue = "EDRAM"; break;
                case 0x7: outValue = "VRAM"; break;
                case 0x8: outValue = "SRAM"; break;
                case 0x9: outValue = "RAM"; break;
                case 0xa: outValue = "ROM"; break;
                case 0xb: outValue = "Flash"; break;
                case 0xc: outValue = "EEPROM"; break;
                case 0xd: outValue = "FEPROM"; break;
                case 0xe: outValue = "EPROM"; break;
                case 0xf: outValue = "CDRAM"; break;
                case 0x10: outValue = "3DRAM"; break;
                case 0x11: outValue = "SDRAM"; break;
                case 0x12: outValue = "SGRAM"; break;
                case 0x13: outValue = "RDRAM"; break;
                case 0x14: outValue = "DDR"; break;
                case 0x15: outValue = "DDR2"; break;
                case 0x16: outValue = "DDR2 FB-DIMM"; break;
                case 0x17: outValue = "Undefined 23"; break;
                case 0x18: outValue = "DDR3"; break;
                case 0x19: outValue = "FBD2"; break;
                default: outValue = "Undefined"; break;
            }

            return outValue;
        }

       public static string GetRamType(string memoryType, string formFactor)
        {
            if (memoryType == "0" && formFactor == "8") // 0 indicates "DDR3" in Win32_PhysicalMemory class
            {
                return "DDR3";
            }
            else if (memoryType == "0" && formFactor == "9") // 9 indicates "DDR4" in Win32_PhysicalMemory class
            {
                return "DDR4";
            }
            else
            {
                return "Unknown";
            }
        }

        public string GetRAM()
        {
            string RAMSize = string.Empty;
            try
            {
                // Query WMI for total physical memory
                ObjectQuery query = new ObjectQuery("SELECT TotalPhysicalMemory FROM Win32_ComputerSystem");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                ManagementObjectCollection collection = searcher.Get();

                foreach (ManagementObject obj in collection)
                {
                    ulong memoryBytes = (ulong)obj["TotalPhysicalMemory"];
                    // Convert bytes to GB for easier readability
                    double memoryGB = memoryBytes / (1024.0 * 1024.0 * 1024.0);

                    memoryGB = Math.Round(memoryGB, 0);
                    RAMSize = memoryGB + " GB";
                    return RAMSize;
                    //Console.WriteLine($"Total RAM: {memoryGB:F2} GB");
                }
                return RAMSize;
            }
            catch (ManagementException e)
            {
                //Console.WriteLine("An error occurred while querying WMI: " + e.Message);
                return RAMSize;
            }
            catch (Exception ex)
            {
                return RAMSize;
                //Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public string GetSerialNumber()
        {
            string serialNumber = string.Empty;
            try
            {
                // Query WMI for serial number
                ObjectQuery query = new ObjectQuery("SELECT SerialNumber FROM Win32_BIOS");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                ManagementObjectCollection collection = searcher.Get();

                foreach (ManagementObject obj in collection)
                {
                    serialNumber = obj["SerialNumber"].ToString();
                    //Console.WriteLine($"Serial Number: {serialNumber}");
                }
                return serialNumber;
            }
            catch (ManagementException e)
            {
                //Console.WriteLine("An error occurred while querying WMI: " + e.Message);
                return serialNumber;
            }
            catch (Exception ex)
            {
                //Console.WriteLine("An error occurred: " + ex.Message);
                return serialNumber;
            }
        }
        //[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        //private class MEMORYSTATUSEX
        //{
        //    public uint dwLength;
        //    public uint dwMemoryLoad;
        //    public ulong ullTotalPhys;
        //    public ulong ullAvailPhys;
        //    public ulong ullTotalPageFile;
        //    public ulong ullAvailPageFile;
        //    public ulong ullTotalVirtual;
        //    public ulong ullAvailVirtual;
        //    public ulong ullAvailExtendedVirtual;

        //    public MEMORYSTATUSEX()
        //    {
        //        this.dwLength = (uint)Marshal.SizeOf(typeof(NativeMethods.MEMORYSTATUSEX));
        //    }
        //}


        //[return: MarshalAs(UnmanagedType.Bool)]
        //[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        //static extern bool GlobalMemoryStatusEx([In, Out] MEMORYSTATUSEX lpBuffer);

        public string GetManufracture()
        {
            string manufacturer = string.Empty;
            try
            {
                // Query WMI for manufacturer
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_ComputerSystem");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                ManagementObjectCollection collection = searcher.Get();

                foreach (ManagementObject obj in collection)
                {
                    manufacturer = obj["Manufacturer"].ToString();
                    //Console.WriteLine($"Manufacturer: {manufacturer}");
                }

                return manufacturer;
            }
            catch (ManagementException e)
            {
                return manufacturer;
                //Console.WriteLine("An error occurred while querying WMI: " + e.Message);
            }
            catch (Exception ex)
            {
                return manufacturer;
                //Console.WriteLine("An error occurred: " + ex.Message);
            }
        }


        public string GetMACAddress()
        {
            string macAddress = string.Empty;
            try
            {
                // Get all network interfaces
                NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

                foreach (NetworkInterface networkInterface in networkInterfaces)
                {
                    //string networkInterfaceName =networkInterface.Name;
                    //string networkInterfaceName1 =networkInterface.NetworkInterfaceType.ToString();
                    //string networkInterfaceName2 =networkInterface.OperationalStatus.ToString();

            //                Console.WriteLine($"Interface: {networkInterface.Name}");
            //Console.WriteLine($"   Type: {networkInterface.NetworkInterfaceType}");
            //Console.WriteLine($"   Status: {networkInterface.OperationalStatus}");

                    // Skip loopback and other non-physical interfaces
                    if (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Loopback ||
                        networkInterface.NetworkInterfaceType == NetworkInterfaceType.Tunnel ||
                        networkInterface.NetworkInterfaceType == NetworkInterfaceType.Unknown)
                    {
                        continue;
                    }

                    // Get the physical (MAC) address
                    byte[] physicalAddressBytes = networkInterface.GetPhysicalAddress().GetAddressBytes();
                    macAddress = BitConverter.ToString(physicalAddressBytes);
                    ///return macAddress;
                    //Console.WriteLine($"MAC Address: {macAddress}");
                    break; // Stop after the first valid MAC address is found


                }

                return macAddress;
            }
            catch (Exception ex)
            {
                return macAddress;
                //Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public string GetIPAddress()
        {
            string IPAddress = string.Empty;
            try
            {
                // Get host entry for the local machine
                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

                // Iterate through IP addresses and print IPv4 addresses
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        IPAddress = ip.ToString();

                        IPAddress = ip.ToString();
                        //Console.WriteLine($"IP Address: {ip}");
                    }
                }

                return IPAddress;
            }
            catch (Exception ex)
            {
                return IPAddress;
                //Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public string HDDModel = string.Empty;
        public string HDDSize = string.Empty;
        public string HDDType = string.Empty;

        public string SSDModel = string.Empty;
        public string SSDSize = string.Empty;
        public string SSDType = string.Empty;

        public string RAMType = string.Empty;

        public void GetHardDiskDetails()
        {
            try
            {
                // Query WMI for hard disk information
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_DiskDrive");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                ManagementObjectCollection collection = searcher.Get();
                int C1 = 0;
                foreach (ManagementObject obj in collection)
                {
                    if (C1 == 0)
                    {
                        // Get hard disk type
                        HDDModel = obj["Model"].ToString();
                        // Console.WriteLine($"Hard Disk Type: {model}");

                        // Get hard disk size
                        ulong sizeBytes = Convert.ToUInt64(obj["Size"]);
                        double sizeGB = sizeBytes / (1024.0 * 1024.0 * 1024.0);
                        //HDDSize = sizeGB.ToString();
                        sizeGB = Math.Round(sizeGB);
                        HDDSize = sizeGB.ToString() + " GB";

                        //SSDType = obj["MediaType"].ToString();
                        HDDType = obj["InterfaceType"].ToString();

                        //string sCaption = obj["Caption"].ToString();
                        // if (sCaption.Contains("ATA"))
                        // {

                        // }


                        // string strQuery = "ASSOCIATORS OF {Win32_LogicalDisk.DeviceID=\"" + System.IO.Path.GetPathRoot(Environment.SystemDirectory).Replace("\\", "") + "\"} WHERE AssocClass = Win32_LogicalDiskToPartition";
                        // RelatedObjectQuery relquery = new RelatedObjectQuery(strQuery);
                        // ManagementObjectSearcher search = new ManagementObjectSearcher(relquery);
                        // UInt32 ndx = 0;
                        // foreach (var diskPartition in search.Get())
                        // {
                        //     ndx = (uint)diskPartition["DiskIndex"];
                        //     Console.WriteLine("Disk Index of System Drive is {0}, Disk Partition is {1}", ndx, diskPartition["DeviceID"]);
                        // }

                        // SelectQuery diskQuery = new SelectQuery(string.Format("SELECT * FROM Win32_DiskDrive WHERE Index={0}", ndx));
                        // ManagementObjectSearcher diskSearch = new ManagementObjectSearcher(diskQuery);
                        // foreach (var disk in diskSearch.Get())
                        // {
                        //     sCaption = Convert.ToString(disk["Caption"]);
                        //     sCaption = Convert.ToString(disk["SerialNumber"]);
                        //     sCaption = Convert.ToString(disk["Signature"]);

                        //     //Console.WriteLine("Serial Number is {0}", disk["SerialNumber"]);
                        //     //Console.WriteLine("Model is {0}", disk["Model"]);
                        //     //Console.WriteLine("InterfaceType is {0}", disk["InterfaceType"]);
                        // }
                    }
                    if (C1 == 1)
                    {
                        // Get hard disk type
                        SSDModel = obj["Model"].ToString();
                        // Console.WriteLine($"Hard Disk Type: {model}");

                        // Get hard disk size
                        ulong sizeBytes = Convert.ToUInt64(obj["Size"]);
                        double sizeGB = sizeBytes / (1024.0 * 1024.0 * 1024.0);
                        sizeGB = Math.Round(sizeGB);
                        SSDSize = sizeGB.ToString() + " GB";

                        //A_MediaType

                        //SSDType = obj["MediaType"].ToString();
                        SSDType = obj["InterfaceType"].ToString();

                        //string model = obj["Model"].ToString();
                        //string interfaceType = obj["InterfaceType"].ToString();

                        //if (interfaceType == "PCIe") // NVMe drives are often identified by the PCIe interface
                        //    SSDType = model;
                        //else if (interfaceType == "IDE" || interfaceType == "SCSI" || interfaceType == "SATA")
                        //    SSDType = model;
                        //else
                        //    SSDType = model + ", Interface-" + interfaceType;
                    }  
                    C1++;
                    //Console.WriteLine($"Hard Disk Size: {sizeGB:F2} GB");
                }
            }
            catch (ManagementException e)
            {
                Console.WriteLine("An error occurred while querying WMI: " + e.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public enum ChassisTypes
        {
            Other = 1,
            Unknown,
            Desktop,
            LowProfileDesktop,
            PizzaBox,
            MiniTower,
            Tower,
            Portable,
            Laptop,
            Notebook,
            Handheld,
            DockingStation,
            AllInOne,
            SubNotebook,
            SpaceSaving,
            LunchBox,
            MainSystemChassis,
            ExpansionChassis,
            SubChassis,
            BusExpansionChassis,
            PeripheralChassis,
            StorageChassis,
            RackMountChassis,
            SealedCasePC
        }

        public static ChassisTypes GetCurrentChassisType()
        {
            ManagementClass systemEnclosures = new ManagementClass("Win32_SystemEnclosure");
            foreach (ManagementObject obj in systemEnclosures.GetInstances())
            {
                foreach (int i in (UInt16[])(obj["ChassisTypes"]))
                {
                    if (i > 0 && i < 25)
                    {
                        return (ChassisTypes)i;
                    }
                }
            }
            return ChassisTypes.Unknown;
        }

        public void GetSize_In_GB(ulong sizeBytes)
        {
            //long totalSizeBytes = ConvesizeBytes; // cDrive.TotalSize;
            double totalSizeGB = sizeBytes / (1024 * 1024 * 1024);
        }

        public List<string> lSoftware = new List<string>();

        public void Get_Domain()
        {
            
        }

        public void GetSoftwareInstalled()
        {
            try
            {
                lSoftware.Clear();
                // Open the registry key for installed software
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall");

                // Iterate through each subkey (representing installed software)
                foreach (string subKeyName in key.GetSubKeyNames())
                {
                    RegistryKey subKey = key.OpenSubKey(subKeyName);

                    // Retrieve and print the display name of the software
                    string displayName = subKey.GetValue("DisplayName") as string;
                    if (!string.IsNullOrEmpty(displayName))
                    {
                        lSoftware.Add(displayName);
                        //Console.WriteLine($"Software: {displayName}");
                    }

                    // Close the subkey
                    subKey.Close();
                }

                // Close the key
                key.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        string MainQuery = string.Empty, WhereBasic = string.Empty, OrderBy = string.Empty;

        public void Get_Memo_Count_By_EmployeeId_MemoId()
        {
            DataSet ds = new DataSet();

            MainQuery = string.Empty;
            WhereClause = string.Empty;
            WhereBasic = string.Empty;
            OrderBy = string.Empty;

            if (objPC.EmployeeId > 0 && objPC.MemoTemplateMasterId > 0)
            {
                WhereClause = " and M.EmployeeId=" + objPC.EmployeeId + " and M.MemoTemplateMasterId=" + objPC.MemoTemplateMasterId + " ";

                MainQuery = "select Count(M.MemoTemplateMasterId) as 'Count' " +
                             "from " +
                             "memo M inner join Employees E on E.EmployeeId=M.EmployeeId inner join " +
                             "locationmaster L on L.LocationId=M.LocationId inner join " +
                             "departmentmaster D on D.DepartmentId=M.DepartmentId inner join " +
                             "memotemplatemaster MTM on MTM.MemoTemplateMasterId=M.MemoTemplateMasterId ";

                WhereBasic = "where M.CancelTag=0 and L.CancelTag=0 and D.CancelTag=0 and E.CancelTag=0 and MTM.CancelTag=0 and M.LetterType='" + objPC.FormName + "'";
                OrderBy = " order by M.EntryDate desc";

                objBL.Query = MainQuery + WhereBasic + WhereClause + OrderBy;
                ds = objBL.ReturnDataSet();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    objPC.MemoCount = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Count"])));
                }
            }
        }

        public bool CheckExist_Document_Letter()
        {
            DataSet ds = new DataSet();
            objBL.Query = "select UD.UploadDocumentId from uploaddocuments UD  inner join documentmaster DM on DM.DocumentId=UD.DocumentId inner join formmaster FM on FM.FormId=DM.FormId where FM.FormName='" + objPC.FormName + "' and DM.DocumentName='" + objPC.DocumentName + "'";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }

        //Updates Queries

        public bool Get_Update_Details()
        {
            bool RFlag = false;
            int UpdateVersion = 0;
            DataTable dt = new DataTable();
            //objBL.Query = "select * from macaddresstable where CancelTag=0 and MachinName='" + Environment.MachineName.ToString() + "' and UpdateVersion=" + BusinessLayer.UpdateVersion + " and UpdateFlag=1";
            objBL.Query = "select * from macaddresstable where CancelTag=0 and MachinName='" + Environment.MachineName.ToString() + "' and UpdateVersion=" + BusinessLayer.UpdateVersion + " ";
            dt = objBL.ReturnDataTable();
            
            if(dt.Rows.Count == 0)
            {
                ShowMessage(48, 4);
                RFlag = true;
            }
            else
            {
                RFlag = false;
                objPC.MacAddressTableID = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(dt.Rows[0]["ID"])));
                objPC.UpdateVersion =CheckNullString_ReturnInt(CheckNullString(Convert.ToString(dt.Rows[0]["UpdateVersion"])));
                objPC.UpdateFlag = CheckNullString_ReturnInt(CheckNullString(Convert.ToString(dt.Rows[0]["UpdateFlag"])));
            }
            return RFlag;
        }

       string DBPath = string.Empty;
        public int LoginBackup_Auto()
        {
            int Result = 0;
            try
            {
                //using (new CursorWait())
                //{
                //
                DBPath = string.Empty;
                if (!string.IsNullOrEmpty(Convert.ToString(ConfigurationManager.AppSettings["DBBackupPath"])))
                {
                    DBPath = ConfigurationManager.AppSettings["DBBackupPath"].ToString();
                    if (!Directory.Exists(DBPath))
                        Directory.CreateDirectory(DBPath);

                    DBPath += BusinessLayer.DatabaseName + "_dump_" + DateTime.Now.ToString("dd-MMM-yyyy");
                }
                //this.timer1.Start();
                //string ConcatCommand = "c: && cd C:\\Program Files\\MySQL\\MySQL Server 8.0\\bin && mysqldump.exe -h Yashwant -u clinicuser --password=" + Pass + "  " + BusinessLayer.DatabaseName + " > " + DBPath + "";
                string ConcatCommand = "c: && cd C:\\Program Files\\MySQL\\MySQL Server 8.0\\bin && mysqldump.exe -h " + BusinessLayer.ServerName + " -u " + BusinessLayer.Uid + " --password=" + BusinessLayer.DatabasePassword + "  " + BusinessLayer.DatabaseName + " --routines > " + DBPath + "";
                ExecuteCommand(ConcatCommand, 100, false);
                objQL.SearchFlag = false;
                objQL.EntryDate = DateTime.Now.Date;
                objQL.UserId = BusinessLayer.LoginId_Static;
                Result = objQL.SP_Backups_Save();
                 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return Result;

        }

        private void ExecuteCommand(string Command, int Timeout, Boolean closeProcess)
        {
            //System.Diagnostics.ProcessStartInfo ProcessInfo = new System.Diagnostics.ProcessStartInfo(); //Initializes a new ProcessStartInfo of name myProcessInfo
            //ProcessInfo.FileName = Environment.ExpandEnvironmentVariables("%SystemRoot%") + @"\System32\cmd.exe"; //Sets the FileName property of myProcessInfo to %SystemRoot%\System32\cmd.exe where %SystemRoot% is a system variable which is expanded using Environment.ExpandEnvironmentVariables
            ////ProcessInfo.Arguments = "cd.."; //Sets the arguments to cd..
            //ProcessInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden; //Sets the WindowStyle of myProcessInfo which indicates the window state to use when the process is started to Hidden
            ////System.Diagnostics.Process.Start(ProcessInfo);

            ProcessStartInfo ProcessInfo;
            Process Process;

            //if(PasswordFlag)
            //    ProcessInfo = new ProcessStartInfo("cmd.exe", "Enter Password: " + Command);
            //else
            //ProcessInfo = new ProcessStartInfo("cmd.exe", "/C " + Command);

            ProcessInfo = new ProcessStartInfo("cmd.exe", "/C " + Command);
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = false;
            ProcessInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            Process = Process.Start(ProcessInfo);
            Process.WaitForExit(Timeout);

            if (closeProcess == true) { Process.Close(); }
        }


        //string server = "localhost";
        //string database = "malasdb";
        //string uid = "root";
        //string password = "Clinic@1234";
        //string backupFile = "E:\\SystemBackup\\Dump\\backup.sql";

        //public void Backup_Process()
        //{
        //    using (Process mysqldump = new Process())
        //    {
        //        mysqldump.StartInfo.FileName = "mysqldump";
        //        mysqldump.StartInfo.RedirectStandardInput = false;
        //        mysqldump.StartInfo.RedirectStandardOutput = true;
        //        mysqldump.StartInfo.Arguments = $"-u {uid} -p {password} -h {server} {database}";
        //        mysqldump.StartInfo.UseShellExecute = false;

        //        using (System.IO.StreamWriter file = new System.IO.StreamWriter(backupFile))
        //        {
        //            mysqldump.Start();
        //            string output = mysqldump.StandardOutput.ReadToEnd();
        //            file.WriteLine(output);
        //            mysqldump.WaitForExit();
        //        }
        //    }
        //}

        public void Set_Approval_Colour_DataGridView(DataGridView dgv,Label lblPending, Label lblHRApproved, Label lblManagerApproved, Label lblRemarks, Label lblCompleted, string ColumnName)
        {
            int PendingCount = 0, HRApprovedCount = 0, ManagerApprovedCount = 0, RemarksCount = 0, CompletedCount = 0;

            lblPending.Text = ""; 
            lblHRApproved.Text = "";
            lblManagerApproved.Text = ""; 
            lblRemarks.Text = ""; 
            lblCompleted.Text = "";

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!string.IsNullOrWhiteSpace(Convert.ToString(row.Cells[ColumnName].Value)))
                {
                    //Pending 1
                    if (row.Cells[ColumnName].Value != null && Convert.ToInt32(row.Cells[ColumnName].Value) == 1)
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml(BusinessResources.LS_Pending_Color);
                        PendingCount++;
                    }
                    //HRApprovedCount 6
                    else if (row.Cells[ColumnName].Value != null && Convert.ToInt32(row.Cells[ColumnName].Value) == 6)
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml(BusinessResources.LS_HRApproved_Color);
                        HRApprovedCount++;
                    }
                    //ManagerApprovedCount 8
                    else if (row.Cells[ColumnName].Value != null && Convert.ToInt32(row.Cells[ColumnName].Value) == 8)
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml(BusinessResources.LS_Manager_Color);
                        ManagerApprovedCount++;
                    }
                    //RemarksCount 3
                    else if (row.Cells[ColumnName].Value != null && Convert.ToInt32(row.Cells[ColumnName].Value) == 3)
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml(BusinessResources.LS_Remarks_Color);
                        RemarksCount++;
                    }
                    //CompletedCount 2
                    else if (row.Cells[ColumnName].Value != null && Convert.ToInt32(row.Cells[ColumnName].Value) == 2)
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml(BusinessResources.LS_Completed_Color);
                        CompletedCount++;
                    }
                    else
                    {

                    }
                }
            }

            lblPending.Text = "Pending-"+ PendingCount;
            lblHRApproved.Text = "HR Approved-" + HRApprovedCount;
            lblManagerApproved.Text = "Manager Approved- " + ManagerApprovedCount;
            lblRemarks.Text = "Remarks-" + RemarksCount;
            lblCompleted.Text = "Completed-" + CompletedCount;
        }

        public int AttendanceCountAll()
        {
            int count = 0;

            using (MySqlConnection conn = new MySqlConnection(objBL.conString))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(PropertyClass.AllCountQuery, conn))
                {
                    // ExecuteScalar returns first column of first row
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        count = Convert.ToInt32(result);
                    }
                }
            }
            return count;
        }
    }
}
