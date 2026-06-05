using BusinessLayerUtility;
using Microsoft.Office.Interop.Excel;
//using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SPApplication.Report
{
    public partial class ESSLPunchReport : Form
    {
        ErrorProvider objEP = new ErrorProvider();
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        PropertyClass objPC = new PropertyClass();
        QueryLayer objQL = new QueryLayer();
        AttendanceLogics objAL = new AttendanceLogics();
        public ESSLPunchReport()
        {
            InitializeComponent();
            objDL.SetDesign3Buttons(this, lblHeader, btnAddData, btnClear, btnExit, BusinessResources.LBL_HEADER_ESSLDATA);
            objRL.FillLocation(cmbLocation, cmbDepartment);
            btnSearch.Text = BusinessResources.BTN_SEARCH;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Fill_Report();
            Fill_Grid_By_Date();
        }
        private void Fill_Report()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            objBL.Query = "select AL.*,E.* from AttendanceLogs AL inner join Employees E on E.EmployeeId=AL.EmployeeId where E.RecordStatus=1 and E.Status='Working' and AL.AttendanceDate='" + dtpDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' order by E.EmployeeCode asc";
            //objBL.Query = "select AL.*,E.* from AttendanceLogs AL inner join Employees E on E.EmployeeId=AL.EmployeeId where E.EmployeeCode='" + objPC.EmployeeCode + "' and E.RecordStatus=1 and E.Status='Working' and AL.AttendanceDate=#" + objPC.AttendanceDate.ToString(BusinessResources.DATEFORMATMMDDYYYY) + "# order by AL.AttendanceDate desc";
            //else
            //    objBL.Query = "select AL.*,E.* from AttendanceLogs AL inner join Employees E on E.EmployeeId=AL.EmployeeId where E.EmployeeCode='" + objPC.EmployeeCode + "' and E.RecordStatus=1 and E.Status='Working' and AL.AttendanceDate='" + objPC.AttendanceDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' order by AL.AttendanceDate desc";

            dt = objBL.ReturnDataTable_ESSL(BusinessResources.Database_MSSQL);

            if (dt.Rows.Count > 0)
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    objPC.EsslAttendanceLogsId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[i]["AttendanceLogId"])));
                    objPC.ESSLEmployeeId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[i]["EmployeeId"])));
                    objPC.EmployeeCode = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[i]["EmployeeCode"])));
                    
                    DataSet ds=new DataSet();

                    ds = objQL.SP_Employees_By_EmployeeCode();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objPC.EmployeeId = 0;
                        objPC.OverTimeApplicable = 0;
                        objPC.LocationId = 0;
                        objPC.DepartmentId = 0;
                        objPC.ShiftGroupId = 0;
                        objPC.CategoryId = 0;
                        objPC.DesignationId = 0;

                        objPC.EmployeeId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["EmployeeId"])));
                        objPC.OverTimeApplicable = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["OverTimeApplicable"])));
                        objPC.LocationId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["LocationId"])));
                        objPC.LocationName = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Location Name"]));
                        objPC.DepartmentId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["DepartmentId"])));
                        objPC.Department = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Department"]));
                        objPC.ShiftGroupId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["ShiftGroupId"])));
                        objPC.CategoryId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["CategoryId"])));
                        objPC.DesignationId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["DesignationId"])));

                        objRL.Get_CategoriesDetails_By_Id();

                        objPC.AttendanceDate = Convert.ToDateTime(dt.Rows[i]["AttendanceDate"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[i]["InTime"].ToString())))
                            objPC.InTime = Convert.ToDateTime(dt.Rows[i]["InTime"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[i]["OutTime"].ToString())))
                            objPC.OutTime = Convert.ToDateTime(dt.Rows[i]["OutTime"]);

                        objPC.Duration_Float = 0;

                        TimeSpan duration = objPC.OutTime - objPC.InTime;

                        objPC.Duration_Float = (float)duration.TotalHours;

                        double ROption= Math.Round(objPC.Duration_Float, 2);

                        objPC.Duration_Float = Convert.ToSingle(ROption);

                        objPC.InDeviceId = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["InDeviceId"]));
                        objPC.OutDeviceId = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["OutDeviceId"]));

                        objPC.PunchRecords = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["PunchRecords"]));
                        //objPC.InTime = Convert.ToDateTime(dt.Rows[i]["InTime"]);
                        //objPC.OutTime = Convert.ToDateTime(dt.Rows[i]["InTime"]);

                        objPC.Status = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["Status"]));
                        objPC.StatusCode = objRL.CheckNullString(Convert.ToString(dt.Rows[i]["StatusCode"]));

                        objPC.MissedOutPunch = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[i]["MissedOutPunch"])));
                        objPC.MissedInPunch = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[i]["MissedInPunch"])));


                        Result = objQL.SP_AttendancelogPunchRecord_Insert(); // objBL.Function_ExecuteNonQuery_ESSL(BusinessResources.Database_MSSQL);

                    }


                    //objPC.EntryDate = DateTime.Now.Date;
                    //objPC.EsslAttendanceLogsId = Convert.ToInt32(dt.Rows[0]["attendancelogid"]);

                    //if (cmbDatabase.Text == BusinessResources.Database_ACCESS)
                    //    objPC.ESSLEmployeeId = Convert.ToInt32(dt.Rows[0]["E.EmployeeId"]);
                    //else
                    //    objPC.ESSLEmployeeId = Convert.ToInt32(dt.Rows[0]["EmployeeId"]);


                    //objPC.StatusCode = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["StatusCode"]));
                    //objPC.PunchRecords = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["PunchRecords"]));

                    objPC.MissedOutPunch = 0;
                    objPC.MissedInPunch = 0;

                    //AttendanceLogId bigint AI PK
                    //ESSLAttendanceLogId bigint
                    //AttendanceDate date
                    //ESSLEmployeeId int
                    //InTime varchar(200)
                    //InDeviceId varchar(100) 
                    //OutTime varchar(200) 
                    //OutDeviceId varchar(100) 
                    //Duration float
                    //PunchRecords longtext
                    //ShiftId int
                    //Present float
                    //Absent float
                    //Status mediumtext
                    //StatusCode mediumtext
                    //MissedOutPunch int
                    //Remarks longtext
                    //MissedInPunch int
                    //UserId int
                    //CancelTag int
                    //CreatedDate datetime
                    //ModifiedUserId int
                    //ModifiedDate datetime

                    //objBL.Query = string.Empty;
                    //objBL.Query = "insert into attendancelogpunchrecord (" +
                    //                "ESSLAttendanceLogId," +
                    //                "AttendanceDate," +
                    //                "ESSLEmployeeId," +
                    //                "InTime," +
                    //                "InDeviceId," +
                    //                "OutTime," +
                    //                "OutDeviceId," +
                    //                "Duration," +
                    //                "PunchRecords," +
                    //                "ShiftId," +
                    //                "Present," +
                    //                "Absent," +
                    //                "Status," +
                    //                "StatusCode," +
                    //                "MissedOutPunch," +
                    //                "Remarks," +
                    //                "MissedInPunch," +
                    //                "EmployeeId," +
                    //                "EmployeeCode," +
                    //                "LocationName," +
                    //                "DepartmentName," +
                    //                "UserId) values(" +
                    //                ""+objPC.EsslAttendanceLogsId + ","+
                    //                "'" + objPC.AttendanceDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'," +
                    //                "" + objPC.ESSLEmployeeId + "," +
                    //                "'" + objPC.InTime.ToString(BusinessResources.TimeFormat_HHMM) + "'," +
                    //                "'" + objPC.InDeviceId + "'," +
                    //                "'" + objPC.OutTime.ToString(BusinessResources.TimeFormat_HHMM) + "'," +
                    //                "'" + objPC.OutDeviceId + "'," +
                    //                "'" + objPC.Duration + "'," +
                    //                "'" + objPC.PunchRecords + "'," +
                    //                "" + objPC.ShiftId + "," +
                    //                "" + objPC.Present + "," +
                    //                "" + objPC.Absent + "," +
                    //                "'" + objPC.Status + "'," +
                    //                "'" + objPC.StatusCode + "'," +
                    //                "" + objPC.MissedOutPunch + "," +
                    //                "'" + objPC.Remarks + "'," +
                    //                "" + objPC.MissedInPunch + "," +
                    //                "" + objPC.EmployeeId + "," +
                    //                "" + objPC.EmployeeCode + "," +
                    //                "'" + objPC.LocationName + "'," +
                    //                "'" + objPC.DepartmentName + "'," +
                    //                "" + BusinessLayer.LoginId_Static + ")";
                    //Result= objBL.Function_ExecuteNonQuery();



                    if (Result > 0)
                    {

                    }
                }

                Fill_Grid_By_Date();
            }
        }

        int Result = 0;

        bool FlagExist = false;

        string WhereClause = string.Empty;
        string MainQuery = string.Empty;
        private void Fill_Grid_By_Date()
        {
            WhereClause = string.Empty;

            DataSet ds = new DataSet();
           // objPC.AttendanceDate = dtpDate.Value;

            MainQuery = string.Empty;
            MainQuery = "select OBJ.AttendanceLogId,OBJ.ESSLAttendanceLogId,OBJ.AttendanceDate,OBJ.ESSLEmployeeId,OBJ.EmployeeId,OBJ.EmployeeCode,E.EmployeeName,OBJ.LocationName,OBJ.DepartmentName,OBJ.InTime,OBJ.InDeviceId,OBJ.OutTime,OBJ.OutDeviceId,OBJ.Duration,OBJ.PunchRecords,OBJ.ShiftId,OBJ.Present,OBJ.Absent,OBJ.Status,OBJ.StatusCode,OBJ.MissedOutPunch,OBJ.Remarks,OBJ.MissedInPunch from attendancelogpunchrecord OBJ inner join Employees E on E.EmployeeId=OBJ.EmployeeId where OBJ.CancelTag=0 and E.CancelTag=0 ";
            
            if (!cbSelectAllLocation.Checked)
                WhereClause += " and OBJ.LocationName='" + cmbLocation.Text + "'";

            if (!cbSelectAllDepartment.Checked)
                WhereClause += " and OBJ.DepartmentName='" + cmbDepartment.Text + "'";

            WhereClause += " and OBJ.AttendanceDate='"+ dtpDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";

            //ds =objQL.SP_AttendancelogPunchRecord_FillGrid();

            objBL.Query = MainQuery + WhereClause;
            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0 )
            {
                //0 OBJ.AttendanceLogId,
                //1 OBJ.ESSLAttendanceLogId, 
                //2 OBJ.AttendanceDate,
                //3 OBJ.ESSLEmployeeId,
                //4 OBJ.EmployeeId,
                //5 OBJ.EmployeeCode,
                //6 E.EmployeeName,
                //7 OBJ.LocationName,
                //8 OBJ.DepartmentName,
                //9 OBJ.InTime,
                //10 OBJ.InDeviceId,
                //11 OBJ.OutTime,
                //12 OBJ.OutDeviceId,
                //13 OBJ.Duration,
                //14 OBJ.PunchRecords,
                //15 OBJ.ShiftId,
                //16 OBJ.Present,
                //17 OBJ.Absent,
                //18 OBJ.Status,
                //19 OBJ.StatusCode,
                //20 OBJ.MissedOutPunch,
                //21 OBJ.Remarks,
                //22 OBJ.MissedInPunch

                FlagExist = true;
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[15].Visible = false;
                dataGridView1.Columns[16].Visible = false;
                dataGridView1.Columns[17].Visible = false;
                dataGridView1.Columns[21].Visible = false;
            }
            else
                FlagExist = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cbSelectAllLocation.Checked = true;
            cbSelectAllDepartment.Checked = true;
            dtpDate.Value = DateTime.Now.Date;
            dataGridView1.DataSource = null;
            cbSelectAllLocation.Checked = true;
            cbSelectAllDepartment.Checked = true;
        }

        private void ESSLPunchReport_Load(object sender, EventArgs e)
        {
            cbSelectAllLocation.Checked = true;
            cbSelectAllDepartment.Checked = true;

        }

        private void btnAddData_Click(object sender, EventArgs e)
        {
            Fill_Grid_By_Date();

            if(!FlagExist)
                Fill_Report();
        }

        private void cmbLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbLocation.SelectedIndex > -1)
                objRL.FillDepartment(cmbLocation, cmbDepartment);
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
    }
}
