using BusinessLayerUtility;
using Microsoft.Office.Interop.Excel;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPApplication.Transaction
{
    public partial class OTApprovalNew : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();

        PropertyClass objPC = new PropertyClass();
        AttendanceLogics objAL = new AttendanceLogics();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0, LocationId = 0;

        int SrNo = 1;
        string MainQuery = string.Empty, WhereClause = string.Empty, WhereClause_Other = string.Empty;
        DateTime dtInTime, dtOutTime;
        TimeSpan TOT;
        int Pending_Count = 0, ManagerApprovedCount = 0, Remarks=0;

        public OTApprovalNew()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, "Attendance and OT Approval");
            btnDelete.Text = BusinessResources.BTN_VIEW;

            objRL.FillLocation(cmbLocation, cmbDepartment);
            objRL.Fill_Approval_Status(cmbAttendanceStatus);
            Fill_Label_Color();
            Fill_Data();
            ClearAll();
        }

        private void Fill_Data()
        {
            //objRL.Fill_Contractor_IN_Attendance(cmbRoll);
            objRL.FillLocation(cmbLocation, cmbDepartment);
            //cbAttendanceDate.Checked = true;
        }
        private void cbSelectAllDepartment_CheckedChanged(object sender, EventArgs e)
        {
            //if (cbSelectAllDepartment.Checked)
            //{
            //    cmbDepartment.SelectedIndex = -1;
            //    cmbDepartment.Enabled = false;
            //}
            //else
            //{
            //    cmbDepartment.SelectedIndex = -1;
            //    cmbDepartment.Enabled = true;
            //}
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!Validation())
            {
                ChangeFlag = false;
                Fill_Grid_AttendanceRecord();
            }
        }
        private void Fill_Label_Color()
        {
            lblPending.BackColor = Color.FromName(BusinessResources.LS_Pending_Color);
            lblHRApproved.BackColor = Color.FromName(BusinessResources.LS_HRApproved_Color);
            //lblInchargeApproved.BackColor = Color.FromName(BusinessResources.LS_InchargeApproved_Color);
            lblManagerApproved.BackColor = Color.FromName(BusinessResources.LS_Manager_Color);
            lblReject.BackColor = Color.FromName(BusinessResources.LS_Reject_Color);
            lblRemark.BackColor = Color.FromName(BusinessResources.LS_Remarks_Color);
            //lblCompleted.BackColor = Color.FromName(BusinessResources.LS_Completed_Color);
            //lblError.BackColor = Color.FromName(BusinessResources.LS_Error_Color);
            //lblError.BackColor = Color.FromName(BusinessResources.LS_Completed_Color);
        }

        private bool Validation()
        {
            bool RetrunFlag = false;
            objEP.Clear();

            if (!cbSelectAllLocation.Checked)
            {
                if (cmbLocation.SelectedIndex == -1)
                {
                    cmbLocation.Focus();
                    objEP.SetError(cmbLocation, "Select Location");
                    RetrunFlag = true;
                }
                else
                    RetrunFlag = false;
            }
            else
                RetrunFlag = false;

            if (!RetrunFlag)
            {
                if (!cbSelectAllDepartment.Checked)
                {
                    if (cmbDepartment.SelectedIndex == -1)
                    {
                        cmbDepartment.Focus();
                        objEP.SetError(cmbDepartment, "Select Department");
                        RetrunFlag = true;
                    }
                    else
                        RetrunFlag = false;
                }
                else
                    RetrunFlag = false;
            }

            return RetrunFlag;
        }
        private bool ValidationMain()
        {
            bool RetrunFlag = false;
            objEP.Clear();

            if (!cbSelectAllLocation.Checked)
            {
                if (cmbLocation.SelectedIndex == -1)
                {
                    cmbLocation.Focus();
                    objEP.SetError(cmbLocation, "Select Location");
                    RetrunFlag = true;
                }
                else
                    RetrunFlag = false;
            }
            else
                RetrunFlag = false;

            if (!RetrunFlag)
            {
                if (!cbSelectAllDepartment.Checked)
                {
                    if (cmbDepartment.SelectedIndex == -1)
                    {
                        cmbDepartment.Focus();
                        objEP.SetError(cmbDepartment, "Select Department");
                        RetrunFlag = true;
                    }
                    else
                        RetrunFlag = false;
                }
                else
                    RetrunFlag = false;
            }

            if (!RetrunFlag)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    bool isChecked = (bool)dataGridView1.Rows[i].Cells[0].Value;

                    // int ID= Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clmAttendanceRecordId"].Value);
                    if (isChecked)
                    {
                        RetrunFlag = false;
                        break;
                    }
                    else
                        RetrunFlag = true;
                }
            }
            if (!RetrunFlag)
            {
                if (cmbAttendanceStatus.SelectedIndex == -1)
                {
                    cmbAttendanceStatus.Focus();
                    objEP.SetError(cmbAttendanceStatus, "Select Status");
                    RetrunFlag = true;
                }
                else if (cmbAttendanceStatus.Text == "Remarks")
                {
                    if (txtRemarks.Text == "")
                    {
                        txtRemarks.Focus();
                        objEP.SetError(txtRemarks, "Enter Remarks");
                        RetrunFlag = true;
                    }
                    else
                        RetrunFlag = false;
                }
                else
                    RetrunFlag = false;
            }
            if (!RetrunFlag)
            {
                if (SName == "Completed" || SName == "Pending")
                {
                    lblStatusValue.Focus();
                    objEP.SetError(lblStatusValue, "Status is not valid");

                    objRL.ShowMessage(51, 4);
                    RetrunFlag = true;
                }
                else
                    RetrunFlag = false;
            }


            return RetrunFlag;
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void cmbLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbLocation.SelectedIndex > -1)
                objRL.FillDepartment(cmbLocation, cmbDepartment);
        }

        private void OTApprovalNew_Load(object sender, EventArgs e)
        {

        }

        private void cbTransferEmployee_CheckedChanged(object sender, EventArgs e)
        {
            //if (cbTransferEmployee.Checked)
                Fill_Grid_AttendanceRecord();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                RowCount_Grid = dataGridView1.Rows.Count;
                CurrentRowIndex = dataGridView1.CurrentRow.Index;

                if (BusinessLayer.Department == "TIME OFFICE" || BusinessLayer.Department == "HR") //  BusinessLayer.UserType == BusinessResources.USER_TYPE_SENIOROFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER)
                {
                    if (RowCount_Grid >= 0 && CurrentRowIndex >= 0)
                    {
                        objPC.LeaveTypeFlag = false;
                        if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["clmAttendanceRecordId"].Value)))
                        {
                            
                            objPC.AttendanceRecordMasterId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clmAttendanceRecordMasterId"].Value);
                            objPC.AttendanceRecordId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clmAttendanceRecordId"].Value);
                            objPC.EmployeeId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clmEmployeeId"].Value);
                            objPC.EmployeeCode = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clmEmployeeCode"].Value);

                            if (objPC.AttendanceRecordId != 0)
                            {
                                EditAttendanceRecord objForm = new EditAttendanceRecord();
                                objForm.ShowDialog(this);
                                Fill_Grid_AttendanceRecord();
                            }
                        }
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
            // btnDelete.Visible = true;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            pSave.Visible = false;
            // Check if the changed cell is in the checkbox column
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                bool isChecked = (bool)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                // int ID= Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clmAttendanceRecordId"].Value);
                if (isChecked)
                {
                    pSave.Visible = true;
                    //if break;
                }
                    


                //MessageBox.Show($"Checkbox at row {e.RowIndex} is now {(isChecked ? "checked" : "unchecked")}");
            }
        }

        private void cbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count >0)
            {
                for(int i = 0; i < dataGridView1.Rows.Count;i++)
                {
                    if (cbSelectAll.Checked)
                        dataGridView1.Rows[i].Cells["clmSelectAll"].Value = true;
                    else
                        dataGridView1.Rows[i].Cells["clmSelectAll"].Value = false;
                }
            }
        }

        //private void SetStatusColor()
        //{
        //    objRL.SetStatusColor(cmbAttendanceStatus, lblData);
        //}

        int TransferCount = 0;

        private void Fill_Grid_AttendanceRecord()
        {
            SName = string.Empty;
            lblStatusValue.Text = "";
            dataGridView1.Rows.Clear();
            ChangeFlag = false;
            TransferCount = 0;
            SrNo = 1;
            objEP.Clear();
            TOT = TimeSpan.Zero;
            lblTotalCount.Text = "";
            lblPending.Text = "";
            lblManagerApproved.Text = "";
            lblHRApproved.Text = "";
            lblRemark.Text = "";
            lblReject.Text = "";

            OTHoursTotal = 0;
            ManagerApprovedCount = 0;
            Pending_Count = 0;

            System.Data.DataTable dt = new System.Data.DataTable();
            System.Data.DataTable dtCLD = new System.Data.DataTable();

            WhereClause = string.Empty;
            MainQuery = string.Empty;
            WhereClause_Other = string.Empty;

            WhereClause = " and ARM.AttendanceDate='" + dtpOTDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' "; // and E.OverTimeApplicable=1 and TIME_TO_SEC(AR.OverTime) / 3600 > 0 "; //AR.OverTime !='00:00' or AR.OverTime !='0:0'

            //if (!cbSelectAllLocation.Checked)
            WhereClause_Other += " and E.LocationId=" + cmbLocation.SelectedValue + "";
            //else
                //WhereClause_Other += " and " + objQL.Get_Location_Id("Location") + " ";

            //if (!cbSelectAllDepartment.Checked)
                WhereClause_Other += " and E.DepartmentId=" + cmbDepartment.SelectedValue + "";
            //else
            //    WhereClause_Other += " and " + objQL.Get_Location_Id("Department");

            if (cbTransferEmployee.Checked)
                WhereClause_Other += " and AR.ChangeDepartmentFlag>0 ";
            //else
            //    WhereClause_Other += " and AR.ChangeDepartmentFlag=0 ";

            MainQuery = "select distinct " +
                         "AR.AttendanceRecordId," +
                         "AR.AttendanceRecordMasterId," +
                         "AR.AttendanceHistoryId," +
                         "AR.EsslAttendanceLogsId," +
                         "AR.EmployeeId," +
                         "ARM.AttendanceDate," +
                         "E.EmployeeName," +
                         "E.EmployeeCode," +
                         "AR.ShiftId," +
                         "S.ShiftSName," +
                         "AR.ShiftGroupId," +
                         "AR.InTime," +
                         "AR.OutTime," +
                         "AR.Duration," +
                         "AR.OverTime," +
                         "AR.TotalDuration," +
                         "AR.Status," +
                         "AR.LateBy," +
                         "AR.EarlyBy," +
                         "AR.MissedInPunch," +
                         "AR.MissedOutPunch," +
                         "AR.ChangeDepartmentFlag," +
                         "AR.ChangeDepartmentId," +
                         "AR.ChangeLocationtId," +
                         "AR.LeaveTypeId," +
                         "AR.LeaveDuration," +
                         "AR.WeeklyOff," +
                         "AR.Holiday," +
                         "AR.LeaveRemarks," +
                         "AR.PunchRecords," +
                         "AR.LossOfHours," +
                         "AR.Present," +
                         "AR.Absent," +
                         "AR.Remarks," +
                         "S.ShiftDuration," +
                         "S.ShiftDurationHours," +
                         "S.BeginTime," +
                         "S.EndTime," +
                         "AR.EditFlag," +
                         "E.CategoryId," +
                         "E.ContractorId," +
                         "L.LocationName," +
                         "D.Department," +
                         "ARM.OTApprovalFlag, " +
                         "AR.OTApprovalFlag as 'OTFlagAR'," +
                         "AR.OTApprovalStatus, " +
                         "AR.Notes," +
                         "AR.OTRemarks," +
                         "AR.OTReply, " +
                         "ARM.ApprovalStatusId, " +
                         "ASM.AttendanceStatus " +
                         " from AttendanceRecord AR inner join " +
                         " attendancerecordmaster ARM on ARM.AttendanceRecordMasterId=AR.AttendanceRecordMasterId inner join " +
                         " Employees E on E.EmployeeId=AR.EmployeeId inner join " +
                         " shifts S on S.ShiftId=AR.ShiftId inner join " +
                         " locationmaster L on L.LocationId=E.LocationId inner join " +
                         " departmentmaster D on D.DepartmentId=E.DepartmentId inner join " +
                         " attendancestatusmaster ASM on ARM.ApprovalStatusId=ASM.AttendanceStatusId " +
                         " where " +
                         " AR.CancelTag=0 and" +
                         " ARM.CancelTag=0 and" +
                         " E.CancelTag=0 and " +
                         " S.CancelTag=0 " ;

            objBL.Query = MainQuery + WhereClause + WhereClause_Other + "  order by ARM.AttendanceDate asc";
            dt = objBL.ReturnDataTable();

            //if(!cbTransferEmployee.Checked)
            //{
            if (dt.Rows.Count > 0)
            {
                ChangeFlag = false;
                RowDGV = 0;
                SName = dt.Rows[0]["AttendanceStatus"].ToString();
                lblStatusValue.Text = SName.ToString();

                if(SName != "Pending") // || SName != "Completed" || SName != "HR Approved")
                {
                    Fill_DataGridView_Values(RowDGV, dt);
                }
                else
                {
                    objRL.ShowMessage(52, 4);
                    return;
                }
            }
            //}


            ////Transfer window shown
            //WhereClause_Other = string.Empty;

            //WhereClause_Other += " and AR.ChangeDepartmentFlag>0 ";

            //if (!cbSelectAllLocation.Checked)
            //{
            //    if (cmbDepartment.SelectedIndex > -1)
            //        WhereClause_Other += " and AR.ChangeLocationtId IN(" + cmbLocation.SelectedValue + ")";
            //}
            //else
            //    WhereClause_Other += " and " + objQL.Get_Change_LocationId_And_DepartmentId_Type_Object("Location", "AR.") + " ";

            //if (!cbSelectAllDepartment.Checked)
            //{
            //    if (cmbDepartment.SelectedIndex > -1)
            //        WhereClause_Other += " and AR.ChangeDepartmentId IN(" + cmbDepartment.SelectedValue + ") ";
            //}
            //else
            //    WhereClause_Other += " and " + objQL.Get_Change_LocationId_And_DepartmentId_Type_Object("Department", "AR.") + " ";

            //objBL.Query = MainQuery + WhereClause + WhereClause_Other + "  order by ARM.AttendanceDate asc";

            WhereClause_Other = string.Empty;
            MainQuery = string.Empty;
            ChangeFlag = false;
            

            MainQuery = "select " +
                         "AR.AttendanceRecordId," +
                         "AR.AttendanceRecordMasterId," +
                         "AR.AttendanceHistoryId," +
                         "AR.EsslAttendanceLogsId," +
                         "AR.EmployeeId," +
                         "ARM.AttendanceDate," +
                         "E.EmployeeName," +
                         "E.EmployeeCode," +
                         "AR.ShiftId," +
                         "S.ShiftSName," +
                         "AR.ShiftGroupId," +
                         "AR.InTime," +
                         "AR.OutTime," +
                         "AR.Duration," +
                         "AR.OverTime," +
                         "AR.TotalDuration," +
                         "AR.Status," +
                         "AR.LateBy," +
                         "AR.EarlyBy," +
                         "AR.MissedInPunch," +
                         "AR.MissedOutPunch," +
                         "AR.ChangeDepartmentFlag," +
                         "AR.ChangeDepartmentId," +
                         "AR.ChangeLocationtId," +
                         "AR.LeaveTypeId," +
                         "AR.LeaveDuration," +
                         "AR.WeeklyOff," +
                         "AR.Holiday," +
                         "AR.LeaveRemarks," +
                         "AR.PunchRecords," +
                         "AR.LossOfHours," +
                         "AR.Present," +
                         "AR.Absent," +
                         "AR.Remarks," +
                         "S.ShiftDuration," +
                         "S.ShiftDurationHours," +
                         "S.BeginTime," +
                         "S.EndTime," +
                         "AR.EditFlag," +
                         "E.CategoryId," +
                         "E.ContractorId," +
                         "L1.LocationName as 'EmpLocation'," +
                         "D1.Department as 'EmpDepartment'," +
                         "L.LocationName," +
                         "D.Department," +
                         "ARM.OTApprovalFlag, " +
                         "AR.OTApprovalFlag as 'OTFlagAR'," +
                         "AR.OTApprovalStatus, " +
                         "AR.Notes," +
                         "AR.OTRemarks," +
                         "AR.OTReply " +
                         " from AttendanceRecord AR inner join " +
                         " attendancerecordmaster ARM on ARM.AttendanceRecordMasterId=AR.AttendanceRecordMasterId inner join " +
                         " Employees E on E.EmployeeId=AR.EmployeeId inner join " +
                         " shifts S on S.ShiftId=AR.ShiftId inner join " +
                         " locationmaster L on L.LocationId=AR.ChangeLocationtId inner join " +
                         " departmentmaster D on D.DepartmentId=AR.ChangeDepartmentId inner join " +
                         " locationmaster L1 on L1.LocationId=E.LocationId inner join " +
                         " departmentmaster D1 on D1.DepartmentId=E.DepartmentId " +
                         " where " +
                         " AR.CancelTag=0 and" +
                         " ARM.CancelTag=0 and" +
                         " E.CancelTag=0 and " +
                         " S.CancelTag=0 ";

            //if (!cbSelectAllLocation.Checked)
            //{
            //    if (cmbDepartment.SelectedIndex > -1)
            //        WhereClause_Other += " and AR.ChangeLocationtId IN(" + cmbLocation.SelectedValue + ")";
            //}
            //else
            //    WhereClause_Other += " and " + objQL.Get_Change_LocationId_And_DepartmentId_Type_Object("Location", "AR.") + " ";

            //if (!cbSelectAllDepartment.Checked)
            //{
            //    if (cmbDepartment.SelectedIndex > -1)
            //        WhereClause_Other += " and AR.ChangeDepartmentId IN(" + cmbDepartment.SelectedValue + ") ";
            //}
            //else
            //    WhereClause_Other += " and " + objQL.Get_Change_LocationId_And_DepartmentId_Type_Object("Department", "AR.") + " ";

            //if (cmbDepartment.SelectedIndex > -1)
            //    WhereClause_Other += " and AR.ChangeLocationtId NOT IN(" + cmbLocation.SelectedValue + ")";

            if (cmbLocation.SelectedIndex >-1 && cmbDepartment.SelectedIndex > -1)
            {
                WhereClause_Other += " and AR.ChangeLocationtId IN(" + cmbLocation.SelectedValue + ") and AR.ChangeDepartmentId IN(" + cmbDepartment.SelectedValue + ") ";
            }
                


            WhereClause_Other += " and AR.ChangeDepartmentFlag>0 ";

            //if (cbTransferEmployee.Checked)
            //WhereClause_Other += " and AR.ChangeDepartmentFlag>0";

            objBL.Query = MainQuery + WhereClause + WhereClause_Other + "  order by ARM.AttendanceDate asc";
            dtCLD = objBL.ReturnDataTable();

            if (dtCLD.Rows.Count > 0)
            {
                ChangeFlag = true;
                RowDGV = dataGridView1.Rows.Count;
                Fill_DataGridView_Values(RowDGV, dtCLD);
            }

            cbTransferEmployee.Text = "Transfer Employee: " + TransferCount.ToString();
            objPC.AttendanceDate = dtpOTDate.Value;
            objPC.AttendanceDay = objPC.AttendanceDate.DayOfWeek.ToString();

            objRL.Get_Incharge_Senior_OfficerId();

            string LName = string.Empty, DName = string.Empty;

            if (cbSelectAllLocation.Checked)
                LName = "ALL";
            else
                LName = cmbLocation.Text;

            if (cbSelectAllDepartment.Checked)
                DName = "ALL";
            else
                DName = cmbDepartment.Text;
             
            lblOverTime.Text = "Total Over Time (in Hours) - " + OTHoursTotal.ToString();
            
            string AStatus = string.Empty, OTStatus = string.Empty;

            foreach (DataGridViewRow Myrow in dataGridView1.Rows)
            {
                OTStatus = string.Empty;
                OTStatus = objRL.CheckNullString(Convert.ToString(Myrow.Cells["clmOTStatus"].Value));
                if (OTStatus == "Pending")
                {
                    Pending_Count++;
                    Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Pending_Color);
                }
                else if (OTStatus == "Remarks")
                {
                    Remarks++;
                    Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Remarks_Color);
                }
                else if (OTStatus == "Manager Approved")
                {
                    ManagerApprovedCount++;
                    Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Manager_Color);
                }
                else
                {

                }
            }
            lblPending.Text = "Pending: " + Pending_Count.ToString();
            lblManagerApproved.Text = "Manager Approved: " + ManagerApprovedCount.ToString();
            lblRemark.Text = "Remarks: " + Remarks.ToString();
            lblTotalCount.Text ="Total Count:"+ dataGridView1.Rows.Count.ToString();
            dataGridView1.ClearSelection();
        }

        string SName = string.Empty;
        private void cmbAttendanceStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(cmbAttendanceStatus.SelectedIndex > -1)
            {
                if(cmbAttendanceStatus.Text =="Remarks")
                {
                    lblRemarks.Visible = true;
                    txtRemarks.Visible = true;
                }
                else
                {
                    lblRemarks.Visible = false;
                    txtRemarks.Visible = false;
                }
            }
        }

        private void dtpOTDate_ValueChanged(object sender, EventArgs e)
        {

        }

        int RowDGV = 0; bool ChangeFlag = false;
        TimeSpan OTSpan = TimeSpan.Zero;
        private void Fill_DataGridView_Values(int RCount,  System.Data.DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                TransferCount = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    OTSpan = TimeSpan.Zero;

                    dataGridView1.Rows[RCount].Cells["clmSelectAll"].Value = false;

                    dataGridView1.Rows[RCount].Cells["clmSrNo"].Value = SrNo.ToString();
                    dataGridView1.Rows[RCount].Cells["clmOTApprovalFlag"].Value = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["OTApprovalFlag"])); //ds.Rows[i]["AttendanceRecordId"].ToString();

                    dataGridView1.Rows[RCount].Cells["clmAttendanceRecordId"].Value = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["AttendanceRecordId"])); //ds.Rows[i]["AttendanceRecordId"].ToString();

                    DateTime dtDate = Convert.ToDateTime(objRL.CheckNullString(Convert.ToString(dt.Rows[i]["AttendanceDate"])));
                    //dataGridView1.Rows[i].Cells["clmAttendanceDate"].Value = dt.ToString(BusinessResources.DATEFORMATDDMMMYYYY); // objRL.CheckNullString(Convert.ToString(ds.Rows[i]["AttendanceRecordId"])); //ds.Rows[i]["AttendanceRecordId"].ToString();

                    dataGridView1.Rows[RCount].Cells["clmAttendanceRecordMasterId"].Value = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["AttendanceRecordMasterId"])); //ds.Rows[i]["AttendanceRecordMasterId"].ToString();
                    dataGridView1.Rows[RCount].Cells["clmEsslAttendanceLogsId"].Value = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["EsslAttendanceLogsId"])); //ds.Rows[i]["EsslAttendanceLogsId"].ToString();
                    dataGridView1.Rows[RCount].Cells["clmEmployeeId"].Value = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["EmployeeId"])); //ds.Rows[i]["EmployeeId"].ToString();
                    dataGridView1.Rows[RCount].Cells["clmEmployeeName"].Value = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["EmployeeName"])); //ds.Rows[i]["EmployeeName"].ToString();
                    dataGridView1.Rows[RCount].Cells["clmEmployeeCode"].Value = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["EmployeeCode"])); //ds.Rows[i]["EmployeeCode"].ToString();

                    dataGridView1.Rows[RCount].Cells["clmShiftId"].Value = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["ShiftId"])); //ds.Rows[i]["ShiftId"].ToString();
                    dataGridView1.Rows[RCount].Cells["clmShift"].Value = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["ShiftSName"])); //ds.Rows[i]["ShiftSName"].ToString();
                    dataGridView1.Rows[RCount].Cells["clmShiftGroupId"].Value = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["ShiftGroupId"]));

                    dataGridView1.Rows[RCount].Cells["clmLocation"].Value = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["LocationName"]));
                    dataGridView1.Rows[RCount].Cells["clmDepartment"].Value = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["Department"]));

                    if (ChangeFlag)
                    {
                        dataGridView1.Rows[RCount].Cells["clmLocation"].Value = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["EmpLocation"]));
                        dataGridView1.Rows[RCount].Cells["clmDepartment"].Value = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["EmpDepartment"]));
                    }

                    //if (!ChangeFlag)
                    //{
                    //    dataGridView1.Rows[RCount].Cells["clmLocation"].Value = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["LocationName"]));
                    //    dataGridView1.Rows[RCount].Cells["clmDepartment"].Value = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["Department"]));
                    //}
                    //else
                    //{
                    //    //dataGridView1.Rows[RCount].Cells["clmLocation"].Value = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["EmpLocation"]));
                    //    //dataGridView1.Rows[RCount].Cells["clmDepartment"].Value = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["EmpDepartment"]));
                    //}


                    dtInTime = Convert.ToDateTime(dt.Rows[i]["InTime"].ToString());
                    dtOutTime = Convert.ToDateTime(dt.Rows[i]["OutTime"].ToString());

                    objPC.CategoryId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[i]["CategoryId"])));
                    objPC.ContractorId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[i]["ContractorId"])));

                    //objRL.Get_CategoriesDetails_By_Id();

                    dataGridView1.Rows[RCount].Cells["clmInTime"].Value = dtInTime.ToString("HH:mm");
                    dataGridView1.Rows[RCount].Cells["clmOutTime"].Value = dtOutTime.ToString("HH:mm");

                    //objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftId"])));
                    dataGridView1.Rows[RCount].Cells["clmShiftDuration"].Value = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["ShiftDurationHours"])); // objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftDuration"])); //ds.Rows[i]["ShiftId"].ToString();
                    dataGridView1.Rows[RCount].Cells["clmDuration"].Value = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["Duration"])); //Convert.ToString(ds.Rows[i]["Duration"].ToString());
                    dataGridView1.Rows[RCount].Cells["clmOverTime"].Value = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["OverTime"]));

                    objPC.ChangeDepartmentFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[i]["ChangeDepartmentFlag"])));
                    objPC.ChangeLocationtId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[i]["ChangeLocationtId"])));
                    objPC.ChangeDepartmentId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[i]["ChangeDepartmentId"])));


                    OTSpan = TimeSpan.Parse(objRL.CheckNullString(Convert.ToString(dt.Rows[i]["OverTime"])));

                    if (OTSpan.Hours > 0)
                    {
                        objRL.Set_Error_Color(dataGridView1, RCount, "clmOverTime", Color.Pink);

                        TOT = TimeSpan.Zero;
                        TOT = TimeSpan.Parse(objRL.CheckNullString(Convert.ToString(dt.Rows[i]["OverTime"])));

                        //if (!ChangeFlag)
                        //    OTHoursTotal += TOT.Hours;

                        if (!ChangeFlag)
                        {
                            if (objPC.ChangeDepartmentFlag == 0)
                            {
                                OTHoursTotal += TOT.Hours;
                            }
                        }

                        if(ChangeFlag && objPC.ChangeDepartmentFlag>0)
                            OTHoursTotal += TOT.Hours;
                    }

                    if (OTSpan.Hours > 4)
                    {
                        objRL.Set_Error_Color(dataGridView1, RCount, "clmOverTime", Color.FromName(BusinessResources.LS_Error_Color));
                    }

                    dataGridView1.Rows[RCount].Cells["clmTotalDuration"].Value = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["TotalDuration"]));
                    dataGridView1.Rows[RCount].Cells["clmStatus"].Value = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["Status"]));

                    dataGridView1.Rows[RCount].Cells["clmLateBy"].Value = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["LateBy"]));
                    dataGridView1.Rows[RCount].Cells["clmEarlyBy"].Value = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["EarlyBy"]));

                    dataGridView1.Rows[RCount].Cells["clmOTApprovalFlagAR"].Value = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["OTFlagAR"]));
                    dataGridView1.Rows[RCount].Cells["clmOTStatus"].Value = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["OTApprovalStatus"]));
                    dataGridView1.Rows[RCount].Cells["clmRemarks"].Value = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["OTRemarks"]));
                    dataGridView1.Rows[RCount].Cells["clmOTReply"].Value = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["OTReply"]));

                    objPC.LateBy = 0;
                    objPC.LateBy = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[i]["LateBy"])));
                    dataGridView1.Rows[RCount].Cells["clmLateBy"].Value = objPC.LateBy.ToString();

                    objPC.EarlyBy = 0;
                    objPC.EarlyBy = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[i]["EarlyBy"])));
                    dataGridView1.Rows[RCount].Cells["clmEarlyBy"].Value = objPC.EarlyBy.ToString();

                  
                    string ChangeLocation = string.Empty, ChangeDepartment = string.Empty;

                    if (!ChangeFlag)
                    {
                        if (objPC.ChangeDepartmentFlag > 0)
                        {
                            ChangeLocation = objRL.Fill_Location_By_LocationId(objPC.ChangeLocationtId);
                            ChangeDepartment = objRL.Fill_Department_By_DepartmentId(objPC.ChangeDepartmentId);

                            dataGridView1.Rows[RCount].Cells["clmChangeLocationtId"].Value = objRL.CheckNullString(Convert.ToString(ChangeLocation));
                            dataGridView1.Rows[RCount].Cells["clmChangeDepartmentId"].Value = objRL.CheckNullString(Convert.ToString(ChangeDepartment));

                            objRL.Set_Error_Color(dataGridView1, RCount, "clmChangeLocationtId", Color.Coral);
                            objRL.Set_Error_Color(dataGridView1, RCount, "clmChangeDepartmentId", Color.Coral);
                            TransferCount++;
                        }
                    }
                    else
                    {
                        //ChangeLocation = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["EmpLocation"]));
                        //ChangeDepartment = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["EmpDepartment"]));

                        ChangeLocation = objRL.Fill_Location_By_LocationId(objPC.ChangeLocationtId);
                        ChangeDepartment = objRL.Fill_Department_By_DepartmentId(objPC.ChangeDepartmentId);

                        dataGridView1.Rows[RCount].Cells["clmChangeLocationtId"].Value = objRL.CheckNullString(Convert.ToString(ChangeLocation));
                        dataGridView1.Rows[RCount].Cells["clmChangeDepartmentId"].Value = objRL.CheckNullString(Convert.ToString(ChangeDepartment));

                        objRL.Set_Error_Color(dataGridView1, RCount, "clmChangeLocationtId", Color.Coral);
                        objRL.Set_Error_Color(dataGridView1, RCount, "clmChangeDepartmentId", Color.Coral);
                        TransferCount++;
                    }

                    //if (ChangeFlag)
                    //{
                    //    if (objPC.ChangeDepartmentFlag > 0)
                    //    {
                    //        //string ChangeLocation = string.Empty, ChangeDepartment = string.Empty;

                    //        ChangeLocation = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["EmpLocation"]));
                    //        ChangeDepartment = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["EmpDepartment"]));

                    //        ChangeLocation = objRL.Fill_Location_By_LocationId(objPC.ChangeLocationtId);
                    //        ChangeDepartment = objRL.Fill_Department_By_DepartmentId(objPC.ChangeDepartmentId);


                    //        dataGridView1.Rows[RCount].Cells["clmChangeLocationtId"].Value = objRL.CheckNullString(Convert.ToString(ChangeLocation));
                    //        dataGridView1.Rows[RCount].Cells["clmChangeDepartmentId"].Value = objRL.CheckNullString(Convert.ToString(ChangeDepartment));

                    //        objRL.Set_Error_Color(dataGridView1, RCount, "clmChangeLocationtId", Color.Coral);
                    //        objRL.Set_Error_Color(dataGridView1, RCount, "clmChangeDepartmentId", Color.Coral);
                    //        TransferCount++;
                    //    }
                    //}

                    RCount++;
                    SrNo++;
                }
                
            }
        }

        double OTHoursTotal = 0;
        private void Fill_Grid_AttendanceRecord_Old()
        {
            
            TransferCount = 0;
            objEP.Clear();
            TOT = TimeSpan.Zero;
            lblTotalCount.Text = "";
            lblPending.Text = "";
            lblManagerApproved.Text = "";
            lblHRApproved.Text = "";
            //lblInchargeApproved.Text = "";
            lblRemark.Text = "";
            lblReject.Text = "";

            OTHoursTotal = 0;
            ManagerApprovedCount = 0;
            Pending_Count = 0;

            dataGridView1.Rows.Clear();
            //dataGridView1.DataSource = null;

            //if (objPC.AttendanceRecordMasterId != 0)
            //{
            //lblData.Text = objPC.AttendanceData.ToString();
            cmbAttendanceStatus.Text = objPC.ApprovalStatus;

            //if (cmbAttendanceStatus.SelectedIndex > -1)
            //    SetStatusColor();

            System.Data.DataTable ds = new System.Data.DataTable();
            WhereClause = string.Empty;
            MainQuery = string.Empty;

            //WhereClause = " and ARM.AttendanceDate='"+dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD)+ "' and E.OverTimeApplicable=1 and TIME_TO_SEC(AR.OverTime) / 3600 > 0 "; //AR.OverTime !='00:00' or AR.OverTime !='0:0'

            //WhereClause = " and ARM.AttendanceDate='" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and E.OverTimeApplicable=1 and TIME_TO_SEC(AR.OverTime) / 3600 > 0 "; //AR.OverTime !='00:00' or AR.OverTime !='0:0'

            WhereClause = " and ARM.AttendanceDate='" + dtpOTDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' "; // and E.OverTimeApplicable=1 and TIME_TO_SEC(AR.OverTime) / 3600 > 0 "; //AR.OverTime !='00:00' or AR.OverTime !='0:0'

            if (!cbSelectAllLocation.Checked)
                WhereClause += " and E.LocationId=" + cmbLocation.SelectedValue + "";
            else
                WhereClause += " and " + objQL.Get_Location_Id("Location") + " ";

            if (!cbSelectAllDepartment.Checked)
                WhereClause += " and E.DepartmentId=" + cmbDepartment.SelectedValue + "";
            else
                WhereClause += " and " + objQL.Get_Location_Id("Department");

            if (cbTransferEmployee.Checked)
                WhereClause += " and AR.ChangeDepartmentFlag>0";

            MainQuery = "select " +
                         "AR.AttendanceRecordId," +
                         "AR.AttendanceRecordMasterId," +
                         "AR.AttendanceHistoryId," +
                         "AR.EsslAttendanceLogsId," +
                         "AR.EmployeeId," +
                         "ARM.AttendanceDate," +
                         "E.EmployeeName," +
                         "E.EmployeeCode," +
                         "AR.ShiftId," +
                         "S.ShiftSName," +
                         "AR.ShiftGroupId," +
                         "AR.InTime," +
                         "AR.OutTime," +
                         "AR.Duration," +
                         "AR.OverTime," +
                         "AR.TotalDuration," +
                         "AR.Status," +
                         "AR.LateBy," +
                         "AR.EarlyBy," +
                         "AR.MissedInPunch," +
                         "AR.MissedOutPunch," +
                         "AR.ChangeDepartmentFlag," +
                         "AR.ChangeDepartmentId," +
                         "AR.ChangeLocationtId," +
                         "AR.LeaveTypeId," +
                         "AR.LeaveDuration," +
                         "AR.WeeklyOff," +
                         "AR.Holiday," +
                         "AR.LeaveRemarks," +
                         "AR.PunchRecords," +
                         "AR.LossOfHours," +
                         "AR.Present," +
                         "AR.Absent," +
                         "AR.Remarks," +
                         "S.ShiftDuration," +
                         "S.ShiftDurationHours," +
                         "S.BeginTime," +
                         "S.EndTime," +
                         "AR.EditFlag," +
                         "E.CategoryId," +
                         "E.ContractorId," +
                         "L.LocationName," +
                         "D.Department," +
                         "ARM.OTApprovalFlag, " +
                         "AR.OTApprovalFlag as 'OTFlagAR'," +
                         "AR.OTApprovalStatus, " +
                         "AR.Notes," +
                         "AR.OTRemarks," +
                         "AR.OTReply " +
                         " from AttendanceRecord AR inner join " +
                         " attendancerecordmaster ARM on ARM.AttendanceRecordMasterId=AR.AttendanceRecordMasterId inner join " +
                         " Employees E on E.EmployeeId=AR.EmployeeId inner join " +
                         " shifts S on S.ShiftId=AR.ShiftId inner join " +
                         " locationmaster L on L.LocationId=E.LocationId inner join " +
                         " departmentmaster D on D.DepartmentId=E.DepartmentId " +
                         " where " +
                         " AR.CancelTag=0 and" +
                         " ARM.CancelTag=0 and" +
                         " E.CancelTag=0 and " +
                         " S.CancelTag=0 ";

            objBL.Query = MainQuery + WhereClause + "  order by ARM.AttendanceDate asc";
            ds = objBL.ReturnDataTable();

            if (ds.Rows.Count > 0)
            {
                lblTotalCount.Text = "Total Count: " + ds.Rows.Count.ToString();

                SrNo = 1;
                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    //0 AR.AttendanceRecordId,
                    //1 AR.AttendanceRecordMasterId,
                    //2 AR.AttendanceHistoryId,
                    //3 AR.EsslAttendanceLogsId,
                    //4 AR.EmployeeId, 
                    //5 E.EmployeeName,
                    //6 E.EmployeeCode,
                    //7 AR.ShiftId, 
                    //8 S.ShiftSName,
                    //9 AR.ShiftGroupId,
                    //10 AR.InTime,
                    //11 AR.OutTime,
                    //12 AR.Duration,
                    //13AR.OverTime,
                    //14 AR.TotalDuration,
                    //15 AR.Status,
                    //16 AR.LateBy,
                    //17 AR.EarlyBy,
                    //18 AR.MissedInPunch,
                    //19 AR.MissedOutPunch,
                    //20 AR.ChangeDepartmentFlag,
                    //21 AR.ChangeDepartmentId,
                    //22 AR.ChangeLocationtId,
                    //23 AR.IsOnLeave,
                    //24 AR.LeaveTypeId,
                    //25 AR.LeaveDuration,
                    //26 AR.WeeklyOff,
                    //27 AR.Holiday,
                    //28 AR.LeaveRemarks,
                    //29 AR.PunchRecords,
                    //30 AR.LossOfHours,
                    //31 AR.Present,
                    //32 AR.Absent,
                    //33 AR.Remarks
                    //34  S.ShiftDuration,
                    //35 S.ShiftDurationHours,
                    //36 S.BeginTime,
                    //37 S.EndTime,
                    //38 AR.EditFlag,
                    //E.CategoryId,
                    //E.ContractorId,
                    //OTApprovalFlag
                    //OTFlagAR
                    //OTApprovalStatus
                    //OTRemarks

                    dataGridView1.Rows.Add();
                    int EditFlag = 0;
                     
                    dataGridView1.Rows[i].Cells["clmSelectAll"].Value = false;

                    dataGridView1.Rows[i].Cells["clmSrNo"].Value = SrNo.ToString();
                    dataGridView1.Rows[i].Cells["clmOTApprovalFlag"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["OTApprovalFlag"])); //ds.Rows[i]["AttendanceRecordId"].ToString();

                    dataGridView1.Rows[i].Cells["clmAttendanceRecordId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["AttendanceRecordId"])); //ds.Rows[i]["AttendanceRecordId"].ToString();

                    DateTime dt = Convert.ToDateTime(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["AttendanceDate"])));
                    //dataGridView1.Rows[i].Cells["clmAttendanceDate"].Value = dt.ToString(BusinessResources.DATEFORMATDDMMMYYYY); // objRL.CheckNullString(Convert.ToString(ds.Rows[i]["AttendanceRecordId"])); //ds.Rows[i]["AttendanceRecordId"].ToString();

                    dataGridView1.Rows[i].Cells["clmAttendanceRecordMasterId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["AttendanceRecordMasterId"])); //ds.Rows[i]["AttendanceRecordMasterId"].ToString();
                    dataGridView1.Rows[i].Cells["clmEsslAttendanceLogsId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EsslAttendanceLogsId"])); //ds.Rows[i]["EsslAttendanceLogsId"].ToString();
                    dataGridView1.Rows[i].Cells["clmEmployeeId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EmployeeId"])); //ds.Rows[i]["EmployeeId"].ToString();
                    dataGridView1.Rows[i].Cells["clmEmployeeName"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EmployeeName"])); //ds.Rows[i]["EmployeeName"].ToString();
                    dataGridView1.Rows[i].Cells["clmEmployeeCode"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EmployeeCode"])); //ds.Rows[i]["EmployeeCode"].ToString();

                    dataGridView1.Rows[i].Cells["clmShiftId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftId"])); //ds.Rows[i]["ShiftId"].ToString();
                    dataGridView1.Rows[i].Cells["clmShift"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftSName"])); //ds.Rows[i]["ShiftSName"].ToString();
                    dataGridView1.Rows[i].Cells["clmShiftGroupId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftGroupId"]));

                    dataGridView1.Rows[i].Cells["clmLocation"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LocationName"]));
                    dataGridView1.Rows[i].Cells["clmDepartment"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Department"]));

                    dtInTime = Convert.ToDateTime(ds.Rows[i]["InTime"].ToString());
                    dtOutTime = Convert.ToDateTime(ds.Rows[i]["OutTime"].ToString());

                    objPC.CategoryId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["CategoryId"])));
                    objPC.ContractorId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ContractorId"])));

                    //objRL.Get_CategoriesDetails_By_Id();

                    dataGridView1.Rows[i].Cells["clmInTime"].Value = dtInTime.ToString("HH:mm");
                    dataGridView1.Rows[i].Cells["clmOutTime"].Value = dtOutTime.ToString("HH:mm");

                    //objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftId"])));
                    dataGridView1.Rows[i].Cells["clmShiftDuration"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftDurationHours"])); // objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftDuration"])); //ds.Rows[i]["ShiftId"].ToString();
                    dataGridView1.Rows[i].Cells["clmDuration"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Duration"])); //Convert.ToString(ds.Rows[i]["Duration"].ToString());
                    dataGridView1.Rows[i].Cells["clmOverTime"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["OverTime"]));

                    TimeSpan OTSpan = TimeSpan.Zero;
                    OTSpan = TimeSpan.Zero;

                    OTSpan = TimeSpan.Parse(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["OverTime"])));

                    if (OTSpan.Hours > 0)
                    {
                        objRL.Set_Error_Color(dataGridView1, i, "clmOverTime", Color.Pink);

                        TOT = TimeSpan.Zero;
                        TOT = TimeSpan.Parse(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["OverTime"])));
                        OTHoursTotal += TOT.Hours;
                    }

                    if (OTSpan.Hours > 4)
                    {
                        objRL.Set_Error_Color(dataGridView1, i, "clmOverTime", Color.FromName(BusinessResources.LS_Error_Color));
                    }

                    dataGridView1.Rows[i].Cells["clmTotalDuration"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["TotalDuration"]));
                    dataGridView1.Rows[i].Cells["clmStatus"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Status"]));

                    dataGridView1.Rows[i].Cells["clmLateBy"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LateBy"]));
                    dataGridView1.Rows[i].Cells["clmEarlyBy"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EarlyBy"]));

                    dataGridView1.Rows[i].Cells["clmOTApprovalFlagAR"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["OTFlagAR"]));
                    dataGridView1.Rows[i].Cells["clmOTStatus"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["OTApprovalStatus"]));
                    dataGridView1.Rows[i].Cells["clmRemarks"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["OTRemarks"]));
                    dataGridView1.Rows[i].Cells["clmOTReply"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["OTReply"]));

                    objPC.LateBy = 0;
                    objPC.LateBy = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LateBy"])));
                    dataGridView1.Rows[i].Cells["clmLateBy"].Value = objPC.LateBy.ToString();

                    objPC.EarlyBy = 0;
                    objPC.EarlyBy = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EarlyBy"])));
                    dataGridView1.Rows[i].Cells["clmEarlyBy"].Value = objPC.EarlyBy.ToString();

                    objPC.ChangeDepartmentFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentFlag"])));
                    objPC.ChangeLocationtId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeLocationtId"])));
                    objPC.ChangeDepartmentId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentId"])));

                    if(objPC.ChangeDepartmentFlag >0)
                    {
                        objPC.AttendanceRecordId= objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["AttendanceRecordId"])));

                          MainQuery = "select " +
                         "AR.AttendanceRecordId," +
                         "AR.AttendanceRecordMasterId," +
                         "AR.AttendanceHistoryId," +
                         "AR.EsslAttendanceLogsId," +
                         "AR.EmployeeId," +
                         "ARM.AttendanceDate," +
                         "E.EmployeeName," +
                         "E.EmployeeCode," +
                         "AR.ShiftId," +
                         "S.ShiftSName," +
                         "AR.ShiftGroupId," +
                         "AR.InTime," +
                         "AR.OutTime," +
                         "AR.Duration," +
                         "AR.OverTime," +
                         "AR.TotalDuration," +
                         "AR.Status," +
                         "AR.LateBy," +
                         "AR.EarlyBy," +
                         "AR.MissedInPunch," +
                         "AR.MissedOutPunch," +
                         "AR.ChangeDepartmentFlag," +
                         "AR.ChangeDepartmentId," +
                         "AR.ChangeLocationtId," +
                         "AR.LeaveTypeId," +
                         "AR.LeaveDuration," +
                         "AR.WeeklyOff," +
                         "AR.Holiday," +
                         "AR.LeaveRemarks," +
                         "AR.PunchRecords," +
                         "AR.LossOfHours," +
                         "AR.Present," +
                         "AR.Absent," +
                         "AR.Remarks," +
                         "S.ShiftDuration," +
                         "S.ShiftDurationHours," +
                         "S.BeginTime," +
                         "S.EndTime," +
                         "AR.EditFlag," +
                         "E.CategoryId," +
                         "E.ContractorId," +
                         "L.LocationName," +
                         "D.Department," +
                         "ARM.OTApprovalFlag, " +
                         "AR.OTApprovalFlag as 'OTFlagAR'," +
                         "AR.OTApprovalStatus, " +
                         "AR.Notes," +
                         "AR.OTRemarks," +
                         "AR.OTReply " +
                         " from AttendanceRecord AR inner join " +
                         " attendancerecordmaster ARM on ARM.AttendanceRecordMasterId=AR.AttendanceRecordMasterId inner join " +
                         " Employees E on E.EmployeeId=AR.EmployeeId inner join " +
                         " shifts S on S.ShiftId=AR.ShiftId inner join " +
                         " locationmaster L on L.LocationId=AR.ChangeLocationtId inner join " +
                         " departmentmaster D on D.DepartmentId=AR.ChangeDepartmentId " +
                         " where " +
                         " AR.CancelTag=0 and" +
                         " ARM.CancelTag=0 and" +
                         " E.CancelTag=0 and " +
                         " S.CancelTag=0 and " +
                         " AR.AttendanceRecordId=" + objPC.AttendanceRecordId + " ";

                        //string CLocationIn= objQL.Get_Location_Id_Type_Object("Location", "AR.");
                        //string CDepartmentIn = objQL.Get_Location_Id_Type_Object("Location", "AR.");


                        //objBL.Query = MainQuery + WhereClause;

                        //DataSet dsLoc = new DataSet();

                        //dsLoc= objBL.ReturnDataSet();

                        //if(dsLoc.Tables[0].Rows.Count > 0 )
                        //{
                        //   string ChangeLocation=string.Empty,ChangeDepartment=string.Empty;

                        //    ChangeLocation = objRL.CheckNullString(Convert.ToString(dsLoc.Tables[0].Rows[0]["LocationName"]));
                        //    ChangeDepartment = objRL.CheckNullString(Convert.ToString(dsLoc.Tables[0].Rows[0]["Department"]));
                            
                        //    dataGridView1.Rows[i].Cells["clmChangeLocationtId"].Value = objRL.CheckNullString(Convert.ToString(ChangeLocation));
                        //    dataGridView1.Rows[i].Cells["clmChangeDepartmentId"].Value = objRL.CheckNullString(Convert.ToString(ChangeDepartment));

                        //    objRL.Set_Error_Color(dataGridView1, i, "clmChangeLocationtId", Color.Coral);
                        //    objRL.Set_Error_Color(dataGridView1, i, "clmChangeDepartmentId", Color.Coral);
                        //    TransferCount++;
                        //}
                    }
                    //20 AR.ChangeDepartmentFlag,
                    //21 AR.ChangeDepartmentId,
                    //22 AR.ChangeLocationtId,
                     
                    SrNo++;
                } //End For Loop


                //objPC.AttendanceRecordId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["AttendanceRecordId"])));
                WhereClause=string.Empty;

                WhereClause = " and ARM.AttendanceDate='" + dtpOTDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' "; // and E.OverTimeApplicable=1 and TIME_TO_SEC(AR.OverTime) / 3600 > 0 "; //AR.OverTime !='00:00' or AR.OverTime !='0:0'

                MainQuery = "select " +
              "AR.AttendanceRecordId," +
              "AR.AttendanceRecordMasterId," +
              "AR.AttendanceHistoryId," +
              "AR.EsslAttendanceLogsId," +
              "AR.EmployeeId," +
              "ARM.AttendanceDate," +
              "E.EmployeeName," +
              "E.EmployeeCode," +
              "AR.ShiftId," +
              "S.ShiftSName," +
              "AR.ShiftGroupId," +
              "AR.InTime," +
              "AR.OutTime," +
              "AR.Duration," +
              "AR.OverTime," +
              "AR.TotalDuration," +
              "AR.Status," +
              "AR.LateBy," +
              "AR.EarlyBy," +
              "AR.MissedInPunch," +
              "AR.MissedOutPunch," +
              "AR.ChangeDepartmentFlag," +
              "AR.ChangeDepartmentId," +
              "AR.ChangeLocationtId," +
              "AR.LeaveTypeId," +
              "AR.LeaveDuration," +
              "AR.WeeklyOff," +
              "AR.Holiday," +
              "AR.LeaveRemarks," +
              "AR.PunchRecords," +
              "AR.LossOfHours," +
              "AR.Present," +
              "AR.Absent," +
              "AR.Remarks," +
              "S.ShiftDuration," +
              "S.ShiftDurationHours," +
              "S.BeginTime," +
              "S.EndTime," +
              "AR.EditFlag," +
              "E.CategoryId," +
              "E.ContractorId," +
              "L.LocationName," +
              "D.Department," +
              "ARM.OTApprovalFlag, " +
              "AR.OTApprovalFlag as 'OTFlagAR'," +
              "AR.OTApprovalStatus, " +
              "AR.Notes," +
              "AR.OTRemarks," +
              "AR.OTReply " +
              " from AttendanceRecord AR inner join " +
              " attendancerecordmaster ARM on ARM.AttendanceRecordMasterId=AR.AttendanceRecordMasterId inner join " +
              " Employees E on E.EmployeeId=AR.EmployeeId inner join " +
              " shifts S on S.ShiftId=AR.ShiftId inner join " +
              " locationmaster L on L.LocationId=AR.ChangeLocationtId inner join " +
              " departmentmaster D on D.DepartmentId=AR.ChangeDepartmentId " +
              " where " +
              " AR.CancelTag=0 and" +
              " ARM.CancelTag=0 and" +
              " E.CancelTag=0 and " +
              " S.CancelTag=0 and " +
              " AR.ChangeDepartmentFlag >0 and " +
               " S.CancelTag=0 ";

                //string CLocationIn =string.Empty, CDepartmentIn = string.Empty;

                //CLocationIn = objQL.Get_Location_Id_Type_Object("Location", "AR.");
                //if (!cbSelectAllLocation.Checked)
                WhereClause += " and " + objQL.Get_Change_LocationId_And_DepartmentId_Type_Object("Location", "AR.") + " ";

                //if (!cbSelectAllDepartment.Checked)
                WhereClause += " and " + objQL.Get_Change_LocationId_And_DepartmentId_Type_Object("Department", "AR.") + " ";

                //CDepartmentIn = objQL.Get_Location_Id_Type_Object("Department", "AR.");

                //WhereClause = CLocationIn + " " + CDepartmentIn;

                objBL.Query = MainQuery + WhereClause + "  order by ARM.AttendanceDate asc";

                DataSet dsLoc = new DataSet();

                dsLoc = objBL.ReturnDataSet();

                if (dsLoc.Tables[0].Rows.Count > 0)
                {
                    int RCount = dataGridView1.Rows.Count;

                    for (int i = 0; i < dsLoc.Tables[0].Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add();
                        string ChangeLocation = string.Empty, ChangeDepartment = string.Empty;

                        ChangeLocation = objRL.CheckNullString(Convert.ToString(dsLoc.Tables[0].Rows[i]["LocationName"]));
                        ChangeDepartment = objRL.CheckNullString(Convert.ToString(dsLoc.Tables[0].Rows[i]["Department"]));

                        dataGridView1.Rows[RCount].Cells["clmChangeLocationtId"].Value = objRL.CheckNullString(Convert.ToString(ChangeLocation));
                        dataGridView1.Rows[RCount].Cells["clmChangeDepartmentId"].Value = objRL.CheckNullString(Convert.ToString(ChangeDepartment));

                        objRL.Set_Error_Color(dataGridView1, RCount, "clmChangeLocationtId", Color.Coral);
                        objRL.Set_Error_Color(dataGridView1, RCount, "clmChangeDepartmentId", Color.Coral);
                        RCount++;
                        TransferCount++;
                    }
                }

                //20 AR.ChangeDepartmentFlag,
                //21 AR.ChangeDepartmentId,
                //22 AR.ChangeLocationtId,

                cbTransferEmployee.Text = "Transfer Employee: " + TransferCount.ToString();

                dataGridView1.ClearSelection();

                objPC.AttendanceDate = dtpOTDate.Value;

                objPC.AttendanceDay = objPC.AttendanceDate.DayOfWeek.ToString();

                objRL.Get_Incharge_Senior_OfficerId();

                string LName = string.Empty, DName = string.Empty;

                if (cbSelectAllLocation.Checked)
                    LName = "ALL";
                else
                    LName = cmbLocation.Text;

                if (cbSelectAllDepartment.Checked)
                    DName = "ALL";
                else
                    DName = cmbDepartment.Text;

                //objPC.AttendanceData = "Attendance From Date-" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATDDMMYYYY) + "-To Date-" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATDDMMYYYY) + System.Environment.NewLine +
                //                       "Location- " + LName + System.Environment.NewLine +
                //                       "Department- " + DName + System.Environment.NewLine;

                //lblData.Text = objPC.AttendanceData.ToString();

                lblOverTime.Text = "Total Over Time (in Hours) - " + OTHoursTotal.ToString();
                //TOtal OVertime

                string AStatus = string.Empty, OTStatus = string.Empty;
                foreach (DataGridViewRow Myrow in dataGridView1.Rows)
                {
                    OTStatus = string.Empty;
                    OTStatus = objRL.CheckNullString(Convert.ToString(Myrow.Cells["clmOTStatus"].Value));
                    if (OTStatus == "Pending")
                    {
                        Pending_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Pending_Color);
                    }
                    else if (OTStatus == "Remarks")
                    {
                        Remarks++;
                        Myrow.DefaultCellStyle.BackColor =  Color.FromName(BusinessResources.LS_Remarks_Color);
                    }
                    else if (OTStatus == "Manager Approved")
                    {
                        ManagerApprovedCount++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Manager_Color);
                    }
                    else
                    {

                    }
                }

                lblPending.Text = "Pending: " + Pending_Count.ToString();
                lblManagerApproved.Text = "Manager Approved: " + ManagerApprovedCount.ToString();
                lblRemark.Text = "Remarks: " + Remarks.ToString();
            }
            //}
        }
        private void cbSelectAllLocation_CheckedChanged(object sender, EventArgs e)
        {
            //if (cbSelectAllLocation.Checked)
            //{
            //    cmbLocation.SelectedIndex = -1;
            //    cmbLocation.Enabled = false;
            //}
            //else
            //{
            //    cmbLocation.SelectedIndex = -1;
            //    cmbLocation.Enabled = true;
            //}
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            TableId = 0;
            cbSelectAllLocation.Checked = true;
            cbSelectAllDepartment.Checked = true;
            //cmbLocation.Enabled = false;
            //cmbLocation.Enabled = false;
            
            cmbLocation.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            txtRemarks.Text = "";
            cmbAttendanceStatus.SelectedIndex = -1;
            TOT = TimeSpan.Zero;
            dataGridView1.Rows.Clear();
            lblPending.Text = "";
            Pending_Count = 0;
            lblManagerApproved.Text = "";
            ManagerApprovedCount = 0;
            lblOverTime.Text = "";

            lblPending.Text = "";
            lblManagerApproved.Text = "";
            lblRemark.Text = "";
            lblHRApproved.Text = "";
            lblReject.Text = "";
            lblTotalCount.Text = "";

            SName = string.Empty;
            lblStatusValue.Text = "";

            dtpOTDate.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidationMain())
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    bool isChecked = (bool)dataGridView1.Rows[i].Cells[0].Value;

                    if(isChecked)
                    {
                        int AttendanceRecordId = 0,Result=0;
                        AttendanceRecordId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[i].Cells["clmAttendanceRecordId"].Value)));

                        objBL.Query = "update attendancerecord set OTApprovalFlag=1,OTApprovalStatus='" + cmbAttendanceStatus.Text + "',OTRemarks='" + txtRemarks.Text + "' where AttendanceRecordId=" + AttendanceRecordId + "";
                        Result = objBL.Function_ExecuteNonQuery();

                        int CompleteFlag = 0, OTApprovalFlag=0;

                        if(cmbAttendanceStatus.Text == BusinessResources.LS_Completed)
                            CompleteFlag = 1;
                        else
                            CompleteFlag = 0;

                        if (cmbAttendanceStatus.Text == BusinessResources.LS_ManagerApproved)
                            OTApprovalFlag = 1;
                        else
                            OTApprovalFlag = 0;

                        //objBL.Query = "update attendancerecordmaster set ApprovalStatusId="+cmbAttendanceStatus.SelectedValue+ ",CompleteFlag="+ CompleteFlag + ", OTApprovalFlag=" + OTApprovalFlag + " where AttendanceDate='" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";
                        objBL.Query = "update attendancerecordmaster set ApprovalStatusId=" + cmbAttendanceStatus.SelectedValue + ",CompleteFlag=" + CompleteFlag + ", OTApprovalFlag=" + OTApprovalFlag + " where AttendanceDate='" + dtpOTDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and LocationId=" + cmbLocation.SelectedValue + " and DepartmentId=" + cmbDepartment.SelectedValue + "";
                        Result = objBL.Function_ExecuteNonQuery();
                         
                    }
                }

                objRL.ShowMessage(7, 1);
                cmbAttendanceStatus.SelectedIndex = -1;
                txtRemarks.Text = "";
                //return;
            }
        }

       

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
