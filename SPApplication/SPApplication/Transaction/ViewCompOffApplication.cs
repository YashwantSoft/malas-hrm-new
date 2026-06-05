using BusinessLayerUtility;
using MySql.Data.MySqlClient;
using SPApplication.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPApplication.Transaction
{
    public partial class ViewCompOffApplication : Form
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

        int Pending_Count = 0, ManagerApproved_Count = 0, HRApproved_Count = 0, Reject_Count = 0, Remarks_Count = 0, Completed_Count = 0;
        int SelectedCount = 0;

        double TotalLeavesAssigned = 0, TotalLeaveUsed = 0, BalanceLeave = 0;
        int EmpId = 0, LeaveApplicationId_Grid = 0;
        public ViewCompOffApplication()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_COMPOFFLIST);
            objRL.Fill_Approval_Status(cmbStatus);
            objRL.Fill_Approval_Status(cmbStatusSearch);
        }

        private void CompOffList_Load(object sender, EventArgs e)
        {
            ClearAll();
            FillGrid();

            if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR || BusinessLayer.UserType == BusinessResources.USER_TYPE_PLANTHEAD || BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER)
            {
                cbSelectAll.Enabled = true;
                dataGridView1.Enabled = true;
            }
        }

        private void cbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            SelectedCount = 0;
            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    chk.Value = cbSelectAll.CheckState;

                    if (cbSelectAll.Checked)
                        SelectedCount++;
                }
            }
            lblTotalCount.Text = "Selected Count-" + SelectedCount.ToString();
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
                SearchFlag = true;
            else
                SearchFlag = false;

            FillGrid();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        int EmployeeId = 0;
        string DestinationPath = string.Empty;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string columnName = dataGridView1.Columns[e.ColumnIndex].Name;

                // Check if clicked column is clmView
                if (columnName == "clmView")
                {
                    // Get file path from another column (example: "FilePath")
                    string filePath = dataGridView1.Rows[e.RowIndex].Cells[19].Value?.ToString();

                    EmployeeId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value)));

                    if (!string.IsNullOrEmpty(filePath) && EmployeeId > 0)
                    {
                        DestinationPath = string.Empty;
                        DestinationPath = objRL.GetPath("CompOffFiles") + EmployeeId + "\\" + filePath;

                        if (File.Exists(DestinationPath))
                            // Open file
                            System.Diagnostics.Process.Start(DestinationPath);
                        else
                            MessageBox.Show("File not found.");
                    }
                    else
                    {
                        MessageBox.Show("File not found.");
                    }
                }
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
            
        }

        private void Get_SelectedCount_CheckBox()
        {
            SelectedCount = 0;
            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];

                    if (Convert.ToBoolean(chk.Value))// = cbSelectAll.CheckState;
                        SelectedCount++;
                }
            }
        }

        private bool Validation()
        {
            objEP.Clear();
            Get_SelectedCount_CheckBox();

            if (cmbStatus.SelectedIndex == -1)
            {
                cmbStatus.Focus();
                objEP.SetError(cmbStatus, "Select Status");
                return true;
            }
            else if (SelectedCount == 0)
            {
                dataGridView1.Focus();
                objEP.SetError(dataGridView1, "Select at last one comp off");
                return true;
            }
            else if (dataGridView1.Rows.Count == 0)
            {
                dataGridView1.Focus();
                objEP.SetError(dataGridView1, "Select Status");
                return true;
            }
            else
                return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveDB();
        }

        private void SaveDB()
        {
            Get_SelectedCount_CheckBox();

            if (!Validation())
            {
                if (cmbStatus.SelectedIndex > -1 && SelectedCount > 0)
                {
                    if (dataGridView1.Rows.Count > 0)
                    {
                        //0   COA.CompOffApplicationId,  +
                        //1   COA.EmployeeId,  +
                        //2   LM.LocationName,  +
                        //3   DM.Department,  +
                        //4   E.EmployeeName as 'Employee Name', +
                        //5   DES.Designation, +
                        //6   COA.CompOffDate as 'Comp Off Date', +
                        //7   COA.ReasonOfCompOff as 'Reason Of Comp Off', +
                        //8   COA.WorkRemarks as 'Work Remarks', +
                        //9   COA.CompStatusId as 'ApprovalStatusId', +
                        //10   CASE WHEN COA.CompStatusId = 1 THEN 'Pending' WHEN COA.CompStatusId = 2 THEN 'Completed' WHEN COA.CompStatusId = 3 THEN 'Remarks' WHEN COA.CompStatusId = 6 THEN 'HR Approved' WHEN COA.CompStatusId = 8 THEN 'Manager Approved' ELSE 'Unknown' END AS 'Status',  +
                        //11  COA.CompOffDueDate,  +
                        //12  COA.IsCompOffExpired,  +
                        //13  COA.IsUsedCompOff,  +
                        //14  COA.UsedCompOffDate as 'Used Comp Off Date',  +
                        //15  COA.UsedCompStatusId,  +
                        //16   CASE WHEN COA.UsedCompStatusId = 1 THEN 'Pending' WHEN COA.UsedCompStatusId = 2 THEN 'Completed' WHEN COA.UsedCompStatusId = 3 THEN 'Remarks' WHEN COA.UsedCompStatusId = 6 THEN 'HR Approved' WHEN COA.UsedCompStatusId = 8 THEN 'Manager Approved' ELSE 'Unknown' END AS 'Used Status',  +
                        //17  COA.FinancialYearId +
                        //18 "COA.FileName " +

                        List<int> selectedIds = new List<int>();
                        List<int> selectedEmployeeIds = new List<int>();
                        List<DateTime> selectedCompOffDate = new List<DateTime>();
                        List<DateTime> selectedCompOffUsedDate = new List<DateTime>();

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.IsNewRow) continue;

                            var cellValue = row.Cells[0].Value;

                            if (cellValue != null && Convert.ToBoolean(cellValue))
                            {
                                selectedIds.Add(Convert.ToInt32(row.Cells["CompOffApplicationId"].Value));
                                selectedEmployeeIds.Add(Convert.ToInt32(row.Cells["EmployeeId"].Value));
                                //selectedCompOffDate.Add(Convert.ToDateTime(row.Cells["Comp Off Date"].Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD)));

                                if (row.Cells["Comp Off Date"].Value is DateTime date)
                                {
                                    selectedCompOffDate.Add(date);
                                }

                                //selectedCompOffUsedDate.Add(Convert.ToDateTime(row.Cells["Used Comp Off Date"].Value));
                            }
                        }

                        if (selectedIds.Count > 0)
                        {
                            var idParams = selectedIds.Select((id, i) => $"@CompOffApplicationId{i}").ToList();
                            var empParams = selectedEmployeeIds.Select((id, i) => $"@EmployeeId{i}").ToList();


                            string ids = string.Join(",", selectedIds);
                            string idEmployees = string.Join(",", selectedEmployeeIds);
                            string ColumnUpdate = string.Empty;
                            string ColumnNameStatus = string.Empty;

                            // Use list directly
                            //var ids = selectedIds;
                            var empIds = selectedEmployeeIds;

                            // Create parameters for EmployeeIds
                            var paramNames = empIds
                                .Select((id, index) => $"@EmployeeId{index}")
                                .ToList();

                            // Safe column selection
                            string conditionUsed;

                            if (!cbCompOffUsed.Checked)
                            {
                                ColumnUpdate = " CompStatusId = @Status";
                                conditionUsed = " CompStatusId = 2";
                            }
                            else
                            {
                                ColumnUpdate = " UsedCompStatusId = @Status";
                                conditionUsed = " IsUsedCompOff = 1 AND UsedCompStatusId = 2";
                            }
                             
                            if (!cbCompOffUsed.Checked)
                            {
                                ColumnUpdate = " CompStatusId=" + cmbStatus.SelectedValue + " ";
                                //ColumnNameStatus = "CompStatusId";
                                ColumnNameStatus = " AND CompStatusId=2 ";
                            }
                            else
                            {
                                ColumnUpdate = " UsedCompStatusId=" + cmbStatus.SelectedValue + " ";
                                ColumnNameStatus = " AND IsUsedCompOff=1 AND UsedCompStatusId=2 ";
                            }

                            objBL.Query = $"UPDATE compoffapplication SET " + ColumnUpdate + " WHERE CompOffApplicationId IN (" + ids + ")";
                            Result = objBL.Function_ExecuteNonQuery();

                            if (Result > 0)
                            {
                                objBL.objCmd.Parameters.Clear();

                                string query = $@"
                                                UPDATE Employees e
                                                LEFT JOIN (
                                                    SELECT 
                                                        EmployeeId,
                                                        COUNT(CompOffApplicationId) AS CompOffCount,
                                                        SUM(CASE WHEN {conditionUsed} THEN 1 ELSE 0 END) AS CompOffUsedCount
                                                    FROM compoffapplication
                                                    WHERE CancelTag = 0
                                                    GROUP BY EmployeeId
                                                ) la ON e.EmployeeId = la.EmployeeId
                                                SET e.CompOffBalance = 
                                                    COALESCE(la.CompOffCount, 0) - COALESCE(la.CompOffUsedCount, 0)
                                                WHERE e.CancelTag = 0
                                                AND e.EmployeeId IN (" + idEmployees + ")";
                                                //AND e.EmployeeId IN({ string.Join(",", empParams)})";



                                objBL.Query = query;

                                //for (int i = 0; i < selectedEmployeeIds.Count; i++)
                                //{
                                //    objBL.objCmd.Parameters.AddWithValue(empParams[i], selectedEmployeeIds[i]);
                                //}

                                Result = objBL.Function_ExecuteNonQuery();
                            }
                             
                            if (Result > 0 && cmbStatus.Text == BusinessResources.LS_Completed)
                            {
                                if (selectedCompOffDate.Count > 0)
                                {
                                    for (int i = 0; i < ids.Length; i++)
                                    {
                                        //paramNames.Add($"@id{i}");

                                        int EID = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(selectedEmployeeIds[i])));
                                        if (EID > 0)
                                        {
                                            var dates = selectedCompOffDate; // List<DateTime>
                                            var dateParams = dates.Select((d, p) => $"@date{p}").ToList();

                                            var query = $@"
                                            UPDATE attendancelogs 
                                            SET Status = 'CO'
                                            WHERE CancelTag = 0
                                            AND AttendanceDate IN ({string.Join(",", dateParams)})
                                            AND EmployeeId = @empId";

                                            objBL.Connect();
                                            using (var cmd = new MySqlCommand(query, objBL.objCon))
                                            {
                                                cmd.Parameters.AddWithValue("@empId", EID);

                                                for (int j = 0; j < dates.Count; j++)
                                                {
                                                    cmd.Parameters.AddWithValue(dateParams[j], dates[j]);
                                                }

                                                Result = cmd.ExecuteNonQuery();
                                            }

                                            //string query = string.Empty;
                                            //query= "update attendancelogs set Status='CO' where CancelTag=0 and AttendanceDate IN ('"+ selectedCompOffDate + "') and  EmployeeId IN (" + idEmployees + ") ";
                                            //objBL.Query = query;
                                            //Result = objBL.Function_ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No rows selected.");
                }
                FillGrid();
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
             
        }

        private void SaveDB1()
        {
            Get_SelectedCount_CheckBox();

            if (!Validation())
            {
                if (cmbStatus.SelectedIndex > -1 && SelectedCount > 0)
                {
                    if (dataGridView1.Rows.Count > 0)
                    {
                        //0   COA.CompOffApplicationId,  +
                        //1   COA.EmployeeId,  +
                        //2   LM.LocationName,  +
                        //3   DM.Department,  +
                        //4   E.EmployeeName as 'Employee Name', +
                        //5   DES.Designation, +
                        //6   COA.CompOffDate as 'Comp Off Date', +
                        //7   COA.ReasonOfCompOff as 'Reason Of Comp Off', +
                        //8   COA.WorkRemarks as 'Work Remarks', +
                        //9   COA.CompStatusId as 'ApprovalStatusId', +
                        //10   CASE WHEN COA.CompStatusId = 1 THEN 'Pending' WHEN COA.CompStatusId = 2 THEN 'Completed' WHEN COA.CompStatusId = 3 THEN 'Remarks' WHEN COA.CompStatusId = 6 THEN 'HR Approved' WHEN COA.CompStatusId = 8 THEN 'Manager Approved' ELSE 'Unknown' END AS 'Status',  +
                        //11  COA.CompOffDueDate,  +
                        //12  COA.IsCompOffExpired,  +
                        //13  COA.IsUsedCompOff,  +
                        //14  COA.UsedCompOffDate as 'Used Comp Off Date',  +
                        //15  COA.UsedCompStatusId,  +
                        //16   CASE WHEN COA.UsedCompStatusId = 1 THEN 'Pending' WHEN COA.UsedCompStatusId = 2 THEN 'Completed' WHEN COA.UsedCompStatusId = 3 THEN 'Remarks' WHEN COA.UsedCompStatusId = 6 THEN 'HR Approved' WHEN COA.UsedCompStatusId = 8 THEN 'Manager Approved' ELSE 'Unknown' END AS 'Used Status',  +
                        //17  COA.FinancialYearId +
                        //18 "COA.FileName " +

                        List<int> selectedIds = new List<int>();
                        List<int> selectedEmployeeIds = new List<int>();
                        List<DateTime> selectedCompOffDate = new List<DateTime>();
                        List<DateTime> selectedCompOffUsedDate = new List<DateTime>();

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.IsNewRow) continue;

                            var cellValue = row.Cells[0].Value;

                            if (cellValue != null && Convert.ToBoolean(cellValue))
                            {
                                selectedIds.Add(Convert.ToInt32(row.Cells["CompOffApplicationId"].Value));
                                selectedEmployeeIds.Add(Convert.ToInt32(row.Cells["EmployeeId"].Value));
                                selectedCompOffDate.Add(Convert.ToDateTime(row.Cells["Comp Off Date"].Value));
                                //selectedCompOffUsedDate.Add(Convert.ToDateTime(row.Cells["Used Comp Off Date"].Value));
                            }
                        }

                        if (selectedIds.Count > 0)
                        {
                           
                            string ids = string.Join(",", selectedIds);
                            string idEmployees = string.Join(",", selectedEmployeeIds);
                            string ColumnUpdate = string.Empty;
                            string ColumnNameStatus = string.Empty;

                            // Use list directly
                            //var ids = selectedIds;
                            var empIds = selectedEmployeeIds;

                            // Create parameters for EmployeeIds
                            var paramNames = empIds
                                .Select((id, index) => $"@EmployeeId{index}")
                                .ToList();

                            // Safe column selection
                            string conditionUsed;

                            if (!cbCompOffUsed.Checked)
                            {
                                ColumnUpdate = " CompStatusId = @Status";
                                conditionUsed = " CompStatusId = 2";
                            }
                            else
                            {
                                ColumnUpdate = " UsedCompStatusId = @Status";
                                conditionUsed = " IsUsedCompOff = 1 AND UsedCompStatusId = 2";
                            }

                            

                            //objBL.Query = $"UPDATE compoffapplication SET {ColumnUpdate} WHERE CompOffApplicationId IN ({string.Join(",", ids)})";

                            //objBL.objCmd.Parameters.Clear();
                            //objBL.objCmd.Parameters.AddWithValue("@Status", cmbStatus.SelectedValue);

                            //Result = objBL.Function_ExecuteNonQuery();

                            //// ✅ Update compoffapplication (parameterized)
                            //objBL.Query = $"UPDATE compoffapplication SET " + ColumnUpdate + " WHERE CompOffApplicationId IN (" + ids + ")";

                            //objBL.objCmd.Parameters.Clear();
                            //objBL.objCmd.Parameters.AddWithValue("@Status", cmbStatus.SelectedValue);

                            //Result = objBL.Function_ExecuteNonQuery();


                            if (!cbCompOffUsed.Checked)
                            {
                                ColumnUpdate = " CompStatusId=" + cmbStatus.SelectedValue + " ";
                                //ColumnNameStatus = "CompStatusId";
                                ColumnNameStatus = " AND CompStatusId=2 ";
                            }
                            else
                            {
                                ColumnUpdate = " UsedCompStatusId=" + cmbStatus.SelectedValue + " ";
                                ColumnNameStatus = " AND IsUsedCompOff=1 AND UsedCompStatusId=2 ";
                            }

                            objBL.Query = $"UPDATE compoffapplication SET " + ColumnUpdate + " WHERE CompOffApplicationId IN (" + ids + ")";
                            Result = objBL.Function_ExecuteNonQuery();

                            if (Result > 0)
                            {
                                string query = $@"
                                                UPDATE Employees e
                                                LEFT JOIN (
                                                    SELECT 
                                                        EmployeeId,
                                                        COUNT(CompOffApplicationId) AS CompOffCount,
                                                        SUM(CASE WHEN {conditionUsed} THEN 1 ELSE 0 END) AS CompOffUsedCount
                                                    FROM compoffapplication
                                                    WHERE CancelTag = 0
                                                    GROUP BY EmployeeId
                                                ) la ON e.EmployeeId = la.EmployeeId
                                                SET e.CompOffBalance = 
                                                    COALESCE(la.CompOffCount, 0) - COALESCE(la.CompOffUsedCount, 0)
                                                WHERE e.CancelTag = 0
                                                AND e.EmployeeId IN ({string.Join(",", paramNames)})";

                                objBL.Query = query;
                                objBL.objCmd.Parameters.Clear();

                                // Bind EmployeeIds correctly
                                for (int i = 0; i < empIds.Count; i++)
                                {
                                    objBL.objCmd.Parameters.AddWithValue(paramNames[i], empIds[i]);
                                }

                                Result = objBL.Function_ExecuteNonQuery();
                            }



                            //if (!cbCompOffUsed.Checked)
                            //{
                            //    ColumnUpdate = " CompStatusId=" + cmbStatus.SelectedValue + " ";
                            //    //ColumnNameStatus = "CompStatusId";
                            //    ColumnNameStatus = " AND CompStatusId=2 ";
                            //}
                            //else
                            //{
                            //    ColumnUpdate = " UsedCompStatusId=" + cmbStatus.SelectedValue + " ";
                            //    ColumnNameStatus = " AND IsUsedCompOff=1 AND UsedCompStatusId=2 ";
                            //}

                            //objBL.Query = $"UPDATE compoffapplication SET " + ColumnUpdate + " WHERE CompOffApplicationId IN (" + ids + ")";
                            //Result = objBL.Function_ExecuteNonQuery();

                            //if (Result > 0)
                            //{
                            //    if (BusinessLayer.Department == "ADMINISTRATOR" || BusinessLayer.Department == "TIME OFFICE")
                            //    {
                            //        //var ids = idEmployees.Split(',');

                            //        //var paramNames = new List<string>();
                            //        var paramNames = idEmployees.Select((id, index) => $"@EmployeeId{index}").ToList();

                            //        //for (int i = 0; i < ids.Length; i++)
                            //        //{
                            //        //    paramNames.Add($"@id{i}");
                            //        //}

                            //        string query = $@"
                            //                        UPDATE Employees e
                            //                        LEFT JOIN (
                            //                            SELECT 
                            //                                EmployeeId,
                            //                                COUNT(CompOffApplicationId) AS CompOffCount,
                            //                                SUM(CASE WHEN {ColumnNameStatus} = 2 THEN 1 ELSE 0 END) AS CompOffUsedCount
                            //                            FROM compoffapplication
                            //                            WHERE CancelTag = 0
                            //                            GROUP BY EmployeeId
                            //                        ) la ON e.EmployeeId = la.EmployeeId
                            //                        SET e.CompOffBalance = 
                            //                            COALESCE(la.CompOffCount, 0) - COALESCE(la.CompOffUsedCount, 0)
                            //                        WHERE e.CancelTag = 0
                            //                        AND e.EmployeeId IN ({string.Join(",", paramNames)})";
                            //                        //AND e.EmployeeId IN({ string.Join(",", paramNames)})";


                            //        //objBL.Query = " UPDATE Employees e " +
                            //        //                " LEFT JOIN( "+
                            //        //                    " SELECT EmployeeId, COALESCE(Count(CompOffApplicationId), 0) AS CompOffCount,COALESCE(Count(CompOffApplicationId), 0) AS CompOffUsedCount " +
                            //        //                    " FROM compoffapplication  "+
                            //        //                    " WHERE CancelTag = 0 " + ColumnNameStatus + " " +
                            //        //                    " GROUP BY EmployeeId " +
                            //        //                " ) la ON e.EmployeeId = la.EmployeeId "+
                            //        //                //" SET e.BalanceLeave = (e.TotalLeave + e.OpeningLeave) - COALESCE(la.UsedLeave, 0) "+
                            //        //                " SET e.CompOffBalance = COALESCE(la.CompOffCount) - COALESCE(la.CompOffUsedCount, 0) " +

                            //        //                " WHERE e.CancelTag = 0 " +
                            //        //                " AND e.EmployeeId IN (" + idEmployees + ")";

                            //        // query = string.Format(query, idEmployees); // still risky if not controlled!

                            //        objBL.Query = query;

                            //        for (int i = 0; i < selectedEmployeeIds.Count; i++)
                            //        {
                            //            objBL.objCmd.Parameters.AddWithValue(paramNames[i], ids[i]);
                            //        }

                            //        Result = objBL.Function_ExecuteNonQuery();

                            if (Result > 0)
                            {
                                if (selectedCompOffDate.Count > 0)
                                {
                                    for (int i = 0; i < ids.Length; i++)
                                    {
                                        paramNames.Add($"@id{i}");

                                        int EID = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(selectedEmployeeIds[i])));
                                        if (EID > 0)
                                        {

                                        }
                                    }
                                }
                            }

                            //CompOff=" + objPC.CompOff_Count + ",CompOffUsed=" + objPC.CompOffUsed_Count + ",CompOffBalance=" + objPC.CompOffUsedBalance_Count + " where CancelTag=0 and EmployeeId=" + objPC.EmployeeId + " ";

                        }


                    }
                }
                else
                {
                    MessageBox.Show("No rows selected.");
                }
                FillGrid();
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }


            //Get_SelectedCount_CheckBox();

            //if (!Validation())
            //{
            //    if (dataGridView1.Rows.Count > 0)
            //    {
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

            //        for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //        {
            //            Status = string.Empty; LeaveApplicationId_Grid = 0;

            //            if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value))
            //            {
            //                if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[i].Cells[1].Value.ToString())))
            //                {
            //                    Status = cmbStatus.Text;
            //                    objPC.CompOffApplicationId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[i].Cells[1].Value)));
            //                    objPC.EmployeeId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[i].Cells[3].Value)));

            //                    string ColumnUpdate = string.Empty;

            //                    if (!cbCompOffUsed.Checked)
            //                        ColumnUpdate = " CompStatus='" + Status + "'";
            //                    else
            //                        ColumnUpdate = " CompUsedStatus='" + Status + "'";

            //                    objPC.Remarks = txtRemarks.Text;
            //                    // Result = objQL.SP_CompOffApplication_Update_CompStatus();

            //                    objBL.Query = "update compoffapplication set  " + ColumnUpdate + ",Remarks='" + objPC.Remarks + "' where CancelTag=0 and CompOffApplicationId=" + objPC.CompOffApplicationId + " ";
            //                    Result = objBL.Function_ExecuteNonQuery();

            //                    if (Result > 0)
            //                    {
            //                        //Get Count 

            //                        if (cmbStatus.Text == BusinessResources.LS_Completed)
            //                        {
            //                            if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR || BusinessLayer.UserType == BusinessResources.USER_TYPE_HROFFICER)
            //                            {
            //                                objRL.Get_Comp_Off_Count_By_EmployeeId();
            //                                objBL.Query = "update employees set CompOff=" + objPC.CompOff_Count + ",CompOffUsed=" + objPC.CompOffUsed_Count + ",CompOffBalance=" + objPC.CompOffUsedBalance_Count + " where CancelTag=0 and EmployeeId=" + objPC.EmployeeId + " ";
            //                                Result = objBL.Function_ExecuteNonQuery();
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //        ClearAll();
            //    }
            //}
            //else
            //{
            //    objRL.ShowMessage(17, 4);
            //    return;
            //}
        }

        string Status = string.Empty, MainQuery = string.Empty, WhereClause = string.Empty, WhereClauseS = string.Empty, WhereClauseOther = string.Empty, OrderClause = string.Empty;

        private void FillGrid()
        {
            objBL.Query = "";
            MainQuery = string.Empty; WhereClause = string.Empty; WhereClauseS = string.Empty; OrderClause = string.Empty;

            //
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

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
                    WhereClauseS = " and COA.CompStatusId=" + cmbStatusSearch.SelectedValue + " ";
                }
                else
                    WhereClauseS = "";
            }
            else
                WhereClauseS = "";

            if (cbCompOffUsed.Checked)
            {
                objPC.CompOffUsedFlag = 1;
                WhereClause += " and COA.IsUsedCompOff=1 ";
            }
            else
            {
                objPC.CompOffUsedFlag = 0;
                WhereClause += " "; // " and COA.CompOffUsedFlag=0 ";
            }

            //WhereClause += " and COA.FinancialYearId=" + objPC.FinancialYearId + " ";

            WhereClause += " AND (YEAR(COA.UsedCompOffDate) IN (2025,2026) OR COA.FinancialYearId=" + objPC.FinancialYearId + ") ";

            MainQuery = string.Empty; WhereClause = string.Empty; WhereClauseOther = string.Empty; OrderClause = string.Empty;
            dataGridView1.DataSource = null;

            MainQuery = "Select distinct " +
                   "COA.CompOffApplicationId, " +
                   "COA.EmployeeId, " +
                   "LM.LocationName, " +
                   "DM.Department, " +
                   "E.EmployeeName as 'Employee Name'," +
                   "DES.Designation," +
                   "COA.CompOffDate as 'Comp Off Date'," +
                   //"COA.ReasonOfCompOff as 'Reason Of Comp Off'," +
                   "COA.WorkRemarks as 'Work Remarks'," +
                   "COA.CompStatusId as 'ApprovalStatusId'," +
                   " CASE WHEN COA.CompStatusId = 1 THEN 'Pending' WHEN COA.CompStatusId = 2 THEN 'Completed' WHEN COA.CompStatusId = 3 THEN 'Remarks' WHEN COA.CompStatusId = 6 THEN 'HR Approved' WHEN COA.CompStatusId = 8 THEN 'Manager Approved' ELSE 'Pending' END AS 'Status', " +
                   "COA.CompOffDueDate, " +
                   "COA.IsCompOffExpired, " +
                   "COA.IsUsedCompOff, " +
                   "COA.UsedCompOffDate as 'Used Comp Off Date', " +
                   "COA.UsedCompStatusId, " +
                   " CASE WHEN COA.UsedCompStatusId = 1 THEN 'Pending' WHEN COA.UsedCompStatusId = 2 THEN 'Completed' WHEN COA.UsedCompStatusId = 3 THEN 'Remarks' WHEN COA.UsedCompStatusId = 6 THEN 'HR Approved' WHEN COA.UsedCompStatusId = 8 THEN 'Manager Approved' ELSE 'Pending' END AS 'Used Status', " +
                   "COA.FinancialYearId, " +
                   "COA.FileName " +
               " from " +
                   " compoffapplication COA inner join " +
                   //" leavetypes LT on LT.LeaveTypeId=LA.LeaveTypeId inner join " +
                   " Employees E on E.EmployeeId=COA.EmployeeId inner join " +
                   " DesignationMaster DES on DES.DesignationId=E.DesignationId inner join " +
                   " LocationMaster LM on LM.LocationId=E.LocationId inner join " +
                   " DepartmentMaster DM on DM.DepartmentId=E.DepartmentId inner join " +
                   " locationwisedepartmentusers LWDU on LWDU.LocationId=LM.LocationId and LWDU.DepartmentId=DM.DepartmentId" +
               " where " +
                   "COA.CancelTag=0 and " +
                   //"LT.CancelTag=0 and " +
                   "E.CancelTag=0 and " +
                   "DM.CancelTag=0 and " +
                   "DES.CancelTag=0 and " +
                   "LM.CancelTag=0 ";

            if (BusinessLayer.UserType == "ADMINISTRATOR")
            {
                if (SearchFlag && txtSearch.Text != "")
                    WhereClause += " and E.EmployeeName LIKE '%" + txtSearch.Text + "%'";
                else
                    WhereClause += string.Empty;
            }
            else
                WhereClause = " and E.EmployeeId=" + BusinessLayer.EmployeeLoginId_Static + " ";

            WhereClause += " and COA.FinancialYearId=" + objPC.FinancialYearId + " ";

            OrderClause = " order by COA.CompOffApplicationId desc ";

            objBL.Query = MainQuery + WhereClause + WhereClauseS + OrderClause;

            ds = objBL.ReturnDataSet();

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

                //0   COA.CompOffApplicationId,  +
                //1   COA.EmployeeId,  +
                //2   LM.LocationName,  +
                //3   DM.Department,  +
                //4   E.EmployeeName as 'Employee Name', +
                //5   DES.Designation, +
                //6   COA.CompOffDate as 'Comp Off Date', +
                //7   COA.WorkRemarks as 'Work Remarks', +
                //8   COA.CompStatusId as 'ApprovalStatusId', +
                //9   CASE WHEN COA.CompStatusId = 1 THEN 'Pending' WHEN COA.CompStatusId = 2 THEN 'Completed' WHEN COA.CompStatusId = 3 THEN 'Remarks' WHEN COA.CompStatusId = 6 THEN 'HR Approved' WHEN COA.CompStatusId = 8 THEN 'Manager Approved' ELSE 'Unknown' END AS 'Status',  +
                //11  COA.CompOffDueDate,  +
                //12  COA.IsCompOffExpired,  +
                //13  COA.IsUsedCompOff,  +
                //14  COA.UsedCompOffDate as 'Used Comp Off Date',  +
                //15  COA.UsedCompStatusId,  +
                //16   CASE WHEN COA.UsedCompStatusId = 1 THEN 'Pending' WHEN COA.UsedCompStatusId = 2 THEN 'Completed' WHEN COA.UsedCompStatusId = 3 THEN 'Remarks' WHEN COA.UsedCompStatusId = 6 THEN 'HR Approved' WHEN COA.UsedCompStatusId = 8 THEN 'Manager Approved' ELSE 'Unknown' END AS 'Used Status',  +
                //17  COA.FinancialYearId +
                //18 "COA.FileName " +

                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;

                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[15].Visible = false;
                dataGridView1.Columns[17].Visible = false;

                dataGridView1.Columns[3].Width = 80;
                dataGridView1.Columns[4].Width = 120;
                dataGridView1.Columns[5].Width = 200;
                dataGridView1.Columns[6].Width = 100;
                dataGridView1.Columns[7].Width = 100;
                dataGridView1.Columns[8].Width = 150;
                dataGridView1.Columns[9].Width = 150;
                dataGridView1.Columns[10].Width = 150;
                dataGridView1.Columns[12].Width = 80;

               
                DataGridViewLinkColumn chk = new DataGridViewLinkColumn();
                chk.HeaderText = "View";
                chk.Name = "clmView";
                chk.Width = 50;

                // Add to DataGridView
                dataGridView1.Columns.Insert(dataGridView1.Columns.Count, chk); // adds as first column

                if (dataGridView1.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            row.Cells["clmView"].Value = "View";
                        }
                    }
                }

                objRL.Set_Approval_Colour_DataGridView(dataGridView1, lblPending, lblHRApproved, lblManagerApproved, lblRemark, lblCompleted, "ApprovalStatusId");

                dataGridView1.ClearSelection();
            }
        }

        private void FillGridOld()
        {
            objBL.Query = "";
            MainQuery = string.Empty; WhereClause = string.Empty; WhereClauseS = string.Empty; OrderClause = string.Empty;

            if (SearchFlag && txtSearch.Text != "")
                WhereClause = " and E.EmployeeName LIKE '%" + txtSearch.Text + "%'";
            else
                WhereClause = string.Empty;

            if (!cbStatus.Checked)
            {
                if (cmbStatusSearch.SelectedIndex > -1)
                {
                    //cmbStatusSearch.Text = BusinessResources.LS_Pending;
                    WhereClauseS = " and COA.CompStatus='" + cmbStatusSearch.Text + "' ";
                }
                else
                    WhereClauseS = "";
            }
            else
                WhereClauseS = "";

            if (cbCompOffUsed.Checked)
            {
                objPC.CompOffUsedFlag = 1;
                WhereClause += " and COA.CompOffUsedFlag=1 ";
            }
            else
            {
                objPC.CompOffUsedFlag = 0;
                WhereClause += " "; // " and COA.CompOffUsedFlag=0 ";
            }

            //WhereClause += " and COA.FinancialYearId=" + objPC.FinancialYearId + " ";

            WhereClause += " AND (YEAR(COA.UsedCompOffDate) IN (2025,2026) OR COA.FinancialYearId=" + objPC.FinancialYearId + ") ";

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
            //MainQuery = BusinessResources.CompOffQuery + objRL.WhereClasuse_CompOff_Comman();

            MainQuery = "Select distinct " +
                       "COA.CompOffApplicationId," +
                       "COA.EntryDate," +
                       "COA.EmployeeId," +
                       "LM.LocationName," +
                       "DM.Department," +
                       "E.EmployeeName," +
                       "DES.Designation," +
                       "COA.LeaveTypeId," +
                       //"LT.LeaveTypeFName, " +
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
                           //" leavetypes LT on LT.LeaveTypeId=COA.LeaveTypeId inner join " +
                           " Employees E on E.EmployeeId=COA.EmployeeId inner join " +
                           " DesignationMaster DES on DES.DesignationId=E.DesignationId inner join " +
                           " LocationMaster LM on LM.LocationId=E.LocationId inner join " +
                           " DepartmentMaster DM on DM.DepartmentId=E.DepartmentId inner join " +
                           " locationwisedepartmentusers LWDU on LWDU.LocationId=LM.LocationId and LWDU.DepartmentId=DM.DepartmentId" +
                       " where " +
                           "COA.CancelTag = 0 and " +
                           //"LT.CancelTag = 0 and " +
                           "E.CancelTag = 0 and " +
                           "DM.CancelTag = 0 and " +
                           "DES.CancelTag = 0 and " +
                           "LM.CancelTag = 0 and " +
                           "LWDU.CancelTag=0 ";

            OrderClause = " order by COA.CompOffApplicationId desc ";

            //objBL.Query = BusinessResources.CompOffQuery + objRL.WhereClasuse_CompOff_Comman() + WhereClause + WhereClauseS + OrderClause;
            objBL.Query = MainQuery + objRL.WhereClasuse_CompOff_Comman() + WhereClause + WhereClauseS + OrderClause;

            //MainQuery = "Select " +
            //        "COA.CompOffApplicationId," +
            //        "COA.EntryDate as ' Entry Date'," +
            //        "COA.EmployeeId, " +
            //        "LM.LocationName," +
            //        "DM.Department," +
            //        "E.EmployeeName as 'Employee Name'," +
            //        "DES.Designation," +
            //        "COA.LeaveTypeId," +
            //        "L.LeaveTypeFName  as 'Comp off Type'," +
            //        "COA.CompOffDate as 'Comp Off Date'," +
            //        "COA.CompOffDay as 'Comp Off Day', " +
            //        "COA.HolidayType as 'Holiday Type', " +
            //        "COA.Festival, " +
            //        "COA.CompOffReason as 'Comp Off Reason',  " +
            //        "COA.WorkRemarks as 'Work Remarks', " +
            //        "COA.CompStatus as 'Status'," +
            //        "COA.CompOffDueDate as 'Comp Off Due Date'," +
            //        "COA.CompOffUsedFlag," +
            //        "COA.CompUsedStatus " +
            //        " from " +
            //        "compoffapplication COA inner join " +
            //        "leavetypes L on L.LeaveTypeId=COA.LeaveTypeId inner join " +
            //        "Employees E on E.EmployeeId=COA.EmployeeId inner join " +
            //        "DepartmentMaster DM on DM.DepartmentId=E.DepartmentId inner join " +
            //        "DesignationMaster DES on DES.DesignationId=E.DesignationId inner join " +
            //        "LocationMaster LM on LM.LocationId=E.LocationId " +
            //        " where " +
            //        "L.CancelTag=0 and " +
            //        "COA.CancelTag=0 and " +
            //        "E.CancelTag=0 and " +
            //        "DM.CancelTag=0 and " +
            //        "DES.CancelTag=0 and " +
            //        "LM.CancelTag=0 ";
            //E.LocationId IN (select LocationId from locationwisedepartmentusers where InchargeId=UserId_V) and
            //E.DepartmentId IN (select DepartmentId from locationwisedepartmentusers where InchargeId=UserId_V);

            //objBL.Query = MainQuery + WhereClause;



            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            DataSet ds = new DataSet();
            ds = objBL.ReturnDataSet();

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
                //18 COA.CompUsedStatus as 'Comp Off Used Status'

                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[18].Visible = false;

                dataGridView1.Columns[2].Width = 120;
                dataGridView1.Columns[4].Width = 130;
                dataGridView1.Columns[5].Width = 120;
                dataGridView1.Columns[6].Width = 120;
                dataGridView1.Columns[7].Width = 120;
                dataGridView1.Columns[9].Width = 130;
                dataGridView1.Columns[10].Width = 120;
                dataGridView1.Columns[11].Width = 130;
                dataGridView1.Columns[12].Width = 130;
                dataGridView1.Columns[13].Width = 130;
                dataGridView1.Columns[14].Width = 130;
                dataGridView1.Columns[15].Width = 100;
                dataGridView1.Columns[16].Width = 100;
                dataGridView1.Columns[17].Width = 100;
                //dataGridView1.Columns[18].Width = 100;

                Pending_Count = 0; ManagerApproved_Count = 0; HRApproved_Count = 0; Remarks_Count = 0; Reject_Count = 0; Completed_Count = 0;

                string CompStatus = string.Empty;
                foreach (DataGridViewRow Myrow in dataGridView1.Rows)
                {
                    CompStatus = string.Empty;
                    //Here 2 cell is target value and 1 cell is Volume

                    if (!cbCompOffUsed.Checked)
                        CompStatus = objRL.CheckNullString(Convert.ToString(Myrow.Cells[15].Value));
                    else
                        CompStatus = objRL.CheckNullString(Convert.ToString(Myrow.Cells[19].Value));

                    if (CompStatus == BusinessResources.LS_Pending)
                    {
                        Pending_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Pending_Color);
                    }
                    else if (CompStatus == BusinessResources.LS_ManagerApproved)
                    {
                        ManagerApproved_Count++; HRApproved_Count++;
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

        protected void FillGrid1()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            DataSet ds = new DataSet();
            ds = objQL.SP_CompOffApplication_FillGrid();

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                checkColumn.Name = "clmSelect";
                checkColumn.HeaderText = "Select";
                checkColumn.Width = 50;
                checkColumn.ReadOnly = false;
                checkColumn.FillWeight = 10; //if the datagridview is resized (on form resize) the checkbox won't take up too much; value is relative to the other columns' fill values
                dataGridView1.Columns.Add(checkColumn);
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

                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[18].Visible = false;

                dataGridView1.Columns[2].Width = 120;
                dataGridView1.Columns[4].Width = 130;
                dataGridView1.Columns[5].Width = 120;
                dataGridView1.Columns[6].Width = 120;
                dataGridView1.Columns[7].Width = 120;
                dataGridView1.Columns[9].Width = 130;
                dataGridView1.Columns[10].Width = 120;
                dataGridView1.Columns[11].Width = 130;
                dataGridView1.Columns[12].Width = 130;
                dataGridView1.Columns[13].Width = 130;
                dataGridView1.Columns[14].Width = 130;
                dataGridView1.Columns[15].Width = 100;
                dataGridView1.Columns[16].Width = 100;
                dataGridView1.Columns[17].Width = 100;

                //dataGridView1.Columns[18].Width = 100;

                Pending_Count = 0; ManagerApproved_Count = 0; HRApproved_Count = 0; Remarks_Count = 0; Reject_Count = 0; Completed_Count = 0;

                string CompStatus = string.Empty;
                foreach (DataGridViewRow Myrow in dataGridView1.Rows)
                {
                    CompStatus = string.Empty;
                    //Here 2 cell is target value and 1 cell is Volume
                    if (!string.IsNullOrEmpty(Convert.ToString(Myrow.Cells[16].Value)))
                        CompStatus = Convert.ToString(Myrow.Cells[16].Value);

                    //Remark-
                    //Cancel
                    //Remark
                    //Approved
                    //HR Approved

                    if (CompStatus == BusinessResources.LS_Pending)
                    {
                        Pending_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Pending_Color);
                    }
                    else if (CompStatus == BusinessResources.LS_ManagerApproved)
                    {
                        ManagerApproved_Count++; HRApproved_Count++;
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

        private void ClearAll()
        {
            SearchFlag = false;
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
            lblRemark.Text = "";
            lblReject.Text = "";
            lblCompleted.Text = "";
            txtSearch.Text = "";
            FillGrid();

        }

        int CompOffUsed = 0;
        private void cbCompOffUsed_CheckedChanged(object sender, EventArgs e)
        {
            FillGrid();
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
