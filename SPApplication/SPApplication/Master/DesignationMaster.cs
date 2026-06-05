using BusinessLayerUtility;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPApplication.HR
{
    public partial class DesignationMaster : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0;

        public DesignationMaster()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_DESIGNATIONMASTER);
            objRL.Get_UserRights_By_MenuName(BusinessResources.LBL_HEADER_MASTER);

            objRL.ColumnNameCM = "DesignationCategory";
            objRL.Fill_ComboBox_Comman(cmbDesignationCategory);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            objEP.Clear();
            txtDesignation.Text = "";
            txtSearch.Text = "";
            cmbGrade.SelectedIndex = -1;
            FlagDelete = false;
            btnDelete.Enabled = false;
            cmbDesignationCategory.SelectedIndex = -1;
            cbOTApplicable.Checked = false;
            txtLeave.Text = "";
            OTApplicable = 0;
        }

        private void txtDesignationId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtDesignation.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (objPC.AddFlag == 1)
            {
                try
                {
                    FlagDelete = false;
                    SaveDB();
                }
                catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
                finally { GC.Collect(); }
            }
            else
            {
                objRL.ShowMessage(24, 4);
                return;
            }
        }

        private bool Validation()
        {
            if (txtDesignation.Text == "")
            {
                txtDesignation.Focus();
                objEP.SetError(txtDesignation, "Enter Designation");
                return false;
            }
            else if (cmbGrade.SelectedIndex == -1)
            {
                cmbGrade.Focus();
                objEP.SetError(cmbGrade, "Select Grade");
                return false;
            }
            else if (cmbDesignationCategory.SelectedIndex == -1)
            {
                cmbDesignationCategory.Focus();
                objEP.SetError(cmbDesignationCategory, "Select Designation Category");
                return false;
            }
            //else if (txtLeave.Text == "")
            //{
            //    txtLeave.Focus();
            //    objEP.SetError(txtLeave, "Select Leave");
            //    return false;
            //}
            else
                return false;
        }

        private void Designation_Master_Load(object sender, EventArgs e)
        {
            ClearAll();
            FillGrid();
        }

        protected void SaveDB()
        {
            if (!Validation())
            {
                objPC.DesignationId = TableId;
                objPC.Designation = txtDesignation.Text;
                objPC.Grade = cmbGrade.Text;
                objPC.DesignationCategory = cmbDesignationCategory.Text;

                if(txtLeave.Text !="")
                    objPC.LeaveCountDesignation =  txtLeave.Text;
                else
                    objPC.LeaveCountDesignation = "0";

                objPC.OTApplicable = OTApplicable;
                objPC.UserId = BusinessLayer.LoginId_Static;
                objPC.DeleteFlag = FlagDelete;

                if (!FlagDelete)
                {
                    if (CheckExist())
                    {
                        objRL.ShowMessage(12, 4);
                        return;
                    }
                }
                Result = objQL.SP_DesignationMaster_Insert_Update_Delete();
                if (Result > 0)
                {
                    if (!FlagDelete)
                        objRL.ShowMessage(7, 1);
                    else
                        objRL.ShowMessage(9, 1);

                    FillGrid();
                    ClearAll();
                }
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }

        protected void FillGrid()
        {
            lblTotalCount.Text = "";
            dataGridView1.DataSource = null;
            DataSet ds = new DataSet();
            objPC.Designation = txtSearch.Text;

            if (!SearchFlag)
                objPC.SearchFlag = false;
            else
                objPC.SearchFlag = true;

            ds = objQL.SP_DesignationMaster_FillGrid();

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTotalCount.Text = "Total-" + ds.Tables[0].Rows.Count;
                //0 ContryId,
                //1 ContryName as 'Contry Name', 
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Width = 400;
                dataGridView1.Columns[2].Width = 100;
            }
        }

        protected bool CheckExist()
        {
            DataSet ds = new DataSet();
            ds = objQL.SP_DesignationMaster_CheckExist();
            if (ds.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (objPC.ViewFlag == 1)
            {
                try
                {
                    RowCount_Grid = dataGridView1.Rows.Count;
                    CurrentRowIndex = dataGridView1.CurrentRow.Index;

                    if (RowCount_Grid >= 0 && CurrentRowIndex >= 0)
                    {
                        ClearAll();
                        //0 ContryId,
                        //1 ContryName as 'Contry Name', 

                        btnDelete.Enabled = true;
                        TableId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                        txtDesignation.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        cmbGrade.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        cmbDesignationCategory.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                        txtLeave.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value));
                        OTApplicable = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[5].Value)));

                        if (OTApplicable == 1)
                            cbOTApplicable.Checked = true;

                        //cmbGrade.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
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
            else
            {
                objRL.ShowMessage(24, 4);
                return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (objPC.DeleteFlagUR == 1)
            {
                try
                {
                    DialogResult dr = objRL.Delete_Record_Show_Message();
                    if (dr == System.Windows.Forms.DialogResult.Yes)
                    {
                        FlagDelete = true;
                        SaveDB();
                    }
                }
                catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
                finally { GC.Collect(); }
            }
            else
            {
                objRL.ShowMessage(24, 4);
                return;
            }
        }


        int OTApplicable = 0;
        private void cbOTApplicable_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOTApplicable.Checked)
                OTApplicable = 1;
            else
                OTApplicable = 0;
        }

        private void txtLeave_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtLeave);
        }
    }
}
