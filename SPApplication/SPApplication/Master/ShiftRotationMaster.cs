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

namespace SPApplication.Transaction
{
    public partial class ShiftRotationMaster : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        //bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int TableId = 0; // RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0;

         
        public ShiftRotationMaster()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_SHIFTROTATION);
            objRL.Fill_Shift_ComboBox(cmb1stDay);
            objRL.Fill_Shift_ComboBox(cmb2ndDay);
            objRL.Fill_Shift_ComboBox(cmb3rdDay);
            objRL.Fill_Shift_ComboBox(cmb4hDay);
            objRL.Fill_Shift_ComboBox(cmb5thDay);
            objRL.Fill_Shift_ComboBox(cmb6thDay);
            objRL.Fill_Shift_ComboBox(cmb7thDay);

            objRL.Fill_Shift_ComboBox(cmbMonday);
            objRL.Fill_Shift_ComboBox(cmbTuesday);
            objRL.Fill_Shift_ComboBox(cmbWednesday);
            objRL.Fill_Shift_ComboBox(cmbThursday);
            objRL.Fill_Shift_ComboBox(cmbFriday);
            objRL.Fill_Shift_ComboBox(cmbSaturday);
            objRL.Fill_Shift_ComboBox(cmbSunday);

            objRL.ColumnNameCM = "WeekDays";
            objRL.Fill_ComboBox_Comman(cmbWeeklyOff1);
            objRL.Fill_ComboBox_Comman(cmbWeeklyOff2);

            objRL.ColumnNameCM = "WeeklyOff2";
            objRL.Fill_ComboBox_Comman(cmbWeeklyOff2Type);
           
            ClearAll();
        }

        private void ShiftRotationMaster_Load(object sender, EventArgs e)
        {

        }

        private void CheckedBoxFalseAll(CheckBox cb,ComboBox cmb)
        {
            if (cb.Checked)
            {
                //cb.Checked = tr;
                cmb.SelectedIndex = -1;
                cmb.Enabled = true;
            }
            else
            {
                cb.Checked = false;
                cmb.SelectedIndex = -1;
                cmb.Enabled = false;
            }
        }

        private void ClearAll()
        {
            TableId = 0;
            objEP.Clear();
             
            cmbRotationPattern.SelectedIndex = 1;
            dtpBeginDate.Value = DateTime.Now.Date;
            dtpEndDate.Value = DateTime.Now.Date;
            gbDaily.Enabled = false;
            gbWeekly.Enabled = false;
            gbMonth.Enabled = false;

            ClearAll_Daily();
            ClearAll_Weekly();
            ClearAll_Monthly();
            txtSearch.Text = "";
        }

        private void ClearAll_Daily()
        {
            gbDaily.Enabled = false;
            cb1stDay.Checked = false;
            cb2ndDay.Checked = false;
            cb3rdDay.Checked = false;
            cb4hDay.Checked = false;
            cb5thDay.Checked = false;
            cb6thDay.Checked = false;
            cb7thDay.Checked = false;

            CheckedBoxFalseAll(cb1stDay, cmb1stDay);
            CheckedBoxFalseAll(cb2ndDay, cmb2ndDay);
            CheckedBoxFalseAll(cb3rdDay, cmb3rdDay);
            CheckedBoxFalseAll(cb4hDay, cmb4hDay);
            CheckedBoxFalseAll(cb5thDay, cmb5thDay);
            CheckedBoxFalseAll(cb6thDay, cmb6thDay);
            CheckedBoxFalseAll(cb7thDay, cmb7thDay); 
        }

        private void ClearAll_Weekly()
        {
            gbWeekly.Enabled = false;
            cmbMonday.SelectedIndex = -1;
            cmbTuesday.SelectedIndex = -1;
            cmbWednesday.SelectedIndex = -1;
            cmbThursday.SelectedIndex = -1;
            cmbFriday.SelectedIndex = -1;
            cmbSaturday.SelectedIndex = -1;
            cmbSunday.SelectedIndex = -1;
        }

        private void ClearAll_Monthly()
        {
            gbMonth.Enabled = false;
             
        }

        private void cmbRotationPattern_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Set_Date();
        }

        private void cbWeeklyOff2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbWeeklyOff1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
           // if(dtpEndDate.Value <= dtpBeginDate.Value)
                Set_Date();
        }

        string RotationPattern = string.Empty;

        private void Set_Date()
        {
            RotationPattern = string.Empty;
            if (cmbRotationPattern.SelectedIndex > -1)
            {
                //dtpBeginDate.Value = DateTime.Now.Date;
                //dtpEndDate.Value = DateTime.Now.Date;

                ClearAll_Daily();
                ClearAll_Weekly();
                ClearAll_Monthly();

                RotationPattern = cmbRotationPattern.Text;
 
                if (RotationPattern == "Daily")
                {
                    gbDaily.Enabled = true;
                    dtpEndDate.Value = dtpBeginDate.Value;
                }
                else if (RotationPattern == "Weekly")
                {
                    gbWeekly.Enabled = true;
                    dtpEndDate.Value = dtpBeginDate.Value.AddDays(7);
                }
                else if (RotationPattern == "Monthly")
                {
                    gbMonth.Enabled = true;
                    dtpEndDate.Value = dtpBeginDate.Value.AddMonths(1);
                }
                else
                {

                }
            }
        }

       

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cb1stDay_CheckedChanged(object sender, EventArgs e)
        {
            CheckedBoxFalseAll(cb1stDay, cmb1stDay);
        }

        private void cb2ndDay_CheckedChanged(object sender, EventArgs e)
        {
            CheckedBoxFalseAll(cb2ndDay, cmb2ndDay);
        }

        private void cb3rdDay_CheckedChanged(object sender, EventArgs e)
        {
            CheckedBoxFalseAll(cb3rdDay, cmb3rdDay);
        }

        private void cb4hDay_CheckedChanged(object sender, EventArgs e)
        {
            CheckedBoxFalseAll(cb4hDay, cmb4hDay);
        }

        private void cb5thDay_CheckedChanged(object sender, EventArgs e)
        {
            CheckedBoxFalseAll(cb5thDay, cmb5thDay);
        }

        private void cb6thDay_CheckedChanged(object sender, EventArgs e)
        {
            CheckedBoxFalseAll(cb6thDay, cmb6thDay);
        }

        private void cb7thDay_CheckedChanged(object sender, EventArgs e)
        {
            CheckedBoxFalseAll(cb7thDay, cmb7thDay);
        }
    }
}
