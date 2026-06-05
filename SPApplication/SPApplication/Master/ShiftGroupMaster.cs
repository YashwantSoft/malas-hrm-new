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
    public partial class ShiftGroupMaster : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0;

        public ShiftGroupMaster()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_SHIFTGROUPMASTER);
            objRL.Get_UserRights_By_MenuName(BusinessResources.LBL_HEADER_MASTER);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
                SearchFlag = true;
            else
                SearchFlag = false;

            FillGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (objPC.AddFlag == 1)
            {
                try
                {
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

        private void ShiftGroupMaster_Load(object sender, EventArgs e)
        {
            ClearAll();
            FillGrid();
        }

        private bool Validation()
        {
            if (txtShiftGroupFullName.Text == "")
            {
                txtShiftGroupFullName.Focus();
                objEP.SetError(txtShiftGroupFullName, "Enter Shif tGroup Full Name");
                return false;
            }
            else if (txtShiftGroupShortName.Text == "")
            {
                txtShiftGroupShortName.Focus();
                objEP.SetError(txtShiftGroupShortName, "Enter Shift Group Short Name");
                return false;
            }
            else
                return false;
        }

        protected void SaveDB()
        {
            if (!Validation())
            {
                objPC.ShiftGroupId = TableId;
                objPC.ShiftFName = txtShiftGroupFullName.Text;
                objPC.ShiftSName = txtShiftGroupShortName.Text;
                objPC.UserId = BusinessLayer.LoginId_Static;
                objPC.DeleteFlag = FlagDelete;
                Result = objQL.SP_ShiftGroups_Insert_Update_Delete();
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

        private void ClearAll()
        {
            TableId = 0;
            objEP.Clear();
            txtShiftGroupFullName.Text = "";
            txtShiftGroupShortName.Text = "";
            FlagDelete = false;
            btnDelete.Enabled = false;
            txtShiftGroupFullName.Focus();
        }

        protected void FillGrid()
        {
            dataGridView1.DataSource = null;
            DataSet ds = new DataSet();

            objPC.ShiftFName = txtSearch.Text;

            if (!SearchFlag)
                objPC.SearchFlag = false;
            else
                objPC.SearchFlag = true;

            ds = objQL.SP_ShiftGroupMaster_FillGrid();
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
                //dataGridView1.Columns[2].Visible = false;

                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    dataGridView1.Columns[i].Width = 300;
                }
            }
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
                        txtShiftGroupFullName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtShiftGroupShortName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
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
