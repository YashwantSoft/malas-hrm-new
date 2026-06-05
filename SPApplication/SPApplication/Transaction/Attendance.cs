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
    public partial class Attendance : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0, Pending_Count = 0, HRApproved_Count = 0, InchargeApproved_Count = 0,ManagerApproved_Count=0, Completed_Count = 0, Remarks_Count = 0, Reject_Count = 0, SelectedCount = 0, LocationId = 0;

        string EmpDesignation = string.Empty;
        string EmpDepartment = string.Empty;
        string MainQuery = string.Empty;
        string WhereClause = string.Empty;
        string OrderBy = string.Empty;

        double WorkDurationCal = 0, OverTime_Cal = 0;
        int SearchId = 0;

        public Attendance()
        {
            InitializeComponent();
            //cmbLocation.Enabled = false;
            //objDL.SetButtonDesign
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_ATTENDANCEAPPROVALMASTER);
            btnSave.Text = BusinessResources.BTN_VIEW;
            SearchId = BusinessLayer.EmployeeLoginId_Static;

            objRL.FillLocation(cmbLocation, cmbDepartment);

            //FillLocation();
            FillColor();
            //objQL.Fill_Master_ComboBox(cmbLocation, "locationmaster");

            //if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMIN || BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMIN)
            //{

            //}


            //if (BusinessLayer.UserType != BusinessResources.USER_TYPE_ADMIN && BusinessLayer.UserType != BusinessResources.USER_TYPE_OFFICER)
            //{
            //    objQL.WhereClause_V = " and lwd.InchargeId=" + BusinessLayer.EmployeeLoginId_Static + "";
            //    objQL.Fill_Location_By_EmployeeId(cmbLocation);
            //    cmbLocation.Text = BusinessLayer.LocationName;
            //    FillDepartment();
            //    cmbLocation.Enabled = false;
            //    cmbDepartment.Text = BusinessLayer.Department;
            //}
            //else
            //{
            //    objQL.Fill_Master_ComboBox(cmbLocation, "locationmaster");
            //  //  if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMIN || BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMIN)
            //    cmbLocation.Enabled = true;
            //    cmbLocation.SelectedIndex=-1;
            //    cmbDepartment.SelectedIndex = -1;
            //    FillGrid_AttendanceRecordMaster();
            //}

            //if (BusinessLayer.UserType != BusinessResources.USER_TYPE_ADMIN)
            //{
            //    cmbLocation.Text = BusinessLayer.LocationName;
            //    //FillDepartment();
            //    cmbDepartment.Text = BusinessLayer.Department;
            //    //cmbLocation.Enabled = false;
            //    //cmbDepartment.Enabled = false;
            //}
            //Status_ComboBox();
            //Fill_Status();

            objRL.Fill_Approval_Status(cmbApprovalStatus);
        }
       
        private void FillColor()
        {
            lblPending.Text = BusinessResources.LS_Pending;
            lblHRApproved.Text = BusinessResources.LS_HRApproved;
            lblInchargeApproved.Text = BusinessResources.LS_InchargeApproved;
            lblManagerApproved.Text = BusinessResources.LS_ManagerApproved;
            lblReject.Text = BusinessResources.LS_Reject;
            lblRemark.Text = BusinessResources.LS_Remarks;
            lblCompleted.Text = BusinessResources.LS_Completed;

            lblPending.BackColor = Color.FromName(BusinessResources.LS_Pending_Color);
            lblHRApproved.BackColor = Color.FromName(BusinessResources.LS_HRApproved_Color);
            lblInchargeApproved.BackColor = Color.FromName(BusinessResources.LS_InchargeApproved_Color);
            lblManagerApproved.BackColor = Color.FromName(BusinessResources.LS_Manager_Color);
            lblReject.BackColor = Color.FromName(BusinessResources.LS_Reject_Color);
            lblRemark.BackColor = Color.FromName(BusinessResources.LS_Remarks_Color);
            lblCompleted.BackColor = Color.FromName(BusinessResources.LS_Completed_Color);
        }
          

        //private void FillLocation()
        //{
        //    //MANAGER           BusinessResources.USER_TYPE_MANAGER
        //    //SENIOR OFFICER    BusinessResources.USER_TYPE_SENIOROFFICER
        //    //OFFICER           BusinessResources.USER_TYPE_OFFICER
        //    //TRAINEE           
        //    //SUPERVISOR        BusinessResources.USER_TYPE_SUPERVISOR
        //    //WORKER
        //    //ADMINISTRATOR    BusinessResources.USER_TYPE_ADMINISTRATOR
        //    //HR OFFICER

        //    btnSave.Visible = false;

        //    if (BusinessLayer.DesignationCategory == BusinessResources.USER_TYPE_MANAGER)
        //        objQL.WhereClause_V = " and lwd.PlantHeadId=" + SearchId + " ";
        //    else if (BusinessLayer.DesignationCategory == BusinessResources.USER_TYPE_SENIOROFFICER)
        //        objQL.WhereClause_V = " and lwd.InchargeId=" + SearchId + " ";
        //    else if (BusinessLayer.DesignationCategory == BusinessResources.USER_TYPE_ADMINISTRATOR)
        //    {
        //        btnSave.Visible = true;
        //        objQL.WhereClause_V = "";
        //    }
        //    else
        //    {
        //        objRL.ShowMessage(38, 4);
        //        return;
        //    }

        //    //if (BusinessLayer.DesignationCategory == BusinessResources.USER_TYPE_INCHARGE)
        //    //    objQL.WhereClause_V = " and lwd.InchargeId=" + SearchId + " ";
        //    //else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER)
        //    //    objQL.WhereClause_V = " and lwd.PlantHeadId=" + SearchId + " ";
        //    //else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMIN)
        //    //{
        //    //    btnSave.Visible = true;
        //    //    objQL.WhereClause_V = "";
        //    //}
        //    //else
        //    //{
        //    //    objRL.ShowMessage(38, 4);
        //    //    return;
        //    //}

        //    objQL.Fill_Location_By_EmployeeId(cmbLocation);

        //    if (BusinessLayer.UserType == BusinessResources.USER_TYPE_INCHARGE)
        //    {
        //        cmbLocation.Text = BusinessLayer.LocationName;
        //        FillDepartment();
        //        //cmbLocation.Enabled = false;
        //        cmbDepartment.Text = BusinessLayer.Department;
        //    }
        //    else
        //    {
        //        cmbLocation.Enabled = true;
        //        cmbLocation.SelectedIndex = -1;
        //        cmbDepartment.SelectedIndex = -1;
        //    }
        //}

        ////private void FillDepartmentAdmin()
        ////{
        ////    //Hardcode
        ////    if (cmbLocation.SelectedIndex > -1)
        ////    {
        ////        //LocationId = 
        ////        objRL.Fill_Department_ComboBox_By_Location(cmbDepartment, Convert.ToInt32(cmbLocation.SelectedValue));
        ////    }
        ////}


        //private void FillDepartment()
        //{
        //    if (cmbLocation.SelectedIndex > -1)
        //    {
        //        LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
        //        objPC.LocationId = LocationId;
        //        objPC.InchargeId = BusinessLayer.EmployeeLoginId_Static;
        //        objQL.WhereClause_V = string.Empty;

        //        if (BusinessLayer.DesignationCategory == BusinessResources.USER_TYPE_MANAGER)
        //            objQL.WhereClause_V = " and lwd.PlantHeadId=" + SearchId + " and lwd.LocationId=" + objPC.LocationId + " ";
        //        else if (BusinessLayer.DesignationCategory == BusinessResources.USER_TYPE_SENIOROFFICER)
        //            objQL.WhereClause_V = " and lwd.InchargeId=" + SearchId + " and lwd.LocationId=" + objPC.LocationId + " ";
        //        else if (BusinessLayer.DesignationCategory == BusinessResources.USER_TYPE_ADMINISTRATOR)
        //        {
        //            btnSave.Visible = true;
        //            objQL.WhereClause_V = "";
        //        }
        //        else
        //        {
        //            objRL.ShowMessage(38, 4);
        //            return;
        //        }

        //        //if (BusinessLayer.UserType == BusinessResources.USER_TYPE_INCHARGE)
        //        //    objQL.WhereClause_V = " and lwd.InchargeId=" + SearchId + " and lwd.LocationId=" + objPC.LocationId + " ";
        //        //else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER)
        //        //    objQL.WhereClause_V = " and lwd.PlantHeadId=" + SearchId + " and lwd.LocationId=" + objPC.LocationId + " ";
        //        //else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMIN)
        //        //    objQL.WhereClause_V = " and lwd.LocationId=" + objPC.LocationId + " ";
        //        //else
        //        //{
        //        //    objRL.ShowMessage(38, 4);
        //        //    return;
        //        //}

        //        objQL.Fill_Department_By_EmployeeId(cmbDepartment);
               
        //        //if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMIN) // && BusinessLayer.UserType != BusinessResources.USER_TYPE_OFFICER)
        //        //{
                    
        //        //    //objQL.WhereClause_V = " and lwd.HRId=" + BusinessLayer.EmployeeLoginId_Static + "";
        //        //    if (BusinessLayer.UserType == BusinessResources.USER_TYPE_PLANTHEAD)
        //        //        objPC.SearchType = BusinessResources.USER_TYPE_PLANTHEAD;
        //        //    else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_INCHARGE)
        //        //        objPC.SearchType = BusinessResources.USER_TYPE_INCHARGE;
        //        //    else
        //        //        objPC.SearchType = BusinessResources.USER_TYPE_INCHARGE;

        //        //    objQL.SP_ApprovalLevel_Get_Department_By_LocationId_InchargeId(cmbDepartment);
        //        //}
        //        //    //objPC.SearchType = BusinessResources.USER_TYPE_ADMIN;
                    
        //        //else
        //        //{
        //        //    FillDepartmentAdmin();
        //        //}
        //    }
        //}

        private void AttendanceApprovalMaster_Load(object sender, EventArgs e)
        {
            ClearAll();
            //this.WindowState = FormWindowState.Maximized;
            //FillGrid_AttendanceRecordMaster();
        }

        private void SetMonthYear()
        {
            string MonthName = objRL.GetMonthName(DateTime.Now.Date.Month);
            int YearNo = DateTime.Now.Year;

            cmbYear.Text = YearNo.ToString();
            cmbMonth.Text = MonthName.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        //private void Status_ComboBox()
        //{
        //    cmbStatus.Items.Clear();
        //    if (BusinessLayer.UserType == BusinessResources.USER_TYPE_PLANTHEAD)
        //        cmbStatus.Items.Add(BusinessResources.STATUS_FINAL_APPROVED);
        //    else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMIN)
        //        cmbStatus.Items.Add(BusinessResources.STATUS_HR_APPROVED);
        //    else
        //        cmbStatus.Items.Clear();
        //}

       
        //private bool Validation()
        //{
        //    objEP.Clear();
        //    if (cmbLocation.SelectedIndex == -1)
        //    {
        //        cmbLocation.Focus();
        //        objEP.SetError(cmbLocation, " Enter Location");
        //        return true;
        //    }
        //    else if (cmbDepartment.SelectedIndex == -1)
        //    {
        //        cmbDepartment.Focus();
        //        objEP.SetError(cmbDepartment, " Enter Department");
        //        return true;
        //    }
        //    else
        //        return false;
        //}

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Validation())
            {
                //Fill_Record();
                //FillGrid();
                FillGrid();
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }
        private bool CheckExist_Record()
        {
            DataSet ds = new DataSet();
            //ApprovedFlag
            objPC.AttendanceDate = dtpAttendanceDate.Value;
            objPC.LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
            objPC.DepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue);
            ds = objQL.SP_AttendanceRecordMaster_CheckExist();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (!string.IsNullOrWhiteSpace(Convert.ToString(ds.Tables[0].Rows[0][0].ToString())))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
      
        private void cmbDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbLocation.SelectedIndex > -1 && cmbDepartment.SelectedIndex > -1)
            {
                //cmbApprovalStatus.Text = BusinessResources.LS_Pending;
               // FillGrid();
            }
        }

        private void cmbLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(cmbLocation.SelectedIndex >-1)
                objRL.FillDepartment(cmbLocation, cmbDepartment);

            //FillDepartment();

        }

        string WhereClause_LocationDeparment=string.Empty;
        string WhereClause_Status=string.Empty;

    //    private void FillGrid_AttendanceRecordMaster()
    //    {
    //        WhereClause=string.Empty;
    //        WhereClause_LocationDeparment=string.Empty;
    //        WhereClause_Status=string.Empty;



    ////        string MainQUery="select arm.AttendanceRecordMasterId,arm.EntryDate,arm.AttendanceDate as 'Attendance Date',arm.LocationId,lm.LocationName as 'Location Name',arm.DepartmentId, dm.Department,arm.InchargeId,e.EmployeeName as 'HR Name',arm.ApprovedFlag, 
    ////    arm.ApprovalStatus as 'Approval Status',
    ////    arm.Status as 'Status',
    ////    arm.AttendanceRecordMasterId as 'View'
    ////from
    ////    attendancerecordmaster arm inner join
    ////    locationmaster lm on lm.LocationId=arm.LocationId inner join
    ////    departmentmaster dm on dm.DepartmentId=arm.DepartmentId inner join
    ////    employees e on e.EmployeeId=arm.InchargeId
    ////where
    ////    arm.CancelTag=0 and
    ////    lm.CancelTag=0 and
    ////    dm.CancelTag=0 and
    ////    e.CancelTag=0 and
    ////    arm.LocationId=LocationId_V and 
    ////    arm.DepartmentId=DepartmentId_V order by arm.AttendanceRecordMasterId desc;


    //        dataGridView1.DataSource = null;
    //        //dataGridView1.Columns.Clear();
    //        DataTable dt = new DataTable();
    //        //objPC.LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
    //        objPC.LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
    //        objPC.DepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue);

    //        if (cbSelectAllStatus.Checked)
    //            WhereClause_Status = "";
    //        else
    //        {
    //            if (cmbAttendanceStatus.SelectedIndex > -1)
    //                WhereClause_Status = " and arm.Status='" + cmbAttendanceStatus.Text + "'";
    //            else
    //                WhereClause_Status = "";
    //        }


    //        WhereClause_LocationDeparment = " and arm.LocationId=" + Convert.ToInt32(cmbLocation.SelectedValue) + " and arm.DepartmentId=" + Convert.ToInt32(cmbDepartment.SelectedValue) + "";

    //        //if (BusinessLayer.UserType != BusinessResources.USER_TYPE_ADMIN && BusinessLayer.UserType != BusinessResources.USER_TYPE_OFFICER)
    //        //    WhereClause_LocationDeparment = " and arm.LocationId=LocationId_V and arm.DepartmentId=DepartmentId_V";
    //        //else
    //        //    WhereClause_LocationDeparment = ""; //" and arm.LocationId=LocationId_V and arm.DepartmentId=DepartmentId_V";

    //        dt = objQL.SP_AttendanceRecordMaster_FillGrid();

    //        WhereClause = BusinessResources.AttendanceRecordMaster_WhereClause + WhereClause_LocationDeparment + WhereClause_Status;
            
    //        objQL.TableNames_V = BusinessResources.AttendanceRecordMaster_Tables;
    //        objQL.ColumnNames_V = BusinessResources.AttendanceRecordMaster_Column;
    //        objQL.WhereClause_V = WhereClause;
    //        objQL.OrderBy_V = BusinessResources.AttendanceRecordMaster_OrderBy;
    //        objQL.GroupBy_V = "";
            
    //        dt = objQL.SP_AttendanceRecordMaster_Concat_Query();

    //        //if (BusinessLayer.UserType != BusinessResources.USER_TYPE_ADMIN && BusinessLayer.UserType != BusinessResources.USER_TYPE_OFFICER)
    //        //    dt = objQL.SP_AttendanceRecordMaster_FillGrid();
    //        //else
    //        //    dt = objQL.SP_AttendanceRecordMaster_FillGrid_Admin_Officer();

    //        if (dt.Rows.Count > 0)
    //        {
    //            dataGridView1.DataSource = dt;
    //            lblTotalCount.Text = "Total-" + dt.Rows.Count;
    //            //0 arm.AttendanceRecordMasterId,
    //            //1 arm.EntryDate, 
    //            //2 arm.AttendanceDate as 'Attendance Date', 
    //            //3 arm.LocationId,
    //            //4 lm.Location,
    //            //5 arm.DepartmentId,
    //            //6 dm.Department,
    //            //7 arm.InchargeId,
    //            //8 e.EmployeeName as 'Employee Name',
    //            //9 arm.ApprovedFlag, 
    //            //10 arm.ApprovalStatus, 
    //            //11 arm.Status as 'Status',
    //            //12 arm.AttendanceRecordMasterId as 'View'

    //            dataGridView1.Columns[0].Visible = false;
    //            dataGridView1.Columns[1].Visible = false;
    //            dataGridView1.Columns[3].Visible = false;
    //            dataGridView1.Columns[5].Visible = false;
    //            dataGridView1.Columns[7].Visible = false;
    //            dataGridView1.Columns[9].Visible = false;
    //            dataGridView1.Columns[10].Visible = false;
    //            dataGridView1.Columns[12].Visible = false;

    //            dataGridView1.Columns[2].Width = 150;
    //            dataGridView1.Columns[4].Width = 200;
    //            dataGridView1.Columns[6].Width = 200;
    //            dataGridView1.Columns[8].Width = 350;
    //            dataGridView1.Columns[10].Width = 200;
    //            dataGridView1.Columns[11].Width = 250;
    //            //dataGridView1.Columns[12].Width = 60;

    //            Pending_Count = 0; HRApproved_Count = 0; InchargeApproved_Count = 0; ManagerApproved_Count = 0; Completed_Count = 0; Remarks_Count = 0; Reject_Count = 0;

    //            string AStatus = string.Empty;
                 
    //            foreach (DataGridViewRow Myrow in dataGridView1.Rows)
    //            {
    //                AStatus = string.Empty;
    //                //Here 2 cell is target value and 1 cell is Volume
    //                if (!string.IsNullOrEmpty(Convert.ToString(Myrow.Cells[11].Value)))
    //                    AStatus = Convert.ToString(Myrow.Cells[11].Value);

    //                if (AStatus == BusinessResources.LS_Pending)
    //                {
    //                    Pending_Count++;
    //                    Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Pending_Color);
    //                }
    //                else if (AStatus == BusinessResources.LS_HRApproved)
    //                {
    //                    HRApproved_Count++;
    //                    Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_HRApproved_Color);
    //                }
    //                else if (AStatus == BusinessResources.LS_InchargeApproved)
    //                {
    //                    InchargeApproved_Count++;
    //                    Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_InchargeApproved_Color);
    //                }
    //                else if (AStatus == BusinessResources.LS_ManagerApproved)
    //                {
    //                    ManagerApproved_Count++;
    //                    Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Manager_Color);
    //                }
    //                else if (AStatus == BusinessResources.LS_Completed)
    //                {
    //                    HRApproved_Count++;
    //                    Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Completed_Color);
    //                }
    //                else if (AStatus == BusinessResources.LS_Remarks)
    //                {
    //                    Remarks_Count++;
    //                    Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Remarks_Color);
    //                }
    //                else if (AStatus == BusinessResources.LS_Reject)
    //                {
    //                    Reject_Count++;
    //                    Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Reject_Color);
    //                }
    //                else
    //                {
    //                    //string hex = BusinessResources.BACKGROUND_COLOUR;
    //                    //Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
    //                    //Myrow.DefaultCellStyle.BackColor = _color;
    //                }
    //            }

    //            //lblDepartmentHeadApproved.Text = BusinessResources.STATUS_DEPARTMENT_HEAD_APPROVED + "Pending-" + PendingCount.ToString();
    //            //lblFinalApproved.Text = BusinessResources.STATUS_FINAL_APPROVED + "-" + FinaldApproved_Count.ToString();
    //            //lblHRApproved.Text = BusinessResources.STATUS_HR_APPROVED + "-" + HRApproved_Count.ToString();
    //            //lblCancel.Text = BusinessResources.STATUS_CANCEL + "-" + Cancel_Count.ToString();

    //            lblPending.Text = BusinessResources.LS_Pending + "-" + InchargeApproved_Count.ToString();
    //            lblHRApproved.Text = BusinessResources.LS_HRApproved + "-" + HRApproved_Count.ToString();
    //            lblInchargeApproved.Text = BusinessResources.LS_InchargeApproved + "-" + InchargeApproved_Count.ToString();
    //            lblManagerApproved.Text = BusinessResources.LS_ManagerApproved + "-" + ManagerApproved_Count.ToString();
    //            lblCompleted.Text = BusinessResources.LS_ManagerApproved + "-" + Completed_Count.ToString();
    //            lblRemark.Text = BusinessResources.LS_Remarks + "-" + Remarks_Count.ToString();
    //            lblReject.Text = BusinessResources.LS_Reject + "-" + Reject_Count.ToString();

    //            dataGridView1.ClearSelection();
    //            //dataGridView1.CurrentCell = Nothing;
    //        }
    //    }

        private bool Validation()
        {
            objEP.Clear();
            bool ReturnFlag = false;
            
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
            else if(!cbAttendanceDate.Checked)
            {
                if (cmbMonth.SelectedIndex == -1)
                {
                    cmbMonth.Focus();
                    objEP.SetError(cmbMonth, "Select Month");
                    return true;
                }
                else if (cmbYear.SelectedIndex == -1)
                {
                    cmbYear.Focus();
                    objEP.SetError(cmbYear, "Select Year");
                    return true;
                }
                else
                    return false;
            }
 
            else if (!cbSelectAllStatus.Checked)
            {
                if (cmbApprovalStatus.SelectedIndex == -1)
                {
                    cmbApprovalStatus.Focus();
                    objEP.SetError(cmbApprovalStatus, "Select Approval Status");
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        private void FillGrid12()
        {
            lblCompleted.Text = "";
            objPC.ApprovalStatusId = 0;
            dataGridView1.DataSource = null;
            DataTable dt = new DataTable();
            objPC.LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
            objPC.DepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue);

            if (cmbApprovalStatus.SelectedIndex > -1)
                objPC.ApprovalStatusId = Convert.ToInt32(cmbApprovalStatus.SelectedValue);

            dt = objQL.SP_AttendanceRecordMaster_FillGrid();

            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                lblCompleted.Text = "Total-" + dt.Rows.Count;
                //0 arm.AttendanceRecordMasterId,
                //1 arm.AttendanceHistoryId,
                //2 arm.EntryDate, 
                //3 arm.AttendanceDate as 'Attendance Date', 
                //4 arm.LocationId,
                //5 lm.LocationName as 'Location Name',
                //6 arm.DepartmentId,
                //7 dm.Department,
                //8 arm.HRId,
                //9 e.EmployeeName as 'HR Name',
                //10 arm.InchargeId,
                //11 e1.EmployeeName as 'Incharge Name',
                //12 arm.ApprovalStatusId,
                //13 asm.AttendanceStatus as 'Approval Status',
                //14 arm.CompleteFlag,
                //15 arm.OTApprovalFlag as 'OT Approval',
                //16 arm.OTApprovalFlag

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[14].Visible = false;
                dataGridView1.Columns[16].Visible = false;

                dataGridView1.Columns[3].Width = 150;
                dataGridView1.Columns[5].Width = 400;
                dataGridView1.Columns[7].Width = 400;
                dataGridView1.Columns[9].Width = 200;
                dataGridView1.Columns[11].Width = 200;
                dataGridView1.Columns[13].Width = 150;
                dataGridView1.Columns[15].Width = 100;

                dataGridView1.Columns[15].HeaderText = "OT Approval";

                Pending_Count = 0; HRApproved_Count = 0; InchargeApproved_Count = 0; ManagerApproved_Count = 0; Completed_Count = 0; Remarks_Count = 0; Reject_Count = 0;

                string AStatus = string.Empty;

                foreach (DataGridViewRow Myrow in dataGridView1.Rows)
                {
                    AStatus = string.Empty;
                    //Here 2 cell is target value and 1 cell is Volume
                    if (!string.IsNullOrEmpty(Convert.ToString(Myrow.Cells[13].Value)))
                        AStatus = Convert.ToString(Myrow.Cells[13].Value);

                    if (AStatus == BusinessResources.LS_Pending)
                    {
                        Pending_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Pending_Color);
                    }
                    else if (AStatus == BusinessResources.LS_HRApproved)
                    {
                        HRApproved_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_HRApproved_Color);
                    }
                    else if (AStatus == BusinessResources.LS_InchargeApproved)
                    {
                        InchargeApproved_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_InchargeApproved_Color);
                    }
                    else if (AStatus == BusinessResources.LS_ManagerApproved)
                    {
                        ManagerApproved_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Manager_Color);
                    }
                    else if (AStatus == BusinessResources.LS_Completed)
                    {
                        Completed_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Completed_Color);
                    }
                    else if (AStatus == BusinessResources.LS_Remarks)
                    {
                        Remarks_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Remarks_Color);
                    }
                    else if (AStatus == BusinessResources.LS_Reject)
                    {
                        Reject_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Reject_Color);
                    }
                    else
                    {
                        //string hex = BusinessResources.BACKGROUND_COLOUR;
                        //Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
                        //Myrow.DefaultCellStyle.BackColor = _color;
                    }
                }
                
                //foreach (DataGridViewRow Myrow in dataGridView1.Rows)
                //{
                //    AStatus = string.Empty;
                //    //Here 2 cell is target value and 1 cell is Volume
                //    if (!string.IsNullOrEmpty(Convert.ToString(Myrow.Cells[13].Value)))
                //    {
                //    }
                //}

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    //if (i == 13)
                    //{

                    //}
                    if (objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[i].Cells[16].Value))) == 0)
                    {
                        dataGridView1.Rows[i].Cells[15].Value = "No";
                        dataGridView1.Rows[i].Cells[15].Style.BackColor = Color.DeepSkyBlue;
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[15].Value = "Yes";
                    }


                    //if (BusinessLayer.UserType == BusinessResources.USER_TYPE_SENIOROFFICER ||  BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER)
                    //{
                    //    //if (i == 13)
                    //    //{
                    //    //}
                    //    string RStatus = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[i].Cells[13].Value));

                    //    if (RStatus != BusinessResources.LS_HRApproved)
                    //    {
                    //        dataGridView1.Rows[i].ReadOnly = true;

                    //        //CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                    //        //currencyManager1.SuspendBinding();
                    //        //dataGridView1.Rows[i].Visible = false;
                    //        //currencyManager1.ResumeBinding();
                    //    }
                    //    else
                    //        dataGridView1.Rows[i].ReadOnly = false;
                    //}
                    //if (objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[i].Cells[13].Value))) == 0)
                }


                //foreach (DataGridView Myrow1 in dataGridView1.Columns)
                //{
                //    if(Myrow1.Cells[)
                //    Myrow1.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Reject_Color);
                //}

                //lblDepartmentHeadApproved.Text = BusinessResources.STATUS_DEPARTMENT_HEAD_APPROVED + "Pending-" + PendingCount.ToString();
                //lblFinalApproved.Text = BusinessResources.STATUS_FINAL_APPROVED + "-" + FinaldApproved_Count.ToString();
                //lblHRApproved.Text = BusinessResources.STATUS_HR_APPROVED + "-" + HRApproved_Count.ToString();
                //lblCancel.Text = BusinessResources.STATUS_CANCEL + "-" + Cancel_Count.ToString();

                lblPending.Text = BusinessResources.LS_Pending + "-" + Pending_Count.ToString();
                lblHRApproved.Text = BusinessResources.LS_HRApproved + "-" + HRApproved_Count.ToString();
                lblInchargeApproved.Text = BusinessResources.LS_InchargeApproved + "-" + InchargeApproved_Count.ToString();
                lblManagerApproved.Text = BusinessResources.LS_ManagerApproved + "-" + ManagerApproved_Count.ToString();
                lblCompleted.Text = BusinessResources.LS_ManagerApproved + "-" + Completed_Count.ToString();
                lblRemark.Text = BusinessResources.LS_Remarks + "-" + Remarks_Count.ToString();
                lblReject.Text = BusinessResources.LS_Reject + "-" + Reject_Count.ToString();
                dataGridView1.ClearSelection();
                //dataGridView1.CurrentCell = Nothing;
            }


            //if (cbSelectAllStatus.Checked)
            //    WhereClause_Status = "";
            //else
            //{
            //    if (cmbApprovalStatus.SelectedIndex > -1)
            //        WhereClause_Status = " and arm.ApprovalStatusId=" + cmbApprovalStatus.SelectedValue + "";
            //    else
            //        WhereClause_Status = "";
            //}
            //WhereClause_LocationDeparment = " and arm.LocationId=" + Convert.ToInt32(cmbLocation.SelectedValue) + " and arm.DepartmentId=" + Convert.ToInt32(cmbDepartment.SelectedValue) + "";
            //WhereClause = BusinessResources.AttendanceRecordMaster_WhereClause + WhereClause_LocationDeparment + WhereClause_Status;
            //objQL.TableNames_V = BusinessResources.AttendanceRecordMaster_Tables;
            //objQL.ColumnNames_V = BusinessResources.AttendanceRecordMaster_Column;
            //objQL.WhereClause_V = WhereClause;
            //objQL.OrderBy_V = BusinessResources.AttendanceRecordMaster_OrderBy;
            //objQL.GroupBy_V = "";

            //dt = objQL.SP_AttendanceRecordMaster_Concat_Query();

            ////if (BusinessLayer.UserType != BusinessResources.USER_TYPE_ADMIN && BusinessLayer.UserType != BusinessResources.USER_TYPE_OFFICER)
            ////    dt = objQL.SP_AttendanceRecordMaster_FillGrid();
            ////else
            ////    dt = objQL.SP_AttendanceRecordMaster_FillGrid_Admin_Officer();

            
        }

        private void FillGrid()
        {
            dataGridView1.DataSource = null;
            DataTable dt = new DataTable();
            MainQuery = string.Empty;
            WhereClause = string.Empty;
            OrderBy = string.Empty;
            MainQuery = "select " +
                    "arm.AttendanceRecordMasterId," +
                    "arm.AttendanceHistoryId," +
                    "arm.EntryDate, " +
                    "arm.AttendanceDate as 'Attendance Date', " +
                    "arm.LocationId," +
                    "lm.LocationName as 'Location Name'," +
                    "arm.DepartmentId," +
                    "dm.Department," +
                    "arm.HRId," +
                    "e.EmployeeName as 'HR Name'," +
                    "arm.InchargeId," +
                    "e1.EmployeeName as 'Incharge Name'," +
                    "arm.ApprovalStatusId," +
                    "asm.AttendanceStatus as 'Approval Status'," +
                    "arm.CompleteFlag," +
                    "'No'," +
                    "arm.OTApprovalFlag" +
                " from " +
                    "attendancerecordmaster arm inner join " +
                    "locationmaster lm on lm.LocationId=arm.LocationId inner join " +
                    "departmentmaster dm on dm.DepartmentId=arm.DepartmentId inner join " +
                    "employees e on e.EmployeeId=arm.HRId inner join " +
                    "employees e1 on e1.EmployeeId=arm.InchargeId inner join " +
                    "attendancestatusmaster asm on asm.AttendanceStatusId=arm.ApprovalStatusId " +
                " where " +
                    "arm.CancelTag=0 and " +
                    "lm.CancelTag=0 and " +
                    "dm.CancelTag=0 and " +
                    "e.CancelTag=0 and arm.FinancialYearId=" + objPC.FinancialYearId + " ";
           
            if(cmbLocation.SelectedIndex >-1)
                WhereClause += " and arm.LocationId=" + cmbLocation.SelectedValue + "";
            if (cmbDepartment.SelectedIndex > -1)
                WhereClause += " and arm.DepartmentId=" + cmbDepartment.SelectedValue + "";
            
            if (!cbAttendanceDate.Checked)
            {
                if (cmbMonth.SelectedIndex > -1)
                    WhereClause += " and MONTH(arm.AttendanceDate)=" + objRL.GetMonthNumber(cmbMonth.Text) + "";
                if (cmbYear.SelectedIndex > -1)
                    WhereClause += " and YEAR(arm.AttendanceDate)=" + cmbYear.Text + "";
            }
            else
                WhereClause += " and arm.AttendanceDate='" + dtpAttendanceDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";

            if (cmbApprovalStatus.SelectedIndex > -1)
                WhereClause += " and arm.ApprovalStatusId=" + cmbApprovalStatus.SelectedValue + "";
                 

            OrderBy = " order by arm.AttendanceDate desc";

            objBL.Query = MainQuery + WhereClause +  OrderBy;
            dt = objBL.ReturnDataTable();

            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                lblCompleted.Text = "Total-" + dt.Rows.Count;
                //0 arm.AttendanceRecordMasterId,
                //1 arm.AttendanceHistoryId,
                //2 arm.EntryDate, 
                //3 arm.AttendanceDate as 'Attendance Date', 
                //4 arm.LocationId,
                //5 lm.LocationName as 'Location Name',
                //6 arm.DepartmentId,
                //7 dm.Department,
                //8 arm.HRId,
                //9 e.EmployeeName as 'HR Name',
                //10 arm.InchargeId,
                //11 e1.EmployeeName as 'Incharge Name',
                //12 arm.ApprovalStatusId,
                //13 asm.AttendanceStatus as 'Approval Status',
                //14 arm.CompleteFlag,
                //15 arm.OTApprovalFlag as 'OT Approval',
                //16 arm.OTApprovalFlag

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[14].Visible = false;
                dataGridView1.Columns[16].Visible = false;

                dataGridView1.Columns[3].Width = 150;
                dataGridView1.Columns[5].Width = 400;
                dataGridView1.Columns[7].Width = 400;
                dataGridView1.Columns[9].Width = 200;
                dataGridView1.Columns[11].Width = 200;
                dataGridView1.Columns[13].Width = 150;
                dataGridView1.Columns[15].Width = 100;

                dataGridView1.Columns[15].HeaderText = "OT Approval";

                Pending_Count = 0; HRApproved_Count = 0; InchargeApproved_Count = 0; ManagerApproved_Count = 0; Completed_Count = 0; Remarks_Count = 0; Reject_Count = 0;

                string AStatus = string.Empty;

                foreach (DataGridViewRow Myrow in dataGridView1.Rows)
                {
                    AStatus = string.Empty;
                    //Here 2 cell is target value and 1 cell is Volume
                    if (!string.IsNullOrEmpty(Convert.ToString(Myrow.Cells[13].Value)))
                        AStatus = Convert.ToString(Myrow.Cells[13].Value);

                    if (AStatus == BusinessResources.LS_Pending)
                    {
                        Pending_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Pending_Color);
                    }
                    else if (AStatus == BusinessResources.LS_HRApproved)
                    {
                        HRApproved_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_HRApproved_Color);
                    }
                    else if (AStatus == BusinessResources.LS_InchargeApproved)
                    {
                        InchargeApproved_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_InchargeApproved_Color);
                    }
                    else if (AStatus == BusinessResources.LS_ManagerApproved)
                    {
                        ManagerApproved_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Manager_Color);
                    }
                    else if (AStatus == BusinessResources.LS_Completed)
                    {
                        Completed_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Completed_Color);
                    }
                    else if (AStatus == BusinessResources.LS_Remarks)
                    {
                        Remarks_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Remarks_Color);
                    }
                    else if (AStatus == BusinessResources.LS_Reject)
                    {
                        Reject_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Reject_Color);
                    }
                    else
                    {
                        //string hex = BusinessResources.BACKGROUND_COLOUR;
                        //Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
                        //Myrow.DefaultCellStyle.BackColor = _color;
                    }
                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    //if (i == 13)
                    //{

                    //}
                    if (objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[i].Cells[16].Value))) == 0)
                    {
                        dataGridView1.Rows[i].Cells[15].Value = "No";
                        dataGridView1.Rows[i].Cells[15].Style.BackColor = Color.DeepSkyBlue;
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[15].Value = "Yes";
                    }

                }
                lblPending.Text = BusinessResources.LS_Pending + "-" + Pending_Count.ToString();
                lblHRApproved.Text = BusinessResources.LS_HRApproved + "-" + HRApproved_Count.ToString();
                lblInchargeApproved.Text = BusinessResources.LS_InchargeApproved + "-" + InchargeApproved_Count.ToString();
                lblManagerApproved.Text = BusinessResources.LS_ManagerApproved + "-" + ManagerApproved_Count.ToString();
                lblCompleted.Text = BusinessResources.LS_ManagerApproved + "-" + Completed_Count.ToString();
                lblRemark.Text = BusinessResources.LS_Remarks + "-" + Remarks_Count.ToString();
                lblReject.Text = BusinessResources.LS_Reject + "-" + Reject_Count.ToString();
                dataGridView1.ClearSelection();
            }
            else
            {
                objRL.ShowMessage(35, 4);
                return;
            }
        }

        // DateTime AttendanceDate;        //int ApprovedFlag = 0;
        string Department = string.Empty, InchargeName = string.Empty, ApprovalStatus = string.Empty;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                RowCount_Grid = dataGridView1.Rows.Count;
                CurrentRowIndex = dataGridView1.CurrentRow.Index;

                if (RowCount_Grid >= 0 && CurrentRowIndex >= 0)
                {
                    //0 arm.AttendanceRecordMasterId,
                    //1 arm.EntryDate, 
                    //2 arm.AttendanceDate as 'Attendance Date', 
                    //3 arm.LocationId,
                    //4 lm.Location,
                    //5 arm.DepartmentId,
                    //6 dm.Department,
                    //7 arm.InchargeId,
                    //8 e.EmployeeName as 'Employee Name',
                    //9 arm.ApprovedFlag, 
                    //10 arm.ApprovalStatus, 

                    if (BusinessLayer.UserType == BusinessResources.USER_TYPE_SENIOROFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER)
                    {
                        string RStatus = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[13].Value));

                        if (RStatus == BusinessResources.LS_HRApproved || RStatus == BusinessResources.LS_Remarks)
                        {
                            ViewData_OnClick(dataGridView1, e.RowIndex);
                        }
                        else
                        {
                            objRL.ShowMessage(24, 4);
                            return;
                        }
                    }

                    if (BusinessLayer.UserType == BusinessResources.USER_TYPE_HROFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR)
                        ViewData_OnClick(dataGridView1, e.RowIndex);
                   
                    //objPC.LocationName = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
                    //objPC.Department = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[6].Value);
                    //objPC.ApprovalStatus = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[10].Value);
                    //objPC.ApprovedFlag = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[9].Value);
                    //objPC.AttendanceDate = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                    //objPC.InchargeName = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[8].Value);
                    //objPC.AttendanceData = "Location-" + objPC.LocationName + System.Environment.NewLine + "Department-" + objPC.Department + System.Environment.NewLine + "Incharge Name-" + objPC.InchargeName + System.Environment.NewLine + "Attendance Date-" + objPC.AttendanceDate.ToString(BusinessResources.DATEFORMATDDMMYYYY) + System.Environment.NewLine + "Attendance Day-" + cmbAttendanceDay.Text;
                    //objPC.ApprovedFlag = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[9].Value);
                    //objPC.ApprovalStatus = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[10].Value);

                    //objPC.AttendanceRecordMasterId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                    //AttendanceWorking objForm = new AttendanceWorking();
                    //objForm.Show(this);
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

        private void ViewData_OnClick(DataGridView dgv,int RIndex)
        {
            //0 arm.AttendanceRecordMasterId,
            //1 arm.AttendanceHistoryId,
            //2 arm.EntryDate, 
            //3 arm.AttendanceDate as 'Attendance Date', 
            //4 arm.LocationId,
            //5 lm.LocationName as 'Location Name',
            //6 arm.DepartmentId,
            //7 dm.Department,
            //8 arm.HRId,
            //9 e.EmployeeName as 'HR Name',
            //10 arm.InchargeId,
            //11 e1.EmployeeName as 'Incharge Name',
            //12 arm.ApprovalStatusId,
            //13 asm.AttendanceStatus as 'Approval Status',
            //14 arm.CompleteFlag

            objPC.LocationId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dgv.Rows[RIndex].Cells[4].Value)));
            objPC.DepartmentId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dgv.Rows[RIndex].Cells[6].Value)));

            objPC.AttendanceRecordMasterId = Convert.ToInt32(dgv.Rows[RIndex].Cells[0].Value);
            objPC.AttendanceDate = Convert.ToDateTime(dgv.Rows[RIndex].Cells[3].Value);
            objPC.LocationName = Convert.ToString(dgv.Rows[RIndex].Cells[5].Value);
            objPC.Department = Convert.ToString(dgv.Rows[RIndex].Cells[7].Value);
            objPC.ApprovalStatus = Convert.ToString(dgv.Rows[RIndex].Cells[13].Value);
            objPC.ApprovedFlag = Convert.ToInt32(dgv.Rows[RIndex].Cells[14].Value);
            objPC.InchargeName = Convert.ToString(dgv.Rows[RIndex].Cells[11].Value);
            objPC.HRName = Convert.ToString(dgv.Rows[RIndex].Cells[9].Value);
            objPC.HRId = Convert.ToInt32(dgv.Rows[RIndex].Cells[8].Value);
            objPC.InchargeId = Convert.ToInt32(dgv.Rows[RIndex].Cells[10].Value);
            objPC.AttendanceDay= objPC.AttendanceDate.DayOfWeek.ToString();
            objRL.Get_Incharge_Senior_OfficerId();

            //objPC.AttendanceData = "Attendance Date- " + objPC.AttendanceDate.ToString(BusinessResources.DATEFORMATDDMMYYYY) + " | " + objPC.AttendanceDay.ToString() + System.Environment.NewLine + System.Environment.NewLine +
            //                       "Location- " + objPC.LocationName + System.Environment.NewLine +
            //                       "Department- " + objPC.Department + System.Environment.NewLine +
            //                       "Manager Name- " + objPC.PlantHeadName + System.Environment.NewLine +
            //                       "Senior Officer Name- " + objPC.InchargeName + System.Environment.NewLine +
            //                       "HR Name- " + objPC.HRName + System.Environment.NewLine;

            objPC.AttendanceData = "Attendance Date- " + objPC.AttendanceDate.ToString(BusinessResources.DATEFORMATDDMMYYYY) + " | " + objPC.AttendanceDay.ToString() + System.Environment.NewLine + System.Environment.NewLine +
                                   "Location- " + objPC.LocationName + System.Environment.NewLine+
                                   "Department- " + objPC.Department + System.Environment.NewLine;
            
            AttendanceWorking objForm = new AttendanceWorking();
            objForm.Show(this);
            cbSelectAllStatus.Checked = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
            dataGridView1.DataSource = null;
            
            //FillGrid();
        }

        private void ClearAll()
        {
            objEP.Clear();
            cmbLocation.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            cbAttendanceDate.Checked = true;
            cbSelectAllStatus.Checked = false;
            Set_Approval_Status();
            dtpAttendanceDate.Value = DateTime.Now.Date;
            SetMonthYear();
        }

        private void dtpAttendanceDate_ValueChanged(object sender, EventArgs e)
        {
            lblAttendanceDay.Text = "Attendance Day-" + Convert.ToString(dtpAttendanceDate.Value.Date.DayOfWeek);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dataGridView1.Rows.Count > 0)
            //{
            //    if (e.ColumnIndex == 12)
            //    {
            //        ViewData_OnClick(dataGridView1, e.RowIndex);
            //    }
            //}
        }

        private void Set_Approval_Status()
        {
            cmbApprovalStatus.SelectedIndex = -1;
            if (cbSelectAllStatus.Checked)
            {
                cmbApprovalStatus.Enabled = false;
                cmbApprovalStatus.SelectedIndex = -1;
            }
            else
            {
                cmbApprovalStatus.Text = BusinessResources.LS_Pending;
                cmbApprovalStatus.Enabled = true;
            }
        }

        private void cbSelectAllStatus_CheckedChanged(object sender, EventArgs e)
        {
            Set_Approval_Status();
            //FillGrid();
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
            cmbApprovalStatus.DataSource = null;
            objRL.Fill_Approval_Status(cmbApprovalStatus);

            //cmbApprovalStatus.Items.Clear();
            //cmbApprovalStatus.Enabled = true;
            //if (BusinessLayer.UserType == BusinessResources.USER_TYPE_INCHARGE)
            //{
            //    cmbApprovalStatus.Items.Add(BusinessResources.LS_InchargeApproved);
            //    cmbApprovalStatus.Items.Add(BusinessResources.LS_Pending);
            //    cmbApprovalStatus.Items.Add(BusinessResources.LS_Remarks);
            //}
            //else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER || BusinessLayer.UserType == BusinessResources.USER_TYPE_PLANTHEAD)
            //{
            //    cmbApprovalStatus.Items.Add(BusinessResources.LS_ManagerApproved);
            //    cmbApprovalStatus.Items.Add(BusinessResources.LS_Pending);
            //    cmbApprovalStatus.Items.Add(BusinessResources.LS_Remarks);
            //    cmbApprovalStatus.Items.Add(BusinessResources.LS_Reject);
            //}
            //else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMIN)
            //{
            //    cmbApprovalStatus.Items.Add(BusinessResources.LS_HRApproved);
            //    cmbApprovalStatus.Items.Add(BusinessResources.LS_ManagerApproved);
            //    cmbApprovalStatus.Items.Add(BusinessResources.LS_InchargeApproved);
            //    cmbApprovalStatus.Items.Add(BusinessResources.LS_Completed);
            //    cmbApprovalStatus.Items.Add(BusinessResources.LS_Pending);
            //    cmbApprovalStatus.Items.Add(BusinessResources.LS_Remarks);
            //    cmbApprovalStatus.Items.Add(BusinessResources.LS_Reject);
            //}
            //else
            //    cmbApprovalStatus.Items.Clear();
        }

        private void cmbAttendanceStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbApprovalStatus.SelectedIndex > -1)
            {
                //FillGrid();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void MonthYear_Visible(bool FlagF)
        {
            lblMonth.Visible = FlagF;
            lblYear.Visible = FlagF;
            cmbMonth.Visible = FlagF;
            cmbYear.Visible = FlagF;

            if (!FlagF)
            {
                cmbMonth.SelectedIndex = -1;
                cmbYear.SelectedIndex = -1;
                dtpAttendanceDate.Visible = true;
                lblAttendanceDay.Visible = true;
            }
            else
            {
                SetMonthYear();
                dtpAttendanceDate.Visible = false;
                lblAttendanceDay.Visible = false;
            }
        }

        private void cbAttendanceDate_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAttendanceDate.Checked)
            {
                MonthYear_Visible(false);
            }
            else
            {
                MonthYear_Visible(true);
            }
        }
    }
}
