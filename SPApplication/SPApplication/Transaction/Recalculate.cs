using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayerUtility;

namespace SPApplication.Transaction
{
    public partial class Recalculate : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();

        PropertyClass objPC = new PropertyClass();
        AttendanceLogics objAL = new AttendanceLogics();
        
        public Recalculate()
        {
            InitializeComponent();
            objDL.SetLabelDesign(lblHeader, BusinessResources.Recalculate_M);
            //objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_ATTENDANCEAPPROVAL);
            btnRecalculate.Text = BusinessResources.BTN_RECALCULATE;
            btnClear.Text = BusinessResources.BTN_CLEAR;
            btnExit.Text = BusinessResources.BTN_EXIT;
        }

        private void Recalculate_Load(object sender, EventArgs e)
        {
            ClearAll();
            dtpFromDate.Value = DateTime.Now.Date;
            dtpToDate.Value = DateTime.Now.Date;    
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            objPC.CalculateFor = "";
            if (cmbCalculateFor.SelectedIndex > -1)
            {
                objPC.CalculateFor = cmbCalculateFor.Text;

                if (cmbCalculateFor.Text == "Leave")
                    objAL.Recalculate_Leave(dtpFromDate.Value, dtpToDate.Value);
                else if (cmbCalculateFor.Text == "Comp Off")
                    objAL.Recalculate_CompOff(dtpFromDate.Value, dtpToDate.Value);
                else if (cmbCalculateFor.Text == "Weekly Off")
                    objAL.Recalculate_CompOff(dtpFromDate.Value, dtpToDate.Value);
                else if (cmbCalculateFor.Text == "Database Updates")
                {
                    UpdatesInDatabase();
                }
                //else
                //    objAL.ReCalculate_Funcation(dtpFromDate.Value, dtpToDate.Value);
            }
        }
        int Result = 0;

        private void UpdatesInDatabase()
        {
            string columnDefinition = " int ";

            List<string> TableName = new List<string>();

            //15
            TableName.Add("attendancelogpunchrecord");
            TableName.Add("attendancelogsexcel");
            TableName.Add("attendancemonthlydata");
            TableName.Add("attendancerecord");
            TableName.Add("attendancerecordmaster");
            TableName.Add("attendancehistory");
            TableName.Add("attendancelogpunchrecord");
            TableName.Add("compoffapplication");
            TableName.Add("departmentsummaryreport");
            TableName.Add("Employees");
            TableName.Add("employeeseffect");
            TableName.Add("holidaymaster");
            TableName.Add("leaveapplication");
            TableName.Add("memo");
            TableName.Add("manpowerrequirements");
            TableName.Add("reportdata");
            TableName.Add("tempcountreport");
            TableName.Add("tempdepartmentwisedesignationattendancereport");
            TableName.Add("ticket");
            TableName.Add("memo");
            //TableName.Add("employeeseffect");

            for (int i = 0; i < TableName.Count; i++)
            {
                objBL.Query = string.Empty;
                string query = "ALTER TABLE " + TableName[i].ToString() + " ADD COLUMN FinancialYearId " + columnDefinition + " ";
                objBL.Query = query;
                Result = objBL.Function_ExecuteNonQuery();

                objBL.Query = string.Empty;
                objBL.Query = "update " + TableName[i].ToString() + " set FinancialYearId=1";
                Result = objBL.Function_ExecuteNonQuery();
            }

            //string tableName = "your_table"; // Name of your table
            //string columnName = "new_column"; // Name of the new column
            //string columnDefinition = "int"; // Define the column type and constraints as needed

            objRL.ShowMessage(50, 1);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            objPC.ClearAttendanceRecords();
            dtpFromDate.Value = DateTime.Now.Date;
            dtpToDate.Value = DateTime.Now.Date;
        }
    }
}
