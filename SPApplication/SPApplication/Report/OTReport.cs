using BusinessLayerUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace SPApplication.Report.HRReports
{
    public partial class OTReport : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();
        AttendanceLogics objAL = new AttendanceLogics();
        public OTReport()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnView, btnClear, btnReport, btnExit, "Over Time (OT) Month Wise Report");
            btnView.Text = BusinessResources.BTN_VIEW;
            btnReport.Text = BusinessResources.BTN_REPORT;
            Fill_Data();
            ClearAll();
        }

        private void ClearAll()
        {
            cbSelectAllLocation.Checked = true;
            cbSelectAllDepartment.Checked = true;
            cmbLocation.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            dataGridView1.Rows.Clear();
            cbSelectAllLocation.Checked = true;
            cbSelectAllDepartment.Checked = true;
            cbRoll.Checked = true;
            cmbLocation.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            cmbMonth.SelectedIndex = -1;
            cmbYear.SelectedIndex = -1;
            cmbRoll.SelectedIndex = -1;
            cbStatusAll.Checked = true;
            SetMonthYear();
        }

        private void Fill_Data()
        {
            objRL.Fill_Contractor_IN_Attendance(cmbRoll);
            objRL.FillLocation(cmbLocation, cmbDepartment);
        }

        private void SetMonthYear()
        {
            string MonthName = objRL.GetMonthName(DateTime.Now.Date.Month);
            int YearNo = DateTime.Now.Year;

            cmbYear.Text = YearNo.ToString();
            cmbMonth.Text = MonthName.ToString();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cbSelectAllLocation_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSelectAllLocation.Checked)
            {
                cmbLocation.SelectedIndex = -1;
                cmbLocation.Enabled = false;
            }
            else
            {
                cmbLocation.SelectedIndex = -1;
                cmbLocation.Enabled = true;
            }
        }

        private void cbSelectAllDepartment_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSelectAllDepartment.Checked)
            {
                cmbDepartment.SelectedIndex = -1;
                cmbDepartment.Enabled = false;
            }
            else
            {
                cmbDepartment.SelectedIndex = -1;
                cmbDepartment.Enabled = true;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            FillGrid();
        }

        string MainQuery = string.Empty, WhereClause = string.Empty, OrderByClause = string.Empty;
        private void FillGrid()
        {
            DataSet ds = new DataSet();
            WhereClause = string.Empty;

            dataGridView1.Rows.Clear();

            if (!cbSelectAllLocation.Checked)
                WhereClause += " and AMD.LocationId=" + cmbLocation.SelectedValue + "";
            //else
            //    WhereClause += " and " + objQL.Get_Location_Id("Location") + " ";

            if (!cbSelectAllDepartment.Checked)
                WhereClause += " and AMD.DepartmentId=" + cmbDepartment.SelectedValue + "";
            //else
            //    WhereClause += " and " + objQL.Get_Location_Id("Department");

            if (!cbRoll.Checked)
                WhereClause += " and E.ContractorId=" + cmbRoll.SelectedValue + "";

            if (cmbMonth.SelectedIndex >-1 && cmbYear.SelectedIndex >-1)
                WhereClause += " and AMD.AMonth=" + objRL.GetMonthNumber(cmbMonth.Text) + " and AMD.AYear=" + cmbYear.Text + " ";
            //WhereClass_Date = " and ARM.AttendanceDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";
            //else

            OrderByClause = " order by E.EmployeeCode asc";

            MainQuery = "select " +
                        "AMD.*,E.EmployeeCode,E.EmployeeName,C.ContractorName,L.LocationName,D.Department " +
                        //"Id," +
                        //"AYear," +
                        //"AMonth," +
                        //"LocationId," +
                        //"DepartmentId," +
                        //"EmployeeId," +
                        //"E.EmployeeName," +
                        //"AtId1," +
                        //"ShiftId1," +
                        //"In1," +
                        //"Out1," +
                        //"Duration1," +
                        //"Status1," +
                        //"OT1," +
                        //"LT1," +
                        //"AtId2," +
                        //"ShiftId2," +
                        //"In2," +
                        //"Out2 ," +
                        //"Duration2 ," +
                        //"Status2 ," +
                        //"OT2 ," +
                        //"LT2 ," +
                        //"AtId3 ," +
                        //"ShiftId3 ," +
                        //"In3 ," +
                        //"Out3 ," +
                        //"Duration3 ," +
                        //"Status3 ," +
                        //"OT3 ," +
                        //"LT3 ," +
                        //"AtId4 ," +
                        //"ShiftId4 ," +
                        //"In4 ," +
                        //"Out4 ," +
                        //"Duration4 ," +
                        //"Status4 ," +
                        //"OT4 ," +
                        //"LT4 ," +
                        //"AtId5 ," +
                        //"ShiftId5 ," +
                        //"In5 ," +
                        //"Out5 ," +
                        //"Duration5 ," +
                        //"Status5 ," +
                        //"OT5 ," +
                        //"LT5 ," +
                        //"AtId6 ," +
                        //"ShiftId6 ," +
                        //"In6 ," +
                        //"Out6 ," +
                        //"Duration6 ," +
                        //"Status6 ," +
                        //"OT6 ," +
                        //"LT6 ," +
                        //"AtId7 ," +
                        //"ShiftId7 ," +
                        //"In7 ," +
                        //"Out7 ," +
                        //"Duration7 ," +
                        //"Status7 ," +
                        //"OT7 ," +
                        //"LT7 ," +
                        //"AtId8 ," +
                        //"ShiftId8 ," +
                        //"Status8 ," +
                        //"In8 ," +
                        //"Out8 ," +
                        //"Duration8 ," +
                        //"OT8 ," +
                        //"LT8 ," +
                        //"AtId9 ," +
                        //"ShiftId9 ," +
                        //"In9 ," +
                        //"Out9 ," +
                        //"Duration9 ," +
                        //"Status9 ," +
                        //"OT9 ," +
                        //"LT9 ," +
                        //"AtId10 ," +
                        //"ShiftId10 ," +
                        //"In10 ," +
                        //"Out10 ," +
                        //"Duration10 ," +
                        //"Status10 ," +
                        //"OT10 ," +
                        //"LT10 ," +
                        //"AtId11 ," +
                        //"ShiftId11 ," +
                        //"In11 ," +
                        //"Out11 ," +
                        //"Duration11 ," +
                        //"Status11 ," +
                        //"OT11 ," +
                        //"LT11 ," +
                        //"AtId12 ," +
                        //"ShiftId12 ," +
                        //"In12 ," +
                        //"Out12 ," +
                        //"Duration12 ," +
                        //"Status12 ," +
                        //"OT12 ," +
                        //"LT12 ," +
                        //"AtId13 ," +
                        //"ShiftId13 ," +
                        //"In13 ," +
                        //"Out13 ," +
                        //"Duration13 ," +
                        //"Status13 ," +
                        //"OT13 ," +
                        //"LT13 ," +
                        //"AtId14 ," +
                        //"ShiftId14 ," +
                        //"In14 ," +
                        //"Out14 ," +
                        //"Duration14 ," +
                        //"Status14 ," +
                        //"OT14 ," +
                        //"LT14 ," +
                        //"AtId15 ," +
                        //"ShiftId15 ," +
                        //"In15 ," +
                        //"Out15 ," +
                        //"Duration15 ," +
                        //"Status15 ," +
                        //"OT15 ," +
                        //"LT15 ," +
                        //"ShiftId16 ," +
                        //"AtId16 ," +
                        //"In16 ," +
                        //"Out16 ," +
                        //"Duration16 ," +
                        //"Status16 ," +
                        //"OT16 ," +
                        //"LT16 ," +
                        //"AtId17 ," +
                        //"ShiftId17 ," +
                        //"In17 ," +
                        //"Out17 ," +
                        //"Duration17 ," +
                        //"Status17 ," +
                        //"OT17 ," +
                        //"LT17 ," +
                        //"AtId18 ," +
                        //"ShiftId18 ," +
                        //"In18 ," +
                        //"Out18 ," +
                        //"Duration18 ," +
                        //"Status18 ," +
                        //"OT18 ," +
                        //"LT18 ," +
                        //"AtId19 ," +
                        //"ShiftId19 ," +
                        //"In19 ," +
                        //"Out19 ," +
                        //"Duration19 ," +
                        //"Status19 ," +
                        //"OT19 ," +
                        //"LT19 ," +
                        //"AtId20 ," +
                        //"ShiftId20 ," +
                        //"In20 ," +
                        //"Out20 ," +
                        //"Duration20 ," +
                        //"Status20 ," +
                        //"OT20 ," +
                        //"LT20 ," +
                        //"AtId21," +
                        //"ShiftId21 ," +
                        //"In21 ," +
                        //"Out21 ," +
                        //"Duration21 ," +
                        //"Status21 ," +
                        //"OT21 ," +
                        //"LT21 ," +
                        //"AtId22 ," +
                        //"ShiftId22 ," +
                        //"In22 ," +
                        //"Out22 ," +
                        //"Duration22 ," +
                        //"Status22 ," +
                        //"OT22 ," +
                        //"LT22 ," +
                        //"AtId23 ," +
                        //"ShiftId23 ," +
                        //"In23 ," +
                        //"Out23 ," +
                        //"Duration23 ," +
                        //"OT23 ," +
                        //"Status23 ," +
                        //"LT23 ," +
                        //"AtId24 ," +
                        //"ShiftId24 ," +
                        //"In24 ," +
                        //"Out24 ," +
                        //"Duration24 ," +
                        //"Status24 ," +
                        //"OT24 ," +
                        //"LT24 ," +
                        //"AtId25 ," +
                        //"ShiftId25 ," +
                        //"In25 ," +
                        //"Out25 ," +
                        //"Duration25 ," +
                        //"Status25 ," +
                        //"OT25 ," +
                        //"LT25 ," +
                        //"AtId26 ," +
                        //"ShiftId26 ," +
                        //"In26 ," +
                        //"Out26 ," +
                        //"Duration26 ," +
                        //"Status26 ," +
                        //"OT26 ," +
                        //"LT26 ," +
                        //"AtId27 ," +
                        //"ShiftId27 ," +
                        //"In27 ," +
                        //"Out27 ," +
                        //"Duration27 ," +
                        //"Status27 ," +
                        //"OT27 ," +
                        //"LT27 ," +
                        //"AtId28 ," +
                        //"ShiftId28 ," +
                        //"In28 ," +
                        //"Out28 ," +
                        //"Duration28 ," +
                        //"Status28 ," +
                        //"OT28 ," +
                        //"LT28 ," +
                        //"AtId29 ," +
                        //"ShiftId29 ," +
                        //"In29 ," +
                        //"Out29 ," +
                        //"Duration29 ," +
                        //"Status29 ," +
                        //"OT29 ," +
                        //"LT29 ," +
                        //"AtId30 ," +
                        //"ShiftId30 ," +
                        //"In30 ," +
                        //"Out30 ," +
                        //"Duration30 ," +
                        //"Status30 ," +
                        //"OT30 ," +
                        //"LT30 ," +
                        //"AtId31 ," +
                        //"ShiftId31 ," +
                        //"In31 ," +
                        //"Out31 ," +
                        //"Duration31 ," +
                        //"Status31 ," +
                        //"OT31 ," +
                        //"LT31 ," +
                        //"TotalPresent ," +
                        //"TotalAbsent ," +
                        //"TotalOT ," +
                        //"TotalHours ," +
                        //"TotalWeeklyOff ," +
                        //"TotalHoliday ," +
                        //"TotalLateBy ," +
                        //"TotalEarlyBy " +
                        " from " +
                        " attendancemonthlydata AMD inner join " +
                        " Employees E on E.EmployeeId=AMD.EmployeeId inner join contractormaster C on C.ContractorId=E.ContractorId inner join locationmaster L on L.LocationId=E.LocationId inner join departmentmaster D on D.DepartmentId=E.DepartmentId " +
                        " where AMD.CancelTag = 0 and E.CancelTag=0 and E.OverTimeApplicable=1 and C.CancelTag=0 and E.EmployeeCode NOT IN" +
                        "(100001,100004,50002,50003,50004,50005,50006,50007,50008,50009,50010,50011,50013,50014,50015,50016,50017,50018,50019,50020,50012,50021,50022,50023,50024,50025,50026,50027,50028) ";// and AMD.FinancialYearId=" + objPC.FinancialYearId + " ";

            objBL.Query = MainQuery +WhereClause +OrderByClause;
            ds = objBL.ReturnDataSet();

            if(ds.Tables[0].Rows.Count > 0 )
            {
                dataGridView1.Rows.Clear();
                
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++) 
                {
                    TotalOTDays = 0;
                    TimeSpan TotalOTTime = TimeSpan.Zero;
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["clmLocation"].Value = ds.Tables[0].Rows[i]["LocationName"].ToString();
                    dataGridView1.Rows[i].Cells["clmDepartment"].Value = ds.Tables[0].Rows[i]["Department"].ToString();
                    dataGridView1.Rows[i].Cells["clmRoll"].Value = ds.Tables[0].Rows[i]["ContractorName"].ToString();
                    dataGridView1.Rows[i].Cells["clmEmployeeCode"].Value = ds.Tables[0].Rows[i]["EmployeeCode"].ToString();
                    dataGridView1.Rows[i].Cells["clmEmployeeName"].Value = ds.Tables[0].Rows[i]["EmployeeName"].ToString();

                    //if(dataGridView1.Rows[i].Cells["clmEmployeeCode"].Value.ToString() == "524")
                    //{

                    //}
                    for (int j = 1; j <= 31; j++)
                    {
                        TimeSpan t1 = TimeSpan.Zero;

                        ColumnName1 = string.Empty;
                        ColumnName1 = "OT" + j;
                        string TimeString = string.Empty;
                        TimeString = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i][ColumnName1]));

                        t1 = TimeSpan.Zero;

                        if(!string.IsNullOrEmpty(Convert.ToString(TimeString)))
                            t1 = TimeSpan.Parse(TimeString);


                        string HoursC1 = t1.TotalHours.ToString();
                        double hours1 = t1.TotalHours;

                        //Fill_OT_Values(dataGridView1, i, j, objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i][ColumnName1])));

                        Fill_OT_Values(dataGridView1, i, j, objRL.CheckNullString(Convert.ToString(HoursC1)));

                        if (TimeString != "")
                        {
                            TimeSpan OTTime = TimeSpan.Zero;
                            OTTime = TimeSpan.Parse(TimeString);
                            TotalOTTime = TotalOTTime + OTTime; // TimeSpan.Parse(TimeString);

                            if (OTTime > TimeSpan.Zero)
                            {
                                TotalOTDays++;
                            }
                        }
                    }
                    string HoursC = TotalOTTime.TotalHours.ToString();
                    double hours = TotalOTTime.TotalHours;
                    dataGridView1.Rows[i].Cells["clmTotalOT"].Value = hours.ToString();
                    dataGridView1.Rows[i].Cells["clmTotalOTDays"].Value = TotalOTDays.ToString();
                }
            }
        }

        int TotalOTDays = 0;
        private void cmbLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbLocation.SelectedIndex > -1)
                objRL.FillDepartment(cmbLocation, cmbDepartment);
        }

        private void OTReport_Load(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        
        string ColumnName1 = string.Empty;
        private void Fill_OT_Values(DataGridView dgv,int RowNo,int Cno,string ValueD)
        {
            ColumnName1 = string.Empty;
            ColumnName1 = "clm" + Cno;
            dgv.Rows[RowNo].Cells[ColumnName1].Value = ValueD;
            dgv.Columns[ColumnName1].Width= 50;
        }
    }
}
