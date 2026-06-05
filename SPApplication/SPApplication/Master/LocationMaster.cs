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
    public partial class LocationMaster : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        bool FlagDelete = false,  SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0;

        public LocationMaster()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_LOCATION);
            objRL.Get_UserRights_By_MenuName(BusinessResources.LBL_HEADER_MASTER);
        }
        private void GetTableId()
        {
            txtLocationId.Text = Convert.ToString(objQL.GetTableId("LocationId", "locationmaster"));
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
            TableId = 0;
            objEP.Clear();
            txtLocationId.Text = "";
            txtLocationName.Text = "";
            txtContactPerson.Text = "";
            txtExtensionNo.Text = "";
            txtMobileNumber.Text = "";
            txtDescription.Text = "";
            txtSearch.Text = "";
            GetTableId();
            FlagDelete = false;
            btnDelete.Enabled = false;
            txtLocationName.Focus();
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
            if (objPC.ViewFlag == 1)
            {
                try
                {
                    RowCount_Grid = dataGridView1.Rows.Count;
                    CurrentRowIndex = dataGridView1.CurrentRow.Index;

                    if (RowCount_Grid >= 0 && CurrentRowIndex >= 0)
                    {
                        ClearAll();
                        //0 LocationId,
                        //1 LocationName as 'Lacation Name', 
                        //2 Description, 
                        //3 ContactPerson as 'Contact Person',  
                        //4 MobileNumber as 'Mobile Number',  
                        //5 ExtensionNo as 'Extension Number'

                        btnDelete.Enabled = true;
                        TableId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                        txtLocationId.Text = TableId.ToString();
                        txtLocationName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtDescription.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        txtContactPerson.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                        txtMobileNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                        txtExtensionNo.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
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

        private void LocationMaster_Load(object sender, EventArgs e)
        {
            ClearAll();
            FillGrid();
        }

        private bool Validation()
        {
            if (txtLocationId.Text == "")
            {
                txtLocationId.Focus();
                objEP.SetError(txtLocationId, " Enter Location Id");
                return true;
            }
            else if (txtLocationName.Text == "")
            {
                txtLocationName.Focus();
                objEP.SetError(txtLocationName, "Enter Location Name");
                return true;
            }
            else if (txtContactPerson.Text == "")
            {
                txtContactPerson.Focus();
                objEP.SetError(txtContactPerson, "Enter Contact Person ");
                return true;
            }
            else if (txtExtensionNo.Text == "")
            {
                txtExtensionNo.Focus();
                objEP.SetError(txtExtensionNo, "Enter Extension Number");
                return true;
            }
            else if (txtMobileNumber.Text == "")
            {
                txtMobileNumber.Focus();
                objEP.SetError(txtMobileNumber, "Enter Mobile Number");
                return true;
            }
            else if (txtDescription.Text == "")
            {
                txtDescription.Focus();
                objEP.SetError(txtDescription, "Enter Description");
                return true;
            }
            else
                return false;
        }

        protected bool CheckExist()
        {
            DataSet ds = new DataSet();
            ds = objQL.SP_LocationMaster_CheckExist();
            if (ds.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }

        protected void SaveDB()
        {
            if (!Validation())
            {
                objPC.LocationId = TableId;
                objPC.LocationName = txtLocationName.Text;
                objPC.Description = txtDescription.Text;
                objPC.ContactPerson = txtContactPerson.Text;

                if (!string.IsNullOrEmpty(Convert.ToString(txtMobileNumber.Text)))
                    objPC.MobileNumber = txtMobileNumber.Text;
                else
                    objPC.MobileNumber = "0";

                if (!string.IsNullOrEmpty(Convert.ToString(txtExtensionNo.Text)))
                    objPC.ExtensionNo = Convert.ToInt32(txtExtensionNo.Text);
                else
                    objPC.ExtensionNo = 0;

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
                Result = objQL.SP_LocationMaster_Insert_Update_Delete();
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
            objPC.LocationName = txtSearch.Text;

            if (!SearchFlag)
                objPC.SearchFlag = false;
            else
                objPC.SearchFlag = true;

            ds = objQL.SP_LocationMaster_FillGrid();

            if (ds.Tables[0].Rows.Count > 0)
            {

                lblTotalCount.Text = "Total-" + ds.Tables[0].Rows.Count;

                //0 LocationId,
                //1 LocationName as 'Lacation Name', 
                //2 Description, 
                //3 ContactPerson as 'Contact Person',  
                //4 MobileNumber as 'Mobile Number',  
                //5 ExtensionNo as 'Extension Number'
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[2].Width = 150;
                dataGridView1.Columns[4].Width = 150;
                dataGridView1.Columns[5].Width = 150;
                dataGridView1.Columns[3].Width = 150;
            }
        }

        private void txtExtensionNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.NumericValue(sender, e, txtExtensionNo);
        }

        private void txtMobileNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.NumericValue(sender, e, txtMobileNumber);
        }
    }
}
