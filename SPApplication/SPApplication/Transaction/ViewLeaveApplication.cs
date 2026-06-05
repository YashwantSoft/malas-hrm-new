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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SPApplication
{
    public partial class ViewLeaveApplication : Form
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

        int Pending_Count = 0, ManagerApproved_Count = 0, HRApproved_Count = 0, Remarks_Count = 0, Reject_Count = 0, Completed_Count = 0;
        int SelectedCount = 0;

        public ViewLeaveApplication()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_LEAVELIST);
            //objQL.Fill_Master_ComboBox(cmbLeaveStatus, "attendancestatusmaster");

            //cmbLeaveStatus.Items.Clear();
            //if (BusinessLayer.UserType == BusinessResources.USER_TYPE_PLANTHEAD)
            //    cmbLeaveStatus.Items.Add(BusinessResources.STATUS_FINAL_APPROVED);
            //else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMIN || BusinessLayer.UserType == BusinessResources.USER_TYPE_OFFICER)
            //    cmbLeaveStatus.Items.Add(BusinessResources.STATUS_HR_APPROVED);
            //else
            //    cmbLeaveStatus.Items.Clear();

            //Fill_Status();

            objRL.Fill_Approval_Status(cmbStatus);
            objRL.Fill_Approval_Status(cmbStatusSearch);
        }

        private void Fill_Status()
        {
            //LS_Completed_Color	Lime	
            //LS_Error_Color	    Red	
            //LS_HRApproved_Color	Aqua	
            //LS_InchargeApproved_  Color	HotPink	
            //LS_Manager_Color	    NavajoWhite	
            //LS_Pending_Color	    Yellow	
            //LS_Reject_Color	    DarkOrchid	
            //LS_Remarks_Color	    Khaki	

            //LS_Reject	            Reject	
            //LS_Cancel	            Reject	
            //LS_Completed      	Completed	
            //LS_HRApproved	HR      Approved	
            //LS_InchargeApproved	Incharge Approved	
            //LS_ManagerApproved	Manager Approved	
            //LS_Pending	        Pending	
            //LS_Remarks	        Remarks	



            cmbStatus.Items.Clear();
            cmbStatus.Enabled = true;
            if (BusinessLayer.UserType == BusinessResources.USER_TYPE_INCHARGE)
            {
                cmbStatus.Items.Add(BusinessResources.LS_InchargeApproved);
                cmbStatus.Items.Add(BusinessResources.LS_Pending);
                cmbStatus.Items.Add(BusinessResources.LS_Remarks);
            }
            else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER || BusinessLayer.UserType == BusinessResources.USER_TYPE_PLANTHEAD)
            {
                cmbStatus.Items.Add(BusinessResources.LS_ManagerApproved);
                cmbStatus.Items.Add(BusinessResources.LS_Pending);
                cmbStatus.Items.Add(BusinessResources.LS_Remarks);
                cmbStatus.Items.Add(BusinessResources.LS_Reject);
            }
            else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMIN)
            {
                cmbStatus.Items.Add(BusinessResources.LS_HRApproved);
                cmbStatus.Items.Add(BusinessResources.LS_ManagerApproved);
                cmbStatus.Items.Add(BusinessResources.LS_InchargeApproved);
                cmbStatus.Items.Add(BusinessResources.LS_Completed);
                cmbStatus.Items.Add(BusinessResources.LS_Pending);
                cmbStatus.Items.Add(BusinessResources.LS_Remarks);
                cmbStatus.Items.Add(BusinessResources.LS_Reject);
            }
            else
                cmbStatus.Items.Clear();
        }
       
        private void cbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            SelectedCount = 0; int i=0;
            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];

                    int StatusId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[i].Cells[13].Value)));

                    if (StatusId == 1) // BusinessResources.LS_Pending)
                    {
                        chk.Value = cbSelectAll.CheckState;
                        if (cbSelectAll.Checked)
                            SelectedCount++;
                    }
                    i++;
                }
            }
            lblTotalCount.Text = "Selected Count-" + SelectedCount.ToString();
        }

        private void LeaveList_Load(object sender, EventArgs e)
        {
            FillGrid();

            //if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMIN || BusinessLayer.UserType == BusinessResources.USER_TYPE_OFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_PLANTHEAD || BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER)
            if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR || BusinessLayer.UserType == BusinessResources.USER_TYPE_PLANTHEAD || BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER)
            {
                cbSelectAll.Enabled = true;
                dataGridView1.Enabled = true;
            }

            cbStatus.Checked = true;
        }

        string MainQuery = string.Empty, WhereClauseOther = string.Empty, OrderClause = string.Empty, WhereClause = string.Empty;

        protected void FillGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            DataSet ds = new DataSet();
            MainQuery = string.Empty; WhereClause = string.Empty; WhereClauseOther = string.Empty; OrderClause = string.Empty;
            dataGridView1.DataSource = null;

            MainQuery = "Select distinct " +
                   "LA.LeaveApplicationId, " +
                   "LA.EmployeeId, " +
                   "LM.LocationName, " +
                   "DM.Department, " +
                   "E.EmployeeName as 'Employee Name'," +
                   "DES.Designation," +
                   "LA.LeaveDate as 'Leave Date'," +
                   "LT.LeaveTypeFName as 'Leave Type'," +
                   "LA.LeaveReason as 'Leave Reason'," +
                   "LA.LeaveRemarks as 'Leave Remarks'," +
                   " CASE WHEN LA.ApprovalStatusId = 1 THEN 'Pending' WHEN LA.ApprovalStatusId = 2 THEN 'Completed' WHEN LA.ApprovalStatusId = 3 THEN 'Remarks' WHEN LA.ApprovalStatusId = 6 THEN 'HR Approved' WHEN LA.ApprovalStatusId = 8 THEN 'Manager Approved' ELSE 'Unknown' END AS 'Status', " +
                   "LA.IsRevertLeave, " +
                   "LA.ApprovalStatusId " +
               " from " +
                   " leaveapplication LA inner join " +
                   " leavetypes LT on LT.LeaveTypeId=LA.LeaveTypeId inner join " +
                   " Employees E on E.EmployeeId=LA.EmployeeId inner join " +
                   " DesignationMaster DES on DES.DesignationId=E.DesignationId inner join " +
                   " LocationMaster LM on LM.LocationId=E.LocationId inner join " +
                   " DepartmentMaster DM on DM.DepartmentId=E.DepartmentId inner join " +
                   " locationwisedepartmentusers LWDU on LWDU.LocationId=LM.LocationId and LWDU.DepartmentId=DM.DepartmentId " +
               " where " +
                   "LA.CancelTag=0 and " +
                   "LT.CancelTag=0 and " +
                   "E.CancelTag=0 and " +
                   "DM.CancelTag=0 and " +
                   "DES.CancelTag=0 and " +
                   "LM.CancelTag=0 and " +
                   "LWDU.CancelTag=0 ";

            if(SearchFlag)
            {
                if (SearchFlag && txtSearch.Text != "")
                    WhereClause += " and E.EmployeeName LIKE '%" + txtSearch.Text + "%'";
                else
                    WhereClause += string.Empty;
            }

            //if (BusinessLayer.Department == "COMPLIANCE" || BusinessLayer.Department == "TIME OFFICE")
            //{

            //}
            //else
            //{
            //    WhereClause = " and E.EmployeeId=" + BusinessLayer.EmployeeLoginId_Static + " ";
            //}

                //if (BusinessLayer.UserType == "ADMINISTRATOR")
                //{
                //    if (SearchFlag && txtSearch.Text != "")
                //        WhereClause += " and E.EmployeeName LIKE '%" + txtSearch.Text + "%'";
                //    else
                //        WhereClause += string.Empty;
                //}
                //else
                //    WhereClause = " and E.EmployeeId=" + BusinessLayer.EmployeeLoginId_Static + " ";

                WhereClause += " and LA.FinancialYearId=" + objPC.FinancialYearId + " ";

            OrderClause = " order by LA.LeaveApplicationId desc ";

            //objBL.Query = MainQuery + WhereClause + OrderClause;

           // OrderClause = " order by LA.LeaveApplicationId desc ";

            objBL.Query = MainQuery + objRL.WhereClasuse_CompOff_Comman() + WhereClause + OrderClause;

            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTotalCount.Text = "Total-" + ds.Tables[0].Rows.Count;

                //0	  LA.LeaveApplicationId,  +
                //1   LA.EmployeeId,  +
                //2   LM.LocationName,  +
                //3   DM.Department,  +
                //4   E.EmployeeName as 'Employee Name', +
                //5   DES.Designation, +
                //6   LA.LeaveDate as 'Leave Date', +
                //7   LT.LeaveTypeFName as 'Leave Type', +
                //8   LA.LeaveReason as 'Leave Reason', +
                //9   LA.LeaveRemarks as 'Leave Remarks', +
                //10   CASE WHEN LA.ApprovalStatusId = 1 THEN 'Pending' WHEN LA.ApprovalStatusId = 2 THEN 'Completed' WHEN LA.ApprovalStatusId = 3 THEN 'Remarks' WHEN LA.ApprovalStatusId = 6 THEN 'HR Approved' WHEN LA.ApprovalStatusId = 8 THEN 'Manager Approved' ELSE 'Unknown' END AS 'Status',  +
                //11  LA.IsRevertLeave,  +
                //12  LA.ApprovalStatusId +

                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                checkColumn.Name = "clmSelect";
                checkColumn.HeaderText = "Select";
                checkColumn.Width = 50;
                checkColumn.ReadOnly = false;
                checkColumn.FillWeight = 10; //if the datagridview is resized (on form resize) the checkbox won't take up too much; value is relative to the other columns' fill values
                dataGridView1.Columns.Add(checkColumn);


                dataGridView1.DataSource = ds.Tables[0];
                //dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;

                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = false;

                dataGridView1.Columns[3].Width = 80;
                dataGridView1.Columns[4].Width = 120;
                dataGridView1.Columns[5].Width = 200;
                dataGridView1.Columns[6].Width = 100;
                dataGridView1.Columns[7].Width = 100;
                dataGridView1.Columns[8].Width = 80;
                dataGridView1.Columns[9].Width = 150;
                dataGridView1.Columns[10].Width = 150;
                dataGridView1.Columns[12].Width = 80;
               
                objRL.Set_Approval_Colour_DataGridView(dataGridView1, lblPending, lblHRApproved, lblManagerApproved, lblRemark, lblCompleted, "ApprovalStatusId");

                dataGridView1.ClearSelection();
            }
        }

        protected void FillGridOld()
        {
            OrderClause = string.Empty;
            WhereClause = string.Empty;
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            DataSet ds = new DataSet();

            if (SearchFlag && txtSearch.Text != "")
                WhereClause = " and E.EmployeeName LIKE '%" + txtSearch.Text + "%'";
            else
                WhereClause = string.Empty;

            if (!cbStatus.Checked)
            {
                if (cmbStatusSearch.SelectedIndex > -1)
                {
                    //cmbStatusSearch.Text = BusinessResources.LS_Pending;
                    WhereClause += " and LA.LeaveStatus='" + cmbStatusSearch.Text + "' ";
                }
                else
                    WhereClause += "";
            }
            else
                WhereClause += "";

            WhereClause += " and LA.FinancialYearId=" + objPC.FinancialYearId + " ";

            OrderClause = " order by LA.LeaveApplicationId desc ";

            objBL.Query = BusinessResources.LEAVE_LIST_QUERY + objRL.WhereClasuse_CompOff_Comman() + WhereClause + OrderClause;
            ds = objBL.ReturnDataSet();
            //ds = objQL.SP_LeaveApplication_FillGrid();

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTotalCount.Text = "Total Count-" + ds.Tables[0].Rows.Count.ToString();

                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                checkColumn.Name = "clmSelect";
                checkColumn.HeaderText = "Select";
                checkColumn.Width = 50;
                checkColumn.ReadOnly = false;
                checkColumn.FillWeight = 10; //if the datagridview is resized (on form resize) the checkbox won't take up too much; value is relative to the other columns' fill values
                dataGridView1.Columns.Add(checkColumn);

                //lblTotalCount.Text = "Total-" + ds.Tables[0].Rows.Count;

                //0 Check Box
                //1 LA.LeaveApplicationId,
                //2 LA.EntryDate as 'Date',
                //3 LA.EmployeeId,
                //4 LM.LocationName,
                //5 DM.Department,
                //6 E.EmployeeName as 'Employee Name',
                //7 DES.Designation,
                //8 LA.FromDate as 'From Date',
                //9 LA.ToDate as 'To Date',
                //10 LA.TotalDays as 'Total Days',
                //11 LT.LeaveTypeFName as 'Leave Type',
                //12 LA.LeaveReason as 'Leave Reason',
                //13 LA.LeaveStatus as 'Leave Status',
                //14 E.TotalLeave,
                //15 LA.LeaveTypeId
                //16 LA.IsRevertLeave

                dataGridView1.DataSource = ds.Tables[0];
                //dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[14].Visible = false; 
                dataGridView1.Columns[15].Visible = false;
                dataGridView1.Columns[16].Visible = false;
                //dataGridView1.Columns[17].Visible = false;

                dataGridView1.Columns[0].Width = 60;
                dataGridView1.Columns[2].Width = 80;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].Width = 100;
                dataGridView1.Columns[6].Width = 200;
                dataGridView1.Columns[7].Width = 150;
                dataGridView1.Columns[8].Width = 100;
                dataGridView1.Columns[9].Width = 80;
                dataGridView1.Columns[10].Width = 100;
                dataGridView1.Columns[11].Width = 120;
                dataGridView1.Columns[12].Width = 120;
                dataGridView1.Columns[14].Width = 120;

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
                    if (!string.IsNullOrEmpty(Convert.ToString(Myrow.Cells[13].Value)))
                        LeaveStatus = Convert.ToString(Myrow.Cells[13].Value);

                    RevertLeaveStatus = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(Myrow.Cells[16].Value)));

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
                        ManagerApproved_Count++;  
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Manager_Color);
                    }
                    else if (LeaveStatus == BusinessResources.LS_HRApproved)
                    {
                        HRApproved_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_HRApproved_Color);
                    }
                    //else if (LeaveStatus == BusinessResources.LS_Reject)
                    //{
                    //    Reject_Count++;
                    //    Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Reject_Color);
                    //}
                    else if (LeaveStatus == BusinessResources.LS_Remarks)
                    {
                        Remarks_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Remarks_Color);
                    }
                    else if (LeaveStatus == BusinessResources.LS_Completed)
                    {
                        Completed_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Completed_Color);
                        Myrow.Cells[0].ReadOnly = true;
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Get_SelectedCount_CheckBox()
        {
            SelectedCount = 0;
            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];

                    if(Convert.ToBoolean(chk.Value))// = cbSelectAll.CheckState;
                        SelectedCount++;
                }
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            gbApproval.Visible = false;
            // Check if the changed cell is in the checkbox column
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                bool isChecked = (bool)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                // int ID= Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clmAttendanceRecordId"].Value);
                if (isChecked)
                {
                    gbApproval.Visible = true;
                    //if break;
                }



                //MessageBox.Show($"Checkbox at row {e.RowIndex} is now {(isChecked ? "checked" : "unchecked")}");
            }
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            string status = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Status"].Value);

            if (status == BusinessResources.LS_Completed)
            {
                e.Cancel = true; // stops editing
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Get_SelectedCount_CheckBox();

            if (cmbStatus.SelectedIndex > -1 && SelectedCount >0)
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    //0	  LA.LeaveApplicationId,  +
                    //1   LA.EmployeeId,  +
                    //2   LM.LocationName,  +
                    //3   DM.Department,  +
                    //4   E.EmployeeName as 'Employee Name', +
                    //5   DES.Designation, +
                    //6   LA.LeaveDate as 'Leave Date', +
                    //7   LT.LeaveTypeFName as 'Leave Type', +
                    //8   LA.LeaveReason as 'Leave Reason', +
                    //9   LA.LeaveRemarks as 'Leave Remarks', +
                    //10   CASE WHEN LA.ApprovalStatusId = 1 THEN 'Pending' WHEN LA.ApprovalStatusId = 2 THEN 'Completed' WHEN LA.ApprovalStatusId = 3 THEN 'Remarks' WHEN LA.ApprovalStatusId = 6 THEN 'HR Approved' WHEN LA.ApprovalStatusId = 8 THEN 'Manager Approved' ELSE 'Unknown' END AS 'Status',  +
                    //11  LA.IsRevertLeave,  +
                    //12  LA.ApprovalStatusId +

                    List<int> selectedIds = new List<int>();
                    List<int> selectedEmployeeIds = new List<int>();
                    List<DateTime> selectedLeaveDate = new List<DateTime>();

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue;

                        var cellValue = row.Cells[0].Value;

                        if (cellValue != null && Convert.ToBoolean(cellValue))
                        {
                            selectedIds.Add(Convert.ToInt32(row.Cells["LeaveApplicationId"].Value));
                            selectedEmployeeIds.Add(Convert.ToInt32(row.Cells["EmployeeId"].Value));
                            selectedLeaveDate.Add(Convert.ToDateTime(row.Cells["Leave Date"].Value));
                        }
                    }

                    if (selectedIds.Count > 0)
                    {
                        string ids = string.Join(",", selectedIds);
                        string idEmployees = string.Join(",", selectedEmployeeIds);
                        objBL.Query = $"UPDATE leaveapplication SET ApprovalStatusId = " + cmbStatus.SelectedValue + " WHERE LeaveApplicationId IN ("+ids+")";
                        Result = objBL.Function_ExecuteNonQuery();

                        if (Result > 0)
                        {
                            if (BusinessLayer.Department == "ADMINISTRATOR" || BusinessLayer.Department == "TIME OFFICE")
                            {
                               string query = @"
                                                UPDATE Employees e
                                                LEFT JOIN (
                                                    SELECT EmployeeId, COALESCE(Count(LeaveApplicationId), 0) AS UsedLeave
                                                    FROM LeaveApplication
                                                    WHERE CancelTag = 0 AND ApprovalStatusId=2
                                                    GROUP BY EmployeeId
                                                ) la ON e.EmployeeId = la.EmployeeId
                                                SET e.BalanceLeave = (e.TotalLeave + e.OpeningLeave) - COALESCE(la.UsedLeave, 0)
                                                WHERE e.CancelTag = 0
                                                AND e.EmployeeId IN ({0})";

                               query = string.Format(query, idEmployees); // still risky if not controlled!
                               objBL.Query = query;

                               Result = objBL.Function_ExecuteNonQuery();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No rows selected.");
                    }
                    FillGrid();
                }


                //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                //    {
                //        Status = string.Empty; LeaveApplicationId_Grid = 0;
                //        if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value))
                //        {
                //            if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[i].Cells[1].Value.ToString())))
                //            {
                //                Status = cmbStatus.Text;// Convert.ToString(dataGridView1.Rows[i].Cells[12].Value.ToString());
                //                LeaveApplicationId_Grid = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value.ToString());

                //                if(!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[i].Cells[14].Value)))
                //                    TotalLeavesAssigned = Convert.ToInt32(dataGridView1.Rows[i].Cells[14].Value.ToString());

                //                //if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[i].Cells[2].Value.ToString())))
                //                EmpId = Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value.ToString());

                //                objPC.LeaveApplicationId = LeaveApplicationId_Grid;
                //                objPC.LeaveStatus = Status;
                //                objPC.Remarks = txtRemarks.Text;

                //                //if (Status == BusinessResources.STATUS_FINAL_APPROVED || Status == BusinessResources.STATUS_HR_APPROVED)
                //                //{
                //                //    //Update Database
                //                //    if (Status == BusinessResources.STATUS_HR_APPROVED)
                //                //    {
                //                //        Get_Leave_Count();
                //                //    }
                //                //}

                //                //if (cmbLeaveStatus.Text == BusinessResources.LS_Remarks)
                //                //{
                //                //    if (!string.IsNullOrEmpty(Convert.ToString(txtRemarks.Text)))
                //                //        objPC.Remarks = txtRemarks.Text;
                //                //}
                //                //else
                                  
                //                objPC.EmployeeId = EmpId;
                //                objPC.BalanceLeave = BalanceLeave.ToString();
                //                Result = objQL.SP_LeaveApplication_Update_LeaveStatus();

                //                objBL.Query = string.Empty;

                //                objBL.Query = "update LeaveApplication set " +
                //                              "LeaveStatus = LeaveStatus_V, " +
                //                              "Remarks = Remarks_V " +
                //                              "where " +
                //                              "CancelTag = 0 and " +
                //                              "LeaveApplicationId = LeaveApplicationId_V";

                                
                //    END IF;

                //    if (Result > 0)
                //                {
                //                    if (Status == BusinessResources.LS_Completed)
                //                    {
                //                        DataSet dsEMP = new DataSet();
                //                        dsEMP = objQL.SP_Employees_By_EmployeeId();

                //                        if (dsEMP.Tables[0].Rows.Count > 0)
                //                        {
                //                            objRL.Get_CategoriesDetails_By_Id();
                //                            objPC.ShiftGroupId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dsEMP.Tables[0].Rows[0]["ShiftGroupId"])));
                //                            objPC.OverTimeApplicable = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dsEMP.Tables[0].Rows[0]["OverTimeApplicable"])));

                //                            //dtpFromDateL = Convert.ToDateTime(objRL.CheckNullString(Convert.T8oString(ds.Tables[0].Rows[i]["FromDate"])));
                //                            //dtpToDateL = Convert.ToDateTime(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["FromDate"])));

                //                            dtpFromDateL = Convert.ToDateTime(dataGridView1.Rows[i].Cells[8].Value.ToString());
                //                            dtpToDateL = Convert.ToDateTime(dataGridView1.Rows[i].Cells[9].Value.ToString());

                //                            //objAL.CalculationsDate_Leave(dtpFromDateL, dtpToDateL);
                //                        }
                //                    }
                //                }
                //            }
                //        }
                //    }
                //    objAL.Update_Present_Absent();
                //    ClearAll();
                //}
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
                SearchFlag = true;
            else
                SearchFlag = false;

            FillGrid();
        }

        DateTime dtpFromDateL, dtpToDateL;

        AttendanceLogics objAL = new AttendanceLogics();

        string Status = string.Empty;


        private void ClearAll()
        {
            dataGridView1.DataSource = null;
            TotalLeavesAssigned = 0; TotalLeaveUsed = 0; BalanceLeave = 0; EmpId = 0; LeaveApplicationId_Grid = 0; Result = 0;
            Pending_Count = 0; ManagerApproved_Count = 0; HRApproved_Count = 0; Remarks_Count = 0; Reject_Count = 0; Completed_Count = 0;

            cmbStatus.SelectedIndex = -1;
            txtRemarks.Text = "";
            cbSelectAll.Checked = false;
            lblTotalCount.Text = "";
            lblPending.Text = "";
            lblManagerApproved.Text = "";
            lblHRApproved.Text = "";
            lblReject.Text = "";
            lblCompleted.Text = "";
            lblRemark.Text = "";
            SearchFlag = false;
            txtSearch.Text = "";
            FillGrid();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        double TotalLeavesAssigned = 0, TotalLeaveUsed = 0, BalanceLeave=0;
        int EmpId = 0, LeaveApplicationId_Grid=0;

        private void Get_Leave_Count()
        {
            DataSet ds = new DataSet();
            objPC.EmployeeId = EmpId;
            objPC.LeaveStatus = BusinessResources.STATUS_HR_APPROVED;

            ds = objQL.SP_LeaveApplication_Get_Leave_Count_By_EmployeeId();

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][0].ToString())))
                    TotalLeaveUsed = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
            }
            BalanceLeave = TotalLeavesAssigned - TotalLeaveUsed;
        }

        private void cmbStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbStatus.SelectedIndex > -1)
            {
                lblRemarksMain.Visible = false;
                txtRemarks.Visible = false;

                if (cmbStatus.Text == BusinessResources.LS_Remarks || cmbStatus.Text == BusinessResources.LS_Reject)
                {
                    lblRemarksMain.Visible = true;
                    txtRemarks.Visible = true;
                }
            }
        }

        private void cbStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStatus.Checked)
            {
                cmbStatusSearch.SelectedIndex = -1;
                cmbStatusSearch.Enabled = false;
            }
            else
            {
                cmbStatusSearch.SelectedIndex = -1;
                cmbStatusSearch.Enabled = true;
                cmbStatusSearch.Text = BusinessResources.LS_Pending;
            }

            FillGrid();
        }

        private void cmbStatusSearch_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbStatusSearch.SelectedIndex > -1)
                FillGrid();
        }
    }
}
