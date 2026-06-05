using BusinessLayerUtility;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPApplication.Authentication
{
    public partial class UpdateWizard : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0;

        private void btnDownload_Click(object sender, EventArgs e)
        {
            string downloadPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";

            //string sourcePath = "C:\\Path\\To\\YourFile.exe";
            //UpdatePath

            string sourcePath = objRL.GetPath_WithoutServer("UpdatePath");

            //string sourcePath = "D:\\BitBucketProjects\\Malas Fruit\\UpdateVersion\\apps.exe";
        
            // Destination path to save the file
            //string destinationPath = "C:\\Destination\\Path\\YourFile.exe";

            string destinationPath1 = ""+ downloadPath + "\\don.exe";

            if (File.Exists(sourcePath))
            {
                // Copy the file
                File.Copy(sourcePath, destinationPath1, true);

                try
                {
                    Process.Start(destinationPath1);
                   //Application.Exit();
                    //System.Windows.Application.Exit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                MessageBox.Show("File Downloaded successfully.");
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

        }
        public UpdateWizard()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, "Update Wizard");
        }

        private void UpdateWizard_Load(object sender, EventArgs e)
        {
            if (objRL.Get_Update_Details())
                btnDownload.Visible = true;
            else
                btnDownload.Visible = false;

            //string hostName = Dns.GetHostName();
            //IPHostEntry ipEntry = Dns.GetHostEntry(hostName);
            //IPAddress[] addresses = ipEntry.AddressList;

            //foreach (IPAddress address in addresses)
            //{
            //    Console.WriteLine("IP Address: " + address.ToString());
            //}
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void Code_For_Download_Web()
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    // URL of the file to download
                    string url = "https://example.com/path/to/yourfile.exe";
                    // Path to save the downloaded file
                    string savePath = "C:\\Path\\To\\Save\\YourFile.exe";

                    // Download the file
                    client.DownloadFile(url, savePath);

                    MessageBox.Show("File downloaded successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error downloading file: " + ex.Message);
                }
            }
        }

    }
}
