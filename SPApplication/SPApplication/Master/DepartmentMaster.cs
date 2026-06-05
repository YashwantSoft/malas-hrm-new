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
    public partial class DepartmentMaster : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0;

        public DepartmentMaster()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_DEPARTMENTMASTER);
            objRL.Get_UserRights_By_MenuName(BusinessResources.LBL_HEADER_MASTER);
            //objQL.Fill_Master_ComboBox(cmbLocation, "locationmaster");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
            //cmbLocation.SelectedIndex = -1;
        }

        private void ClearAll()
        {
            objEP.Clear();

            txtDepartmentName.Text = "";
            txtInchargeName.Text = "";
            txtContactPerson.Text = "";
            txtExtensionNo.Text = "";
            txtMobileNumber.Text = "";
            txtEmailId.Text = "";
            txtDescription.Text = "";
            txtSearch.Text = "";
            FlagDelete = false;
            btnDelete.Enabled = false;
            txtDepartmentName.Focus();
        }

        private void txtDepartmentID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtDepartmentName.Focus();
        }

        private void txtDepartmentName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtInchargeName.Focus();
        }

        private void txtHODName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtContactPerson.Focus();
        }

        private void txtContactPerson_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtExtensionNo.Focus();

        }

        private void txtExtensionNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtMobileNumber.Focus();
        }

        private void txtMobileNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtDescription.Focus();
        }


        private bool Validation()
        {
            if (txtDepartmentName.Text == "")
            {
                txtDepartmentName.Focus();
                objEP.SetError(txtDepartmentName, "Enter Department Name");
                return false;
            }
            //else if (txtInchargeName.Text == "")
            //{
            //    txtInchargeName.Focus();
            //    objEP.SetError(txtInchargeName, "Enter HOD");
            //    return false;
            //}
            //else if (txtContactPerson.Text == "")
            //{
            //    txtContactPerson.Focus();
            //    objEP.SetError(txtContactPerson, "Enter Contact Person ");
            //    return false;
            //}
            //else if (txtExtensionNo.Text == "")
            //{
            //    txtExtensionNo.Focus();
            //    objEP.SetError(txtExtensionNo, "Enter Extension Number");
            //    return false;
            //}
            //else if (txtMobileNumber.Text == "")
            //{
            //    txtMobileNumber.Focus();
            //    objEP.SetError(txtMobileNumber, "Enter Mobile Number");
            //    return false;
            //}
            //else if (txtDescription.Text == "")
            //{
            //    txtDescription.Focus();
            //    objEP.SetError(txtDescription, "Enter Description");
            //    return false;
            //}
            else
                return false;
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

        protected void SaveDB()
        {
            if (!Validation())
            {
                objPC.DepartmentId = TableId;
                objPC.Department = txtDepartmentName.Text;
                objPC.InchargeName = txtInchargeName.Text;
                objPC.ContactPerson = txtContactPerson.Text;

                if (!string.IsNullOrEmpty(txtMobileNumber.Text))
                    objPC.MobileNumber = txtMobileNumber.Text;
                else
                    objPC.MobileNumber = "0";


                objPC.EmailId = txtEmailId.Text;

                if (!string.IsNullOrEmpty(txtExtensionNo.Text))
                    objPC.ExtensionNo = Convert.ToInt32(txtExtensionNo.Text);
                else
                    objPC.ExtensionNo = 0;

                objPC.Description = txtDescription.Text;
                objPC.UserId = BusinessLayer.LoginId_Static;
                objPC.DeleteFlag = FlagDelete;
                Result = objQL.SP_DepartmentMaster_Insert_Update_Delete();
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
            dataGridView1.DataSource = null;
            DataSet ds = new DataSet();
            objPC.Department = txtSearch.Text;

            if (!SearchFlag)
                objPC.SearchFlag = false;
            else
                objPC.SearchFlag = true;

            ds = objQL.SP_DepartmentMaster_FillGrid();
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTotalCount.Text = "Total-" + ds.Tables[0].Rows.Count;
                //0 D.LocationId,
                //1 LM.LocationName as 'Location Name',
                //2 D.DepartmentId,
                //3 D.Department,
                //4 D.InchargeName as 'Incharge Name', 
                //5 D.ContactPerson as 'Contact Person', 
                //6 D.MobileNumber as 'Mobile Number', 
                //7 D.EmailId, 
                //8 D.ExtensionNo, 
                //9 D.Description

                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                //dataGridView1.Columns[7].Visible = false;
               // dataGridView1.Columns[8].Visible = false;

                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    dataGridView1.Columns[i].Width = 250;
                }
            }
        }

        private void Department_Master_Load(object sender, EventArgs e)
        {
            ClearAll();
            FillGrid();
        }

        private void lbDescription_Click(object sender, EventArgs e)
        {

        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

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

                        //0 D.LocationId,
                        //1 LM.LocationName as 'Location Name',
                        //2 D.DepartmentId,
                        //3 D.Department,
                        //4 D.InchargeName as 'Incharge Name', 
                        //5 D.ContactPerson as 'Contact Person', 
                        //6 D.MobileNumber as 'Mobile Number', 
                        //7 D.EmailId, 
                        //8 D.ExtensionNo, 
                        //9 D.Description

                        btnDelete.Enabled = true;
                        TableId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                        txtDepartmentName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtInchargeName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        txtContactPerson.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                        txtMobileNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                        txtEmailId.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                        txtExtensionNo.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                        txtDescription.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
                SearchFlag = true;
            else
                SearchFlag = false;

            FillGrid();
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

        private void txtMobileNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.NumericValue(sender, e, txtMobileNumber);
        }

        private void txtExtensionNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.NumericValue(sender, e, txtExtensionNo);
        }
    }
}
