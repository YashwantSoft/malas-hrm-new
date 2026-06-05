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
    public partial class CommanEdit : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();

        PropertyClass objPC = new PropertyClass();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0, LocationId = 0;

        string ColumnName = string.Empty;
        List<int> empId = new List<int>();

        private void SetDesign()
        {
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_ATTENDANCEAPPROVAL);
        }

        public CommanEdit()
        {
            InitializeComponent();
            SetDesign();
        }

        public CommanEdit(List<int> indexComman,string ColumnName)
        {
            InitializeComponent();
            SetDesign();
            this.ColumnName = ColumnName;
            empId = indexComman;
            Fill_Data();
            lblHeader.Text = ColumnName;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Fill_Data()
        {
            //objQL.Fill_Master_ComboBox(cmbLocation, "locationmaster");
            //objQL.Fill_Master_ComboBox(cmbDepartment, "departmentmaster");
            //objQL.Fill_Master_ComboBox(cmbDesignation, "designationmaster");
            //objQL.Fill_Master_ComboBox(cmbContractor, "contractormaster");
            //objQL.Fill_Master_ComboBox(cmbCategory, "categories");
            //objQL.Fill_Master_ComboBox(cmbShiftGroup, "shiftgroups");
            //objQL.Fill_Master_ComboBox(cmbJobProfile, "jobprofilemaster");
            //objQL.Fill_Master_ComboBox(cmbType, "employementtypemaster");

            // m.MenuItems.Add("Update Location and Department", new EventHandler(SubmenuItem_Click));
            //m.MenuItems.Add("Update Contractor", new EventHandler(SubmenuItem_Click));
            //m.MenuItems.Add("Update Shift Group", new EventHandler(SubmenuItem_Click));
            //m.MenuItems.Add("Update Category", new EventHandler(SubmenuItem_Click));
            //m.MenuItems.Add("Update Designation", new EventHandler(SubmenuItem_Click));
            //m.MenuItems.Add("Update Status", new EventHandler(SubmenuItem_Click));
            //m.MenuItems.Add("Update Job Profile", new EventHandler(SubmenuItem_Click));
            //m.MenuItems.Add("Update Employment Type",

            lblLocation.Visible = false; cmbLocation.Visible = false;
            cmbComman.DataSource = null; cmbComman.Items.Clear();
            cbOverTimeApplicable.Visible = false;

            if (ColumnName == "Update Location and Department")
            {
                lblLocation.Visible = true; cmbLocation.Visible = true;
                lblComman.Text = ColumnName;
                objQL.Fill_Master_ComboBox(cmbLocation, "locationmaster");
            }
            //else if (ColumnName == "Update Department")
            //{
            //    lblComman.Text = ColumnName;
            //    objQL.Fill_Master_ComboBox(cmbComman, "departmentmaster");
            //}
            else if (ColumnName == "Update Contractor")
            {
                lblComman.Text = ColumnName;
                objQL.Fill_Master_ComboBox(cmbComman, "contractormaster");
            }
            else if (ColumnName == "Update Shift Group")
            {
                lblComman.Text = ColumnName;
                objQL.Fill_Master_ComboBox(cmbComman, "shiftgroups");
            }
            else if (ColumnName == "Update Category")
            {
                lblComman.Text = ColumnName;
                objQL.Fill_Master_ComboBox(cmbComman, "categories");
            }
            else if (ColumnName == "Update Job Profile")
            {
                lblComman.Text = ColumnName;
                objQL.Fill_Master_ComboBox(cmbComman, "jobprofilemaster");
            }
            else if (ColumnName == "Update Designation")
            {
                lblComman.Text = ColumnName;
                objQL.Fill_Master_ComboBox(cmbComman, "designationmaster");
            }
            else if (ColumnName == "Update Employment Type")
            {
                lblComman.Text = ColumnName;
                objQL.Fill_Master_ComboBox(cmbComman, "employementtypemaster");
            }
            else if (ColumnName == "Save New Employee")
            {
                lblLocation.Visible = false; 
                cmbLocation.Visible = false;
                lblComman.Visible = false;
                cmbComman.Visible = false;
                
            }
            else if (ColumnName == "Update Status")
            {
                lblComman.Text = ColumnName;
                cmbComman.DataSource = null; cmbComman.Items.Clear();
                cmbComman.Items.Add("All");
                cmbComman.Items.Add("Working");
                cmbComman.Items.Add("Resigned");
                //objQL.Fill_Master_ComboBox(cmbComman, "employementtypemaster");
            }
            else if (ColumnName == "Update Over Time Applicable")
            {
                lblComman.Text = ColumnName;
                cmbComman.DataSource = null; 
                cmbComman.Items.Clear();
                lblLocation.Visible = false;
                cmbLocation.Visible = false;
                cmbComman.Visible = false;
                lblComman.Visible = true;
                cbOverTimeApplicable.Visible = true;
            }
            else if (ColumnName == "Update Flexible Hours")
            {
                lblComman.Text = ColumnName;
                cmbComman.DataSource = null;
                cmbComman.Items.Clear();
                lblLocation.Visible = false;
                cmbLocation.Visible = false;
                cmbComman.Visible = false;
                lblComman.Visible = true;
                cbFlexibleHours.Visible = true;
            }
            else
            {

            }
        }

        private bool Validation()
        {
            bool RValue = false;
            objEP.Clear();

            if (ColumnName == "Save New Employee")
            {
                RValue = false;
            }
            else if (ColumnName == "Update Over Time Applicable")
            {
                if (!cbOverTimeApplicable.Checked)
                {
                    cbOverTimeApplicable.Focus();
                    objEP.SetError(cbOverTimeApplicable, "Please check Over Time Applicable");
                    RValue = true;
                }
                else
                    RValue = false;
            }
            else if (ColumnName == "Update Flexible Hours")
            {
                if (!cbFlexibleHours.Checked)
                {
                    cbFlexibleHours.Focus();
                    objEP.SetError(cbFlexibleHours, "Please check Flexible Hours");
                    RValue = true;
                }
                else
                    RValue = false;
            }
            else if (ColumnName == "Update Location and Department")
            {
                if (cmbLocation.SelectedIndex == -1)
                {
                    cmbLocation.Focus();
                    objEP.SetError(cmbLocation, "Select Location");
                    RValue = true;
                }
                else if (cmbComman.SelectedIndex == -1)
                {
                    cmbComman.Focus();
                    objEP.SetError(cmbComman, "Select List");
                    RValue = true;
                }
                else
                    RValue = false;
            }
            else
            {
                if (cmbComman.SelectedIndex == -1)
                {
                    cmbComman.Focus();
                    objEP.SetError(cmbComman, "Select List");
                    RValue = true;
                }
                else
                    RValue = false;
            }

            //if (ColumnName != "Save New Employee")
            //{
            //    if (ColumnName == "Update Location and Department")
            //    {
            //        if (cmbLocation.SelectedIndex == -1)
            //        {
            //            cmbLocation.Focus();
            //            objEP.SetError(cmbLocation, "Select Location");
            //            RValue = true;
            //        }
            //        else
            //            RValue = false;
            //    }
            //    else
            //        RValue = false;

            //    if (!RValue)
            //    {
            //        if (cmbComman.SelectedIndex == -1)
            //        {
            //            cmbComman.Focus();
            //            objEP.SetError(cmbComman, "Select List");
            //            RValue = true;
            //        }
            //        else
            //            RValue = false;
            //    }
            //}
            //else
            //    RValue = false;

            return RValue;
        }

        string UpdateClause = string.Empty;
        string WhereInUpdate = string.Empty;
        string WhereInUpdateAR = string.Empty;

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Validation())
            {
                WhereInUpdate = string.Empty;
                WhereInUpdateAR = string.Empty;
                if (empId.Count > 0)
                {
                    //WhereInUpdate = String.Join(",", new List<uint> { 1, 2, 3, 4, 5 });
                    var csvString = String.Join(",", empId);
                    WhereInUpdate = " and EmployeeId IN (" + csvString + ")";
                    WhereInUpdateAR = " and AR.EmployeeId IN (" + csvString + ")";
                }

                UpdateClause=string.Empty;
                //System implemented by value (if Required)
                //Development 
                if (ColumnName == "Update Location and Department")
                    UpdateClause = " LocationId=" + cmbLocation.SelectedValue + ",DepartmentId=" + cmbComman.SelectedValue + "";
                else if (ColumnName == "Update Contractor")
                    UpdateClause = " ContractorId=" + cmbComman.SelectedValue + "";
                else if (ColumnName == "Update Shift Group")
                    UpdateClause = " ShiftGroupId=" + cmbComman.SelectedValue + "";
                else if (ColumnName == "Update Category")
                    UpdateClause = " CategoryId=" + cmbComman.SelectedValue + "";
                else if (ColumnName == "Update Job Profile")
                    UpdateClause = " JobProfile='" + cmbComman.Text + "'";
                else if (ColumnName == "Update Designation")
                    UpdateClause = " DesignationId=" + cmbComman.SelectedValue + "";
                else if (ColumnName == "Update Employment Type")
                    UpdateClause = " EmployementTypeId=" + cmbComman.SelectedValue + "";
                else if (ColumnName == "Update Status")
                    UpdateClause = " Status='" + cmbComman.Text + "'";
                else if (ColumnName == "Update Over Time Applicable")
                {
                    int OverTimeApplicable = 0;
                    if (cbOverTimeApplicable.Checked)
                        OverTimeApplicable = 1;
                    else
                        OverTimeApplicable = 0;

                    UpdateClause = " OverTimeApplicable=" + OverTimeApplicable + "";
                }
                else if (ColumnName == "Update Flexible Hours")
                {
                    int FlexibleHoursFlag = 0;
                    if (cbFlexibleHours.Checked)
                        FlexibleHoursFlag = 1;
                    else
                        FlexibleHoursFlag = 0;

                    UpdateClause = " FlexibleHoursFlag=" + FlexibleHoursFlag + "";
                }
                else if (ColumnName == "Save New Employee")
                    UpdateClause = " NewFlag=0 ";
                else
                {

                }
                objBL.Query = "update Employees set " + UpdateClause + ",ModifiedUserId=" + BusinessLayer.LoginId_Static + " where CancelTag=0 " + WhereInUpdate + "";
                 Result= objBL.Function_ExecuteNonQuery();

                 if (Result > 0)
                 {
                     if (ColumnName == "Update Location and Department")
                         Recalculate();
                 }
                 objRL.ShowMessage(8, 1);
                 cmbComman.SelectedIndex = -1;
            }
            else
            {

            }
        }

        private void Recalculate()
        {
            int EID = 0, ARID = 0, ARMID = 0;
            DateTime ATDate;

            //WhereInUpdate
            objPC.LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
            objPC.DepartmentId = Convert.ToInt32(cmbComman.SelectedValue);

            //AttendanceRecord
            DataTable dt = new DataTable();
            objBL.Query = "select AR.AttendanceRecordId,ARM.AttendanceRecordMasterId,AR.EmployeeId,ARM.AttendanceDate from attendancerecord AR inner join attendancerecordmaster ARM on ARM.AttendanceRecordMasterId=AR.AttendanceRecordMasterId where AR.CancelTag=0 and ARM.CancelTag=0 and ARM.CompleteFlag=0 " + WhereInUpdateAR + " order by AR.EmployeeId asc";
            dt = objBL.ReturnDataTable();
         
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    EID = 0; ARID = 0; ARMID = 0;
                    ARID = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[i]["AttendanceRecordId"])));
                    ATDate = Convert.ToDateTime(dt.Rows[i]["AttendanceDate"]);
                    ARMID = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[i]["AttendanceRecordMasterId"])));

                    //objBL.Query = "select ARM.AttendanceRecordMasterId,AR.EmployeeId,AR.AttendanceRecordId from attendancerecord AR inner join attendancerecordmaster ARM on ARM.AttendanceRecordMasterId=AR.AttendanceRecordMasterId where AR.CancelTag=0 and ARM.CancelTag=0 and ARM.CompleteFlag=0 and ARM.LocationId=4 and ARM.DepartmentId=33 and ARM.AttendanceDate='" + ATDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";
                    objBL.Query = "SELECT * from attendancerecordmaster where LocationId=" + objPC.LocationId + " and DepartmentId=" + objPC.DepartmentId + " and AttendanceDate='" + ATDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";
                    DataTable dtAR = new DataTable();
                    //objBL.Query = "select ARM.AttendanceRecordMasterId,AR.EmployeeId,AR.AttendanceRecordId from attendancerecord AR inner join attendancerecordmaster ARM on ARM.AttendanceRecordMasterId=AR.AttendanceRecordMasterId where AR.CancelTag=0 and ARM.CancelTag=0 and ARM.CompleteFlag=0 and ARM.LocationId=" + objPC.LocationId + " and ARM.DepartmentId=" + objPC.DepartmentId + "";
                    dtAR = objBL.ReturnDataTable();

                    if (dtAR.Rows.Count > 0)
                    {
                        int NewAttendanceRecordMasterId = 0;
                        NewAttendanceRecordMasterId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dtAR.Rows[0]["AttendanceRecordMasterId"])));
                        //objPC.AttendanceRecordId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dtAR.Rows[j]["AttendanceRecordId"])));

                        objBL.Query = "update attendancerecord set AttendanceRecordMasterId=" + NewAttendanceRecordMasterId + " where AttendanceRecordId=" + ARID + " and CancelTag=0";
                        Result = objBL.Function_ExecuteNonQuery();

                        //for (int j = 0; j < dtAR.Rows.Count; j++)
                        //{
                        //    NewAttendanceRecordMasterId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dtAR.Rows[j]["AttendanceRecordMasterId"])));
                        //    //objPC.AttendanceRecordId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dtAR.Rows[j]["AttendanceRecordId"])));
                            
                        //    objBL.Query = "update attendancerecord set AttendanceRecordMasterId=" + NewAttendanceRecordMasterId + " where AttendanceRecordId=" + objPC.AttendanceRecordId + " and CancelTag=0";
                        //    Result= objBL.Function_ExecuteNonQuery();
                        //}
                    }
                }
            }
        }

        private void CommanEdit_Load(object sender, EventArgs e)
        {

        }

        private void cmbLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbLocation.SelectedIndex > -1)
            {
                objPC.LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
                objRL.Fill_Department_ComboBox_By_Location(cmbComman, Convert.ToInt16(cmbLocation.SelectedValue));
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }
    }
}
