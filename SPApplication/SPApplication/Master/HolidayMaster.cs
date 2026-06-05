using BusinessLayerUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Controls;
using System.Windows.Forms;

namespace SPApplication.Master
{
    public partial class HolidayMaster : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0;

        public HolidayMaster()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_HOLIDAYMASTER);
            objRL.Get_UserRights_By_MenuName(BusinessResources.LBL_HEADER_MASTER);
            objRL.Fill_Location_CheckedListBox_HolidayMaster(clbLocation);
        }

        private void HolidayMaster_Load(object sender, EventArgs e)
        {
            ClearAll();
            FillGrid();
            txtHolidayDay.Text = dtpHolidayDate.Value.DayOfWeek.ToString();
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

        private void ClearAll()
        {
            TableId = 0;
            objEP.Clear();
            dtpHolidayDate.Value = DateTime.Now.Date;
            txtHolidayDay.Text = "";
            txtHolidayFestival.Text = "";
            txtSearch.Text = "";
            SearchFlag = false;
            FlagDelete = false;
            btnDelete.Enabled = false;
            cbIsNationalHoliday.Checked = false;
            objPC.NationalHolidayFlag = 0;
            cbSelectAllLocation.Checked = false;
            Fill_Location_SelectAll(clbLocation,cbSelectAllLocation);
            dtpHolidayDate.Focus();
        }

        private bool Validation()
        {
            if (txtHolidayDay.Text == "")
            {
                txtHolidayDay.Focus();
                objEP.SetError(txtHolidayDay, "Enter Holiday Day");
                return false;
            }
            else if (txtHolidayFestival.Text == "")
            {
                txtHolidayFestival.Focus();
                objEP.SetError(txtHolidayFestival, "Enter Holiday Festival");
                return false;
            }
            else if (cmbHolidayType.SelectedIndex == -1)
            {
                cmbHolidayType.Focus();
                objEP.SetError(cmbHolidayType, "Select Holiday Type");
                return false;
            }
            else if (clbLocation.CheckedItems.Count == 0)
            {
                clbLocation.Focus();
                objEP.SetError(clbLocation, "Select Location");
                return false;
            }
            else
                return false;
        }

        int ForPanchgani = 0, ForWai = 0;

        private void cbSelectAllLocation_CheckedChanged(object sender, EventArgs e)
        {
            Fill_Location_SelectAll(clbLocation, cbSelectAllLocation);
        }

        private void Fill_Location_SelectAll(CheckedListBox clb, CheckBox cbSelectAll)
        {
            for (int i = 0; i < clb.Items.Count; i++)
            {
                if (cbSelectAll.Checked)
                    clb.SetItemChecked(i, true);
                else
                    clb.SetItemChecked(i, false);
            }
        }

        protected bool CheckExist()
        {
            DataSet ds = new DataSet();
            ds = objQL.SP_HolidayMaster_CheckExist();
            if (ds.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }

        protected void SaveDB()
        {
            if (!Validation())
            {
                HolidayLocationId = 0; HolidayId = 0; LocationId = 0;

                if (cbIsNationalHoliday.Checked)
                    objPC.NationalHolidayFlag = 1;
                else
                    objPC.NationalHolidayFlag = 0;

                objPC.HolidayId = TableId;
                objPC.HolidayDate = dtpHolidayDate.Value;
                objPC.HolidayDay = txtHolidayDay.Text;
                objPC.Festival = txtHolidayFestival.Text;
                objPC.HolidayType = cmbHolidayType.Text;
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

                Result = objQL.SP_HolidayMaster_Insert_Update_Delete();

                if (Result > 0)
                {
                    if (TableId == 0)
                        HolidayId = Convert.ToInt32(objRL.ReturnMaxID_Fix("holidaymaster", "HolidayId"));
                    else
                        HolidayId = objPC.HolidayId;

                    if (clbLocation.CheckedItems.Count > 0)
                    {
                        objBL.Query = "delete from holidaylocation where HolidayId=" + HolidayId + " and CancelTag=0";
                        Result = objBL.Function_ExecuteNonQuery();

                        foreach (object itemChecked in clbLocation.CheckedItems)
                        {
                            DataRowView castedItem = itemChecked as DataRowView;
                            int? id = Convert.ToInt32(castedItem[0]);
                            LocationId = (int)id;

                            if (LocationId != 0)
                            {
                                DataSet ds = new DataSet();
                                objBL.Query = "select HolidayLocationId,HolidayId,LocationId from holidaylocation where LocationId=" + LocationId + " and HolidayId=" + HolidayId + " and CancelTag=0";
                                ds = objBL.ReturnDataSet();
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][0].ToString())))
                                    {
                                        HolidayLocationId = objRL.CheckNullString_ReturnInt(Convert.ToString(ds.Tables[0].Rows[0][0]));

                                        objBL.Query = "update holidaylocation set LocationId=" + LocationId + ",ModifiedUserId=" + BusinessLayer.LoginId_Static + "  where HolidayLocationId=" + HolidayLocationId + " and CancelTag=0";
                                        Result = objBL.Function_ExecuteNonQuery();
                                    }
                                }
                                else
                                {
                                    objBL.Query = "insert into holidaylocation(HolidayId,LocationId,UserId) values(" + HolidayId + "," + LocationId + ", " + BusinessLayer.LoginId_Static + ")";
                                    Result = objBL.Function_ExecuteNonQuery();
                                }
                            }
                        }
                    }
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

        int HolidayLocationId=0,HolidayId = 0, LocationId = 0;
        protected void FillGrid()
        {
            dataGridView1.DataSource = null;
            DataSet ds = new DataSet();
            objPC.Festival = txtSearch.Text;

            if (!SearchFlag)
                objPC.SearchFlag = false;
            else
                objPC.SearchFlag = true;

            ds = objQL.SP_HolidayMaster_FillGrid();
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTotalCount.Text = "Total-" + ds.Tables[0].Rows.Count;
                //0 HolidayId,
                //1 HolidayDate as 'Holiday Date',
				//2 HolidayDay as 'Holiday Day',
				//3 Festival,
				//4 NationalHolidayFlag,
                //5 HolidyaType as 'Holiday Type'

                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[4].Visible = false;

                dataGridView1.Columns[1].Width = 120;
                dataGridView1.Columns[2].Width = 120;
                dataGridView1.Columns[3].Width = 300;
                dataGridView1.Columns[5].Width = 200;
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
                        //0 HolidayId,
                        //1 HolidayDate as 'Holiday Date',
                        //2 HolidayDay as 'Holiday Day',
                        //3 Festival,
                        //4 NationalHolidayFlag
                        //5 HolidyaType as 'Holiday Type'
                        btnDelete.Enabled = true;
                        objPC.NationalHolidayFlag = 0;
                        TableId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                        HolidayId = TableId;
                        dtpHolidayDate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                        txtHolidayDay.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value));
                        txtHolidayFestival.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value));
                        objPC.NationalHolidayFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value)));
                        cmbHolidayType.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[5].Value));


                        if (objPC.NationalHolidayFlag == 1)
                            cbIsNationalHoliday.Checked = true;
                        else
                            cbIsNationalHoliday.Checked = false;

                        Fill_Location_By_HolidayId();
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

        private void dtpHolidayDate_ValueChanged(object sender, EventArgs e)
        {
            txtHolidayDay.Text = dtpHolidayDate.Value.DayOfWeek.ToString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
                SearchFlag = true;
            else
                SearchFlag = false;

            FillGrid();
        }

        string ConcatString = string.Empty;
        string CheckBoxListSelectedValue = string.Empty;

        List<int> objItem = new List<int>();
        private void Fill_Location_By_HolidayId()
        {
            if(HolidayId !=0)
            {
                DataSet ds = new DataSet();
                objBL.Query = "select HolidayLocationId,HolidayId,LocationId from holidaylocation where HolidayId=" + HolidayId + " and CancelTag=0";
                ds = objBL.ReturnDataSet();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //0 HolidayLocationId,
                    //1 HolidayId,
                    //2 LocationId

                    objItem = new List<int>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["LocationId"])))
                        {
                            int Iid = Convert.ToInt32(ds.Tables[0].Rows[i]["LocationId"].ToString());
                            objItem.Add(Iid);
                        }
                    }

                     
                    for (int i = 0; i < clbLocation.Items.Count; i++)
                    {
                        DataRowView castedItem = clbLocation.Items[i] as DataRowView;
                        int? id = Convert.ToInt32(castedItem[0]);
                        LocationId = (int)id;

                        if (objItem.Contains(LocationId))
                            clbLocation.SetItemChecked(i, true);
                    }
                }
            }
        }
    }
}
