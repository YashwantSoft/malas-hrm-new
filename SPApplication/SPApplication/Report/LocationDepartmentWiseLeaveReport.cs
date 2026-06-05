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
    public partial class LocationDepartmentWiseLeaveReport : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();
         
        string EmpDesignation = string.Empty;
        string EmpDepartment = string.Empty;

        int SearchId = 0, LocationId = 0;

        public LocationDepartmentWiseLeaveReport()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnReport, btnClear, btnView, btnExit, BusinessResources.LBL_HEADER_USERLEAVEREPORT);
            btnReport.Text = BusinessResources.BTN_VIEW;
            //objRL.FillLocation(cmbLocation, cmbDepartment);
            objRL.FillLocation(cmbLocation, cmbDepartment);
            ClearAll();
              
            if (objPC.ReportForm == "Leave Report")
            {
                cmbLeaveType.Visible = false;
                lblLeaveType.Visible = false;
               // lblLeaveType.Text = "Leave Type";
                objRL.Fill_LeaveType(cmbLeaveType, true);
                 
                cbSelectAllLeaveType.Checked = true;
                cbSelectAllLeaveType.Enabled = true;
                lblHeader.Text = BusinessResources.LBL_HEADER_LOCATIONDEPARTMENTWISELEAVEREPORT;
            }
            else
            {
                cmbLeaveType.Visible = true;
                lblLeaveType.Visible = true;
                lblLeaveType.Text = "Select Comp Off Type";
                objRL.Fill_LeaveType(cmbLeaveType, false);
                cbSelectAllLeaveType.Checked = false;
                cbSelectAllLeaveType.Enabled = false;
                lblHeader.Text = BusinessResources.LBL_HEADER_LOCATIONDEPARTMENTWISECOMPOFFEREPORT;
            }
        }

        private void ClearAll()
        {
            objEP.Clear();
            cmbLocation.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            cmbLeaveType.SelectedIndex = -1;
            cbSelectAllLeaveType.Checked = true;
            cbSelectAllLocation.Checked = true;
            cbSelectAllDepartment.Checked = true;
            cmbLocation.Focus();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void LocationDepartmentWiseLeaveReport_Load(object sender, EventArgs e)
        {

        }

        private void cmbDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void cmbLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbLocation.SelectedIndex > -1)
            {
                objPC.LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
                objRL.FillDepartment(cmbLocation, cmbDepartment);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {

        }

        private bool Validation()
        {
            bool FlagReturn = false;
            objEP.Clear();
             
            if (!FlagReturn)
            {
                if (!cbSelectAllLocation.Checked &&  cmbLocation.SelectedIndex == -1)
                {
                    cmbLocation.Focus();
                    objEP.SetError(cmbLocation, "Select Location");
                    FlagReturn = true;
                }
                else if (!cbSelectAllDepartment.Checked && cmbDepartment.SelectedIndex == -1)
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
                    if (objPC.ReportForm != "Leave Report")
                    {
                        if (cmbLeaveType.SelectedIndex == -1)
                        {
                            cmbLeaveType.Focus();
                            objEP.SetError(cmbLeaveType, "Select Leave Type");
                            FlagReturn = true;
                        }
                        else
                            FlagReturn = false;
                    }
                    else
                        FlagReturn = false;
                }
                else
                    FlagReturn = false;
            }
            return FlagReturn;
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

        string MainQuery =string.Empty,ColumnNames_BR = string.Empty, TableNames_BR = string.Empty, WhereClause_BR = string.Empty, WhereClause = string.Empty, OrderBy = string.Empty;

        private void cbSelectAllLocation_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSelectAllLocation.Checked)
            {
                cmbLocation.SelectedIndex = -1;
                cmbLocation.Enabled = false;
            }
            else
            {
                cmbLocation.SelectedIndex = -1;
                cmbLocation.Enabled = true;
            }
        }

        private void cbSelectAllDepartment_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSelectAllDepartment.Checked)
            {
                cmbDepartment.SelectedIndex = -1;
                cmbDepartment.Enabled = false;
            }
            else
            {
                cmbDepartment.SelectedIndex = -1;
                cmbDepartment.Enabled = true;
            }
        }

        string DateColumn = string.Empty, EmployeeIn = string.Empty, LeaveStatusIn = string.Empty, ContractorIn = string.Empty, StatusIn = string.Empty, DepartmentIn = string.Empty, LocationIdS = string.Empty;

        int Pending_Count = 0, ManagerApproved_Count = 0, HRApproved_Count = 0, Remarks_Count = 0, Reject_Count = 0, Completed_Count = 0;

        private void GetReport()
        {
            MainQuery = "select " +
                        "LM.LocationName as 'Location'," +
                        "DM.Department, " +
                        "E.EmployeeId," +
                        "E.EmployeeCode as 'Emp Code'," +
                        "E.EmployeeName as 'Employee Name'," +
                        "DES.Designation," +
                        "E.OpeningLeave as 'Opening'," +
                        "E.CurrentLeave as 'Current'," +
                        "E.TotalApplicableLeave as 'Applicable'," +
                        "E.EnjoyLeave as 'Enjoy'," +
                        "E.BalanceLeave as 'Balance'" +
                        " from " +
                        "Employees E inner join  " +
                        "DepartmentMaster DM on DM.DepartmentId=E.DepartmentId inner join " +
                        "DesignationMaster DES on DES.DesignationId=E.DesignationId inner join " +
                        "LocationMaster LM on LM.LocationId=E.LocationId "+
                        " where E.CancelTag=0 and DM.CancelTag=0 and DES.CancelTag=0 and LM.CancelTag=0 ";
             
            //Report Query
            DataSet ds = new DataSet();

            ColumnNames_BR = string.Empty; TableNames_BR = string.Empty; WhereClause_BR = string.Empty; WhereClause = string.Empty; OrderBy = string.Empty;
            DateColumn = string.Empty; EmployeeIn = string.Empty; ContractorIn = string.Empty; StatusIn = string.Empty; DepartmentIn = string.Empty; LocationIdS = string.Empty;

            //Where Clauses All
            //DateColumn = " LA.FromDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' ";

            //if (cmbLocation.SelectedIndex > -1)
            //    LocationIdS = " and E.LocationId=" + cmbLocation.SelectedValue + " ";

            
            //if (cmbLocation.SelectedIndex > -1)
            //    DepartmentIn = " and E.DepartmentId=" + cmbDepartment.SelectedValue + " ";


            if (!cbSelectAllLocation.Checked)
                WhereClause += " and E.LocationId=" + cmbLocation.SelectedValue + "";
            //else
            //    WhereClause += " and " + objQL.Get_Location_Id("Location") + " ";

            if (!cbSelectAllDepartment.Checked)
                WhereClause += " and E.DepartmentId=" + cmbDepartment.SelectedValue + "";


            //if (!cbSelectAllLeaveType.Checked)
            //{
            //    if (cmbLeaveType.SelectedIndex > -1)
            //        LeaveStatusIn = " and LA.LeaveTypeId=" + cmbLeaveType.SelectedValue + " ";
            //}


            //ColumnNames_BR = BusinessResources.LeaveApplication_Column;
            //TableNames_BR = BusinessResources.LeaveApplication_Table;
            //WhereClause_BR = BusinessResources.LeaveApplication_Where;
            OrderBy = " order by E.EmployeeName asc ";
             
            WhereClause +=  DateColumn + EmployeeIn + LocationIdS + DepartmentIn + ContractorIn + StatusIn + LeaveStatusIn + " ";

            //WhereClause = WhereClause + " and E.CancelTag=0 and DM.CancelTag=0 and DES.CancelTag=0 and LM.CancelTag=0 ";
            //objQL.ColumnNames_Report = ColumnNames_BR;
            //objQL.TableNames_Report = TableNames_BR;
            //objQL.WhereClause_V = WhereClause;
            //objQL.OrderBy_V = OrderBy;
            //objQL.GroupBy_V = "";
            //ds = objQL.SP_Attendance_Report_Query();

            objBL.Query = MainQuery + WhereClause;
            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTotalCount.Text = "Total-" + ds.Tables[0].Rows.Count;

                //0 "LM.LocationName as 'Location'," +
                //1 "DM.Department, " +
                //2 "E.EmployeeId," +
                //3 "E.EmployeeCode as 'Emp Code'," +
                //4 "E.EmployeeName as 'Employee Name'," +
                //5 "DES.Designation," +
                //6 "E.OpeningLeave as 'Opening'," +
                //7 "E.CurrentLeave as 'Current'," +
                //8 "E.TotalApplicableLeave as 'Applicable'," +
                //9 "E.EnjoyLeave as 'Enjoy'," +
                //10 "E.BalanceLeave as 'Balance'" +

                dataGridView1.DataSource = ds.Tables[0];
               // dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                //dataGridView1.Columns[5].Visible = false;
                //// dataGridView1.Columns[10].Visible = false;
                ////dataGridView1.Columns[18].Visible = false;
                //dataGridView1.Columns[19].Visible = false;
                //dataGridView1.Columns[22].Visible = false;
                //dataGridView1.Columns[21].Visible = false;

                //dataGridView1.Columns[15].Visible = false;
                //dataGridView1.Columns[16].Visible = false;
                //dataGridView1.Columns[17].Visible = false;

                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[3].Width = 90;
                dataGridView1.Columns[4].Width = 200;
                dataGridView1.Columns[5].Width = 150;
                dataGridView1.Columns[6].Width = 90;
                dataGridView1.Columns[7].Width = 90;
                dataGridView1.Columns[8].Width = 90;
                dataGridView1.Columns[9].Width = 90;
                dataGridView1.Columns[10].Width = 90;
                  
            }
            else
            {
                objRL.ShowMessage(35, 4);
                return;
            }
        }


        private void GetReport_CompOff()
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
           // DateColumn = " and COA.CompOffDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' ";

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
                                CompOffClause = " and COA.CompOffUsedFlag=1 and COA.ExpiredFlag=0 and COA.CompUsedStatus='" + BusinessResources.LS_Completed + "' ";
                            else
                            {
                                LeaveStatusIn = " and COA.LeaveTypeId=" + cmbLeaveType.SelectedValue + " ";
                                CompOffClause = " and COA.CompStatus='" + BusinessResources.LS_Completed + "' ";
                            }
                        }
                    }
                }
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

                 
                dataGridView1.ClearSelection();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void cbSelectAllLeaveType_CheckedChanged(object sender, EventArgs e)
        {
            cmbLeaveType.SelectedIndex = -1;

            if (cbSelectAllLeaveType.Checked)
                cmbLeaveType.Enabled = false;
            else
                cmbLeaveType.Enabled = true;
        }
    }
}
