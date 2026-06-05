using BusinessLayerUtility;
using DocumentFormat.OpenXml.Spreadsheet;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using SPApplication.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPApplication.ESSLUtility
{
    public partial class ESSLDataNew : Form
    {
        ErrorProvider objEP = new ErrorProvider();
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        PropertyClass objPC = new PropertyClass();
        QueryLayer objQL = new QueryLayer();
        AttendanceLogics objAL = new AttendanceLogics();

        string DataType = string.Empty, Database = string.Empty;
        bool FlagSave = false;
         
        string EmployeeCodeConcat = string.Empty;
        string R1 = "(", R2 = ")";
        string EmployeeCode = string.Empty;
        string DefaultV = "Default";

        bool FlagInsert = false;
        int TotalCount = 0, Result = 0;

        List<DateTime> allDates = new List<DateTime>();
        bool DateOfJoiningFlag = false, DateExitFlag = false;
        bool InsertFlagJoingDate = false, InsertFlagExitDate = false;

        public ESSLDataNew()
        {
            InitializeComponent();
            objDL.SetDesign3Buttons(this, lblHeader, btnESSLData, btnClear, btnExit, BusinessResources.LBL_HEADER_ESSLDATA);
            btnESSLData.Text = BusinessResources.BTN_ESSL;
            btnDelete.Text = BusinessResources.BTN_DELETE;
        }

        private void Fill_Database()
        {
            //Database_ACCESS	ACCESS	
            // Database_MSSQL	MSSQL	
            // Database_MYSQL	MYSQL	

            cmbDatabase.Items.Clear();
            cmbDatabase.Items.Add(BusinessResources.Database_ACCESS);
            cmbDatabase.Items.Add(BusinessResources.Database_MSSQL);

            //cmbDataType.Items.Clear();
            //cmbDataType.Items.Add(BusinessResources.DataType_AttendanceLog);
            //cmbDataType.Items.Add(BusinessResources.DataType_EmployeeMaster);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        private void ClearAll()
        {
            progressBar1.Value = 0;
            FlagSave = false;
            objEP.Clear();
            TotalCount = 0;
            //lblTotalInserted.Text = "";
            Fill_Database();
            //dtpDate.Value = DateTime.Now.Date;
            dtpAttendanceDate.Value = DateTime.Now.Date;
            //dtpToDate.Value = DateTime.Now.Date;
            DataType = string.Empty;
            Database = string.Empty;
            cmbDatabase.SelectedIndex = -1;
            //cmbDataType.SelectedIndex = -1;
            btnDelete.Visible = false;
            dtpAttendanceDate.Focus();
        }

        private void ESSLDataNew_Load(object sender, EventArgs e)
        {
            ClearAll();
        }
        private void btnESSLData_Click(object sender, EventArgs e)
        {
            bool FlagGo = false;
            if (objPC.AddFlag == 1)
            {
                try
                {
                    if (!Validation())
                    {
                        objPC.LeaveTypeFlag = false;
                        objPC.NewEmpCount = 0;

                        //Get Employee
                        New_Employee_Inserted_In_MYSQL_FROM_MSSQL();
                        GetNewEmployeeCount();

                        if (objPC.NewEmpCount == 0)
                        {
                            if (CheckExistAttendanceDate())
                            {
                                string msg = "Attendance for " + dtpAttendanceDate.Value.ToString(BusinessResources.DATEFORMATDDMMMYYYY) + " already has " + EditCount + " edited records. Do you want to overwrite them?";

                                DialogResult dr;
                                dr = MessageBox.Show(msg, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                                if (dr == DialogResult.Yes)
                                {
                                    FlagGo = true;
                                }
                                else
                                {
                                    FlagGo = false;
                                    objRL.ShowMessage(55, 4);
                                    return;
                                }
                            }
                            else
                                FlagGo = true;

                            if (FlagGo)
                            {
                                //if (EditCount > 0)
                                    
                                Delete_AttendanceRecords();
                                ConvertTable("AttendanceLogs");
                                CallStoreProcedure_AttendanceLogs();
                                objRL.ShowMessage(34, 1);
                                FillGrid_Data();
                             }
                        }
                        else
                        {
                            objRL.ShowMessage(39, 4);
                            return;
                        }
                    }
                }
                catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
                finally { GC.Collect(); }
            }
            else
            {
                objRL.ShowMessage(24, 4);
                return;
            }
        }

        private void Delete_AttendanceRecords()
        {
            //string connectionString = "server=your_server;database=your_db;uid=your_user;pwd=your_password;";

            using (MySqlConnection conn = new MySqlConnection(objBL.conString))
            {
                try
                {
                    conn.Open();

                    string query = "DELETE FROM attendancelogs WHERE AttendanceDate = @AttendanceDate";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@AttendanceDate", dtpAttendanceDate.Value.Date);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        //Console.WriteLine(rowsAffected + " record(s) deleted.");
                    }
                }
                catch (Exception ex)
                {
                    //Console.WriteLine("Error: " + ex.Message);
                }
            }

        }

        int EditCount = 0;
        private bool CheckExistAttendanceDate()
        {
            bool FlagExist=false;

            DateTime attendanceDate = dtpAttendanceDate.Value;

            using (MySqlConnection conn = new MySqlConnection(objBL.conString))
            {
                conn.Open();

                string query = @"SELECT 
                        COUNT(*) AS TotalRecords,
                        SUM(CASE WHEN IsEditAttendance = 1 THEN 1 ELSE 0 END) AS EditCount
                     FROM attendancelogs
                     WHERE DATE(AttendanceDate) = @AttendanceDate";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@AttendanceDate", MySqlDbType.Date).Value = attendanceDate;

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int totalRecords = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(reader["TotalRecords"])));  
                            int editCount = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(reader["EditCount"])));



                            EditCount = editCount; // Convert.ToInt32(reader["EditCount"]);

                            bool exists = totalRecords > 0;

                            // 👉 your logic
                            if (exists)
                            {
                                //Console.WriteLine("Date exists");
                                //Console.WriteLine("IsEditAttendance count: " + editCount);
                                FlagExist = true;
                            }
                            else
                            {
                                //Console.WriteLine("Date does not exist");
                                FlagExist = false;
                            }
                        }
                    }
                }
            }

            return FlagExist;

                //using (MySqlConnection conn = new MySqlConnection(objBL.conString))
                //{
                //    conn.Open();

            //    string query = @"SELECT EXISTS(
            //            SELECT 1 
            //            FROM attendancelogs 
            //            WHERE AttendanceDate = @AttendanceDate
            //        )";

            //    using (MySqlCommand cmd = new MySqlCommand(query, conn))
            //    {
            //        cmd.Parameters.AddWithValue("@AttendanceDate", attendanceDate);

            //        bool exists = Convert.ToBoolean(cmd.ExecuteScalar());

            //        if (exists)
            //        {
            //            return true;
            //        }
            //        else
            //        {
            //            return false;
            //        }
            //    }
            //}
            }
        private void CallStoreProcedure_AttendanceLogs()
        {
            objBL.Connect();
            using (MySqlConnection conn = new MySqlConnection(objBL.conString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SP_Update_Attendancelogs_New", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Pass DATE parameter
                    cmd.Parameters.Add("@AttendanceDate_V", MySqlDbType.Date).Value = dtpAttendanceDate.Value;

                    conn.Open();
                    int R= cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        private void FillGrid_Data()
        {
            lblTotalCount.Text = "";

            DataTable dt = new DataTable();
            objBL.Query = "select distinct AttendanceDate as 'Attendance Date' from attendancelogs where CancelTag=0 order by AttendanceDate desc";
            dt = objBL.ReturnDataTable();

            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 300;
                lblTotalCount.Text = "Total Count-" + dt.Rows.Count;
            }
        }

        public void ConvertTable(string tableName)
        {
            //attendancelogs Table add code

            //StringBuilder createTableSql = new StringBuilder($"CREATE TABLE IF NOT EXISTS `{tableName}` (");

            //foreach (DataColumn col in data.Columns)
            //{
            //    string mysqlType = GetMySqlDataType(col.DataType);
            //    createTableSql.Append($"`{col.ColumnName}` {mysqlType},");
            //}
            //createTableSql.Length--; // remove last comma
            //createTableSql.Append(");");

            //MySqlCommand createCmd = new MySqlCommand(createTableSql.ToString(), objBL.objCon);
            //createCmd.ExecuteNonQuery();

            objBL.Connect();
            objBL.ConnectESSL(BusinessResources.Database_MSSQL);
            SqlConnection sqlConn = new SqlConnection(objBL.conStringEssl);
            MySqlConnection mySqlConn = new MySqlConnection(objBL.conString);
            //sqlConn.Open();
            //mySqlConn.Open();

            DataTable data = new DataTable();
            //SqlCommand sqlCmd = new SqlCommand($"SELECT AL.*,E.* FROM AttendanceLogs AL inner join Employees E on E.EmployeeId=AL.EmployeeId where AttendanceDate='" +dtpFromDate.Value.ToString("yyyy-dd-MM")+"'", objBL.objCon_SQL_ESSL);
            //SqlCommand sqlCmd = new SqlCommand($"SELECT AL.*,E.EmployeeCode FROM AttendanceLogs AL inner join Employees E on E.EmployeeId=AL.EmployeeId where E.RecordStatus=1 and AL.AttendanceDate='" + dtpFromDate.Value.ToString("yyyy-MM-dd") + "' ", objBL.objCon_SQL_ESSL);

            SqlCommand sqlCmd = new SqlCommand(
            @"SELECT AL.AttendanceDate,
                    E.EmployeeCode,
                    AL.InTime,
                    AL.OutTime,
                    AL.Duration,
                    AL.Status,
                    AL.StatusCode,
                    AL.MissedOutPunch,
                    AL.MissedInPunch,
                    AL.PunchRecords
            FROM AttendanceLogs AL
            INNER JOIN Employees E ON E.EmployeeId = AL.EmployeeId
            WHERE E.RecordStatus = 1 AND AL.AttendanceDate=@date", objBL.objCon_SQL_ESSL);

            sqlCmd.Parameters.AddWithValue("@date", dtpAttendanceDate.Value.Date);

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
            adapter.Fill(data);

            //Dictionary<int, Employee> empMap = new Dictionary<int, Employee>();
            //Dictionary<int, int> empMap = new Dictionary<int, int>();
            List<Employee> employees = new List<Employee>();
            Dictionary<int, Employee> empMap = new Dictionary<int, Employee>();
            //MySqlCommand cmd = new MySqlCommand("SELECT * FROM employees where CancelTag=0 and Status='WORKING' and '"+ dtpAttendanceDate.Value.Date + "' <= DateOfExit ", objBL.objCon);
            MySqlCommand cmd = new MySqlCommand(@"SELECT E.*,C.CategoryFName FROM employees E inner join categories C on C.CategoryId=E.CategoryId where E.CancelTag=0 and C.CancelTag=0 and E.Status='WORKING' AND(E.DateOfExit IS NOT NULL AND E.DateOfExit >= @AttendanceDate) AND(E.DOJ IS NOT NULL AND E.DOJ <= @AttendanceDate) ORDER BY E.EmployeeCode asc", objBL.objCon);
            //cmd.Parameters.AddWithValue("@AttendanceDate", dtpAttendanceDate.Value.Date.ToString(BusinessResources.DATEFORMATYYYYYMMDD));
            cmd.Parameters.AddWithValue("@AttendanceDate", dtpAttendanceDate.Value.Date);
            //MySqlDataReader dr = cmd.ExecuteReader();

            //while (dr.Read())
            //{
            //    empMap.Add(dr.GetInt32("EmployeeCode"), dr.GetInt32("EmployeeId"));

            //    Employee emp = new Employee();

            //    emp.EmployeeId = dr.GetInt32("EmployeeId");
            //    emp.EmployeeCode = dr.GetInt32("EmployeeCode");
            //    emp.EmployeeName = dr["EmployeeName"].ToString();
            //    emp.DepartmentId = Convert.ToInt32(dr["DepartmentId"]);
            //    emp.DateOfJoin = Convert.ToDateTime(dr["DateOfJoin"]);
            //    emp.DateOfExit = dr["DateOfExit"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DateOfExit"]);

            //    employees.Add(emp);

            //}
            //dr.Close();

            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                int Count = 0;

                while (dr.Read())
                {
                    //empMap.Add(dr.GetInt32("EmployeeCode"), dr.GetInt32("EmployeeId"));

                    //empMap.Add(dr.GetInt32("EmployeeCode"), dr.GetInt32("EmployeeId"));

                    Employee emp = new Employee
                    {

                        //objPC.EmployeeCode = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dsEmployee.Tables[0].Rows[i]["EmployeeCode"])));
                        //objPC.EmployeeId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dsEmployee.Tables[0].Rows[i]["EmployeeId"])));
                        //objPC.LocationId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dsEmployee.Tables[0].Rows[i]["LocationId"])));
                        //objPC.DepartmentId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dsEmployee.Tables[0].Rows[i]["DepartmentId"])));
                        //objPC.ShiftGroupId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dsEmployee.Tables[0].Rows[i]["ShiftGroupId"])));
                        //objPC.CategoryId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dsEmployee.Tables[0].Rows[i]["CategoryId"])));
                        //objPC.DesignationId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dsEmployee.Tables[0].Rows[i]["DesignationId"])));
                        //objPC.Status = objRL.CheckNullString(Convert.ToString(dsEmployee.Tables[0].Rows[i]["Status"]));
                        //objPC.OverTimeApplicable

                        EmployeeId =dr.IsDBNull(dr.GetOrdinal("EmployeeId")) ? 0 : dr.GetInt32("EmployeeId"),
                        EmployeeCode = dr.IsDBNull(dr.GetOrdinal("EmployeeCode")) ? 0 : dr.GetInt32("EmployeeCode"),
                        EmployeeName = dr.IsDBNull(dr.GetOrdinal("EmployeeName")) ? "" : dr.GetString("EmployeeName"),
                        LocationId = dr.IsDBNull(dr.GetOrdinal("LocationId")) ? 0 : dr.GetInt32("LocationId"),
                        DepartmentId = dr.IsDBNull(dr.GetOrdinal("DepartmentId")) ? 0 : dr.GetInt32("DepartmentId"),
                        ContractorId = dr.IsDBNull(dr.GetOrdinal("ContractorId")) ? 0 : dr.GetInt32("ContractorId"),
                        CategoryId = dr.IsDBNull(dr.GetOrdinal("CategoryId")) ? 0 : dr.GetInt32("CategoryId"),
                        DesignationId = dr.IsDBNull(dr.GetOrdinal("DesignationId")) ? 0 : dr.GetInt32("DesignationId"),
                        ShiftGroupId = dr.IsDBNull(dr.GetOrdinal("ShiftGroupId")) ? 0 : dr.GetInt32("ShiftGroupId"),
                        OverTimeApplicable = dr.IsDBNull(dr.GetOrdinal("OverTimeApplicable")) ? 0 : dr.GetInt32("OverTimeApplicable"),
                        //DOJ = (DateTime)(dr["DOJ"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DOJ"])),
                        DOJ = dr["DOJ"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DOJ"]),
                        //DateOfExit = (DateTime)(dr["DateOfExit"] == DBNull.Value ? (DateTime?)null :Convert.ToDateTime(dr["DateOfExit"]))
                        DateOfExit = dr["DateOfExit"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DateOfExit"]),
                        CategoryFName = dr.IsDBNull(dr.GetOrdinal("CategoryFName")) ? "" : dr.GetString("CategoryFName")
                    };
                    Count++;

                    //empMap[emp.EmployeeCode] = emp;   // store full object
                    //employees.Add(emp);
                    empMap.Add(emp.EmployeeCode, emp);
                }
                dr.Close();
            }

            StringBuilder insertSql = new StringBuilder();
            insertSql.Append($"INSERT INTO `{tableName}` ");
            insertSql.Append("(AttendanceDate,EmployeeCode,EmployeeId,LocationId,DepartmentId,ContractorId,CategoryId,DesignationId,InTime,OutTime,Duration,Status,MissedOutPunch,MissedInPunch,ApprovalStatusId,FinancialYearId,PunchRecords) VALUES ");

            int batchSize = 5000;
            int count = 0;

            foreach (DataRow row in data.Rows)
            {
                DateTime attendanceDate = Convert.ToDateTime(row["AttendanceDate"]);
                int empCode = Convert.ToInt32(row["EmployeeCode"]);

                //int empId = 0;
                //int LocationId = 0;
                //string CName = string.Empty;

                Employee emp; 
                Employee emp1 =new Employee();

                if (empMap.TryGetValue(empCode, out emp))
                {
                    emp1.EmployeeId = emp.EmployeeId;
                    emp1.LocationId = emp.LocationId;
                    emp1.DepartmentId = emp.DepartmentId;
                    emp1.ContractorId = emp.ContractorId;
                    emp1.CategoryId = emp.CategoryId;
                    emp1.DesignationId = emp.DesignationId;
                    //emp1.CategoryFName = emp.CategoryFName;

                    if (emp1.EmployeeId > 0)
                    {
                        if (emp1.EmployeeId == 2041)
                        {

                        }

                        insertSql.Append("(");
                        insertSql.Append($"'{attendanceDate:yyyy-MM-dd}',");
                        insertSql.Append($"{empCode},");
                        insertSql.Append($"{emp1.EmployeeId},");
                        insertSql.Append($"{emp1.LocationId},");
                        insertSql.Append($"{emp1.DepartmentId},");
                        insertSql.Append($"{emp1.ContractorId},");
                        insertSql.Append($"{emp1.CategoryId},");
                        insertSql.Append($"{emp1.DesignationId},");
                        insertSql.Append($"{GetSqlValue(row["InTime"])},");
                        insertSql.Append($"{GetSqlValue(row["OutTime"])},");
                        insertSql.Append($"{GetSqlValue(row["Duration"])},");
                        insertSql.Append($"{GetSqlValue(row["StatusCode"])},");
                        insertSql.Append($"{GetSqlValue(row["MissedOutPunch"])},");
                        insertSql.Append($"{GetSqlValue(row["MissedInPunch"])},");
                        insertSql.Append($"{GetSqlValue(1)},");
                        //insertSql.Append($"{GetSqlValue(row["MissedInPunch"])})");
                        //insertSql.Append($"{GetSqlValue(row["PunchRecords"])})");
                        insertSql.Append($"{GetSqlValue(objPC.FinancialYearId)},");
                        
                        insertSql.Append($"('{row["PunchRecords"].ToString().Replace("'", "''")}'))");

                        insertSql.Append(",");

                        count++;

                        //string AB1 = insertSql.ToString();
                        if (count % batchSize == 0)
                        {
                            insertSql.Length--;
                            ExecuteInsert(objBL.objCon, insertSql.ToString());

                            insertSql.Clear();
                            insertSql.Append($"INSERT INTO `{tableName}` ");
                            insertSql.Append("(AttendanceDate,EmployeeCode,EmployeeId,LocationId,DepartmentId,ContractorId,CategoryId,DesignationId,InTime,OutTime,Duration,Status,MissedOutPunch,MissedInPunch,ApprovalStatusId,FinancialYearId,PunchRecords) VALUES ");
                        }
                    }
                }
                else
                {
                    continue; // skip if employee not found
                }

                //int empId = 0;
                //int LocationId = 0;

                ////empId = empMap.ContainsKey(empCode) ? empMap[empCode] : 0;
                //empId = empMap[empCode].EmployeeId;
                //LocationId = empMap[empCode].LocationId;
                //if (empMap.ContainsKey(empCode))
                //{

                //}


                //if (empMap.TryGetValue(empCode, out Employee emp))
                //{
                //    empId = emp.EmployeeId;
                //    LocationId = emp.LocationId;
                //}

                //if (empMap.TryGetValue(empCode, out Employee emp))
                //{
                //    empId = emp.EmployeeId;
                //    LocationId = emp.LocationId;
                //}


                //if (empMap.ContainsKey(empCode))
                //{
                //    //Employee emp = empMap[empCode];

                //    empId = emp.EmployeeId;
                //}
                ////int empId = empMap.ContainsKey(empCode) ? empMap[empCode] : 0;

                //// int LID =  empMap.ContainsKey(empCode) ? empMap[empCode] : 0;

                
            }

            MessageBox.Show("Total EMP Count-" + count);
            //string AB = insertSql.ToString();
            if (insertSql.Length > 0)
            {
                insertSql.Length--;
                ExecuteInsert(objBL.objCon, insertSql.ToString());
            }

            // Bulk Insert using batched INSERTs
            //int batchSize = 500;
            //int rowCount = 0;
            //StringBuilder insertSql = new StringBuilder();

            //foreach (DataRow row in data.Rows)
            //{
            //    if (rowCount % batchSize == 0)
            //    {
            //        if (insertSql.Length > 0)
            //        {
            //            ExecuteInsert(objBL.objCon, insertSql.ToString());
            //            insertSql.Clear();
            //        }
            //        //insertSql.Append($"INSERT INTO `{tableName}` VALUES ");
            //        insertSql.Append($"INSERT INTO `{tableName} (AttendanceDate,EmployeeId,InTime,OutTime,Duration,Status,StatusCode)` VALUES ");
            //    }
            //    insertSql.Append("(");
            //    for (int i = 0; i < data.Columns.Count - 1; i++)
            //    {
            //        objPC.EmployeeId = 0;
            //        string IsertDate = string.Empty;
            //        string CName = data.Columns[i].ColumnName;

            //        if (CName == "AttendanceDate" || CName == "EmployeeCode" || CName == "InTime" || CName == "OutTime" || CName == "Duration" || CName == "Status" || CName == "StatusCode")
            //        {
            //            var val = row[i];


            //            if (CName == "AttendanceDate")
            //            {
            //                objPC.AttendanceDate = Convert.ToDateTime(row[i]);
            //                IsertDate = objPC.AttendanceDate.ToString("yyyy-MM-dd");
            //                val = IsertDate;
            //            }

            //            if (CName == "EmployeeCode")
            //            {
            //                objRL.Get_EmployeeId_By_EmployeeCode(Convert.ToInt32(val));
            //                val = objPC.EmployeeId;
            //            }
            //            //var val = row[i];
            //            insertSql.Append(GetSqlValue(val));

            //            if (i < data.Columns.Count - 1)
            //                insertSql.Append(",");
            //        }
            //    }
            //    insertSql.Append("),");
            //    rowCount++;
            //}

            //if (insertSql.Length > 0)
            //{
            //    insertSql.Length--; // remove trailing comma
            //    ExecuteInsert(objBL.objCon, insertSql.ToString());
            //}

            //Console.WriteLine($"✅ Table `{tableName}` migrated: {rowCount} rows.");


        }



        public void ConvertTableOld(string tableName)
        {
            objBL.Connect();
            objBL.ConnectESSL(BusinessResources.Database_MSSQL);
            SqlConnection sqlConn = new SqlConnection(objBL.conStringEssl);
            MySqlConnection mySqlConn = new MySqlConnection(objBL.conString);
            //sqlConn.Open();
            //mySqlConn.Open();

            DataTable data = new DataTable();
            //SqlCommand sqlCmd = new SqlCommand($"SELECT AL.*,E.* FROM AttendanceLogs AL inner join Employees E on E.EmployeeId=AL.EmployeeId where AttendanceDate='" +dtpFromDate.Value.ToString("yyyy-dd-MM")+"'", objBL.objCon_SQL_ESSL);
            SqlCommand sqlCmd = new SqlCommand($"SELECT AL.*,E.EmployeeCode FROM AttendanceLogs AL inner join Employees E on E.EmployeeId=AL.EmployeeId where E.RecordStatus=1 and AL.AttendanceDate='" + dtpAttendanceDate.Value.ToString("yyyy-MM-dd") + "' ", objBL.objCon_SQL_ESSL);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
            adapter.Fill(data);

            //attendancelogs

            StringBuilder createTableSql = new StringBuilder($"CREATE TABLE IF NOT EXISTS `{tableName}` (");

            foreach (DataColumn col in data.Columns)
            {
                string mysqlType = GetMySqlDataType(col.DataType);
                createTableSql.Append($"`{col.ColumnName}` {mysqlType},");
            }
            createTableSql.Length--; // remove last comma
            createTableSql.Append(");");

            MySqlCommand createCmd = new MySqlCommand(createTableSql.ToString(), objBL.objCon);
            createCmd.ExecuteNonQuery();

            // Bulk Insert using batched INSERTs
            int batchSize = 500;
            int rowCount = 0;
            StringBuilder insertSql = new StringBuilder();

            foreach (DataRow row in data.Rows)
            {
                if (rowCount % batchSize == 0)
                {
                    if (insertSql.Length > 0)
                    {
                        ExecuteInsert(objBL.objCon, insertSql.ToString());
                        insertSql.Clear();
                    }
                    //insertSql.Append($"INSERT INTO `{tableName}` VALUES ");
                    insertSql.Append($"INSERT INTO `{tableName} (AttendanceDate,EmployeeId,InTime,OutTime,Duration,Status,StatusCode)` VALUES ");
                }
                insertSql.Append("(");
                for (int i = 0; i < data.Columns.Count-1; i++)
                {
                    objPC.EmployeeId = 0;
                    string IsertDate = string.Empty;
                    string CName = data.Columns[i].ColumnName;

                    if (CName == "AttendanceDate" || CName == "EmployeeCode" || CName == "InTime" || CName == "OutTime" || CName == "Duration" || CName == "Status" || CName == "StatusCode")
                    {
                        var val = row[i];
                        

                        if (CName == "AttendanceDate")
                        {
                            objPC.AttendanceDate = Convert.ToDateTime(row[i]);
                            IsertDate = objPC.AttendanceDate.ToString("yyyy-MM-dd");
                            val = IsertDate;
                        }

                        if (CName == "EmployeeCode")
                        {
                            objRL.Get_EmployeeId_By_EmployeeCode(Convert.ToInt32(val));
                            val = objPC.EmployeeId;
                        }
                            //var val = row[i];
                            insertSql.Append(GetSqlValue(val));

                        if (i < data.Columns.Count - 1)
                            insertSql.Append(",");
                    }
                }
                insertSql.Append("),");
                rowCount++;
            }

            if (insertSql.Length > 0)
            {
                insertSql.Length--; // remove trailing comma
                ExecuteInsert(objBL.objCon, insertSql.ToString());
            }

            Console.WriteLine($"✅ Table `{tableName}` migrated: {rowCount} rows.");
        }


        private string GetMySqlDataType(Type type)
        {
            if (type == typeof(string)) return "VARCHAR(255)";
            if (type == typeof(int)) return "INT";
            if (type == typeof(long)) return "BIGINT";
            if (type == typeof(decimal)) return "DECIMAL(18,2)";
            if (type == typeof(DateTime)) return "DATETIME";
            if (type == typeof(bool)) return "TINYINT(1)";
            return "TEXT";
        }

        private string GetSqlValue(object val)
        {
            if (val == DBNull.Value) return "NULL";
            if (val is string || val is DateTime)
                return $"'{val.ToString().Replace("'", "''")}'";
            if (val is bool b) return b ? "1" : "0";
            return val.ToString();
        }
        private void ExecuteInsert(MySqlConnection conn, string insertSql)
        {
            var cmd = new MySqlCommand(insertSql, conn);
            int Result= cmd.ExecuteNonQuery();
        }

        private void Employee_Insert_Database()
        {
            objPC.NewEmpCount = 0; objPC.NewFlag = 0; objPC.FlagC = 0;
            EmployeeCodeConcat = string.Empty;
            try
            {
                //DataSet dsS = new DataSet();
                ////objBL.Query = "select * from Employees where CancelTag=0 and Status='Working'";
                //objBL.Query = "select * from Employees where CancelTag=0 order by EmployeeCode asc";
                //dsS = objBL.ReturnDataSet();

                //if (dsS.Tables[0].Rows.Count > 0)
                //{
                //    //EmployeeCodeConcat = "(";
                //    for (int i = 0; i < dsS.Tables[0].Rows.Count; i++)
                //    {
                //        if (!string.IsNullOrEmpty(Convert.ToString(dsS.Tables[0].Rows[i]["EmployeeCode"])))
                //        {
                //            EmployeeCodeConcat += "'" + Convert.ToString(dsS.Tables[0].Rows[i]["EmployeeCode"]) + "',";
                //        }
                //    }
                //}

                //EmployeeCodeConcat = EmployeeCodeConcat.Remove(EmployeeCodeConcat.Length - 1);
                //EmployeeCodeConcat = R1 + EmployeeCodeConcat + R2;
                //string WhereQ = " RecordStatus=1 and Status='Working' and EmployeeCode NOT IN " + EmployeeCodeConcat;

                DataTable dt = new DataTable();
                objBL.Query = "SELECT EmployeeCode FROM Employees WHERE CancelTag=0 ORDER BY EmployeeCode ASC";
                dt = objBL.ReturnDataTable();

                List<string> empCodes = new List<string>();

                foreach (DataRow row in dt.Rows)
                {
                    if (!string.IsNullOrEmpty(row["EmployeeCode"].ToString()))
                    {
                        empCodes.Add("'" + row["EmployeeCode"].ToString() + "'");
                    }
                }

                string EmployeeCodeConcat = "(" + string.Join(",", empCodes) + ")";

                string WhereQ = "RecordStatus=1 AND Status='Working' AND EmployeeCode NOT IN " + EmployeeCodeConcat;



                DataSet ds = new DataSet();

                string MainQuery = "Select " +
                                    "EmployeeId," +
                                    "EmployeeName," +
                                    "EmployeeCode," +
                                    "StringCode," +
                                    "NumericCode," +
                                    "Gender," +
                                    "CompanyId," +
                                    "DepartmentId," +
                                    "Designation," +
                                    "CategoryId," +
                                    "DOJ," +
                                    "DOR," +
                                    "DOC," +
                                    "EmployeeCodeInDevice," +
                                    "EmployeeRFIDNumber," +
                                    "EmployementType," +
                                    "Status," +
                                    "EmployeeDevicePassword," +
                                    "EmployeeDeviceGroup," +
                                    "FatherName," +
                                    "MotherName," +
                                    "ResidentialAddress," +
                                    "PermanentAddress," +
                                    "ContactNo," +
                                    "Email," +
                                    "DOB," +
                                    "PlaceOfBirth," +
                                    "Nomenee1," +
                                    "Nomenee2," +
                                    "Remarks," +
                                    "RecordStatus," +
                                    "Location," +
                                    "BLOODGROUP," +
                                    "WorkPlace," +
                                    "ExtensionNo," +
                                    "LoginName," +
                                    "LoginPassword," +
                                    "Team," +
                                    "IsRecieveNotification," +
                                    "HolidayGroup," +
                                    "ShiftGroupId," +
                                    "ShiftRosterId," +
                                    "LastModifiedBy," +
                                    "AadhaarNumber," +
                                    "EmployeePhoto," +
                                    "MasterDeviceId," +
                                    "BIOPhoto1," +
                                    "BIOPhotoPic," +
                                    "DeviceExpiryRule," +
                                    "DeviceExpiryStartDate," +
                                    "DeviceExpiryEndDate," +
                                    "DeviceId," +
                                    "EnrolledDate," +
                                    "MigrateToOtherCryptography," +
                                    "GeofenceId from Employees where " + WhereQ + "";

                //Employees E inner join Departments D on D.DepartmentId=E.DepartmentId inner join Categories CT on CT.CategoryId=E.CategoryId inner join ShiftGroups SG on SG.ShiftGroupId=E.ShiftGroupId where E.RecordStatus=1 and E.Status='Working'

                if (cmbDatabase.Text == BusinessResources.Database_ACCESS)
                {
                    objPC.FlagC = 1;
                    //objBL.Query = BusinessResources.EmployeeESSL_Column + " " + BusinessResources.EmployeeESSL_Access + WhereQ; //  objEDU.EmployeeQuery + objEDU.FromAccess;
                    //objBL.Query = MainQuery; // BusinessResources.EmployeeESSL_Column + " " + BusinessResources.EmployeeESSL_Access + WhereQ; //  objEDU.EmployeeQuery + objEDU.FromAccess;
                }
                else
                {
                    objPC.FlagC = 0;
                    //objBL.Query = BusinessResources.EmployeeESSL_Column + " " + BusinessResources.EmployeeESSL_SQL + WhereQ; //objEDU.EmployeeQuery + objEDU.FromSQL;
                    // objBL.Query = BusinessResources.EmployeeESSL_Column; // +" " + BusinessResources.EmployeeESSL_SQL + WhereQ; //objEDU.EmployeeQuery + objEDU.FromSQL;
                }

                objBL.Query = MainQuery;
                ds = objBL.ReturnDataSet_ESSL(cmbDatabase.Text);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    TotalCount = ds.Tables[0].Rows.Count;
                    
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ClearEmployeeDetails();
                        objPC.NewFlag = 1;
                        objPC.ESSLEmployeeId = Convert.ToInt32(ds.Tables[0].Rows[i]["EmployeeId"]);
                        objPC.EmployeeCode = Convert.ToInt32(ds.Tables[0].Rows[i]["EmployeeCode"].ToString());
                        objPC.EmployeeName = Convert.ToString(ds.Tables[0].Rows[i]["EmployeeName"]);
                        objPC.Status = "WORKING";
                        objPC.ContractorId = Convert.ToInt32(objQL.SP_Get_All_TableId_By_Name("contractormaster", DefaultV));
                        objPC.LocationId = Convert.ToInt32(objQL.SP_Get_All_TableId_By_Name("locationmaster", DefaultV));
                        objPC.DepartmentId = Convert.ToInt32(objQL.SP_Get_All_TableId_By_Name("DepartmentMaster", DefaultV));
                        objPC.DesignationId = Convert.ToInt32(objQL.SP_Get_All_TableId_By_Name("designationmaster", DefaultV));
                        objPC.CategoryId = Convert.ToInt32(objQL.SP_Get_All_TableId_By_Name("categories", DefaultV));
                        objPC.ShiftGroupId = Convert.ToInt32(objQL.SP_Get_All_TableId_By_Name("shiftgroups", DefaultV));
                        objPC.EmployementTypeId = Convert.ToInt32(objQL.SP_Get_All_TableId_By_Name("employementtypemaster", DefaultV));

                        objBL.Query = "insert into employees(EmployeeCode,EmployeeName,EmployementTypeId,ContractorId,LocationId,DepartmentId,DesignationId,CategoryId,ShiftGroupId,NewFlag,Status,FlagC,UserId,FinancialYearId) " +
                            " values(" + objPC.EmployeeCode + ",'" + objPC.EmployeeName + "'," + objPC.EmployementTypeId + "," + objPC.ContractorId + "," + objPC.LocationId + "," + objPC.DepartmentId + "," + objPC.DesignationId + "," + objPC.CategoryId + "," + objPC.ShiftGroupId + "," + objPC.NewFlag + ",'" + objPC.Status + "'," + objPC.FlagC + "," + objPC.UserId + "," + objPC.FinancialYearId + ")";

                        //if (objPC.EmployeeCode == 741) // || objPC.EmployeeCode == 10361 || objPC.EmployeeCode == 10362 || objPC.EmployeeCode == 10363 || objPC.EmployeeCode == 10366)
                        //{
                        //    MessageBox.Show("Found" + objPC.EmployeeCode);
                        //}

                        Result = objBL.Function_ExecuteNonQuery();
                        Result = 0; objPC.NewFlag = 0;
                    }
                    //objBL.Query = "update Employees set DesignationId=12 where EmployeeCode IN(611,532,100001) and CancelTag=0";
                    //Result = objBL.Function_ExecuteNonQuery();
                    //Result = 0;
                }
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            lblAttendanceDay.Text = Convert.ToString(dtpAttendanceDate.Value.Date.DayOfWeek);
        }

        private void New_Employee_Inserted_In_MYSQL_FROM_MSSQL()
        {
            objBL.Connect();
            HashSet<int> mysqlEmployeeCodes = new HashSet<int>();

            string mysqlQuery = "SELECT EmployeeCode FROM employees where CancelTag=0 ";

            MySqlCommand cmdMy = new MySqlCommand(mysqlQuery, objBL.objCon);
            MySqlDataReader reader = cmdMy.ExecuteReader();

            while (reader.Read())
            {
                mysqlEmployeeCodes.Add(Convert.ToInt32(reader["EmployeeCode"]));
            }
            reader.Close();

            objPC.Status = "WORKING";
            objPC.ContractorId = Convert.ToInt32(objQL.SP_Get_All_TableId_By_Name("contractormaster", DefaultV));
            objPC.LocationId = Convert.ToInt32(objQL.SP_Get_All_TableId_By_Name("locationmaster", DefaultV));
            objPC.DepartmentId = Convert.ToInt32(objQL.SP_Get_All_TableId_By_Name("DepartmentMaster", DefaultV));
            objPC.DesignationId = Convert.ToInt32(objQL.SP_Get_All_TableId_By_Name("designationmaster", DefaultV));
            objPC.CategoryId = Convert.ToInt32(objQL.SP_Get_All_TableId_By_Name("categories", DefaultV));
            objPC.ShiftGroupId = Convert.ToInt32(objQL.SP_Get_All_TableId_By_Name("shiftgroups", DefaultV));
            objPC.EmployementTypeId = Convert.ToInt32(objQL.SP_Get_All_TableId_By_Name("employementtypemaster", DefaultV));

            objBL.objCon.Close();

            objBL.ConnectESSL(BusinessResources.Database_MSSQL);
            string sqlQuery = "SELECT EmployeeId,EmployeeCode,EmployeeName FROM Employees WHERE RecordStatus=1 AND Status='Working'";

            SqlCommand cmdSql = new SqlCommand(sqlQuery, objBL.objCon_SQL_ESSL);
            SqlDataReader sqlReader = cmdSql.ExecuteReader();
            
            objBL.Connect();

            while (sqlReader.Read())
            {
                int empCode = Convert.ToInt32(sqlReader["EmployeeCode"]);

                //string empCode = Convert.ToString(sqlReader["EmployeeCode"]);

                if (!mysqlEmployeeCodes.Contains((empCode)))
                {
                    string insertQuery = @"insert into employees(EmployeeCode,EmployeeName,EmployementTypeId,LocationId,DepartmentId,ContractorId,DesignationId,CategoryId,ShiftGroupId,NewFlag,Status,FlagC,UserId,FinancialYearId) " +
                        " values(@EmployeeCode,@EmployeeName,@EmployementTypeId,@LocationId,@DepartmentId,@ContractorId,@DesignationId,@CategoryId,@ShiftGroupId,@NewFlag,@Status,@FlagC,@UserId,@FinancialYearId) ";



                    //" values(" + objPC.EmployeeCode + ",'" + objPC.EmployeeName + "'," + objPC.EmployementTypeId + "," + objPC.ContractorId + "," + objPC.LocationId + "," + objPC.DepartmentId + "," + objPC.DesignationId + "," + objPC.CategoryId + "," + objPC.ShiftGroupId + "," + objPC.NewFlag + ",'" + objPC.Status + "'," + objPC.FlagC + "," + objPC.UserId + "," + objPC.FinancialYearId + ")";


                    //            string insertQuery = @"INSERT INTO employees
                    //(EmployeeCode,EmployeeName,Status)
                    //VALUES(@EmployeeCode,@EmployeeName,'WORKING')";
                    objPC.NewFlag = 1;

                    MySqlCommand insertCmd = new MySqlCommand(insertQuery, objBL.objCon);
                    insertCmd.Parameters.AddWithValue("@EmployeeCode", empCode);
                    insertCmd.Parameters.AddWithValue("@EmployeeName", sqlReader["EmployeeName"].ToString());
                    insertCmd.Parameters.AddWithValue("@EmployementTypeId", objPC.EmployementTypeId);
                    insertCmd.Parameters.AddWithValue("@LocationId", objPC.LocationId);
                    insertCmd.Parameters.AddWithValue("@DepartmentId", objPC.DepartmentId);
                    insertCmd.Parameters.AddWithValue("@ContractorId", objPC.ContractorId);
                    insertCmd.Parameters.AddWithValue("@DesignationId", objPC.DesignationId);
                    insertCmd.Parameters.AddWithValue("@CategoryId", objPC.CategoryId);
                    insertCmd.Parameters.AddWithValue("@ShiftGroupId", objPC.ShiftGroupId);
                    insertCmd.Parameters.AddWithValue("@NewFlag", objPC.NewFlag);
                    insertCmd.Parameters.AddWithValue("@Status", objPC.Status);
                    insertCmd.Parameters.AddWithValue("@FlagC", objPC.FlagC);
                    insertCmd.Parameters.AddWithValue("@UserId", objPC.UserId);
                    insertCmd.Parameters.AddWithValue("@FinancialYearId", objPC.FinancialYearId);
                    insertCmd.ExecuteNonQuery();
                }
            }
            sqlReader.Close();

        }

        private bool Validation()
        {
            objEP.Clear();
            if (cmbDatabase.SelectedIndex == -1)
            {
                cmbDatabase.Focus();
                objEP.SetError(cmbDatabase, "Select ESSL Database");
                return true;
            }
            else
                return false;
        }

        public bool GetNewEmployeeCount()
        {
            objPC.NewEmpCount = 0;
            objBL.Connect();
            bool returnFlag = false;

            string query = "SELECT COUNT(EmployeeId) FROM Employees WHERE NewFlag = 1 AND CancelTag = 0";

            using (MySqlConnection conn = new MySqlConnection(objBL.conString))
            {
//                objBL.conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, objBL.objCon))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    objPC.NewEmpCount = count;

                    if (count > 0)
                        returnFlag = true;
                }
            }

            return returnFlag;
        }

        private bool CheckExistNewEmployee()
        {
            objPC.NewEmpCount = 0;
            bool ReturnFlag = false;
            DataSet ds = new DataSet();
            objBL.Query = "Select count(EmployeeId) as 'EmpCount' from Employees where NewFlag=1 and CancelTag=0";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["EmpCount"].ToString())))
                {
                    objPC.NewEmpCount = Convert.ToInt32(ds.Tables[0].Rows[0]["EmpCount"].ToString());
                    ReturnFlag = true;
                }
                else
                    ReturnFlag = false;
            }
            return ReturnFlag;
        }

        private void ClearEmployeeDetails()
        {
            objPC.EmployeeId = 0;
            objPC.EmployeeName = "";
            objPC.Gender = "";
            objPC.CompanyName = "";
            objPC.CompanyId = 0;
            objPC.DepartmentName = "";
            objPC.DepartmentId = 0;
            objPC.Designation = "";
            objPC.DesignationId = 0;
            objPC.CategoryName = "";
            objPC.CategoryId = 0;
            objPC.CategoryId = 0;
            objPC.EmployementType = "";
            objPC.EmployementTypeId = 0;
            objPC.Status = "";
            objPC.Location = "";
            objPC.LocationId = 0;
            objPC.ContractorId = 0;
            objPC.ShiftGroupId = 0;
            objPC.DeviceId = 0;
            objPC.NewFlag = 0;
        }
    }
}
