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
    public partial class ManpowerRequisition : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0;

        string FormName = string.Empty;
        int FormId = 0;

        public ManpowerRequisition()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_MANPOWER_REQUISITION_FORM);
            txtRequestedBy.Text = BusinessLayer.UserName_Full_Static.ToString();
            txtDepartment.Text = BusinessLayer.Department.ToString();
            objQL.Fill_Master_ComboBox(cmbDesignation, "designationmaster");
            objRL.FillLocation(cmbLocation, cmbDepartment);
            objRL.Fill_Status_For_Manpower(cmbStatus);
        }

        private void Status_Lock()
        {
             if (BusinessLayer.UserType == BusinessResources.USER_TYPE_SENIOROFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER || BusinessLayer.UserType == BusinessResources.USER_TYPE_PLANTHEAD)
             {
                 cmbStatus.Text="Pending";
                 cmbStatus.Enabled=false;
                 gbReply.Enabled=false;
             }
             else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_HROFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR)
             {
                 //cmbStatus.Text = "Pending";
                 cmbStatus.Enabled = true;
                 gbReply.Enabled = true;
             }
             else
             {
                 cmbStatus.Text = "Pending";
                 cmbStatus.Enabled = false;
                 gbReply.Enabled = false;
             }
        }

        private void ManpowerRequirements_Load(object sender, EventArgs e)
        {
            ClearAll();
            FillGrid();
            Status_Lock();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private bool Validation()
        {
            objEP.Clear();
            if (cmbLocation.SelectedIndex ==-1)
            {
                cmbLocation.Focus();
                objEP.SetError(cmbLocation, "Enter Location");
                return true;
            }
            else if (cmbDepartment.SelectedIndex == -1)
            {
                cmbDepartment.Focus();
                objEP.SetError(cmbDepartment, "Enter Department");
                return true;
            }
            else if (txtReasonOfRequest.Text == "")
            {
                txtReasonOfRequest.Focus();
                objEP.SetError(txtReasonOfRequest, "Enter Reason of Request");
                return true;
            }
            else if (dgv.Rows.Count == 0)
            {
                dgv.Focus();
                objEP.SetError(dgv, "Add Manpower Requirements");
                return true;
            }
            else if (txtRemarks.Text == "")
            {
                txtRemarks.Focus();
                objEP.SetError(txtRemarks, "Enter Remarks");
                return true;
            }
            else if (cmbStatus.SelectedIndex == -1)
            {
                cmbStatus.Focus();
                objEP.SetError(cmbStatus, "Enter Reason of Request");
                return true;
            }
            else
                return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Validation())
            {
                objPC.EntryDate = dtpDateOfRequisition.Value;
                objPC.LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
                objPC.DepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue);
                objPC.InchargeId = BusinessLayer.EmployeeLoginId_Static;
                objPC.DateOfRequisition = dtpDateOfRequisition.Value;
                objPC.ExpectedDate = dtpExpectedDate.Value;
                objPC.ReasonOfRequest = txtReasonOfRequest.Text;
                objPC.Remarks = txtRemarks.Text;
                objPC.Status = cmbStatus.Text;
                objPC.Reply = txtReply.Text;

                Result = objQL.SP_Manpower_Insert_Update_Delete();

                if (Result > 0)
                {
                    if (TableId != 0)
                    {
                        objBL.Query = "delete from manpowerrequirements where ManpowerId=" + TableId + "";
                        int R= objBL.Function_ExecuteNonQuery();
                    }

                    //Manpower Requiremtns
                    if (TableId == 0)
                    {
                        int IdT=0;
                        objBL.Query = "select max(ManpowerId) from Manpower";
                        DataSet dsN = new DataSet();
                        dsN = objBL.ReturnDataSet();
                        if (dsN.Tables[0].Rows.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(dsN.Tables[0].Rows[0][0].ToString())))
                                IdT = Convert.ToInt32(dsN.Tables[0].Rows[0][0].ToString());
                        }

                        if (IdT == 0)
                            TableId = 1;
                        else
                            TableId = IdT;
                    }

                    if (dgv.Rows.Count > 0)
                    {
                        objPC.ManpowerId = TableId;

                        for (int i = 0; i < dgv.Rows.Count; i++)
                        {
                            if(!string.IsNullOrEmpty(Convert.ToString(dgv.Rows[i].Cells[1].Value)))
                                objPC.DesignationId = Convert.ToInt32(dgv.Rows[i].Cells[1].Value);

                            if(!string.IsNullOrEmpty(Convert.ToString(dgv.Rows[i].Cells[3].Value)))
                                objPC.NoOfCandidates = Convert.ToString(dgv.Rows[i].Cells[3].Value);

                            if(!string.IsNullOrEmpty(Convert.ToString(dgv.Rows[i].Cells[4].Value)))
                                objPC.Skill = Convert.ToString(dgv.Rows[i].Cells[4].Value);

                            if(!string.IsNullOrEmpty(Convert.ToString(dgv.Rows[i].Cells[5].Value)))
                                objPC.Gender = Convert.ToString(dgv.Rows[i].Cells[5].Value);

                            Result = objQL.SP_ManpowerRequirements_Save();
                        }
                    }

                    ClearAll();
                    FillGrid();
                }
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

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        static int DataGridIndex;

        private bool Validation_Manapower()
        {
            objEP.Clear();
            if (txtReasonOfRequest.Text == "")
            {
                txtReasonOfRequest.Focus();
                objEP.SetError(txtReasonOfRequest, "Enter Reason of Request");
                return true;
            }
            else if (cmbDesignation.SelectedIndex == -1)
            {
                cmbDesignation.Focus();
                objEP.SetError(cmbDesignation, "Select Designation");
                return true;
            }
            else if (txtNoOfCandidates.Text == "")
            {
                txtNoOfCandidates.Focus();
                objEP.SetError(txtNoOfCandidates, "Enter No of Candidates");
                return true;
            }
            else if (txtSkillQualification.Text == "")
            {
                txtSkillQualification.Focus();
                objEP.SetError(txtSkillQualification, "Enter Skill Qualification");
                return true;
            }
            else if (cmbGender.SelectedIndex == -1)
            {
                cmbGender.Focus();
                objEP.SetError(cmbGender, "Select Gender");
                return true;
            }
            else
                return false;
        }

        private void Add_Manpower_Requrements()
        {
            if (!Validation_Manapower())
            {
                if (dgv.Rows.Count > 0)
                    DataGridIndex = dgv.Rows.Count;
                else
                    DataGridIndex = 0;

                dgv.Rows.Add();
                dgv.Rows[DataGridIndex].Cells["clmDesignationId"].Value = cmbDesignation.SelectedValue.ToString();
                dgv.Rows[DataGridIndex].Cells["clmDesignation"].Value = cmbDesignation.Text.ToString();
                dgv.Rows[DataGridIndex].Cells["clmNoOfCandidates"].Value = txtNoOfCandidates.Text.ToString();
                dgv.Rows[DataGridIndex].Cells["clmSkill"].Value = txtSkillQualification.Text.ToString();
                dgv.Rows[DataGridIndex].Cells["clmGender"].Value = cmbGender.Text.ToString();
                dgv.Rows[DataGridIndex].Cells["clmDelete"].Value = "Delete";
                DataGridIndex++;
                FillSRNO(dgv);
                ClearAllGridItem();
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }

        private void ClearAllGridItem()
        {
            DataGridIndex = 0;
            cmbDesignation.SelectedIndex = -1;
            txtNoOfCandidates.Text = "";
            txtSkillQualification.Text = "";
            cmbGender.SelectedIndex = -1;
        }

        int SrNo = 1;

        private void FillSRNO(DataGridView dgv)
        {
            SrNo = 1;
            if (dgv.Rows.Count > 0)
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    dgv.Rows[i].Cells[0].Value = SrNo.ToString();
                    SrNo++;
                }
            }
        }

        private void btnAddGrid_Click(object sender, EventArgs e)
        {
            Add_Manpower_Requrements();
        }

        private void btnClearGrid_Click(object sender, EventArgs e)
        {
            ClearAllGridItem();
        }
       
        private void ClearAll()
        {
            objEP.Clear();
            TableId = 0;
            dtpDateOfRequisition.Value = DateTime.Now.Date;
            dtpExpectedDate.Value = DateTime.Now.Date;
            txtReasonOfRequest.Text = "";
            dgv.DataSource = null;
            txtRemarks.Text = "";
            ClearAllGridItem();
            dgv.Rows.Clear();
            DataGridIndex = 0;
            gbReply.Enabled = false;
            cmbLocation.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
            txtReply.Text = "";
            cmbStatus.Text = "Pending";
            dtpDateOfRequisition.Focus();
        }
     
        private void txtNoOfCandidates_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.NumericValue(sender, e, txtNoOfCandidates);
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.CurrentCell.ColumnIndex == 6)
            {
                DialogResult dr;
                dr = objRL.Delete_Record_Show_Message();
                if (dr == DialogResult.Yes)
                {
                    dgv.Rows.RemoveAt(e.RowIndex);
                    FillSRNO(dgv);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
                SearchFlag = true;
            else
                SearchFlag = false;

            FillGrid();
        }

        int Pending_Count = 0, Completed_Count = 0, Remarks_Count = 0, Reject_Count = 0;

        protected void FillGrid1()
        {
            lblTotalCount.Text = "";
            dataGridView1.DataSource = null;
            DataSet ds = new DataSet();
            objPC.ReasonOfRequest = txtSearch.Text;

            if (!SearchFlag)
                objPC.SearchFlag = false;
            else
                objPC.SearchFlag = true;

            ds = objQL.SP_Manpower_FillGrid();

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTotalCount.Text = "Total-" + ds.Tables[0].Rows.Count;
                //0 M.ManapowerId,
                //1 M.EntryDate, 
                //2 M.LocationId, 
                //3 L.LocationName as 'Location Name',
                //4 M.DepartmentId, 
                //5 D.Department,
                //6 M.InchargeId, 
                //7 E.EmployeeName as 'Raised Request by',
                //8 M.DateOfRequisition, 
                //9 M.ExpectedDate, 
                //10 M.ReasonOfRequest,
                //11 M.Remarks,
                //12 M.Status, 
				//13 M.Reply

                dataGridView1.DataSource = ds.Tables[0];
                
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[2].Visible = false; 
                //dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                

                dataGridView1.Columns[1].Width = 120;
                dataGridView1.Columns[3].Width = 150;
                dataGridView1.Columns[5].Width = 120;
                dataGridView1.Columns[7].Width = 200;
                dataGridView1.Columns[8].Width = 120;
                dataGridView1.Columns[9].Width = 100;
                dataGridView1.Columns[10].Width = 100;
                dataGridView1.Columns[11].Width = 100;


                string AStatus = string.Empty;
                Pending_Count = 0; Completed_Count = 0; Remarks_Count = 0; Reject_Count = 0;
                foreach (DataGridViewRow Myrow in dataGridView1.Rows)
                {
                    AStatus = string.Empty;
                    //Here 2 cell is target value and 1 cell is Volume
                    if (!string.IsNullOrEmpty(Convert.ToString(Myrow.Cells[12].Value)))
                        AStatus = Convert.ToString(Myrow.Cells[12].Value);

                    if (AStatus == BusinessResources.LS_Pending)
                    {
                        Pending_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Pending_Color);
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

                    lblPending.Text = BusinessResources.LS_Pending + "-" + Pending_Count.ToString();
                    lblCompleted.Text = BusinessResources.LS_ManagerApproved + "-" + Completed_Count.ToString();
                    lblRemark.Text = BusinessResources.LS_Remarks + "-" + Remarks_Count.ToString();
                    lblReject.Text = BusinessResources.LS_Reject + "-" + Reject_Count.ToString();
                    dataGridView1.ClearSelection();
                }
            }
        }

        string MainQuery = string.Empty;
        string WhereClause = string.Empty;
        string WhereBasic = string.Empty;
        string OrderBy = string.Empty;

        protected void FillGrid()
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

            MainQuery = "Select "+
				"M.ManpowerId,"+
				"M.EntryDate as 'Date', "+
				"M.LocationId, "+
                "LM.LocationName as 'Location Name'," +
				"M.DepartmentId, "+
                "DM.Department," +
				"M.InchargeId, "+
                "E.EmployeeName as 'Raised Request by',"+
				"M.DateOfRequisition as 'Date of Requisition', "+
				"M.ExpectedDate as 'Expected Date',"+
				"M.ReasonOfRequest  as 'Reason of Request',"+
				"M.Remarks,"+
                "M.Status, "+
				"M.Reply "+
			"from "+
				"Manpower M inner join "+
                "locationmaster LM on LM.LocationId=M.LocationId inner join "+
                "departmentmaster DM on DM.DepartmentId=M.DepartmentId inner join "+
                "employees E on E.EmployeeId=M.InchargeId inner join locationwisedepartmentusers LWDU on LM.LocationId=LWDU.LocationId and DM.DepartmentId=LWDU.DepartmentId ";

            WhereBasic = " where M.CancelTag=0 and LM.CancelTag=0 and DM.CancelTag=0 and E.CancelTag=0  and LWDU.CancelTag=0 ";
            OrderBy = " order by M.DateOfRequisition asc";

            objBL.Query = MainQuery + WhereBasic + objRL.WhereClasuse_CompOff_Comman() + WhereClause + OrderBy;
            ds = objBL.ReturnDataSet();

            
            //objPC.ReasonOfRequest = txtSearch.Text;

            //if (!SearchFlag)
            //    objPC.SearchFlag = false;
            //else
            //    objPC.SearchFlag = true;

            //ds = objQL.SP_Manpower_FillGrid();

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTotalCount.Text = "Total-" + ds.Tables[0].Rows.Count;
                //0 M.ManapowerId,
                //1 M.EntryDate, 
                //2 M.LocationId, 
                //3 L.LocationName as 'Location Name',
                //4 M.DepartmentId, 
                //5 D.Department,
                //6 M.InchargeId, 
                //7 E.EmployeeName as 'Raised Request by',
                //8 M.DateOfRequisition, 
                //9 M.ExpectedDate, 
                //10 M.ReasonOfRequest,
                //11 M.Remarks,
                //12 M.Status, 
                //13 M.Reply

                dataGridView1.DataSource = ds.Tables[0];

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                //dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[6].Visible = false;


                dataGridView1.Columns[1].Width = 120;
                dataGridView1.Columns[3].Width = 150;
                dataGridView1.Columns[5].Width = 120;
                dataGridView1.Columns[7].Width = 200;
                dataGridView1.Columns[8].Width = 120;
                dataGridView1.Columns[9].Width = 100;
                dataGridView1.Columns[10].Width = 100;
                dataGridView1.Columns[11].Width = 100;
                dataGridView1.Columns[12].Width = 100;
                dataGridView1.Columns[13].Width = 100;

                string AStatus = string.Empty;
                Pending_Count = 0; Completed_Count = 0; Remarks_Count = 0; Reject_Count = 0;
                foreach (DataGridViewRow Myrow in dataGridView1.Rows)
                {
                    AStatus = string.Empty;
                    //Here 2 cell is target value and 1 cell is Volume
                    if (!string.IsNullOrEmpty(Convert.ToString(Myrow.Cells[12].Value)))
                        AStatus = Convert.ToString(Myrow.Cells[12].Value);

                    if (AStatus == BusinessResources.LS_Pending)
                    {
                        Pending_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Pending_Color);
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

                    lblPending.Text = BusinessResources.LS_Pending + "-" + Pending_Count.ToString();
                    lblCompleted.Text = BusinessResources.LS_ManagerApproved + "-" + Completed_Count.ToString();
                    lblRemark.Text = BusinessResources.LS_Remarks + "-" + Remarks_Count.ToString();
                    lblReject.Text = BusinessResources.LS_Reject + "-" + Reject_Count.ToString();
                    dataGridView1.ClearSelection();
                }
            }
        }

        private void Fill_ManpowerRequirements()
        {
            DataGridIndex = 0;
            dgv.Rows.Clear();
            DataSet ds = new DataSet();
            objPC.ManpowerId = TableId;
            ds = objQL.SP_ManpowerRequirements_FillGrid();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dgv.Rows.Add();

                    dgv.Rows[DataGridIndex].Cells["clmDesignationId"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["DesignationId"]));
                    dgv.Rows[DataGridIndex].Cells["clmDesignation"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["Designation"]));
                    dgv.Rows[DataGridIndex].Cells["clmNoOfCandidates"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["NoOfCandidates"]));
                    dgv.Rows[DataGridIndex].Cells["clmSkill"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["Gender"]));
                    dgv.Rows[DataGridIndex].Cells["clmGender"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["Skill"]));
                    dgv.Rows[DataGridIndex].Cells["clmDelete"].Value = "Delete";

                    //dgv.Rows[DataGridIndex].Cells[1].Value = ds.Tables[0].Rows[i]["DesignationId"].ToString();
                    //dgv.Rows[DataGridIndex].Cells[2].Value = ds.Tables[0].Rows[i]["Designation"].ToString();
                    //dgv.Rows[DataGridIndex].Cells[3].Value = ds.Tables[0].Rows[i]["NoOfCandidates"].ToString();
                    //dgv.Rows[DataGridIndex].Cells[4].Value = ds.Tables[0].Rows[i]["Gender"].ToString();
                    //dgv.Rows[DataGridIndex].Cells[5].Value = ds.Tables[0].Rows[i]["Skill"].ToString();
                    //dgv.Rows[DataGridIndex].Cells[6].Value = "Delete";
                    DataGridIndex++;
                }
                FillSRNO(dgv);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                RowCount_Grid = dataGridView1.Rows.Count;
                CurrentRowIndex = dataGridView1.CurrentRow.Index;

                if (RowCount_Grid >= 0 && CurrentRowIndex >= 0)
                {
                    //0 M.ManapowerId,
                    //1 M.EntryDate, 
                    //2 M.LocationId, 
                    //3 L.LocationName as 'Location Name',
                    //4 M.DepartmentId, 
                    //5 D.Department,
                    //6 M.InchargeId, 
                    //7 E.EmployeeName as 'Raised Request by',
                    //8 M.DateOfRequisition, 
                    //9 M.ExpectedDate, 
                    //10 M.ReasonOfRequest,
                    //11 M.Remarks 
                    //12 M.Status,
                    //13 M.Reply 

                    TableId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                    dtpDateOfRequisition.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[8].Value);
                    dtpExpectedDate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[9].Value);
                    txtReasonOfRequest.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                    txtRemarks.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                    Fill_ManpowerRequirements();
                    cmbStatus.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[12].Value));
                    txtReply.Text =objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[13].Value));

                    if (BusinessLayer.UserType == BusinessResources.USER_TYPE_HROFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR)
                    {
                        gbReply.Enabled = true;
                    }
                    else
                        gbReply.Enabled = false;

                    cmbLocation.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value));
                    objRL.FillDepartment(cmbLocation, cmbDepartment);
                    cmbDepartment.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[5].Value));

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

        private void cmbDesignation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtNoOfCandidates.Focus();
        }

        private void txtNoOfCandidates_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtSkillQualification.Focus();
        }

        private void txtSkillQualification_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbGender.Focus();
        }

        private void cmbGender_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAddGrid.Focus();
        }

        private void cmbLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtDepartment.Text = "";
            cmbDepartment.SelectedIndex = -1;
            cmbDepartment.DataSource = null;
            if (cmbLocation.SelectedIndex > -1)
                objRL.FillDepartment(cmbLocation, cmbDepartment);
        }

        private void cmbDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbDepartment.SelectedIndex > -1)
            {
                txtDepartment.Text = cmbDepartment.Text;
            }
        }

        private void cmbLocation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
