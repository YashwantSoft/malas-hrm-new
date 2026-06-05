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

namespace SPApplication.Master
{
    public partial class EmployeeEditMaster : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0;

        public EmployeeEditMaster()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_EMPLOYEELIST);
            objQL.Fill_Master_ComboBox(cmbLocation, "locationmaster");
            objQL.Fill_Master_ComboBox(cmbDepartment, "departmentmaster");
            objQL.Fill_Master_ComboBox(cmbDesignation, "designationmaster");
            objQL.Fill_Master_ComboBox(cmbContractor, "contractormaster");
            objQL.Fill_Master_ComboBox(cmbCategory, "categories");
            objQL.Fill_Master_ComboBox(cmbShiftGroup, "shiftgroups");
            objQL.Fill_Master_ComboBox(cmbJobProfile, "jobprofilemaster");
            objQL.Fill_Master_ComboBox(cmbType, "employementtypemaster");
            //cmbLocation.Items.Add("All");
            //FillGrid();
            Set_Query();
        }

        private void ClearAll()
        {
            cmbLocation.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            cmbDesignation.SelectedIndex = -1;
            cmbContractor.SelectedIndex = -1;
            cmbCategory.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
            cmbShiftGroup.SelectedIndex = -1;
            cmbJobProfile.SelectedIndex = -1;
            cmbType.SelectedIndex = -1;
            txtSearch.Text = "";
            txtSearchCode.Text = "";
        }

        private void EmployeeEditMaster_Load(object sender, EventArgs e)
        {
            //ClearAll();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                SearchFlagCode = false;
                SearchFlag = true;
            }
            else
                SearchFlag = false;

            Set_Query();
        }

        private void txtSearchCode_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchCode.Text != "")
            {
                SearchFlagCode = true;
                SearchFlag = false;
            }
            else
                SearchFlagCode = false;

            Set_Query();
        }

        bool SearchFlagCode = false;
        int EmployeeCode_V = 0;

        protected void FillGrid()
        {
            lblTotalCount.Text = "";
            dataGridView1.DataSource = null;
            DataSet ds = new DataSet();
            objPC.EmployeeName = txtSearch.Text;

            if (SearchFlagCode)
                objPC.EmployeeCode = EmployeeCode_V;
            else
                objPC.EmployeeCode = 0;

            if (!SearchFlag)
                objPC.SearchFlag = false;
            else
                objPC.SearchFlag = true;

            ds = objQL.SP_Employees_FillGrid();

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
                dataGridView1.Columns[21].Visible = false;

                //0 E.EmployeeId, 
                dataGridView1.Columns[1].Width = 120;//1 E.EmployeeCode as 'Code',
                //2 E.EmpInital,
                dataGridView1.Columns[3].Width = 200;//3 E.EmployeeName as 'Employee Name', 
                dataGridView1.Columns[4].Width = 60;//4 E.Gender, 
                //5 E.DOB, 
                dataGridView1.Columns[6].Width = 40;//6 E.Age, 
                dataGridView1.Columns[7].Width = 120;//7 E.MobileNo as 'Mobile No', 
                //8 E.PersonalEmailID as 'Personal Email',   
                //9 E.OfficialEmailID as 'Official Email',
                //10 E.BloodGroup as 'Blood Group',
                //11 E.AadharCardNumber as 'Aadhar Card Number',
                //12 E.PanCardNumber as 'PAN Card Number',
                dataGridView1.Columns[13].Width = 150;//13 CM.ContractorName as 'Contractor Name',
                dataGridView1.Columns[14].Width = 140;//14 ETM.EmployementType as 'Employement Type',
                dataGridView1.Columns[15].Width = 140;//15 CT.CategoryFName as 'Category F Name',
                dataGridView1.Columns[16].Width = 120;//16 LM.LocationName as 'Location Name',
                dataGridView1.Columns[17].Width = 100;//17 DM.Department,
                dataGridView1.Columns[18].Width = 120;//18 DESM.Designation,
                dataGridView1.Columns[19].Width = 120;//19 E.JobProfile as 'Job Profile', 
                dataGridView1.Columns[20].Width = 70;//20 E.Status,

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
                    if (!string.IsNullOrEmpty(Convert.ToString(Myrow.Cells[21].Value)))
                        NFlag = Convert.ToInt32(Myrow.Cells[21].Value);

                    if (NFlag == 1)
                    {
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Pending_Color);
                    }
                }

                //dataGridView1.Columns[3].Width = 200;
            }
        }


        private void Fill_Combo_Event(object sender, EventArgs e)
        {
            Set_Query();
        }

        string SelectClause = string.Empty;
        string FromClause = string.Empty;
        string WhereBasicClause = string.Empty;
        string WhereClause = string.Empty;
        string OrderByClause = string.Empty;


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

        private void Set_Query()
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

        private void txtSearchCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.NumericValue(sender, e, txtSearchCode);
        }

        List<int> list = new List<int>();

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            bool FlagOpen = false; int NFlagCount = 0;
            list = null; list = new List<int>();
            if (e.Button == MouseButtons.Right)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    //int[dataGridView1.SelectedRows.Count] countIndex;
                    //countIndex = Convert.ToInt32(dataGridView1.SelectedRows.Count);

                    //0 "E.EmployeeId, " +
                    //1 "E.EmployeeCode as 'Employee Code'," +
                    //2 "E.EmpInital," +
                    //3 "E.EmployeeName as 'Employee Name', " +
                    //4 "E.Gender, " +
                    //5 "E.DOB," +
                    //6 "E.Age, " +
                    //7 "E.MobileNo as 'Mobile', " +
                    //8 "E.PersonalEmailID as 'Personal Email',   " +
                    //9 "E.OfficialEmailID as 'Official Email'," +
                    //10 "E.BloodGroup as 'Blood Group'," +
                    //11 "E.AadharCardNumber as 'Aadhar Card'," +
                    //12 "E.PanCardNumber as 'PAN Card'," +
                    //13 "CM.ContractorName as 'Contractor'," +
                    //14 "ETM.EmployementType as 'Employement Type'," +
                    //15 "CT.CategoryFName as 'Category'," +
                    //16 "LM.LocationName as 'Location'," +
                    //17 "DM.Department," +
                    //18 "DESM.Designation," +
                    //19 "E.JobProfile as 'Job Profile', " +
                    //20 "SG.ShiftGroupFName as 'Shift Group', " +
                    //21 "E.Status," +
                    //22 "E.NewFlag ";

                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    {
                        int RI = dataGridView1.SelectedRows[i].Index;

                        int NFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[RI].Cells[22].Value)));
                        //int index = dataGridView1.SelectedRows[i].Index;
                        int EmployeeId_Grid = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.SelectedRows[i].Cells[0].Value)));
                        list.Add(EmployeeId_Grid);

                        if (NFlag == 1)
                            NFlagCount++;

                        //    FlagOpen = true;
                    }
                }

                ContextMenu m = new ContextMenu();
                //(gridcontextMenu.Items[1] as ToolStripMenuItem).DropDownItems.Add("Tiger", new EventHandler(SubmenuItem_Click));
                //(gridcontextMenu.Items[1] as ToolStripMenuItem).DropDownItems.Add("Lion", image_source, new EventHandler(SubmenuItem_Click));
                //(gridcontextMenu.Items[1] as ToolStripMenuItem).DropDownItems.Add("Elephant", image_source, new EventHandler(SubmenuItem_Click));


                //if (NFlagCount > 0)
                //    m.MenuItems.Add("Update Location and Department", new EventHandler(SubmenuItem_Click));

                //m.MenuItems.Add("Update Contractor", new EventHandler(SubmenuItem_Click));
                //m.MenuItems.Add("Update Shift Group", new EventHandler(SubmenuItem_Click));
                //m.MenuItems.Add("Update Category", new EventHandler(SubmenuItem_Click));
                //m.MenuItems.Add("Update Designation", new EventHandler(SubmenuItem_Click));
                //m.MenuItems.Add("Update Status", new EventHandler(SubmenuItem_Click));
                //m.MenuItems.Add("Update Job Profile", new EventHandler(SubmenuItem_Click));
                //m.MenuItems.Add("Update Employment Type", new EventHandler(SubmenuItem_Click));

                m.MenuItems.Add("Update Over Time Applicable", new EventHandler(SubmenuItem_Click));
                m.MenuItems.Add("Update Flexible Hours", new EventHandler(SubmenuItem_Click));
                m.MenuItems.Add("Save New Employee", new EventHandler(SubmenuItem_Click));

                //m.MenuItems.Add(new MenuItem("Copy"));
                //m.MenuItems.Add(new MenuItem("Paste"));

                //int currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                //if (currentMouseOverRow >= 0)
                //{
                //    m.MenuItems.Add(new MenuItem(string.Format("Do something to row {0}", currentMouseOverRow.ToString())));
                //}

                m.Show(dataGridView1, new Point(e.X, e.Y));

                //var hti = dataGridView1.HitTest(e.X, e.Y);
                ////dataGridView1.ClearSelection();
                ////dataGridView1.Rows[hti.RowIndex].Selected = true;

                //for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                //{
                //    int index = dataGridView1.SelectedRows[i].Index;

                //    //if (yourDGV.SelectedRows.Count > 0)
                //    //{

                //    //}
                //}
            }
        }

        private void SubmenuItem_Click(object sender, EventArgs e)
        {
            var clickedMenuItem = sender as MenuItem;
            var menuText = clickedMenuItem.Text;

            CommanEdit objForm = new CommanEdit(list, menuText);
            objForm.ShowDialog(this);
            Set_Query();
            //switch (menuText)
            //{
            //    case "Tiger":
            //        break;

            //    case "Lion":
            //        break;
            //}
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
            Set_Query();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                RowCount_Grid = dataGridView1.Rows.Count;
                CurrentRowIndex = dataGridView1.CurrentRow.Index;

                if (RowCount_Grid >= 0 && CurrentRowIndex >= 0)
                {
                    objPC.EmployeeId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                    objPC.EmployeeCode = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);

                    EmployeeMaster objForm = new EmployeeMaster(objPC.EmployeeId);
                    objForm.ShowDialog(this);
                    Set_Query();
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
    }
}
