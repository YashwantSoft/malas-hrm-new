using BusinessLayerUtility;
using DocumentFormat.OpenXml.Math;
using MySql.Data.MySqlClient;
using SPApplication.Master;
using SPApplication.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPApplication.Transaction
{
    public partial class CompOffApplicationNew : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0;

        string MainQuery = string.Empty, WhereClauseOther = string.Empty, OrderClause = string.Empty, WhereClause = string.Empty;

        public CompOffApplicationNew()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, "Comp Off Application");
            //ClearAll();
            //objQL.Fill_Master_ComboBox(cmbLeaveType, "leavetypes");
            //objRL.Fill_LeaveType(cmbLeaveType, false);
            //objRL.FillLocation(cmbLocation, cmbDepartment);
            //FillEmployee_Fixed();
            objRL.Fill_Approval_Status(cmbStatus);
            objRL.Fill_Approval_Status(cmbUsedStatus);

            if (BusinessLayer.Department == "COMPLIANCE" || BusinessLayer.Department == "TIME OFFICE")
            {
                cmbStatus.Enabled = true;
                cmbUsedStatus.Enabled = true;
                txtEmployeeName.Enabled = true;
            }
            else
            {
                cmbStatus.Enabled = false;
                cmbUsedStatus.Enabled = false;
                txtEmployeeName.Enabled = false;
            }
        }
        private void txtEmployeeName_TextChanged(object sender, EventArgs e)
        {
            if (!GridFlag)
            {
                EmployeeId = 0;
                rtbEmployee.Text = "";
            }

            if (!string.IsNullOrWhiteSpace(Convert.ToString(txtEmployeeName.Text)))
                objRL.Fill_Employee_ListBox(lbEmployee, txtEmployeeName.Text, "Text");
            else
                objRL.Fill_Employee_ListBox(lbEmployee, txtEmployeeName.Text, "All");
        }

        private void lbEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetEmployeeDetails();
            }
        }

        private void lbEmployee_Click(object sender, EventArgs e)
        {
            GetEmployeeDetails();
        }

        private void GetEmployeeDetails()
        {
            rtbEmployee.Text = "";
            if (EmployeeId == 0)
            {
                if (lbEmployee.SelectedIndex > -1)
                {
                    EmployeeId = 0;
                    EmployeeId = Convert.ToInt32(lbEmployee.SelectedValue);
                    objRL.Fill_Employee_Details_RichTextBox(rtbEmployee, EmployeeId);
                    lbEmployee.Visible = false;
                    dtpDate.Focus();
                    Get_AttendanceData();
                }
            }
            else if (GridFlag && EmployeeId != 0)
            {
                lbEmployee.Visible = false;
                objRL.Fill_Employee_Details_RichTextBox(rtbEmployee, EmployeeId);
            }
            else if (BusinessLayer.Department != "Time Office" && EmployeeId != 0)
            {
                objRL.Fill_Employee_Details_RichTextBox(rtbEmployee, EmployeeId);
                lbEmployee.Visible = false;
            }
            else
            {
                rtbEmployee.Text = "";
                rtbEmployee.Visible = true;
                lbEmployee.Visible = true;
            }

            Get_Leaves();
        }

        private void Get_Leaves()
        {
            if (EmployeeId > 0)
            {
                objPC.EmployeeId = EmployeeId;
                objRL.Fill_EmployeeDetails();
                //txtEmployeeCode.Text = objPC.EmployeeCode.ToString();
                //txtDesignation.Text = objPC.Designation.ToString();
                objRL.Get_Leaves_Count_All();
                objPC.SearchFlagLeaveCompOff = true;
                objRL.Get_CompOff_Count_All();
                objRL.Fill_Leave_RichTextBox(rtbLeaveRecords);
                gbCompOffDetails.Visible = true;
                //LoadDates();
            }
        }

        private void txtEmployeeName_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtEmployeeName.Text != "" && lbEmployee.Items.Count > 0)
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                {
                    lbEmployee.SelectedIndex = 0;
                    lbEmployee.Focus();
                }
            }
        }

        public void Fill_Employee_ListBox()
        {
            txtEmployeeName.Enabled = false;

            //if (BusinessLayer.Department == "COMPLIANCE" || BusinessLayer.Department == "TIME OFFICE")
            if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR || BusinessLayer.UserType == BusinessResources.USER_TYPE_HROFFICER)
            {
                txtEmployeeName.Enabled = true;
                txtEmployeeName.Focus();
                lbEmployee.Visible = true;
                objRL.Fill_Employee_ListBox(lbEmployee, txtEmployeeName.Text, "All");
            }
            else
            {
                txtEmployeeName.Enabled = false;
                EmployeeId = BusinessLayer.EmployeeLoginId_Static;
                GetEmployeeDetails();
            }

            ////BusinessLayer.EmployeeLoginId_Static
            ////BusinessLayer.EmployeeLoginId_Static
            //if (BusinessLayer.Department == "COMPLIANCE" || BusinessLayer.Department == "TIME OFFICE")
            //{
            //    txtEmployeeName.Enabled = true;
            //    txtEmployeeName.Focus();
            //    lbEmployee.Visible = true;
            //    objRL.Fill_Employee_ListBox(lbEmployee, txtEmployeeName.Text, "All");
            //}
            //else
            //{
            //    txtEmployeeName.Enabled = false;
            //    EmployeeId = BusinessLayer.EmployeeLoginId_Static;
            //    GetEmployeeDetails();
            //}
            //{
            //    txtEmployeeName.Focus();
            //    lbEmployee.Visible = true;
            //    objRL.Fill_Employee_ListBox(lbEmployee, txtEmployeeName.Text, "All");
            //}
            //else
            //{
            //    EmployeeId = BusinessLayer.EmployeeLoginId_Static;
            //    GetEmployeeDetails();
            //}
        }

        private void dtpLeaveDate_ValueChanged(object sender, EventArgs e)
        {
            //objPC.CompOffDate = dtpCompOffDate.Value;
            //objPC.EmployeeId = EmployeeId;

            //if(EmployeeId >0)
            //{
            //    if(!GridFlag)
            //    {
            //        int Result = objQL.Check_CompOff_Date_Valid();

            //        if (Result == 0)
            //        {
            //            objRL.ShowMessage(54, 4);
            //            dtpCompOffDate.Value = DateTime.Now.Date;
            //            return;
            //        }
            //        else
            //        {
            //            lblAttendanceDay.Text = Convert.ToString(dtpCompOffDate.Value.Date.DayOfWeek);

            //            DateTime selectedDate = dtpCompOffDate.Value;
            //            //DateTime dueDate = selectedDate.AddDays(60);
            //            dtpCompOffDueDate.Value = selectedDate.AddDays(60);
            //            lblDueDateDay.Text = Convert.ToString(dtpCompOffDueDate.Value.Date.DayOfWeek);
            //        }
            //    }
            //}
        }
        private void ClearAll()
        {
            objEP.Clear();
            GridFlag = false;
            objPC.CompOffApplicationId = 0;

            IsCompOffExpired = 0;
            IsUsedCompOff = 0;

            cbUsedCompOffDate.Enabled = false;
            gbCompOffUsedDetails.Enabled = false;

            EmployeeId = 0;
            objPC.EmployeeId = 0;
            
            txtEmployeeName.Text = "";
            rtbEmployee.Text = "";
            lbEmployee.Visible = true;
            //objRL.Fill_Employee_ListBox(lbEmployee, txtEmployeeName.Text, "All");
            gbCompOffDetails.Visible = false;
            Fill_Employee_ListBox();

            dtpCompOffDate.Value = DateTime.Now.Date;
            //cmbLeaveType.SelectedIndex = -1;
            //txtReasonOfCompOff.Text = "";
            txtWorkingRemarks.Text = "";
            rtbLeaveRecords.Text = "";

            //txtType.Text = "";
            txtFileName.Text = "";
            dtpCompOffDueDate.Value = DateTime.Now.Date;
            dtpUsedCompOffDate.Value = DateTime.Now.Date;
            lblAttendanceDay.Text = "";
            lblDueDateDay.Text = "";
            lblUsedCompOffDay.Text = "";

            cmbUsedStatus.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1; 
            txtSearch.Text = "";
            rtbLeaveRecords.Text = "";

            cmbStatus.Text = BusinessResources.LS_Pending;
            cmbUsedStatus.Text = BusinessResources.LS_Pending;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!Validation())
            {
                if (TableId == 0)
                    AddFiles();

                FlagDelete = false;
                SaveDB();
            }
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FlagDelete = true;
            SaveDB();
        }

        string EmpDesignation = string.Empty;
        string EmpDepartment = string.Empty;
        bool GridFlag = false; int EmployeeId = 0;

        int SearchId = 0, LocationId = 0;

        private void dtpUsedCompOffDate_ValueChanged(object sender, EventArgs e)
        {
            lblUsedCompOffDay.Text = "";
            

            objPC.CompOffDate = dtpUsedCompOffDate.Value;
            objPC.EmployeeId = EmployeeId;

            if (EmployeeId > 0)
            {
                if (GridFlag)
                {
                    int Result = objQL.Check_CompOff_Date_Valid();

                    if (Result == 1)
                    {
                        objRL.ShowMessage(56, 4);
                        dtpUsedCompOffDate.Value = DateTime.Now.Date;
                        return;
                    }
                    else
                    {
                        lblUsedCompOffDay.Text = Convert.ToString(dtpUsedCompOffDate.Value.Date.DayOfWeek);
                    }
                }
            }
        }

        private void dtpCompOffDueDate_ValueChanged(object sender, EventArgs e)
        {
            lblUsedCompOffDay.Text = "";
            lblUsedCompOffDay.Text = Convert.ToString(dtpCompOffDueDate.Value.Date.DayOfWeek);
        }

        private void cbUsedCompOffDate_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUsedCompOffDate.Checked) 
            {
                gbCompOffUsedDetails.Enabled = true;
            }
            else
            {
                gbCompOffUsedDetails.Enabled = false;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (!ValidationBrowseFile())
            {
                Get_File();
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }

            //if (TableId != 0)
            //{
            //    objPC.FormName = this.Name;
            //    objPC.FormHeader = BusinessResources.LBL_HEADER_EMPLOYEEMASTER;
            //    objPC.TableId = TableId;
            //    Documents objForm = new Documents();
            //    objForm.ShowDialog(this);
            //}
        }

        private void AddFiles()
        {
            objPC.UploadDocumentId = 0;
            //objPC.FormId = objQL.SP_FormMaster_Get_FormId();
            objPC.TableId = TableId;
           // objPC.DocumentId = Convert.ToInt32(cmbDocumentName.SelectedValue);

            if (EmployeeId >0)
            {
                FilePathMain = SourcePath;
                CopyPasteFile();

                //objPC.EntryDate = dtpDate.Value;
                //objPC.DocumentPath = DestinationPath;
                //objPC.DocumentName = txtFileName.Text;
                //objPC.DeleteFlag = false;
                //objPC.UploadDocumentId = 0;
                //int R = objQL.SP_UploadDocuments_Save();

                //if (R > 0)
                //{
                //    //Fill_Files();
                //    //ClearAll();
                //}
               
            }
            else
            {
                objRL.ShowMessage(12, 4);
                return;
            }
        }

        private bool ValidationBrowseFile()
        {
            objEP.Clear();
            if (objPC.EmployeeId == 0)
            {
                txtEmployeeName.Focus();
                objEP.SetError(txtEmployeeName, "Enter Employee Name");
                return true;
            }
            else if (txtWorkingRemarks.Text == "")
            {
                txtWorkingRemarks.Focus();
                objEP.SetError(txtWorkingRemarks, "Enter Working Remarks");
                return true;
            }
            else if (cmbStatus.SelectedIndex == -1)
            {
                cmbStatus.Focus();
                objEP.SetError(cmbStatus, "Select Status");
                return true;
            }
            //else if (!cbUsedCompOffDate.Checked)
            //{
            //    cbUsedCompOffDate.Focus();
            //    objEP.SetError(cbUsedCompOffDate, "Enter Documents For");
            //    return true;
            //}
            //else if (cmbDocumentName.SelectedIndex == -1)
            //{
            //    cmbDocumentName.Focus();
            //    objEP.SetError(cmbDocumentName, "Select Document Name");
            //    return true;
            //}
            else
                return false;
        }

        string FileName = string.Empty, SourcePath = string.Empty, DestinationPath = string.Empty;

        private void Get_File()
        {
            FileName = string.Empty; SourcePath = string.Empty; DestinationPath = string.Empty;
            OpenFileDialog opnfd = new OpenFileDialog();
            //opnfd.Filter = "Files (*.pdf;*.jpg;*.jpeg;.*.png;)|*.pdf;*.jpg;*.jpeg;.*.png";
            opnfd.Filter = "Files (*.pdf)|*.pdf;";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                SourcePath = opnfd.FileName;
                FileName = Path.GetFileName(SourcePath);
                txtFileName.Text = FileName.ToString();
                txtFileName.Text = SourcePath.ToString();
                //pictureBox1.Image = new Bitmap(opnfd.FileName);
            }
        }

        string FileNameInsert = string.Empty;
        //int IsCompOffExpired = 0,
        //int IsUsedCompOff = 0;

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                RowCount_Grid = dataGridView1.Rows.Count;
                CurrentRowIndex = dataGridView1.CurrentRow.Index;

                if (RowCount_Grid >= 0 && CurrentRowIndex >= 0)
                {
                    ClearAll();
                    GridFlag = true;
                    cbUsedCompOffDate.Visible = true;
                    gbCompOffUsedDetails.Visible = false;
                    IsCompOffExpired = 0;
                    IsUsedCompOff = 0;

                    //0   COA.CompOffApplicationId,  +
                    //1   COA.EmployeeId,  +
                    //2   LM.LocationName,  +
                    //3   DM.Department,  +
                    //4   E.EmployeeName as 'Employee Name', +
                    //5   DES.Designation, +
                    //6   COA.CompOffDate as 'Comp Off Date', +
                    //7   COA.WorkRemarks as 'Work Remarks', +
                    //8   COA.CompStatusId as 'ApprovalStatusId', +
                    //9   CASE WHEN COA.CompStatusId = 1 THEN 'Pending' WHEN COA.CompStatusId = 2 THEN 'Completed' WHEN COA.CompStatusId = 3 THEN 'Remarks' WHEN COA.CompStatusId = 6 THEN 'HR Approved' WHEN COA.CompStatusId = 8 THEN 'Manager Approved' ELSE 'Unknown' END AS 'Status',  +
                    //10  COA.CompOffDueDate,  +
                    //11  COA.IsCompOffExpired,  +
                    //12  COA.IsUsedCompOff,  +
                    //13  COA.UsedCompOffDate as 'Used Comp Off Date',  +
                    //14  COA.UsedCompStatusId,  +
                    //15   CASE WHEN COA.UsedCompStatusId = 1 THEN 'Pending' WHEN COA.UsedCompStatusId = 2 THEN 'Completed' WHEN COA.UsedCompStatusId = 3 THEN 'Remarks' WHEN COA.UsedCompStatusId = 6 THEN 'HR Approved' WHEN COA.UsedCompStatusId = 8 THEN 'Manager Approved' ELSE 'Unknown' END AS 'Used Status',  +
                    //16  COA.FinancialYearId +


                    objPC.CompOffUsedFlag = 0;
                    TableId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value)));
                    objPC.CompOffApplicationId = TableId;
                    EmployeeId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value)));
                    GetEmployeeDetails();
                    dtpCompOffDate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());

                   // txtReasonOfCompOff.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[7].Value));
                    txtWorkingRemarks.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[7].Value));

                    
                    cmbStatus.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[9].Value));
                    

                    IsCompOffExpired = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[11].Value)));
                    IsUsedCompOff = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[12].Value)));

                    if (IsUsedCompOff > 0)
                    {
                        cbUsedCompOffDate.Checked = true;
                        gbCompOffUsedDetails.Enabled = true;
                        dtpUsedCompOffDate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString());
                        cmbUsedStatus.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[15].Value));
                    }
                    else
                    {
                        cbUsedCompOffDate.Checked = false;
                        gbCompOffUsedDetails.Enabled = false;
                    }

                    //dtpCompOffDueDate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[16].Value.ToString());

                    TimeSpan difference = DateTime.Now.Date.Subtract(dtpCompOffDueDate.Value);

                    int Dif = Convert.ToInt32(difference.Days);

                    if (Dif > 0)
                    {
                        gbCompOffUsedDetails.Visible = false;
                        objRL.ShowMessage(49, 4);
                        return;
                    }
                    else
                    {
                        gbCompOffUsedDetails.Enabled = true;

                        if(IsUsedCompOff==1)
                        {
                            if (cmbUsedStatus.Text == BusinessResources.LS_Completed)
                            {
                                gbCompOffUsedDetails.Enabled = false;
                            }
                            else
                            {
                                gbCompOffUsedDetails.Enabled = true;
                            }
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
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //dataGridView1
            
            if (e.RowIndex >= 0)
            {
                string columnName = dataGridView1.Columns[e.ColumnIndex].Name;

                // Check if clicked column is clmView
                if (columnName == "clmView")
                {

                    // Get file path from another column (example: "FilePath")
                    string filePath = dataGridView1.Rows[e.RowIndex].Cells[18].Value?.ToString();

                    EmployeeId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value)));

                    if (!string.IsNullOrEmpty(filePath) && EmployeeId >0)
                    {
                        DestinationPath = string.Empty;
                        DestinationPath = objRL.GetPath("CompOffFiles") + EmployeeId + "\\"+ filePath;

                        if (File.Exists(DestinationPath))
                        // Open file
                            System.Diagnostics.Process.Start(DestinationPath);
                        else
                            MessageBox.Show("File not found.");
                    }
                    else
                    {
                        MessageBox.Show("File not found.");
                    }
                }
            }
        }

        string FilePathInsert = string.Empty;

        private void dgvAttendanceList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                RowCount_Grid = dgvAttendanceList.Rows.Count;
                CurrentRowIndex = dgvAttendanceList.CurrentRow.Index;

                if (RowCount_Grid >= 0 && CurrentRowIndex >= 0)
                {
                    ClearAll();
                    GridFlag = true;
                    cbUsedCompOffDate.Visible = true;
                    gbCompOffUsedDetails.Visible = false;
                    IsCompOffExpired = 0;
                    IsUsedCompOff = 0;

                    gbCompOffDetails.Visible = true;

                    //0 "AttendanceLogId," +
                    //1 "AttendanceDate," +
                    //2 "DATE_FORMAT(InTime, '%d/%m/%Y %H:%i') AS 'IN Time', " +
                    //3 "DATE_FORMAT(OutTime, '%d/%m/%Y %H:%i') AS 'Out Time', " +
                    //4 "TIME_FORMAT(SEC_TO_TIME(Duration * 60), '%H:%i') AS Duration," +
                    //5 "Status " +

                    objPC.Status = string.Empty;
                    objPC.AttendanceLogId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dgvAttendanceList.Rows[e.RowIndex].Cells[0].Value)));
                    dtpCompOffDate.Value = Convert.ToDateTime(dgvAttendanceList.Rows[e.RowIndex].Cells[1].Value.ToString());
                    lblAttendanceDay.Text = Convert.ToString(dtpCompOffDate.Value.Date.DayOfWeek);
                    objPC.Status = objRL.CheckNullString(Convert.ToString(dgvAttendanceList.Rows[e.RowIndex].Cells[5].Value));

                    if (objPC.Status == "WOP")
                    {
                        lblAttendanceDay.Text += " - Weekly Off";
                    }
                    else
                    {
                        lblAttendanceDay.Text += " - Holiday";
                    }

                    //objPC.CompOffUsedFlag = 0;
                    //TableId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value)));
                    //objPC.CompOffApplicationId = TableId;
                    //EmployeeId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value)));
                    

                    GetEmployeeDetails();

                    //txtReasonOfCompOff.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[7].Value));
                    //txtWorkingRemarks.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[8].Value));
                    //cmbStatus.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[10].Value));

                    //IsCompOffExpired = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[12].Value)));
                    //IsUsedCompOff = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[13].Value)));

                    //if (IsUsedCompOff > 0)
                    //{
                    //    cbUsedCompOffDate.Checked = true;
                    //    gbCompOffUsedDetails.Enabled = true;
                    //    dtpUsedCompOffDate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString());
                    //    cmbUsedStatus.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[16].Value));
                    //}
                    //else
                    //{
                    //    cbUsedCompOffDate.Checked = false;
                    //    gbCompOffUsedDetails.Enabled = false;
                    //}

                    ////dtpCompOffDueDate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[16].Value.ToString());

                    //TimeSpan difference = DateTime.Now.Date.Subtract(dtpCompOffDueDate.Value);

                    //int Dif = Convert.ToInt32(difference.Days);

                    //if (Dif > 0)
                    //{
                    //    gbCompOffUsedDetails.Visible = false;
                    //    objRL.ShowMessage(49, 4);
                    //    return;
                    //}
                    //else
                    //{
                    //    gbCompOffUsedDetails.Enabled = true;

                    //    if (IsUsedCompOff == 1)
                    //    {
                    //        if (cmbUsedStatus.Text == BusinessResources.LS_Completed)
                    //        {
                    //            gbCompOffUsedDetails.Enabled = false;
                    //        }
                    //        else
                    //        {
                    //            gbCompOffUsedDetails.Enabled = true;
                    //        }
                    //    }
                    //}
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

        string FilePathMain = string.Empty;


        private void CopyPasteFile()
        {
            if (EmployeeId > 0)
            {
                //DestinationPath = objRL.GetPath("DocumentsPath") + "\\" + objPC.FormId + "\\" + TableId + "\\";
                //objRL.GetServerPath()
                DestinationPath = string.Empty;
                DestinationPath = objRL.GetPath("CompOffFiles") + objPC.EmployeeId + "\\";
                DirectoryInfo objDI = new DirectoryInfo(Path.GetFullPath(DestinationPath));

                if (!Directory.Exists(Path.GetFullPath(DestinationPath)))
                    objDI.Create();
                else
                {
                    string[] files = Directory.GetFiles(DestinationPath);

                    foreach (string file in files)
                    {
                        if (file == DestinationPath + FileName)
                            File.Delete(file);
                    }
                }
                File.Copy(FilePathMain, DestinationPath + Path.GetFileName(FilePathMain));
            }
        }

        private void CompOffApplicationNew_Load(object sender, EventArgs e)
        {
            ClearAll();
            FillGrid();
            //Get_AttendanceData();
        }

        private void Get_AttendanceData()
        {
            DataTable dt=new DataTable();
            objBL.Query = "";

            string query = "";

            //                " SELECT "+
            //                    " AttendanceLogId " +
            //                    " DATE(InTime) AS WorkDate, " +
            //                    " MIN(InTime) AS InTime, " +
            //                    " MAX(OutTime) AS OutTime, " +
            //                    " TIMESTAMPDIFF(MINUTE, MIN(InTime), MAX(OutTime)) AS DurationMinutes, " +
            //                    " MAX(Status) AS Status " +
            //                " FROM attendancelogs " +
            //                " WHERE EmployeeId = " + EmployeeId+" "+
            //                " GROUP BY DATE(InTime) " +
            //                " HAVING DurationMinutes > 0 " +
            //                " AND Status IN ('WOP', 'HP');";

            //query = " SELECT " +
            //              "AttendanceLogId," +
            //              "AttendanceDate as 'Attendance Date'," +
            //              "DATE_FORMAT(InTime, '%d/%m/%Y %H:%i') AS 'IN Time', " +
            //              "DATE_FORMAT(OutTime, '%d/%m/%Y %H:%i') AS 'Out Time', " +
            //              "TIME_FORMAT(SEC_TO_TIME(Duration * 60), '%H:%i') AS Duration," +
            //              "Status " +
            //        " FROM attendancelogs  WHERE EmployeeId = " + BusinessLayer.EmployeeLoginId_Static +"  and Duration > 0 AND Status IN ('WOP', 'HP') ";


            dgvAttendanceList.DataSource = null;
            dgvAttendanceList.Rows.Clear();

            MainQuery = string.Empty;
            WhereClause = string.Empty;
            string OrderByClause = string.Empty;

            string AddClause = string.Empty;

            if (BusinessLayer.Department == "COMPLIANCE" || BusinessLayer.Department == "TIME OFFICE")
                AddClause = " al.EmployeeId = " + EmployeeId + " ";
            else
            {
                AddClause = " al.EmployeeId = " + BusinessLayer.EmployeeLoginId_Static + " ";
                EmployeeId = BusinessLayer.EmployeeLoginId_Static;
            }
                

            MainQuery = "SELECT "+
                    " al.AttendanceLogId, " +
                    //" al.EmployeeId, " +
                    " al.AttendanceDate AS `Attendance Date`, " +
                    " DATE_FORMAT(al.InTime, '%d/%m/%Y %H:%i') AS `IN Time`, " +
                    " DATE_FORMAT(al.OutTime, '%d/%m/%Y %H:%i') AS `Out Time`, " +
                    " TIME_FORMAT(SEC_TO_TIME(al.Duration * 60), '%H:%i') AS Duration, " +
                    " al.Status " +
                " FROM attendancelogs al " +
                " WHERE  " + AddClause + "   "+
                    " AND al.CancelTag=0 and al.Duration > 0  " +
                    " AND al.Status IN ('WOP', 'HP')   " +
                    " AND NOT EXISTS(" +
                      "   SELECT 1  " +
                       "  FROM compoffapplication ca  " +
                       "  WHERE ca.CompOffDate = al.AttendanceDate  " +
                         " AND ca.CancelTag = 0)  ";

            OrderByClause = " Order by al.AttendanceDate desc ";

            objBL.Query = MainQuery + WhereClause + OrderByClause ;
            dt = objBL.ReturnDataTable();

            if (dt.Rows.Count > 0)
            {

                //0 "AttendanceLogId," +
                //1 "AttendanceDate," +
                //2 "DATE_FORMAT(InTime, '%d/%m/%Y %H:%i') AS 'IN Time', " +
                //3 "DATE_FORMAT(OutTime, '%d/%m/%Y %H:%i') AS 'Out Time', " +
                //4 "TIME_FORMAT(SEC_TO_TIME(Duration * 60), '%H:%i') AS Duration," +
                //5 "Status " +

                dgvAttendanceList.DataSource = dt;

                dgvAttendanceList.Columns[0].Visible = false;
                dgvAttendanceList.Columns[1].Width = 100;
                dgvAttendanceList.Columns[2].Width = 110;
                dgvAttendanceList.Columns[3].Width = 110;
                dgvAttendanceList.Columns[4].Width = 60;
                dgvAttendanceList.Columns[5].Width = 50;

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        //private bool Leave_Validation()
        //{
        //    if (cmbLeaveType.Text != "Special Leave")
        //    {
        //        double TLeaves = 0;
        //        double BCount = objPC.Balance_Count;

        //        //TLeaves = Convert.ToDouble(txtTotalDays.Text);

        //        double TestLeaves = 0;

        //        TestLeaves = BCount - TLeaves;

        //        //double NewBalanceLeaves=

        //        if (TestLeaves < 0)
        //            return true;
        //        else
        //            return false;
        //    }
        //    else
        //        return false;
        //}
        private bool Validation()
        {
            BalanceFlag = false;
            objEP.Clear();

            if (EmployeeId == 0)
            {
                txtEmployeeName.Focus();
                objEP.SetError(txtEmployeeName, "Select Employee Name");
                return true;
            }
            else if (txtWorkingRemarks.Text == "")
            {
                txtWorkingRemarks.Focus();
                objEP.SetError(txtWorkingRemarks, "Enter Working Remarks");
                return true;
            }
            else if (txtFileName.Text == "")
            {
                txtFileName.Focus();
                objEP.SetError(txtFileName, "Enter File Name");
                return true;
            }
            else if (cmbStatus.SelectedIndex == -1)
            {
                cmbStatus.Focus();
                objEP.SetError(cmbStatus, "Enter Status");
                return true;
            }
            else if (cbUsedCompOffDate.Checked && cmbUsedStatus.SelectedIndex == -1 && TableId >0)
            {
                cmbUsedStatus.Focus();
                objEP.SetError(cmbUsedStatus, "Enter Status");
                return true;
            }
            else
                return false;
        }
        int IsCompOffExpired = 0, IsUsedCompOff=0;
        string LeaveStaus = string.Empty;
        private void SaveDB()
        {
            if (!Validation())
            {
                objPC.CompOffApplicationId = TableId;
                objPC.EmployeeId = EmployeeId;
                //objPC.LeaveDate = dtpCompOffDate.Value;
                ////objPC.LeaveTypeId = Convert.ToInt32(cmbLeaveType.SelectedValue);
                //objPC.LeaveReason = txtReasonOfCompOff.Text;
                //objPC.LeaveStatus = LeaveStaus;
                //objPC.DeleteFlag = FlagDelete;
                //objPC.Remarks = txtWorkingRemarks.Text;
                //objPC.IsRevertLeave = 0;


                if(cbUsedCompOffDate.Checked)
                    IsUsedCompOff = 1;
                else
                    IsUsedCompOff = 0;

                if (TableId == 0)
                {
                    string PathSave= @DestinationPath;

                    //objBL.Query = "insert into compoffapplication(EmployeeId,CompOffDate,ReasonOfCompOff,WorkRemarks,CompStatus,CompOffDueDate,IsCompOffExpired,FileName,@FilePath,FinancialYearId,UserId) values(" + EmployeeId + ",'" + dtpCompOffDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "', '" + txtReasonOfCompOff.Text + "','" + txtWorkingRemarks.Text + "'," + cmbStatus.SelectedValue + ",'" + dtpCompOffDueDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'," + IsCompOffExpired + ",'" + FileName + "',@FilePath," + objPC.FinancialYearId + "," + BusinessLayer.UserName_Static + ")";
                    //objBL.objCmd.Parameters.AddWithValue("@FilePath", PathSave);

                    string query = @"INSERT INTO compoffapplication
                                    (EmployeeId, CompOffDate,  WorkRemarks, CompStatusId,
                                        CompOffDueDate, IsCompOffExpired, FileName, FilePath, FinancialYearId, UserId)
                                    VALUES
                                    (@EmployeeId, @CompOffDate, @WorkRemarks, @CompStatusId,
                                        @CompOffDueDate, @IsCompOffExpired, @FileName, @FilePath, @FinancialYearId, @UserId)";

                    objBL.Connect();
                    MySqlCommand cmd = new MySqlCommand(query, objBL.objCon);

                    cmd.Parameters.AddWithValue("@EmployeeId", EmployeeId);
                    cmd.Parameters.AddWithValue("@CompOffDate", dtpCompOffDate.Value);
                    //cmd.Parameters.AddWithValue("@ReasonOfCompOff", txtReasonOfCompOff.Text);
                    cmd.Parameters.AddWithValue("@WorkRemarks", txtWorkingRemarks.Text);
                    cmd.Parameters.AddWithValue("@CompStatusId", cmbStatus.SelectedValue);
                    cmd.Parameters.AddWithValue("@CompOffDueDate", dtpCompOffDueDate.Value);
                    cmd.Parameters.AddWithValue("@IsCompOffExpired", IsCompOffExpired);
                    cmd.Parameters.AddWithValue("@FileName", FileName);
                    cmd.Parameters.AddWithValue("@FilePath", PathSave);
                    cmd.Parameters.AddWithValue("@FinancialYearId", objPC.FinancialYearId);
                    cmd.Parameters.AddWithValue("@UserId", BusinessLayer.UserName_Static);

                    Result = cmd.ExecuteNonQuery();
                }
                else
                {
                    if (!FlagDelete)
                    {
                        if(cbUsedCompOffDate.Checked)
                        {
                            int Result = objQL.Check_CompOff_Date_Valid();

                            if (Result == 1)
                            {
                                objRL.ShowMessage(56, 4);
                                dtpCompOffDate.Value = DateTime.Now.Date;
                                return;
                            }
                            //else
                            //{
                            //    lblUsedCompOffDay.Text = Convert.ToString(dtpUsedCompOffDate.Value.Date.DayOfWeek);
                            //}
                        }

                        objBL.Query = "update compoffapplication set UsedCompStatusId=" + cmbUsedStatus.SelectedValue + ",IsUsedCompOff=" + IsUsedCompOff + ",UsedCompOffDate='" + dtpUsedCompOffDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "',ModifiedUserId=" + BusinessLayer.UserName_Static + " where CompOffApplicationId=" + TableId + "";
                        //Result = objBL.Function_ExecuteNonQuery();

                    }

                    else
                        objBL.Query = "update compoffapplication set CancelTag=1,ModifiedUserId=" + BusinessLayer.UserName_Static + " where CompOffApplicationId=" + TableId + "";

                    Result = objBL.Function_ExecuteNonQuery();

                }

                // Result = objQL.SP_LeaveApplication_Insert_Update_Delete();

                if (Result > 0)
                {
                    if (!FlagDelete)
                    {
                        //AddFiles();
                        objRL.ShowMessage(7, 1);
                    }
                        
                    else
                    {
                        //Get_Leave_Count();

                        objRL.ShowMessage(9, 1);

                        if (FlagDelete)
                        {
                            
                        }
                    }

                    FillGrid();
                    ClearAll();

                    objPC.SearchFlagLeaveCompOff = false;
                    objRL.Get_Leaves_Count_All();
                    objRL.Fill_Leave_RichTextBox(rtbLeaveRecords);
                }
            }
            else
            {
                if (BalanceFlag)
                    objRL.ShowMessage(46, 4);
                else
                    objRL.ShowMessage(17, 4);
                return;
            }
        }

        bool BalanceFlag = false;
        protected void FillGrid()
        {
            DataSet ds = new DataSet();
            MainQuery = string.Empty; WhereClause = string.Empty; WhereClauseOther = string.Empty; OrderClause = string.Empty;
            dataGridView1.DataSource = null;

            MainQuery = "Select distinct " +
                   "COA.CompOffApplicationId, " +
                   "COA.EmployeeId, " +
                   "LM.LocationName, " +
                   "DM.Department, " +
                   "E.EmployeeName as 'Employee Name'," +
                   "DES.Designation," +
                   "COA.CompOffDate as 'Comp Off Date'," +
                   "COA.WorkRemarks as 'Work Remarks'," +
                   "COA.CompStatusId as 'ApprovalStatusId'," +
                   " CASE WHEN COA.CompStatusId = 1 THEN 'Pending' WHEN COA.CompStatusId = 2 THEN 'Completed' WHEN COA.CompStatusId = 3 THEN 'Remarks' WHEN COA.CompStatusId = 6 THEN 'HR Approved' WHEN COA.CompStatusId = 8 THEN 'Manager Approved' ELSE 'Pending' END AS 'Status', " +
                   "COA.CompOffDueDate, " +
                   "COA.IsCompOffExpired, " +
                   "COA.IsUsedCompOff, " +
                   "COA.UsedCompOffDate as 'Used Comp Off Date', " +
                   "COA.UsedCompStatusId, " +
                   " CASE WHEN COA.UsedCompStatusId = 1 THEN 'Pending' WHEN COA.UsedCompStatusId = 2 THEN 'Completed' WHEN COA.UsedCompStatusId = 3 THEN 'Remarks' WHEN COA.UsedCompStatusId = 6 THEN 'HR Approved' WHEN COA.UsedCompStatusId = 8 THEN 'Manager Approved' ELSE 'Pending' END AS 'Used Status', " +
                   "COA.FinancialYearId, " +
                   "COA.FileName " +
               " from " +
                   " compoffapplication COA inner join " +
                   " Employees E on E.EmployeeId=COA.EmployeeId inner join " +
                   " DesignationMaster DES on DES.DesignationId=E.DesignationId inner join " +
                   " LocationMaster LM on LM.LocationId=E.LocationId inner join " +
                   " DepartmentMaster DM on DM.DepartmentId=E.DepartmentId " +
               " where " +
                   "COA.CancelTag=0 and " +
                   "E.CancelTag=0 and " +
                   "DM.CancelTag=0 and " +
                   "DES.CancelTag=0 and " +
                   "LM.CancelTag=0 ";

            if (BusinessLayer.UserType == "ADMINISTRATOR")
            {
                if (SearchFlag && txtSearch.Text != "")
                    WhereClause += " and E.EmployeeName LIKE '%" + txtSearch.Text + "%'";
                else
                    WhereClause += string.Empty;
            }
            else
                WhereClause = " and E.EmployeeId=" + BusinessLayer.EmployeeLoginId_Static + " ";

            WhereClause += " and COA.FinancialYearId=" + objPC.FinancialYearId + " ";

            OrderClause = " order by COA.CompOffApplicationId desc ";

            objBL.Query = MainQuery + WhereClause + OrderClause;

            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTotalCount.Text = "Total-" + ds.Tables[0].Rows.Count;

                //0   COA.CompOffApplicationId,  +
                //1   COA.EmployeeId,  +
                //2   LM.LocationName,  +
                //3   DM.Department,  +
                //4   E.EmployeeName as 'Employee Name', +
                //5   DES.Designation, +
                //6   COA.CompOffDate as 'Comp Off Date', +
                //7   COA.WorkRemarks as 'Work Remarks', +
                //8   COA.CompStatusId as 'ApprovalStatusId', +
                //9   CASE WHEN COA.CompStatusId = 1 THEN 'Pending' WHEN COA.CompStatusId = 2 THEN 'Completed' WHEN COA.CompStatusId = 3 THEN 'Remarks' WHEN COA.CompStatusId = 6 THEN 'HR Approved' WHEN COA.CompStatusId = 8 THEN 'Manager Approved' ELSE 'Unknown' END AS 'Status',  +
                //10  COA.CompOffDueDate,  +
                //11  COA.IsCompOffExpired,  +
                //12  COA.IsUsedCompOff,  +
                //13  COA.UsedCompOffDate as 'Used Comp Off Date',  +
                //14  COA.UsedCompStatusId,  +
                //15   CASE WHEN COA.UsedCompStatusId = 1 THEN 'Pending' WHEN COA.UsedCompStatusId = 2 THEN 'Completed' WHEN COA.UsedCompStatusId = 3 THEN 'Remarks' WHEN COA.UsedCompStatusId = 6 THEN 'HR Approved' WHEN COA.UsedCompStatusId = 8 THEN 'Manager Approved' ELSE 'Unknown' END AS 'Used Status',  +
                //16  COA.FinancialYearId +
                //17 "COA.FileName " +




                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;

                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[14].Visible = false;
                dataGridView1.Columns[16].Visible = false;


                dataGridView1.Columns[2].Width = 80;
                dataGridView1.Columns[3].Width = 120;
                dataGridView1.Columns[4].Width = 200;
                dataGridView1.Columns[5].Width = 100;
                dataGridView1.Columns[6].Width = 100;
                dataGridView1.Columns[7].Width = 150;
                dataGridView1.Columns[9].Width = 150;
                dataGridView1.Columns[10].Width = 150;
                dataGridView1.Columns[12].Width = 80;

                // Create checkbox column
                DataGridViewLinkColumn chk = new DataGridViewLinkColumn();
                chk.HeaderText = "View";
                chk.Name = "clmView";
                chk.Width = 50;

                // Add to DataGridView
                dataGridView1.Columns.Insert(dataGridView1.Columns.Count, chk); // adds as first column

                if (dataGridView1.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            row.Cells["clmView"].Value = "View";
                        }
                    }
                }

                objRL.Set_Approval_Colour_DataGridView(dataGridView1, lblPending, lblHRApproved, lblManagerApproved, lblRemark, lblCompleted, "ApprovalStatusId");

                dataGridView1.ClearSelection();
            }
        }
    }
}
