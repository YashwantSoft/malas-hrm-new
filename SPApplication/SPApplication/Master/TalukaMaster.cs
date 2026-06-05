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
    public partial class TalukaMaster : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0;

        public TalukaMaster()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_TALUKAMASTER);
            objRL.Get_UserRights_By_MenuName(BusinessResources.LBL_HEADER_MASTER);
            objQL.Fill_Master_ComboBox(cmbContryName, "contrymaster");

            objDL.SetPlusButtonDesign(btnAddContry);
            objDL.SetPlusButtonDesign(btnAddState);
        }

        private void ClearAll()
        {
            TableId = 0;
            objEP.Clear();
            cmbContryName.SelectedIndex = -1;
            cmbStateName.SelectedIndex = -1;
            cmbDistrictName.SelectedIndex = -1;
            txtTalukaName.Text = "";
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
            else if (txtTalukaName.Text == "")
            {
                txtTalukaName.Focus();
                objEP.SetError(txtTalukaName, " Enter Taluka Name");
                return true;
            }
            else
                return false;
        }

        protected bool CheckExist()
        {
            DataSet ds = new DataSet();
            ds = objQL.SP_TalukaMaster_CheckExist();
            if (ds.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }

        protected void SaveDB()
        {
            if (!Validation())
            {
                objPC.TalukaId = TableId;
                objPC.ContryId = Convert.ToInt32(cmbContryName.SelectedValue);
                objPC.StateId = Convert.ToInt32(cmbStateName.SelectedValue);
                objPC.DistrictId = Convert.ToInt32(cmbDistrictName.SelectedValue);
                objPC.TalukaName = txtTalukaName.Text;
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
                Result = objQL.SP_TalukaMaster_Insert_Update_Delete();
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
            objPC.TalukaName = txtSearch.Text;

            if (!SearchFlag)
                objPC.SearchFlag = false;
            else
                objPC.SearchFlag = true;

            ds = objQL.SP_TalukaMaster_FillGrid();

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTotalCount.Text = "Total-" + ds.Tables[0].Rows.Count;
                //0 TM.TalukaId,
                //1 TM.ContryId,
                //2 CM.ContryName as 'Contry Name',
                //3 TM.StateId,
                //4 SM.StateName as 'State Name',
                //5 TM.DistrictId,
                //6 DM.DistrictName as 'District Name',
                //7 TM.TalukaName as 'Taluka Name'

                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[2].Width = 120;
                dataGridView1.Columns[4].Width = 120;
                dataGridView1.Columns[6].Width = 120;
                dataGridView1.Columns[7].Width = 120;
            }
        }

        private void TalukaMaster_Load(object sender, EventArgs e)
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

        private void cmbContryName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_State();
        }

        private void Fill_State()
        {
            if (cmbContryName.SelectedIndex > -1)
            {
                objPC.SearchType = "State";
                objPC.SearchId = Convert.ToInt32(cmbContryName.SelectedValue);
                objQL.SP_State_District_Area_Master_By_Id(cmbStateName);
                cmbDistrictName.SelectedIndex = -1;
            }
        }

        private void Fill_District()
        {
            if (cmbContryName.SelectedIndex > -1 && cmbStateName.SelectedIndex > -1)
            {
                objPC.SearchType = "District";
                objPC.SearchId = Convert.ToInt32(cmbStateName.SelectedValue);
                objQL.SP_State_District_Area_Master_By_Id(cmbDistrictName);
            }
        }

        private void cmbStateName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_District();
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
                DialogResult dr = objRL.Delete_Record_Show_Message();
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    FlagDelete = true;
                    SaveDB();
                }
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
                        //0 TM.TalukaId,
                        //1 TM.ContryId,
                        //2 CM.ContryName as 'Contry Name',
                        //3 TM.StateId,
                        //4 SM.StateName as 'State Name',
                        //5 TM.DistrictId,
                        //6 DM.DistrictName as 'District Name',
                        //7 TM.TalukaName as 'Taluka Name'


                        btnDelete.Enabled = true;
                        TableId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                        cmbContryName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        Fill_State();
                        cmbStateName.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                        Fill_District();
                        cmbDistrictName.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                        txtTalukaName.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
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
    }
}
