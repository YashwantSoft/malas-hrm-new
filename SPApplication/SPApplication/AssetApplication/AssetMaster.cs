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
using System.Management;
using Microsoft.Win32;

namespace SPApplication.Master
{
    public partial class AssetMaster : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        int TableId = 0;
        bool DeleteFlag = false;
        string ExecuteType = "";

        
        public AssetMaster()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_ASSET_MASTER);
            btnViewSystem.Text = BusinessResources.BTN_VIEWDATA;

            objPC.FormName = this.Name;

            btnDelete.Text = BusinessResources.BTN_PRINT;
            btnReport.Text = BusinessResources.BTN_REPORT;

            objDL.SetButtonDesign(btnTransfer, BusinessResources.BTN_SAVE);
            objDL.SetButtonDesign(btnUpgrade, BusinessResources.BTN_SAVE);

            objDL.SetButtonDesign_SmallSize(btnAdd, BusinessResources.BTN_ADD);
            objDL.SetButtonDesign_SmallSize(btnClearDocuments, BusinessResources.BTN_CLEAR);


            objDL.SetPlusButtonDesign(btnAddDocuments);
            objDL.SetPlusButtonDesign(btnAddInstalledSoftwares);
            objDL.SetPlusButtonDesign(btnAddDepartment);
            objDL.SetPlusButtonDesign(btnAddModelNo);
            objDL.SetPlusButtonDesign(btnAddAssetType);
            objDL.SetPlusButtonDesign(btnAddMakeCompany);
            objDL.SetPlusButtonDesign(btnAddBusinessUnit);
            objDL.SetPlusButtonDesign(btnAddProcessor);

            objQL.Fill_Master_ComboBox(cmbDepartment, "departmentmaster");
            objQL.Fill_Master_ComboBox(cmbLocation, "locationmaster");

            objPC.FormName = "AssetMaster";
            objQL.SP_DocumentMaster_Select_ComboBox(cmbDocumentType);
           // objRL.Fill_Documents(cmbDocumentType);

            objRL.Fill_AssetTypeMaster(cmbAssetType);
            objRL.Fill_MakeMaster(cmbMake);

           
            objRL.Fill_OSMaster(cmbOSName);
             

            objRL.CommanAssetMaster(cmbProcessor, "Processor");
            objRL.CommanAssetMaster(cmbRAM, "RAM");
            objRL.CommanAssetMaster(cmbOSBit, "OSType");
            objRL.CommanAssetMaster(cmbOSTag, "OSTag");
            objRL.CommanAssetMaster(cmbSSDType, "HDDSSDType");
            objRL.CommanAssetMaster(cmbHDDType, "HDDSSDType");
            objRL.CommanAssetMaster(cmbSSDSize, "HDDSSDSize");
            objRL.CommanAssetMaster(cmbHDDSize, "HDDSSDSize");
            objRL.CommanAssetMaster(cmbScreen, "Screen");
            objRL.CommanAssetMaster(cmbModelNo, "Model");
            objRL.CommanAssetMaster(cmbUpgrade, "Upgrade");
            // objRL.Fill_HDDSSDMaster(cmbOSName, "OSName");

            objRL.Fill_CheckListBox_Softwares(clbInstalledSoftware);

            objRL.CommanAssetMaster(cmbPurchaseType, "PurchaseType");
            objRL.CommanAssetMaster(cmbSearchBy, "SearchBy");

            btnBrowse.BackColor = objDL.GetBackgroundColor();
            btnBrowse.ForeColor = objDL.GetForeColor();

            btnReport.BackColor = objDL.GetBackgroundColor();
            btnReport.ForeColor = objDL.GetForeColor();
        }

        private void ClearAll()
        {
            AssetLocationId = 0;
            AssetUpgradeId = 0;
            AssetMasterId = 0;
            AssetDocumentsId = 0;
            DeleteFlag = false;
            GridFlag = false;
            TableId = 0;
            objEP.Clear();
            ClearAll_AssetMaster();
            ClearAll_Location();
            ClearAll_Upgrade();
            ClearAll_Documents();
            Get_AssetID();

            cmbLocation.Focus();
        }

        private void ClearAll_AssetMaster()
        {
            TableId = 0;
            dtpDate.Value = DateTime.Now.Date;
            txtAssetCode.Text = "";
            dtpPurchaseDate.Value = DateTime.Now.Date;
            txtInvoiceNo.Text = "";
            cmbWarrantyPeriod.SelectedIndex = -1;
            dtpWarrantyExpiredDate.Value = DateTime.Now.Date;
            txtGRNNo.Text = "";
            cmbStatus.SelectedIndex = -1;
            cmbAssetType.SelectedIndex = -1;
            cmbMake.SelectedIndex = -1;
            cmbModelNo.SelectedIndex = -1;
            txtSerialNumber.Text = "";
            txtAssetCost.Text = "";
            pbQRCode.Image = null;
            txtQRCodeData.Text = "";
            dtpDate.Focus();
        }

        private void ClearAll_Location()
        {
            IsTransfer = 0;
            cbIsTransfer.Checked = false;
            cbIsTransfer.Visible = false;
            txtCurrentLocation.Text = "";
            cmbLocation.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            txtDesignation.Text = "";
            txtUserName.Text = "";
            txtComputerName.Text = "";
            txtNarationLocation.Text = "";
        }

        private void ClearAll_Upgrade()
        {
            IsUpgrade = 0;
            gbUpgrade.Visible = false;
            dtpUpgradeDate.Value = DateTime.Now.Date;
            cmbUpgrade.SelectedIndex = -1;
            cmbWarrantyUpgrade.SelectedIndex = -1;
            dtpWarrantyExpiredDateUpgrade.Value = DateTime.Now.Date;
            txtInvoiceNoUpgrade.Text = "";
            txtGRNNoUpgrade.Text = "";
            txtUpgradeCost.Text = "";
            txtNarationUpgrade.Text = "";
            cmbProcessor.SelectedIndex = -1;
            cmbRAM.SelectedIndex = -1;
            cmbScreen.SelectedIndex = -1;
            cbSSD.Checked = false;
            cmbSSDType.SelectedIndex = -1;
            cmbSSDSize.SelectedIndex = -1;
            cbHDD.Checked = false;
            cmbHDDType.SelectedIndex = -1;
            cmbHDDSize.SelectedIndex = -1;
            cmbOSName.SelectedIndex = -1;
            cmbOSBit.SelectedIndex = -1;
            cmbOSTag.SelectedIndex = -1;
            //clbInstalledSoftware.DataSource = null;
            txtAntivirusSerialNo.Text = "";
            dtpAntivirusExpiryDate.Value = DateTime.Now.Date;
        }

        private void ClearAll_Documents()
        {
            dtpDocumentDate.Value = DateTime.Now.Date;
            cmbDocumentType.SelectedIndex = -1;
            txtFileName.Text = "";
            txtFilePath.Text = "";
            dgvFiles.Rows.Clear();
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

        private bool Validation()
        {
            objEP.Clear();
            if (txtAssetCode.Text == "")
            {
                objEP.SetError(txtAssetCode, "Enter Asset Type");
                txtAssetCode.Focus();
                return true;
            }

            else if (cmbAssetType.SelectedIndex == -1)
            {
                objEP.SetError(cmbAssetType, "Select Asset Type");
                cmbAssetType.Focus();
                return true;
            }
            else if (cmbMake.SelectedIndex == -1)
            {
                objEP.SetError(cmbMake, "Select Make");
                cmbMake.Focus();
                return true;
            }
            else if (txtSerialNumber.Text == "")
            {
                txtSerialNumber.Focus();
                objEP.SetError(txtSerialNumber, "Enter Serial Number");
                return true;
            }

            else if (cmbStatus.SelectedIndex == -1)
            {
                objEP.SetError(cmbStatus, "Select Status");
                cmbStatus.Focus();
                return true;
            }
            else if (cmbPurchaseType.SelectedIndex == -1)
            {
                objEP.SetError(cmbPurchaseType, "Select Purchase Type");
                cmbPurchaseType.Focus();
                return true;
            }
            else if (txtQRCodeData.Text == "")
            {
                txtQRCodeData.Focus();
                objEP.SetError(txtQRCodeData, "Enter QR Code Data");
                return true;
            }
            else
                return false;
        }

        string QRImagePath = string.Empty;

        private bool CheckExist()
        {
            DataSet ds = new DataSet();
            objBL.Query = "select AssetMasterId from AssetMaster where SerialNumber='" + txtSerialNumber.Text + "' and CancelTag=0 and AssetMasterId <> " + TableId + "";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }

        int Result = 0, DepartmentId = 0, AssetUpgradeId = 0, AssetLocationId = 0, AssetMasterId = 0, IsSSD = 0, IsHDD = 0;

        private void SaveDB()
        {
            Result = 0; AssetUpgradeId = 0; AssetLocationId = 0;
            try
            {
                if (!Validation())
                {
                    if (!DeleteFlag)
                    {
                        if (CheckExist())
                        {
                            objRL.ShowMessage(34, 9);
                            return;
                        }
                    }

                    IsSSD = 0; IsHDD = 0;

                    if (TableId != 0)
                    {
                        if (DeleteFlag)
                        {
                            objBL.Query = "update AssetMaster set CancelTag=1 where AssetMasterId=" + objPC.AssetMasterId + "";
                            ExecuteType = "Delete";
                        }
                        else
                        {
                            //objBL.Query = "update AssetMaster set EntryDate='" + dtpDate.Value.ToShortDateString() + "',SiteId=" + cmbBusinessUnit.SelectedValue + ",DepartmentId=" + DepartmentId + ",DepartmentName='" + cmbDepartment.Text + "',AssetUserName='" + txtUserName.Text + "',ComputerName='" + txtComputerName.Text + "',AssetTypeId=" + cmbAssetType.SelectedValue + ",MakeId=" + cmbMake.SelectedValue + ",SerialNumber='" + txtSerialNumber.Text + "',OSName='" + cmbOSName.Text + "',OSType='" + cmbOSType.Text + "',OSTag='" + cmbOSTag.Text + "',Processor='" + cmbProcessor.Text + "',HDDType='" + cmbHDDType1.Text + "',SSD='" + cmbSSD.Text + "',HDD='" + cmbHDD.Text + "',RAM='" + cmbRAM.Text + "',IPAddressLAN='" + txtIPAddressLAN.Text + "',IPAddressWifi='" + txtIPAddressWifi.Text + "',OfficeVersion='" + cmbOfficeVersion.Text + "',AntivirusSerialNumber='" + txtAntivirusSerialNo.Text + "',AntivirusExpiryDate='" + dtpEndDate.Value.ToShortDateString() + "',Status='" + cmbStatus.Text + "',QRCodeData='" + txtQRCodeData.Text + "',ModifiedId=" + BusinessLayer.EmployeeLoginId_Static + " where ID=" + TableId + " and CancelTag=0";
                            objBL.Query = "update AssetMaster set EntryDate='" + dtpDate.Value.ToShortDateString() + "',PurchaseDate='" + dtpPurchaseDate.Value.ToShortDateString() + "',InvoiceNo='" + txtInvoiceNo.Text + "',WarrantyPeriod='" + cmbWarrantyPeriod.Text + "',WarrantyEndDate='" + dtpPurchaseDate.Value.ToShortDateString() + "',GRNNo='" + txtGRNNo.Text + "',Status='" + cmbStatus.Text + "',AssetTypeId=" + cmbAssetType.SelectedValue + ",MakeId=" + cmbMake.SelectedValue + ",ModelNo='" + cmbModelNo.Text + "',SerialNumber='" + txtSerialNumber.Text + "',AssetCost='" + txtAssetCost.Text + "',QRCodeData='" + txtQRCodeData.Text + "',PurchaseType='" + cmbPurchaseType.Text + "',ModifiedId=" + BusinessLayer.EmployeeLoginId_Static + " where AssetMasterId=" + objPC.AssetMasterId + " and CancelTag=0";
                            ExecuteType = "Update";

                            // SiteId=" + cmbBusinessUnit.SelectedValue + ",DepartmentId=" + DepartmentId + ",AssetUserName='" + txtUserName.Text + "',ComputerName='" + txtComputerName.Text + "',AssetTypeId=" + cmbAssetType.SelectedValue + ",MakeId=" + cmbMake.SelectedValue + ",SerialNumber='" + txtSerialNumber.Text + "',OSName='" + cmbOSName.Text + "',OSType='" + cmbOSType.Text + "',OSTag='" + cmbOSTag.Text + "',Processor='" + cmbProcessor.Text + "',HDDType='" + cmbHDDType1.Text + "',SSD='" + cmbSSD.Text + "',HDD='" + cmbHDD.Text + "',RAM='" + cmbRAM.Text + "',IPAddressLAN='" + txtIPAddressLAN.Text + "',IPAddressWifi='" + txtIPAddressWifi.Text + "',OfficeVersion='" + cmbOfficeVersion.Text + "',AntivirusSerialNumber='" + txtAntivirusSerialNo.Text + "',AntivirusExpiryDate='" + dtpEndDate.Value.ToShortDateString() + "',Status='" + cmbStatus.Text + "',QRCodeData='" + txtQRCodeData.Text + "',
                        }
                    }
                    else
                    {
                        //objBL.Query = "insert into AssetMaster(EntryDate,PurchaseDate,InvoiceNo,WarrantyPeriod,WarrantyEndDate,GRNNo,Status,QRCodeData,SiteId,DepartmentName,AssetUserName,ComputerName,AssetTypeId,MakeId,SerialNumber,OSName,OSType,OSTag,Processor,HDDType,SSD,HDD,RAM,IPAddressLAN,IPAddressWifi,OfficeVersion,AntivirusSerialNumber,AntivirusExpiryDate,Status,QRCodeData,UserId) values('"
                        objBL.Query = "insert into AssetMaster(EntryDate,PurchaseDate,InvoiceNo,WarrantyPeriod,WarrantyEndDate,GRNNo,Status,AssetTypeId,MakeId,ModelNo,SerialNumber,AssetCost,QRCodeData,PurchaseType,UserId) values('" + dtpDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "','" + dtpPurchaseDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "','" + txtInvoiceNo.Text + "','" + cmbWarrantyPeriod.Text + "','" + dtpWarrantyExpiredDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "','" + txtGRNNo.Text + "','" + cmbStatus.Text + "'," + cmbAssetType.SelectedValue + "," + cmbMake.SelectedValue + ",'" + cmbModelNo.Text + "','" + txtSerialNumber.Text + "','" + txtAssetCost.Text + "','" + txtQRCodeData.Text + "','" + cmbPurchaseType.Text + "'," + BusinessLayer.EmployeeLoginId_Static + ")";
                        ExecuteType = "Save";
                    }

                    Result = objBL.Function_ExecuteNonQuery();

                    if (Result > 0)
                    {
                        if (TableId == 0)
                            TableId = objRL.ReturnMaxID_Fix("AssetMaster","AssetMasterId");

                        objRL.ShowMessage(7, 1);

                        if (TableId != 0)
                        {
                            FillGrid();
                            AssetMasterId = TableId;
                            tpAssetLocation.Focus();
                            tcConfigurationRead.SelectedIndex = 1;
                        }

                        //if (ExecuteType == "Save")
                        //    objRL.ShowMessage(7, 1);
                        //else if (ExecuteType == "Update")
                        //    objRL.ShowMessage(8, 1);
                        //else
                        //    objRL.ShowMessage(9, 1);

                        //DialogResult dr;
                        //dr = objRL.Report_Record_Show_Message();

                        //if (dr == System.Windows.Forms.DialogResult.Yes)
                        //{
                        //    QRImagePath = objRL.GetPath("ImagePath");
                        //    var filePath = QRImagePath;
                        //    Directory.CreateDirectory(filePath);
                        //    string FileName = txtAssetCode.Text.ToString();
                        //    pbQRCode.Image.Save(Path.Combine(filePath, FileName), System.Drawing.Imaging.ImageFormat.Png);
                        //    GetReportSingle();
                        //}

                        //ClearAll();
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

        string QRCodeData = string.Empty;
        string DepartmentName = string.Empty;
        string UserName = string.Empty;
        string Make = string.Empty;
        string SerialNo = string.Empty;
        string Configuration = string.Empty;
        string AssetId_S = string.Empty;

        private void SetQRCode()
        {
            AssetId_S = string.Empty;
            QRCodeData = string.Empty;
            DepartmentName = string.Empty;
            Make = string.Empty;
            SerialNo = string.Empty;
            Configuration = string.Empty;

            if (txtAssetCode.Text != "")
                AssetId_S = "-" + txtAssetCode.Text;
            if (txtUserName.Text != "")
                UserName = "-" + txtUserName.Text;
            if (cmbDepartment.SelectedIndex > -1)
                DepartmentName = "-" + cmbDepartment.Text;
            if (cmbMake.SelectedIndex > -1)
                Make = "-" + cmbMake.Text;
            if (!string.IsNullOrEmpty(txtSerialNumber.Text))
                SerialNo = "-" + txtSerialNumber.Text;

            //QRCodeData = "T&T-AssetID-" + AssetId + AssetType + Make + SerialNo + Configuration;

            string QRDisplay = string.Empty;

            QRDisplay = "MALAS" + AssetId_S;

            QRCodeData = "MALAS" + DepartmentName + AssetId_S + UserName + SerialNo;
           // Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            //pbQRCode.Image = qrcode.Draw(QRCodeData, 50);
            //pbQRCode.Image = qrcode.Draw(QRDisplay, 50);
            txtQRCodeData.Text = QRCodeData.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
            //cbSelectAll.Checked = true;
            cmbSearch.SelectedIndex = -1;
            txtSearch.Text = "";
            cmbSearchBy.SelectedIndex = -1;

            cbSelectAll.Visible = true;
            cbSelectAll.Checked = true;
            gbSearch.Visible = false;
            FillGrid();
        }

        private void Get_AssetID()
        {
            txtAssetCode.Text = Convert.ToString(objRL.ReturnMaxID_Increase("AssetMaster", "AssetMasterId"));
        }

        private void AssetMasterNew_Load(object sender, EventArgs e)
        {
            ClearAll();
            cbSelectAll.Checked = true;
            FillGrid();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        string PSColumn = string.Empty, PSInnerJoinClause = string.Empty, PSInvoice = string.Empty, PSSC = string.Empty, PSSCHead = string.Empty;
        string MainQuery = string.Empty;
        string WhereClause = string.Empty;
        string OrderByClause = string.Empty;
        string UserClause = string.Empty;
        bool IDFlag = false, SearchByName = false, DateFlag = false;


        //private void FillGrid()
        //{
        //    if (BusinessLayer.UserType_Static == "HOD" || BusinessLayer.UserType_Static == "Admin" || BusinessLayer.Department_Static == "IT")
        //    {
        //        //Asset updates

        //        DataSet ds = new DataSet();

        //        dataGridView1.DataSource = null;
        //        PSColumn = string.Empty;
        //        PSInnerJoinClause = string.Empty;
        //        PSInvoice = string.Empty;
        //        PSSC = string.Empty;
        //        PSSCHead = string.Empty;
        //        MainQuery = string.Empty;
        //        WhereClause = string.Empty;
        //        OrderByClause = string.Empty;
        //        UserClause = string.Empty;

        //        try
        //        {
        //            if (IDFlag)
        //                WhereClause = " and AM.ID=" + txtSearchID.Text + "";
        //            if (SearchByName)
        //                WhereClause += " and AM.AssetUserName like '%" + txtSearchAsset.Text + "%'";
        //            if (!cbSelectAllAssetType.Checked)
        //            {
        //                if (cmbSearchAssetType.SelectedIndex > -1)
        //                    WhereClause += " and AM.AssetTypeId=" + cmbSearchAssetType.SelectedValue + "";
        //            }
        //            if (!cbSelectAllMake.Checked)
        //            {
        //                if (cmbSearchMake.SelectedIndex > -1)
        //                    WhereClause += " and AM.MakeId=" + cmbSearchMake.SelectedValue + "";
        //            }

        //            if (string.IsNullOrEmpty(WhereClause))
        //                WhereClause = string.Empty;

        //            MainQuery = "select AM.ID as [Asset Code],AM.EntryDate as [Date],AM.SiteId,BUM.BusinessUnit as [Site Name],AM.DepartmentName as [Department Name],AM.AssetUserName as [User Name],AM.ComputerName as [Computer Name],AM.AssetTypeId,ATM.AssetType as [Asset Type],AM.MakeId,MM.MakeName as [Make Name],AM.SerialNumber as [Serial Number],AM.OSName,AM.OSType,AM.OSTag,AM.Processor,AM.HDDType,AM.SSD,AM.HDD,AM.RAM,AM.IPAddressLAN,AM.IPAddressWifi,AM.OfficeVersion,AM.AntivirusSerialNumber,AM.AntivirusExpiryDate,AM.Status,AM.QRCodeData from (((AssetMaster AM inner join AssetTypeMaster ATM on ATM.ID=AM.AssetTypeId) inner join MakeMaster MM on MM.ID=AM.MakeId) inner join BusinessUnitMaster BUM on BUM.ID=AM.SiteId) where AM.CancelTag=0 and ATM.CancelTag=0 and MM.CancelTag=0 and BUM.CancelTag=0";
        //            OrderByClause = " order by AM.ID asc";

        //            objBL.Query = MainQuery + UserClause + WhereClause + OrderByClause;
        //            ds = objBL.ReturnDataSet();

        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                //0 AM.ID as [Asset Code],
        //                //1 AM.EntryDate as [Date],
        //                //2 AM.SiteId,
        //                //3 BUM.BusinessUnit as [Site Name],
        //                //4 AM.DepartmentName,
        //                //5 AM.AssetUserName,
        //                //6 AM.ComputerName,
        //                //7 AM.AssetTypeId,
        //                //8 ATM.AssetType as [Asset Type],
        //                //9 AM.MakeId,
        //                //10 MM.MakeName as [Make Name],
        //                //11 AM.SerialNumber as [Serial Number],
        //                //12 AM.OSName,
        //                //13 AM.OSType,
        //                //14 AM.OSTag,
        //                //15 AM.Processor,
        //                //16 AM.HDDType,
        //                //17 AM.SSD,
        //                //18 AM.HDD,
        //                //19 AM.RAM,
        //                //20 AM.IPAddressLAN,
        //                //21 AM.IPAddressWifi,
        //                //22 AM.OfficeVersion,
        //                //23 AM.AntivirusSerialNumber,
        //                //24 AM.AntivirusExpiryDate,
        //                //25 AM.Status,
        //                //26 AM.QRCodeData

        //                lblTotalCount.Text = "Total Count-" + ds.Tables[0].Rows.Count;
        //                dataGridView1.DataSource = ds.Tables[0];
        //                //dataGridView1.Columns[0].Visible = false;
        //                dataGridView1.Columns[1].Visible = false;
        //                dataGridView1.Columns[2].Visible = false;
        //                // dataGridView1.Columns[4].Visible = false;
        //                dataGridView1.Columns[7].Visible = false;
        //                dataGridView1.Columns[9].Visible = false;
        //                // dataGridView1.Columns[10].Visible = false;
        //                dataGridView1.Columns[14].Visible = false;
        //                dataGridView1.Columns[26].Visible = false;
        //                //dataGridView1.Columns[13].Visible = false;
        //                //dataGridView1.Columns[14].Visible = false;
        //                //dataGridView1.Columns[16].Visible = false;
        //                dataGridView1.Columns[23].Visible = false;
        //                dataGridView1.Columns[24].Visible = false;
        //                dataGridView1.Columns[0].Width = 120;
        //                dataGridView1.Columns[1].Width = 80;
        //                dataGridView1.Columns[2].Width = 80;
        //                dataGridView1.Columns[3].Width = 120;
        //                dataGridView1.Columns[5].Width = 120;
        //                dataGridView1.Columns[6].Width = 200;
        //                dataGridView1.Columns[7].Width = 150;
        //                dataGridView1.Columns[8].Width = 250;
        //                dataGridView1.Columns[9].Width = 120;
        //                dataGridView1.Columns[10].Width = 120;
        //                dataGridView1.Columns[11].Width = 120;
        //                dataGridView1.Columns[13].Width = 120;
        //                dataGridView1.Columns[15].Width = 200;

        //                //foreach (DataGridViewRow Myrow in dataGridView1.Rows)
        //                //{            //Here 2 cell is target value and 1 cell is Volume
        //                //    if (Convert.ToString(Myrow.Cells[16].Value) == "0") // < Convert.ToInt32(Myrow.Cells[1].Value))// Or your condition 
        //                //        Myrow.DefaultCellStyle.BackColor = Color.Lime;
        //                //    else if (Convert.ToString(Myrow.Cells[12].Value) == "1")
        //                //    {
        //                //        Myrow.DefaultCellStyle.BackColor = Color.Red;
        //                //    }
        //                //    //else if (Convert.ToString(Myrow.Cells[8].Value) == "In Process")
        //                //    //{
        //                //    //    Myrow.DefaultCellStyle.BackColor = Color.Aqua;
        //                //    //}
        //                //    //else if (Convert.ToString(Myrow.Cells[8].Value) == "Cancel")
        //                //    //{
        //                //    //    Myrow.DefaultCellStyle.BackColor = Color.Red;
        //                //    //}
        //                //    else
        //                //    {
        //                //        //string hex = BusinessResources.BACKGROUND_COLOUR;
        //                //        //Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
        //                //        //Myrow.DefaultCellStyle.BackColor = _color;
        //                //    }
        //                //}

        //                for (int i = 0; i < dataGridView1.Columns.Count; i++)
        //                {
        //                    dataGridView1.Columns[i].Width = 120;
        //                }
        //                dataGridView1.Columns[0].Width = 60;
        //                dataGridView1.Columns[13].Width = 60;
        //            }
        //        }
        //        catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
        //        finally { GC.Collect(); }
        //    }
        //}

        string SearchColumnName = string.Empty;
        bool IDTextFlag = false;

        double TotalCost = 0;
        string TableClause = string.Empty;
        string WhereBasic = string.Empty;

        private void FillGrid()
        {
            if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR || BusinessLayer.Designation == "IT HEAD" || BusinessLayer.Department == "INFORMATION TECHNOLOGY")
            {
                TotalCost = 0;
                DataSet ds = new DataSet();
                dataGridView1.DataSource = null;
                PSColumn = string.Empty;
                WhereBasic = string.Empty;
                TableClause = string.Empty;
                PSInnerJoinClause = string.Empty;
                PSInvoice = string.Empty;
                PSSC = string.Empty;
                PSSCHead = string.Empty;
                MainQuery = string.Empty;
                WhereClause = string.Empty;
                OrderByClause = string.Empty;
                UserClause = string.Empty;
                //TableName = string.Empty;
                lblTotalAssetCost.Text = "";
                lblTotalCount.Text = "";

                try
                {
                    if (cmbSearchBy.SelectedIndex > -1)
                    {
                        if (!cbSelectAll.Checked)
                            GetColumnName_Search();
                        else
                            WhereClause = string.Empty;
                    }
                     
                    if (string.IsNullOrEmpty(WhereClause))
                    {
                        TableName = "AssetMaster";
                        WhereClause = string.Empty;
                    }

                    MainQuery = "select AM.AssetMasterId as 'Asset Code',AM.EntryDate as 'Date',E.EmployeeName as 'Employee Name',E.EmployeeCode as 'Emp Code',DES.Designation,L.LocationName as 'Location',DM.Department,AL.ComputerName,AM.AssetTypeId,ATM.AssetType as 'Asset Type',AM.MakeId,MM.MakeName as 'Make Name',AM.ModelNo as 'Model No',AM.SerialNumber as 'Serial Number',AM.PurchaseDate as 'Purchase Date',AM.InvoiceNo as 'Invoice No',AM.WarrantyPeriod,AM.WarrantyEndDate,AM.GRNNo,AM.Status,AM.AssetCost,AM.QRCodeData,AM.PurchaseType from AssetMaster AM inner join AssetTypeMaster ATM on ATM.AssetTypeId=AM.AssetTypeId inner join MakeMaster MM on MM.MakeId=AM.MakeId inner join AssetLocation AL on AL.AssetMasterId=AM.AssetMasterId inner join Employees E on E.EmployeeId=AL.EmployeeId inner join locationmaster L on L.LocationId=AL.LocationId inner join DepartmentMaster DM on DM.DepartmentId=AL.DepartmentId inner join designationmaster DES on DES.DesignationId=E.DesignationId "; // ((((((AssetMaster AM inner join AssetTypeMaster ATM on ATM.ID=AM.AssetTypeId) inner join MakeMaster MM on MM.ID=AM.MakeId) inner join AssetLocation AL on AL.AssetId=AM.ID) inner join BusinessUnitMaster BU on BU.ID=AL.SiteId) inner join DepartmentMaster DM on DM.ID=AL.DepartmentId) inner join DesignationMaster DES on DES.ID=AL.DesignationId) where AM.CancelTag=0 and AL.CancelTag=0 and BU.CancelTag=0 and DM.CancelTag=0 and DES.CancelTag=0 and ATM.CancelTag=0 and MM.CancelTag=0 and AL.CurrentFlag=1";
                    WhereBasic = " where AM.CancelTag=0 and AL.CancelTag=0 and L.CancelTag=0 and DM.CancelTag=0 and DES.CancelTag=0 and ATM.CancelTag=0 and MM.CancelTag=0 and AL.CurrentFlag=1";

                    //if (TableName == "AssetMaster")
                    //    TableClause = " inner join AssetLocation AL on AL.AssetLocationId=AM.AssetLocationId inner join locationmaster L on L.LocationId=AL.LocationId inner join DepartmentMaster DM on DM.ID=AL.DepartmentId inner join DesignationMaster DES on DES.ID=AL.DesignationId ";
                    //else if (TableName == "AssetLocation")
                    //    TableClause = " inner join AssetLocation AL on AL.AssetLocationId=AM.AssetLocationId inner join BusinessUnitMaster BU on BU.ID=AL.SiteId inner join DepartmentMaster DM on DM.ID=AL.DepartmentId inner join DesignationMaster DES on DES.ID=AL.DesignationId ";
                    if (TableName == "AssetUpgrade")
                        TableClause = " inner join AssetUpgrade AU on AU.AssetMasterId=AM.AssetMasterId ";
                    else if (TableName == "AssetSoftwares")
                        TableClause = " inner join AssetSoftwares AS on AS.AssetMasterId=AM.AssetMasterId ";
                    else
                    {
                        //MainQuery = "";
                        //return;
                    }
                     
                    OrderByClause = " order by AM.AssetMasterId asc";
                     
                    objBL.Query = MainQuery + TableClause + UserClause + WhereBasic + WhereClause + OrderByClause;
                    ds = objBL.ReturnDataSet();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //0 AM.AssetMasterId as 'Asset Code',
                        //1 AM.EntryDate as 'Date',
                        //2 E.EmployeeName as 'Employee Name',
                        //3 E.EmployeeCode as 'Emp Code',
                        //4 DES.Designation,
                        //5 L.LocationName as 'Location',
                        //6 DM.Department,
                        //7 AL.ComputerName,
                        //8 AM.AssetTypeId,
                        //9 ATM.AssetType as 'Asset Type',
                        //10 AM.MakeId,
                        //11 MM.MakeName as 'Make Name',
                        //12 AM.ModelNo as 'Model No',
                        //13 AM.SerialNumber as 'Serial Number',
                        //14 AM.PurchaseDate as 'Purchase Date',
                        //15 AM.InvoiceNo as 'Invoice No',
                        //16 AM.WarrantyPeriod,
                        //17 AM.WarrantyEndDate,
                        //18 AM.GRNNo,
                        //19 AM.Status,
                        //20 AM.AssetCost,
                        //21 AM.QRCodeData,
                        //22 AM.PurchaseType

                        lblTotalCount.Text = "Total Count-" + ds.Tables[0].Rows.Count;
                        dataGridView1.DataSource = ds.Tables[0];

                        
                        dataGridView1.Columns[1].Visible = false;
                        //dataGridView1.Columns[6].Visible = false;
                        dataGridView1.Columns[8].Visible = false;
                        dataGridView1.Columns[10].Visible = false;
                        dataGridView1.Columns[14].Visible = false;
                        dataGridView1.Columns[15].Visible = false;
                        dataGridView1.Columns[16].Visible = false;
                        dataGridView1.Columns[18].Visible = false;

                        //dataGridView1.Columns[16].Visible = false;
                        
                        //dataGridView1.Columns[19].Visible = false;
                        dataGridView1.Columns[20].Visible = false;
                        ////dataGridView1.Columns[13].Visible = false;
                        ////dataGridView1.Columns[14].Visible = false;
                        ////dataGridView1.Columns[16].Visible = false;
                        //dataGridView1.Columns[23].Visible = false;
                        //dataGridView1.Columns[24].Visible = false;
                        //dataGridView1.Columns[0].Width = 120;
                        //dataGridView1.Columns[1].Width = 80;
                        //dataGridView1.Columns[2].Width = 80;
                        //dataGridView1.Columns[3].Width = 120;
                        //dataGridView1.Columns[5].Width = 120;
                        //dataGridView1.Columns[6].Width = 200;
                        //dataGridView1.Columns[7].Width = 150;
                        //dataGridView1.Columns[8].Width = 250;
                        //dataGridView1.Columns[9].Width = 120;
                        //dataGridView1.Columns[10].Width = 120;
                        //dataGridView1.Columns[11].Width = 120;
                        //dataGridView1.Columns[13].Width = 120;
                        //dataGridView1.Columns[15].Width = 200;

                        //foreach (DataGridViewRow Myrow in dataGridView1.Rows)
                        //{            //Here 2 cell is target value and 1 cell is Volume
                        //    if (Convert.ToString(Myrow.Cells[16].Value) == "0") // < Convert.ToInt32(Myrow.Cells[1].Value))// Or your condition 
                        //        Myrow.DefaultCellStyle.BackColor = Color.Lime;
                        //    else if (Convert.ToString(Myrow.Cells[12].Value) == "1")
                        //    {
                        //        Myrow.DefaultCellStyle.BackColor = Color.Red;
                        //    }
                        //    //else if (Convert.ToString(Myrow.Cells[8].Value) == "In Process")
                        //    //{
                        //    //    Myrow.DefaultCellStyle.BackColor = Color.Aqua;
                        //    //}
                        //    //else if (Convert.ToString(Myrow.Cells[8].Value) == "Cancel")
                        //    //{
                        //    //    Myrow.DefaultCellStyle.BackColor = Color.Red;
                        //    //}
                        //    else
                        //    {
                        //        //string hex = BusinessResources.BACKGROUND_COLOUR;
                        //        //Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
                        //        //Myrow.DefaultCellStyle.BackColor = _color;
                        //    }
                        //}

                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        {
                            dataGridView1.Columns[i].Width = 120;
                        }

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["AssetCost"])))
                                TotalCost += Convert.ToDouble(ds.Tables[0].Rows[i]["AssetCost"]);
                        }

                        TotalCost = TotalCost + TotalUpgradeCost;
                        lblTotalAssetCost.Text = "Total Asset Cost-:" + TotalCost.ToString();
                        //dataGridView1.Columns[0].Width = 60;
                        //dataGridView1.Columns[13].Width = 60;
                    }
                }
                catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
                finally { GC.Collect(); }
            }
        }

        int RowCount = 0;
        bool MH_Value = false;
        Excel.Application myExcelApp;
        Excel.Workbooks myExcelWorkbooks;
        Excel.Workbook myExcelWorkbook;
        string PDFReport = string.Empty;
        int AFlag = 0;

        bool BorderFlag = false;

        private void SetQRCode(Excel.Worksheet myExcelWorksheet, int RowNo, int ColumnNo)
        {
            QRImagePath = objRL.GetPath("ImagePath") + txtAssetCode.Text;
            Microsoft.Office.Interop.Excel.Range oRange = (Microsoft.Office.Interop.Excel.Range)myExcelWorksheet.Cells[RowNo, ColumnNo];
            float Left = (float)((double)oRange.Left);
            float Top = (float)((double)oRange.Top);
            const float ImageSize = 45;
            oRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oRange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            myExcelWorksheet.Shapes.AddPicture(QRImagePath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, ImageSize, ImageSize);
        }

        public void GetReportSingle()
        {
            using (new CursorWait())
            {
                BorderFlag = false;

                object misValue = System.Reflection.Missing.Value;
                myExcelApp = new Excel.Application();
                myExcelWorkbooks = myExcelApp.Workbooks;

                objRL.ClearExcelPath();
                objRL.isPDF = true;
                objRL.Form_ExcelFileName = "AssetQR.xlsx";
                objRL.Form_ReportFileName = "ID-" + txtAssetCode.Text + "-";
                objRL.Form_DestinationReportFilePath = "\\Asset Stickers\\";
                objRL.Path_Comman();

                myExcelWorkbook = myExcelWorkbooks.Open(objRL.RL_DestinationPath, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue);
                Excel.Worksheet myExcelWorksheet = (Excel.Worksheet)myExcelWorkbook.ActiveSheet;

                if (!string.IsNullOrEmpty(txtQRCodeData.Text))
                {
                    string concatData = string.Empty;

                    //myExcelWorksheet.get_Range("B1", misValue).Formula = "T & T Infra Ltd.";
                    //myExcelWorksheet.get_Range("B2", misValue).Formula = cmbDepartment.Text + "-" + txtAssetCode.Text;
                    //// myExcelWorksheet.get_Range("B3", misValue).Formula = txtSerialNumber.Text;
                    //myExcelWorksheet.get_Range("B3", misValue).Formula = txtUserName.Text;

                    // myExcelWorksheet.get_Range("B1", misValue).Formula = "T & T Infra Ltd.";
                    //myExcelWorksheet.get_Range("B2", misValue).Formula = cmbDepartment.Text + "-" + txtAssetCode.Text;
                    //// myExcelWorksheet.get_Range("B3", misValue).Formula = txtSerialNumber.Text;
                    myExcelWorksheet.get_Range("B1", misValue).Formula = txtQRCodeData.Text;


                    SetQRCode(myExcelWorksheet, 2, 1);
                }

                myExcelWorkbook.Save();

                try
                {
                    myExcelWorkbook.Close(true, misValue, misValue);
                    myExcelApp.Quit();
                    System.Diagnostics.Process.Start(objRL.RL_DestinationPath);
                }
                catch (Exception ex1)
                {
                    objRL.ShowMessage(27, 4);
                    return;
                }
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

        bool GridFlag = false;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //0 AM.AssetMasterId as 'Asset Code',
                //1 AM.EntryDate as 'Date',
                //2 E.EmployeeName as 'Employee Name',
                //3 E.EmployeeCode as 'Emp Code',
                //4 DES.Designation,
                //5 L.LocationName as 'Location',
                //6 DM.Department,
                //7 AL.ComputerName,
                //8 AM.AssetTypeId,
                //9 ATM.AssetType as 'Asset Type',
                //10 AM.MakeId,
                //11 MM.MakeName as 'Make Name',
                //12 AM.ModelNo as 'Model No',
                //13 AM.SerialNumber as 'Serial Number',
                //14 AM.PurchaseDate as 'Purchase Date',
                //15 AM.InvoiceNo as 'Invoice No',
                //16 AM.WarrantyPeriod,
                //17 AM.WarrantyEndDate,
                //18 AM.GRNNo,
                //19 AM.Status,
                //20 AM.AssetCost,
                //21 AM.QRCodeData,
                //22 AM.PurchaseType

                ClearAll();
                btnDelete.Visible = true;
                GridFlag = true;
                TableId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtAssetCode.Text = TableId.ToString();
                AssetMasterId = TableId;
                dtpDate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                cmbLocation.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[5].Value));
                cmbDepartment.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[6].Value));
                Fill_Employee_ComboBox();
                cmbEmployeeName.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value));
                Fill_EmployeeDetails();
                txtComputerName.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[7].Value));
                cmbAssetType.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[9].Value));
                cmbMake.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[11].Value));
                cmbModelNo.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[12].Value));
                txtSerialNumber.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[13].Value));

                if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[14].Value)))
                    dtpPurchaseDate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString());

                txtInvoiceNo.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[15].Value));
                cmbWarrantyPeriod.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[16].Value));

                if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[17].Value)))
                    dtpWarrantyExpiredDate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[17].Value.ToString());

                txtGRNNo.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[18].Value));
                cmbStatus.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[19].Value));
                txtQRCodeData.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[20].Value));
                txtAssetCost.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[21].Value));
                cmbPurchaseType.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[22].Value));
               

                SetQRCode();
                Check_AssetType();
                cbIsTransfer.Visible = true;
                cbIsUpgrade.Visible = true;
                Fill_Location();
                Fill_Hardware_Software();
                Fill_Files();
            }
            catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
            finally { GC.Collect(); }
        }

        private void Fill_Location()
        {
            dgvLocation.DataSource = null;
            DataSet ds = new DataSet();
            //objBL.Query = "select AL.ID,AL.EntryDate,AL.IsTransfer,AL.TransferDate as [Transfer Date],AL.AssetId,AL.SiteId,BUM.BusinessUnit as [Site Name],AL.DepartmentId,D.Department,AL.DesignationId,Des.Designation,AL.AssetUserName as [User Name],AL.ComputerName as [Computer Name],NarationLocation from (((AssetLocation AL inner join BusinessUnitMaster BUM on BUM.ID=AL.SiteId) inner join DepartmentMaster D on D.ID=AL.DepartmentId) inner join DesignationMaster Des on Des.ID=AL.DesignationId) where AL.AssetId=" + AssetId + " and AL.CancelTag=0 and D.CancelTag=0 and Des.CancelTag=0 order by AL.ID desc";

            objBL.Query = "select AL.AssetLocationId,AL.EntryDate,AL.IsTransfer,AL.TransferDate as 'Transfer Date',AL.AssetMasterId,E.EmployeeName as 'Employee Name',E.EmployeeCode as 'Emp Code',DES.Designation,L.LocationName as 'Location',D.Department,AL.AssetUserName as 'Asset Name',AL.ComputerName as 'Computer Name',AL.NarationLocation from AssetLocation AL inner join Employees E on E.EmployeeId=AL.EmployeeId inner join locationmaster L on L.LocationId=AL.LocationId inner join DepartmentMaster D on D.DepartmentId=AL.DepartmentId inner join designationmaster DES on DES.DesignationId=E.DesignationId where AL.AssetMasterId=" + AssetMasterId + " and E.CancelTag=0 and DES.CancelTag=0 and L.CancelTag=0 and AL.CancelTag=0 and D.CancelTag=0 order by AL.EntryDate desc";

            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                //0 AL.AssetLocationId,
                //1 AL.EntryDate,
                //2 AL.IsTransfer,
                //3 AL.TransferDate as 'Transfer Date',
                //4 AL.AssetMasterId,
                //5 E.EmployeeName as 'Employee Name',
                //6 E.EmployeeCode as 'Emp Code',
                //7 DES.Designation,
                //8 L.LocationName as 'Location',
                //9 D.Department,
                //10 AL.AssetUserName as 'Asset Name',
                //11 AL.ComputerName as 'Computer Name',
                //12 AL.NarationLocation

                IsTransferGrid = 0;
                dgvLocation.DataSource = ds.Tables[0];
                lblTotalTransferCount.Text = "Total Transfer Count-" + ds.Tables[0].Rows.Count.ToString();
                dgvLocation.Columns[0].Visible = false;
                dgvLocation.Columns[1].Visible = false;
                dgvLocation.Columns[2].Visible = false;
                dgvLocation.Columns[4].Visible = false;
                dgvLocation.Columns[3].Width = 100;
                dgvLocation.Columns[5].Width = 200;
                dgvLocation.Columns[6].Width = 100;
                dgvLocation.Columns[7].Width = 100;
                dgvLocation.Columns[8].Width = 100;
                dgvLocation.Columns[9].Width = 100;
                dgvLocation.Columns[10].Width = 150;
                dgvLocation.Columns[11].Width = 150;
                dgvLocation.Columns[12].Width = 150;

                //AL.ID,AL.EntryDate,AL.IsTransfer,AL.TransferDate as [Transfer Date],AL.AssetId,AL.SiteId,BUM.BusinessUnit as [Site Name],AL.DepartmentId,D.Department,AL.DesignationId,Des.Designation,AL.AssetUserName as [User Name],AL.ComputerName as [Computer Name]
                string CurrentLocation = string.Empty, BusinessUnit = string.Empty, Department = string.Empty, Designation = string.Empty, AssetUserName = string.Empty, ComputerName = string.Empty;

                AssetLocationId = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["AssetLocationId"].ToString())));
                IsTransfer = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["IsTransfer"].ToString())));

                if (IsTransfer == 1)
                {
                    IsTransferGrid = 1;
                    lblTransferDate.Visible = false;
                    dtpTransferDate.Visible = false;

                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Transfer Date"].ToString())))
                        dtpTransferDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["Transfer Date"].ToString());
                }

                BusinessUnit = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Location"].ToString()));
                Department = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Department"].ToString()));
                Designation = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Designation"].ToString()));
                AssetUserName = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Asset Name"].ToString()));
                ComputerName = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Computer Name"].ToString()));
                txtNarationLocation.Text = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["NarationLocation"].ToString()));

                CurrentLocation = "Location:\t" + BusinessUnit + "\n" +
                                  "Department:\t" + Department + "\n" +
                                  "Designation:\t" + Designation + "\n" +
                                  "AssetUserName:\t" + AssetUserName + "\n" +
                                  "ComputerName:\t" + ComputerName;

                txtCurrentLocation.Text = CurrentLocation.ToString();
            }
        }

        private void Fill_Hardware_Software()
        {
            lblTotalUpgradeCost.Text = "";
            lblTotalUpgradeCount.Text = "";
            TotalUpgradeCost = 0;

            dgvHardwareSoftware.DataSource = null;
            DataSet ds = new DataSet();
            //objBL.Query = "select from AL.ID,AL.EntryDate,AL.IsTransfer,AL.TransferDate as [Transfer Date],AL.AssetId,AL.SiteId,BUM.BusinessUnit,AL.DepartmentId,D.Department,AL.DesignationId,Des.Designation,AL.AssetUserName,AL.ComputerName from (((AssetLocation AL inner join BusinessUnitMaster BUM on BUM.ID=AL.SiteId) inner join DepartmentMaster D on D.ID=AL.DepartmentId) inner join DesignationMaster Des on Des.ID=AL.DesignationId) where AL.AssetId=" + AssetId + " and AL.CancelTag=0 and D.CancelTag=0 and Des.CancelTag=0";
            objBL.Query = "select AssetUpgradeId,EntryDate as 'Date',AssetMasterId,IsUpgrade,UpgradeDate as 'Upgrade Date',UpgradeFor as 'Upgrade for',WarrantyUpgrade as 'Warranty',WarrantyExpiredDateUpgrade as 'Warranty Expired Date',InvoiceNoUpgrade as 'Invoice No',GRNNoUpgrade as 'GRN No',UpgradeCost as 'Upgrade Cost',NarationUpgrade as Narration,Processor,RAM,Screen,IsSSD,SSDType,SSDSize,IsHDD,HDDType,HDDSize,OSName,OSBit,OSTag,AntivirusSerialNumber,AntivirusExpiryDate,UpgradeStatus from AssetUpgrade where AssetMasterId=" + AssetMasterId + " and CancelTag=0 order by EntryDate desc";

            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                //0 AssetUpgradeId,
                //1 EntryDate,
                //2 AssetMasterId,
                //3 IsUpgrade,
                //4 UpgradeDate as [Upgrade Date],
                //5 UpgradeFor,
                //6 WarrantyUpgrade,
                //7 WarrantyExpiredDateUpgrade,
                //8 InvoiceNoUpgrade,
                //9 GRNNoUpgrade,
                //10 UpgradeCost,
                //11 NarationUpgrade,
                //12 Processor,
                //13 RAM,
                //14 Screen,
                //15 IsSSD,
                //16 SSDType,
                //17 SSDSize,
                //18 IsHDD,
                //19 HDDType,
                //20 HDDSize,
                //21 OSName,
                //22 OSBit,
                //23 OSTag,
                //24 AntivirusSerialNumber,
                //25 AntivirusExpiryDate,
                //26 UpgradeStatus

                gbSSD.Visible = false; gbHDD.Visible = false; gbUpgrade.Visible = false;

                dgvHardwareSoftware.DataSource = ds.Tables[0];
                lblTotalUpgradeCount.Text = "Total Upgrade Count-" + ds.Tables[0].Rows.Count.ToString();
                dgvHardwareSoftware.Columns[0].Visible = false;
                dgvHardwareSoftware.Columns[2].Visible = false;
                dgvHardwareSoftware.Columns[3].Visible = false;
                dgvHardwareSoftware.Columns[15].Visible = false;
                dgvHardwareSoftware.Columns[18].Visible = false;
                //dgvLocation.Columns[5].Visible = false;
                //dgvLocation.Columns[7].Visible = false;
                //dgvLocation.Columns[9].Visible = false;

                AssetUpgradeId = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["AssetUpgradeId"].ToString())));

                //ID,EntryDate as [Date],AssetId,,UpgradeDate as [Upgrade Date],UpgradeFor as [Upgrade for],
                //WarrantyUpgrade as [Warranty],WarrantyExpiredDateUpgrade as [Warranty Expired Date],InvoiceNoUpgrade as [Invoice No],
                //GRNNoUpgrade as [GRN No],UpgradeCost as [Upgrade Cost],NarationUpgrade as [Narration],
                //,,,,,,,,,,,,,,UpgradeStatus from AssetUpgrade where AssetId=" + AssetId + " and CancelTag=0 order by ID desc";

                IsUpgrade = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["IsUpgrade"].ToString())));

                if (IsUpgrade == 1)
                {
                    IsUpgradGrid = 1;
                    gbUpgrade.Visible = true;

                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Upgrade Date"].ToString())))
                        dtpUpgradeDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["Upgrade Date"].ToString());

                    cmbUpgrade.Text = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Upgrade for"].ToString()));
                    cmbWarrantyUpgrade.Text = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Warranty"].ToString()));

                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Warranty Expired Date"].ToString())))
                        dtpUpgradeDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["Warranty Expired Date"].ToString());

                    txtInvoiceNoUpgrade.Text = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Invoice No"].ToString()));
                    txtGRNNoUpgrade.Text = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["GRN No"].ToString()));
                    txtUpgradeCost.Text = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Upgrade Cost"].ToString()));
                    txtNarationUpgrade.Text = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Narration"].ToString()));
                }
                else
                    IsUpgradGrid = 0;

                cmbProcessor.Text = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Processor"].ToString()));
                cmbRAM.Text = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["RAM"].ToString()));
                cmbScreen.Text = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Screen"].ToString()));
                IsSSD = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["IsSSD"].ToString())));

                if (IsSSD == 1)
                {
                    gbSSD.Visible = true;
                    cbSSD.Checked = true;
                    cmbSSDType.Text = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["SSDType"].ToString()));
                    cmbSSDSize.Text = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["SSDSize"].ToString()));
                }

                IsHDD = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["IsHDD"].ToString())));
                if (IsHDD == 1)
                {
                    gbHDD.Visible = true;
                    cbHDD.Checked = true;
                    cmbHDDType.Text = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["HDDType"].ToString()));
                    cmbHDDSize.Text = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["HDDSize"].ToString()));
                }

                cmbOSName.Text = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["OSName"].ToString()));
                cmbOSBit.Text = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["OSBit"].ToString()));
                cmbOSTag.Text = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["OSTag"].ToString()));
                txtAntivirusSerialNo.Text = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["AntivirusSerialNumber"].ToString()));

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["AntivirusExpiryDate"].ToString())))
                {
                    dtpAntivirusExpiryDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["AntivirusExpiryDate"].ToString());
                }

                cmbUpgradeStatus.Text = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["UpgradeStatus"].ToString()));

                if (AssetTypeCheck == "Laptop" || AssetTypeCheck == "All In One" || AssetTypeCheck == "Desktop" || AssetTypeCheck == "Server")
                    Fill_Software();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["Upgrade Cost"])))
                        TotalUpgradeCost += Convert.ToDouble(ds.Tables[0].Rows[i]["Upgrade Cost"]);
                }

                lblTotalUpgradeCost.Text = "Total Upgrade Cost-" + TotalUpgradeCost.ToString();

                TotalCost = TotalCost + TotalUpgradeCost;
                lblTotalAssetCost.Text = "Total Asset Cost-:" + TotalCost.ToString();
            }
        }

        double TotalUpgradeCost = 0;

        private void Fill_Software()
        {
            DataSet ds = new DataSet();
            objBL.Query = "select AssetSoftwaresId,EntryDate,AssetMasterId,Software,UserId from AssetSoftwares where AssetMasterId=" + AssetMasterId + " and CancelTag=0";
            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    int index = 0;
                    string SoftwareDS = string.Empty;
                    SoftwareDS = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["Software"]));

                    foreach (object itemChecked in clbInstalledSoftware.Items)
                    {
                        DataRowView castedItem = itemChecked as DataRowView;
                        string Software = castedItem["Softwares"].ToString();
                        //int? id =Convert.ToInt32(castedItem["ID"]);

                        if (Software == SoftwareDS)
                        {
                            clbInstalledSoftware.SetItemChecked(index, true);
                            break;
                        }

                        index++;
                    }

                    //for(int j=0;j<clbInstalledSoftware.Items.Count;i++)
                    //{
                    //    string ISoftwares = string.Empty;
                    //    ISoftwares = clbInstalledSoftware.Items[j].ToString();

                    //    if (ISoftwares.Contains(SoftwareDS)) //.Contains(clbInstalledSoftware.Items[j].ToString()))
                    //        clbInstalledSoftware.SetItemChecked(j, true);
                    //}
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (TableId != 0)
            {
                QRImagePath = objRL.GetPath("ImagePath");
                var filePath = QRImagePath;
                Directory.CreateDirectory(filePath);
                string FileName = txtAssetCode.Text.ToString();
                pbQRCode.Image.Save(Path.Combine(filePath, FileName), System.Drawing.Imaging.ImageFormat.Png);
            }
            GetReportSingle();
        }

        private void cmbLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbLocation.SelectedIndex > -1)
            {
                Clear_Employee();
                objPC.LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
                objRL.Fill_Department_ComboBox_By_Location(cmbDepartment, objPC.LocationId);
                SetQRCode();
            }
        }

        private void Clear_Employee()
        {
            cmbDepartment.DataSource = null;
            cmbEmployeeName.DataSource = null;
            txtUserName.Text = "";
            txtDesignation.Text = "";
        }

        private void cmbDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //SetQRCode();
            Fill_Employee_ComboBox();
        }

        private void Fill_Employee_ComboBox()
        {
            if (cmbDepartment.SelectedIndex > -1 && cmbLocation.SelectedIndex > -1)
            {
                cmbEmployeeName.DataSource = null;
                txtUserName.Text = "";
                txtDesignation.Text = "";
                objPC.LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
                objPC.DepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue);
                objQL.SP_Employees_ComboBox_By_DepartmentId_LocationId_Without_Login(cmbEmployeeName);
            }
        }

        private void cmbAssetType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetQRCode();
            Check_AssetType();
        }

        private void cmbMake_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetQRCode();
        }

        private void cmbOSName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetQRCode();
        }

        private void cmbOSType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetQRCode();
        }

        private void cmbOSTag_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetQRCode();
        }

        private void cmbProcessor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetQRCode();
        }

        string AssetTypeCheck = string.Empty;

        private void Check_AssetType()
        {
            //AssetType

            //Laptop
            //All In One
            //Desktop
            //Printer
            //Monitor
            //Mouse
            //Keyboard
            //Bullet Camera
            //Dome Camera
            //PTZ Camera
            //NVR
            //DVR
            //Switch
            //Cable
            //POE Switch
            //Connector
            //Router
            //Projector
            //NA
            //Server

            if (cmbAssetType.SelectedIndex > -1 && txtAssetCode.Text != "")
            {
                AssetTypeCheck = cmbAssetType.Text;
                gbHardware.Visible = false;
                gbSoftware.Visible = false;
                gbScreen.Visible = false;
                if (AssetTypeCheck == "Laptop" || AssetTypeCheck == "All In One" || AssetTypeCheck == "Desktop" || AssetTypeCheck == "Server")
                {
                    gbHardware.Visible = true;
                    gbSoftware.Visible = true;
                    gbScreen.Visible = true;
                }
                else if (AssetTypeCheck == "Monitor")
                {
                    gbScreen.Visible = true;
                }
                else
                {
                    gbHardware.Visible = false;
                    gbSoftware.Visible = false;
                    gbScreen.Visible = false;
                }
            }
        }

        private void cmbBusinessUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbDepartment.Focus();
        }

        private void cmbDepartment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtUserName.Focus();
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtComputerName.Focus();
        }

        private void txtComputerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbAssetType.Focus();
        }

        private void cmbAssetType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbMake.Focus();
        }

        private void cmbMake_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtSerialNumber.Focus();
        }

        private void txtSerialNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbOSName.Focus();
        }

        private void cmbOSName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbOSBit.Focus();
        }

        private void cmbOSType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbOSTag.Focus();
        }

        private void cmbOSTag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbProcessor.Focus();
        }

        private void cmbProcessor_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //    cmbHDDType1.Focus();
        }

        private void cmbHDDType_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //    cmbSSD.Focus();
        }

        private void cmbSSD_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //    cmbHDD.Focus();
        }

        private void cmbHDD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbRAM.Focus();
        }

        private void cmbRAM_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //    txtIPAddressLAN.Focus();
        }

        private void txtIPAddressLAN_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //    txtIPAddressWifi.Focus();
        }
        private void txtIPAddressWifi_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //    cmbOfficeVersion.Focus();
        }
        private void cmbOfficeVersion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtAntivirusSerialNo.Focus();
        }
        private void txtAntivirusSerialNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dtpAntivirusExpiryDate.Focus();
        }
        private void dtpEndDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbStatus.Focus();
        }
        private void cmbStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSave.Focus();
        }
        
        private void btnAddProcessor_Click(object sender, EventArgs e)
        {
            AddMasterData(BusinessResources.TN_Processor);
            objRL.CommanAssetMaster(cmbProcessor, "Processor");
        }

        private void btnUpgradation_Click(object sender, EventArgs e)
        {

        }
         
        private void btnAddInstalledSoftwares_Click(object sender, EventArgs e)
        {
            AddMasterData(BusinessResources.TN_Software);
            objRL.Fill_CheckListBox_Softwares(clbInstalledSoftware);
        }

        private void btnAddModelNo_Click(object sender, EventArgs e)
        {
            AddMasterData(BusinessResources.TN_Model);
            objRL.CommanAssetMaster(cmbModelNo, "Model");
        }

        private void cbSSD_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSSD.Checked)
            {
                gbSSD.Visible = true;
            }
            else
            {
                gbSSD.Visible = false;
                cmbSSDType.SelectedIndex = -1;
                cmbSSDSize.SelectedIndex = -1;
            }
        }

        private void cbHDD_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHDD.Checked)
            {
                gbHDD.Visible = true;
            }
            else
            {
                gbHDD.Visible = false;
                cmbHDDType.SelectedIndex = -1;
                cmbHDDSize.SelectedIndex = -1;
            }
        }

        private bool Validation_Location()
        {
            objEP.Clear();
            if (AssetMasterId == 0)
            {
                objEP.SetError(txtAssetCode, "Enter Asset Code");
                txtAssetCode.Focus();
                return true;
            }
            else if (cmbLocation.SelectedIndex == -1)
            {
                objEP.SetError(cmbLocation, "Enter Business Unit");
                cmbLocation.Focus();
                return true;
            }
            else if (cmbDepartment.SelectedIndex == -1)
            {
                objEP.SetError(cmbDepartment, "Enter Department");
                cmbDepartment.Focus();
                return true;
            }
            else if (cmbEmployeeName.SelectedIndex == -1)
            {
                objEP.SetError(cmbEmployeeName, "Enter Employee Name");
                cmbEmployeeName.Focus();
                return true;
            }
            else if (txtUserName.Text == "")
            {
                objEP.SetError(txtUserName, "Enter User Name");
                txtUserName.Focus();
                return true;
            }
            else if (txtComputerName.Text == "")
            {
                objEP.SetError(txtComputerName, "Enter Computer Name");
                txtComputerName.Focus();
                return true;
            }
            else if (txtNarationLocation.Text == "")
            {
                objEP.SetError(txtNarationLocation, "Enter Naration Location");
                txtNarationLocation.Focus();
                return true;
            }
            else
                return false;
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            bool SaveFlag = false;
            try
            {
                if (!Validation_Location())
                {
                    if (GridFlag)
                    {
                        if (cbIsTransfer.Checked)
                        {
                            IsTransfer = 1;
                            SaveFlag = true;
                        }
                        else
                        {
                            SaveFlag = false;
                            IsTransfer = 0;
                        }
                    }
                    else
                        SaveFlag = true;

                    if (AssetLocationId == 0)
                        SaveFlag = true;
                    else
                        SaveFlag = false;

                    if (SaveFlag)
                    {
                        objBL.Query = "update AssetLocation set CurrentFlag=0 where CancelTag=0 and AssetMasterId=" + AssetMasterId + ""; //  (EntryDate,AssetId,IsUpgrade,UpgradeDate,UpgradeFor,WarrantyUpgrade,WarrantyExpiredDateUpgrade,InvoiceNoUpgrade,GRNNoUpgrade,UpgradeCost,NarationUpgrade,Processor,RAM,Screen,IsSSD,SSDType,SSDSize,IsHDD,HDDType,HDDSize,OSName,OSBit,OSTag,AntivirusSerialNumber,AntivirusExpiryDate,UpgradeStatus,CurrntFlag,UserId) values('" + dtpDate.Value.ToShortDateString() + "'," + AssetId + "," + IsUpgrade + ",'" + dtpUpgradeDate.Value.ToShortDateString() + "','" + cmbUpgrade.Text + "','" + cmbWarrantyUpgrade.Text + "','" + dtpWarrantyExpiredDateUpgrade.Value.ToShortDateString() + "','" + txtInvoiceNoUpgrade.Text + "','" + txtGRNNoUpgrade.Text + "','" + txtUpgradeCost.Text + "','" + txtNarationUpgrade.Text + "','" + cmbProcessor.Text + "','" + cmbRAM.Text + "','" + cmbScreen.Text + "'," + IsSSD + ",'" + cmbSSDType.Text + "','" + cmbSSDSize.Text + "'," + IsHDD + ",'" + cmbHDDType.Text + "','" + cmbHDDSize.Text + "','" + cmbOSName.Text + "','" + cmbOSBit.Text + "','" + cmbOSTag.Text + "','" + txtAntivirusSerialNo.Text + "','" + dtpAntivirusExpiryDate.Value.ToShortDateString() + "','" + UpgradeStatus + "',1," + BusinessLayer.EmployeeLoginId_Static + ")";
                        Result = objBL.Function_ExecuteNonQuery();

                        objBL.Query = "insert into AssetLocation(EntryDate,IsTransfer,TransferDate,AssetMasterId,LocationId,DepartmentId,EmployeeId,AssetUserName,ComputerName,NarationLocation,CurrentFlag,UserId) values('" + dtpDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'," + IsTransfer + ",'" + dtpTransferDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'," + AssetMasterId + "," + cmbLocation.SelectedValue + "," + cmbDepartment.SelectedValue + "," + cmbEmployeeName.SelectedValue + ",'" + txtUserName.Text + "','" + txtComputerName.Text + "','" + txtNarationLocation.Text + "',1," + BusinessLayer.EmployeeLoginId_Static + ")";
                        Result = objBL.Function_ExecuteNonQuery();

                        if (Result > 0)
                        {
                            AssetLocationId = objRL.ReturnMaxID_Fix("AssetLocation", "AssetLocationId");
                        }
                    }
                    else
                    {
                        objBL.Query = "update AssetLocation set IsTransfer=" + IsTransferGrid + ",TransferDate='" + dtpTransferDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "',LocationId=" + cmbLocation.SelectedValue + ",DepartmentId=" + cmbDepartment.SelectedValue + ",EmployeeId=" + cmbEmployeeName.SelectedValue + ",AssetUserName='" + txtUserName.Text + "',ComputerName='" + txtComputerName.Text + "',NarationLocation='" + txtNarationLocation.Text + "',ModifiedUserId=" + BusinessLayer.EmployeeLoginId_Static + " where AssetLocationId=" + AssetLocationId + " and CancelTag=0";
                        Result = objBL.Function_ExecuteNonQuery();
                    }


                    //if (IsTransfer == 1 && cbIsTransfer.Checked)
                    //{
                    //    //Update
                    //    if (GridFlag)
                    //    {
                    //        objBL.Query = "update AssetLocation set IsTransfer=" + IsTransfer + ",TransferDate='" + dtpTransferDate.Value.ToShortDateString() + "',SiteId=" + cmbBusinessUnit.SelectedValue + ",DepartmentId=" + cmbDepartment.SelectedValue + ",DesignationId=" + cmbDesignation.SelectedValue + ",AssetUserName='" + txtUserName.Text + "',ComputerName='" + txtComputerName.Text + "',ModifiedId=" + BusinessLayer.EmployeeLoginId_Static + " where ID=" + AssetId + " and CancelTag=0";
                    //        Result = objBL.Function_ExecuteNonQuery();
                    //    }
                    //}
                    //else
                    //{
                    //    if (!GridFlag)
                    //    {
                    //        //Insert

                    //        //AssetLocationId = 0;
                    //        if (AssetId != 0)
                    //        {
                    //            //AssetId = TableId;
                    //            if (AssetLocationId == 0)
                    //            {
                    //                objBL.Query = "insert into AssetLocation(EntryDate,IsTransfer,AssetId,SiteId,DepartmentId,DesignationId,AssetUserName,ComputerName,UserId) values('" + dtpDate.Value.ToShortDateString() + "'," + IsTransfer + "," + AssetId + "," + cmbBusinessUnit.SelectedValue + "," + cmbDepartment.SelectedValue + "," + cmbDesignation.SelectedValue + ",'" + txtUserName.Text + "','" + txtComputerName.Text + "'," + BusinessLayer.EmployeeLoginId_Static + ")";
                    //                Result = objBL.Function_ExecuteNonQuery();
                    //                AssetLocationId = objRL.ReturnMaxID_Fix("AssetLocation");
                    //            }
                    //            else
                    //            {
                    //                objBL.Query = "update AssetLocation set SiteId=" + cmbBusinessUnit.SelectedValue + ",DepartmentId=" + cmbDepartment.SelectedValue + ",DesignationId=" + cmbDesignation.SelectedValue + ",AssetUserName='" + txtUserName.Text + "',ComputerName='" + txtComputerName.Text + "',ModifiedId=" + BusinessLayer.EmployeeLoginId_Static + " where ID=" + AssetLocationId + " and CancelTag=0";
                    //                Result = objBL.Function_ExecuteNonQuery();
                    //            }
                    //        }
                    //    }
                    //}

                    if (Result > 0)
                    {
                        //objBL.Query = "update AssetMaster set BusinessUnit='" + cmbLocation.Text + "',Department='" + cmbDepartment.Text + "',Designation='" + txtDesignation.Text + "',UserName='" + txtUserName.Text + "',ComputerName='" + txtComputerName.Text + "',ModifiedId=" + BusinessLayer.EmployeeLoginId_Static + " where ID=" + AssetId + " and CancelTag=0";
                        //Result = objBL.Function_ExecuteNonQuery();
                        FillGrid();
                        Fill_Location();
                        objRL.ShowMessage(7, 1);
                        tcConfigurationRead.SelectedIndex = 2;
                    }
                }
                else
                {
                    objRL.ShowMessage(17, 4);
                    return;
                }
            }
            catch (Exception ex1) { MessageBox.Show(ex1.ToString()); }
            finally { GC.Collect(); }
        }

        private bool Validation_Hardware_Software()
        {
            bool ReturnFlag = false;
            objEP.Clear();
            if (AssetMasterId == 0)
            {
                objEP.SetError(txtAssetCode, "Enter Asset Code");
                tcConfigurationRead.SelectedIndex = 0;
                txtAssetCode.Focus();
                ReturnFlag = true;
            }
            else
                ReturnFlag = false;

            if (!ReturnFlag)
            {
                if (AssetTypeCheck == "Laptop" || AssetTypeCheck == "All In One" || AssetTypeCheck == "Desktop" || AssetTypeCheck == "Server")
                {
                    if (cmbOSName.SelectedIndex == -1)
                    {
                        objEP.SetError(cmbOSName, "Select OS Name");
                        cmbOSName.Focus();
                        ReturnFlag = true;
                    }
                    else if (cmbOSBit.SelectedIndex == -1)
                    {
                        objEP.SetError(cmbOSBit, "Select OS Type");
                        cmbOSBit.Focus();
                        ReturnFlag = true;
                    }
                    else if (cmbOSTag.SelectedIndex == -1)
                    {
                        objEP.SetError(cmbOSTag, "Select OS Tag");
                        cmbOSTag.Focus();
                        ReturnFlag = true;
                    }
                    else if (cmbProcessor.SelectedIndex == -1)
                    {
                        objEP.SetError(cmbProcessor, "Select Processor");
                        cmbProcessor.Focus();
                        ReturnFlag = true;
                    }
                    else if (cmbRAM.SelectedIndex == -1)
                    {
                        objEP.SetError(cmbRAM, "Select RAM");
                        cmbRAM.Focus();
                        ReturnFlag = true;
                    }

                    if (!ReturnFlag)
                    {
                        if (cbSSD.Checked)
                        {
                            if (cmbSSDType.SelectedIndex == -1)
                            {
                                objEP.SetError(cmbSSDType, "Select SSD Type");
                                cmbSSDType.Focus();
                                ReturnFlag = true;
                            }
                            else if (cmbSSDSize.SelectedIndex == -1)
                            {
                                objEP.SetError(cmbSSDSize, "Select SSD Size");
                                cmbSSDSize.Focus();
                                ReturnFlag = true;
                            }
                            else
                                ReturnFlag = false;
                        }
                        else
                            ReturnFlag = false;
                    }

                    if (!ReturnFlag)
                    {
                        if (cbHDD.Checked)
                        {
                            if (cmbHDDType.SelectedIndex == -1)
                            {
                                objEP.SetError(cmbHDDType, "Select HDD Type");
                                cmbHDDType.Focus();
                                ReturnFlag = true;
                            }
                            else if (cmbHDDSize.SelectedIndex == -1)
                            {
                                objEP.SetError(cmbHDDSize, "Select HDD Size");
                                cmbHDDSize.Focus();
                                ReturnFlag = true;
                            }
                            else
                                ReturnFlag = false;
                        }
                        else
                            ReturnFlag = false;
                    }

                    if (!ReturnFlag)
                    {
                        if (clbInstalledSoftware.CheckedItems.Count == 0)
                        {
                            objEP.SetError(clbInstalledSoftware, "Select Software from List");
                            clbInstalledSoftware.Focus();
                            ReturnFlag = true;
                        }
                        else
                            ReturnFlag = false;
                    }
                    else
                        ReturnFlag = false;
                }
                else if (AssetTypeCheck == "Monitor")
                {
                    if (cmbScreen.SelectedIndex == -1)
                    {
                        objEP.SetError(cmbScreen, "Select Screen");
                        cmbScreen.Focus();
                        ReturnFlag = true;
                    }
                    else
                        ReturnFlag = false;
                }
                else
                    ReturnFlag = false;
            }
            else
                ReturnFlag = true;

            return ReturnFlag;
        }

        int IsUpgradGrid = 0, IsTransferGrid = 0; string UpgradeStatus = string.Empty;

        private void btnUpgrade_Click(object sender, EventArgs e)
        {
            UpgradeStatus = string.Empty;
            try
            {
                if (!Validation_Hardware_Software())
                {
                    bool SaveFlag = false;

                    if (GridFlag)
                    {
                        if (cbIsUpgrade.Checked)
                        {
                            IsUpgrade = 1;
                            SaveFlag = true;
                            UpgradeStatus = "Upgrade";
                        }
                        else
                        {
                            SaveFlag = false;
                            IsUpgrade = 0;
                            UpgradeStatus = "New";
                        }
                    }
                    else
                    {
                        SaveFlag = true;
                        UpgradeStatus = "New";
                    }

                    if (AssetUpgradeId == 0)
                        SaveFlag = true;
                    else
                        SaveFlag = false;


                    if (SaveFlag)
                    {
                        if (cbSSD.Checked)
                            IsSSD = 1;
                        else
                            IsSSD = 0;

                        if (cbHDD.Checked)
                            IsHDD = 1;
                        else
                            IsHDD = 0;

                        objBL.Query = "update AssetUpgrade set CurrentFlag=0 where CancelTag=0 and AssetMasterId=" + AssetMasterId + ""; //  (EntryDate,AssetId,IsUpgrade,UpgradeDate,UpgradeFor,WarrantyUpgrade,WarrantyExpiredDateUpgrade,InvoiceNoUpgrade,GRNNoUpgrade,UpgradeCost,NarationUpgrade,Processor,RAM,Screen,IsSSD,SSDType,SSDSize,IsHDD,HDDType,HDDSize,OSName,OSBit,OSTag,AntivirusSerialNumber,AntivirusExpiryDate,UpgradeStatus,CurrntFlag,UserId) values('" + dtpDate.Value.ToShortDateString() + "'," + AssetId + "," + IsUpgrade + ",'" + dtpUpgradeDate.Value.ToShortDateString() + "','" + cmbUpgrade.Text + "','" + cmbWarrantyUpgrade.Text + "','" + dtpWarrantyExpiredDateUpgrade.Value.ToShortDateString() + "','" + txtInvoiceNoUpgrade.Text + "','" + txtGRNNoUpgrade.Text + "','" + txtUpgradeCost.Text + "','" + txtNarationUpgrade.Text + "','" + cmbProcessor.Text + "','" + cmbRAM.Text + "','" + cmbScreen.Text + "'," + IsSSD + ",'" + cmbSSDType.Text + "','" + cmbSSDSize.Text + "'," + IsHDD + ",'" + cmbHDDType.Text + "','" + cmbHDDSize.Text + "','" + cmbOSName.Text + "','" + cmbOSBit.Text + "','" + cmbOSTag.Text + "','" + txtAntivirusSerialNo.Text + "','" + dtpAntivirusExpiryDate.Value.ToShortDateString() + "','" + UpgradeStatus + "',1," + BusinessLayer.EmployeeLoginId_Static + ")";
                        Result = objBL.Function_ExecuteNonQuery();

                        objBL.Query = "insert into AssetUpgrade(EntryDate,AssetMasterId,IsUpgrade,UpgradeDate,UpgradeFor,WarrantyUpgrade,WarrantyExpiredDateUpgrade,InvoiceNoUpgrade,GRNNoUpgrade,UpgradeCost,NarationUpgrade,Processor,RAM,Screen,IsSSD,SSDType,SSDSize,IsHDD,HDDType,HDDSize,OSName,OSBit,OSTag,AntivirusSerialNumber,AntivirusExpiryDate,UpgradeStatus,CurrentFlag,UserId) values('" + dtpDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'," + AssetMasterId + "," + IsUpgrade + ",'" + dtpUpgradeDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "','" + cmbUpgrade.Text + "','" + cmbWarrantyUpgrade.Text + "','" + dtpWarrantyExpiredDateUpgrade.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "','" + txtInvoiceNoUpgrade.Text + "','" + txtGRNNoUpgrade.Text + "','" + txtUpgradeCost.Text + "','" + txtNarationUpgrade.Text + "','" + cmbProcessor.Text + "','" + cmbRAM.Text + "','" + cmbScreen.Text + "'," + IsSSD + ",'" + cmbSSDType.Text + "','" + cmbSSDSize.Text + "'," + IsHDD + ",'" + cmbHDDType.Text + "','" + cmbHDDSize.Text + "','" + cmbOSName.Text + "','" + cmbOSBit.Text + "','" + cmbOSTag.Text + "','" + txtAntivirusSerialNo.Text + "','" + dtpAntivirusExpiryDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "','" + UpgradeStatus + "',1," + BusinessLayer.EmployeeLoginId_Static + ")";
                        Result = objBL.Function_ExecuteNonQuery();
                        if (Result > 0)
                        {
                            AssetUpgradeId = objRL.ReturnMaxID_Fix("AssetUpgrade", "AssetUpgradeId");
                            tcConfigurationRead.SelectedIndex = 3;
                        }
                    }
                    else
                    {
                        objBL.Query = "update AssetUpgrade set IsUpgrade=" + IsUpgradGrid + ",UpgradeDate='" + dtpUpgradeDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "',UpgradeFor='" + cmbUpgrade.Text + "',WarrantyUpgrade='" + cmbWarrantyUpgrade.Text + "',WarrantyExpiredDateUpgrade='" + dtpWarrantyExpiredDateUpgrade.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "',InvoiceNoUpgrade='" + txtInvoiceNoUpgrade.Text + "',GRNNoUpgrade='" + txtGRNNoUpgrade.Text + "',UpgradeCost='" + txtUpgradeCost.Text + "',NarationUpgrade='" + txtNarationUpgrade.Text + "',Processor='" + cmbProcessor.Text + "',RAM='" + cmbRAM.Text + "',Screen='" + cmbScreen.Text + "',IsSSD=" + IsSSD + ",SSDType='" + cmbSSDType.Text + "',SSDSize='" + cmbSSDSize.Text + "',IsHDD=" + IsHDD + ",HDDType='" + cmbHDDType.Text + "',HDDSize='" + cmbHDDSize.Text + "',OSName='" + cmbOSName.Text + "',OSBit='" + cmbOSBit.Text + "',OSTag='" + cmbOSTag.Text + "',AntivirusSerialNumber='" + txtAntivirusSerialNo.Text + "',AntivirusExpiryDate='" + dtpAntivirusExpiryDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "',UpgradeStatus='" + UpgradeStatus + "',ModifiedUserId=" + BusinessLayer.EmployeeLoginId_Static + " where CancelTag=0 and AssetUpgradeId=" + AssetUpgradeId + "";
                        Result = objBL.Function_ExecuteNonQuery();
                    }

                    if (Result > 0)
                    {
                        Save_Software();
                        objRL.ShowMessage(7, 1);
                        Fill_Hardware_Software();
                    }
                }
                else
                {
                    objRL.ShowMessage(17, 4);
                    return;
                }
            }
            catch (Exception ex1) { MessageBox.Show(ex1.ToString()); }
            finally { GC.Collect(); }
        }

        private void Save_Software()
        {
            if (AssetTypeCheck == "Laptop" || AssetTypeCheck == "All In One" || AssetTypeCheck == "Desktop" || AssetTypeCheck == "Server")
            {
                if (GridFlag)
                {
                    if (AssetMasterId != 0)
                    {
                        objBL.Query = "Delete from AssetSoftwares where AssetMasterId=" + AssetMasterId + " and CancelTag=0";
                        Result = objBL.Function_ExecuteNonQuery();
                    }
                }

                if (clbInstalledSoftware.SelectedItems.Count > 0)
                {
                    foreach (object itemChecked in clbInstalledSoftware.CheckedItems)
                    {
                        DataRowView castedItem = itemChecked as DataRowView;
                        string Software = castedItem["Softwares"].ToString();
                        //int? id = castedItem["ID"];

                        objBL.Query = "insert into AssetSoftwares(EntryDate,AssetMasterId,Software,UserId) values('" + dtpDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'," + AssetMasterId + ",'" + Software + "'," + BusinessLayer.EmployeeLoginId_Static + ")";
                        Result = objBL.Function_ExecuteNonQuery();
                    }
                }
            }
        }



        
        int IsTransfer = 0, IsUpgrade = 0;

        private void cbIsTransfer_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIsTransfer.Checked)
            {
                IsTransfer = 1;
                lblTransferDate.Visible = true;
                dtpTransferDate.Visible = true;

                cmbLocation.SelectedIndex = -1;
                cmbDepartment.SelectedIndex = -1;
                txtDesignation.Text = "";
                txtUserName.Text = "";
                txtComputerName.Text = "";
                txtNarationLocation.Text = "";
                AssetLocationId = 0;
            }
            else
            {
                IsTransfer = 0;
                lblTransferDate.Visible = false;
                dtpTransferDate.Visible = false;
                cmbLocation.SelectedIndex = -1;
                cmbDepartment.SelectedIndex = -1;
                txtDesignation.Text = "";
                txtUserName.Text = "";
                txtComputerName.Text = "";
                txtNarationLocation.Text = "";
                AssetLocationId = 0;
            }
        }

        private void cbIsUpgrade_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIsUpgrade.Checked)
            {
                IsUpgrade = 1;
                gbUpgrade.Visible = true;
                AssetUpgradeId = 0;
                dtpUpgradeDate.Value = DateTime.Now.Date;
                cmbUpgrade.SelectedIndex = -1;
                cmbWarrantyUpgrade.SelectedIndex = -1;
                dtpWarrantyExpiredDateUpgrade.Value = DateTime.Now.Date;
                txtInvoiceNoUpgrade.Text = "";
                txtGRNNoUpgrade.Text = "";
                txtUpgradeCost.Text = "";
                txtNarationUpgrade.Text = "";
            }
            else
            {
                IsUpgrade = 0;
                gbUpgrade.Visible = false;
            }
        }

        private void txtAssetCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtAssetCost);
        }

        int WarrantyMonth = 0;
        private void SetWarrantyPeriod(ComboBox cmb, DateTimePicker dtp)
        {
            WarrantyMonth = 0;
            if (cmb.SelectedIndex > -1)
            {
                WarrantyMonth = Convert.ToInt32(cmb.Text);
                dtp.Value = dtpPurchaseDate.Value.AddMonths(WarrantyMonth);
            }
        }

        private void cmbWarrantyPeriod_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetWarrantyPeriod(cmbWarrantyPeriod, dtpWarrantyExpiredDate);
        }

        private void cmbWarrantyUpgrade_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetWarrantyPeriod(cmbWarrantyUpgrade, dtpWarrantyExpiredDateUpgrade);
        }

        private void btnAddDocuments_Click(object sender, EventArgs e)
        {
            //DocumentMaster objForm = new DocumentMaster();
            //objForm.ShowDialog(this);
            //objRL.Fill_Documents(cmbDocumentType);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (!ValidationBrowseFile())
            {
                Get_File();
                //System.Environment.NewLine
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }

        private bool ValidationBrowseFile()
        {
            objEP.Clear();
            if (AssetMasterId == 0)
            {
                txtAssetCode.Focus();
                objEP.SetError(txtAssetCode, "Select Asset Code");
                return true;
            }
            else if (cmbDocumentType.SelectedIndex == -1)
            {
                cmbDocumentType.Focus();
                objEP.SetError(cmbDocumentType, "Select Document Name");
                return true;
            }
            else
                return false;
        }

        string FileName = string.Empty, SourcePath = string.Empty, DestinationPath = string.Empty;

        private void Get_File()
        {
            FileName = string.Empty; SourcePath = string.Empty; DestinationPath = string.Empty;
            System.Windows.Forms.OpenFileDialog opnfd = new System.Windows.Forms.OpenFileDialog();
            //opnfd.Filter = "Files (*.pdf;*.jpg;*.jpeg;.*.png;)|*.pdf;*.jpg;*.jpeg;.*.png";
            opnfd.Filter = "Files (*.pdf;)|*.pdf";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                SourcePath = opnfd.FileName;
                FileName = Path.GetFileName(SourcePath);
                txtFileName.Text = FileName.ToString();
                txtFilePath.Text = SourcePath.ToString();
                //pictureBox1.Image = new Bitmap(opnfd.FileName);
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (AssetMasterId != 0)
            {
                DialogResult dr;
                dr = objRL.Report_Record_Show_Message();

                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    QRImagePath = objRL.GetPath("ImagePath");
                    var filePath = QRImagePath;
                    Directory.CreateDirectory(filePath);
                    string FileName = txtAssetCode.Text.ToString();
                    pbQRCode.Image.Save(Path.Combine(filePath, FileName), System.Drawing.Imaging.ImageFormat.Png);
                    GetReportSingle();
                }
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }

        private bool Validation_Files()
        {
            objEP.Clear();
            if (AssetMasterId == 0)
            {
                txtAssetCode.Focus();
                objEP.SetError(txtAssetCode, "Enter Asset Code");
                return true;
            }
            else if (cmbDocumentType.Text == "")
            {
                cmbDocumentType.Focus();
                objEP.SetError(cmbDocumentType, "Enter Document Type");
                return true;
            }
            else if (cmbDocumentType.SelectedIndex == -1)
            {
                cmbDocumentType.Focus();
                objEP.SetError(cmbDocumentType, "Select Document Name");
                return true;
            }
            else if (txtFileName.Text == "")
            {
                txtFileName.Focus();
                objEP.SetError(txtFileName, "Enter File Name");
                return true;
            }
            else if (txtFilePath.Text == "")
            {
                txtFilePath.Focus();
                objEP.SetError(txtFilePath, "Enter File Path");
                return true;
            }
            else
                return false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!Validation_Files())
            {
                AddFiles();
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }

        string DocumentType = string.Empty, DocumentPathSave = string.Empty, DocumentPath = string.Empty, FilePathMain = string.Empty;
        DateTime DocumentDate;

        private void AddFiles()
        {
            //FileFlag = false;
            //Result = 0;
            //FilePathMain = SourcePath;
            //CopyPasteFile();

            //if (!FileFlag)
            //{
            //    DocumentDate = dtpDate.Value;
            //    DocumentType = cmbDocumentType.Text;
            //    //DocumentPath = DestinationPath;
            //    FileName = txtFileName.Text;

            //    objBL.Connect();
            //    string sql = "INSERT INTO AssetDocuments(EntryDate,AssetMasterId,DocumentDate,DocumentType,FileName,UserId) VALUES (@EntryDate,@AssetMasterId,@DocumentDate,@DocumentType,@FileName,@UserId)";
            //    using (var command = new MySqlCommand(sql, objBL.objCon))
            //    {
            //        command.Parameters.Add("@EntryDate", MySqlDbType.Date).Value = dtpDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD);
            //        command.Parameters.Add("@AssetMasterId", MySqlDbType.Int32).Value = AssetMasterId;
            //        command.Parameters.Add("@DocumentDate", MySqlDbType.Date).Value = dtpDocumentDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD);
            //        command.Parameters.Add("@DocumentType", MySqlDbType.VarChar).Value = DocumentType;
            //        //command.Parameters.Add("@DocumentPath", MySqlDbType.Text).Value = DocumentPath;
            //        //command.Parameters.Add("@DocumentPathSave", MySqlDbType.Text).Value = DocumentPathSave;
            //        command.Parameters.Add("@FileName", MySqlDbType.Text).Value = FileName;
            //        command.Parameters.Add("@UserId", MySqlDbType.Int32).Value = BusinessLayer.EmployeeLoginId_Static;
            //        Result = command.ExecuteNonQuery();
            //        objBL.objCon.Clone();
            //    }

            //    //objBL.Query = "insert into AssetDocuments(EntryDate,AssetMasterId,DocumentDate,DocumentType,DocumentPath,DocumentPathSave,FileName,UserId) values('" + dtpDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'," + AssetId + ",'" + dtpDocumentDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "','" + DocumentType + "','" + DocumentPath + "','" + DocumentPathSave + "','" + FileName + "'," + BusinessLayer.EmployeeLoginId_Static + ")";
            //    //Result = objBL.Function_ExecuteNonQuery();

            //    if (Result > 0)
            //    {
            //        objRL.ShowMessage(7, 1);
            //        Fill_Files();
            //        ClearAll_Files();
            //    }
            //}
            //else
            //{
            //    objRL.ShowMessage(43, 4);
            //    return;
            //}
        }

        private void ClearAll_Files()
        {
            dgvItemRow = 0;
            cmbDocumentType.SelectedIndex = -1;
            dtpDocumentDate.Value = DateTime.Now.Date;
            txtFileName.Text = "";
            txtFilePath.Text = "";
        }

        bool FileFlag = false;
        private void CopyPasteFile()
        {
            if (AssetMasterId > 0)
            {
                FileFlag = false;
                //DocumentPathSave = "AssetDocuments\\" + AssetMasterId + "\\";
                //DestinationPath = objRL.GetPath("DocumentsPath") + DocumentPathSave;

                DestinationPath = objRL.GetPath_DocumentsMain(AssetMasterId);

                DirectoryInfo objDI = new DirectoryInfo(Path.GetFullPath(DestinationPath));

                if (!Directory.Exists(Path.GetFullPath(DestinationPath)))
                {
                    objDI.Create();
                }
                else
                {
                    string[] files = Directory.GetFiles(DestinationPath);
                    foreach (string file in files)
                    {
                        //if( File.Exists(file))
                        //{
                        //    objRL.ShowMessage(35,4);
                        //    return;
                        //}
                        if (file == DestinationPath + FileName)
                            FileFlag = true;
                        //File.Delete(file);
                    }
                }

                if (!FileFlag)
                    File.Copy(FilePathMain, DestinationPath + Path.GetFileName(FilePathMain));
            }
        }

        private void Fill_Files()
        {
            dgvItemRow = 0;
            dgvFiles.Rows.Clear();
            DataSet ds = new DataSet();
            objBL.Query = "select AssetDocumentsId,EntryDate,AssetMasterId,DocumentDate,DocumentType,FileName from AssetDocuments where CancelTag=0 and AssetMasterId=" + AssetMasterId + "";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dgvFiles.Rows.Add();
                    dgvFiles.Rows[dgvItemRow].Cells["clmId"].Value = ds.Tables[0].Rows[i]["AssetDocumentsId"].ToString();
                    DateTime dt = Convert.ToDateTime(ds.Tables[0].Rows[i]["DocumentDate"].ToString());
                    dgvFiles.Rows[dgvItemRow].Cells["clmDocumentDate"].Value = dt.ToString(BusinessResources.DATEFORMATDDMMYYYY);
                    dgvFiles.Rows[dgvItemRow].Cells["clmDocumentType"].Value = ds.Tables[0].Rows[i]["DocumentType"].ToString();
                    //dgvFiles.Rows[dgvItemRow].Cells["clmDocumentPath"].Value = ds.Tables[0].Rows[i]["DocumentPath"].ToString();
                    //dgvFiles.Rows[dgvItemRow].Cells["clmDocumentPathSave"].Value = ds.Tables[0].Rows[i]["DocumentPathSave"].ToString();
                    dgvFiles.Rows[dgvItemRow].Cells["clmFileName"].Value = ds.Tables[0].Rows[i]["FileName"].ToString();
                    dgvFiles.Rows[dgvItemRow].Cells["clmView"].Value = "View";
                    dgvFiles.Rows[dgvItemRow].Cells["clmDelete"].Value = "Delete";
                    dgvItemRow++;
                    SrNo_Add();
                }
            }
        }

        static int dgvItemRow;
        int FlagValue = 0;
        int AssetDocumentsId = 0;
        string FilePathInsert = string.Empty;

        private void SrNo_Add()
        {
            if (dgvFiles.Rows.Count > 0)
            {
                int SrNo = 1;
                for (int i = 0; i < dgvFiles.Rows.Count; i++)
                {
                    dgvFiles.Rows[i].Cells["clmSrNo"].Value = SrNo.ToString();
                    SrNo++;
                }
            }
            lblTotalDocuments.Text = "Total Item Count: " + dgvFiles.Rows.Count.ToString();
        }



        private void dgvFiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvFiles.CurrentCell.ColumnIndex == 6)
                {
                    DialogResult dr;
                    dr = objRL.Delete_Record_Show_Message();
                    if (dr == DialogResult.Yes)
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(dgvFiles.Rows[e.RowIndex].Cells["clmId"].Value)))
                        {
                            AssetDocumentsId = Convert.ToInt32(dgvFiles.Rows[e.RowIndex].Cells["clmId"].Value);
                            if (AssetDocumentsId > 0)
                            {
                                objBL.Query = "delete from AssetDocuments where AssetDocumentsId=" + AssetDocumentsId + " and CancelTag=0";
                                Result = objBL.Function_ExecuteNonQuery();

                                if (Result > 0)
                                {
                                   // DestinationPath = objRL.GetPath("DocumentsPath") + dgvFiles.Rows[e.RowIndex].Cells["clmDocumentPath"].Value.ToString();

                                    //DestinationPath = objRL.GetServerPath() + BusinessResources.ASSETDOCUMENTS + dgvFiles.Rows[e.RowIndex].Cells["clmFileName"].Value.ToString();
                                    FileName = dgvFiles.Rows[e.RowIndex].Cells["clmFileName"].Value.ToString();
                                    DestinationPath = objRL.GetPath_DocumentsMain(AssetMasterId) + FileName; // dgvFiles.Rows[e.RowIndex].Cells["clmFileName"].Value.ToString();
                                    
                                    FilePathInsert = DestinationPath + FileName;

                                    string[] files = Directory.GetFiles(objRL.GetPath_DocumentsMain(AssetMasterId));
                                    foreach (string file in files)
                                    {
                                        if (file == DestinationPath)
                                            File.Delete(file);
                                    }
                                }
                            }

                            Fill_Files();
                            objRL.ShowMessage(9, 1);
                            ClearAll_Files();
                        }
                    }
                }

                if (dgvFiles.CurrentCell.ColumnIndex == 5)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(dgvFiles.Rows[e.RowIndex].Cells["clmFileName"].Value)))
                    {
                        //DestinationPath = objRL.GetPath("DocumentsPath") + Convert.ToString(dgvFiles.Rows[e.RowIndex].Cells["clmDocumentPathSave"].Value.ToString());
                        FileName = objRL.CheckNullString(Convert.ToString(dgvFiles.Rows[e.RowIndex].Cells["clmFileName"].Value));
                        DestinationPath = objRL.GetPath_DocumentsMain(AssetMasterId) + FileName;
                        System.Diagnostics.Process.Start(DestinationPath);
                    }
                }
            }
            catch (Exception ex1) { }
            finally { GC.Collect(); }
        }

        private void btnAddAssetType_Click(object sender, EventArgs e)
        {
            AddMasterData(BusinessResources.TN_AssetType);
            objRL.Fill_AssetTypeMaster(cmbAssetType);
        }

        private void AddMasterData(string MasterType)
        {
            CommanMasterAsset objForm = new CommanMasterAsset(MasterType);
            objForm.ShowDialog(this);
        }

        private void btnAddMakeCompany_Click(object sender, EventArgs e)
        {
            AddMasterData(BusinessResources.TN_Make);
            objRL.Fill_MakeMaster(cmbMake);
        }

        private void btnAddUpgrade_Click(object sender, EventArgs e)
        {
            AddMasterData(BusinessResources.TN_Upgrade);
            objRL.CommanAssetMaster(cmbUpgrade, "Upgrade");
        }

        private void btnAddRAM_Click(object sender, EventArgs e)
        {
            AddMasterData(BusinessResources.TN_RAM);
            objRL.CommanAssetMaster(cmbRAM, "RAM");
        }

        private void btnAddScreen_Click(object sender, EventArgs e)
        {
            AddMasterData(BusinessResources.TN_Screen);
            objRL.CommanAssetMaster(cmbScreen, "Screen");
        }

        private void btnAddSSDType_Click(object sender, EventArgs e)
        {
            AddMasterData(BusinessResources.TN_HDDSSDType);
            objRL.CommanAssetMaster(cmbSSDType, "HDDSSDType");
        }

        private void btnAddSSDSize_Click(object sender, EventArgs e)
        {
            AddMasterData(BusinessResources.TN_HDDSSDSize);
            objRL.CommanAssetMaster(cmbSSDSize, "HDDSSDSize");
        }

        private void btnAddHDDType_Click(object sender, EventArgs e)
        {
            AddMasterData(BusinessResources.TN_HDDSSDType);
            objRL.CommanAssetMaster(cmbHDDType, "HDDSSDType");
        }

        private void btnAddHDDSize_Click(object sender, EventArgs e)
        {
            AddMasterData(BusinessResources.TN_HDDSSDSize);
            objRL.CommanAssetMaster(cmbHDDSize, "HDDSSDSize");
        }

        private void btnAddOSName_Click(object sender, EventArgs e)
        {
            AddMasterData(BusinessResources.TN_OSName);
            objRL.Fill_OSMaster(cmbOSName);
        }

        private void cmbSearchBy_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbSearchBy.SelectedIndex > -1)
            {
                gbSearch.Visible = true;
                Get_Search();
            }
            else
                gbSearch.Visible = false;
        }

        string SearchBy = string.Empty;
        bool SearchFlag = false;
        string SearchBy_T = "Search by ";

        private void Search_Column()
        {
            gbSearch.Visible = true;
            SearchBy_T = "Search by ";
            lblSearchName.Text = SearchBy_T + SearchBy;
            txtSearch.Visible = false;
            cmbSearch.Visible = false;
            SearchFlag = false;
            cmbSearch.DataSource = null;
            //cmbSearch.SelectedIndex = -1;
            //txtSearch.Text = "";
            //cbSelectAll.Visible = true;
            IDTextFlag = false;
            TableName = string.Empty;

            switch (SearchBy)
            {
                //Text Box Searching

                //SearchBy
                //Asset Code
                //Business Unit
                //Department
                //User Name
                //Computer Name
                //Asset Type
                //Make (Company)
                //Serial Number
                //OS Name
                //OS Type (Bit)
                //OS License
                //Processor
                //SSD Type
                //SSD Size
                //HDD Type
                //HDD Size
                //RAM
                //Software

                case "Asset Code":
                    txtSearch.Visible = true;
                    SearchFlag = true;
                    SearchColumnName = "ID";
                    IDTextFlag = false;
                    TableName = "AssetMaster";
                    break;
                case "User Name":
                    txtSearch.Visible = true;
                    SearchFlag = true;
                    SearchColumnName = "AssetUserName";
                    IDTextFlag = false;
                    TableName = "AssetLocation";
                    break;
                case "Computer Name":
                    txtSearch.Visible = true;
                    SearchFlag = true;
                    SearchColumnName = "ComputerName";
                    IDTextFlag = false;
                    TableName = "AssetLocation";
                    break;
                case "Serial Number":
                    txtSearch.Visible = true;
                    SearchFlag = true;
                    SearchColumnName = "SerialNumber";
                    IDTextFlag = false;
                    TableName = "AssetMaster";
                    break;
                case "Location":
                    cmbSearch.Visible = true;
                    objQL.Fill_Master_ComboBox(cmbSearch, "locationmaster");
                    SearchColumnName = "LocationId";
                    IDTextFlag = true;
                    TableName = "AssetLocation";
                    break;
                case "Department":
                    cmbSearch.Visible = true;
                    objQL.Fill_Master_ComboBox(cmbSearch, "departmentmaster");
                    SearchColumnName = "DepartmentId";
                    IDTextFlag = true;
                    TableName = "AssetLocation";
                    break;
                case "Asset Type":
                    cmbSearch.Visible = true;
                    objRL.Fill_AssetTypeMaster(cmbSearch);
                    SearchColumnName = "AssetTypeId";
                    IDTextFlag = true;
                    TableName = "AssetMaster";
                    break;
                case "Make (Company)":
                    cmbSearch.Visible = true;
                    objRL.Fill_MakeMaster(cmbSearch);
                    SearchColumnName = "MakeId";
                    IDTextFlag = true;
                    TableName = "AssetMaster";
                    break;
                case "OS Name":
                    cmbSearch.Visible = true;
                    objRL.Fill_OSMaster(cmbSearch);
                    SearchColumnName = "OSName";
                    IDTextFlag = false;
                    TableName = "AssetUpgrade";
                    break;
                case "OS Type (Bit)":
                    cmbSearch.Visible = true;
                    objRL.CommanAssetMaster(cmbSearch, "OSType");
                    SearchColumnName = "OSBit";
                    IDTextFlag = false;
                    TableName = "AssetUpgrade";
                    break;
                case "OS License":
                    cmbSearch.Visible = true;
                    objRL.CommanAssetMaster(cmbSearch, "OSTag");
                    SearchColumnName = "OSTag";
                    TableName = "AssetUpgrade";
                    break;
                case "Processor":
                    cmbSearch.Visible = true;
                    objRL.CommanAssetMaster(cmbSearch, "Processor");
                    SearchColumnName = "OSTag";
                    TableName = "AssetUpgrade";
                    IDTextFlag = false;
                    break;
                case "SSD Type":
                    cmbSearch.Visible = true;
                    objRL.CommanAssetMaster(cmbSearch, "HDDSSDType");
                    SearchColumnName = "SSDType";
                    TableName = "AssetUpgrade";
                    IDTextFlag = false;
                    break;
                case "SSD Size":
                    cmbSearch.Visible = true;
                    objRL.CommanAssetMaster(cmbSearch, "HDDSSDSize");
                    SearchColumnName = "SSDSize";
                    IDTextFlag = false;
                    TableName = "AssetUpgrade";
                    break;
                case "HDD Type":
                    cmbSearch.Visible = true;
                    objRL.CommanAssetMaster(cmbSearch, "HDDSSDType");
                    SearchColumnName = "HDDType";
                    IDTextFlag = false;
                    TableName = "AssetUpgrade";
                    break;
                case "HDD Size":
                    cmbSearch.Visible = true;
                    objRL.CommanAssetMaster(cmbSearch, "HDDSSDSize");
                    SearchColumnName = "HDDSize";
                    IDTextFlag = false;
                    TableName = "AssetUpgrade";
                    break;
                case "RAM":
                    cmbSearch.Visible = true;
                    objRL.CommanAssetMaster(cmbSearch, "RAM");
                    SearchColumnName = "RAM";
                    IDTextFlag = false;
                    TableName = "AssetUpgrade";
                    break;
                case "Softwares":
                    cmbSearch.Visible = true;
                    objRL.CommanAssetMaster(cmbSearch, "Softwares");
                    SearchColumnName = "Software";
                    IDTextFlag = false;
                    TableName = "AssetSoftwares";
                    break;
                case "Purchase Type":
                    cmbSearch.Visible = true;
                    objRL.CommanAssetMaster(cmbSearch, "PurchaseType");
                    SearchColumnName = "PurchaseType";
                    IDTextFlag = false;
                    TableName = "AssetMaster";
                    break;
            }
        }

        string TableName = string.Empty;

        private void Get_Search()
        {
            SearchBy = string.Empty;
            if (cmbSearchBy.SelectedIndex > -1)
            {
                SearchBy = cmbSearchBy.Text;
                Search_Column();
            }

            //Asset Code
            //User Name
            //Computer Name
            //Serial Number

            //Business Unit
            //Department
            //Asset Type
            //Make (Company)
            //OS Name
            //OS Type (Bit)
            //OS License
            //Processor
            //HDD Type
            //HDD
            //SSD
            //RAM
            //Office Version
            //Auto CAD

            //objRL.Fill_BusinessUnitMaster(cmbBusinessUnit);
            //objRL.Fill_AssetTypeMaster(cmbAssetType);
            //objRL.Fill_MakeMaster(cmbMake);
            //objRL.Fill_AssetTypeMaster(cmbSearchAssetType);
            //objRL.Fill_MakeMaster(cmbSearchMake);
            //objRL.Fill_DepartmentMaster(cmbDepartment);
            //objRL.Fill_OSMaster(cmbOSName);
            //objRL.Fill_HDDSSDMaster(cmbProcessor, "Processor");
            //objRL.Fill_HDDSSDMaster(cmbHDD, "HDD");
            //objRL.Fill_HDDSSDMaster(cmbSSD, "SSD");
            //objRL.Fill_HDDSSDMaster(cmbRAM, "RAM");
            //objRL.Fill_HDDSSDMaster(cmbOfficeVersion, "OfficeVersion");
        }

        private void cbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSelectAll.Checked)
            {
                gbSearch.Visible = false;
                cmbSearch.SelectedIndex = -1;
                txtSearch.Text = "";
                gbSearch.Visible = false;
                cmbSearchBy.SelectedIndex = -1;
                cmbSearchBy.Enabled = false;

                FillGrid();
            }
            else
            {
                gbSearch.Visible = true;
                cmbSearchBy.SelectedIndex = -1; 
                cmbSearchBy.Enabled = true;
            }
        }

        string SearchText = string.Empty;
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {


        }

        string TblObj = string.Empty;

        private void GetColumnName_Search()
        {
            string ColumnIdName = string.Empty;
            if (cmbSearchBy.SelectedIndex > -1)
            {
                //Search_Column();

                if (TableName == "AssetMaster")
                {
                    TblObj = " AM.";
                    ColumnIdName = "AssetMasterId";
                }
                else if (TableName == "AssetLocation")
                {
                    TblObj = " AL.";
                    ColumnIdName = "AssetLocationId";
                }
                else if (TableName == "AssetUpgrade")
                {
                    TblObj = " AU.";
                    ColumnIdName = "AssetUpgradeId";
                }
                else if (TableName == "AssetSoftwares")
                {
                    TblObj = " AS.";
                    ColumnIdName = "AssetSoftwaresId";
                }
                else
                {
                    TblObj = "";
                    return;
                }
                
                if (SearchColumnName == "ID" || SearchColumnName == "AssetUserName" || SearchColumnName == "ComputerName" || SearchColumnName == "SerialNumber")
                {
                    if (txtSearch.Text != "")
                    {
                        SearchText = txtSearch.Text;

                        if (SearchColumnName == "ID")
                            WhereClause = " and " + TblObj + ColumnIdName + "=" + SearchText;
                        else
                            WhereClause = " and " + TblObj + SearchColumnName + " like '%" + SearchText + "%'";
                        //like '%" + txtSearchAsset.Text + "%'";
                        //WhereClause = " and " + TblObj + SearchColumnName + " = " + SearchText + "";
                    }
                }
                else
                {
                    if (cmbSearch.SelectedIndex > -1)
                    {
                        if (IDTextFlag)
                            WhereClause = " and " + TblObj + SearchColumnName + " =" + cmbSearch.SelectedValue + "";
                        else
                        {
                            WhereClause = " and " + TblObj + SearchColumnName + " ='" + cmbSearch.Text + "'";

                            //if (TableName == "AssetMaster")
                            //    WhereClause = " and " + TblObj + SearchColumnName + " ='" + cmbSearch.Text + "'";
                            //else if(TableName =="AssetUpgrade")
                            //    WhereClause = " and " + TblObj + SearchColumnName + "='" + cmbSearch.Text + "'"; // (select " + SearchColumnName + " from AssetUpgrade AU inner join AssetMaster AM on AM.ID=AU.AssetId where AM.CancelTag=0 and AU.CancelTag=0 and " + SearchColumnName + "=" + cmbSearch.Text + " )";
                            //else if (TableName == "AssetSoftwares")
                            //    WhereClause = " and " + TblObj + SearchColumnName + " ='" + cmbSearch.Text + "'";
                            //else
                            //    WhereClause = ""; // and " + TblObj + SearchColumnName + " ='" + cmbSearch.Text + "'";

                            //WhereClause += " and " + TblObj + " CancelTag=0";
                        }
                    }
                }
            }
        }

        private void cmbSearch_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbSearch.SelectedIndex > -1)
            {
                FillGrid();
            }
        }

        private void txtUpgradeCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtUpgradeCost);
        }

        private void tpAssetMaster_Click(object sender, EventArgs e)
        {

        }

        private void txtAssetCode_TextChanged(object sender, EventArgs e)
        {
            if (txtAssetCode.Text != "")
                SetQRCode();
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
                SearchText = txtSearch.Text;
            else
                SearchText = "";
            FillGrid();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbSearchBy.SelectedIndex > -1)
            {
                if (cmbSearchBy.Text == "Asset Code")
                    objRL.NumericValue(sender, e, txtSearch);
                else
                    objRL.TxtNumericValue(sender, e, txtSearch);
            }
        }

        private void cmbEmployeeName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_EmployeeDetails();
        }

        private void Fill_EmployeeDetails()
        {
            txtUserName.Text = "";
            txtDesignation.Text = "";

            if (cmbEmployeeName.SelectedIndex > -1 && cmbLocation.SelectedIndex >-1 && cmbDepartment.SelectedIndex >-1)
            {
                objPC.EmployeeId = Convert.ToInt32(cmbEmployeeName.SelectedValue);

                DataSet ds = new DataSet();
                objPC.EmployeeId = Convert.ToInt32(cmbEmployeeName.SelectedValue);
                ds = objQL.SP_Employees_By_EmployeeId();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Code"].ToString())))
                        txtUserName.Text = ds.Tables[0].Rows[0]["Code"].ToString();
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Designation"].ToString())))
                        txtDesignation.Text = ds.Tables[0].Rows[0]["Designation"].ToString();
                }
            }
        }

        //GetManufracture

        private void btnViewSystem_Click(object sender, EventArgs e)
        {

            var key = Registry.LocalMachine.OpenSubKey(@"HARDWARE\DESCRIPTION\System\CentralProcessor\0\");
            var processorName = key.GetValue("ProcessorNameString");
            txtProcessor.Text = processorName.ToString();

            txtOperationSystem.Text = Convert.ToString(RedundancyLogics.GetOSFriendlyName("Win32_OperatingSystem"));
            //txtProcessor.Text = Convert.ToString(RedundancyLogics.GetOSFriendlyName("Win32_Processor"));
            txtRAM.Text = System.Convert.ToString(objRL.GetRAM()); //.GetOSFriendlyName("Win32_PhysicalMemory"));
            //txtSystemManufracturer.Text = Convert.ToString(RedundancyLogics.GetOSFriendlyName("Win32_ComputerSystem"));
            txtSerialNumberAsset.Text = objRL.GetSerialNumber();
            txtSystemManufracturer.Text = Convert.ToString(objRL.GetManufracture());

            txtComputerNameAsset.Text = Environment.MachineName;

            txtMACAddress.Text = Convert.ToString(objRL.GetMACAddress());

            txtIPAddress.Text = Convert.ToString(objRL.GetIPAddress());

            objRL.GetHardDiskDetails();
            txtHDDModel.Text = Convert.ToString(objRL.HDDModel);
            txtHDDSizeAsset.Text = Convert.ToString(objRL.HDDSize);

            txtSDDModel.Text = Convert.ToString(objRL.SSDModel);
            txtSDDSize.Text = Convert.ToString(objRL.SSDSize);

           // objRL.lSoftware = null;
            objRL.lSoftware.Clear();
            objRL.GetSoftwareInstalled();

            lbSoftware.DataSource =  objRL.lSoftware;

            lblTotalSoftware.Text = "Total Installed Software-" + objRL.lSoftware.Count.ToString();

    //        var wmi =
    //new ManagementObjectSearcher("select * from Win32_OperatingSystem")
    //.Get()
    //.Cast<ManagementObject>()
    //.First();

    //        OS.Name = ((string)wmi["Caption"]).Trim();
    //        OS.Version = (string)wmi["Version"];
    //        OS.MaxProcessCount = (uint)wmi["MaxNumberOfProcesses"];
    //        OS.MaxProcessRAM = (ulong)wmi["MaxProcessMemorySize"];
    //        OS.Architecture = (string)wmi["OSArchitecture"];
    //        OS.SerialNumber = (string)wmi["SerialNumber"];
    //        OS.Build = ((string)wmi["BuildNumber"]).ToUint();

        }

        private void label56_Click(object sender, EventArgs e)
        {

        }

        private void txtMACAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
