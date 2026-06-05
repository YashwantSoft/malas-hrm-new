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

namespace SPApplication.Report
{
    public partial class ManpowerDashboard : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();

        PropertyClass objPC = new PropertyClass();
        AttendanceLogics objAL = new AttendanceLogics();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0, LocationId = 0;

        int SrNo = 1;
        string MainQuery = string.Empty;
        string WhereClause = string.Empty;
        DateTime dtInTime, dtOutTime;
        TimeSpan TOT;
        
        public ManpowerDashboard()
        {
            InitializeComponent();
            lblHeader.Text = "Manpower Dashboard";
            btnView.Text = BusinessResources.BTN_VIEW;
            objRL.FillLocation(cmbLocation, cmbDepartment);
            //objRL.Fill_Approval_Status(cmbAttendanceStatus);
            //ClearAll();
            objDL.SetButtonDesign(btnView, BusinessResources.BTN_VIEW);
            objDL.SetButtonDesign(btnClear, BusinessResources.BTN_CLEAR);
            objDL.SetButtonDesign(btnExit, BusinessResources.BTN_EXIT);
            lblHeader.BackColor = objDL.GetBackgroundColor();
            lblHeader.ForeColor = objDL.GetForeColor();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (!Validation())
            {
                //objAL.Set_Manpower_Count(dtpDate.Value, dtpDate.Value);
                //objAL.Set_Manpower_Count(dtpDate.Value);
                //FillGrid();
                FillGridNew();
            }
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void cbToday_CheckedChanged(object sender, EventArgs e)
        {
            if (cbToday.Checked)
            {
                dtpDate.Value = DateTime.Now.Date;
                dtpDate.Enabled = false;
            }
            else
            {
                dtpDate.Value = DateTime.Now.Date;
                dtpDate.Enabled = true;
            }
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmbLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbLocation.SelectedIndex > -1)
                objRL.FillDepartment(cmbLocation, cmbDepartment);
        }

        private bool Validation()
        {
            bool RetrunFlag = false;
            objEP.Clear();

            if (!cbSelectAllLocation.Checked)
            {
                if (cmbLocation.SelectedIndex == -1)
                {
                    cmbLocation.Focus();
                    objEP.SetError(cmbLocation, "Select Location");
                    RetrunFlag = true;
                }
                else
                    RetrunFlag = false;
            }
            else
                RetrunFlag = false;

            if (!RetrunFlag)
            {
                if (!cbSelectAllDepartment.Checked)
                {
                    if (cmbDepartment.SelectedIndex == -1)
                    {
                        cmbDepartment.Focus();
                        objEP.SetError(cmbDepartment, "Select Department");
                        RetrunFlag = true;
                    }
                    else
                        RetrunFlag = false;
                }
                else
                    RetrunFlag = false;
            }

            return RetrunFlag;
        }

        private void ClearAll()
        {
            TableId = 0;
            cbSelectAllLocation.Checked = true;
            cbSelectAllDepartment.Checked = true;
            cmbLocation.Enabled = false;
            cmbLocation.Enabled = false;
          
            cmbLocation.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
         
            TOT = TimeSpan.Zero;
            dataGridView1.Rows.Clear();
        }

        string WhereClauseAdd = string.Empty;
      
        private int Get_Count(string SearchFor)
        {
            int empcount = 0;
            DataTable ds = new DataTable();
            WhereClause = string.Empty;
            MainQuery = string.Empty;

            WhereClause = " and ARM.AttendanceDate='" + dtpDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and AR.OverTime !='00:00' ";
             
            //    WhereClause += " and E.LocationId=" + objPC.LocationId + "";
             
            //if (!cbSelectAllDepartment.Checked)
            //    WhereClause += " and E.DepartmentId=" + objPC.DepartmentId + "";
            //else
            //    WhereClause += " and " + objQL.Get_Location_Id("Department");

            if (!string.IsNullOrEmpty(Convert.ToString(SearchFor)))
                WhereClause += WhereClauseAdd; // " and DM.DesignationCategory='" + SearchFor + "'";

            MainQuery = "select " +
                         " count(AR.AttendanceRecordId) as 'empcount'" +
                         " from AttendanceRecord AR inner join " +
                         " attendancerecordmaster ARM on ARM.AttendanceRecordMasterId=AR.AttendanceRecordMasterId inner join " +
                         " Employees E on E.EmployeeId=AR.EmployeeId inner join " +
                         " locationmaster L on L.LocationId=E.LocationId inner join " +
                         " designationmaster DM on DM.DesignationId=E.DesignationId inner join " +
                         " departmentmaster D on D.DepartmentId=E.DepartmentId " +
                         " where " +
                         " AR.CancelTag=0 and" +
                         " ARM.CancelTag=0 and" +
                         " E.CancelTag=0 and "+
                         " E.LocationId=" + objPC.LocationId + " and " +
                         " E.DepartmentId=" + objPC.DepartmentId + "";

            objBL.Query = MainQuery + WhereClause + WhereClause + " order by E.EmployeeCode asc";
            ds = objBL.ReturnDataTable();

            if (ds.Rows.Count > 0)
                empcount = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[0]["empcount"])));
            else
                empcount = 0;

            return empcount;
        }

        private void FillGrid()
        {
            objEP.Clear();
            dataGridView1.Rows.Clear();
           
            DataTable ds = new DataTable();
            WhereClause = string.Empty;
            MainQuery = string.Empty;

            WhereClause = " and ARM.AttendanceDate='" + dtpDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";

            if (!cbSelectAllLocation.Checked)
                WhereClause += " and ARM.LocationId=" + cmbLocation.SelectedValue + "";
            else
            {
                objQL.WhereClause_V = "  and lwd.PlantHeadId=" + BusinessLayer.EmployeeLoginId_Static + " ";
                //WhereClause += " and " + objQL.Get_Location_Id_Type_Object("Location", "L.") + " ";
            }

            if (!cbSelectAllDepartment.Checked)
                WhereClause += " and ARM.DepartmentId=" + cmbDepartment.SelectedValue + "";
            else
            {
                objQL.WhereClause_V = "  and lwd.PlantHeadId=" + BusinessLayer.EmployeeLoginId_Static + " ";
                //WhereClause += " and " + objQL.Get_Location_Id_Type_Object("Department", "D.");
            }

            WhereClause += objRL.WhereClasuse_CompOff_Comman();
            //MainQuery = "select lwd.LocationId,L.LocationName,lwd.DepartmentId,D.Department from locationwisedepartment lwd inner join locationmaster L on L.LocationId=lwd.LocationId inner join departmentmaster d on d.DepartmentId=lwd.DepartmentId where lwd.CancelTag=0 and d.CancelTag=0 and L.CancelTag=0 ";
            //MainQuery = "select * from attendancerecordmaster where CancelTag=0 " + WhereClause + "";

            //DepartmentMaster DM on DM.DepartmentId=ARM.DepartmentId inner join 
            //LocationMaster LM on LM.LocationId=ARM.LocationId inner join 
            //locationwisedepartmentusers LWDU on LM.LocationId=LWDU.LocationId and DM.DepartmentId=LWDU.DepartmentId 

            MainQuery = "select distinct ARM.AttendanceRecordMasterId,ARM.LocationId,LM.LocationName,ARM.DepartmentId,DM.Department,ARM.PRESENTMANPOWER,ARM.ADMINISTRATOR,ARM.HROFFICER,ARM.MANAGER,ARM.OFFICER,ARM.SENIOROFFICER,ARM.SUPERVISOR,ARM.TRAINEE,ARM.WORKER,ARM.CONTRACTWORKER,ARM.TOTAL,ARM.ABSENT,ARM.PERCENTAGE from " +
                        " attendancerecordmaster ARM inner join " +
                        " DepartmentMaster DM on DM.DepartmentId=ARM.DepartmentId inner join " +
                        " LocationMaster LM on LM.LocationId=ARM.LocationId inner join " +
                        " locationwisedepartmentusers LWDU on LM.LocationId=LWDU.LocationId and DM.DepartmentId=LWDU.DepartmentId ";

                        //" locationmaster L on L.LocationId=ARM.LocationId inner join " +
                        //" departmentmaster D on D.DepartmentId=ARM.DepartmentId ";

            //             " designationmaster DM on DM.DesignationId=E.DesignationId inner join " +
            //             " departmentmaster D on D.DepartmentId=E.DepartmentId " +
            //             " where " +
            //             " AR.CancelTag=0 and" +
            //             " ARM.CancelTag=0 and" +
            //             " E.CancelTag=0 and " +
            //             " S.CancelTag=0 ";

            //MainQuery = "select " +
            //             "E.LocationId,"+
            //             "L.LocationName," +
            //             "E.DepartmentId," +
            //             "D.Department" +
            //             " from AttendanceRecord AR inner join " +
            //             " attendancerecordmaster ARM on ARM.AttendanceRecordMasterId=AR.AttendanceRecordMasterId inner join " +
            //             " Employees E on E.EmployeeId=AR.EmployeeId inner join " +
            //             " shifts S on S.ShiftId=AR.ShiftId inner join " +
            //             " locationmaster L on L.LocationId=E.LocationId inner join " +
            //             " designationmaster DM on DM.DesignationId=E.DesignationId inner join " +
            //             " departmentmaster D on D.DepartmentId=E.DepartmentId " +
            //             " where " +
            //             " AR.CancelTag=0 and" +
            //             " ARM.CancelTag=0 and" +
            //             " E.CancelTag=0 and " +
            //             " S.CancelTag=0 ";

            objBL.Query = MainQuery + WhereClause + "  order by LM.LocationName asc";
            ds = objBL.ReturnDataTable();

            //string LocId= objQL.Get_Location_Id("Location");
            //string DepId = objQL.Get_Location_Id("Department");

            
            if (ds.Rows.Count > 0)
            {
                dataGridView1.Columns["clmADMINISTRATOR"].Visible = false;
                dataGridView1.Columns["clmHROFFICER"].Visible = false;

                //lblTotalCount.Text = "Total Count: " + ds.Rows.Count.ToString();
                SrNo = 1;
                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    //"E.LocationId," +
                    //"L.LocationName," +
                    //"E.DepartmentId," +
                    //"D.Department" +
                    WhereClauseAdd = string.Empty;

                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["clmSrNo"].Value = SrNo.ToString();
                    objPC.LocationId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LocationId"])));
                    dataGridView1.Rows[i].Cells["clmLocationId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LocationId"])); //ds.Rows[i]["AttendanceRecordId"].ToString();
                    objPC.DepartmentId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["DepartmentId"])));
                    dataGridView1.Rows[i].Cells["clmDepartmentId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["DepartmentId"]));
                    dataGridView1.Rows[i].Cells["clmLocation"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LocationName"]));
                    dataGridView1.Rows[i].Cells["clmDepartment"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Department"]));

                    //, ADMINISTRATOR,HROFFICER,MANAGER,OFFICER,SENIOROFFICER,SUPERVISOR,TRAINEE,WORKER,CONTRACTWORKER,TOTAL,ABSENT,PERCENTAGE
                    dataGridView1.Rows[i].Cells["clmPresentManpower"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["PRESENTMANPOWER"]));
                    dataGridView1.Rows[i].Cells["clmManagers"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["MANAGER"]));
                    dataGridView1.Rows[i].Cells["clmSeniorOfficers"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["SENIOROFFICER"]));
                    dataGridView1.Rows[i].Cells["clmOfficers"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["OFFICER"]));
                    //dataGridView1.Rows[i].Cells["clmIncharges"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Department"]));
                    dataGridView1.Rows[i].Cells["clmSupervisors"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["SUPERVISOR"]));
                    dataGridView1.Rows[i].Cells["clmWorkers"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["WORKER"]));
                    dataGridView1.Rows[i].Cells["clmContractWorkers"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["CONTRACTWORKER"]));
                    dataGridView1.Rows[i].Cells["clmTRAINEE"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["TRAINEE"]));
                    dataGridView1.Rows[i].Cells["clmTotal"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["TOTAL"]));
                    dataGridView1.Rows[i].Cells["clmAbsent"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ABSENT"]));
                    dataGridView1.Rows[i].Cells["clmPresentPer"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["PERCENTAGE"]));

                    //WhereClauseAdd = " and AR.Status='P'";
                    //dataGridView1.Rows[i].Cells["clmPresentManpower"].Value = Convert.ToString(Get_Count(""));
                    //WhereClauseAdd = " and AR.Status='P' and DM.DesignationCategory IN('" + BusinessResources.USER_TYPE_MANAGER + "')";
                    //dataGridView1.Rows[i].Cells["clmManagers"].Value = Convert.ToString(Get_Count(BusinessResources.USER_TYPE_MANAGER));
                    
                    //dataGridView1.Rows[i].Cells["clmSeniorOfficers"].Value = Convert.ToString(Get_Count(BusinessResources.USER_TYPE_SENIOROFFICER));
                    //dataGridView1.Rows[i].Cells["clmOfficers"].Value = Convert.ToString(Get_Count(BusinessResources.USER_TYPE_OFFICER));
                    //dataGridView1.Rows[i].Cells["clmIncharges"].Value = Convert.ToString(Get_Count(BusinessResources.USER_TYPE_INCHARGE));
                    //dataGridView1.Rows[i].Cells["clmSupervisors"].Value = Convert.ToString(Get_Count(BusinessResources.USER_TYPE_SUPERVISOR));
                    //dataGridView1.Rows[i].Cells["clmOperators"].Value = Convert.ToString(Get_Count(BusinessResources.USER_TYPE_WORKER));
                    //dataGridView1.Rows[i].Cells["clmWorkers"].Value = Convert.ToString(Get_Count(BusinessResources.USER_TYPE_WORKER));
                    //dataGridView1.Rows[i].Cells["clmContractWorkers"].Value = Convert.ToString(Get_Count(BusinessResources.USER_TYPE_WORKER));
                    //dataGridView1.Rows[i].Cells["clmContractWorkers"].Value = Convert.ToString(Get_Count(BusinessResources.USER_TYPE_WORKER));

                    SrNo++;
                }
                dataGridView1.ClearSelection();
            }
        }

        public class CursorWait : IDisposable
        {
            public CursorWait(bool appStarting = false, bool applicationCursor = false)
            {
                // Wait
                Cursor.Current = appStarting ? Cursors.AppStarting : Cursors.WaitCursor;
                if (applicationCursor) System.Windows.Forms.Application.UseWaitCursor = true;
            }

            public void Dispose()
            {
                // Reset
                Cursor.Current = Cursors.Default;
                System.Windows.Forms.Application.UseWaitCursor = false;
            }
        }

        string OrderBy = string.Empty;

        private void FillGridNew()
        {
            objEP.Clear();
            dataGridView1.Rows.Clear();

           
            DataTable ds = new DataTable();
            WhereClause = string.Empty;
            MainQuery = string.Empty;
            OrderBy = string.Empty;

            //MainQuery = "select " +
            //            "LM.LocationName as 'Location'," +
            //            "DM.Department, " +
            //            "CM.ContractorName, " +
            //            "E.EmployeeId," +
            //            "E.EmployeeCode," +
            //            "E.EmployeeName," +
            //            "DES.Designation," +
            //            "E.OpeningLeave as 'Opening'," +
            //            "E.CurrentLeave as 'Current'," +
            //            "E.TotalApplicableLeave as 'Applicable'," +
            //            "E.EnjoyLeave as 'Enjoy'," +
            //            "E.BalanceLeave as 'Balance'," +
            //            "E.CategoryId," +
            //            "E.FlexibleHoursFlag "+
            //            " from " +
            //            "Employees E inner join  " +
            //            "DepartmentMaster DM on DM.DepartmentId=E.DepartmentId inner join " +
            //            "DesignationMaster DES on DES.DesignationId=E.DesignationId inner join " +
            //            "LocationMaster LM on LM.LocationId=E.LocationId inner join contractormaster CM on CM.ContractorId=E.ContractorId " +
            //            " where  E.CancelTag=0 and DM.CancelTag=0 and DES.CancelTag=0 and LM.CancelTag=0 and CM.CancelTag=0 ";


            MainQuery = "select LM.LocationId,LM.LocationName,DM.DepartmentId,DM.Department from  " +
                       " locationwisedepartment LWD inner join locationmaster LM on LM.LocationId=LWD.LocationId inner join " +
                       " DepartmentMaster DM on LWD.DepartmentId=DM.DepartmentId where LWD.CancelTag=0 and LM.CancelTag=0 and DM.CancelTag=0 ";


            //Report Query
           
            //Where Clauses All
            //DateColumn = " LA.FromDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' ";

           
            if (!cbSelectAllLocation.Checked)
                WhereClause += " and LM.LocationId=" + cmbLocation.SelectedValue + "";
            //else
            //    WhereClause += " and " + objQL.Get_Location_Id("Location") + " ";

            if (!cbSelectAllDepartment.Checked)
                WhereClause += " and DM.DepartmentId=" + cmbDepartment.SelectedValue + "";
            //else
            //    WhereClause += " and " + objQL.Get_Location_Id("Department");


            //WhereClause += " and ARM.AttendanceDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";
             

             
            
            //if (cmbLocation.SelectedIndex > -1)
            //    LocationIdS = " and E.LocationId=" + cmbLocation.SelectedValue + " ";

            //if (cmbLocation.SelectedIndex > -1)
            //    DepartmentIn = " and E.DepartmentId=" + cmbDepartment.SelectedValue + " ";

            OrderBy = " order by LM.LocationName asc ";
            //WhereClause = DateColumn + EmployeeIn + LocationIdS + DepartmentIn + ContractorIn + StatusIn + LeaveStatusIn + " ";

            objBL.Query = MainQuery + WhereClause + OrderBy;
            ds = objBL.ReturnDataTable();

            //if (ds.Rows.Count > 0)
            //{

            //}

            ////WhereClause = " and ARM.AttendanceDate='" + dtpDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";

            //WhereClause = " and ARM.AttendanceDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";

            //if (!cbSelectAllLocation.Checked)
            //    WhereClause += " and ARM.LocationId=" + cmbLocation.SelectedValue + "";
            //else
            //{
            //    objQL.WhereClause_V = "  and lwd.PlantHeadId=" + BusinessLayer.EmployeeLoginId_Static + " ";
            //    //WhereClause += " and " + objQL.Get_Location_Id_Type_Object("Location", "L.") + " ";
            //}

            //if (!cbSelectAllDepartment.Checked)
            //    WhereClause += " and ARM.DepartmentId=" + cmbDepartment.SelectedValue + "";
            //else
            //{
            //    objQL.WhereClause_V = "  and lwd.PlantHeadId=" + BusinessLayer.EmployeeLoginId_Static + " ";
            //    //WhereClause += " and " + objQL.Get_Location_Id_Type_Object("Department", "D.");
            //}

            //WhereClause += objRL.WhereClasuse_CompOff_Comman();
            ////MainQuery = "select lwd.LocationId,L.LocationName,lwd.DepartmentId,D.Department from locationwisedepartment lwd inner join locationmaster L on L.LocationId=lwd.LocationId inner join departmentmaster d on d.DepartmentId=lwd.DepartmentId where lwd.CancelTag=0 and d.CancelTag=0 and L.CancelTag=0 ";
            ////MainQuery = "select * from attendancerecordmaster where CancelTag=0 " + WhereClause + "";

            ////DepartmentMaster DM on DM.DepartmentId=ARM.DepartmentId inner join 
            ////LocationMaster LM on LM.LocationId=ARM.LocationId inner join 
            ////locationwisedepartmentusers LWDU on LM.LocationId=LWDU.LocationId and DM.DepartmentId=LWDU.DepartmentId 

            //MainQuery = "select distinct ARM.AttendanceRecordMasterId,ARM.LocationId,LM.LocationName,ARM.DepartmentId,DM.Department from " + //,ARM.PRESENTMANPOWER,ARM.ADMINISTRATOR,ARM.HROFFICER,ARM.MANAGER,ARM.OFFICER,ARM.SENIOROFFICER,ARM.SUPERVISOR,ARM.TRAINEE,ARM.WORKER,ARM.CONTRACTWORKER,ARM.TOTAL,ARM.ABSENT,ARM.PERCENTAGE 
            //            " attendancerecordmaster ARM inner join " +
            //            " DepartmentMaster DM on DM.DepartmentId=ARM.DepartmentId inner join " +
            //            " LocationMaster LM on LM.LocationId=ARM.LocationId inner join " +
            //            " locationwisedepartmentusers LWDU on LM.LocationId=LWDU.LocationId and DM.DepartmentId=LWDU.DepartmentId ";

            ////" locationmaster L on L.LocationId=ARM.LocationId inner join " +
            ////" departmentmaster D on D.DepartmentId=ARM.DepartmentId ";

            ////             " designationmaster DM on DM.DesignationId=E.DesignationId inner join " +
            ////             " departmentmaster D on D.DepartmentId=E.DepartmentId " +
            ////             " where " +
            ////             " AR.CancelTag=0 and" +
            ////             " ARM.CancelTag=0 and" +
            ////             " E.CancelTag=0 and " +
            ////             " S.CancelTag=0 ";

            ////MainQuery = "select " +
            ////             "E.LocationId,"+
            ////             "L.LocationName," +
            ////             "E.DepartmentId," +
            ////             "D.Department" +
            ////             " from AttendanceRecord AR inner join " +
            ////             " attendancerecordmaster ARM on ARM.AttendanceRecordMasterId=AR.AttendanceRecordMasterId inner join " +
            ////             " Employees E on E.EmployeeId=AR.EmployeeId inner join " +
            ////             " shifts S on S.ShiftId=AR.ShiftId inner join " +
            ////             " locationmaster L on L.LocationId=E.LocationId inner join " +
            ////             " designationmaster DM on DM.DesignationId=E.DesignationId inner join " +
            ////             " departmentmaster D on D.DepartmentId=E.DepartmentId " +
            ////             " where " +
            ////             " AR.CancelTag=0 and" +
            ////             " ARM.CancelTag=0 and" +
            ////             " E.CancelTag=0 and " +
            ////             " S.CancelTag=0 ";

            //objBL.Query = MainQuery + WhereClause + "  order by LM.LocationName asc";
            //ds = objBL.ReturnDataTable();

            ////string LocId= objQL.Get_Location_Id("Location");
            ////string DepId = objQL.Get_Location_Id("Department");


            if (ds.Rows.Count > 0)
            {
                using (new CursorWait())
                {
                    //dataGridView1.Columns["clmADMINISTRATOR"].Visible = false;
                    //dataGridView1.Columns["clmHROFFICER"].Visible = false;

                    //lblTotalCount.Text = "Total Count: " + ds.Rows.Count.ToString();
                    SrNo = 1;
                    for (int i = 0; i < ds.Rows.Count; i++)
                    {
                        //PLANT HEAD		MANAGER
                        //HOD				MANAGER
                        //MANAGER         SENIOR OFFICER
                        //INCHARGE		OFFICER
                        //SUPERVISOR		SUPERVISOR
                        //TECHNICIAN		WORKER
                        //OPERATOR		WORKER	
                        //WORKER			WORKER
                        //TRAINEE			TRAINEE
                        //EXECUTIVE		HR OFFICER

                        WhereClauseAdd = string.Empty;
                        WhereClause1 = string.Empty;
                        PAFlag = string.Empty;

                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells["clmSrNo"].Value = SrNo.ToString();
                        objPC.LocationId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LocationId"])));
                        dataGridView1.Rows[i].Cells["clmLocationId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LocationId"])); //ds.Rows[i]["AttendanceRecordId"].ToString();
                        objPC.DepartmentId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["DepartmentId"])));
                        dataGridView1.Rows[i].Cells["clmDepartmentId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["DepartmentId"]));
                        dataGridView1.Rows[i].Cells["clmLocation"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LocationName"]));
                        dataGridView1.Rows[i].Cells["clmDepartment"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Department"]));

                        PAFlag = "'P','WOP','HP','CO','HD','ODP'";
                        //, ADMINISTRATOR,HROFFICER,MANAGER,OFFICER,SENIOROFFICER,SUPERVISOR,TRAINEE,WORKER,CONTRACTWORKER,TOTAL,ABSENT,PERCENTAGE
                        objPC.DesignationCategory = "All"; //WhereClause = "'P','WOP','HP'";
                        dataGridView1.Rows[i].Cells["clmPRESENT"].Value = Get_Count(); //objRL.CheckNullString(Convert.ToString(ds.Rows[i]["PRESENTMANPOWER"]));

                        objPC.DesignationCategory = "MANAGER"; WhereClause1 = ""; // WhereClause1 = " or DM.Designation IN('HR MANAGER') ";
                        dataGridView1.Rows[i].Cells["clmPLANTHEAD"].Value = Get_Count(); // objRL.CheckNullString(Convert.ToString(ds.Rows[i]["MANAGER"]));

                        objPC.DesignationCategory = "HOD"; WhereClause1 = "";
                        dataGridView1.Rows[i].Cells["clmHOD"].Value = Get_Count();

                        objPC.DesignationCategory = "SENIOR OFFICER"; WhereClause1 = "";
                        dataGridView1.Rows[i].Cells["clmMANAGER"].Value = Get_Count(); // objRL.CheckNullString(Convert.ToString(ds.Rows[i]["SENIOROFFICER"]));

                        objPC.DesignationCategory = "OFFICER"; WhereClause1 = ""; // WhereClause1 = " or DM.Designation IN('HR OFFICER')";
                        dataGridView1.Rows[i].Cells["clmINCHARGE"].Value = Get_Count(); // objRL.CheckNullString(Convert.ToString(ds.Rows[i]["OFFICER"]));

                        objPC.DesignationCategory = "SUPERVISOR"; WhereClause1 = "";
                        //dataGridView1.Rows[i].Cells["clmIncharges"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Department"]));
                        dataGridView1.Rows[i].Cells["clmSUPERVISOR"].Value = Get_Count(); //objRL.CheckNullString(Convert.ToString(ds.Rows[i]["SUPERVISOR"]));

                        //TECHNICIAN
                        objPC.DesignationCategory = "WORKER"; WhereClause1 = " and DM.Designation IN('TECHNICIAN-ELECTRICIAN','TECHNICIAN-FITTER')";
                        dataGridView1.Rows[i].Cells["clmTECHNICIAN"].Value = Get_Count();  // objRL.CheckNullString(Convert.ToString(ds.Rows[i]["WORKER"]));

                        //OPERATOR
                        objPC.DesignationCategory = "WORKER"; WhereClause1 = " and DM.Designation IN('BOILER-OPERATOR','ETP-OPERATOR','MACHINE OPERATOR')";
                        dataGridView1.Rows[i].Cells["clmOPERATOR"].Value = Get_Count();  // objRL.CheckNullString(Convert.ToString(ds.Rows[i]["CONTRACTWORKER"]));

                        //WORKER
                        objPC.DesignationCategory = "WORKER"; WhereClause1 = " and DM.Designation NOT IN('TECHNICIAN-ELECTRICIAN','TECHNICIAN-FITTER','BOILER-OPERATOR','ETP-OPERATOR','MACHINE OPERATOR')";
                        dataGridView1.Rows[i].Cells["clmWORKER"].Value = Get_Count();  // objRL.CheckNullString(Convert.ToString(ds.Rows[i]["TRAINEE"]));

                        //TRAINEE
                        objPC.DesignationCategory = "TRAINEE"; WhereClause1 = "";
                        dataGridView1.Rows[i].Cells["clmTRAINEE"].Value = Get_Count();  // objRL.CheckNullString(Convert.ToString(ds.Rows[i]["TRAINEE"]));

                        //EXECUTIVE
                        objPC.DesignationCategory = "OFFICER"; WhereClause1 = " and DM.Designation IN('EXPORT EXECUTIVE OFFICER','PURCHASE EXECUTIVE OFFICER')";
                        dataGridView1.Rows[i].Cells["clmEXECUTIVE"].Value = Get_Count();  // objRL.CheckNullString(Convert.ToString(ds.Rows[i]["TRAINEE"]));

                        //ABSENT
                        PAFlag = "'A','L','COU','WO','H'";
                        objPC.DesignationCategory = "All"; WhereClause1 = "";
                        dataGridView1.Rows[i].Cells["clmAbsent"].Value = Get_Count();

                        //ABSENT
                        PAFlag = "";
                        objPC.DesignationCategory = "All"; WhereClause1 = "";
                        dataGridView1.Rows[i].Cells["clmTotal"].Value = Get_Count();

                        //dataGridView1.Rows[i].Cells["clmTotal"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["TOTAL"]));
                        //dataGridView1.Rows[i].Cells["clmAbsent"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ABSENT"]));
                        //dataGridView1.Rows[i].Cells["clmPresentPer"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["PERCENTAGE"]));

                        //WhereClauseAdd = " and AR.Status='P'";
                        //dataGridView1.Rows[i].Cells["clmPresentManpower"].Value = Convert.ToString(Get_Count(""));
                        //WhereClauseAdd = " and AR.Status='P' and DM.DesignationCategory IN('" + BusinessResources.USER_TYPE_MANAGER + "')";
                        //dataGridView1.Rows[i].Cells["clmManagers"].Value = Convert.ToString(Get_Count(BusinessResources.USER_TYPE_MANAGER));

                        //dataGridView1.Rows[i].Cells["clmSeniorOfficers"].Value = Convert.ToString(Get_Count(BusinessResources.USER_TYPE_SENIOROFFICER));
                        //dataGridView1.Rows[i].Cells["clmOfficers"].Value = Convert.ToString(Get_Count(BusinessResources.USER_TYPE_OFFICER));
                        //dataGridView1.Rows[i].Cells["clmIncharges"].Value = Convert.ToString(Get_Count(BusinessResources.USER_TYPE_INCHARGE));
                        //dataGridView1.Rows[i].Cells["clmSupervisors"].Value = Convert.ToString(Get_Count(BusinessResources.USER_TYPE_SUPERVISOR));
                        //dataGridView1.Rows[i].Cells["clmOperators"].Value = Convert.ToString(Get_Count(BusinessResources.USER_TYPE_WORKER));
                        //dataGridView1.Rows[i].Cells["clmWorkers"].Value = Convert.ToString(Get_Count(BusinessResources.USER_TYPE_WORKER));
                        //dataGridView1.Rows[i].Cells["clmContractWorkers"].Value = Convert.ToString(Get_Count(BusinessResources.USER_TYPE_WORKER));
                        //dataGridView1.Rows[i].Cells["clmContractWorkers"].Value = Convert.ToString(Get_Count(BusinessResources.USER_TYPE_WORKER));



                        SrNo++;
                    }
                }
                dataGridView1.ClearSelection();
            }
        }

        string DType = string.Empty;
        string PAFlag = string.Empty;
        string WhereClause1=string.Empty;

        private int Get_Count()
        {
            int CountReturn = 0; 
            WhereClauseAdd = string.Empty;
           // WhereClause = string.Empty;

            if (PAFlag != "")
                WhereClause = " and AR.Status IN(" + PAFlag + ") ";
            else
                WhereClause = "";

            if (objPC.DesignationCategory == "All")
                WhereClauseAdd = "";
            else if (objPC.DesignationCategory == "OFFICER")
                WhereClauseAdd = " and DM.DesignationCategory IN('OFFICER','HR OFFICER','ADMINISTRATOR') ";
            else if (objPC.DesignationCategory == "MANAGER")
                WhereClauseAdd = " and DM.DesignationCategory IN('MANAGER','ADMINISTRATOR') ";
            else
                WhereClauseAdd = " and DM.DesignationCategory='" + objPC.DesignationCategory + "' ";

            objBL.Query = "select count(*) " +
                        " from AttendanceRecord AR inner join " +
                        " attendancerecordmaster ARM on ARM.AttendanceRecordMasterId=AR.AttendanceRecordMasterId inner join " +
                        " Employees E on E.EmployeeId=AR.EmployeeId inner join " +
                        " locationmaster L on L.LocationId=E.LocationId inner join " +
                        " designationmaster DM on DM.DesignationId=E.DesignationId inner join " +
                        " departmentmaster D on D.DepartmentId=E.DepartmentId where " +
                        " AR.CancelTag=0 and DM.CancelTag=0 and E.CancelTag=0 and D.CancelTag=0 and L.CancelTag=0 and " +
                        " E.EmployeeCode NOT IN" +
                        "(100001,100004,50002,50003,50004,50005,50006,50007,50008,50009,50010,50011,50013,50014,50015,50016,50017,50018,50019,50020,50012,50021,50022,50023,50024,50025,50026,50027,50028) " +
                        " and " +
                        " L.LocationId=" + objPC.LocationId + " and " +
                        " E.DepartmentId=" + objPC.DepartmentId + " and " +
                        //" ARM.AttendanceDate='" + dtpDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' " +
                        " ARM.AttendanceDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' " +
                         "  " + WhereClauseAdd + WhereClause + WhereClause1 + " ";

            DataTable dt;

            dt = objBL.ReturnDataTable();
            if (dt.Rows.Count > 0)
            {
                CountReturn = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[0][0])));
            }

            return CountReturn;
        }

        private void DashboardReport_Load(object sender, EventArgs e)
        {
            cbToday.Checked = true;
            cbSelectAllLocation.Checked = true;
            cbSelectAllDepartment.Checked = true;
        }
    }
}
