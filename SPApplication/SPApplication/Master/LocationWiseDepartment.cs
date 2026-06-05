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
    public partial class LocationWiseDepartment : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0;

        public LocationWiseDepartment()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_LOCATIONWISEDEPARTMENT);
            objRL.Get_UserRights_By_MenuName(BusinessResources.LBL_HEADER_MASTER);
            objQL.Fill_Master_ComboBox(cmbLocation, "locationmaster");
            objRL.Fill_Department_CheckedListBox(clbDepartment);
        }

        private void ClearAll()
        {
            TableId = 0;
            objEP.Clear();
            FlagDelete = false;
            cbSelectAllDepartment.Checked = false;
            cmbLocation.SelectedIndex = -1;
            btnDelete.Enabled = false;
            Department_CheckBox_Checked(false);
        }

        private void Department_CheckBox_Checked(bool check)
        {
            for (int i = 0; i < clbDepartment.Items.Count; i++)
            {
                clbDepartment.SetItemChecked(i, check);
            }
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

        private void FillGrid()
        {
            lblTotalCount.Text = "";
            dataGridView1.DataSource = null;
            DataSet ds = new DataSet();

            objPC.LocationName = txtSearch.Text;

            if (!SearchFlag)
                objPC.SearchFlag = false;
            else
                objPC.SearchFlag = true;

            ds = objQL.SP_LocationWiseDepartment_FillGrid();

            if (ds.Tables[0].Rows.Count > 0)
            {
                //0 SGS.ShiftGroupId,
                //1 SG.ShiftGroupFName 

                lblTotalCount.Text = "Total-" + ds.Tables[0].Rows.Count;
                dataGridView1.DataSource = ds.Tables[0];
                //dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;

                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    dataGridView1.Columns[i].Width = 500;
                }
            }
        }

        List<int> objItem = new List<int>();

        private void Fill_Department_By_GroupId()
        {
            DataSet ds = new DataSet();
            objPC.LocationId = TableId;
            ds = objQL.SP_LocationWiseDepartment_FillGrid_DepartmentName();
            if (ds.Tables[0].Rows.Count > 0)
            {
                //0 SGS.ShiftGroupId,
                //1 SG.ShiftGroupFName 
                //2 SGS.ShiftId

                objItem = new List<int>();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["DepartmentId"])))
                    {
                        int Iid = Convert.ToInt32(ds.Tables[0].Rows[i]["DepartmentId"].ToString());
                        objItem.Add(Iid);
                    }
                }

                //foreach (object itemChecked in clbShift.CheckedItems)
                //{
                //    DataRowView castedItem = itemChecked as DataRowView;
                //    int? id = Convert.ToInt32(castedItem[0]);
                //    ShiftId_Checked = (int)id;
                //    if (objItem.Contains(ShiftId_Checked))
                //        clbShift.SetItemChecked(i, true);
                //}

                int value = 0;
                for (int i = 0; i < clbDepartment.Items.Count; i++)
                {
                    DataRowView castedItem = clbDepartment.Items[i] as DataRowView;
                    int? id = Convert.ToInt32(castedItem[0]);
                    DepartmentId_Checked = (int)id;
                    //DataRowView view = clbShift.Items[i] as DataRowView;
                    //value = (int)view["ShiftId"];
                    if (objItem.Contains(DepartmentId_Checked))
                        clbDepartment.SetItemChecked(i, true);
                }
            }
            //else
            //    objRL.Fill_Supervisor_CheckedListBox(clbShift);

        }

        int DepartmentId_Checked = 0;

        protected void SaveDB()
        {
            if (!Validation())
            {
                if (TableId != 0)
                {
                    //SP_ShiftGroupShifts_Delete
                    objPC.LocationId = TableId;
                    Result = objQL.SP_LocationWiseDepartment_Delete();
                }

                foreach (object itemChecked in clbDepartment.CheckedItems)
                {
                    DataRowView castedItem = itemChecked as DataRowView;
                    int? id = Convert.ToInt32(castedItem[0]);
                    DepartmentId_Checked = (int)id;

                    if (DepartmentId_Checked != 0)
                    {
                        // objPC.ShiftGroupShiftId = TableId;
                        objPC.LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
                        objPC.DepartmentId = DepartmentId_Checked; //Convert.ToInt32(cmbShiftsGroup.SelectedValue);
                        objPC.UserId = BusinessLayer.LoginId_Static;
                        Result = objQL.SP_LocationWiseDepartment_Insert_Update_Delete();
                        Result++;
                    }
                }

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (objPC.DeleteFlagUR == 1)
            {
                DialogResult dr;
                dr = objRL.Delete_Record_Show_Message();

                if (dr == DialogResult.Yes)
                {
                    if (!Validation())
                    {
                        if (TableId != 0)
                        {
                            //SP_ShiftGroupShifts_Delete
                            objPC.LocationId = TableId;
                            Result = objQL.SP_LocationWiseDepartment_Delete_All();
                            if (Result > 0)
                            {
                                objRL.ShowMessage(9, 1);
                                FillGrid();
                                ClearAll();
                            }
                        }
                    }
                    else
                    {
                        objRL.ShowMessage(17, 4);
                        return;
                    }
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

        private void LocationWiseDepartment_Load(object sender, EventArgs e)
        {
            ClearAll();
            FillGrid();
        }

        private bool Validation()
        {
            objEP.Clear();
            if (cmbLocation.SelectedIndex == -1)
            {
                cmbLocation.Focus();
                objEP.SetError(cmbLocation, "Select Location");
                return true;
            }
            else if (!Validation_CheckListBox())
            {
                clbDepartment.Focus();
                objEP.SetError(clbDepartment, "Select Shift");
                return true;
            }
            else
                return false;
        }

        private bool Validation_CheckListBox()
        {
            objEP.Clear();
            bool checkCheck = false;

            for (int i = 0; i < clbDepartment.Items.Count; i++)
            {
                checkCheck = clbDepartment.GetItemChecked(i);
                if (checkCheck)
                    break;
            }
            return checkCheck;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
                SearchFlag = true;
            else
                SearchFlag = false;

            FillGrid();
        }

        private void cbSelectAllDepartment_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSelectAllDepartment.Checked)
                Department_CheckBox_Checked(true);
            else
                Department_CheckBox_Checked(false);
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
                        TableId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                        cmbLocation.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                        Fill_Department_By_GroupId();
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

        private void cmbLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

    }
}
