using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
 
 
namespace BusinessLayerUtility
{
    public class QueryLayer
    {
        BusinessLayer objBL = new BusinessLayer();
        PropertyClass objPC = new PropertyClass();

        public MySqlDataAdapter objDA;
        public MySqlCommand objCmd;

        //DocumentMaster Combo Box : Yashwant

        //public void SP_Update_Attendancelogs_New()
        //{

        //    DataSet ds = new DataSet();
        //    string returnValue = string.Empty;
        //    objBL.Connect();
        //    objCmd = new MySqlCommand();
        //    objCmd.CommandType = CommandType.StoredProcedure;
        //    objCmd.CommandText = "SP_State_District_Area_Master_By_Id";
        //    objCmd.Connection = objBL.objCon;
        //    objCmd.Parameters.AddWithValue("@SearchType_V", objPC.SearchType.ToString());
        //    objCmd.Parameters.AddWithValue("@SearchId_V", objPC.SearchId.ToString());
        //    objDA = new MySqlDataAdapter(objCmd);
        //    objDA.Fill(ds);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        cmb.DataSource = ds.Tables[0];
        //        cmb.ValueMember = ds.Tables[0].Columns[0].ToString();
        //        cmb.DisplayMember = ds.Tables[0].Columns[1].ToString();
        //        cmb.SelectedIndex = -1;
        //    }
        //}

        public int Check_Leave_Date_Valid()
        {
            objBL.Connect();

            string QueryString = " SELECT " +
            " CASE " +
            " WHEN  " +
            " DAYNAME(@LeaveDate) IN(  " +
                " SELECT C.CategoryFName  " +
                " FROM categories C  " +
                " INNER JOIN employees e  " +
                    " ON e.CategoryId = C.CategoryId  " +
                " WHERE e.EmployeeId = @EmployeeId   " +
            " ) " +
            " OR @LeaveDate IN( " +
                " SELECT HolidayDate " +
                " FROM holidaymaster " +
            " ) " +
            " THEN 1 " +
            " ELSE 0 " +
            " END AS CheckValid ";

            objCmd = new MySqlCommand();
            objCmd.CommandText = QueryString;
            objCmd.CommandType = CommandType.Text;
            objCmd.Connection = objBL.objCon;

            objCmd.Parameters.AddWithValue("@LeaveDate", objPC.LeaveDate);
            objCmd.Parameters.AddWithValue("@EmployeeId", objPC.EmployeeId);
            int result = Convert.ToInt32(objCmd.ExecuteScalar());
           
            objBL.objCon.Close();
            return result;
        }

        public int Check_CompOff_Date_Valid()
        {
            objBL.Connect();

            string QueryString = " SELECT " +
            " CASE " +
            " WHEN  " +
            " DAYNAME(@CompOffDate) IN(  " +
                " SELECT C.CategoryFName  " +
                " FROM categories C  " +
                " INNER JOIN employees e  " +
                    " ON e.CategoryId = C.CategoryId  " +
                " WHERE e.EmployeeId = @EmployeeId   " +
            " ) " +
            " OR @CompOffDate IN( " +
                " SELECT HolidayDate " +
                " FROM holidaymaster " +
            " ) " +
            " THEN 1 " +
            " ELSE 0 " +
            " END AS CheckValid ";

            objCmd = new MySqlCommand();
            objCmd.CommandText = QueryString;
            objCmd.CommandType = CommandType.Text;
            objCmd.Connection = objBL.objCon;

            objCmd.Parameters.AddWithValue("@CompOffDate", objPC.CompOffDate);
            objCmd.Parameters.AddWithValue("@EmployeeId", objPC.EmployeeId);
            int result = Convert.ToInt32(objCmd.ExecuteScalar());

            objBL.objCon.Close();
            return result;
        }

        public DataTable SP_Get_Shift_Details()
        {
            objBL.Connect();
            DataTable ds = new DataTable();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_Get_Shift_Details";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@InTime_V", objPC.InTime);
            objCmd.Parameters.AddWithValue("@OutTime_V", objPC.OutTime);
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataTable SP_Update_Attendancelogs_Edit()
        {
            objBL.Connect();
            DataTable dt = new DataTable();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_Update_Attendancelogs_Edit";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@AttendanceLogId_V", objPC.AttendanceLogId);
            objCmd.Parameters.AddWithValue("@AttendanceDate_V", objPC.AttendanceDate);
            objCmd.Parameters.AddWithValue("@InTime_V", objPC.InTime);
            objCmd.Parameters.AddWithValue("@OutTime_V", objPC.OutTime);
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.Parameters.AddWithValue("@IsLeaveForce_V", objPC.IsLeaveForce);
             
            //int ReturnResult = objCmd.ExecuteNonQuery();
            //ReturnResult;

            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(dt);
            objBL.objCon.Close();
            return dt;
        }

        public void SP_DocumentMaster_Select_ComboBox(ComboBox cmb)
        {
            cmb.DataSource = null;
            DataSet ds = new DataSet();
            string returnValue = string.Empty;
            objBL.Connect();
            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_DocumentMaster_Select_ComboBox";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@FormName_V", objPC.FormName);
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = ds.Tables[0].Columns["DocumentName"].ToString();
                cmb.ValueMember = ds.Tables[0].Columns["DocumentId"].ToString();
                cmb.SelectedIndex = -1;
            }
        }

        public bool SP_UploadDocuments_CheckExist()
        {
            bool ReturnResult = false;
            DataSet ds = new DataSet();
            string returnValue = string.Empty;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_UploadDocuments_CheckExist";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@UploadDocumentId_V", objPC.UploadDocumentId);
            objCmd.Parameters.AddWithValue("@FormId_V", objPC.FormId.ToString());
            objCmd.Parameters.AddWithValue("@TableId_V", objPC.TableId.ToString());
            objCmd.Parameters.AddWithValue("@DocumentId_V", objPC.DocumentId);
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
                ReturnResult = true;
            else
                ReturnResult = false;

            return ReturnResult;
        }

        public int SP_UploadDocuments_Save()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_UploadDocuments_Save";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@EntryDate_V", objPC.EntryDate);
            objCmd.Parameters.AddWithValue("@FormId_V", objPC.FormId);
            objCmd.Parameters.AddWithValue("@TableId_V", objPC.TableId);
            objCmd.Parameters.AddWithValue("@DocumentId_V", objPC.DocumentId);
            objCmd.Parameters.AddWithValue("@DocumentPath_V", objPC.DocumentPath);
            objCmd.Parameters.AddWithValue("@DocumentName_V", objPC.DocumentName);
            objCmd.Parameters.AddWithValue("@UserId_V", objPC.UserId);
            objCmd.Parameters.AddWithValue("@DeleteFlag_V", objPC.DeleteFlag);
            objCmd.Parameters.AddWithValue("@UploadDocumentId_V", objPC.UploadDocumentId);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public void TuncateTables_Report()
        {
             int ReturnResult = 0;
            DataSet ds = new DataSet();
            objBL.Connect();
            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "TuncateTables_Report";
            objCmd.Connection = objBL.objCon;
             ReturnResult = objCmd.ExecuteNonQuery();
            //return ReturnResult;
            //objDA = new MySqlDataAdapter(objCmd);
            //objDA.Fill(ds);
            //return ds;
        }
        
        public int SP_FormMaster_Get_FormId()
        {
            int TableId_V = 0;
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_FormMaster_Get_FormId";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@FormName_V", objPC.FormName);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0][0].ToString()))
                    TableId_V = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            objBL.objCon.Close();
            return TableId_V;
        }

        public DataSet SP_UploadDocuments_Select()
        {
            DataSet ds = new DataSet();
            objBL.Connect();
            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_UploadDocuments_Select";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@FormId_V", objPC.FormId);
            objCmd.Parameters.AddWithValue("@TableId_V", objPC.TableId);
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            return ds;
        }

        public DataSet SP_AttendanceHistory_CheckExist()
        {
            DataSet ds = new DataSet();
            objBL.Connect();
            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_AttendanceHistory_CheckExist";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@FromDate_V", objPC.FromDate);
            objCmd.Parameters.AddWithValue("@ToDate_V", objPC.ToDate);
            objCmd.Parameters.AddWithValue("@DatabaseName_V", objPC.DatabaseName);
            objCmd.Parameters.AddWithValue("@DataType_V", objPC.DataType);
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            return ds;
        }

        public int SP_Get_All_TableId_By_Name(string SelectMaster_V, string ColumnData_V)
        {

            int TableId_V = 0;
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_Get_All_TableId_By_Name";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@SelectMaster_V", SelectMaster_V);
            objCmd.Parameters.AddWithValue("@ColumnData_V", ColumnData_V);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0][0].ToString()))
                    TableId_V = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            objBL.objCon.Close();
            return TableId_V;
        }

        public int GetTableId(string IdColumnName, string TableName)
        {
            int Maxid = 0;
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_GetTableId_By_ColumnName_TableName";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@Id_V", IdColumnName);
            TableName = TableName + " order by " + IdColumnName + " desc ";
            objCmd.Parameters.AddWithValue("@TableName_V", TableName);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0][0].ToString()))
                {
                    Maxid = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                    Maxid += 1;
                }
                    
            //
            if (Maxid == 0)
                Maxid = 1;
            

            objBL.objCon.Close();
            return Maxid;
        }

        public DataSet SP_SelectAll_Data_By_TableName()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_SelectAll_Data_By_TableName";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@TableName_V", TableName);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public int ReturnMaxID(string TableName)
        {
            int Maxid = 0;
            DataSet ds = new DataSet();
            this.TableName = TableName;
            ds = SP_SelectAll_Data_By_TableName();

            //objBL.Query = "select Max(ID) from " + TableName + "";
            //DataSet ds = new DataSet();
            //ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0][0].ToString()))
                    Maxid = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            Maxid += 1;
            return Maxid;
        }

        public void Fill_Master_ComboBox(ComboBox cmb, string SelectMaster_V)
        {
            cmb.DataSource = null;
            DataSet ds = new DataSet();
            string returnValue = string.Empty;
            objBL.Connect();
            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_MasterTable_Select_ComboBox";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@SelectMaster_V", SelectMaster_V.ToString());
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmb.DataSource = ds.Tables[0];
                cmb.ValueMember = ds.Tables[0].Columns[0].ToString();
                cmb.DisplayMember = ds.Tables[0].Columns[1].ToString();
                cmb.SelectedIndex = -1;
            }
        }

        public void Fill_Master_ComboBox_One_by_One(ComboBox cmb, string SelectMaster_V)
        {
            cmb.DataSource = null;
            DataSet ds = new DataSet();
            string returnValue = string.Empty;
            objBL.Connect();
            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_MasterTable_Select_ComboBox";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@SelectMaster_V", SelectMaster_V.ToString());
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    cmb.Items.Add(ds.Tables[0].Rows[i][1].ToString());
                }
                cmb.Items.Add("All");
                cmb.SelectedIndex = -1;
            }
        }

        public void SP_State_District_Area_Master_By_Id(ComboBox cmb)
        {
            cmb.DataSource = null;
            DataSet ds = new DataSet();
            string returnValue = string.Empty;
            objBL.Connect();
            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_State_District_Area_Master_By_Id";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@SearchType_V", objPC.SearchType.ToString());
            objCmd.Parameters.AddWithValue("@SearchId_V", objPC.SearchId.ToString());
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmb.DataSource = ds.Tables[0];
                cmb.ValueMember = ds.Tables[0].Columns[0].ToString();
                cmb.DisplayMember = ds.Tables[0].Columns[1].ToString();
                cmb.SelectedIndex = -1;
            }
        }



        public bool SP_Login_CheckExist()
        {
            bool ReturnResult = false;
            DataSet ds = new DataSet();
            string returnValue = string.Empty;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_Login_CheckExist";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@LoginId_V", objPC.LoginId.ToString());
            objCmd.Parameters.AddWithValue("@UserName_V", objPC.UserName.ToString());
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
                ReturnResult = true;
            else
                ReturnResult = false;

            return ReturnResult;
        }

        public int SP_Insert_Update_Delete_Select_LoginUsers()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_Insert_Update_Delete_Select_LoginUsers";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@Id_V", objPC.LoginId.ToString());
            objCmd.Parameters.AddWithValue("@UserTypeId_V", objPC.UserTypeId.ToString());
            objCmd.Parameters.AddWithValue("@DepartmentId_V", objPC.DepartmentId.ToString());
            objCmd.Parameters.AddWithValue("@UserName_V", objPC.UserName.ToString());
            objCmd.Parameters.AddWithValue("@Search_V", objPC.Search.ToString());
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }


        public int SP_Login_Insert_Update_Delete_Select()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_Login_Insert_Update_Delete_Select";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@LoginId_V", objPC.LoginId.ToString());
            objCmd.Parameters.AddWithValue("@UserTypeId_V", objPC.UserTypeId.ToString());
            objCmd.Parameters.AddWithValue("@UserName_V", objPC.UserName.ToString());
            //objCmd.Parameters.AddWithValue("@UserType_V", objPC.UserType.ToString());
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.Parameters.AddWithValue("@UserId_V", BusinessLayer.LoginId_Static);
            objCmd.Parameters.AddWithValue("@DeleteFlag_V", objPC.DeleteFlag);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public DataSet SP_Login_FillGrid()
        {
            DataSet ds = new DataSet();
            objBL.Connect();
            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_Login_FillGrid";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@EmployeeName_V", objPC.EmployeeName);
            objCmd.Parameters.AddWithValue("@Search_V", objPC.SearchFlag);
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            return ds;
        }

        //Attendance Logics
        
        
        public int SP_Test()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_Test";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@EntryDate_V", objPC.EntryDate);
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.UserTypeId.ToString());
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public int SP_AttendanceHistory_Insert()
        {
            DataSet ds = new DataSet();
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_AttendanceHistory_Insert";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@EntryDate_V", objPC.EntryDate);
            objCmd.Parameters.AddWithValue("@FromDate_V", objPC.FromDate);
            objCmd.Parameters.AddWithValue("@ToDate_V", objPC.ToDate);
            objCmd.Parameters.AddWithValue("@DatabaseName_V", objPC.DatabaseName);
            objCmd.Parameters.AddWithValue("@DataType_V", objPC.DataType);
            objCmd.Parameters.AddWithValue("@UserId_V", BusinessLayer.EmployeeLoginId_Static);
            ReturnResult = Convert.ToInt32(objCmd.ExecuteScalar());
            return ReturnResult;
        }

        public DataSet SP_AttendanceHistory_FillGrid()
        {
            DataSet ds = new DataSet();
            objBL.Connect();
            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_AttendanceHistory_FillGrid";
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            return ds;
        }

        public int sp_attendancelogs_insert()
        {
            int ReturnResult = 0;
            objBL.Connect();
            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "sp_attendancelogs_insert";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@Id_V", objPC.TableId);
            objCmd.Parameters.AddWithValue("@EntryDate_V", objPC.EntryDate);
            objCmd.Parameters.AddWithValue("@attendancelogid_V", objPC.AttendanceLogId);
            objCmd.Parameters.AddWithValue("@AttendanceDate_V", objPC.AttendanceDate);
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.Parameters.AddWithValue("@InTime_V", objPC.InTime);
            objCmd.Parameters.AddWithValue("@InDeviceId_V", objPC.InDeviceId);
            objCmd.Parameters.AddWithValue("@OutTime_V", objPC.OutTime);
            objCmd.Parameters.AddWithValue("@OutDeviceId_V", objPC.OutDeviceId);
            objCmd.Parameters.AddWithValue("@Duration_V", objPC.Duration);
            objCmd.Parameters.AddWithValue("@LateBy_V", objPC.LateBy);
            objCmd.Parameters.AddWithValue("@EarlyBy_V", objPC.EarlyBy);
            objCmd.Parameters.AddWithValue("@IsOnLeave_V", objPC.IsOnLeave);
            objCmd.Parameters.AddWithValue("@LeaveType_V", objPC.LeaveType);
            objCmd.Parameters.AddWithValue("@LeaveDuration_V", objPC.LeaveDuration);
            objCmd.Parameters.AddWithValue("@WeeklyOff_V", objPC.WeeklyOff);
            objCmd.Parameters.AddWithValue("@Holiday_V", objPC.Holiday);
            objCmd.Parameters.AddWithValue("@LeaveRemarks_V", objPC.LeaveRemarks);
            objCmd.Parameters.AddWithValue("@PunchRecords_V", objPC.PunchRecords);
            objCmd.Parameters.AddWithValue("@ShiftId_V", objPC.ShiftId);
            objCmd.Parameters.AddWithValue("@Present_V", objPC.Present);
            objCmd.Parameters.AddWithValue("@Absent_V", objPC.Absent);
            objCmd.Parameters.AddWithValue("@Status_V", objPC.Status);
            objCmd.Parameters.AddWithValue("@StatusCode_V", objPC.StatusCode);
            objCmd.Parameters.AddWithValue("@P1Status_V", objPC.P1Status);
            objCmd.Parameters.AddWithValue("@P2Status_V", objPC.P2Status);
            objCmd.Parameters.AddWithValue("@P3Status_V", objPC.P3Status);
            objCmd.Parameters.AddWithValue("@IsonSpecialOff_V", objPC.IsonSpecialOff);
            objCmd.Parameters.AddWithValue("@SpecialOffType_V", objPC.SpecialOffType);
            objCmd.Parameters.AddWithValue("@SpecialOffRemark_V", objPC.SpecialOffRemark);
            objCmd.Parameters.AddWithValue("@SpecialOffDuration_V", objPC.SpecialOffDuration);
            objCmd.Parameters.AddWithValue("@OverTime_V", objPC.OverTime);
            objCmd.Parameters.AddWithValue("@OverTimeE_V", objPC.OverTimeE);
            objCmd.Parameters.AddWithValue("@MissedOutPunch_V", objPC.MissedOutPunch);
            objCmd.Parameters.AddWithValue("@MissedInPunch_V", objPC.MissedInPunch);
            objCmd.Parameters.AddWithValue("@C1_V", objPC.C1);
            objCmd.Parameters.AddWithValue("@C2_V", objPC.C2);
            objCmd.Parameters.AddWithValue("@C3_V", objPC.C3);
            objCmd.Parameters.AddWithValue("@C4_V", objPC.C4);
            objCmd.Parameters.AddWithValue("@C5_V", objPC.C5);
            objCmd.Parameters.AddWithValue("@C6_V", objPC.C6);
            objCmd.Parameters.AddWithValue("@C7_V", objPC.C7);
            objCmd.Parameters.AddWithValue("@Remarks_V", objPC.Remarks);
            objCmd.Parameters.AddWithValue("@LeaveTypeId_V", objPC.LeaveTypeId);
            objCmd.Parameters.AddWithValue("@LossOfHours_V", objPC.LossOfHours);
            objCmd.Parameters.AddWithValue("@UserId_V", objPC.UserId);
            objCmd.Parameters.AddWithValue("@AttendanceHistoryId_V", objPC.AttendanceHistoryId);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        //Monthly Attendance Report

         string MonthlyAttendance_Column = " AL.Id, "+
		                    "AL.EntryDate,"+
		                    "AL.attendancelogid,"+
		                    "AL.AttendanceDate,"+
		                    "AL.EmployeeId,"+
                            "E.EmployeeCode,"+
                            "E.EmployeeName,"+
                            "E.Gender,"+
                            "AL.InTime," +
		                    "AL.InDeviceId,"+
		                    "AL.OutTime,"+
		                    "AL.OutDeviceId,"+
		                    "AL.Duration,"+
		                    "AL.LateBy,"+
		                    "AL.EarlyBy, "+
		                    "AL.IsOnLeave,"+
		                    "AL.LeaveType,"+
		                    "AL.LeaveDuration,"+
		                    "AL.WeeklyOff,"+
		                    "AL.Holiday,"+
		                    "AL.LeaveRemarks,"+
		                    "AL.PunchRecords,"+
		                    "AL.ShiftId,"+
		                    "AL.Present,"+
		                    "AL.Absent,"+
		                    "AL.Status,"+
		                    "AL.StatusCode,"+
		                    "AL.P1Status,"+
		                    "AL.P2Status,"+
		                    "AL.P3Status,"+
		                    "AL.IsonSpecialOff,"+ 
		                    "AL.SpecialOffType,"+
		                    "AL.SpecialOffRemark,"+
		                    "AL.SpecialOffDuration,"+
		                    "AL.OverTime,"+
		                    "AL.OverTimeE,"+
		                    "AL.MissedOutPunch,"+
		                    "AL.MissedInPunch, "+
		                    "AL.C1, "+
		                    "AL.C2, "+
		                    "AL.C3, "+
		                    "AL.C4, "+
		                    "AL.C5, "+
		                    "AL.C6, "+
		                    "AL.C7, "+
		                    "AL.Remarks,"+ 
		                    "AL.LeaveTypeId,"+ 
                            "AL.LossOfHours,"+
                            "AL.AttendanceHistoryId, " +
		                    "E.DepartmentId,"+
                            "D.Department,"+
		                    "E.DesignationId,"+
                            "DM.Designation,"+
		                    "E.CategoryId,"+ 
		                    "E.EmployementTypeId,"+ 
                            "ETM.EmployementType,"+
		                    "E.Status, "+
		                    "E.RecordStatus,"+
		                    "E.EmployeeDeviceGroup,"+
		                    "E.LocationId,"+
                            "L.LocationName,"+
		                    "E.ContractorId,"+ 
		                    "E.ShiftGroupId,"+
		                    "E.DeviceId,"+
                            "E.GeofenceId ";

         public string ColumnNames_Report = " AL.Id, "+
		                    "AL.EntryDate,"+
		                    "AL.attendancelogid,"+
		                    "AL.AttendanceDate,"+
		                    "AL.EmployeeId,"+
                            "AL.InTime," +
		                    "AL.InDeviceId,"+
		                    "AL.OutTime,"+
		                    "AL.OutDeviceId,"+
		                    "AL.Duration,"+
		                    "AL.LateBy,"+
		                    "AL.EarlyBy, "+
		                    "AL.IsOnLeave,"+
		                    "AL.LeaveType,"+
		                    "AL.LeaveDuration,"+
		                    "AL.WeeklyOff,"+
		                    "AL.Holiday,"+
		                    "AL.LeaveRemarks,"+
		                    "AL.PunchRecords,"+
		                    "AL.ShiftId,"+
		                    "AL.Present,"+
		                    "AL.Absent,"+
		                    "AL.Status,"+
		                    "AL.StatusCode,"+
		                    "AL.P1Status,"+
		                    "AL.P2Status,"+
		                    "AL.P3Status,"+
		                    "AL.IsonSpecialOff,"+ 
		                    "AL.SpecialOffType,"+
		                    "AL.SpecialOffRemark,"+
		                    "AL.SpecialOffDuration,"+
		                    "AL.OverTime,"+
		                    "AL.OverTimeE,"+
		                    "AL.MissedOutPunch,"+
		                    "AL.MissedInPunch, "+
		                    "AL.C1, "+
		                    "AL.C2, "+
		                    "AL.C3, "+
		                    "AL.C4, "+
		                    "AL.C5, "+
		                    "AL.C6, "+
		                    "AL.C7, "+
		                    "AL.Remarks,"+ 
		                    "AL.LeaveTypeId,"+ 
		                    "AL.LossOfHours,"+
                            "AL.AttendanceHistoryId, " +
                            "E.EmployeeId,"+
		                    "E.EmployeeCode,"+
		                    "E.EmployeeName,"+
		                    "E.Gender,"+
		                    "E.DepartmentId,"+
                            "D.Department,"+
		                    "E.DesignationId,"+
                            "DM.Designation,"+
		                    "E.CategoryId,"+
                            "CT.CategoryFName,"+
		                    "E.EmployementTypeId,"+ 
                            "ETM.EmployementType,"+
		                    "E.Status, "+
		                    "E.RecordStatus,"+
		                    "E.EmployeeDeviceGroup,"+
		                    "E.LocationId,"+
                            "L.LocationName,"+
		                    "E.ContractorId,"+
                            "CM.ContractorName,"+
		                    "E.ShiftGroupId,"+
		                    "E.DeviceId,"+
                            "E.GeofenceId ";

         
         //public string TableNames_Report = " attendancelogs AL inner join Employees E on AL.EmployeeId=E.EmployeeId inner join " +
         //                                 "LocationMaster L on L.LocationId=E.LocationId inner join "+
         //                                 "departmentmaster D on D.DepartmentId=E.DepartmentId inner join "+
         //                                 "designationmaster DM on DM.DesignationId=E.DesignationId inner join "+
         //                                 "employementtypemaster ETM on ETM.EmployementTypeId=E.EmployementTypeId inner join "+
         //                                 "LocationMaster C on C.LocationId=E.LocationId inner join "+
         //                                 "contractormaster CM on CM.ContractorId=E.ContractorId inner join "+
         //                                 "shiftgroupshifts SGS on SGS.ShiftGroupShiftId=E.ShiftGroupId inner join " +
         //                                 "shiftgroups SG on SG.ShiftGroupId=SGS.ShiftGroupId inner join " +
         //                                 "shifts shif on shif.ShiftId=SGS.ShiftId inner join " +
         //                                 "Categories CT on CT.CategoryId=E.CategoryId ";

         public string TableNames_Report = " attendancelogs AL inner join Employees E on AL.EmployeeId=E.EmployeeId inner join " +
                                           "LocationMaster L on L.LocationId=E.LocationId inner join " +
                                           "departmentmaster D on D.DepartmentId=E.DepartmentId inner join " +
                                           "designationmaster DM on DM.DesignationId=E.DesignationId inner join " +
                                           "employementtypemaster ETM on ETM.EmployementTypeId=E.EmployementTypeId inner join " +
                                           "contractormaster CM on CM.ContractorId=E.ContractorId inner join " +
                                           "shiftgroups SG on E.ShiftGroupId=SG.ShiftGroupId ";


         public string Employees_ColumnNames = " E.EmployeeId," +
				                                "E.EmployeeCode as 'Code',"+
				                                "E.EmpInital,"+
				                                "E.EmployeeName as 'Employee Name',"+ 
				                                "E.Gender,"+ 
				                                "E.DOB,"+ 
				                                "E.Age,"+ 
				                                "E.MaritalStatus as 'Marital Status',"+  
				                                "E.MarriageDate as 'Marital Date',"+   
				                                "E.PersonalEmailID as 'Personal Email',"+   
				                                "E.MobileNo as 'Mobile No',"+ 
				                                "E.OfficialEmailID as 'Official Email',"+
				                                "E.BloodGroup as 'Blood Group',"+
				                                "E.AadharCardNumber as 'Aadhar Card Number',"+
				                                "E.PanCardNumber as 'PAN Card Number',"+
				                                "E.FatherName as 'Father Name',"+ 
				                                "E.MotherName as 'Mother Name',"+ 
				                                "E.DrivingLicenseNumber as 'Driving License Number',"+ 
				                                "E.PersonalIdentificationMark as 'Personal Identification Mark',"+ 
				                                "E.PhysicalDisability,"+ 
				                                "E.DescriptionOfPhysicalDisability,"+
				                                "E.DOJ,"+ 
				                                "E.TotalYearsService,"+ 
				                                "E.ContractorId,"+ 
                                                "CM.ContractorName as 'Contractor Name',"+
				                                "E.EmployementTypeId,"+ 
                                                "ETM.EmployementType as 'Employement Type',"+
				                                "E.DepartmentId,"+ 
                                                "DM.Department,"+
				                                "E.DesignationId,"+ 
                                                "DESM.Designation,"+
				                                "E.JobProfile,"+ 
				                                "E.CategoryId,"+ 
                                                "CT.CategoryFName as 'Category F Name',"+
				                                "E.LocationId,"+
                                                "LM.LocationName as 'Location Name',"+
				                                "E.ReportingTo,"+
				                                "E.Nationality,"+
				                                "E.Address,"+
				                                "AM.ContryId,"+
				                                "CMS.ContryName as 'Contry Name',"+
				                                "AM.StateId,"+
				                                "SM.StateName as 'State Name',"+
				                                "AM.DistrictId,"+
				                                "DMS.DistrictName as 'District Name',"+
				                                "AM.TalukaId,"+
				                                "TM.TalukaName as 'Taluka Name',"+
				                                "AM.CityVillageId,"+
				                                "CVM.CityVillageName as 'City/Village Name',"+
				                                "E.AreaId,"+ 
				                                "AM.AreaName as 'Area Name',"+
				                                "E.PoliceStationId,"+
                                                "CVMPS.CityVillageName as 'Police Station',"+
				                                "E.SameAsPA,"+
				                                "E.Address1,"+
				                                "AM1.ContryId,"+
				                                "CM1.ContryName as 'Contry Name',"+
				                                "AM1.StateId,"+
				                                "SM1.StateName as 'State Name',"+
				                                "AM1.DistrictId,"+
				                                "DMS1.DistrictName as 'District Name',"+
				                                "AM1.TalukaId,"+
				                                "TM1.TalukaName as 'Taluka Name',"+
				                                "AM1.CityVillageId,"+
				                                "CVM1.CityVillageName as 'City/Village Name',"+
				                                "E.AreaId1,"+ 
				                                "AM1.AreaName as 'Area Name',"+
				                                "E.PoliceStationId1,"+ 
                                                "CVMPS1.CityVillageName as 'Police Station 1',"+
				                                "E.NomineeName,"+
				                                "E.NomineeRelationship,"+
				                                "E.NomineeAddress,"+ 
				                                "E.NomineeDOB,"+
				                                "E.NomineeContactNo,"+
				                                "E.NomineeFor,"+
				                                "E.NomineeBankName,"+
				                                "E.NomineeAccountNo,"+
				                                "E.NomineeIFSCCode,"+
				                                "E.NomineeMICRCode,"+
				                                "E.EmergancyContactName,"+
				                                "E.EmergancyContactMobileNumber,"+
				                                "E.EmergancyContactWorkPhone,"+ 
				                                "E.EmergancyContactRelationship,"+
				                                "E.EmergancyContactHomePhone,"+
				                                "E.QualificationEducation,"+
				                                "E.QualificationSpeciazation,"+
				                                "E.QualificationStartDate,"+
				                                "E.QualificationEndDate,"+ 
				                                "E.QualificationScoreClass,"+
				                                "E.QualificationYear,"+
				                                "E.QualificationRemarks,"+ 
				                                "E.ExperienceEmployer,"+
				                                "E.ExperienceBranch,"+
				                                "E.ExperienceLocation,"+
				                                "E.ExperienceDesignation,"+ 
				                                "E.ExperienceCTC,"+
				                                "E.ExperienceGrossSalary,"+
				                                "E.ExperienceStartDate,"+
				                                "E.ExperienceEndDate,"+ 
				                                "E.ExperienceManager,"+ 
				                                "E.ExperienceManagerContactNo,"+
				                                "E.ExperienceIndustryType,"+
				                                "E.ExperienceRemarks,"+
				                                "E.SkillLanguage,"+ 
				                                "E.SkillFluency,"+ 
				                                "E.SkillAbilityWrite,"+
				                                "E.SkillAbilityRead,"+ 
				                                "E.SkillAbilitySpeak,"+ 
				                                "E.SkillAbilityUnderstand,"+
				                                "E.SkillType,"+
                                                "E.CostCenter,"+
                                                "E.SalaryMonthlyBasic,"+
				                                "E.SalaryMonthlyHRA,"+
				                                "E.SalaryMonthlyEducationAllowance,"+ 
				                                "E.SalaryMonthlyConveyanceAllowance,"+
				                                "E.SalaryMonthlyOtherAllowance,"+ 
				                                "E.SalaryMonthlyGrossSalary,"+ 
				                                "E.SalaryMonthlyTaxDeducted,"+
				                                "E.SalaryMonthlyProvidentFund,"+
				                                "E.SalaryMonthlyNetSalary,"+
				                                "E.SalaryAnualBasic,"+
				                                "E.SalaryAnualHRA,"+
				                                "E.SalaryAnualEducationAllowance,"+
				                                "E.SalaryAnualConveyanceAllowance,"+
				                                "E.SalaryAnualOtherAllowance,"+ 
				                                "E.SalaryAnualGrossSalary,"+ 
				                                "E.SalaryAnualTaxDeducted,"+
				                                "E.SalaryAnualProvidentFund,"+
				                                "E.SalaryAnualNetSalary,"+
				                                "E.SalaryPaymentMode,"+
				                                "E.SalaryBank,"+ 
				                                "E.SalaryAccountNo,"+
				                                "E.SalaryBranchName,"+ 
				                                "E.SalaryMICRNo,"+
				                                "E.SalaryIFSCCode,"+ 
				                                "E.SalaryPaymentMode1,"+
				                                "E.SalaryBank1,"+ 
				                                "E.SalaryAccountNo1,"+ 
				                                "E.SalaryBranchName1,"+
				                                "E.SalaryMICRNo1,"+
				                                "E.SalaryIFSCCode1,"+
				                                "E.PFMemberIDNo,"+ 
				                                "E.UANNumber,"+ 
				                                "E.ESICNo,"+ 
				                                "E.LWFLINNo,"+
				                                "E.PassportType,"+ 
				                                "E.PassportNo,"+
				                                "E.IssuesDate,"+ 
				                                "E.RenewalDate,"+
				                                "E.DateOfExpiry,"+ 
				                                "E.Citizenship,"+ 
				                                "E.DateOfJoining,"+ 
				                                "E.ConfirmDate,"+ 
				                                "E.PFStartDate,"+ 
				                                "E.DateOfRetirement,"+ 
				                                "E.DateOfExit,"+ 
				                                "E.A1,"+ 
				                                "E.A2,"+ 
				                                "E.A3,"+ 
				                                "E.DOR,"+ 
				                                "E.DOC,"+ 
				                                "E.EmployeeCodeInDevice,"+ 
				                                "E.EmployeeRFIDNumber,"+
				                                "E.Status,"+ 
				                                "E.RecordStatus,"+
				                                "E.EmployeeDeviceGroup ";

         public string Employees_Join_TableNames_Report =   "Employees E inner join " +
                                                            "contractormaster CM on CM.ContractorId=E.ContractorId inner join " +
                                                            "employementtypemaster ETM on ETM.EmployementTypeId=E.EmployementTypeId inner join " +
                                                            "departmentmaster DM on DM.DepartmentId=E.DepartmentId inner join " +
                                                            "designationmaster DESM on DESM.DesignationId=E.DesignationId inner join " +
                                                            "categories CT on CT.CategoryId=E.CategoryId inner join " +
                                                            "locationmaster LM on LM.LocationId=E.LocationId inner join " +
                                                            "AreaMaster AM on AM.AreaId=E.AreaId inner join " +
				                                            "CityVillageMaster CVM on AM.CityVillageId=CVM.CityVillageId inner join " +
				                                            "TalukaMaster TM on TM.TalukaId=CVM.TalukaId inner join " +
				                                            "DistrictMaster DMS on DMS.DistrictId=TM.DistrictId inner join " +
				                                            "ContryMaster CMS on CMS.ContryId=TM.ContryId inner join " +
				                                            "StateMaster SM on TM.StateId=SM.StateId inner join " +
				                                            "CityVillageMaster CVMPS on E.PoliceStationId=CVMPS.CityVillageId inner join " +
              	                                            "AreaMaster AM1 on AM1.AreaId=E.AreaId1 inner join " +
				                                            "CityVillageMaster CVM1 on AM1.CityVillageId=CVM1.CityVillageId inner join " +
				                                            "TalukaMaster TM1 on TM1.TalukaId=CVM1.TalukaId inner join " +
				                                            "DistrictMaster DMS1 on DMS1.DistrictId=TM1.DistrictId inner join " +
				                                            "ContryMaster CM1 on CM1.ContryId=TM1.ContryId inner join " +
				                                            "StateMaster SM1 on TM1.StateId=SM1.StateId inner join " +
				                                            "CityVillageMaster CVMPS1 on E.PoliceStationId1=CVMPS1.CityVillageId inner join " +
                                                            "shiftgroupshifts SGS on SGS.ShiftGroupShiftId=E.ShiftGroupId inner join " +
                                                            "shiftgroups SG on SG.ShiftGroupId=SGS.ShiftGroupId inner join " +
                                                            "shifts shif on shif.ShiftId=SGS.ShiftId ";

         private static string tablenames_v;
         public string TableNames_V
         {
             get { return tablenames_v; }
             set { tablenames_v = value; }
         }

         private static string columnnames_v;
         public string ColumnNames_V
         {
             get { return columnnames_v; }
             set { columnnames_v = value; }
         }

         private static string whereclause_v;
         public string WhereClause_V
         {
             get { return whereclause_v; }
             set { whereclause_v = value; }
         }

         private static string orderby_v;
         public string OrderBy_V
         {
             get { return orderby_v; }
             set { orderby_v = value; }
         }

         private static string groupby_v;
         public string GroupBy_V
         {
             get { return groupby_v; }
             set { groupby_v = value; }
         }

         private static string reportperiod;
         public string ReportPeriod
         {
             get { return reportperiod; }
             set { reportperiod = value; }
         }

        public DataSet SP_MonthlyAttendanceReport()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_MonthlyAttendanceReport";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("AttendanceDate_V", objPC.AttendanceDate);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_AttendanceLog__By_EmployeeId_Date()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_AttendanceLog__By_EmployeeId_Date";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("AttendanceDate_V", objPC.AttendanceDate);
            objCmd.Parameters.AddWithValue("EmployeeId_V", objPC.EmployeeId);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        //Report Data

        public DataSet SP_ReportData_Insert()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_ReportData_Insert";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@MonthNumber_V", objPC.MonthNumber);
            objCmd.Parameters.AddWithValue("@MonthYear_V", objPC.MonthYear);
            objCmd.Parameters.AddWithValue("@EmpId_V", objPC.EmployeeId); 
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public int SP_ReportData_Insert_Update()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_ReportData_Insert_Update";
            //objPC.ReportTableId = 1;
            objCmd.Parameters.AddWithValue("@Id_V", objPC.ReportTableId);
            objCmd.Parameters.AddWithValue("@ColumnNames_V", objPC.ColumnNames);
            //objCmd.Parameters.AddWithValue("@Column1_V", objPC.Column1_V);
            //objCmd.Parameters.AddWithValue("@Value1_V", objPC.Value1_V);
            objCmd.Connection = objBL.objCon;

            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public int SP_ReportData_Update_Total_Values()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_ReportData_Update_Total_Values";
            //objPC.ReportTableId = 1;
            objCmd.Parameters.AddWithValue("@Id_V", objPC.ReportTableId);
            objCmd.Parameters.AddWithValue("@TotalDays_V", objPC.TotalDays);
            objCmd.Parameters.AddWithValue("@TotalPresent_V", objPC.TotalPresent);
            objCmd.Parameters.AddWithValue("@TotalAbsent_V", objPC.TotalAbsent);
            objCmd.Parameters.AddWithValue("@TotalDuration_V", objPC.TotalDuration);
            objCmd.Parameters.AddWithValue("@TotalOT_V", objPC.TotalOT);
            objCmd.Parameters.AddWithValue("@TotalLate_V", objPC.TotalLate);
            objCmd.Parameters.AddWithValue("@EmployeeName_V", objPC.EmployeeName);
            objCmd.Connection = objBL.objCon;

            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public DataSet SP_Report_Query()
        {
            ColumnNames_V = MonthlyAttendance_Column;
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_Report_Query";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@TableNames_V", TableNames_V);
            objCmd.Parameters.AddWithValue("@ColumnNames_V", ColumnNames_V);
            objCmd.Parameters.AddWithValue("@OrderBy_V", OrderBy_V);
            objCmd.Parameters.AddWithValue("@GroupBy_V", GroupBy_V);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_ReportData_ViewAll()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_ReportData_ViewAll";
            objCmd.CommandType = CommandType.StoredProcedure;
            
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_Attendance_Report_Query()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            //WhereClause_V = " where AL.AttendanceDate='2022-12-04' and E.LocationId=3 and E.DepartmentId=34";
            objCmd.CommandText = "SP_Attendance_Report_Query";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@TableNames_V", TableNames_Report);
            objCmd.Parameters.AddWithValue("@ColumnNames_V", ColumnNames_Report);
            objCmd.Parameters.AddWithValue("@WhereClause_V", WhereClause_V);
            objCmd.Parameters.AddWithValue("@OrderBy_V", OrderBy_V);
            objCmd.Parameters.AddWithValue("@GroupBy_V", GroupBy_V);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataTable SP_AttendanceRecordMaster_Concat_Query()
        {
            objBL.Connect();
            DataTable ds = new DataTable();
            objCmd = new MySqlCommand();
            //WhereClause_V = " where AL.AttendanceDate='2022-12-04' and E.LocationId=3 and E.DepartmentId=34";
            objCmd.CommandText = "SP_Attendance_Report_Query";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@TableNames_V", TableNames_V);
            objCmd.Parameters.AddWithValue("@ColumnNames_V", ColumnNames_V);
            objCmd.Parameters.AddWithValue("@WhereClause_V", WhereClause_V);
            objCmd.Parameters.AddWithValue("@OrderBy_V", OrderBy_V);
            objCmd.Parameters.AddWithValue("@GroupBy_V", GroupBy_V);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_DepartmentSummaryReport_GetReport()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            //WhereClause_V = " where AL.AttendanceDate='2022-12-04' and E.LocationId=3 and E.DepartmentId=34";
            objCmd.CommandText = "SP_DepartmentSummaryReport_GetReport";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@AMonth_V", objPC.AMonth);
            objCmd.Parameters.AddWithValue("@AYear_V", objPC.AYear);
            objCmd.Parameters.AddWithValue("@LocationId_V", objPC.LocationId);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataTable SP_Attendance_Report_Query_DataTable()
        {
            objBL.Connect();
            DataTable ds = new DataTable();
            objCmd = new MySqlCommand();
            //WhereClause_V = " where AL.AttendanceDate='2022-12-04' and E.LocationId=3 and E.DepartmentId=34";
            objCmd.CommandText = "SP_Attendance_Report_Query";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@TableNames_V", TableNames_V);
            objCmd.Parameters.AddWithValue("@ColumnNames_V", ColumnNames_V);
            objCmd.Parameters.AddWithValue("@WhereClause_V", WhereClause_V);
            objCmd.Parameters.AddWithValue("@OrderBy_V", OrderBy_V);
            objCmd.Parameters.AddWithValue("@GroupBy_V", GroupBy_V);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_AttendanceRecordMaster_CheckExist()
        {
            ColumnNames_V = MonthlyAttendance_Column;
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_AttendanceRecordMaster_CheckExist";
            objCmd.CommandType = CommandType.StoredProcedure;
            //objCmd.Parameters.AddWithValue("@AttendanceRecordMasterId_V", objPC.AttendanceRecordMasterId);
            objCmd.Parameters.AddWithValue("@AttendanceDate_V", objPC.AttendanceDate);
            objCmd.Parameters.AddWithValue("@LocationId_V", objPC.LocationId);
            objCmd.Parameters.AddWithValue("@DepartmentId_V", objPC.DepartmentId);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public int SP_AttendanceRecordMaster_Insert_Update_Delete()
        {
            //DataSet ds = new DataSet();
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_AttendanceRecordMaster_Insert_Update_Delete";
            //objPC.ReportTableId = 1;
            objCmd.Parameters.AddWithValue("@AttendanceRecordMasterId_V", objPC.AttendanceRecordMasterId);
            objCmd.Parameters.AddWithValue("@EntryDate_V", objPC.EntryDate);
            objCmd.Parameters.AddWithValue("@AttendanceDate_V", objPC.AttendanceDate);
            objCmd.Parameters.AddWithValue("@LocationId_V", objPC.LocationId);
            objCmd.Parameters.AddWithValue("@DepartmentId_V", objPC.DepartmentId);
            objCmd.Parameters.AddWithValue("@InchargeId_V", objPC.InchargeId);
            objCmd.Parameters.AddWithValue("@ApprovedFlag_V", objPC.ApprovedFlag);
            objCmd.Parameters.AddWithValue("@ApprovalStatus_V", objPC.ApprovalStatus);
            objCmd.Parameters.AddWithValue("@Status_V", objPC.AttendanceStatus);
            objCmd.Parameters.AddWithValue("@UserId_V", BusinessLayer.LoginId_Static);
            objCmd.Parameters.AddWithValue("@DeleteFlag_V", objPC.DeleteFlag);
            objCmd.Parameters.AddWithValue("@AttendanceHistoryId_V", objPC.AttendanceHistoryId);
            objCmd.Connection = objBL.objCon;
            ReturnResult = Convert.ToInt32(objCmd.ExecuteScalar());

           // ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        //public int SP_AttendanceRecord_Insert_Update_Delete()
        //{
        //    int ReturnResult = 0;
        //    objBL.Connect();
        //    objCmd = new MySqlCommand();
        //    objCmd.CommandType = CommandType.StoredProcedure;
        //    objCmd.CommandText = "SP_AttendanceRecord_Insert_Update_Delete";
        //    objCmd.Parameters.AddWithValue("@AttendanceRecordId_V", objPC.AttendanceRecordId);
        //    objCmd.Parameters.AddWithValue("@AttendanceRecordMasterId_V", objPC.AttendanceRecordMasterId);
        //    objCmd.Parameters.AddWithValue("@AttendanceId_V", objPC.AttendanceId);
        //    objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
        //    objCmd.Parameters.AddWithValue("@ShiftId_V", objPC.ShiftId);
        //    objCmd.Parameters.AddWithValue("@InTime_V", objPC.InTime);
        //    objCmd.Parameters.AddWithValue("@OutTime_V", objPC.OutTime);
        //    objCmd.Parameters.AddWithValue("@Duration_V", objPC.Duration);
        //    objCmd.Parameters.AddWithValue("@OverTime_V", objPC.OverTime);
        //    objCmd.Parameters.AddWithValue("@TotalDuration_V", objPC.TotalDuration);
        //    objCmd.Parameters.AddWithValue("@OTByChange_V", objPC.OTByChange);
        //    objCmd.Parameters.AddWithValue("@Status_V", objPC.Status);
        //    objCmd.Parameters.AddWithValue("@WorkingTransfer_V", objPC.WorkingTransfer);
        //    objCmd.Parameters.AddWithValue("@InchargeRemark_V", objPC.InchargeRemark);
        //    objCmd.Parameters.AddWithValue("@LeaveApplication_V", objPC.LeaveApplication);
        //    objCmd.Parameters.AddWithValue("@LateComming_V", objPC.LateComming);
        //    objCmd.Parameters.AddWithValue("@Remarks_V", objPC.Remarks);
        //    objCmd.Parameters.AddWithValue("@LateBy_V", objPC.LateBy);
        //    objCmd.Parameters.AddWithValue("@EarlyBy_V", objPC.EarlyBy);
        //    objCmd.Parameters.AddWithValue("@MissedInPunch_V", objPC.MissedInPunch);
        //    objCmd.Parameters.AddWithValue("@MissedOutPunch_V", objPC.MissedOutPunch);
        //    objCmd.Parameters.AddWithValue("@ChangeDepartmentId_V", objPC.ChangeDepartmentId);
        //    objCmd.Parameters.AddWithValue("@UserId_V", BusinessLayer.LoginId_Static);
        //    objCmd.Parameters.AddWithValue("@DeleteFlag_V", objPC.DeleteFlag);
        //    objCmd.Parameters.AddWithValue("@AttendanceHistoryId_V", objPC.AttendanceHistoryId);
        //    objCmd.Connection = objBL.objCon;
        //    ReturnResult = objCmd.ExecuteNonQuery();
        //    return ReturnResult;
        //}

        public int SP_AttendanceRecord_Insert_Update()
        {
            string SCode = string.Empty;
            int ReturnResult = 0;

            if (objPC.EmployeeId > 0)
            {
                objPC.Present = 0; objPC.Absent = 0;

                if (!string.IsNullOrEmpty(Convert.ToString(objPC.StatusCode)))
                {
                    SCode = objPC.StatusCode;

                    if (SCode == "A")
                    {
                        objPC.Absent = 1;
                        objPC.PunchRecords = "";
                    }
                    else if (SCode == "WO")
                        objPC.Present = 0;
                    else if (SCode == "WOP")
                    {
                        if (objPC.OverTimeApplicable == 0)
                            objPC.Present = 1;
                        else
                            objPC.Present = 0;
                    }
                    else if (SCode == "H")
                        objPC.Present = 0;
                    else if (SCode == "P")
                        objPC.Present = 1;
                    else if (SCode == "HD")
                    {
                        objPC.Present = 0.5;
                        objPC.Absent = 0.5;
                    }
                    else if (SCode == "HP")
                        objPC.Present = 1;
                    else if (SCode == "L")
                    {
                        objPC.Present = 0;
                        objPC.Absent = 0;
                    }
                    else if (SCode == "CO")
                    {
                        objPC.Present = 0;
                        objPC.Absent = 0;
                    }
                    else if (SCode == "COU")
                    {
                        objPC.Present = 0;
                        objPC.Absent = 0;
                    }
                    else if (SCode == "MOP")
                    {
                        objPC.Present = 0;
                        objPC.Absent = 0;
                    }
                    else if (SCode == "SL")
                    {
                        objPC.Present = 0;
                        objPC.Absent = 0;
                    }
                    else
                    {

                    }
                }

                //DataSet dsARM = new DataSet();
                //objBL.Query = "select AR.AttendanceRecordId, ARM.AttendanceRecordMasterId,AR.ShiftId,AR.ShiftGroupId from attendancerecord AR inner join attendancerecordmaster ARM on ARM.AttendanceRecordMasterId=AR.AttendanceRecordMasterId where ARM.AttendanceDate='" + objPC.AttendanceDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and AR.EmployeeId=" + objPC.EmployeeId + " and AR.CancelTag=0 and ARM.CancelTag=0 and ARM.LocationId=" + objPC.LocationId + "  and  ARM.DepartmentId=" + objPC.DepartmentId + " ";
                //dsARM = objBL.ReturnDataSet();
                //if (dsARM.Tables[0].Rows.Count > 0)
                //{
                //    if (!string.IsNullOrEmpty(Convert.ToString(dsARM.Tables[0].Rows[0]["AttendanceRecordId"])))
                //    {
                //        objPC.AttendanceRecordId = Convert.ToInt32(dsARM.Tables[0].Rows[0]["AttendanceRecordId"]);
                //        objPC.AttendanceRecordMasterId = Convert.ToInt32(dsARM.Tables[0].Rows[0]["AttendanceRecordMasterId"]);
                //    }
                //}

                DataSet ds = new DataSet();
                objBL.Query = "select AR.AttendanceRecordId, ARM.AttendanceRecordMasterId,AR.ShiftId,AR.ShiftGroupId from attendancerecord AR inner join attendancerecordmaster ARM on ARM.AttendanceRecordMasterId=AR.AttendanceRecordMasterId where ARM.AttendanceDate='" + objPC.AttendanceDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and AR.EmployeeId=" + objPC.EmployeeId + " and AR.CancelTag=0 and ARM.CancelTag=0 "; // and ARM.AttendanceRecordMasterId=" + objPC.AttendanceRecordMasterId + "";
                ds = objBL.ReturnDataSet();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["AttendanceRecordId"])))
                    {
                        objPC.AttendanceRecordId = Convert.ToInt32(ds.Tables[0].Rows[0]["AttendanceRecordId"]);
                        //objPC.AttendanceRecordMasterId = Convert.ToInt32(ds.Tables[0].Rows[0]["AttendanceRecordMasterId"]);
                    }
                }
                else
                {
                    objPC.AttendanceRecordId = 0;
                    //objPC.AttendanceRecordMasterId = 0;
                    //objPC.ApprovalStatusId = 1;
                    //RedundancyLogics objRL = new RedundancyLogics();
                    //objRL.Get_Incharge_Senior_OfficerId();
                    //objPC.AttendanceRecordMasterId = SP_AttendanceRecordMaster_CheckExist_Insert();
                }

                objBL.Connect();
                objCmd = new MySqlCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SP_AttendanceRecord_Insert_Update";
                objCmd.Parameters.AddWithValue("@AttendanceRecordId_V", objPC.AttendanceRecordId);
                objCmd.Parameters.AddWithValue("@AttendanceRecordMasterId_V", objPC.AttendanceRecordMasterId);
                objCmd.Parameters.AddWithValue("@AttendanceHistoryId_V", objPC.AttendanceHistoryId);
                objCmd.Parameters.AddWithValue("@EsslAttendanceLogsId_V", objPC.EsslAttendanceLogsId);
                objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
                objCmd.Parameters.AddWithValue("@ShiftId_V", objPC.ShiftId);
                objCmd.Parameters.AddWithValue("@ShiftGroupId_V", objPC.ShiftGroupId);
                objCmd.Parameters.AddWithValue("@InTime_V", objPC.InTime);
                objCmd.Parameters.AddWithValue("@OutTime_V", objPC.OutTime);
                objCmd.Parameters.AddWithValue("@Duration_V", objPC.Duration);
                objCmd.Parameters.AddWithValue("@OverTime_V", objPC.OverTime);
                objCmd.Parameters.AddWithValue("@TotalDuration_V", objPC.TotalDuration);
                objCmd.Parameters.AddWithValue("@Status_V", objPC.StatusCode);
                objCmd.Parameters.AddWithValue("@LateBy_V", objPC.LateBy);
                objCmd.Parameters.AddWithValue("@EarlyBy_V", objPC.EarlyBy);
                objCmd.Parameters.AddWithValue("@MissedInPunch_V", objPC.MissedInPunch);
                objCmd.Parameters.AddWithValue("@MissedOutPunch_V", objPC.MissedOutPunch);
                objCmd.Parameters.AddWithValue("@ChangeDepartmentFlag_V", objPC.ChangeDepartmentFlag);
                objCmd.Parameters.AddWithValue("@ChangeDepartmentId_V", objPC.ChangeDepartmentId);
                objCmd.Parameters.AddWithValue("@ChangeLocationtId_V", objPC.ChangeLocationtId);
                objCmd.Parameters.AddWithValue("@LeaveTypeId_V", objPC.LeaveTypeId);
                objCmd.Parameters.AddWithValue("@LeaveDuration_V", objPC.LeaveDuration);
                objCmd.Parameters.AddWithValue("@WeeklyOff_V", objPC.WeeklyOff);
                objCmd.Parameters.AddWithValue("@Holiday_V", objPC.Holiday);
                objCmd.Parameters.AddWithValue("@LeaveRemarks_V", objPC.LeaveRemarks);
                objCmd.Parameters.AddWithValue("@PunchRecords_V", objPC.PunchRecords);
                objCmd.Parameters.AddWithValue("@LossOfHours_V", objPC.LossOfHours);
                objCmd.Parameters.AddWithValue("@Present_V", objPC.Present);
                objCmd.Parameters.AddWithValue("@Absent_V", objPC.Absent);
                objCmd.Parameters.AddWithValue("@Remarks_V", objPC.Remarks);
                objCmd.Parameters.AddWithValue("@Notes_V", objPC.RemarksReply);
                objCmd.Parameters.AddWithValue("@OverTimeManualFlag_V", objPC.OverTimeManualFlag);
                objCmd.Parameters.AddWithValue("@EditFlag_V", objPC.EditFlag);
                objCmd.Parameters.AddWithValue("@UserId_V", BusinessLayer.LoginId_Static);
                objCmd.Parameters.AddWithValue("@FinancialYearId_V", objPC.FinancialYearId);

                //objPC.OutDoorEntryFlag = 0;
                objCmd.Parameters.AddWithValue("@OutDoorEntryFlag_V", objPC.OutDoorEntryFlag);
                //objCmd.Parameters.AddWithValue("@ChangeLocation_V", objPC.ChangeLocation);
                //objCmd.Parameters.AddWithValue("@ChangeDepartment_V", objPC.ChangeDepartment);
                objCmd.Connection = objBL.objCon;
                ReturnResult = objCmd.ExecuteNonQuery();
                objBL.objCon.Close();
            }
            return ReturnResult;
        }

        public int SP_AttendanceRecordMaster_Update_ApprovalFlag()
        {
            int ReturnResult = 0;
            objBL.Connect();
            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_AttendanceRecordMaster_Update_ApprovalFlag";
            objCmd.Parameters.AddWithValue("@AttendanceRecordMasterId_V", objPC.AttendanceRecordMasterId);
            objCmd.Parameters.AddWithValue("@ApprovedFlag_V", objPC.ApprovedFlag);
            objCmd.Parameters.AddWithValue("@ApprovalStatus_V", objPC.ApprovalStatus);
            objCmd.Parameters.AddWithValue("@Status_V", objPC.AttendanceStatus);
            objCmd.Parameters.AddWithValue("@UserId_V", BusinessLayer.LoginId_Static);
            objCmd.Connection = objBL.objCon;
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }


        public TimeSpan OTHours, TotalDurationHours; // = TimeSpan.Parse(objPC.TotalDuration.ToString());

        string OTColumnName = string.Empty;
        string OTValue = string.Empty;

        string DurationColumnName = string.Empty;
        string DurationValue = string.Empty;

        string StatusColumnName = string.Empty;
        string StatusValue = string.Empty;

        string LateByColumnName = string.Empty;
        string LateByValue = string.Empty;

        string EarlyByColumnName = string.Empty;
        string EarlyByValue = string.Empty;

        double TotalPresent = 0, TotalAbsent = 0, TotalOT = 0, TotalHours = 0, TotalWeeklyOff = 0, TotalHoliday = 0, TotalLateBy = 0, TotalEarlyBy = 0;

        public void GetSumOTRecords(DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Columns.Count > 0)
                {
                    TotalPresent = 0; TotalAbsent = 0; TotalOT = 0; TotalHours = 0; TotalWeeklyOff = 0; TotalHoliday = 0; TotalLateBy = 0; TotalEarlyBy = 0;

                    TotalDurationHours = TimeSpan.Parse("00:00");
                    OTHours = TimeSpan.Parse("00:00");

                    for (int i = 1; i < 32; i++)
                    {
                        OTValue = "";
                        OTColumnName = "OT" + i;

                        DurationValue = "";
                        DurationColumnName = "Duration" + i;

                        StatusValue = "";
                        StatusColumnName = "Status" + i;

                        LateByColumnName = "LT" + i;
                        LateByValue = string.Empty;

                        EarlyByColumnName = string.Empty;
                        EarlyByValue = string.Empty;

                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][LateByColumnName])))
                        {
                            LateByValue = Convert.ToString(ds.Tables[0].Rows[0][LateByColumnName].ToString());

                            double LateBy = 0;
                            LateBy = Convert.ToDouble(LateByValue);

                            if (LateBy > 0)
                                TotalLateBy++;
                        }

                        //10319
                        //objPC.EmployeeCode
                       // objPC.EmployeeId
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][OTColumnName])))
                        {

                            OTValue = Convert.ToString(ds.Tables[0].Rows[0][OTColumnName].ToString());
                            OTHours += TimeSpan.Parse(OTValue);
                        }

                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][DurationColumnName])))
                        {
                            //double OTH = objPC.OTHours_TS.Hours;
                            ///objPC.TotalDuration_TS
                            DurationValue = Convert.ToString(ds.Tables[0].Rows[0][DurationColumnName].ToString());
                            //TimeSpan Value1 = TimeSpan.Parse(DurationValue); 
                            TotalDurationHours += TimeSpan.Parse(DurationValue);
                        }

                        //½P	0.5
                        //A	    0
                        //A(OD)	0
                        //H	    1   
                        //H½P	0.5
                        //HA	0
                        //HP	1
                        //P	    1
                        //P(OD)	1
                        //WO	1
                        //WO½P	0.5
                        //WOA	0
                        //WOP	1

                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][StatusColumnName].ToString())))
                        {
                            StatusValue = Convert.ToString(ds.Tables[0].Rows[0][StatusColumnName].ToString());
                            objPC.Status = StatusValue;

                            if (objPC.Status == "½P")
                                TotalPresent += 0.5;
                            else if (objPC.Status == "A")
                                TotalAbsent += 1;
                            else if (objPC.Status == "A(OD)")
                                TotalAbsent += 1;
                            else if (objPC.Status == "H")
                                TotalHoliday += 1;
                            else if (objPC.Status == "H½P")
                                TotalPresent += 0.5;
                            else if (objPC.Status == "HA")
                                TotalAbsent += 1;
                            else if (objPC.Status == "HP")
                                TotalPresent += 1;
                            else if (objPC.Status == "P")
                                TotalPresent += 1;
                            else if (objPC.Status == "P(OD)")
                                TotalPresent += 1;
                            else if (objPC.Status == "WO")
                                TotalWeeklyOff += 1;
                            else if (objPC.Status == "WO½P")
                                TotalPresent += 0.5;
                            else if (objPC.Status == "WOP")
                                TotalPresent += 1;
                            else
                            {
                            }

                            objBL.Query = "";
                            //int Monthdays = DateTime.DaysInMonth(objPC.AYear, objPC.AMonth);

                            objBL.Query = "update attendancemonthlydata set TotalPresent='" + TotalPresent + "',TotalAbsent='" + TotalAbsent + "',TotalOT='" + OTHours + "',TotalWeeklyOff='" + TotalWeeklyOff + "',TotalHoliday='" + TotalHoliday + "',TotalLateBy='" + TotalLateBy + "',TotalEarlyBy='" + TotalLateBy + "' where AYear=" + objPC.AYear + " and AMonth=" + objPC.AMonth + " and EmployeeId=" + objPC.EmployeeId + "";
                            int R = objBL.Function_ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public bool SP_AttendanceMonthlyData_CheckExist()
        {
            bool ReturnResult = false;
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_AttendanceMonthlyData_CheckExist";
            objCmd.Parameters.AddWithValue("@AYear_V", objPC.AYear);
            objCmd.Parameters.AddWithValue("@AMonth_V", objPC.AMonth);
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Id"].ToString()))
                {
                    //GetSumOTRecords(ds);
                    ReturnResult = true;
                }
                else
                    ReturnResult = false;
            }
            else
                ReturnResult = false;

            objBL.objCon.Close();
            return ReturnResult;
        }

        public void SP_AttendanceMonthlyData_Total_Update_All_Records()
        {
            bool ReturnResult = false;
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_AttendanceMonthlyData_CheckExist";
            objCmd.Parameters.AddWithValue("@AYear_V", objPC.AYear);
            objCmd.Parameters.AddWithValue("@AMonth_V", objPC.AMonth);
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Id"].ToString()))
                    GetSumOTRecords(ds);
            }

            objBL.objCon.Close();
        }
       
        public int SP_AttendanceMonthlyData_TotalHours()
        {
            int ReturnResult = 0;
            objBL.Connect();
            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_AttendanceMonthlyData_TotalHours";
            objCmd.Parameters.AddWithValue("@AYear_V", objPC.AYear);
            objCmd.Parameters.AddWithValue("@AMonth_V", objPC.AMonth);
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.Connection = objBL.objCon;
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public int SP_AttendanceMonthlyData_Update_All()
        {
            int ReturnResult = 0;
            objBL.Connect();
            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_AttendanceMonthlyData_Update_All";
            objCmd.Parameters.AddWithValue("@AYear_V", objPC.AYear);
            objCmd.Parameters.AddWithValue("@AMonth_V", objPC.AMonth);
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.Parameters.AddWithValue("@UserId_V", BusinessLayer.LoginId_Static);
            objCmd.Parameters.AddWithValue("@CheckR", 'P');
            objCmd.Connection = objBL.objCon;
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public DataSet SP_AttendanceMonthlyData_MonthlyReport()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_AttendanceMonthlyData_MonthlyReport";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@AYear_V", objPC.AYear);
            objCmd.Parameters.AddWithValue("@AMonth_V", objPC.AMonth);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        

        public DataSet SP_DepartmentMaster_ById(string DeptIDName,string SearchBy)
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_DepartmentMaster_ById";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@DepartmentId_V", DeptIDName);
            objCmd.Parameters.AddWithValue("@SearchBy", SearchBy);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataTable SP_AttendanceRecordMaster_FillGrid()
        {
            objBL.Connect();
            DataTable ds = new DataTable();
            objCmd = new MySqlCommand();
            // WhereClause_V = " where AL.AttendanceDate='2022-12-04' and E.LocationId=3 and E.DepartmentId=34";
            objCmd.CommandText = "SP_AttendanceRecordMaster_FillGrid";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@LocationId_V", objPC.LocationId);
            objCmd.Parameters.AddWithValue("@DepartmentId_V", objPC.DepartmentId);
            objCmd.Parameters.AddWithValue("@ApprovalStatusId_V", objPC.ApprovalStatusId);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataTable SP_AttendanceRecordMaster_FillGrid_Admin_Officer()
        {
            objBL.Connect();
            DataTable ds = new DataTable();
            objCmd = new MySqlCommand();
            // WhereClause_V = " where AL.AttendanceDate='2022-12-04' and E.LocationId=3 and E.DepartmentId=34";
            objCmd.CommandText = "SP_AttendanceRecordMaster_FillGrid_Admin_Officer";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataTable SP_AttendanceRecord_FillGrid_By_AttendanceRecordMasterId()
        {
            objBL.Connect();
            DataTable ds = new DataTable();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_AttendanceRecord_FillGrid_By_AttendanceRecordMasterId";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@AttendanceRecordMasterId_V", objPC.AttendanceRecordMasterId);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataTable SP_AttendanceRecord_FillGrid_By_BetweenDates()
        {
            objBL.Connect();
            DataTable ds = new DataTable();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_AttendanceRecord_FillGrid_By_BetweenDates";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@FromDate_V", objPC.FromDate);
            objCmd.Parameters.AddWithValue("@ToDate_V", objPC.ToDate);
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataTable SP_AttendanceRecord_Get_By_AttendanceRecordId()
        {
            objBL.Connect();
            DataTable ds = new DataTable();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_AttendanceRecord_Get_By_AttendanceRecordId";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@AttendanceRecordId_V", objPC.AttendanceRecordId);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        //Employee Master
        //SP_Employees_CheckExist_By_EmployeeId
        public bool SP_Employees_CheckExist_By_EmployeeId()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_Employees_CheckExist_By_EmployeeId";
            objCmd.CommandType = CommandType.StoredProcedure;


            objCmd.Parameters.AddWithValue("@EmployeeCode_V", objPC.EmployeeCode);
            //objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if(!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["EmployeeId"].ToString())))
                    objPC.EmployeeId = Convert.ToInt32(ds.Tables[0].Rows[0]["EmployeeId"].ToString());

                return true;
            }
            else
                return false;
        }

        public bool SP_Employees_CheckExist_By_EmployeeId_Attendance()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_Employees_CheckExist_By_EmployeeId_Attendance";
            objCmd.CommandType = CommandType.StoredProcedure;


            objCmd.Parameters.AddWithValue("@EmployeeCode_V", objPC.EmployeeCode);
            //objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["EmployeeId"].ToString())))
                    objPC.EmployeeId = Convert.ToInt32(ds.Tables[0].Rows[0]["EmployeeId"].ToString());

                return true;
            }
            else
                return false;
        }

        public DataSet SP_Employees_By_EmployeeCode()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_Employees_By_EmployeeCode";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@EmployeeCode_V", objPC.EmployeeCode);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_AttendancelogPunchRecord_FillGrid()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_AttendancelogPunchRecord_FillGrid";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@AttendanceDate_V", objPC.AttendanceDate);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public int SP_AttendancelogPunchRecord_Insert()
        {
            int ReturnResult = 0;
            objBL.Connect();
            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_AttendancelogPunchRecord_Insert";
            objCmd.Parameters.AddWithValue("@ESSLAttendanceLogId_V", objPC.AttendanceLogId);
            objCmd.Parameters.AddWithValue("@AttendanceDate_V", objPC.AttendanceDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD));
            objCmd.Parameters.AddWithValue("@ESSLEmployeeId_V", objPC.ESSLEmployeeId);
            objCmd.Parameters.AddWithValue("@InTime_V", objPC.InTime.ToString(BusinessResources.TimeFormat_HHMM));
            objCmd.Parameters.AddWithValue("@InDeviceId_V", objPC.InDeviceId);
            objCmd.Parameters.AddWithValue("@OutTime_V", objPC.OutTime.ToString(BusinessResources.TimeFormat_HHMM));
            objCmd.Parameters.AddWithValue("@OutDeviceId_V", objPC.OutDeviceId);
            objCmd.Parameters.AddWithValue("@Duration_V", objPC.Duration_Float);
            objCmd.Parameters.AddWithValue("@PunchRecords_V", objPC.PunchRecords);
            objCmd.Parameters.AddWithValue("@ShiftId_V", objPC.ShiftId);
            objCmd.Parameters.AddWithValue("@Present_V", objPC.Present);
            objCmd.Parameters.AddWithValue("@Absent_V", objPC.Absent);
            objCmd.Parameters.AddWithValue("@Status_V", objPC.Status);
            objCmd.Parameters.AddWithValue("@StatusCode_V", objPC.StatusCode);
            objCmd.Parameters.AddWithValue("@MissedOutPunch_V", objPC.MissedOutPunch);
            objCmd.Parameters.AddWithValue("@Remarks_V", objPC.Remarks);
            objCmd.Parameters.AddWithValue("@MissedInPunch_V", objPC.MissedInPunch);
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.Parameters.AddWithValue("@EmployeeCode_V", objPC.EmployeeCode);
            objCmd.Parameters.AddWithValue("@LocationName_V", objPC.LocationName);
            objCmd.Parameters.AddWithValue("@DepartmentName_V", objPC.Department);
            objCmd.Parameters.AddWithValue("@UserId_V", BusinessLayer.LoginId_Static);
            objCmd.Connection = objBL.objCon;
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public int AttendanceRecordMasterId_QL = 0;
       
        public int SP_AttendanceRecordMaster_CheckExist_Insert()
        {
            int Result = 0;
            objBL.Connect();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_AttendanceRecordMaster_CheckExist_Insert";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@AttendanceRecordMasterId_V", objPC.AttendanceRecordMasterId);
            objCmd.Parameters.AddWithValue("@AttendanceHistoryId_V", objPC.AttendanceHistoryId);
            objCmd.Parameters.AddWithValue("@EsslAttendanceLogsId_V", objPC.EsslAttendanceLogsId);
            objCmd.Parameters.AddWithValue("@EntryDate_V", objPC.EntryDate);
            objCmd.Parameters.AddWithValue("@AttendanceDate_V", objPC.AttendanceDate);
            objCmd.Parameters.AddWithValue("@LocationId_V", objPC.LocationId);
            objCmd.Parameters.AddWithValue("@DepartmentId_V", objPC.DepartmentId);
            objCmd.Parameters.AddWithValue("@HRId_V", objPC.HRId);
            objCmd.Parameters.AddWithValue("@InchargeId_V", objPC.InchargeId);
            objCmd.Parameters.AddWithValue("@ApprovalStatusId_V", objPC.ApprovalStatusId);
            objCmd.Parameters.AddWithValue("@CompleteFlag_V", objPC.CompleteFlag);
            objCmd.Parameters.AddWithValue("@UserId_V", BusinessLayer.EmployeeLoginId_Static);
            objCmd.Parameters.AddWithValue("@FinancialYearId_V", objPC.FinancialYearId);
            objCmd.Connection = objBL.objCon;
            Result = Convert.ToInt32(objCmd.ExecuteScalar());
            return Result;
        }

        public int SP_AttendanceRecordMaster_Update_ApprovalStatus()
        {
            int Result = 0;
            objBL.Connect();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_AttendanceRecordMaster_CheckExist_Insert";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@AttendanceRecordMasterId_V", objPC.AttendanceRecordMasterId);
            objCmd.Parameters.AddWithValue("@HRId_V", BusinessLayer.EmployeeLoginId_Static);
            objCmd.Parameters.AddWithValue("@InchargeId_V", BusinessLayer.EmployeeLoginId_Static);
            objCmd.Parameters.AddWithValue("@ApprovalStatusId_V", objPC.ApprovalStatusId);
            objCmd.Parameters.AddWithValue("@CompleteFlag_V", objPC.CompleteFlag);
            objCmd.Parameters.AddWithValue("@UserId_V", BusinessLayer.EmployeeLoginId_Static);
            objCmd.Connection = objBL.objCon;
            Result = Convert.ToInt32(objCmd.ExecuteScalar());
            return Result;
        }

        //Check Exist AttendanceRecord
        public bool SP_AttendanceRecord_CheckExist()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_AttendanceRecord_CheckExist";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@AttendanceDate_V", objPC.AttendanceDate);
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            //objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["AttendanceRecordId"].ToString())))
                {
                    objPC.AttendanceRecordId = Convert.ToInt32(ds.Tables[0].Rows[0]["AttendanceRecordId"].ToString());

                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["EditFlag"].ToString())))
                        objPC.EditFlag = Convert.ToInt32(ds.Tables[0].Rows[0]["EditFlag"].ToString());

                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        

        public DataSet SP_Employees_ListBox_LikeSearch()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_Employees_ListBox_LikeSearch";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@SearchText_V", SearchText);
            objCmd.Parameters.AddWithValue("@SearchType_V", SearchType);
            objCmd.Connection = objBL.objCon;
            
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }


        public void Fill_Employee_ListBox(ListBox lb, string SearchText_V, string SearchType_V)
        {
            lb.DataSource = null;
            DataSet ds = new DataSet();

            objPC.EmployeeCode = 0;
            SearchText = SearchText_V;
            SearchType = SearchType_V;
            ds = SP_Employees_ListBox_LikeSearch();
            if (ds.Tables[0].Rows.Count > 0)
            {
                lb.Visible = true;
                lb.DataSource = ds.Tables[0];
                lb.DisplayMember = "EmpData";
                lb.ValueMember = "EmployeeCode";
                //lb.ValueMember = "EmployeeId";
                lb.SelectedIndex = -1;
            }
        }

        public void Fill_Employee_RichTextBox(RichTextBox rtb, int EmployeeId_F)
        {
            if (EmployeeId_F != 0)
            {
                SP_Employees_By_Id(EmployeeId_F);
                Supplier_Details_RichTextBox();
                rtb.Text = EmployeeDetails_RTB.ToString();
            }
        }

        public string EmployeeDetails_RTB = string.Empty;

        private void Supplier_Details_RichTextBox()
        {
            EmployeeDetails_RTB = string.Empty;

            EmployeeDetails_RTB =   "Employee Code:\t\t" + objPC.EmployeeCode + "\n" +
                                    "Employee Name:\t\t" + objPC.EmployeeName + "\n" +
                                    "Department:\t\t" + objPC.DepartmentName + "\n" +
                                    "Designation:\t\t" + objPC.Designation + "\n" +
                                    "Location Name:\t\t" + objPC.Location + "\n" +
                                    "Contractor Name:\t" + objPC.ContractorName + "\n" +
                                    "Employement Type:\t" + objPC.EmployementType + "\n" +
                                    "Category:\t\t" + objPC.CategoryName;
        }

        public void SP_Employees_By_Id(int EmployeeId_F)
        {
            if (EmployeeId_F != 0)
            {
                objBL.Connect();
                DataSet ds = new DataSet();
                objCmd = new MySqlCommand();
                objCmd.CommandText = "SP_Employees_By_Id";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@EmployeeId_V", EmployeeId_F);
                objCmd.Connection = objBL.objCon;
                objDA = new MySqlDataAdapter(objCmd);
                objDA.Fill(ds);
                objBL.objCon.Close();
                
                if (ds.Tables[0].Rows.Count > 0)
                {
                    objPC.EmployeeId = Convert.ToInt32(ds.Tables[0].Rows[0]["EmployeeId"].ToString());
                    objPC.EmployeeCode = Convert.ToInt32(ds.Tables[0].Rows[0]["EmployeeCode"].ToString());
                    objPC.EmployeeName = Convert.ToString(ds.Tables[0].Rows[0]["EmployeeName"].ToString());
                    objPC.DepartmentName = Convert.ToString(ds.Tables[0].Rows[0]["Department"].ToString());
                    objPC.Designation = Convert.ToString(ds.Tables[0].Rows[0]["Designation"].ToString());
                    objPC.CategoryName = Convert.ToString(ds.Tables[0].Rows[0]["CategoryFName"].ToString());
                    objPC.EmployementType = Convert.ToString(ds.Tables[0].Rows[0]["EmployementType"].ToString());
                    objPC.Location = Convert.ToString(ds.Tables[0].Rows[0]["LocationName"].ToString());
                    //objPC.Grade = Convert.ToString(ds.Tables[0].Rows[0]["Grade"].ToString());
                    objPC.ContractorName = Convert.ToString(ds.Tables[0].Rows[0]["ContractorName"].ToString());
                    objPC.Status = Convert.ToString(ds.Tables[0].Rows[0]["Status"].ToString());
                }
            }
        }

        //Location Master
        //PropertyClass objPC = new PropertyClass();
        public int SP_LocationMaster_Insert_Update_Delete()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_LocationMaster_Insert_Update_Delete";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@LocationId_V", objPC.LocationId);
            objCmd.Parameters.AddWithValue("@LocationName_V", objPC.LocationName);
            objCmd.Parameters.AddWithValue("@Description_V", objPC.Description);
            objCmd.Parameters.AddWithValue("@ContactPerson_V", objPC.ContactPerson);
            objCmd.Parameters.AddWithValue("@MobileNumber_V", objPC.MobileNumber);
            objCmd.Parameters.AddWithValue("@ExtensionNo_V", objPC.ExtensionNo);
            objCmd.Parameters.AddWithValue("@UserId_V", objPC.UserId);
            objCmd.Parameters.AddWithValue("@DeleteFlag_V", objPC.DeleteFlag);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public DataSet SP_LocationMaster_CheckExist()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_LocationMaster_CheckExist";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@LocationId_V", objPC.LocationId);
            objCmd.Parameters.AddWithValue("@LocationName_V", objPC.LocationName);
             
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_LocationMaster_FillGrid()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_LocationMaster_FillGrid";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@LocationName_V", objPC.LocationName);
            objCmd.Parameters.AddWithValue("@Search_V", objPC.SearchFlag);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_CompanyProfile_Report()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_CompanyProfile_Report";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        //Employee Type Master

        public DataSet SP_EmployementTypeMaster_CheckExist()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_EmployementTypeMaster_CheckExist";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@EmployementTypeId_V", objPC.EmployementTypeId);
            objCmd.Parameters.AddWithValue("@EmployementType_V", objPC.EmployementType);

            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public int SP_EmployementTypeMaster_Insert_Update_Delete()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_EmployementTypeMaster_Insert_Update_Delete";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@EmployementTypeId_V", objPC.EmployementTypeId);
            objCmd.Parameters.AddWithValue("@EmployementType_V", objPC.EmployementType);
            objCmd.Parameters.AddWithValue("@Description_V", objPC.Description);
            objCmd.Parameters.AddWithValue("@UserId_V", objPC.UserId);
            objCmd.Parameters.AddWithValue("@DeleteFlag_V", objPC.DeleteFlag);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public DataSet SP_EmployementTypeMaster_FillGrid()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_EmployementTypeMaster_FillGrid";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@EmployementType_V", objPC.EmployementType);
            objCmd.Parameters.AddWithValue("@Search_V", objPC.SearchFlag);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public int SP_Employees_Insert_ESSLData()
        {
            int ReturnResult = 0;
            objBL.Connect();
            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_Employees_Insert_ESSLData";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.Parameters.AddWithValue("@EmployeeCode_V", objPC.EmployeeCode);
            objCmd.Parameters.AddWithValue("@EmployeeName_V", objPC.EmployeeName);
            objCmd.Parameters.AddWithValue("@Gender_V", objPC.Gender);
            //objCmd.Parameters.AddWithValue("@CompanyId_V", objPC.CompanyId);
            objCmd.Parameters.AddWithValue("@DepartmentId_V", objPC.DepartmentId);
            objCmd.Parameters.AddWithValue("@DesignationId_V", objPC.DesignationId);
            objCmd.Parameters.AddWithValue("@CategoryId_V", objPC.CategoryId);
            objCmd.Parameters.AddWithValue("@EmployeeCodeInDevice_V", objPC.EmployeeCodeInDevice);
            objCmd.Parameters.AddWithValue("@EmployeeRFIDNumber_V", objPC.EmployeeRFIDNumber);
            objCmd.Parameters.AddWithValue("@EmployementTypeId_V", objPC.EmployementTypeId);
            objCmd.Parameters.AddWithValue("@Status_V", objPC.Status);
            objCmd.Parameters.AddWithValue("@RecordStatus_V", objPC.RecordStatus);
            objCmd.Parameters.AddWithValue("@EmployeeDeviceGroup_V", objPC.EmployeeDeviceGroup);
            objCmd.Parameters.AddWithValue("@LocationId_V", objPC.LocationId);
            //objCmd.Parameters.AddWithValue("@Grade_V", objPC.Grade);
            objCmd.Parameters.AddWithValue("@ContractorId_V", objPC.ContractorId);
            objCmd.Parameters.AddWithValue("@ShiftGroupId_V", objPC.ShiftGroupId);
            objCmd.Parameters.AddWithValue("@DeviceId_V", objPC.DeviceId);
            objCmd.Parameters.AddWithValue("@GeofenceId_V", objPC.GeofenceId);
            objCmd.Parameters.AddWithValue("@NewFlag_V", objPC.NewFlag);
           
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        //LeaveMaster

        public int SP_LeaveTypes_Insert_Update_Delete()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_LeaveTypes_Insert_Update_Delete";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@LeaveTypeId_V", objPC.LeaveTypeId);
            objCmd.Parameters.AddWithValue("@LeaveTypeFName_V", objPC.LeaveTypeFName);
            objCmd.Parameters.AddWithValue("@Description_V", objPC.Description);
            objCmd.Parameters.AddWithValue("@UserId_V", objPC.UserId);
            objCmd.Parameters.AddWithValue("@DeleteFlag_V", objPC.DeleteFlag);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public DataSet SP_LeaveTypes_CheckExist()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_LeaveTypes_CheckExist";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@LeaveTypeId_V", objPC.LeaveTypeId);
            objCmd.Parameters.AddWithValue("@LeaveTypeFName_V", objPC.LeaveTypeFName);

            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_LeaveTypes_FillGrid()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_LeaveTypes_FillGrid";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@LeaveTypeFName_V", objPC.LeaveTypeFName);
            objCmd.Parameters.AddWithValue("@Search_V", objPC.SearchFlag);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        //Contry Master: Yashwant
        public DataSet SP_ContryMaster_CheckExist()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_ContryMaster_CheckExist";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@ContryId_V", objPC.ContryId);
            objCmd.Parameters.AddWithValue("@ContryName_V", objPC.ContryName);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public int SP_ContryMaster_Insert_Update_Delete()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_ContryMaster_Insert_Update_Delete";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@ContryId_V", objPC.ContryId);
            objCmd.Parameters.AddWithValue("@ContryName_V", objPC.ContryName);
            objCmd.Parameters.AddWithValue("@UserId_V", objPC.UserId);
            objCmd.Parameters.AddWithValue("@DeleteFlag_V", objPC.DeleteFlag);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public DataSet SP_ContryMaster_FillGrid()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_ContryMaster_FillGrid";
            objCmd.Parameters.AddWithValue("@ContryName_V", objPC.ContryName);
            objCmd.Parameters.AddWithValue("@Search_V", objPC.SearchFlag);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        //MachAddressTable
        public DataSet SP_MacAddressTable_CheckExist()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_MacAddressTable_CheckExist";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@ID_V", objPC.MacAddressTableID);
            objCmd.Parameters.AddWithValue("@MachinName_V", objPC.ComputerName);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public int SP_MacAddressTable_Insert_Update_Delete()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_MacAddressTable_Insert_Update_Delete";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@ID_V", objPC.MacAddressTableID);
            objCmd.Parameters.AddWithValue("@MachinName_V", objPC.ComputerName);
            objCmd.Parameters.AddWithValue("@UserId_V", objPC.UserId);
            objCmd.Parameters.AddWithValue("@DeleteFlag_V", objPC.DeleteFlag);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public DataSet SP_MacAddressTable_FillGrid()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_MacAddressTable_FillGrid";
            objCmd.Parameters.AddWithValue("@MachinName_V", objPC.ComputerName);
            objCmd.Parameters.AddWithValue("@Search_V", objPC.SearchFlag);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        //Job Profile Master: Yashwant
        public DataSet SP_JobProfileMaster_CheckExist()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_JobProfileMaster_CheckExist";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@JobProfileId_V", objPC.JobProfileId);
            objCmd.Parameters.AddWithValue("@JobProfile_V", objPC.JobProfile);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public int SP_JobProfileMaster_Insert_Update_Delete()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_JobProfileMaster_Insert_Update_Delete";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@JobProfileId_V", objPC.JobProfileId);
            objCmd.Parameters.AddWithValue("@JobProfile_V", objPC.JobProfile);
            objCmd.Parameters.AddWithValue("@JobProfileFileName_V", objPC.JobProfileFileName);
            objCmd.Parameters.AddWithValue("@UserId_V", objPC.UserId);
            objCmd.Parameters.AddWithValue("@DeleteFlag_V", objPC.DeleteFlag);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public DataSet SP_JobProfileMaster_FillGrid()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_JobProfileMaster_FillGrid";
            objCmd.Parameters.AddWithValue("@JobProfile_V", objPC.JobProfile);
            objCmd.Parameters.AddWithValue("@Search_V", objPC.SearchFlag);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }


        //Memo Tmplate Master: Yashwant
        public DataSet SP_MemoTemplateMaster_CheckExist()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_MemoTemplateMaster_CheckExist";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@MemoTemplateMasterId_V", objPC.MemoTemplateMasterId);
            objCmd.Parameters.AddWithValue("@MemoSubject_V", objPC.MemoSubject);
            objCmd.Parameters.AddWithValue("@LetterType_V", objPC.LetterType);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public int SP_MemoTemplateMaster_Insert_Update_Delete()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_MemoTemplateMaster_Insert_Update_Delete";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@MemoTemplateMasterId_V", objPC.MemoTemplateMasterId);
            objCmd.Parameters.AddWithValue("@MemoSubject_V", objPC.MemoSubject);
            objCmd.Parameters.AddWithValue("@MemoTemplate_V", objPC.MemoTemplate);
            objCmd.Parameters.AddWithValue("@LetterType_V", objPC.LetterType);
            objCmd.Parameters.AddWithValue("@UserId_V", objPC.UserId);
            objCmd.Parameters.AddWithValue("@DeleteFlag_V", objPC.DeleteFlag);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public DataSet SP_MemoTemplateMaster_FillGrid()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_MemoTemplateMaster_FillGrid";
            objCmd.Parameters.AddWithValue("@MemoSubject_V", objPC.MemoSubject);
            objCmd.Parameters.AddWithValue("@LetterType_V", objPC.LetterType);
            objCmd.Parameters.AddWithValue("@Search_V", objPC.SearchFlag);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        //Memo Tmplate Master: Yashwant

        ////Overloading complile time error
        //public int GetSalary(int DID)
        //{
        //    return 40000;
        //}

        //public string GetSalary(int DID)
        //{
        //    return "50000";
        //}

        public DataSet SP_Memo_CheckExist()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_Memo_CheckExist";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@MemoId_V", objPC.MemoId);
            objCmd.Parameters.AddWithValue("@MemoTemplateMasterId_V", objPC.MemoTemplateMasterId);
            objCmd.Parameters.AddWithValue("@LetterType_V", objPC.LetterType);
            objCmd.Parameters.AddWithValue("EmployeeId_V", objPC.EmployeeId);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public int SP_Memo_Insert_Update_Delete()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_Memo_Insert_Update_Delete";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@MemoId_V", objPC.MemoId);
            objCmd.Parameters.AddWithValue("@EntryDate_V", objPC.EntryDate);
            objCmd.Parameters.AddWithValue("@EntryTime_V", objPC.EntryTime);
            objCmd.Parameters.AddWithValue("@LocationId_V", objPC.LocationId);
            objCmd.Parameters.AddWithValue("@DepartmentId_V", objPC.DepartmentId);
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.Parameters.AddWithValue("@MemoTemplateMasterId_V", objPC.MemoTemplateMasterId);
            objCmd.Parameters.AddWithValue("@LetterType_V", objPC.LetterType);
            objCmd.Parameters.AddWithValue("@MemoFine_V", objPC.MemoFine);
            objCmd.Parameters.AddWithValue("@LetterData_V", objPC.LetterData);
            objCmd.Parameters.AddWithValue("@UserId_V", objPC.UserId);
            objCmd.Parameters.AddWithValue("@DeleteFlag_V", objPC.DeleteFlag);
            objCmd.Parameters.AddWithValue("@FinancialYearId_V", objPC.FinancialYearId);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public DataSet SP_Memo_FillGrid()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_Memo_FillGrid";
            objCmd.Parameters.AddWithValue("@EmployeeName_V", objPC.EmployeeName);
            objCmd.Parameters.AddWithValue("@Search_V", objPC.SearchFlag);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        //State Master
        public DataSet SP_StateMaster_CheckExist()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_StateMaster_CheckExist";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@ContryId_V", objPC.ContryId);
            objCmd.Parameters.AddWithValue("@StateId_V", objPC.StateId);
            objCmd.Parameters.AddWithValue("@StateName_V", objPC.StateName);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public int SP_StateMaster_Insert_Update_Delete()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_StateMaster_Insert_Update_Delete";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@StateId_V", objPC.StateId);
            objCmd.Parameters.AddWithValue("@ContryId_V", objPC.ContryId);
            objCmd.Parameters.AddWithValue("@StateName_V", objPC.StateName);
            objCmd.Parameters.AddWithValue("@UserId_V", objPC.UserId);
            objCmd.Parameters.AddWithValue("@DeleteFlag_V", objPC.DeleteFlag);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public DataSet SP_StateMaster_FillGrid()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_StateMaster_FillGrid";
            objCmd.Parameters.AddWithValue("@StateName_V", objPC.StateName);
            objCmd.Parameters.AddWithValue("@Search_V", objPC.SearchFlag);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        //District Master

        public DataSet SP_DistrictMaster_CheckExist()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_DistrictMaster_CheckExist";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@DistrictId_V", objPC.DistrictId);
            objCmd.Parameters.AddWithValue("@ContryId_V", objPC.ContryId);
            objCmd.Parameters.AddWithValue("@StateId_V", objPC.StateId);
            objCmd.Parameters.AddWithValue("@DistrictName_V", objPC.DistrictName);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public int SP_DistrictMaster_Insert_Update_Delete()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_DistrictMaster_Insert_Update_Delete";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@DistrictId_V", objPC.DistrictId);
            objCmd.Parameters.AddWithValue("@ContryId_V", objPC.ContryId);
            objCmd.Parameters.AddWithValue("@StateId_V", objPC.StateId);
            objCmd.Parameters.AddWithValue("@DistrictName_V", objPC.DistrictName);
            objCmd.Parameters.AddWithValue("@UserId_V", objPC.UserId);
            objCmd.Parameters.AddWithValue("@DeleteFlag_V", objPC.DeleteFlag);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public DataSet SP_DistrictMaster_FillGrid()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_DistrictMaster_FillGrid";
            objCmd.Parameters.AddWithValue("@DistrictName_V", objPC.DistrictName);
            objCmd.Parameters.AddWithValue("@Search_V", objPC.SearchFlag);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        //Taluka Master
        public DataSet SP_TalukaMaster_CheckExist()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_TalukaMaster_CheckExist";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@TalukaId_V", objPC.TalukaId);
            objCmd.Parameters.AddWithValue("@DistrictId_V", objPC.DistrictId);
            objCmd.Parameters.AddWithValue("@ContryId_V", objPC.ContryId);
            objCmd.Parameters.AddWithValue("@StateId_V", objPC.StateId);
            objCmd.Parameters.AddWithValue("@TalukaName_V", objPC.TalukaName);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public int SP_TalukaMaster_Insert_Update_Delete()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_TalukaMaster_Insert_Update_Delete";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@TalukaId_V", objPC.TalukaId);
            objCmd.Parameters.AddWithValue("@DistrictId_V", objPC.DistrictId);
            objCmd.Parameters.AddWithValue("@ContryId_V", objPC.ContryId);
            objCmd.Parameters.AddWithValue("@StateId_V", objPC.StateId);
            objCmd.Parameters.AddWithValue("@TalukaNameName_V", objPC.TalukaName);
            objCmd.Parameters.AddWithValue("@UserId_V", objPC.UserId);
            objCmd.Parameters.AddWithValue("@DeleteFlag_V", objPC.DeleteFlag);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public DataSet SP_TalukaMaster_FillGrid()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_TalukaMaster_FillGrid";
            objCmd.Parameters.AddWithValue("@TalukaName_V", objPC.TalukaName);
            objCmd.Parameters.AddWithValue("@Search_V", objPC.SearchFlag);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        //City Village Master
        public DataSet SP_CityVillageMaster_CheckExist()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_CityVillageMaster_CheckExist";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@CityVillageId_V", objPC.CityVillageId);
            objCmd.Parameters.AddWithValue("@ContryId_V", objPC.ContryId);
            objCmd.Parameters.AddWithValue("@StateId_V", objPC.StateId);
            objCmd.Parameters.AddWithValue("@DistrictId_V", objPC.DistrictId);
            objCmd.Parameters.AddWithValue("@TalukaId_V", objPC.TalukaId);
            objCmd.Parameters.AddWithValue("@CityVillageName_V", objPC.CityVillageName);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public int SP_CityVillageMaster_Insert_Update_Delete()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_CityVillageMaster_Insert_Update_Delete";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@CityVillageId_V", objPC.CityVillageId);
            objCmd.Parameters.AddWithValue("@ContryId_V", objPC.ContryId);
            objCmd.Parameters.AddWithValue("@StateId_V", objPC.StateId);
            objCmd.Parameters.AddWithValue("@DistrictId_V", objPC.DistrictId);
            objCmd.Parameters.AddWithValue("@TalukaId_V", objPC.TalukaId);
            objCmd.Parameters.AddWithValue("@CityVillageName_V", objPC.CityVillageName);
            objCmd.Parameters.AddWithValue("@Pincode_V", objPC.Pincode);
            objCmd.Parameters.AddWithValue("@UserId_V", objPC.UserId);
            objCmd.Parameters.AddWithValue("@DeleteFlag_V", objPC.DeleteFlag);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public DataSet SP_CityVillageMaster_FillGrid()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_CityVillageMaster_FillGrid";
            objCmd.Parameters.AddWithValue("@CityVillageName_V", objPC.CityVillageName);
            objCmd.Parameters.AddWithValue("@Search_V", objPC.SearchFlag);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        //Manpower

        public int SP_Manpower_Insert_Update_Delete()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_Manpower_Insert_Update_Delete";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@ManpowerId_V", objPC.ManpowerId);
            objCmd.Parameters.AddWithValue("@EntryDate_V", objPC.EntryDate);
            objCmd.Parameters.AddWithValue("@LocationId_V", objPC.LocationId);
            objCmd.Parameters.AddWithValue("@DepartmentId_V", objPC.DepartmentId);
            objCmd.Parameters.AddWithValue("@InchargeId_V", objPC.InchargeId);
            objCmd.Parameters.AddWithValue("@DateOfRequisition_V", objPC.DateOfRequisition);
            objCmd.Parameters.AddWithValue("@ExpectedDate_V", objPC.ExpectedDate);
            objCmd.Parameters.AddWithValue("@ReasonOfRequest_V", objPC.ReasonOfRequest);
            objCmd.Parameters.AddWithValue("@Remarks_V", objPC.Remarks);
            objCmd.Parameters.AddWithValue("@Status_V", objPC.Status);
            objCmd.Parameters.AddWithValue("@Reply_V", objPC.Reply);
            objCmd.Parameters.AddWithValue("@UserId_V", BusinessLayer.EmployeeLoginId_Static);
            objCmd.Parameters.AddWithValue("@DeleteFlag_V", objPC.DeleteFlag);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public DataSet SP_Manpower_FillGrid()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_Manpower_FillGrid";
            objCmd.Parameters.AddWithValue("@ReasonOfRequest_V", objPC.ReasonOfRequest);
            objCmd.Parameters.AddWithValue("@Search_V", objPC.SearchFlag);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        //Manpower Requirements
        public int SP_ManpowerRequirements_Save()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_ManpowerRequirements_Save";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@ManpowerId_V", objPC.ManpowerId);
            objCmd.Parameters.AddWithValue("@DesignationId_V", objPC.DesignationId);
            objCmd.Parameters.AddWithValue("@NoOfCandidates_V", objPC.NoOfCandidates);
            objCmd.Parameters.AddWithValue("@Skill_V", objPC.Skill);
            objCmd.Parameters.AddWithValue("@Gender_V", objPC.Gender);
            objCmd.Parameters.AddWithValue("@UserId_V", BusinessLayer.EmployeeLoginId_Static);
            objCmd.Parameters.AddWithValue("@FinancialYearId_V", objPC.FinancialYearId);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public DataSet SP_ManpowerRequirements_FillGrid()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_ManpowerRequirements_FillGrid";
            objCmd.Parameters.AddWithValue("@ManpowerId_V", objPC.ManpowerId);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        

        //Area Master
        public DataSet SP_AreaMaster_CheckExist()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_AreaMaster_CheckExist";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@AreaId_V", objPC.AreaId);
            objCmd.Parameters.AddWithValue("@ContryId_V", objPC.ContryId);
            objCmd.Parameters.AddWithValue("@StateId_V", objPC.StateId);
            objCmd.Parameters.AddWithValue("@DistrictId_V", objPC.DistrictId);
            objCmd.Parameters.AddWithValue("@TalukaId_V", objPC.TalukaId);
            objCmd.Parameters.AddWithValue("@CityVillageId_V", objPC.CityVillageId);
            objCmd.Parameters.AddWithValue("@AreaName_V", objPC.AreaName);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public int SP_AreaMaster_Insert_Update_Delete()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_AreaMaster_Insert_Update_Delete";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@AreaId_V", objPC.AreaId);
            objCmd.Parameters.AddWithValue("@ContryId_V", objPC.ContryId);
            objCmd.Parameters.AddWithValue("@StateId_V", objPC.StateId);
            objCmd.Parameters.AddWithValue("@DistrictId_V", objPC.DistrictId);
            objCmd.Parameters.AddWithValue("@TalukaId_V", objPC.TalukaId);
            objCmd.Parameters.AddWithValue("@CityVillageId_V", objPC.CityVillageId);
            objCmd.Parameters.AddWithValue("@AreaName_V", objPC.AreaName);
            objCmd.Parameters.AddWithValue("@UserId_V", objPC.UserId);
            objCmd.Parameters.AddWithValue("@DeleteFlag_V", objPC.DeleteFlag);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public DataSet SP_AreaMaster_FillGrid()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_AreaMaster_FillGrid";
            objCmd.Parameters.AddWithValue("@AreaName_V", objPC.AreaName);
            objCmd.Parameters.AddWithValue("@Search_V", objPC.SearchFlag);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }


        //Comp of Master
        public DataSet SP_CompOffApplication_CheckExist()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_CompOffApplication_CheckExist";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@CompOffApplicationId_V", objPC.CompOffApplicationId);
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.Parameters.AddWithValue("@LeaveTypeId_V", objPC.LeaveTypeId);
            objCmd.Parameters.AddWithValue("@CompOffDate_V", objPC.CompOffDate);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public int SP_CompOffApplication_Insert_Update_Delete()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_CompOffApplication_Insert_Update_Delete";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@CompOffApplicationId_V", objPC.CompOffApplicationId);
            objCmd.Parameters.AddWithValue("@EntryDate_V", objPC.EntryDate);
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.Parameters.AddWithValue("@LeaveTypeId_V", objPC.LeaveTypeId);
            objCmd.Parameters.AddWithValue("@CompOffDate_V", objPC.CompOffDate);
            objCmd.Parameters.AddWithValue("@CompOffDay_V", objPC.CompOffDay);
            objCmd.Parameters.AddWithValue("@HolidayType_V", objPC.HolidayType);
            objCmd.Parameters.AddWithValue("@Festival_V", objPC.Festival);
            objCmd.Parameters.AddWithValue("@CompOffReason_V", objPC.CompOffReason);
            objCmd.Parameters.AddWithValue("@WorkRemarks_V", objPC.WorkRemarks);
            objCmd.Parameters.AddWithValue("@CompOffUsedFlag_V", objPC.CompOffUsedFlag);
            objCmd.Parameters.AddWithValue("@CompStatus_V", objPC.CompStatus);
            objCmd.Parameters.AddWithValue("@CompOffDueDate_V", objPC.CompOffDueDate);
            objCmd.Parameters.AddWithValue("@UserId_V", objPC.UserId);
            objCmd.Parameters.AddWithValue("@DeleteFlag_V", objPC.DeleteFlag);
            objCmd.Parameters.AddWithValue("@FinancialYearId_V", objPC.FinancialYearId);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public DataSet SP_CompOffApplication_FillGrid()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_CompOffApplication_FillGrid";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@UserType_V", BusinessLayer.UserType);
            objCmd.Parameters.AddWithValue("@UserId_V", BusinessLayer.EmployeeLoginId_Static);
            objCmd.Parameters.AddWithValue("@LocationId_V", BusinessLayer.LocationId);
            objCmd.Parameters.AddWithValue("@DepartmentId_V", BusinessLayer.DepartmentId);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        //Document Master
        public DataSet SP_DocumentMaster_CheckExist()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_DocumentMaster_CheckExist";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@DocumentId_V", objPC.DocumentId);
            objCmd.Parameters.AddWithValue("@FormId_V", objPC.FormId);
            objCmd.Parameters.AddWithValue("@DocumentName_V", objPC.DocumentName);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public int SP_DocumentMaster_Insert_Update_Delete()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_DocumentMaster_Insert_Update_Delete";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@DocumentId_V", objPC.DocumentId);
            objCmd.Parameters.AddWithValue("@FormId_V", objPC.FormId);
            objCmd.Parameters.AddWithValue("@DocumentName_V", objPC.DocumentName);
            objCmd.Parameters.AddWithValue("@UserId_V", objPC.UserId);
            objCmd.Parameters.AddWithValue("@DeleteFlag_V", objPC.DeleteFlag);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public DataSet SP_DocumentMaster_FillGrid()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_DocumentMaster_FillGrid";
            objCmd.Parameters.AddWithValue("@DocumentName_V", objPC.DocumentName);
            objCmd.Parameters.AddWithValue("@Search_V", objPC.SearchFlag);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        //Categories

        public DataSet SP_Categories_CheckExist()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_Categories_CheckExist";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@CategoryId_V", objPC.CategoryId);
            objCmd.Parameters.AddWithValue("@CategoryFName_V", objPC.CategoryFName);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public int SP_CategoriesNew_Insert_Update_Delete()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_CategoriesNew_Insert_Update_Delete";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@CategoryId_V", objPC.CategoryId);
            objCmd.Parameters.AddWithValue("@CategoryFName_V", objPC.CategoryFName);
            objCmd.Parameters.AddWithValue("@CategorySName_V", objPC.CategorySName);
            objCmd.Parameters.AddWithValue("@OTFormula_V", objPC.OTFormula);
            objCmd.Parameters.AddWithValue("@MinOT_V", objPC.MinOT);
            objCmd.Parameters.AddWithValue("@MaxOT_V", objPC.MaxOT);
            objCmd.Parameters.AddWithValue("@MaxOTMin_V", objPC.MaxOTMin);
            objCmd.Parameters.AddWithValue("@ConsiderOnlyFirstAndLastPunchInAttCalculations_V", objPC.ConsiderOnlyFirstAndLastPunchInAttCalculations);
            objCmd.Parameters.AddWithValue("@GraceTimeForLateComingMins_V", objPC.GraceTimeForLateComingMins);
            objCmd.Parameters.AddWithValue("@NeglectLastInPunchForMissedOutPunch_V", objPC.NeglectLastInPunchForMissedOutPunch);
            objCmd.Parameters.AddWithValue("@GraceTimeForEarlyGoingMins_V", objPC.GraceTimeForEarlyGoingMins);
            objCmd.Parameters.AddWithValue("@WeeklyOff1_V", objPC.WeeklyOff1);
            objCmd.Parameters.AddWithValue("@WeeklyOff1Value_V", objPC.WeeklyOff1Value);
            objCmd.Parameters.AddWithValue("@WeeklyOff2_V", objPC.WeeklyOff2);
            objCmd.Parameters.AddWithValue("@WeeklyOff2Value_V", objPC.WeeklyOff2Value);
            objCmd.Parameters.AddWithValue("@1st_V", objPC.FirstR);
            objCmd.Parameters.AddWithValue("@2nd_V", objPC.SecondR);
            objCmd.Parameters.AddWithValue("@3rd_V", objPC.ThirdR);
            objCmd.Parameters.AddWithValue("@4th_V", objPC.ForthR);
            objCmd.Parameters.AddWithValue("@5th_V", objPC.FiveR);
            objCmd.Parameters.AddWithValue("@ConsiderEarlyComingPunch_V", objPC.ConsiderEarlyComingPunch);
            objCmd.Parameters.AddWithValue("@ConsiderLateGoingPunch_V", objPC.ConsiderLateGoingPunch);
            objCmd.Parameters.AddWithValue("@DeductBreakHoursFormWorkDuration_V", objPC.DeductBreakHoursFormWorkDuration);
            objCmd.Parameters.AddWithValue("@CalculateHalfDayifWorkDurationIsLessThan_V", objPC.CalculateHalfDayifWorkDurationIsLessThan);
            objCmd.Parameters.AddWithValue("@CalculateHalfDayifWorkDurationIsLessThanMins_V", objPC.CalculateHalfDayifWorkDurationIsLessThanMins);
            objCmd.Parameters.AddWithValue("@CalculationAbsentIfWorkDurationIsLessThan_V", objPC.CalculationAbsentIfWorkDurationIsLessThan);
            objCmd.Parameters.AddWithValue("@CalculationAbsentIfWorkDurationIsLessThanMins_V", objPC.CalculationAbsentIfWorkDurationIsLessThanMins);
            objCmd.Parameters.AddWithValue("@OnPartialDayCalculateHalfDayifWorkDurationisLessThan_V", objPC.OnPartialDayCalculateHalfDayifWorkDurationisLessThan);
            objCmd.Parameters.AddWithValue("@OnPartialDayCalculateHalfDayifWorkDurationisLessThanMins_V", objPC.OnPartialDayCalculateHalfDayifWorkDurationisLessThanMins);
            objCmd.Parameters.AddWithValue("@OnPartialDayCalculateAbsentDayifWorkDurationislessThan_V", objPC.OnPartialDayCalculateAbsentDayifWorkDurationislessThan);
            objCmd.Parameters.AddWithValue("@OnPartialDayCalculateAbsentDayifWorkDurationislessThanMins_V", objPC.OnPartialDayCalculateAbsentDayifWorkDurationislessThanMins);
            objCmd.Parameters.AddWithValue("@MarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent_V", objPC.MarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent);
            objCmd.Parameters.AddWithValue("@MarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent_V", objPC.MarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent);
            objCmd.Parameters.AddWithValue("@MWOHAbsentifBothPrefixandSuffixDayisAbsent_V", objPC.MWOHAbsentifBothPrefixandSuffixDayisAbsent);
            objCmd.Parameters.AddWithValue("@Mark_V", objPC.Mark);
            objCmd.Parameters.AddWithValue("@MarkValue_V", objPC.MarkValue);
            objCmd.Parameters.AddWithValue("@AbsentWhenLateForValue_V", objPC.AbsentWhenLateForValue);
            objCmd.Parameters.AddWithValue("@MarkHalfDayifLateBy_V", objPC.MarkHalfDayifLateBy);
            objCmd.Parameters.AddWithValue("@MarkHalfDayifLateByMins_V", objPC.MarkHalfDayifLateByMins);
            objCmd.Parameters.AddWithValue("@MarkHalfDayifEarlyGoingBy_V", objPC.MarkHalfDayifEarlyGoingBy);
            objCmd.Parameters.AddWithValue("@MarkHalfDayifEarlyGoingByMins_V", objPC.MarkHalfDayifEarlyGoingByMins);
            objCmd.Parameters.AddWithValue("@UserId_V", objPC.UserId);
            objCmd.Parameters.AddWithValue("@DeleteFlag_V", objPC.DeleteFlag);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public DataSet SP_Categories_FillGrid()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_Categories_FillGrid";
            objCmd.Parameters.AddWithValue("@CategoryFName_V", objPC.CategoryFName);
            objCmd.Parameters.AddWithValue("@Search_V", objPC.SearchFlag);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_Categories_By_CategoryId()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_Categories_By_CategoryId";
            objCmd.Parameters.AddWithValue("@CategoryId_V", objPC.CategoryId);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }


        public int SP_Get_Pincode_By_CityVillageId()
        {
            int Pincode = 0;
            DataSet ds = new DataSet();
            string returnValue = string.Empty;
            objBL.Connect();
            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_Get_Pincode_By_CityVillageId";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@AreaId_V", objPC.AreaId.ToString()); 
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Pincode"].ToString())))
                    Pincode = Convert.ToInt32(ds.Tables[0].Rows[0]["Pincode"].ToString());
            }
            return Pincode;
        }

        //Company Profile Master

        public DataSet SP_CompanyProfile_FillGrid()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_CompanyProfile_FillGrid";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public int SP_CompanyProfile_Insert_Update_Delete()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_CompanyProfile_Insert_Update_Delete";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@CompanyId_V", objPC.CompanyId);
            objCmd.Parameters.AddWithValue("@CompanyName_V", objPC.CompanyName);
            objCmd.Parameters.AddWithValue("@RegisteredAddress_V", objPC.RegisteredAddress);
            objCmd.Parameters.AddWithValue("@UnitsAddressDetails_V", objPC.UnitsAddressDetails);
            objCmd.Parameters.AddWithValue("@AreaId_V", objPC.AreaId);
            objCmd.Parameters.AddWithValue("@EmailId_V", objPC.EmailId);
            objCmd.Parameters.AddWithValue("@Website_V", objPC.Website);
            objCmd.Parameters.AddWithValue("@ContactNumber_V", objPC.ContactNumber);
            objCmd.Parameters.AddWithValue("@EstablishmentDate_V", objPC.EstablishmentDate);
            objCmd.Parameters.AddWithValue("@DateOfIncorporation_V", objPC.DateOfIncorporation);
            objCmd.Parameters.AddWithValue("@RegistrationNumber_V", objPC.RegistrationNumber);
            objCmd.Parameters.AddWithValue("@FactoryLicenseNumber_V", objPC.FactoryLicenseNumber);
            objCmd.Parameters.AddWithValue("@UdyogAadharNumber_V", objPC.UdyogAadharNumber);
            objCmd.Parameters.AddWithValue("@FSSAINo_V", objPC.FSSAINo);
            objCmd.Parameters.AddWithValue("@GSTIN_V", objPC.GSTIN);
            objCmd.Parameters.AddWithValue("@PANNo_V", objPC.PANNo);
            objCmd.Parameters.AddWithValue("@TANNo_V", objPC.TANNo);
            objCmd.Parameters.AddWithValue("@PFEstablishmentID_V", objPC.PFEstablishmentID);
            objCmd.Parameters.AddWithValue("@ESICEstablishmentID_V", objPC.ESICEstablishmentID);
            objCmd.Parameters.AddWithValue("@PTRCNo_V", objPC.PTRCNo);
            objCmd.Parameters.AddWithValue("@PTECNo_V", objPC.PTECNo);
            objCmd.Parameters.AddWithValue("@LWFNo_V", objPC.LWFNo);
            objCmd.Parameters.AddWithValue("@LabourLicenseRegNo_V", objPC.LabourLicenseRegNo);
            objCmd.Parameters.AddWithValue("@LabourLicenseDate_V", objPC.LabourLicenseDate);
            objCmd.Parameters.AddWithValue("@TotalEmployeeAsPerLicense_V", objPC.TotalEmployeeAsPerLicense);
            objCmd.Parameters.AddWithValue("@BRCRegNo_V", objPC.BRCRegNo);
            objCmd.Parameters.AddWithValue("@BRCRegisteredDate_V", objPC.BRCRegisteredDate);
            objCmd.Parameters.AddWithValue("@ISORegNo_V", objPC.ISORegNo);
            objCmd.Parameters.AddWithValue("@ISORegisteredDate_V", objPC.ISORegisteredDate);
            objCmd.Parameters.AddWithValue("@BankName_V", objPC.BankName);
            objCmd.Parameters.AddWithValue("@AccountNo_V", objPC.AccountNo);
            objCmd.Parameters.AddWithValue("@BranchName_V", objPC.BranchName);
            objCmd.Parameters.AddWithValue("@MICRNo_V", objPC.MICRNo);
            objCmd.Parameters.AddWithValue("@IFSCCode_V", objPC.IFSCCode);
            objCmd.Parameters.AddWithValue("@UserId_V", objPC.UserId);
            objCmd.Parameters.AddWithValue("@DeleteFlag_V", objPC.DeleteFlag);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        //Contractor Master


        public DataSet SP_ContractorMaster_FillGrid()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_ContractorMaster_FillGrid";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public int SP_ContractorMaster_Insert_Update_Delete()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_ContractorMaster_Insert_Update_Delete";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@ContractorId_V", objPC.ContractorId);
            objCmd.Parameters.AddWithValue("@RegisterNo_V", objPC.RegisterNo);
            objCmd.Parameters.AddWithValue("@VendorNumber_V", objPC.VendorNumber);
            objCmd.Parameters.AddWithValue("@ContractorName_V", objPC.ContractorName);
            objCmd.Parameters.AddWithValue("@Address_V", objPC.Address);
            objCmd.Parameters.AddWithValue("@AreaId_V", objPC.AreaId);
            objCmd.Parameters.AddWithValue("@ProprietorName_V", objPC.ProprietorName);
            objCmd.Parameters.AddWithValue("@MobileNumber_V", objPC.MobileNumber);
            objCmd.Parameters.AddWithValue("@EmailId_V", objPC.EmailId);
            objCmd.Parameters.AddWithValue("@JoiningDate_V", objPC.JoiningDate);
            objCmd.Parameters.AddWithValue("@GSTIN_V", objPC.GSTIN);
            objCmd.Parameters.AddWithValue("@PFEstablishmentID_V", objPC.PFEstablishmentID);
            objCmd.Parameters.AddWithValue("@ESICEstablishmentID_V", objPC.ESICEstablishmentID);
            objCmd.Parameters.AddWithValue("@LWFNo_V", objPC.LWFNo);
            objCmd.Parameters.AddWithValue("@PTRCNo_V", objPC.PTRCNo);
            objCmd.Parameters.AddWithValue("@PTECNo_V", objPC.PTECNo);
            objCmd.Parameters.AddWithValue("@ContractRenewalDate_V", objPC.ContractRenewalDate);
            objCmd.Parameters.AddWithValue("@LabourLicenseNo_V", objPC.LabourLicenseNo);
            objCmd.Parameters.AddWithValue("@TotalEmployeeAsPerLicense_V", objPC.TotalEmployeeAsPerLicense);
            objCmd.Parameters.AddWithValue("@UdyogAadharNo_V", objPC.UdyogAadharNo);
            objCmd.Parameters.AddWithValue("@AadharNo_V", objPC.AadharNo);
            objCmd.Parameters.AddWithValue("@PANCardNumber_V", objPC.PANCardNumber);
            objCmd.Parameters.AddWithValue("@PaymentMode_V", objPC.PaymentMode);
            objCmd.Parameters.AddWithValue("@BankName_V", objPC.BankName);
            objCmd.Parameters.AddWithValue("@AccountNo_V", objPC.AccountNo);
            objCmd.Parameters.AddWithValue("@BranchName_V", objPC.BranchName);
            objCmd.Parameters.AddWithValue("@MICRNo_V", objPC.MICRNo);
            objCmd.Parameters.AddWithValue("@IFSCCode_V", objPC.IFSCCode);
            objCmd.Parameters.AddWithValue("@UserId_V", objPC.UserId);
            objCmd.Parameters.AddWithValue("@DeleteFlag_V", objPC.DeleteFlag);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        //Department Master

        public DataSet SP_DepartmentMaster_FillGrid()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_DepartmentMaster_FillGrid";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@LocationId_V", objPC.LocationId);
            objCmd.Parameters.AddWithValue("@Department_V", objPC.Department);
            objCmd.Parameters.AddWithValue("@Search_V", objPC.SearchFlag);
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        //SP_HolidayMaster_FillGrid


        public DataSet SP_ShiftGroupMaster_FillGrid()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_ShiftGroupMaster_FillGrid";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@ShiftGroupFName_V", objPC.ShiftFName);
            objCmd.Parameters.AddWithValue("@Search_V", objPC.SearchFlag);
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_Shift_by_ShiftGroupId()
        {
            //SELECT BeginTime FROM shifts where CancelTag=0 ORDER BY ABS(time(BeginTime) - time('22:3')) LIMIT 1;
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_Shift_by_ShiftGroupId";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@ShiftGroupId_V", objPC.ShiftGroupId);
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            //Get_Auto_Shift_Details(ds);
            objBL.objCon.Close();
            return ds;
        }

        public int SP_ShiftGroups_Insert_Update_Delete()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_ShiftGroups_Insert_Update_Delete";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@ShiftGroupId_V", objPC.ShiftGroupId);
            objCmd.Parameters.AddWithValue("@ShiftGroupFName_V", objPC.ShiftFName);
            objCmd.Parameters.AddWithValue("@ShiftGroupSName_V", objPC.ShiftSName);
            objCmd.Parameters.AddWithValue("@UserId_V", objPC.UserId);
            objCmd.Parameters.AddWithValue("@DeleteFlag_V", objPC.DeleteFlag);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        //ShiftGroupsShifts

        public int SP_ShiftGroupShifts_Insert_Update_Delete()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_ShiftGroupShifts_Insert_Update_Delete";
            objCmd.Connection = objBL.objCon;
            //objCmd.Parameters.AddWithValue("@ShiftGroupShiftId_V", objPC.ShiftGroupShiftId);
            objCmd.Parameters.AddWithValue("@ShiftGroupId_V", objPC.ShiftGroupId);
            objCmd.Parameters.AddWithValue("@ShiftId_V", objPC.ShiftId);
            objCmd.Parameters.AddWithValue("@UserId_V", objPC.UserId); 
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public int SP_ShiftGroupShifts_Delete()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_ShiftGroupShifts_Delete";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@ShiftGroupId_V", objPC.ShiftGroupId);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public int SP_ShiftGroupShifts_Delete_All()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_ShiftGroupShifts_Delete_All";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@ShiftGroupId_V", objPC.ShiftGroupId);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }
      
        public DataSet SP_ShiftGroupShifts_FillGrid()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_ShiftGroupShifts_FillGrid";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@ShiftGroupFName_V", objPC.ShiftFName);
            objCmd.Parameters.AddWithValue("@SearchFlag_V", objPC.SearchFlag);
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_ShiftGroupShifts_FillGrid_ShiftName()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_ShiftGroupShifts_FillGrid_ShiftName";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@ShiftGroupId_V", objPC.ShiftGroupId);
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        //LocationWiseDepartment

        public int SP_LocationWiseDepartment_Insert_Update_Delete()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_LocationWiseDepartment_Insert_Update_Delete";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@LocationId_V", objPC.LocationId);
            objCmd.Parameters.AddWithValue("@DepartmentId_V", objPC.DepartmentId);
            objCmd.Parameters.AddWithValue("@UserId_V", objPC.UserId);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public int SP_LocationWiseDepartment_Delete()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_LocationWiseDepartment_Delete";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@LocationId_V", objPC.LocationId);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public int SP_LocationWiseDepartment_Delete_All()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_LocationWiseDepartment_Delete_All";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@LocationId_V", objPC.LocationId);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public DataSet SP_LocationWiseDepartment_FillGrid()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_LocationWiseDepartment_FillGrid";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@LocationName_V", objPC.LocationName);
            objCmd.Parameters.AddWithValue("@SearchFlag_V", objPC.SearchFlag);
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_LocationWiseDepartment_FillGrid_ShiftName()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_LocationWiseDepartment_FillGrid_ShiftName";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@LocationId_V", objPC.LocationId);
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_LocationWiseDepartment_FillGrid_DepartmentName()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_LocationWiseDepartment_FillGrid_DepartmentName";
            objCmd.CommandType = CommandType.StoredProcedure;

            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@LocationId_V", objPC.LocationId);
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_LocationWiseDepartment_Get_Department_By_LocationId()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_LocationWiseDepartment_Get_Department_By_LocationId";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@LocationId_V", objPC.LocationId);
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        //SP_LocationWiseDepartment_Get_Department_By_LocationId

        public int SP_DepartmentMaster_Insert_Update_Delete()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_DepartmentMaster_Insert_Update_Delete";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@DepartmentId_V", objPC.DepartmentId);
            objCmd.Parameters.AddWithValue("@Department_V", objPC.Department);
            objCmd.Parameters.AddWithValue("@InchargeName_V", objPC.InchargeName);
            objCmd.Parameters.AddWithValue("@ContactPerson_V", objPC.ContactPerson);
            objCmd.Parameters.AddWithValue("@MobileNumber_V", objPC.MobileNumber);
            objCmd.Parameters.AddWithValue("@EmailId_V", objPC.EmailId);
            objCmd.Parameters.AddWithValue("@ExtensionNo_V", objPC.ExtensionNo);
            objCmd.Parameters.AddWithValue("@Description_V", objPC.Description);
            objCmd.Parameters.AddWithValue("@UserId_V", objPC.UserId);
            objCmd.Parameters.AddWithValue("@DeleteFlag_V", objPC.DeleteFlag);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        //Holiday Master

        public int SP_HolidayMaster_Insert_Update_Delete()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_HolidayMaster_Insert_Update_Delete";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@HolidayId_V", objPC.HolidayId);
            objCmd.Parameters.AddWithValue("@HolidayDate_V", objPC.HolidayDate);
            objCmd.Parameters.AddWithValue("@HolidayDay_V", objPC.HolidayDay);
            objCmd.Parameters.AddWithValue("@Festival_V", objPC.Festival);
            objCmd.Parameters.AddWithValue("@NationalHolidayFlag_V", objPC.NationalHolidayFlag);
            objCmd.Parameters.AddWithValue("@HolidayType_V", objPC.HolidayType);
            objCmd.Parameters.AddWithValue("@UserId_V", objPC.UserId);
            objCmd.Parameters.AddWithValue("@DeleteFlag_V", objPC.DeleteFlag);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public DataSet SP_HolidayMaster_FillGrid()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_HolidayMaster_FillGrid";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@Festival_V", objPC.Festival);
            objCmd.Parameters.AddWithValue("@Search_V", objPC.SearchFlag);
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_HolidayMaster_CheckExist()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_HolidayMaster_CheckExist";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@HolidayId_V", objPC.HolidayId);
            objCmd.Parameters.AddWithValue("@HolidayDate_V", objPC.HolidayDate);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }


        //

        //Designation Master
         
        public DataSet SP_DesignationMaster_CheckExist()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_DesignationMaster_CheckExist";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@DesignationId_V", objPC.DesignationId);
            objCmd.Parameters.AddWithValue("@Designation_V", objPC.Designation);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public int SP_DesignationMaster_Insert_Update_Delete()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_DesignationMaster_Insert_Update_Delete";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@DesignationId_V", objPC.DesignationId);
            objCmd.Parameters.AddWithValue("@Designation_V", objPC.Designation);
            objCmd.Parameters.AddWithValue("@Grade_V", objPC.Grade);
            objCmd.Parameters.AddWithValue("@DesignationCategory_V", objPC.DesignationCategory);
            objCmd.Parameters.AddWithValue("@Leaves_V", objPC.LeaveCountDesignation);
            objCmd.Parameters.AddWithValue("@OvertimeFlag_V", objPC.OTApplicable);
            objCmd.Parameters.AddWithValue("@UserId_V", objPC.UserId);
            objCmd.Parameters.AddWithValue("@DeleteFlag_V", objPC.DeleteFlag);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public DataSet SP_DesignationMaster_FillGrid()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_DesignationMaster_FillGrid";
            objCmd.Parameters.AddWithValue("@Designation_V", objPC.Designation);
            objCmd.Parameters.AddWithValue("@Search_V", objPC.SearchFlag);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public int SP_TempDepartmentWiseDesignationAttendanceReport_Insert()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_TempDepartmentWiseDesignationAttendanceReport_Insert";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@TempDepartmentWiseDesignationAttendanceReportId_V", objPC.TempDepartmentWiseDesignationAttendanceReportId);
            objCmd.Parameters.AddWithValue("@ReportType_V", objPC.ReportType);
            objCmd.Parameters.AddWithValue("@FromDate_V", objPC.FromDate);
            objCmd.Parameters.AddWithValue("@ToDate_V", objPC.ToDate);
            objCmd.Parameters.AddWithValue("@AMonth_V", objPC.AMonth);
            objCmd.Parameters.AddWithValue("@AYear_V", objPC.AYear);
            objCmd.Parameters.AddWithValue("@DepartmentId_V", objPC.DepartmentId);
            objCmd.Parameters.AddWithValue("@DesignationId_V", objPC.DesignationId);
            objCmd.Parameters.AddWithValue("@Total_V",Convert.ToInt32(objPC.TotalPresent));
            objCmd.Parameters.AddWithValue("@UserId_V", BusinessLayer.EmployeeLoginId_Static);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public DataSet SP_TempDepartmentWiseDesignationAttendanceReport_Report()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_TempDepartmentWiseDesignationAttendanceReport_Report";
            objCmd.Parameters.AddWithValue("@ReportType_V", objPC.ReportType);
            objCmd.Parameters.AddWithValue("@FromDate_V", objPC.FromDate);
            objCmd.Parameters.AddWithValue("@ToDate_V", objPC.ToDate);
            objCmd.Parameters.AddWithValue("@AMonth_V", objPC.AMonth);
            objCmd.Parameters.AddWithValue("@AYear_V", objPC.AYear);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }
        
        // Employee Master
        public int SP_Employees_Profile_Insert_Update_Delete()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_Employees_Profile_Insert_Update_Delete";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.Parameters.AddWithValue("@EmployeeCode_V", objPC.EmployeeCodeInDevice);
            objCmd.Parameters.AddWithValue("@EmpInital_V", objPC.EmpInital);
            objCmd.Parameters.AddWithValue("@EmployeeName_V", objPC.EmployeeName);
            objCmd.Parameters.AddWithValue("@Gender_V", objPC.Gender);
            objCmd.Parameters.AddWithValue("@DOB_V", objPC.DOB);
            objCmd.Parameters.AddWithValue("@Age_V", objPC.Age);
            objCmd.Parameters.AddWithValue("@MaritalStatus_V", objPC.MaritalStatus);
            objCmd.Parameters.AddWithValue("@MarriageDate_V", objPC.MarriageDate);
            objCmd.Parameters.AddWithValue("@PersonalEmailID_V", objPC.PersonalEmailID);
            objCmd.Parameters.AddWithValue("@MobileNo_V", objPC.MobileNo);
            objCmd.Parameters.AddWithValue("@OfficialEmailID_V", objPC.OfficialEmailID);
            objCmd.Parameters.AddWithValue("@BloodGroup_V", objPC.BloodGroup);
            objCmd.Parameters.AddWithValue("@AadharCardNumber_V", objPC.AadharCardNumber);
            objCmd.Parameters.AddWithValue("@PanCardNumber_V", objPC.PANCardNumber);
            objCmd.Parameters.AddWithValue("@FatherName_V", objPC.FatherName);
            objCmd.Parameters.AddWithValue("@MotherName_V", objPC.MotherName);
            objCmd.Parameters.AddWithValue("@DrivingLicenseNumber_V", objPC.DrivingLicenseNumber);
            objCmd.Parameters.AddWithValue("@PersonalIdentificationMark_V", objPC.PersonalIdentificationMark);
            objCmd.Parameters.AddWithValue("@PhysicalDisability_V", objPC.PhysicalDisability);
            objCmd.Parameters.AddWithValue("@DescriptionOfPhysicalDisability_V", objPC.DescriptionOfPhysicalDisability);
            objCmd.Parameters.AddWithValue("@DOJ_V", objPC.DOJ);
            objCmd.Parameters.AddWithValue("@TotalYearsService_V", objPC.TotalYearsService);
            objCmd.Parameters.AddWithValue("@ContractorId_V", objPC.ContractorId);
            objCmd.Parameters.AddWithValue("@EmployementTypeId_V", objPC.EmployementTypeId);
            objCmd.Parameters.AddWithValue("@DepartmentId_V", objPC.DepartmentId);
            objCmd.Parameters.AddWithValue("@DesignationId_V", objPC.DesignationId);
            objCmd.Parameters.AddWithValue("@JobProfile_V", objPC.JobProfile);
            objCmd.Parameters.AddWithValue("@CategoryId_V", objPC.CategoryId);
            objCmd.Parameters.AddWithValue("@LocationId_V", objPC.LocationId);
            objCmd.Parameters.AddWithValue("@ShiftGroupId_V", objPC.ShiftGroupId);
            objCmd.Parameters.AddWithValue("@Status_V", objPC.Status);
            objCmd.Parameters.AddWithValue("@OverTimeApplicable_V", objPC.OverTimeApplicable);
            objCmd.Parameters.AddWithValue("@FlexibleHoursFlag_V", objPC.FlexibleHoursFlag);
            objCmd.Parameters.AddWithValue("@DateOfExit_V", objPC.DateOfExit);
            objCmd.Parameters.AddWithValue("@UserId_V", BusinessLayer.LoginId_Static);
            objCmd.Parameters.AddWithValue("@FinancialYearId_V", objPC.FinancialYearId);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public int SP_Employees_Delete()
        {
            int ReturnResult = 0;
            objBL.Connect();
            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_Employees_Delete";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.Parameters.AddWithValue("@UserId_V", BusinessLayer.LoginId_Static);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public int SP_Employees_Contact_Update()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_Employees_Contact_Update";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.Parameters.AddWithValue("@Nationality_V", objPC.Nationality);
            objCmd.Parameters.AddWithValue("@Address_V", objPC.Address);
            objCmd.Parameters.AddWithValue("@AreaId_V", objPC.AreaId);
            objCmd.Parameters.AddWithValue("@PoliceStationId_V", objPC.PoliceStationId);
            objCmd.Parameters.AddWithValue("@SameAsPA_V", objPC.SameAsPA);
            objCmd.Parameters.AddWithValue("@Address1_V", objPC.Address1);
            objCmd.Parameters.AddWithValue("@AreaId1_V", objPC.AreaId1);
            objCmd.Parameters.AddWithValue("@PoliceStationId1_V", objPC.PoliceStationId1);
            objCmd.Parameters.AddWithValue("@UserId_V", BusinessLayer.LoginId_Static);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public int SP_EmployeeFamily_Save_Update()
        {
            int ReturnResult = 0;
            objBL.Connect();
            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_EmployeeFamily_Save_Update";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@EmployeeFamilyId_V", objPC.EmployeeFamilyId);
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.Parameters.AddWithValue("@MemberName_V", objPC.MemberName);
            objCmd.Parameters.AddWithValue("@Relationship_V", objPC.Relationship);
            objCmd.Parameters.AddWithValue("@Gender_V", objPC.FamilyGender);
            objCmd.Parameters.AddWithValue("@DOB_V", objPC.MemberDOB);
            objCmd.Parameters.AddWithValue("@IsResidingWith_V", objPC.IsResidingWith);
            objCmd.Parameters.AddWithValue("@DependentOnYou_V", objPC.IsDependentOnYou);
            objCmd.Parameters.AddWithValue("@PANCard_V", objPC.MemberPANCard);
            objCmd.Parameters.AddWithValue("@AadharCard_V", objPC.MemberAadharCard);
            objCmd.Parameters.AddWithValue("@ContactNo_V", objPC.MemberContactNo);
            objCmd.Parameters.AddWithValue("@IsPrimaryNominee_V", objPC.IsPrimaryNominee);
            objCmd.Parameters.AddWithValue("@DeleteFlag_V", objPC.DeleteFlag);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public int SP_EmployeeQualification_Save_Update()
        {
            int ReturnResult = 0;
            objBL.Connect();
            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_EmployeeQualification_Save_Update";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@EmployeeQualificationId_V", objPC.EmployeeQualificationId);
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.Parameters.AddWithValue("@Qualification_V", objPC.Qualification);
            objCmd.Parameters.AddWithValue("@Stream_V", objPC.Stream);
            objCmd.Parameters.AddWithValue("@College_V", objPC.College);
            objCmd.Parameters.AddWithValue("@University_V", objPC.University);
            objCmd.Parameters.AddWithValue("@YearOfPassing_V", objPC.YearOfPassing);
            objCmd.Parameters.AddWithValue("@Grade_V", objPC.GradeQualification);
            objCmd.Parameters.AddWithValue("@UserId_V", BusinessLayer.LoginId_Static);
            objCmd.Parameters.AddWithValue("@DeleteFlag_V", objPC.DeleteFlag);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public int SP_EmployeeFamily_Delete()
        {
            int ReturnResult = 0;
            objBL.Connect();
            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_EmployeeFamily_Delete";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@EmployeeFamilyId_V", objPC.EmployeeFamilyId);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }
 
        public int SP_EmployeeExperience_Save_Update()
        {
            int ReturnResult = 0;
            objBL.Connect();
            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_EmployeeExperience_Save_Update";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@EmployeeExperienceId_V", objPC.EmployeeExperienceId);
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.Parameters.AddWithValue("@OrganizationName_V", objPC.OrganizationNameExperience);
            objCmd.Parameters.AddWithValue("@OrganizationAddress_V", objPC.OrganizationAddressExperience);
            objCmd.Parameters.AddWithValue("@StartDate_V", objPC.StartDate);
            objCmd.Parameters.AddWithValue("@EndDate_V", objPC.EndDate);
            objCmd.Parameters.AddWithValue("@Designation_V", objPC.DesignationExperience);
            objCmd.Parameters.AddWithValue("@GrossSalaryPE_V", objPC.GrossSalaryPreviousExperience);
            objCmd.Parameters.AddWithValue("@UserId_V", BusinessLayer.LoginId_Static);
            objCmd.Parameters.AddWithValue("@DeleteFlag_V", objPC.DeleteFlag);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public int SP_Employees_Nominee_Emergancy_Update()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_Employees_Nominee_Emergancy_Update";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.Parameters.AddWithValue("@NomineeName_V", objPC.NomineeName);
            objCmd.Parameters.AddWithValue("@NomineeRelationship_V", objPC.NomineeRelationship);
            objCmd.Parameters.AddWithValue("@NomineeAddress_V", objPC.NomineeAddress);
            objCmd.Parameters.AddWithValue("@NomineeDOB_V", objPC.NomineeDOB);
            objCmd.Parameters.AddWithValue("@NomineeContactNo_V", objPC.NomineeContactNo);
            objCmd.Parameters.AddWithValue("@NomineeFor_V", objPC.NomineeFor);
            objCmd.Parameters.AddWithValue("@NomineeBankName_V", objPC.NomineeBankName);
            objCmd.Parameters.AddWithValue("@NomineeAccountNo_V", objPC.NomineeAccountNo);
            objCmd.Parameters.AddWithValue("@NomineeIFSCCode_V", objPC.NomineeIFSCCode);
            objCmd.Parameters.AddWithValue("@NomineeMICRCode_V", objPC.NomineeMICRCode);
            objCmd.Parameters.AddWithValue("@EmergancyContactName_V", objPC.EmergancyContactName);
            objCmd.Parameters.AddWithValue("@EmergancyContactMobileNumber_V", objPC.EmergancyContactMobileNumber);
            objCmd.Parameters.AddWithValue("@EmergancyContactWorkPhone_V", objPC.EmergancyContactWorkPhone);
            objCmd.Parameters.AddWithValue("@EmergancyContactRelationship_V", objPC.EmergancyContactRelationship);
            objCmd.Parameters.AddWithValue("@EmergancyContactHomePhone_V", objPC.EmergancyContactHomePhone);
            objCmd.Parameters.AddWithValue("@UserId_V", BusinessLayer.LoginId_Static);

            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public int SP_Employees_Qualification_Education_Update()
        {
            int ReturnResult = 0;
            objBL.Connect();

            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_Employees_Qualification_Education_Update";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.Parameters.AddWithValue("@QualificationEducation_V", objPC.QualificationEducation);
            objCmd.Parameters.AddWithValue("@QualificationSpeciazation_V", objPC.QualificationSpeciazation);
            objCmd.Parameters.AddWithValue("@QualificationStartDate_V", objPC.QualificationStartDate);
            objCmd.Parameters.AddWithValue("@QualificationEndDate_V", objPC.QualificationEndDate);
            objCmd.Parameters.AddWithValue("@QualificationScoreClass_V", objPC.QualificationScoreClass);
            objCmd.Parameters.AddWithValue("@QualificationYear_V", objPC.QualificationYear);
            objCmd.Parameters.AddWithValue("@QualificationRemarks_V", objPC.QualificationRemarks);
            objCmd.Parameters.AddWithValue("@ExperienceEmployer_V", objPC.ExperienceEmployer);
            objCmd.Parameters.AddWithValue("@ExperienceBranch_V", objPC.ExperienceBranch);
            objCmd.Parameters.AddWithValue("@ExperienceLocation_V", objPC.ExperienceLocation);
            objCmd.Parameters.AddWithValue("@ExperienceDesignation_V", objPC.ExperienceDesignation);
            objCmd.Parameters.AddWithValue("@ExperienceCTC_V", objPC.ExperienceCTC);
            objCmd.Parameters.AddWithValue("@ExperienceGrossSalary_V", objPC.ExperienceGrossSalary);
            objCmd.Parameters.AddWithValue("@ExperienceStartDate_V", objPC.ExperienceStartDate);
            objCmd.Parameters.AddWithValue("@ExperienceEndDate_V", objPC.ExperienceEndDate);
            objCmd.Parameters.AddWithValue("@ExperienceManager_V", objPC.ExperienceManager);
            objCmd.Parameters.AddWithValue("@ExperienceManagerContactNo_V", objPC.ExperienceManagerContactNo);
            objCmd.Parameters.AddWithValue("@ExperienceIndustryType_V", objPC.ExperienceIndustryType);
            objCmd.Parameters.AddWithValue("@ExperienceRemarks_V", objPC.ExperienceRemarks);

            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public int SP_Employees_Skill_Update()
        {
            int ReturnResult = 0;
            objBL.Connect();
            
            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_Employees_Skill_Update";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.Parameters.AddWithValue("@SkillLanguage_V", objPC.SkillLanguage);
            objCmd.Parameters.AddWithValue("@SkillFluency_V", objPC.SkillFluency);
            objCmd.Parameters.AddWithValue("@SkillAbilityWrite_V", objPC.SkillAbilityWrite);
            objCmd.Parameters.AddWithValue("@SkillAbilityRead_V", objPC.SkillAbilityRead);
            objCmd.Parameters.AddWithValue("@SkillAbilitySpeak_V", objPC.SkillAbilitySpeak);
            objCmd.Parameters.AddWithValue("@SkillAbilityUnderstand_V", objPC.SkillAbilityUnderstand);
            objCmd.Parameters.AddWithValue("@SkillType_V", objPC.SkillType);
            objCmd.Parameters.AddWithValue("@UserId_V", BusinessLayer.LoginId_Static);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public int SP_EmployeeSkill_Save_Update()
        {
            int ReturnResult = 0;
            objBL.Connect();
            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_EmployeeSkill_Save_Update";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@EmployeeSkillId_V", objPC.EmployeeSkillId);
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.Parameters.AddWithValue("@Skills_V", objPC.Skills);
            objCmd.Parameters.AddWithValue("@YearsOfExperience_V", objPC.YearsOfExperience);
            objCmd.Parameters.AddWithValue("@Comments_V", objPC.Comments);
            objCmd.Parameters.AddWithValue("@UserId_V", BusinessLayer.LoginId_Static);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public int SP_EmployeeSkill_Delete()
        {
            int ReturnResult = 0;
            objBL.Connect();
            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_EmployeeSkill_Delete";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@EmployeeSkillId_V", objPC.EmployeeSkillId);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public DataSet SP_EmployeeSkill_Grid()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_EmployeeSkill_Grid";
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public int SP_Employees_Salary_Update()
        {
            int ReturnResult = 0;
            objBL.Connect();
            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_Employees_Salary_Update";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.Parameters.AddWithValue("@CostCenter_V", objPC.CostCenter);
            objCmd.Parameters.AddWithValue("@SalaryMonthlyBasic_V", objPC.SalaryMonthlyBasic);
            objCmd.Parameters.AddWithValue("@SalaryMonthlyHRA_V", objPC.SalaryMonthlyHRA);
            objCmd.Parameters.AddWithValue("@SalaryMonthlyEducationAllowance_V", objPC.SalaryMonthlyEducationAllowance);
            objCmd.Parameters.AddWithValue("@SalaryMonthlyConveyanceAllowance_V", objPC.SalaryMonthlyConveyanceAllowance);
            objCmd.Parameters.AddWithValue("@SalaryMonthlyOtherAllowance_V", objPC.SalaryMonthlyOtherAllowance);
            objCmd.Parameters.AddWithValue("@SalaryMonthlyGrossSalary_V", objPC.SalaryMonthlyGrossSalary);
            objCmd.Parameters.AddWithValue("@SalaryMonthlyTaxDeducted_V", objPC.SalaryMonthlyTaxDeducted);
            objCmd.Parameters.AddWithValue("@SalaryMonthlyProvidentFund_V", objPC.SalaryMonthlyProvidentFund);
            objCmd.Parameters.AddWithValue("@SalaryMonthlyNetSalary_V", objPC.SalaryMonthlyNetSalary);
            objCmd.Parameters.AddWithValue("@SalaryAnualBasic_V", objPC.SalaryAnualBasic);
            objCmd.Parameters.AddWithValue("@SalaryAnualHRA_V", objPC.SalaryAnualHRA);
            objCmd.Parameters.AddWithValue("@SalaryAnualEducationAllowance_V", objPC.SalaryAnualEducationAllowance);
            objCmd.Parameters.AddWithValue("@SalaryAnualConveyanceAllowance_V", objPC.SalaryAnualConveyanceAllowance);
            objCmd.Parameters.AddWithValue("@SalaryAnualOtherAllowance_V", objPC.SalaryAnualOtherAllowance);
            objCmd.Parameters.AddWithValue("@SalaryAnualGrossSalary_V", objPC.SalaryAnualGrossSalary);
            objCmd.Parameters.AddWithValue("@SalaryAnualTaxDeducted_V", objPC.SalaryAnualTaxDeducted);
            objCmd.Parameters.AddWithValue("@SalaryAnualProvidentFund_V", objPC.SalaryAnualProvidentFund);
            objCmd.Parameters.AddWithValue("@SalaryAnualNetSalary_V", objPC.SalaryAnualNetSalary);
            objCmd.Parameters.AddWithValue("@SalaryPaymentMode_V", objPC.SalaryPaymentMode);
            objCmd.Parameters.AddWithValue("@SalaryBank_V", objPC.SalaryBank);
            objCmd.Parameters.AddWithValue("@SalaryAccountNo_V", objPC.SalaryAccountNo);
            objCmd.Parameters.AddWithValue("@SalaryBranchName_V", objPC.SalaryBranchName);
            objCmd.Parameters.AddWithValue("@SalaryMICRNo_V", objPC.SalaryMICRNo);
            objCmd.Parameters.AddWithValue("@SalaryIFSCCode_V", objPC.SalaryIFSCCode);
            objCmd.Parameters.AddWithValue("@SalaryPaymentMode1_V", objPC.SalaryPaymentMode1);
            objCmd.Parameters.AddWithValue("@SalaryBank1_V", objPC.SalaryBank1);
            objCmd.Parameters.AddWithValue("@SalaryAccountNo1_V", objPC.SalaryAccountNo1);
            objCmd.Parameters.AddWithValue("@SalaryBranchName1_V", objPC.SalaryBranchName1);
            objCmd.Parameters.AddWithValue("@SalaryMICRNo1_V", objPC.SalaryMICRNo1);
            objCmd.Parameters.AddWithValue("@SalaryIFSCCode1_V", objPC.SalaryIFSCCode1);
            objCmd.Parameters.AddWithValue("@UserId_V", BusinessLayer.LoginId_Static);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public int SP_Employee_PF_Update()
        {
            int ReturnResult = 0;
            objBL.Connect();
            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_Employee_PF_Update";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.Parameters.AddWithValue("@PFMemberIDNo_V", objPC.PFMemberIDNo);
            objCmd.Parameters.AddWithValue("@UANNumber_V", objPC.UANNumber);
            objCmd.Parameters.AddWithValue("@ESICNo_V", objPC.ESICNo);
            objCmd.Parameters.AddWithValue("@LWFLINNo_V", objPC.LWFLINNo);
            objCmd.Parameters.AddWithValue("@PassportType_V", objPC.PassportType);
            objCmd.Parameters.AddWithValue("@PassportNo_V", objPC.PassportNo);
            objCmd.Parameters.AddWithValue("@IssuesDate_V", objPC.IssuesDate);
            objCmd.Parameters.AddWithValue("@RenewalDate_V", objPC.RenewalDate);
            objCmd.Parameters.AddWithValue("@DateOfExpiry_V", objPC.DateOfExpiry);
            objCmd.Parameters.AddWithValue("@Citizenship_V", objPC.Citizenship);
            objCmd.Parameters.AddWithValue("@DateOfJoining_V", objPC.DateOfJoining);
            objCmd.Parameters.AddWithValue("@ConfirmDate_V", objPC.ConfirmDate);
            objCmd.Parameters.AddWithValue("@PFStartDate_V", objPC.PFStartDate);
            objCmd.Parameters.AddWithValue("@DateOfRetirement_V", objPC.DateOfRetirement);
            objCmd.Parameters.AddWithValue("@DateOfExit_V", objPC.DateOfExit);
            objCmd.Parameters.AddWithValue("@A1_V", objPC.A1);
            objCmd.Parameters.AddWithValue("@A2_V", objPC.A2);
            objCmd.Parameters.AddWithValue("@A3_V", objPC.A3);
            objCmd.Parameters.AddWithValue("@UserId_V", BusinessLayer.LoginId_Static);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        //Opening Leave

        public DataSet SP_Employees_OpeningLeave_Grid()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_Employees_OpeningLeave_Grid";
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public int SP_Employees_OpeningLeave_Update()
        {
            int ReturnResult = 0;
            objBL.Connect();
            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_Employees_OpeningLeave_Update";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.Parameters.AddWithValue("@OpeningLeave_V", objPC.OpeningLeave);
            objCmd.Parameters.AddWithValue("@BalanceLeave_V", objPC.BalanceLeave);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public DataSet SP_EmployeeFamily_Select_By_EmployeeId()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_EmployeeFamily_Select_By_EmployeeId";
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;  
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_EmployeeQualification_Select_By_EmployeeId()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_EmployeeQualification_Select_By_EmployeeId";
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_EmployeeExperience_Select_By_EmployeeId()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_EmployeeExperience_Select_By_EmployeeId";
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_Employees_FillGrid()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_Employees_FillGrid";
            objCmd.Parameters.AddWithValue("@EmployeeName_V", objPC.EmployeeName);
            objCmd.Parameters.AddWithValue("@Search_V", objPC.SearchFlag);
            objCmd.Parameters.AddWithValue("@NewFlag_V", objPC.NewFlag);
            objCmd.Parameters.AddWithValue("@EmployeeCode_V", objPC.EmployeeCode);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;  
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_Employees_By_EmployeeId()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_Employees_By_EmployeeId";
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;  
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

       

        public DataSet SP_AreaMaster_FillGrid_by_AreaId(int AID)
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_AreaMaster_FillGrid_by_AreaId";
            objCmd.Parameters.AddWithValue("@AreaId_V", AID);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        //Shift
        public int SP_Shifts_Insert_Update_Delete()
        {
            int ReturnResult = 0;
            objBL.Connect();
            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_Shifts_Insert_Update_Delete";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@ShiftId_V", objPC.ShiftId);
            objCmd.Parameters.AddWithValue("@ShiftFName_V", objPC.ShiftFName);
            objCmd.Parameters.AddWithValue("@ShiftSName_V", objPC.ShiftSName);
            objCmd.Parameters.AddWithValue("@BeginTime_V", objPC.BeginTime);
            objCmd.Parameters.AddWithValue("@EndTime_V", objPC.EndTime);
            objCmd.Parameters.AddWithValue("@Break1_V", objPC.Break1);
            objCmd.Parameters.AddWithValue("@Break2_V", objPC.Break2);
            objCmd.Parameters.AddWithValue("@Break1BeginTime_V", objPC.Break1BeginTime);
            objCmd.Parameters.AddWithValue("@Break2BeginTime_V", objPC.Break2BeginTime);
            objCmd.Parameters.AddWithValue("@Break1EndTime_V", objPC.Break1EndTime);
            objCmd.Parameters.AddWithValue("@Break2EndTime_V", objPC.Break2EndTime);
            objCmd.Parameters.AddWithValue("@Break1Duration_V", objPC.Break1Duration);
            objCmd.Parameters.AddWithValue("@Break2Duration_V", objPC.Break2Duration);
            objCmd.Parameters.AddWithValue("@ShiftDuration_V", objPC.ShiftDuration);
            objCmd.Parameters.AddWithValue("@ShiftType_V", objPC.ShiftType);
            objCmd.Parameters.AddWithValue("@RecordStatus_V", objPC.RecordStatus);
            objCmd.Parameters.AddWithValue("@PunchBeginDuration_V", objPC.PunchBeginDuration);
            objCmd.Parameters.AddWithValue("@PunchEndDuration_V", objPC.PunchEndDuration);
            objCmd.Parameters.AddWithValue("@IsGraceTimeApplicable_V", objPC.IsGraceTimeApplicable);
            objCmd.Parameters.AddWithValue("@GraceTime_V", objPC.GraceTime);
            objCmd.Parameters.AddWithValue("@IsPartialDayApplicable_V", objPC.IsPartialDayApplicable);
            objCmd.Parameters.AddWithValue("@PartialDay_V", objPC.PartialDay);
            objCmd.Parameters.AddWithValue("@PartialDayBeginTime_V", objPC.PartialDayBeginTime);
            objCmd.Parameters.AddWithValue("@PartialDayEndTime_V", objPC.PartialDayEndTime);
            objCmd.Parameters.AddWithValue("@IsFlexibleShift_V", objPC.IsFlexibleShift);
            objCmd.Parameters.AddWithValue("@ShiftDurationHours_V", objPC.ShiftDurationHours);
            objCmd.Parameters.AddWithValue("@UserId_V", BusinessLayer.LoginId_Static);
            objCmd.Parameters.AddWithValue("@DeleteFlag_V", objPC.DeleteFlag); 
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public int SP_Shifts_Delete()
        {
            int ReturnResult = 0;
            objBL.Connect();
            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_Shifts_Delete";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@ShiftId_V", objPC.ShiftId);
            objCmd.Parameters.AddWithValue("@UserId_V", BusinessLayer.LoginId_Static);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public DataSet SP_Shifts_FillGrid()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_Shifts_FillGrid";
            objCmd.Parameters.AddWithValue("@ShiftFName_V", objPC.ShiftFName);
            objCmd.Parameters.AddWithValue("@Search_V", objPC.SearchFlag);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon; 
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_Shifts_FillGrid_ById(int ShiftId)
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_Shifts_FillGrid_ById";
            objCmd.Parameters.AddWithValue("@ShiftId_V", ShiftId);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        //Leave Application
        public int SP_LeaveApplication_Insert_Update_Delete()
        {
            int ReturnResult = 0;
            objBL.Connect();
            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_LeaveApplication_Insert_Update_Delete";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@LeaveApplicationId_V", objPC.LeaveApplicationId);
            objCmd.Parameters.AddWithValue("@EntryDate_V", objPC.EntryDate);
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.Parameters.AddWithValue("@FromDate_V", objPC.FromDate);
            objCmd.Parameters.AddWithValue("@ToDate_V", objPC.ToDate);
            objCmd.Parameters.AddWithValue("@TotalDays_V", objPC.TotalDays);
            objCmd.Parameters.AddWithValue("@LeaveTypeId_V", objPC.LeaveTypeId);
            objCmd.Parameters.AddWithValue("@LeaveReason_V", objPC.LeaveReason);
            objCmd.Parameters.AddWithValue("@LeaveStatus_V", objPC.LeaveStatus);
            objCmd.Parameters.AddWithValue("@Remarks_V", objPC.Remarks);
            objCmd.Parameters.AddWithValue("@IsRevertLeave_V", objPC.IsRevertLeave);
            objCmd.Parameters.AddWithValue("@UserId_V", BusinessLayer.LoginId_Static);
            objCmd.Parameters.AddWithValue("@DeleteFlag_V", objPC.DeleteFlag);
            objCmd.Parameters.AddWithValue("@FinancialYearId_V", objPC.FinancialYearId);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public DataSet SP_LeaveApplication_FillGrid()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_LeaveApplication_FillGrid";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            //objCmd.Parameters.AddWithValue("@UserType_V", BusinessLayer.UserType);
            objCmd.Parameters.AddWithValue("@UserType_V", BusinessLayer.UserType);
            objCmd.Parameters.AddWithValue("@UserId_V", BusinessLayer.EmployeeLoginId_Static);
            objCmd.Parameters.AddWithValue("@LocationId_V", BusinessLayer.LocationId);
            objCmd.Parameters.AddWithValue("@DepartmentId_V", BusinessLayer.DepartmentId);
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_LeaveApplication_FillGrid_CompOff()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_LeaveApplication_FillGrid_CompOff";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            //objCmd.Parameters.AddWithValue("@LeaveTypeId_V", objPC.LeaveTypeId);
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_LeaveApplication_By_EmployeeId()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_LeaveApplication_By_EmployeeId";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;

            //if (objPC.EmployeeId == 37)
            //{
            //    MessageBox.Show("Found");
            //}
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.Parameters.AddWithValue("@CheckDate_V", objPC.AttendanceDate);
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        

        public DataSet SP_LeaveApplication_Count()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_LeaveApplication_Count";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@UserType_V", BusinessLayer.UserType);
            objCmd.Parameters.AddWithValue("@LocationId_V", BusinessLayer.LocationId);
            objCmd.Parameters.AddWithValue("@DepartmentId_V", BusinessLayer.DepartmentId);
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public int SP_AttendanceRecordMaster_Count_Pending_Complete_Remark(string ATS)
        {
            int Count=0;
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_AttendanceRecordMaster_Count_Pending_Complete_Remark";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@LocationId_V", BusinessLayer.LocationId);
            objCmd.Parameters.AddWithValue("@DepartmentId_V", BusinessLayer.DepartmentId);
            objCmd.Parameters.AddWithValue("@Status_V", ATS);
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][0])))
                    Count = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            objBL.objCon.Close();
            return Count;
        }

        public DataSet SP_LeaveApplication_CheckExist()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_LeaveApplication_CheckExist";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@LeaveApplicationId_V", objPC.LeaveApplicationId);
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.Parameters.AddWithValue("@FromDate_V", objPC.FromDate);
            objCmd.Parameters.AddWithValue("@ToDate_V", objPC.ToDate); 
            //objCmd.Parameters.AddWithValue("@LeaveStatus_V", objPC.LeaveStatus); 
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_LeaveApplication_Get_Leave_Count_By_EmployeeId()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_LeaveApplication_Get_Leave_Count_By_EmployeeId";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.Parameters.AddWithValue("@LeaveStatus_V", objPC.LeaveStatus);
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_Employees_ComboBox_By_Department(ComboBox cmb)
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_Employees_ComboBox_By_Department";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@DepartmentId_V", objPC.DepartmentId);
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "Employee Name";
                cmb.ValueMember = "EmployeeId";
                cmb.SelectedIndex = -1;
            }
            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_Employees_ComboBox_By_DepartmentId_LocationId(ComboBox cmb)
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_Employees_ComboBox_By_DepartmentId_LocationId";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@LocationId_V", objPC.LocationId);
            objCmd.Parameters.AddWithValue("@DepartmentId_V", objPC.DepartmentId);
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "Employee Name";
                cmb.ValueMember = "EmployeeId";
                cmb.SelectedIndex = -1;
            }
            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_Employees_ComboBox_By_DepartmentId_LocationId_Without_Login(ComboBox cmb)
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_Employees_ComboBox_By_DepartmentId_LocationId_Without_Login";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@LocationId_V", objPC.LocationId);
            objCmd.Parameters.AddWithValue("@DepartmentId_V", objPC.DepartmentId);
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "Employee Name";
                cmb.ValueMember = "EmployeeId";
                cmb.SelectedIndex = -1;
            }
            objBL.objCon.Close();
            return ds;
        }


        public DataSet SP_Employees_ComboBox_By_LocationId_UserType(CheckedListBox clb)
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_Employees_ComboBox_By_LocationId_UserType";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@LocationId_V", objPC.LocationId);
            objCmd.Parameters.AddWithValue("@UserType_V", objPC.UserType);
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                clb.DataSource = ds.Tables[0];
                clb.DisplayMember = "Employee Name";
                clb.ValueMember = "EmployeeId";
            }
            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_Employees_ComboBox_By_LocationId_UserType(ComboBox cmb)
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_Employees_ComboBox_By_LocationId_UserType";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@LocationId_V", objPC.LocationId);
            objCmd.Parameters.AddWithValue("@UserType_V", objPC.UserType);
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "Employee Name";
                cmb.ValueMember = "EmployeeId";
                cmb.SelectedIndex = -1;
            }
            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_Employees_FillBy_LocationAndUserType(ComboBox cmb)
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_Employees_FillBy_LocationAndUserType";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@LocationId_V", objPC.LocationId);
            objCmd.Parameters.AddWithValue("@UserType_V", objPC.UserType);
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "Employee Name";
                cmb.ValueMember = "EmployeeId";
                cmb.SelectedIndex = -1;
            }
            objBL.objCon.Close();
            return ds;
        }

        public void SP_Employees_Get_By_All(ComboBox cmb)
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            //objCmd = new MySqlCommand();

            string WhereOther = string.Empty; string WhereOther1 = string.Empty;
            string EmpQuery = "select E.EmployeeId,E.EmployeeCode,E.EmployeeName,E.Gender,E.DepartmentId,D.Department,E.DesignationId,DM.Designation,E.CategoryId,CT.CategoryFName,E.EmployementTypeId,ETM.EmployementType,E.Status,E.LocationId,L.LocationName,E.ContractorId,CM.ContractorName,E.ShiftGroupId";
            string EmpTableName= " from Employees E	inner join LocationMaster L on L.LocationId=E.LocationId inner join departmentmaster D on D.DepartmentId=E.DepartmentId inner join designationmaster DM on DM.DesignationId=E.DesignationId inner join employementtypemaster ETM on ETM.EmployementTypeId=E.EmployementTypeId inner join contractormaster CM on CM.ContractorId=E.ContractorId inner join Categories CT on CT.CategoryId=E.CategoryId inner join shiftgroups sg on sg.ShiftGroupId=E.ShiftGroupId ";
            string EmpWhereClause = " where E.Status='WORKING' and E.CancelTag=0 and L.CancelTag=0 and D.CancelTag=0 and DM.CancelTag=0 and ETM.CancelTag=0 and CM.CancelTag=0 and CT.CancelTag=0 and sg.CancelTag=0 "; // and E.LocationId="+objPC.LocationId +" ";
 
            //SearchBy_DepartmentId	DepartmentId	
            //SearchBy_DesignationId	DesignationId	
            //SearchBy_EmployeeId	EmployeeId	
            //SearchBy_LocationId	LocationId	

            //if (SearchBy == BusinessResources.SearchBy_LocationId)
            //    WhereOther = " and E." + BusinessResources.SearchBy_LocationId + "=" + SearchValue + "";
            //else if (SearchBy == BusinessResources.SearchBy_DepartmentId)
            //    WhereOther = " and E." + BusinessResources.SearchBy_DepartmentId + "=" + SearchValue + "";
            //else if (SearchBy == BusinessResources.SearchBy_DesignationId)
            //    WhereOther = " and E." + BusinessResources.SearchBy_DesignationId + "=" + SearchValue + "";
            //else if (SearchBy == BusinessResources.SearchBy_LocationId)
            //    WhereOther = " and E." + BusinessResources.SearchBy_EmployeeId + "=" + SearchValue + "";
            //else if (SearchBy == BusinessResources.SearchBy_Designation)
            //    WhereOther = " and DM." + BusinessResources.SearchBy_Designation + "='" + SearchValue + "'";
            //else if (SearchBy == BusinessResources.SearchyBy_Department)
            //    WhereOther = " and D." + BusinessResources.SearchyBy_Department + "='" + SearchValue + "'";
            //else
            //    WhereOther = "";

            //if (!string.IsNullOrEmpty(Convert.ToString(WhereValue)))
            //    WhereOther1 = WhereClause_V; // WhereValue; // " and D." + BusinessResources.SearchyBy_Department + "='" + WhereValue + "'";

            //objBL.Query = EmpQuery + EmpTableName + EmpWhereClause + WhereClause_V + " order by E.EmployeeName ";
            objBL.Query = EmpQuery + EmpTableName + EmpWhereClause + WhereClause_V + " order by E.EmployeeName ";
            ds = objBL.ReturnDataSet();
            cmb.DataSource = null;
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "EmployeeName";
                cmb.ValueMember = "EmployeeId";
                cmb.SelectedIndex = -1;
            }

            
            //objCmd.CommandText = "SP_Employees_FillBy_LocationAndUserType";
            //objCmd.CommandType = CommandType.StoredProcedure;
            //objCmd.Connection = objBL.objCon;
            //objCmd.Parameters.AddWithValue("@LocationId_V", objPC.LocationId);
            //objCmd.Parameters.AddWithValue("@UserType_V", objPC.UserType);
            //objDA = new MySqlDataAdapter(objCmd);
            //objDA.Fill(ds);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    cmb.DataSource = ds.Tables[0];
            //    cmb.DisplayMember = "Employee Name";
            //    cmb.ValueMember = "EmployeeId";
            //    cmb.SelectedIndex = -1;
            //}
            objBL.objCon.Close();
            //return ds;
        }


        public void Fill_Location_By_EmployeeId(ComboBox cmb)
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            string LDQuery = "select distinct lm.LocationName, lwd.LocationId from locationwisedepartmentusers lwd inner join locationmaster lm on lm.LocationId=lwd.LocationId where lwd.CancelTag=0 and lm.CancelTag=0 ";
            objBL.Query = LDQuery + WhereClause_V + " order by lm.LocationName ";
            ds = objBL.ReturnDataSet();
            cmb.DataSource = null;
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "LocationName";
                cmb.ValueMember = "LocationId";
                cmb.SelectedIndex = -1;
            }
        }

        public string Get_Location_Id(string TypeOfColumn)
        {
            string ConcatId = string.Empty;
            string MainQuery = string.Empty;

            objBL.Connect();
            DataSet ds = new DataSet();

            if (TypeOfColumn == "Location")
                MainQuery = "select distinct lm.LocationName, lwd.LocationId from locationwisedepartmentusers lwd inner join locationmaster lm on lm.LocationId=lwd.LocationId where lwd.CancelTag=0 and lm.CancelTag=0 ";
            else
                MainQuery = "select distinct dm.Department, lwd.DepartmentId from locationwisedepartmentusers lwd inner join departmentmaster dm on dm.DepartmentId=lwd.DepartmentId where lwd.CancelTag=0 and dm.CancelTag=0 ";

            objBL.Query = MainQuery + WhereClause_V + " ";
            ds = objBL.ReturnDataSet();
             
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ConcatId +=  ds.Tables[0].Rows[i][1].ToString() + ",";
                }

                ConcatId = ConcatId.Remove(ConcatId.Length - 1);

                if (TypeOfColumn == "Location")
                    ConcatId = " E.LocationId IN(" + ConcatId + ")";
                else
                    ConcatId = " E.DepartmentId IN(" + ConcatId + ")";
            }

            return ConcatId;
        }

        public string Get_Location_Id_Type_Object(string TypeOfColumn,string ObjN)
        {
            string ConcatId = string.Empty;
            string MainQuery = string.Empty;

            objBL.Connect();
            DataSet ds = new DataSet();

            if (TypeOfColumn == "Location")
                MainQuery = "select distinct lm.LocationName, lwd.LocationId from locationwisedepartmentusers lwd inner join locationmaster lm on lm.LocationId=lwd.LocationId where lwd.CancelTag=0 and lm.CancelTag=0 ";
            else
                MainQuery = "select distinct dm.Department, lwd.DepartmentId from locationwisedepartmentusers lwd inner join departmentmaster dm on dm.DepartmentId=lwd.DepartmentId where lwd.CancelTag=0 and dm.CancelTag=0 ";

            objBL.Query = MainQuery + WhereClause_V + " ";
            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ConcatId += ds.Tables[0].Rows[i][1].ToString() + ",";
                }

                ConcatId = ConcatId.Remove(ConcatId.Length - 1);

                if (TypeOfColumn == "Location")
                    ConcatId = ObjN + "LocationId IN(" + ConcatId + ")";
                else
                    ConcatId = ObjN + "DepartmentId IN(" + ConcatId + ")";
            }
            return ConcatId;
        }

        public string Get_Change_LocationId_And_DepartmentId_Type_Object(string TypeOfColumn, string ObjN)
        {
            string ConcatId = string.Empty;
            string MainQuery = string.Empty;

            objBL.Connect();
            DataSet ds = new DataSet();

            if (TypeOfColumn == "Location")
                MainQuery = "select distinct lm.LocationName, lwd.LocationId from locationwisedepartmentusers lwd inner join locationmaster lm on lm.LocationId=lwd.LocationId where lwd.CancelTag=0 and lm.CancelTag=0 ";
            else
                MainQuery = "select distinct dm.Department, lwd.DepartmentId from locationwisedepartmentusers lwd inner join departmentmaster dm on dm.DepartmentId=lwd.DepartmentId where lwd.CancelTag=0 and dm.CancelTag=0 ";

            objBL.Query = MainQuery + WhereClause_V + " ";
            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ConcatId += ds.Tables[0].Rows[i][1].ToString() + ",";
                }

                ConcatId = ConcatId.Remove(ConcatId.Length - 1);

                if (TypeOfColumn == "Location")
                    ConcatId = ObjN + "ChangeLocationtId IN(" + ConcatId + ")";
                else
                    ConcatId = ObjN + "ChangeDepartmentId IN(" + ConcatId + ")";
            }

            return ConcatId;
        }

        public void Fill_Department_By_EmployeeId(ComboBox cmb)
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            string LDQuery = "select distinct dm.Department, lwd.DepartmentId from locationwisedepartmentusers lwd inner join departmentmaster dm on dm.DepartmentId=lwd.DepartmentId where lwd.CancelTag=0 and dm.CancelTag=0 ";
            objBL.Query = LDQuery + WhereClause_V + " order by dm.Department ";
            ds = objBL.ReturnDataSet();
            cmb.DataSource = null;
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "Department";
                cmb.ValueMember = "DepartmentId";
                cmb.SelectedIndex = -1;
            }
        }

        public void Fill_Department_By_LocationId(ComboBox cmb)
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            string LDQuery = "select distinct dm.Department, lwd.DepartmentId from locationwisedepartmentusers lwd inner join departmentmaster dm on dm.DepartmentId=lwd.DepartmentId where lwd.CancelTag=0 and dm.CancelTag=0 and lwd.LocationId="+objPC.LocationId+" order by dm.Department  ";
            objBL.Query = LDQuery; // +WhereClause_V + " order by dm.Department ";
            ds = objBL.ReturnDataSet();
            cmb.DataSource = null;
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "Department";
                cmb.ValueMember = "DepartmentId";
                cmb.SelectedIndex = -1;
            }
        }

        public void Fill_Department_By_EmployeeId_CheckListBox(CheckedListBox cmb)
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            string LDQuery = "select distinct dm.Department, lwd.DepartmentId from locationwisedepartmentusers lwd inner join departmentmaster dm on dm.DepartmentId=lwd.DepartmentId where lwd.CancelTag=0 and dm.CancelTag=0 ";
            objBL.Query = LDQuery + WhereClause_V + " order by dm.Department ";
            ds = objBL.ReturnDataSet();
            cmb.DataSource = null;
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "Department";
                cmb.ValueMember = "DepartmentId";
                cmb.SelectedIndex = -1;
            }
        }

        //public DataSet SP_Employees_FillBy_LocationAndUserType_DepartmentWise(ComboBox cmb)
        //{
        //    objBL.Connect();
        //    DataSet ds = new DataSet();
        //    objCmd = new MySqlCommand();
        //    objCmd.CommandText = "SP_Employees_FillBy_LocationAndUserType_DepartmentWise";
        //    objCmd.CommandType = CommandType.StoredProcedure;
        //    objCmd.Connection = objBL.objCon;
        //    objCmd.Parameters.AddWithValue("@Department_V", objPC.Department);
        //    objCmd.Parameters.AddWithValue("@UserType_V", objPC.UserType);
        //    objDA = new MySqlDataAdapter(objCmd);
        //    objDA.Fill(ds);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        cmb.DataSource = ds.Tables[0];
        //        cmb.DisplayMember = "Employee Name";
        //        cmb.ValueMember = "EmployeeId";
        //        cmb.SelectedIndex = -1;
        //    }
        //    objBL.objCon.Close();
        //    return ds;
        //}

        public int SP_LeaveApplication_Update_LeaveStatus()
        {
            int ReturnResult = 0;
            objBL.Connect();
            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_LeaveApplication_Update_LeaveStatus";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@LeaveApplicationId_V", objPC.LeaveApplicationId);
            objCmd.Parameters.AddWithValue("@LeaveStatus_V", objPC.LeaveStatus);
            objCmd.Parameters.AddWithValue("@Remarks_V", objPC.Remarks);
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.Parameters.AddWithValue("@BalanceLeave_V", objPC.BalanceLeave);
            objCmd.Parameters.AddWithValue("@UserType_V", BusinessLayer.UserType);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        //Comp off Status update

        public int SP_CompOffApplication_Update_CompStatus()
        {
            int ReturnResult = 0;
            objBL.Connect();
            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_CompOffApplication_Update_CompStatus";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@CompOffApplicationId_V", objPC.CompOffApplicationId);
            objCmd.Parameters.AddWithValue("@CompStatus_V", objPC.CompStatus);
            objCmd.Parameters.AddWithValue("@Remarks_V", objPC.Remarks);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }


        //Approval Level Master
        public int SP_ApprovalLevel_Insert_Update_Delete()
        {
            int ReturnResult = 0;
            objBL.Connect();
            objCmd = new MySqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "SP_ApprovalLevel_Insert_Update_Delete";
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@ApprovalLevelId_V", objPC.ApprovalLevelId);
            objCmd.Parameters.AddWithValue("@LocationId_V", objPC.LocationId);
            objCmd.Parameters.AddWithValue("@InchargeId_V", objPC.InchargeId);
            objCmd.Parameters.AddWithValue("@DepartmentId_V", objPC.DepartmentId_S);
            objCmd.Parameters.AddWithValue("@PlantHeadId_V", objPC.PlantHeadId);
            objCmd.Parameters.AddWithValue("@HRApprovalId_V", objPC.HRApprovalId);
            objCmd.Parameters.AddWithValue("@UserId_V", BusinessLayer.LoginId_Static);
            objCmd.Parameters.AddWithValue("@DeleteFlag_V", objPC.DeleteFlag);
            ReturnResult = objCmd.ExecuteNonQuery();
            return ReturnResult;
        }

        public DataSet SP_ApprovalLevel_FillGrid()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_ApprovalLevel_FillGrid";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@LocationName_V", objPC.LocationName);
            objCmd.Parameters.AddWithValue("@Search_V", objPC.SearchFlag);
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_LocationWiseDepartmentUsers_FillGrid()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_LocationWiseDepartmentUsers_FillGrid";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@DepartmentName_V", objPC.Department);
            objCmd.Parameters.AddWithValue("@Search_V", objPC.SearchFlag);
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        

        //Fill Department Approvl wise
        public void SP_ApprovalLevel_Get_Department_By_LocationId_InchargeId(ComboBox cmb)
        {
            //Hardcode
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_ApprovalLevel_Get_Department_By_LocationId_InchargeId";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;
            objCmd.Parameters.AddWithValue("@LocationId_V", objPC.LocationId);
            objCmd.Parameters.AddWithValue("@InchargeId_V", objPC.InchargeId);// objPC.InchargeId);
            objCmd.Parameters.AddWithValue("@SearchType_V", objPC.SearchType);
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "Department";
                cmb.ValueMember = "DepartmentId";
                cmb.SelectedIndex = -1;
            }
            objBL.objCon.Close();
        }


        private static string username;
        private static string password;
        private static string expensespassword;
        private static string fullname;
        private static string mobileno;
        private static int userid;
        private static int status;
        private static int tableid;

        private static int id;           //bigint,
        private static int designationid;//int(11), 
        private static string gender; //tinytext,
        private static DateTime dob;  //date, 
        private static int age;// 				int(11), 
        private static string bloodgroup;// 			tinytext, 
        private static string currentaddress;//		longtext,
        private static string asabove; 	//		tinytext, 
        private static string permenentaddress;// 	longtext,
        private static string mobileno1;		//	longtext, 
        private static string mobileno2;		//	longtext, 
        private static string emailid; 			//longtext, 
        private static string qualification;	//	mediumtext, 
        private static string regno;			//	mediumtext, 
        private static string speciality;		//	mediumtext, 
        private static string experience; 		//	mediumtext, 
        private static DateTime dateofjoining;	//date, 

        private static string usertype; 		//	mediumtext, 
        private static int modifieduserid;// 		int(11),
        private static int deleteflag;//			int
        private static int patientid;
        private static int balance;
        private static int commanid;// 						bigint(20), 
        private static DateTime entrydate;// 						date, 
        private static int tokennumber;
        private static string certificatename;// 				longtext, 
        private static string whomitmayconcern;// 				longtext,
        private static string thisistocertifythat;// 			longtext, 
        private static string thisistocertifythatdescription;// 	longtext, 
        private static string sonof;// 							longtext, 
        private static string sonofdescription;// 				longtext, 
        private static string aged;// 							text, 
        private static string ofplace;// 						text, 
        private static string category;// 						text, 
        private static string opdno;// 						text, 
        private static int opdid;
        private static string admitedon;// 						text, 
        private static string admitedondescription;//			text, 
        private static string dischargeon;// 					text, 
        private static string dignosis;// 						text, 
        private static string dignosisdescription;// 			text, 
        private static string certificatecaption;// 				text, 
        private static string remarks;// 						text, 
        private static DateTime datee;
        private static string broughthospitalon;

        private static string dateofinjury;
        private static string timeofinjury;
        private static string placeofinjury;
        private static string salutation;


        private static string patientname;
        private static string ipdno;
        private static string address;
        private static string contactno;

        private static DateTime doa;
        private static string refby;
        private static string diagnosis;
        private static string chiefcomplaint;
        private static string machine;
        private static string exercise;
        private static string billtype;
        private static double rate;
        private static double shootqty;
        private static string clinicaldiagnosis;
        private static string clinicalfindings;
        private static string clinicalhistory;
        private static string drugschedule;
        private static string expenseshead;
        private static string investigation;
        private static string weight;
        private static string medicinename;
        private static string medicinepipe;
        private static bool searchmedicine;
        private static string medicinetype;

        private static string dose;
        private static string drugchedule;
        private static string duration;
        private static string remark;
        private static string miscellaneousheadmain;
        private static string otrequirements;
        private static string surgery;
        private static string treatment;
        private static string patienttype;
        private static string lastname;
        private static string firstname;
        private static string middlename;
        private static string sex;
        private static string occupation;
        private static string email;
        private static string mobilenumber;
        private static string filerackno;
        private static string doctor;
        private static string documentspath;
        private static bool searchflag;
        private static string searchtext;
        private static string tablename;
        private static string query;
        private static string reportpath;
        private static int categoryid;
        private static double amount;
        private static double tax;

        private static double taxamount;
        private static double discount;
        private static double totalamount;
        private static double totalbillamount;
        private static string paymenttype;
        private static string charitywelfare;
        private static DateTime chequedate;
        private static string chequebankname;
        private static string chequenumber;
        private static DateTime neftdate;
        private static string neftbankname;
        private static string neftaccountNumber;
        private static string printflag;
        private static string printcount;
        private static string savetype;
       
        private static string desgnation;
      

        private static DateTime fromdate;
        private static DateTime todate;
        private static string querystring;

 
        
        private static int expensesheadid;
        private static string expensesdescription;

        private static int miscellaneousheadid;
        private static string miscellaneoushead;
        private static string miscellaneousdescription;
 
        private static string nameofdrug;
        private static string since;
        private static string howmanytimesperday;
 

      
        private static string notes;
       
        private static int notesid;
        private static string macaddress;
        

        public int NotesId
        {
            get { return notesid; }
            set { notesid = value; }
        }

        public string Notes
        {
            get { return notes; }
            set { notes = value; }
        }

         
        
        public int MiscellaneousHeadId
        {
            get { return miscellaneousheadid; }
            set { miscellaneousheadid = value; }
        }

        public string MiscellaneousHead
        {
            get { return miscellaneoushead; }
            set { miscellaneoushead = value; }
        }

        public string MiscellaneousDescription
        {
            get { return miscellaneousdescription; }
            set { miscellaneousdescription = value; }
        }

        public string ExpensesDescription
        {
            get { return expensesdescription; }
            set { expensesdescription = value; }
        }

        public string ExpensesHead
        {
            get { return expenseshead; }
            set { expenseshead = value; }
        }

        public int ExpensesHeadId
        {
            get { return expensesheadid; }
            set { expensesheadid = value; }
        }
 

        public string QueryString
        {
            get { return querystring; }
            set { querystring = value; }
        }

        public DateTime ToDate
        {
            get { return todate; }
            set { todate = value; }
        }

        public DateTime FromDate
        {
            get { return fromdate; }
            set { fromdate = value; }
        }
        

        

        public string Designation
        {
            get { return desgnation; }
            set { desgnation = value; }
        }
 
 
 

        public string SaveType
        {
            get { return savetype; }
            set { savetype = value; }
        }

        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public double Tax
        {
            get { return tax; }
            set { tax = value; }
        }

        public double TaxAmount
        {
            get { return taxamount; }
            set { taxamount = value; }
        }
        public double Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        public double TotalAmount
        {
            get { return totalamount; }
            set { totalamount = value; }
        }

        public double TotalBillAmount
        {
            get { return totalbillamount; }
            set { totalbillamount = value; }
        }
        public string PaymentType
        {
            get { return paymenttype; }
            set { paymenttype = value; }
        }

        public string CharityWelfare
        {
            get { return charitywelfare; }
            set { charitywelfare = value; }
        }

        public DateTime ChequeDate
        {
            get { return chequedate; }
            set { chequedate = value; }
        }

        public string ChequeBankName
        {
            get { return chequebankname; }
            set { chequebankname = value; }
        }

        public string ChequeNumber
        {
            get { return chequenumber; }
            set { chequebankname = value; }
        }

        public DateTime NEFTDate
        {
            get { return neftdate; }
            set { neftdate = value; }
        }

        public string NEFTBankName
        {
            get { return neftbankname; }
            set { chequebankname = value; }
        }

        public string NEFTAccountNumber
        {
            get { return neftaccountNumber; }
            set { neftaccountNumber = value; }
        }
 
        public string PrintFlag
        {
            get { return printflag; }
            set { printflag = value; }
        }

        public string PrintCount
        {
            get { return printcount; }
            set { printcount = value; }
        }
 

        public int CategoryId
        {
            get { return categoryid; }
            set { categoryid = value; }
        }

        public string ReportPath
        {
            get { return reportpath; }
            set { reportpath = value; }
        }
 
 
        public string Query
        {
            get { return query; }
            set { query = value; }
        }

        public string TableName
        {
            get { return tablename; }
            set { tablename = value; }
        }

        public string SearchText
        {
            get { return searchtext; }
            set { searchtext = value; }
        }

        private static string searchtype;

        public string SearchType
        {
            get { return searchtype; }
            set { searchtype = value; }
        }

        

        public bool SearchFlag
        {
            get { return searchflag; }
            set { searchflag = value; }
        }
 

        public string DocumentsPath
        {
            get { return documentspath; }
            set { documentspath = value; }
        }

        

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public DateTime DOB
        {
            get { return dob; }
            set { dob = value; }
        }
         
 

        public DateTime EntryDate
        {
            get { return entrydate; }
            set { entrydate = value; }
        }
         

        
         

        
          
         
        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }

       
        public string OfPlace
        {
            get { return ofplace; }
            set { ofplace = value; }
        }

        public string Aged
        {
            get { return aged; }
            set { aged = value; }
        }
 
        public int DesignationId
        {
            get { return designationid; }
            set { designationid = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public string BloodGroup
        {
            get { return bloodgroup; }
            set { bloodgroup = value; }
        }

        public string CurrentAddress
        {
            get { return currentaddress; }
            set { currentaddress = value; }
        }

        public string AsAbove
        {
            get { return asabove; }
            set { asabove = value; }
        }

        public string PermenentAddress
        {
            get { return permenentaddress; }
            set { permenentaddress = value; }
        }

        public string MobileNo1
        {
            get { return mobileno1; }
            set { mobileno1 = value; }
        }

        public string MobileNo2
        {
            get { return mobileno2; }
            set { mobileno2 = value; }
        }

        public string EmailId
        {
            get { return emailid; }
            set { emailid = value; }
        }

        public string Qualification
        {
            get { return qualification; }
            set { qualification = value; }
        }

        public string RegNo
        {
            get { return regno; }
            set { regno = value; }
        }

        public string Speciality
        {
            get { return speciality; }
            set { speciality = value; }
        }

        public string Experience
        {
            get { return experience; }
            set { experience = value; }
        }

        public DateTime DateOfJoining
        {
            get { return dateofjoining; }
            set { dateofjoining = value; }
        }

        public string UserType
        {
            get { return usertype; }
            set { usertype = value; }
        }

        public int ModifiedUserId
        {
            get { return modifieduserid; }
            set { modifieduserid = value; }
        }

        public int DeleteFlag
        {
            get { return deleteflag; }
            set { deleteflag = value; }
        }

        public int TableId
        {
            get { return tableid; }
            set { tableid = value; }
        }

        public int UserId
        {
            get { return userid; }
            set { userid = value; }
        }

        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string ExpensesPassword
        {
            get { return expensespassword; }
            set { expensespassword = value; }
        }
        

        public string UserName
        {
            get { return username; }
            set { username = value; }
        }

        public string FullName
        {
            get { return fullname; }
            set { fullname = value; }
        }

        public string MobileNo
        {
            get { return mobileno; }
            set { mobileno = value; }
        }

       
        public string NameOfDrug
        {
            get { return nameofdrug; }
            set { nameofdrug = value; }
        }

        public string HowManyTimesPerDay
        {
            get { return howmanytimesperday; }
            set { howmanytimesperday = value; }
        }

        public string Since
        {
            get { return since; }
            set { since = value; }
        }

        public string MACAddress
        {
            get { return macaddress; }
            set { macaddress = value; }
        }
       

        public DataSet Get_MaxID_Query()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = Query;
            objCmd.CommandType = CommandType.Text;
            objCmd.Connection = objBL.objCon;;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();

            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_Login_By_UserName_Password()
        {
            DataSet ds = new DataSet();
            try
            {
                objBL.Connect();

                objCmd = new MySqlCommand();
                objCmd.CommandText = "SP_Login_By_UserName_Password";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@UserName_V", UserName);
                objCmd.Parameters.AddWithValue("@Password_V", Password);
                objCmd.Connection = objBL.objCon;
                objDA = new MySqlDataAdapter(objCmd);
                objDA.Fill(ds);
                objBL.objCon.Close();
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }
            return ds;
        }

        public DataSet SP_Select_ExpensesCredentials()
        {
            DataSet ds = new DataSet();
            try
            {
                objBL.Connect();
                objCmd = new MySqlCommand();
                objCmd.CommandText = "SP_Select_ExpensesCredentials";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@UserId_V", UserId);
                objCmd.Parameters.AddWithValue("@ExpensesPassword_V", ExpensesPassword);
                objCmd.Connection = objBL.objCon;
                objDA = new MySqlDataAdapter(objCmd);
                objDA.Fill(ds);
                objBL.objCon.Close();
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }
            return ds;
        }

        public void SP_SpectialistsMaster_FillGrid(ComboBox cmb)
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_SpectialistsMaster_FillGrid";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = "Speciallists";
                cmb.ValueMember = "ID";
                cmb.SelectedIndex = -1;
            }
            objBL.objCon.Close();
        }

        public int SP_Login_ChangePassword()
        {
            int Result = 0;
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_Login_ChangePassword";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@LoginId_V", BusinessLayer.LoginId_Static);
            objCmd.Parameters.AddWithValue("@Password_V", Password);
            objCmd.Connection = objBL.objCon;;
            Result = objCmd.ExecuteNonQuery();
            return Result;
        }

        public int SP_Login_ChangePassword_ExpensesPassword()
        {
            int Result = 0;
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_Login_ChangePassword_ExpensesPassword";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@LoginId_V", BusinessLayer.LoginId_Static);
            objCmd.Parameters.AddWithValue("@ExpensesPassword_V", ExpensesPassword);
            objCmd.Connection = objBL.objCon;
            Result = objCmd.ExecuteNonQuery();
            return Result;
        }

       

        public DataSet SP_Select_UserType_In_Cashier_Receiption()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_Select_UserType_In_Cashier_Receiption";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_FillGrid_Login_By_DesignationId()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_FillGrid_Login_By_DesignationId";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@DesignationId_V", DesignationId);
            objCmd.Connection = objBL.objCon;;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_FillGrid_Designation()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_FillGrid_Designation";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

         
         
 
         

        public int SP_EmailList_Insert_Update_Delete()
        {
            int Result = 0;
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_EmailList_Insert_Update_Delete";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@ID_V", TableId);
            objCmd.Parameters.AddWithValue("@EmailId_V", EmailId);
            objCmd.Parameters.AddWithValue("@UserId_V", UserId);
            objCmd.Parameters.AddWithValue("@ModifiedUserId_V", ModifiedUserId);
            objCmd.Parameters.AddWithValue("@DeleteFlag_V", DeleteFlag);
            objCmd.Connection = objBL.objCon;;
            Result = objCmd.ExecuteNonQuery();
            return Result;
        }

        public DataSet SP_EmailList_FillGrid()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_EmailList_FillGrid";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_EmailList_CheckExist()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_EmailList_CheckExist";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@ID_V", TableId);
            objCmd.Parameters.AddWithValue("@EmailId_V", EmailId);
            objCmd.Connection = objBL.objCon;;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public int SP_ExpensesHead_Insert_Update_Delete()
        {
            int Result = 0;
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_ExpensesHead_Insert_Update_Delete";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@ID_V", TableId);
            objCmd.Parameters.AddWithValue("@ExpensesHeadMain_V", ExpensesHead);
            objCmd.Parameters.AddWithValue("@UserId_V", UserId);
            objCmd.Parameters.AddWithValue("@ModifiedUserId_V", ModifiedUserId);
            objCmd.Parameters.AddWithValue("@DeleteFlag_V", DeleteFlag);
            objCmd.Connection = objBL.objCon;;
            Result = objCmd.ExecuteNonQuery();
            return Result;
        }

        public DataSet SP_ExpencesHead_FillGrid()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_ExpensesHead_FillGrid";
            objCmd.Parameters.AddWithValue("@SearchFlag_V", SearchFlag);
            objCmd.Parameters.AddWithValue("@ExpensesHead_V", ExpensesHead);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Connection = objBL.objCon;;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_ExpensesHead_CheckExist()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_ExpensesHead_CheckExist";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@ID_V", TableId);
            objCmd.Parameters.AddWithValue("@ExpensesHeadMain_V", ExpensesHead);
            objCmd.Connection = objBL.objCon;;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_DesignationMaster_By_Designation()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_DesignationMaster_By_Designation";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@Designation_V", Designation);
            objCmd.Connection = objBL.objCon;;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public void SP_ComboBox_All(ComboBox cmb,string TName, string ValueMember, string DisplayMember)
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_ComboBox_All";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@ValueMember_V", ValueMember);
            objCmd.Parameters.AddWithValue("@DisplayMember_V", DisplayMember);
            objCmd.Parameters.AddWithValue("@TableName_V", TName);
            objCmd.Connection = objBL.objCon;;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                cmb.DataSource = ds.Tables[0];
                cmb.DisplayMember = DisplayMember;
                cmb.ValueMember = ValueMember;
                cmb.SelectedIndex = -1;
            }
            objBL.objCon.Close();
        }

        public DataSet SP_Select_Staff_By_Designation()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_Select_Staff_By_Designation";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@Designation_V", Designation);
            objCmd.Connection = objBL.objCon;;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }
        
        public DataSet SP_Expenses_FillGrid_Report()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_Expenses_FillGrid_Report";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@QueryString_V", QueryString);
            objCmd.Parameters.AddWithValue("@FromDate_V", FromDate);
            objCmd.Parameters.AddWithValue("@ToDate_V", ToDate);
            objCmd.Connection = objBL.objCon;;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_Expenses_FillGrid()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_Expenses_FillGrid";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@SearchFlag_V", SearchFlag);
            objCmd.Parameters.AddWithValue("@FromDate_V", FromDate);
            objCmd.Parameters.AddWithValue("@ToDate_V", ToDate);
            objCmd.Parameters.AddWithValue("@UserId_V", UserId);
            objCmd.Connection = objBL.objCon;;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public int SP_Expenses_Insert_Update()
        {
            int Result = 0;
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_Expenses_Insert_Update";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@ID_V", TableId);
            objCmd.Parameters.AddWithValue("@EntryDate_V", EntryDate);
            objCmd.Parameters.AddWithValue("@ExpensesHeadId_V", ExpensesHeadId);
            objCmd.Parameters.AddWithValue("@ExpensesHead_V", ExpensesHead);
            objCmd.Parameters.AddWithValue("@ExpensesDescription_V", ExpensesDescription);
            objCmd.Parameters.AddWithValue("@Amount_V", Amount);
            objCmd.Parameters.AddWithValue("@PaymentType_V", PaymentType);
            objCmd.Parameters.AddWithValue("@ChequeDate_V", ChequeDate);
            objCmd.Parameters.AddWithValue("@ChequeBankName_V", ChequeBankName);
            objCmd.Parameters.AddWithValue("@ChequeNumber_V", ChequeNumber);
            objCmd.Parameters.AddWithValue("@NEFTDate_V", NEFTDate);
            objCmd.Parameters.AddWithValue("@NEFTBankName_V", NEFTBankName);
            objCmd.Parameters.AddWithValue("@NEFTAccountNumber_V", NEFTAccountNumber);
            objCmd.Parameters.AddWithValue("@UserId_V", UserId);
            objCmd.Parameters.AddWithValue("@DeleteFlag_V", DeleteFlag);
            objCmd.Connection = objBL.objCon;;
            Result = objCmd.ExecuteNonQuery();
            return Result;
        }
        
        public DataSet SP_Expenses_Report()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_Expenses_Report";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@FromDate_V", FromDate);
            objCmd.Parameters.AddWithValue("@ToDate_V", ToDate);
            objCmd.Parameters.AddWithValue("@UserId_V", BusinessLayer.LoginId_Static);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public int SP_Backups_Save()
        {
            int Result = 0;
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_Backups_Save";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("Flag", SearchFlag);
            objCmd.Parameters.AddWithValue("@Date_V", EntryDate);
            objCmd.Parameters.AddWithValue("@UserId_V", UserId);
            objCmd.Connection = objBL.objCon;
            Result = objCmd.ExecuteNonQuery();
            return Result;
        }

        public DataSet SP_Backups_Select()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_Backups_Select";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("Flag", SearchFlag);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        public DataSet SP_MACAddressTable_Select()
        {
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_MACAddressTable_Select";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@macaddress_V", MACAddress);
            objCmd.Connection = objBL.objCon;
            objDA = new MySqlDataAdapter(objCmd);
            objDA.Fill(ds);
            objBL.objCon.Close();
            return ds;
        }

        //Asset Master
        public int SP_AssetMaster_Insert_Update_Delete()
        {
            int Result = 0;
            objBL.Connect();
            DataSet ds = new DataSet();
            objCmd = new MySqlCommand();
            objCmd.CommandText = "SP_AssetMaster_Insert_Update_Delete";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@AssetMasterId_V", objPC.AssetMasterId);
            objCmd.Parameters.AddWithValue("@EntryDate_V", objPC.EntryDate);
            objCmd.Parameters.AddWithValue("@FixedAssetCode_V", objPC.FixedAssetCode);
            objCmd.Parameters.AddWithValue("@AssetTypeId_V", objPC.AssetTypeId);
            objCmd.Parameters.AddWithValue("@ModelNo_V", objPC.ModelNo);
            objCmd.Parameters.AddWithValue("@SerialNumber_V", objPC.SerialNumber);
            objCmd.Parameters.AddWithValue("@DomainName_V", objPC.DomainName);
            objCmd.Parameters.AddWithValue("@UserName_V", objPC.UserName);
            objCmd.Parameters.AddWithValue("@DeviceManufracturer_V", objPC.DeviceManufracturer);
            objCmd.Parameters.AddWithValue("@DeviceName_V", objPC.DeviceName);
            objCmd.Parameters.AddWithValue("@Processor_V", objPC.Processor);
            objCmd.Parameters.AddWithValue("@RAM_V", objPC.RAM);
            objCmd.Parameters.AddWithValue("@RAMType_V", objPC.RAMType);
            objCmd.Parameters.AddWithValue("@MotherBoardSerialNo_V", objPC.MotherBoardSerialNo);
            objCmd.Parameters.AddWithValue("@DeviceID_V", objPC.DeviceID);
            objCmd.Parameters.AddWithValue("@ProductID_V", objPC.ProductID);
            objCmd.Parameters.AddWithValue("@HDDModel_V", objPC.HDDModel);
            objCmd.Parameters.AddWithValue("@HDDSize_V", objPC.HDDSize);
            objCmd.Parameters.AddWithValue("@HDDType_V", objPC.HDDType);
            objCmd.Parameters.AddWithValue("@SSDModel_V", objPC.SSDModel);
            objCmd.Parameters.AddWithValue("@SSDSize_V", objPC.SSDSize);
            objCmd.Parameters.AddWithValue("@SSDType_V", objPC.SSDType);
            objCmd.Parameters.AddWithValue("@Edition_V", objPC.Edition);
            objCmd.Parameters.AddWithValue("@Version_V", objPC.Version);
            objCmd.Parameters.AddWithValue("@InstalledOn_V", objPC.InstalledOn);
            objCmd.Parameters.AddWithValue("@OSBuild_V", objPC.OSBuild);
            objCmd.Parameters.AddWithValue("@Experience_V", objPC.Experience);
            objCmd.Parameters.AddWithValue("@OSManufacturer_V", objPC.OSManufacturer);
            objCmd.Parameters.AddWithValue("@MACAddress_V", objPC.MACAddress);
            objCmd.Parameters.AddWithValue("@IPAddress_V", objPC.IPAddress);
            objCmd.Parameters.AddWithValue("@Status_V", objPC.AssetStatus);
            objCmd.Parameters.AddWithValue("@EmployeeId_V", objPC.EmployeeId);
            objCmd.Parameters.AddWithValue("@UserId_V", UserId);
            objCmd.Parameters.AddWithValue("@DeleteFlag_V", objPC.DeleteFlag);
            objCmd.Connection = objBL.objCon;
            Result = objCmd.ExecuteNonQuery();
            return Result;
        }
    }
}
