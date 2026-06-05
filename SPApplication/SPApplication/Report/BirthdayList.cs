using BusinessLayerUtility;
using SPApplication.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SPApplication.Report
{
    

    public partial class BirthdayList : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();
        AttendanceLogics objAL = new AttendanceLogics();

        public BirthdayList()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnView, btnClear, btnReport, btnExit, "Birthday List");
            btnView.Text = BusinessResources.BTN_VIEW;
            btnReport.Text = BusinessResources.BTN_REPORT;
            objRL.FillLocation(cmbLocation, cmbDepartment);
            ClearAll();
        }
        private void ClearAll()
        {
            dataGridView1.Rows.Clear();
            cbSelectAllLocation.Checked = true;
            cbSelectAllDepartment.Checked = true;
            dtpSearchDate.Value = DateTime.Now.Date;
            cmbLocation.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            cmbMonth.SelectedIndex = -1;
            cmbYear.SelectedIndex = -1;
            cbDateWise.Checked = true;
            SetMonthYear();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (!Validation())
            {
                GetReport();
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
        private void BirthdayList_Load(object sender, EventArgs e)
        {
            cbDateWise.Checked = true;
            SetMonthYear();
            GetReport();
        }
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

        private void SetMonthYear()
        {
            string MonthName = objRL.GetMonthName(DateTime.Now.Date.Month);
            int YearNo = DateTime.Now.Year;

            cmbYear.Text = YearNo.ToString();
            cmbMonth.Text = MonthName.ToString();
        }

        private void cmbLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbLocation.SelectedIndex > -1)
                objRL.FillDepartment(cmbLocation, cmbDepartment);
        }

        private bool Validation()
        {
            bool FlagReturn = false;
            objEP.Clear();

            if (!cbSelectAllLocation.Checked)
            {
                if (cmbLocation.SelectedIndex == -1)
                {
                    cmbLocation.Focus();
                    objEP.SetError(cmbLocation, "Select Location");
                    FlagReturn = true;
                }
                else
                    FlagReturn = false;
            }

            if (!FlagReturn)
            {
                if (!cbSelectAllDepartment.Checked)
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
                else
                    FlagReturn = false;
            }
            if (!FlagReturn)
            {

                if (cmbMonth.SelectedIndex == -1)
                {
                    cmbMonth.Focus();
                    objEP.SetError(cmbMonth, "Select Month");
                    FlagReturn = true;
                }
                else if (cmbYear.SelectedIndex == -1)
                {
                    cmbYear.Focus();
                    objEP.SetError(cmbYear, "Select Year");
                    FlagReturn = true;
                }
                else
                    FlagReturn = false;
            }
            return FlagReturn;
        }

        string MainQuery = string.Empty, ColumnNames_BR = string.Empty, TableNames_BR = string.Empty, WhereClause_BR = string.Empty, WhereClause = string.Empty, OrderBy = string.Empty;

        private void cbDateWise_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDateWise.Checked)
            {
                dtpSearchDate.Visible = true;
                dtpSearchDate.Value = DateTime.Now.Date;
                gbMonth.Visible = false;
            }
            else
            {
                dtpSearchDate.Visible = false;
                gbMonth.Visible = true;
                SetMonthYear();
                GetReport();
            }
        }
        int SrNo = 1;

        private void cmbMonth_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbMonth.SelectedIndex == -1) {
                GetReport();
            }
        }

        private void SrNo_Function()
        {
            SrNo = 1;

            if (dataGridView1.Rows.Count > 0) {
                for (int i = 0; i < dataGridView1.Rows.Count; i++) {
                    dataGridView1.Rows[i].Cells["clmSrNo"].Value = SrNo.ToString();
                    SrNo++;
                }
            }
        }
        string DateColumn = string.Empty, EmployeeIn = string.Empty, LeaveStatusIn = string.Empty, ContractorIn = string.Empty, StatusIn = string.Empty, DepartmentIn = string.Empty;
            int EmployeeId = 0;
        private void GetReport()
        {
            dataGridView1.Rows.Clear();
            MainQuery = string.Empty;WhereClause=string.Empty;

            DataSet ds = new DataSet();
            MainQuery = "select "+
                         "E.EmployeeId, " +
                         "E.DOB," +
                         "E.EmployeeCode," +
                         "E.EmpInital," +
                         "E.EmployeeName, " +
                         "CONCAT(E.EmpInital, ' ', E.EmployeeName) AS EmployeeConcat, " +
                         "E.Gender, " +
                         "E.Age, " +
                         "E.MobileNo, " +
                         "LM.LocationName," +
                         "DM.Department," +
                         "DESM.Designation," +
                         "E.JobProfile, " +
                         "CM.ContractorName," +
                         "E.PersonalEmailID,   " +
                         "E.DOJ, " +
                         "ETM.EmployementType" +
                    " from " +
                        "Employees E inner join " +
                        "contractormaster CM on CM.ContractorId=E.ContractorId inner join " +
                        "employementtypemaster ETM on ETM.EmployementTypeId=E.EmployementTypeId inner join " +
                        "departmentmaster DM on DM.DepartmentId=E.DepartmentId inner join " +
                        "designationmaster DESM on DESM.DesignationId=E.DesignationId inner join " +
                        "categories CT on CT.CategoryId=E.CategoryId inner join " +
                        "locationmaster LM on LM.LocationId=E.LocationId  " +
                    " where " +
                        "E.CancelTag=0 and " +
                        "CM.CancelTag=0 and " +
                        "ETM.CancelTag=0 and " +
                        "DM.CancelTag=0 and " +
                        "DESM.CancelTag=0 and " +
                        "CT.CancelTag=0 and " +
                        "LM.CancelTag=0 and E.Status='WORKING' ";
             
            if (!cbSelectAllLocation.Checked)
                WhereClause += " and E.LocationId=" + cmbLocation.SelectedValue + "";
            //else
            //    WhereClause += " and " + objQL.Get_Location_Id("Location") + " ";

            if (!cbSelectAllDepartment.Checked)
                WhereClause += " and E.DepartmentId=" + cmbDepartment.SelectedValue + "";
            //else
            //    WhereClause += " and " + objQL.Get_Location_Id("Department");

            if (cbDateWise.Checked)
                WhereClause += " and DAY(E.DOB)=DAY('" + dtpSearchDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "') and MONTH(E.DOB)=MONTH('" + dtpSearchDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "')"  ; // and Month(E.DOB)=" + dtpSearchDate.Value.Month + ""; //.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'"; // E.DOB='" + dtpSearchDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' ";
            else
                WhereClause += " and Month(E.DOB)=" + objRL.GetMonthNumber(cmbMonth.Text); // and Year(E.DOB)=" + cmbYear.Text + "";


            OrderBy = " ORDER BY DAY(E.DOB) asc";
            //OrderBy = " order by E.DOB ";
            
            objBL.Query = MainQuery + WhereClause + OrderBy;
            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTotalCount.Text = "Total Count-" + ds.Tables[0].Rows.Count.ToString();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();

                    //dataGridView1.Rows[i].Cells["clmSrNo"].Value = SrNo.ToString();
                    EmployeeId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmployeeId"])));
                    dataGridView1.Rows[i].Cells["clmEmployeeId"].Value = EmployeeId; // objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmployeeCode"])));
                    DateTime dtDob = Convert.ToDateTime(ds.Tables[0].Rows[i]["DOB"]);
                    dataGridView1.Rows[i].Cells["clmDOB"].Value = dtDob.ToString(BusinessResources.DATEFORMATDDMMMYYYY);
                    dataGridView1.Rows[i].Cells["clmEmployeeCode"].Value = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmployeeCode"])));
                    dataGridView1.Rows[i].Cells["clmEmpInital"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmpInital"]));
                    dataGridView1.Rows[i].Cells["clmEmployeeName"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmployeeName"]));
                    dataGridView1.Rows[i].Cells["clmEmployeeConcat"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmployeeConcat"]));
                    dataGridView1.Rows[i].Cells["clmGender"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["Gender"]));
                    dataGridView1.Rows[i].Cells["clmAge"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["Age"]));
                    dataGridView1.Rows[i].Cells["clmMobileNo"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["MobileNo"]));
                    dataGridView1.Rows[i].Cells["clmLocation"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["LocationName"]));
                    dataGridView1.Rows[i].Cells["clmDepartment"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["Department"]));
                    dataGridView1.Rows[i].Cells["clmDesignation"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["Designation"]));
                    dataGridView1.Rows[i].Cells["clmJobProfile"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["JobProfile"]));
                    dataGridView1.Rows[i].Cells["clmRoll"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["ContractorName"]));
                    dataGridView1.Rows[i].Cells["clmPersonalEmailID"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["PersonalEmailID"]));
                    dataGridView1.Rows[i].Cells["clmDOJ"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["DOJ"]));
                    dataGridView1.Rows[i].Cells["clmEmployementType"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmployementType"]));
                    // dataGridView1.Sort(dataGridView1.Columns["clmDOB"], System.ComponentModel.ListSortDirection.Ascending);
                    //SrNo++;
                    dataGridView1.ClearSelection();
                }
                SrNo_Function();
                

                foreach (DataGridViewRow Myrow in dataGridView1.Rows)
                {
                     
                    //Here 2 cell is target value and 1 cell is Volume
                    if (!string.IsNullOrEmpty(Convert.ToString(Myrow.Cells["clmDOB"].Value)))
                        //DateTime dtDob = Convert.ToDateTime(ds.Tables[0].Rows[i]["clmDOB"]);
                        dtDob1 = Convert.ToDateTime(Myrow.Cells["clmDOB"].Value);

                    if (dtDob1.Date.Day  == DateTime.Now.Date.Date.Day)
                    {
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Completed_Color);
                    }
                }
            }
            else
            {
                //objRL.ShowMessage(35, 4);
                //return;
            }
        }
        DateTime dtDob1;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0;


    }
}
