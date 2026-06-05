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

namespace SPApplication.Transaction
{
    public partial class OutdoorPunch_old : Form
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
        bool SearchFlagCode = false;
        int EmployeeCode_V = 0;

        public OutdoorPunch_old()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_OUTDOORENTRIES);
            btnDelete.Text = BusinessResources.BTN_CLEAR;
            objQL.Fill_Master_ComboBox(cmbLocation, "locationmaster");
            objQL.Fill_Master_ComboBox(cmbDepartment, "departmentmaster");
            objQL.Fill_Master_ComboBox(cmbDesignation, "designationmaster");
            objQL.Fill_Master_ComboBox(cmbContractor, "contractormaster");
            objQL.Fill_Master_ComboBox(cmbCategory, "categories");
            objQL.Fill_Master_ComboBox(cmbShiftGroup, "shiftgroups");
            objQL.Fill_Master_ComboBox(cmbJobProfile, "jobprofilemaster");
            objQL.Fill_Master_ComboBox(cmbType, "employementtypemaster");

            objRL.Fill_Shift_ComboBox(cmbShift);
            objRL.Fill_Status_ComboBox(cmbStatus);

            // FillLocation();
            ClearAll();
             
            objQL.Fill_Master_ComboBox(cmbLeaveType, "leavetypes");

            Set_Query();
        }


        private void ClearAll()
        {
            cmbLocation.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            cmbDesignation.SelectedIndex = -1;
            cmbContractor.SelectedIndex = -1;
            cmbCategory.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
            cmbShiftGroup.SelectedIndex = -1;
            cmbJobProfile.SelectedIndex = -1;
            cmbType.SelectedIndex = -1;
            txtSearch.Text = "";
            txtSearchCode.Text = "";
            cbSelectAllEmployee.Checked = false;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private bool Validation_GridCheckBox()
        {
            objEP.Clear();
            bool RValue = false;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value) == true)
                {
                    RValue = true;
                    break;
                }
                else
                    RValue = false;
            }
            return RValue;
        }

        private bool Validation()
        {
            objEP.Clear();

            if (!Validation_GridCheckBox())
            {
                objEP.SetError(dataGridView1, "Select Employee");
                dataGridView1.Focus();
                return true;
            }
            //else if (cmbShift.SelectedIndex == -1)
            //{
            //    objEP.SetError(cmbShift, "Select Employee");
            //    cmbShift.Focus();
            //    return true;
            //}
            else if (cmbStatus.SelectedIndex == -1)
            {
                objEP.SetError(cmbStatus, "Select Status");
                cmbStatus.Focus();
                return true;
            }
            else
                return false;
        }

        //outdoor punch 
        //Shift
        //Nim

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Validation())
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value)==true)
                        {
                            //1 "E.LocationId," +
                            //24 "E.LocationId," +
                            //25 "E.DepartmentId ";

                            objPC.EmployeeId = 0;
                            objPC.LocationId = 0;
                            objPC.DepartmentId = 0;
                            objPC.DesignationId = 0;
                            objPC.ShiftGroupId = 0;

                            objPC.EmployeeId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[i].Cells[1].Value)));
                            objPC.LocationId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[i].Cells[24].Value)));
                            objPC.DepartmentId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[i].Cells[25].Value)));
                            objPC.DesignationId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[i].Cells[26].Value)));
                            objPC.ShiftGroupId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[i].Cells[27].Value)));
                            objPC.OverTimeApplicable = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[i].Cells[28].Value)));

                            if (cmbStatus.SelectedIndex >-1)
                                objPC.Status = cmbStatus.Text;

                            DateTime starting = new DateTime();
                            starting = dtpFromDate.Value; // DateTime.ParseExact(dtpFromDate.Value, BusinessResources.DATEFORMATYYYYYMMDD, null);
                            DateTime ending = new DateTime();
                            ending = dtpToDate.Value; // DateTime.ParseExact(date2.Value, "dd-MM-yyyy", null);

                            GetDatesBetween(starting, ending);

                            if (allDates.Count > 0)
                            {
                                for (int j = 0; j < allDates.Count; j++)
                                {
                                    objPC.AttendanceDate = Convert.ToDateTime(allDates[j]);

                                    bool CheckFlag = false;

                                    DataSet dsARM = new DataSet();
                                    objPC.CompleteFlag = 0;
                                    objPC.AttendanceRecordMasterId = 0; //Convert.ToInt32(objCmd.ExecuteScalar());
                                    //objPC.AttendanceHistoryId = AttendanceHistoryId_Temp; // objAC1.AttendanceHistoryId;
                                    objPC.EntryDate = DateTime.Now.Date;
                                    dsARM = objQL.SP_AttendanceRecordMaster_CheckExist();
                                    CheckFlag = false;

                                    if (dsARM.Tables[0].Rows.Count > 0)
                                    {
                                        if (!string.IsNullOrEmpty(Convert.ToString(dsARM.Tables[0].Rows[0]["AttendanceRecordMasterId"].ToString())))
                                        {
                                            objPC.AttendanceRecordMasterId = Convert.ToInt32(dsARM.Tables[0].Rows[0]["AttendanceRecordMasterId"].ToString());
                                            //objPC.ApprovalStatusId = Convert.ToInt32(dsARM.Tables[0].Rows[0]["ApprovalStatusId"].ToString());
                                            CheckFlag = true;
                                        }
                                    }

                                    if (!CheckFlag)
                                    {
                                        objPC.ApprovalStatusId = 1;
                                        objPC.AttendanceRecordMasterId = objQL.SP_AttendanceRecordMaster_CheckExist_Insert();
                                    }

                                    if (objPC.AttendanceRecordMasterId != 0)
                                    {
                                        objPC.AttendanceRecordId = 0;

                                        if (objQL.SP_AttendanceRecord_CheckExist())
                                            objPC.AttendanceRecordId = 0;

                                        if (cmbStatus.SelectedIndex > -1)
                                            objPC.StatusCode = cmbStatus.Text.ToString();

                                        objPC.InTime = Convert.ToDateTime(dtpInTime.Value);
                                        objPC.OutTime = Convert.ToDateTime(dtpOutTime.Value);
                                        objPC.PunchRecords = "";

                                        AttendanceLogics objAL = new AttendanceLogics();
                                        objAL.AttendanceWorking();

                                        objPC.UserId = Convert.ToInt32(BusinessLayer.EmployeeLoginId_Static);

                                        Result = objQL.SP_AttendanceRecord_Insert_Update();

                                        if (Result > 0)
                                        {
                                            if (objPC.AttendanceRecordId == 0)
                                                objPC.AttendanceRecordId = objRL.ReturnMaxID_Fix("attendancerecord", "AttendanceRecordId");

                                            objAL.Save_AttendanceMonthlyData();
                                            objPC.AttendanceRecordId = 0;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    
                    objRL.ShowMessage(7, 1);
                    ClearAll_Attendance();
                }
            }
        }

        List<DateTime> allDates = new List<DateTime>();
        public void GetDatesBetween(DateTime startDate, DateTime endDate)
        {
            allDates = null; allDates = new List<DateTime>();
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                allDates.Add(date);

            if (allDates.Count == 0)
                allDates.Add(dtpFromDate.Value);
            //return allDates;
        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
            
        }

        private void ClearAll_Attendance()
        {
            dtpFromDate.Value = DateTime.Now.Date;
            dtpToDate.Value = DateTime.Now.Date;
            dtpInTime.Value = DateTime.Now.Date;
            dtpOutTime.Value = DateTime.Now.Date;
            txtDuration.Text = "";
            cmbShift.SelectedIndex = -1;
            dtpShiftInTime.Value = DateTime.Now.Date;
            dtpShiftOutTime.Value = DateTime.Now.Date;
            txtShiftDuration.Text = "";
            txtLateBy.Text = "";
            
            txtTotalDuration.Text = "";
            txtOverTime.Text = "";
            txtEarlyBy.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll_Attendance();
            //var startDate = new DateTime(dtpFromDate);
            //var endDate = new DateTime(2013, 1, 31);
            //int days = (endDate - startDate).Days + 1; // incl. endDate 

            //List<DateTime> range = Enumerable.Range(0, days)
            //    .Select(i => startDate.AddDays(i))
            //    .ToList();
        }

        private void cbSelectAllEmployee_CheckedChanged(object sender, EventArgs e)
        {
            CheckTrueFalse();
        }

        private void CheckTrueFalse()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (cbSelectAllEmployee.Checked)
                        dataGridView1.Rows[i].Cells[0].Value = true;
                    else
                        dataGridView1.Rows[i].Cells[0].Value = false;
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                SearchFlagCode = false;
                SearchFlag = true;
            }
            else
                SearchFlag = false;

            Set_Query();
        }

        private void txtSearchCode_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchCode.Text != "")
            {
                SearchFlagCode = true;
                SearchFlag = false;
            }
            else
                SearchFlagCode = false;

            Set_Query();
        }

        private void Fill_Combo_Event(object sender, EventArgs e)
        {
            Set_Query();
        }

        string SelectClause = string.Empty;
        string FromClause = string.Empty;
        string WhereBasicClause = string.Empty;
        string WhereClause = string.Empty;
        string OrderByClause = string.Empty;


        private string Get_Combo_Clause(ComboBox cmb, string SearchColumn)
        {
            string ComboClause = string.Empty;
            if (cmb.SelectedIndex > -1)
            {
                if (cmb.Text != "All")
                {
                    if (SearchColumn == "LocationId")
                        ComboClause = " and E." + SearchColumn + "=" + cmb.SelectedValue + "";
                    else if (SearchColumn == "DepartmentId")
                        ComboClause = " and E." + SearchColumn + "=" + cmb.SelectedValue + "";
                    else if (SearchColumn == "DesignationId")
                        ComboClause = " and E." + SearchColumn + "=" + cmb.SelectedValue + "";
                    else if (SearchColumn == "ContractorId")
                        ComboClause = " and E." + SearchColumn + "=" + cmb.SelectedValue + "";
                    else if (SearchColumn == "CategoryId")
                        ComboClause = " and E." + SearchColumn + "=" + cmb.SelectedValue + "";
                    else if (SearchColumn == "ShiftGroupId")
                        ComboClause = " and E." + SearchColumn + "=" + cmb.SelectedValue + "";
                    else if (SearchColumn == "EmployementTypeId")
                        ComboClause = " and E." + SearchColumn + "=" + cmb.SelectedValue + "";
                    else if (SearchColumn == "Status")
                        ComboClause = " and E." + SearchColumn + "='" + cmb.Text + "'";
                    else if (SearchColumn == "JobProfile")
                        ComboClause = " and E." + SearchColumn + "='" + cmb.Text + "'";
                    else if (SearchColumn == "NewFlag")
                    {
                        if (cmbEmployee.Text == "New")
                            ComboClause = " and E." + SearchColumn + "=1";
                        else
                            ComboClause = " and E." + SearchColumn + "=0";
                    }
                    else
                        ComboClause = "";
                }
            }
            return ComboClause;
        }

        private void Set_Query()
        {
            if (!SearchFlagCode && !SearchFlag)
            {
                WhereClause = Get_Combo_Clause(cmbLocation, "LocationId");
                WhereClause += Get_Combo_Clause(cmbDepartment, "DepartmentId");
                WhereClause += Get_Combo_Clause(cmbDesignation, "DesignationId");
                WhereClause += Get_Combo_Clause(cmbContractor, "ContractorId");
                WhereClause += Get_Combo_Clause(cmbCategory, "CategoryId");
                WhereClause += Get_Combo_Clause(cmbShiftGroup, "ShiftGroupId");
                WhereClause += Get_Combo_Clause(cmbType, "EmployementTypeId");
                //Text
                WhereClause += Get_Combo_Clause(cmbStatus, "Status");
                WhereClause += Get_Combo_Clause(cmbJobProfile, "JobProfile");
                WhereClause += Get_Combo_Clause(cmbEmployee, "NewFlag");
            }
            else
            {
                WhereClause = string.Empty;

                if (SearchFlag)
                    //WhereClause = " and E.EmployeeName LIKE CONCAT('%'," + txtSearch.Text + ",'%')";
                    WhereClause = " and E.EmployeeName LIKE '%" + txtSearch.Text + "%'";
                else if (SearchFlagCode)
                    WhereClause = " and E.EmployeeCode=" + txtSearchCode.Text + "";
                else
                    WhereClause = string.Empty;
            }


            //	E.EmployeeName LIKE CONCAT('%' , EmployeeName_V , '%') 
            lblTotalCount.Text = "";
            
            DataSet ds = new DataSet();
            //  "E.EmployeeId as 'CheckBox', " +

            SelectClause = "select " +
                        "E.EmployeeId, " +
                        "E.EmployeeCode as 'Employee Code'," +
                        "E.EmpInital," +
                        "E.EmployeeName as 'Employee Name', " +
                        "E.Gender, " +
                        "E.DOB," +
                        "E.Age, " +
                        "E.MobileNo as 'Mobile', " +
                        "E.PersonalEmailID as 'Personal Email',   " +
                        "E.OfficialEmailID as 'Official Email'," +
                        "E.BloodGroup as 'Blood Group'," +
                        "E.AadharCardNumber as 'Aadhar Card'," +
                        "E.PanCardNumber as 'PAN Card'," +
                        "CM.ContractorName as 'Contractor'," +
                        "ETM.EmployementType as 'Employement Type'," +
                        "CT.CategoryFName as 'Category'," +
                        "LM.LocationName as 'Location'," +
                        "DM.Department," +
                        "DESM.Designation," +
                        "E.JobProfile as 'Job Profile', " +
                        "SG.ShiftGroupFName as 'Shift Group', " +
                        "E.Status," +
                        "E.NewFlag,"+
                        "E.LocationId," +
                        "E.DepartmentId, "+
                        "E.DesignationId, "+
                        "E.ShiftGroupId,"+
                        "E.OverTimeApplicable ";

            FromClause = " from " +
                " Employees E inner join " +
                " contractormaster CM on CM.ContractorId=E.ContractorId inner join " +
                " employementtypemaster ETM on ETM.EmployementTypeId=E.EmployementTypeId inner join" +
                " departmentmaster DM on DM.DepartmentId=E.DepartmentId inner join" +
                " designationmaster DESM on DESM.DesignationId=E.DesignationId inner join" +
                " categories CT on CT.CategoryId=E.CategoryId inner join" +
                " locationmaster LM on LM.LocationId=E.LocationId inner join " +
                " shiftgroups SG on SG.ShiftGroupId=E.ShiftGroupId ";

            WhereBasicClause = " where " +
                " E.CancelTag=0 and" +
                " CM.CancelTag=0 and" +
                " ETM.CancelTag=0 and" +
                " DM.CancelTag=0 and" +
                " DESM.CancelTag=0 and" +
                " CT.CancelTag=0 and" +
                " LM.CancelTag=0 and" +
                " SG.CancelTag=0 ";


            OrderByClause = " order by E.EmployeeCode asc";
            objBL.Query = SelectClause + FromClause + WhereBasicClause + WhereClause;

            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                checkColumn.Name = "clmSelect";
                checkColumn.HeaderText = "";
                checkColumn.Width = 20;
                checkColumn.ReadOnly = false;
                checkColumn.FillWeight = 10; //if the datagridview is resized (on form resize) the checkbox won't take up too much; value is relative to the other columns' fill values
                dataGridView1.Columns.Add(checkColumn);


                lblTotalCount.Text = "Total-" + ds.Tables[0].Rows.Count;

                //0 Select Check Box
                //1  "E.EmployeeId, " +
                //2 "E.EmployeeCode as 'Employee Code'," +
                //3 "E.EmpInital," +
                //4 "E.EmployeeName as 'Employee Name', " +
                //5 "E.Gender, " +
                //6 "E.DOB," +
                //7 "E.Age, " +
                //8 "E.MobileNo as 'Mobile', " +
                //9 "E.PersonalEmailID as 'Personal Email',   " +
                //10 "E.OfficialEmailID as 'Official Email'," +
                //11 "E.BloodGroup as 'Blood Group'," +
                //12 "E.AadharCardNumber as 'Aadhar Card'," +
                //13 "E.PanCardNumber as 'PAN Card'," +
                //14 "CM.ContractorName as 'Contractor'," +
                //15 "ETM.EmployementType as 'Employement Type'," +
                //16 "CT.CategoryFName as 'Category'," +
                //17 "LM.LocationName as 'Location'," +
                //18 "DM.Department," +
                //19 "DESM.Designation," +
                //20 "E.JobProfile as 'Job Profile', " +
                //21 "SG.ShiftGroupFName as 'Shift Group', " +
                //22 "E.Status," +
                //23 "E.NewFlag," +
                //24 "E.LocationId," +
                //25 "E.DepartmentId, " +
                //26 "E.DesignationId, " +
                //27 "E.ShiftGroupId ";
                //28 "E.OverTimeApplicable

                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[22].Visible = false;
                dataGridView1.Columns[23].Visible = false;
                dataGridView1.Columns[24].Visible = false;
                dataGridView1.Columns[25].Visible = false;
                dataGridView1.Columns[26].Visible = false;
                dataGridView1.Columns[27].Visible = false;

                //0 E.EmployeeId, 
                dataGridView1.Columns[2].Width = 80;//1 E.EmployeeCode as 'Code',
                //2 E.EmpInital,
                dataGridView1.Columns[4].Width = 200;//3 E.EmployeeName as 'Employee Name', 
                dataGridView1.Columns[5].Width = 60;//4 E.Gender, 
                //5 E.DOB, 
                dataGridView1.Columns[7].Width = 30;//6 E.Age, 
                dataGridView1.Columns[8].Width = 80;//7 E.MobileNo as 'Mobile No', 
                //8 E.PersonalEmailID as 'Personal Email',   
                //9 E.OfficialEmailID as 'Official Email',
                //10 E.BloodGroup as 'Blood Group',
                //11 E.AadharCardNumber as 'Aadhar Card Number',
                //12 E.PanCardNumber as 'PAN Card Number',
                dataGridView1.Columns[14].Width = 150;//13 CM.ContractorName as 'Contractor Name',
                dataGridView1.Columns[15].Width = 100;//14 ETM.EmployementType as 'Employement Type',
                dataGridView1.Columns[16].Width = 60;//15 CT.CategoryFName as 'Category F Name',
                dataGridView1.Columns[17].Width = 70; //16 LM.LocationName as 'Location Name',
                dataGridView1.Columns[18].Width = 100;//17 DM.Department,
                dataGridView1.Columns[19].Width = 100;//18 DESM.Designation,
                dataGridView1.Columns[20].Width = 80;//19 E.JobProfile as 'Job Profile', 
                dataGridView1.Columns[21].Width = 110;//20 "SG.ShiftGroupFName as 'Shift Group', " +
                dataGridView1.Columns[22].Width = 60;//20 E.Status,
                //dataGridView1.Columns[22].Width = 70;//22 "E.NewFlag ";
                //24 "E.LocationId," +
                //25 "E.DepartmentId ";
                

               // dataGridView1.Columns[1] = (CheckBox)
                // dataGridView1.Columns[22].Visible = false;
                //dataGridView1.Columns[23].Visible = false;

                //dataGridView1.Columns[2].Width = 120;
                //dataGridView1.Columns[4].Width = 120;
                //dataGridView1.Columns[6].Width = 120;
                //dataGridView1.Columns[8].Width = 120;
                //dataGridView1.Columns[9].Width = 120;
                //dataGridView1.Columns[10].Width = 100;

                //for (int i = 0; i < dataGridView1.Columns.Count; i++)
                //{
                //    dataGridView1.Columns[i].Width = 150;
                //}

                //DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                //dataGridView1.Columns.Add(chk);

                //chk.HeaderText = "Check Data";
                //chk.Name = "chk";

              //  DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                //DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                //dataGridView1.Columns.Add(checkColumn);
                //CheckBox box;
                ////for (int i = 0; i < 10; i++)
                ////{
                ////    box = new CheckBox();
                ////    box.Tag = i.ToString();
                ////    box.Text = "a";
                ////    box.AutoSize = true;
                ////    box.Location = new Point(10, i * 50); //vertical
                ////    //box.Location = new Point(i * 50, 10); //horizontal
                ////    this.Controls.Add(box);
                ////}
                
                //for (int i = 0; i < dataGridView1.Rows.Count; i++)
                //{
                //    //box = new CheckBox();
                //    //box.Tag = i.ToString();
                //    //box.Text = "a";
                //    //box.AutoSize = true;
                //    //box.Location = new Point(10, i * 50); //vertical
                //    ////box.Location = new Point(i * 50, 10); //horizontal
                //    //this.Controls.Add(box);

                //    //dataGridView1.Rows[i].Cells[0].Value = false;

                //    //var cell = new DataGridViewCheckBoxCell()
                //    //{
                //    //    TrueValue = "1",
                //    //    FalseValue = "0",
                //    //};
                //    ////cell.Style.NullValue = false;

                //    //DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                //    //this.dataGridView1.Rows[i].Cells[1] = chk;

                //    //checkColumn.Name = i.ToString();
                //    //checkColumn.HeaderText = "X";
                //    //checkColumn.Width = 50; // or any other value as you wish
                //    //checkColumn.ReadOnly = false;
                //    //checkColumn.FillWeight = 10;
                   

                //    //DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                //    //dataGridView1.Columns.Add(chk);

                //    //chk.HeaderText = "Check Data";
                //    //chk.Name = "chk";
                //    //

                //    //dataGridView1.Rows[i].Cells.a
                //}

                //foreach (DataGridViewRow drv in this.dtgrid_event_list.Rows)
                //{
                //    DataGridViewCheckBoxCell chkchecking = new DataGridViewCheckBoxCell();
                //    chkchecking = (DataGridViewCheckBoxCell)drv.Cells[1];
                //}

                int NFlag = 0;
                foreach (DataGridViewRow Myrow in dataGridView1.Rows)
                {
                    NFlag = 0; // = string.Empty;
                    //Here 2 cell is target value and 1 cell is Volume
                    if (!string.IsNullOrEmpty(Convert.ToString(Myrow.Cells[23].Value)))
                        NFlag = Convert.ToInt32(Myrow.Cells[23].Value);

                    if (NFlag == 1)
                    {
                        Myrow.DefaultCellStyle.BackColor = Color.Yellow; // Color.FromName(BusinessResources.LS_Pending_Color);
                    }

                    //foreach (DataGridViewRow row in vendorsDataGridView.Rows)
                    //    if (Convert.ToInt32(row.Cells[7].Value) < Convert.ToInt32(row.Cells[10].Value))
                    //    {
                    //        row.DefaultCellStyle.BackColor = Color.Red;
                    //    }
                }

                //dataGridView1.Columns[3].Width = 200;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void OutdoorPunch_Load(object sender, EventArgs e)
        {

        }

        private void dtpInTime_Leave(object sender, EventArgs e)
        {
            //Set_Attendance();
        }

        private void Set_Attendance()
        {
            //objPC.ShiftGroupId = objPC.ShiftGroupId; // Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clmShiftGroupId"].Value.ToString());

            objPC.InTime = dtpInTime.Value;
            objPC.OutTime = dtpOutTime.Value;

            //objRL.CalculateComman_Attendance();

            objAL.AttendanceWorking();

            //DataSet dsAutoShift = new DataSet();
            //dsAutoShift = objQL.SP_Shift_by_ShiftGroupId();
            //objRL.Get_Auto_Shift_Details(dsAutoShift);

            if (objPC.ShiftId != 0)
            {
                dtpShiftInTime.Value = objPC.BeginTime_Shift_DT;
                dtpShiftOutTime.Value = objPC.EndTime_Shift_DT;

                //objRL.OT_Calculations();
                //objRL.LateBy_And_Early_Calculation();
                //objRL.MissedPunchIn_Calculations();
                //objRL.MissedPunchOut_Calculations();
                cmbShift.Text = objPC.ShiftName;
                txtShiftDuration.Text = objPC.Duration;
                txtDuration.Text = objPC.Duration.ToString();
                txtTotalDuration.Text = objPC.TotalDuration.ToString();
                txtOverTime.Text = objPC.OverTime.ToString();
                txtLateBy.Text = objPC.LateBy.ToString();
                txtEarlyBy.Text = objPC.EarlyBy.ToString();
                txtLateBy.Text = objPC.LateBy.ToString();
                txtEarlyBy.Text = objPC.EarlyBy.ToString();
            }
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        int num = 0;

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            bool isChecked = (bool)dataGridView1.Rows[e.RowIndex].Cells[0].Value;

            if (isChecked)
            {
                num += 1;
            }
            else
            {
                num -= 1;
            }

            lblSelectedCount.Text = "Selected Employee: " + num;
        }

        private void txtSearchCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.NumericValue(sender, e, txtSearchCode);
        }

        private void dtpInTime_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
