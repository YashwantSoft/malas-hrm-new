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
    public partial class AttendanceWorking : Form
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
        string EmpDesignation = string.Empty;
        string EmpDepartment = string.Empty;

        string MainQuery = string.Empty;
        string WhereClause = string.Empty;
        bool ApproveFlag = false;

        DateTime dtInTime, dtOutTime;

        double LateBy = 0, EarlyBy = 0, TotalDurationDuration = 0;

        string Duration = "", OverTimeInMin = "", OverTimeInHours = "", TotalDuration = "";

        public AttendanceWorking()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_ATTENDANCEAPPROVAL);
            objRL.Fill_Status_ComboBox(cmbStatus);
            rtbStatusCount.ForeColor = objDL.GetForeColor();
            rtbStatusCount.BackColor = objDL.GetBackgroundColor();

            rtbContractorWiseCount.ForeColor = objDL.GetForeColor();
            rtbContractorWiseCount.BackColor = objDL.GetBackgroundColor();

            objDL.SetButtonDesign(btnSearch, BusinessResources.BTN_SEARCH);
            objDL.SetButtonDesign(btnClearSearch, BusinessResources.BTN_CLEAR);

            //btnSave.Text = BusinessResources.BTN_VIEW;
            //btnDelete.Text = BusinessResources.BTN_APPROVE;
            //objQL.Fill_Master_ComboBox(cmbAttendanceStatus, "attendancestatusmaster");
            //Fill_Status();

            objRL.Fill_Approval_Status(cmbAttendanceStatus);

            ClearAll();

            objRL.Fill_Contractor_IN_Attendance(cmbContractor);
            //DataGridViewComboBoxColumn comboBoxColumn = (DataGridViewComboBoxColumn)dataGridView1.Columns["clmShiftCombo"];
            //comboBoxColumn.DataSource = Student.GetStudents();
            //comboBoxColumn.DisplayMember = "Name";
            //comboBoxColumn.ValueMember = "StudentId";
        }

        private void Fill_Label_Color()
        {
            lblPending.BackColor = Color.FromName(BusinessResources.LS_Pending_Color);
            lblHRApproved.BackColor = Color.FromName(BusinessResources.LS_HRApproved_Color);
            lblInchargeApproved.BackColor = Color.FromName(BusinessResources.LS_InchargeApproved_Color);
            lblManagerApproved.BackColor = Color.FromName(BusinessResources.LS_Manager_Color);
            lblReject.BackColor = Color.FromName(BusinessResources.LS_Reject_Color);
            lblRemark.BackColor = Color.FromName(BusinessResources.LS_Remarks_Color);
            lblCompleted.BackColor = Color.FromName(BusinessResources.LS_Completed_Color);
            lblError.BackColor = Color.FromName(BusinessResources.LS_Error_Color);
            //lblError.BackColor = Color.FromName(BusinessResources.LS_Completed_Color);
        }

        private void GridViewReadOnly_EnableTrueFalse(bool flag)
        {
            if (flag)
            {
                dataGridView1.ReadOnly = false;
                dataGridView1.Columns["clmSrNo"].ReadOnly = true;
                dataGridView1.Columns["clmEmployeeCode"].ReadOnly = true;
                dataGridView1.Columns["clmShift"].ReadOnly = true;
                dataGridView1.Columns["clmDuration"].ReadOnly = true;
                dataGridView1.Columns["clmStatus"].ReadOnly = true;
                dataGridView1.Columns["clmInTime"].ReadOnly = true;
                dataGridView1.Columns["clmOutTime"].ReadOnly = true;
                dataGridView1.Columns["clmDuration"].ReadOnly = true;
                dataGridView1.Columns["clmOverTime"].ReadOnly = true;
                dataGridView1.Columns["clmTotalDuration"].ReadOnly = true;
                dataGridView1.Columns["clmLateBy"].ReadOnly = true;
                dataGridView1.Columns["clmEarlyBy"].ReadOnly = true;
                dataGridView1.Columns["clmMissedInPunch"].ReadOnly = true;
                dataGridView1.Columns["clmMissedOutPunch"].ReadOnly = true;
                dataGridView1.Columns["clmRemarksGrid"].ReadOnly = false;
                dataGridView1.Columns["clmDepartmentChange"].ReadOnly = false;
            }
            else
            {
                dataGridView1.ReadOnly = flag;
            }

        }

        private void Fill_Status()
        {
            //LS_Completed_Color	Lime	
            //LS_Error_Color	    Red	
            //LS_HRApproved_Color	Aqua	
            //LS_InchargeApproved_  Color	HotPink	
            //LS_Manager_Color	    NavajoWhite	
            //LS_Pending_Color	    Yellow	
            //LS_Reject_Color	    DarkOrchid	
            //LS_Remarks_Color	    Khaki	

            //LS_Reject	            Reject	
            //LS_Cancel	            Reject	
            //LS_Completed      	Completed	
            //LS_HRApproved	HR      Approved	
            //LS_InchargeApproved	Incharge Approved	
            //LS_ManagerApproved	Manager Approved	
            //LS_Pending	        Pending	
            //LS_Remarks	        Remarks	

            objRL.Fill_Approval_Status(cmbAttendanceStatus);


            //cmbAttendanceStatus.Items.Clear();
            //cmbAttendanceStatus.Enabled = true;
            //if (BusinessLayer.UserType == BusinessResources.USER_TYPE_INCHARGE)
            //{
            //    cmbAttendanceStatus.Items.Add(BusinessResources.LS_InchargeApproved);
            //    cmbAttendanceStatus.Items.Add(BusinessResources.LS_Pending);
            //    cmbAttendanceStatus.Items.Add(BusinessResources.LS_Remarks);
            //    GridViewReadOnly_EnableTrueFalse(true);
            //}
            //else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER || BusinessLayer.UserType == BusinessResources.USER_TYPE_PLANTHEAD)
            //{
            //    cmbAttendanceStatus.Items.Add(BusinessResources.LS_ManagerApproved);
            //    cmbAttendanceStatus.Items.Add(BusinessResources.LS_Pending);
            //    cmbAttendanceStatus.Items.Add(BusinessResources.LS_Remarks);
            //    cmbAttendanceStatus.Items.Add(BusinessResources.LS_Reject);
            //    GridViewReadOnly_EnableTrueFalse(true);
            //}
            //else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMIN)
            //{
            //    cmbAttendanceStatus.Items.Add(BusinessResources.LS_HRApproved);
            //    cmbAttendanceStatus.Items.Add(BusinessResources.LS_ManagerApproved);
            //    cmbAttendanceStatus.Items.Add(BusinessResources.LS_InchargeApproved);
            //    cmbAttendanceStatus.Items.Add(BusinessResources.LS_Completed);
            //    cmbAttendanceStatus.Items.Add(BusinessResources.LS_Pending);
            //    cmbAttendanceStatus.Items.Add(BusinessResources.LS_Remarks);
            //    cmbAttendanceStatus.Items.Add(BusinessResources.LS_Reject);
            //    GridViewReadOnly_EnableTrueFalse(false);
            //}
            //else
            //    cmbAttendanceStatus.Items.Clear();
        }

        public class Student
        {
            public string Name { get; private set; }
            public int StudentId { get; private set; }
            public Student(string name, int studentId)
            {
                Name = name;
                StudentId = studentId;
            }

            private static readonly List<Student> students = new List<Student>
    {
        { new Student("Chuck", 1) },
        { new Student("Bob", 2) }
    };

            public static List<Student> GetStudents()
            {
                return students;
            }
        }

        private void CurrentStatus()
        {
            ////cmbStatus.Enabled = false;
            //cmbApproval.Items.Add(BusinessResources.STATUS_HR_APPROVED);
            //cmbApproval.Items.Add(BusinessResources.STATUS_FINAL_APPROVED);
            //cmbApproval.Items.Add(BusinessResources.STATUS_DEPARTMENT_HEAD_APPROVED);

            //if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMIN)
            //{
            //    cmbApproval.Text = BusinessResources.STATUS_HR_APPROVED;
            //    cmbApproval.Enabled = true;
            //}
            //else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_PLANTHEAD || BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER)
            //{
            //    cmbApproval.Text = BusinessResources.STATUS_FINAL_APPROVED;
            //}
            //else
            //    cmbApproval.Text = BusinessResources.STATUS_DEPARTMENT_HEAD_APPROVED;
        }

        private void ClearAll()
        {
            //lblData.Text = "";
            CurrentStatus();
        }

        private void Fill_Combo_DataGridView_Shift()
        {
            DataGridViewComboBoxColumn clmShiftCombo = new DataGridViewComboBoxColumn();

            // objQL.Fill_Master_ComboBox(clmShiftCombo, "shifts");

            //clmShiftCombo.ValueMember = 
            //ComboBox cmb1 = (DataGridView).ComboBox();
        }

        private void AttendanceApproval_Load(object sender, EventArgs e)
        {
            objPC.EditFlag = 0;
            objPC.EditFlagTemp = 0;
            TotalDurationDuration = 0;
            TotalHoursCount = 0;
            cbContractor.Checked = true;
            cbStatus.Checked = true;

            //Original Code Slow
            if(BusinessLayer.UserType == "ADMINISTRATOR" || BusinessLayer.UserType == "HR OFFICER")
                Save_AttendanceRecord();

            

            Fill_Grid_AttendanceRecord();

            objRL.SetApprovalStatusColor(lblData);
            //if (BusinessLayer.UserType == BusinessResources.USER_TYPE_PLANTHEAD || BusinessLayer.UserType == BusinessResources.USER_TYPE_INCHARGE ==
            //if (BusinessLayer.UserType != BusinessResources.USER_TYPE_OFFICER || BusinessLayer.UserType != BusinessResources.USER_TYPE_ADMIN || BusinessLayer.UserType != BusinessResources.USER_TYPE_MANAGER)
            //    btnSave.Enabled = false;
            //else
            //    btnSave.Enabled = true;
        }


        string checkStatus = string.Empty, LeaveName = string.Empty;
        string ConcatTotal = string.Empty;

        int TotalMP = 0, TotalA = 0, TotalWO = 0, TotalWOP = 0, TotalH = 0, TotalP = 0, TotalHD = 0, TotalHP = 0, TotalL = 0, TotalGL = 0, TotalCO = 0, TotalCOU = 0;
        double TotalHoursCount = 0;
        //double TotalMP = 0, TotalA = 0, TotalWO = 0, TotalWOP = 0, TotalH = 0, TotalP = 0, TotalHD = 0, TotalHP = 0, TotalL = 0, TotalCO = 0, TotalCOU = 0;
        //1	A	Absent	
        //2	WO	Weekly off	
        //3	WOP	Weekly off Present	
        //4	H	Holiday	
        //5	P	Present	
        //6	HD	Half Day
        //7	HP	Holiday Present	
        //8	L	Leave
        //9	CO	Comp off
        //10 COU Comp off Used

        private void Get_Count_All()
        {
            //Casual Leave
            //Paid Leave
            //Sick Leave
            //Marraige Leave
            //Compensation Off
            //Medical Leave
            //Compensation Off Used
            //Revert Leave
            //Maternity Leave

            //1	A	Absent	
            //2	WO	Weekly off	
            //3	WOP	Weekly off Present	
            //4	H	Holiday	
            //5	P	Present	
            //6	HD	Half Day
            //7	HP	Holiday Present	
            //8	L	Leave
            //9	CO	Comp off
            //10 COU Comp off Used

            rtbStatusCount.Text = "";
            checkStatus = string.Empty; LeaveName = string.Empty; ConcatTotal = string.Empty;

            TotalMP = 0; TotalA = 0; TotalWO = 0; TotalWOP = 0; TotalH = 0; TotalP = 0; TotalHD = 0; TotalHP = 0; TotalL = 0; TotalGL = 0; TotalCO = 0; TotalCOU = 0;

            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    TotalMP += objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[i].Cells["clmMissedOutPunch"].Value)));

                    if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[i].Cells["clmStatus"].Value)))
                    {
                        checkStatus = Convert.ToString(dataGridView1.Rows[i].Cells["clmStatus"].Value.ToString());

                        //1	A	Absent	
                        //2	WO	Weekly off	
                        //3	WOP	Weekly off Present	
                        //4	H	Holiday	
                        //5	P	Present	
                        //6	HD	Half Day
                        //7	HP	Holiday Present	
                        //8	L	Leave
                        //9	CO	Comp off
                        //10 COU

                        if (checkStatus == "A")
                            //TotalA += 1;
                            TotalA++;
                        else if (checkStatus == "WO")
                            //TotalWO += 1;
                            TotalWO++;
                        else if (checkStatus == "WOP")
                            //TotalWOP+=1;
                            TotalWOP++;
                        else if (checkStatus == "H")
                            //TotalH += 1;
                            TotalH++;
                        else if (checkStatus == "P")
                            //TotalP += 1;TotalGL
                            TotalP++;
                        else if (checkStatus == "HD")
                            //TotalHD += 0.5;
                            TotalHD++;
                        else if (checkStatus == "HP")
                            //TotalHP += 1;
                            TotalHP++;
                        else if (checkStatus == "L")
                            //TotalL+=1;
                            TotalL++;
                        else if (checkStatus == "SL")
                            //TotalL+=1;
                            TotalGL++;
                        else if (checkStatus == "CO")
                            TotalCO += 1;
                        //TotalCO++;
                        else if (checkStatus == "COU")
                            //TotalCOU+=1;
                            TotalCOU++;
                        else
                        {

                        }
                    }

                    //if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[i].Cells["clmLeave"].Value)))
                    //{
                    //   LeaveName= Convert.ToString(dataGridView1.Rows[i].Cells["clmLeave"].Value);
                    //   if (LeaveName != "NA")
                    //       TotalLeave++;
                    //}
                }
                ConcatTotal = "Total Count-" + dataGridView1.Rows.Count.ToString() + System.Environment.NewLine +
                              "Present-" + TotalP.ToString() + System.Environment.NewLine +
                              "Absent-" + TotalA.ToString() + System.Environment.NewLine +
                              "Half Days-" + TotalHD.ToString() + System.Environment.NewLine +
                              "Weekly off-" + TotalWO.ToString() + System.Environment.NewLine +
                              "Weekly off Present-" + TotalWOP.ToString() + System.Environment.NewLine +
                              "Holiday Present-" + TotalHP.ToString() + System.Environment.NewLine +
                              "Comp off-" + TotalCO.ToString() + System.Environment.NewLine +
                              "Comp off Used-" + TotalCOU.ToString() + System.Environment.NewLine +
                              "Leaves-" + TotalL.ToString() + System.Environment.NewLine +
                              "Special Leaves-" + TotalGL.ToString() + System.Environment.NewLine +
                              "Total OT Hours-" + OTHoursTotal.ToString() + System.Environment.NewLine +
                              "Total Hours-" + TotalHoursCount.ToString() + System.Environment.NewLine +
                              "Holiday-" + TotalH.ToString() + System.Environment.NewLine +
                              "Missed Punch-" + TotalMP.ToString();
                //lblStatusCount.Text = ConcatTotal.ToString();
                rtbStatusCount.Text = ConcatTotal.ToString();
            }
        }

        private void Save_AttendanceRecord()
        {
            if (objPC.AttendanceRecordMasterId != 0)
            {
                lblData.Text = objPC.AttendanceData.ToString();
                cmbAttendanceStatus.Text = objPC.ApprovalStatus;
                DataTable ds = new DataTable();
                ds = objQL.SP_AttendanceRecord_FillGrid_By_AttendanceRecordMasterId();

                if (ds.Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Rows.Count; i++)
                    {
                        //5122
                        //insert into Attendance Record

                        objPC.LeaveTypeFlag = false;

                        objPC.ClearAttendanceRecords();
                        objPC.AttendanceDate = Convert.ToDateTime(ds.Rows[i]["AttendanceDate"]);
                        objPC.AttendanceRecordId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["AttendanceRecordId"])));
                        objPC.AttendanceRecordMasterId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["AttendanceRecordMasterId"])));
                        objPC.EmployeeId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EmployeeId"])));
                        objPC.EmployeeName = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EmployeeName"]));
                        objPC.EmployeeCode = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EmployeeCode"])));
                        objPC.ShiftId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftId"])))); //ds.Rows[i]["ShiftId"].ToString();
                        objPC.ShiftFName = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftSName"])); //ds.Rows[i]["ShiftSName"].ToString();
                        objPC.ShiftGroupId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftGroupId"])));
                        objPC.CategoryId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["CategoryId"])));
                        objRL.Get_CategoriesDetails_By_Id();
                        objPC.OverTimeApplicable = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["OverTimeApplicable"])));
                        objPC.FlexibleHoursFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["FlexibleHoursFlag"])));
                        objPC.ContractorId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ContractorId"])));
                        objPC.OverTimeManualFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["OverTimeManualFlag"])));
                        objPC.EditFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EditFlag"])));

                        //if (objPC.EmployeeId == 194)
                        //{

                        //}

                        //if (objPC.EmployeeCode == 5189)
                        //{

                        //}

                        string OTValue = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["OverTime"]));

                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[i]["InTime"])))
                            objPC.InTime = Convert.ToDateTime(ds.Rows[i]["InTime"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[i]["OutTime"])))
                            objPC.OutTime = Convert.ToDateTime(ds.Rows[i]["OutTime"]);


                        //if (objPC.EmployeeCode == 2726)
                        //{

                        //}
                        //if(objPC.EditFlag ==0)
                        objAL.AttendanceWorking();


                        if (objPC.OverTimeManualFlag == 1)
                            objPC.OverTime = OTValue;

                        //objPC.LateBy = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LateBy"])));
                        //objPC.EarlyBy = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EarlyBy"])));
                        // objPC.MissedInPunch = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["MissedInPunch"])));
                        // objPC.MissedOutPunch = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["MissedOutPunch"])));

                        objPC.ChangeDepartmentFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentFlag"])));
                        objPC.ChangeDepartmentId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentId"])));
                        objPC.ChangeLocationtId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeLocationtId"])));
                        objPC.LeaveTypeId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LeaveTypeId"])));
                        objPC.LeaveDuration = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LeaveDuration"])));
                        objPC.WeeklyOff = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["WeeklyOff"])));
                        objPC.Holiday = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Holiday"])));
                        objPC.LeaveRemarks = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LeaveRemarks"]));
                        objPC.PunchRecords = "";
                        objPC.PunchRecords = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["PunchRecords"]));
                        objPC.LossOfHours = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LossOfHours"])));
                        objPC.Present = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Present"])));
                        objPC.Absent = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Absent"])));
                        objPC.Remarks = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Remarks"]));
                        objPC.RemarksReply = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Notes"]));
                        objPC.EditFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EditFlag"])));
                        objPC.OutDoorEntryFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["OutDoorEntryFlag"])));

                        //objPC.UserId = Convert.ToInt32(BusinessLayer.EmployeeLoginId_Static);

                        Result = objQL.SP_AttendanceRecord_Insert_Update();

                        if (Result > 0)
                        {
                            objAL.Save_AttendanceMonthlyData();
                            objPC.AttendanceRecordId = 0;
                            //objPC.ClearAttendanceRecords();
                            objPC.PunchRecords = "";
                        }

                        //Result

                        //dataGridView1.Rows[i].Cells["clmShiftDuration"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftDurationHours"])); // objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftDuration"])); //ds.Rows[i]["ShiftId"].ToString();
                        //dataGridView1.Rows[i].Cells["clmDuration"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Duration"])); //Convert.ToString(ds.Rows[i]["Duration"].ToString());

                        ////dataGridView1.Rows[i].Cells["clmOverTime"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["OverTime"]));

                        //TimeSpan OTH = TimeSpan.Parse(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["OverTime"])));
                        //dataGridView1.Rows[i].Cells["clmOverTime"].Value = objAL.Get_String_TimeSpan(OTH);

                        //dataGridView1.Rows[i].Cells["clmTotalDuration"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["TotalDuration"]));
                        //dataGridView1.Rows[i].Cells["clmStatus"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Status"]));

                        //dataGridView1.Rows[i].Cells["clmLateBy"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LateBy"]));
                        //dataGridView1.Rows[i].Cells["clmEarlyBy"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EarlyBy"]));
                        //dataGridView1.Rows[i].Cells["clmMissedInPunch"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["MissedInPunch"]));
                        //dataGridView1.Rows[i].Cells["clmMissedOutPunch"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["MissedInPunch"]));

                        //dataGridView1.Rows[i].Cells["clmChangeDepartmentFlag"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentFlag"]));
                        //dataGridView1.Rows[i].Cells["clmChangeDepartmentId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentId"]));
                        //dataGridView1.Rows[i].Cells["clmChangeLocationId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeLocationtId"]));

                        //objPC.LeaveType = string.Empty;
                        //objAL.LeaveDetailsEmployees();

                        //if (objPC.LeaveTypeId > 0)
                        //{
                        //    objPC.LeaveTypeId = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LeaveTypeId"])));
                        //    objRL.GetLeaveDetailsEmployees_ByLeaveId();
                        //    dataGridView1.Rows[i].Cells["clmLeave"].Value = objPC.LeaveType.ToString();
                        //    dataGridView1.Rows[i].Cells["clmLeaveTypeId"].Value = objPC.LeaveTypeId.ToString();
                        //    dataGridView1.Rows[i].Cells["clmStatus"].Value = "L";
                        //    dataGridView1.Rows[i].Cells["clmInTime"].Value = "00:00";
                        //    dataGridView1.Rows[i].Cells["clmOutTime"].Value = "00:00";

                        //    dataGridView1.Rows[i].Cells["clmInTime"].Value = "00:00";
                        //    dataGridView1.Rows[i].Cells["clmOutTime"].Value = "0:0";

                        //    dataGridView1.Rows[i].Cells["clmShiftDuration"].Value = "00:00";
                        //    dataGridView1.Rows[i].Cells["clmDuration"].Value = "00:00";
                        //    dataGridView1.Rows[i].Cells["clmOverTime"].Value = "00:00";
                        //    dataGridView1.Rows[i].Cells["clmTotalDuration"].Value = "00:00";

                        //    dataGridView1.Rows[i].Cells["clmMissedInPunch"].Value = "0";
                        //    dataGridView1.Rows[i].Cells["clmMissedOutPunch"].Value = "0";

                        //    dataGridView1.Rows[i].Cells["clmChangeDepartmentFlag"].Value = "";
                        //    dataGridView1.Rows[i].Cells["clmChangeDepartmentId"].Value = "";
                        //    dataGridView1.Rows[i].Cells["clmChangeLocationId"].Value = "";

                        //    dataGridView1.Rows[i].Cells["clmPunchRecords"].Value = "";
                        //    dataGridView1.Rows[i].Cells["clmLossOfHours"].Value = "";
                        //    dataGridView1.Rows[i].Cells["clmRemarksGrid"].Value = "";
                        //    dataGridView1.Rows[i].Cells["clmChangeLocation"].Value = "";
                        //    dataGridView1.Rows[i].Cells["clmDepartmentChange"].Value = "";
                        //    dataGridView1.Rows[i].Cells["clmEarlyBy"].Value = "0";
                        //    dataGridView1.Rows[i].Cells["clmLateBy"].Value = "0";
                        //    dataGridView1.Rows[i].Cells["clmMissedInPunch"].Value = "";
                        //}
                        //else
                        //{
                        //    dataGridView1.Rows[i].Cells["clmLeave"].Value = "";
                        //    dataGridView1.Rows[i].Cells["clmLeaveTypeId"].Value = "";
                        //}

                        ////dataGridView1.Rows[i].Cells["clmLeaveTypeId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LeaveTypeId"]));
                        ////dataGridView1.Rows[i].Cells["clmLeaveDuration"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LeaveDuration"]));
                        ////dataGridView1.Rows[i].Cells["clmWeeklyOff"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["WeeklyOff"]));

                        ////dataGridView1.Rows[i].Cells["clmHoliday"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Holiday"]));
                        ////dataGridView1.Rows[i].Cells["clmLeaveRemarks"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LeaveRemarks"]));
                        //dataGridView1.Rows[i].Cells["clmPunchRecords"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["PunchRecords"]));
                        //dataGridView1.Rows[i].Cells["clmLossOfHours"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LossOfHours"]));
                        //dataGridView1.Rows[i].Cells["clmRemarksGrid"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Remarks"]));

                        ////Leave Working
                        //objPC.EmployeeId = Convert.ToInt32(ds.Rows[i]["EmployeeId"].ToString());
                        ////objPC.CheckDate = objPC.AttendanceDate;

                        //dataGridView1.Rows[i].Cells["clmChangeDepartmentFlag"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentFlag"]));
                        //objPC.ChangeDepartmentFlag = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentFlag"])));

                        //if (objPC.ChangeDepartmentFlag == 1)
                        //{
                        //    objPC.ChangeLocationtId = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeLocationtId"])));
                        //    objPC.ChangeDepartmentId = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentId"])));


                        //    dataGridView1.Rows[i].Cells["clmChangeLocation"].Value = objRL.Fill_Location_By_LocationId(objPC.ChangeLocationtId);
                        //    dataGridView1.Rows[i].Cells["clmDepartmentChange"].Value = objRL.Fill_Department_By_DepartmentId(objPC.ChangeDepartmentId);
                        //}

                        //dtpAttendanceDate.Value = objPC.AttendanceDate;

                        //objPC.LateBy = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LateBy"])));
                        //dataGridView1.Rows[i].Cells["clmLateBy"].Value = objPC.LateBy.ToString();
                        //if (objPC.LateBy > 0)
                        //{
                        //    objRL.Set_Error_Color(dataGridView1, i, "clmInTime", Color.FromName(BusinessResources.LS_Error_Color));
                        //    objRL.Set_Error_Color(dataGridView1, i, "clmLateBy", Color.FromName(BusinessResources.LS_Error_Color));
                        //}
                        //else
                        //{
                        //    dataGridView1.Rows[i].Cells["clmLateBy"].Value = "0";
                        //    objRL.Set_Error_Color(dataGridView1, i, "clmInTime", Color.White);
                        //    objRL.Set_Error_Color(dataGridView1, i, "clmLateBy", Color.White);
                        //}

                        //objPC.EarlyBy = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EarlyBy"])));
                        //dataGridView1.Rows[i].Cells["clmEarlyBy"].Value = objPC.EarlyBy.ToString();
                        //if (objPC.EarlyBy > 0)
                        //{
                        //    objRL.Set_Error_Color(dataGridView1, i, "clmOutTime", Color.FromName(BusinessResources.LS_Error_Color));
                        //    objRL.Set_Error_Color(dataGridView1, i, "clmEarlyBy", Color.FromName(BusinessResources.LS_Error_Color));
                        //}
                        //else
                        //{
                        //    dataGridView1.Rows[i].Cells["clmEarlyBy"].Value = "0";
                        //    objRL.Set_Error_Color(dataGridView1, i, "clmOutTime", Color.White);
                        //    objRL.Set_Error_Color(dataGridView1, i, "clmEarlyBy", Color.White);
                        //}

                        //objPC.MissedInPunch = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["MissedInPunch"])));
                        //dataGridView1.Rows[i].Cells["clmMissedInPunch"].Value = objPC.MissedInPunch.ToString();
                        //if (objPC.MissedInPunch > 0)
                        //    objRL.Set_Error_Color(dataGridView1, i, "clmMissedInPunch", Color.FromName(BusinessResources.LS_Error_Color));
                        //else
                        //    objRL.Set_Error_Color(dataGridView1, i, "clmMissedInPunch", Color.White);

                        //objPC.MissedOutPunch = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["MissedOutPunch"])));
                        //dataGridView1.Rows[i].Cells["clmMissedOutPunch"].Value = objPC.MissedOutPunch.ToString();
                        //if (objPC.MissedOutPunch > 0)
                        //    objRL.Set_Error_Color(dataGridView1, i, "clmMissedOutPunch", Color.FromName(BusinessResources.LS_Error_Color));
                        //else
                        //    objRL.Set_Error_Color(dataGridView1, i, "clmMissedOutPunch", Color.White);
                    }
                }
            }
        }

        //private void Fill_Grid_AttendanceRecord()
        //{
        //    dataGridView1.Rows.Clear();

        //    if (objPC.AttendanceRecordMasterId != 0)
        //    {
        //        lblData.Text = objPC.AttendanceData.ToString();
        //        cmbAttendanceStatus.Text = objPC.ApprovalStatus;

        //        if (cmbAttendanceStatus.SelectedIndex > -1)
        //            SetStatusColor();

        //        DataTable ds = new DataTable();
        //        ds = objQL.SP_AttendanceRecord_FillGrid_By_AttendanceRecordMasterId();

        //        if (ds.Rows.Count > 0)
        //        {
        //            lblTotalCount.Text = "Total Count: " + ds.Rows.Count.ToString();

        //            SrNo = 1;
        //            for (int i = 0; i < ds.Rows.Count; i++)
        //            {
        //                //0 AR.AttendanceRecordId,
        //                //1 AR.AttendanceRecordMasterId,
        //                //2 AR.AttendanceHistoryId,
        //                //3 AR.EsslAttendanceLogsId,
        //                //4 AR.EmployeeId, 
        //                //5 E.EmployeeName,
        //                //6 E.EmployeeCode,
        //                //7 AR.ShiftId, 
        //                //8 S.ShiftSName,
        //                //9 AR.ShiftGroupId,
        //                //10 AR.InTime,
        //                //11 AR.OutTime,
        //                //12 AR.Duration,
        //                //13AR.OverTime,
        //                //14 AR.TotalDuration,
        //                //15 AR.Status,
        //                //16 AR.LateBy,
        //                //17 AR.EarlyBy,
        //                //18 AR.MissedInPunch,
        //                //19 AR.MissedOutPunch,
        //                //20 AR.ChangeDepartmentFlag,
        //                //21 AR.ChangeDepartmentId,
        //                //22 AR.ChangeLocationtId,
        //                //23 AR.IsOnLeave,
        //                //24 AR.LeaveTypeId,
        //                //25 AR.LeaveDuration,
        //                //26 AR.WeeklyOff,
        //                //27 AR.Holiday,
        //                //28 AR.LeaveRemarks,
        //                //29 AR.PunchRecords,
        //                //30 AR.LossOfHours,
        //                //31 AR.Present,
        //                //32 AR.Absent,
        //                //33 AR.Remarks
        //                //34  S.ShiftDuration,
        //                //35 S.ShiftDurationHours,
        //                //36 S.BeginTime,
        //                //37 S.EndTime,
        //                //38 AR.EditFlag,
        //                //E.CategoryId,
        //                //E.ContractorId

        //                dataGridView1.Rows.Add();

        //                int EditFlag=0;

        //                dataGridView1.Rows[i].Cells["clmSrNo"].Value = SrNo.ToString();
        //                dataGridView1.Rows[i].Cells["clmAttendanceRecordId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["AttendanceRecordId"])); //ds.Rows[i]["AttendanceRecordId"].ToString();
        //                dataGridView1.Rows[i].Cells["clmAttendanceRecordMasterId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["AttendanceRecordMasterId"])); //ds.Rows[i]["AttendanceRecordMasterId"].ToString();
        //                dataGridView1.Rows[i].Cells["clmEsslAttendanceLogsId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EsslAttendanceLogsId"])); //ds.Rows[i]["EsslAttendanceLogsId"].ToString();
        //                dataGridView1.Rows[i].Cells["clmEmployeeId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EmployeeId"])); //ds.Rows[i]["EmployeeId"].ToString();
        //                dataGridView1.Rows[i].Cells["clmEmployeeName"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EmployeeName"])); //ds.Rows[i]["EmployeeName"].ToString();
        //                dataGridView1.Rows[i].Cells["clmEmployeeCode"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EmployeeCode"])); //ds.Rows[i]["EmployeeCode"].ToString();

        //                dataGridView1.Rows[i].Cells["clmShiftId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftId"])); //ds.Rows[i]["ShiftId"].ToString();
        //                dataGridView1.Rows[i].Cells["clmShift"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftSName"])); //ds.Rows[i]["ShiftSName"].ToString();
        //                dataGridView1.Rows[i].Cells["clmShiftGroupId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftGroupId"]));

        //                dtInTime = Convert.ToDateTime(ds.Rows[i]["InTime"].ToString());
        //                dtOutTime = Convert.ToDateTime(ds.Rows[i]["OutTime"].ToString());

        //                objPC.CategoryId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["CategoryId"])));
        //                objPC.ContractorId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ContractorId"])));

        //                //objRL.Get_CategoriesDetails_By_Id();

        //                EditFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EditFlag"])));
        //                if(EditFlag ==0)
        //                {
        //                    //objRL.Attendance_Working1();
        //                }

        //                dataGridView1.Rows[i].Cells["clmInTime"].Value = dtInTime.ToString("HH:mm");
        //                dataGridView1.Rows[i].Cells["clmOutTime"].Value = dtOutTime.ToString("HH:mm");

        //                //objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftId"])));
        //                dataGridView1.Rows[i].Cells["clmShiftDuration"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftDurationHours"])); // objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftDuration"])); //ds.Rows[i]["ShiftId"].ToString();
        //                dataGridView1.Rows[i].Cells["clmDuration"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Duration"])); //Convert.ToString(ds.Rows[i]["Duration"].ToString());
        //                dataGridView1.Rows[i].Cells["clmOverTime"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["OverTime"]));
        //                dataGridView1.Rows[i].Cells["clmTotalDuration"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["TotalDuration"]));
        //                dataGridView1.Rows[i].Cells["clmStatus"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Status"]));

        //                dataGridView1.Rows[i].Cells["clmLateBy"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LateBy"]));
        //                dataGridView1.Rows[i].Cells["clmEarlyBy"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EarlyBy"]));
        //                dataGridView1.Rows[i].Cells["clmMissedInPunch"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["MissedInPunch"]));
        //                dataGridView1.Rows[i].Cells["clmMissedOutPunch"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["MissedInPunch"]));

        //                dataGridView1.Rows[i].Cells["clmChangeDepartmentFlag"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentFlag"]));
        //                dataGridView1.Rows[i].Cells["clmChangeDepartmentId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentId"]));
        //                dataGridView1.Rows[i].Cells["clmChangeLocationId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeLocationtId"]));

        //                objPC.LeaveType = string.Empty;
        //                objAL.LeaveDetailsEmployees();

        //                if (objPC.LeaveTypeId == 0)
        //                {
        //                    objPC.LeaveTypeId = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LeaveTypeId"])));
        //                    objRL.GetLeaveDetailsEmployees_ByLeaveId();
        //                    dataGridView1.Rows[i].Cells["clmLeave"].Value = objPC.LeaveType.ToString();
        //                    dataGridView1.Rows[i].Cells["clmLeaveTypeId"].Value = objPC.LeaveTypeId.ToString();
        //                }

        //                dataGridView1.Rows[i].Cells["clmLeaveTypeId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LeaveTypeId"]));
        //                dataGridView1.Rows[i].Cells["clmLeaveDuration"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LeaveDuration"]));
        //                //dataGridView1.Rows[i].Cells["clmWeeklyOff"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["WeeklyOff"]));

        //                //dataGridView1.Rows[i].Cells["clmHoliday"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Holiday"]));
        //                //dataGridView1.Rows[i].Cells["clmLeaveRemarks"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LeaveRemarks"]));
        //                dataGridView1.Rows[i].Cells["clmPunchRecords"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["PunchRecords"]));
        //                dataGridView1.Rows[i].Cells["clmLossOfHours"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LossOfHours"]));
        //                dataGridView1.Rows[i].Cells["clmRemarksGrid"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Remarks"]));

        //                //Leave Working
        //                objPC.EmployeeId = Convert.ToInt32(ds.Rows[i]["EmployeeId"].ToString());
        //                //objPC.CheckDate = objPC.AttendanceDate;

        //                dataGridView1.Rows[i].Cells["clmChangeDepartmentFlag"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentFlag"]));
        //                objPC.ChangeDepartmentFlag =Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentFlag"])));

        //                if(objPC.ChangeDepartmentFlag == 1)
        //                {
        //                    objPC.ChangeLocationtId = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeLocationtId"])));
        //                    objPC.ChangeDepartmentId = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentId"])));


        //                    dataGridView1.Rows[i].Cells["clmChangeLocation"].Value = objRL.Fill_Location_By_LocationId(objPC.ChangeLocationtId);
        //                    dataGridView1.Rows[i].Cells["clmDepartmentChange"].Value = objRL.Fill_Department_By_DepartmentId(objPC.ChangeDepartmentId);
        //                }

        //                dtpAttendanceDate.Value = objPC.AttendanceDate;

        //                if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[i]["LateBy"].ToString())))
        //                {
        //                    LateBy = Convert.ToDouble(ds.Rows[i]["LateBy"].ToString());
        //                    dataGridView1.Rows[i].Cells["clmLateBy"].Value = LateBy.ToString();
        //                    if (LateBy > 10)
        //                    {
        //                        objRL.Set_Error_Color(dataGridView1, i, "clmInTime", Color.FromName(BusinessResources.LS_Error_Color));
        //                        objRL.Set_Error_Color(dataGridView1, i, "clmLateBy", Color.FromName(BusinessResources.LS_Error_Color));
        //                    }
        //                    else
        //                    {
        //                        dataGridView1.Rows[i].Cells["clmLateBy"].Value = "0";
        //                        objRL.Set_Error_Color(dataGridView1, i, "clmInTime", Color.White);
        //                        objRL.Set_Error_Color(dataGridView1, i, "clmLateBy", Color.White);
        //                    }
        //                }

        //                if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[i]["EarlyBy"].ToString())))
        //                {
        //                    EarlyBy = Convert.ToDouble(ds.Rows[i]["EarlyBy"].ToString());
        //                    dataGridView1.Rows[i].Cells["clmEarlyBy"].Value = EarlyBy.ToString();
        //                    if (EarlyBy > 10)
        //                    {
        //                        objRL.Set_Error_Color(dataGridView1, i, "clmOutTime", Color.FromName(BusinessResources.LS_Error_Color));
        //                        objRL.Set_Error_Color(dataGridView1, i, "clmEarlyBy", Color.FromName(BusinessResources.LS_Error_Color));
        //                    }
        //                    else
        //                    {
        //                        dataGridView1.Rows[i].Cells["clmEarlyBy"].Value = "0";
        //                        objRL.Set_Error_Color(dataGridView1, i, "clmOutTime", Color.White);
        //                        objRL.Set_Error_Color(dataGridView1, i, "clmEarlyBy", Color.White);
        //                    }
        //                }

        //                if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[i]["MissedInPunch"].ToString())))
        //                {
        //                    string MIP = ds.Rows[i]["MissedInPunch"].ToString();
        //                    dataGridView1.Rows[i].Cells["clmMissedInPunch"].Value = MIP.ToString();

        //                    if (Convert.ToInt32(MIP) !=0) // == "Yes")
        //                        objRL.Set_Error_Color(dataGridView1, i, "clmMissedInPunch", Color.FromName(BusinessResources.LS_Error_Color));
        //                    else
        //                        objRL.Set_Error_Color(dataGridView1, i, "clmMissedInPunch", Color.White);
        //                }

        //                if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[i]["MissedOutPunch"].ToString())))
        //                {
        //                    string MIP = ds.Rows[i]["MissedOutPunch"].ToString();
        //                    dataGridView1.Rows[i].Cells["clmMissedOutPunch"].Value = MIP.ToString();

        //                    if (Convert.ToInt32(MIP) !=0) //"Yes")
        //                        objRL.Set_Error_Color(dataGridView1, i, "clmMissedOutPunch", Color.FromName(BusinessResources.LS_Error_Color));
        //                    else
        //                        objRL.Set_Error_Color(dataGridView1, i, "clmMissedInPunch", Color.White);
        //                }

        //                SrNo++;
        //            }

        //            Get_Count_All();
        //        }
        //    }
        //}

        //private void Fill_Grid_AttendanceRecord()
        //{
        //    objEP.Clear();

        //    dataGridView1.Rows.Clear();

        //    if (objPC.AttendanceRecordMasterId != 0)
        //    {
        //        lblData.Text = objPC.AttendanceData.ToString();
        //        cmbAttendanceStatus.Text = objPC.ApprovalStatus;

        //        if (cmbAttendanceStatus.SelectedIndex > -1)
        //            SetStatusColor();

        //        DataTable ds = new DataTable();
        //        WhereClause = string.Empty;
        //        MainQuery = string.Empty;

        //        if (!string.IsNullOrEmpty(Convert.ToString(txtSearchEmpCode.Text)))
        //            WhereClause = " and E.EmployeeCode=" + txtSearchEmpCode.Text + " ";
        //        else
        //        {
        //            if (!cbContractor.Checked)
        //            {
        //                if (cmbContractor.SelectedIndex == -1)
        //                {
        //                    cmbContractor.Focus();
        //                    objEP.SetError(cmbContractor, "Select Contractor");
        //                    return;
        //                }
        //                else
        //                    WhereClause = " and E.ContractorId=" + cmbContractor.SelectedValue + " ";
        //            }
        //            else if (!cbStatus.Checked)
        //            {
        //                if (cmbStatus.SelectedIndex == -1)
        //                {
        //                    cmbStatus.Focus();
        //                    objEP.SetError(cmbStatus, "Select Status");
        //                    return;
        //                }
        //                else
        //                    WhereClause += " and AR.Status='" + cmbStatus.Text + "' ";
        //            }
        //            else if (cbMissedPunch.Checked)
        //            {
        //                //MissedInPunch int 
        //                //MissedOutPunch
        //                WhereClause += " and AR.MissedOutPunch=" + MissedInOutPunch + " ";
        //            }
        //            else
        //                WhereClause = string.Empty;
        //        }

        //        MainQuery = "select " +
        //                     "AR.AttendanceRecordId," +
        //                     "AR.AttendanceRecordMasterId," +
        //                     "AR.AttendanceHistoryId," +
        //                     "AR.EsslAttendanceLogsId," +
        //                     "AR.EmployeeId," +
        //                     "E.EmployeeName," +
        //                     "E.EmployeeCode," +
        //                     "AR.ShiftId," +
        //                     "S.ShiftSName," +
        //                     "AR.ShiftGroupId," +
        //                     "AR.InTime," +
        //                     "AR.OutTime," +
        //                     "AR.Duration," +
        //                     "AR.OverTime," +
        //                     "AR.TotalDuration," +
        //                     "AR.Status," +
        //                     "AR.LateBy," +
        //                     "AR.EarlyBy," +
        //                     "AR.MissedInPunch," +
        //                     "AR.MissedOutPunch," +
        //                     "AR.ChangeDepartmentFlag," +
        //                     "AR.ChangeDepartmentId," +
        //                     "AR.ChangeLocationtId," +
        //                     "AR.LeaveTypeId," +
        //                     "AR.LeaveDuration," +
        //                     "AR.WeeklyOff," +
        //                     "AR.Holiday," +
        //                     "AR.LeaveRemarks," +
        //                     "AR.PunchRecords," +
        //                     "AR.LossOfHours," +
        //                     "AR.Present," +
        //                     "AR.Absent," +
        //                     "AR.Remarks," +
        //                     "S.ShiftDuration," +
        //                     "S.ShiftDurationHours," +
        //                     "S.BeginTime," +
        //                     "S.EndTime," +
        //                     "AR.EditFlag," +
        //                     "E.CategoryId," +
        //                     "E.ContractorId" +
        //                     " from AttendanceRecord AR inner join " +
        //                     " Employees E on E.EmployeeId=AR.EmployeeId inner join " +
        //                     " shifts S on S.ShiftId=AR.ShiftId " +
        //                     " where " +
        //                     " AR.AttendanceRecordMasterId=" + objPC.AttendanceRecordMasterId + " and " +
        //                     " AR.CancelTag=0 and" +
        //                     " E.CancelTag=0 and " +
        //                     " S.CancelTag=0 ";
        //        //+ " order by E.EmployeeCode asc";

        //        objBL.Query = MainQuery + WhereClause + " order by E.EmployeeCode asc";
        //        ds = objBL.ReturnDataTable();

        //        if (ds.Rows.Count > 0)
        //        {
        //            lblTotalCount.Text = "Total Count: " + ds.Rows.Count.ToString();

        //            SrNo = 1;
        //            for (int i = 0; i < ds.Rows.Count; i++)
        //            {
        //                //0 AR.AttendanceRecordId,
        //                //1 AR.AttendanceRecordMasterId,
        //                //2 AR.AttendanceHistoryId,
        //                //3 AR.EsslAttendanceLogsId,
        //                //4 AR.EmployeeId, 
        //                //5 E.EmployeeName,
        //                //6 E.EmployeeCode,
        //                //7 AR.ShiftId, 
        //                //8 S.ShiftSName,
        //                //9 AR.ShiftGroupId,
        //                //10 AR.InTime,
        //                //11 AR.OutTime,
        //                //12 AR.Duration,
        //                //13AR.OverTime,
        //                //14 AR.TotalDuration,
        //                //15 AR.Status,
        //                //16 AR.LateBy,
        //                //17 AR.EarlyBy,
        //                //18 AR.MissedInPunch,
        //                //19 AR.MissedOutPunch,
        //                //20 AR.ChangeDepartmentFlag,
        //                //21 AR.ChangeDepartmentId,
        //                //22 AR.ChangeLocationtId,
        //                //23 AR.IsOnLeave,
        //                //24 AR.LeaveTypeId,
        //                //25 AR.LeaveDuration,
        //                //26 AR.WeeklyOff,
        //                //27 AR.Holiday,
        //                //28 AR.LeaveRemarks,
        //                //29 AR.PunchRecords,
        //                //30 AR.LossOfHours,
        //                //31 AR.Present,
        //                //32 AR.Absent,
        //                //33 AR.Remarks
        //                //34  S.ShiftDuration,
        //                //35 S.ShiftDurationHours,
        //                //36 S.BeginTime,
        //                //37 S.EndTime,
        //                //38 AR.EditFlag,
        //                //E.CategoryId,
        //                //E.ContractorId

        //                dataGridView1.Rows.Add();

        //                int EditFlag = 0;

        //                dataGridView1.Rows[i].Cells["clmSrNo"].Value = SrNo.ToString();
        //                dataGridView1.Rows[i].Cells["clmAttendanceRecordId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["AttendanceRecordId"])); //ds.Rows[i]["AttendanceRecordId"].ToString();
        //                dataGridView1.Rows[i].Cells["clmAttendanceRecordMasterId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["AttendanceRecordMasterId"])); //ds.Rows[i]["AttendanceRecordMasterId"].ToString();
        //                dataGridView1.Rows[i].Cells["clmEsslAttendanceLogsId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EsslAttendanceLogsId"])); //ds.Rows[i]["EsslAttendanceLogsId"].ToString();
        //                dataGridView1.Rows[i].Cells["clmEmployeeId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EmployeeId"])); //ds.Rows[i]["EmployeeId"].ToString();
        //                dataGridView1.Rows[i].Cells["clmEmployeeName"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EmployeeName"])); //ds.Rows[i]["EmployeeName"].ToString();
        //                dataGridView1.Rows[i].Cells["clmEmployeeCode"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EmployeeCode"])); //ds.Rows[i]["EmployeeCode"].ToString();

        //                dataGridView1.Rows[i].Cells["clmShiftId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftId"])); //ds.Rows[i]["ShiftId"].ToString();
        //                dataGridView1.Rows[i].Cells["clmShift"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftSName"])); //ds.Rows[i]["ShiftSName"].ToString();
        //                dataGridView1.Rows[i].Cells["clmShiftGroupId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftGroupId"]));

        //                dtInTime = Convert.ToDateTime(ds.Rows[i]["InTime"].ToString());
        //                dtOutTime = Convert.ToDateTime(ds.Rows[i]["OutTime"].ToString());

        //                objPC.CategoryId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["CategoryId"])));
        //                objPC.ContractorId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ContractorId"])));

        //                //objRL.Get_CategoriesDetails_By_Id();

        //                EditFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EditFlag"])));
        //                if (EditFlag == 0)
        //                {
        //                    //objRL.Attendance_Working1();
        //                }

        //                dataGridView1.Rows[i].Cells["clmInTime"].Value = dtInTime.ToString("HH:mm");
        //                dataGridView1.Rows[i].Cells["clmOutTime"].Value = dtOutTime.ToString("HH:mm");

        //                //objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftId"])));
        //                dataGridView1.Rows[i].Cells["clmShiftDuration"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftDurationHours"])); // objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftDuration"])); //ds.Rows[i]["ShiftId"].ToString();
        //                dataGridView1.Rows[i].Cells["clmDuration"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Duration"])); //Convert.ToString(ds.Rows[i]["Duration"].ToString());
        //                dataGridView1.Rows[i].Cells["clmOverTime"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["OverTime"]));
        //                dataGridView1.Rows[i].Cells["clmTotalDuration"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["TotalDuration"]));
        //                dataGridView1.Rows[i].Cells["clmStatus"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Status"]));

        //                dataGridView1.Rows[i].Cells["clmLateBy"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LateBy"]));
        //                dataGridView1.Rows[i].Cells["clmEarlyBy"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EarlyBy"]));
        //                dataGridView1.Rows[i].Cells["clmMissedInPunch"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["MissedInPunch"]));
        //                dataGridView1.Rows[i].Cells["clmMissedOutPunch"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["MissedInPunch"]));

        //                dataGridView1.Rows[i].Cells["clmChangeDepartmentFlag"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentFlag"]));
        //                dataGridView1.Rows[i].Cells["clmChangeDepartmentId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentId"]));
        //                dataGridView1.Rows[i].Cells["clmChangeLocationId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeLocationtId"]));

        //                objPC.LeaveType = string.Empty;
        //                objAL.LeaveDetailsEmployees();

        //                if (objPC.LeaveTypeId == 0)
        //                {
        //                    objPC.LeaveTypeId = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LeaveTypeId"])));
        //                    objRL.GetLeaveDetailsEmployees_ByLeaveId();
        //                    dataGridView1.Rows[i].Cells["clmLeave"].Value = objPC.LeaveType.ToString();
        //                    dataGridView1.Rows[i].Cells["clmLeaveTypeId"].Value = objPC.LeaveTypeId.ToString();
        //                }

        //                dataGridView1.Rows[i].Cells["clmLeaveTypeId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LeaveTypeId"]));
        //                dataGridView1.Rows[i].Cells["clmLeaveDuration"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LeaveDuration"]));
        //                //dataGridView1.Rows[i].Cells["clmWeeklyOff"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["WeeklyOff"]));

        //                //dataGridView1.Rows[i].Cells["clmHoliday"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Holiday"]));
        //                //dataGridView1.Rows[i].Cells["clmLeaveRemarks"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LeaveRemarks"]));
        //                dataGridView1.Rows[i].Cells["clmPunchRecords"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["PunchRecords"]));
        //                dataGridView1.Rows[i].Cells["clmLossOfHours"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LossOfHours"]));
        //                dataGridView1.Rows[i].Cells["clmRemarksGrid"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Remarks"]));

        //                //Leave Working
        //                objPC.EmployeeId = Convert.ToInt32(ds.Rows[i]["EmployeeId"].ToString());
        //                //objPC.CheckDate = objPC.AttendanceDate;

        //                dataGridView1.Rows[i].Cells["clmChangeDepartmentFlag"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentFlag"]));
        //                objPC.ChangeDepartmentFlag = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentFlag"])));

        //                if (objPC.ChangeDepartmentFlag == 1)
        //                {
        //                    objPC.ChangeLocationtId = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeLocationtId"])));
        //                    objPC.ChangeDepartmentId = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentId"])));


        //                    dataGridView1.Rows[i].Cells["clmChangeLocation"].Value = objRL.Fill_Location_By_LocationId(objPC.ChangeLocationtId);
        //                    dataGridView1.Rows[i].Cells["clmDepartmentChange"].Value = objRL.Fill_Department_By_DepartmentId(objPC.ChangeDepartmentId);
        //                }

        //                dtpAttendanceDate.Value = objPC.AttendanceDate;

        //                if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[i]["LateBy"].ToString())))
        //                {
        //                    LateBy = Convert.ToDouble(ds.Rows[i]["LateBy"].ToString());
        //                    dataGridView1.Rows[i].Cells["clmLateBy"].Value = LateBy.ToString();
        //                    if (LateBy > 10)
        //                    {
        //                        objRL.Set_Error_Color(dataGridView1, i, "clmInTime", Color.FromName(BusinessResources.LS_Error_Color));
        //                        objRL.Set_Error_Color(dataGridView1, i, "clmLateBy", Color.FromName(BusinessResources.LS_Error_Color));
        //                    }
        //                    else
        //                    {
        //                        dataGridView1.Rows[i].Cells["clmLateBy"].Value = "0";
        //                        objRL.Set_Error_Color(dataGridView1, i, "clmInTime", Color.White);
        //                        objRL.Set_Error_Color(dataGridView1, i, "clmLateBy", Color.White);
        //                    }
        //                }

        //                if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[i]["EarlyBy"].ToString())))
        //                {
        //                    EarlyBy = Convert.ToDouble(ds.Rows[i]["EarlyBy"].ToString());
        //                    dataGridView1.Rows[i].Cells["clmEarlyBy"].Value = EarlyBy.ToString();
        //                    if (EarlyBy > 10)
        //                    {
        //                        objRL.Set_Error_Color(dataGridView1, i, "clmOutTime", Color.FromName(BusinessResources.LS_Error_Color));
        //                        objRL.Set_Error_Color(dataGridView1, i, "clmEarlyBy", Color.FromName(BusinessResources.LS_Error_Color));
        //                    }
        //                    else
        //                    {
        //                        dataGridView1.Rows[i].Cells["clmEarlyBy"].Value = "0";
        //                        objRL.Set_Error_Color(dataGridView1, i, "clmOutTime", Color.White);
        //                        objRL.Set_Error_Color(dataGridView1, i, "clmEarlyBy", Color.White);
        //                    }
        //                }

        //                if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[i]["MissedInPunch"].ToString())))
        //                {
        //                    string MIP = ds.Rows[i]["MissedInPunch"].ToString();
        //                    dataGridView1.Rows[i].Cells["clmMissedInPunch"].Value = MIP.ToString();

        //                    if (Convert.ToInt32(MIP) != 0) // == "Yes")
        //                        objRL.Set_Error_Color(dataGridView1, i, "clmMissedInPunch", Color.FromName(BusinessResources.LS_Error_Color));
        //                    else
        //                        objRL.Set_Error_Color(dataGridView1, i, "clmMissedInPunch", Color.White);
        //                }

        //                if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[i]["MissedOutPunch"].ToString())))
        //                {
        //                    string MIP = ds.Rows[i]["MissedOutPunch"].ToString();
        //                    dataGridView1.Rows[i].Cells["clmMissedOutPunch"].Value = MIP.ToString();

        //                    if (Convert.ToInt32(MIP) != 0) //"Yes")
        //                        objRL.Set_Error_Color(dataGridView1, i, "clmMissedOutPunch", Color.FromName(BusinessResources.LS_Error_Color));
        //                    else
        //                        objRL.Set_Error_Color(dataGridView1, i, "clmMissedInPunch", Color.White);
        //                }

        //                SrNo++;
        //            }
        //            Get_Count_All();
        //            Get_Contractor_Count();

        //            dataGridView1.ClearSelection();
        //            dataGridView1.Rows[0].Cells[0].Selected = false;
        //        }
        //    }
        //}

        double OTHoursTotal = 0;

        private void Fill_Grid_AttendanceRecord()
        {
            TotalDurationDuration = 0; OTHoursTotal = 0; TotalHoursCount = 0;
            objPC.EditFlag = 0;

            objEP.Clear();
            OTHoursTotal = 0;
            TOT = TimeSpan.Zero;

            dataGridView1.Rows.Clear();

            if (objPC.AttendanceRecordMasterId != 0)
            {
                lblData.Text = objPC.AttendanceData.ToString();
                cmbAttendanceStatus.Text = objPC.ApprovalStatus;

                if (cmbAttendanceStatus.SelectedIndex > -1)
                    SetStatusColor();

                DataTable ds = new DataTable();
                WhereClause = string.Empty;
                MainQuery = string.Empty;

                if (!string.IsNullOrEmpty(Convert.ToString(txtSearchEmpCode.Text)))
                    WhereClause = " and E.EmployeeCode=" + txtSearchEmpCode.Text + " ";
                else
                {
                    if (!cbContractor.Checked)
                    {
                        if (cmbContractor.SelectedIndex == -1)
                        {
                            cmbContractor.Focus();
                            objEP.SetError(cmbContractor, "Select Contractor");
                            return;
                        }
                        else
                            WhereClause = " and E.ContractorId=" + cmbContractor.SelectedValue + " ";
                    }
                    else if (!cbStatus.Checked)
                    {
                        if (cmbStatus.SelectedIndex == -1)
                        {
                            cmbStatus.Focus();
                            objEP.SetError(cmbStatus, "Select Status");
                            return;
                        }
                        else
                            WhereClause += " and AR.Status='" + cmbStatus.Text + "' ";
                    }
                    else if (cbMissedPunch.Checked)
                    {
                        //MissedInPunch int 
                        //MissedOutPunch
                        WhereClause += " and AR.MissedOutPunch=" + MissedInOutPunch + " ";
                    }
                    else
                        WhereClause = string.Empty;
                }

                MainQuery = "select " +
                             "AR.AttendanceRecordId," +
                             "AR.AttendanceRecordMasterId," +
                             "AR.AttendanceHistoryId," +
                             "AR.EsslAttendanceLogsId," +
                             "AR.EmployeeId," +
                             "E.EmployeeName," +
                             "E.EmployeeCode," +
                             "AR.ShiftId," +
                             "S.ShiftSName," +
                             "E.ShiftGroupId," +
                             "AR.InTime," +
                             "AR.OutTime," +
                             "AR.Duration," +
                             "AR.OverTime," +
                             "AR.TotalDuration," +
                             "AR.Status," +
                             "AR.LateBy," +
                             "AR.EarlyBy," +
                             "AR.MissedInPunch," +
                             "AR.MissedOutPunch," +
                             "AR.ChangeDepartmentFlag," +
                             "AR.ChangeDepartmentId," +
                             "AR.ChangeLocationtId," +
                             "AR.LeaveTypeId," +
                             "AR.LeaveDuration," +
                             "AR.WeeklyOff," +
                             "AR.Holiday," +
                             "AR.LeaveRemarks," +
                             "AR.PunchRecords," +
                             "AR.LossOfHours," +
                             "AR.Present," +
                             "AR.Absent," +
                             "AR.Remarks," +
                             "S.ShiftDuration," +
                             "S.ShiftDurationHours," +
                             "S.BeginTime," +
                             "S.EndTime," +
                             "AR.EditFlag," +
                             "E.CategoryId," +
                             "E.ContractorId," +
                             "AR.Notes, " +
                             "E.Gender," +
                             "E.OverTimeApplicable," +
                             "E.FlexibleHoursFlag," +
                             "AR.OutDoorEntryFlag, " +
                             "AR.OTApprovalFlag," +
                             "AR.OTApprovalStatus," +
                             "AR.OTRemarks," +
                             "AR.OTReply " +
                             " from AttendanceRecord AR inner join " +
                             " Employees E on E.EmployeeId=AR.EmployeeId inner join " +
                             " shifts S on S.ShiftId=AR.ShiftId " +
                             " where " +
                             " AR.AttendanceRecordMasterId=" + objPC.AttendanceRecordMasterId + " and " +
                             " AR.CancelTag=0 and" +
                             " E.CancelTag=0 and " +
                             " E.EmployeeCode NOT IN" +
                             "(100001,100004,50002,50003,50004,50005,50006,50007,50008,50009,50010,50011,50013,50014,50015,50016,50017,50018,50019,50020,50012,50021,50022,50023,50024,50025,50026,50027,50028) " +
                             " and " +
                             " S.CancelTag=0 ";

                //"(50002,50003,50004,50005,50006,50007,50008,50009,50010,50011,50012,50013,50014,50015,50016,50017,50018,100001,100002,100003,100004)" +

                objBL.Query = MainQuery + WhereClause + " order by E.EmployeeCode asc";
                ds = objBL.ReturnDataTable();

                if (ds.Rows.Count > 0)
                {
                    lblTotalCount.Text = "Total Count: " + ds.Rows.Count.ToString();

                    if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR || BusinessLayer.UserType == BusinessResources.USER_TYPE_HROFFICER)
                    {
                        lblContractorCount.Visible = true;
                        rtbContractorWiseCount.Visible = true;
                    }
                    else
                    {
                        lblContractorCount.Visible = false;
                        rtbContractorWiseCount.Visible = false;
                    }

                    SrNo = 1;
                    for (int i = 0; i < ds.Rows.Count; i++)
                    {
                        //0 AR.AttendanceRecordId,
                        //1 AR.AttendanceRecordMasterId,
                        //2 AR.AttendanceHistoryId,
                        //3 AR.EsslAttendanceLogsId,
                        //4 AR.EmployeeId, 
                        //5 E.EmployeeName,
                        //6 E.EmployeeCode,
                        //7 AR.ShiftId, 
                        //8 S.ShiftSName,
                        //9 AR.ShiftGroupId,
                        //10 AR.InTime,
                        //11 AR.OutTime,
                        //12 AR.Duration,
                        //13AR.OverTime,
                        //14 AR.TotalDuration,
                        //15 AR.Status,
                        //16 AR.LateBy,
                        //17 AR.EarlyBy,
                        //18 AR.MissedInPunch,
                        //19 AR.MissedOutPunch,
                        //20 AR.ChangeDepartmentFlag,
                        //21 AR.ChangeDepartmentId,
                        //22 AR.ChangeLocationtId,
                        //23 AR.IsOnLeave,
                        //24 AR.LeaveTypeId,
                        //25 AR.LeaveDuration,
                        //26 AR.WeeklyOff,
                        //27 AR.Holiday,
                        //28 AR.LeaveRemarks,
                        //29 AR.PunchRecords,
                        //30 AR.LossOfHours,
                        //31 AR.Present,
                        //32 AR.Absent,
                        //33 AR.Remarks
                        //34  S.ShiftDuration,
                        //35 S.ShiftDurationHours,
                        //36 S.BeginTime,
                        //37 S.EndTime,
                        //38 AR.EditFlag,
                        //E.CategoryId,
                        //E.ContractorId
                        //"AR.OTApprovalFlag," +
                        //"AR.OTApprovalStatus," +
                        //"AR.OTRemarks," +
                        //"AR.OTReply" +

                        dataGridView1.Rows.Add();
                        int EditFlag = 0; TimeSpan OTH = TimeSpan.Zero;

                        //EditFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EditFlag"])));
                        //if (EditFlag == 0)
                        //{
                        //    //objRL.Attendance_Working1();
                        //}

                        dataGridView1.Rows[i].Cells["clmSrNo"].Value = SrNo.ToString();
                        dtpAttendanceDate.Value = objPC.AttendanceDate;

                        dataGridView1.Rows[i].Cells["clmAttendanceRecordId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["AttendanceRecordId"])); //ds.Rows[i]["AttendanceRecordId"].ToString();
                        dataGridView1.Rows[i].Cells["clmAttendanceRecordMasterId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["AttendanceRecordMasterId"])); //ds.Rows[i]["AttendanceRecordMasterId"].ToString();
                        dataGridView1.Rows[i].Cells["clmEsslAttendanceLogsId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EsslAttendanceLogsId"])); //ds.Rows[i]["EsslAttendanceLogsId"].ToString();
                        dataGridView1.Rows[i].Cells["clmEmployeeId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EmployeeId"])); //ds.Rows[i]["EmployeeId"].ToString();
                        dataGridView1.Rows[i].Cells["clmEmployeeName"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EmployeeName"])); //ds.Rows[i]["EmployeeName"].ToString();
                        dataGridView1.Rows[i].Cells["clmGender"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Gender"])); //ds.Rows[i]["EmployeeName"].ToString();
                        dataGridView1.Rows[i].Cells["clmEmployeeCode"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EmployeeCode"])); //ds.Rows[i]["EmployeeCode"].ToString();
                        dataGridView1.Rows[i].Cells["clmShiftId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftId"])); //ds.Rows[i]["ShiftId"].ToString();
                        dataGridView1.Rows[i].Cells["clmShift"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftSName"])); //ds.Rows[i]["ShiftSName"].ToString();
                        dataGridView1.Rows[i].Cells["clmShiftGroupId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftGroupId"]));
                        objPC.CategoryId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["CategoryId"])));
                        objPC.ContractorId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ContractorId"])));
                        objPC.OverTimeApplicable = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["OverTimeApplicable"])));
                        objPC.FlexibleHoursFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["FlexibleHoursFlag"])));

                        dataGridView1.Rows[i].Cells["clmOTApprovalFlag"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["OTApprovalFlag"]));
                        dataGridView1.Rows[i].Cells["clmOTStatus"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["OTApprovalStatus"]));
                        dataGridView1.Rows[i].Cells["clmOTRemarks"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["OTRemarks"]));
                        dataGridView1.Rows[i].Cells["clmOTReply"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["OTReply"]));

                        //"AR.OTApprovalFlag," +
                        //"AR.OTApprovalStatus," +
                        //"AR.OTRemarks," +
                        //"AR.OTReply" +

                        //if(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EmployeeCode"])) == "600145")
                        //{

                        //}

                        dtInTime = Convert.ToDateTime(ds.Rows[i]["InTime"].ToString());
                        dtOutTime = Convert.ToDateTime(ds.Rows[i]["OutTime"].ToString());

                        //objRL.Get_CategoriesDetails_By_Id();

                        dataGridView1.Rows[i].Cells["clmInTime"].Value = dtInTime.ToString("HH:mm");
                        dataGridView1.Rows[i].Cells["clmOutTime"].Value = dtOutTime.ToString("HH:mm");

                        //objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftId"])));
                        dataGridView1.Rows[i].Cells["clmShiftDuration"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftDurationHours"])); // objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftDuration"])); //ds.Rows[i]["ShiftId"].ToString();
                        dataGridView1.Rows[i].Cells["clmDuration"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Duration"])); //Convert.ToString(ds.Rows[i]["Duration"].ToString());

                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[i]["OverTime"])))
                            OTH = TimeSpan.Parse(Convert.ToString(ds.Rows[i]["OverTime"]));
                        else
                            OTH = TimeSpan.Zero;

                        dataGridView1.Rows[i].Cells["clmOverTime"].Value = objAL.Get_String_TimeSpan(OTH);
                        dataGridView1.Rows[i].Cells["clmTotalDuration"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["TotalDuration"]));

                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[i]["TotalDuration"])))
                        {
                            TimeSpan TD = TimeSpan.Parse(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["TotalDuration"])));
                            TotalDurationDuration = Math.Round(TD.TotalHours);
                            TotalHoursCount += TotalDurationDuration;
                        }

                        if (objPC.StatusCode != "A" && objPC.StatusCode != "L" && objPC.StatusCode != "WO" && objPC.StatusCode != "H" && objPC.StatusCode != "H")
                        {
                            if (objPC.FlexibleHoursFlag == 1)
                            {
                                if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[i]["TotalDuration"])))
                                {
                                    //TotalDuration = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["TotalDuration"])));
                                    if (TotalDurationDuration < 8.30)
                                        objRL.Set_Error_Color(dataGridView1, i, "clmTotalDuration", Color.FromName(BusinessResources.LS_Error_Color));
                                }
                            }
                        }

                        //if (Convert.ToInt32(dataGridView1.Rows[i].Cells["clmEmployeeId"].Value) == 317)
                        //{

                        //}

                        //if (objPC.EmployeeCode == 5189)
                        //{

                        //}

                        //dataGridView1.Rows[i].Cells["clmTotalDuration"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["TotalDuration"]));
                        dataGridView1.Rows[i].Cells["clmStatus"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Status"]));

                        //dataGridView1.Rows[i].Cells["clmLateBy"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LateBy"]));
                        //dataGridView1.Rows[i].Cells["clmEarlyBy"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EarlyBy"]));
                        //dataGridView1.Rows[i].Cells["clmMissedInPunch"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["MissedInPunch"]));
                        //dataGridView1.Rows[i].Cells["clmMissedOutPunch"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["MissedInPunch"]));

                        //dataGridView1.Rows[i].Cells["clmChangeDepartmentFlag"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentFlag"]));
                        //dataGridView1.Rows[i].Cells["clmChangeDepartmentId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentId"]));
                        //dataGridView1.Rows[i].Cells["clmChangeLocationId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeLocationtId"]));
                        dataGridView1.Rows[i].Cells["clmPunchRecords"].Value = "";
                        dataGridView1.Rows[i].Cells["clmPunchRecords"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["PunchRecords"]));
                        dataGridView1.Rows[i].Cells["clmLossOfHours"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LossOfHours"]));

                        //if (objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EmployeeCode"])) == "5056")
                        //{

                        //}

                        dataGridView1.Rows[i].Cells["clmRemarksGrid"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Remarks"]));
                        dataGridView1.Rows[i].Cells["clmNotes"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Notes"]));

                        objPC.LeaveTypeId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LeaveTypeId"])));
                        if (objPC.LeaveTypeId > 0)
                        {
                            objRL.GetLeaveDetailsEmployees_ByLeaveId();
                            dataGridView1.Rows[i].Cells["clmLeave"].Value = objPC.LeaveType.ToString();
                            dataGridView1.Rows[i].Cells["clmLeaveTypeId"].Value = objPC.LeaveTypeId.ToString();
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells["clmLeave"].Value = "";
                            dataGridView1.Rows[i].Cells["clmLeaveTypeId"].Value = "";
                        }

                        //objPC.LeaveType = string.Empty;
                        //objAL.LeaveDetailsEmployees();

                        //if (objPC.LeaveTypeId > 0)
                        //{
                        //    objPC.LeaveTypeId = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LeaveTypeId"])));
                        //    objRL.GetLeaveDetailsEmployees_ByLeaveId();
                        //    dataGridView1.Rows[i].Cells["clmLeave"].Value = objPC.LeaveType.ToString();
                        //    dataGridView1.Rows[i].Cells["clmLeaveTypeId"].Value = objPC.LeaveTypeId.ToString();
                        //    dataGridView1.Rows[i].Cells["clmStatus"].Value = "L";
                        //    dataGridView1.Rows[i].Cells["clmInTime"].Value = "00:00";
                        //    dataGridView1.Rows[i].Cells["clmOutTime"].Value = "00:00";

                        //    dataGridView1.Rows[i].Cells["clmInTime"].Value = "00:00";
                        //    dataGridView1.Rows[i].Cells["clmOutTime"].Value = "0:0";

                        //    dataGridView1.Rows[i].Cells["clmShiftDuration"].Value = "00:00";
                        //    dataGridView1.Rows[i].Cells["clmDuration"].Value = "00:00";
                        //    dataGridView1.Rows[i].Cells["clmOverTime"].Value = "00:00";
                        //    dataGridView1.Rows[i].Cells["clmTotalDuration"].Value = "00:00";

                        //    dataGridView1.Rows[i].Cells["clmMissedInPunch"].Value = "0";
                        //    dataGridView1.Rows[i].Cells["clmMissedOutPunch"].Value = "0";

                        //    dataGridView1.Rows[i].Cells["clmChangeDepartmentFlag"].Value = "";
                        //    dataGridView1.Rows[i].Cells["clmChangeDepartmentId"].Value = "";
                        //    dataGridView1.Rows[i].Cells["clmChangeLocationId"].Value = "";

                        //    dataGridView1.Rows[i].Cells["clmPunchRecords"].Value = "";
                        //    dataGridView1.Rows[i].Cells["clmLossOfHours"].Value = "";
                        //    dataGridView1.Rows[i].Cells["clmRemarksGrid"].Value = "";
                        //    dataGridView1.Rows[i].Cells["clmChangeLocation"].Value = "";
                        //    dataGridView1.Rows[i].Cells["clmDepartmentChange"].Value = "";
                        //    dataGridView1.Rows[i].Cells["clmEarlyBy"].Value = "0";
                        //    dataGridView1.Rows[i].Cells["clmLateBy"].Value = "0";
                        //    dataGridView1.Rows[i].Cells["clmMissedInPunch"].Value = "";
                        //}
                        //else
                        //{
                        //    dataGridView1.Rows[i].Cells["clmLeave"].Value = "";
                        //    dataGridView1.Rows[i].Cells["clmLeaveTypeId"].Value = "";
                        //}

                        //dataGridView1.Rows[i].Cells["clmLeaveTypeId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LeaveTypeId"]));
                        //dataGridView1.Rows[i].Cells["clmLeaveDuration"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LeaveDuration"]));
                        //dataGridView1.Rows[i].Cells["clmWeeklyOff"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["WeeklyOff"]));

                        //dataGridView1.Rows[i].Cells["clmHoliday"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Holiday"]));
                        //dataGridView1.Rows[i].Cells["clmLeaveRemarks"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LeaveRemarks"]));


                        //Leave Working
                        objPC.EmployeeId = Convert.ToInt32(ds.Rows[i]["EmployeeId"].ToString());
                        //objPC.CheckDate = objPC.AttendanceDate;

                        dataGridView1.Rows[i].Cells["clmChangeDepartmentFlag"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentFlag"]));
                        objPC.ChangeDepartmentFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentFlag"])));

                        if (objPC.ChangeDepartmentFlag == 1)
                        {
                            objPC.ChangeLocationtId = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeLocationtId"])));
                            objPC.ChangeDepartmentId = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentId"])));

                            //dataGridView1.Rows[i].Cells["clmChangeLocation"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeLocation"]));
                            //dataGridView1.Rows[i].Cells["clmDepartmentChange"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartment"]));

                            dataGridView1.Rows[i].Cells["clmChangeLocation"].Value = objRL.Fill_Location_By_LocationId(objPC.ChangeLocationtId);
                            dataGridView1.Rows[i].Cells["clmDepartmentChange"].Value = objRL.Fill_Department_By_DepartmentId(objPC.ChangeDepartmentId);


                        }

                        objPC.OutDoorEntryFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["OutDoorEntryFlag"])));
                        objPC.LateBy = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LateBy"])));
                        dataGridView1.Rows[i].Cells["clmLateBy"].Value = objPC.LateBy.ToString();

                        if (objPC.LateBy > 0)
                        {
                            if (objPC.FlexibleHoursFlag == 0)
                            {
                                objRL.Set_Error_Color(dataGridView1, i, "clmInTime", Color.FromName(BusinessResources.LS_Error_Color));
                                objRL.Set_Error_Color(dataGridView1, i, "clmLateBy", Color.FromName(BusinessResources.LS_Error_Color));
                            }
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells["clmLateBy"].Value = "0";
                            objRL.Set_Error_Color(dataGridView1, i, "clmInTime", Color.White);
                            objRL.Set_Error_Color(dataGridView1, i, "clmLateBy", Color.White);
                        }

                        objPC.EarlyBy = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EarlyBy"])));
                        dataGridView1.Rows[i].Cells["clmEarlyBy"].Value = objPC.EarlyBy.ToString();
                        if (objPC.EarlyBy > 0)
                        {
                            if (objPC.FlexibleHoursFlag == 0)
                            {
                                objRL.Set_Error_Color(dataGridView1, i, "clmOutTime", Color.FromName(BusinessResources.LS_Error_Color));
                                objRL.Set_Error_Color(dataGridView1, i, "clmEarlyBy", Color.FromName(BusinessResources.LS_Error_Color));
                            }
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells["clmEarlyBy"].Value = "0";
                            objRL.Set_Error_Color(dataGridView1, i, "clmOutTime", Color.White);
                            objRL.Set_Error_Color(dataGridView1, i, "clmEarlyBy", Color.White);
                        }

                        objPC.MissedInPunch = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["MissedInPunch"])));
                        dataGridView1.Rows[i].Cells["clmMissedInPunch"].Value = objPC.MissedInPunch.ToString();
                        if (objPC.MissedInPunch > 0)
                            objRL.Set_Error_Color(dataGridView1, i, "clmMissedInPunch", Color.FromName(BusinessResources.LS_Error_Color));
                        else
                            objRL.Set_Error_Color(dataGridView1, i, "clmMissedInPunch", Color.White);

                        objPC.MissedOutPunch = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["MissedOutPunch"])));
                        dataGridView1.Rows[i].Cells["clmMissedOutPunch"].Value = objPC.MissedOutPunch.ToString();
                        if (objPC.MissedOutPunch > 0)
                            objRL.Set_Error_Color(dataGridView1, i, "clmMissedOutPunch", Color.FromName(BusinessResources.LS_Error_Color));
                        else
                            objRL.Set_Error_Color(dataGridView1, i, "clmMissedOutPunch", Color.White);

                        objPC.OTApprovalFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["OTApprovalFlag"])));

                        if(objPC.OTApprovalFlag > 0)
                        {
                            objPC.OTApprovalStatus = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["OTApprovalStatus"]));

                            if(objPC.OTApprovalStatus == BusinessResources.LS_Remarks)
                            {
                                objRL.Set_Error_Color(dataGridView1, i, "clmOverTime", Color.FromName(BusinessResources.LS_Remarks_Color));
                            }
                            else if (objPC.OTApprovalStatus == BusinessResources.LS_Remarks)
                            {
                                objRL.Set_Error_Color(dataGridView1, i, "clmOverTime", Color.FromName(BusinessResources.LS_Manager_Color));
                            }
                            else
                            {
                                objRL.Set_Error_Color(dataGridView1, i, "clmOverTime", Color.White);
                            }
                        }

                        SrNo++;

                        TOT = TimeSpan.Zero;

                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[i]["OverTime"])))
                        {
                            TOT = TimeSpan.Parse(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["OverTime"])));
                            OTHoursTotal += TOT.Hours;
                        }
                    }
                    Get_Count_All();
                    Get_Contractor_Count();

                    dataGridView1.ClearSelection();
                    //dataGridView1.Rows[0].Cells[0].Selected = false;
                }
            }
        }

        TimeSpan TOT = TimeSpan.Zero;

        public void Get_Contractor_Count()
        {
            rtbContractorWiseCount.Text = "";
            string ContractorConcat = string.Empty;
            string ContractorName = string.Empty;

            int CID = 0, CCount = 0;
            DataSet ds = new DataSet();
            objBL.Query = "select ContractorId,ContractorName from contractormaster where CancelTag=0 ";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["ContractorId"])))
                    {
                        CID = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["ContractorId"])));
                        ContractorName = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["ContractorName"]));
                        if (CID > 0)
                        {
                            DataSet dsCount = new DataSet();
                            objBL.Query = "select Count(AR.AttendanceRecordId) as 'CCount' from AttendanceRecord AR inner join Employees E on E.EmployeeId=AR.EmployeeId where E.CancelTag=0 and AR.CancelTag=0 and AR.AttendanceRecordMasterId=" + objPC.AttendanceRecordMasterId + " and E.ContractorId=" + CID + "";
                            dsCount = objBL.ReturnDataSet();
                            if (dsCount.Tables[0].Rows.Count > 0)
                            {
                                CCount = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dsCount.Tables[0].Rows[0]["CCount"])));

                                if (CCount > 0)
                                    ContractorConcat += ContractorName + "-" + CCount.ToString() + System.Environment.NewLine;
                            }
                        }
                    }
                }
                rtbContractorWiseCount.Text = ContractorConcat.ToString();
            }
        }

        private void FillGrid_With_Search()
        {
            DataTable ds = new DataTable();
            WhereClause = string.Empty;
            MainQuery = string.Empty;

            if (!string.IsNullOrEmpty(Convert.ToString(txtSearchEmpCode.Text)))
                WhereClause = " and E.EmployeeCode=" + txtSearchEmpCode.Text + " ";
            else
            {
                if (!cbContractor.Checked)
                    WhereClause = " and E.ContractorId=" + cmbContractor.SelectedValue + " ";
                else if (!cbStatus.Checked)
                    WhereClause += " and AR.Status='" + cmbStatus.SelectedValue + "' ";
                else
                    WhereClause = string.Empty;
            }

            MainQuery = "select " +
                         "AR.AttendanceRecordId," +
                         "AR.AttendanceRecordMasterId," +
                         "AR.AttendanceHistoryId," +
                         "AR.EsslAttendanceLogsId," +
                         "AR.EmployeeId," +
                         "E.EmployeeName," +
                         "E.EmployeeCode," +
                         "AR.ShiftId," +
                         "S.ShiftSName," +
                         "AR.ShiftGroupId," +
                         "AR.InTime," +
                         "AR.OutTime," +
                         "AR.Duration," +
                         "AR.OverTime," +
                         "AR.TotalDuration," +
                         "AR.Status," +
                         "AR.LateBy," +
                         "AR.EarlyBy," +
                         "AR.MissedInPunch," +
                         "AR.MissedOutPunch," +
                         "AR.ChangeDepartmentFlag," +
                         "AR.ChangeDepartmentId," +
                         "AR.ChangeLocationtId," +
                         "AR.LeaveTypeId," +
                         "AR.LeaveDuration," +
                         "AR.WeeklyOff," +
                         "AR.Holiday," +
                         "AR.LeaveRemarks," +
                         "AR.PunchRecords," +
                         "AR.LossOfHours," +
                         "AR.Present," +
                         "AR.Absent," +
                         "AR.Remarks," +
                         "S.ShiftDuration," +
                         "S.ShiftDurationHours," +
                         "S.BeginTime," +
                         "S.EndTime," +
                         "AR.EditFlag," +
                         "E.CategoryId," +
                         "E.ContractorId" +
                         " from AttendanceRecord AR inner join " +
                         " Employees E on E.EmployeeId=AR.EmployeeId inner join " +
                         " shifts S on S.ShiftId=AR.ShiftId " +
                         " where " +
                         " AR.AttendanceRecordMasterId=" + objPC.AttendanceRecordMasterId + " and " +
                         " AR.CancelTag=0 and" +
                         " E.CancelTag=0 and " +
                         " S.CancelTag=0 ";
            //+ " order by E.EmployeeCode asc";

            objBL.Query = MainQuery + WhereClause + " order by E.EmployeeCode asc";
            ds = objBL.ReturnDataTable();

            if (ds.Rows.Count > 0)
            {

            }
        }

        //private void SetApprovalStatusColor()
        //{
        //    if (!string.IsNullOrEmpty(objPC.ApprovalStatus))
        //    {
        //        if (objPC.ApprovalStatus == BusinessResources.LS_Pending)
        //            lblData.BackColor = Color.Yellow;
        //        else if (objPC.ApprovalStatus == BusinessResources.LS_Completed)
        //            lblData.BackColor = Color.Lime;
        //        else if (objPC.ApprovalStatus == BusinessResources.LS_Remarks)
        //            lblData.BackColor = Color.Aqua;
        //        else if (objPC.ApprovalStatus == BusinessResources.LS_Reject)
        //            lblData.BackColor = Color.Red;
        //        else
        //            lblData.BackColor = Color.White;
        //    }
        //}


        private void SetStatusColor()
        {
            objRL.SetStatusColor(cmbAttendanceStatus, lblData);

            //if (cmbAttendanceStatus.SelectedIndex > -1)
            //{
            //    string AStatus = cmbAttendanceStatus.Text;

            //    if (AStatus == BusinessResources.LS_Pending)
            //        lblData.BackColor = Color.FromName(BusinessResources.LS_Manager_Color);
            //    else if (AStatus == BusinessResources.LS_ManagerApproved)
            //    {
            //        lblData.BackColor = Color.Lime;
            //    }
            //    else if (AStatus == BusinessResources.LS_HRApproved)
            //    {
            //        lblData.BackColor = Color.Cyan;
            //    }
            //    else if (AStatus == BusinessResources.LS_Remarks)
            //    {
            //        lblData.BackColor = Color.Violet;
            //    }
            //    else if (AStatus == BusinessResources.LS_Reject)
            //    {
            //        lblData.BackColor = Color.Tomato;
            //    }
            //    else
            //    {
            //        //string hex = BusinessResources.BACKGROUND_COLOUR;
            //        //Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
            //        //Myrow.DefaultCellStyle.BackColor = _color;
            //    }
            //}

            //if (!string.IsNullOrEmpty(objPC.AttendanceStatus))
            //{
            //    if (objPC.ApprovalStatus == BusinessResources.STATUS_DEPARTMENT_HEAD_APPROVED)
            //        lblData.BackColor = Color.Yellow;
            //    else if (objPC.ApprovalStatus == BusinessResources.STATUS_FINAL_APPROVED)
            //        lblData.BackColor = Color.Lime;
            //    else if (objPC.ApprovalStatus == BusinessResources.STATUS_HR_APPROVED)
            //        lblData.BackColor = Color.Aqua;
            //    else
            //        lblData.BackColor = Color.White;
            //}
        }

        int SrNo = 1, ChangeDepartmentId = 0;

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private bool Validation()
        {
            objEP.Clear();

            //if (cmbApproval.SelectedIndex == -1)
            //{
            //    objEP.SetError(cmbApproval, "Select Status");
            //    return true;
            //}
            //else 
            if (cmbAttendanceStatus.SelectedIndex == -1)
            {
                cmbAttendanceStatus.Focus();
                objEP.SetError(cmbAttendanceStatus, "Select Attendance Status");
                return true;
            }
            else if (objPC.HRId == 0)
            {
                lblData.Focus();
                objEP.SetError(lblData, "HR ID is missing");
                return true;
            }
            else if (objPC.InchargeId == 0)
            {
                lblData.Focus();
                objEP.SetError(lblData, "Incharge ID is missing");
                return true;
            }
            else if (objPC.PlantHeadId == 0)
            {
                lblData.Focus();
                objEP.SetError(lblData, "PlantHead ID is missing");
                return true;
            }
            else
                return false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            objRL.Get_Incharge_Senior_OfficerId();
            if (!Validation())
                SaveDB();
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }
        private bool CheckExist_Record()
        {
            DataSet ds = new DataSet();
            //ApprovedFlag
            objPC.AttendanceDate = dtpDate.Value;
            //ds= objQL.SP_AttendanceRecord_CheckExist();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (!string.IsNullOrWhiteSpace(Convert.ToString(ds.Tables[0].Rows[0][0].ToString())))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }


        string OTByChange = string.Empty;


        //Holiday 
        //Holiday  Â½Present 
        //WeeklyOff Absent 
        //Present  On OD
        //Present 
        //Absent
        //Absent On OD
        // Â½Present 
        //WeeklyOff Present 
        //WeeklyOff 
        //Holiday Present 
        //WeeklyOff  Â½Present 
        //Holiday Absent 

        string DepartmentChange = string.Empty;

        string InTime_I = string.Empty, OutTime_I = string.Empty;

        private void SaveDB()
        {
            if (objPC.AttendanceRecordMasterId != 0 && dataGridView1.Rows.Count > 0)
            {
                TotalMP = 0; TotalA = 0; TotalWO = 0; TotalWOP = 0; TotalH = 0; TotalP = 0; TotalHD = 0; TotalHP = 0; TotalL = 0; TotalCO = 0; TotalCOU = 0;

                if (cmbAttendanceStatus.Text == BusinessResources.LS_Completed)
                    objPC.CompleteFlag = 1;

                objPC.AttendanceRecordMasterId = objPC.AttendanceRecordMasterId;  //Convert.ToInt32(objCmd.ExecuteScalar());
                objPC.AttendanceHistoryId = objPC.AttendanceHistoryId;
                objPC.EntryDate = DateTime.Now.Date;

                objPC.ApprovalStatusId = Convert.ToInt32(cmbAttendanceStatus.SelectedValue);
                //objPC.LocationId = objPC.LocationId;
                //objPC.DepartmentId = objPC.DepartmentId;


                //if (BusinessLayer.UserType == BusinessResources.USER_TYPE_INCHARGE)
                //    objPC.InchargeId = BusinessLayer.EmployeeLoginId_Static;
                //else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER || BusinessLayer.UserType == BusinessResources.USER_TYPE_PLANTHEAD)
                //    objPC.InchargeId = BusinessLayer.EmployeeLoginId_Static;
                //else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMIN)
                //    objPC.HRId = BusinessLayer.EmployeeLoginId_Static;
                //else
                //{
                //    objPC.HRId = 0;
                //    objPC.InchargeId = 0;
                //}

                if (cmbAttendanceStatus.SelectedIndex > -1)
                {
                    if (cmbAttendanceStatus.Text == BusinessResources.LS_Completed)
                        objPC.EditFlag = 1;
                    else
                        objPC.EditFlag = 0;
                }

                objBL.Query = "update attendancerecordmaster set HRId=" + objPC.HRId + ",InchargeId=" + objPC.InchargeId + ",ApprovalStatusId=" + objPC.ApprovalStatusId + ",CompleteFlag=" + objPC.CompleteFlag + " where AttendanceRecordMasterId=" + objPC.AttendanceRecordMasterId + "";
                Result = objBL.Function_ExecuteNonQuery();

                //Result=  objQL.SP_AttendanceRecordMaster_CheckExist_Insert();

                if (Result > 0)
                {
                    objRL.ShowMessage(7, 1);
                }

                //for (int i = 0; i < dataGridView1.Rows.Count; i++)
                //{
                //    //AttendanceRecordMasterId,
                //    //AttendanceId, 
                //    //EmployeeId, 
                //    //ShiftId, 
                //    //InTime, 
                //    //OutTime, 
                //    //Duration, 
                //    //OverTime, 
                //    //TotalDuration, 
                //    //OTByChange, 
                //    //Status, 
                //    //WorkingTransfer, 
                //    //InchargeRemark, 
                //    //LeaveApplication, 
                //    //LateComming, 
                //    //Remarks, 
                //    //LateBy, 
                //    //EarlyBy,
                //    //UserId

                //    objPC.TotalDuration = "00:00";
                //    objPC.WorkingTransfer = "NA";
                //    objPC.Remarks = "NA";
                //    objPC.LateBy = 0;
                //    objPC.EarlyBy = 0;
                //    objPC.MissedInPunch = 0;
                //    objPC.MissedOutPunch = 0;

                //    //objPC.EmployeeId = Convert.ToInt32(dataGridView1.Rows[i].Cells["clmEmployeeId"].Value.ToString());
                //    objPC.AttendanceRecordId = Convert.ToInt32(dataGridView1.Rows[i].Cells["clmAttendanceRecordId"].Value.ToString());
                //    objPC.AttendanceRecordMasterId = Convert.ToInt32(dataGridView1.Rows[i].Cells["clmAttendanceRecordMasterId"].Value.ToString());
                //    objPC.ShiftId = Convert.ToInt32(dataGridView1.Rows[i].Cells["clmShiftId"].Value.ToString());
                //    objPC.InTime = Convert.ToDateTime(dataGridView1.Rows[i].Cells["clmInTime"].Value.ToString());
                //    objPC.OutTime = Convert.ToDateTime(dataGridView1.Rows[i].Cells["clmOutTime"].Value.ToString());
                //    objPC.Duration = Convert.ToString(dataGridView1.Rows[i].Cells["clmDuration"].Value);
                //    objPC.OverTime = Convert.ToString(dataGridView1.Rows[i].Cells["clmOverTime"].Value);
                //    objPC.Status = Convert.ToString(dataGridView1.Rows[i].Cells["clmStatus"].Value.ToString());

                //    CurrentStatusGrid = Convert.ToString(dataGridView1.Rows[i].Cells["clmStatus"].Value);

                //    if (CurrentStatusGrid == "A" || CurrentStatusGrid == "WO" || CurrentStatusGrid == "H" || CurrentStatusGrid == "HA" || CurrentStatusGrid == "WOA")
                //    {
                //        objPC.ShiftId = 3;
                //        objRL.Get_Shift_Details(objPC.ShiftId);

                //        objPC.TotalDuration = "00:00";
                //        objPC.WorkingTransfer = "NA";

                //        objPC.Remarks = "NA";
                //        objPC.LateBy = 0;
                //        objPC.EarlyBy = 0;
                //        objPC.MissedInPunch = 0;
                //        objPC.MissedOutPunch = 0; 

                //        //dataGridView1.Rows[e.RowIndex].Cells["clmOutTime"].Value = "00:00";
                //        //dataGridView1.Rows[e.RowIndex].Cells["clmDuration"].Value = "00:00";
                //        //dataGridView1.Rows[e.RowIndex].Cells["clmOverTime"].Value = "00:00";
                //        //dataGridView1.Rows[e.RowIndex].Cells["clmTotalDuration"].Value = "00:00";

                //        //Same part of the work when employee Absent
                //    }
                //    else
                //    {
                //        objPC.TotalDuration = dataGridView1.Rows[i].Cells["clmTotalDuration"].Value.ToString();

                //        //if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[i].Cells["clmDepartmentChange"].Value)))
                //        //    objPC.WorkingTransfer = Convert.ToString(dataGridView1.Rows[i].Cells["clmDepartmentChange"].Value);
                //        //else

                //        objPC.WorkingTransfer = "NA";

                //        //objPC.InchargeRemark = Convert.ToString(dataGridView1.Rows[i].Cells["clmInchargeRemark"].Value);
                //        //objPC.LeaveApplication = Convert.ToString(dataGridView1.Rows[i].Cells["clmLeaveApplication"].Value);
                //        //objPC.LateComming = Convert.ToString(dataGridView1.Rows[i].Cells["clmLateComming"].Value);

                //        objPC.Remarks = Convert.ToString(dataGridView1.Rows[i].Cells["clmRemarksGrid"].Value);
                //        objPC.LateBy = Convert.ToDouble(dataGridView1.Rows[i].Cells["clmLateBy"].Value);
                //        objPC.EarlyBy = Convert.ToDouble(dataGridView1.Rows[i].Cells["clmEarlyBy"].Value);
                //        objPC.MissedInPunch = Convert.ToInt32(dataGridView1.Rows[i].Cells["clmMissedInPunch"].Value);
                //        objPC.MissedOutPunch = Convert.ToInt32(dataGridView1.Rows[i].Cells["clmMissedOutPunch"].Value);

                //        DepartmentChange = Convert.ToString(dataGridView1.Rows[i].Cells["clmDepartmentChange"].Value);

                //        //objRL.Fill_Department_ComboBox_By_Location
                //        //objPC.ChangeDepartmentId = Convert.ToInt32(dataGridView1.Rows[i].Cells["clmChangeDepartmentId"].Value);
                //        objRL.DepartmentId_Dept = 0; objRL.DepartmentName_Depat = "";

                //        if (DepartmentChange != "NA" && DepartmentChange != "")
                //        {
                //            objRL.Get_Department_ID_Name(DepartmentChange, "DepartmentName");
                //            objPC.ChangeDepartmentId = objRL.DepartmentId_Dept;
                //        }
                //        else
                //            objPC.ChangeDepartmentId = 0;
                //    }

                //    Result = objQL.SP_AttendanceRecord_Insert_Update_Delete();

                //    if (Result > 0)
                //    {
                //        DateTime AttDate = objPC.AttendanceDate;

                //        int MonS = AttDate.Month;
                //        int DayS = AttDate.Day;
                //        int yearS = AttDate.Year;

                //        string In1 = string.Empty, Out1 = string.Empty, Duration1 = string.Empty, Status1 = string.Empty, OT1 = string.Empty, LT1 = string.Empty, AtId = string.Empty, ShiftId = string.Empty;

                //        InTime_I = string.Empty; OutTime_I = string.Empty;

                //        In1 = "In" + DayS.ToString();
                //        Out1 = "Out" + DayS.ToString();
                //        Duration1 = "Duration" + DayS.ToString();
                //        Status1 = "Status" + DayS.ToString();
                //        OT1 = "OT" + DayS.ToString();
                //        LT1 = "LT" + DayS.ToString();

                //        AtId = "AtId" + DayS.ToString();
                //        ShiftId = "ShiftId" + DayS.ToString();

                //        int R = 0;

                //        int EID = Convert.ToInt32(Convert.ToDouble(dataGridView1.Rows[i].Cells["clmEmployeeId"].Value));
                //        objPC.AMonth = MonS;
                //        objPC.AYear = yearS;
                //        objPC.EmployeeId = EID; // objPC.EmployeeId;

                //        InTime_I = objPC.InTime.ToString("HH:mm");
                //        OutTime_I = objPC.OutTime.ToString("HH:mm");

                //        //Id bigint AI PK 
                //        //AttendanceIdD1 bigint 
                //        //AttendanceIdD2 int 
                //        //AttendanceIdD3 int

                //        //objBL.Query = "insert into attendancetest(" + In1 + ") values(" + objPC.AttendanceRecordId + ")";
                //        //R = objBL.Function_ExecuteNonQuery();

                //        //½P	0.5
                //        //A	    0
                //        //A(OD)	0
                //        //H	    1   
                //        //H½P	0.5
                //        //HA	0
                //        //HP	1
                //        //P	    1
                //        //P(OD)	1
                //        //WO	1
                //        //WO½P	0.5
                //        //WOA	0
                //        //WOP	1

                //        TotalPresent = 0; TotalAbsent = 0; TotalOT = 0; TotalHours = 0; TotalWeeklyOff = 0; TotalHoliday = 0; TotalLateBy = 0; TotalEarlyBy = 0;

                //        string TotalColumnName = string.Empty;

                //        if (objPC.Status == "½P")
                //            TotalPresent = 0.5;
                //        else if (objPC.Status == "A")
                //            TotalAbsent = 1;
                //        else if (objPC.Status == "A(OD)")
                //            TotalAbsent = 1;
                //        else if (objPC.Status == "H")
                //            TotalHoliday = 1;
                //        else if (objPC.Status == "H½P")
                //            TotalPresent = 0.5;
                //        else if (objPC.Status == "HA")
                //            TotalAbsent = 1;
                //        else if (objPC.Status == "HP")
                //            TotalPresent = 1;
                //        else if (objPC.Status == "P")
                //            TotalPresent = 1;
                //        else if (objPC.Status == "P(OD)")
                //            TotalPresent = 1;
                //        else if (objPC.Status == "WO")
                //            TotalWeeklyOff = 1;
                //        else if (objPC.Status == "WO½P")
                //            TotalPresent = 0.5;
                //        else if (objPC.Status == "WOP")
                //            TotalPresent = 1;
                //        else
                //        {

                //        }

                //        //TimeSpan DurationTotalInHours1 = TimeSpan.Parse("01:00");
                //        //TimeSpan DurationTotalInHours2 = TimeSpan.Parse("02:22");
                //        //TimeSpan DurationTotalInHours3 = TimeSpan.Parse("03:50");
                //        //TimeSpan DurationTotalInHours4 = TimeSpan.Parse("10:00");

                //        //TimeSpan DurationTotalInHours = DurationTotalInHours1 + DurationTotalInHours2 + DurationTotalInHours3+DurationTotalInHours4;


                //        //01:00
                //        //02:22
                //        //03:50
                //        //10:00


                //        TimeSpan DurationTotalInHours = TimeSpan.Parse(objPC.TotalDuration.ToString());


                //        //var totalSpan = new TimeSpan(objPC.OverTime_Hours.ToString());

                //        //TotalOT = 0;

                //        //objBL.Query = "insert into test(TotalHours) values(,AMonth,EmpId," + In1 + "," + Out1 + "," + Duration1 + "," + Status1 + "," + OT1 + "," + LT1 + "," + AtId + "," + ShiftId + ",TotalPresent,TotalAbsent,TotalOT,TotalHours,TotalWeeklyOff,TotalHoliday,TotalLateBy,TotalEarlyBy) values(" + yearS + "," + MonS + "," + objPC.EmployeeId + ",'" + InTime_I + "','" + OutTime_I + "','" + objPC.TotalDuration + "','" + objPC.Status + "','" + objPC.OverTime_Hours + "','" + objPC.LateBy + "'," + objPC.AttendanceRecordId + "," + objPC.ShiftId + "," + TotalPresent + "," + TotalAbsent + "," + TotalOT + "," + TotalHours + "," + TotalWeeklyOff + "," + TotalHoliday + "," + TotalLateBy + "," + TotalEarlyBy + ")";
                //        //R = objBL.Function_ExecuteNonQuery();

                //        // var totalSpan = new TimeSpan(myCollection.Sum(r => r.TheDuration.Ticks));

                //        //    0
                //        //A(OD)	0
                //        //H	    1   
                //        //H½P	0.5
                //        //HA	0
                //        //HP	1
                //        //P	    1
                //        //P(OD)	1
                //        //WO	1
                //        //WO½P	0.5
                //        //WOA	0
                //        //WOP   1

                //        //OTTimes = OTTimes + OTTimes;
                //        //Check Exist

                //        if (objQL.SP_AttendanceMonthlyData_CheckExist())
                //        {
                //            //TotalHours='" + TotalDuration + "',
                //            //string OTH = Convert.ToString(objQL.OTHours);
                //            //                        string TotalDuration = Convert.ToString(objQL.TotalDurationHours);

                //            //objBL.Query = "update attendancemonthlydata set " + In1 + "='" + InTime_I + "'," + Out1 + "='" + OutTime_I + "'," + Duration1 + "='" + objPC.TotalDuration + "'," + Status1 + "='" + objPC.Status + "'," + OT1 + "='" + objPC.OverTime_Hours + "'," + LT1 + "='" + objPC.LateBy + "'," + AtId + "=" + objPC.AttendanceRecordId + "," + ShiftId + "=" + objPC.ShiftId + ",TotalPresent=TotalPresent+" + TotalPresent + ",TotalAbsent=TotalAbsent+" + TotalAbsent + ",TotalOT='" + OTH + "',TotalWeeklyOff=TotalWeeklyOff+" + TotalWeeklyOff + ",TotalHoliday=TotalHoliday+" + TotalHoliday + ",TotalLateBy=TotalLateBy+" + TotalLateBy + ",TotalEarlyBy=TotalEarlyBy+" + TotalEarlyBy + " where AYear=" + objPC.AYear + " and AMonth=" + objPC.AMonth + " and EmployeeId=" + EID + "";

                //            objBL.Query = "update attendancemonthlydata set LocationId=" + objPC.LocationId + ",DepartmentId=" + objPC.DepartmentId + "," + In1 + "='" + InTime_I + "'," + Out1 + "='" + OutTime_I + "'," + Duration1 + "='" + objPC.TotalDuration + "'," + Status1 + "='" + objPC.Status + "'," + OT1 + "='" + objPC.OverTime + "'," + LT1 + "='" + objPC.LateBy + "'," + AtId + "=" + objPC.AttendanceRecordId + "," + ShiftId + "=" + objPC.ShiftId + " where AYear=" + objPC.AYear + " and AMonth=" + objPC.AMonth + " and EmployeeId=" + EID + "";
                //            R = objBL.Function_ExecuteNonQuery();
                //        }
                //        else
                //        {
                //            // int Monthdays = DateTime.DaysInMonth(objPC.AYear,objPC.AMonth);

                //            objBL.Query = "insert into attendancemonthlydata(AYear,AMonth,LocationId,DepartmentId,EmployeeId," + In1 + "," + Out1 + "," + Duration1 + "," + Status1 + "," + OT1 + "," + LT1 + "," + AtId + "," + ShiftId + ",AttendanceHistoryId) values(" + yearS + "," + MonS + "," + objPC.LocationId + "," + objPC.DepartmentId + "," + objPC.EmployeeId + ",'" + InTime_I + "','" + OutTime_I + "','" + objPC.TotalDuration + "','" + objPC.Status + "','" + objPC.OverTime + "','" + objPC.LateBy + "'," + objPC.AttendanceRecordId + "," + objPC.ShiftId + "," + objPC.AttendanceHistoryId + ")";
                //            R = objBL.Function_ExecuteNonQuery();
                //        }

                //        objQL.SP_AttendanceMonthlyData_Total_Update_All_Records();
                //    }

                //    //Total Present Days Calculations

                //    // int ResultHours = objQL.SP_AttendanceMonthlyData_TotalHours();
                //    //Present
                //    //int RI = objQL.SP_AttendanceMonthlyData_Update_All();
                //    //
                //}

                //ApproveFlag = true;

                ////Update Approve Flag Level
                ////1 Approve by Incharge
                ////2 Apprave by Plant Head
                ////3 Approve by HR Department

                ////if (ApproveFlag)
                ////{
                ////    BusinessLayer.UserType = BusinessResources.USER_TYPE_INCHARGE;

                ////    if (BusinessLayer.UserType == BusinessResources.USER_TYPE_INCHARGE)
                ////    {
                ////        objPC.ApprovedFlag = 1;
                ////    }
                ////    else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_PLANTHEAD)
                ////    {
                ////        objPC.ApprovedFlag = 2;
                ////    }
                ////    else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMIN)
                ////    {
                ////        objPC.ApprovedFlag = 3;
                ////    }
                ////    else
                ////        objPC.ApprovedFlag = 0;
                ////}

                //ApproveFlag = true;
                //Save_Attendance_Approval_Status();
                //Fill_Grid_AttendanceRecord();

            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }

        private void Save_Attendance_Approval_Status()
        {
            // objPC.ApprovalStatus = cmbApproval.Text;
            objPC.AttendanceStatus = cmbAttendanceStatus.Text;
            Result = objQL.SP_AttendanceRecordMaster_Update_ApprovalFlag();
        }

        // double TotalPresent = 0, TotalAbsent = 0, TotalOT = 0, TotalHours = 0, TotalWeeklyOff = 0, TotalHoliday = 0, TotalLateBy = 0, TotalEarlyBy = 0;

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //double EarlyBy_Check = 0, LateBy_Check = 0;
            //DataGridView dgv = sender as DataGridView;

            //if (dgv.Columns[e.ColumnIndex].Name.Equals("clmLateBy"))
            //{
            //    if (!string.IsNullOrEmpty(Convert.ToString(e.Value)))
            //    {
            //        LateBy_Check = Convert.ToDouble(e.Value);

            //        if (LateBy_Check > 0)
            //        {
            //            dgv.Rows[e.RowIndex].Cells["clmInTime"].Style.BackColor = Color.Yellow;
            //            dgv.Rows[e.RowIndex].Cells["clmLateBy"].Style.BackColor = Color.Yellow;
            //        }
            //        else
            //        {
            //            dgv.Rows[e.RowIndex].Cells["clmInTime"].Style.BackColor = Color.White;
            //            dgv.Rows[e.RowIndex].Cells["clmLateBy"].Style.BackColor = Color.White;
            //        }
            //    }
            //}

            //if (dgv.Columns[e.ColumnIndex].Name.Equals("clmEarlyBy"))
            //{
            //    if (!string.IsNullOrEmpty(Convert.ToString(e.Value)))
            //    {
            //        EarlyBy_Check = Convert.ToDouble(e.Value);

            //        if (EarlyBy_Check > 0)
            //        {
            //            dgv.Rows[e.RowIndex].Cells["clmOutTime"].Style.BackColor = Color.Yellow;
            //            dgv.Rows[e.RowIndex].Cells["clmEarlyBy"].Style.BackColor = Color.Yellow;
            //        }
            //        else
            //        {
            //            dgv.Rows[e.RowIndex].Cells["clmOutTime"].Style.BackColor = Color.White;
            //            dgv.Rows[e.RowIndex].Cells["clmEarlyBy"].Style.BackColor = Color.White;
            //        }
            //    }
            //}

            //if (e.Value != null && e.Value.ToString().Trim() == "Male")
            //{
            //    dgv.Rows[e.RowIndex].Cells["name"].Style.BackColor = Color.White;
            //}
            //else
            //{
            //    dgv.Rows[e.RowIndex].Cells["name"].Style.BackColor = Color.DarkGray;
            //}

            //if (e.ColumnIndex != color.Index)
            //    return;

            //if (e.ColumnIndex == 3 && e.Value == targetValue)
            //    e.CellStyle.BackColor = Color.Red;
            //else
            //    e.CellStyle.BackColor = SystemColors.Window;

            //e.CellStyle.BackColor = Color.FromArgb(int.Parse(((DataRowView)dataGridView1.Rows[e.RowIndex].DataBoundItem).Row[4].ToString()));
        }

        DateTime IN_Value, Out_Value;

        int ShiftId = 0; string CurrentStatusGrid = string.Empty;

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //Fill_Changed_Value_DataGridView(e);
        }




        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //objRL.FloatValue(sender, e);
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = true;
            //}

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ':')
            {
                e.Handled = true;
            }


            if ((e.KeyChar == ':') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf(':') > -1))
            {
                if ((sender as System.Windows.Forms.TextBox).Text != ":")
                {
                    e.Handled = true;
                }
            }
        }

        //private void cmbApproval_SelectionChangeCommitted(object sender, EventArgs e)
        //{
        //    if (cmbApproval.SelectedIndex > -1)
        //    {
        //        objPC.ApprovalStatus = cmbApproval.Text;
        //        SetApprovalStatusColor();
        //    }
        //}

        private void cmbAttendanceStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetStatusColor();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                RowCount_Grid = dataGridView1.Rows.Count;
                CurrentRowIndex = dataGridView1.CurrentRow.Index;

                if (RowCount_Grid >= 0 && CurrentRowIndex >= 0)
                {
                    // btnDelete.Visible = true;
                    objPC.LeaveTypeFlag = false;
                    if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["clmAttendanceRecordId"].Value)))
                    {
                        objPC.AttendanceRecordId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clmAttendanceRecordId"].Value);
                        objPC.EmployeeId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clmEmployeeId"].Value);
                        objPC.EmployeeCode = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clmEmployeeCode"].Value);

                        if (objPC.AttendanceRecordId != 0)
                        {
                            //EditRecordsView = string.Empty;
                            //EditRecordsView = "Employee Name: " + dataGridView1.Rows[e.RowIndex].Cells["clmEmployeeCode"].Value.ToString() + System.Environment.NewLine;
                            //EditRecordsView += "Employee Code: " + dataGridView1.Rows[e.RowIndex].Cells["clmInTime"].Value.ToString() + System.Environment.NewLine;
                            EditAttendanceRecord objForm = new EditAttendanceRecord();
                            objForm.ShowDialog(this);

                            //if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR || BusinessLayer.UserType == BusinessResources.USER_TYPE_HROFFICER || BusinessLayer.Department == "TIME OFFICE")
                            //{

                            //}
                            //else
                            //{
                            //    EditAttendanceNotes objForm = new EditAttendanceNotes();
                            //    objForm.ShowDialog(this);
                            //}

                            Fill_Grid_AttendanceRecord();
                        }
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
            // btnDelete.Visible = true;
        }

        string EditRecordsView = string.Empty;



        private void cbContractor_CheckedChanged(object sender, EventArgs e)
        {
            if (cbContractor.Checked)
            {
                cmbContractor.SelectedIndex = -1;
                cmbContractor.Enabled = false;
            }
            else
            {
                cmbContractor.SelectedIndex = -1;
                cmbContractor.Enabled = true;
                cmbContractor.Focus();
            }
        }

        private void cbStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStatus.Checked)
            {
                cmbStatus.SelectedIndex = -1;
                cmbStatus.Enabled = false;
            }
            else
            {
                cmbStatus.SelectedIndex = -1;
                cmbStatus.Enabled = true;
                cmbStatus.Focus();
            }
        }

        private bool ValidationSearch()
        {
            objEP.Clear();
            if (!cbContractor.Checked)
            {
                if (cmbContractor.SelectedIndex == -1)
                {
                    cmbContractor.Focus();
                    objEP.SetError(cmbContractor, "Select Contractor");
                    return true;
                }
                else
                    return false;
            }
            else if (!cbStatus.Checked)
            {
                if (cmbStatus.SelectedIndex == -1)
                {
                    cmbStatus.Focus();
                    objEP.SetError(cmbStatus, "Select Status");
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!Validation())
            {
                Fill_Grid_AttendanceRecord();
            }
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            cbContractor.Checked = true;
            cbStatus.Checked = true;
            cbMissedPunch.Checked = false;
            txtSearchEmpCode.Text = "";
            rtbContractorWiseCount.Text = "";
            rtbStatusCount.Text = "";
            Fill_Grid_AttendanceRecord();
        }

        int MissedInOutPunch = 0;
        private void cbMissedPunch_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMissedPunch.Checked)
                MissedInOutPunch = 1;
            else
                MissedInOutPunch = 0;
        }

        private void rtbStatusCount_TextChanged(object sender, EventArgs e)
        {

        }

        //public void BulkToMySQL()
        //{
        //    objBL.Connect();

        //    string ConnectionString = "server=192.168.1xxx";
        //    StringBuilder sCommand = new StringBuilder("INSERT INTO User (EntryDate, LastName) VALUES ");
        //    using (MySqlConnection mConnection = new MySqlConnection(ConnectionString))
        //    {
        //        List<string> Rows = new List<string>();
        //        for (int i = 0; i < 100000; i++)
        //        {
        //            Rows.Add(string.Format("('{0}','{1}')", MySqlHelper.EscapeString("test"), MySqlHelper.EscapeString("test")));
        //        }
        //        sCommand.Append(string.Join(",", Rows));
        //        sCommand.Append(";");
        //        mConnection.Open();
        //        using (MySqlCommand myCmd = new MySqlCommand(sCommand.ToString(), mConnection))
        //        {
        //            myCmd.CommandType = CommandType.Text;
        //            myCmd.ExecuteNonQuery();
        //        }
        //    }
        //}
    }
}
