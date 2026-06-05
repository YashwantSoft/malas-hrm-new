using BusinessLayerUtility;
using SPApplication.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPApplication.Transaction
{
    public partial class CompOffApplication : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0;

        string EmpDesignation = string.Empty;
        string EmpDepartment = string.Empty;

        int SearchId = 0, LocationId = 0;

        string WeeklyOffDay = string.Empty;

        public CompOffApplication()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_COMPOFFAPPLICATION);
            ClearAll();
            //objQL.Fill_Master_ComboBox(cmbLeaveType, "leavetypes");
            objRL.FillLocation(cmbLocation, cmbDepartment);
            objRL.Fill_LeaveType(cmbLeaveType,false);
            FillEmployee_Fixed();
        }
        private void ClearAll_Location_Department()
        {
            cmbEmployeeName.SelectedIndex = -1;
            txtEmployeeCode.Text = "";
            txtDesignation.Text = "";
             
            cmbLeaveType.SelectedIndex = -1;
            txtCompOffReason.Text = "";
            txtWorkingRemarks.Text = "";
            rtbLeaveRecords.Text = "";
        }
        private void ClearAll()
        {
            TableId = 0;
            objEP.Clear();
            WeeklyOffDay = string.Empty;
            cmbLocation.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            cmbEmployeeName.SelectedIndex = -1;
            txtEmployeeCode.Text = "";
            txtDesignation.Text = "";
            cmbLeaveType.SelectedIndex = -1;
            dgvHolidayList.Rows.Clear();
            gbWorkingRemarks.Visible = false;
            txtWorkingRemarks.Text = "";
            txtCompOffReason.Text = "";

            objPC.IsCompensationOff = 0;
            objPC.IsRevertLeave = 0;

            dtpDate.Value = DateTime.Now.Date;
            cmbLeaveType.SelectedIndex = -1;
            txtCompOffReason.Text = "";
            
            rtbLeaveRecords.Text = "";
           
            ClearAll_Location_Department();
            objPC.IsCompensationOff = 0;
            objPC.IsRevertLeave = 0;
            objPC.CompOffUsedFlag = 0;

            gbCompOffDetails.Visible = false;

            objPC.CompOffUsedFlag = 0;
            dtpUsedCompOffDate.Value = DateTime.Now.Date;
            txtUsedCompOffDay.Text = "";

            gbCompOffUsedDetails.Visible = false;
            gbCompOffDetails.Enabled = true;
            gbWorkingRemarks.Enabled = false;
            gbCompOffUsedDetails.Enabled = true;
        }

        private void CompOffApplication_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        List<string> weekendList = new List<string>();

        public void GetWeekendDates(DateTime startDate, DateTime endDate)
        {
            weekendList = new List<string>();
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek.ToString() == WeeklyOffDay) //  DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)
                    weekendList.Add(date.ToShortDateString());
            }
            //return weekendList;
        }
        private void FillEmployee_Fixed()
        {
            //FillEmployees_Combobox();
            ClearAll_Location_Department();

            if (cmbLocation.SelectedIndex > -1 && cmbDepartment.SelectedIndex > -1)
            {
                objQL.WhereClause_V = " and E.LocationId=" + cmbLocation.SelectedValue + "  and E.DepartmentId=" + cmbDepartment.SelectedValue + " and DM.DesignationCategory NOT IN('" + BusinessResources.USER_TYPE_TRAINEE + "','" + BusinessResources.USER_TYPE_WORKER + "')";
                objQL.SP_Employees_Get_By_All(cmbEmployeeName);

                if (BusinessLayer.UserType == BusinessResources.USER_TYPE_OFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_SUPERVISOR)
                {
                    cmbEmployeeName.Enabled = false;
                    cmbEmployeeName.Text = BusinessLayer.UserName_Full_Static;
                    //objRL.Fill_EmployeeDetails();
                    Fill_EmployeeDetails();
                }
                else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER)
                {
                    //8,17,5076,23,41,19,55,100001,100002
                    //if (BusinessLayer.UserName_Static == "8" || BusinessLayer.UserName_Static == "17" || BusinessLayer.UserName_Static == "19" || BusinessLayer.UserName_Static == "23" || BusinessLayer.UserName_Static == "41" || BusinessLayer.UserName_Static == "55" || BusinessLayer.UserName_Static == "5076" || BusinessLayer.UserName_Static == "100001" || BusinessLayer.UserName_Static == "100002")
                    //{
                        objQL.SP_Employees_ComboBox_By_Department(cmbEmployeeName);
                        cmbEmployeeName.Text = BusinessLayer.UserName_Full_Static.ToString();
                        cmbEmployeeName.Enabled = false;
                        Fill_EmployeeDetails();
                    //}
                    //BusinessLayer.Designation
                }
                else
                {
                }
                //objRL.FillEmployees();
            }
        }

        private void FillEmployee_Fixed_CompOff()
        {
            //FillEmployees_Combobox();
            ClearAll_Location_Department();

            if (cmbLocation.SelectedIndex > -1 && cmbDepartment.SelectedIndex > -1)
            {
                objQL.WhereClause_V = " and E.OverTimeApplicable=0 and E.LocationId=" + cmbLocation.SelectedValue + "  and E.DepartmentId=" + cmbDepartment.SelectedValue + " and DM.DesignationCategory NOT IN('" + BusinessResources.USER_TYPE_TRAINEE + "','" + BusinessResources.USER_TYPE_WORKER + "')";
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

        private void Fill_EmployeeDetails()
        {
            txtEmployeeCode.Text = "";
            txtDesignation.Text = "";
            if (cmbEmployeeName.SelectedIndex > -1)
            {
                objPC.SearchFlagLeaveCompOff = false;
                objPC.EmployeeId = Convert.ToInt32(cmbEmployeeName.SelectedValue);
                objRL.Fill_EmployeeDetails();
                txtEmployeeCode.Text = objPC.EmployeeCode.ToString();
                txtDesignation.Text = objPC.Designation.ToString();
                objRL.Get_Leaves_Count_All();
                objPC.SearchFlagLeaveCompOff = true;
                objRL.Get_CompOff_Count_All();
                objRL.Fill_Leave_RichTextBox(rtbLeaveRecords);
                txtWeeklyOff.Text = objPC.WeeklyOff1Value;
                WeeklyOffDay = objPC.WeeklyOff1Value;
            }
        }

        private void cmbLeaveType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_Holiday_List();
        }

        private void cmbEmployeeName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_EmployeeDetails();
        }

        DateTime HolidayDate_I;
        string HolidayDay_I = string.Empty, Festival_I = string.Empty, HolidayType_I = string.Empty;
        int NationalHolidayFlag_I;

        private void Fill_Holiday_List()
        {
            if(cmbLeaveType.SelectedIndex >-1)
            {
                if (cmbLeaveType.Text == "Compensation Off")
                {
                    objBL.Query = "delete from tempholiday";
                    Result = objBL.Function_ExecuteNonQuery();

                    DataSet ds = new DataSet();
                    //objBL.Query = "select * from holidaymaster where HolidayDate >='" + DateTime.Now.Date.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and CancelTag=0";
                    objBL.Query = "select * from holidaymaster where CancelTag=0 order by HolidayDate";
                    ds = objBL.ReturnDataSet();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            HolidayDay_I = string.Empty; Festival_I = string.Empty; NationalHolidayFlag_I = 0; HolidayType_I = string.Empty;

                            HolidayDate_I = Convert.ToDateTime(ds.Tables[0].Rows[i]["HolidayDate"]);
                            HolidayDay_I = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["HolidayDay"]));
                            Festival_I = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["Festival"]));
                            NationalHolidayFlag_I = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["NationalHolidayFlag"])));

                            if (NationalHolidayFlag_I == 1)
                                HolidayType_I = "National";
                            else
                                HolidayType_I = "Regional";

                            if(Festival_I.Contains("'"))
                            {
                                //Festival_I = "'" + Festival_I.Replace("'", "''") + "'";

                                Festival_I = Festival_I.Replace("'", "''");
                            }
                            //Festival_I= "'" + Festival_I.Replace("'", "''") + "'";
                            objBL.Query = "insert into TempHoliday(HolidayDate,HolidayDay,Festival,HolidayType,NationalHolidayFlag) values('" + HolidayDate_I.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "','" + HolidayDay_I + "','" + Festival_I + "','" + HolidayType_I + "'," + NationalHolidayFlag_I + ")";
                            Result = objBL.Function_ExecuteNonQuery();
                        }
                    }

                    //GetWeekendDates(DateTime.Now.Date.AddMonths(-2), DateTime.Now.Date.AddYears(1));
                    //GetWeekendDates(DateTime.Now.Date.AddMonths(-1), DateTime.Now.Date.AddYears(1));
                    
                    GetWeekendDates(DateTime.Now.Date.AddMonths(-2), DateTime.Now.Date.AddYears(1));

                    for (int i = 0; i < weekendList.Count; i++)
                    {
                        HolidayDay_I = string.Empty; Festival_I = string.Empty; NationalHolidayFlag_I = 0; HolidayType_I = string.Empty;

                        HolidayDate_I = Convert.ToDateTime(weekendList[i]);
                        HolidayType_I = "Weekly Off";
                        HolidayDay_I = WeeklyOffDay;

                        objBL.Query = "insert into TempHoliday(HolidayDate,HolidayDay,Festival,HolidayType,NationalHolidayFlag) values('" + HolidayDate_I.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "','" + HolidayDay_I + "','" + Festival_I + "','" + HolidayType_I + "'," + NationalHolidayFlag_I + ")";
                        Result = objBL.Function_ExecuteNonQuery();
                    }

                    Fill_Hoilday_Grid();
                }
                else
                {
                    
                }
            }
        }

        private void Fill_Hoilday_Grid()
        {
            lblTotalHoliday.Text = "";
            dgvHolidayList.Rows.Clear();
            DataSet ds = new DataSet();
            //objBL.Query = "select * from tempholiday where CancelTag=0 and HolidayDate NOT IN(select FromDate from leaveapplication where CancelTag=0) order by HolidayDate asc";
            //objBL.Query = "select * from tempholiday where CancelTag=0 and HolidayDate NOT IN(select FromDate from leaveapplication where CancelTag=0) order by HolidayDate asc";
            objBL.Query = "select * from tempholiday where CancelTag=0 and HolidayDate NOT IN(select FromDate from leaveapplication where CancelTag=0 and EmployeeId=" + objPC.EmployeeId + ") order by HolidayDate asc";
            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTotalHoliday.Text = "Total Holidays- "+ ds.Tables[0].Rows.Count.ToString();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dgvHolidayList.Rows.Add();
                    dgvHolidayList.Rows[i].Cells["clmTempHolidayId"].Value = ds.Tables[0].Rows[i]["TempHolidayId"].ToString();
                    
                    DateTime dt;
                    dt = Convert.ToDateTime(ds.Tables[0].Rows[i]["HolidayDate"]);

                    dgvHolidayList.Rows[i].Cells["clmHolidayDate"].Value = dt.ToString(BusinessResources.DATEFORMATDDMMYYYY); // ds.Tables[0].Rows[i]["HolidayDate"].ToString();
                    dgvHolidayList.Rows[i].Cells["clmHolidayDay"].Value = ds.Tables[0].Rows[i]["HolidayDay"].ToString();
                    dgvHolidayList.Rows[i].Cells["clmFestival"].Value = ds.Tables[0].Rows[i]["Festival"].ToString();
                    dgvHolidayList.Rows[i].Cells["clmHolidayType"].Value = ds.Tables[0].Rows[i]["HolidayType"].ToString();
                    //dataGridView1.Rows[i].Cells["clmHolidayDate"].Value = ds.Tables[0].Rows[i]["NationalHolidayFlag"].ToString();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private bool Validation()
        {
            objEP.Clear();

            if (cmbLocation.SelectedIndex == -1)
            {
                cmbLocation.Focus();
                objEP.SetError(cmbLocation, "Select Location");
                return true;
            }
            else if (cmbDepartment.SelectedIndex == -1)
            {
                cmbDepartment.Focus();
                objEP.SetError(cmbDepartment, "Select Department");
                return true;
            }
            else if (cmbEmployeeName.SelectedIndex == -1)
            {
                cmbEmployeeName.Focus();
                objEP.SetError(cmbEmployeeName, "Select EmployeeName");
                return true;
            }
            else if (cmbLeaveType.SelectedIndex == -1)
            {
                cmbLeaveType.Focus();
                objEP.SetError(cmbLeaveType, "Select Leave Type");
                return true;
            }
            else if (txtCompOffReason.Text == "")
            {
                objEP.SetError(txtCompOffReason, "Enter Reason");
                return true;
            }
            else if (txtWeeklyOff.Text == "")
            {
                objEP.SetError(txtWeeklyOff, "Enter Weekly Off");
                return true;
            }
            else if (txtDay.Text == "")
            {
                objEP.SetError(txtDay, "Enter Comp off Day");
                return true;
            }
            else if (txtType.Text == "")
            {
                objEP.SetError(txtType, "Enter Comp off Day");
                return true;
            }
            else
                return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (objPC.AddFlag == 1)
            {
                try
                {
                    FlagDelete = false;
                    SaveDB();
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
        protected void SaveDB()
        {
            if (!Validation())
            {
                if (!cbUsedCompOffDate.Checked)
                {
                    objPC.CompOffApplicationId = TableId;
                    objPC.EntryDate = dtpDate.Value;
                    objPC.EmployeeId = Convert.ToInt32(cmbEmployeeName.SelectedValue);
                    objPC.LeaveTypeId = Convert.ToInt32(cmbLeaveType.SelectedValue);
                    objPC.CompOffDate = dtpCompOffDate.Value;
                    objPC.CompOffDay = txtDay.Text;
                    objPC.HolidayType = txtType.Text;
                    objPC.Festival = txtFestival.Text;
                    objPC.CompOffReason = txtCompOffReason.Text;
                    objPC.WorkRemarks = txtWorkingRemarks.Text;
                    objPC.CompOffDueDate = dtpCompOffDueDate.Value;
                    objPC.CompOffUsedFlag = 0;
                    objPC.CompStatus = BusinessResources.LS_Pending;
                    objPC.UserId = BusinessLayer.LoginId_Static;
                    objPC.DeleteFlag = FlagDelete;

                    if (!FlagDelete)
                    {
                        if (CheckExist())
                        {
                            objRL.ShowMessage(12, 4);
                            return;
                        }
                    }

                    Result = objQL.SP_CompOffApplication_Insert_Update_Delete();
                }
                else
                {
                    if (!Validation_CompOffUsed() && cbUsedCompOffDate.Checked && txtUsedCompOffDay.Text != "")
                    {
                        objPC.CompOffUsedFlag = 1;
                        objPC.CompUsedStatus = BusinessResources.LS_Pending;
                        objBL.Query = "update compoffapplication set CompOffUsedFlag=" + objPC.CompOffUsedFlag + ",UsedCompOffDate='" + dtpUsedCompOffDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "',UsedCompOffDay='" + txtUsedCompOffDay.Text + "',CompUsedStatus='" + BusinessResources.LS_Pending + "' where CompOffApplicationId=" + TableId + " and CancelTag=0";
                        Result = objBL.Function_ExecuteNonQuery();
                    }
                }

                if (Result > 0)
                {
                    if (!FlagDelete)
                        objRL.ShowMessage(7, 1);
                    else
                        objRL.ShowMessage(9, 1);

                    FillGrid();
                    ClearAll();
                }
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }

        int Pending_Count = 0, ManagerApproved_Count = 0, HRApproved_Count = 0, Remarks_Count = 0, Reject_Count = 0, Completed_Count = 0, Due_Count = 0, Expired_Count = 0;

        string MainQuery = string.Empty, OrderClause = string.Empty, WhereClause = string.Empty, WhereClauseOther = string.Empty;
        DateTime DueDateCompOff;

        
        private void FillGrid_Working()
        {
            lblTotalCount.Text = "";
            dataGridView1.DataSource = null;
            //DataSet ds = new DataSet();

            MainQuery = string.Empty;
            WhereClause = string.Empty;

            if (SearchFlag && txtSearch.Text != "")
                WhereClause = " and E.EmployeeName LIKE '%" + txtSearch.Text + "%'";
            else
                WhereClause = string.Empty;

            //if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR || BusinessLayer.UserType == BusinessResources.USER_TYPE_HROFFICER)
            //    WhereClause = "";
            //else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER)
            //    WhereClause = " and E.LocationId IN (select LocationId from locationwisedepartmentusers where InchargeId=UserId_V) ";
            //else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_SENIOROFFICER)
            //    WhereClause = " and E.LocationId IN (select LocationId from locationwisedepartmentusers where InchargeId=UserId_V) and E.DepartmentId IN (select DepartmentId from locationwisedepartmentusers where InchargeId=UserId_V) ";
            //else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_OFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_SUPERVISOR)
            //    WhereClause = " and E.EmployeeId=" + BusinessLayer.EmployeeLoginId_Static + " ";
            //else
            //{
            //    WhereClause = "";
            //}

            if (cbCompOffUsedList.Checked)
                WhereClause += " and COA.CompOffUsedFlag=1 ";
            else
                WhereClause += "";

            OrderClause = " order by COA.EntryDate desc ";


            if (BusinessLayer.UserType == "ADMINISTRATOR")
            {


            }
            else
            {

            }
                
            objBL.Query = BusinessResources.CompOffQuery + objRL.WhereClasuse_CompOff_Comman() + WhereClause + " order by COA.EntryDate desc ";

            //MainQuery = BusinessResources.CompOffQuery;
            //"Select " +
            //"COA.CompOffApplicationId," +
            //"COA.EntryDate as ' Entry Date'," +
            //"COA.EmployeeId, " +
            //"LM.LocationName," +
            //"DM.Department," +
            //"E.EmployeeName as 'Employee Name'," +
            //"DES.Designation," +
            //"COA.LeaveTypeId," +
            //"L.LeaveTypeFName  as 'Comp off Type'," +
            //"COA.CompOffDate as 'Comp Off Date'," +
            //"COA.CompOffDay as 'Comp Off Day', " +
            //"COA.HolidayType as 'Holiday Type', " +
            //"COA.Festival, " +
            //"COA.CompOffReason as 'Comp Off Reason',  " +
            //"COA.WorkRemarks as 'Work Remarks', " +
            //"COA.CompStatus as 'Status'," +
            //"COA.CompOffDueDate as 'Comp Off Due Date'," +
            //"COA.CompOffUsedFlag," +
            //"COA.CompUsedStatus " +
            //" from " +
            //"compoffapplication COA inner join " +
            //"leavetypes L on L.LeaveTypeId=COA.LeaveTypeId inner join " +
            //"Employees E on E.EmployeeId=COA.EmployeeId inner join " +
            //"DepartmentMaster DM on DM.DepartmentId=E.DepartmentId inner join " +
            //"DesignationMaster DES on DES.DesignationId=E.DesignationId inner join " +
            //"LocationMaster LM on LM.LocationId=E.LocationId " +
            //" where " +
            //"L.CancelTag=0 and " +
            //"COA.CancelTag=0 and " +
            //"E.CancelTag=0 and " +
            //"DM.CancelTag=0 and " +
            //"DES.CancelTag=0 and " +
            //"LM.CancelTag=0 ";
            //E.LocationId IN (select LocationId from locationwisedepartmentusers where InchargeId=UserId_V) and
            //E.DepartmentId IN (select DepartmentId from locationwisedepartmentusers where InchargeId=UserId_V);

            // objBL.Query = MainQuery + WhereClause;

            dataGridView1.DataSource = null;
            // dataGridView1.Columns.Clear();
            // dataGridView1.Rows.Clear();
            DataSet ds = new DataSet();
            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
            {
                //DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                //checkColumn.Name = "clmSelect";
                //checkColumn.HeaderText = "Select";
                //checkColumn.Width = 50;
                //checkColumn.ReadOnly = false;
                //checkColumn.FillWeight = 10; //if the datagridview is resized (on form resize) the checkbox won't take up too much; value is relative to the other columns' fill values
                //dataGridView1.Columns.Add(checkColumn);


                //0 COA.CompOffApplicationId,
                //1 COA.EntryDate as ' Entry Date',
                //2 COA.EmployeeId, 
                //3 LM.LocationName,
                //4 DM.Department,
                //5 E.EmployeeName as 'Employee Name',
                //6 DES.Designation,
                //7 COA.LeaveTypeId,
                //8 L.LeaveTypeFName  as 'Comp off Type',
                //9 COA.CompOffDate as 'Comp Off Date',
                //10 COA.CompOffDay as 'Comp Off Day', 
                //11 COA.HolidayType as 'Holiday Type', 
                //12 COA.Festival, 
                //13 COA.CompOffReason as 'Comp Off Reason',  
                //14 COA.WorkRemarks as 'Work Remarks', 
                //15 COA.CompStatus as 'Status',
                //16 COA.CompOffDueDate as 'Comp Off Due Date',
                //17 COA.CompOffUsedFlag
                //18 COA.CompUsedStatus,
                //19 COA.UsedCompOffDate,
                //20 COA.UsedCompOffDay

                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[17].Visible = false;

                dataGridView1.Columns[1].Width = 120;
                dataGridView1.Columns[3].Width = 130;
                dataGridView1.Columns[4].Width = 120;
                dataGridView1.Columns[5].Width = 120;
                dataGridView1.Columns[6].Width = 120;
                dataGridView1.Columns[8].Width = 130;
                dataGridView1.Columns[9].Width = 120;
                dataGridView1.Columns[10].Width = 130;
                dataGridView1.Columns[11].Width = 130;
                dataGridView1.Columns[12].Width = 130;
                dataGridView1.Columns[13].Width = 130;
                dataGridView1.Columns[14].Width = 130;
                dataGridView1.Columns[15].Width = 100;

                Pending_Count = 0; ManagerApproved_Count = 0; HRApproved_Count = 0; Remarks_Count = 0; Reject_Count = 0; Completed_Count = 0; Due_Count = 0; Expired_Count = 0;

                int CompOffUsedFlag_I = 0;

                string CompStatus = string.Empty;
                int CID = 0;

                foreach (DataGridViewRow Myrow in dataGridView1.Rows)
                {
                    CompStatus = string.Empty; CID = 0; CompOffUsedFlag_I = 0;
                    int EID1 = 0;

                    //5
                    //if (!string.IsNullOrEmpty(Convert.ToString(Myrow.Cells[0].Value)))
                    //    EID1 = Convert.ToInt32(Myrow.Cells[0].Value);

                    //if(EID1 == 34)
                    //{

                    //}

                    //Here 2 cell is target value and 1 cell is Volume
                    int RCount = 15;

                    if (cbCompOffUsedList.Checked)
                        RCount = 18;

                    if (!string.IsNullOrEmpty(Convert.ToString(Myrow.Cells[RCount].Value)))
                        CompStatus = Convert.ToString(Myrow.Cells[RCount].Value);


                    if (CompStatus == BusinessResources.LS_Pending)
                    {
                        Pending_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Pending_Color);
                    }
                    else if (CompStatus == BusinessResources.LS_ManagerApproved)
                    {
                        ManagerApproved_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Manager_Color);
                    }
                    else if (CompStatus == BusinessResources.LS_HRApproved)
                    {
                        HRApproved_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_HRApproved_Color);
                    }
                    else if (CompStatus == BusinessResources.LS_Reject)
                    {
                        Reject_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Reject_Color);
                    }
                    else if (CompStatus == BusinessResources.LS_Remarks)
                    {
                        Remarks_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Remarks_Color);
                    }
                    else if (CompStatus == BusinessResources.LS_Completed)
                    {
                        Completed_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Completed_Color);
                    }
                    else
                    {
                        Myrow.DefaultCellStyle.BackColor = Color.White;
                        //string hex = BusinessResources.BACKGROUND_COLOUR;
                        //Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
                        //Myrow.DefaultCellStyle.BackColor = _color;
                    }


                    if (!cbCompOffUsedList.Checked)
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(Myrow.Cells[17].Value)))
                            CompOffUsedFlag_I = Convert.ToInt32(Myrow.Cells[17].Value);

                        if (!string.IsNullOrEmpty(Convert.ToString(Myrow.Cells[16].Value)))
                            DueDateCompOff = Convert.ToDateTime(Myrow.Cells[16].Value);

                        if (!string.IsNullOrEmpty(Convert.ToString(Myrow.Cells[0].Value)))
                            CID = Convert.ToInt32(Myrow.Cells[0].Value);

                        //TimeSpan difference = DateTime.Now.Date- DueDateCompOff;
                        TimeSpan difference = DueDateCompOff - DateTime.Now.Date;

                        int CalculateDays = difference.Days;

                        if (CalculateDays < 0 && CompOffUsedFlag_I == 0)
                        {
                            Myrow.DefaultCellStyle.BackColor = Color.Red;

                            //Update Query
                            objBL.Query = "update compoffapplication set ExpiredFlag=1 where CancelTag=0 and CompOffApplicationId=" + CID + " and CompOffUsedFlag=0";
                            Result = objBL.Function_ExecuteNonQuery();

                            Expired_Count++;
                        }
                        else if (CalculateDays <= 20 && CalculateDays > 0 && CompOffUsedFlag_I == 0)
                        {
                            Myrow.DefaultCellStyle.BackColor = Color.HotPink; // Color.FromName(BusinessResources.LS_Pending_Color);
                            Due_Count++;
                        }
                        else
                        {

                        }

                        //if (CalculateDays < 20 && CalculateDays > 0 && CompOffUsedFlag_I == 0)
                        //{
                        //    Myrow.DefaultCellStyle.BackColor = Color.HotPink; // Color.FromName(BusinessResources.LS_Pending_Color);
                        //}
                        //else if (CalculateDays == 0 && CalculateDays < 0 && CompOffUsedFlag_I==0)
                        //{

                        //}
                        //else
                        //{
                        //    //objBL.Query = "update compoffapplication set ExpiredFlag=0 where CancelTag=0 and CompOffApplicationId=" + CID + " and CompOffUsedFlag=1";
                        //    //Result = objBL.Function_ExecuteNonQuery();
                        //}
                    }
                }
                lblPending.Text = BusinessResources.LS_Pending + "-" + Pending_Count.ToString();
                lblManagerApproved.Text = BusinessResources.LS_ManagerApproved + "-" + ManagerApproved_Count.ToString();
                lblHRApproved.Text = BusinessResources.LS_HRApproved + "-" + HRApproved_Count.ToString();
                lblReject.Text = BusinessResources.LS_Reject + "-" + Reject_Count.ToString();
                lblRemark.Text = BusinessResources.LS_Remarks + "-" + Remarks_Count.ToString();
                lblCompleted.Text = BusinessResources.LS_Completed + "-" + Completed_Count.ToString();

                lblDue.Text = "Due-" + Due_Count.ToString();
                lblExpired.Text = "Expired-" + Expired_Count.ToString();
                dataGridView1.ClearSelection();
            }
        }

       

        private void FillGrid()
        {
            DataSet ds = new DataSet();
            dataGridView1.DataSource = null;
            lblTotalCount.Text = "";
            MainQuery = string.Empty; OrderClause = string.Empty; WhereClause = string.Empty; WhereClauseOther = string.Empty;
            
            MainQuery = "Select distinct " +
                        "COA.CompOffApplicationId," +
                        "COA.EntryDate," +
                        "COA.EmployeeId," +
                        "LM.LocationName," +
                        "DM.Department," +
                        "E.EmployeeName," +
                        "DES.Designation," +
                        "COA.LeaveTypeId," +
                        "LT.LeaveTypeFName, " +
                        "COA.CompOffDate," +
                        "COA.CompOffDay, " +
                        "COA.HolidayType, " +
                        "COA.Festival, " +
                        "COA.CompOffReason, " +
                        "COA.WorkRemarks, " +
                        "COA.CompStatus," +
                        "COA.CompOffDueDate," +
                        "COA.CompOffUsedFlag," +
                        "COA.CompUsedStatus," +
                        "COA.UsedCompOffDate," +
                        "COA.UsedCompOffDay" +
                        " from " +
                            " compoffapplication COA inner join " +
                            " leavetypes LT on LT.LeaveTypeId=COA.LeaveTypeId inner join " +
                            " Employees E on E.EmployeeId=COA.EmployeeId inner join " +
                            " DesignationMaster DES on DES.DesignationId=E.DesignationId inner join " +
                            " LocationMaster LM on LM.LocationId=E.LocationId inner join " +
                            " DepartmentMaster DM on DM.DepartmentId=E.DepartmentId " +
                        " where " +
                            "COA.CancelTag = 0 and " +
                            "LT.CancelTag = 0 and " +
                            "E.CancelTag = 0 and " +
                            "DM.CancelTag = 0 and " +
                            "DES.CancelTag = 0 and " +
                            "LM.CancelTag = 0 ";

            if (BusinessLayer.UserType == "ADMINISTRATOR")
            {
                if (SearchFlag && txtSearch.Text != "")
                    WhereClause = " and E.EmployeeName LIKE '%" + txtSearch.Text + "%'";
                else
                    WhereClause = string.Empty;
            }
            else
            {
                WhereClause = " and COA.EmployeeId=" + BusinessLayer.EmployeeLoginId_Static + " ";
            }
                 

            if (cbCompOffUsedList.Checked)
                WhereClause += " and COA.CompOffUsedFlag=1 ";
            else
                WhereClause += "";

            OrderClause = " order by COA.EntryDate desc ";

            //objBL.Query = BusinessResources.CompOffQuery + objRL.WhereClasuse_CompOff_Comman() + WhereClause + " order by COA.EntryDate desc ";

            //MainQuery = BusinessResources.CompOffQuery;
            //"Select " +
            //"COA.CompOffApplicationId," +
            //"COA.EntryDate as ' Entry Date'," +
            //"COA.EmployeeId, " +
            //"LM.LocationName," +
            //"DM.Department," +
            //"E.EmployeeName as 'Employee Name'," +
            //"DES.Designation," +
            //"COA.LeaveTypeId," +
            //"L.LeaveTypeFName  as 'Comp off Type'," +
            //"COA.CompOffDate as 'Comp Off Date'," +
            //"COA.CompOffDay as 'Comp Off Day', " +
            //"COA.HolidayType as 'Holiday Type', " +
            //"COA.Festival, " +
            //"COA.CompOffReason as 'Comp Off Reason',  " +
            //"COA.WorkRemarks as 'Work Remarks', " +
            //"COA.CompStatus as 'Status'," +
            //"COA.CompOffDueDate as 'Comp Off Due Date'," +
            //"COA.CompOffUsedFlag," +
            //"COA.CompUsedStatus " +
            //" from " +
            //"compoffapplication COA inner join " +
            //"leavetypes L on L.LeaveTypeId=COA.LeaveTypeId inner join " +
            //"Employees E on E.EmployeeId=COA.EmployeeId inner join " +
            //"DepartmentMaster DM on DM.DepartmentId=E.DepartmentId inner join " +
            //"DesignationMaster DES on DES.DesignationId=E.DesignationId inner join " +
            //"LocationMaster LM on LM.LocationId=E.LocationId " +
            //" where " +
            //"L.CancelTag=0 and " +
            //"COA.CancelTag=0 and " +
            //"E.CancelTag=0 and " +
            //"DM.CancelTag=0 and " +
            //"DES.CancelTag=0 and " +
            //"LM.CancelTag=0 ";
            //E.LocationId IN (select LocationId from locationwisedepartmentusers where InchargeId=UserId_V) and
            //E.DepartmentId IN (select DepartmentId from locationwisedepartmentusers where InchargeId=UserId_V);

            // objBL.Query = MainQuery + WhereClause;


            // dataGridView1.Columns.Clear();
            // dataGridView1.Rows.Clear();

            objBL.Query = MainQuery + WhereClause + OrderClause;

            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
            {
                //DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                //checkColumn.Name = "clmSelect";
                //checkColumn.HeaderText = "Select";
                //checkColumn.Width = 50;
                //checkColumn.ReadOnly = false;
                //checkColumn.FillWeight = 10; //if the datagridview is resized (on form resize) the checkbox won't take up too much; value is relative to the other columns' fill values
                //dataGridView1.Columns.Add(checkColumn);


                //0 COA.CompOffApplicationId,
                //1 COA.EntryDate as ' Entry Date',
                //2 COA.EmployeeId, 
                //3 LM.LocationName,
                //4 DM.Department,
                //5 E.EmployeeName as 'Employee Name',
                //6 DES.Designation,
                //7 COA.LeaveTypeId,
                //8 L.LeaveTypeFName  as 'Comp off Type',
                //9 COA.CompOffDate as 'Comp Off Date',
                //10 COA.CompOffDay as 'Comp Off Day', 
                //11 COA.HolidayType as 'Holiday Type', 
                //12 COA.Festival, 
                //13 COA.CompOffReason as 'Comp Off Reason',  
                //14 COA.WorkRemarks as 'Work Remarks', 
                //15 COA.CompStatus as 'Status',
                //16 COA.CompOffDueDate as 'Comp Off Due Date',
                //17 COA.CompOffUsedFlag
                //18 COA.CompUsedStatus,
                //19 COA.UsedCompOffDate,
                //20 COA.UsedCompOffDay

                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[17].Visible = false;

                dataGridView1.Columns[1].Width = 120;
                dataGridView1.Columns[3].Width = 130;
                dataGridView1.Columns[4].Width = 120;
                dataGridView1.Columns[5].Width = 120;
                dataGridView1.Columns[6].Width = 120;
                dataGridView1.Columns[8].Width = 130;
                dataGridView1.Columns[9].Width = 120;
                dataGridView1.Columns[10].Width = 130;
                dataGridView1.Columns[11].Width = 130;
                dataGridView1.Columns[12].Width = 130;
                dataGridView1.Columns[13].Width = 130;
                dataGridView1.Columns[14].Width = 130;
                dataGridView1.Columns[15].Width = 100;

                Pending_Count = 0; ManagerApproved_Count = 0; HRApproved_Count = 0; Remarks_Count = 0; Reject_Count = 0; Completed_Count = 0; Due_Count = 0; Expired_Count = 0;

                int CompOffUsedFlag_I = 0;

                string CompStatus = string.Empty;
                int CID = 0;

                foreach (DataGridViewRow Myrow in dataGridView1.Rows)
                {
                    CompStatus = string.Empty; CID = 0; CompOffUsedFlag_I = 0;
                    int EID1 = 0;

                    //5
                    //if (!string.IsNullOrEmpty(Convert.ToString(Myrow.Cells[0].Value)))
                    //    EID1 = Convert.ToInt32(Myrow.Cells[0].Value);

                    //if(EID1 == 34)
                    //{

                    //}

                    //Here 2 cell is target value and 1 cell is Volume
                    int RCount = 15;
                    
                    if (cbCompOffUsedList.Checked)
                        RCount = 18;

                    if (!string.IsNullOrEmpty(Convert.ToString(Myrow.Cells[RCount].Value)))
                        CompStatus = Convert.ToString(Myrow.Cells[RCount].Value);

                     
                        if (CompStatus == BusinessResources.LS_Pending)
                        {
                            Pending_Count++;
                            Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Pending_Color);
                        }
                        else if (CompStatus == BusinessResources.LS_ManagerApproved)
                        {
                            ManagerApproved_Count++;
                            Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Manager_Color);
                        }
                        else if (CompStatus == BusinessResources.LS_HRApproved)
                        {
                            HRApproved_Count++;
                            Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_HRApproved_Color);
                        }
                        else if (CompStatus == BusinessResources.LS_Reject)
                        {
                            Reject_Count++;
                            Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Reject_Color);
                        }
                        else if (CompStatus == BusinessResources.LS_Remarks)
                        {
                            Remarks_Count++;
                            Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Remarks_Color);
                        }
                        else if (CompStatus == BusinessResources.LS_Completed)
                        {
                            Completed_Count++;
                            Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Completed_Color);
                        }
                        else
                        {
                            Myrow.DefaultCellStyle.BackColor = Color.White;
                            //string hex = BusinessResources.BACKGROUND_COLOUR;
                            //Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
                            //Myrow.DefaultCellStyle.BackColor = _color;
                        }
                    

                    if (!cbCompOffUsedList.Checked)
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(Myrow.Cells[17].Value)))
                            CompOffUsedFlag_I = Convert.ToInt32(Myrow.Cells[17].Value);

                        if (!string.IsNullOrEmpty(Convert.ToString(Myrow.Cells[16].Value)))
                            DueDateCompOff = Convert.ToDateTime(Myrow.Cells[16].Value);

                        if (!string.IsNullOrEmpty(Convert.ToString(Myrow.Cells[0].Value)))
                            CID = Convert.ToInt32(Myrow.Cells[0].Value);

                        //TimeSpan difference = DateTime.Now.Date- DueDateCompOff;
                        TimeSpan difference = DueDateCompOff- DateTime.Now.Date;

                        int CalculateDays = difference.Days;

                        if(CalculateDays <0 && CompOffUsedFlag_I == 0)
                        {
                            Myrow.DefaultCellStyle.BackColor = Color.Red;

                            //Update Query
                            objBL.Query = "update compoffapplication set ExpiredFlag=1 where CancelTag=0 and CompOffApplicationId=" + CID + " and CompOffUsedFlag=0";
                            Result = objBL.Function_ExecuteNonQuery();

                            Expired_Count++;
                        }
                        else if(CalculateDays <= 20 && CalculateDays >0 && CompOffUsedFlag_I == 0)
                        {
                            Myrow.DefaultCellStyle.BackColor = Color.HotPink; // Color.FromName(BusinessResources.LS_Pending_Color);
                            Due_Count++;
                        }
                        else
                        {

                        }

                        //if (CalculateDays < 20 && CalculateDays > 0 && CompOffUsedFlag_I == 0)
                        //{
                        //    Myrow.DefaultCellStyle.BackColor = Color.HotPink; // Color.FromName(BusinessResources.LS_Pending_Color);
                        //}
                        //else if (CalculateDays == 0 && CalculateDays < 0 && CompOffUsedFlag_I==0)
                        //{
                            
                        //}
                        //else
                        //{
                        //    //objBL.Query = "update compoffapplication set ExpiredFlag=0 where CancelTag=0 and CompOffApplicationId=" + CID + " and CompOffUsedFlag=1";
                        //    //Result = objBL.Function_ExecuteNonQuery();
                        //}
                    }
                }
                lblPending.Text = BusinessResources.LS_Pending + "-" + Pending_Count.ToString();
                lblManagerApproved.Text = BusinessResources.LS_ManagerApproved + "-" + ManagerApproved_Count.ToString();
                lblHRApproved.Text = BusinessResources.LS_HRApproved + "-" + HRApproved_Count.ToString();
                lblReject.Text = BusinessResources.LS_Reject + "-" + Reject_Count.ToString();
                lblRemark.Text = BusinessResources.LS_Remarks + "-" + Remarks_Count.ToString();
                lblCompleted.Text = BusinessResources.LS_Completed + "-" + Completed_Count.ToString();

                lblDue.Text =  "Due-" + Due_Count.ToString();
                lblExpired.Text =  "Expired-" + Expired_Count.ToString();
                dataGridView1.ClearSelection();
            }
        }

        //protected void FillGrid1()
        //{
        //    lblTotalCount.Text = "";
        //    dataGridView1.DataSource = null;
        //    DataSet ds = new DataSet();
            
        //    if (!SearchFlag)
        //        objPC.SearchFlag = false;
        //    else
        //        objPC.SearchFlag = true;

        //    ds = objQL.SP_CompOffApplication_FillGrid();

        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        lblTotalCount.Text = "Total-" + ds.Tables[0].Rows.Count;
        //        //0 COA.CompOffApplicationId,
        //        //1 COA.EntryDate as ' Entry Date',
        //        //2 COA.EmployeeId, 
        //        //3 LM.LocationName,
        //        //4 DM.Department,
        //        //5 E.EmployeeName as 'Employee Name',
        //        //6 DES.Designation,
        //        //7 COA.LeaveTypeId,
        //        //8 L.LeaveTypeFName  as 'Comp off Type',
        //        //9 COA.CompOffDate as 'Comp Off Date',
        //        //10 COA.CompOffDay as 'Comp Off Day', 
        //        //11 COA.HolidayType as 'Holiday Type', 
        //        //12 COA.Festival, 
        //        //13 COA.CompOffReason as 'Comp Off Reason',  
        //        //14 COA.WorkRemarks as 'Work Remarks', 
        //        //15 COA.CompStatus as 'Status',
        //        //16 COA.CompOffDueDate as 'Comp Off Due Date',
        //        //17 COA.CompOffUsedFlag

        //        dataGridView1.DataSource = ds.Tables[0];
        //        dataGridView1.Columns[0].Visible = false;
        //        dataGridView1.Columns[2].Visible = false;
        //        dataGridView1.Columns[7].Visible = false;
        //        dataGridView1.Columns[17].Visible = false;
                 
        //        dataGridView1.Columns[1].Width = 120;
        //        dataGridView1.Columns[3].Width = 130;
        //        dataGridView1.Columns[4].Width = 120;
        //        dataGridView1.Columns[5].Width = 120;
        //        dataGridView1.Columns[6].Width = 120;
        //        dataGridView1.Columns[8].Width = 130;
        //        dataGridView1.Columns[9].Width = 120;
        //        dataGridView1.Columns[10].Width = 130;
        //        dataGridView1.Columns[11].Width = 130;
        //        dataGridView1.Columns[12].Width = 130;
        //        dataGridView1.Columns[13].Width = 130;
        //        dataGridView1.Columns[14].Width = 130;
        //        dataGridView1.Columns[15].Width = 100;

        //        Pending_Count = 0; Approved_Count = 0; HRApproved_Count = 0; Remarks_Count = 0; Cancel_Count = 0;

        //        string CompStatus = string.Empty;
        //        foreach (DataGridViewRow Myrow in dataGridView1.Rows)
        //        {
        //            CompStatus = string.Empty;
        //            //Here 2 cell is target value and 1 cell is Volume
        //            if (!string.IsNullOrEmpty(Convert.ToString(Myrow.Cells[15].Value)))
        //                CompStatus = Convert.ToString(Myrow.Cells[15].Value);

        //            //Remark-
        //            //Cancel
        //            //Remark
        //            //Approved
        //            //HR Approved

        //            if (CompStatus == BusinessResources.LS_Pending)
        //            {
        //                Pending_Count++;
        //                Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Pending_Color);
        //            }
        //            else if (CompStatus == BusinessResources.LS_ManagerApproved)
        //            {
        //                Approved_Count++; HRApproved_Count++;
        //                Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Manager_Color);
        //            }
        //            else if (CompStatus == BusinessResources.LS_HRApproved)
        //            {
        //                HRApproved_Count++;
        //                Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_HRApproved_Color);
        //            }
        //            else if (CompStatus == BusinessResources.LS_Remarks)
        //            {
        //                Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Remarks_Color);
        //            }
        //            else if (CompStatus == BusinessResources.LS_Reject)
        //            {
        //                Cancel_Count++;
        //                Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Reject_Color);
        //            }
        //            else
        //            {
        //                Myrow.DefaultCellStyle.BackColor = Color.White;
        //                //string hex = BusinessResources.BACKGROUND_COLOUR;
        //                //Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
        //                //Myrow.DefaultCellStyle.BackColor = _color;
        //            }
        //        }

        //        lblPending.Text = BusinessResources.LS_Pending + "-" + Pending_Count.ToString();
        //        lblApproved.Text = BusinessResources.LS_ManagerApproved + "-" + Approved_Count.ToString();
        //        lblHRApproved.Text = BusinessResources.LS_HRApproved + "-" + HRApproved_Count.ToString();
        //        lblRemarks.Text = BusinessResources.LS_Remarks + "-" + Remarks_Count.ToString();
        //        lblCancel.Text = BusinessResources.LS_Reject + "-" + Cancel_Count.ToString();
        //    }
        //}

        protected bool CheckExist()
        {
            DataSet ds = new DataSet();
            ds = objQL.SP_CompOffApplication_CheckExist();
            if (ds.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
            txtSearch.Text = "";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
                SearchFlag = true;
            else
                SearchFlag = false;

            FillGrid();
        }

        private void txtDay_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (objPC.DeleteFlagUR == 1)
            {
                try
                {
                    DialogResult dr = objRL.Delete_Record_Show_Message();
                    if (dr == System.Windows.Forms.DialogResult.Yes)
                    {
                        FlagDelete = true;
                        SaveDB();
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

        private void cmbLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            objRL.FillDepartment(cmbLocation, cmbDepartment);
        }

        private void cmbDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FillEmployee_Fixed_CompOff();
        }

        int num = 0;
        private void dgvHolidayList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if ((sender as DataGridView).CurrentCell is DataGridViewCheckBoxCell)
            //{
            //    if (Convert.ToBoolean(((sender as DataGridView).CurrentCell as DataGridViewCheckBoxCell).Value))
            //    {
            //        // Maybe have a method which does the
            //        //loop and set value except for the current cell
            //    }
            //}

            //foreach (DataGridViewRow row in dgvHolidayList.Rows)
            //{
            //    if (row.Cells[0].Value != null && row.Cells[0].Value.Equals(true)) //3 is the column number of checkbox
            //    {
            //        row.Selected = true;
            //        row.DefaultCellStyle.SelectionBackColor = Color.LightSlateGray;
            //        num = 1;
            //    }
            //    else
            //    {
            //        num = 0;
            //        row.Selected = false;
            //        return;
            //    }
            //}

            bool isChecked = false;
            if (e.RowIndex < 0)
                return;

            if (!string.IsNullOrEmpty(Convert.ToString(dgvHolidayList.Rows[e.RowIndex].Cells["clmSelect"].Value)))
                isChecked = (bool)dgvHolidayList.Rows[e.RowIndex].Cells["clmSelect"].Value;

            if (isChecked)
                num += 1;
            else
                num = 0;

            if (num == 1)
            {
                gbCompOffDetails.Visible = true;
                HolidayDate_I = DateTime.Now.Date; HolidayDay_I = ""; Festival_I = "";
                txtDay.Text = "";
                txtFestival.Text = "";
                txtType.Text = "";
                HolidayDate_I = Convert.ToDateTime(dgvHolidayList.Rows[e.RowIndex].Cells["clmHolidayDate"].Value);
                HolidayDay_I = objRL.CheckNullString(Convert.ToString(dgvHolidayList.Rows[e.RowIndex].Cells["clmHolidayDay"].Value));
                HolidayType_I = objRL.CheckNullString(Convert.ToString(dgvHolidayList.Rows[e.RowIndex].Cells["clmHolidayType"].Value));
                Festival_I = objRL.CheckNullString(Convert.ToString(dgvHolidayList.Rows[e.RowIndex].Cells["clmFestival"].Value));
                dtpCompOffDate.Value = HolidayDate_I;
                txtDay.Text = HolidayDay_I;
                txtFestival.Text = Festival_I;
                txtType.Text = HolidayType_I;
            }
            else
            {
                //dgvHolidayList.Rows[e.RowIndex].Cells["clmSelect"].Value = false;
                gbCompOffDetails.Visible = false;
                HolidayDate_I = DateTime.Now.Date; HolidayDay_I = ""; Festival_I = "";
                dtpCompOffDate.Value = DateTime.Now.Date;
                txtDay.Text = "";
                txtFestival.Text = "";
                txtType.Text = "";

                for (int i = 0; i < dgvHolidayList.Rows.Count; i++)
                {
                    dgvHolidayList.Rows[i].Cells["clmSelect"].Value = false;
                }

                //foreach (DataGridViewRow row in dgvHolidayList.Rows)
                //{
                //    if (row.Cells[0].Value != null && row.Cells[0].Value.Equals(true)) //3 is the column number of checkbox
                //        row.Selected = false;
                //}
               // return;
            }
        }

        private void ClearCompOff()
        {
            gbCompOffDetails.Visible = false;

        }

        private void dgvHolidayList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvHolidayList.IsCurrentCellDirty)
                dgvHolidayList.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private bool Validation_CompOffUsed()
        {
            objEP.Clear();
            //if (txtWorkingRemarks.Text == "")
            //{
            //    txtWorkingRemarks.Focus();
            //    objEP.SetError(txtWorkingRemarks, "Enter Working Details");
            //    return true;
            //}
            if (TableId == 0)
            {
                dataGridView1.Focus();
                objEP.SetError(dataGridView1, "Enter Table Id");
                return true;
            }
            //else if(Convert.ToInt32(dtpCompOffDueDate.Value.Subtract(dtpUsedCompOffDate.Value)) > 60)
            //{
            //    dtpUsedCompOffDate.Focus();
            //    objEP.SetError(dtpUsedCompOffDate, "Enter Valid Date");
            //    return true;
            //}
            else
                return false;
        }

        private void cbUsedCompOffDate_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUsedCompOffDate.Checked)
            {
                if (!Validation_CompOffUsed())
                {
                    dtpUsedCompOffDate.Visible = true;
                    txtUsedCompOffDay.Visible = true;
                    //objPC.CompOffUsedFlag = 1;
                }
                else
                {
                    objRL.ShowMessage(17, 4);
                    return;
                }
            }
            else
            {
                dtpUsedCompOffDate.Visible = false ;
                txtUsedCompOffDay.Visible = false;
                objPC.CompOffUsedFlag = 0;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                RowCount_Grid = dataGridView1.Rows.Count;
                CurrentRowIndex = dataGridView1.CurrentRow.Index;

                if (RowCount_Grid >= 0 && CurrentRowIndex >= 0)
                {
                    ClearAll();
                    //gbCompOffUsedDetails.Visible = true;
                    gbCompOffDetails.Enabled = true;
                    gbWorkingRemarks.Enabled = true;
                    gbCompOffDetails.Visible = true;
                    gbWorkingRemarks.Visible = true;
                    gbCompOffUsedDetails.Visible = false;
                    
                    //0 COA.CompOffApplicationId,
                    //1 COA.EntryDate as ' Entry Date',
                    //2 COA.EmployeeId, 
                    //3 LM.LocationName,
                    //4 DM.Department,
                    //5 E.EmployeeName as 'Employee Name',
                    //6 DES.Designation,
                    //7 COA.LeaveTypeId,
                    //8 L.LeaveTypeFName  as 'Comp off Type',
                    //9 COA.CompOffDate as 'Comp Off Date',
                    //10 COA.CompOffDay as 'Comp Off Day', 
                    //11 COA.HolidayType as 'Holiday Type', 
                    //12 COA.Festival, 
                    //13 COA.CompOffReason as 'Comp Off Reason',  
                    //14 COA.WorkRemarks as 'Work Remarks', 
                    //15 COA.CompStatus as 'Status',
                    //16 COA.CompOffDueDate as 'Comp Off Due Date',
                    //17 COA.CompOffUsedFlag
                    //18 COA.CompUsedStatus,
                    //19 COA.UsedCompOffDate,
                    //20 COA.UsedCompOffDay

                    objPC.CompOffUsedFlag = 0;
                    TableId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                    objPC.CompOffApplicationId = TableId;

                    dtpDate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    objRL.FillLocation(cmbLocation, cmbDepartment);
                    cmbLocation.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    //objRL.FillDepartment(cmbLocation, cmbDepartment);
                    objRL.FillDepartment(cmbLocation, cmbDepartment);
                    cmbDepartment.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    FillEmployee_Fixed_CompOff();
                    cmbEmployeeName.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    objPC.EmployeeId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                    Fill_EmployeeDetails();

                    txtDesignation.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                    cmbLeaveType.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                    dtpCompOffDate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString());
                     
                    txtDay.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                    txtType.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                    txtFestival.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
                    txtCompOffReason.Text = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
                    txtWorkingRemarks.Text = dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString();

                    cmbLeaveType.Enabled = false;
                    objPC.CompStatus = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[15].Value));
                    objPC.CompOffUsedFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[17].Value)));

                    if (objPC.CompStatus == BusinessResources.LS_Completed || objPC.CompOffUsedFlag == 1)
                        gbCompOffUsedDetails.Visible = true;
                    else
                        gbCompOffUsedDetails.Visible = false;

                    if (objPC.CompOffUsedFlag == 1)
                    {
                        cbUsedCompOffDate.Checked = true;
                        dtpUsedCompOffDate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[19].Value.ToString());
                        txtUsedCompOffDay.Text = Convert.ToString(dtpUsedCompOffDate.Value.DayOfWeek);
                        
                        //if (objPC.CompStatus == BusinessResources.LS_Pending)
                        //    gbCompOffUsedDetails.Enabled = true;
                        //else
                            gbCompOffUsedDetails.Enabled = false;
                    }
                    else
                    {
                        cbUsedCompOffDate.Checked = false;
                        dtpUsedCompOffDate.Value = DateTime.Now.Date;
                        txtUsedCompOffDay.Text = "";
                    }

                    dtpCompOffDueDate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[16].Value.ToString());

                    TimeSpan difference = DateTime.Now.Date.Subtract(dtpCompOffDueDate.Value);

                    int Dif = Convert.ToInt32(difference.Days);

                    if (Dif > 0)
                    {
                        gbCompOffUsedDetails.Visible = false;
                        objRL.ShowMessage(49, 4);
                        return;
                    }
                    else
                    {
                        gbCompOffUsedDetails.Visible = true;
                    }
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

        private void dtpCompOffDate_ValueChanged(object sender, EventArgs e)
        {
            dtpCompOffDueDate.Value = dtpCompOffDate.Value.AddDays(60);
        }

        private void dtpUsedCompOffDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpUsedCompOffDate.Value > dtpCompOffDate.Value)
            {
               // double SubstractDays = Convert.ToDouble(dtpCompOffDueDate.Value.Subtract(dtpCompOffDate.Value));

                txtUsedCompOffDay.Text = Convert.ToString(dtpUsedCompOffDate.Value.DayOfWeek);
            }
            else
                txtUsedCompOffDay.Text = "";
        }

        int CompOffUsedList = 0;

        private void cbCompOffUsed_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCompOffUsedList.Checked)
                CompOffUsedList = 1;
            else
                CompOffUsedList = 0;

            FillGrid();
        }
    }
}
