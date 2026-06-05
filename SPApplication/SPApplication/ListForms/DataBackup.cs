using System;
//using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using BusinessLayerUtility;
using System.Diagnostics;
using System.IO;
//using Google.Apis.Auth.OAuth2;
//using Google.Apis.Drive.v3;
//using Google.Apis.Drive.v3.Data;
//using Google.Apis.Services;
//using Google.Apis.Util.Store;
using System.Configuration;

namespace SPApplication.ListForms
{
    public partial class DataBackup : Form
    {
        PropertyClass objPC = new PropertyClass();
        BusinessLayer objBL = new BusinessLayer();
        ErrorProvider objEP = new ErrorProvider();
        RedundancyLogics objRL = new RedundancyLogics(); DesignLayer objDL = new DesignLayer();
        QueryLayer objQL = new QueryLayer();

        //public static string[] Scopes = { DriveService.Scope.Drive };
        //public static string ApplicationName = "LaxmiClinicBackup";

        public DataBackup()
        {
            InitializeComponent();
            objDL.SetLabelDesign(lblHeader, BusinessResources.LBL_HEADER_DATABACKUP);
            objDL.SetButtonDesign(btnBackuData, BusinessResources.BTN_BACKUPDATA);
            objDL.SetButtonDesign(btnSyncToCloud, BusinessResources.BTN_SYNCTOCLOUD);
            objDL.SetButtonDesign(btnExit, BusinessResources.BTN_EXIT);

            objRL.Get_UserRights_By_MenuName(BusinessResources.LBL_HEADER_DATABACKUP);
        }

        private void DataBackup_Load(object sender, EventArgs e)
        {
            Fill_LastDate(false);
            Fill_LastDate(true);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        //public static string[] Scopes = { DriveService.Scope.Drive };
        //public static string ApplicationName = "LaxmiClinicBackup";

        private void btnSyncToCloud_Click(object sender, EventArgs e)
        {
            //RedundancyLogics.Call_GoogleAPI();

            //https://developers.google.com/drive/api/v3/quickstart/dotnet

            //// UserCredential credential;
            // string FilePath = @"C:\Users\Yash\source\repos\ConsoleApp1\ConsoleApp1\credentials.json";

            // //using (var stream =
            // //    new FileStream(FilePath, FileMode.Open, FileAccess.Read))
            // //{
            // //    // The file token.json stores the user's access and refresh tokens, and is created
            // //    // automatically when the authorization flow completes for the first time.
            // //    string credPath = "token.json";
            // //    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
            // //        GoogleClientSecrets.Load(stream).Secrets,
            // //        Scopes,
            // //        "user",
            // //        CancellationToken.None,
            // //        new FileDataStore(credPath, true)).Result;
            // //    //Console.WriteLine("Credential file saved to: " + credPath);
            // //}

            // //// Create Drive API service.
            // //var service = new DriveService(new BaseClientService.Initializer()
            // //{
            // //    HttpClientInitializer = credential,
            // //    ApplicationName = ApplicationName,
            // //});

            // //Upload_DB_File("D:\\laxmidb.sql", service);
            // //// Define parameters of request.
            // //FilesResource.ListRequest listRequest = service.Files.List();
            // //listRequest.PageSize = 10;
            // //listRequest.Fields = "nextPageToken, files(id, name)";

            // //// List files.
            // //IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute()
            // //    .Files;
            // //MessageBox.Show("Files:");

            // //if (files != null && files.Count > 0)
            // //{
            // //    foreach (var file in files)
            // //    {
            // //        Console.WriteLine("{0} ({1})", file.Name, file.Id);
            // //    }
            // //}
            // //else
            // //{
            // //    Console.WriteLine("No files found.");
            // //}
            // //Console.Read();


            // UserCredential credential;

            // //string FilePath = @"H:\Backup 04-09-2019\SPApplication\SPApplication\credentials.json";

            // using (var stream =
            //     new FileStream(FilePath, FileMode.Open, FileAccess.Read))
            // {
            //     // The file token.json stores the user's access and refresh tokens, and is created
            //     // automatically when the authorization flow completes for the first time.
            //     string credPath = "token.json";
            //     credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
            //         GoogleClientSecrets.Load(stream).Secrets,
            //         Scopes,
            //         "user",
            //         CancellationToken.None,
            //         new FileDataStore(credPath, true)).Result;
            //     //Console.WriteLine("Credential file saved to: " + credPath);
            // }

            // // Create Drive API service.
            // var service = new DriveService(new BaseClientService.Initializer()
            // {
            //     HttpClientInitializer = credential,
            //     ApplicationName = ApplicationName,
            // });

            // Upload_DB_File("D:\\laxmidb.sql", service);

            objQL.SearchFlag = true;
            objQL.EntryDate = DateTime.Now.Date;
            objQL.UserId = BusinessLayer.LoginId_Static;
            int Result = objQL.SP_Backups_Save();
        }

        //public static void Upload_DB_File(string path, DriveService service)
        //{
        //    var fileMataData = new Google.Apis.Drive.v3.Data.File();
        //    fileMataData.Name = Path.GetFileName(path);
        //    fileMataData.MimeType = "text/sql";
        //    FilesResource.CreateMediaUpload request;

        //    using (var stream = new System.IO.FileStream(path, System.IO.FileMode.Open))
        //    {
        //        request = service.Files.Create(fileMataData, stream, "text/sql");
        //        request.Fields = "id";
        //        request.Upload();
        //    }
        //    var file = request.ResponseBody;
        //    //MessageBox.Show(file.Id.ToString());
        //}

        static void p_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Process p = sender as Process;
            if (p == null)
                return;
            Console.WriteLine(e.Data);
        }

        static void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Process p = sender as Process;
            if (p == null)
                return;
            Console.WriteLine(e.Data);
        }

        bool PasswordFlag = false;

        private void ExecuteCommand(string Command, int Timeout, Boolean closeProcess)
        {
            //System.Diagnostics.ProcessStartInfo ProcessInfo = new System.Diagnostics.ProcessStartInfo(); //Initializes a new ProcessStartInfo of name myProcessInfo
            //ProcessInfo.FileName = Environment.ExpandEnvironmentVariables("%SystemRoot%") + @"\System32\cmd.exe"; //Sets the FileName property of myProcessInfo to %SystemRoot%\System32\cmd.exe where %SystemRoot% is a system variable which is expanded using Environment.ExpandEnvironmentVariables
            ////ProcessInfo.Arguments = "cd.."; //Sets the arguments to cd..
            //ProcessInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden; //Sets the WindowStyle of myProcessInfo which indicates the window state to use when the process is started to Hidden
            ////System.Diagnostics.Process.Start(ProcessInfo);

            ProcessStartInfo ProcessInfo;
            Process Process;

            //if(PasswordFlag)
            //    ProcessInfo = new ProcessStartInfo("cmd.exe", "Enter Password: " + Command);
            //else
            //ProcessInfo = new ProcessStartInfo("cmd.exe", "/C " + Command);

            ProcessInfo = new ProcessStartInfo("cmd.exe", "/C " + Command);
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = false;
            ProcessInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            Process = Process.Start(ProcessInfo);
            Process.WaitForExit(Timeout);

            if (closeProcess == true) { Process.Close(); }
        }

        string Pass = @"""Clinic@1234""";

        private void GetBackup()
        {
            //try
            //{

            //    DateTime backupTime = DateTime.Now;
            //    int year = backupTime.Year;
            //    int month = backupTime.Month;
            //    int day = backupTime.Day;
            //    int hour = backupTime.Hour;
            //    int minute = backupTime.Minute;
            //    int second = backupTime.Second;
            //    int ms = backupTime.Millisecond;

            //    String tmestr = backupTime.ToString();
            //    tmestr = "D:\\Backup0.txt";
            //    StreamWriter file = new StreamWriter(tmestr);
            //    ProcessStartInfo proc = new ProcessStartInfo();
            //    proc.FileName = "mysqldump";
            //    proc.RedirectStandardInput = false;
            //    proc.RedirectStandardOutput = true;

            //    proc.Arguments = "supplydirect";
            //    proc.UseShellExecute = false;
            //    Process p = Process.Start(proc);
            //    string res;
            //    res = p.StandardOutput.ReadToEnd();
            //    file.WriteLine(res);
            //    p.WaitForExit();
            //    file.Close();
            //}

            //catch (IOException ex)
            //{
            //    MessageBox.Show("Disk or other IO error , unable to backup!");
            //}

            //progressBar1.Maximum = 100;
            //progressBar1.Step = 1;
            //progressBar1.Value = 0;
            //backgroundWorker.RunWorkerAsync();

            //GetBackup();

            //System.Diagnostics.Process.Start(@"D:\STL\bitbucket_laxmi_clinic\ClinicPro\SPApplication\SPApplication\backupdb.bat");

            // string BactchFilePath = @"D:\STL\bitbucket_laxmi_clinic\ClinicPro\SPApplication\SPApplication\backupdb.bat";
            //ExecuteCommand(BactchFilePath, 100, false);

            //string BactchFilePath = @"D:\PatientNo-1.pdf";
            //ExecuteCommand(BactchFilePath, 100, false);

            //cd C:\\Program Files\\MySQL\\MySQL Server 8.0\\bin && mysqldump.exe -u clinicuser --password="Clinic@1234" laxmiclinicdb > D:\\laxmidb.sql

            //string ConcatCommand = "c: && cd C:\\Program Files\\MySQL\\MySQL Server 8.0\\bin && mysqldump.exe -u clinicuser --password=" + Pass + " laxmiclinicdb > D:\\laxmidb.sql";
            //ExecuteCommand(ConcatCommand, 100, false);

            //string strCmdText = "cd\\ && cd C:\\Program Files\\MySQL\\MySQL Server 8.0\\bin && mysqldump.exe -u clinicuser --password=" + Pass + " laxmiclinicdb > D:\\laxmidb.sql";
            //System.Diagnostics.Process.Start("CMD.exe", strCmdText);

            //ExecuteCommand("cd\\ && cd C:\\Program Files\\MySQL\\MySQL Server 8.0\\bin && mysqldump.exe -u clinicuser --password=" + Pass + " laxmiclinicdb > D:\\laxmidb.sql", 100, false);
            //ExecuteCommand("cd\\", 100, false);

            //string strCmdText = "/c start cd C:\\Program Files\\MySQL\\MySQL Server 8.0\\bin";
            //ExecuteCommand("cd\\", 100, false);
            //ExecuteCommand("cd C:\\Program Files\\MySQL\\MySQL Server 8.0\\bin", 100, false);
            ////ExecuteCommand("mysqldump.exe -u clinicuser -p laxmiclinicdb > D:\\laxmidb.sql", 100, false);
            //ExecuteCommand("mysqldump.exe -u clinicuser --password=" + Pass + " laxmiclinicdb > D:\\laxmidb.sql", 100, false);

            //PasswordFlag = true;
            //ExecuteCommand("Clinic@1234", 100, false);

            //Process cmd = new Process();
            //cmd.StartInfo.FileName = @"cmd.exe";
            //cmd.StartInfo.Arguments = ConcatCommand;

            ////cmd.StartInfo.Arguments = @"/C cd C:\Program Files\MySQL\MySQL Server 8.0\bin";
            ////cmd.StartInfo.Arguments = @"mysqldump.exe -u clinicuser -p laxmiclinicdb > D:\Laxmidb.sql";
            ////cmd.StartInfo.Arguments = @"Clinic@1234";
            //cmd.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            //cmd.Start();
            //cmd.WaitForExit();

            //System.Diagnostics.ProcessStartInfo ProcessInfo = new System.Diagnostics.ProcessStartInfo(); //Initializes a new ProcessStartInfo of name myProcessInfo
            //ProcessInfo.FileName = Environment.ExpandEnvironmentVariables("cmd.exe"); //Sets the FileName property of myProcessInfo to %SystemRoot%\System32\cmd.exe where %SystemRoot% is a system variable which is expanded using Environment.ExpandEnvironmentVariables
            //ProcessInfo.Arguments = ConcatCommand; //Sets the arguments to cd..
            //ProcessInfo.Arguments = "cd C:\\Program Files\\MySQL\\MySQL Server 8.0\\bin"; //Sets the arguments to cd..
            ////ProcessInfo.Arguments = "mysqldump.exe -u clinicuser -p laxmiclinicdb > D:\\laxmidb.sql"; //Sets the arguments to cd..
            ////ProcessInfo.Arguments = "Clinic@1234"; //Sets the arguments to cd..
            //ProcessInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal; //Sets the WindowStyle of myProcessInfo which indicates the window state to use when the process is started to Hidden
            //System.Diagnostics.Process.Start(ProcessInfo);

            //string path = @"C:\Program Files\MySQL\MySQL Server 8.0\bin\mysqldump.exe -u root -p laxmiclinicdb > D:\Backup\Backup.sql";
            //Process p = new Process();
            //p.StartInfo.FileName = path;
            //p.Start();

            //string strCmdText = "/c start cd C:\\Program Files\\MySQL\\MySQL Server 8.0\\bin";

            ////cd C:\Program Files\MySQL\MySQL Server 8.0\bin
            ////mysqldump -u root -p laxmiclinicdb > laxmidb.sql

            //string strCmdText = "/c start cd C:\\Program Files\\MySQL\\MySQL Server 8.0\\bin";
            //ExecuteCommand("cd\\", 100, false);
            //ExecuteCommand("cd C:\\Program Files\\MySQL\\MySQL Server 8.0\\bin", 100, false);
            //ExecuteCommand("mysqldump.exe -u clinicuser -p laxmiclinicdb > D:\\laxmidb.sql", 100, false);
            //PasswordFlag = true;
            //ExecuteCommand("Clinic@1234", 100, false);

            //ExecuteCommand(@"\. " + Environment.CurrentDirectory + @"\MySQL\CaseManager.sql", 100, true);
            //ExecuteCommand(@"\. " + Environment.CurrentDirectory + @"\MySQL\CaseManager.sql", 100, true);


            //ExecuteCommand("mysql --user=root --password=sa casemanager", 100, false);
            //ExecuteCommand(@"\. " + Environment.CurrentDirectory + @"\MySQL\CaseManager.sql", 100, true);
            //ExecuteCommand(@"\. " + Environment.CurrentDirectory + @"\MySQL\CaseManager.sql", 100, true);

            //strCmdText += "mysqldump -u root -p laxmiclinicdb > laxmidb.sql";

            //Process cmd = new Process();
            //cmd.StartInfo.FileName = "cmd.exe";
            ////cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //cmd.StartInfo.Arguments = strCmdText;
            //cmd.StartInfo.Arguments = strCmdText;
            //cmd.StartInfo.Arguments = strCmdText;
            //cmd.Start();

            //strCmdText = "/c start C:\\Users\\Yash\\mercurial.ini";
            //System.Diagnostics.Process.Start("CMD.exe", strCmdText);

            //System.Diagnostics.Process.Start("CMD.exe", "/C Users\\Yash\\mercurial.ini"); 

            //var proc = new Process
            //{
            //    StartInfo = new ProcessStartInfo
            //    {
            //        FileName = @"C:\Program Files\MySQL\MySQL Server 8.0\bin\",
            //        Arguments = "checkout AndroidManifest.xml",
            //        UseShellExecute = false,
            //        RedirectStandardOutput = true,
            //        CreateNoWindow = true,
            //        WorkingDirectory = @"C:\MyAndroidApp\"
            //    }
            //};

            //proc.Start();

            //Process cmd = new Process();
            //cmd.StartInfo.FileName = "cmd.exe";
            //cmd.StartInfo.RedirectStandardInput = true;
            //cmd.StartInfo.RedirectStandardOutput = true;
            //cmd.StartInfo.CreateNoWindow = true;
            //cmd.StartInfo.UseShellExecute = false;
            //cmd.Start();

            //cmd.StandardInput.WriteLine("echo Oscar");
            //cmd.StandardInput.Flush();
            //cmd.StandardInput.Close();
            //cmd.WaitForExit();
            //Console.WriteLine(cmd.StandardOutput.ReadToEnd());

            //using (Process p = new Process())
            //{
            //    // set start info
            //    p.StartInfo = new ProcessStartInfo("cmd.exe")
            //    {
            //        RedirectStandardInput = true,
            //        UseShellExecute = false,
            //        WorkingDirectory = @"C:\"
            //    };
            //    // event handlers for output & error
            //    p.OutputDataReceived += p_OutputDataReceived;
            //    p.ErrorDataReceived += p_ErrorDataReceived;

            //    // start process
            //    p.Start();
            //    // send command to its input
            //    p.StandardInput.Write(@"cd C:\Program Files\MySQL\MySQL Server 8.0\bin" + p.StandardInput.NewLine);
            //    //wait
            //    p.WaitForExit();
            //}

            //System.Diagnostics.Process process = new System.Diagnostics.Process();
            //System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //startInfo.UseShellExecute = false;
            //startInfo.RedirectStandardOutput = true;
            //startInfo.FileName = "CMD.exe";
            //startInfo.Arguments = "dir";
            //process.StartInfo = startInfo;
            //process.Start();
            //string output = process.StandardOutput.ReadToEnd();
            //MessageBox.Show(output);
            //process.WaitForExit(); 

            //cd C:\Program Files\MySQL\MySQL Server 8.0\bin
            //mysqldump -u root -p laxmiclinicdb > laxmidb.sql

            //path = @"D:\MySQL\MySQL Server 5.5\bin\mysqldump.exe -u " + txtBoxDBUsername.Text + @" -p " + txtBoxDBName.Text + @" > D:\C#\Client\Salesmate - EMC\SalesMate\Backup\" + maskeTxtBoxDBFile.Text + @"";
            //Process p = new Process();
            //p.StartInfo.FileName = path;
            //p.Start();


            ////objBL.Connect();
            //////objBL.objCon;
            ////string Backup = @"D:\Backup\";

            ////using(MySqlCommand objcmd=new MySqlCommand())
            ////{
            ////    using (MySqlBackup()) ;
            ////}

            // using (MySqlBackup mb = new MySqlBackup(cmd))
        }

        private void Calculate(int i)
        {
            double pow = Math.Pow(i, i);
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;
            for (int j = 0; j < 10000; j++)
            {
                Calculate(j);
                backgroundWorker.ReportProgress((j * 10) / 100000);
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // TODO: do something with final calculation.
        }

        string DBPath = string.Empty;

        private void btnBackuData_Click(object sender, EventArgs e)
        {
            if (objPC.AddFlag == 1)
            {
                try
                {
                    int Result = objRL.LoginBackup_Auto();
                    if (Result > 0)
                    {
                        objRL.ShowMessage(26, 1);
                    }

                    ////using (new CursorWait())
                    ////{
                    ////
                    //DBPath = string.Empty;
                    //if (!string.IsNullOrEmpty(Convert.ToString(ConfigurationManager.AppSettings["DBBackupPath"])))
                    //{
                    //    DBPath = ConfigurationManager.AppSettings["DBBackupPath"].ToString();
                    //    if (!Directory.Exists(DBPath))
                    //        Directory.CreateDirectory(DBPath);

                    //    DBPath += BusinessLayer.DatabaseName + "_dump_" + DateTime.Now.ToString("dd-MMM-yyyy");
                    //}
                    //this.timer1.Start();
                    ////string ConcatCommand = "c: && cd C:\\Program Files\\MySQL\\MySQL Server 8.0\\bin && mysqldump.exe -h Yashwant -u clinicuser --password=" + Pass + "  " + BusinessLayer.DatabaseName + " > " + DBPath + "";
                    //string ConcatCommand = "c: && cd C:\\Program Files\\MySQL\\MySQL Server 8.0\\bin && mysqldump.exe -h " + BusinessLayer.ServerName + " -u " + BusinessLayer.Uid + " --password=" + BusinessLayer.DatabasePassword + "  " + BusinessLayer.DatabaseName + " > " + DBPath + "";
                    //ExecuteCommand(ConcatCommand, 100, false);
                    
                    //objQL.SearchFlag = false;
                    //objQL.EntryDate = DateTime.Now.Date;
                    //objQL.UserId = BusinessLayer.LoginId_Static;
                    //int Result = objQL.SP_Backups_Save();

                   
                    
                    //}
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            else
            {
                objRL.ShowMessage(24, 4);
                return;
            }
           

            //try
            //{
            //    //using (new CursorWait())
            //    //{
            //        this.timer1.Start();
            //        string ConcatCommand = "c: && cd C:\\Program Files\\MySQL\\MySQL Server 8.0\\bin && mysqldump.exe -h Yashwant -u clinicuser --password=" + Pass + " laxmiclinicdb > D:\\laxmidb.sql";
            //        ExecuteCommand(ConcatCommand, 100, false);
            //        objRL.ShowMessage(26, 1);

            //        objQL.SearchFlag = false;
            //        objQL.EntryDate = DateTime.Now.Date;
            //        objQL.UserId = BusinessLayer.UserId_Static;
            //        int Result = objQL.SP_Backups_Save();
            //    //}
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.progressBar1.Increment(100);
        }

        private void Fill_LastDate(bool Flag)
        {
            DataSet ds = new DataSet();
            objQL.SearchFlag = Flag;
            ds = objQL.SP_Backups_Select();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if(!Flag)
                    lblDailyBackupLastDate.Text = "Last data backup taken on : " + ds.Tables[0].Rows[0]["Local_Backup_Date"].ToString();
                if (Flag)
                    lblCloudBackup.Text = "Last data backup taken on : " + ds.Tables[0].Rows[0]["Cloud_Backup_Date"].ToString();
            }
        }
    }
}
