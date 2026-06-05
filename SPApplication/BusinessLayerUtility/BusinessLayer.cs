using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Management;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace BusinessLayerUtility
{
    public class BusinessLayer
    {
        public static int UpdateVersion = 1;

        public string Query = "";

        //Access
        //public OleDbCommand objCmd;
        //public OleDbConnection objCon;
        //public OleDbDataAdapter da;

        //MySql
        public MySqlCommand objCmd;
        public MySqlConnection objCon;
        public MySqlDataAdapter da;

        public string conString = string.Empty;

        public static string UserName_Static;
        public static int LoginId_Static;
        public static int EmployeeLoginId_Static;
        public static string UserName_Full_Static;
        public static string DBPathMain;
        public static string UserType;

        public static string Designation;
        //public static string DesignationCategory;
        public static string Department;

        public static int DesignationId;
        public static int DepartmentId;
        public static int LocationId;
        public static string LocationName;

        //public void Connect_MySql()
        //{
        //    try
        //    {
        //        //conn = "Server=127.0.0.1;Database=officedb;Uid=root;Pwd=Logical@1;";
        //        //conn = "Server = 127.0.0.1;Port=3306;Database=officedb;Uid=root;Pwd = Logical@1;";
        //        //conn = "Server=localhost;Port=3306;Database=clinicprodb;Uid=root;Pwd=;";
        //          //System.Configuration.ConfigurationManager.ConnectionStrings["MyCon"].ToString();
        //        //conn = "Server=DESKTOP-HG0MGJT;Database=officedb;Uid=root;Pwd=Logical@1;";
        //        objCon = new MySqlConnection(conString);
        //        objCon.Open();
        //        //FillData();
        //    }
        //    catch (MySqlException e)
        //    {
        //        throw;
        //    }
        //}

        //public static string ServerName = ConfigurationManager.AppSettings["MachineName"]; //GetPath("MachineName");//  "Yashwant";
        //public static string PortNumber = "3306";
        //public static string DatabaseName = "laxmiclinicdb";
        // public static string DatabaseName = "laxmiclinicdb";
        //public static string DatabaseName = "sampledata";
        //public static string DatabasePassword = "Clinic@1234";


        //public static string DatabasePassword = "cp@30012014";
        //public static string DatabaseUser = "clinicuser";
        //public static string PasswordBackup = @"" + DatabasePassword + "";


        // public static string Uid = "root";
        // //public static string Uid = "clinicuser";

        // //My Machine
        // //public static string DatabaseUser = "clinicuser";
        // //public static string DatabasePassword = "cp@30012014";

        //// public static string DatabaseUser = "clinicuser";
        // public static string DatabasePassword = "Clinic@1234";


        public static string ServerName = ConfigurationManager.AppSettings["MachineName"];
        public static string PortNumber = "3306";
        //public static string DatabaseName = "malasdbnew";
        public static string DatabaseName = "malasdb";
        public static string PasswordBackup = @"" + DatabasePassword + "";


        //For Doctor Amit Jamdade
        //public static string Uid = "clinicuser";
        //public static string DatabasePassword = "Clinic@1234";

        ////For Doctor Dattakumar Gurav Satar
        //public static string Uid = "root";
        //public static string DatabasePassword = "Clinic@1234";

        //For Malas
        public static string Uid = "HRM";
        public static string DatabasePassword = "Clinic@1234";

        //For Yashwant Machine
        //public static string Uid = "root";
        //public static string DatabasePassword = "Clinic@1234";

        public static string GetPath(string KeyName)
        {
            string RPath = "";
            RPath = ConfigurationManager.AppSettings[KeyName];

            if (!string.IsNullOrEmpty(RPath))
                RPath = RPath + ConfigurationManager.AppSettings[KeyName];

            return RPath;
        }

        public void Connect()
        {
            try
            {
                //conString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\198.168.2.3\Yashwant\Projects\Surya Hospital\SPApplication\Database\MDAppsDB.mdb";

                //conString = "Server=localhost;Port=3306;Database=laxmiclinicdb;Uid=root;Pwd=Clinic@1234";

                //LAN Connection Connection String
               //conString = "Server=" + ServerName + ";Port=" + PortNumber + ";Database=" + DatabaseName + ";Uid=" + Uid + ";Pwd=" + DatabasePassword + "";
                conString = ConfigurationManager.ConnectionStrings["MyCon"].ToString();
                // conString = "Server=Doctor;Port=3306;Database=laxmiclinicdb;Uid=clinicuser;Pwd=Clinic@1234";

                //conString = "Server=192.168.0.10;Port=3306;Database=laxmiclinicdb;Uid=clinicuser;Pwd=Clinic@1234";


                //Access
                //conString = System.Configuration.ConfigurationManager.ConnectionStrings["MyCon"].ToString();

                //conString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\GRAVITY-PC\Yashwant\Projects\Surya Hospital\SPApplication\Database\MDAppsDB.mdb";

                //conString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\Yashwant\Projects\Surya Hospital\SPApplication\Database\MDAppsDB.mdb";
                //conString = System.Configuration.ConfigurationManager.ConnectionStrings["MyCon"].ToString();

                //objCon = new OleDbConnection(conString);
                //objCon.Open();


                //objCon = new OleDbConnection(conString);
                //objCon.Open();

                objCon = new MySqlConnection(conString);
                objCon.Open();

                //string constring = "server=localhost;user=root;pwd=qwerty;database=test;";
                //string file = "C:\\backup.sql";
                //using (MySqlConnection conn = new MySqlConnection(constring))
                //{
                //    using (MySqlCommand cmd = new MySqlCommand())
                //    {
                //        using (MySqlBackup mb = new MySqlBackup(cmd))
                //        {
                //            cmd.Connection = conn;
                //            conn.Open();
                //            mb.ExportToFile(file);
                //            conn.Close();
                //        }
                //    }
                //}
            }
            catch (Exception ex1)
            {
                MessageBox.Show("Server is not found." + ex1, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("Server is not found.");
                return;
            }
        }

        public MySqlConnection ReturnConnection()
        {
            try
            {
                conString = ConfigurationManager.ConnectionStrings["MyCon"].ToString();
                objCon = new MySqlConnection(conString);
                return objCon;
                 
            }
            catch (Exception ex1)
            {
                MessageBox.Show("Server is not found." + ex1, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("Server is not found.");
                return objCon;
            }
        }

        public int Function_ExecuteNonQuery()
        {
            //RedundancyLogics objRL = new RedundancyLogics(); DesignLayer objDL = new DesignLayer();
            //int Result = 0;
            //try
            //{
            //    Connect();
            //    objCmd = new OleDbCommand(Query, objCon);
            //    Result = objCmd.ExecuteNonQuery();
            //    objCon.Close();
            //}
            //catch (Exception ex1) {objRL.ErrorMessge(ex1.ToString()); }
            //finally { GC.Collect(); }
            //return Result;

            RedundancyLogics objRL = new RedundancyLogics(); 
            //DesignLayer objDL = new DesignLayer();
            int Result = 0;
            try
            {
                Connect();
                objCmd = new MySqlCommand(Query, objCon);
                Result = objCmd.ExecuteNonQuery();
                objCon.Close();
            }
            catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
            finally { GC.Collect(); }
            return Result;
        }

        public DataSet ReturnDataSet()
        {
            //RedundancyLogics objRL = new RedundancyLogics(); DesignLayer objDL = new DesignLayer();
            //DataSet ds = new DataSet();
            //try
            //{
            //    Connect();
            //    objCmd = new OleDbCommand(Query, objCon);
            //    da = new OleDbDataAdapter(objCmd);
            //    da.Fill(ds);
            //    objCon.Close();
            //}
            //catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
            //finally { GC.Collect(); objCon.Close(); }

            //return ds;

            //RedundancyLogics objRL = new RedundancyLogics(); DesignLayer objDL = new DesignLayer();
            //DataSet ds = new DataSet();
            //try
            //{
            //    Connect();
            //    objCmd = new OleDbCommand(Query, objCon);
            //    da = new OleDbDataAdapter(objCmd);
            //    da.Fill(ds);
            //    objCon.Close();
            //}
            //catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
            //finally { GC.Collect(); objCon.Close(); }

            //return ds;

            RedundancyLogics objRL = new RedundancyLogics(); 
            DesignLayer objDL = new DesignLayer();
            DataSet ds = new DataSet();
            try
            {
                Connect();
                objCmd = new MySqlCommand(Query, objCon);
                da = new MySqlDataAdapter(objCmd);
                da.Fill(ds);
                objCon.Close();
            }
            catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
            finally { GC.Collect(); objCon.Close(); }

            return ds;
        }

        //public OleDbDataReader ReturnDataReader()
        //{
        //    OleDbDataReader ds ;
        //    RedundancyLogics objRL = new RedundancyLogics(); DesignLayer objDL = new DesignLayer();

        //    try
        //    {
        //        Connect();
        //        objCmd = new OleDbCommand(Query, objCon);
        //        ds = objCmd.ExecuteReader();
        //        //da = new OleDbDataAdapter(objCmd);
        //        //da.Fill(ds);
        //        objCon.Close();
        //        //return ds;
        //    }
        //    catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); return ds; }
        //    finally { GC.Collect(); objCon.Close(); }

        //    return ds;
        //}

        public DataTable ReturnDataTable()
        {
            //RedundancyLogics objRL = new RedundancyLogics(); DesignLayer objDL = new DesignLayer();
            //DataTable dt = new DataTable();
            //try
            //{
            //    Connect();
            //    objCmd = new OleDbCommand(Query, objCon);
            //    da = new OleDbDataAdapter(objCmd);
            //    da.Fill(dt);
            //    objCon.Close();
            //}
            //catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
            //finally { GC.Collect(); }

            //return dt;

            RedundancyLogics objRL = new RedundancyLogics(); 
            DesignLayer objDL = new DesignLayer();
            DataTable dt = new DataTable();
            try
            {
                Connect();
                objCmd = new MySqlCommand(Query, objCon);
                da = new MySqlDataAdapter(objCmd);
                da.Fill(dt);
                objCon.Close();
            }
            catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
            finally { GC.Collect(); }

            return dt;
        }

        public string GetMacAddress()
        {
            string MachineName = Environment.MachineName.ToString();
           
            return MachineName;


            //string macAddresses = string.Empty;
            //////ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_NetworkAdapter Where AdapterType='Ethernet 802.3'");
            ////ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_NetworkAdapter");
            ////foreach (ManagementObject mo in mos.Get())
            ////{
            ////    string id= mo["Name"].ToString();

            ////    //comboBox1.Items.Add(mo["Name"].ToString());
            ////}

            //IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            //NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

            ////MessageBox.Show()
            ////Console.WriteLine("Interface information for {0}.{1}     ",
            //        //computerProperties.HostName, computerProperties.DomainName);
            //if (nics == null || nics.Length < 1)
            //{
            //    //Console.WriteLine("  No network interfaces found.");
            //    //return;
            //}

            //Console.WriteLine("  Number of interfaces .................... : {0}", nics.Length);
            //foreach (NetworkInterface adapter in nics)
            //{
            //    IPInterfaceProperties properties = adapter.GetIPProperties(); //  .GetIPInterfaceProperties();
            //    //Console.WriteLine();
            //    //Console.WriteLine(adapter.Description);
            //    //Console.WriteLine(String.Empty.PadLeft(adapter.Description.Length, '='));
            //    //Console.WriteLine("  Interface type .......................... : {0}", adapter.NetworkInterfaceType);

            //    //if (adapter.NetworkInterfaceType.ToString() == "Wi-Fi")
            //    if (adapter.Name.ToString() == "Ethernet")
            //    {
            //        PhysicalAddress address11 = adapter.GetPhysicalAddress();
            //        macAddresses = address11.ToString();
            //        break;
            //    }
            //    //Console.Write("  Physical address ........................ : ");
            //    //PhysicalAddress address = adapter.GetPhysicalAddress();
            //    //byte[] bytes = address.GetAddressBytes();
            //    //for (int i = 0; i < bytes.Length; i++)
            //    //{
            //    //    // Display the physical address in hexadecimal.
            //    //    Console.Write("{0}", bytes[i].ToString("X2"));
            //    //    // Insert a hyphen after each byte, unless we are at the end of the 
            //    //    // address.
            //    //    if (i != bytes.Length - 1)
            //    //    {
            //    //        Console.Write("-");
            //    //    }
            //    //}
            //    //Console.WriteLine();
            //}

            

            ////foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            ////{
            ////    if (nic.OperationalStatus == OperationalStatus.Up)
            ////    {
            ////        macAddresses += nic.GetPhysicalAddress().ToString();
            ////        break;
            ////    }
            ////}
            //return macAddresses;
        }

        public string GetMacAddressNew()
        {
            string macAddresses = string.Empty;

            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            string MACAddress = "";

            foreach (ManagementObject mo in moc)
            {
                if (mo["MacAddress"] != null)
                {
                    MACAddress = mo["MacAddress"].ToString();
                }
            }

            //Yashwant Machine Address-: 00:27:0E:0C:4E:81
            //Pushkaraj Sir Machine Address-: 
            //Laptop Address-: 00:1D:72:25:FE:5D

            macAddresses = MACAddress;
            return macAddresses;
            //if (MACAddress != "00:26:22:CF:4F:61")
            //{
            //    //objMUC.ShowMessageBox(52, 9);
            //    Application.Exit();
            //}
        }

        //Password Encription Decrypt
        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            System.Configuration.AppSettingsReader settingsReader =
                                                new AppSettingsReader();
            // Get the key from config file

            string key = (string)settingsReader.GetValue("SecurityKey",
                                                             typeof(String));
            //System.Windows.Forms.MessageBox.Show(key);
            //If hashing use get hashcode regards to your key
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //Always release the resources and flush data
                // of the Cryptographic service provide. Best Practice

                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes.
            //We choose ECB(Electronic code Book)
            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)

            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            //transform the specified region of bytes array to resultArray
            byte[] resultArray =
              cTransform.TransformFinalBlock(toEncryptArray, 0,
              toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor
            tdes.Clear();
            //Return the encrypted data into unreadable string format
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string Decrypt(string cipherString, bool useHashing)
        {
            byte[] keyArray;
            //get the byte code of the string

            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            System.Configuration.AppSettingsReader settingsReader =
                                                new AppSettingsReader();
            //Get your key from config file to open the lock!
            string key = (string)settingsReader.GetValue("SecurityKey",
                                                         typeof(String));

            if (useHashing)
            {
                //if hashing was used get the hash code with regards to your key
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //release any resource held by the MD5CryptoServiceProvider

                hashmd5.Clear();
            }
            else
            {
                //if hashing was not implemented get the byte code of the key
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes. 
            //We choose ECB(Electronic code Book)

            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                                 toEncryptArray, 0, toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor                
            tdes.Clear();
            //return the Clear decrypted TEXT
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        public void FillComboBox(ComboBox cmb, string DisplayMember, string ValueMember)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = ReturnDataSet();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmb.DataSource = ds.Tables[0];
                    cmb.DisplayMember = DisplayMember;
                    cmb.ValueMember = ValueMember;
                }
            }
            catch (Exception ex1) { MessageBox.Show(ex1.ToString()); }
            finally { GC.Collect(); }
        }

        //ESSL Connection and DB

        public OleDbCommand objCmd_Access_ESSL;
        public OleDbConnection objCon_Access_ESSL;
        public OleDbDataAdapter da_Access_ESSL;

        public string conStringEssl = null;
        public string conStringErp = null;
        public string QueryESSL = "";

        public SqlCommand objCmd_SQL_ESSL;
        public SqlConnection objCon_SQL_ESSL;
        public SqlDataAdapter da_SQL_ESSL;

        public SqlCommand objCmd_SQL_Erp;
        public SqlConnection objCon_SQL_Erp;
        public SqlDataAdapter da_SQL_Erp;

        public void ConnectESSL(string ConType)
        {
            try
            {
                if (ConType == BusinessResources.Database_ACCESS)
                {
                    conStringEssl = ConfigurationManager.ConnectionStrings["ESSLConnectionAccess"].ToString();
                    objCon_Access_ESSL = new OleDbConnection(conStringEssl);
                    objCon_Access_ESSL.Open();
                }
                else
                {
                    conStringEssl = ConfigurationManager.ConnectionStrings["ESSLConnectionSql"].ToString();
                    objCon_SQL_ESSL = new SqlConnection(conStringEssl);
                    objCon_SQL_ESSL.Open();
                }

            }
            catch (Exception ex1)
            {
                MessageBox.Show("Server is not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }



         public int Function_ExecuteNonQuery_ESSL(string ConType)
        {
            RedundancyLogics objRL = new RedundancyLogics(); 
            int Result = 0;

            try
            {
                ConnectESSL(ConType);

                if (ConType == BusinessResources.Database_ACCESS)
                {
                    objCmd_Access_ESSL = new OleDbCommand(Query, objCon_Access_ESSL);
                    Result = objCmd_Access_ESSL.ExecuteNonQuery();
                    objCon_Access_ESSL.Close();
                }
                else
                {
                    objCmd_SQL_ESSL = new SqlCommand(Query, objCon_SQL_ESSL);
                    Result = objCmd_SQL_ESSL.ExecuteNonQuery();
                    objCon_SQL_ESSL.Close(); 
                }
            }
            catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
            finally { GC.Collect(); }
            return Result;
        }

        public DataSet ReturnDataSet_ESSL(string ConType)
        {
            RedundancyLogics objRL = new RedundancyLogics();  
            DataSet ds = new DataSet();
            try
            {
                ConnectESSL(ConType);
                if (ConType == BusinessResources.Database_ACCESS)
                {
                    objCmd_Access_ESSL = new OleDbCommand(Query, objCon_Access_ESSL);
                    da_Access_ESSL = new OleDbDataAdapter(objCmd_Access_ESSL);
                    da_Access_ESSL.Fill(ds);
                    objCon_Access_ESSL.Close();
                }
                else
                {
                    objCmd_SQL_ESSL = new SqlCommand(Query, objCon_SQL_ESSL);
                    da_SQL_ESSL = new SqlDataAdapter(objCmd_SQL_ESSL);
                    da_SQL_ESSL.Fill(ds);
                    objCon_SQL_ESSL.Close();
                }
            }
            catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
            finally { GC.Collect();   }

            return ds;
        }

        public DataTable ReturnDataTable_ESSL(string ConType)
        {
            RedundancyLogics objRL = new RedundancyLogics();
            DataTable dt = new DataTable();
            try
            {
                ConnectESSL(ConType);
                if (ConType == BusinessResources.Database_ACCESS)
                {
                    objCmd_Access_ESSL = new OleDbCommand(Query, objCon_Access_ESSL);
                    da_Access_ESSL = new OleDbDataAdapter(objCmd_Access_ESSL);
                    da_Access_ESSL.Fill(dt);
                    objCon_Access_ESSL.Close();
                }
                else
                {
                    objCmd_SQL_ESSL = new SqlCommand(Query, objCon_SQL_ESSL);
                    da_SQL_ESSL = new SqlDataAdapter(objCmd_SQL_ESSL);
                    da_SQL_ESSL.Fill(dt);
                    objCon_SQL_ESSL.Close();
                }
            }
            catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
            finally { GC.Collect(); }

            return dt;
        }

        public void ConnectESSL_F()
        {
            try
            {
                conStringErp = ConfigurationManager.ConnectionStrings["ERPConnectionSql"].ToString();
                objCon_SQL_Erp = new SqlConnection(conStringErp);
                objCon_SQL_Erp.Open();
            }
            catch (Exception ex1)
            {
                MessageBox.Show("Server is not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
