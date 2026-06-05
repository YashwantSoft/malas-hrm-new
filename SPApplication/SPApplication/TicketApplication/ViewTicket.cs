using BusinessLayerUtility;
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
    public partial class ViewTicket : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        AttendanceLogics objAL = new AttendanceLogics();
        PropertyClass objPC = new PropertyClass();

        //localhost.MyServices objWeb = new localhost.MyServices();

        string PSColumn = string.Empty, PSInnerJoinClause = string.Empty, PSInvoice = string.Empty, PSSC = string.Empty, PSSCHead = string.Empty;
        string MainQuery = string.Empty;
        string WhereClause = string.Empty;
        string OrderByClause = string.Empty;
        string UserClause = string.Empty;

        int TableId = 0;
        public ViewTicket()
        {
            InitializeComponent();
             
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_TICKETLIST);
            btnDelete.Text = BusinessResources.BTN_TICKETS;
            btnRefresh.BackgroundImage = BusinessResources.Refresh;
            lblSelected.BackColor = objDL.GetBackgroundColor();

            objRL.ColumnNameCM = "TicketStatus";
            objRL.Fill_ComboBox_Comman(cmbStatus);
            objRL.Fill_ComboBox_Comman(cmbStatusTicket);

            objRL.ColumnNameCM = "Priority";
            objRL.Fill_ComboBox_Comman(cmbPriority);

            //cmbStatus.Enabled = false;

            lblSelected.BackColor = objDL.GetBackgroundColor();
           // By_Default_Values();
            
            cmbDepartment.SelectedIndex = -1;
            cmbDepartment.Enabled = true;

            

            SetByDefault();
            ClearAllTicket();

        }

        private void FillDepartment_Employee()
        {
            objPC.ViewTicketFlag = true;
            objRL.Fill_Department_Ticket(cmbDepartment);

            if (BusinessLayer.Department == "TIME OFFICE" || BusinessLayer.Department == "INFORMATION TECHNOLOGY")
            {
                cmbDepartment.Text = BusinessLayer.Department.ToString();
                cmbDepartment.Enabled = false;
            }
            else
            {
                cmbDepartment.SelectedIndex = -1;
                cmbDepartment.Enabled = true;
            }

            Fill_Employee_ComboBox();
        }

        private void SetByDefault()
        {
            txtSearchTicketNo.Text = "";
            txtSearchEmployee.Text = "";
            cbToday.Checked = true;
            cmbPriority.Text = "High";
            cmbStatus.Text = "Pending";
            cmbPriority.Text = "Select All";
            cmbTicketType.Text = "Select All";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ClearAllTicket();
            txtSearchTicketNo.Text = "";
            txtSearchEmployee.Text = "";
            cbToday.Checked = true;
            cmbPriority.Text = "High";
            cmbStatus.Text = "Pending";
            gbTicket.Visible= false;
            FillGrid();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cbToday_CheckedChanged(object sender, EventArgs e)
        {
            if (cbToday.Checked)
            {
                dtpFromDate.Enabled = false;
                dtpToDate.Enabled = false;
                dtpFromDate.Value = DateTime.Now.Date;
                dtpToDate.Value = DateTime.Now.Date;
            }
            else
            {
                dtpFromDate.Enabled = true;
                dtpToDate.Enabled = true;
            }
        }

        private void ViewTicket_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        bool IDFlag = false;
        private void txtSearchTicketNo_TextChanged(object sender, EventArgs e)
        {
            SearchByName = false;

            if (txtSearchTicketNo.Text != "")
                IDFlag = true;
            else
                IDFlag = false;

            FillGrid();
        }

        private void txtSearchEmployee_TextChanged(object sender, EventArgs e)
        {
            IDFlag = false;

            if (txtSearchEmployee.Text != "")
                SearchByName = true;
            else
                SearchByName = false;

            FillGrid();
        }

        private void cbAssignToSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAssignToSelectAll.Checked)
            {
                cmbAssignedTo.SelectedIndex = -1;
                cmbAssignedTo.Enabled = false;
            }
            else
                cmbAssignedTo.Enabled = true;

            FillGrid();
        }

        private void ClearAllTicket()
        {
            gbTicket.Visible = false;
            txtTicketNo.Text = "";
            txtAssignTo.Text = "";
            cbToday.Checked = true;
            dtpDate.Value = DateTime.Now.Date;
            dtpTime.Value = DateTime.Now;
            txtPriority.Text = "";
            txtTicketType.Text = "";
            txtQuery.Text = "";
            txtReply.Text = "";
            cmbStatusTicket.SelectedIndex = -1;
            txtSolvedPeriod.Text = "";

            cmbAssignedTo.SelectedIndex = -1;
            txtSearchTicketNo.Text = "";
            cmbPriority.SelectedIndex = -1;
            txtSearchEmployee.Text = "";
            cmbStatus.SelectedIndex = -1;
            cmbTicketType.SelectedIndex = -1;
            cmbTicketType.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            cmbStatus.Text = BusinessResources.LS_Pending;
            //cbAssignToSelectAll.Checked = true;
            FillDepartment_Employee();
        }

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

                ClearAllTicket();
                TableId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtTicketNo.Text = TableId.ToString();
                dtpDate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                dtpTime.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                txtDepartment.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value));
                txtLocation.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[9].Value));
                txtQuery.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[5].Value));

                //Set_Assign_To();
                Fill_DepartmentWise_Users();
                txtTicketType.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[6].Value));
                txtEmpName.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[8].Value));
                txtAssignTo.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[11].Value));
                txtPriority.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[12].Value));
                cmbStatusTicket.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[13].Value));
                txtPeriod.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[14].Value));
                txtReply.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[15].Value));
                txtRatings.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[13].Value));
                txtSolvedPeriod.Text = dataGridView1.Rows[e.RowIndex].Cells[17].Value.ToString();

                //txtTicketType.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                //txtAssignTo.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                
                //txtDepartment.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                //txtQuery.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                //txtPriority.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                //cmbStatusTicket.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                //txtPeriod.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
                //txtReply.Text = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
                //txtRatings.Text = dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString();
                
                
                //if (cmbRatings.SelectedIndex > -1)
                //    cmbRatings.Enabled = false;
                //else
                //{
                //    if (cmbStatus.Text == "Complete")
                //        cmbRatings.Enabled = true;
                //    else
                //        cmbRatings.Enabled = false;
                //}
                //EnableFalse();
                //cmbStatus.Enabled = false;

                //if (BusinessLayer.Department == "TIME OFFICE" || BusinessLayer.Department == "INFORMATION TECHNOLOGY")
                //{
                //    txtReply.Enabled = true;
                //    cmbStatus.Enabled = true;
                //    txtReply.ReadOnly = false;
                //}
                //else
                //    txtReply.Enabled = false;

                gbTicket.Visible = true;
            }
            catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
            finally { GC.Collect(); }

            //try
            //{
            //    //0 RT.ID
            //    //1 RT.EntryDate as [Date],
            //    //2 RT.EntryTime as [Time],
            //    //3 RT.TicketType as [Ticket Type],
            //    //4 RT.AssignedTo,
            //    //5 L.EmployeeName as [Assign To],
            //    //6 RT.UserId,
            //    //7 L1.EmployeeName as [Emp Name],
            //    //8 L1.Department,
            //    //9 RT.RaiseQuery as [Query],
            //    //10 RT.Priority,
            //    //11 RT.Status,
            //    //12 RT.Period,
            //    //13 RT.ReplyAnswer as [Reply],
            //    //14 RT.Ratings

            //    ClearAllTicket();
            //    TableId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            //    txtTicketNo.Text = TableId.ToString();
            //    dtpDate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
            //    dtpTime.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            //    txtTicketType.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            //    txtAssignTo.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            //    txtEmpName.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            //    txtDepartment.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            //    txtQuery.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            //    txtPriority.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            //    cmbStatusTicket.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
            //    txtPeriod.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
            //    txtReply.Text = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
            //    txtRatings.Text = dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString();
            //    txtSolvedPeriod.Text = dataGridView1.Rows[e.RowIndex].Cells[15].Value.ToString();
            //    gbTicket.Visible = true;
            //}
            //catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
            //finally { GC.Collect(); }
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

        private void Fill_Employee_ComboBox()
        {
            if (cmbDepartment.SelectedIndex > -1)
            {
                //cmbAssignedTo.DataSource = null;
                //objPC.LocationId = 0;
                //objPC.DepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue);
                //objRL.Get_LocationId_By_Department_LocationWiseDepartment();
                //objQL.SP_Employees_ComboBox_By_DepartmentId_LocationId_Without_Login(cmbAssignedTo);


                cmbAssignedTo.DataSource = null;
                objPC.DepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue);

                if (objPC.DepartmentId == 41)
                    objRL.Fill_Employee_TimeOffice_Ticket(cmbAssignedTo);
                else
                {
                    objPC.LocationId = 0;

                    objRL.Get_LocationId_By_Department_LocationWiseDepartment();
                    objQL.SP_Employees_ComboBox_By_DepartmentId_LocationId_Without_Login(cmbAssignedTo);
                }

                //if (TableId == 0)
                //    FillGrid();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtReply.Text = "";
            cmbStatusTicket.SelectedIndex = -1;
            txtSolvedPeriod.Text = "";
            txtRatings.Text = "";
            ClearAllTicket();
            cbAssignToSelectAll.Checked = true;
            FillGrid();
        }

        private void cmbStatusTicket_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbStatusTicket.SelectedIndex > -1)
            {
                if (cmbStatusTicket.Text == "Complete")
                {
                    var hours = (DateTime.Now- dtpTime.Value).TotalHours;
                    double value1 = Convert.ToDouble(hours);
                    value1 = Math.Round(value1, 2);
                    txtSolvedPeriod.Text = value1.ToString();
                }
                else
                {
                    txtSolvedPeriod.Text = "";
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateTickets();
        }

        private bool Validation()
        {
            objEP.Clear();
            if (txtReply.Text == "")
            {
                objEP.SetError(txtReply, "Enter Your Replay");
                txtReply.Focus();
                return true;
            }
            else if (cmbStatusTicket.SelectedIndex == -1)
            {
                objEP.SetError(cmbStatusTicket, "Select Status Ticket");
                cmbStatusTicket.Focus();
                return true;
            }
            else
                return false;
        }

        string TicketReply = string.Empty;
        private void UpdateTickets()
        {
            if (!Validation())
            {
                TicketReply = string.Empty;
                TicketReply = txtReply.Text;

                objBL.Query = "update Ticket set ReplyAnswer='" + TicketReply.Replace("'", "''") + "',Status='" + cmbStatusTicket.Text + "' where TicketId=" + TableId + " and CancelTag=0";
                if (objBL.Function_ExecuteNonQuery() > 0)
                {
                    objRL.ShowMessage(7, 1);
                }
            }
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbStatus.SelectedIndex > -1)
            {
                FillGrid();
            }
        }

        private void cmbAssignedTo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbAssignedTo.SelectedIndex > -1)
            {
                FillGrid();
            }
        }

        private void cmbPriority_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbPriority.SelectedIndex > -1)
            {
                FillGrid();
            }
        }

        private void cmbTicketType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(cmbTicketType.SelectedIndex >-1)
            {
                FillGrid();
            }    
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cbAssignToSelectAll.Checked = true;
            ClearAllTicket();
            FillGrid();
        }

        bool DateFlag = false;
        bool SearchByName = false;

        private void FillGrid()
        {
            //if (BusinessLayer.UserType_Static == "Admin" || BusinessLayer.UserType_Static == "HOD")
            //{
            //    DataSet ds = new DataSet();

            //    dataGridView1.DataSource = null;
            //    PSColumn = string.Empty;
            //    PSInnerJoinClause = string.Empty;
            //    PSInvoice = string.Empty;
            //    PSSC = string.Empty;
            //    PSSCHead = string.Empty;
            //    MainQuery = string.Empty;
            //    WhereClause = string.Empty;
            //    OrderByClause = string.Empty;
            //    UserClause = string.Empty;

            //    try
            //    {
            //        if (IDFlag)
            //            WhereClause += " and RT.ID=" + txtSearchTicketNo.Text + "";
            //        if (SearchByName)
            //            WhereClause += " and L1.EmployeeName like '%" + txtSearchEmployee.Text + "%'";
            //        if (DateFlag)
            //            WhereClause += " and RT.EntryDate between #" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATMMDDYYYY) + "# and #" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATMMDDYYYY) + "#";

            //        if (BusinessLayer.Department_Static != "IT")
            //            WhereClause += " and L1.Department='" + BusinessLayer.Department_Static + "'";

            //        if (!cbAssignToSelectAll.Checked)
            //        {
            //            if (cmbAssignedTo.SelectedIndex > -1)
            //                WhereClause += " and RT.AssignedTo=" + cmbAssignedTo.SelectedValue + "";
            //        }

            //        if (cmbPriority.SelectedIndex > -1)
            //        {
            //            if (cmbPriority.Text != "Select All")
            //                WhereClause += " and RT.Priority='" + cmbPriority.Text + "'";
            //        }

            //        if (cmbStatus.SelectedIndex > -1)
            //        {
            //            if (cmbStatus.Text != "Select All")
            //                WhereClause += " and RT.Status='" + cmbStatus.Text + "'";
            //        }

            //        if (cmbTicketType.SelectedIndex > -1)
            //        {
            //            if (cmbTicketType.Text != "Select All")
            //                WhereClause += " and RT.TicketType='" + cmbTicketType.Text + "'";
            //        }

            //        if (string.IsNullOrEmpty(WhereClause))
            //            WhereClause = string.Empty;

            //        MainQuery = "select RT.ID,RT.EntryDate as [Date],RT.EntryTime as [Time],RT.TicketType as [Ticket Type],RT.AssignedTo,L.EmployeeName as [Assign To],RT.UserId,L1.EmployeeName as [Emp Name],L1.Department,RT.RaiseQuery as [Query],RT.Priority,RT.Status,RT.Period,RT.ReplyAnswer as [Reply],RT.Ratings,RT.SolvedPeriod as [Sol Time] from (RaiseTicket RT inner join Login L on L.ID=RT.AssignedTo) inner join Login L1 on L1.ID=RT.UserId where L.CancelTag=0 and L1.CancelTag=0 and RT.CancelTag=0 ";
            //        OrderByClause = " order by RT.EntryDate desc";

            //        objBL.Query = MainQuery + UserClause + WhereClause + OrderByClause;
            //        ds = objBL.ReturnDataSet();

            //        if (ds.Tables[0].Rows.Count > 0)
            //        {
            //            //0 RT.ID
            //            //1 RT.EntryDate as [Date],
            //            //2 RT.EntryTime as [Time],
            //            //3 RT.TicketType as [Ticket Type],
            //            //4 RT.AssignedTo,
            //            //5 L.EmployeeName as [Assign To],
            //            //6 RT.UserId,
            //            //7 L1.EmployeeName as [Emp Name],
            //            //8 L1.Department,
            //            //9 RT.RaiseQuery as [Query],
            //            //10 RT.Priority,
            //            //11 RT.Status,
            //            //12 RT.Period,
            //            //13 RT.ReplyAnswer as [Reply],
            //            //14 RT.Ratings
            //            //15 RT.SolvedPeriod as [Sol Time]

            //            lblTotalCount.Text = "Total Count-" + ds.Tables[0].Rows.Count;
            //            dataGridView1.DataSource = ds.Tables[0];
            //            dataGridView1.Columns[0].Visible = false;
            //            dataGridView1.Columns[4].Visible = false;
            //            dataGridView1.Columns[6].Visible = false;
            //            dataGridView1.Columns[1].Width = 80;
            //            dataGridView1.Columns[2].Width = 80;
            //            dataGridView1.Columns[3].Width = 120;
            //            dataGridView1.Columns[4].Width = 120;
            //            dataGridView1.Columns[5].Width = 120;
            //            dataGridView1.Columns[6].Width = 120;
            //            dataGridView1.Columns[7].Width = 120;
            //            dataGridView1.Columns[8].Width = 120;
            //            dataGridView1.Columns[9].Width = 200;
            //            dataGridView1.Columns[10].Width = 120;
            //            dataGridView1.Columns[11].Width = 120;
            //            dataGridView1.Columns[12].Width = 120;
            //            dataGridView1.Columns[13].Width = 120;
            //            dataGridView1.Columns[14].Width = 120;
            //            dataGridView1.Columns[15].Width = 120;

            //            foreach (DataGridViewRow Myrow in dataGridView1.Rows)
            //            {    
            //                if (Convert.ToString(Myrow.Cells[11].Value) == "Pending") // < Convert.ToInt32(Myrow.Cells[1].Value))// Or your condition 
            //                    Myrow.DefaultCellStyle.BackColor = Color.Yellow;
            //                else if (Convert.ToString(Myrow.Cells[11].Value) == "Complete")
            //                {
            //                    Myrow.DefaultCellStyle.BackColor = Color.LawnGreen;
            //                }
            //                else if (Convert.ToString(Myrow.Cells[11].Value) == "In Process")
            //                {
            //                    Myrow.DefaultCellStyle.BackColor = Color.Aqua;
            //                }
            //                else if (Convert.ToString(Myrow.Cells[11].Value) == "Cancel")
            //                {
            //                    Myrow.DefaultCellStyle.BackColor = Color.Red;
            //                }
            //                else
            //                {
            //                    string hex = BusinessResources.BACKGROUND_COLOUR;
            //                    Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
            //                    Myrow.DefaultCellStyle.BackColor = _color;
            //                }
            //            }
            //        }
            //    }
            //    catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
            //    finally { GC.Collect(); }
            //}

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
                        WhereClause += " and E.EmployeeName like '%" + txtSearchEmployee.Text + "%'";
                    if (DateFlag)
                        WhereClause += " and RT.EntryDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";

                    //if (BusinessLayer.UserType == "User")

                    if (BusinessLayer.Department != "TIME OFFICE" && BusinessLayer.Department != "HR" && BusinessLayer.Department != "INFORMATION TECHNOLOGY")
                        WhereClause += " and RT.UserId=" + BusinessLayer.EmployeeLoginId_Static + "";

                    if (!cbAssignToSelectAll.Checked)
                    {
                        if (cmbAssignedTo.SelectedIndex > -1)
                            WhereClause += " and RT.AssignedTo=" + cmbAssignedTo.SelectedValue + "";
                    }

                    if (cmbPriority.SelectedIndex > -1)
                    {
                        if (cmbPriority.Text != "Select All")
                            WhereClause += " and RT.Priority='" + cmbPriority.Text + "'";
                    }

                    if (cmbStatus.SelectedIndex > -1)
                    {
                        if (cmbStatus.Text != "Select All")
                            WhereClause += " and RT.Status='" + cmbStatus.Text + "'";
                    }

                    if (cmbTicketType.SelectedIndex > -1)
                    {
                        if (cmbTicketType.Text != "Select All")
                            WhereClause += " and RT.TicketType='" + cmbTicketType.Text + "'";
                    }

                    //string T = BusinessLayer.Department;
                    //if (BusinessLayer.Department_Static != "IT")
                    WhereClause += " and D.Department='" + cmbDepartment.Text + "'";

                    if (string.IsNullOrEmpty(WhereClause))
                        WhereClause = string.Empty;

                    MainQuery = "select RT.TicketId as 'Ticket No',RT.EntryDate as 'Date',RT.EntryTime as 'Time',RT.DepartmentId,D.Department as 'Dept',RT.RaiseQuery as 'Query',RT.TicketType as 'Ticket Type',RT.AssignedTo,E.EmployeeName as 'Ticket by',L.LocationName as 'Location',D1.Department as 'Department',E1.EmployeeName as 'Assign To',RT.Priority,RT.Status,RT.Period,RT.ReplyAnswer as 'Reply',RT.Ratings,RT.SolvedPeriod from Ticket RT inner join departmentmaster D on D.DepartmentId=RT.DepartmentId inner join Employees E on E.EmployeeId=RT.UserId inner join locationmaster L on L.LocationId=E.LocationId inner join departmentmaster D1 on D1.DepartmentId=E.DepartmentId inner join Employees E1 on E1.EmployeeId=RT.AssignedTo where D.CancelTag=0 and E.CancelTag=0 and E1.CancelTag=0 and RT.CancelTag=0 and RT.FinancialYearId=" + objPC.FinancialYearId + " ";
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
    }
}
