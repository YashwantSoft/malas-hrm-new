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

namespace SPApplication.Report
{
    public partial class LeaveReport : Form
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

        public LeaveReport()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.REPORT_LEAVEREPORT);
            btnSave.Text = BusinessResources.BTN_REPORT;
            ClearAll();
            objRL.Fill_Location_ComboBox(cmbLocation);
           // objQL.Fill_Master_ComboBox(cmbLeaveType, "leavetypes");
            objQL.Fill_Master_ComboBox(cmbContractor, "contractormaster");

            objRL.Fill_Approval_Status(cmbStatus);
            //Fill_Status();

            if (cbSelectAllStatus.Checked)
                cmbStatus.Enabled = false;
            else
                cmbStatus.Enabled = true;

            if (objPC.ReportForm == "Leave Report")
            {
                objRL.Fill_LeaveType(cmbLeaveType, true);
                cbRevertLeave.Visible = true;
                cbSelectAllLeaveType.Checked = true;
                cbSelectAllLeaveType.Enabled = true;
                lblHeader.Text = BusinessResources.REPORT_LEAVEREPORT;
            }
            else
            {
                objRL.Fill_LeaveType(cmbLeaveType, false);
                cbRevertLeave.Visible = false;
                cbSelectAllLeaveType.Checked = false;
                cbSelectAllLeaveType.Enabled = false;
                lblHeader.Text = BusinessResources.REPORT_COMPOFF;
            }
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

        private void ClearAll()
        {
            objEP.Clear();
            cbToday.Checked = true;
            cbEmployee.Checked = true;
            cbSelectAllLeaveType.Checked = true;
            cbRevertLeave.Checked = false;
            cbSelectAllContractor.Checked = true;
            cbSelectAllStatus.Checked = true;

            ClearEmployee();
            cmbLocation.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            cmbLeaveType.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
            cmbContractor.SelectedIndex = -1;
            
            //cbToday.Checked = true;
        }

        private void LeaveDashboardReport_Load(object sender, EventArgs e)
        {
            //ClearAll();
        }

        private void cbEmployee_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEmployee.Checked)
            {
                gbEmployee.Enabled = true;
                cbSelectAllEmployee.Checked = true;
                gbLocationDepartment.Visible = true;
            }
            else
            {
                cbSelectAllEmployee.Checked = false;
                ClearEmployee();
            }
        }

        int EmployeeId = 0;
        private void ClearEmployee()
        {
            EmployeeId = 0;
            txtSearchEmployeeCode.Text = "";
            // txtSearchEmployeeName.Text = "";
            lbEmployee.DataSource = null;
            rtbEmployeeDetails.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();

            //string TypeA = cmbLeaveType.Text;
            //switch (TypeA)
            //{
            //    case "Banana":
            //        Patra_Dance();
            //        break;
            //    case "Chair":
            //        Patra_Dance();
            //        break;
            //    case "Compensation Off":
            //        goto case "Banana";
            //    case "Table":
            //        goto case "Chair";
            //    default:
            //        MessageBox.Show("Select valid option");
            //        break;
            //}


            //if (cmbLeaveType.Text == "Compensation Off")
            //{
               
            //}
            //else
            //{

            //}

            //string Fruit = "Apple";
            //switch (Fruit)
            //{
            //    case "Banana":
            //        MessageBox.Show(Fruit + " is the delecious fruit");
            //        break;
            //    case "Chair":
            //        MessageBox.Show(Fruit + " is the delecious fruit");
            //        break;
            //    case "Apple":
            //        goto case "Banana";
            //    case "Table":
            //        goto case "Chair";
            //    default:
            //        MessageBox.Show("Select valid option");
            //        break;
            //}


            


        }


        private void Patra_Dance()
        {
            MessageBox.Show("Patra doing Nagin Dance");
        }

        private void cbSelectAllStatus_CheckedChanged(object sender, EventArgs e)
        {
            cmbStatus.SelectedIndex = -1;

            if (cbSelectAllStatus.Checked)
                cmbStatus.Enabled = false;
            else
                cmbStatus.Enabled = true;
        }

        private void cmbLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_Department();
        }

        private void Fill_Department()
        {
            if (cmbLocation.SelectedIndex > -1)
                objPC.LocationId = Convert.ToInt32(cmbLocation.SelectedValue);

            objRL.Fill_Department_ComboBox_By_Location(cmbDepartment, Convert.ToInt32(cmbLocation.SelectedValue));
        }

        private void txtSearchEmployeeName_TextChanged(object sender, EventArgs e)
        {
            if (cbEmployee.Checked)
            {
                ClearEmployee();

                if (txtSearchEmployeeName.Text != "")
                    objQL.Fill_Employee_ListBox(lbEmployee, txtSearchEmployeeName.Text, "Text");
                else
                    objQL.Fill_Employee_ListBox(lbEmployee, txtSearchEmployeeName.Text, "All");
            }
            else
                gbEmployee.Enabled = false;
        }

        private void txtSearchEmployeeCode_TextChanged(object sender, EventArgs e)
        {
            if (cbEmployee.Checked)
            {
                ClearEmployee();

                if (txtSearchEmployeeCode.Text != "")
                    objQL.Fill_Employee_ListBox(lbEmployee, txtSearchEmployeeName.Text, "Text");
                else
                    objQL.Fill_Employee_ListBox(lbEmployee, txtSearchEmployeeName.Text, "All");
            }
            else
                gbEmployee.Enabled = false;
        }

        private void txtSearchEmployeeCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.NumericValue(sender, e, txtSearchEmployeeCode);
        }

        private void lbEmployee_Click(object sender, EventArgs e)
        {
            Get_Employee();
        }

        private void lbEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Get_Employee();
        }

        private void Get_Employee()
        {
            if (lbEmployee.SelectedIndex > -1)
            {
                rtbEmployeeDetails.Text = "";
                EmployeeId = Convert.ToInt32(lbEmployee.SelectedValue.ToString());
                Fill_Employee_Information();
                cmbLocation.Text = objPC.Location;
                objRL.Fill_Department_ComboBox_By_Location(cmbDepartment, objPC.LocationId);
                cmbDepartment.Text = objPC.DepartmentName;
                gbLocationDepartment.Visible = true;
                //gbLocationDepartment
            }
        }

        private void Fill_Employee_Information()
        {
            if (EmployeeId > 0)
            {
                objQL.Fill_Employee_RichTextBox(rtbEmployeeDetails, EmployeeId);
                lbEmployee.Visible = false;
                rtbEmployeeDetails.Visible = true;
                //cbToday.Focus();
            }
            else
            {
                rtbEmployeeDetails.Text = "";
                rtbEmployeeDetails.Visible = true;
            }
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
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

        private bool Validation()
        {
            bool FlagReturn = false;
            objEP.Clear();

            if (!cbEmployee.Checked)
            {
                if (!cbSelectAllEmployee.Checked)
                {
                    if (EmployeeId == 0)
                    {
                        txtSearchEmployeeName.Focus();
                        objEP.SetError(txtSearchEmployeeName, "Select Employee");
                        FlagReturn = true;
                    }
                }
                else
                    FlagReturn = false;
            }
            else
                FlagReturn = false;

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

        string ColumnNames_BR = string.Empty, TableNames_BR = string.Empty, WhereClause_BR = string.Empty, WhereClause = string.Empty, OrderBy=string.Empty;
        string DateColumn = string.Empty, EmployeeIn = string.Empty, LeaveStatusIn = string.Empty, ContractorIn = string.Empty, StatusIn = string.Empty, DepartmentIn = string.Empty, LocationIdS = string.Empty, CompOffClause = string.Empty;

        private void GetReport()
        {
            //Report Query
            DataSet ds = new DataSet();

            ColumnNames_BR = string.Empty; TableNames_BR = string.Empty; WhereClause_BR = string.Empty; WhereClause = string.Empty; OrderBy = string.Empty;
            DateColumn = string.Empty; EmployeeIn = string.Empty; ContractorIn = string.Empty; StatusIn = string.Empty; DepartmentIn = string.Empty; LocationIdS = string.Empty; CompOffClause = string.Empty; LeaveStatusIn = string.Empty;

            //Where Clauses All
            DateColumn = " LA.FromDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' ";

            if (EmployeeId != 0)
                //EmployeeIn = " and LA.EmployeeId=" + EmployeeId + " ";
                EmployeeIn = " and E.EmployeeCode=" + EmployeeId + " ";

            if(cmbLocation.SelectedIndex >-1)
                LocationIdS = " and E.LocationId=" + cmbLocation.SelectedValue + " ";

            if (cmbLocation.SelectedIndex > -1)
                DepartmentIn = " and E.DepartmentId=" + cmbDepartment.SelectedValue + " ";

            if (!cbSelectAllContractor.Checked)
            {
                if(cmbContractor.SelectedIndex >-1)
                    ContractorIn = " and E.ContractorId=" + cmbContractor.SelectedValue + " ";
            }

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

            ColumnNames_BR = BusinessResources.LeaveApplication_Column;
            TableNames_BR = BusinessResources.LeaveApplication_Table;
            WhereClause_BR = BusinessResources.LeaveApplication_Where;
            OrderBy = " order by LA.EntryDate asc ";

            // DateColumn = " monthname(LA.EntryDate)='" + cmbMonth.Text + "' and YEAR(LA.EntryDate)='" + cmbYear.Text + "' ";

            WhereClause = " where " + DateColumn + EmployeeIn + LocationIdS + DepartmentIn + ContractorIn + StatusIn + LeaveStatusIn+ " ";

            WhereClause = WhereClause + " and " + WhereClause_BR;
            objQL.ColumnNames_Report = ColumnNames_BR;
            objQL.TableNames_Report = TableNames_BR;
            objQL.WhereClause_V = WhereClause;
            objQL.OrderBy_V = OrderBy;
            objQL.GroupBy_V = "";
            ds = objQL.SP_Attendance_Report_Query();

            if (ds.Tables[0].Rows.Count > 0)
            {
                string ReportPeriod = "From Date-" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATDDMMMYYYY) + " To Date-" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATDDMMMYYYY);
                objQL.ReportPeriod = ReportPeriod;
                string ReportName = BusinessResources.REPORT_LEAVEREPORT;
                ViewReportW objForm = new ViewReportW(ds, ReportName);
                objForm.Show();
            }
            else
            {
                objRL.ShowMessage(35, 4);
                return;
            }
        }

        private void GetReport_CompOff()
        {
            //Report Query
            DataSet ds = new DataSet();

            ColumnNames_BR = string.Empty; TableNames_BR = string.Empty; WhereClause_BR = string.Empty; WhereClause = string.Empty; OrderBy = string.Empty;
            DateColumn = string.Empty; EmployeeIn = string.Empty; ContractorIn = string.Empty; StatusIn = string.Empty; DepartmentIn = string.Empty; LocationIdS = string.Empty; CompOffClause = string.Empty; LeaveStatusIn = string.Empty;

            //Where Clauses All
            DateColumn = " and COA.CompOffDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' ";

            if (EmployeeId != 0)
                //EmployeeIn = " and LA.EmployeeId=" + EmployeeId + " ";
                EmployeeIn = " and E.EmployeeCode=" + EmployeeId + " ";

            if (cmbLocation.SelectedIndex > -1)
                LocationIdS = " and E.LocationId=" + cmbLocation.SelectedValue + " ";

            if (cmbLocation.SelectedIndex > -1)
                DepartmentIn = " and E.DepartmentId=" + cmbDepartment.SelectedValue + " ";

            if (!cbSelectAllContractor.Checked)
            {
                if (cmbContractor.SelectedIndex > -1)
                    ContractorIn = " and E.ContractorId=" + cmbContractor.SelectedValue + " ";
            }

            if (!cbSelectAllLeaveType.Checked)
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
                            //CompOffClause = " and COA.CompStatus='" + BusinessResources.LS_Completed + "' ";
                        }
                    }
                }
            }

            if (!cbSelectAllStatus.Checked)
            {
                if (cmbStatus.SelectedIndex > -1)
                {
                        if (cmbLeaveType.Text == "Compensation Off")
                            StatusIn = " and COA.CompStatus='" + cmbStatus.Text + "' ";
                }
                else
                {

                }
            }

            //ColumnNames_BR = BusinessResources.LeaveApplication_Column;
            //TableNames_BR = BusinessResources.LeaveApplication_Table;
            //WhereClause_BR = BusinessResources.LeaveApplication_Where;
            OrderBy = " order by COA.EntryDate asc ";

            // DateColumn = " monthname(LA.EntryDate)='" + cmbMonth.Text + "' and YEAR(LA.EntryDate)='" + cmbYear.Text + "' ";

            WhereClause = DateColumn + EmployeeIn + LocationIdS + DepartmentIn + ContractorIn + StatusIn + LeaveStatusIn + " ";

            objBL.Query = BusinessResources.CompOffQueryReport + WhereClause + OrderBy;
            ds = objBL.ReturnDataSet(); 

            //WhereClause = WhereClause + " and " + WhereClause_BR;
            //objQL.ColumnNames_Report = ColumnNames_BR;
            //objQL.TableNames_Report = TableNames_BR;
            //objQL.WhereClause_V = WhereClause;
            //objQL.OrderBy_V = OrderBy;
            //objQL.GroupBy_V = "";
            //ds = objQL.SP_Attendance_Report_Query();

            if (ds.Tables[0].Rows.Count > 0)
            {
                string ReportName = string.Empty;
                string ReportPeriod = "From Date-" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATDDMMMYYYY) + " To Date-" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATDDMMMYYYY);
                objQL.ReportPeriod = ReportPeriod;

                if(objPC.ReportForm =="Leave Report")
                     ReportName = BusinessResources.REPORT_LEAVEREPORT;
                else
                    ReportName = BusinessResources.REPORT_COMPOFF;

                ViewReportW objForm = new ViewReportW(ds, ReportName);
                objForm.Show();
            }
            else
            {
                objRL.ShowMessage(35, 4);
                return;
            }
        }

        private void cbSelectAllLeaveType_CheckedChanged(object sender, EventArgs e)
        {
            cmbLeaveType.SelectedIndex = -1;

            if (cbSelectAllLeaveType.Checked)
                cmbLeaveType.Enabled = false;
            else
                cmbLeaveType.Enabled = true;
        }

        private void cbSelectAllContractor_CheckedChanged(object sender, EventArgs e)
        {
            cmbContractor.SelectedIndex = -1;

            if (cbSelectAllContractor.Checked)
                cmbContractor.Enabled = false;
            else
                cmbContractor.Enabled = true;
        }
    }
}
