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
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;



namespace SPApplication
{
    public partial class ESSLData : Form
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
        int TotalCount = 0;

        List<DateTime> allDates = new List<DateTime>();
        bool DateOfJoiningFlag = false, DateExitFlag = false;
        bool InsertFlagJoingDate = false, InsertFlagExitDate = false;
        public ESSLData()
        {
            InitializeComponent();
            objDL.SetDesign3Buttons(this, lblHeader, btnESSLData, btnClear, btnExit, BusinessResources.LBL_HEADER_ESSLDATA);
            btnESSLData.Text = BusinessResources.BTN_ESSL;
            btnDelete.Text = BusinessResources.BTN_DELETE;
            // Fill_Database();
            objRL.Get_UserRights_By_MenuName(BusinessResources.LBL_HEADER_ESSLDATA);
        }

        private void Fill_Database()
        {
            //Database_ACCESS	ACCESS	
            // Database_MSSQL	MSSQL	
            // Database_MYSQL	MYSQL	

            cmbDatabase.Items.Clear();
            cmbDatabase.Items.Add(BusinessResources.Database_ACCESS);
            cmbDatabase.Items.Add(BusinessResources.Database_MSSQL);

            cmbDataType.Items.Clear();
            cmbDataType.Items.Add(BusinessResources.DataType_AttendanceLog);
            //cmbDataType.Items.Add(BusinessResources.DataType_EmployeeMaster);
        }

        private void FillGrid()
        {
            dataGridView1.DataSource = null;
            DataSet ds = new DataSet();
            ds = objQL.SP_AttendanceHistory_FillGrid();
            if (ds.Tables[0].Rows.Count > 0)
            {
                //0 AH.AttendanceHistoryId,
                //1 AH.EntryDate as 'Date', 
                //2 AH.FromDate as 'From Date',  
                //3 AH.ToDate as 'To Date',  
                //4 AH.DatabaseName  as 'Database Name',  
                //5 AH.DataType  as 'Data Type',  
                //6 E.EmployeeName as 'Inserted by'

                dataGridView1.DataSource = ds.Tables[0];

                lblTotalCount.Text = "Total Count-" + ds.Tables[0].Rows.Count.ToString();
                dataGridView1.Columns[0].Visible = false;

                dataGridView1.Columns[1].Width = 200;
                dataGridView1.Columns[2].Width = 200;
                dataGridView1.Columns[3].Width = 200;
                dataGridView1.Columns[4].Width = 200;
                dataGridView1.Columns[5].Width = 200;
                dataGridView1.Columns[6].Width = 200;
            }
        }

        private void ESSLRecords_Load(object sender, EventArgs e)
        {
            TotalCount = 0;
            lblTotalInserted.Text = "";
            ClearAll();
            FillGrid();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private bool CheckExist()
        {
            bool FlagReturn = false;
            try
            {
                DataSet ds = new DataSet();
                objPC.FromDate = dtpFromDate.Value;
                objPC.ToDate = dtpToDate.Value;
                objPC.DatabaseName = Database;
                objPC.DataType = DataType;
                ds = objQL.SP_AttendanceHistory_CheckExist();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["AttendanceHistoryId"].ToString())))
                    {
                        objPC.AttendanceHistoryId = Convert.ToInt32(ds.Tables[0].Rows[0]["AttendanceHistoryId"].ToString());
                        FlagReturn = true;
                    }
                    else
                        FlagReturn = false;
                }
            }
            catch (Exception ex)
            {
                // handle exception here
            }
            finally
            {
                //objBL.objCon.Close();
            }
            return FlagReturn;
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
            //else if (cmbDataType.SelectedIndex == -1)
            //{
            //    cmbDataType.Focus();
            //    objEP.SetError(cmbDataType, "Select ESSL Data Type");
            //    return true;
            //}
            else
                return false;
        }

        //progressBar1.Maximum = 100;
        //progressBar1.Step = 1;
        //progressBar1.Value = 0;
        //backgroundWorker1.RunWorkerAsync();
        //backgroundWorker1.WorkerReportsProgress = true;

        private void Calculate(int i)
        {
            double pow = Math.Pow(i, i);
        }

        private int SaveAttendanceHistory()
        {
            Result = 0;
            objPC.EntryDate = dtpDate.Value;
            objPC.FromDate = dtpFromDate.Value;
            objPC.ToDate = dtpToDate.Value;
            objPC.DatabaseName = Database;
            objPC.DataType = DataType;
            Result = objQL.SP_AttendanceHistory_Insert();
            return Result;
        }

        private void ClearAll()
        {
            progressBar1.Value = 0;
            FlagSave = false;
            objEP.Clear();
            TotalCount = 0;
            //lblTotalInserted.Text = "";
            //Fill_Database();
            dtpDate.Value = DateTime.Now.Date;
            dtpFromDate.Value = DateTime.Now.Date;
            dtpToDate.Value = DateTime.Now.Date;
            DataType = string.Empty;
            Database = string.Empty;
            cmbDatabase.SelectedIndex = -1;
            cmbDataType.SelectedIndex = -1;
            Fill_Database();
            btnDelete.Visible = false;
            dtpFromDate.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //backgroundWorker1.RunWorkerAsync();
            //backgroundWorker1.WorkerReportsProgress = true;
            lblTotalInserted.Text = "";
            ClearAll();
            // dataGridView1.Rows.Clear();
            FillGrid();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // TODO: do something with final calculation.
            //if(FlagInsert)
            //    GetReport();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //progressBar1.Value = e.ProgressPercentage;

            // Change the value of the ProgressBar   
            progressBar1.Value = e.ProgressPercentage;
            // Set the text.  
            this.Text = e.ProgressPercentage.ToString();
            //progressBar1.ResetText = e.ProgressPercentage.ToString();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {
                // Wait 50 milliseconds.  
                Thread.Sleep(50);
                // Report progress.  
                backgroundWorker1.ReportProgress(i);
            }

            //var backgroundWorker = sender as BackgroundWorker;
            //for (int j = 1; j < 100000; j++)
            //{
            //    Calculate(j);
            //    backgroundWorker.ReportProgress((j * 100) / 100000);
            //}
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            objEP.Clear();
            if (dtpToDate.Value.Date < dtpFromDate.Value.Date)
            {
                objEP.SetError(dtpToDate, "Select Proper Date");
                objRL.ShowMessage(17, 4);
                dtpToDate.Value = DateTime.Now.Date;
                return;
            }
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

        public void GetDatesBetween(DateTime startDate, DateTime endDate)
        {
            allDates = null; allDates = new List<DateTime>();
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                allDates.Add(date);

            if (allDates.Count == 0)
                allDates.Add(dtpFromDate.Value);
            //return allDates;
        }
        private void AttendanceRecords_FromESSL()
        {
            DateTime starting = new DateTime();
            starting = dtpFromDate.Value; // DateTime.ParseExact(dtpFromDate.Value, BusinessResources.DATEFORMATYYYYYMMDD, null);
            DateTime ending = new DateTime();
            ending = dtpToDate.Value; // DateTime.ParseExact(date2.Value, "dd-MM-yyyy", null);
            GetDatesBetween(starting, ending);

            DataSet dsEmployee = new DataSet();
            //objBL.Query = "select * from employees where CancelTag=0 and Status='WORKING' and DOJ<='" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' order by EmployeeCode asc";
            //objBL.Query = "select * from employees where CancelTag=0 and Status='WORKING' order by EmployeeCode asc";
            //objBL.Query = "select * from employees where CancelTag=0 and Status='WORKING' and NewFlag=0 and EmployeeCode NOT IN(50002,50003,50004,50005,50006,50007,50008,50009,50010,100001,100004) order by EmployeeCode asc";

            //if (objPC.LocationName != "Default" && objPC.DepartmentName != "DEFAULT")
            //{

            //}

            //objBL.Query = "select * from employees where CancelTag=0 and Status='WORKING' and NewFlag=0 and EmployeeCode NOT IN(50002,50003,50004,50005,50006,50007,50008,50009,50010,100001,100004) order by EmployeeCode asc";

            //objBL.Query = "select E.* from employees E inner join locationmaster LM on LM.LocationId=E.LocationId inner join departmentmaster DM on DM.DepartmentId=E.DepartmentId  where E.CancelTag=0 and LM.CancelTag=0 and DM.CancelTag=0 and E.Status='WORKING' and LM.LocationName NOT IN('All','Default') and DM.Department NOT IN('All','DEFAULT') and E.NewFlag=0 and E.EmployeeCode NOT IN(50002,50003,50004,50005,50006,50007,50008,50009,50010,50011,50012,50013,50014,50015,50016,50017,50018,50019,50020,100001,100002,100003,100004) order by EmployeeCode asc";
            objBL.Query = "select E.* from employees E inner join locationmaster LM on LM.LocationId=E.LocationId inner join departmentmaster DM on DM.DepartmentId=E.DepartmentId  where E.CancelTag=0 and LM.CancelTag=0 and DM.CancelTag=0 and E.Status='WORKING' and LM.LocationName NOT IN('All','Default') and DM.Department NOT IN('All','DEFAULT') and E.NewFlag=0 and "+
                          "E.EmployeeCode NOT IN" +
                          "(100001,100004,50002,50003,50004,50005,50006,50007,50008,50009,50010,50011,50013,50014,50015,50016,50017,50018,50019,50020,50012,50021,50022,50023,50024,50025,50026,50027,50028) " +
                          "order by EmployeeCode asc";

            dsEmployee = objBL.ReturnDataSet();

            if (dsEmployee.Tables[0].Rows.Count > 0)
            {
                progressBar1.Maximum = dsEmployee.Tables[0].Rows.Count;
                progressBar1.Minimum = 0;
                progressBar1.Step = 1;
                progressBar1.Style = ProgressBarStyle.Blocks;
                TotalCount = dsEmployee.Tables[0].Rows.Count;

                //329
                for (int i = 0; i < dsEmployee.Tables[0].Rows.Count; i++)
                {
                    //if (i == 255)
                    //{
                    //    MessageBox.Show("Found");
                    //}

                    objPC.ClearAttendanceRecords();

                    ClearEmployeeDetails();

                    DateOfJoiningFlag = false;
                    InsertFlagJoingDate = false;
                    DateExitFlag = false;
                    InsertFlagExitDate = false;

                    EmployeeCode = string.Empty;

                    objPC.EmployeeCode = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dsEmployee.Tables[0].Rows[i]["EmployeeCode"])));
                    objPC.EmployeeId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dsEmployee.Tables[0].Rows[i]["EmployeeId"])));
                    objPC.LocationId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dsEmployee.Tables[0].Rows[i]["LocationId"])));
                    objPC.DepartmentId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dsEmployee.Tables[0].Rows[i]["DepartmentId"])));
                    objPC.ShiftGroupId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dsEmployee.Tables[0].Rows[i]["ShiftGroupId"])));
                    objPC.CategoryId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dsEmployee.Tables[0].Rows[i]["CategoryId"])));
                    objPC.DesignationId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dsEmployee.Tables[0].Rows[i]["DesignationId"])));
                    objPC.Status = objRL.CheckNullString(Convert.ToString(dsEmployee.Tables[0].Rows[i]["Status"]));
                    objPC.OverTimeApplicable = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dsEmployee.Tables[0].Rows[i]["OverTimeApplicable"])));

                    //if (objPC.LocationId == 1)
                    //{
                    //}
                    //objRL.Get_Designation_Details_By_DesignationId(objPC.DesignationId);

                    objRL.Get_CategoriesDetails_By_Id();

                    //if (objPC.EmployeeCode == 598) // || objPC.EmployeeCode == 547 || objPC.EmployeeCode == 548 || objPC.EmployeeCode == 561)
                    //{
                    //    MessageBox.Show("Found-" + objPC.EmployeeCode);
                    //}

                    //if (objPC.EmployeeCode == 10360 || objPC.EmployeeCode == 10361 || objPC.EmployeeCode == 10362 || objPC.EmployeeCode == 10363 || objPC.EmployeeCode == 10366)
                    //{
                    //    MessageBox.Show("Found" + objPC.EmployeeCode);
                    //}

                    //619
                    //637
                    //5199

                    //523

                    //if (objPC.EmployeeCode == 2508) // || objPC.EmployeeCode == 547 || objPC.EmployeeCode == 548 || objPC.EmployeeCode == 561)
                    //{
                    //    MessageBox.Show("Found-" + objPC.EmployeeCode);
                    //}

                    //if (objPC.EmployeeCode == 501 || objPC.EmployeeCode == 547 || objPC.EmployeeCode == 548 || objPC.EmployeeCode == 561)
                    //{
                    //    MessageBox.Show("Found-" + objPC.EmployeeCode);
                    //}

                    //if (objPC.EmployeeCode == 19) // || objPC.EmployeeCode == 10361 || objPC.EmployeeCode == 10362 || objPC.EmployeeCode == 10363 || objPC.EmployeeCode == 10366)
                    //{
                    //    MessageBox.Show("Found" + objPC.EmployeeCode);
                    //}


                    //if (objPC.EmployeeCode == 50007) // || objPC.EmployeeCode == 10361 || objPC.EmployeeCode == 10362 || objPC.EmployeeCode == 10363 || objPC.EmployeeCode == 10366)
                    //{
                    //    MessageBox.Show("Found" + objPC.EmployeeCode);
                    //}


                    //if (objPC.EmployeeCode == 598) //598//741 || objPC.EmployeeCode == 10361 || objPC.EmployeeCode == 10362 || objPC.EmployeeCode == 10363 || objPC.EmployeeCode == 10366)
                    //{
                    //    MessageBox.Show("Found" + objPC.EmployeeCode);
                    //}

                    //595 15 708
                    //if (objPC.EmployeeCode == 666 || objPC.EmployeeCode == 708 || objPC.EmployeeCode == 595)
                    //{
                    //    MessageBox.Show("Found" + objPC.EmployeeCode);
                    //}

                    //2508 2721
                    //if (objPC.EmployeeCode == 2508 || objPC.EmployeeCode == 2615 || objPC.EmployeeCode == 2721)
                    //{
                    //    MessageBox.Show("Found" + objPC.EmployeeCode);
                    //}

                    //SACHIN SAVATA LADKAT
                    //                    264
                    //650062

                    //if (objPC.EmployeeCode == 650062) // || objPC.EmployeeCode == 2615 || objPC.EmployeeCode == 2721)
                    //{
                    //    MessageBox.Show("Found" + objPC.EmployeeCode);
                    //}

                    if (!string.IsNullOrEmpty(Convert.ToString(dsEmployee.Tables[0].Rows[i]["DOJ"].ToString())))
                    {
                        DateOfJoiningFlag = true;
                        objPC.DateOfJoining = Convert.ToDateTime(dsEmployee.Tables[0].Rows[i]["DOJ"].ToString());
                    }
                    else
                    {
                        DateOfJoiningFlag = false;
                        InsertFlagJoingDate = false;
                    }

                    if (!string.IsNullOrEmpty(Convert.ToString(dsEmployee.Tables[0].Rows[i]["DateOfExit"].ToString())))
                    {
                        DateExitFlag = true;
                        objPC.DateOfExit = Convert.ToDateTime(dsEmployee.Tables[0].Rows[i]["DateOfExit"].ToString());
                    }
                    else
                    {
                        DateExitFlag = false;
                        InsertFlagExitDate = true;
                    }

                    if (allDates.Count > 0)
                    {
                        //if (objPC.EmployeeCode == 544)
                        //{
                        //    MessageBox.Show("Found");
                        //}

                        for (int j = 0; j < allDates.Count; j++)
                        {
                            DataSet ds = new DataSet();
                            objPC.AttendanceDate = Convert.ToDateTime(allDates[j]);
                            objPC.AttendanceDay = objPC.AttendanceDate.DayOfWeek.ToString();

                            if (DateOfJoiningFlag)
                            {
                                if (objPC.DateOfJoining <= objPC.AttendanceDate)
                                    InsertFlagJoingDate = true;
                                else
                                    InsertFlagJoingDate = false;
                            }
                            else
                                InsertFlagJoingDate = false;

                            if (DateExitFlag)
                            {
                                if (objPC.DateOfExit >= objPC.AttendanceDate)
                                    InsertFlagExitDate = true;
                                else
                                    InsertFlagExitDate = false;
                            }//DateExitFlag
                            //else
                            //    InsertFlagExitDate = false;

                            if (InsertFlagJoingDate && InsertFlagExitDate)
                            {

                                //if (objPC.EmployeeCode == 501 || objPC.EmployeeCode == 547 || objPC.EmployeeCode == 548 || objPC.EmployeeCode == 561)
                                //{
                                //    MessageBox.Show("Found-" + objPC.EmployeeCode);
                                //}

                                //if (objPC.EmployeeCode == 556)
                                //{
                                //    MessageBox.Show("Found");
                                //}

                                string msgDisplay = string.Empty;

                                //if (objPC.EmployeeCode == 10360)
                                //{
                                //    msgDisplay = "Found-" + objPC.EmployeeCode + System.Environment.NewLine +
                                //                 "Connection-"+objBL.conStringEssl+System.Environment.NewLine+
                                //                 "ds-" + ds.Tables[0].Rows[0][0].ToString() + System.Environment.NewLine +"";

                                //    MessageBox.Show(msgDisplay);
                                //}


                                //if (objPC.EmployeeCode == 5210)
                                //{
                                //    MessageBox.Show("Found");

                                //}

                                //if (objPC.LocationName != "Default" && objPC.DepartmentName != "DEFAULT")
                                //{

                                //}

                                objAL.Check_ARM();

                                //bool CheckFlag = false;

                                //DataSet dsARM = new DataSet();
                                //objPC.CompleteFlag = 0;
                                //objPC.AttendanceRecordMasterId = 0; //Convert.ToInt32(objCmd.ExecuteScalar());
                                //objPC.EntryDate = DateTime.Now.Date;
                                //dsARM = objQL.SP_AttendanceRecordMaster_CheckExist();
                                //CheckFlag = false;

                                //if (dsARM.Tables[0].Rows.Count > 0)
                                //{
                                //    if (!string.IsNullOrEmpty(Convert.ToString(dsARM.Tables[0].Rows[0]["AttendanceRecordMasterId"].ToString())))
                                //    {
                                //        objPC.AttendanceRecordMasterId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dsARM.Tables[0].Rows[0]["AttendanceRecordMasterId"])));
                                //        objPC.ApprovalStatusId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dsARM.Tables[0].Rows[0]["ApprovalStatusId"])));
                                //        objPC.AttendanceStatus = objRL.CheckNullString(Convert.ToString(dsARM.Tables[0].Rows[0]["AttendanceStatus"]));
                                //        CheckFlag = true;
                                //    }
                                //}

                                //if (objPC.ApprovalStatusId != 2)
                                if (objPC.AttendanceStatus != BusinessResources.LS_Completed)
                                {
                                    if (!objPC.CheckFlagARM)
                                    {
                                        objPC.ApprovalStatusId = 1;
                                        objRL.Get_Incharge_Senior_OfficerId();
                                        objPC.AttendanceRecordMasterId = objQL.SP_AttendanceRecordMaster_CheckExist_Insert();
                                    }

                                    if (objPC.AttendanceRecordMasterId != 0)
                                    {
                                        //Insert into AttendanceRecord
                                        //1st Check Exist if record is not available then insert 
                                        //If exist show time

                                        objPC.AttendanceRecordId = 0;

                                        if (objQL.SP_AttendanceRecord_CheckExist())
                                            objPC.AttendanceRecordId = 0;

                                        //if (objPC.EditFlag == 1)
                                        //{
                                        //    MessageBox.Show("Found Edit Flag");
                                        //}


                                        if (objPC.EditFlag == 0)
                                        {
                                            objAL.Clear_Attendance();

                                            if (cmbDatabase.Text == BusinessResources.Database_ACCESS)
                                                objBL.Query = "select AL.*,E.* from AttendanceLogs AL inner join Employees E on E.EmployeeId=AL.EmployeeId where E.EmployeeCode='" + objPC.EmployeeCode + "' and E.RecordStatus=1 and E.Status='Working' and AL.AttendanceDate=#" + objPC.AttendanceDate.ToString(BusinessResources.DATEFORMATMMDDYYYY) + "# order by AL.AttendanceDate desc";
                                            //objBL.Query = "select AL.*,E.* from AttendanceLogs AL inner join Employees E on E.EmployeeId=AL.EmployeeId where E.EmployeeCode='" + objPC.EmployeeCode + "' and E.RecordStatus=1 and E.Status='Working' and AL.AttendanceDate=#" + objPC.AttendanceDate.ToString(BusinessResources.DATEFORMATMMDDYYYY) + "# order by AL.AttendanceDate desc";
                                            else
                                                objBL.Query = "select AL.*,E.* from AttendanceLogs AL inner join Employees E on E.EmployeeId=AL.EmployeeId where E.EmployeeCode='" + objPC.EmployeeCode + "' and E.RecordStatus=1 and E.Status='Working' and AL.AttendanceDate='" + objPC.AttendanceDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' order by AL.AttendanceDate desc";

                                            ds = objBL.ReturnDataSet_ESSL(cmbDatabase.Text);

                                            if (ds.Tables[0].Rows.Count > 0)
                                            {
                                                objPC.EntryDate = DateTime.Now.Date;
                                                objPC.EsslAttendanceLogsId = Convert.ToInt32(ds.Tables[0].Rows[0]["attendancelogid"]);

                                                if (cmbDatabase.Text == BusinessResources.Database_ACCESS)
                                                    objPC.ESSLEmployeeId = Convert.ToInt32(ds.Tables[0].Rows[0]["E.EmployeeId"]);
                                                else
                                                    objPC.ESSLEmployeeId = Convert.ToInt32(ds.Tables[0].Rows[0]["EmployeeId"]);

                                                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["InTime"].ToString())))
                                                    objPC.InTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["InTime"]);
                                                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["OutTime"].ToString())))
                                                    objPC.OutTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["OutTime"]);

                                                objPC.StatusCode = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["StatusCode"]));
                                                objPC.PunchRecords = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["PunchRecords"]));

                                                objPC.MissedOutPunch = 0;
                                                objPC.MissedInPunch = 0;

                                                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["MissedOutPunch"])))
                                                {
                                                    string MIOut = Convert.ToString(ds.Tables[0].Rows[0]["MissedOutPunch"]);

                                                    if (cmbDatabase.Text == BusinessResources.Database_ACCESS)
                                                    {
                                                        if (MIOut == "False")
                                                            objPC.MissedOutPunch = 0;
                                                        else
                                                            objPC.MissedOutPunch = 1;
                                                    }
                                                    else
                                                        objPC.MissedOutPunch = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["MissedOutPunch"])));
                                                }

                                                ////objPC.AttendanceDate
                                                //if (objPC.EmployeeCode == 556)
                                                //{
                                                //    MessageBox.Show("Found");
                                                //}


                                                if (objPC.MissedOutPunch < 0)
                                                {
                                                    objPC.MissedOutPunch = 1;
                                                    objPC.StatusCode = "MOP";
                                                }

                                                //objAL.AttendanceWorking();

                                                ////objRL.Attendance_Working1();

                                                //objPC.UserId = Convert.ToInt32(BusinessLayer.EmployeeLoginId_Static);

                                                //Result = objQL.SP_AttendanceRecord_Insert_Update();

                                                //if (Result > 0)
                                                //{
                                                //    if (objPC.AttendanceRecordId == 0)
                                                //        objPC.AttendanceRecordId = objRL.ReturnMaxID_Fix("attendancerecord", "AttendanceRecordId");

                                                //    objAL.Save_AttendanceMonthlyData();
                                                //    objPC.AttendanceRecordId = 0;
                                                //}//Result
                                            }//ds
                                            else
                                            {
                                                objAL.Clear_Attendance();
                                                objAL.Absent_Shift();
                                            }


                                            objPC.LeaveTypeFlag = false;

                                            if (objPC.MissedOutPunch == 0)
                                                objAL.AttendanceWorking();

                                            if (objPC.ShiftId == 0)
                                            {
                                                objPC.ShiftFName = "NoShift";
                                                objAL.Get_Shift_Details_ByName_ById("Name", "NoShift");
                                            }

                                            //objRL.Attendance_Working1();

                                            objPC.UserId = Convert.ToInt32(BusinessLayer.EmployeeLoginId_Static);
                                            objPC.OutDoorEntryFlag = 0;
                                            //objAL.Check_ARM();

                                            Result = objQL.SP_AttendanceRecord_Insert_Update();

                                            if (Result > 0)
                                            {
                                                if (objPC.AttendanceRecordId == 0)
                                                    objPC.AttendanceRecordId = objRL.ReturnMaxID_Fix("attendancerecord", "AttendanceRecordId");

                                                objAL.Save_AttendanceMonthlyData();
                                                objPC.AttendanceRecordId = 0;
                                            }//Result

                                        }
                                    }
                                }
                            } //InsertFlagExitDate
                        }
                    }
                    progressBar1.Value = i;
                    Thread.Sleep(50);
                    progressBar1.BeginInvoke(new Action(() => progressBar1.Value = i));
                    progressBar1.CreateGraphics().DrawString("Total Inserted- " + i.ToString() + " / " + TotalCount, new Font("Calibri",
                    (float)10.25, FontStyle.Bold),
                    Brushes.Red, new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));
                    int TCount = i + 1;
                    lblTotalInserted.Text = "Total Inserted Records- " + TotalCount + " / " + TCount.ToString();
                }

                objAL.Set_Manpower_Count(dtpFromDate.Value, dtpToDate.Value);

                objRL.ShowMessage(34, 1);

            }
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

        private void Employee_Insert_Database()
        {
            objPC.NewEmpCount = 0; objPC.NewFlag = 0; objPC.FlagC = 0;
            EmployeeCodeConcat = string.Empty;
            try
            {
                DataSet dsS = new DataSet();
                //objBL.Query = "select * from Employees where CancelTag=0 and Status='Working'";
                objBL.Query = "select * from Employees where CancelTag=0 order by EmployeeCode asc";
                dsS = objBL.ReturnDataSet();
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

                if (dsS.Tables.Count > 0 && dsS.Tables[0].Rows.Count > 0)
                {
                    EmployeeCodeConcat = string.Join(",",
                        dsS.Tables[0].AsEnumerable()
                        .Where(r => !string.IsNullOrEmpty(r["EmployeeCode"].ToString()))
                        .Select(r => $"'{r["EmployeeCode"]}'")
                    );
                }

                //EmployeeCodeConcat = EmployeeCodeConcat.Remove(EmployeeCodeConcat.Length - 1);
                EmployeeCodeConcat = R1 + EmployeeCodeConcat + R2;
                string WhereQ = " RecordStatus=1 and Status='Working' and EmployeeCode NOT IN " + EmployeeCodeConcat;

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
                        objPC.ESSLEmployeeId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmployeeId"])));
                        objPC.EmployeeCode = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmployeeCode"])));
                        objPC.EmployeeName = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmployeeName"]));
                        objPC.Status = "WORKING";
                        objPC.ContractorId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(objQL.SP_Get_All_TableId_By_Name("contractormaster", DefaultV))));
                        objPC.LocationId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(objQL.SP_Get_All_TableId_By_Name("locationmaster", DefaultV))));
                        objPC.DepartmentId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(objQL.SP_Get_All_TableId_By_Name("DepartmentMaster", DefaultV))));
                        objPC.DesignationId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(objQL.SP_Get_All_TableId_By_Name("designationmaster", DefaultV))));
                        objPC.CategoryId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(objQL.SP_Get_All_TableId_By_Name("categories", DefaultV))));
                        objPC.ShiftGroupId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(objQL.SP_Get_All_TableId_By_Name("shiftgroups", DefaultV))));
                        objPC.EmployementTypeId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(objQL.SP_Get_All_TableId_By_Name("employementtypemaster", DefaultV))));

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!Validation() && TableId != 0)
            {
                DialogResult dr;
                dr = objRL.Delete_Record_Show_Message();
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    objBL.Query = "delete from attendancehistory where AttendanceHistoryId=" + TableId + "";
                    Result = objBL.Function_ExecuteNonQuery();

                    objBL.Query = "delete from attendancelogs where AttendanceHistoryId=" + TableId + "";
                    Result = objBL.Function_ExecuteNonQuery();

                    objBL.Query = "delete from attendancerecordmaster where AttendanceHistoryId=" + TableId + "";
                    Result = objBL.Function_ExecuteNonQuery();

                    objBL.Query = "delete from attendancerecord where AttendanceHistoryId=" + TableId + "";
                    Result = objBL.Function_ExecuteNonQuery();

                    objBL.Query = "delete from attendancemonthlydata where AttendanceHistoryId=" + TableId + "";
                    Result = objBL.Function_ExecuteNonQuery();

                    //objBL.Query = "delete from attendancelogs where AttendanceDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";
                    //Result = objBL.Function_ExecuteNonQuery();

                    if (DataType == BusinessResources.DataType_AttendanceLog)   //Employee Master
                    {
                        if (cmbDatabase.Text == BusinessResources.Database_ACCESS)
                        {
                            objBL.Query = "Update AttendanceLogs set Flag=0 where Flag=1 and AttendanceDate > #" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATMMDDYYYY) + "#";
                            Result = objBL.Function_ExecuteNonQuery();
                        }
                        else
                        {
                            objBL.Query = "Update AttendanceLogs set Flag=0 where Flag=1 and AttendanceDate > " + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATMMDDYYYY) + "";
                            Result = objBL.Function_ExecuteNonQuery();
                        }
                    }

                    objRL.ShowMessage(9, 1);

                    //if (Result > 0)
                    //    objRL.ShowMessage(9, 1);
                    //else
                    //    objRL.ShowMessage(35, 4);

                    ClearAll();
                    FillGrid();
                }
                else
                {
                    ClearAll();
                }
            }
        }

        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0;

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                RowCount_Grid = dataGridView1.Rows.Count;
                CurrentRowIndex = dataGridView1.CurrentRow.Index;

                if (RowCount_Grid >= 0 && CurrentRowIndex >= 0)
                {
                    ClearAll();

                    //0 AH.AttendanceHistoryId,
                    //1 AH.EntryDate as 'Date', 
                    //2 AH.FromDate as 'From Date',  
                    //3 AH.ToDate as 'To Date',  
                    //4 AH.DatabaseName  as 'Database Name',  
                    //5 AH.DataType  as 'Data Type',  
                    //6 E.EmployeeName as 'Inserted by'

                    btnDelete.Visible = true;
                    TableId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                    dtpDate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                    dtpFromDate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                    dtpToDate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                    cmbDatabase.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    cmbDataType.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                }
            }
            catch (Exception ex1)
            {
                objRL.ErrorMessge(ex1.ToString());
                return;
            }
            finally
            {
                GC.Collect();
            }
        }

        private void btnESSLData_Click(object sender, EventArgs e)
        {
            if (objPC.AddFlag == 1)
            {
                try
                {
                    if (!Validation())
                    {
                        objPC.LeaveTypeFlag = false;
                        objPC.NewEmpCount = 0;
                        Employee_Insert_Database();
                        CheckExistNewEmployee();

                        if (objPC.NewEmpCount == 0)
                            AttendanceRecords_FromESSL();
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


        //objPC.InDeviceId = Convert.ToString(ds.Tables[0].Rows[i]["InDeviceId"]);
        //objPC.OutDeviceId = Convert.ToString(ds.Tables[0].Rows[i]["OutDeviceId"]);
        //objPC.Duration = Convert.ToString(ds.Tables[0].Rows[i]["Duration"]);
        //objPC.LateBy = Convert.ToInt32(ds.Tables[0].Rows[i]["LateBy"]);
        //objPC.EarlyBy = Convert.ToInt32(ds.Tables[0].Rows[i]["EarlyBy"]);
        //objPC.IsOnLeave = Convert.ToString(ds.Tables[0].Rows[i]["IsOnLeave"]);
        //objPC.LeaveType = Convert.ToString(ds.Tables[0].Rows[i]["LeaveType"]);
        //objPC.LeaveDuration = Convert.ToInt32(ds.Tables[0].Rows[i]["LeaveDuration"]);
        //objPC.WeeklyOff = Convert.ToInt32(ds.Tables[0].Rows[i]["WeeklyOff"]);
        //objPC.Holiday = Convert.ToInt32(ds.Tables[0].Rows[i]["Holiday"]);
        //objPC.LeaveRemarks = Convert.ToString(ds.Tables[0].Rows[i]["LeaveRemarks"]);
        //objPC.PunchRecords = Convert.ToString(ds.Tables[0].Rows[i]["PunchRecords"]);
        //objPC.ShiftId = Convert.ToInt32(ds.Tables[0].Rows[i]["ShiftId"]);
        //objPC.Present = Convert.ToDouble(ds.Tables[0].Rows[i]["Present"]);
        //objPC.Absent = Convert.ToDouble(ds.Tables[0].Rows[i]["Absent"]);
        //objPC.Status = Convert.ToString(ds.Tables[0].Rows[i]["Status"]);
        //objPC.StatusCode = Convert.ToString(ds.Tables[0].Rows[i]["StatusCode"]);
        //objPC.P1Status = Convert.ToString(ds.Tables[0].Rows[i]["P1Status"]);
        //objPC.P2Status = Convert.ToString(ds.Tables[0].Rows[i]["P2Status"]);
        //objPC.P3Status = Convert.ToString(ds.Tables[0].Rows[i]["P3Status"]);
        //objPC.IsonSpecialOff = Convert.ToString(ds.Tables[0].Rows[i]["IsonSpecialOff"]);
        //objPC.SpecialOffType = Convert.ToString(ds.Tables[0].Rows[i]["SpecialOffType"]);
        //objPC.SpecialOffRemark = Convert.ToString(ds.Tables[0].Rows[i]["SpecialOffRemark"]);
        //objPC.SpecialOffDuration = Convert.ToString(ds.Tables[0].Rows[i]["SpecialOffDuration"]);
        //objPC.OverTime = Convert.ToString(ds.Tables[0].Rows[i]["OverTime"]);
        //objPC.OverTimeE = Convert.ToInt32(ds.Tables[0].Rows[i]["OverTimeE"]);
        //objPC.MissedOutPunch = Convert.ToString(ds.Tables[0].Rows[i]["MissedOutPunch"]);
        //objPC.MissedInPunch = Convert.ToString(ds.Tables[0].Rows[i]["MissedInPunch"]);
        //objPC.C1 = Convert.ToString(ds.Tables[0].Rows[i]["C1"]);
        //objPC.C2 = Convert.ToString(ds.Tables[0].Rows[i]["C2"]);
        //objPC.C3 = Convert.ToString(ds.Tables[0].Rows[i]["C3"]);
        //objPC.C4 = Convert.ToString(ds.Tables[0].Rows[i]["C4"]);
        //objPC.C5 = Convert.ToString(ds.Tables[0].Rows[i]["C5"]);
        //objPC.C6 = Convert.ToString(ds.Tables[0].Rows[i]["C6"]);
        //objPC.C7 = Convert.ToString(ds.Tables[0].Rows[i]["C7"]);
        //objPC.Remarks = Convert.ToString(ds.Tables[0].Rows[i]["Remarks"]);
        //objPC.LeaveTypeId = Convert.ToInt32(ds.Tables[0].Rows[i]["LeaveTypeId"]);
        //objPC.LossOfHours = Convert.ToInt32(ds.Tables[0].Rows[i]["LossOfHours"]);


        //objPC.AttendanceRecordMasterId, 
        //objPC.AttendanceHistoryId,
        //objPC.EsslAttendanceLogsId,
        //objPC.EmployeeId, 
        //objPC.ShiftId,
        //objPC.ShiftGroupId,
        //objPC.InTime,
        //objPC.OutTime,
        //objPC.Duration, 
        //objPC.OverTime, 
        //objPC.TotalDuration, 
        //objPC.Status, 
        //objPC.LateBy,
        //objPC.EarlyBy,
        //objPC.MissedInPunch,
        //objPC.MissedOutPunch,
        //objPC.ChangeDepartmentFlag,
        //objPC.ChangeDepartmentId,
        //objPC.ChangeLocationtId,
        //objPC.IsOnLeave,
        //objPC.LeaveTypeId,
        //objPC.LeaveDuration,
        //objPC.WeeklyOff,
        //objPC.Holiday,
        //objPC.LeaveRemarks,
        //objPC.PunchRecords,
        //objPC.LossOfHours,
        //objPC.Present,
        //objPC.Absent
        //objPC.UserId
    }
}
