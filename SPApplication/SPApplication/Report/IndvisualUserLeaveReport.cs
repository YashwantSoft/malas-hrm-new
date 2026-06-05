using BusinessLayerUtility;
using MySqlX.XDevAPI.Common;
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
    public partial class IndvisualUserLeaveReport : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        //bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        //int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0;

        string EmpDesignation = string.Empty;
        string EmpDepartment = string.Empty;

        int SearchId = 0, LocationId = 0;

        public IndvisualUserLeaveReport()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnReport, btnClear, btnView, btnExit, BusinessResources.LBL_HEADER_USERLEAVEREPORT);
            btnReport.Text = BusinessResources.BTN_VIEW;
            ClearAll();
            FillEmployees_Combobox();
            SearchId = BusinessLayer.EmployeeLoginId_Static;
            //FillLocation();
            objRL.FillLocation(cmbLocation, cmbDepartment);
           // objQL.Fill_Master_ComboBox(cmbLeaveType, "leavetypes");
            objRL.Fill_Approval_Status(cmbStatus);


            if (objPC.ReportForm == "Leave Report")
            {
                objRL.Fill_LeaveType(cmbLeaveType, true);
                cbRevertLeave.Visible = true;
                cbSelectAllLeaveType.Checked = true;
                cbSelectAllLeaveType.Enabled = true;
                lblHeader.Text = BusinessResources.LBL_HEADER_USERLEAVEREPORT;
            }
            else
            {
                objRL.Fill_LeaveType(cmbLeaveType, false);
                cbRevertLeave.Visible = false;
                cbSelectAllLeaveType.Checked = false;
                cbSelectAllLeaveType.Enabled = false;
                lblHeader.Text = BusinessResources.LBL_HEADER_USERCOMPOFFREPORT;
            }
        }

         

        private void LeaveReport_Load(object sender, EventArgs e)
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

        private void Fill_EmployeeDetails()
        {
            objPC.EmployeeId = 0;
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

                    if (objPC.ReportForm == "Leave Report")
                        objPC.SearchFlagLeaveCompOff = false;
                    else
                        objPC.SearchFlagLeaveCompOff = true;

                        objRL.Get_Leaves_Count_All();
                    objPC.SearchFlagLeaveCompOff = true;
                    objRL.Get_CompOff_Count_All();

                    objRL.Fill_Leave_RichTextBox(rtbLeaveRecords);
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
            cbSelectAllLeaveType.Checked = true;
            cbSelectAllStatus.Checked = true;
        }

        private void cbSelectAllLeaveType_CheckedChanged(object sender, EventArgs e)
        {
            cmbLeaveType.SelectedIndex = -1;

            if (cbSelectAllLeaveType.Checked)
                cmbLeaveType.Enabled = false;
            else
                cmbLeaveType.Enabled = true;
        }

        private void cbSelectAllStatus_CheckedChanged(object sender, EventArgs e)
        {
            cmbStatus.SelectedIndex = -1;

            if (cbSelectAllStatus.Checked)
                cmbStatus.Enabled = false;
            else
                cmbStatus.Enabled = true;
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

        private void cmbLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //FillDepartment();
            objRL.FillDepartment(cmbLocation, cmbDepartment);
        }

        private void cmbDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
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
                objQL.WhereClause_V = " and E.LocationId=" + cmbLocation.SelectedValue + "  and E.DepartmentId=" + cmbDepartment.SelectedValue + "  and DM.DesignationCategory NOT IN('" + BusinessResources.USER_TYPE_TRAINEE + "')";
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
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            if (!Validation())
            {
                if (objPC.ReportForm == "Leave Report")
                    GetReport();
                else
                    GetReport_CompOff();
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }

        int Result = 0;
        string MainQuery = string.Empty;
        DateTime DueDateCompOff;
        private void GetReport_CompOff()
        {
            lblTotalCount.Text = "";
            dataGridView1.DataSource = null;
            //DataSet ds = new DataSet();

            MainQuery = string.Empty;
            WhereClause = string.Empty;
            LeaveStatusIn = string.Empty;

            string CompOffClause=string.Empty;

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

           // objBL.Query = BusinessResources.CompOffQuery + objRL.WhereClasuse_CompOff_Comman() + " order by COA.EntryDate desc ";

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

            //Report Query
           // DataSet ds = new DataSet();

            ColumnNames_BR = string.Empty; TableNames_BR = string.Empty; WhereClause_BR = string.Empty; WhereClause = string.Empty; OrderBy = string.Empty;
            DateColumn = string.Empty; EmployeeIn = string.Empty; ContractorIn = string.Empty; StatusIn = string.Empty; DepartmentIn = string.Empty; LocationIdS = string.Empty;

            //Where Clauses All
            DateColumn = " and COA.CompOffDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' ";

            if (objPC.EmployeeId != 0)
                //EmployeeIn = " and LA.EmployeeId=" + EmployeeId + " ";
                EmployeeIn = " and E.EmployeeId=" + objPC.EmployeeId + " ";

            if (cmbLocation.SelectedIndex > -1)
                LocationIdS = " and E.LocationId=" + cmbLocation.SelectedValue + " ";

            if (cmbLocation.SelectedIndex > -1)
                DepartmentIn = " and E.DepartmentId=" + cmbDepartment.SelectedValue + " ";

            //if (!cbSelectAllContractor.Checked)
            //{
            //    if (cmbContractor.SelectedIndex > -1)
            //        ContractorIn = " and E.ContractorId=" + cmbContractor.SelectedValue + " ";
            //}

            if (!cbSelectAllLeaveType.Checked)
            {
                if (cmbLeaveType.SelectedIndex > -1)
                {
                    if (cmbLeaveType.SelectedIndex > -1)
                    {
                        //if(objPC.ReportForm == )
                        if (cmbLeaveType.Text == "Compensation Off Used" || cmbLeaveType.Text == "Compensation Off")
                        {
                            if (cmbLeaveType.Text == "Compensation Off Used")
                                CompOffClause = " and COA.CompOffUsedFlag=1 and COA.CompUsedStatus='" + BusinessResources.LS_Completed + "' ";
                            else
                            {
                                //LeaveStatusIn = " and COA.LeaveTypeId=" + cmbLeaveType.SelectedValue + " ";
                                CompOffClause = " and COA.CompStatus='" + BusinessResources.LS_Completed + "' ";
                            }
                        }
                    }
                }
            }

            if (!cbSelectAllStatus.Checked)
            {
                if (cmbStatus.SelectedIndex > -1)
                    StatusIn = " and COA.CompStatus='" + cmbStatus.Text + "' ";
            }

            //ColumnNames_BR = BusinessResources.LeaveApplication_Column;
            //TableNames_BR = BusinessResources.LeaveApplication_Table;
            //WhereClause_BR = BusinessResources.LeaveApplication_Where;
            OrderBy = " order by COA.EntryDate asc ";

            // DateColumn = " monthname(LA.EntryDate)='" + cmbMonth.Text + "' and YEAR(LA.EntryDate)='" + cmbYear.Text + "' ";

            WhereClause = DateColumn + EmployeeIn + LocationIdS + DepartmentIn + ContractorIn + StatusIn + LeaveStatusIn + CompOffClause + " ";

            objBL.Query = BusinessResources.CompOffQuery + WhereClause + OrderBy;
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
                //18 COA.CompUsedStatus 

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

        //changes on 15-11-2024 as per HRM user
        private void GetReport_CompOff_old()
        {
            lblTotalCount.Text = "";
            dataGridView1.DataSource = null;
            //DataSet ds = new DataSet();

            MainQuery = string.Empty;
            WhereClause = string.Empty;
            LeaveStatusIn = string.Empty;

            string CompOffClause = string.Empty;

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

            // objBL.Query = BusinessResources.CompOffQuery + objRL.WhereClasuse_CompOff_Comman() + " order by COA.EntryDate desc ";

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

            //Report Query
            // DataSet ds = new DataSet();

            ColumnNames_BR = string.Empty; TableNames_BR = string.Empty; WhereClause_BR = string.Empty; WhereClause = string.Empty; OrderBy = string.Empty;
            DateColumn = string.Empty; EmployeeIn = string.Empty; ContractorIn = string.Empty; StatusIn = string.Empty; DepartmentIn = string.Empty; LocationIdS = string.Empty;

            //Where Clauses All
            DateColumn = " and COA.CompOffDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' ";

            if (objPC.EmployeeId != 0)
                //EmployeeIn = " and LA.EmployeeId=" + EmployeeId + " ";
                EmployeeIn = " and E.EmployeeId=" + objPC.EmployeeId + " ";

            if (cmbLocation.SelectedIndex > -1)
                LocationIdS = " and E.LocationId=" + cmbLocation.SelectedValue + " ";

            if (cmbLocation.SelectedIndex > -1)
                DepartmentIn = " and E.DepartmentId=" + cmbDepartment.SelectedValue + " ";

            //if (!cbSelectAllContractor.Checked)
            //{
            //    if (cmbContractor.SelectedIndex > -1)
            //        ContractorIn = " and E.ContractorId=" + cmbContractor.SelectedValue + " ";
            //}

            if (!cbSelectAllLeaveType.Checked)
            {
                if (cmbLeaveType.SelectedIndex > -1)
                {
                    if (cmbLeaveType.SelectedIndex > -1)
                    {
                        if (cmbLeaveType.Text == "Compensation Off Used" || cmbLeaveType.Text == "Compensation Off")
                        {
                            if (cmbLeaveType.Text == "Compensation Off Used")
                                CompOffClause = " and COA.CompOffUsedFlag=1 and COA.CompUsedStatus='" + BusinessResources.LS_Completed + "' ";
                            else
                            {
                                LeaveStatusIn = " and COA.LeaveTypeId=" + cmbLeaveType.SelectedValue + " ";
                                CompOffClause = " and COA.CompStatus='" + BusinessResources.LS_Completed + "' ";
                            }
                        }
                    }
                }
            }

            if (!cbSelectAllStatus.Checked)
            {
                if (cmbStatus.SelectedIndex > -1)
                    StatusIn = " and COA.CompStatus='" + cmbStatus.Text + "' ";
            }

            //ColumnNames_BR = BusinessResources.LeaveApplication_Column;
            //TableNames_BR = BusinessResources.LeaveApplication_Table;
            //WhereClause_BR = BusinessResources.LeaveApplication_Where;
            OrderBy = " order by COA.EntryDate asc ";

            // DateColumn = " monthname(LA.EntryDate)='" + cmbMonth.Text + "' and YEAR(LA.EntryDate)='" + cmbYear.Text + "' ";

            WhereClause = DateColumn + EmployeeIn + LocationIdS + DepartmentIn + ContractorIn + StatusIn + LeaveStatusIn + CompOffClause + " ";

            objBL.Query = BusinessResources.CompOffQuery + WhereClause + OrderBy;
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
                //18 COA.CompUsedStatus 

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

                Pending_Count = 0; ManagerApproved_Count = 0; HRApproved_Count = 0; Remarks_Count = 0; Reject_Count = 0; Completed_Count = 0;

                string CompStatus = string.Empty;
                foreach (DataGridViewRow Myrow in dataGridView1.Rows)
                {
                    CompStatus = string.Empty;
                    //Here 2 cell is target value and 1 cell is Volume
                    if (!string.IsNullOrEmpty(Convert.ToString(Myrow.Cells[15].Value)))
                        CompStatus = Convert.ToString(Myrow.Cells[15].Value);

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
                }
                lblPending.Text = BusinessResources.LS_Pending + "-" + Pending_Count.ToString();
                lblManagerApproved.Text = BusinessResources.LS_ManagerApproved + "-" + ManagerApproved_Count.ToString();
                lblHRApproved.Text = BusinessResources.LS_HRApproved + "-" + HRApproved_Count.ToString();
                lblReject.Text = BusinessResources.LS_Reject + "-" + Reject_Count.ToString();
                lblRemark.Text = BusinessResources.LS_Remarks + "-" + Remarks_Count.ToString();
                lblCompleted.Text = BusinessResources.LS_Completed + "-" + Completed_Count.ToString();
                dataGridView1.ClearSelection();
            }
        }
        private bool Validation()
        {
            bool FlagReturn = false;
            objEP.Clear();

            //if (!cbEmployee.Checked)
            //{
            //    if (!cbSelectAllEmployee.Checked)
            //    {
            //        if (EmployeeId == 0)
            //        {
            //            txtSearchEmployeeName.Focus();
            //            objEP.SetError(txtSearchEmployeeName, "Select Employee");
            //            FlagReturn = true;
            //        }
            //    }
            //    else
            //        FlagReturn = false;
            //}
            //else
            //    FlagReturn = false;

            if (!FlagReturn)
            {
                if (dtpFromDate.Value > dtpToDate.Value)
                {
                    dtpToDate.Focus();
                    objEP.SetError(cmbDepartment, "Enter Valid Date");
                    FlagReturn = true;
                }
                else
                    FlagReturn = false;
            }

            if (!FlagReturn)
            {
                if (cmbLocation.SelectedIndex == -1)
                {
                    cmbLocation.Focus();
                    objEP.SetError(cmbLocation, "Select Location");
                    FlagReturn = true;
                }
                else if (cmbDepartment.SelectedIndex == -1)
                {
                    cmbDepartment.Focus();
                    objEP.SetError(cmbDepartment, "Select Department");
                    FlagReturn = true;
                }
                else
                    FlagReturn = false;
            }

            if (!FlagReturn)
            {
                if (!cbSelectAllLeaveType.Checked)
                {
                    if (cmbLeaveType.SelectedIndex == -1)
                    {
                        cmbLeaveType.Focus();
                        objEP.SetError(cmbLeaveType, "Select Leave Type");
                        FlagReturn = true;
                    }
                }
                else
                    FlagReturn = false;
            }

            if (!FlagReturn)
            {
                if (!cbSelectAllStatus.Checked)
                {
                    if (cmbStatus.SelectedIndex == -1)
                    {
                        cmbStatus.Focus();
                        objEP.SetError(cmbStatus, "Select Status");
                        FlagReturn = true;
                    }
                }
                else
                    FlagReturn = false;
            }
            return FlagReturn;
        }

        string ColumnNames_BR = string.Empty, TableNames_BR = string.Empty, WhereClause_BR = string.Empty, WhereClause = string.Empty, OrderBy = string.Empty;
        string DateColumn = string.Empty, EmployeeIn = string.Empty, LeaveStatusIn = string.Empty, ContractorIn = string.Empty, StatusIn = string.Empty, DepartmentIn = string.Empty, LocationIdS = string.Empty;

        int Pending_Count = 0, ManagerApproved_Count = 0, HRApproved_Count = 0, Remarks_Count = 0, Reject_Count = 0, Completed_Count = 0, Due_Count = 0, Expired_Count = 0;
        private void GetReport()
        {
            MainQuery = "select LA.LeaveApplicationId," +
                       "LA.EntryDate as 'Date'," +
                        "LA.EmployeeId," +
                        "LM.LocationName as 'Location'," +
                        "DM.Department, " +
                        "E.EmployeeId," +
                        "E.EmployeeCode as 'Emp Code'," +
                        "E.EmployeeName as 'Employee Name'," +
                        "DES.Designation," +
                        "LA.FromDate as 'From Date'," +
                        "LA.ToDate as 'To Date'," +
                        "LA.TotalDays as 'Total Days'," +
                        "LT.LeaveTypeFName as 'Leave Type'," +
                        "LA.LeaveReason as 'Leave Reason'," +
                        "LA.LeaveStatus as 'Status'," +
                        "E.OpeningLeave as 'Opening'," +
                        "E.CurrentLeave as 'Current'," +
                        "E.TotalApplicableLeave as 'Applicable'," +
                        "E.EnjoyLeave as 'Enjoy'," +
                        "E.TotalLeave," +
                        "E.BalanceLeave as 'Balance'," +
                        "LA.LeaveTypeId," +
                        "LA.IsRevertLeave" +
                        " from " +
                        "LeaveApplication LA inner join  " +
                        "leavetypes LT on LT.LeaveTypeId=LA.LeaveTypeId inner join " +
                        "Employees E on E.EmployeeId=LA.EmployeeId inner join  " +
                        "DepartmentMaster DM on DM.DepartmentId=E.DepartmentId inner join " +
                        "DesignationMaster DES on DES.DesignationId=E.DesignationId inner join " +
                        "LocationMaster LM on LM.LocationId=E.LocationId ";

            //WhereClause_BR = BusinessResources.LeaveApplication_Where;

            //Report Query
            DataSet ds = new DataSet();

            ColumnNames_BR = string.Empty; TableNames_BR = string.Empty; WhereClause_BR = string.Empty; WhereClause = string.Empty; OrderBy = string.Empty;
            DateColumn = string.Empty; EmployeeIn = string.Empty; ContractorIn = string.Empty; StatusIn = string.Empty; DepartmentIn = string.Empty; LocationIdS = string.Empty;

            //Where Clauses All
            DateColumn = " LA.FromDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' ";

            if (objPC.EmployeeId != 0)
                EmployeeIn = " and LA.EmployeeId=" + objPC.EmployeeId + " ";

            if (cmbLocation.SelectedIndex > -1)
                LocationIdS = " and E.LocationId=" + cmbLocation.SelectedValue + " ";

            if (cmbLocation.SelectedIndex > -1)
                DepartmentIn = " and E.DepartmentId=" + cmbDepartment.SelectedValue + " ";

            if (!cbSelectAllLeaveType.Checked)
            {
                if (cmbLeaveType.SelectedIndex > -1)
                    LeaveStatusIn = " and LA.LeaveTypeId=" + cmbLeaveType.SelectedValue + " ";
            }

            if (!cbSelectAllStatus.Checked)
            {
                if (cmbStatus.SelectedIndex > -1)
                    StatusIn = " and LA.LeaveStatus='" + cmbStatus.Text + "' ";
            }

            //ColumnNames_BR = BusinessResources.LeaveApplication_Column;
            //TableNames_BR = BusinessResources.LeaveApplication_Table;
            WhereClause_BR = BusinessResources.LeaveApplication_Where;
            OrderBy = " order by LA.EntryDate asc ";
            // DateColumn = " monthname(LA.EntryDate)='" + cmbMonth.Text + "' and YEAR(LA.EntryDate)='" + cmbYear.Text + "' ";
            WhereClause = " where " + DateColumn + EmployeeIn + LocationIdS + DepartmentIn + ContractorIn + StatusIn + LeaveStatusIn + " ";
            WhereClause = WhereClause + " and " + WhereClause_BR;
            //objQL.ColumnNames_Report = ColumnNames_BR;
            //objQL.TableNames_Report = TableNames_BR;
            //objQL.WhereClause_V = WhereClause;
            //objQL.OrderBy_V = OrderBy;
            //objQL.GroupBy_V = "";
            //ds = objQL.SP_Attendance_Report_Query();

            objBL.Query = MainQuery +  WhereClause;
            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTotalCount.Text = "Total-" + ds.Tables[0].Rows.Count;

                //0 LA.LeaveApplicationId,
                //1 LA.EntryDate,
                //2 LA.EmployeeId,
                //3 LM.LocationName,
                //4 DM.Department, 
                //5 E.EmployeeId,
                //6 E.EmployeeCode,
                //7 E.EmployeeName,
                //8 DES.Designation,
                //9 LA.FromDate,
                //10 LA.ToDate,
                //11 LA.TotalDays,
                //12 LT.LeaveTypeFName,
                //13 LA.LeaveReason,
                //14 LA.LeaveStatus,
                //15 E.TotalLeave, 
                //16 E.OpeningLeave,
                //17 E.BalanceLeave,
                //18 LA.LeaveTypeId,
                //19 LA.IsRevertLeave,

                //0 LA.LeaveApplicationId,
                //1 LA.EntryDate,
                //2 LA.EmployeeId,
                //3 LM.LocationName,
                //4 DM.Department, 
                //5 E.EmployeeId,
                //6 E.EmployeeCode,
                //7 E.EmployeeName,
                //8 DES.Designation,
                //9 LA.FromDate,
                //10 LA.ToDate,
                //11 LA.TotalDays,
                //12 LT.LeaveTypeFName,
                //13 LA.LeaveReason,
                //14 LA.LeaveStatus,
                //15 E.OpeningLeave,
                //16 E.CurrentLeave,
                //17 E.TotalApplicableLeave,
                //18 E.EnjoyLeave,
                //19 E.TotalLeave,
                //20 E.BalanceLeave,
                //21 LA.LeaveTypeId,
                //22 LA.IsRevertLeave
              
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[5].Visible = false;
               // dataGridView1.Columns[10].Visible = false;
                //dataGridView1.Columns[18].Visible = false;
                dataGridView1.Columns[19].Visible = false;
                dataGridView1.Columns[22].Visible = false;
                dataGridView1.Columns[21].Visible = false;

                //dataGridView1.Columns[15].Visible = false;
                //dataGridView1.Columns[16].Visible = false;
                //dataGridView1.Columns[17].Visible = false;

                dataGridView1.Columns[1].Width = 80;
                //dataGridView1.Columns[2].Width = 80;
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].Width = 100;
               // dataGridView1.Columns[5].Width = 180;
                dataGridView1.Columns[6].Width = 100;
                dataGridView1.Columns[7].Width = 200;
                dataGridView1.Columns[8].Width = 150;
                dataGridView1.Columns[9].Width = 100;
                dataGridView1.Columns[10].Width = 100;
                dataGridView1.Columns[11].Width = 100;
                dataGridView1.Columns[12].Width = 120;
                dataGridView1.Columns[13].Width = 120;
                dataGridView1.Columns[14].Width = 100;
                dataGridView1.Columns[15].Width = 100;
                dataGridView1.Columns[16].Width = 100;
                dataGridView1.Columns[17].Width = 100;
                dataGridView1.Columns[18].Width = 100;
                dataGridView1.Columns[19].Width = 100;
                dataGridView1.Columns[20].Width = 100;
                //DEPARTMENT HEAD APPROVED
                //FINAL APPROVED
                //HR APPROVED
                //CANCEL

                Pending_Count = 0; ManagerApproved_Count = 0; HRApproved_Count = 0; Remarks_Count = 0; Reject_Count = 0; Completed_Count = 0;

                string LeaveStatus = string.Empty;int RevertLeaveStatus = 0;
                foreach (DataGridViewRow Myrow in dataGridView1.Rows)
                {
                    LeaveStatus = string.Empty;
                    //Here 2 cell is target value and 1 cell is Volume
                    if (!string.IsNullOrEmpty(Convert.ToString(Myrow.Cells[14].Value)))
                        LeaveStatus = Convert.ToString(Myrow.Cells[14].Value);

                    RevertLeaveStatus = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(Myrow.Cells[22].Value)));

                    //Remark-
                    //Cancel
                    //Remark
                    //Approved
                    //HR Approved

                    if (RevertLeaveStatus == 1) // BusinessResources.LS_Reject)
                    {
                        Reject_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Reject_Color);
                    }
                    else if (LeaveStatus == BusinessResources.LS_Pending)
                    {
                        Pending_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Pending_Color);
                    }
                    else if (LeaveStatus == BusinessResources.LS_ManagerApproved)
                    {
                        ManagerApproved_Count++; HRApproved_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Manager_Color);
                    }
                    else if (LeaveStatus == BusinessResources.LS_HRApproved)
                    {
                        HRApproved_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_HRApproved_Color);
                    }
                    else if (LeaveStatus == BusinessResources.LS_Reject)
                    {
                        Reject_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Reject_Color);
                    }
                    else if (LeaveStatus == BusinessResources.LS_Remarks)
                    {
                        Remarks_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Remarks_Color);
                    }
                    else if (LeaveStatus == BusinessResources.LS_Completed)
                    {
                        Completed_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Completed_Color);
                    }
                    else
                    {
                        Myrow.DefaultCellStyle.BackColor = Color.White;
                         
                    }

                    //if (LeaveStatus == BusinessResources.LS_Pending)
                    //{

                    //}
                    //else if (LeaveStatus == BusinessResources.LS_ManagerApproved)
                    //{

                    //    Myrow.DefaultCellStyle.BackColor = Color.Lime;
                    //}
                    //else if (LeaveStatus == BusinessResources.LS_HRApproved)
                    //{

                    //    Myrow.DefaultCellStyle.BackColor = Color.Cyan;
                    //}
                    //else if (LeaveStatus == BusinessResources.LS_Remarks)
                    //{

                    //    Myrow.DefaultCellStyle.BackColor = Color.Violet;
                    //}
                    //else if (LeaveStatus == BusinessResources.LS_Reject)
                    //{

                    //    Myrow.DefaultCellStyle.BackColor = Color.Tomato;
                    //}

                }
            }
            else
            {
                objRL.ShowMessage(35, 4);
                return;
            }
        }
        private void btnView_Click(object sender, EventArgs e)
        {

        }
    }
}
