using BusinessLayerUtility;
using SPApplication.Master;
using SPApplication.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Word = Microsoft.Office.Interop.Word;
using DocumentFormat.OpenXml;

namespace SPApplication.Transaction
{
    public partial class MemoAndLetters : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0;

        Excel.Application myExcelApp;
        Excel.Workbooks myExcelWorkbooks;
        Excel.Workbook myExcelWorkbook;

        bool BorderFlag = false; bool CellFlag = false;
        string PDFReport = string.Empty;
        int AFlag = 0; int SrNo = 1;
        bool AlignFlag = false; bool boldflag = false;
        int RowCount = 18;
        bool MH_Value = false;
        string ReportName = string.Empty;

        private static string formName;

        public MemoAndLetters()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_MEMOINFORMATION);
            objQL.Fill_Master_ComboBox(cmbLocation, "locationmaster");
            lblFine.Visible = false; txtFine.Visible = false;
            formName = objPC.FormName;
           
            if (objPC.FormName == "Memo")
            {
                objQL.Fill_Master_ComboBox(cmbMemoSubject, "memotemplatemaster");
                lblHeader.Text = objPC.FormName.ToString();
                lblFine.Visible = true; txtFine.Visible = true;
            }
            else
            {
                objQL.Fill_Master_ComboBox(cmbMemoSubject, "memotemplatemasterletter");
                lblHeader.Text = objPC.FormName.ToString();
            }

            objDL.SetButtonDesign(btnPrint, BusinessResources.BTN_PRINT);

            objRL.FillLocation(cmbLocation, cmbDepartment);
            FillEmployee_Fixed();
        }

        private void FillEmployee_Fixed()
        {
            //FillEmployees_Combobox();
            ClearAll_Location_Department();

            if (cmbLocation.SelectedIndex > -1 && cmbDepartment.SelectedIndex > -1)
            {
                //objQL.WhereClause_V = " and E.LocationId=" + cmbLocation.SelectedValue + "  and E.DepartmentId=" + cmbDepartment.SelectedValue + "  and DM.DesignationCategory NOT IN('" + BusinessResources.USER_TYPE_TRAINEE + "')";
                objQL.WhereClause_V = " and E.LocationId=" + cmbLocation.SelectedValue + "  and E.DepartmentId=" + cmbDepartment.SelectedValue + ""; //  and DM.DesignationCategory NOT IN('" + BusinessResources.USER_TYPE_TRAINEE + "')";

                objQL.SP_Employees_Get_By_All(cmbEmployeeName);

                if (BusinessLayer.UserType == BusinessResources.USER_TYPE_OFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_SUPERVISOR)
                {
                    cmbEmployeeName.Enabled = false;
                    cmbEmployeeName.Text = BusinessLayer.UserName_Full_Static;
                    //objRL.Fill_EmployeeDetails();
                    Fill_EmployeeDetails();
                }
                //objRL.FillEmployees();
            }
        }

        private void ClearAll_Location_Department()
        {
            cmbEmployeeName.SelectedIndex = -1;
            txtEmployeeCode.Text = "";
            txtDesignation.Text = "";
            cmbMemoSubject.SelectedIndex = -1;
            rtbTemplate.Text = "";
        }

        private void CTC_VisibleTrueFalse(bool SetTF)
        {
            txtCTCMonthly.Text = "";
            txtCTCYearly.Text = "";
            lblCTCMonthly.Visible = SetTF;
            txtCTCMonthly.Visible = SetTF;
            txtCTCYearly.Visible = SetTF;
            lblCTCYearly.Visible = SetTF;
        }

        private void Fill_EmployeeDetails()
        {
            txtEmployeeCode.Text = "";
            txtDesignation.Text = "";
            if (cmbEmployeeName.SelectedIndex > -1)
            {
                objPC.EmployeeId = Convert.ToInt32(cmbEmployeeName.SelectedValue);
                objRL.Fill_EmployeeDetails();
                txtEmployeeCode.Text = objPC.EmployeeCode.ToString();
                txtDesignation.Text = objPC.Designation.ToString();

                if (objPC.FormName == "Memo")
                {
                    CTC_VisibleTrueFalse(false);
                    dgvMemo.Visible = true;
                    dgvMemo.Rows.Clear();
                    GetTotalMemo();
                }
                else
                {
                    dgvMemo.Visible = false;
                    dgvMemo.Rows.Clear();
                    CTC_VisibleTrueFalse(true);
                    txtCTCMonthly.Text = objPC.SalaryMonthlyNetSalary;
                    txtCTCYearly.Text = objPC.SalaryAnualNetSalary;
                }
            }
        }

        string EMPNAME = string.Empty, EDITDESIGNATION = string.Empty, EDITDATE = string.Empty, MONTHLYSALARY = string.Empty, EMONTH = string.Empty, CTCYEARLY = string.Empty, CNAME = string.Empty, EAMOUNT=string.Empty;

        private void GetTotalMemo()
        {
            dgvMemo.Rows.Clear();
            DataSet ds = new DataSet();
            objBL.Query = "select MemoTemplateMasterId,MemoSubject from memotemplatemaster where LetterType='Memo' order by MemoSubject asc";
            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dgvMemo.Rows.Add();
                    dgvMemo.Rows[i].Cells["clmMemoTemplateId"].Value = ds.Tables[0].Rows[i]["MemoTemplateMasterId"].ToString();
                    dgvMemo.Rows[i].Cells["clmMemoName"].Value = ds.Tables[0].Rows[i]["MemoSubject"].ToString();
                    objPC.MemoTemplateMasterId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["MemoTemplateMasterId"])));
                    objRL.Get_Memo_Count_By_EmployeeId_MemoId();
                    dgvMemo.Rows[i].Cells["clmCount"].Value = objPC.MemoCount.ToString();
                }
            }
        }

        private void MemoInformation_Load(object sender, EventArgs e)
        {
            ClearAll();
            FillGrid();
        }

        private void ClearAll()
        {
            EMPNAME = string.Empty; EDITDESIGNATION = string.Empty; EDITDATE = string.Empty; MONTHLYSALARY = string.Empty; CTCYEARLY = string.Empty; EAMOUNT = string.Empty;

            TableId = 0;
            objEP.Clear();
            EmployeeId = 0;
            //cmbLocation.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            cmbEmployeeName.SelectedIndex = -1;
            cmbMemoSubject.SelectedIndex = -1;
            rtbTemplate.Text = "";
            txtSearch.Text = "";
            txtEmployeeCode.Text = "";
            txtDesignation.Text = "";
            btnPrint.Visible = false;
            GridFlag = false;

            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }

        int EmployeeId = 0, EmployeeCode = 0;

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FlagDelete = false;
            SaveDB();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (BusinessLayer.Department == "TIME OFFICE")
            {
                DialogResult dr = objRL.Delete_Record_Show_Message();
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    FlagDelete = true;
                    SaveDB();
                }
            }
        }

        protected void FillGrid1()
        {
            lblTotalCount.Text = "";
            dataGridView1.DataSource = null;
            DataSet ds = new DataSet();
            objPC.EmployeeName = txtSearch.Text;

            if (SearchFlag)
            {
                objPC.SearchFlag = false;
            }
            else
            {
                objPC.SearchFlag = true;
            }

            ds = objQL.SP_Memo_FillGrid();

            //0 M.MemoId,
            //1 M.EntryDate as 'Memo Date',
            //2 M.EmployeeId,
            //3 E.EmployeeName as 'Employee Name',
            //4 M.LocationId,
            //5 L.LocationName as 'Location',
            //6 M.MemoTemplateMasterId,
            //7 MTM.MemoSubject as 'Memo Subject',
            //8 MTM.MemoTemplate as 'Memo Template' 

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTotalCount.Text = "Total-" + ds.Tables[0].Rows.Count;
                //0 ContryId,
                //1 ContryName as 'Contry Name', 
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[6].Visible = false;

                dataGridView1.Columns[1].Width = 100;
                dataGridView1.Columns[3].Width = 200;
                dataGridView1.Columns[5].Width = 200;
                dataGridView1.Columns[7].Width = 200;
                dataGridView1.Columns[8].Width = 200;
            }
        }

        string MainQuery = string.Empty;
        string WhereClause = string.Empty;
        string WhereBasic = string.Empty;
        string OrderBy = string.Empty;

        public void FillGrid()
        {
            lblTotalCount.Text = "";
            dataGridView1.DataSource = null;
            DataSet ds = new DataSet();

            MainQuery = string.Empty;
            WhereClause = string.Empty;
            WhereBasic = string.Empty;
            OrderBy = string.Empty;

            if (SearchFlag)
                WhereClause = " and E.EmployeeName LIKE '%" + txtSearch.Text + "%'";

            MainQuery = "select distinct " +
                     "M.MemoId," +
                     "M.EntryDate as 'Date'," +
                     "DATE_FORMAT(M.EntryTime, '%H:%i') as 'Time'," +
                     "M.LocationId, " +
                     "L.LocationName as 'Location'," +
                     "M.DepartmentId, " +
                     "D.Department," +
                     "M.EmployeeId," +
                     "E.EmployeeName as 'Employee Name'," +
                     "M.MemoTemplateMasterId," +
                     "MTM.MemoSubject as 'Subject'," +
                     "MTM.MemoTemplate as 'Template', " +
                     "M.MemoFine as 'Memo Fine', " +
                     "M.LetterType, " +
                     "M.LetterData " +
                     "from " +
                     "memo M inner join Employees E on E.EmployeeId=M.EmployeeId inner join " +
                     "locationmaster L on L.LocationId=M.LocationId inner join " +
                     "departmentmaster D on D.DepartmentId=M.DepartmentId inner join " +
                     "memotemplatemaster MTM on MTM.MemoTemplateMasterId=M.MemoTemplateMasterId inner join " +
                     "locationwisedepartmentusers LWDU on L.LocationId = LWDU.LocationId and D.DepartmentId = LWDU.DepartmentId ";

            WhereBasic = "where M.CancelTag=0 and L.CancelTag=0 and D.CancelTag=0 and E.CancelTag=0 and MTM.CancelTag=0 and M.LetterType='" + objPC.FormName + "'";
            OrderBy = " order by M.EntryDate desc";

            objBL.Query = MainQuery + WhereBasic + objRL.WhereClasuse_CompOff_Comman() + WhereClause + OrderBy;
            ds = objBL.ReturnDataSet();

            //0 "M.MemoId," +
            //1 "M.EntryDate as 'Date'," +
            //2 "M.EntryDate as 'Memo Date'," +
            //3 "M.LocationId, " +
            //4 "L.LocationName as 'Location'," +
            //5 "M.DepartmentId, " +
            //6 "L.Department," +
            //7 "M.EmployeeId," +
            //8 "E.EmployeeName as 'Employee Name'," +
            //9 "M.MemoTemplateMasterId," +
            //10 "MTM.MemoSubject as 'Memo Subject'," +
            //11 "MTM.MemoTemplate as 'Memo Template' " +
            //12 "M.LetterType "+
            //13 "M.LetterData " +

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTotalCount.Text = "Total-" + ds.Tables[0].Rows.Count;
                //0 ContryId,
                //1 ContryName as 'Contry Name', 
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[13].Visible = false;

                if (objPC.FormName == "Letter")
                    dataGridView1.Columns[12].Visible = false;

                dataGridView1.Columns[1].Width = 80;
                dataGridView1.Columns[2].Width = 60;
                dataGridView1.Columns[4].Width = 150;
                dataGridView1.Columns[6].Width = 150;
                dataGridView1.Columns[8].Width = 200;
                dataGridView1.Columns[10].Width = 150;
                dataGridView1.Columns[11].Width = 300;
            }
        }

        private bool Validation()
        {
            objEP.Clear();
            if (cmbLocation.SelectedIndex == -1)
            {
                cmbLocation.Focus();
                objEP.SetError(cmbLocation, " Enter Location");
                return true;
            }
            else if (cmbDepartment.SelectedIndex == -1)
            {
                cmbDepartment.Focus();
                objEP.SetError(cmbDepartment, " Enter Department");
                return true;
            }
            else if (cmbEmployeeName.SelectedIndex == -1)
            {
                cmbEmployeeName.Focus();
                objEP.SetError(cmbEmployeeName, " Enter Employee Name");
                return true;
            }
            else if (cmbMemoSubject.SelectedIndex == -1)
            {
                cmbMemoSubject.Focus();
                objEP.SetError(cmbMemoSubject, " Enter Memo Subject");
                return true;
            }
            else if (cmbMemoSubject.Text == "Chewing Tobacco  inside the company")
            {
                if (txtFine.Text == "")
                {
                    txtFine.Focus();
                    objEP.SetError(txtFine, " Enter Fine");
                    return true;
                }
                else
                    return false;
            }
            else if (rtbTemplate.Text == "")
            {
                rtbTemplate.Focus();
                objEP.SetError(rtbTemplate, " Enter Memo Template");
                return true;
            }
            else
                return false;
        }

        protected bool CheckExist()
        {
            DataSet ds = new DataSet();
            ds = objQL.SP_Memo_CheckExist();
            if (ds.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }

        protected void SaveDB()
        {
            if (!Validation())
            {
                objPC.MemoId = TableId;
                objPC.EntryDate = dtpEntryDate.Value;
                objPC.EntryTime = dtpEntryTime.Value;
                objPC.LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
                objPC.DepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue);
                objPC.EmployeeId = Convert.ToInt32(cmbEmployeeName.SelectedValue);
                objPC.MemoTemplateMasterId = Convert.ToInt32(cmbMemoSubject.SelectedValue);
                objPC.LetterType = objPC.FormName;
                objPC.LetterData = rtbTemplate.Text;

                if (txtFine.Text != "")
                    objPC.MemoFine = Convert.ToInt32(txtFine.Text);
                else
                    objPC.MemoFine = 0;

                objPC.UserId = BusinessLayer.LoginId_Static;
                objPC.DeleteFlag = FlagDelete;

                if (objPC.FormName == "Letter")
                {
                    if (!FlagDelete)
                    {
                        if (CheckExist())
                        {
                            objRL.ShowMessage(12, 4);
                            return;
                        }
                    }
                }

                Result = objQL.SP_Memo_Insert_Update_Delete();

                if (Result > 0)
                {
                    if (!FlagDelete)
                        objRL.ShowMessage(7, 1);
                    else
                        objRL.ShowMessage(9, 1);

                    FillGrid();
                    //ClearAll();
                    if (TableId == 0)
                        TableId = objRL.ReturnMaxID_Fix("memo", "MemoId");

                    btnPrint.Visible = true;
                }
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }

        private void btnAddMemo_Click(object sender, EventArgs e)
        {
            objPC.FormName = formName;
            objPC.LetterType = formName;
            MemoTemplateMaster objForm = new MemoTemplateMaster();
            objForm.ShowDialog(this);

            if (formName == "Memo")
                objQL.Fill_Master_ComboBox(cmbMemoSubject, "memotemplatemaster");
            else
                objQL.Fill_Master_ComboBox(cmbMemoSubject, "memotemplatemasterletter");
        }

        private void cmbMemoSubject_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_Memo_Template();
        }

        bool GridFlag = false;

        private bool Validation_Letter()
        {
            
            objEP.Clear();
            if (cmbLocation.SelectedIndex == -1)
            {
                cmbLocation.Focus();
                objEP.SetError(cmbLocation, " Enter Location");
                return true;
            }
            else if (cmbDepartment.SelectedIndex == -1)
            {
                cmbDepartment.Focus();
                objEP.SetError(cmbDepartment, " Enter Department");
                return true;
            }
            else if (cmbEmployeeName.SelectedIndex == -1)
            {
                cmbEmployeeName.Focus();
                objEP.SetError(cmbEmployeeName, " Enter Employee Name");
                return true;
            }
            else if (cmbMemoSubject.SelectedIndex == -1)
            {
                cmbMemoSubject.Focus();
                objEP.SetError(cmbMemoSubject, " Enter Memo Subject");
                return true;
            }
            else if (objPC.FormName == "Letter")
            {
                if (txtCTCMonthly.Text == "" || txtCTCMonthly.Text == "0")
                {
                    txtCTCMonthly.Focus();
                    objEP.SetError(txtCTCMonthly, " Enter CTC Monthly");
                    return true;
                }
                else if (txtCTCYearly.Text == "" || txtCTCYearly.Text == "0")
                {
                    txtCTCYearly.Focus();
                    objEP.SetError(txtCTCYearly, " Enter CTC Yearly");
                    return true;
                }
                else
                    return false;
            }
            //else if (objPC.FormName == "Memo")
            //{
            //    return false;
            //}
            else
                return false;
        }
        private void Fill_Memo_Template()
        {
            if (!Validation_Letter())
            {
                rtbTemplate.Text = ""; Temp_MemoTemplate = string.Empty;
                if (cmbMemoSubject.SelectedIndex > -1)
                {
                    DataSet ds = new DataSet();
                    objBL.Query = "select MemoTemplateMasterId,MemoSubject,MemoTemplate from memotemplatemaster where MemoTemplateMasterId=" + cmbMemoSubject.SelectedValue + " and CancelTag=0";
                    ds = objBL.ReturnDataSet();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["MemoTemplate"])))
                        {
                            //rtbTemplate.Text = Convert.ToString(ds.Tables[0].Rows[0]["MemoTemplate"]);
                            //objPC.MemoTemplate = Convert.ToString(ds.Tables[0].Rows[0]["MemoTemplate"]);
                            Temp_MemoTemplate = Convert.ToString(ds.Tables[0].Rows[0]["MemoTemplate"]);

                            if (!GridFlag)
                                ReplaceMemoTemplate();
                        }
                    }
                }
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }

        private void ReplaceMemoTemplate()
        {
            if (cmbLocation.SelectedIndex > -1 && cmbDepartment.SelectedIndex > -1 && cmbEmployeeName.SelectedIndex > -1)
            {
                EDITDESIGNATION = string.Empty; EDITDATE = string.Empty; MONTHLYSALARY = string.Empty; CTCYEARLY = string.Empty; EMONTH = string.Empty;

                //if (!string.IsNullOrEmpty(Convert.ToString(objPC.LocationName)))
                //    Location = objPC.LocationName;

                if (!string.IsNullOrEmpty(Convert.ToString(objPC.Designation)))
                    EDITDESIGNATION = objPC.Designation;

                if (!string.IsNullOrEmpty(Convert.ToString(objPC.DOJ)))
                    EDITDATE = objPC.DOJ.ToString(BusinessResources.DATEFORMATDDMMYYYY);

                if (!string.IsNullOrEmpty(Convert.ToString(objPC.SalaryMonthlyNetSalary)))
                    MONTHLYSALARY = objPC.SalaryMonthlyNetSalary.ToString();

                if (!string.IsNullOrEmpty(Convert.ToString(objPC.SalaryAnualNetSalary)))
                    CTCYEARLY = objPC.SalaryAnualNetSalary.ToString();

               if (!string.IsNullOrEmpty(Convert.ToString(objPC.EmployeeName)))
                   EMPNAME = objPC.EmployeeName ;

               objRL.Get_Company_Name();
               if (!string.IsNullOrEmpty(Convert.ToString(objPC.CompanyName)))
                   CNAME = objPC.CompanyName;
                 
                rtbTemplate.Text = ReplaceMethod();
            }
        }

        public string ReplaceMethod()
        {
            StringBuilder sb = new StringBuilder(Temp_MemoTemplate);

            if (cmbMemoSubject.SelectedIndex > -1)
            {
                sb.Replace("CNAME", CNAME);
                if (cmbMemoSubject.Text == "Appointment Letter")
                {
                    sb.Replace("EDITDESIGNATION", EDITDESIGNATION);
                    sb.Replace("EDITDATE", EDITDATE);
                    sb.Replace("MONTHLYSALARY", MONTHLYSALARY);
                    sb.Replace("CTCYEARLY", CTCYEARLY);
                }
                else if (cmbMemoSubject.Text == "Offer Letter")
                {
                    sb.Replace("EMPNAME", EMPNAME);
                    sb.Replace("EDITDESIGNATION", EDITDESIGNATION);
                    sb.Replace("EDITDATE", EDITDATE);
                }
                else if (cmbMemoSubject.Text == "Experience Letter")
                {
                    sb.Replace("EMPNAME", EMPNAME);
                    sb.Replace("EDITDESIGNATION", EDITDESIGNATION);
                    EDITDATE = objPC.DOJ.ToString(BusinessResources.DATEFORMATDDMMMYYYY) + " to " + objPC.DateOfExit.ToString(BusinessResources.DATEFORMATDDMMMYYYY);
                    sb.Replace("EDITDATE", EDITDATE);
                }
                else if (cmbMemoSubject.Text == "Relieving Letter")
                {
                    sb.Replace("EMPNAME", EMPNAME);
                    sb.Replace("EDITDATE", EDITDATE);

                    if (!string.IsNullOrEmpty(Convert.ToString(objPC.DOR)))
                    {
                        EDITDATE = objPC.DOR.ToString(BusinessResources.DATEFORMATDDMMMYYYY);
                        int M = objPC.DOR.Month;
                        EMONTH = objRL.GetMonthName(M);
                        sb.Replace("EMONTH", EMONTH);
                    }
                }
                else if (cmbMemoSubject.Text == "No Dues Certificate For Company")
                {
                    sb.Replace("EMPNAME", EMPNAME);
                    //sb.Replace("EMPNAME", EMPNAME);
                }
                else if (cmbMemoSubject.Text == "Breakfast in changing room")
                {
                    sb.Replace("EMPNAME", EMPNAME);
                    //sb.Replace("EMPNAME", EMPNAME);
                }
                else if (cmbMemoSubject.Text == "Use of mobile in working")
                {
                    sb.Replace("EMPNAME", EMPNAME);
                    sb.Replace("ELOCATION", objPC.LocationName);
                    EDITDATE = dtpEntryDate.Value.ToString(BusinessResources.DATEFORMATDDMMMYYYY);
                    sb.Replace("EDITDATE", EDITDATE);
                }
                else if (cmbMemoSubject.Text == "Miss Behave")
                {
                    sb.Replace("EMPNAME", EMPNAME);
                    //sb.Replace("LOCATION", objPC.LocationName);
                    //EDITDATE = dtpEntryDate.Value.ToString(BusinessResources.DATEFORMATDDMMMYYYY);
                    //sb.Replace("EDITDATE", EDITDATE);
                }
                else if (cmbMemoSubject.Text == "Chewing Tobacco  inside the company")
                {
                    sb.Replace("EMPNAME", EMPNAME);
                    sb.Replace("ELOCATION", objPC.LocationName);

                    if (!string.IsNullOrEmpty(Convert.ToString(txtFine.Text)))
                    {
                        string AMOUNT = string.Empty;
                        AMOUNT = " Rs." + txtFine.Text.ToString() + "/-";
                        sb.Replace("EAMOUNT", AMOUNT);
                    }
                    EDITDATE = dtpEntryDate.Value.ToString(BusinessResources.DATEFORMATDDMMMYYYY);
                    sb.Replace("EDITDATE", EDITDATE);
                }
                else
                {

                }
            }
            return sb.ToString();
        }

        string Temp_MemoTemplate = string.Empty;
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
                SearchFlag = true;
            else
                SearchFlag = false;

            FillGrid();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                RowCount_Grid = dataGridView1.Rows.Count;
                CurrentRowIndex = dataGridView1.CurrentRow.Index;

                if (RowCount_Grid >= 0 && CurrentRowIndex >= 0)
                {
                    //ClearAll();

                    //0 "M.MemoId," +
                    //1 "M.EntryDate as 'Date'," +
                    //2 "M.EntryDate as 'Memo Date'," +
                    //3 "M.LocationId, " +
                    //4 "L.LocationName as 'Location'," +
                    //5 "M.DepartmentId, " +
                    //6 "L.Department," +
                    //7 "M.EmployeeId," +
                    //8 "E.EmployeeName as 'Employee Name'," +
                    //9 "M.MemoTemplateMasterId," +
                    //10 "MTM.MemoSubject as 'Memo Subject'," +
                    //11 "MTM.MemoTemplate as 'Memo Template' " +
                    //12 "M.LetterType "+
                    //13 "M.LetterData " +

                    GridFlag = true;
                    TableId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                    dtpEntryDate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                    dtpEntryTime.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                    cmbLocation.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    objRL.FillDepartment(cmbLocation, cmbDepartment);
                    cmbDepartment.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                    FillEmployee_Fixed();
                    cmbEmployeeName.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                    EmployeeId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
                    objPC.EmployeeId = EmployeeId;
                    Fill_EmployeeDetails();
                    cmbMemoSubject.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                    Fill_Memo_Template();
                    //Temp_MemoTemplate = Convert.ToString(ds.Tables[0].Rows[0]["MemoTemplate"]);
                    ReplaceMemoTemplate();
                    //rtbTemplate.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();

                    if (BusinessLayer.Department == "TIME OFFICE")
                    {
                        btnDelete.Enabled = true;
                    }
                    else
                    {
                        btnDelete.Enabled = false;
                        btnSave.Enabled = false;
                    }

                    btnPrint.Visible = true;
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

        public static class PdfExporter
        {
            public static void ConvertDocxToPdf(string docxPath, string pdfPath)
            {
                var app = new Word.Application();
                var doc = app.Documents.Open(docxPath);
                doc.ExportAsFixedFormat(pdfPath, Word.WdExportFormat.wdExportFormatPDF);
                doc.Close(false);
                app.Quit();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //string docxPath = @"D:\BitBucketProjects\Malas Fruit\OT Approval Development\SPApplication\SPApplication\bin\Debug\Data\Format\MemoR.docx";
            //string pdfPath = @"D:\Softwares\Reports\MemoOutput.pdf";

            //CreateMemoDocx(docxPath);
            //PdfExporter.ConvertDocxToPdf(docxPath, pdfPath);

            //MessageBox.Show("Memo and PDF created successfully.");

            if (!Validation())
            {
                Get_Report_Data();
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }

        string ReportPath = string.Empty;
        string ReportDS = string.Empty, ReportDS1 = string.Empty, ReportDS_CompanyComman = string.Empty;
        string RDLC_ReportName = string.Empty;
        string ReportConcatPath = string.Empty;
        bool ParameterFlag = false;
        string rpReportName = string.Empty, rpReportDate = string.Empty, rpReportPeriod = string.Empty, rpReportBy = string.Empty;

        private void Get_Report_Data()
        {
            objBL.Query = " select " +
                "M.MemoId, " +
                "M.EntryDate," +
                "M.EmployeeId," +
                "E.EmployeeCode," +
                "E.EmployeeName," +
                "M.LocationId," +
                "L.LocationName," +
                "E.DepartmentId," +
                "DM.Department," +
                "E.DesignationId," +
                "D.Designation," +
                "M.MemoTemplateMasterId," +
                "MTM.MemoSubject," +
                "MTM.MemoTemplate" +
            " from " +
                "memo M inner join Employees E on E.EmployeeId=M.EmployeeId inner join " +
                "locationmaster L on L.LocationId=M.LocationId inner join " +
                "departmentmaster DM on DM.DepartmentId=E.DepartmentId inner join " +
                "designationmaster D on D.DesignationId=E.DesignationId inner join " +
                "memotemplatemaster MTM on MTM.MemoTemplateMasterId=M.MemoTemplateMasterId " +
             "where " +
                "E.CancelTag=0 and " +
                "L.CancelTag=0 and " +
                "DM.CancelTag=0 and " +
                "D.CancelTag=0 and " +
                "MTM.CancelTag=0 and " +
                "MTM.CancelTag=0 and " +
                "M.MemoId="+TableId+" and "+
                "M.LetterType='" + objPC.FormName + "' " +
                " order by M.EntryDate desc";
            
            DataSet ds = new DataSet();
            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
            {
                EmployeeConcat = string.Empty;

                objPC.EmployeeId = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["EmployeeId"])));
                objPC.EmployeeCode = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["EmployeeCode"])));
                objPC.EmployeeName = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["EmployeeName"]));
                objPC.LocationId = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["LocationId"])));
                objPC.LocationName = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["LocationName"]));
                objPC.DepartmentId = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["DepartmentId"])));
                objPC.Department = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Department"]));
                objPC.DesignationId = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["DesignationId"])));
                objPC.Designation = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Designation"]));
                objPC.MemoSubject = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["MemoSubject"]));
                objPC.MemoTemplate = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["MemoTemplate"]));
                objPC.MemoId = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["MemoId"])));
                objPC.MemoTemplateMasterId = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["MemoTemplateMasterId"])));

                //Excel Report
                BorderFlag = false;

                object misValue = System.Reflection.Missing.Value;
                myExcelApp = new Excel.Application();
                myExcelWorkbooks = myExcelApp.Workbooks;


                objRL.ClearExcelPath();
                objRL.isPDF = true;

                string CompanyName_Report = string.Empty;

                if (objPC.FormName == "Memo")
                    objRL.Form_ExcelFileName = "MemoReport.xlsx";
                else
                    objRL.Form_ExcelFileName = "Letter.xlsx";

                objRL.DocumentFlag = false; 
                if (objPC.FormName == "Memo")
                {
                    objRL.Form_ReportFileName = "MemoReport-" + objPC.EmployeeCode;
                    objRL.Form_DestinationReportFilePath = "Memo\\";
                }
                else
                {
                    objRL.DocumentFlag = true; 
                    objRL.Form_ReportFileName = cmbMemoSubject.Text;
                    objRL.Form_DestinationReportFilePath = cmbMemoSubject.Text+"\\";
                }

                
                objRL.Path_Comman();

                myExcelWorkbook = myExcelWorkbooks.Open(objRL.RL_DestinationPath, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue);
                Excel.Worksheet myExcelWorksheet = (Excel.Worksheet)myExcelWorkbook.ActiveSheet;
                objRL.DocumentFlag = false;

                if (objPC.FormName == "Memo")
                {
                    
                    //Get Memo Count
                    int MemoCount = 0;
                    DataSet dsMemoCount = new DataSet();
                    objBL.Query = "select count(*) from Memo where EmployeeId=" + objPC.EmployeeId + " and MemoTemplateMasterId=" + objPC.MemoTemplateMasterId + " and CancelTag=0";
                    dsMemoCount = objBL.ReturnDataSet();
                    if (dsMemoCount.Tables[0].Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(dsMemoCount.Tables[0].Rows[0][0])))
                            MemoCount = Convert.ToInt32(dsMemoCount.Tables[0].Rows[0][0]);
                    }

                    objRL.Get_Company_Name();
                    //myExcelWorksheet.get_Range("A1", misValue).Formula = objPC.CompanyName.ToString();

                    //objRL.FillCompanyData();
                    //objRL.Fill_Firm_Data(Convert.ToInt32(cmbCompany.SelectedValue));

                    myExcelWorksheet.get_Range("B5", misValue).Formula = TableId.ToString();

                    myExcelWorksheet.get_Range("B6", misValue).Formula = MemoCount.ToString();
                    myExcelWorksheet.get_Range("H5", misValue).Formula = dtpEntryDate.Value.ToString(BusinessResources.DATEFORMATDDMMMYYYY);


                    EmployeeConcat = "To, " + System.Environment.NewLine +
                                     "Employee Code: " + objPC.EmployeeCode + System.Environment.NewLine +
                                     "Employee Name: " + objPC.EmployeeName + System.Environment.NewLine +
                                     "Location: " + objPC.LocationName + System.Environment.NewLine +
                                     "Department: " + objPC.Department + System.Environment.NewLine +
                                     "Designation: " + objPC.Designation + System.Environment.NewLine;// +

                    //EmployeeConcat = "To, " + System.Environment.NewLine +
                    //                 "Employee Code: \t" + objPC.EmployeeCode + System.Environment.NewLine +
                    //                 "Employee Name: \t" + objPC.EmployeeName + System.Environment.NewLine +
                    //                 "Location: \t" + objPC.LocationName + System.Environment.NewLine +
                    //                 "Department: \t" + objPC.Department + System.Environment.NewLine +
                    //                 "Designation: \t" + objPC.Designation + System.Environment.NewLine;// +

                    //"Department: \t" + objPC.Department + System.Environment.NewLine;

                    //A8

                    // myExcelWorksheet.get_Range("A1", misValue).Formula = "MALAS FOOD PRODUCTS PRIVATE LIMITED";
                    myExcelWorksheet.get_Range("A4", misValue).Formula = "MEMO";

                    myExcelWorksheet.get_Range("A8", misValue).Formula = EmployeeConcat.ToString();
                    myExcelWorksheet.get_Range("A16", misValue).Formula = "Subject:" + objPC.MemoSubject.ToString();
                    myExcelWorksheet.get_Range("B19", misValue).Formula = rtbTemplate.Text.ToString(); // objPC.MemoTemplate.ToString();

                    objRL.GetTotalMemo_By_Subject();
                    myExcelWorksheet.get_Range("B6", misValue).Formula = objPC.MemoCount.ToString();
                    
                    objPC.LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
                    objPC.DepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue);

                    //objRL.Get_Incharge_Senior_OfficerId();
                    ////objRL.Get_Incharge_Senior_OfficerId_for_memo();

                    //myExcelWorksheet.get_Range("B47", misValue).Formula = objPC.HRName.ToString();
                    //myExcelWorksheet.get_Range("B48", misValue).Formula = objPC.InchargeName; // Get_Employee_Details(BusinessResources.USER_TYPE_INCHARGE);
                    //myExcelWorksheet.get_Range("B49", misValue).Formula = objPC.PlantHeadName; // Get_Employee_Details(BusinessResources.USER_TYPE_OFFICER);
                    //myExcelWorksheet.get_Range("B50", misValue).Formula = objPC.EmployeeName;



                    //myExcelWorksheet.get_Range("C42", misValue).Formula = objPC.HRName.ToString();
                    //myExcelWorksheet.get_Range("C44", misValue).Formula = objPC.InchargeName; // Get_Employee_Details(BusinessResources.USER_TYPE_INCHARGE);
                    //myExcelWorksheet.get_Range("C46", misValue).Formula = objPC.PlantHeadName; // Get_Employee_Details(BusinessResources.USER_TYPE_OFFICER);
                    //myExcelWorksheet.get_Range("C48", misValue).Formula = objPC.EmployeeName;

                    //Fill_Merge_Cell("H", "H", misValue, myExcelWorksheet, txtInvoiceTotalMain.Text.ToString());
                }
                else
                {
                    ////Get Memo Count
                    //int MemoCount = 0;
                    //DataSet dsMemoCount = new DataSet();
                    //objBL.Query = "select count(*) from Memo where EmployeeId=" + objPC.EmployeeId + " and MemoTemplateMasterId=" + objPC.MemoTemplateMasterId + " and CancelTag=0";
                    //dsMemoCount = objBL.ReturnDataSet();
                    //if (dsMemoCount.Tables[0].Rows.Count > 0)
                    //{
                    //    if (!string.IsNullOrEmpty(Convert.ToString(dsMemoCount.Tables[0].Rows[0][0])))
                    //        MemoCount = Convert.ToInt32(dsMemoCount.Tables[0].Rows[0][0]);
                    //}

                    //  myExcelWorksheet.get_Range("B6", misValue).Formula = MemoCount.ToString();

                    // myExcelWorksheet.get_Range("A1", misValue).Formula = "MALAS FOOD PRODUCTS PRIVATE LIMITED";
                    myExcelWorksheet.get_Range("H5", misValue).Formula = dtpEntryDate.Value.ToString(BusinessResources.DATEFORMATDDMMMYYYY);


                    EmployeeConcat = "Dear "+ objPC.EmployeeName;

                    myExcelWorksheet.get_Range("A5", misValue).Formula = EmployeeConcat.ToString();
                    myExcelWorksheet.get_Range("A4", misValue).Formula = cmbMemoSubject.Text;

                    //myExcelWorksheet.get_Range("A8", misValue).Formula = txtMemoTemplate.Text.ToString(); // objPC.MemoTemplate.ToString();
                    myExcelWorksheet.get_Range("A8", misValue).Formula = rtbTemplate.Text.ToString(); // objPC.MemoTemplate.ToString();
                    //myExcelWorksheet.get_Range("C42", misValue).Formula = BusinessLayer.UserName_Full_Static.ToString();
                    //myExcelWorksheet.get_Range("C44", misValue).Formula = Get_Employee_Details(BusinessResources.USER_TYPE_INCHARGE);
                    //myExcelWorksheet.get_Range("C46", misValue).Formula = Get_Employee_Details(BusinessResources.USER_TYPE_OFFICER);
                    //myExcelWorksheet.get_Range("C48", misValue).Formula = objPC.EmployeeName.ToString();
                }

                myExcelWorkbook.Save();
                PDFReport = objRL.RL_DestinationPath.Replace(".xlsx", ".pdf");

                try
                {
                    const int xlQualityStandard = 0;
                    myExcelWorkbook.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, PDFReport, xlQualityStandard, true, false, Type.Missing, Type.Missing, false, Type.Missing);
                    myExcelWorkbook.Close(true, misValue, misValue);
                    myExcelApp.Quit();

                    //objRL.ShowMessage(22, 1);

                    //DialogResult dr;
                    //dr = MessageBox.Show("Do you want to view this report", "Report View", MessageBoxButtons.YesNo);
                    //if (dr == DialogResult.Yes)
                    //    System.Diagnostics.Process.Start(objRL.RL_DestinationPath);

                    if (objPC.FormName == "Letter")
                    {
                        objPC.FormName = "EmployeeMaster"; 
                        objPC.DocumentName = cmbMemoSubject.Text;

                        if (!objRL.CheckExist_Document_Letter())
                        {
                            int FormId= objQL.SP_FormMaster_Get_FormId();
                            DataSet dsDoc = new DataSet();

                            objBL.Query ="select DM.DocumentId,DM.FormId,FM.FormName,DM.DocumentName from documentmaster DM inner join formmaster FM on DM.FormId=DM.FormId	where DM.CancelTag=0 and FM.CancelTag=0 and	DM.DocumentName='"+objPC.DocumentName+"' and FM.FormId="+FormId+"";

                            dsDoc = objBL.ReturnDataSet();
                            if (dsDoc.Tables[0].Rows.Count > 0)
                            {
                                objPC.DocumentId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dsDoc.Tables[0].Rows[0]["DocumentId"])));
                            }

                            objPC.DocumentName = cmbMemoSubject.Text;
                            objPC.DocumentName = objPC.DocumentName + ".pdf";
                            objBL.Query = "insert into uploaddocuments(EntryDate,FormId,TableId,DocumentId,DocumentName) values('" + dtpEntryDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'," + FormId + "," + objPC.EmployeeId + "," + objPC.DocumentId + ",'"+objPC.DocumentName+"')";
                            int Result= objBL.Function_ExecuteNonQuery();

                            
                        }
                        objPC.FormName = "Letter";
                    }

                    System.Diagnostics.Process.Start(PDFReport);
                    //System.Diagnostics.Process.Start(objRL.RL_DestinationPath);
                    //objRL.DeleteExcelFile();

                    //if (!string.IsNullOrEmpty(objRL.EmailId) && cbEmail.Checked)
                    //{
                    //    objRL.EmailId_RL = cbEmail.Text;
                    //    objRL.Subject_RL = "Amount Collection Report";
                    //    //string body = "<div><p>Dear " + objRL.CustomerName_Customer + " <p/><br/> <p>Please find attachment of pdf file.</p><br/><p>Thanks,</p><br/><p>" + objRL.CI_CompanyName + "</p></div>";
                    //    string body = "<div><p>Dear Sir,<p/><p>Please find attachment of pdf file.</p><p>Sale Invoice on " + dtpDate.Value.ToString(BusinessResources.DATEFORMATDDMMYYYY) + "- Invoice No- " + txtBillID.Text + " </p><p>Thanks,</p></div>";

                    //    objRL.Body_RL = body;// "Dear " + RedundancyLogics.SupplierName + ", " + System.Environment.NewLine + " PFA..!" + System.Environment.NewLine + " Thanks, " + System.Environment.NewLine + " " + objRL.CompanyName;
                    //    objRL.FilePath_RL = PDFReport;
                    //    objRL.SendEMail();
                    //}

                    //if (cbEmail.Checked)
                    //{
                    //    objRL.EmailId_RL = "";
                    //    objRL.Subject_RL = "";
                    //    objRL.Body_RL = "";
                    //    objRL.FilePath_RL = PDFReport;
                    //    //objRL.SendEMail();
                    //}
                }
                catch (Exception ex1)
                {
                    objRL.ShowMessage(27, 4);
                    return;
                }

                //ViewReportW objForm = new ViewReportW(ds, "MEMO");
                //objForm.Show();
            }
        }

        string EmployeeConcat = string.Empty;

        private string Get_Employee_Details(string Designation)
        {
            string EmpName = string.Empty;
            string ColumnName = string.Empty;
            DataSet ds = new DataSet();

            if (Designation == BusinessResources.USER_TYPE_OFFICER)
                ColumnName = "LWD.PlantHeadId ";
            else if (Designation == BusinessResources.USER_TYPE_INCHARGE)
                ColumnName = "LWD.InchargeId ";
            else
                ColumnName = "";

            objBL.Query = "select E.EmployeeId,E.EmployeeCode,E.EmployeeName from " +
                          " locationwisedepartmentusers LWD inner join " +
                          " Employees E on E.EmployeeId=" + ColumnName + " inner join designationmaster dm on dm.DesignationId=E.DesignationId " +
                          " where E.CancelTag=0 and dm.Designation='" + Designation + "' and LWD.LocationId=" + objPC.LocationId + " and LWD.DepartmentId=" + objPC.DepartmentId + "";

            //objBL.Query = "select E.EmployeeId,E.EmployeeCode,E.EmployeeName from "+
            //              "Employees E inner join LocationMaster L on L.LocationId=E.LocationId inner join departmentmaster D on D.DepartmentId=E.DepartmentId inner join designationmaster DM on DM.DesignationId=E.DesignationId "+
            //              " where E.CancelTag=0 and L.CancelTag=0 and D.CancelTag=0 and DM.CancelTag=0 and DM.Designation IN('" + Designation + "') and E.LocationId=" + objPC.LocationId + " and E.DepartmentId=" + objPC.DepartmentId + "";

            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
            {
                EmpName = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["EmployeeName"]));
            }

            return EmpName;
        }

        private void cmbLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ClearAll();
            objRL.FillDepartment(cmbLocation, cmbDepartment);
        }

        private void cmbDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FillEmployee_Fixed();
        }

        private void cmbEmployeeName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_EmployeeDetails();

        }

        private void txtFine_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.NumericValue(sender, e, txtFine);
        }


        private void New_Word_Format_Report()
        {

        }

        public string CreateMemoDocx(string filePath)
        {
            String T1 = Convert.ToString(rtbTemplate.Text);

            using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(filePath, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
            {
                var mainPart = wordDoc.AddMainDocumentPart();
                mainPart.Document = new Document();
                var body = new Body();

                // MEMO NUMBER (Left Aligned)
                Paragraph memoNumPara = new Paragraph(new Run(new Text($"Memo No: {1}")));
                memoNumPara.ParagraphProperties = new ParagraphProperties(new Justification() { Val = JustificationValues.Right });
                body.Append(memoNumPara);

               // string Memo= 
                // DATE (Right Aligned)
                Paragraph datePara = new Paragraph(new Run(new Text($"Date: {dtpEntryDate.Value.ToString("dd/MM/yyyy")}")));
                datePara.ParagraphProperties = new ParagraphProperties(new Justification() { Val = JustificationValues.Right });
                body.Append(datePara);

                // Empty line
                body.Append(new Paragraph(new Run(new Text(" "))));

                Paragraph dateParaSubject = new Paragraph(new Run(new Text($"{cmbMemoSubject.Text.ToString()}")));
                datePara.ParagraphProperties = new ParagraphProperties(new Justification() { Val = JustificationValues.Center });
                body.Append(dateParaSubject);

                // MAIN PARAGRAPH (Justified)
                Paragraph bodyPara = new Paragraph();
                Run bodyRun = new Run(new Text(rtbTemplate.Text.ToString()) { Space = SpaceProcessingModeValues.Preserve }); // Preserve line breaks
                bodyPara.Append(bodyRun);
                bodyPara.ParagraphProperties = new ParagraphProperties(new Justification() { Val = JustificationValues.Both });
                body.Append(bodyPara);

                

                Paragraph dateParaSubject2 = new Paragraph(new Run(new Text($"{cmbMemoSubject.Text.ToString()}")));
                datePara.ParagraphProperties = new ParagraphProperties(new Justification() { Val = JustificationValues.Center });
                body.Append(dateParaSubject2);

                mainPart.Document.Append(body);
                mainPart.Document.Save();

                //for (int i = 1; i <= 3; i++)
                //{

                //    body.Append(new Paragraph(new Run(new Text($"This is page {T1} of the memo/letter."))));

                //    if (i < 3)
                //    {
                //        body.Append(new Paragraph(new Run(new Break() { Type = BreakValues.Page })));
                //    }
                //}

                //mainPart.Document.Append(body);
                //mainPart.Document.Save();
            }

            return filePath;
        }
    }
}
