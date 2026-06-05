using BusinessLayerUtility;
using SPApplication.HR;
using SPApplication.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPApplication.NewSoftware.Reports
{
    public partial class EmployeeReport : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        int LatePunch = 0, EarlyGoing = 0;
        string EmpDesignation = string.Empty;
        string EmpDepartment = string.Empty;
        string ConcatTotal = string.Empty;
        string RollTotal = string.Empty;

        string MainQuery = string.Empty, WhereClause = string.Empty, OrderByClause = string.Empty;
        bool ApproveFlag = false;

        DateTime dtIn, dtOut;
        double Duration = 0, OverTime = 0, TotalDuration = 0, LateBy = 0, EarlyBy = 0;

        TimeSpan totalOT = TimeSpan.Zero;

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void lbEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetEmployeeDetails();
            }
        }

        private void lbEmployee_Click(object sender, EventArgs e)
        {
            GetEmployeeDetails();
        }

        private void GetEmployeeDetails()
        {
            rtbEmployee.Text = "";

            //if (EmployeeId == 0)
            //{
            if (lbEmployee.SelectedIndex > -1)
            {
                EmployeeId = 0;
                EmployeeId = Convert.ToInt32(lbEmployee.SelectedValue);
                objRL.Fill_Employee_Details_RichTextBox(rtbEmployee, EmployeeId);
                lbEmployee.Visible = false;
                cbStatus.Focus();
            }
            //}
            //else if (EmployeeId != 0)
            //{
            //    objRL.Fill_Employee_Details_RichTextBox(rtbEmployee, EmployeeId);
            //}
            //else if (BusinessLayer.Department != "Time Office" && EmployeeId != 0)
            //{
            //    objRL.Fill_Employee_Details_RichTextBox(rtbEmployee, EmployeeId);
            //    lbEmployee.Visible = false;
            //}
            else
            {
                EmployeeId = 0;
                rtbEmployee.Text = "";
                rtbEmployee.Visible = true;
                lbEmployee.Visible = true;
            }

            //Get_Leaves();
        }

        private void cbLocation_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLocation.Checked)
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

        private void cbDepartment_CheckedChanged(object sender, EventArgs e)
        {
            cmbDepartment.DataSource = null;
            if (cbDepartment.Checked)
            {
                cmbDepartment.SelectedIndex = -1;
                cmbDepartment.Enabled = false;
            }
            else
            {
                if (cmbLocation.SelectedIndex > -1)
                {

                    cmbDepartment.SelectedIndex = -1;
                    cmbDepartment.Enabled = true;
                    objRL.FillDepartment(cmbLocation, cmbDepartment);
                }
            }
        }

        private void cbContractor_CheckedChanged(object sender, EventArgs e)
        {
            if (cbContractor.Checked)
            {
                cmbContractor.SelectedIndex = -1;
                cmbContractor.Enabled = false;
            }
            else
            {
                cmbContractor.SelectedIndex = -1;
                cmbContractor.Enabled = true;
                cmbContractor.Focus();
            }
        }

        private void cbStatus_CheckedChanged(object sender, EventArgs e)
        {
            cmbStatus.SelectedIndex = -1;
            if (cbStatus.Checked)
            {
                cmbStatus.Enabled = false;
                cmbStatus.SelectedIndex = -1;
            }
            else
            {
                cmbStatus.Text = BusinessResources.LS_Pending;
                cmbStatus.Enabled = true;
            }
        }

        private void cbDevice_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDevice.Checked)
            {
                cmbDevice.SelectedIndex = -1;
                cmbDevice.Enabled = false;
            }
            else
            {
                cmbDevice.SelectedIndex = -1;
                cmbDevice.Enabled = true;
                cmbDevice.Focus();
            }
        }

        TimeSpan totalDuration = TimeSpan.Zero;

        private void txtSearchEmpCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.NumericValue(sender, e, txtSearchEmpCode);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0, LocationId = 0, DepartmentId = 0, ApprovalStatusId = 0, EmployeeId = 0, EmployeeCode = 0;

        private void cbNewFlag_CheckedChanged(object sender, EventArgs e)
        {
            cmbEmployee.SelectedIndex = -1;
            if (cbNewFlag.Checked)
            {
                cmbEmployee.Enabled = false;
                cmbEmployee.SelectedIndex = -1;
            }
            else
            {
               // cmbEmployee.Text = BusinessResources.LS_Pending;
                cmbEmployee.Enabled = true;
            }
        }

        public EmployeeReport()
        {
            InitializeComponent();

            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, "EMPLOYEE REPORT");
            //btnSave.Text = BusinessResources.BTN_VIEW;
            btnDelete.Text = BusinessResources.BTN_VIEW;
            //objQL.Fill_Master_ComboBox(cmbLocation, "locationmaster");
            objRL.FillLocation(cmbLocation, cmbDepartment);

            objRL.Fill_Approval_Status(cmbStatus);
            objRL.Fill_Contractor_IN_Attendance(cmbContractor);


            //ClearAll();
             
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cbEmployeeWise_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEmployeeWise.Checked)
            {
                txtEmployeeName.Enabled = true;
                txtSearchEmpCode.Enabled = true;
                lbEmployee.Visible = true;
                gbOtherSelection.Visible = false;
            }
            else
            {
                txtEmployeeName.Enabled = false;
                txtSearchEmpCode.Enabled = false;
                txtEmployeeName.Text = "";
                txtSearchEmpCode.Text = "";
                lbEmployee.Visible = false;
                gbOtherSelection.Visible = true;
            }
        }

        private void txtEmployeeName_TextChanged(object sender, EventArgs e)
        {
            EmployeeId = 0;
            rtbEmployee.Text = "";

            if (!string.IsNullOrWhiteSpace(Convert.ToString(txtEmployeeName.Text)))
                objRL.Fill_Employee_ListBox(lbEmployee, txtEmployeeName.Text, "Text");
            else
                objRL.Fill_Employee_ListBox(lbEmployee, txtEmployeeName.Text, "All");
        }

        private void txtSearchEmpCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Convert.ToString(txtSearchEmpCode.Text)) && txtEmployeeName.Text == "")
            {
                rtbEmployee.Text = "";
                EmployeeId = 0;
                EmployeeCode = 0;
                //rtbEmployee.Text = "";
                EmployeeCode = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(txtSearchEmpCode.Text)));
                objRL.Get_EmployeeId_By_EmployeeCode(EmployeeCode);
                EmployeeId = objPC.EmployeeId;  // objRL.Get_EmployeeId_By_EmployeeCode(EmployeeCode);
                objRL.Fill_Employee_Details_RichTextBox(rtbEmployee, EmployeeId);
                lbEmployee.Visible = false;
                cbStatus.Focus();
            }
            else
            {
                rtbEmployee.Text = "";
                EmployeeId = 0;
                EmployeeCode = 0;
            }
        }

        private void ClearAll()
        {
            //dtpFromDate.Value = DateTime.Now.Date;
            //dtpToDate.Value = DateTime.Now.Date;
            //cmbReportType.Text = "Today";
            cbEmployeeWise.Checked = true;
            cbLocation.Checked = true;
            cbDepartment.Checked = true;
            cmbLocation.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            cbStatus.Checked = true;
            cmbStatus.SelectedIndex = -1;
            cbContractor.Checked = true;
            cmbContractor.SelectedIndex = -1;
            cbStatus.Checked = true;
            cmbStatus.SelectedIndex = -1;
            cbDevice.Checked = true;
            cmbDevice.SelectedIndex = -1;
            txtSearchEmpCode.Text = "";
            txtEmployeeName.Text = "";
            //dataGridView1.Rows.Clear();
            // rtbStatusCount.Text = "";
            //rtbContractorWiseCount.Text = "";
            txtSearchEmpCode.Text = "";
            //txtSearchEmployee.Text = "";
            dataGridView1.DataSource = null;


            FillGrid();
        }

        string SelectClause = string.Empty;
        string FromClause = string.Empty;
        string WhereBasicClause = string.Empty;
        
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

        bool SearchFlagCode=false
        private void FillGrid()
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
            dataGridView1.DataSource = null;
            DataSet ds = new DataSet();

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
                        "E.NewFlag, " +
                        "E.DOJ, " +
                        "E.DateOfExit as 'DOE' ";

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
                lblTotalCount.Text = "Total-" + ds.Tables[0].Rows.Count;
                //0 EmployeeId, 
                //1 EmployeeCode,
                //2 EmpInital,
                //3 EmployeeName, 
                //4 Gender, 
                //5 DOB, 
                //6 Age, 
                //7 MaritalStatus, 
                //8 MarriageDate, 
                //9 PersonalEmailID,
                //10 MobileNo, 
                //11 OfficialEmailID,
                //12 BloodGroup,
                //13 AadharCardNumber,
                //14 PanCardNumber,
                //15 FartherName, 
                //16 MotherName,
                //17 DrivingLicenseNumber, 
                //18 PersonalIdentificationMark, 
                //19 PhysicalDisability, 
                //20 DescriptionOfPhysicalDisability,
                //21 DOJ, 
                //22 TotalYearsService, 
                //23 E.ContractorId, 
                //24 CM.ContractorName as 'Contractor Name',
                //25 E.EmployementTypeId, 
                //26 ETM.EmployementType as 'Employement Type',
                //27 E.DepartmentId, 
                //28 DM.Department,
                //29 E.DesignationId, 
                //30 DESM.Designation,
                //31 E.JobProfile, 
                //32 E.CategoryId, 
                //33 CT.CategoryFName as 'Category F Name',
                //34 E.LocationId,
                //35 LM.LocationName as 'Location Name',
                //36 RE.eportingTo

                ////0 E.EmployeeId, 
                //dataGridView1.Columns[1].Width = 100;//1 E.EmployeeCode as 'Code',
                ////2 E.EmpInital,
                //dataGridView1.Columns[3].Width = 200;//3 E.EmployeeName as 'Employee Name', 
                //dataGridView1.Columns[4].Width = 60;//4 E.Gender, 
                ////5 E.DOB, 
                //dataGridView1.Columns[6].Width = 40;//6 E.Age, 
                //dataGridView1.Columns[7].Width = 120;//7 E.MobileNo as 'Mobile No', 
                ////8 E.PersonalEmailID as 'Personal Email',   
                ////9 E.OfficialEmailID as 'Official Email',
                ////10 E.BloodGroup as 'Blood Group',
                ////11 E.AadharCardNumber as 'Aadhar Card Number',
                ////12 E.PanCardNumber as 'PAN Card Number',
                //dataGridView1.Columns[13].Width = 150;//13 CM.ContractorName as 'Contractor Name',
                //dataGridView1.Columns[14].Width = 120;//14 ETM.EmployementType as 'Employement Type',
                //dataGridView1.Columns[15].Width = 120;//15 CT.CategoryFName as 'Category F Name',
                //dataGridView1.Columns[16].Width = 120;//16 LM.LocationName as 'Location Name',
                //dataGridView1.Columns[17].Width = 100;//17 DM.Department,
                //dataGridView1.Columns[18].Width = 120;//18 DESM.Designation,
                //dataGridView1.Columns[19].Width = 120;//19 E.JobProfile as 'Job Profile', 
                //dataGridView1.Columns[20].Width = 70;//20 E.Status,
                //21 E.NewFlag

                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[22].Visible = false;

                //0 E.EmployeeId, 
                dataGridView1.Columns[1].Width = 50;//1 E.EmployeeCode as 'Code',
                //2 E.EmpInital,
                dataGridView1.Columns[3].Width = 200;//3 E.EmployeeName as 'Employee Name', 
                dataGridView1.Columns[4].Width = 60;//4 E.Gender, 
                //5 E.DOB, 
                dataGridView1.Columns[6].Width = 30;//6 E.Age, 
                dataGridView1.Columns[7].Width = 80;//7 E.MobileNo as 'Mobile No', 
                //8 E.PersonalEmailID as 'Personal Email',   
                //9 E.OfficialEmailID as 'Official Email',
                //10 E.BloodGroup as 'Blood Group',
                //11 E.AadharCardNumber as 'Aadhar Card Number',
                //12 E.PanCardNumber as 'PAN Card Number',
                dataGridView1.Columns[13].Width = 150;//13 CM.ContractorName as 'Contractor Name',
                dataGridView1.Columns[14].Width = 100;//14 ETM.EmployementType as 'Employement Type',
                dataGridView1.Columns[15].Width = 60;//15 CT.CategoryFName as 'Category F Name',
                dataGridView1.Columns[16].Width = 70; //16 LM.LocationName as 'Location Name',
                dataGridView1.Columns[17].Width = 100;//17 DM.Department,
                dataGridView1.Columns[18].Width = 100;//18 DESM.Designation,
                dataGridView1.Columns[19].Width = 80;//19 E.JobProfile as 'Job Profile', 
                dataGridView1.Columns[20].Width = 110;//20 "SG.ShiftGroupFName as 'Shift Group', " +
                dataGridView1.Columns[21].Width = 60;//20 E.Status,
                //dataGridView1.Columns[22].Width = 70;//22 "E.NewFlag ";
                dataGridView1.Columns[23].Width = 100;//22 "E.NewFlag ";

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

                int NFlag = 0;
                foreach (DataGridViewRow Myrow in dataGridView1.Rows)
                {
                    NFlag = 0; // = string.Empty;
                    //Here 2 cell is target value and 1 cell is Volume
                    if (!string.IsNullOrEmpty(Convert.ToString(Myrow.Cells[22].Value)))
                        NFlag = Convert.ToInt32(Myrow.Cells[22].Value);

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
    }
}
