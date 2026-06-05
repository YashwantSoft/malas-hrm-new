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
    public partial class CompOffDetailsReport : Form
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

        public CompOffDetailsReport()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnReport, btnClear, btnView, btnExit, "Comp Off Details Report");
            btnReport.Text = BusinessResources.BTN_VIEW;
            objRL.FillLocation(cmbLocation, cmbDepartment);
            ClearAll();

            
        }

        private void ClearAll()
        {
            objEP.Clear();
            cmbLocation.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
             
            cmbLocation.Focus();
        }

        private void CompOffSummaryReport_Load(object sender, EventArgs e)
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
                //if (objPC.ReportForm == "Leave Report")
                //    GetReport();
                //else
                    GetReport_CompOff();
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void cmbLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbLocation.SelectedIndex > -1)
            {
                objPC.LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
                objRL.FillDepartment(cmbLocation, cmbDepartment);
            }
        }

        private bool Validation()
        {
            bool FlagReturn = false;
            objEP.Clear();

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

            
            return FlagReturn;
        }

        string MainQuery = string.Empty, ColumnNames_BR = string.Empty, TableNames_BR = string.Empty, WhereClause_BR = string.Empty, WhereClause = string.Empty, OrderBy = string.Empty;
        string DateColumn = string.Empty, EmployeeIn = string.Empty, LeaveStatusIn = string.Empty, ContractorIn = string.Empty, StatusIn = string.Empty, DepartmentIn = string.Empty, LocationIdS = string.Empty;

        int Pending_Count = 0, ManagerApproved_Count = 0, HRApproved_Count = 0, Remarks_Count = 0, Reject_Count = 0, Completed_Count = 0;

        private void GetReport_CompOff()
        {
             MainQuery = "select " +
                        "LM.LocationName as 'Location'," +
                        "DM.Department, " +
                        "E.EmployeeId," +
                        "E.EmployeeCode as 'Emp Code'," +
                        "E.EmployeeName as 'Employee Name'," +
                        "DES.Designation," +
                        "E.CompOff as 'Comp Off'," +
                        "E.CompOffUsed as 'Comp Off Used'," +
                        "E.CompOffExpired as 'Comp Off Expired'," +
                        "E.CompOffBalance as 'Comp Off Balance' " +
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

            if (cmbLocation.SelectedIndex > -1)
                LocationIdS = " and E.LocationId=" + cmbLocation.SelectedValue + " ";

            
            if (cmbLocation.SelectedIndex > -1)
                DepartmentIn = " and E.DepartmentId=" + cmbDepartment.SelectedValue + " ";

            //if (!cbSelectAllLeaveType.Checked)
            //{
            //    if (cmbLeaveType.SelectedIndex > -1)
            //        LeaveStatusIn = " and LA.LeaveTypeId=" + cmbLeaveType.SelectedValue + " ";
            //}


            //ColumnNames_BR = BusinessResources.LeaveApplication_Column;
            //TableNames_BR = BusinessResources.LeaveApplication_Table;
            //WhereClause_BR = BusinessResources.LeaveApplication_Where;
            OrderBy = " order by E.EmployeeName asc ";
             
            WhereClause =  DateColumn + EmployeeIn + LocationIdS + DepartmentIn + ContractorIn + StatusIn + LeaveStatusIn + " ";

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
               // dataGridView1.Columns[10].Width = 90;
            }
            else
            {
                objRL.ShowMessage(35, 4);
                return;
            }
        }
    }
}
