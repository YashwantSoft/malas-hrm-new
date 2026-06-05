using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLayerUtility;
using System.IO;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using SPApplication.Master;
using SPApplication.Comman;

namespace SPApplication.OPD
{
    public partial class Appointment : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        ErrorProvider objEP = new ErrorProvider();
        RedundancyLogics objRL = new RedundancyLogics(); DesignLayer objDL = new DesignLayer();
        QueryLayer objQL = new QueryLayer();

        bool FlagDelete = false;
        int TableID = 0, Result= 0;
        int PatientId = 0;
        int RowCount = 0;

        bool MH_Value = false;
        Excel.Application myExcelApp;
        Excel.Workbooks myExcelWorkbooks;
        Excel.Workbook myExcelWorkbook;

        public Appointment()
        {
            InitializeComponent();
             objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_APPONTMENTS);
             objDL.SetPlusButtonDesign(btnAddPatient);
             objDL.SetPlusButtonDesign(btnAddPatient);
            lblTokenNumber.BackColor = objDL.GetBackgroundColor();
            lblTokenNumber.ForeColor = objDL.GetForeColor();
            btnRefresh.BackColor = objDL.GetBackgroundColor();
            btnRefresh.ForeColor = objDL.GetForeColor();
            dtpAppointmentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        }

        //private const int CS_DropShadow = 0x00020000;
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ClassStyle |= CS_DropShadow;
        //        return cp;
        //    }
        //}

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ClearAll()
        {
            objEP.Clear();
            gbRegisterPatientDetails.Visible = true;
            dtpAppointmentDate.Value = DateTime.Now;
            btnDelete.Enabled = false;
            ClearPatient();
            txtSearchPatientGrid.Text = "";
            cbIsSpecial.Checked = false;
            GridFlag = false;
        }

        private void ClearDate()
        {
            dtpFromDate.Value = DateTime.Now.Date;
            dtpToDate.Value = DateTime.Now.Date;
        }

        private void ClearPatient()
        {
            txtPatientRegNo.Text = "";
            txtFullName.Text = "";
            txtAddress.Text = "";
            txtMobileNo.Text = "";
            txtSexAge.Text = "";
            txtPatientRegNo.Text = "";
            txtSearchPatientGrid.Text = "";
            cbIsSpecial.Checked = false;
            lbSearchPatient.Visible = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
            txtPatientSearch.Text = "";
            txtSearchID.Text = "";
            PatientId = 0;
            TableID = 0;
            ClearDate();
            cbToday.Checked = true;
            txtPatientSearch.Focus();
        }

        private void Appointment_Load(object sender, EventArgs e)
        {
            dtpAppointmentDate.CustomFormat = "dd/MM/yyyy hh:mm tt";
            cbToday.Checked = true;
            ClearAll();
            //objRL.Fill_Staff("Doctor", cmbDoctorName);
            Get_Token_Number();
            dtpAppointmentDate.Select();
        }

        private void Get_Token_Number()
        {
            lblTokenNumber.Text = "";
            TokenNumber = 0;
            DataSet ds = new DataSet();

            objQL.EntryDate = dtpAppointmentDate.Value;
            ds = objQL.SP_Appointment_Token_Number();

            //objBL.Query = "select MAX(TokenNumber) from Appointment where CancelTag=0 and EntryDate=#" + DateTime.Now.Date.ToString(RedundancyLogics.DateFormatMMDDYYYY) + "# ";
            
            //ds = objBL.ReturnDataSet();
            
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][0])))
                    TokenNumber = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) + 1;
                else
                    TokenNumber = 1;

                lblTokenNumber.Text = TokenNumber.ToString();
            }
        }

        private void txtPatientSearch_TextChanged(object sender, EventArgs e)
        {
            ClearPatient();
            if (txtPatientSearch.Text != "")
                Fill_Patient_ListBox();
            else
                lbSearchPatient.Visible = false;
        }

        private void Call_Patient_Details()
        {
            if (lbSearchPatient.Items.Count > 0)
            {
                PatientId = Convert.ToInt32(lbSearchPatient.SelectedValue);
                Fill_Patient_Details();
            }
        }

        private void Fill_Patient_ListBox()
        {
            lbSearchPatient.DataSource = null;
            DataSet ds = new DataSet();
            //objBL.Query = "select ID,EntryDate,PatientName,Address,MobileNumber,SexAge from Patient where CancelTag=0 and  PatientName like '%" + txtPatientSearch.Text + "%'  order by PatientName desc";
            //ds = objBL.ReturnDataSet();

            objQL.SearchText = txtPatientSearch.Text;
            objQL.PatientId = 0;
            ds = objQL.SP_Patinet_Select_by_PatientId_PatientName();

            if (ds.Tables[0].Rows.Count > 0)
            {
                lbSearchPatient.Visible = true;
                lbSearchPatient.DataSource = ds.Tables[0];
                lbSearchPatient.DisplayMember = "PatientName";
                lbSearchPatient.ValueMember = "ID";
                lbSearchPatient.SelectedIndex = -1;
            }
        }

        private void Fill_Patient_Details()
        {
            if (PatientId != 0)
            {
                DataSet ds = new DataSet();
                
                //objBL.Query = "select ID,EntryDate,PatientName,Address,MobileNumber,SexAge from Patient where CancelTag=0 and ID=" + PatientId + "";
                //ds = objBL.ReturnDataSet();

                objQL.SearchText = "";
                objQL.PatientId = PatientId;
                ds = objQL.SP_Patinet_Select_by_PatientId_PatientName();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    lbSearchPatient.Visible = false;
                    txtPatientRegNo.Text = ds.Tables[0].Rows[0]["ID"].ToString();
                    txtFullName.Text = ds.Tables[0].Rows[0]["PatientName"].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                    txtMobileNo.Text = ds.Tables[0].Rows[0]["MobileNumber"].ToString();
                    txtSexAge.Text = ds.Tables[0].Rows[0]["SexAge"].ToString();
                    lbSearchPatient.Visible = false;
                    btnSave.Focus();
                }
            }
        }

        private void lbSearchPatient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (lbSearchPatient.Items.Count > 0)
                    Call_Patient_Details();
            }

            if (e.KeyCode == Keys.Escape)
            {
                lbSearchPatient.Visible = false;
                txtPatientSearch.Focus();
            }
        }

        private void lbSearchPatient_Click(object sender, EventArgs e)
        {
            if (lbSearchPatient.Items.Count > 0)
                Call_Patient_Details();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Validation())
            {
                FlagDelete = false;
                SaveDB();
                FillGrid();
                ClearAll();
                txtPatientSearch.Text = "";
                PatientId = 0;
                TableID = 0;
                objRL.ShowMessage(7, 1);
                dtpAppointmentDate.Value = DateTime.Now;
                //Get_Token_Number();
                txtPatientSearch.Focus();
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }

        protected void SaveDB()
        {
            
            //if (TableID != 0)
            //    if (FlagDelete == true)
            //        objBL.Query = "update Appointment set CancelTag=1 where ID=" + TableID + "";
            //    else
            //        objBL.Query = "update Appointment set EntryDate='" + DateTime.Now.Date.ToString(objRL.SystemDateFormat) + "',IsRegister='" + Register + "',AD='" + dtpAppointmentDate.Value.ToString(objRL.SystemDateFormat) + "', AppointmentDate='" + dtpAppointmentDate.Value + "',PatientName='" + PatientName + "' ,Address='" + Address + "',Sex='" + Sex + "',MobileNumber='" + MobileNumber + "',CloseTag=1,UserId=" + BusinessLayer.UserId_Static + " where ID=" + TableID + "";
            //else
            //    objBL.Query = "insert into Appointment(EntryDate,IsRegister,AD,AppointmentDate,PatientName,Address,Sex,MobileNumber,CloseTag,UserId) values('" + DateTime.Now.Date.ToString(RedundancyLogics.DateFormatMMDDYYYY) + "','" + Register + "','" + dtpAppointmentDate.Value.ToString(objRL.SystemDateFormat) + "','" + dtpAppointmentDate.Value + "','" + PatientName + "' ,'" + Address + "','" + Sex + "','" + MobileNumber + "',0," + BusinessLayer.UserId_Static + ")";

            //objBL.Function_ExecuteNonQuery();

            if (cbIsSpecial.Checked)
                PatientType = "Special";
            else
                PatientType = "Regular";

            objQL.TableId = TableID;

            objQL.EntryDate = DateTime.Now.Date;
            objQL.TokenNumber = Convert.ToInt32(lblTokenNumber.Text);
            objQL.AppointmentDateTime = dtpAppointmentDate.Value;
            objQL.PatientId = Convert.ToInt32(PatientId);
            objQL.PatientType = PatientType;
            objQL.UserId = BusinessLayer.LoginId_Static;
            if(FlagDelete)
                objQL.DeleteFlag=1;
            else
                objQL.DeleteFlag=0;
              
            Result= objQL.SP_Appointment_Insert_Update_Delete();
            //PatientName = txtFullName.Text;
            //MobileNumber = txtMobileNo.Text;
            //Address = txtAddress.Text;
            //Sex = txtSexRegister.Text;

           

            //if (TableID != 0)
            //    if (FlagDelete == true)
            //        objBL.Query = "update Appointment set CancelTag=1 where ID=" + TableID + "";
            //    else
            //        objBL.Query = "update Appointment set EntryDate='" + DateTime.Now.Date.ToShortDateString() + "',TokenNumber=" + txtTokenNumber.Text + ",AppointmentDate='" + dtpAppointmentDate.Value + "',PatientId=" + PatientId + ",PatientType='" + PatientType + "',UserId=" + BusinessLayer.UserId_Static + " where ID=" + TableID + "";
            //else
            //    objBL.Query = "insert into Appointment(EntryDate,TokenNumber,AppointmentDate,PatientId,PatientType,UserId) values('" + DateTime.Now.Date.ToShortDateString() + "'," + txtTokenNumber.Text + ",'" + dtpAppointmentDate.Value + "'," + PatientId + ",'" + PatientType + "'," + BusinessLayer.UserId_Static + ")";

            //objBL.Function_ExecuteNonQuery();
        }

        int TokenNumber = 1;

        private bool Validation()
        {
            if (PatientId == 0)
            {
                objEP.SetError(txtPatientSearch, "Select Patient");
                txtPatientSearch.Focus();
                return true;
            }
            else if (txtFullName.Text == "")
            {
                objEP.SetError(txtPatientSearch, "Select Patient");
                txtPatientSearch.Focus();
                return true;
            }
            else
                return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!Validation())
            {
                DialogResult dr;
                dr = MessageBox.Show("Do yo want to delete this record", "Delete Record", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    FlagDelete = true;
                    SaveDB();
                    ClearAll();
                    FillGrid();
                    objRL.ShowMessage(9, 1);
                }
                else
                    ClearAll();
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }

        protected void FillGrid()
        {
            dgvAppointment.DataSource = null;
            DataSet ds = new DataSet();

            if(!string.IsNullOrEmpty(txtSearchPatientGrid.Text))
                objQL.SearchText = txtSearchPatientGrid.Text.ToString();

            objQL.SearchFlag = SearchFlag;
            objQL.FromDate =  dtpFromDate.Value;
            objQL.ToDate = dtpToDate.Value;

            //objQL.ToDate = Convert.ToDateTime(dtpToDate.Value.ToString(RedundancyLogics.DateFormatMMDDYYYY));

            ds = objQL.SP_Appointment_FillGrid();
            //DataSet ds = new DataSet();
            //if (!SearchFlag)
            //    objBL.Query = "select A.ID,A.EntryDate as Date,A.TokenNumber as Token Number,A.AppointmentDate as Appointment Date and Time,A.PatientId as [Patient ID],P.PatientName as [Patient Name],P.Address,P.MobileNumber as [Mobile No],P.SexAge,A.PatientType from Appointment A inner join Patient P on P.ID=A.PatientId where A.CancelTag=0 and P.CancelTag=0 and A.EntryDate between #" + dtpFromDate.Value.ToString(RedundancyLogics.DateFormatMMDDYYYY) + "# and #" + dtpToDate.Value.ToString(RedundancyLogics.DateFormatMMDDYYYY) + "# ";
            //else
            //    objBL.Query = "select A.ID,A.EntryDate as Date,A.TokenNumber as Token Number,A.AppointmentDate as Appointment Date and Time,A.PatientId as [Patient ID],P.PatientName as [Patient Name],P.Address,P.MobileNumber as [Mobile No],P.SexAge,A.PatientType from Appointment A inner join Patient P on P.ID=A.PatientId where A.CancelTag=0 and P.CancelTag=0 and A.EntryDate between #" + dtpFromDate.Value.ToString(RedundancyLogics.DateFormatMMDDYYYY) + "# and #" + dtpToDate.Value.ToString(RedundancyLogics.DateFormatMMDDYYYY) + "# and P.PatientName like '%" + txtSearchPatientGrid.Text + "%'  ";

            //ds = objBL.ReturnDataSet();
            {
                //0 A.ID,
                //1 A.AppointmentDate as "Appointment Date and Time",
                //2 A.TokenNumber as "Token#",
                //3 A.PatientId as "Patient ID",
			    //4 P.PatientName as "Patient Name",
          	    //5 P.SexAge as "Sex/Age",
                //6 A.PatientType as "Patient Type",
			    //7 P.MobileNumber as "Mobile",
                //8 P.Address,
			    //9 A.EntryDate as "Reg. Date",
			    //10 CONCAT(A.TokenNumber, '-' , P.PatientName) as 'ConcatAll'

                dgvAppointment.DataSource = ds.Tables[0];
                //dataGridView1.DataSource = ds.Tables[0];

                lblTotalCount.Text = "Total Appointments-" + ds.Tables[0].Rows.Count;

                dgvAppointment.Columns[0].Visible = false;
                dgvAppointment.Columns[10].Visible = false;
                dgvAppointment.Columns[11].Visible = false;
                dgvAppointment.Columns[1].Width = 160;
                dgvAppointment.Columns[2].Width = 60;
                dgvAppointment.Columns[3].Width = 60;
                dgvAppointment.Columns[4].Width = 220;
                dgvAppointment.Columns[5].Width = 80;
                dgvAppointment.Columns[6].Width = 80;
                dgvAppointment.Columns[7].Width = 100;
                dgvAppointment.Columns[8].Width = 150;

                dgvAppointment.DefaultCellStyle.SelectionBackColor = objDL.GetBackgroundColor();
                //dgvAppointment.ColumnHeadersDefaultCellStyle.BackColor = objRL.GetBackgroundColor();
                dgvAppointment.RowHeadersDefaultCellStyle.BackColor = objDL.GetBackgroundColor();


                for (int i = 0; i < dgvAppointment.Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(dgvAppointment.Rows[i].Cells[11].Value)))
                    {
                        if (Convert.ToBoolean(dgvAppointment.Rows[i].Cells[11].Value) == true)
                            dgvAppointment.Rows[i].DefaultCellStyle.BackColor = Color.Lime;
                        //dgvAppointment.RowHeadersDefaultCellStyle.BackColor = Color.GreenYellow;
                    }
                        

                }
                //dgvAppointment.ColumnHeadersDefaultCellStyle.ForeColor = objRL.GetBackgroundColor();
                //dgvAppointment.ColumnHeadersDefaultCellStyle.BackColor = objRL.GetBackgroundColor();
                //dgvAppointment.RowHeadersDefaultCellStyle.BackColor = objRL.GetBackgroundColor();

                //dgvAppointment.Columns[1].HeaderCell.Style.BackColor = objRL.GetBackgroundColor();

                //DataGridViewColumn dataGridViewColumn = dgvAppointment.Columns[1];
                //dataGridViewColumn.HeaderCell.Style.BackColor = Color.Magenta;
                //dataGridViewColumn.HeaderCell.Style.ForeColor = Color.Yellow;
            }
        }

        bool FlagToday = false;

        private void cbToday_CheckedChanged(object sender, EventArgs e)
        {
            ClearDate();

            if (cbToday.Checked)
            {
                FlagToday = true;
                dtpFromDate.Enabled = false;
                dtpToDate.Enabled = false;
            }
            else
            {
                FlagToday = false;
                dtpFromDate.Enabled = true;
                dtpToDate.Enabled = true;
            }
            FillGrid();
        }

        bool GridFlag = false;

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            if (!GridFlag)
                FillGrid();
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            if (!GridFlag)
                FillGrid();
        }

        bool SearchFlag = false;

        private void etxtSearchPatientGrid_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchPatientGrid.Text != "")
                SearchFlag = true;
            else
                SearchFlag = false;

            FillGrid();
        }

        protected void DrawBorder(Excel.Range Functionrange)
        {
            Excel.Borders borders = Functionrange.Borders;
            //borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlBorderWeight.xlHairline;
            borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlBorderWeight.xlHairline;
            borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlBorderWeight.xlHairline;
            borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlBorderWeight.xlHairline;
            borders.Weight = 1D;
        }

        public int AFlag = 0;

        protected void Fill_Merge_Cell(string Cell1, string Cell2, object val1, Excel.Worksheet myExcelWorksheet, string SetValue)
        {
            //Cell1 = Cell1 + RowCount;
            //Cell2 = Cell2 + RowCount;
            //Excel.Range AlingRange1 = myExcelWorksheet.get_Range(Cell1, Cell2);
            //AlingRange1.Merge(val1);
            //myExcelWorksheet.get_Range(Cell1, Cell2).Formula = SetValue;

            //Excel.Range AlingRange2 = myExcelWorksheet.get_Range(Cell1, Cell2);
            //AlingRange2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            //AlingRange2.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //DrawBorder(AlingRange2);

            //if (MH_Value == true)
            //    AlingRange2.RowHeight = 60;

            Cell1 = Cell1 + RowCount;
            Cell2 = Cell2 + RowCount;
            Microsoft.Office.Interop.Excel.Range AlingRange1 = myExcelWorksheet.get_Range(Cell1, Cell2);
            AlingRange1.Merge(val1);
            myExcelWorksheet.get_Range(Cell1, Cell2).Formula = SetValue;

            Microsoft.Office.Interop.Excel.Range AlingRange2 = myExcelWorksheet.get_Range(Cell1, Cell2);

            if (AFlag == 0)
                AlingRange2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            if (AFlag == 1)
                AlingRange2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            if (AFlag == 2)
                AlingRange2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;

            DrawBorder(AlingRange2);

            if (MH_Value == true)
            {
                AlingRange2.RowHeight = 40;
                AlingRange2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                AlingRange2.WrapText = true;
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

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (dgvAppointment.Rows.Count > 0)
            {
                using (new CursorWait())
                {
                    // Perform some code that shows cursor


                    //0 A.ID,
                    //1 A.EntryDate,
                    //2 A.TokenNumber,
                    //3 A.AppointmentDate,
                    //4 A.PatientId,
                    //5 P.PatientName,
                    //6 P.Address,
                    //7 P.MobileNumber,
                    //8 P.SexAge
                    //9 A.Patient Type

                    //string PathSystem = System.Reflection.Assembly.GetEntryAssembly()..Location;

                    //string PathSystem = System.Reflection.Assembly.GetEntryAssembly().Location;

                    //string PathSystem = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

                    //string PathSystem = System.IO.Directory.GetCurrentDirectory();

                    //string[] PathSystem = System.IO.Directory.GetDirectories("ExcelFormat");

                    //string myExeDir = new FileInfo(Assembly.GetEntryAssembly().Location).Directory.ToString();

                    // string myExeDir = AppDomain.CurrentDomain.BaseDirectory +"ExcelFormat\\";

                    //string path = System.Reflection.Assembly.GetExecutingAssembly().Location;



                    RowCount = 4;
                    object misValue = System.Reflection.Missing.Value;
                    myExcelApp = new Excel.Application();
                    myExcelWorkbooks = myExcelApp.Workbooks;

                    objRL.ClearExcelPath();
                    objRL.isPDF = true;
                    objRL.Form_ExcelFileName = "Appointment.xlsx";
                    objRL.Form_ReportFileName = "Appointment-" + RedundancyLogics.OPD_RegistrationNo + "-";
                    objRL.Form_DestinationReportFilePath = "\\Appointment\\";
                    objRL.Path_Comman();

                    myExcelWorkbook = myExcelWorkbooks.Open(objRL.RL_DestinationPath, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue);
                    Excel.Worksheet myExcelWorksheet = (Excel.Worksheet)myExcelWorkbook.ActiveSheet;

                    //0 A.ID,
                    //1 A.AppointmentDate as "Appointment Date and Time",
                    //2 A.TokenNumber as "Token Number",
                    //3 A.PatientId as "Patient ID",
                    //4 P.PatientName as "Patient Name",
                    //5 P.SexAge as "Sex / Age",
                    //6 A.PatientType as "Patient Type",
                    //7 P.MobileNumber as "Mobile",
                    //8 P.Address,
                    //9 A.EntryDate as "Reg. Date",
                    //10 CONCAT(A.TokenNumber, '-' , P.PatientName) as 'ConcatAll'

                    myExcelWorksheet.get_Range("A3", misValue).Formula = "Appointment Date from: " + dtpFromDate.Value.ToString(RedundancyLogics.SystemDateFormat) + " to " + dtpToDate.Value.ToString(RedundancyLogics.SystemDateFormat);

                    Fill_Merge_Cell("A", "A", misValue, myExcelWorksheet, "Token#");
                    Fill_Merge_Cell("B", "C", misValue, myExcelWorksheet, "App. Date & Time");
                    Fill_Merge_Cell("D", "D", misValue, myExcelWorksheet, "Patient ID");
                    Fill_Merge_Cell("E", "G", misValue, myExcelWorksheet, "Patient Name");
                    Fill_Merge_Cell("H", "H", misValue, myExcelWorksheet, "Sex/Age");
                    Fill_Merge_Cell("I", "I", misValue, myExcelWorksheet, "Patient Type");
                    Fill_Merge_Cell("J", "J", misValue, myExcelWorksheet, "Mobile");
                    Fill_Merge_Cell("K", "K", misValue, myExcelWorksheet, "");

                    RowCount++;

                    for (int i = 0; i < dgvAppointment.Rows.Count; i++)
                    {
                        Fill_Merge_Cell("A", "A", misValue, myExcelWorksheet, dgvAppointment.Rows[i].Cells[2].Value.ToString());
                        Fill_Merge_Cell("B", "C", misValue, myExcelWorksheet, dgvAppointment.Rows[i].Cells[1].Value.ToString());
                        Fill_Merge_Cell("D", "D", misValue, myExcelWorksheet, dgvAppointment.Rows[i].Cells[3].Value.ToString());
                        Fill_Merge_Cell("E", "G", misValue, myExcelWorksheet, dgvAppointment.Rows[i].Cells[4].Value.ToString());
                        Fill_Merge_Cell("H", "H", misValue, myExcelWorksheet, dgvAppointment.Rows[i].Cells[5].Value.ToString());
                        Fill_Merge_Cell("I", "I", misValue, myExcelWorksheet, dgvAppointment.Rows[i].Cells[6].Value.ToString());
                        Fill_Merge_Cell("J", "J", misValue, myExcelWorksheet, dgvAppointment.Rows[i].Cells[7].Value.ToString());
                        Fill_Merge_Cell("K", "K", misValue, myExcelWorksheet, "");
                        RowCount++;
                        //SRNO++;
                    }

                    RowCount++;
                    myExcelWorkbook.Save();

                    string PDFReport = objRL.RL_DestinationPath.Replace(".xlsx", ".pdf");
                    const int xlQualityStandard = 0;
                    myExcelWorkbook.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, PDFReport, xlQualityStandard, true, false, Type.Missing, Type.Missing, false, Type.Missing);
                    myExcelWorkbook.Close(true, misValue, misValue);
                    myExcelApp.Quit();

                    //objRL.ShowMessage(22, 1);

                    //DialogResult dr;
                    //dr = MessageBox.Show("Do you want to view this report", "Report View", MessageBoxButtons.YesNo);
                    //if (dr == DialogResult.Yes)
                    System.Diagnostics.Process.Start(PDFReport);
                    objRL.DeleteExcelFile();
                }
            }
        }

        private void btnAddDoctor_Click(object sender, EventArgs e)
        {
            Master.User objForm = new User();
            objForm.ShowDialog(this);
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            objRL.DCFlagClick = true;
            Patient objForm = new Patient();
            objForm.ShowDialog(this);

            PatientId = objRL.PatientId;
            Fill_Patient_Details();
        }

        string PatientType = "Regular";

        private void cbIsSpecial_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIsSpecial.Checked)
                PatientType = "Special";
            else
                PatientType = "Regular";
        }

        private void txtPatientSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (lbSearchPatient.Items.Count > 0)
                {
                    lbSearchPatient.SelectedIndex = 0;
                    lbSearchPatient.Focus();
                }
            }
        


        //lbSearchPatient.Focus();
        //    lbSearchPatient.SelectedIndex = 0;
            

            //if (e.KeyCode == Keys.Down)
            //{
            //    if (lbSearchPatient.Items.Count > 0)
            //    {
            //        lbSearchPatient.Focus();
            //        lbSearchPatient.SelectedIndex = 0;

            //    }
            //}

            //if (txtPatientSearch.Text == "")
            //    btnAddPatient.Focus();
        }

        int RowCount_Grid = 0, CurrentRowIndex = 0;

      
        private void txtSearchPatientGrid_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchPatientGrid.Text != "")
                SearchFlag = true;
            else
                SearchFlag = false;

            FillGrid();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            FillGrid();
        }

        bool SearchById = false;
        private void TxtSearchID_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TxtSearchID_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.NumericValue(sender, e, txtSearchID);
        }

        private void TxtSearchID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                ClearPatient();
                if (txtSearchID.Text != "")
                {
                    lbSearchPatient.Visible = false;
                    SearchById = true;
                    PatientId = Convert.ToInt32(txtSearchID.Text);
                    Fill_Patient_Details();
                }
            }
        }

        private void dtpAppointmentDate_ValueChanged(object sender, EventArgs e)
        {
            if(!GridFlag)
                Get_Token_Number();
        }

        private void dgvAppointment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                RowCount_Grid = dgvAppointment.Rows.Count;
                CurrentRowIndex = dgvAppointment.CurrentRow.Index;

                if (RowCount_Grid >= 0 && CurrentRowIndex >= 0)
                {
                    //0 A.ID,
                    //1 A.AppointmentDate as "Appointment Date and Time",
                    //2 A.TokenNumber as "Token#",
                    //3 A.PatientId as "Patient ID",
                    //4 P.PatientName as "Patient Name",
                    //5 P.SexAge as "Sex/Age",
                    //6 A.PatientType as "Patient Type",
                    //7 P.MobileNumber as "Mobile",
                    //8 P.Address,
                    //9 A.EntryDate as "Reg. Date",
                    //10 CONCAT(A.TokenNumber, '-' , P.PatientName) as 'ConcatAll'

                    ClearAll();
                    btnDelete.Enabled = true;
                    GridFlag = true;
                    TableID = Convert.ToInt32(dgvAppointment.Rows[e.RowIndex].Cells[0].Value);
                    dtpAppointmentDate.Value = Convert.ToDateTime(dgvAppointment.Rows[e.RowIndex].Cells[1].Value);
                    lblTokenNumber.Text = dgvAppointment.Rows[e.RowIndex].Cells[2].Value.ToString();
                    PatientId = Convert.ToInt32(dgvAppointment.Rows[e.RowIndex].Cells[3].Value.ToString());
                    Fill_Patient_Details();

                    PatientType = dgvAppointment.Rows[e.RowIndex].Cells[6].Value.ToString();

                    if (PatientType == "Special")
                        cbIsSpecial.Checked = true;
                    else
                        cbIsSpecial.Checked = false;

                    lblTokenNumber.Text = dgvAppointment.Rows[e.RowIndex].Cells[2].Value.ToString();
                }
            }
            catch (Exception ex1)
            {
                //objRL.ErrorMessge(ex1.ToString());
                return;
            }
            finally
            {
                GC.Collect();
            }
        }

       
    }
}
