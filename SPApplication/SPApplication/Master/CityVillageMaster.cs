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

namespace SPApplication.Master
{
    public partial class CityVillageMaster : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0;

        public CityVillageMaster()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_CITYVILLAGEMASTER);
            objRL.Get_UserRights_By_MenuName(BusinessResources.LBL_HEADER_MASTER);

            objQL.Fill_Master_ComboBox(cmbContryName, "contrymaster");

            objDL.SetPlusButtonDesign(btnAddContry);
            objDL.SetPlusButtonDesign(btnAddState);
            objDL.SetPlusButtonDesign(btnAddDistrict);
            objDL.SetPlusButtonDesign(btnAddTaluka);
        }

        private void ClearAll()
        {
            TableId = 0;
            objEP.Clear();
            cmbContryName.SelectedIndex = -1;
            cmbStateName.SelectedIndex = -1;
            cmbDistrictName.SelectedIndex = -1;
            cmbTalukaName.SelectedIndex = -1;
            txtCityVillageName.Text = "";
            txtPincode.Text = "";
            txtSearch.Text = "";
            FlagDelete = false;
            btnDelete.Enabled = false;
            cmbContryName.Focus();
        }

        private bool Validation()
        {
            if (cmbContryName.SelectedIndex == -1)
            {
                cmbContryName.Focus();
                objEP.SetError(cmbContryName, " Enter Contry Name");
                return true;
            }
            else if (cmbStateName.SelectedIndex == -1)
            {
                cmbStateName.Focus();
                objEP.SetError(cmbStateName, " Enter State Name");
                return true;
            }
            else if (cmbDistrictName.SelectedIndex == -1)
            {
                cmbStateName.Focus();
                objEP.SetError(cmbDistrictName, " Enter District Name");
                return true;
            }
            else if (cmbTalukaName.SelectedIndex == -1)
            {
                cmbTalukaName.Focus();
                objEP.SetError(cmbTalukaName, " Enter Taluka Name");
                return true;
            }
            else if (txtCityVillageName.Text == "")
            {
                txtCityVillageName.Focus();
                objEP.SetError(txtCityVillageName, " Enter City/Village Name");
                return true;
            }
            else if (txtPincode.Text == "" || txtPincode.Text.Length < 6)
            {
                txtPincode.Focus();
                objEP.SetError(txtPincode, " Enter Valid Pincode");
                return true;
            }
            else
                return false;
        }

        protected bool CheckExist()
        {
            DataSet ds = new DataSet();
            ds = objQL.SP_CityVillageMaster_CheckExist();
            if (ds.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }

        protected void SaveDB()
        {
            if (!Validation())
            {
                objPC.CityVillageId = TableId;
                objPC.ContryId = Convert.ToInt32(cmbContryName.SelectedValue);
                objPC.StateId = Convert.ToInt32(cmbStateName.SelectedValue);
                objPC.DistrictId = Convert.ToInt32(cmbDistrictName.SelectedValue);
                objPC.TalukaId = Convert.ToInt32(cmbTalukaName.SelectedValue);
                objPC.CityVillageName = txtCityVillageName.Text;
                objPC.Pincode = Convert.ToInt32(txtPincode.Text);
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
                Result = objQL.SP_CityVillageMaster_Insert_Update_Delete();
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
            objPC.CityVillageName = txtSearch.Text;

            if (!SearchFlag)
                objPC.SearchFlag = false;
            else
                objPC.SearchFlag = true;

            ds = objQL.SP_CityVillageMaster_FillGrid();

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTotalCount.Text = "Total-" + ds.Tables[0].Rows.Count;
                //0 CVM.CityVillageId,
                //1 CVM.ContryId,
                //2 CM.ContryName as 'Contry Name',
                //3 CVM.StateId,
                //4 SM.StateName as 'State Name',
                //5 CVM.DistrictId,
                //6 DM.DistrictName as 'District Name',
                //7 CVM.TalukaId,
                //8 TM.TalukaName as 'Taluka Name',
                //9 CVM.CityVillageName as 'City/Village Name'
                //10 CVM.Pincode

                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[2].Width = 120;
                dataGridView1.Columns[4].Width = 120;
                dataGridView1.Columns[6].Width = 120;
                dataGridView1.Columns[8].Width = 120;
                dataGridView1.Columns[9].Width = 120;
                dataGridView1.Columns[10].Width = 100;
            }
        }

        private void Fill_State()
        {
            if (cmbContryName.SelectedIndex > -1)
            {
                objPC.SearchType = "State";
                objPC.SearchId = Convert.ToInt32(cmbContryName.SelectedValue);
                objQL.SP_State_District_Area_Master_By_Id(cmbStateName);
                cmbDistrictName.SelectedIndex = -1;
                cmbTalukaName.SelectedIndex = -1;
            }
        }

        private void Fill_District()
        {
            if (cmbContryName.SelectedIndex > -1 && cmbStateName.SelectedIndex > -1)
            {
                objPC.SearchType = "District";
                objPC.SearchId = Convert.ToInt32(cmbStateName.SelectedValue);
                objQL.SP_State_District_Area_Master_By_Id(cmbDistrictName);
                cmbTalukaName.SelectedIndex = -1;
            }
        }

        private void Fill_Taluka()
        {
            if (cmbContryName.SelectedIndex > -1 && cmbStateName.SelectedIndex > -1 && cmbDistrictName.SelectedIndex > -1)
            {
                objPC.SearchType = "Taluka";
                objPC.SearchId = Convert.ToInt32(cmbDistrictName.SelectedValue);
                objQL.SP_State_District_Area_Master_By_Id(cmbTalukaName);
            }
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void CityVillageMaster_Load(object sender, EventArgs e)
        {
            ClearAll();
            FillGrid();
        }

        private void btnAddContry_Click(object sender, EventArgs e)
        {
            CountryMaster objForm = new CountryMaster();
            objForm.ShowDialog(this);
            objQL.Fill_Master_ComboBox(cmbContryName, "contrymaster");
            cmbStateName.SelectedIndex = -1;
            cmbDistrictName.SelectedIndex = -1;
            cmbTalukaName.SelectedIndex = -1;
        }

        private void btnAddState_Click(object sender, EventArgs e)
        {
            StateMaster objForm = new StateMaster();
            objForm.ShowDialog(this);
            Fill_State();
        }

        private void btnAddDistrict_Click(object sender, EventArgs e)
        {
            DistrictMaster objForm = new DistrictMaster();
            objForm.ShowDialog(this);
            Fill_District();
        }

        private void btnAddTaluka_Click(object sender, EventArgs e)
        {
            TalukaMaster objForm = new TalukaMaster();
            objForm.ShowDialog(this);
            Fill_Taluka();
        }

        private void cmbContryName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_State();
        }

        private void cmbStateName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_District();
        }

        private void cmbDistrictName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_Taluka();
        }

        private void cmbTalukaName_SelectionChangeCommitted(object sender, EventArgs e)
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

                        //0 CVM.CityVillageId,
                        //1 CVM.ContryId,
                        //2 CM.ContryName as 'Contry Name',
                        //3 CVM.StateId,
                        //4 SM.StateName as 'State Name',
                        //5 CVM.DistrictId,
                        //6 DM.DistrictName as 'District Name',
                        //7 CVM.TalukaId,
                        //8 TM.TalukaName as 'Taluka Name',
                        //9 CVM.CityVillageName as 'City/Village Name'

                        btnDelete.Enabled = true;
                        TableId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                        cmbContryName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        Fill_State();
                        cmbStateName.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                        Fill_District();
                        cmbDistrictName.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                        Fill_Taluka();
                        cmbTalukaName.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                        txtCityVillageName.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                        txtPincode.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
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

        private void txtPincode_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.NumericValue(sender, e, txtPincode);
        }
    }
}
