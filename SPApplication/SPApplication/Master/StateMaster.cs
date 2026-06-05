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
    public partial class StateMaster : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0;

        public StateMaster()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_STATEMASTER);
            objRL.Get_UserRights_By_MenuName(BusinessResources.LBL_HEADER_MASTER);
            objQL.Fill_Master_ComboBox(cmbContryName, "contrymaster");
            objDL.SetPlusButtonDesign(btnAddContry);
        }

        private void StateMaster_Load(object sender, EventArgs e)
        {
            ClearAll();
            FillGrid();
        }

        private void ClearAll()
        {
            TableId = 0;
            objEP.Clear();
            cmbContryName.SelectedIndex = -1;
            txtStateName.Text = "";
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
            else if (txtStateName.Text == "")
            {
                txtStateName.Focus();
                objEP.SetError(txtStateName, " Enter State Name");
                return true;
            }
            else
                return false;
        }

        protected bool CheckExist()
        {
            DataSet ds = new DataSet();
            ds = objQL.SP_StateMaster_CheckExist();
            if (ds.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }

        protected void SaveDB()
        {
            if (!Validation())
            {
                objPC.StateId = TableId;
                objPC.ContryId = Convert.ToInt32(cmbContryName.SelectedValue);
                objPC.StateName = txtStateName.Text;
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
                Result = objQL.SP_StateMaster_Insert_Update_Delete();
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
            objPC.StateName = txtSearch.Text;

            if (!SearchFlag)
                objPC.SearchFlag = false;
            else
                objPC.SearchFlag = true;

            ds = objQL.SP_StateMaster_FillGrid();

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTotalCount.Text = "Total-" + ds.Tables[0].Rows.Count;
                //0 SM.StateId,
                //1 SM.ContryId,
                //2 CM.ContryName as 'Contry Name',
                //3 SM.StateName as 'State Name'

                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Width = 250;
                dataGridView1.Columns[3].Width = 250;
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

        private void btnAddContry_Click(object sender, EventArgs e)
        {
            CountryMaster objForm = new CountryMaster();
            objForm.ShowDialog(this);
            objQL.Fill_Master_ComboBox(cmbContryName, "contrymaster");
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
                        //0 StateId,
                        //1 ContryId,
                        //2 ContryName as 'Contry Name', 
                        //3 StateName as 'State Name',

                        btnDelete.Enabled = true;
                        TableId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                        cmbContryName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        txtStateName.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
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
    }
}
