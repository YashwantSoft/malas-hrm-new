
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

    public partial class ShiftMaster : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0;

        public ShiftMaster()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_SHIFTMASTER);
            objRL.Get_UserRights_By_MenuName(BusinessResources.LBL_HEADER_MASTER);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Shift_Master_Load(object sender, EventArgs e)
        {
            ClearAll();
            FillGrid();
        }

        protected void FillGrid()
        {
            lblTotalCount.Text = "";
            dataGridView1.DataSource = null;
            DataSet ds = new DataSet();
            objPC.ShiftFName = txtSearch.Text;

            if (!SearchFlag)
                objPC.SearchFlag = false;
            else
                objPC.SearchFlag = true;

            ds = objQL.SP_Shifts_FillGrid();

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTotalCount.Text = "Total-" + ds.Tables[0].Rows.Count;
                //0	ShiftId,
                //1	ShiftFName, 
                //2	ShiftSName, 
                //3	BeginTime, 
                //4	EndTime,
                //5	Break1, 
                //6	Break2, 
                //7	Break1BeginTime, 
                //8	Break2BeginTime, 
                //9	Break1EndTime,
                //10 Break2EndTime, 
                //11 Break1Duration, 
                //12 ShiftType, 
                //13 PunchBeginDuration, 
                //14 PunchEndDuration, 
                //15 IsGraceTimeApplicable, 
                //16 GraceTime, 
                //17 IsPartialDayApplicable, 
                //18 PartialDay, 
                //19 PartialDayBeginTime, 
                //20 PartialDayEndTime, 
                //21 IsFlexibleShift


                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[15].Visible = false;
                dataGridView1.Columns[17].Visible = false;
                dataGridView1.Columns[21].Visible = false;

                dataGridView1.Columns[2].Width = 120;
                dataGridView1.Columns[4].Width = 120;
                dataGridView1.Columns[6].Width = 120;
                dataGridView1.Columns[8].Width = 120;
                dataGridView1.Columns[10].Width = 120;
                dataGridView1.Columns[11].Width = 100;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtShiftName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtShortName.Focus();
        }

        private void txtShortName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtBegingTime.Focus();
        }

        private void txtBegingTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtEndTime.Focus();
        }

        private void txtEndTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbBreak1.Focus();
        }

        private void cbBreak1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtBegingTime1.Focus();
        }

        private void txtBegingTime1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtEndTime1.Focus();
        }

        private void txtEndTime1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbBreak2.Focus();
        }

        private void cbBreak2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtBegingTime2.Focus();
        }

        private void txtBegingTime2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtEndTime2.Focus();
        }

        private void txtEndTime2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbFlexibleShift.Focus();
        }

        private void cbFlexibleShift_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbPunchBeginBefore.Focus();
        }

        private void cbPunchBeginBefore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPunchBeginBefore.Focus();
        }

        private void txtPunchBeginBefore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbPunchEndAfter.Focus();
        }

        private void cbPunchEndAfter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPunchEndAfter.Focus();
        }

        private void cbGraceTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtGraceTime.Focus();
        }

        private void txtGraceTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbPartialDayon.Focus();
        }

        private void cbPartialDayon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbPartialDayon.Focus();
        }

        private void cmbPartialDayon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtBeginsAt.Focus();
        }

        private void txtBeginsAt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtEndAt.Focus();
        }

        private void txtEndAt_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtPunchEndAfter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbGraceTime.Focus();
        }

        private void ClearAll()
        {
            objEP.Clear();
            txtShiftName.Text = "";
            txtShortName.Text = "";
            txtBegingTime.Text = "";
            txtEndTime.Text = "";
            cbBreak1.Checked = false;
            txtBegingTime1.Text = "";
            txtEndTime1.Text = "";
            cbBreak2.Checked = false;
            txtBegingTime2.Text = "";
            txtEndTime2.Text = "";
            cbFlexibleShift.Checked = false;
            cbPunchBeginBefore.Checked = false;
            txtPunchBeginBefore.Text = "";
            cbPunchEndAfter.Checked = false;
            txtPunchEndAfter.Text = "";
            cbGraceTime.Checked = false;
            txtGraceTime.Text = "";
            cbPartialDayon.Checked = false;
            cmbPartialDayon.Text = "";
            txtBeginsAt.Text = "";
            txtEndAt.Text = "";
            txtSearch.Text = "";
            FlagDelete = false;
            btnDelete.Enabled = false;
            txtShiftName.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
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

        int Break1 = 0, Break2 = 0, IsFlexibleShift = 0, PunchBeginDuration = 0, PunchEndDuration = 0, IsGraceTimeApplicable = 0, IsPartialDayApplicable = 0;

        private void cbBreak1_CheckedChanged(object sender, EventArgs e)
        {
            objRL.CheckBox_Checked_TextBox2EnableTrue(cbBreak1, txtBegingTime1, txtEndTime1);
            if (cbBreak1.Checked)
                Break1 = 1;
            else
                Break1 = 0;
        }

        private void cbBreak2_CheckedChanged(object sender, EventArgs e)
        {
            objRL.CheckBox_Checked_TextBox2EnableTrue(cbBreak2, txtBegingTime2, txtEndTime2);
            if (cbBreak2.Checked)
                Break2 = 1;
            else
                Break2 = 0;
        }

        private void cbFlexibleShift_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFlexibleShift.Checked)
            {
                gbPunch.Enabled = true;
                IsFlexibleShift = 1;
            }
            else
                ClearAll_FlexibleDetails();
        }

        private void ClearAll_FlexibleDetails()
        {
            gbPunch.Enabled = false;
            IsFlexibleShift = 0;
            cbPunchBeginBefore.Checked = false;
            cbPunchEndAfter.Checked = false;
            cbGraceTime.Checked = false;
            cbPartialDayon.Checked = false;
        }

        private void EnableFalse_TextBox()
        {
            txtPunchBeginBefore.Enabled = false;
            txtPunchEndAfter.Enabled = false;
            txtGraceTime.Enabled = false;
            cmbPartialDayon.Enabled = false;
            txtBeginsAt.Enabled = false;
            txtBeginsAt.Enabled = false;
            txtEndAt.Enabled = false;

            txtPunchBeginBefore.Text = "";
            txtPunchEndAfter.Text = "";
            txtGraceTime.Text = "";
            cmbPartialDayon.SelectedIndex = -1;
            txtBeginsAt.Text = "";
            txtBeginsAt.Text = "";
            txtEndAt.Text = "";
        }

        private void cbPunchBeginBefore_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPunchBeginBefore.Checked)
            {
                txtPunchBeginBefore.Enabled = true;
                PunchBeginDuration = 1;
            }
            else
            {
                txtPunchBeginBefore.Enabled = false;
                PunchBeginDuration = 0;
            }
        }

        private void cbPunchEndAfter_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPunchEndAfter.Checked)
            {
                txtPunchEndAfter.Enabled = true;
                PunchEndDuration = 1;
            }
            else
            {
                txtPunchEndAfter.Enabled = false;
                PunchEndDuration = 0;
            }
        }

        private void cbGraceTime_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGraceTime.Checked)
            {
                txtGraceTime.Enabled = true;
                IsGraceTimeApplicable = 1;
            }
            else
            {
                txtGraceTime.Enabled = false;
                IsGraceTimeApplicable = 0;
            }
        }

        private void cbPartialDayon_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPartialDayon.Checked)
            {
                cmbPartialDayon.Enabled = true;
                txtBeginsAt.Enabled = true;
                txtBeginsAt.Enabled = true;
                txtEndAt.Enabled = true;
                IsPartialDayApplicable = 1;
                //cmbPartialDayon.SelectedIndex = -1;
                //txtBeginsAt.Text = "";
                //txtEndAt.Text = "";
            }
            else
            {
                cmbPartialDayon.Enabled = false;
                txtBeginsAt.Enabled = false;
                txtBeginsAt.Enabled = false;
                txtEndAt.Enabled = false;
                IsPartialDayApplicable = 0;
                cmbPartialDayon.SelectedIndex = -1;
                txtBeginsAt.Text = "";
                txtEndAt.Text = "";
            }
        }

        private bool Validation()
        {
            if (txtShiftName.Text == "")
            {
                txtShiftName.Focus();
                objEP.SetError(txtShiftName, "Enter Shift Name");
                return true;
            }
            else if (txtShortName.Text == "")
            {
                txtShortName.Focus();
                objEP.SetError(txtShortName, "Enter Short Name");
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

        int Break1Duration = 0, Break2Duration = 0;

        protected void SaveDB()
        {
            if (!Validation())
            {
                objPC.ShiftId = TableId;

                objPC.ShiftFName = objRL.CheckNullString(Convert.ToString(txtShiftName.Text));
                objPC.ShiftSName = objRL.CheckNullString(Convert.ToString(txtShortName.Text));
                objPC.BeginTime = objRL.CheckNullString(Convert.ToString(txtBegingTime.Text));
                objPC.EndTime = objRL.CheckNullString(Convert.ToString(txtEndTime.Text));
                objPC.Break1 = Break1;
                objPC.Break2 = Break2;
                objPC.Break1BeginTime = objRL.CheckNullString(Convert.ToString(txtBegingTime1.Text));
                objPC.Break2BeginTime = objRL.CheckNullString(Convert.ToString(txtBegingTime2.Text));
                objPC.Break1EndTime = objRL.CheckNullString(Convert.ToString(txtEndTime1.Text));
                objPC.Break2EndTime = objRL.CheckNullString(Convert.ToString(txtEndTime2.Text));
                objPC.Break1Duration = Break1Duration;
                objPC.Break2Duration = Break2Duration;

                if (!string.IsNullOrEmpty(Convert.ToString(cmbPartialDayon.Text)))
                    objPC.ShiftType = Convert.ToInt32(cmbPartialDayon.Text);

                if (!string.IsNullOrEmpty(Convert.ToString(txtPunchBeginBefore.Text)))
                    objPC.PunchBeginDuration = Convert.ToInt32(txtPunchBeginBefore.Text);

                if (!string.IsNullOrEmpty(Convert.ToString(txtPunchEndAfter.Text)))
                    objPC.PunchEndDuration = Convert.ToInt32(txtPunchEndAfter.Text);

                //if (!string.IsNullOrEmpty(Convert.ToString(txtPunchBeginBefore.Text)))
                objPC.IsGraceTimeApplicable = IsGraceTimeApplicable;

                if (!string.IsNullOrEmpty(Convert.ToString(txtGraceTime.Text)))
                    objPC.GraceTime = Convert.ToInt32(txtGraceTime.Text);

                objPC.IsPartialDayApplicable = IsPartialDayApplicable;
                objPC.PartialDay = IsPartialDayApplicable.ToString();
                objPC.PartialDayBeginTime = PunchBeginDuration.ToString();
                objPC.PartialDayEndTime = PunchEndDuration.ToString();
                objPC.IsFlexibleShift = IsFlexibleShift.ToString();

                objRL.Calculate_Time_Differance(objPC.BeginTime, objPC.EndTime);

                //TimeSpan BTIme = TimeSpan.Parse(objPC.BeginTime);
                //TimeSpan ETIme = TimeSpan.Parse();
                //TimeSpan interval = ETIme - BTIme;
                //double minutesTotal = interval.TotalMinutes;

                objPC.ShiftDuration = objPC.TimeIntervalMinutes.ToString();
                // objPC.ShifDurationHours = objPC.TimeIntervalHours.ToString();

                //objPC.ShifDurationHours = objRL.Get_Hours_Format(objPC.ShiftDuration);

                objPC.UserId = BusinessLayer.LoginId_Static;
                objPC.DeleteFlag = FlagDelete;

                Result = objQL.SP_Shifts_Insert_Update_Delete();
                if (Result > 0)
                {
                    if (!FlagDelete)
                        objRL.ShowMessage(7, 1);
                    else
                        objRL.ShowMessage(9, 1);

                    // FillGrid();
                    ClearAll();
                    FillGrid();
                }
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
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

                        //0	ShiftId,
                        //1	ShiftFName, 
                        //2	ShiftSName, 
                        //3	BeginTime, 
                        //4	EndTime,
                        //5	Break1, 
                        //6	Break2, 
                        //7	Break1BeginTime, 
                        //8	Break2BeginTime, 
                        //9	Break1EndTime,
                        //10 Break2EndTime, 
                        //11 Break1Duration, 
                        //12 ShiftType, 
                        //13 PunchBeginDuration, 
                        //14 PunchEndDuration, 
                        //15 IsGraceTimeApplicable, 
                        //16 GraceTime, 
                        //17 IsPartialDayApplicable, 
                        //18 PartialDay, 
                        //19 PartialDayBeginTime, 
                        //20 PartialDayEndTime, 
                        //21 IsFlexibleShift

                        btnDelete.Enabled = true;
                        TableId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                        txtShiftName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtShortName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        txtBegingTime.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                        txtEndTime.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

                        if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString())))
                        {
                            Break1 = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                            if (Break1 == 1)
                            {

                                cbBreak1.Checked = true;
                                objRL.CheckBox_Checked_TextBox2EnableTrue(cbBreak1, txtBegingTime1, txtEndTime1);
                                txtBegingTime1.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                                txtEndTime1.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                            }
                        }

                        if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString())))
                        {
                            Break2 = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
                            if (Break2 == 1)
                            {
                                cbBreak2.Checked = true;
                                objRL.CheckBox_Checked_TextBox2EnableTrue(cbBreak2, txtBegingTime2, txtEndTime2);
                                txtBegingTime2.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                                txtEndTime2.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                            }
                        }

                        if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[21].Value.ToString())))
                        {
                            IsFlexibleShift = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[21].Value.ToString());
                            if (IsFlexibleShift == 1)
                            {
                                cbFlexibleShift.Checked = true;
                                gbPunch.Enabled = true;

                                if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[13].Value)))
                                {
                                    txtPunchBeginBefore.Text = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
                                    cbPunchBeginBefore.Checked = true;
                                }

                                if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[14].Value)))
                                {
                                    txtPunchBeginBefore.Text = dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString();
                                    cbPunchEndAfter.Checked = true;
                                }

                                IsGraceTimeApplicable = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[15].Value.ToString());
                                if (IsGraceTimeApplicable == 1)
                                {
                                    txtGraceTime.Text = dataGridView1.Rows[e.RowIndex].Cells[16].Value.ToString();
                                }
                                else
                                    txtGraceTime.Text = "";

                                IsPartialDayApplicable = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[17].Value.ToString());

                                if (IsPartialDayApplicable == 1)
                                {
                                    cmbPartialDayon.Text = dataGridView1.Rows[e.RowIndex].Cells[18].Value.ToString();
                                    txtBeginsAt.Text = dataGridView1.Rows[e.RowIndex].Cells[19].Value.ToString();
                                    txtEndAt.Text = dataGridView1.Rows[e.RowIndex].Cells[20].Value.ToString();
                                }
                            }
                        }
                        else
                        {
                            cbFlexibleShift.Checked = true;
                            gbPunch.Enabled = true;
                            EnableFalse_TextBox();
                        }
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Result = 0;
            DialogResult dr = objRL.Delete_Record_Show_Message();
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                FlagDelete = true;
                objPC.ShiftId = TableId;
                Result = objQL.SP_Shifts_Delete();
                if (Result > 0)
                {
                    objRL.ShowMessage(9, 1);
                    FillGrid();
                    ClearAll();
                }
            }
        }
    }
}
