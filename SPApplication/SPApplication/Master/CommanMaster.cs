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
    public partial class CommanMaster : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        bool FlagDelete = false;
        int TableId = 0, Result = 0;//,RowCount_Grid = 0, CurrentRowIndex = 0;

        public CommanMaster()
        {
            InitializeComponent();
            DesignAll();
        }

        public CommanMaster(string CName)
        {
            InitializeComponent();
            GridSearch = CName;
            DesignAll();
            cmbMasterName.Enabled = false;
            cmbMasterName.Text = CName;
            
        }

        string GridSearch = string.Empty;
        private void DesignAll()
        {
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_COMMANMASTER);
            objRL.Get_UserRights_By_MenuName(BusinessResources.LBL_HEADER_MASTER);
            objRL.ColumnNameCM = "CommanMasterList";
            objRL.Fill_ComboBox_Comman(cmbMasterName);
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

         protected void SaveDB()
        {
            if (!Validation())
            {
                objRL.ClearAll_CommanMaster();

                objRL.CommanMasterId = TableId;
                objRL.CommanValue = txtMasterValue.Text;
                objRL.ColumnNameCM = cmbMasterName.Text;

                if (objRL.CheckExistCM())
                {
                    objRL.ShowMessage(12, 4);
                    return;
                }
              
                Result = objRL.Save_CommanMaster();
                 
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
             objRL.ColumnNameCM = GridSearch;
             objRL.FillGrid_Comman(dataGridView1);
         }

        private bool Validation()
        {
            if (cmbMasterName.SelectedIndex == -1)
            {
                cmbMasterName.Focus();
                objEP.SetError(cmbMasterName, " Enter Contry Name");
                return true;
            }
            else if (txtMasterValue.Text == "")
            {
                txtMasterValue.Focus();
                objEP.SetError(txtMasterValue, " Enter Area Name");
                return true;
            }
            else
                return false;
        }

        private void ClearAll()
        {
            objEP.Clear();
            TableId = 0;
            cmbMasterName.SelectedIndex = -1;
            txtMasterValue.Text = "";
            txtSearch.Text = "";
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
                    DialogResult dr;
                    dr = objRL.Delete_Record_Show_Message();
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

        private void CommanMaster_Load(object sender, EventArgs e)
        {
            FillGrid();
        }
    }
}
