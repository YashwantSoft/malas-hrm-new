using BusinessLayerUtility;
using Microsoft.Reporting.WinForms;
using SPApplication.AssetApplication;
using SPApplication.Authentication;
using SPApplication.ESSLUtility;
using SPApplication.HR;
using SPApplication.ListForms;
using SPApplication.Master;
using SPApplication.NewSoftware.Reports;
using SPApplication.Report;
using SPApplication.Report.AssetReport;
using SPApplication.Report.HRReports;
using SPApplication.Salary.Calculations;
using SPApplication.Salary.Master;
using SPApplication.Transaction;
using SPApplication.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using voucher;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace SPApplication
{
    public partial class MainDashboard : Form
    {
        private int childFormNumber = 0;

        BusinessLayer objBL = new BusinessLayer();
        ErrorProvider objEP = new ErrorProvider();
        DesignLayer objDL = new DesignLayer();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        RedundancyLogics objRL = new RedundancyLogics();

        public MainDashboard()
        {
            InitializeComponent();
            btnManpower.BackgroundImage = BusinessResources.Manpower;
            //btnManpower.ForeColor = objDL.GetForeColor();
            
            btnESSLData.BackgroundImage = BusinessResources.ESSLData;
            //btnMaster.BackgroundImage = BusinessResources.Masters;
            //btnLeaveList.BackgroundImage = BusinessResources.Transaction;
            //btnReport.BackgroundImage = BusinessResources.Reports;
            //btnSettings.BackgroundImage = BusinessResources.Settings;
            btnExit.BackgroundImage = BusinessResources.Exit;
            //pbProductLogo.BackgroundImage = BusinessResources.ClientLogo;
            //this.Icon = BusinessResources.MalasICO;

            //pbProductLogo.Image = BusinessResources.ClientLogo;
            //pbCompanyBackground.Image = BusinessResources.MalasBackgroud;
            //pbProductLogo.Image = BusinessResources.ClientLogo1;
            //this.Text = BusinessResources.COMPANYNAME;
            //this.Text = BusinessResources.COMPANYNAME1;

            if (BusinessResources.ProjectBy == "T")
            {
                //For T and T
                pbProductLogo.Image = BusinessResources.ClientLogo1;
                this.Text = BusinessResources.COMPANYNAME;
                pbCompanyBackground.Visible = false;

                //lblUser.Visible = true;
                //lblDesignation.Visible = true;
                //lblDepartment.Visible = true;
            }
            else
            {
                //For M
                this.Text = BusinessResources.COMPANYNAME1;
                pbProductLogo.Image = BusinessResources.ClientLogo;
                pbCompanyBackground.Image = BusinessResources.MalasBackgroud;
                lblUser.Visible = true;
                lblDesignation.Visible = true;
                lblDepartment.Visible = true;
            }

            SearchId = BusinessLayer.EmployeeLoginId_Static;

            VisibleTrueFalseButton(false);
        }

        int SearchId = 0;
        private void ShowNewForm(object sender, EventArgs e)
        {
            AddUser childForm = new AddUser();
            childForm.MdiParent = this;
            //childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }
        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
         
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaster_Click(object sender, EventArgs e)
        {
            MalasfruitMasters objForm = new MalasfruitMasters();
            objForm.Show();
        }

        int TicketPendingCount = 0;

        private void Get_Ticket_Count()
        {
            DataSet ds = new DataSet();
            objBL.Query = "select Count(T.TicketId) as 'TicketCount' from ticket T inner join departmentmaster DM on DM.DepartmentId=T.DepartmentId where DM.CancelTag=0 and T.CancelTag=0 and T.Status='Pending' and DM.Department='" + BusinessLayer.Department + "' ";
            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
            {
                TicketPendingCount = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["TicketCount"])));

                if (TicketPendingCount > 0)
                {
                    //if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR || BusinessLayer.UserType == BusinessResources.USER_TYPE_HROFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_HROFFICER)
                    if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR || BusinessLayer.UserType == BusinessResources.USER_TYPE_HROFFICER || BusinessLayer.Designation == "IT HEAD" || BusinessLayer.Department == "INFORMATION TECHNOLOGY")
                    {
                        btnViewTickets.Visible = true;
                        btnViewTickets.BackColor = Color.Yellow;
                        btnViewTickets.Text = "Pending Tickets-" + TicketPendingCount.ToString();
                    }
                    else
                        btnViewTickets.Visible = false;
                }
            }
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            objPC.FormName = string.Empty;
            lblUser.Text = "Welcome " + BusinessLayer.UserName_Full_Static;// + " | " + BusinessLayer.UserType;
            lblDepartment.Text = "Location|Department: " + BusinessLayer.LocationName + " | " + BusinessLayer.Department;
            lblDesignation.Text = "Designation: " + BusinessLayer.Designation;

            StartTimer();
            Get_Count_Leave_Approval();
            Get_UserRightsDetails();
            Get_Ticket_Count();
            BirthdayNotification();

            objRL.Fill_Financial_Year(cmbFinancialYear);
            objPC.FinancialYearId = Convert.ToInt32(cmbFinancialYear.SelectedValue);
            //Get_Attendance_Approval();

            //msMainMenu.BackColor = objDL.GetBackgroundColor();
            //msMainMenu.ForeColor = objDL.GetForeColor();
            //this.Icon = BusinessResources.MalasICO;

            // ADMIN', 'E1', '1', '0', '2023-05-24 11:30:30', '8', '2023-05-24 11:30:30'
            // CLEANER', 'C', '1', '0', '2023-05-24 12:14:12', NULL, '2023-05-24 12:14:12'

            // OFFICER', 'A+', '1', '0', '2023-05-19 13:24:52', NULL, '2023-05-19 13:24:52'
            // MANAGER', 'A++', '1', '0', '2023-05-19 13:24:52', NULL, '2023-05-19 13:24:52'
            // ASSISTANT', 'C', '1', '0', '2023-05-19 13:24:52', NULL, '2023-05-19 13:24:52'

            // INCHARGE', 'A+', '1', '0', '2023-05-19 13:24:52', NULL, '2023-05-19 13:24:52'
            // INCHARGE ASSISTANT', 'C', '1', '0', '2023-05-19 13:24:52', NULL, '2023-05-19 13:24:52'
            // SUPERVISOR', 'A', '1', '0', '2023-05-19 13:24:52', NULL, '2023-05-19 13:24:52'

            // OPERATOR', 'B', '1', '0', '2023-05-19 13:24:52', NULL, '2023-05-19 13:24:52'
            // WORKER', 'C', '1', '0', '2023-05-19 13:24:52', NULL, '2023-05-19 13:24:52'
            // TECHNICIAN', 'A', '1', '0', '2023-05-19 13:24:52', NULL, '2023-05-19 13:24:52'
            // HELPER', 'C', '1', '0', '2023-05-19 13:24:52', NULL, '2023-05-19 13:24:52'

            // LAB ASSISTANT', 'C', '1', '0', '2023-05-19 13:24:52', NULL, '2023-05-19 13:24:52'
            // FSMS CORDINATOR', 'E1', '8', '0', '2023-06-18 10:27:24', NULL, '2023-06-18 10:27:24'
            //'15', 'All'

            //mtsMaster.Enabled = false;
            //mtsAttendance.Enabled = false;
            //mtsMemo.Enabled = false;
            //mtsSettings.Enabled = false;
            //btnMaster.Enabled = false;
            //btnESSLData.Enabled = false;
            //btnSettings.Enabled = false;
            //btnReport.Enabled = false;

            //objPC.MenuName = "Master";
            //objRL.Get_UserRightsDetails();
            //if (objPC.ViewFlag == 1)
            //    mtsMaster.Enabled = true;
            //else
            //    mtsMaster.Enabled = false;

            //if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMIN || BusinessLayer.UserType == BusinessResources.USER_TYPE_CLEANER)
            //{
            //    mtsMaster.Enabled = true;
            //    mtsAttendance.Enabled = true;
            //    mtsMemo.Enabled = true;
            //    mtsSettings.Enabled = true;
            //    btnMaster.Enabled = true;
            //    btnESSLData.Enabled = true;
            //    btnSettings.Enabled = true;
            //    btnReport.Enabled = true;
            //}
            //else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_INCHARGE)
            //{
            //    masterToolStripMenuItem.Enabled = false;
            //    leaveManagementToolStripMenuItem.Enabled = true;
            //    settingsToolStripMenuItem.Enabled = true;
            //    reportsToolStripMenuItem.Enabled = true;
            //    btnMaster.Enabled = false;
            //    btnESSLData.Enabled = false;
            //    btnSettings.Enabled = true;
            //    btnReport.Enabled = true;
            //}
            //else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER || BusinessLayer.UserType == BusinessResources.USER_TYPE_OFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_INCHARGE)
            //{
            //    mtsMaster.Enabled = false;
            //    mtsAttendance.Enabled = false;
            //    mtsMemo.Enabled = false;
            //    mtsSettings.Enabled = false;
            //    btnMaster.Enabled = false;
            //    btnESSLData.Enabled = false;
            //    btnSettings.Enabled = true;
            //    btnReport.Enabled = true;
            //}
            //else
            //{
            //    mtsMaster.Enabled = false;
            //    mtsAttendance.Enabled = false;
            //    mtsMemo.Enabled = false;
            //    mtsSettings.Enabled = false;
            //    btnMaster.Enabled = false;
            //    btnESSLData.Enabled = false;
            //    btnSettings.Enabled = false;
            //    btnReport.Enabled = false;
            //}
            //else if (BusinessLayer.UserType != BusinessResources.USER_TYPE_OFFICER && BusinessLayer.UserType != BusinessResources.USER_TYPE_ADMIN)
            //{
            //    masterToolStripMenuItem.Enabled = false;
            //    leaveManagementToolStripMenuItem.Enabled = false;
            //    settingsToolStripMenuItem.Enabled = false;
            //    reportsToolStripMenuItem.Enabled = true;
            //    btnMaster.Enabled = false;
            //    btnESSLData.Enabled = false;
            //    btnSettings.Enabled = false;
            //    btnReport.Enabled = true;
            //}
            //else
            //{
            //    masterToolStripMenuItem.Enabled = true;
            //    leaveManagementToolStripMenuItem.Enabled = true;
            //    settingsToolStripMenuItem.Enabled = true;
            //    reportsToolStripMenuItem.Enabled = true;
            //    btnMaster.Enabled = true;
            //    btnESSLData.Enabled = true;
            //    btnSettings.Enabled = true;
            //    btnReport.Enabled = true;
            //}
        }

        string WhereClause=string.Empty, MainQuery=string.Empty, OrderBy = string.Empty;
        private void BirthdayNotification()
        {
            pBirthday.Visible = false;
            btnBirthdayNotification.BackColor = Color.White;
            btnBirthdayNotification.Text = "";
            WhereClause = string.Empty; MainQuery = string.Empty; OrderBy = string.Empty;
            DataSet ds = new DataSet();
            MainQuery = "select " +
                         "Count(E.EmployeeId) " +
                    " from " +
                        "Employees E inner join " +
                        "contractormaster CM on CM.ContractorId=E.ContractorId inner join " +
                        "employementtypemaster ETM on ETM.EmployementTypeId=E.EmployementTypeId inner join " +
                        "departmentmaster DM on DM.DepartmentId=E.DepartmentId inner join " +
                        "designationmaster DESM on DESM.DesignationId=E.DesignationId inner join " +
                        "categories CT on CT.CategoryId=E.CategoryId inner join " +
                        "locationmaster LM on LM.LocationId=E.LocationId  " +
                    " where " +
                        "E.CancelTag=0 and " +
                        "CM.CancelTag=0 and " +
                        "ETM.CancelTag=0 and " +
                        "DM.CancelTag=0 and " +
                        "DESM.CancelTag=0 and " +
                        "CT.CancelTag=0 and " +
                        "LM.CancelTag=0 and E.Status='WORKING' ";
             
                //WhereClause += " and " + objQL.Get_Location_Id("Location") + " ";
                //WhereClause += " and " + objQL.Get_Location_Id("Department");
                WhereClause += " and DAY(E.DOB)=DAY('" + DateTime.Now.Date.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "') and MONTH(E.DOB)=MONTH('" + DateTime.Now.Date.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "')"; // and Month(E.DOB)=" + dtpSearchDate.Value.Month + ""; //.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'"; // E.DOB='" + dtpSearchDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' ";

            OrderBy = "  ";
            //OrderBy = " order by E.DOB ";

            objBL.Query = MainQuery + WhereClause + OrderBy;
            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
            {
                int BirthdayCount = 0;

                BirthdayCount = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0][0])));

                if (BirthdayCount > 0)
                {
                    btnBirthdayNotification.BackColor = Color.Yellow;
                    btnBirthdayNotification.Text = BirthdayCount + "\n Birthday";

                    DataSet dsEmp=new DataSet();
                    WhereClause = string.Empty; MainQuery = string.Empty; OrderBy = string.Empty;

                    MainQuery = "select " +
                        " E.EmployeeId " +
                   " from " +
                       "Employees E inner join " +
                       "contractormaster CM on CM.ContractorId=E.ContractorId inner join " +
                       "employementtypemaster ETM on ETM.EmployementTypeId=E.EmployementTypeId inner join " +
                       "departmentmaster DM on DM.DepartmentId=E.DepartmentId inner join " +
                       "designationmaster DESM on DESM.DesignationId=E.DesignationId inner join " +
                       "categories CT on CT.CategoryId=E.CategoryId inner join " +
                       "locationmaster LM on LM.LocationId=E.LocationId  " +
                   " where " +
                       "E.CancelTag=0 and " +
                       "CM.CancelTag=0 and " +
                       "ETM.CancelTag=0 and " +
                       "DM.CancelTag=0 and " +
                       "DESM.CancelTag=0 and " +
                       "CT.CancelTag=0 and " +
                       "LM.CancelTag=0 ";

                    //WhereClause += " and " + objQL.Get_Location_Id("Location") + " ";
                    //WhereClause += " and " + objQL.Get_Location_Id("Department");
                    WhereClause += " and DAY(E.DOB)=DAY('" + DateTime.Now.Date.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "') and MONTH(E.DOB)=MONTH('" + DateTime.Now.Date.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "')"; // and Month(E.DOB)=" + dtpSearchDate.Value.Month + ""; //.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'"; // E.DOB='" + dtpSearchDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' ";
                    WhereClause += " and E.EmployeeId=" + BusinessLayer.EmployeeLoginId_Static + "";

                    OrderBy = "  ";


                    objBL.Query = MainQuery + WhereClause + OrderBy;
                    dsEmp = objBL.ReturnDataSet();
                    if(dsEmp.Tables[0].Rows.Count > 0 )
                    {
                        objPC.EmployeeId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dsEmp.Tables[0].Rows[0][0])));

                        if (objPC.EmployeeId == BusinessLayer.EmployeeLoginId_Static)
                        {
                            pBirthday.Visible = true;
                            btnBirthdayMessage.Text = "Happy Birthday " + BusinessLayer.UserName_Full_Static + ".!";
                        }
                    }
                }
            }
        }

        int PendingCount = 0, CompleteCount = 0, RemarkCount = 0;


        private void Get_Attendance_Approval()
        {
            string ConcatCount = string.Empty;
            PendingCount = 0; CompleteCount = 0; RemarkCount = 0;

            DataSet ds = new DataSet();

            PendingCount = objQL.SP_AttendanceRecordMaster_Count_Pending_Complete_Remark("Pending");
            CompleteCount = objQL.SP_AttendanceRecordMaster_Count_Pending_Complete_Remark("Complete");
            RemarkCount = objQL.SP_AttendanceRecordMaster_Count_Pending_Complete_Remark("Remark");

            if (PendingCount > 0 || RemarkCount > 0)
                btnAttendanceNotification.BackColor = Color.Yellow;
            else
                btnAttendanceNotification.BackColor = Color.Lime;

            ConcatCount = "Pending-" + PendingCount.ToString() + System.Environment.NewLine +
                          "Complete-" + CompleteCount.ToString() + System.Environment.NewLine +
                          "Remark-" + RemarkCount.ToString() + System.Environment.NewLine;

            btnAttendanceNotification.Text = ConcatCount.ToString();
        }

        System.Windows.Forms.Timer tmr = null;
        private void StartTimer()
        {
            tmr = new System.Windows.Forms.Timer();
            tmr.Interval = 1000;
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Enabled = true;
        }

        void tmr_Tick(object sender, EventArgs e)
        {
            lblDateTimeRunning.Text = DateTime.Now.ToString("dddd , dd/MMM/yyyy, hh:mm:ss tt");
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            MenuSettings objForm = new MenuSettings();
            objForm.Show();
        }

        private void btnESSLData_Click(object sender, EventArgs e)
        {
            ESSLData objForm = new ESSLData();
            objForm.ShowDialog(this);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ReportList objForm = new ReportList();
            objForm.ShowDialog(this);
        }

        private void employeeMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeMaster objForm = new EmployeeMaster();
            objForm.ShowDialog(this);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void leaveApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LeaveApplication objForm = new LeaveApplication();
            objForm.ShowDialog(this);
        }

        private void viewLeaveApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewLeaveApplication objForm = new ViewLeaveApplication();
            objForm.ShowDialog(this);
        }

        private void countryMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CountryMaster objForm = new CountryMaster();
            objForm.ShowDialog(this);
        }

        private void stateMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateMaster objForm = new StateMaster();
            objForm.ShowDialog(this);
        }

        private void districtMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DistrictMaster objForm = new DistrictMaster();
            objForm.ShowDialog(this);
        }

        private void talukaMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TalukaMaster objForm = new TalukaMaster();
            objForm.ShowDialog(this);
        }

        private void cityOrVillageMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CityVillageMaster objForm = new CityVillageMaster();
            objForm.ShowDialog(this);
        }

        private void areaMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AreaMaster objForm = new AreaMaster();
            objForm.ShowDialog(this);
        }

        private void contractorMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContractorMaster objForm = new ContractorMaster();
            objForm.ShowDialog(this);
        }

        private void locationMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocationMaster objForm = new LocationMaster();
            objForm.ShowDialog(this);
        }

        private void departmentMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DepartmentMaster objForm = new DepartmentMaster();
            objForm.ShowDialog(this);
        }

        private void designationMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DesignationMaster objForm = new DesignationMaster();
            objForm.ShowDialog(this);
        }

        private void shiftMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShiftMaster objForm = new ShiftMaster();
            objForm.ShowDialog(this);
        }

        private void categoryMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoryMaster objForm = new CategoryMaster();
            objForm.ShowDialog(this);
        }


        private void mtsESSLData_Click(object sender, EventArgs e)
        {
            ESSLData objForm = new ESSLData();
            objForm.ShowDialog(this);
        }


        string WhereClause_V = string.Empty;
        string LocQ = string.Empty;
        string DepQ = string.Empty;
        string ConcatCompOff = string.Empty; 
        int Count = 0;

        private void VisibleTrueFalseButton(bool Flag)
        {
            btnManpower.Visible = Flag;
            btnAttendanceNotification.Visible = Flag;
            btnViewLeaveApplication.Visible = Flag;
            btnViewCompOffApplication.Visible = Flag;
            btnViewTickets.Visible = Flag;
            btnESSLData.Visible = Flag;
        }

        private void Get_Count_Leave_Approval()
        {
            //ConcatCompOff = string.Empty;
            //Count = 0;

            //int HRCount = 0;
            //bool FlagShow = false;
            //string ConcatAttendance = string.Empty;

            //SearchId = BusinessLayer.EmployeeLoginId_Static;
            //LocQ = string.Empty;
            //DepQ = string.Empty;

            //DataSet ds = new DataSet();
            ////objBL.Query = "select count(LA.*) from LeaveApplication LA inner join Employees E on E.EmployeeId=LA.EmployeeId where LA.CancelTag=0 and E.CancelTag=0 and LA.LeaveStatus='" + BusinessResources.LS_Pending + "'";

            ////if (BusinessLayer.UserType == BusinessResources.USER_TYPE_INCHARGE)
            ////    WhereClause_V = " and lwd.InchargeId=" + SearchId + " ";
            ////else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER)
            ////    WhereClause_V = " and lwd.PlantHeadId=" + SearchId + " ";
            ////else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMIN)
            ////    WhereClause_V = "";
            ////else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_OFFICER)
            ////    FlagShow = true;
            ////else
            ////{
            ////    FlagShow = false;
            ////    //objRL.ShowMessage(38, 4);
            ////    //return;
            ////}

            //FlagShow = false;
            //if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR || BusinessLayer.UserType == BusinessResources.USER_TYPE_HROFFICER)
            //{
            //    objQL.WhereClause_V = "";
            //    ConcatAttendance = "Pending-" + GetCount(BusinessResources.LS_Pending) + System.Environment.NewLine;
            //    HRCount = GetCount(BusinessResources.LS_HRApproved);
            //    ConcatAttendance += "HR Approved-" + HRCount + System.Environment.NewLine;
            //    ConcatAttendance += "Incharge Approved-" + GetCount(BusinessResources.LS_InchargeApproved) + System.Environment.NewLine;
            //    ConcatAttendance += "Manager Approved-" + GetCount(BusinessResources.LS_ManagerApproved) + System.Environment.NewLine;
            //    ConcatAttendance += "Completed-" + GetCount(BusinessResources.LS_Completed) + System.Environment.NewLine;
            //    ConcatAttendance += "Remarks-" + GetCount(BusinessResources.LS_Remarks) + System.Environment.NewLine;
            //}
            //else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER)
            //{
            //    objQL.WhereClause_V = " and lwd.PlantHeadId=" + BusinessLayer.EmployeeLoginId_Static + " ";
            //    //ConcatAttendance = "Pending-" + GetCount(BusinessResources.LS_Pending) + System.Environment.NewLine;

            //    HRCount = GetCount(BusinessResources.LS_HRApproved);
            //    // ConcatAttendance += "HR Approved-" + HRCount + System.Environment.NewLine;

            //    ConcatAttendance += "Incharge Approved-" + GetCount(BusinessResources.LS_InchargeApproved) + System.Environment.NewLine;
            //    //ConcatAttendance += "Manager Approved-" + GetCount(BusinessResources.LS_ManagerApproved) + System.Environment.NewLine;
            //    // ConcatAttendance += "Completed-" + GetCount(BusinessResources.LS_Completed) + System.Environment.NewLine;
            //    ConcatAttendance += "Remarks-" + GetCount(BusinessResources.LS_Remarks) + System.Environment.NewLine;
            //}
            //else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_SENIOROFFICER)
            //{
            //    objQL.WhereClause_V = " and lwd.InchargeId=" + BusinessLayer.EmployeeLoginId_Static + " ";
            //    HRCount = GetCount(BusinessResources.LS_HRApproved);
            //    //ConcatAttendance += "HR Approved-" + HRCount + System.Environment.NewLine;
            //    ConcatAttendance += "Pending-" + HRCount + System.Environment.NewLine;
            //    ConcatAttendance += "Incharge Approved-" + GetCount(BusinessResources.LS_InchargeApproved) + System.Environment.NewLine;
            //    //ConcatAttendance += "Manager Approved-" + GetCount(BusinessResources.LS_ManagerApproved) + System.Environment.NewLine;
            //    ConcatAttendance += "Completed-" + GetCount(BusinessResources.LS_Completed) + System.Environment.NewLine;
            //    ConcatAttendance += "Remarks-" + GetCount(BusinessResources.LS_Remarks) + System.Environment.NewLine;
            //}
            //else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_OFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_SUPERVISOR)
            //    FlagShow = true;

            //if (!FlagShow)
            //{
            //    string LDQuery = "select distinct lwd.LocationId from locationwisedepartmentusers lwd inner join locationmaster lm on lm.LocationId=lwd.LocationId where lwd.CancelTag=0 and lm.CancelTag=0 ";
            //    LocQ = LDQuery + objQL.WhereClause_V + " order by lwd.LocationId ";

            //    string DDQuery = "select distinct lwd.DepartmentId from locationwisedepartmentusers lwd inner join DepartmentMaster lm on lm.DepartmentId=lwd.DepartmentId where lwd.CancelTag=0 and lm.CancelTag=0 ";
            //    DepQ = DDQuery + objQL.WhereClause_V + " order by lwd.DepartmentId ";

            //    //objBL.Query = "select count(*) from LeaveApplication LA inner join Employees E on E.EmployeeId=LA.EmployeeId inner join locationmaster lm on lm.LocationId=E.LocationId inner join DepartmentMaster dm on DM.DepartmentId=E.DepartmentId where dm.CancelTag=0 and lm.CancelTag=0 and LA.CancelTag=0 and E.CancelTag=0 and LA.LeaveStatus='" + BusinessResources.LS_Pending + "' " + objRL.WhereClasuse_CompOff_Comman() + "";  // and E.LocationId IN (" + LocQ + ") and E.DepartmentId IN(" + DepQ + ") ";
            //    objBL.Query = "select count(*) from LeaveApplication LA inner join Employees E on E.EmployeeId=LA.EmployeeId inner join locationmaster lm on lm.LocationId=E.LocationId inner join DepartmentMaster dm on DM.DepartmentId=E.DepartmentId inner join locationwisedepartmentusers LWDU on LM.LocationId=LWDU.LocationId and DM.DepartmentId=LWDU.DepartmentId  where dm.CancelTag=0 and lm.CancelTag=0 and LA.CancelTag=0 and E.CancelTag=0 " + objRL.WhereClasuse_CompOff_Comman() + " and LA.LeaveStatus='" + BusinessResources.LS_Pending + "' ";  // and E.LocationId IN (" + LocQ + ") and E.DepartmentId IN(" + DepQ + ") ";

            //    ds = objBL.ReturnDataSet();
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        Count = 0;
            //        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][0].ToString())))
            //            Count = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());

            //        if (Count > 0)
            //            btnViewLeaveApplication.BackColor = Color.Yellow;
            //        else
            //            btnViewLeaveApplication.BackColor = Color.Lime;

            //        btnViewLeaveApplication.Text = Count.ToString() + System.Environment.NewLine + "Leave Application";
            //    }

            //    DataSet dsCompOff = new DataSet();

            //    string ColumnSet = string.Empty;

            //    if (BusinessLayer.UserType == BusinessResources.USER_TYPE_HROFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR)
            //        ColumnSet = BusinessResources.LS_ManagerApproved;
            //    else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_PLANTHEAD || BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER || BusinessLayer.UserType == BusinessResources.USER_TYPE_SENIOROFFICER)
            //        ColumnSet = BusinessResources.LS_Pending;
            //    else
            //        ColumnSet = "";

            //    if (ColumnSet != "")
            //    {
            //        Count = 0;
            //        //objBL.Query = "select count(*) from compoffapplication COA inner join Employees E on E.EmployeeId=COA.EmployeeId inner join locationmaster lm on lm.LocationId=E.LocationId inner join DepartmentMaster dm on DM.DepartmentId=E.DepartmentId where dm.CancelTag=0 and lm.CancelTag=0 and COA.CancelTag=0 and E.CancelTag=0 and COA.CompStatus='" + ColumnSet + "' and E.LocationId IN (" + LocQ + ") and E.DepartmentId IN(" + DepQ + ") ";
            //        objBL.Query = "select count(*) from compoffapplication COA inner join Employees E on E.EmployeeId=COA.EmployeeId inner join locationmaster lm on lm.LocationId=E.LocationId inner join DepartmentMaster dm on DM.DepartmentId=E.DepartmentId  inner join locationwisedepartmentusers LWDU on LM.LocationId=LWDU.LocationId and DM.DepartmentId=LWDU.DepartmentId where dm.CancelTag=0 and lm.CancelTag=0 and COA.CancelTag=0 and E.CancelTag=0 and COA.CompStatus='Pending' " + objRL.WhereClasuse_CompOff_Comman() + ""; // and E.LocationId IN (" + LocQ + ") and E.DepartmentId IN(" + DepQ + ") ";

            //        dsCompOff = objBL.ReturnDataSet();
            //        if (dsCompOff.Tables[0].Rows.Count > 0)
            //        {
            //            if (!string.IsNullOrEmpty(Convert.ToString(dsCompOff.Tables[0].Rows[0][0].ToString())))
            //                Count = Convert.ToInt32(dsCompOff.Tables[0].Rows[0][0].ToString());

            //            if (Count > 0)
            //                btnViewCompOffApplication.BackColor = Color.Yellow;
            //            else
            //                btnViewCompOffApplication.BackColor = Color.Lime;

            //            ConcatCompOff = "CO Pending-" + Count.ToString();

            //            //btnViewCompOffApplication.Text = Count.ToString() + System.Environment.NewLine + "Comp Off Application";
            //        }
            //    }

            //    if (ColumnSet != "")
            //    {
            //        Count = 0;
            //        //objBL.Query = "select count(*) from compoffapplication COA inner join Employees E on E.EmployeeId=COA.EmployeeId inner join locationmaster lm on lm.LocationId=E.LocationId inner join DepartmentMaster dm on DM.DepartmentId=E.DepartmentId where dm.CancelTag=0 and lm.CancelTag=0 and COA.CancelTag=0 and E.CancelTag=0 and COA.CompStatus='" + ColumnSet + "' and E.LocationId IN (" + LocQ + ") and E.DepartmentId IN(" + DepQ + ") ";
            //        objBL.Query = "select count(*) from compoffapplication COA inner join Employees E on E.EmployeeId=COA.EmployeeId inner join locationmaster lm on lm.LocationId=E.LocationId inner join DepartmentMaster dm on DM.DepartmentId=E.DepartmentId  inner join locationwisedepartmentusers LWDU on LM.LocationId=LWDU.LocationId and DM.DepartmentId=LWDU.DepartmentId where dm.CancelTag=0 and lm.CancelTag=0 and COA.CancelTag=0 and E.CancelTag=0 and COA.CompUsedStatus='Pending' " + objRL.WhereClasuse_CompOff_Comman() + ""; // and E.LocationId IN (" + LocQ + ") and E.DepartmentId IN(" + DepQ + ") ";
            //        dsCompOff = objBL.ReturnDataSet();
            //        if (dsCompOff.Tables[0].Rows.Count > 0)
            //        {
            //            Count = 0;
            //            if (!string.IsNullOrEmpty(Convert.ToString(dsCompOff.Tables[0].Rows[0][0].ToString())))
            //                Count = Convert.ToInt32(dsCompOff.Tables[0].Rows[0][0].ToString());

            //            if (Count > 0)
            //                btnViewCompOffApplication.BackColor = Color.Yellow;
            //            else
            //                btnViewCompOffApplication.BackColor = Color.Lime;

            //            ConcatCompOff += "\n" + "COU Pending-" + Count;
            //            //btnViewCompOffApplication.Text = Count.ToString() + System.Environment.NewLine + "Comp Off Application";
            //        }
            //    }

            //    btnViewCompOffApplication.Text = ConcatCompOff.ToString();

            //    //ConcatAttendance = "Pending-" + GetCount(BusinessResources.LS_Pending) + System.Environment.NewLine;
            //    //ConcatAttendance += "HR Approved-" + GetCount(BusinessResources.LS_HRApproved) + System.Environment.NewLine;
            //    //ConcatAttendance += "Incharge Approved-" + GetCount(BusinessResources.LS_InchargeApproved) + System.Environment.NewLine;
            //    //ConcatAttendance += "Manager Approved-" + GetCount(BusinessResources.LS_ManagerApproved) + System.Environment.NewLine;
            //    //ConcatAttendance += "Completed-" + GetCount(BusinessResources.LS_Completed) + System.Environment.NewLine;
            //    //ConcatAttendance += "Remarks-" + GetCount(BusinessResources.LS_Remarks) + System.Environment.NewLine;

            //    btnAttendanceNotification.Text = ConcatAttendance.ToString();

            //    if (CountPlus > 0)
            //        btnAttendanceNotification.BackColor = Color.Yellow;
            //    else
            //        btnAttendanceNotification.BackColor = Color.Lime;

            //    if (BusinessLayer.UserType == BusinessResources.USER_TYPE_SENIOROFFICER)
            //    {
            //        if (HRCount > 0)
            //            btnAttendanceNotification.Enabled = true;
            //        else
            //            btnAttendanceNotification.Enabled = false;
            //    }
            //    else
            //        btnAttendanceNotification.Enabled = true;
            //}

            ////objQL.Fill_Location_By_EmployeeId(cmbLocation);

            ////ds = objQL.SP_LeaveApplication_Count();
            ////if (ds.Tables[0].Rows.Count > 0)
            ////{
            ////    int Count=0;
            ////    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][0].ToString())))
            ////        Count = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());

            ////    if (Count > 0)
            ////        btnLeaveList.BackColor = Color.Yellow;
            ////    else
            ////        btnLeaveList.BackColor = Color.Lime;

            ////    btnLeaveList.Text = Count.ToString() + System.Environment.NewLine + "Approval Pending";
            ////}


            ////string ConcatCount = string.Empty;
            ////PendingCount = 0; CompleteCount = 0; RemarkCount = 0;

            ////DataSet dsAttendance = new DataSet();

            ////PendingCount = objQL.SP_AttendanceRecordMaster_Count_Pending_Complete_Remark("Pending");
            ////CompleteCount = objQL.SP_AttendanceRecordMaster_Count_Pending_Complete_Remark("Complete");
            ////RemarkCount = objQL.SP_AttendanceRecordMaster_Count_Pending_Complete_Remark("Remark");

            ////if (PendingCount > 0 || RemarkCount > 0)
            ////    btnAttendanceNotification.BackColor = Color.Yellow;
            ////else
            ////    btnAttendanceNotification.BackColor = Color.Lime;

            ////ConcatCount = "Pending-" + PendingCount.ToString() + System.Environment.NewLine +
            ////              "Complete-" + CompleteCount.ToString() + System.Environment.NewLine +
            ////              "Remark-" + RemarkCount.ToString() + System.Environment.NewLine;

            ////btnAttendanceNotification.Text = ConcatCount.ToString();
        }

        string MenuNameUR = string.Empty;

        private void MenuTrueFalse(ToolStripMenuItem tsI, Button bt)
        {
            if (objPC.ViewFlag == 1)
            {
                bt.Enabled = true;
                bt.Visible = true;
                tsI.Visible = true;
            }
            else
            {
                bt.Enabled = false;
                bt.Visible = false;
                tsI.Visible = false;
            }
        }

        public void Get_UserRightsDetails()
        {
            objPC.UserRightsId = 0;
            objPC.MenuName = string.Empty;
            objPC.AddFlag = 0;
            objPC.EditFlagUR = 0;
            objPC.DeleteFlagUR = 0;
            objPC.ViewFlag = 0;
            objPC.ApprovalFlag = 0;

            mtsSettings.Visible = true;
            mtsMaster.Visible = false;

            mtsEmployeeProfile.Visible = false;

            //Attendance
            mtsAttendance.Visible = false;
            mtsOutdoorPunch.Visible = false;

            //Manpower Dashboard
             

            //Manpower Requisition
            mtsManpowerRequisition.Visible = false;

            //Memo
            mtsMemo.Visible = false;

            //mtsLetters
            mtsLetters.Visible = false;

            //Ticket Apps
            mtsRaiseTicket.Visible = false;
            mtsViewTickets.Visible = false;

            //Leave
            mtsLeaveApplication.Visible = false;
            mtsViewLeaveApplication.Visible = false;

            //Comp Off
            mtsCompOffApplication.Visible = false;
            mtsViewCompOffApplication.Visible = false;

            //Asset Apps
            //mtsAssetApps.Visible = false;
            mtsClientMachine.Visible = false;
            mtsAssetMaster.Visible = false;

            //Documents
            mtsDocuments.Visible = false;

            //Reports

            //Attendance Report
            mtsDailyAndMonthlyAttendanceReport.Visible = false;
            mtsIndividualUserAttendanceReport.Visible = false;
            //mtsLocationAndDepartmentWiseAttendanceReport.Visible = false;
            //mtsDurationWiseReport.Visible = false;
            mtsWorkingHoursReport.Visible = false;

            //Leave Report
            mtsLeaveReport.Visible = false;
            mtsLocationAndDepartmentWiseLeaveReport.Visible = false;
            mtsIndividualUserLeaveReport.Visible = false;

            //Comp Off Report
            mtsCompOffReport.Visible = false;
            mtsIndividualUserCompOffReport.Visible = false;
            mtsLocationAndDepartmentWiseCompOffReport.Visible = false;
            mtsCompOffDetailsReport.Visible = false;
            //OT Report 
            mtsOTApprovalReport.Visible = false;
            mtsOTApproval.Visible = false;

            //Asset Report
            mtsAssetReport.Visible = false;
            mtsOTReport.Visible = false;
            //
            mtsPunchReport.Visible = false;
            mtsBirthdayList.Visible = false;
            mtsManpowerReport.Visible = false;
            mtsMemoReport.Visible = false;

            //Change Password
            mtsChangePassword.Visible = false;

            //Settings
            mtsSettings.Visible = false;
            mtsESSLData.Visible = false;
            mtsCheckESSLAttendance.Visible = false;
            mtsLocationWiseDepartment.Visible = false;
            mtsLocationAndDepartmentWiseUsers.Visible = false;
            mtsAddUser.Visible = false;
            mtsUserRights.Visible = false;
            mtsDownloadTemplate.Visible = false;
            mtsImport.Visible = false;
            mtsExport.Visible = false;
            mtsRecalculate.Visible = false;
            mtsAttendanceSalaryReport.Visible = false;
            mtsAddComputer.Visible = false;

            //Exit
            mtsExit.Visible = true;

            //Buttons
            btnAttendanceNotification.Enabled = false;
            btnViewLeaveApplication.Enabled = false;
            btnESSLData.Enabled = false;
            btnViewCompOffApplication.Visible = false;
            btnAttendanceNotification.Visible = false;
            btnViewLeaveApplication.Visible = false;
            btnESSLData.Visible = false;
            btnSample.Visible = false;
            btnViewTickets.Visible = false;

            btnViewCompOffApplication.Visible = false;
            btnExit.Visible = true;

            VisibleTrueFalseButton(false);

            DataSet ds = new DataSet();
            objBL.Query = "select UserRightsId,EmployeeId,MenuName,AddFlag,EditFlag,DeleteFlag,ViewFlag,ApprovalFlag from userrights where CancelTag=0 and EmployeeId=" + BusinessLayer.EmployeeLoginId_Static + "";
            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    objPC.UserRightsId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["UserRightsId"])));
                    objPC.MenuName = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["MenuName"]));
                    objPC.AddFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["AddFlag"])));
                    objPC.EditFlagUR = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EditFlag"])));
                    objPC.DeleteFlagUR = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["DeleteFlag"])));
                    objPC.ViewFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["ViewFlag"])));
                    objPC.ApprovalFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["ApprovalFlag"])));

                    //Attendance
                    //Attendance Report
                    //Change Password
                    //Leave Application
                    //Manpower Requisition
                    //Master
                    //Memo
                    //Outdoor Punch
                    //Settings
                    //User Attendance
                    //User Attendance Report
                    //User Leave Report
                    //User Rights
                    //View Leave Application

                    //Master
                    if (objPC.MenuName == BusinessResources.Master_M)
                        MenuTrueFalse(mtsMaster, btnSample);
                    //Attendance
                    else if (objPC.MenuName == BusinessResources.Attendance_M)
                        MenuTrueFalse(mtsAttendance, btnAttendanceNotification);
                    else if (objPC.MenuName == BusinessResources.Outdoor_Punch_M)
                        MenuTrueFalse(mtsOutdoorPunch, btnSample);
                    //Manpower Dashboard
                    else if (objPC.MenuName == BusinessResources.Manpower_Dashboard_M)
                        MenuTrueFalse(mtsManpowerReport, btnManpower);
                    //Leave
                    else if (objPC.MenuName == BusinessResources.Leave_Application_M)
                        MenuTrueFalse(mtsLeaveApplication, btnSample);
                    else if (objPC.MenuName == BusinessResources.View_Leave_Application_M)
                        MenuTrueFalse(mtsViewLeaveApplication, btnViewLeaveApplication);

                    //Comp Off
                    else if (objPC.MenuName == BusinessResources.Comp_Off_Application_M)
                        MenuTrueFalse(mtsCompOffApplication, btnSample);
                    else if (objPC.MenuName == BusinessResources.View_Comp_Off_Application_M)
                        MenuTrueFalse(mtsViewCompOffApplication, btnViewCompOffApplication);

                    //Manpower Requisition
                    else if (objPC.MenuName == BusinessResources.Manpower_Requisition_M)
                        MenuTrueFalse(mtsManpowerRequisition, btnSample);

                    //Memo
                    else if (objPC.MenuName == BusinessResources.Memo_M)
                        MenuTrueFalse(mtsMemo, btnSample);

                    //Letters
                    else if (objPC.MenuName == BusinessResources.Letters_M)
                        MenuTrueFalse(mtsLetters, btnSample);

                    //Ticket Apps
                    else if (objPC.MenuName == BusinessResources.Raise_Ticket_M)
                        MenuTrueFalse(mtsRaiseTicket, btnSample);
                    else if (objPC.MenuName == BusinessResources.View_Tickets_M)
                        MenuTrueFalse(mtsViewTickets, btnViewTickets);

                    //Asset Apps
                    else if (objPC.MenuName == BusinessResources.Asset_Master_M)
                        MenuTrueFalse(mtsAssetMaster, btnSample);
                    else if (objPC.MenuName == BusinessResources.Client_Machine_M)
                        MenuTrueFalse(mtsClientMachine, btnSample);

                    //Documents
                    else if (objPC.MenuName == BusinessResources.Documents_M)
                        MenuTrueFalse(mtsDocuments, btnSample);

                    //Reports
                    //Attendance Report
                    else if (objPC.MenuName == BusinessResources.Daily_And_Monthly_Attendance_Report_M)
                        MenuTrueFalse(mtsDailyAndMonthlyAttendanceReport, btnSample);
                    else if (objPC.MenuName == BusinessResources.Individual_User_Attendance_Report_M)
                        MenuTrueFalse(mtsIndividualUserAttendanceReport, btnSample);
                    //else if (objPC.MenuName == BusinessResources.Location_And_Department_Wise_Attendance_Report_M)
                    //    MenuTrueFalse(mtsLocationAndDepartmentWiseAttendanceReport, btnSample);
                    //else if (objPC.MenuName == BusinessResources.Duration_Wise_Report_M)
                    //    MenuTrueFalse(mtsDurationWiseReport, btnSample);
                    else if (objPC.MenuName == BusinessResources.Working_Hours_Report_M)
                        MenuTrueFalse(mtsWorkingHoursReport, btnSample);
                    else if (objPC.MenuName == BusinessResources.AttendanceSalaryReport_M)
                        MenuTrueFalse(mtsAttendanceSalaryReport, btnSample);
                    //else if (objPC.MenuName == BusinessResources.OTReport_M)
                    //    MenuTrueFalse(mtsOTReport, btnSample);

                    

                    //Leave Report
                    else if (objPC.MenuName == BusinessResources.Leave_Report_M)
                        MenuTrueFalse(mtsLeaveReport, btnSample);
                    else if (objPC.MenuName == BusinessResources.Individual_User_Leave_Report_M)
                        MenuTrueFalse(mtsIndividualUserLeaveReport, btnSample);
                    else if (objPC.MenuName == BusinessResources.Location_And_Department_Wise_Leave_Report_M)
                        MenuTrueFalse(mtsLocationAndDepartmentWiseLeaveReport, btnSample);

                    //Comp Off Report
                    else if (objPC.MenuName == BusinessResources.Comp_Off_Report_M)
                        MenuTrueFalse(mtsCompOffReport, btnSample);
                    else if (objPC.MenuName == BusinessResources.Individual_User_Comp_Off_Report_M)
                        MenuTrueFalse(mtsIndividualUserCompOffReport, btnSample);
                    else if (objPC.MenuName == BusinessResources.Location_And_Department_Wise_Comp_Off_Report_M)
                        MenuTrueFalse(mtsLocationAndDepartmentWiseCompOffReport, btnSample);
                    else if (objPC.MenuName == "Comp Off Details Report")
                        MenuTrueFalse(mtsCompOffDetailsReport, btnSample);

                    //OT Report
                    else if (objPC.MenuName == BusinessResources.OT_Approval_M)
                        MenuTrueFalse(mtsOTApproval, btnSample);

                    else if (objPC.MenuName == "OT Approval Report")
                        MenuTrueFalse(mtsOTApprovalReport, btnSample);

                    //Asset Report
                    else if (objPC.MenuName == BusinessResources.Asset_Report_M)
                        MenuTrueFalse(mtsAssetReport, btnSample);

                    else if (objPC.MenuName == "Punch Report")
                        MenuTrueFalse(mtsPunchReport, btnSample);

                    else if (objPC.MenuName == "Birthday List")
                        MenuTrueFalse(mtsBirthdayList, btnBirthdayNotification);

                    else if (objPC.MenuName == "Memo Report")
                        MenuTrueFalse(mtsMemoReport, btnSample);
                        
                    //if(objPC.MenuName =="ESSL Data")
                    //{

                    //}

                    //Change Password
                    else if (objPC.MenuName == BusinessResources.Change_Password_M)
                        MenuTrueFalse(mtsChangePassword, btnSample);

                    //Settings
                    else if (objPC.MenuName == BusinessResources.ESSL_Data_M)
                        MenuTrueFalse(mtsESSLData, btnESSLData);
                    else if (objPC.MenuName == BusinessResources.Check_ESSL_Attendance_M)
                        MenuTrueFalse(mtsCheckESSLAttendance, btnSample);

                    //User's Setting
                    else if (objPC.MenuName == BusinessResources.Location_Wise_Department_M)
                        MenuTrueFalse(mtsLocationWiseDepartment, btnSample);
                    else if (objPC.MenuName == BusinessResources.Location_And_Department_Wise_Users_M)
                        MenuTrueFalse(mtsLocationAndDepartmentWiseUsers, btnSample);
                    else if (objPC.MenuName == BusinessResources.Add_User_M)
                        MenuTrueFalse(mtsAddUser, btnSample);
                    else if (objPC.MenuName == BusinessResources.User_Rights_M)
                        MenuTrueFalse(mtsUserRights, btnSample);
                    else if (objPC.MenuName == BusinessResources.Data_Backup_M)
                        MenuTrueFalse(mtsDataBackup, btnSample);
                    else if (objPC.MenuName == "Add Computer")
                        MenuTrueFalse(mtsAddComputer, btnSample);

                    //Template
                    else if (objPC.MenuName == BusinessResources.Download_Template_M)
                        MenuTrueFalse(mtsDownloadTemplate, btnSample);
                    else if (objPC.MenuName == BusinessResources.Import_M)
                        MenuTrueFalse(mtsImport, btnSample);
                    //else if (objPC.MenuName == BusinessResources.Export_M)
                    //    MenuTrueFalse(mtsExport, btnSample);
                    else if (objPC.MenuName == BusinessResources.Recalculate_M)
                        MenuTrueFalse(mtsRecalculate, btnSample);
                    else if (objPC.MenuName == BusinessResources.EmployeeProfile_M)
                        MenuTrueFalse(mtsEmployeeProfile, btnSample);
                    else 
                    {

                    }
                }

                if (BusinessLayer.Department == "TIME OFFICE")
                    mtsOTReport.Visible = true;

                if (BusinessLayer.Department == "TIME OFFICE")
                    mtsSalary.Visible = true;
            }

            if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR)
            {
                mtsSettings.Visible = true;
            }

            btnSample.Visible = false;
        }

        int CountPlus = 0;
        private int GetCount(string CheckType)
        {
            int CountSet = 0;
            DataSet ds = new DataSet();

            //objBL.Query = "select count(*) from attendancerecordmaster ARM where ARM.AStatus='" + CheckType + "' and " +
            //              "ARM.LocationId IN (select distinct lwd.LocationId from "+
            //              "locationwisedepartmentusers lwd inner join locationmaster lm on lm.LocationId=lwd.LocationId "+
            //              "where lwd.CancelTag=0 and lm.CancelTag=0 "+WhereClause_V+" order by lwd.LocationId ) and "+
            //              "ARM.DepartmentId IN(select distinct lwd.DepartmentId from locationwisedepartmentusers lwd inner join "+
            //              "DepartmentMaster lm on lm.DepartmentId=lwd.DepartmentId where lwd.CancelTag=0 and lm.CancelTag=0 "+
            //              ""+WhereClause_V+"  order by lwd.DepartmentId)";

            //objBL.Query = "select count(*) from attendancerecordmaster ARM inner join attendancestatusmaster asm on asm.AttendanceStatusId=arm.ApprovalStatusId where asm.AttendanceStatus='" + CheckType + "' and " +
            //              "ARM.LocationId IN (select distinct lwd.LocationId from " +
            //              "locationwisedepartmentusers lwd inner join locationmaster lm on lm.LocationId=lwd.LocationId " +
            //              "where lwd.CancelTag=0 and lm.CancelTag=0 " + WhereClause_V + " order by lwd.LocationId ) and " +
            //              "ARM.DepartmentId IN(select distinct lwd.DepartmentId from locationwisedepartmentusers lwd inner join " +
            //              "DepartmentMaster lm on lm.DepartmentId=lwd.DepartmentId where lwd.CancelTag=0 and lm.CancelTag=0 " +
            //              "" + WhereClause_V + " order by lwd.DepartmentId)";

            objPC.FlagC = 1;

            objBL.Query = "select count(*) from attendancerecordmaster ARM inner join attendancestatusmaster asm on asm.AttendanceStatusId=arm.ApprovalStatusId inner join  " +
                          " DepartmentMaster DM on DM.DepartmentId=ARM.DepartmentId inner join " +
                          " LocationMaster LM on LM.LocationId=ARM.LocationId inner join " +
                          " locationwisedepartmentusers LWDU on LM.LocationId=LWDU.LocationId and DM.DepartmentId=LWDU.DepartmentId " +
                          " where ARM.CancelTag=0 and LM.CancelTag=0 and DM.CancelTag=0 and LWDU.CancelTag=0 and asm.AttendanceStatus='" + CheckType + "' " + objRL.WhereClasuse_CompOff_Comman() + " ";

            //objBL.Query = "select count(*) from attendancerecordmaster ARM  inner join LocationMaster lm1 on ARM.LocationId=lm1.LocationId inner join DepartmentMaster dm1 on dm1.DepartmentId=ARM.DepartmentId inner join Employees E inner join locationmaster lm on lm.LocationId=E.LocationId inner join DepartmentMaster dm on DM.DepartmentId=E.DepartmentId where dm.CancelTag=0 and dm1.CancelTag=0 and lm.CancelTag=0 and lm1.CancelTag=0 and ARM.CancelTag=0 and E.CancelTag=0 and ARM.Status='" + CheckType + "' and E.LocationId IN (" + LocQ + ") and E.DepartmentId IN(" + DepQ + ") ";
            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][0].ToString())))
                {
                    CountSet = Convert.ToInt32(Convert.ToString(ds.Tables[0].Rows[0][0].ToString()));

                    if (CountSet > 0)
                    {
                        //if (CheckType == BusinessResources.LS_HRApproved)
                        CountPlus++;
                    }
                }
            objPC.FlagC = 0;
            return CountSet;
        }

        private void btnLeaveList_Click(object sender, EventArgs e)
        {
            ViewLeaveApplication objForm = new ViewLeaveApplication();
            objForm.ShowDialog(this);
            Get_Count_Leave_Approval();
        }

        private void companyProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompanyProfile objForm = new CompanyProfile();
            objForm.ShowDialog(this);
        }

        private void attendanceApprovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AttendanceWorking objForm = new AttendanceWorking();
            objForm.ShowDialog(this);
        }

        private void mtsAttendance_Click(object sender, EventArgs e)
        {
            Attendance objForm = new Attendance();
            objForm.ShowDialog(this);
        }

        private void attendanceWorkingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AttendanceWorkingNew objForm = new AttendanceWorkingNew();
            objForm.ShowDialog(this);
        }

        private void btnAttendanceNotification_Click(object sender, EventArgs e)
        {
            Attendance objForm = new Attendance();
            objForm.ShowDialog(this);
            Get_Count_Leave_Approval();
        }

        private void dailyAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DailyAndMonthlyAttendanceReport objForm = new DailyAndMonthlyAttendanceReport();
            objForm.ShowDialog(this);
        }

        private void changePasswordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ChangePassword objForm = new ChangePassword();
            objForm.ShowDialog(this);
        }

        private void shiftGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShiftGroupShifts objForm = new ShiftGroupShifts();
            objForm.ShowDialog(this);
        }

        private void shiftGroupMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShiftGroupMaster objForm = new ShiftGroupMaster();
            objForm.ShowDialog(this);
        }

        private void holidayMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HolidayMaster objForm = new HolidayMaster();
            objForm.ShowDialog(this);
        }

        private void employmentTypeMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeTypeMaster objForm = new EmployeeTypeMaster();
            objForm.ShowDialog(this);
        }

        private void leaveMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Leave_Master objForm = new Leave_Master();
            objForm.ShowDialog(this);
        }

        private void mtsAttendanceReport_Click(object sender, EventArgs e)
        {
            DailyAndMonthlyAttendanceReport objForm = new DailyAndMonthlyAttendanceReport();
            objForm.ShowDialog(this);
        }

        private void mtsLeaveApplication_Click(object sender, EventArgs e)
        {
            LeaveApplication objForm = new LeaveApplication();
            objForm.ShowDialog(this);
        }

        private void mtsViewLeaveApplication_Click(object sender, EventArgs e)
        {
            ViewLeaveApplication objForm = new ViewLeaveApplication();
            objForm.ShowDialog(this);
        }

        private void jobProfileMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JobProfileMaster objForm = new JobProfileMaster();
            objForm.ShowDialog(this);
        }

        private void memoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MemoAndLetters objForm = new MemoAndLetters();
            objForm.ShowDialog(this);
        }

        private void employeeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeEditMaster objForm = new EmployeeEditMaster();
            objForm.ShowDialog(this);
        }

        private void jobProfileMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            JobProfileMaster objForm = new JobProfileMaster();
            objForm.ShowDialog(this);
        }

        private void memoTemplateMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MemoTemplateMaster objForm = new MemoTemplateMaster();
            objForm.ShowDialog(this);
        }

        private void mtsOutdoorPunch_Click(object sender, EventArgs e)
        {
            OutdoorPunch objForm = new OutdoorPunch();
            objForm.ShowDialog(this);
        }

        private void shiftRotationMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShiftRotationMaster objForm = new ShiftRotationMaster();
            objForm.ShowDialog(this);
        }

        private void userRightsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UserRights objForm = new UserRights();
            objForm.ShowDialog(this);
        }

        private void mtsUserAttendance_Click(object sender, EventArgs e)
        {
            IndvisualUserAttendanceReport objForm = new IndvisualUserAttendanceReport();
            objForm.ShowDialog(this);
        }

        private void leaveReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objPC.ReportForm = "Leave Report";
            LeaveReport objForm = new LeaveReport();
            objForm.ShowDialog(this);
        }

        private void mtsCheckESSLAttendance_Click(object sender, EventArgs e)
        {
            CheckESSLAttendance objForm = new CheckESSLAttendance();
            objForm.ShowDialog(this);
        }

        private void documentMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DocumentsMaster objForm = new DocumentsMaster();
            objForm.ShowDialog(this);
        }

        private void mtsMemo_Click(object sender, EventArgs e)
        {
            objPC.FormName = "Memo";
            MemoAndLetters objForm = new MemoAndLetters();
            objForm.ShowDialog(this);
        }

        private void mtsLetters_Click(object sender, EventArgs e)
        {
            objPC.FormName = "Letter";
            MemoAndLetters objForm = new MemoAndLetters();
            objForm.ShowDialog(this);
        }

        private void mtsCompOffApplication_Click(object sender, EventArgs e)
        {
            CompOffApplication objForm = new CompOffApplication();
            objForm.ShowDialog(this);
        }

        private void compOffUsedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompOffApplication objForm = new CompOffApplication();
            objForm.ShowDialog(this);
        }

        private void btnTodaysStatus_Click(object sender, EventArgs e)
        {
            ManpowerDateWiseReport objForm = new ManpowerDateWiseReport();
            objForm.ShowDialog(this);
        }

        private void mtsViewCompOffApplication_Click(object sender, EventArgs e)
        {
            ViewCompOffApplication objForm = new ViewCompOffApplication();
            objForm.ShowDialog(this);
        }

        

        private void assetMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AssetMaster objForm = new AssetMaster();
            objForm.ShowDialog(this);
        }


        private void mtsRaiseTicket_Click(object sender, EventArgs e)
        {
            RaiseTicket objForm = new RaiseTicket();
            objForm.ShowDialog(this);
        }

        private void holidayListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDocuments("HolidayCalendar");
        }

        private void mtsViewTickets_Click(object sender, EventArgs e)
        {
            ViewTicket objForm = new ViewTicket();
            objForm.ShowDialog(this);
        }

        private void mtsAddUser_Click(object sender, EventArgs e)
        {
            AddUser objForm = new AddUser();
            objForm.ShowDialog(this);
        }

        private void mtsLocationWiseDepartment_Click(object sender, EventArgs e)
        {
            LocationWiseDepartment objForm = new LocationWiseDepartment();
            objForm.ShowDialog(this);
        }

        private void locationAndDepartmentWiseUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocationDepartmentWiseUsers objForm = new LocationDepartmentWiseUsers();
            objForm.ShowDialog(this);
        }

        private void mtsUserRights_Click(object sender, EventArgs e)
        {
            UserRights objForm = new UserRights();
            objForm.ShowDialog(this);
        }

        private void mtsDownloadTemplate_Click(object sender, EventArgs e)
        {
            objPC.FormName = "Template";
            ImportExportFacility objForm = new ImportExportFacility();
            objForm.ShowDialog(this);
        }

        private void mtsImport_Click(object sender, EventArgs e)
        {
            objPC.FormName = "Import";
            ImportExportFacility objForm = new ImportExportFacility();
            objForm.ShowDialog(this);
        }

        private void mtsExport_Click(object sender, EventArgs e)
        {
            objPC.FormName = "Export";
            ImportExportFacility objForm = new ImportExportFacility();
            objForm.ShowDialog(this);
        }
        private void mtsClientMachine_Click(object sender, EventArgs e)
        {
            AssetClient objForm = new AssetClient();
            objForm.ShowDialog(this);
        }

        private void mtsManpowerRequisition_Click(object sender, EventArgs e)
        {
            ManpowerRequisition objForm = new ManpowerRequisition();
            objForm.ShowDialog(this);
        }

        private void asignCompOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HolidayCompOffAsign objForm = new HolidayCompOffAsign();
            objForm.ShowDialog(this);
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            ViewTicket objForm = new ViewTicket();
            objForm.ShowDialog(this);
        }

        private void btnCompOffApplication_Click(object sender, EventArgs e)
        {
            ViewCompOffApplication objForm = new ViewCompOffApplication();
            objForm.ShowDialog(this);
            Get_Count_Leave_Approval();
        }

        private void mtsDataBackup_Click(object sender, EventArgs e)
        {
            DataBackup objForm = new DataBackup();
            objForm.ShowDialog(this);
        }

        private void mtsChangePassword_Click(object sender, EventArgs e)
        {
            ChangePassword objForm = new ChangePassword();
            objForm.ShowDialog(this);
        }

        private void mtsDailyAndMonthlyAttendanceReport_Click(object sender, EventArgs e)
        {
            DailyAndMonthlyAttendanceReport objForm = new DailyAndMonthlyAttendanceReport();
            objForm.ShowDialog(this);
        }

        private void mtsLocationAndDepartmentWiseAttendanceReport_Click(object sender, EventArgs e)
        {
            LocationDepartmentWiseAttendanceReport objForm = new LocationDepartmentWiseAttendanceReport();
            objForm.ShowDialog(this);
        }

        private void mtsAssetReport_Click(object sender, EventArgs e)
        {
            AssetReport objForm = new AssetReport();
            objForm.ShowDialog(this);
        }

        private void mtsDurationWiseReport_Click(object sender, EventArgs e)
        {
            DurationwiseReport objForm = new DurationwiseReport();
            objForm.ShowDialog(this);
        }

        private void mtsWorkingHoursReport_Click(object sender, EventArgs e)
        {
            WorkingHoursReport objForm = new WorkingHoursReport();
            objForm.ShowDialog(this);
        }

        private void mtsIndividualUserAttendanceReport_Click(object sender, EventArgs e)
        {
            IndvisualUserAttendanceReport objForm = new IndvisualUserAttendanceReport();
            objForm.ShowDialog(this);
        }

        private void mtsLocationAndDepartmentWiseLeaveReport_Click(object sender, EventArgs e)
        {
            objPC.ReportForm = "Leave Report";
            LocationDepartmentWiseLeaveReport objForm = new LocationDepartmentWiseLeaveReport();
            objForm.ShowDialog(this);
        }

        private void mtsIndividualUserLeaveReport_Click(object sender, EventArgs e)
        {
            objPC.ReportForm = "Leave Report";
            IndvisualUserLeaveReport objForm = new IndvisualUserLeaveReport();
            objForm.ShowDialog(this);
        }

        private void mtsCompOffReport_Click(object sender, EventArgs e)
        {
            objPC.ReportForm = "Comp Off";
            LeaveReport objForm = new LeaveReport();
            objForm.ShowDialog(this);
        }

        private void mtsIndividualUserCompOffReport_Click(object sender, EventArgs e)
        {
            objPC.ReportForm = "Comp Off";
            IndvisualUserLeaveReport objForm = new IndvisualUserLeaveReport();
            objForm.ShowDialog(this);
        }

        private void mtsLocationAndDepartmentWiseCompOffReport_Click(object sender, EventArgs e)
        {
            objPC.ReportForm = "Comp Off";
            LocationDepartmentWiseLeaveReport objForm = new LocationDepartmentWiseLeaveReport();
            objForm.ShowDialog(this);
        }

        private void mtsRecalculate_Click(object sender, EventArgs e)
        {
            Recalculate objForm = new Recalculate();
            objForm.ShowDialog(this);
        }

        private void mtsOTApproval_Click(object sender, EventArgs e)
        {
            OTApproval objForm = new OTApproval();
            objForm.ShowDialog(this);
        }

        private void mtsLeaveReport_Click(object sender, EventArgs e)
        {
            objPC.ReportForm = "Leave Report";
            LeaveReport objForm = new LeaveReport();
            objForm.ShowDialog(this);
        }

        private void attendanceSalaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AttendanceSalaryReport objForm = new AttendanceSalaryReport();
            objForm.ShowDialog(this);
        }

        private void mtsUpdateWizard_Click(object sender, EventArgs e)
        {
            UpdateWizard objForm = new UpdateWizard();
            objForm.ShowDialog(this);
        }

        private void countryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CountryMaster objForm = new CountryMaster();
            objForm.ShowDialog(this);
        }

        private void areaMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AreaMaster objForm = new AreaMaster();
            objForm.ShowDialog(this);
        }

        private void stateMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StateMaster objForm = new StateMaster();
            objForm.ShowDialog(this);
        }

        private void districtMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DistrictMaster objForm = new DistrictMaster();
            objForm.ShowDialog(this);
        }

        private void talukaMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TalukaMaster objForm = new TalukaMaster();
            objForm.ShowDialog(this);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CityVillageMaster objForm = new CityVillageMaster();
            objForm.ShowDialog(this);
        }

        private void shiftMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShiftMaster objForm = new ShiftMaster();
            objForm.ShowDialog(this);
        }

        private void shiftGroupMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShiftGroupMaster objForm = new ShiftGroupMaster();
            objForm.ShowDialog(this);
        }

        private void asignShiftGroupMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShiftGroupShifts objForm = new ShiftGroupShifts();
            objForm.ShowDialog(this);
        }

        private void btnBirthdayNotification_Click(object sender, EventArgs e)
        {
            BirthdayList objForm = new BirthdayList();
            objForm.ShowDialog(this);
        }

        private void purchReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ESSLPunchReport objForm = new ESSLPunchReport();
            objForm.ShowDialog(this);
        }

        private void birthdayListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BirthdayList objForm=new BirthdayList();
            objForm.ShowDialog(this);
        }

        private void outdoorPunchNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void employeeProfielToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeProfile objForm = new EmployeeProfile();
            objForm.ShowDialog(this);
        }

        private void memoReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MemoReport objForm = new MemoReport();
            objForm.ShowDialog(this);
        }

        private void compOffDetailsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompOffDetailsReport objForm = new CompOffDetailsReport();
            objForm.ShowDialog(this);
        }

        private void oTReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OTReport objForm = new OTReport();
            objForm.ShowDialog(this);
        }

        private void oTApprovalNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OTApprovalNew objForm = new OTApprovalNew();
            objForm.ShowDialog(this);
        }

        private void testDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestDB objForm = new TestDB();
            objForm.ShowDialog(this);
        }

        private void contractorWiseHeaderMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalaryConfigurations objForm = new SalaryConfigurations();
            objForm.ShowDialog(this);
        }

        private void salaryCalculationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalaryCalculations objForm = new SalaryCalculations();
            objForm.ShowDialog(this);
        }

        private void internshipPolicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDocuments("InternshipPolicy");
        }

        private void employeeLoanAdvancePolicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDocuments("EmployeeLoanAndAdvancePolicy");
        }

        private void staffAndSupervisorsUniformPolicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDocuments("StaffAndSupervisorsUniformPolicy");
        }

        private void employeeCheckOutExitPassPolicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDocuments("EmployeeCheckOutExitPassPolicy");
        }

        private void leavePolicyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start(ConfigurationManager.AppSettings["LeavePolicy"]);
            OpenDocuments("LeavePolicy");
        }

        private void OpenDocuments(string DocumentName)
        {
            System.Diagnostics.Process.Start(ConfigurationManager.AppSettings[DocumentName]);
        }

        private void workingHoursAndOvertimePolicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDocuments("WorkingHoursAndOvertimePolicy");
            
        }

        private void empoyeeCodeOfConductPolicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDocuments("EmpoyeeCodeOfConductPolicy");
            
        }

        private void retirmentPolicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDocuments("RetirmentPolicy");
            
        }

        private void productIntegrityAndConfidentialityPolicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDocuments("ProductIntegrityAndConfidentialityPolicy");
        }

        private void hygienePolicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDocuments("HygienePolicy");
        }

        private void violenceInTheWorkplacePolicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDocuments("ViolenceInTheWorkplacePolicy");
            
        }

        private void maternityPolicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDocuments("MaternityPolicy");
            
        }

        private void mobilePolicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDocuments("MobilePolicy");
            
        }

        private void tabbaccoPolicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDocuments("TabbaccoPolicy");
            
        }

        private void recruitmentPolicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDocuments("RecruitmentPolicy");
            
        }

        private void pOSHPreventionOfSexualHarassmentPolicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDocuments("POSHPreventionOfSexualHarassmentPolicy");
            
        }

        private void employeePaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeEarnings objForm = new EmployeeEarnings();
            objForm.ShowDialog(this);
        }

        private void employeeReceiptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeDeduction objForm = new EmployeeDeduction();
            objForm.ShowDialog(this);
        }

        private void salaryCasualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalaryCalculationsCasual objForm = new SalaryCalculationsCasual();
            objForm.ShowDialog(this);
        }

        private void eSSLNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ESSLDataNew objForm = new ESSLDataNew();
            objForm.ShowDialog(this);
        }

        private void attendanceNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AttendanceWorkingNew objForm=new AttendanceWorkingNew();    
            objForm.ShowDialog(this);
        }

        private void oTApprovalNewToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AttendanceOTApproval objForm = new AttendanceOTApproval();
            objForm.ShowDialog(this);
        }

        private void leaveNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LeaveApplicationNew objForm = new LeaveApplicationNew();
            objForm.ShowDialog(this);
        }

        private void compOffApplicationNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompOffApplicationNew objForm = new CompOffApplicationNew();
            objForm.ShowDialog(this);
        }

        private void compOffApplicationNewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CompOffApplicationNew objForm = new CompOffApplicationNew();
            objForm.ShowDialog(this);
        }

        private void outdoorPunchNewToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OutdoorPunchNew objForm = new OutdoorPunchNew();    
            objForm.ShowDialog(this);
        }

        private void outdoorPunchApprovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OutddorPunchApproval objForm = new OutddorPunchApproval();
            objForm.ShowDialog(this);
        }

        private void msMainMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void viewLeaveApplicationToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ViewLeaveApplication objForm = new ViewLeaveApplication();
            objForm.ShowDialog(this);
        }

        private void leaveNewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LeaveApplicationNew objForm = new LeaveApplicationNew();    
            objForm.ShowDialog(this);
        }

        private void attendanceNewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AttendanceWorkingNew objForm = new AttendanceWorkingNew();
            objForm.ShowDialog(this);
        }

        private void compOffApplicationNewToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CompOffApplicationNew objForm = new CompOffApplicationNew();
            objForm.ShowDialog(this);
        }

        private void viewCompOffApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewCompOffApplication objForm = new ViewCompOffApplication();
            objForm.ShowDialog(this);
        }

        private void outdoorPunchNewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OutdoorPunchNew objForm = new OutdoorPunchNew();
            objForm.ShowDialog(this);
        }

        private void outdoorPunchApprovalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OutddorPunchApproval objForm = new OutddorPunchApproval();
            objForm.ShowDialog(this);
        }

        private void oTApprovalNewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //OTApprovalNew objForm = new OTApprovalNew();
            //objForm.ShowDialog(this);

            AttendanceOTApproval objForm = new AttendanceOTApproval();
            objForm.ShowDialog(this);
        }

        private void eSSLNewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ESSLDataNew objForm = new ESSLDataNew();
            objForm.ShowDialog(this);
        }

        private void attendanceReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AttendanceReport objForm = new AttendanceReport();
            objForm.ShowDialog(this);
        }

        private void employeeAttendanceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeAttendanceReport objForm = new EmployeeAttendanceReport();
            objForm.ShowDialog(this);
        }

        private void employeeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeReport objForm = new EmployeeReport();
            objForm.ShowDialog(this);
        }

        private void manpowerDateWiseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManpowerDateWiseReport objForm = new ManpowerDateWiseReport();
            objForm.ShowDialog(this);
        }

        private void addComputerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddComputer objForm = new AddComputer();
            objForm.ShowDialog(this);
        }

        private void cmbFinancialYear_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbFinancialYear.SelectedIndex > -1)
            {
                objPC.FinancialYearId = Convert.ToInt32(cmbFinancialYear.SelectedValue);
            }
        }

        private void financialYearMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FinancialYearMaster objForm = new FinancialYearMaster();
            objForm.ShowDialog(this);
        }
    }
}
