using BusinessLayerUtility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPApplication.Views
{
    public partial class TestDB : Form
    {
        BusinessLayer objBL = new BusinessLayer();

        public TestDB()
        {
            InitializeComponent();
        }

        private void CallAll()
        {
            DataTable dt=new DataTable();
            objBL.Query = "select ARM.*,AR.* " +
                " from malasnewserver31052026.attendancerecordmaster ARM inner join attendancerecord AR  " +
                " on ARM.AttendanceRecordMasterId=AR.AttendanceRecordMasterId where ARM.CancelTag=0 and ARM.FinancialYearId=4 " +
                " and AR.FinancialYearId=4";

            dt = objBL.ReturnDataTable();
            dataGridView1.DataSource = dt;


}
        private void TestDB_Load(object sender, EventArgs e)
        {
            CallAll();

            //objBL.ConnectESSL_F();

            //string Query = "SELECT TABLE_SCHEMA, TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' ORDER BY TABLE_SCHEMA ASC";

            ////SELECT * FROM sys.databases
            ////SELECT TABLE_SCHEMA, TABLE_NAME FROM INFORMATION_SCHEMA.TABLES

            //objBL.objCmd_SQL_Erp = new SqlCommand(Query);
            //objBL.objCmd_SQL_Erp.Connection = objBL.objCon_SQL_Erp;
            //objBL.da_SQL_Erp = new SqlDataAdapter(objBL.objCmd_SQL_Erp);
            //DataTable dt = new DataTable();
            //objBL.da_SQL_Erp.Fill(dt);
            //objBL.objCon_SQL_Erp.Close();


            //objBL.ConnectESSL_F();
            //DataTable dt2 = new DataTable();
            //string Query1 = "SELECT * FROM Framework.LoginUserGroup ";

            //objBL.objCmd_SQL_Erp = new SqlCommand(Query1);
            //objBL.objCmd_SQL_Erp.Connection = objBL.objCon_SQL_Erp;
            //objBL.da_SQL_Erp = new SqlDataAdapter(objBL.objCmd_SQL_Erp);

            //objBL.da_SQL_Erp.Fill(dt2);
            //objBL.objCon_SQL_Erp.Close();

            //SqlConnection objCon=new SqlConnection("<add name="ERPConnectionSql" connectionString="Server=192.168.1.251;Database=TNTINFRA_Live;User Id=sa;Password='Password9'" providerName="System.Data.SqlClient" />" 
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string ipAddress = "192.168.1.5";
            int port = 8085; // Replace with the port number of your ESSL machine

            //string ipAddress = "192.168.1.201"; // Replace with the IP address of your ESSL machine
            //int port = 9999; // Replace with the port number of your ESSL machine

            using (TcpClient client = new TcpClient(ipAddress, port))
            {
                NetworkStream stream = client.GetStream();

                // Send a command to the ESSL machine to request data
                byte[] command = Encoding.ASCII.GetBytes("GetAttLog\r\n");
                stream.Write(command, 0, command.Length);

                // Read the response from the ESSL machine
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string responseData = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                stream.Close();
                client.Close();
                // Process the response data
                Console.WriteLine("Response from ESSL machine: " + responseData);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //HttpClient
        }

        private void btnExportFile_Click(object sender, EventArgs e)
        {
            ConvertTable("AttendanceLogs");
        }

        string sqlConnStr = "Server=SQL_SERVER;Database=essl;User Id=sa;Password=password;";
        string mySqlConnStr = "Server=localhost;Database=essl_mysql;Uid=root;Pwd=password;";

        public void ConvertTable(string tableName)
        {
            objBL.Connect();
            objBL.ConnectESSL(BusinessResources.Database_MSSQL);
            SqlConnection sqlConn = new SqlConnection(objBL.conStringEssl);
            MySqlConnection mySqlConn = new MySqlConnection(objBL.conString);

            //sqlConn.Open();
            //mySqlConn.Open();
            string primaryKeyColumn = "AttendanceLogId"; // change to your PK column name

            DataTable data = new DataTable();

            string Query = "select AL.AttendanceLogId,AL.AttendanceDate,AL.EmployeeId,E.EmployeeCode,AL.InTime,AL.OutTime,AL.PunchRecords,AL.Status,AL.StatusCode,AL.MissedOutPunch from AttendanceLogs AL inner join Employees E on E.EmployeeId=AL.EmployeeId where E.RecordStatus=1 order by AL.AttendanceDate asc ";

            SqlCommand sqlCmd = new SqlCommand($"{Query}", objBL.objCon_SQL_ESSL);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
            adapter.Fill(data);

            StringBuilder createTableSql = new StringBuilder($"CREATE TABLE IF NOT EXISTS `{tableName}` (");

            foreach (DataColumn col in data.Columns)
            {
                string mysqlType = GetMySqlDataType(col.DataType);
                //createTableSql.Append($"`{col.ColumnName}` {mysqlType},");

                if (col.ColumnName == primaryKeyColumn)
                {
                    //createTableSql.Append("PRIMARY KEY,");
                    createTableSql.Append($"`{col.ColumnName}` {mysqlType} NOT NULL AUTO_INCREMENT PRIMARY KEY,");
                }
                else
                    createTableSql.Append($"`{col.ColumnName}` {mysqlType},");
            }
            createTableSql.Length--; // remove last comma
            createTableSql.Append(");");

            MySqlCommand createCmd = new MySqlCommand(createTableSql.ToString(), objBL.objCon);
            createCmd.ExecuteNonQuery();

            // Bulk Insert using batched INSERTs
            int batchSize = 10000;
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
                    insertSql.Append($"INSERT INTO `{tableName}` VALUES ");
                }
                insertSql.Append("(");
                for (int i = 0; i < data.Columns.Count; i++)
                {
                    var val = row[i];
                    string CN= data.Columns[i].ToString();

                    if (CN == "AttendanceDate")
                    {
                        DateTime dt = Convert.ToDateTime(val);
                        val = dt.ToString("yyyy-MM-dd");
                    }
                    insertSql.Append(GetSqlValue(val));
                    if (i < data.Columns.Count - 1)
                        insertSql.Append(",");
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
            if (!string.IsNullOrEmpty(insertSql))
            {
                insertSql = insertSql.Substring(0, insertSql.Length - 1);
            }

            var cmd = new MySqlCommand(insertSql, conn);
            cmd.ExecuteNonQuery();
        }

        private void btnAddMysql_Click(object sender, EventArgs e)
        {
            string tableName = string.Empty;
            tableName = "attendancelogs";
            DataTable dt = new DataTable();

             
            objBL.Query = "select ARM.*,AR.*,E.* " +
                " from malasnewserver31052026.attendancerecordmaster ARM inner join attendancerecord AR  " +
                " on ARM.AttendanceRecordMasterId=AR.AttendanceRecordMasterId inner join employees E on E.EmployeeId=AR.EmployeeId where E.CancelTag=0 and ARM.CancelTag=0 and ARM.FinancialYearId=4 " +
                " and AR.FinancialYearId=4";

            dt = objBL.ReturnDataTable();
            dataGridView1.DataSource = dt;

            if(dt.Rows.Count >0)
            {
                StringBuilder insertSql = new StringBuilder();
                insertSql.Append($"INSERT INTO `{tableName}` ");
                insertSql.Append("(AttendanceDate,EmployeeCode,EmployeeId,LocationId,DepartmentId,ContractorId,CategoryId,DesignationId,InTime,OutTime,Duration,Status,MissedOutPunch,MissedInPunch,ApprovalStatusId,FinancialYearId,PunchRecords) VALUES ");

                int batchSize = 5000;
                int count = 0;

                foreach (DataRow row in dt.Rows)
                {
                    DateTime attendanceDate = Convert.ToDateTime(row["AttendanceDate"]);


                    insertSql.Append("(");
                    insertSql.Append($"'{attendanceDate:yyyy-MM-dd}',");
                    insertSql.Append($"{GetSqlValue(row["EmployeeCode"])},");  //insertSql.Append($"{empCode},");

                    insertSql.Append($"{GetSqlValue(row["EmployeeId"])},"); //insertSql.Append($"{emp1.EmployeeId},");
                    insertSql.Append($"{GetSqlValue(row["LocationId"])},"); //insertSql.Append($"{emp1.LocationId},");
                    insertSql.Append($"{GetSqlValue(row["DepartmentId"])},"); //insertSql.Append($"{emp1.DepartmentId},");
                    insertSql.Append($"{GetSqlValue(row["ContractorId"])},"); //insertSql.Append($"{emp1.ContractorId},");
                    insertSql.Append($"{GetSqlValue(row["CategoryId"])},"); //insertSql.Append($"{emp1.CategoryId},");
                    insertSql.Append($"{GetSqlValue(row["DesignationId"])},"); //insertSql.Append($"{emp1.DesignationId},");
                    insertSql.Append($"{GetSqlValue(row["InTime"])},");
                    insertSql.Append($"{GetSqlValue(row["OutTime"])},");
                    insertSql.Append($"{GetSqlValue(row["Duration"])},");
                    insertSql.Append($"{GetSqlValue(row["Status"])},");
                    insertSql.Append($"{GetSqlValue(row["MissedOutPunch"])},");
                    insertSql.Append($"{GetSqlValue(row["MissedInPunch"])},");
                    insertSql.Append($"{GetSqlValue(1)},");
                    //insertSql.Append($"{GetSqlValue(row["MissedInPunch"])})");
                    //insertSql.Append($"{GetSqlValue(row["PunchRecords"])})");
                    
                    insertSql.Append($"{GetSqlValue(4)},");
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
        }
    }
}
