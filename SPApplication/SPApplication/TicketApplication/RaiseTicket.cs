using BusinessLayerUtility;
using SPApplication.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPApplication.Transaction
{
    public partial class RaiseTicket : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        AttendanceLogics objAL = new AttendanceLogics();
        PropertyClass objPC = new PropertyClass();

        bool SearchFlag = false;
        int TableId = 0;
        bool DeleteFlag = false;
        string ExecuteType = "";
       
        public RaiseTicket()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_RAISETICKET);
            btnSave.Text = BusinessResources.BTN_SEND;

            objRL.ColumnNameCM = "TicketStatus";
            objRL.Fill_ComboBox_Comman(cmbStatus);

            objRL.ColumnNameCM = "Priority";
            objRL.Fill_ComboBox_Comman(cmbPriority);
             
            cmbStatus.Enabled = false;

            lblSelected.BackColor = objDL.GetBackgroundColor();
            By_Default_Values();

            objPC.ViewTicketFlag = false;
            objRL.Fill_Department_Ticket(cmbDepartment);
            cmbDepartment.SelectedIndex = -1;
            cmbDepartment.Enabled = true;
           
            cmbStatus.Text = BusinessResources.LS_Pending;

            //if (BusinessLayer.Department == "TIME OFFICE")
            //{
            //    //cmbDepartment.Text = BusinessLayer.Department.ToString();
            //    cmbDepartment.Enabled = true;
            //}
            //else if(BusinessLayer.Department == "INFORMATION TECHNOLOGY")
            //{
            //    cmbDepartment.Text = BusinessLayer.Department.ToString();
            //    cmbDepartment.Enabled = false;
            //}
            //else
            //{
            //    cmbDepartment.SelectedIndex = -1;
            //    cmbDepartment.Enabled = true;
            //}
        }

        private void By_Default_Values()
        {
            if (BusinessLayer.UserType == BusinessResources.USER_TYPE_OFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER || BusinessLayer.UserType == BusinessResources.USER_TYPE_SENIOROFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_INCHARGE || BusinessLayer.UserType == BusinessResources.USER_TYPE_HROFFICER)
            {
                cmbStatus.Text = "Pending";
                cmbStatus.Enabled = false;
            }
            else
            {
                //cmbStatus.Text = "Pending";
                cmbStatus.Enabled = true;
            }

            EnableTrue();
        }

        private void SetTicketNo()
        {
            txtTicketNo.Text = Convert.ToString(objRL.ReturnMaxID_Increase("Ticket", "TicketId"));
        }

        private void RaiseTicket_Load(object sender, EventArgs e)
        {
            try
            {
                //objRL.Add_Tool_Tip(btnSave, btnClear, btnDelete, btnExit);
                FillGrid();
                ClearAll();
            }
            catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
            finally { GC.Collect(); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveDB();
            }
            catch (Exception ex1) { MessageBox.Show(ex1.ToString()); }
            finally { GC.Collect(); }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearAll();
                EnableTrue();
                By_Default_Values();
            }
            catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
            finally { GC.Collect(); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    DeleteFlag = true;
            //    SaveDB();
            //}
            //catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
            //finally { GC.Collect(); }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ClearAll()
        {
            TableId = 0;
            objEP.Clear();
            DeleteFlag = false;
            SearchFlag = false;

            dtpDate.Value = DateTime.Now.Date;
            dtpTime.Value = DateTime.Now;
            txtTicketNo.Text = "";
            txtQuery.Text = "";
            cmbTicketType.SelectedIndex = -1;
            ExecuteType = "";
            cmbAssignedTo.SelectedIndex = -1;
            cmbPriority.SelectedIndex = -1;
            //cmbStatus.SelectedIndex = -1;
            cmbPeriod.SelectedIndex = -1;
            cmbRatings.SelectedIndex = -1;
            txtReply.Text = "";
            cmbRatings.Text = "";
            txtSearchTicketNo.Text = "";
            txtSearchTicketNo.Text = "";

            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            SetTicketNo();
            txtQuery.Focus();
        }

        private bool Validation()
        {
            objEP.Clear();
            if (txtQuery.Text == "")
            {
                objEP.SetError(txtQuery, "Enter Query");
                txtQuery.Focus();
                return true;
            }
            else if (cmbDepartment.SelectedIndex == -1)
            {
                objEP.SetError(cmbDepartment, "Select Department");
                cmbDepartment.Focus();
                return true;
            }
            if (cmbTicketType.SelectedIndex == -1)
            {
                objEP.SetError(cmbTicketType, "Select Ticket Type");
                cmbTicketType.Focus();
                return true;
            }
            else if (cmbAssignedTo.SelectedIndex == -1)
            {
                objEP.SetError(cmbAssignedTo, "Select Assigned To");
                cmbAssignedTo.Focus();
                return true;
            }
            else if (cmbPriority.SelectedIndex == -1)
            {
                objEP.SetError(cmbPriority, "Select Priority");
                cmbPriority.Focus();
                return true;
            }
            else if (cmbStatus.SelectedIndex == -1)
            {
                objEP.SetError(cmbStatus, "Select Status");
                cmbStatus.Focus();
                return true;
            }
            else if (cmbPeriod.SelectedIndex == -1)
            {
                objEP.SetError(cmbPeriod, "Select Period");
                cmbPeriod.Focus();
                return true;
            }
            else
                return false;
        }

        string RaiseQuery = string.Empty;
        string Reply = string.Empty;

        private void SaveDB()
        {
            try
            {
                if (!Validation())
                {
                    if(!string.IsNullOrEmpty(Convert.ToString(txtQuery.Text)))
                        RaiseQuery = txtQuery.Text;
                    if (!string.IsNullOrEmpty(Convert.ToString(txtReply.Text)))
                        Reply = txtReply.Text;

                    if (TableId != 0)
                    {
                        if (DeleteFlag)
                        {
                            objBL.Query = "update Ticket set CancelTag=1 where TicketId=" + TableId + "";
                            ExecuteType = "Delete";
                        }
                        else
                        {
                            objBL.Query = "update Ticket set EntryDate='" + dtpDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "',EntryTime='" + dtpTime.Value.ToString(BusinessResources.TimeFormat_HHMM) + "',DepartmentId=" + cmbDepartment.SelectedValue + ",RaiseQuery='" + RaiseQuery.Replace("'", "''") + "',TicketType='" + cmbTicketType.Text + "',AssignedTo=" + cmbAssignedTo.SelectedValue + ",Priority='" + cmbPriority.Text + "',Status='" + cmbStatus.Text + "',Period='" + cmbPeriod.Text + "',ReplyAnswer='" + Reply.Replace("'", "''") + "',Ratings='" + cmbRatings.Text + "',ModifiedUserId=" + BusinessLayer.EmployeeLoginId_Static + " where TicketId=" + TableId + " and CancelTag=0";
                            ExecuteType = "Update";
                        }    
                    }
                    else
                    {
                        objBL.Query = "insert into Ticket(EntryDate,EntryTime,DepartmentId,RaiseQuery,TicketType,AssignedTo,Priority,Status,Period,ReplyAnswer,Ratings,UserId,FinancialYearId) values('" + dtpDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "','" + dtpTime.Value.ToString(BusinessResources.TimeFormat_HHMM) + "'," + cmbDepartment.SelectedValue + ",'" + RaiseQuery.Replace("'", "''") + "','" + cmbTicketType.Text + "'," + cmbAssignedTo.SelectedValue + ",'" + cmbPriority.Text + "','" + cmbStatus.Text + "','" + cmbPeriod.Text + "','" + Reply.Replace("'", "''") + "','" + cmbRatings.Text + "'," + BusinessLayer.EmployeeLoginId_Static + "," + objPC.FinancialYearId + ")";
                        ExecuteType = "Save";
                    }

                    int Result = objBL.Function_ExecuteNonQuery();
                    if (Result > 0)
                    {
                        if (ExecuteType == "Save")
                            objRL.ShowMessage(7, 1);
                        else if (ExecuteType == "Update")
                            objRL.ShowMessage(8, 1);
                        else
                            objRL.ShowMessage(9, 1);

                        FillGrid();
                        ClearAll();
                    }
                }
                else
                {
                    objRL.ShowMessage(17, 4);
                    return;
                }
            }
            catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
            finally { GC.Collect(); }
        }


        string PSColumn = string.Empty, PSInnerJoinClause = string.Empty, PSInvoice = string.Empty, PSSC = string.Empty, PSSCHead = string.Empty;
        string MainQuery = string.Empty;
        string WhereClause = string.Empty;
        string OrderByClause = string.Empty;
        string UserClause = string.Empty;

        private void txtSearchTicketNo_TextChanged(object sender, EventArgs e)
        {
            SearchByName = false;

            if (txtSearchTicketNo.Text != "")
                IDFlag = true;
            else
                IDFlag = false;

            FillGrid();
        }

        private void cbToday_CheckedChanged(object sender, EventArgs e)
        {
            if (cbToday.Checked)
            {
                FillGrid();
            }
        }

        bool IDFlag = false;

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //0 RT.TicketId as 'Ticket No',
                //1 RT.EntryDate as 'Date',
                //2 RT.EntryTime as 'Time',
                //3 RT.DepartmentId,
                //4 D.Department,
                //5 RT.RaiseQuery as 'Query',
                //6 RT.TicketType as 'Ticket Type',
                //7 RT.AssignedTo,
                //8 E.EmployeeName as 'Ticket by',
                //9 L.LocationName as 'Location',
                //10 D1.Department,
                //11 E1.EmployeeName as 'Assign To',
                //12 RT.Priority,
                //13 RT.Status,
                //14 RT.Period,
                //15 RT.ReplyAnswer as 'Reply',
                //16 RT.Ratings,
                //17 RT.SolvedPeriod 

                ClearAll();
                TableId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtTicketNo.Text = TableId.ToString();
                dtpDate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                dtpTime.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                cmbDepartment.Text =objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value));
                txtQuery.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[5].Value));
                
                //Set_Assign_To();
                Fill_DepartmentWise_Users();
                cmbTicketType.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[6].Value));
                cmbAssignedTo.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[11].Value));
                cmbPriority.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[12].Value));
                cmbStatus.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[13].Value));
                cmbPeriod.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[14].Value));
                txtReply.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[15].Value));
                cmbRatings.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[16].Value));

                if (cmbRatings.SelectedIndex > -1)
                    cmbRatings.Enabled = false;
                else
                {
                    if (cmbStatus.Text == "Complete")
                        cmbRatings.Enabled = true;
                    else
                        cmbRatings.Enabled = false;
                }
                EnableFalse();
                cmbStatus.Enabled = false;
                txtReply.ReadOnly = true;

                //if (BusinessLayer.Department == "TIME OFFICE" || BusinessLayer.Department == "INFORMATION TECHNOLOGY")
                //{
                //    txtReply.Enabled = true;
                //    cmbStatus.Enabled = true;
                //    txtReply.ReadOnly = false;
                //}
                //else
                //    txtReply.Enabled = false;
            }
            catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
            finally { GC.Collect(); }
        }

        bool DateFlag = false;

        bool SearchByName = false;

        private void cmbTicketType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Set_Assign_To();
        }

        private void Set_Assign_To()
        {
            if (cmbTicketType.SelectedIndex > -1)
            {
                //TicketType
                //ERP
                //Computer
                //Laptop
                //Internet
                //Email
                //Printer
                //Requirements
                //Select All
              
                objRL.EmplCode_L.Clear();
                if (cmbTicketType.Text == "ERP")
                {
                    objRL.EmplCode_L.Add(2346);
                    objRL.EmplCode_L.Add(2446);
                    objRL.Fill_EmployeeName_AssignTo_CodeWise(cmbAssignedTo);
                }
                else
                {
                    objRL.EmplCode_L.Add(2346);
                    objRL.EmplCode_L.Add(2482);
                    objRL.EmplCode_L.Add(1899);
                    objRL.Fill_EmployeeName_AssignTo_CodeWise(cmbAssignedTo);
                }
            }
        }

        private void EnableFalse()
        {
            dtpDate.Enabled=false;
            dtpTime.Enabled = false;
            txtQuery.Enabled = false;
            cmbTicketType.Enabled = false;
            cmbAssignedTo.Enabled = false;
            cmbPriority.Enabled = false;
            cmbStatus.Enabled = false;
            cmbPeriod.Enabled = false;
            txtReply.Enabled = false;
           // cmbRatings.Enabled = true;
        }

        private void EnableTrue()
        {
            dtpDate.Enabled = true;
            dtpTime.Enabled = true;
            txtQuery.Enabled = true;
            cmbTicketType.Enabled = true;
            cmbAssignedTo.Enabled = true;
            cmbPriority.Enabled = true;
            //cmbStatus.Enabled = true;
            cmbPeriod.Enabled = true;
            txtReply.Enabled = true;
            cmbRatings.Enabled = false;
        }

        private void FillGrid()
        {
            if (cmbDepartment.SelectedIndex > -1)
            {
                dataGridView1.DataSource = null;
                PSColumn = string.Empty;
                PSInnerJoinClause = string.Empty;
                PSInvoice = string.Empty;
                PSSC = string.Empty;
                PSSCHead = string.Empty;
                MainQuery = string.Empty;
                WhereClause = string.Empty;
                OrderByClause = string.Empty;
                UserClause = string.Empty;
                DataSet ds = new DataSet();

                try
                {
                    if (IDFlag)
                        WhereClause += " and RT.TicketId=" + txtSearchTicketNo.Text + "";
                    if (SearchByName)
                        WhereClause += " and RT.RaiseQuery like '%" + txtSearchQuery.Text + "%'";
                    if (DateFlag)
                        WhereClause += " and RT.EntryDate=#" + dtpSearch.Value.ToString(BusinessResources.DATEFORMATMMDDYYYY) + "#";

                    //if (BusinessLayer.UserType == "User")

                    //if (BusinessLayer.Department != "TIME OFFICE" && BusinessLayer.Department != "HR" && BusinessLayer.Department != "INFORMATION TECHNOLOGY")
                    //    WhereClause += " and RT.UserId=" + BusinessLayer.EmployeeLoginId_Static + "";

                    if (BusinessLayer.Department == "INFORMATION TECHNOLOGY")
                    {
                        WhereClause += " and D.Department='TIME OFFICE'";
                    }
                    else if (BusinessLayer.Department == "TIME OFFICE")
                    {
                        WhereClause += " and D.Department='INFORMATION TECHNOLOGY'";
                    }
                    else
                    {
                        WhereClause += " and D.Department='" + cmbDepartment.Text + "'";
                        
                    }

                    WhereClause += " and RT.UserId=" + BusinessLayer.EmployeeLoginId_Static + "";

                    //string T = BusinessLayer.Department;
                    //if (BusinessLayer.Department_Static != "IT")
                  

                    if (string.IsNullOrEmpty(WhereClause))
                        WhereClause = string.Empty;

                    MainQuery = "select RT.TicketId as 'Ticket No',RT.EntryDate as 'Date',RT.EntryTime as 'Time',RT.DepartmentId,D.Department as 'Dept',RT.RaiseQuery as 'Query',RT.TicketType as 'Ticket Type',RT.AssignedTo,E.EmployeeName as 'Ticket by',L.LocationName as 'Location',D1.Department as 'Department',E1.EmployeeName as 'Assign To',RT.Priority,RT.Status,RT.Period,RT.ReplyAnswer as 'Reply',RT.Ratings,RT.SolvedPeriod from Ticket RT inner join departmentmaster D on D.DepartmentId=RT.DepartmentId inner join Employees E on E.EmployeeId=RT.UserId inner join locationmaster L on L.LocationId=E.LocationId inner join departmentmaster D1 on D1.DepartmentId=E.DepartmentId inner join Employees E1 on E1.EmployeeId=RT.AssignedTo where D.CancelTag=0 and E.CancelTag=0 and E1.CancelTag=0 and RT.CancelTag=0 ";
                    OrderByClause = " order by RT.EntryDate desc";

                    objBL.Query = MainQuery + UserClause + WhereClause + OrderByClause;
                    ds = objBL.ReturnDataSet();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //0 RT.TicketId as 'Ticket No',
                        //1 RT.EntryDate as 'Date',
                        //2 RT.EntryTime as 'Time',
                        //3 RT.DepartmentId,
                        //4 D.Department,
                        //5 RT.RaiseQuery as 'Query',
                        //6 RT.TicketType as 'Ticket Type',
                        //7 RT.AssignedTo,
                        //8 E.EmployeeName as 'Ticket by',
                        //9 L.LocationName as 'Location',
                        //10 D1.Department,
                        //11 E1.EmployeeName as 'Assign To',
                        //12 RT.Priority,
                        //13 RT.Status,
                        //14 RT.Period,
                        //15 RT.ReplyAnswer as 'Reply',
                        //16 RT.Ratings,
                        //17 RT.SolvedPeriod 
                         
                        lblTotalCount.Text = "Total Count-" + ds.Tables[0].Rows.Count;
                        dataGridView1.DataSource = ds.Tables[0];
                        //dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[3].Visible = false;
                        dataGridView1.Columns[4].Visible = false;
                        dataGridView1.Columns[7].Visible = false;
                        //dataGridView1.Columns[17].Visible = false;

                        dataGridView1.Columns[0].Width = 80;
                        dataGridView1.Columns[1].Width = 100;
                        dataGridView1.Columns[2].Width = 100;
                        
                        dataGridView1.Columns[5].Width = 200;
                        dataGridView1.Columns[6].Width = 110;
                        dataGridView1.Columns[8].Width = 200;
                        dataGridView1.Columns[9].Width = 100;
                        dataGridView1.Columns[10].Width = 100;
                        dataGridView1.Columns[11].Width = 200;
                        dataGridView1.Columns[12].Width = 120;
                        dataGridView1.Columns[13].Width = 120;
                        dataGridView1.Columns[14].Width = 120;
                        //dataGridView1.Columns[15].Width = 120;

                        foreach (DataGridViewRow Myrow in dataGridView1.Rows)
                        {            
                            string StatusD = objRL.CheckNullString(Convert.ToString(Myrow.Cells[13].Value));

                            if (StatusD == "Pending") 
                                Myrow.DefaultCellStyle.BackColor = Color.Yellow;
                            else if (StatusD == "Complete")
                                Myrow.DefaultCellStyle.BackColor = Color.LawnGreen;
                            else if (StatusD == "In Process")
                                Myrow.DefaultCellStyle.BackColor = Color.Aqua;
                            else if (StatusD == "Cancel")
                                Myrow.DefaultCellStyle.BackColor = Color.Red;
                            else
                            {
                                string hex = BusinessResources.BACKGROUND_COLOUR;
                                Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
                                Myrow.DefaultCellStyle.BackColor = _color;
                            }
                        }
                        dataGridView1.ClearSelection();
                    }
                }
                catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
                finally { GC.Collect(); }
            }
        }

        private void txtSearchQuery_TextChanged(object sender, EventArgs e)
        {
            IDFlag = false;

            if (txtSearchQuery.Text != "")
                SearchByName = true;
            else
                SearchByName = false;

            FillGrid();
        }

        private void Fill_DepartmentWise_Users()
        {
            if (cmbDepartment.SelectedIndex > -1)
            {
                if (cmbDepartment.Text == "TIME OFFICE")
                {
                    objRL.ColumnNameCM = "TicketTypeHR";
                    objRL.Fill_ComboBox_Comman(cmbTicketType);
                }
                else
                {
                    objRL.ColumnNameCM = "TicketType";
                    objRL.Fill_ComboBox_Comman(cmbTicketType);
                }

                Fill_Employee_ComboBox();
            }
        }

        private void cmbDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_DepartmentWise_Users();
        }
         
        private void Fill_Employee_ComboBox()
        {
            if (cmbDepartment.SelectedIndex > -1)
            {
                cmbAssignedTo.DataSource = null;
                objPC.DepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue);

                if (objPC.DepartmentId ==41)
                    objRL.Fill_Employee_TimeOffice_Ticket(cmbAssignedTo);
                else
                {
                    objPC.LocationId = 0;
                    
                    objRL.Get_LocationId_By_Department_LocationWiseDepartment();
                    objQL.SP_Employees_ComboBox_By_DepartmentId_LocationId_Without_Login(cmbAssignedTo);
                }
                
                if (TableId ==0)
                     FillGrid();
            }
        }

        private void btnAddTicketType_Click(object sender, EventArgs e)
        {
            objEP.Clear();
            if (cmbDepartment.SelectedIndex > -1)
            {
                if (cmbDepartment.Text == "TIME OFFICE")
                    objRL.ColumnNameCM = "TicketTypeHR";
                     
                else
                    objRL.ColumnNameCM = "TicketType";

                CommanMaster objForm = new CommanMaster(objRL.ColumnNameCM);
                objForm.ShowDialog(this);
                objRL.Fill_ComboBox_Comman(cmbTicketType);
            }
            else
            {
                objEP.SetError(cmbDepartment, "Select Department");
                cmbDepartment.Focus();
                objRL.ShowMessage(17, 4);
                return;
            }
            
        }
    }
}
