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
    public partial class ShiftGroupShifts : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0;

        public ShiftGroupShifts()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_SHIFTGROUPMASTER);
            objRL.Get_UserRights_By_MenuName(BusinessResources.LBL_HEADER_MASTER);
            objQL.Fill_Master_ComboBox(cmbShiftsGroup, "shiftgroups");
            objRL.Fill_Shifts_CheckedListBox(clbShift);
        }

        private void ClearAll()
        {
            objEP.Clear();
            FlagDelete = false;
            cbSelectAllShift.Checked = false;
            cmbShiftsGroup.SelectedIndex = -1;
            btnDelete.Enabled = false;
            Shift_CheckBox_Checked(false);
        }

        private void Shift_CheckBox_Checked(bool check)
        {
            for (int i = 0; i < clbShift.Items.Count; i++)
            {
                clbShift.SetItemChecked(i, check);
            }
        }

        private void ShiftGroupMaster_Load(object sender, EventArgs e)
        {
            ClearAll();
            FillGrid();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private bool Validation()
        {
            objEP.Clear();
            if (cmbShiftsGroup.SelectedIndex == -1)
            {
                cmbShiftsGroup.Focus();
                objEP.SetError(cmbShiftsGroup, "Select Location");
                return true;
            }
            else if (!Validation_CheckListBox())
            {
                clbShift.Focus();
                objEP.SetError(clbShift, "Select Shift");
                return true;
            }
            else
                return false;
        }

        private bool Validation_CheckListBox()
        {
            objEP.Clear();
            bool checkCheck = false;

            for (int i = 0; i < clbShift.Items.Count; i++)
            {
                checkCheck = clbShift.GetItemChecked(i);
                if (checkCheck)
                    break;
            }
            return checkCheck;
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

        private void FillGrid()
        {
            lblTotalCount.Text = "";
            dataGridView1.DataSource = null;
            DataSet ds = new DataSet();

            objPC.ShiftFName = txtSearch.Text;

            if (!SearchFlag)
                objPC.SearchFlag = false;
            else
                objPC.SearchFlag = true;


            ds = objQL.SP_ShiftGroupShifts_FillGrid();
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

        private void Fill_Shift_By_GroupId()
        {
            DataSet ds = new DataSet();
            objPC.ShiftGroupId = TableId;
            ds = objQL.SP_ShiftGroupShifts_FillGrid_ShiftName();
            if (ds.Tables[0].Rows.Count > 0)
            {
                //0 SGS.ShiftGroupId,
                //1 SG.ShiftGroupFName 
                //2 SGS.ShiftId

                objItem = new List<int>();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["ShiftId"])))
                    {
                        int Iid = Convert.ToInt32(ds.Tables[0].Rows[i]["ShiftId"].ToString());
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
                for (int i = 0; i < clbShift.Items.Count; i++)
                {
                    DataRowView castedItem = clbShift.Items[i] as DataRowView;
                    int? id = Convert.ToInt32(castedItem[0]);
                    ShiftId_Checked = (int)id;
                    //DataRowView view = clbShift.Items[i] as DataRowView;
                    //value = (int)view["ShiftId"];
                    if (objItem.Contains(ShiftId_Checked))
                        clbShift.SetItemChecked(i, true);
                }
            }
            //else
            //    objRL.Fill_Supervisor_CheckedListBox(clbShift);

        }

        int ShiftId_Checked = 0;

        protected void SaveDB()
        {
            if (!Validation())
            {
                if (TableId != 0)
                {
                    //SP_ShiftGroupShifts_Delete
                    objPC.ShiftGroupId = TableId;
                    Result = objQL.SP_ShiftGroupShifts_Delete();
                }

                foreach (object itemChecked in clbShift.CheckedItems)
                {
                    DataRowView castedItem = itemChecked as DataRowView;
                    int? id = Convert.ToInt32(castedItem[0]);
                    ShiftId_Checked = (int)id;

                    if (ShiftId_Checked != 0)
                    {
                        // objPC.ShiftGroupShiftId = TableId;
                        objPC.ShiftGroupId = Convert.ToInt32(cmbShiftsGroup.SelectedValue);
                        objPC.ShiftId = ShiftId_Checked; //Convert.ToInt32(cmbShiftsGroup.SelectedValue);
                        objPC.UserId = BusinessLayer.LoginId_Static;
                        Result = objQL.SP_ShiftGroupShifts_Insert_Update_Delete();
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

                    if (dr == DialogResult.Yes)
                    {
                        if (!Validation())
                        {
                            if (TableId != 0)
                            {
                                //SP_ShiftGroupShifts_Delete
                                objPC.ShiftGroupId = TableId;
                                Result = objQL.SP_ShiftGroupShifts_Delete_All();
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
                catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
                finally { GC.Collect(); }
            }
            else
            {
                objRL.ShowMessage(24, 4);
                return;
            }

        }

        private void cbSelectAllShift_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSelectAllShift.Checked)
                Shift_CheckBox_Checked(true);
            else
                Shift_CheckBox_Checked(false);
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
                        //0 ContryId,
                        //1 ContryName as 'Contry Name', 

                        btnDelete.Enabled = true;
                        TableId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                        cmbShiftsGroup.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                        Fill_Shift_By_GroupId();
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
