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
    public partial class AreaMaster : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0;

        public AreaMaster()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_AREAMASTER);

            objRL.Get_UserRights_By_MenuName(BusinessResources.LBL_HEADER_MASTER);

            objQL.Fill_Master_ComboBox(cmbContryName, "contrymaster");

            objDL.SetPlusButtonDesign(btnAddContry);
            objDL.SetPlusButtonDesign(btnAddState);
            objDL.SetPlusButtonDesign(btnAddDistrict);
            objDL.SetPlusButtonDesign(btnAddTaluka);
            objDL.SetPlusButtonDesign(btnAddCityVillage);
        }

        private void ClearAll()
        {
            TableId = 0;
            FlagDelete = false;
            objEP.Clear();
            cmbContryName.SelectedIndex = -1;
            cmbStateName.SelectedIndex = -1;
            cmbDistrictName.SelectedIndex = -1;
            cmbTalukaName.SelectedIndex = -1;
            cmbCityVillageName.SelectedIndex = -1;
            txtAreaName.Text = "";
            txtSearch.Text = "";
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
            else if (cmbCityVillageName.SelectedIndex == -1)
            {
                cmbCityVillageName.Focus();
                objEP.SetError(cmbCityVillageName, " Enter City Village Name");
                return true;
            }
            else if (txtAreaName.Text == "")
            {
                txtAreaName.Focus();
                objEP.SetError(txtAreaName, " Enter Area Name");
                return true;
            }
            else
                return false;
        }

        protected bool CheckExist()
        {
            DataSet ds = new DataSet();
            ds = objQL.SP_AreaMaster_CheckExist();
            if (ds.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }

        protected void SaveDB()
        {
            if (!Validation())
            {
                objPC.AreaId = TableId;
                objPC.ContryId = Convert.ToInt32(cmbContryName.SelectedValue);
                objPC.StateId = Convert.ToInt32(cmbStateName.SelectedValue);
                objPC.DistrictId = Convert.ToInt32(cmbDistrictName.SelectedValue);
                objPC.TalukaId = Convert.ToInt32(cmbTalukaName.SelectedValue);
                objPC.CityVillageId = Convert.ToInt32(cmbCityVillageName.SelectedValue);
                objPC.AreaName = txtAreaName.Text; 
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
                Result = objQL.SP_AreaMaster_Insert_Update_Delete();
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
            objPC.AreaName = txtSearch.Text;

            if (!SearchFlag)
                objPC.SearchFlag = false;
            else
                objPC.SearchFlag = true;

            ds = objQL.SP_AreaMaster_FillGrid();

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTotalCount.Text = "Total-" + ds.Tables[0].Rows.Count;
                //0 AM.AreaId,
                //1 AM.ContryId,
                //2 CM.ContryName as 'Contry Name',
				//3 AM.StateId,
                //4 SM.StateName as 'State Name',
				//5 AM.DistrictId,
				//6 DM.DistrictName as 'District Name',
                //7 AM.TalukaId,
                //8 TM.TalukaName as 'Taluka Name',
                //9 AM.CityVillageId,
                //10 CVM.CityVillageName as 'City/Village Name',
                //11 AM.AreaName as 'Area Name' 

                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[2].Width = 120;
                dataGridView1.Columns[4].Width = 120;
                dataGridView1.Columns[6].Width = 120;
                dataGridView1.Columns[8].Width = 120;
                dataGridView1.Columns[10].Width = 120;
                dataGridView1.Columns[11].Width = 100;
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

        private void Fill_CityVillage()
        {
            if (cmbContryName.SelectedIndex > -1 && cmbStateName.SelectedIndex > -1 && cmbDistrictName.SelectedIndex > -1 && cmbTalukaName.SelectedIndex > -1)
            {
                objPC.SearchType = "CityVillage";
                objPC.SearchId = Convert.ToInt32(cmbTalukaName.SelectedValue);
                objQL.SP_State_District_Area_Master_By_Id(cmbCityVillageName);
            }
        }

        private void AreaMaster_Load(object sender, EventArgs e)
        {
            ClearAll();
            FillGrid();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
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
            Fill_CityVillage();
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

                        //0 AM.AreaId,
                        //1 AM.ContryId,
                        //2 CM.ContryName as 'Contry Name',
                        //3 AM.StateId,
                        //4 SM.StateName as 'State Name',
                        //5 AM.DistrictId,
                        //6 DM.DistrictName as 'District Name',
                        //7 AM.TalukaId,
                        //8 TM.TalukaName as 'Taluka Name',
                        //9 AM.CityVillageId,
                        //10 CVM.CityVillageName as 'City/Village Name',
                        //11 AM.AreaName as 'Area Name' 

                        btnDelete.Enabled = true;
                        TableId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                        cmbContryName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        Fill_State();
                        cmbStateName.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                        Fill_District();
                        cmbDistrictName.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                        Fill_Taluka();
                        cmbTalukaName.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                        Fill_CityVillage();
                        cmbCityVillageName.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                        txtAreaName.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
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

        private void btnAddContry_Click(object sender, EventArgs e)
        {
            CountryMaster objForm = new CountryMaster();
            objForm.ShowDialog(this);
            objQL.Fill_Master_ComboBox(cmbContryName, "contrymaster");
            cmbStateName.SelectedIndex = -1;
            cmbDistrictName.SelectedIndex = -1;
            cmbTalukaName.SelectedIndex = -1;
            cmbCityVillageName.SelectedIndex = -1;
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

        private void btnAddCityVillage_Click(object sender, EventArgs e)
        {
            CityVillageMaster objForm = new CityVillageMaster();
            objForm.ShowDialog(this);
            Fill_CityVillage();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
                SearchFlag = true;
            else
                SearchFlag = false;

            FillGrid();
        }
    }
}
