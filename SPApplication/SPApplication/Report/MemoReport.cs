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
    public partial class MemoReport : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();
        AttendanceLogics objAL = new AttendanceLogics();

        public MemoReport()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnView, btnClear, btnReport, btnExit, "Memo Report");
            btnView.Text = BusinessResources.BTN_VIEW;
            btnReport.Text = BusinessResources.BTN_REPORT;
            Fill_Data();
            ClearAll();
        }

        private void ClearAll()
        {
            dataGridView1.DataSource = null;
            cbSelectAllLocation.Checked = true;
            cbSelectAllDepartment.Checked = true;
            cbAttendanceDate.Checked = true;
            cbRoll.Checked = true;
            cbMemo.Checked = true;
            cbEmployeeName.Checked = true;
            dtpFromDate.Value = DateTime.Now.Date;
            dtpToDate.Value = DateTime.Now.Date;
            cmbLocation.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            cmbMonth.SelectedIndex = -1;
            cmbYear.SelectedIndex = -1;
            cmbRoll.SelectedIndex = -1;
            cmbMemoTemplate.SelectedIndex = -1;
            cmbEmployeeName.SelectedIndex = -1;
            txtDesignation.Text = "";
            txtEmployeeCode.Text = "";
            SetMonthYear();
        }

        private void Fill_Data()
        {
            objRL.Fill_Contractor_IN_Attendance(cmbRoll);
            objRL.FillLocation(cmbLocation, cmbDepartment);
            objRL.Fill_Memo_Template(cmbMemoTemplate);
            cbAttendanceDate.Checked = true;
        }

        private void MemoReport_Load(object sender, EventArgs e)
        {
            
        }

        private void cbMemo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMemo.Checked)
            {
                cmbMemoTemplate.SelectedIndex = -1;
                cmbMemoTemplate.Enabled = false;
            }
            else
            {
                cmbMemoTemplate.SelectedIndex = -1;
                cmbMemoTemplate.Enabled = true;
                cmbMemoTemplate.Focus();
            }
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

        private void MonthYear_Visible(bool FlagF)
        {
            lblMonth.Visible = FlagF;
            lblYear.Visible = FlagF;
            cmbMonth.Visible = FlagF;
            cmbYear.Visible = FlagF;

            //lblFromDate.Visible = FlagF;
            //dtpFromDate.Visible = FlagF;
            //lblToDate.Visible = FlagF;
            //dtpToDate.Visible = FlagF;

            if (!FlagF)
            {
                cmbMonth.SelectedIndex = -1;
                cmbYear.SelectedIndex = -1;

                lblFromDate.Visible = true;
                dtpFromDate.Visible = true;
                lblToDate.Visible = true;
                dtpToDate.Visible = true;
            }
            else
            {
                SetMonthYear();
                lblFromDate.Visible = false;
                dtpFromDate.Visible = false;
                lblToDate.Visible = false;
                dtpToDate.Visible = false;
            }
        }

        private void SetMonthYear()
        {
            string MonthName = objRL.GetMonthName(DateTime.Now.Date.Month);
            int YearNo = DateTime.Now.Year;

            cmbYear.Text = YearNo.ToString();
            cmbMonth.Text = MonthName.ToString();
        }

        private void cbRoll_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRoll.Checked)
            {
                cmbRoll.SelectedIndex = -1;
                cmbRoll.Enabled = false;
            }
            else
            {
                cmbRoll.SelectedIndex = -1;
                cmbRoll.Enabled = true;
                cmbRoll.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
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
                if (!cbAttendanceDate.Checked)
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
            }
            if (!FlagReturn)
            {
                if (!cbEmployeeName.Checked)
                {
                    if (cmbEmployeeName.SelectedIndex == -1)
                    {
                        cmbEmployeeName.Focus();
                        objEP.SetError(cmbEmployeeName, "Select Employee Name");
                        FlagReturn = true;
                    }
                    else
                        FlagReturn = false;
                }
            }
            if (!FlagReturn)
            {
                if (!cbRoll.Checked)
                {
                    if (cmbRoll.SelectedIndex == -1)
                    {
                        cmbRoll.Focus();
                        objEP.SetError(cmbRoll, "Select Roll");
                        FlagReturn = true;
                    }
                    else
                        FlagReturn = false;
                }
            }
            if (!FlagReturn)
            {
                if (!cbMemo.Checked)
                {
                    if (cmbMemoTemplate.SelectedIndex == -1)
                    {
                        cmbMemoTemplate.Focus();
                        objEP.SetError(cmbMemoTemplate, "Select Memo Template");
                        FlagReturn = true;
                    }
                    else
                        FlagReturn = false;
                }
            }

            return FlagReturn;
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

        string MainQuery = string.Empty, WhereClause = string.Empty,WhereBasic = string.Empty,OrderBy = string.Empty;


        string DateColumn = string.Empty, EmployeeIn = string.Empty, LeaveStatusIn = string.Empty, ContractorIn = string.Empty, StatusIn = string.Empty, DepartmentIn = string.Empty;
        int EmployeeId = 0;

        private void GetReport()
        {
            Fill_Grid();

            //dataGridView1.Rows.Clear();
            //MainQuery = string.Empty; WhereClause = string.Empty;

            //DataSet ds = new DataSet();
            //MainQuery = "select " +
            //             "E.EmployeeId, " +
            //             "E.DOB," +
            //             "E.EmployeeCode," +
            //             "E.EmpInital," +
            //             "E.EmployeeName, " +
            //             "CONCAT(E.EmpInital, ' ', E.EmployeeName) AS EmployeeConcat, " +
            //             "E.Gender, " +
            //             "E.Age, " +
            //             "E.MobileNo, " +
            //             "LM.LocationName," +
            //             "DM.Department," +
            //             "DESM.Designation," +
            //             "E.JobProfile, " +
            //             "CM.ContractorName," +
            //             "E.PersonalEmailID,   " +
            //             "E.DOJ, " +
            //             "ETM.EmployementType" +
            //        " from " +
            //            "Employees E inner join " +
            //            "contractormaster CM on CM.ContractorId=E.ContractorId inner join " +
            //            "employementtypemaster ETM on ETM.EmployementTypeId=E.EmployementTypeId inner join " +
            //            "departmentmaster DM on DM.DepartmentId=E.DepartmentId inner join " +
            //            "designationmaster DESM on DESM.DesignationId=E.DesignationId inner join " +
            //            "categories CT on CT.CategoryId=E.CategoryId inner join " +
            //            "locationmaster LM on LM.LocationId=E.LocationId  " +
            //        " where " +
            //            "E.CancelTag=0 and " +
            //            "CM.CancelTag=0 and " +
            //            "ETM.CancelTag=0 and " +
            //            "DM.CancelTag=0 and " +
            //            "DESM.CancelTag=0 and " +
            //            "CT.CancelTag=0 and " +
            //            "LM.CancelTag=0 ";

            //if (!cbSelectAllLocation.Checked)
            //    WhereClause += " and E.LocationId=" + cmbLocation.SelectedValue + "";
            ////else
            ////    WhereClause += " and " + objQL.Get_Location_Id("Location") + " ";

            //if (!cbSelectAllDepartment.Checked)
            //    WhereClause += " and E.DepartmentId=" + cmbDepartment.SelectedValue + "";
            ////else
            ////    WhereClause += " and " + objQL.Get_Location_Id("Department");

            //if (cbDateWise.Checked)
            //    WhereClause += " and DAY(E.DOB)=DAY('" + dtpSearchDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "') and MONTH(E.DOB)=MONTH('" + dtpSearchDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "')"; // and Month(E.DOB)=" + dtpSearchDate.Value.Month + ""; //.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'"; // E.DOB='" + dtpSearchDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' ";
            //else
            //    WhereClause += " and Month(E.DOB)=" + objRL.GetMonthNumber(cmbMonth.Text); // and Year(E.DOB)=" + cmbYear.Text + "";


            //OrderBy = " ORDER BY DAY(E.DOB) asc";
            ////OrderBy = " order by E.DOB ";

            //objBL.Query = MainQuery + WhereClause + OrderBy;
            //ds = objBL.ReturnDataSet();

            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    lblTotalCount.Text = "Total Count-" + ds.Tables[0].Rows.Count.ToString();

            //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //    {
            //        dataGridView1.Rows.Add();

            //        //dataGridView1.Rows[i].Cells["clmSrNo"].Value = SrNo.ToString();
            //        EmployeeId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmployeeId"])));
            //        dataGridView1.Rows[i].Cells["clmEmployeeId"].Value = EmployeeId; // objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmployeeCode"])));
            //        DateTime dtDob = Convert.ToDateTime(ds.Tables[0].Rows[i]["DOB"]);
            //        dataGridView1.Rows[i].Cells["clmDOB"].Value = dtDob.ToString(BusinessResources.DATEFORMATDDMMMYYYY);
            //        dataGridView1.Rows[i].Cells["clmEmployeeCode"].Value = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmployeeCode"])));
            //        dataGridView1.Rows[i].Cells["clmEmpInital"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmpInital"]));
            //        dataGridView1.Rows[i].Cells["clmEmployeeName"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmployeeName"]));
            //        dataGridView1.Rows[i].Cells["clmEmployeeConcat"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmployeeConcat"]));
            //        dataGridView1.Rows[i].Cells["clmGender"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["Gender"]));
            //        dataGridView1.Rows[i].Cells["clmAge"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["Age"]));
            //        dataGridView1.Rows[i].Cells["clmMobileNo"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["MobileNo"]));
            //        dataGridView1.Rows[i].Cells["clmLocation"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["LocationName"]));
            //        dataGridView1.Rows[i].Cells["clmDepartment"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["Department"]));
            //        dataGridView1.Rows[i].Cells["clmDesignation"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["Designation"]));
            //        dataGridView1.Rows[i].Cells["clmJobProfile"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["JobProfile"]));
            //        dataGridView1.Rows[i].Cells["clmRoll"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["ContractorName"]));
            //        dataGridView1.Rows[i].Cells["clmPersonalEmailID"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["PersonalEmailID"]));
            //        dataGridView1.Rows[i].Cells["clmDOJ"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["DOJ"]));
            //        dataGridView1.Rows[i].Cells["clmEmployementType"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmployementType"]));
            //        // dataGridView1.Sort(dataGridView1.Columns["clmDOB"], System.ComponentModel.ListSortDirection.Ascending);
            //        //SrNo++;
            //        dataGridView1.ClearSelection();
            //    }
            //    SrNo_Function();


            //    foreach (DataGridViewRow Myrow in dataGridView1.Rows)
            //    {

            //        //Here 2 cell is target value and 1 cell is Volume
            //        if (!string.IsNullOrEmpty(Convert.ToString(Myrow.Cells["clmDOB"].Value)))
            //            //DateTime dtDob = Convert.ToDateTime(ds.Tables[0].Rows[i]["clmDOB"]);
            //            dtDob1 = Convert.ToDateTime(Myrow.Cells["clmDOB"].Value);

            //        if (dtDob1.Date.Day == DateTime.Now.Date.Date.Day)
            //        {
            //            Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Completed_Color);
            //        }
            //    }
            //}
            //else
            //{
            //    //objRL.ShowMessage(35, 4);
            //    //return;
            //}
        }

        private void Fill_Grid()
        {
            dataGridView1.DataSource = null;
            DataSet ds = new DataSet();

            MainQuery = string.Empty;
            WhereClause = string.Empty;
            WhereBasic = string.Empty;
            OrderBy = string.Empty;

            if (cbAttendanceDate.Checked)
                WhereClause += " and M.EntryDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";
            else
                WhereClause += " and Month(M.EntryDate)=" + objRL.GetMonthNumber(cmbMonth.Text) + " and Year(M.EntryDate)=" + cmbYear.Text + "";

            if (!cbSelectAllLocation.Checked)
                WhereClause += " and E.LocationId=" + cmbLocation.SelectedValue + "";
            //else
            //    WhereClause += " and " + objQL.Get_Location_Id("Location") + " ";

            if (!cbSelectAllDepartment.Checked)
                WhereClause += " and E.DepartmentId=" + cmbDepartment.SelectedValue + "";
            //else
            //    WhereClause += " and " + objQL.Get_Location_Id("Department");

            if (!cbEmployeeName.Checked)
                WhereClause += " and E.EmployeeId=" + cmbEmployeeName.SelectedValue + "";

            if (!cbMemo.Checked)
                WhereClause += " and M.MemoTemplateMasterId=" + cmbMemoTemplate.SelectedValue + "";

            if (!cbRoll.Checked)
                WhereClause += " and E.ContractorId=" + cmbRoll.SelectedValue + "";

            MainQuery = "select " +
                     "M.MemoId," +
                     "M.EntryDate as 'Memo Date'," +
                     "DATE_FORMAT(M.EntryTime, '%H:%i') as 'Time'," +
                     "M.LocationId, " +
                     "L.LocationName as 'Location'," +
                     "M.DepartmentId, " +
                     "D.Department," +
                     "M.EmployeeId," +
                     "E.EmployeeCode as 'Emp Code'," +
                     "E.EmployeeName as 'Employee Name'," +
                     "M.MemoTemplateMasterId," +
                     "MTM.MemoSubject as 'Memo for'," +
                     "MTM.MemoTemplate as 'Template', " +
                     "M.MemoFine as 'Memo Fine', " +
                     "M.LetterType, " +
                     "M.LetterData, " +
                     "CM.ContractorName " +
                     "from " +
                     "memo M inner join Employees E on E.EmployeeId=M.EmployeeId inner join " +
                     "locationmaster L on L.LocationId=M.LocationId inner join " +
                     "departmentmaster D on D.DepartmentId=M.DepartmentId inner join " +
                     "memotemplatemaster MTM on MTM.MemoTemplateMasterId=M.MemoTemplateMasterId inner join " +
                     "locationwisedepartmentusers LWDU on L.LocationId = LWDU.LocationId and D.DepartmentId = LWDU.DepartmentId inner join " +
                     "contractormaster CM on CM.ContractorId=E.ContractorId ";

            WhereBasic = "where M.CancelTag=0 and L.CancelTag=0 and D.CancelTag=0 and E.CancelTag=0 and MTM.CancelTag=0 and M.LetterType='Memo'";
            OrderBy = " order by M.EntryDate asc";

            objBL.Query = MainQuery + WhereBasic + objRL.WhereClasuse_CompOff_Comman() + WhereClause + OrderBy;
            ds = objBL.ReturnDataSet();

            //0  "M.MemoId," +
            //1 "M.EntryDate as 'Memo Date'," +
            //2 "DATE_FORMAT(M.EntryTime, '%H:%i') as 'Time'," +
            //3 "M.LocationId, " +
            //4 "L.LocationName as 'Location'," +
            //5 "M.DepartmentId, " +
            //6 "D.Department," +
            //7 "M.EmployeeId," +
            //8 "E.EmployeeCode as 'Emp Code'," +
            //9 "E.EmployeeName as 'Employee Name'," +
            //10 "M.MemoTemplateMasterId," +
            //11 "MTM.MemoSubject as 'Memo for'," +
            //12 "MTM.MemoTemplate as 'Template', " +
            //13 "M.MemoFine as 'Memo Fine', " +
            //14 "M.LetterType, " +
            //15 "M.LetterData, " +
            //16 "CM.ContractorName " +

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
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                //dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[14].Visible = false;
                dataGridView1.Columns[15].Visible = false;

                //if (objPC.FormName == "Letter")
                //    dgv.Columns[12].Visible = false;

                dataGridView1.Columns[1].Width = 80;
                dataGridView1.Columns[2].Width = 60;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[6].Width = 100;
                dataGridView1.Columns[8].Width = 100;
                dataGridView1.Columns[9].Width = 200;
                dataGridView1.Columns[11].Width = 300;
                dataGridView1.Columns[13].Width = 60;
                dataGridView1.Columns[15].Width = 120;
            }
        }

        private void cmbLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbLocation.SelectedIndex > -1)
                objRL.FillDepartment(cmbLocation, cmbDepartment);
        }

        private void cmbDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
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
            }
        }

        private void cbEmployeeName_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEmployeeName.Checked)
            {
                txtDesignation.Text = "";
                txtEmployeeCode.Text = "";
                cmbEmployeeName.SelectedIndex = -1;
                cmbEmployeeName.Enabled = false;
            }
            else
            {
                cmbEmployeeName.SelectedIndex = -1;
                cmbEmployeeName.Enabled = true;
            }
        }

        private void cmbEmployeeName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_EmployeeDetails();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
    }
}
