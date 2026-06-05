using BusinessLayerUtility;
using SPApplication.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPApplication.AssetApplication
{
    public partial class AssetClient : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        //bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int TableId = 0, Result = 0;

        public AssetClient()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_CLIENTCONFIGURATIONS);
            objDL.SetPlusButtonDesign(btnAddAssetType);
            objRL.Fill_AssetTypeMaster(cmbAssetType);
            ClearAll();
            Fill_System_Data();
            FillGrid();
            objRL.Fill_Location_ComboBox(cmbLocation);
        }

        private void AddMasterData(string MasterType)
        {
            CommanMasterAsset objForm = new CommanMasterAsset(MasterType);
            objForm.ShowDialog(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private bool Validation()
        {
            objEP.Clear();
            if (cmbAssetType.SelectedIndex == -1)
            {
                txtSerialNumber.Focus();
                objEP.SetError(txtSerialNumber, "Enter Serial Number");
                return true;
            }
            else if (txtSerialNumber.Text == "")
            {
                txtSerialNumber.Focus();
                objEP.SetError(txtSerialNumber, "Enter Serial Number");
                return true;
            }
            else if (cmbLocation.SelectedIndex == -1)
            {
                cmbLocation.Focus();
                objEP.SetError(cmbLocation, "Enter Location");
                return true;
            }
            else if (cmbDepartment.SelectedIndex == -1)
            {
                cmbDepartment.Focus();
                objEP.SetError(cmbDepartment, "Enter Department");
                return true;
            }
            else if (cmbEmployeeName.SelectedIndex == -1)
            {
                cmbEmployeeName.Focus();
                objEP.SetError(cmbEmployeeName, "Enter Employee Name");
                return true;
            }
            else if (txtAssetCode.Text == "")
            {
                txtAssetCode.Focus();
                objEP.SetError(txtAssetCode, "Enter Asset Code");
                return true;
            }
            else
                return false;
        }

        private bool CheckExist()
        {
            bool RFlag = false;
            DataSet ds = new DataSet();
            objBL.Query = "select * from AssetMaster where SerialNumber='" + txtSerialNumber.Text + "' and CancelTag=0 and AssetMasterId !=" + TableId + "";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                RFlag = true;
                TableId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["AssetMasterId"])));
                txtAssetID.Text = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["AssetMasterId"]));
            }
            else
                RFlag = false;

            return RFlag;
        }

        private void FillGrid_SerialNumber()
        {
            //DataSet ds = new DataSet();
            //dataGridView1.DataSource = null;
            //WhereBasic = string.Empty; TableClause = string.Empty; WhereClause = string.Empty;

            //lblTotalCount.Text = "";
            //MainQuery = "select  AM.AssetMasterId, " +
            //                    "AM.EntryDate," +
            //                    "AM.FixedAssetCode, " +
            //                    "AM.AssetTypeId, " +
            //                    "ATM.AssetType as 'Asset Type'," +
            //                    "AM.ModelNo, " +
            //                    "AM.SerialNumber, " +
            //                    "AM.DomainName, " +
            //                    "AM.UserName, " +
            //                    "AM.DeviceManufracturer, " +
            //                    "AM.DeviceName, " +
            //                    "AM.Processor, " +
            //                    "AM.RAM, " +
            //                    "AM.RAMType, " +
            //                    "AM.MotherBoardSerialNo, " +
            //                    "AM.DeviceID, " +
            //                    "AM.ProductID, " +
            //                    "AM.HDDModel, " +
            //                    "AM.HDDSize, " +
            //                    "AM.HDDType, " +
            //                    "AM.SSDModel, " +
            //                    "AM.SSDSize, " +
            //                    "AM.SSDType, " +
            //                    "AM.Edition, " +
            //                    "AM.Version, " +
            //                    "AM.InstalledOn, " +
            //                    "AM.OSBuild, " +
            //                    "AM.Experience, " +
            //                    "AM.OSManufacturer, " +
            //                    "AM.MACAddress, " +
            //                    "AM.IPAddress, " +
            //                    "AM.Status, " +
            //                    "AM.UserId " +
            //                    " from assetmaster AM inner join " +
            //                    " assettypemaster ATM on ATM.AssetTypeId=AM.AssetTypeId ";

            //WhereBasic = " where AM.CancelTag=0 and ATM.CancelTag=0 ";

            //OrderByClause = " order by AM.AssetMasterId asc";

            //if (txtSearch.Text != "")
            //    WhereClause = " and AM.SerialNumber='" + txtSerialNumber.Text + "'";
            //else
            //    WhereClause = "";

            //objBL.Query = MainQuery + WhereBasic + WhereClause;
            //ds = objBL.ReturnDataSet();

            //if (ds.Tables[0].Rows.Count > 0)
            //{

            //}
        }

        //2001-2002
        //03/03/2024

        private void SaveDB()
        {
            if (!Validation())
            {
                if (CheckExist())
                {
                    //objRL.ShowMessage(12, 4);
                    //return;
                }

                objPC.AssetMasterId = TableId; //Convert.ToInt32(txtAssetID.Text);
                objPC.EntryDate = dtpDate.Value;
                objPC.FixedAssetCode = txtFixedAssetCode.Text;
                objPC.AssetTypeId = Convert.ToInt32(cmbAssetType.SelectedValue);
                objPC.ModelNo = txtModelNo.Text;
                objPC.SerialNumber = txtSerialNumber.Text;
                objPC.DomainName = txtDomainName.Text;
                objPC.UserName = txtUserName.Text;
                objPC.DeviceManufracturer = txtDeviceManufracturer.Text;
                objPC.DeviceName = txtDeviceName.Text;
                objPC.Processor = txtProcessor.Text;
                objPC.RAM = txtRAM.Text;
                objPC.RAMType = txtRAMType.Text;
                objPC.MotherBoardSerialNo = txtMotherBoardSerialNo.Text;
                objPC.DeviceID = txtDeviceID.Text;
                objPC.ProductID = txtProductD.Text;
                objPC.HDDModel = txtHDDModel.Text;
                objPC.HDDSize = txtHDDSize.Text;
                objPC.HDDType = txtHDDType.Text;
                objPC.SSDModel = txtSDDModel.Text;
                objPC.SSDSize = txtSDDSize.Text;
                objPC.SSDType = txtSSDType.Text;
                objPC.Edition = txtEdition.Text;
                objPC.Version = txtVersion.Text;
                objPC.InstalledOn = Convert.ToDateTime(txtInstalledOn.Text);
                objPC.OSBuild = txtOSBuild.Text;
                objPC.Experience = txtExperience.Text;
                objPC.OSManufacturer = txtOSManufracturer.Text;
                objPC.MACAddress = txtMACAddress.Text;
                objPC.IPAddress = txtIPAddress.Text;
                objPC.AssetStatus = cmbStatus.Text;
                objPC.EmployeeId = Convert.ToInt32(cmbEmployeeName.SelectedValue);
                objPC.AssetCode = txtAssetCode.Text;
                Result = objQL.SP_AssetMaster_Insert_Update_Delete();

                if (Result > 0)
                {
                    objRL.ShowMessage(7, 1);
                    FillGrid();
                }
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }

        string MainQuery = string.Empty, WhereBasic = string.Empty, TableClause = string.Empty, WhereClause = string.Empty, OrderByClause = string.Empty;

        private void FillGrid()
        {
            if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR || BusinessLayer.Designation == "IT HEAD" || BusinessLayer.Department == "INFORMATION TECHNOLOGY")
            {
                try
                {
                    DataSet ds = new DataSet();
                    dataGridView1.DataSource = null;
                    WhereBasic = string.Empty; TableClause = string.Empty; WhereClause = string.Empty;

                    lblTotalCount.Text = "";

                    MainQuery = "select  AM.AssetMasterId, " +
                                        "AM.EntryDate," +
                                        "AM.FixedAssetCode, " +
                                        "AM.AssetTypeId, " +
                                        "L.LocationName, " +
                                        "D.Department," +
                                        "AM.EmployeeId," +
                                        "E.EmployeeName, " +
                                        "ATM.AssetType as 'Asset Type'," +
                                        "AM.ModelNo, " +
                                        "AM.SerialNumber, " +
                                        "AM.DomainName, " +
                                        "AM.UserName, " +
                                        "AM.DeviceManufracturer, " +
                                        "AM.DeviceName, " +
                                        "AM.Processor, " +
                                        "AM.RAM, " +
                                        "AM.RAMType, " +
                                        "AM.MotherBoardSerialNo, " +
                                        "AM.DeviceID, " +
                                        "AM.ProductID, " +
                                        "AM.HDDModel, " +
                                        "AM.HDDSize, " +
                                        "AM.HDDType, " +
                                        "AM.SSDModel, " +
                                        "AM.SSDSize, " +
                                        "AM.SSDType, " +
                                        "AM.Edition, " +
                                        "AM.Version, " +
                                        "AM.InstalledOn, " +
                                        "AM.OSBuild, " +
                                        "AM.Experience, " +
                                        "AM.OSManufacturer, " +
                                        "AM.MACAddress, " +
                                        "AM.IPAddress, " +
                                        "AM.Status " +
                                        " from assetmaster AM inner join " +
                                        " assettypemaster ATM on ATM.AssetTypeId=AM.AssetTypeId inner join " +
                                        " employees E on E.EmployeeId=AM.EmployeeId inner join " +
                                        " locationmaster L on E.LocationId=L.LocationId inner join " +
                                        " departmentmaster D on E.DepartmentId=D.DepartmentId ";

                    WhereBasic = " where AM.CancelTag=0 and ATM.CancelTag=0 and E.CancelTag=0 and L.CancelTag=0 and D.CancelTag=0 ";

                    OrderByClause = " order by AM.AssetMasterId asc";

                    if (txtSearch.Text != "")
                        WhereClause = " and E.EmployeeName LIKE '%" + txtSearch.Text + "%'";
                    else
                        WhereClause = "";

                    objBL.Query = MainQuery + WhereBasic + WhereClause;
                    ds = objBL.ReturnDataSet();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //0 AM.AssetMasterId, "+
                        //1 AM.EntryDate, " +
                        //2 "AM.FixedAssetCode, " +
                        //3 "AM.AssetTypeId, " +
                        //4 "ATM.AssetType as 'Asset Type',"+
                        //5 "AM.ModelNo, " +
                        //6 "AM.SerialNumber, " +
                        //7 "AM.DomainName, " +
                        //"AM.UserName, " +
                        //"AM.DeviceManufracturer, " +
                        //"AM.DeviceName, " +
                        //"AM.Processor, " +
                        //"AM.RAM, " +
                        //"AM.RAMType, " +
                        //"AM.MotherBoardSerialNo, " +
                        //"AM.DeviceID, " +
                        //"AM.ProductID, " +
                        //"AM.HDDModel, " +
                        //"AM.HDDSize, " +
                        //"AM.HDDType, " +
                        //"AM.SSDModel, " +
                        //"AM.SSDSize, " +
                        //"AM.SSDType, " +
                        //"AM.Edition, " +
                        //"AM.Version, " +
                        //"AM.InstalledOn, " +
                        //"AM.OSBuild, " +
                        //"AM.Experience, " +
                        //"AM.OSManufacturer, " +
                        //"AM.MACAddress, " +
                        //"AM.IPAddress, " +
                        //"AM.Status, " +
                        //"AM.UserId "+

                        lblTotalCount.Text = "Total Count-" + ds.Tables[0].Rows.Count;
                        dataGridView1.DataSource = ds.Tables[0];

                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        {
                            dataGridView1.Columns[i].Width = 120;
                        }
                    }
                }
                catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
                finally { GC.Collect(); }
            }
        }


        private void Get_AssetID()
        {
            string FACode = string.Empty;
            txtAssetID.Text = Convert.ToString(objRL.ReturnMaxID_Increase("assetmaster", "AssetMasterId"));

            if (TableId == 0)
            {
                FACode = "FAC-" + txtAssetID.Text + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
                txtFixedAssetCode.Text = FACode.ToString();
            }
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
            ClearAll();
        }

        private void ClearAll()
        {
            TableId = 0;
            objEP.Clear();
            txtFixedAssetCode.Text = "";
            txtAssetID.Text = "";
            cmbAssetType.SelectedIndex = -1;
            txtSerialNumber.Text = "";
            txtDeviceManufracturer.Text = "";
            txtDeviceName.Text = "";
            txtProcessor.Text = "";
            txtRAM.Text = "";
            txtRAMType.Text = "";
            txtDeviceID.Text = "";
            txtProductD.Text = "";
            txtEdition.Text = "";
            txtVersion.Text = "";
            txtInstalledOn.Text = "";
            txtOSBuild.Text = "";
            txtExperience.Text = "";
            txtOSManufracturer.Text = "";
            txtHDDModel.Text = "";
            txtHDDSize.Text = "";
            txtHDDType.Text = "";
            txtSDDModel.Text = "";
            txtSDDSize.Text = "";
            txtSSDType.Text = "";
            txtMACAddress.Text = "";
            txtIPAddress.Text = "";
            txtDomainName.Text = "";
            txtUserName.Text = "";
            Get_AssetID();
            lbSoftware.DataSource = null;
        }

        private void Fill_System_Data()
        {
            ClearAll();
            cmbAssetType.Text = objRL.Get_System_Data(BusinessResources.A_Win32_ComputerSystem, BusinessResources.A_PCSystemType);
            txtModelNo.Text = objRL.Get_System_Data(BusinessResources.A_Win32_ComputerSystem, BusinessResources.A_Model);

            txtSerialNumber.Text = objRL.Get_System_Data(BusinessResources.A_Win32_BIOS, BusinessResources.A_SerialNumber);
            txtDeviceManufracturer.Text = objRL.Get_System_Data(BusinessResources.A_Win32_ComputerSystem, BusinessResources.A_Manufacturer);
            txtDeviceName.Text = Environment.MachineName;
            txtProcessor.Text = objRL.Get_System_Data(BusinessResources.A_Processor, "");
            txtRAM.Text = objRL.Get_System_Data(BusinessResources.A_Win32_ComputerSystem, BusinessResources.A_TotalPhysicalMemory);
            txtRAMType.Text = objRL.RAMType.ToString();

            txtMotherBoardSerialNo.Text = objRL.Get_System_Data(BusinessResources.A_Win32_BaseBoard, BusinessResources.A_SerialNumber);
            txtDeviceID.Text = objRL.Get_System_Data(BusinessResources.A_Win32_ComputerSystemProduct, BusinessResources.A_UUID);
            txtProductD.Text = objRL.Get_System_Data(BusinessResources.A_Win32_OperatingSystem, BusinessResources.A_SerialNumber);
            txtEdition.Text = objRL.Get_System_Data(BusinessResources.A_Win32_OperatingSystem, BusinessResources.A_Caption);
            txtVersion.Text = Environment.OSVersion.VersionString;

            txtInstalledOn.Text = objRL.Get_System_Data(BusinessResources.A_Win32_OperatingSystem, BusinessResources.A_InstallDate);
            txtOSBuild.Text = Environment.OSVersion.Version.Build.ToString();

            txtExperience.Text = objRL.Get_System_Data(BusinessResources.A_Win32_OperatingSystem, BusinessResources.A_Caption);
            txtOSManufracturer.Text = System.Environment.OSVersion.ToString();

            objRL.GetHardDiskDetails();
            txtHDDModel.Text = objRL.HDDModel;
            txtHDDSize.Text = objRL.HDDSize;
            txtHDDType.Text = objRL.HDDType;

            txtSDDModel.Text = objRL.SSDModel;
            txtSDDSize.Text = objRL.SSDSize;
            txtSSDType.Text = objRL.SSDType;

            txtMACAddress.Text = objRL.GetMACAddress();
            txtIPAddress.Text = objRL.GetIPAddress();

            //Domain domain = Domain.GetComputerDomain();
            txtDomainName.Text = Environment.UserDomainName;
            txtUserName.Text = Environment.UserName;

            objRL.GetSoftwareInstalled();
            lbSoftware.DataSource = objRL.lSoftware;
            gbSoftware.Text = "Software Information Count-" + objRL.lSoftware.Count;
        }

        private void AssetClient_Load(object sender, EventArgs e)
        {
            //FillGrid();
        }

        private void btnAddAssetType_Click(object sender, EventArgs e)
        {
            AddMasterData(BusinessResources.TN_AssetType);
            objRL.Fill_AssetTypeMaster(cmbAssetType);
        }

        private void btnAddDocuments_Click(object sender, EventArgs e)
        {

        }

        private void tpAssetSpecs_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void cmbLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ClearAll_Location_Department();
            cmbDepartment.SelectedIndex = -1;
            objRL.FillDepartment(cmbLocation, cmbDepartment);
            Fill_Asset_Code();
        }

        string ConcatCode = string.Empty;
        private void Fill_Asset_Code()
        {
            ConcatCode = string.Empty;
            //UNIT-47
            //UNIT-48
            //UNIT-133
            //UNIT-49
            //ADMIN
            //C-15

            if (cmbLocation.SelectedIndex > -1)
            {
                if (cmbLocation.Text == "UNIT-47" || cmbLocation.Text == "UNIT-48" || cmbLocation.Text == "UNIT-133" || cmbLocation.Text == "UNIT-49" || cmbLocation.Text == "ADMIN" || cmbLocation.Text == "C-15")
                    ConcatCode = "W-";
            }
            else
                ConcatCode = "P-";

            if (cmbDepartment.SelectedIndex > -1)
                ConcatCode += cmbDepartment.Text.Substring(0, 3) + "-";
            //if (cmbEmployeeName.SelectedIndex > -1)
            //    ConcatCode += cmbEmployeeName.Text.Substring(0, 3) + "-";
            //if (cmbEmployeeName.SelectedIndex > -1)
            //    ConcatCode += cmbEmployeeName.Text.Substring(0, 3) + "-";
            if (txtDeviceName.Text !="")
                ConcatCode += txtDeviceName.Text + "-";
            if (txtAssetID.Text != "")
                ConcatCode += txtAssetID.Text;
            
            txtAssetCode.Text = ConcatCode.ToString();
        }

        private void cmbDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FillEmployee_Fixed();
        }

        private void FillEmployee_Fixed()
        {
            //FillEmployees_Combobox();
            ClearAll_Location_Department();

            if (cmbLocation.SelectedIndex > -1 && cmbDepartment.SelectedIndex > -1)
            {
                objQL.WhereClause_V = " and E.LocationId=" + cmbLocation.SelectedValue + "  and E.DepartmentId=" + cmbDepartment.SelectedValue + "  and DM.DesignationCategory NOT IN('" + BusinessResources.USER_TYPE_TRAINEE + "')";
                objQL.SP_Employees_Get_By_All(cmbEmployeeName);

                if (BusinessLayer.UserType == BusinessResources.USER_TYPE_OFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_SUPERVISOR)
                {
                    cmbEmployeeName.Enabled = false;
                    cmbEmployeeName.Text = BusinessLayer.UserName_Full_Static;
                    //objRL.Fill_EmployeeDetails();
                    Fill_EmployeeDetails();
                }
                //objRL.FillEmployees();
                Fill_Asset_Code();
            }
        }

        private void ClearAll_Location_Department()
        {
            cmbEmployeeName.SelectedIndex = -1;
            txtEmployeeCode.Text = "";
            txtDesignation.Text = "";
        }

        private void Fill_EmployeeDetails()
        {
            txtEmployeeCode.Text = "";
            txtDesignation.Text = "";
            if (cmbEmployeeName.SelectedIndex > -1)
            {
                objPC.SearchFlagLeaveCompOff = false;
                objPC.EmployeeId = Convert.ToInt32(cmbEmployeeName.SelectedValue);
                objRL.Fill_EmployeeDetails();
                txtEmployeeCode.Text = objPC.EmployeeCode.ToString();
                txtDesignation.Text = objPC.Designation.ToString();
                Fill_Asset_Code();
            }
        }

        private void cmbEmployeeName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_EmployeeDetails();
        }
    }
}
