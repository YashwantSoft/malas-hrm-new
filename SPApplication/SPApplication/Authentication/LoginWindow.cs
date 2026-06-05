using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLayerUtility;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
//using MySqlX.XDevAPI.Common;

namespace SPApplication
{
    public partial class LoginWindow : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        ErrorProvider objEP = new ErrorProvider();
        RedundancyLogics objRL = new RedundancyLogics(); DesignLayer objDL = new DesignLayer();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();
        public LoginWindow()
        {
            InitializeComponent();
            Set_Design();
        }

        public void Set_Design()
        {
            btnLogin.BackColor = objDL.GetBackgroundColor();
            btnLogin.ForeColor = objDL.GetForeColor();

            btnCancel.BackColor = objDL.GetBackgroundColor();
            btnCancel.ForeColor = objDL.GetForeColor();

            lblUserName.ForeColor = objDL.GetBackgroundColor();
            lblPassword.ForeColor = objDL.GetBackgroundColor();

            btnExit.BackColor = objDL.GetBackgroundColor();
            btnExit.ForeColor = objDL.GetForeColor();

            objDL.SetLabelDesign_ForeColor(lblContactDetails, BusinessResources.LBL_CONTACTDETAILS);
            objDL.SetLabelDesign_ForeColor(lblCopyRights, BusinessResources.LBL_COPYRIGHTS);
            objDL.SetLabelDesign_ForeColor(lblVersion, BusinessResources.LBL_VERSION);
            objDL.SetLabelDesign_ForeColor(lbHelp, BusinessResources.LBL_HELP);

            //pbClientLogo.Image = BusinessResources.ClientLogo;
            //pbLogo.Image = BusinessResources.ClientLogo;

            if (BusinessResources.ProjectBy == "T")
            {
                //For T and T
                lblCopyRights.Visible = false;
                pbLogo.Image = BusinessResources.ClientLogo1;
                pbClientLogo.Image = BusinessResources.ClientLogo1;
            }
            else
            {
                //For M
                lblCopyRights.Visible = true;
                pbLogo.Image = BusinessResources.ClientLogo;
                pbClientLogo.Image = BusinessResources.ClientLogo;
            }

            
        }

        private const int CS_DropShadow = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                //LoginWindow objLogin = new LoginWindow();
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DropShadow;
                return cp;
            }
        }

        public string HKLM_GetString(string path, string key)
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(path);
                if (rk == null) return "";
                return (string)rk.GetValue(key);
            }
            catch { return ""; }
        }

        public string FriendlyName()
        {
            string ProductName = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName");
            string CSDVersion = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CSDVersion");
            if (ProductName != "")
            {
                return (ProductName.StartsWith("Microsoft") ? "" : "Microsoft ") + ProductName +
                            (CSDVersion != "" ? " " + CSDVersion : "");
            }
            return "";
        }

        string MACAddress = string.Empty;

        private bool Check_MacAddress()
        {

            //         Ethernet adapter vEthernet(Default Switch):

            //Connection - specific DNS Suffix  . :
            //Description. . . . . . . . . . . : Hyper - V Virtual Ethernet Adapter
            // Physical Address. . . . . . . . . : F6 - 15 - B6 - EA - 50 - 15
            //DHCP Enabled. . . . . . . . . . . : No
            //Autoconfiguration Enabled. . . . : Yes
            //Link - local IPv6 Address . . . . . : fe80::bcfd:e913: 1b66: 497b % 20(Preferred)
            //IPv4 Address. . . . . . . . . . . : 172.25.146.193(Preferred)
            //Subnet Mask . . . . . . . . . . . : 255.255.255.240
            //Default Gateway . . . . . . . . . :
            //DHCPv6 IAID . . . . . . . . . . . : 503321949
            //DHCPv6 Client DUID. . . . . . . . : 00 - 01 - 00 - 01 - 20 - E5 - EC - 22 - C8 - 5B - 76 - E7 - C0 - 36
            //DNS Servers . . . . . . . . . . . : fec0: 0:0:ffff::1 % 1
            //                                    fec0: 0:0:ffff::2 % 1
            //                                    fec0: 0:0:ffff::3 % 1
            //NetBIOS over Tcpip. . . . . . . . : Disabled


            //        C:\> getmac

            //Physical Address    Transport Name
            //=================== ==========================================================
            //58-00-E3-F2-C9-15   \Device\Tcpip_{8F8E8A94-BB96-4A5B-9629-C33C119FFEB6}
            //C8-5B-76-E7-C0-36   Media disconnected
            //72-15-C3-D3-12-50   \Device\Tcpip_{D685EE76-AA84-45BA-84FA-C0FAD904F4BD}

            bool ReturnFlag = false;

            MACAddress = objBL.GetMacAddress();

            DataSet ds = new DataSet();
            objQL.MACAddress = MACAddress;
            ds = objQL.SP_MACAddressTable_Select();
            if (ds.Tables[0].Rows.Count > 0)
                ReturnFlag = true;
            else
                ReturnFlag = false;

            //if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["macaddress"])))
            //    {
            //        string MA = Convert.ToString(ds.Tables[0].Rows[0]["macaddress"]);

            //        if(MA == Max)
            //    }
            //}

            //RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion");
            //RegistryKey registryKey1 = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion");
            //string pathName = (string)registryKey.GetValue("productName");
            //string pathName12 = (string)registryKey1.GetValue("CSDVersion");

            return ReturnFlag;
        }

        private void LoginWindow_Load(object sender, EventArgs e)
        {
            //if (!objRL.Get_Update_Details())
            //{
            //    if (objPC.UpdateFlag == 0)
            //    {
            //        //Update Query
            //        objBL.Query = "update macaddresstable set UpdateFlag=1 where UpdateFlag=0 and ID=" + objPC.MacAddressTableID + "";
            //        int Result= objBL.Function_ExecuteNonQuery();
            //    }
            //}

            //if (Check_MacAddress())
            //{
                if (objRL.ReturnSystemDateFormat())
                {
                    //
                    //string osVer = System.Environment.OSVersion.Version.ToString();
                    //string MACAddress = string.Empty;

                    //RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion");
                    //RegistryKey registryKey1 = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion");
                    //string pathName = (string)registryKey.GetValue("productName");
                    //string pathName12 = (string)registryKey1.GetValue("CSDVersion");

                    ////string MyMACAddress = "70:62:B8:2A:C7:FB";
                    ////string MyMACAddress = "7062B82AC7FB";

                    ////string MyMACAddress = "00:1A:73:FE:97:2C";
                    ////string MyMACAddress = "28:E3:47:11:7F:2B";
                    ////string MyMACAddress = "2A:E3:47:11:7F:2B";
                    ////string MyMACAddress = "00:1E:68:17:49:67";

                    ////string MyMACAddress = "DC:53:60:84:FE:72";
                    //string MyMACAddress = "DC:4A:3E:A7:7D:81";
                    ////DC-4A-3E-A7-7D-81
                    ////string MyMACAddress = "001A73FE972C";

                    ////if (pathName == "Windows 10 Enterprise") 
                    //if (pathName == "Windows 10 Home Single") 
                    //    MACAddress = objBL.GetMacAddress();
                    //else
                    //    MACAddress = objBL.GetMacAddressNew();

                    //if (MyMACAddress != MACAddress)
                    //{
                    //    MessageBox.Show("You are not purchasing licence of this software");
                    //    Application.Exit();
                    //    return;
                    //}
                    //else
                    //    ClearAll();

                    //LoginWindow.KeyPreview = true;

                    txtUserName.Select();
                }
                else
                {
                    objRL.ShowMessage(21, 4);
                    this.Dispose();
                    return;
                }
            //}
            //else
            //{
            //    objRL.ShowMessage(28, 4);
            //    this.Dispose();
            //    return;
            //}
        }
        private void ClearAll()
        {
            objEP.Clear();
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtUserName.Focus();
        }

        private bool Validation()
        {
            objEP.Clear();
            if (txtUserName.Text == "")
            {
                objEP.SetError(txtUserName, "Enter User Name");
                txtUserName.Focus();
                return true;
            }
            else if (txtPassword.Text == "")
            {
                objEP.SetError(txtPassword, "Enter Password");
                txtPassword.Focus();
                return true;
            }
            else
                return false;
        }

        string UserName = "", Password = "";
        int PatientId = 0;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //CallMySql();
            LoginSuccess();
        }

        private void LoginSuccess()
        {
            if (!Validation())
            {
                DataSet ds = new DataSet();

                UserName = ""; Password = "";
                UserName = txtUserName.Text;
                Password = txtPassword.Text;
                Password = BusinessLayer.Encrypt(Password, true);

                objQL.UserName = UserName;
                objQL.Password = Password;

                ds = objQL.SP_Login_By_UserName_Password();
                //objBL.Query = "select ID,UserName,Password,FullName from Login where CancelTag=0 and UserName='" + UserName + "' and Password='" + Password + "'";
                //ds = objBL.ReturnDataSet();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["UserName"].ToString()) && !string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Password"].ToString()))
                    {
                        BusinessLayer.LoginId_Static = Convert.ToInt32(ds.Tables[0].Rows[0]["LoginId"].ToString());
                        BusinessLayer.EmployeeLoginId_Static = Convert.ToInt32(ds.Tables[0].Rows[0]["EmployeeId"].ToString());
                        BusinessLayer.UserName_Static = ds.Tables[0].Rows[0]["UserName"].ToString();
                        BusinessLayer.UserName_Full_Static = ds.Tables[0].Rows[0]["EmployeeName"].ToString();
                        BusinessLayer.UserType = ds.Tables[0].Rows[0]["UserType"].ToString();
                        //BusinessLayer.UserType = ds.Tables[0].Rows[0]["Designation"].ToString();
                        BusinessLayer.Department = ds.Tables[0].Rows[0]["Department"].ToString();
                        BusinessLayer.Designation = ds.Tables[0].Rows[0]["Designation"].ToString();
                        BusinessLayer.DesignationId = Convert.ToInt32(ds.Tables[0].Rows[0]["DesignationId"].ToString());
                        BusinessLayer.DepartmentId = Convert.ToInt32(ds.Tables[0].Rows[0]["DepartmentId"].ToString());
                        BusinessLayer.LocationId = Convert.ToInt32(ds.Tables[0].Rows[0]["LocationId"].ToString());
                        BusinessLayer.LocationName = ds.Tables[0].Rows[0]["LocationName"].ToString();

                        //Add New Designation Category
                       // BusinessLayer.DesignationCategory = ds.Tables[0].Rows[0]["UserType"].ToString();  //ds.Tables[0].Rows[0]["DesignationCategory"].ToString();

                        if(BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR)
                        {
                            //objRL.Backup_Process();
                            objRL.LoginBackup_Auto();
                        }

                        //Dashboard objForm = new Dashboard();
                        MainDashboard objForm = new MainDashboard();
                        objForm.Show();
                        this.Hide();

                        //foreach (Process clsProcess in Process.GetProcesses())
                        //    if (clsProcess.ProcessName.Equals("EXCEL"))  //Process Excel?
                        //        clsProcess.Kill();

                        //if (System.Environment.MachineName.ToString() == "Server")
                        //DBBackup();
                    }
                    else
                    {
                        ClearAll();
                        objRL.ShowMessage(20, 4);
                        return;
                    }
                }
                else
                {
                    ClearAll();
                    objRL.ShowMessage(20, 4);
                    return;
                }
            }
            else
            {
                ClearAll();
                objRL.ShowMessage(19, 4);
                return;
            }
        }

        protected void DBBackup()
        {
            string PathNew = @"D:\System Backup\";

            if (!Directory.Exists(PathNew))
                Directory.CreateDirectory(PathNew);

            string DBSavePath = @"D:\System Backup\MissionDB-" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".mdb";

            if (System.IO.File.Exists(BusinessLayer.DBPathMain))
            {
                if (!System.IO.File.Exists(DBSavePath))
                    System.IO.File.Copy(BusinessLayer.DBPathMain, DBSavePath);
                else
                {
                    System.IO.File.Delete(DBSavePath);
                    System.IO.File.Copy(BusinessLayer.DBPathMain, DBSavePath);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //CallMySql();
            ClearAll();
            //Application.Exit();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoginSuccess();
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPassword.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void LoginWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.L)       // Ctrl-S Save
            {
                // Do what you want here
                e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
                LoginSuccess();
            }

            if (e.Alt && e.KeyCode == Keys.X)       // Ctrl-S Save
            {
                // Do what you want here
                e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
                Application.Exit();
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lbHelp_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(BusinessResources.WEBSITE);
            Process.Start(sInfo);
        }
    }
}
