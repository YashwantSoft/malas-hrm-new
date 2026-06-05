using BusinessLayerUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Drawing.Imaging;
using System.Data.OleDb;
using System.Runtime.InteropServices;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using OfficeOpenXml;


namespace SPApplication.ESSLUtility
{
    public partial class ImportExportFacility : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        AttendanceLogics objAL = new AttendanceLogics();
        PropertyClass objPC = new PropertyClass();

        //bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        //int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0, Pending_Count = 0, HRApproved_Count = 0, InchargeApproved_Count = 0, ManagerApproved_Count = 0, Completed_Count = 0, Remarks_Count = 0, Reject_Count = 0, SelectedCount = 0, LocationId = 0;
        string FormName_Local = string.Empty;

        string ReportName = string.Empty;
        //int TotalExist = 0, TotalCount = 0, TotalNewArrival = 0;
        //int SrNo = 1;
        int rCnt = 0, Result = 0;
        int cCnt = 0;
        int rw = 0;
        int cl = 0;
        // int ProductiId = 0;

        string ProductType = string.Empty;
        string Status = string.Empty;
        //int StatusValue = 0;   //1 Exists   //0-New Product     //2-Spelling Error
        //static int GridRowCount;
        string WorksheetName = string.Empty;

        public ImportExportFacility()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_EDITATTENDANCE);
            objRL.ColumnNameCM = "ImportExportFor";
            objRL.Fill_ComboBox_Comman(cmbFor);
            Set_Form_Control();
            lblHeader.Text = FormName_Local.ToString();
        }

        private void Set_Form_Control()
        {
            FormName_Local = string.Empty;
            FormName_Local = objPC.FormName;
            //btnDownload.Visible = false;

            if (FormName_Local == "Template")
                btnDownload.Text = BusinessResources.BTN_DOWNLOAD;
            else if (FormName_Local == "Import")
                btnDownload.Text = BusinessResources.BTN_BROWSE;
            else if (FormName_Local == "Export")
            {
                btnDownload.Visible = false;
                btnDownload.Text = BusinessResources.BTN_DOWNLOAD;
            }
            else
            {
                btnDownload.Visible = false;
            }
        }

        private void EmployeeUploadExcelUtility_Load(object sender, EventArgs e)
        {
            //LBL_HEADER_EXCELUPLOADUTILITY
        }

        private void cmbFor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Fill_Template();
        }

        string TemplateFor = string.Empty;

        private void Fill_Template()
        {
            TemplateFor = string.Empty;

            if (cmbFor.SelectedIndex > -1)
            {
                TemplateFor = cmbFor.Text;

                if (FormName_Local == "Template")
                    Get_Path_Download();
                else if (FormName_Local == "Import")
                    //Get_File_Excel_Read();
                    Uploade_ExcelFile();
                else if (FormName_Local == "Export")
                {

                }
                else
                {

                }
            }
        }

        string FileName = string.Empty;
        string TemplatePath = string.Empty;
        string DestinationPath = string.Empty;

        private void Get_Path_Download()
        {
            try
            {
                TemplatePath = string.Empty;
                DestinationPath = string.Empty;
                FileName = string.Empty;

                if (TemplateFor == "Employee")
                    FileName = "Employee.csv";
                else if (TemplateFor == "Attendance")
                    FileName = "AttendanceTemplate.xlsx";
                else
                    FileName = string.Empty;

                if (FileName != "")
                {
                    TemplatePath = string.Empty;
                    TemplatePath = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["DownloadTemplate"] + "\\" + FileName;
                    DestinationPath = @"C:\Users\Developer\Downloads\" + FileName + "";
                    bool FlagCheck = File.Exists(DestinationPath);
                    objPC.DocumentPath = DestinationPath;
                    if (!FlagCheck)
                    {
                        File.Copy(TemplatePath, DestinationPath);
                        objRL.ShowMessage(41, 1);
                    }
                    else
                    {
                        objRL.ShowMessage(42, 4);
                        return;
                    }
                }
            }
            catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
            finally { }

            //SaveFileDialog sfd = new SaveFileDialog();
            //sfd.Filter = "Excel file |*.xls;*.xlsx;*.csv";
            //if (sfd.ShowDialog() == DialogResult.OK)
            //{
            //    //const string MyFileName = "Employee.csv";

            //    //string execPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);

            //    TemplatePath = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["DownloadTemplate"]; // +"\\" + FileName;

            //    var filePath = Path.Combine(TemplatePath, FileName);

            //    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            //    Microsoft.Office.Interop.Excel.Workbook book = app.Workbooks.Open(filePath);

            //    book.SaveAs(sfd.FileName); //Save   
            //    book.Close();
            //}

            ////if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            ////{
            ////    TemplatePath = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["DownloadTemplate"] + "\\" + FileName;
            ////    //TemplatePath = objRL.GetPath("TemplateFormat");
            ////    //TemplatePath = ConfigurationManager.AppSettings["DownloadTemplate"];
            ////    string sourcePath = Application.StartupPath;
            ////    File.Copy(TemplatePath, saveFileDialog1.FileName);


            ////}
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            using (new CursorWait())
            {
                //dataGridView2.ReadOnly = false;
                //if(dataGridView2.Rows.Count==0)
                //    dataGridView2.Rows.Add();

                ReadExcelData();
            }
            //Fill_Template();
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
        private void ReadExcelData()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
            openFileDialog.Title = "Select an Excel File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                List<object[]> excelData = ReadExcel(filePath);
                PopulateDataGridView(excelData);
            }
        }
        private List<object[]> ReadExcel(string filePath)
        {
            List<object[]> excelData = new List<object[]>();

            FileInfo fileInfo = new FileInfo(filePath);
            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Assuming data is on the first worksheet
                int TotalCount = worksheet.Dimension.End.Row;
                int RCOunt = worksheet.Dimension.Start.Row + 1;

                for (int row = RCOunt; row <= worksheet.Dimension.End.Row; row++)
                {
                    List<object> rowData = new List<object>();
                    for (int col = worksheet.Dimension.Start.Column; col <= worksheet.Dimension.End.Column; col++)
                    {
                        //row++;
                        var cellValue = worksheet.Cells[row, col].Value;
                        rowData.Add(cellValue);
                    }
                    excelData.Add(rowData.ToArray());
                }
                lblTotalCount.Text = TotalCount.ToString();
            }

            return excelData;
        }

        private void PopulateDataGridView(List<object[]> data)
        {
            dataGridView1.Rows.Clear(); // Clear existing rows if needed

            foreach (var row in data)
            {
                dataGridView1.Rows.Add(row);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        string SourcePath = string.Empty;

        private void Get_File_Excel_Read()
        {
            string filePath;
            FileName = string.Empty;
            SourcePath = string.Empty;
            DestinationPath = string.Empty;

            //OpenFileDialog opnfd = new OpenFileDialog();
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Files (*.xlsx;)|*.xlsx;";
            if (file.ShowDialog() == DialogResult.OK)
            {
                filePath = file.FileName;

                //var fileName = @"C:\ExcelFile.xlsx";
                //var fileName = @"C:\Users\Developer\Downloads\AttendanceTemplate.xlsx";
                //var connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties=\"Excel 4.0;IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text\""; ;

                string path = @"C:\Users\Developer\Downloads\AttendanceTemplate.xlsx";
                string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;";

                using (var conn = new OleDbConnection(connStr))
                {
                    conn.Open();

                    var sheets = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT * FROM [" + sheets.Rows[0]["TABLE_NAME"].ToString() + "] ";

                        var adapter = new OleDbDataAdapter(cmd);
                        var ds = new DataSet();
                        adapter.Fill(ds);
                    }
                }
            }
        }

        DateTime InDate_E, InTime_E, OutDate_E, OutTime_E, AttendanceDate_E;
        string Status_E = string.Empty;
        int EmployeeCode_E = 0;



        //private void Get_File()
        //{
        //    string filePath;
        //    FileName = string.Empty; SourcePath = string.Empty; DestinationPath = string.Empty;
        //    //OpenFileDialog opnfd = new OpenFileDialog();
        //    OpenFileDialog file = new OpenFileDialog();
        //    file.Filter = "Files (*.xlsx;)|*.xlsx;";
        //    if (file.ShowDialog() == DialogResult.OK)
        //    {
        //        //SourcePath = opnfd.FileName;
        //        FileName = Path.GetFileName(SourcePath);


        //        filePath = file.FileName;

        //        Excel.Application xlApp;
        //        Excel.Workbook xlWorkBook;
        //        Excel.Worksheet xlWorkSheet;
        //        Excel.Range range;

        //        xlApp = new Excel.Application();
        //        xlWorkBook = xlApp.Workbooks.Open(filePath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
        //        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
        //        WorksheetName = xlWorkSheet.Name.ToString();

        //        if (TemplateFor == "Attendance")
        //        {
        //            range = xlWorkSheet.UsedRange;
        //            rw = range.Rows.Count;
        //            cl = range.Columns.Count;
        //            cCnt = 5;

        //            for (rCnt = 2; rCnt <= rw; rCnt++)
        //            {
        //                EmployeeCode_E = 0;
        //                InTime_E = DateTime.Now.Date;
        //                OutTime_E = DateTime.Now.Date;
        //                AttendanceDate_E = DateTime.Now.Date;
        //                StatusCode_E = string.Empty;

        //                if(!string.IsNullOrEmpty(Convert.ToString(((range.Cells[rCnt, 1] as Excel.Range).Value2))))
        //                    EmployeeCode_E = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString((range.Cells[rCnt, 1] as Excel.Range).Value2)));
        //                if (!string.IsNullOrEmpty(Convert.ToString(((range.Cells[rCnt, 2] as Excel.Range).Value2))))
        //                    AttendanceDate_E = Convert.ToDateTime((range.Cells[rCnt, 2] as Excel.Range).Value2);
        //                if (!string.IsNullOrEmpty(Convert.ToString(((range.Cells[rCnt, 3] as Excel.Range).Value2))))
        //                    InTime_E = Convert.ToDateTime((range.Cells[rCnt, 3] as Excel.Range).Value2);
        //                if (!string.IsNullOrEmpty(Convert.ToString(((range.Cells[rCnt, 4] as Excel.Range).Value2))))
        //                    OutTime_E = Convert.ToDateTime((range.Cells[rCnt, 4] as Excel.Range).Value2);
        //                if (!string.IsNullOrEmpty(Convert.ToString(((range.Cells[rCnt, 1] as Excel.Range).Value2))))
        //                    StatusCode_E = objRL.CheckNullString(Convert.ToString((range.Cells[rCnt, 1] as Excel.Range).Value2));

        //                if (cCnt == 1)
        //                {
        //                    ProductName = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;

        //                    if (!string.IsNullOrEmpty(ProductName))
        //                    {
        //                        if (ProductName.Contains("Grand Total"))
        //                            break;
        //                    }
        //                }
        //            }
        //        }

        //        xlWorkBook.Close(true, null, null);
        //        xlApp.Quit();
        //        Marshal.ReleaseComObject(xlWorkSheet);
        //        Marshal.ReleaseComObject(xlWorkBook);
        //        Marshal.ReleaseComObject(xlApp);

        //        //if (dgvProduct.Rows.Count > 0)
        //        //{
        //        //    TotalCount = Convert.ToInt32(dgvProduct.Rows.Count.ToString());
        //        //    foreach (DataGridViewRow row in dgvProduct.Rows)
        //        //        if (Convert.ToInt32(row.Cells["clmStatusNo"].Value) == 0)
        //        //        {
        //        //            row.DefaultCellStyle.BackColor = Color.Lime;
        //        //            TotalNewArrival++;
        //        //        }
        //        //        else
        //        //        {
        //        //            row.DefaultCellStyle.BackColor = Color.Pink;
        //        //            TotalExist++;
        //        //        }

        //        //    //lblTotalNewArrivalProductCount.Text = "New Arrival Product Count-" + TotalNewArrival.ToString();
        //        //    //lblTotalExistCount.Text = "Exist Product Count-" + TotalExist.ToString();
        //        //    //lblTotalCount.Text = "Total Count-" + TotalCount.ToString();

        //        //    if (TotalNewArrival > 0)
        //        //        btnSave.Visible = true;
        //        //    else
        //        //        btnSave.Visible = false;
        //        //}
        //    }
        //}

        string ConvertDateIn = string.Empty, ConvertDateOut = string.Empty;
        DateTime dtIn, dtOut;

        private void Get_Data_Excel()
        {
            string filePath = string.Empty;
            string fileExt = string.Empty;
            ConvertDateIn = string.Empty;
            ConvertDateOut = string.Empty;
            OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file  

            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK) //if there is a file choosen by the user  
            {
                filePath = file.FileName;

                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                Excel.Range range;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(filePath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                WorksheetName = xlWorkSheet.Name.ToString();

                if (TemplateFor == "Attendance")
                {
                    objBL.Query = "delete from attendancelogsexcel";
                    Result = objBL.Function_ExecuteNonQuery();

                    range = xlWorkSheet.UsedRange;
                    rw = range.Rows.Count;
                    cl = range.Columns.Count;
                    cCnt = 5;

                    if (!string.IsNullOrEmpty(Convert.ToString(((range.Cells[1, 2] as Excel.Range).Value))))
                        AttendanceDate_E = Convert.ToDateTime((range.Cells[1, 2] as Excel.Range).Value);

                    for (rCnt = 3; rCnt <= rw; rCnt++)
                    {
                        EmployeeCode_E = 0;
                        InDate_E = DateTime.Now.Date;
                        OutDate_E = DateTime.Now.Date;
                        InTime_E = DateTime.Now.Date;
                        OutTime_E = DateTime.Now.Date;
                        // AttendanceDate_E = DateTime.Now.Date;
                        Status_E = string.Empty;

                        ConvertDateIn = string.Empty;
                        ConvertDateOut = string.Empty;

                        //EmployeeId,EmployeeCode,AttendanceDate,InTime,OutTime,StatusCode

                        //double A1 = Convert.ToDouble((range.Cells[rCnt, 2] as Excel.Range).Value2);
                        //AttendanceDate_E = Convert.ToDateTime(A1);

                        if (!string.IsNullOrEmpty(Convert.ToString(((range.Cells[rCnt, 1] as Excel.Range).Value))))
                            EmployeeCode_E = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString((range.Cells[rCnt, 1] as Excel.Range).Value)));
                        if (!string.IsNullOrEmpty(Convert.ToString(((range.Cells[rCnt, 2] as Excel.Range).Value))))
                            InDate_E = Convert.ToDateTime((range.Cells[rCnt, 2] as Excel.Range).Value);
                        if (!string.IsNullOrEmpty(Convert.ToString(((range.Cells[rCnt, 3] as Excel.Range).Value))))
                            InTime_E = Convert.ToDateTime((range.Cells[rCnt, 3] as Excel.Range).Value);

                        ConvertDateIn = InDate_E.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + " " + InTime_E.ToString(BusinessResources.TimeFormat_HHMM);
                        dtIn = Convert.ToDateTime(ConvertDateIn);

                        if (!string.IsNullOrEmpty(Convert.ToString(((range.Cells[rCnt, 4] as Excel.Range).Value))))
                            OutDate_E = Convert.ToDateTime((range.Cells[rCnt, 4] as Excel.Range).Value);
                        if (!string.IsNullOrEmpty(Convert.ToString(((range.Cells[rCnt, 5] as Excel.Range).Value))))
                            OutTime_E = Convert.ToDateTime((range.Cells[rCnt, 5] as Excel.Range).Value);

                        ConvertDateOut = OutDate_E.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + " " + OutTime_E.ToString(BusinessResources.TimeFormat_HHMM);
                        dtOut = Convert.ToDateTime(ConvertDateOut);

                        if (!string.IsNullOrEmpty(Convert.ToString(((range.Cells[rCnt, 6] as Excel.Range).Value))))
                            Status_E = objRL.CheckNullString(Convert.ToString((range.Cells[rCnt, 6] as Excel.Range).Value));

                        if (EmployeeCode_E != 0)
                        {
                            Save_ExcelFile_In_AttendanceLogsExcel();
                        }
                    }
                }

                xlWorkBook.Close(true, null, null);
                xlApp.Quit();
                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);

                //if (dgvProduct.Rows.Count > 0)
                //{
                //    TotalCount = Convert.ToInt32(dgvProduct.Rows.Count.ToString());
                //    foreach (DataGridViewRow row in dgvProduct.Rows)
                //        if (Convert.ToInt32(row.Cells["clmStatusNo"].Value) == 0)
                //        {
                //            row.DefaultCellStyle.BackColor = Color.Lime;
                //            TotalNewArrival++;
                //        }
                //        else
                //        {
                //            row.DefaultCellStyle.BackColor = Color.Pink;
                //            TotalExist++;
                //        }

                //    //lblTotalNewArrivalProductCount.Text = "New Arrival Product Count-" + TotalNewArrival.ToString();
                //    //lblTotalExistCount.Text = "Exist Product Count-" + TotalExist.ToString();
                //    //lblTotalCount.Text = "Total Count-" + TotalCount.ToString();

                //    if (TotalNewArrival > 0)
                //        btnSave.Visible = true;
                //    else
                //        btnSave.Visible = false;
                //}
                Fill_Grid();
            }
        }

        private void Get_Data_Excel_Bulk()
        {
            string filePath = string.Empty;
            string fileExt = string.Empty;
            ConvertDateIn = string.Empty;
            ConvertDateOut = string.Empty;
            OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file  

            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK) //if there is a file choosen by the user  
            {
                filePath = file.FileName;

                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                Excel.Range range;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(filePath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                WorksheetName = xlWorkSheet.Name.ToString();

                if (TemplateFor == "Attendance")
                {
                    objBL.Query = "delete from attendancelogsexcel";
                    Result = objBL.Function_ExecuteNonQuery();

                    range = xlWorkSheet.UsedRange;
                    rw = range.Rows.Count;
                    cl = range.Columns.Count;
                    cCnt = 5;

                    for (rCnt = 2; rCnt <= rw; rCnt++)
                    {
                        EmployeeCode_E = 0;
                        InDate_E = DateTime.Now.Date;
                        OutDate_E = DateTime.Now.Date;
                        InTime_E = DateTime.Now.Date;
                        OutTime_E = DateTime.Now.Date;
                        // AttendanceDate_E = DateTime.Now.Date;
                        Status_E = string.Empty;

                        ConvertDateIn = string.Empty;
                        ConvertDateOut = string.Empty;

                        //EmployeeId,EmployeeCode,AttendanceDate,InTime,OutTime,StatusCode

                        //double A1 = Convert.ToDouble((range.Cells[rCnt, 2] as Excel.Range).Value2);
                        //AttendanceDate_E = Convert.ToDateTime(A1);

                        //if (!string.IsNullOrEmpty(Convert.ToString(((range.Cells[rCnt, 2] as Excel.Range).Value))))
                        //    AttendanceDate_E = Convert.ToDateTime((range.Cells[rCnt, 2] as Excel.Range).Value);

                        if (!string.IsNullOrEmpty(Convert.ToString(((range.Cells[rCnt, 1] as Excel.Range).Value))))
                            EmployeeCode_E = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString((range.Cells[rCnt, 1] as Excel.Range).Value)));
                        if (!string.IsNullOrEmpty(Convert.ToString(((range.Cells[rCnt, 2] as Excel.Range).Value))))
                        {
                            InDate_E = Convert.ToDateTime((range.Cells[rCnt, 2] as Excel.Range).Value);
                            AttendanceDate_E = InDate_E;
                        }
                        string stringDate = string.Empty;

                        if (!string.IsNullOrEmpty(Convert.ToString(((range.Cells[rCnt, 3] as Excel.Range).Value))))
                        {
                            stringDate = Convert.ToString(((range.Cells[rCnt, 3] as Excel.Range).Value));
                            TimeSpan time = TimeSpan.Parse(stringDate);
                            DateTime baseDate = AttendanceDate_E; // DateTime.Today;
                            DateTime resultDateTime = baseDate.Add(time);
                            InTime_E = resultDateTime;
                            dtIn = InTime_E;

                            //stringDate = Convert.ToString(((range.Cells[rCnt, 3] as Excel.Range).Value));
                            //InTime_E = objRL.Convert_To_Time(stringDate);

                            //double excelTimeValue = Convert.ToDouble(TDate); // 0.756944444; // Example value

                            // // Convert Excel double value to a DateTime object
                            // DateTime baseDate = new DateTime(1899, 12, 30);
                            // DateTime date = baseDate.AddDays(excelTimeValue);
                            // date = Convert.ToDateTime(date.ToString(BusinessResources.TimeFormat_HHMM));
                            // TimeSpan time = date.TimeOfDay;

                            // //objRL.String_To_Date
                            // DateTime combinedDateTime = InTime_E.Add(time);

                            //InTime_E = Convert.ToDateTime((range.Cells[rCnt, 3] as Excel.Range).Value);

                            //ConvertDateIn = InDate_E.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + " " + InTime_E.ToString(BusinessResources.TimeFormat_HHMM);
                            //dtIn = Convert.ToDateTime(ConvertDateIn);

                        }


                        if (!string.IsNullOrEmpty(Convert.ToString(((range.Cells[rCnt, 4] as Excel.Range).Value))))
                            OutDate_E = Convert.ToDateTime((range.Cells[rCnt, 4] as Excel.Range).Value);
                        if (!string.IsNullOrEmpty(Convert.ToString(((range.Cells[rCnt, 5] as Excel.Range).Value))))
                        {
                            stringDate = string.Empty;
                            stringDate = Convert.ToString(((range.Cells[rCnt, 5] as Excel.Range).Value));
                            TimeSpan time = TimeSpan.Parse(stringDate);
                            DateTime baseDate = OutDate_E; // DateTime.Today;
                            DateTime resultDateTime = baseDate.Add(time);
                            OutTime_E = resultDateTime;
                            dtOut = OutTime_E;

                            // OutTime_E = objRL.Convert_To_Time(stringDate);

                            //// OutTime_E = Convert.ToDateTime((range.Cells[rCnt, 5] as Excel.Range).Value);

                            // ConvertDateOut = OutDate_E.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + " " + OutTime_E.ToString(BusinessResources.TimeFormat_HHMM);
                            // dtOut = Convert.ToDateTime(ConvertDateOut);
                        }

                        if (!string.IsNullOrEmpty(Convert.ToString(((range.Cells[rCnt, 6] as Excel.Range).Value))))
                            Status_E = objRL.CheckNullString(Convert.ToString((range.Cells[rCnt, 6] as Excel.Range).Value));

                        if (EmployeeCode_E != 0)
                        {
                            Save_ExcelFile_In_AttendanceLogsExcel();
                        }
                    }
                }

                xlWorkBook.Close(true, null, null);
                xlApp.Quit();
                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);

                //if (dgvProduct.Rows.Count > 0)
                //{
                //    TotalCount = Convert.ToInt32(dgvProduct.Rows.Count.ToString());
                //    foreach (DataGridViewRow row in dgvProduct.Rows)
                //        if (Convert.ToInt32(row.Cells["clmStatusNo"].Value) == 0)
                //        {
                //            row.DefaultCellStyle.BackColor = Color.Lime;
                //            TotalNewArrival++;
                //        }
                //        else
                //        {
                //            row.DefaultCellStyle.BackColor = Color.Pink;
                //            TotalExist++;
                //        }

                //    //lblTotalNewArrivalProductCount.Text = "New Arrival Product Count-" + TotalNewArrival.ToString();
                //    //lblTotalExistCount.Text = "Exist Product Count-" + TotalExist.ToString();
                //    //lblTotalCount.Text = "Total Count-" + TotalCount.ToString();

                //    if (TotalNewArrival > 0)
                //        btnSave.Visible = true;
                //    else
                //        btnSave.Visible = false;
                //}
                Fill_Grid();
            }
        }
        private void Save_ExcelFile_In_AttendanceLogsExcel()
        {
            //Insert into Temp Table
            //insert into malasdb.attendancelogsexcel(EmployeeId,EmployeeCode,AttendanceDate,InTime,OutTime,Status) values(0,1,'2024-01-01','2024-01-01 07:22','2024-01-01 15:33','P')
            objBL.Query = "insert into attendancelogsexcel(EmployeeId,EmployeeCode,AttendanceDate,InTime,OutTime,Status) values(0," + EmployeeCode_E + ",'" + AttendanceDate_E.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "','" + dtIn.ToString("yyyy-MM-dd HH:mm") + "','" + dtOut.ToString("yyyy-MM-dd HH:mm") + "','" + Status_E + "')";
            Result = objBL.Function_ExecuteNonQuery();
        }

        private void Fill_Grid()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            //objBL.Query = "select AttendanceLogsExcelId,EmployeeId,EmployeeCode,AttendanceDate, DATE_FORMAT(InTime, '%H:%i') as 'InTime', DATE_FORMAT(OutTime, '%H:%i') as 'OutTime',Status,NewFlag from attendancelogsexcel";
            objBL.Query = "select AttendanceLogsExcelId,EmployeeId,EmployeeCode,AttendanceDate, DATE_FORMAT(InTime, '%d/%m/%Y %H:%i') as 'InTime', DATE_FORMAT(OutTime, '%d/%m/%Y %H:%i') as 'OutTime',Status,NewFlag from attendancelogsexcel";
            //DATE_FORMAT(column_name, '%m/%d/%Y %H:%i')
            dt = objBL.ReturnDataTable();

            if (dt.Rows.Count > 0)
            {
                //0 AttendanceLogsExcelId,
                //1 EmployeeId,
                //2 EmployeeCode,
                //3 AttendanceDate,
                //4 InTime,
                //5 OutTime,
                //6 Status,
                //7 NewFlag

                lblTotalCount.Text = "Total Count-" + dt.Rows.Count;
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[7].Visible = false;

                dataGridView1.Columns[2].Width = 150;
                dataGridView1.Columns[3].Width = 150;
                dataGridView1.Columns[4].Width = 150;
                dataGridView1.Columns[5].Width = 150;
                dataGridView1.Columns[6].Width = 150;
            }
        }

        private void Save_Employee_CheckExist()
        {
            objPC.EmployeeId = 0;
            objPC.EmployeeCode = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

            }

            //Check Exist
            System.Data.DataTable dt = new System.Data.DataTable();
            objBL.Query = "select * from Employees where CancelTag=0 and EmployeeCode=" + EmployeeCode_E + "";
            dt = objBL.ReturnDataTable();
            if (dt.Rows.Count > 0)
            {
                objPC.EmployeeId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[0]["EmployeeId"])));
                objPC.EmployeeCode = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[0]["EmployeeCode"])));
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void ClearAll()
        {
            cmbFor.SelectedIndex = -1;
            dataGridView1.DataSource = null;
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            cmbFor.SelectedIndex = -1;
        }

        bool DateOfJoiningFlag = false, InsertFlagJoingDate = false, DateExitFlag = false, InsertFlagExitDate = false;

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (new CursorWait())
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    //0 AttendanceLogsExcelId,
                    //1 EmployeeId,
                    //2 EmployeeCode,
                    //3 AttendanceDate,
                    //4 InTime,
                    //5 OutTime,
                    //6 Status,
                    //7 NewFlag

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        objPC.ClearAttendanceRecords();
                        objAL.Clear_Attendance();
                        objPC.ClearAttendanceRecords();

                        objPC.EmployeeId = 0;
                        objPC.EmployeeCode = 0;
                        objPC.AttendanceDate = DateTime.Now.Date;
                        objPC.AttendanceDay = string.Empty;

                        objPC.InTime = DateTime.Now.Date;
                        objPC.OutTime = DateTime.Now.Date;
                        objPC.StatusCode = string.Empty;

                        //objPC.EmployeeId = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                        objPC.EmployeeCode = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                        objPC.AttendanceDate = Convert.ToDateTime(dataGridView1.Rows[i].Cells[1].Value);
                        objPC.AttendanceDay = objPC.AttendanceDate.DayOfWeek.ToString();

                        //var dateStr = "07:22"; // dataGridView1.Rows[i].Cells[4].Value.ToString();
                        //var dateTime = DateTime.ParseExact(dateStr, "H:mm", null, System.Globalization.DateTimeStyles.None);
                        //objPC.InTime = DateTime.ParseExact(dateStr, "H:mm", null, System.Globalization.DateTimeStyles.None);

                        //string ConcatIn


                        ConvertDateIn = string.Empty;
                        ConvertDateOut = string.Empty;

                        ////EmployeeId,EmployeeCode,AttendanceDate,InTime,OutTime,StatusCode

                        ////double A1 = Convert.ToDouble((range.Cells[rCnt, 2] as Excel.Range).Value2);
                        ////AttendanceDate_E = Convert.ToDateTime(A1);

                        //if (!string.IsNullOrEmpty(Convert.ToString(((range.Cells[rCnt, 1] as Excel.Range).Value))))
                        //    EmployeeCode_E = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString((range.Cells[rCnt, 1] as Excel.Range).Value)));
                        //if (!string.IsNullOrEmpty(Convert.ToString(((range.Cells[rCnt, 2] as Excel.Range).Value))))
                        //    InDate_E = Convert.ToDateTime((range.Cells[rCnt, 2] as Excel.Range).Value);
                        //if (!string.IsNullOrEmpty(Convert.ToString(((range.Cells[rCnt, 3] as Excel.Range).Value))))
                        //    InTime_E = Convert.ToDateTime((range.Cells[rCnt, 3] as Excel.Range).Value);

                        InTime_E = Convert.ToDateTime(dataGridView1.Rows[i].Cells[2].Value);

                        OutDate_E = Convert.ToDateTime(dataGridView1.Rows[i].Cells[3].Value);
                        OutTime_E = Convert.ToDateTime(dataGridView1.Rows[i].Cells[4].Value);

                        ConvertDateIn = objPC.AttendanceDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + " " + InTime_E.ToString(BusinessResources.TimeFormat_HHMM);
                        objPC.InTime = Convert.ToDateTime(ConvertDateIn);

                        ConvertDateOut = OutDate_E.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + " " + OutTime_E.ToString(BusinessResources.TimeFormat_HHMM);
                        objPC.OutTime = Convert.ToDateTime(ConvertDateOut);

                        objPC.StatusCode = Convert.ToString(dataGridView1.Rows[i].Cells[5].Value);

                        //Save Attendance
                        DataSet ds = new DataSet();

                        ds = objQL.SP_Employees_By_EmployeeCode();

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DateOfJoiningFlag = false;
                            InsertFlagJoingDate = false;
                            DateExitFlag = false;
                            InsertFlagExitDate = false;

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
                            objPC.DepartmentId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["DepartmentId"])));
                            objPC.ShiftGroupId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["ShiftGroupId"])));
                            objPC.CategoryId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["CategoryId"])));
                            objPC.DesignationId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["DesignationId"])));

                            objRL.Get_CategoriesDetails_By_Id();

                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["DOJ"].ToString())))
                            {
                                DateOfJoiningFlag = true;
                                objPC.DateOfJoining = Convert.ToDateTime(ds.Tables[0].Rows[0]["DOJ"].ToString());
                            }
                            else
                            {
                                DateOfJoiningFlag = false;
                                InsertFlagJoingDate = false;
                            }

                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["DateOfExit"].ToString())))
                            {
                                DateExitFlag = true;
                                objPC.DateOfExit = Convert.ToDateTime(ds.Tables[0].Rows[0]["DateOfExit"].ToString());
                            }
                            else
                            {
                                DateExitFlag = false;
                                InsertFlagExitDate = true;
                            }

                            if (DateOfJoiningFlag)
                            {
                                if (objPC.DateOfJoining <= objPC.AttendanceDate)
                                    InsertFlagJoingDate = true;
                                else
                                    InsertFlagJoingDate = false;
                            }
                            else
                                InsertFlagJoingDate = false;

                            if (DateExitFlag)
                            {
                                if (objPC.DateOfExit >= objPC.AttendanceDate)
                                    InsertFlagExitDate = true;
                                else
                                    InsertFlagExitDate = false;
                            }

                            if (InsertFlagJoingDate && InsertFlagExitDate)
                            {
                                //bool CheckFlag = false;

                                //DataSet dsARM = new DataSet();
                                //objPC.CompleteFlag = 0;
                                //objPC.AttendanceRecordMasterId = 0; //Convert.ToInt32(objCmd.ExecuteScalar());
                                //objPC.EntryDate = DateTime.Now.Date;
                                //dsARM = objQL.SP_AttendanceRecordMaster_CheckExist();
                                //CheckFlag = false;

                                //if (dsARM.Tables[0].Rows.Count > 0)
                                //{
                                //    if (!string.IsNullOrEmpty(Convert.ToString(dsARM.Tables[0].Rows[0]["AttendanceRecordMasterId"].ToString())))
                                //    {
                                //        objPC.AttendanceRecordMasterId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dsARM.Tables[0].Rows[0]["AttendanceRecordMasterId"])));
                                //        objPC.ApprovalStatusId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dsARM.Tables[0].Rows[0]["ApprovalStatusId"])));
                                //        objPC.AttendanceStatus = objRL.CheckNullString(Convert.ToString(dsARM.Tables[0].Rows[0]["AttendanceStatus"]));
                                //        CheckFlag = true;
                                //    }
                                //}

                                objAL.Check_ARM();

                                if (objPC.AttendanceStatus != BusinessResources.LS_Completed)
                                {
                                    //if (!CheckFlag)
                                    //{
                                    //    objPC.ApprovalStatusId = 1;
                                    //    objRL.Get_Incharge_Senior_OfficerId();
                                    //    objPC.AttendanceRecordMasterId = objQL.SP_AttendanceRecordMaster_CheckExist_Insert();
                                    //}

                                    if (!objPC.CheckFlagARM)
                                    {
                                        objPC.ApprovalStatusId = 1;
                                        objRL.Get_Incharge_Senior_OfficerId();
                                        objPC.AttendanceRecordMasterId = objQL.SP_AttendanceRecordMaster_CheckExist_Insert();
                                    }

                                    if (objPC.AttendanceRecordMasterId != 0)
                                    {
                                        //Insert into AttendanceRecord
                                        //1st Check Exist if record is not available then insert 
                                        //If exist show time

                                        objPC.AttendanceRecordId = 0;

                                        if (objQL.SP_AttendanceRecord_CheckExist())
                                            objPC.AttendanceRecordId = 0;

                                        if (objPC.EditFlag == 0)
                                        {
                                            objAL.Clear_Attendance();

                                            objPC.EntryDate = DateTime.Now.Date;

                                            objPC.MissedOutPunch = 0;
                                            objPC.MissedInPunch = 0;

                                            objAL.AttendanceWorking();

                                            objPC.UserId = Convert.ToInt32(BusinessLayer.EmployeeLoginId_Static);
                                            objPC.Remarks = "Excel Attendance";

                                            Result = objQL.SP_AttendanceRecord_Insert_Update();

                                            if (Result > 0)
                                            {
                                                if (objPC.AttendanceRecordId == 0)
                                                    objPC.AttendanceRecordId = objRL.ReturnMaxID_Fix("attendancerecord", "AttendanceRecordId");

                                                objAL.Save_AttendanceMonthlyData();
                                                objPC.AttendanceRecordId = 0;
                                            }//Result
                                        }
                                    }
                                }
                            }
                        }
                    }

                    objRL.ShowMessage(44, 1);
                    ClearAll();
                }
            }
        }

        private bool Validation()
        {
            objEP.Clear();
            if (cmbFor.SelectedIndex == -1)
            {
                cmbFor.Focus();
                objEP.SetError(cmbFor, "Select For");
                return true;
            }
            else
                return false;

        }

        private void Uploade_ExcelFile()
        {
            try
            {
                if (!Validation())
                {
                    //Get_Data_Excel();
                    Get_Data_Excel_Bulk();
                }
            }
            catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
            finally { }
        }

        private void btnConvertDATExel_Click(object sender, EventArgs e)
        {
            ConvertDATToExel();
        }

        private void ConvertDATToExel()
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;
            string FPath = @"D:\BitBucketProjects\Malas Fruit\Docs\Requirements\ESSL Files DAT\ssrface.dat";

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(FPath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            WorksheetName = xlWorkSheet.Name.ToString();

            // xlWorkBook = xlApp.Workbooks.Open(FPath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkBook.SaveAs(FPath + ".xls", Excel.XlFileFormat.xlWorkbookNormal, false, false, false, false, Excel.XlSaveAsAccessMode.xlExclusive, false, false, false, false, false);
        }
    }
}
