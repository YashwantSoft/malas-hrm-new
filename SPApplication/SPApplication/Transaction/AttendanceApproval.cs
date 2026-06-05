using BusinessLayerUtility;
using BusinessLayerUtility.Classes;
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
    public partial class AttendanceApproval : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        MasterClass objMC = new MasterClass();
        AttendanceClass objAC = new AttendanceClass();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0,LocationId = 0;
        string EmpDesignation = string.Empty;
        string EmpDepartment = string.Empty;

        string MainQuery = string.Empty;
        string WhereClause = string.Empty;
        bool ApproveFlag = false;

        DateTime dtIn, dtOut;
        double Duration = 0, OverTime = 0, TotalDuration = 0, LateBy = 0, EarlyBy = 0;

        public AttendanceApproval()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_ATTENDANCEAPPROVAL);
            //btnSave.Text = BusinessResources.BTN_VIEW;
            btnDelete.Text = BusinessResources.BTN_APPROVE;
            ClearAll();
        }

        private void CurrentStatus()
        {
            cmbStatus.Items.Add(BusinessResources.STATUS_HR_APPROVED);
            cmbStatus.Items.Add(BusinessResources.STATUS_FINAL_APPROVED);
            cmbStatus.Items.Add(BusinessResources.STATUS_DEPARTMENT_HEAD_APPROVED);

            if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMIN)
            {
                cmbStatus.Text = BusinessResources.STATUS_HR_APPROVED;
            }
            else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_PLANTHEAD)
            {
                cmbStatus.Text = BusinessResources.STATUS_FINAL_APPROVED;
            }
            else
                cmbStatus.Text = BusinessResources.STATUS_DEPARTMENT_HEAD_APPROVED;

            cmbStatus.Enabled = false;
        }

        private void ClearAll()
        {
            lblData.Text = "";
            CurrentStatus();
        }

        private void AttendanceApproval_Load(object sender, EventArgs e)
        {
            Fill_Grid_AttendanceRecord();
        }
       
        private void Fill_Grid_AttendanceRecord()
        {
            if (objAC.AttendanceRecordMasterId != 0)
            {
                dataGridView1.Rows.Clear();
                lblData.Text = objAC.AttendanceData.ToString();
                DataTable ds = new DataTable();
                ds = objQL.SP_AttendanceRecord_FillGrid_By_AttendanceRecordMasterId();

                if (ds.Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Rows.Count; i++)
                    {
                        //AR.AttendanceRecordId,
                        //AR.AttendanceRecordMasterId,
                        //AR.AttendanceId, 
                        //AR.EmployeeId, 
                        //E.EmployeeName as 'Employee Name',
                        //AR.ShiftId, 
                        //AR.InTime, 
                        //AR.OutTime, 
                        //AR.Duration, 
                        //AR.OverTime, 
                        //AR.TotalDuration, 
                        //AR.OTByChange, 
                        //AR.Status, 
                        //AR.WorkingTransfer, 
                        //AR.InchargeRemark, 
                        //AR.LeaveApplication, 
                        //AR.LateComming, 
                        //AR.Remarks, 
                        //AR.LateBy, 
                        //AR.EarlyBy,
                        //AR.UserId

                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells["clmSrNo"].Value = SrNo.ToString();
                        dataGridView1.Rows[i].Cells["clmAttendanceRecordId"].Value = ds.Rows[i]["AttendanceRecordId"].ToString();
                        dataGridView1.Rows[i].Cells["clmAttendanceRecordMasterId"].Value = ds.Rows[i]["AttendanceRecordMasterId"].ToString();
                        dataGridView1.Rows[i].Cells["clmAttendanceId"].Value = ds.Rows[i]["AttendanceId"].ToString();
                        dataGridView1.Rows[i].Cells["clmEmployeeId"].Value = ds.Rows[i]["EmployeeId"].ToString();
                        dataGridView1.Rows[i].Cells["clmEmployeeName"].Value = ds.Rows[i]["EmployeeName"].ToString();
                        dataGridView1.Rows[i].Cells["clmEmployeeCode"].Value = ds.Rows[i]["EmployeeCode"].ToString();
                        dataGridView1.Rows[i].Cells["clmShiftId"].Value = ds.Rows[i]["ShiftId"].ToString();
                        dataGridView1.Rows[i].Cells["clmShift"].Value = ds.Rows[i]["ShiftSName"].ToString();
                        dtIn=Convert.ToDateTime(ds.Rows[i]["InTime"].ToString());
                        dtOut = Convert.ToDateTime(ds.Rows[i]["OutTime"].ToString());
                        dataGridView1.Rows[i].Cells["clmInTime"].Value = dtIn.ToString("hh:mm tt");
                        dataGridView1.Rows[i].Cells["clmOutTime"].Value = dtOut.ToString("hh:mm tt");

                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[i]["Duration"].ToString())))
                            Duration = Math.Round(Convert.ToDouble(ds.Rows[i]["Duration"].ToString()), 2);
                        else
                            Duration = 0;

                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[i]["OverTime"].ToString())))
                            OverTime = Math.Round(Convert.ToDouble(ds.Rows[i]["OverTime"].ToString()), 2);
                        else
                            OverTime = 0;

                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[i]["TotalDuration"].ToString())))
                            TotalDuration = Math.Round(Convert.ToDouble(ds.Rows[i]["TotalDuration"].ToString()), 2);
                        else
                            TotalDuration = 0;

                       // if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[i]["TotalDuration"].ToString())))
                        dataGridView1.Rows[i].Cells["clmDuration"].Value = Duration.ToString();
                        dataGridView1.Rows[i].Cells["clmOverTime"].Value = OverTime.ToString();
                        dataGridView1.Rows[i].Cells["clmTotalDuration"].Value = TotalDuration.ToString();
                        dataGridView1.Rows[i].Cells["clmOTByChange"].Value = ds.Rows[i]["OTByChange"].ToString();
                        dataGridView1.Rows[i].Cells["clmStatus"].Value = ds.Rows[i]["Status"].ToString();
                        dataGridView1.Rows[i].Cells["clmWorkingTransfer"].Value = ds.Rows[i]["WorkingTransfer"].ToString();
                        dataGridView1.Rows[i].Cells["clmInchargeRemark"].Value = ds.Rows[i]["InchargeRemark"].ToString();
                        dataGridView1.Rows[i].Cells["clmLeaveApplication"].Value = ds.Rows[i]["LeaveApplication"].ToString();
                        dataGridView1.Rows[i].Cells["clmLateComming"].Value = ds.Rows[i]["LateComming"].ToString();
                        dataGridView1.Rows[i].Cells["clmRemarks"].Value = ds.Rows[i]["Remarks"].ToString();

                        //LateBy = Convert.ToDouble(Math.Round(Convert.ToDouble(ds.Rows[i]["LateBy"].ToString()),2)/60);
                        //EarlyBy = Convert.ToDouble(Math.Round(Convert.ToDouble(ds.Rows[i]["EarlyBy"].ToString()),2)/60);

                        LateBy = Convert.ToDouble(ds.Rows[i]["LateBy"].ToString());
                        EarlyBy = Convert.ToDouble(ds.Rows[i]["EarlyBy"].ToString());

                        dataGridView1.Rows[i].Cells["clmLateBy"].Value = Math.Round(LateBy,2).ToString();
                        dataGridView1.Rows[i].Cells["clmEarlyBy"].Value = Math.Round(EarlyBy,2).ToString();
                        SrNo++;
                    }

                    if (!string.IsNullOrEmpty(objMC.ApprovalStatus))
                    {
                        if (objMC.ApprovalStatus == BusinessResources.STATUS_DEPARTMENT_HEAD_APPROVED)
                            lblData.BackColor = Color.Yellow;
                        else if (objMC.ApprovalStatus == BusinessResources.STATUS_FINAL_APPROVED)
                            lblData.BackColor = Color.Lime;
                        else if (objMC.ApprovalStatus == BusinessResources.STATUS_HR_APPROVED)
                            lblData.BackColor = Color.Aqua;
                        else
                            lblData.BackColor = Color.White;
                    }

                    //foreach (DataGridViewRow Myrow in dataGridView1.Rows)
                    //{
                    //    //Here 2 cell is target value and 1 cell is Volume

                    //    if (!string.IsNullOrEmpty(Convert.ToString(Myrow.Cells["clmLateBy"].Value)))
                    //    {
                    //        if (Convert.ToDouble(Myrow.Cells["clmLateBy"].Value) > 0)// Convert.ToInt32(Myrow.Cells[1].Value))// Or your condition 
                    //        {
                    //            Myrow.DefaultCellStyle.BackColor = Color.Yellow;
                    //        }
                    //    }
                    //}
                }
            }
        }

        int SrNo = 1;

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveDB();
        }

        private bool CheckExist_Record()
        {
            DataSet ds = new DataSet();
            //ApprovedFlag
            objMC.AttendanceDate = dtpDate.Value;
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

        private void SaveDB()
        {
            if (objAC.AttendanceRecordMasterId != 0 && dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    //AttendanceRecordMasterId,
                    //AttendanceId, 
                    //EmployeeId, 
                    //ShiftId, 
                    //InTime, 
                    //OutTime, 
                    //Duration, 
                    //OverTime, 
                    //TotalDuration, 
                    //OTByChange, 
                    //Status, 
                    //WorkingTransfer, 
                    //InchargeRemark, 
                    //LeaveApplication, 
                    //LateComming, 
                    //Remarks, 
                    //LateBy, 
                    //EarlyBy,
                    //UserId

                    objAC.AttendanceRecordId = Convert.ToInt32(dataGridView1.Rows[i].Cells["clmAttendanceRecordId"].Value.ToString());
                    objAC.AttendanceRecordMasterId = Convert.ToInt32(dataGridView1.Rows[i].Cells["clmAttendanceRecordMasterId"].Value.ToString());
                    objAC.ShiftId = Convert.ToInt32(dataGridView1.Rows[i].Cells["clmShiftId"].Value.ToString());
                    objAC.InTime = Convert.ToDateTime(dataGridView1.Rows[i].Cells["clmInTime"].Value.ToString());
                    objAC.OutTime = Convert.ToDateTime(dataGridView1.Rows[i].Cells["clmOutTime"].Value.ToString());
                    objAC.Duration = Convert.ToDouble(dataGridView1.Rows[i].Cells["clmDuration"].Value.ToString());
                    objAC.OverTime = Convert.ToDouble(dataGridView1.Rows[i].Cells["clmOverTime"].Value.ToString());
                    objAC.TotalDuration = Convert.ToDouble(dataGridView1.Rows[i].Cells["clmTotalDuration"].Value.ToString());
                    objAC.OTByChange = Convert.ToDouble(dataGridView1.Rows[i].Cells["clmOTByChange"].Value.ToString());
                    objAC.Status = Convert.ToString(dataGridView1.Rows[i].Cells["clmStatus"].Value.ToString());
                    objAC.WorkingTransfer = Convert.ToString(dataGridView1.Rows[i].Cells["clmWorkingTransfer"].Value.ToString());
                    objAC.InchargeRemark = Convert.ToString(dataGridView1.Rows[i].Cells["clmInchargeRemark"].Value.ToString());
                    objAC.LeaveApplication = Convert.ToString(dataGridView1.Rows[i].Cells["clmLeaveApplication"].Value.ToString());
                    objAC.LateComming = Convert.ToString(dataGridView1.Rows[i].Cells["clmLateComming"].Value.ToString());
                    objAC.Remarks = Convert.ToString(dataGridView1.Rows[i].Cells["clmRemarks"].Value.ToString());
                    objAC.LateBy = Convert.ToDouble(dataGridView1.Rows[i].Cells["clmLateBy"].Value.ToString());
                    objAC.EarlyBy = Convert.ToDouble(dataGridView1.Rows[i].Cells["clmEarlyBy"].Value.ToString());
                    Result = objQL.SP_AttendanceRecord_Insert_Update_Delete();
                }

                ApproveFlag = true;

                if (ApproveFlag)
                {
                    BusinessLayer.UserType = BusinessResources.USER_TYPE_INCHARGE;

                    if (BusinessLayer.UserType == BusinessResources.USER_TYPE_INCHARGE)
                    {
                        objMC.ApprovedFlag = 1;
                    }
                    else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_PLANTHEAD)
                    {
                        objMC.ApprovedFlag = 2;
                    }
                    else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMIN)
                    {
                        objMC.ApprovedFlag = 3;
                    }
                    else
                        objMC.ApprovedFlag = 0;
                }

                objMC.ApprovalStatus = cmbStatus.Text;
                Result = objQL.SP_AttendanceRecordMaster_Update_ApprovalFlag();
                Fill_Grid_AttendanceRecord();
                objRL.ShowMessage(7, 1);
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }

        //Update Approve Flag Level
        //1 Approve by Incharge
        //2 Apprave by Plant Head
        //3 Approve by HR Department

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = objRL.Approve_Show_Message();
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                ApproveFlag = true;
                SaveDB();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            double EarlyBy_Check = 0, LateBy_Check = 0;
            DataGridView dgv = sender as DataGridView;

            if (dgv.Columns[e.ColumnIndex].Name.Equals("clmLateBy"))
            {
                if (!string.IsNullOrEmpty(Convert.ToString(e.Value)))
                {
                    LateBy_Check = Convert.ToDouble(e.Value);

                    if (LateBy_Check > 0)
                    {
                        dgv.Rows[e.RowIndex].Cells["clmInTime"].Style.BackColor = Color.Yellow;
                        dgv.Rows[e.RowIndex].Cells["clmLateBy"].Style.BackColor = Color.Yellow;
                    }
                    else
                    {
                        dgv.Rows[e.RowIndex].Cells["clmInTime"].Style.BackColor = Color.White;
                        dgv.Rows[e.RowIndex].Cells["clmLateBy"].Style.BackColor = Color.White;
                    }
                }
            }

            if (dgv.Columns[e.ColumnIndex].Name.Equals("clmEarlyBy"))
            {
                if (!string.IsNullOrEmpty(Convert.ToString(e.Value)))
                {
                    EarlyBy_Check = Convert.ToDouble(e.Value);

                    if (EarlyBy_Check > 0)
                    {
                        dgv.Rows[e.RowIndex].Cells["clmOutTime"].Style.BackColor = Color.Yellow;
                        dgv.Rows[e.RowIndex].Cells["clmEarlyBy"].Style.BackColor = Color.Yellow;
                    }
                    else
                    {
                        dgv.Rows[e.RowIndex].Cells["clmOutTime"].Style.BackColor = Color.White;
                        dgv.Rows[e.RowIndex].Cells["clmEarlyBy"].Style.BackColor = Color.White;
                    }
                }
            }

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
