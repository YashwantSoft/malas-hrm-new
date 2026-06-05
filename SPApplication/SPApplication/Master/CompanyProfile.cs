using BusinessLayerUtility;
using SPApplication.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Configuration;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Management;
using System.Data.SqlClient;

namespace SPApplication.HR
{
    public partial class CompanyProfile : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0;

        public CompanyProfile()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_COMPANYPROFILE);
            objRL.Get_UserRights_By_MenuName(BusinessResources.LBL_HEADER_MASTER);

            objQL.Fill_Master_ComboBox(cmbContryName, "contrymaster");

            objDL.SetPlusButtonDesign(btnAddContry);
            objDL.SetPlusButtonDesign(btnAddState);
            objDL.SetPlusButtonDesign(btnAddDistrict);
            objDL.SetPlusButtonDesign(btnAddTaluka);
            objDL.SetPlusButtonDesign(btnAddCityVillage);
            objDL.SetPlusButtonDesign(btnAddArea);
            btnDocuments.BackColor = objDL.GetBackgroundColor();
            btnDocuments.ForeColor = objDL.GetForeColor();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            objEP.Clear();
            txtCompanyName.Text = "";
            txtRegisteredAddress.Text = "";
            txtUnitsAddress.Text = "";
            cmbContryName.SelectedIndex = -1;
            cmbStateName.SelectedIndex = -1;
            cmbDistrictName.SelectedIndex = -1;
            cmbTalukaName.SelectedIndex = -1;
            cmbCityVillageName.SelectedIndex = -1;
            cmbAreaName.SelectedIndex = -1;
            txtRegisterNo.Text = "";
            txtFactoryLicenseNumber.Text = "";
            txtUdyogAadharNumber.Text = "";
            txtFSSAINo.Text = "";
            txtGSTIN.Text = "";
            txtPFEstablishmentID.Text = "";
            txtESICEstablishmentID.Text = "";
            txtPTRCNo.Text = "";
            txtPTECNo.Text = "";
            txtLabourLicenseRegNo.Text = "";
            dtpLabourLicenseDate.Text = "";
            txtTotalEmployeeAsPerLicense.Text = "";
            dtpBRCRegisteredDate.Text = "";
            txtISORegNo.Text = "";
            dptISORegisteredDate.Text = "";
            cmbBank.Text = "";
            txtAccountNo.Text = "";
            txtBranchName.Text = "";
            txtMICRNO.Text = "";
            txtIFSCode.Text = "";
            txtPincode.Text = "";
            txtEmailAddress.Text = "";
            txtContactNo.Text = "";
            txtWebsite.Text = "";
            dtpEstablishmentDate.Text = "";
            lbEstablishmentDate.Text ="";
            txtTANNo.Text = "";
            txtPANNoCompanyInfo.Text = "";
            txtLWFNo.Text = "";
            FlagDelete = false;
            btnDelete.Enabled = false;
        }

        private bool Validation()
        {
            if (txtCompanyName.Text == "")
            {
                txtCompanyName.Focus();
                objEP.SetError(txtCompanyName, "Enter Company Name");
                return true;
            }
            else if (txtRegisteredAddress.Text == "")
            {
                txtRegisteredAddress.Focus();
                objEP.SetError(txtRegisteredAddress, "Enter Company Address");
                return true;
            }
            else if (txtUnitsAddress.Text=="")
            {
                txtUnitsAddress.Focus();
                objEP.SetError(txtUnitsAddress, "Enter Unit Address");
                return true;
            }
            else if (cmbContryName.SelectedIndex == -1)
            {
                cmbContryName.Focus();
                objEP.SetError(cmbContryName, " Enter Contry Name");
                return true;
            }
            else if (cmbStateName.SelectedIndex == -1)
            {
                cmbStateName.Focus();
                objEP.SetError(cmbStateName, " Enter State Name");
                return true;
            }
            else if (cmbDistrictName.SelectedIndex == -1)
            {
                cmbStateName.Focus();
                objEP.SetError(cmbDistrictName, " Enter District Name");
                return true;
            }
            else if (cmbTalukaName.SelectedIndex == -1)
            {
                cmbTalukaName.Focus();
                objEP.SetError(cmbTalukaName, " Enter Taluka Name");
                return true;
            }
            else if (cmbCityVillageName.SelectedIndex == -1)
            {
                cmbCityVillageName.Focus();
                objEP.SetError(cmbCityVillageName, " Enter City Village Name");
                return true;
            }
            else if (cmbAreaName.Text == "")
            {
                cmbAreaName.Focus();
                objEP.SetError(cmbAreaName, " Enter Area Name");
                return true;
            }
            else if (txtPincode.Text == "")
            {
                txtPincode.Focus();
                objEP.SetError(txtPincode, "Enter Pincode ");
                return true;
            }
            else if (txtEmailAddress.Text == "")
            {
                txtEmailAddress.Focus();
                objEP.SetError(txtEmailAddress, " Enter Email Address");
                return true;
            }

            else if (txtWebsite.Text == "")
            {
                txtWebsite.Focus();
                objEP.SetError(txtWebsite, "Enter WebSite");
                return true;
            }
            else if (txtContactNo.Text == "")
            {
                txtContactNo.Focus();
                objEP.SetError(txtContactNo, "Enter Contact No");
                return true;
            }
            else if (dtpEstablishmentDate.Text == "")
            {
                dtpEstablishmentDate.Focus();
                objEP.SetError(dtpEstablishmentDate, "Enter Establishment Date");
                return true;
            }

            else if (txtFactoryLicenseNumber.Text == "")
            {
                txtFactoryLicenseNumber.Focus();
                objEP.SetError(txtFactoryLicenseNumber, "Enter Factory LicenseNumber");
                return true;
            }
            else if (txtUdyogAadharNumber.Text == "")
            {
                txtUdyogAadharNumber.Focus();
                objEP.SetError(txtUdyogAadharNumber, "Enter Udyog Aadhar Number");
                return true;
            }

            else if (dtpDateIncorporation.Text == "")
            {
                dtpDateIncorporation.Focus();
                objEP.SetError(dtpDateIncorporation, "Enter Date Incorporation");
                return true;
            }

            else if (txtFSSAINo.Text == "")
            {
                txtFSSAINo.Focus();
                objEP.SetError(txtFSSAINo, "Enter FSSAI No");
                return true;
            }

            else if (txtGSTIN.Text == "")
            {
                txtGSTIN.Focus();
                objEP.SetError(txtGSTIN, "Enter GSTIN");
                return true;
            }

            else if (txtPANNoCompanyInfo.Text == "")
            {
                txtPANNoCompanyInfo.Focus();
                objEP.SetError(txtPANNoCompanyInfo, "Enter PAN No CompanyInfo");
                return true;
            }

            else if (txtTANNo.Text == "")
            {
                txtTANNo.Focus();
                objEP.SetError(txtTANNo, "Enter TANNo");
                return true;
            }

            else if (txtPFEstablishmentID.Text == "")
            {
                txtPFEstablishmentID.Focus();
                objEP.SetError(txtPFEstablishmentID, "Enter PF Establishment ID");
                return true;
            }

            else if (txtESICEstablishmentID.Text == "")
            {
                txtESICEstablishmentID.Focus();
                objEP.SetError(txtESICEstablishmentID, "Enter ESIC Establishment ID");
                return true;
            }

            else if (txtPTRCNo.Text == "")
            {
                txtPTRCNo.Focus();
                objEP.SetError(txtPTRCNo, "Enter PTRC No");
                return true;
            }
            else if (txtPTECNo.Text == "")
            {
                txtPTECNo.Focus();
                objEP.SetError(txtPTECNo, "Enter PTEC No");
                return true;
            }
            else if (txtLWFNo.Text == "")
            {
                txtLWFNo.Focus();
                objEP.SetError(txtLWFNo, "Enter LWF No");
                return true;
            }
            else if (txtLabourLicenseRegNo.Text == "")
            {
                txtLabourLicenseRegNo.Focus();
                objEP.SetError(txtLabourLicenseRegNo, "Enter Labour License Reg No");
                return true;
            }
            else if (dtpLabourLicenseDate.Text == "")
            {
                dtpLabourLicenseDate.Focus();
                objEP.SetError(dtpLabourLicenseDate, "Enter Labour License Date");
                return true;
            }
            else if (txtTotalEmployeeAsPerLicense.Text == "")
            {
                txtTotalEmployeeAsPerLicense.Focus();
                objEP.SetError(txtTotalEmployeeAsPerLicense, "Enter Total Employee As Per License");
                return true;
            }
            else if (txtBRCRegNo.Text == "")
            {
                txtBRCRegNo.Focus();
                objEP.SetError(txtBRCRegNo, "Enter BRC Reg No");
                return true;
            }
            else if (dtpBRCRegisteredDate.Text == "")
            {
                dtpBRCRegisteredDate.Focus();
                objEP.SetError(dtpBRCRegisteredDate, "Enter BRC Registered Date");
                return true;
            }
            else if (txtISORegNo.Text == "")
            {
                txtISORegNo.Focus();
                objEP.SetError(txtISORegNo, "Enter ISO Reg No");
                return true;
            }
            else if (dptISORegisteredDate.Text == "")
            {
                dptISORegisteredDate.Focus();
                objEP.SetError(dptISORegisteredDate, "Enter ISO Registered Date");
                return true;
            }
            else if (cmbBank.SelectedIndex == -1)
            {
                cmbBank.Focus();
                objEP.SetError(cmbBank, "Enter Bank");
                return true;
            }
            else if (txtAccountNo.Text == "")
            {
                txtAccountNo.Focus();
                objEP.SetError(txtAccountNo, "Enter Account No");
                return true;
            }
            else if (txtBranchName.Text == "")
            {
                txtBranchName.Focus();
                objEP.SetError(txtBranchName, "Enter Branch Name");
                return true;
            }
            else if (txtMICRNO.Text == "")
            {
                txtMICRNO.Focus();
                objEP.SetError(txtMICRNO, "Enter MICR NO");
                return true;
            }
            else if (txtIFSCode.Text == "")
            {
                txtIFSCode.Focus();
                objEP.SetError(txtIFSCode, "Enter IFSC Code");
                return true;
            }
            else
                return false;
        }

        private void lbSearch_Click(object sender, EventArgs e)
        {

        }

        int MaxCompanyId = 0;
        protected void SaveDB()
        {
            if (!Validation())
            {
                objPC.CompanyId = TableId;
                objPC.CompanyName = txtCompanyName.Text;
                objPC.RegisteredAddress = txtRegisteredAddress.Text;
                objPC.UnitsAddressDetails = txtUnitsAddress.Text;
                objPC.AreaId = Convert.ToInt32(cmbAreaName.SelectedValue);
                objPC.EmailId = txtEmailAddress.Text;
                objPC.Website = txtWebsite.Text;
                objPC.ContactNumber = txtContactNo.Text;
                objPC.EstablishmentDate = Convert.ToDateTime(dtpEstablishmentDate.Value);
                objPC.DateOfIncorporation = Convert.ToDateTime(dtpDateIncorporation.Value);
                objPC.RegistrationNumber = txtRegisterNo.Text;
                objPC.FactoryLicenseNumber = txtFactoryLicenseNumber.Text;
                objPC.UdyogAadharNumber = txtUdyogAadharNumber.Text;
                objPC.FSSAINo = txtFSSAINo.Text;
                objPC.GSTIN = txtGSTIN.Text;
                objPC.PANNo = txtPANNoCompanyInfo.Text;
                objPC.TANNo = txtTANNo.Text;
                objPC.PFEstablishmentID = txtPFEstablishmentID.Text;
                objPC.ESICEstablishmentID = txtESICEstablishmentID.Text;
                objPC.PTRCNo = txtPTRCNo.Text;
                objPC.PTECNo = txtPTECNo.Text;
                objPC.LWFNo = txtLWFNo.Text;
                objPC.LabourLicenseRegNo = txtLabourLicenseRegNo.Text;
                objPC.LabourLicenseDate = Convert.ToDateTime(dtpLabourLicenseDate.Value);
                objPC.TotalEmployeeAsPerLicense = txtTotalEmployeeAsPerLicense.Text;
                objPC.BRCRegNo = txtBRCRegNo.Text;
                objPC.BRCRegisteredDate = Convert.ToDateTime(dtpBRCRegisteredDate.Value);
                objPC.ISORegNo = txtISORegNo.Text;
                objPC.ISORegisteredDate = Convert.ToDateTime(dptISORegisteredDate.Value);
                objPC.BankName = cmbBank.Text;
                objPC.AccountNo = txtAccountNo.Text;
                objPC.BranchName = txtBranchName.Text;
                objPC.MICRNo = txtMICRNO.Text;
                objPC.IFSCCode = txtIFSCode.Text;
                objPC.UserId = BusinessLayer.LoginId_Static;
                objPC.DeleteFlag = FlagDelete;

                Result = objQL.SP_CompanyProfile_Insert_Update_Delete();
                if (Result > 0)
                {
                    if(TableId ==0)
                        MaxCompanyId = objRL.ReturnMaxID_Fix("companyprofile", "CompanyId");

                    if (!FlagDelete)
                        objRL.ShowMessage(7, 1);
                    else
                        objRL.ShowMessage(9, 1);

                    FillGrid();
                    ClearAll();
                }
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }

        protected void FillGrid()
        {
            DataSet ds = new DataSet();
            ds = objQL.SP_CompanyProfile_FillGrid();
            if (ds.Tables[0].Rows.Count > 0)
            {
                TableId = Convert.ToInt32(ds.Tables[0].Rows[0]["CompanyId"].ToString());
                MaxCompanyId = Convert.ToInt32(ds.Tables[0].Rows[0]["CompanyId"].ToString());
                txtCompanyName.Text = ds.Tables[0].Rows[0]["Company Name"].ToString();
                txtRegisteredAddress.Text = ds.Tables[0].Rows[0]["Registered Address"].ToString();
                txtUnitsAddress.Text = ds.Tables[0].Rows[0]["Units Address Details"].ToString();
                cmbContryName.Text = ds.Tables[0].Rows[0]["Contry Name"].ToString();
                Fill_State();
                cmbStateName.Text = ds.Tables[0].Rows[0]["State Name"].ToString();
                Fill_District();
                cmbDistrictName.Text = ds.Tables[0].Rows[0]["District Name"].ToString();
                Fill_Taluka();
                cmbTalukaName.Text = ds.Tables[0].Rows[0]["Taluka Name"].ToString();
                Fill_CityVillage();
                cmbCityVillageName.Text = ds.Tables[0].Rows[0]["City/Village Name"].ToString();
                Fill_Area();
                cmbAreaName.Text = ds.Tables[0].Rows[0]["Area Name"].ToString();
                GetPincode();
                txtEmailAddress.Text = ds.Tables[0].Rows[0]["EmailId"].ToString();
                txtWebsite.Text = ds.Tables[0].Rows[0]["Website"].ToString();
                txtContactNo.Text = ds.Tables[0].Rows[0]["Contact Number"].ToString();
                dtpEstablishmentDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["Establishment Date"].ToString());
                dtpDateIncorporation.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["Date of Incorporation"].ToString());
                txtRegisterNo.Text = ds.Tables[0].Rows[0]["Registration Number"].ToString();
                txtFactoryLicenseNumber.Text = ds.Tables[0].Rows[0]["Factory License Number"].ToString();
                txtUdyogAadharNumber.Text = ds.Tables[0].Rows[0]["Udyog Aadhar Number"].ToString();
                txtFSSAINo.Text = ds.Tables[0].Rows[0]["FSSAI No"].ToString();
                txtGSTIN.Text = ds.Tables[0].Rows[0]["GSTIN"].ToString();
                txtPANNoCompanyInfo.Text = ds.Tables[0].Rows[0]["PAN No"].ToString();
                txtTANNo.Text = ds.Tables[0].Rows[0]["TAN No"].ToString();
                txtPFEstablishmentID.Text = ds.Tables[0].Rows[0]["PF Establishment ID"].ToString();
                txtESICEstablishmentID.Text = ds.Tables[0].Rows[0]["ESIC Establishment ID"].ToString();
                txtPTRCNo.Text = ds.Tables[0].Rows[0]["PTRC No"].ToString();
                txtPTECNo.Text = ds.Tables[0].Rows[0]["PTEC No"].ToString();
                txtLWFNo.Text = ds.Tables[0].Rows[0]["LWF No"].ToString();
                txtLabourLicenseRegNo.Text = ds.Tables[0].Rows[0]["Labour License Reg No"].ToString();
                dtpLabourLicenseDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["Labour License Date"].ToString());
                txtTotalEmployeeAsPerLicense.Text = ds.Tables[0].Rows[0]["Total Employee as Per License"].ToString();
                txtBRCRegNo.Text = ds.Tables[0].Rows[0]["BRC Reg No"].ToString();
                dtpBRCRegisteredDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["BRC Registered Date"].ToString());
                txtISORegNo.Text = ds.Tables[0].Rows[0]["ISO Reg No"].ToString();
                dptISORegisteredDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["ISO Registered Date"].ToString());
                cmbBank.Text = ds.Tables[0].Rows[0]["Bank Name"].ToString();
                txtAccountNo.Text = ds.Tables[0].Rows[0]["Account No"].ToString();
                txtBranchName.Text = ds.Tables[0].Rows[0]["Branch Name"].ToString();
                txtMICRNO.Text = ds.Tables[0].Rows[0]["MICR No"].ToString();
                txtIFSCode.Text = ds.Tables[0].Rows[0]["IFSC Code"].ToString();
                RetriveImage();
            }

            //    lblTotalCount.Text = "Total-" + ds.Tables[0].Rows.Count;
            //    //0 AM.AreaId,
            //    //1 AM.ContryId,
            //    //2 CM.ContryName as 'Contry Name',
            //    //3 AM.StateId,
            //    //4 SM.StateName as 'State Name',
            //    //5 AM.DistrictId,
            //    //6 DM.DistrictName as 'District Name',
            //    //7 AM.TalukaId,
            //    //8 TM.TalukaName as 'Taluka Name',
            //    //9 AM.CityVillageId,
            //    //10 CVM.CityVillageName as 'City/Village Name',
            //    //11 AM.AreaName as 'Area Name' 

            //    dataGridView1.DataSource = ds.Tables[0];
            //    dataGridView1.Columns[0].Visible = false;
            //    dataGridView1.Columns[1].Visible = false;
            //    dataGridView1.Columns[3].Visible = false;
            //    dataGridView1.Columns[5].Visible = false;
            //    dataGridView1.Columns[7].Visible = false;
            //    dataGridView1.Columns[9].Visible = false;
            //    dataGridView1.Columns[2].Width = 120;
            //    dataGridView1.Columns[4].Width = 120;
            //    dataGridView1.Columns[6].Width = 120;
            //    dataGridView1.Columns[8].Width = 120;
            //    dataGridView1.Columns[10].Width = 120;
            //    dataGridView1.Columns[11].Width = 100;
            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (objPC.AddFlag == 1)
            {
                try
                {
                    FlagDelete = false;
                    SaveDB();
                }
                catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
                finally { GC.Collect(); }
            }
            else
            {
                objRL.ShowMessage(24, 4);
                return;
            } 
        }

        private void Company_Profile_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        
        private void txtCompanyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtRegisteredAddress.Focus();
        }

        private void txtCompanyAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtUnitsAddress.Focus();
        }

        private void txtUnitsAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbContryName.Focus();
        }

        private void cmbTaluka_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPincode.Focus();
        }

        private void txtPincode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtEmailAddress.Focus();
        }

        private void txtEmailAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtWebsite.Focus();
        }

        private void txtWebsite_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtContactNo.Focus();
        }

        private void txtPhoneNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dtpEstablishmentDate.Focus();
        }

        private void dtpFromDate_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dtpEstablishmentDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dtpDateIncorporation.Focus();
        }

        private void dtpDateIncorporation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtRegisterNo.Focus();
        }

        private void txtRegisterNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtFactoryLicenseNumber.Focus();
        }

        private void txtFactoryLicenseNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtUdyogAadharNumber.Focus();
        }

        private void txtUdyogAadharNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtFSSAINo.Focus();
        }

        private void txtFSSAINo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtGSTIN.Focus();
        }

        private void txtGSTIN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPANNoCompanyInfo.Focus();
        }

        private void txtPANNoCompanyInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtTANNo.Focus();
        }

        private void txtTANNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPFEstablishmentID.Focus();
        }

        private void txtPFEstablishmentID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtESICEstablishmentID.Focus();
        }

        private void txtESICEstablishmentID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPTRCNo.Focus();
        }

        private void txtPTRCNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPTECNo.Focus();
        }

        private void txtPTECNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtLWFNo.Focus();
        }

        private void txtLWFNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtLabourLicenseRegNo.Focus();
        }

        private void txtLabourLicenseRegNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dtpLabourLicenseDate.Focus();
        }

        private void dtpLabourLicenseDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtTotalEmployeeAsPerLicense.Focus();
        }

        private void txtTotalEmployeeAsPerLicense_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtBRCRegNo.Focus();
        }

        private void txtBRCRegNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dtpBRCRegisteredDate.Focus();
        }

        private void dtplbBRCRegisteredDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtISORegNo.Focus();
        }

        private void txtISORegNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dptISORegisteredDate.Focus();
        }

        private void dptISORegisteredDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbBank.Focus();
        }

        private void cmbBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtAccountNo.Focus();
        }

        private void txtAccountNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtBranchName.Focus();
        }

        private void txtBranchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtMICRNO.Focus();
        }

        private void txtMICRNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtIFSCode.Focus();
        }

        private void tpInformation_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Fill_State()
        {
            if (cmbContryName.SelectedIndex > -1)
            {
                objPC.SearchType = "State";
                objPC.SearchId = Convert.ToInt32(cmbContryName.SelectedValue);
                objQL.SP_State_District_Area_Master_By_Id(cmbStateName);
                cmbDistrictName.SelectedIndex = -1;
                cmbTalukaName.SelectedIndex = -1;
            }
        }

        private void Fill_District()
        {
            if (cmbContryName.SelectedIndex > -1 && cmbStateName.SelectedIndex > -1)
            {
                objPC.SearchType = "District";
                objPC.SearchId = Convert.ToInt32(cmbStateName.SelectedValue);
                objQL.SP_State_District_Area_Master_By_Id(cmbDistrictName);
                cmbTalukaName.SelectedIndex = -1;
            }
        }

        private void Fill_Taluka()
        {
            if (cmbContryName.SelectedIndex > -1 && cmbStateName.SelectedIndex > -1 && cmbDistrictName.SelectedIndex > -1)
            {
                objPC.SearchType = "Taluka";
                objPC.SearchId = Convert.ToInt32(cmbDistrictName.SelectedValue);
                objQL.SP_State_District_Area_Master_By_Id(cmbTalukaName);
            }
        }

        private void Fill_CityVillage()
        {
            if (cmbContryName.SelectedIndex > -1 && cmbStateName.SelectedIndex > -1 && cmbDistrictName.SelectedIndex > -1 && cmbTalukaName.SelectedIndex > -1)
            {
                objPC.SearchType = "CityVillage";
                objPC.SearchId = Convert.ToInt32(cmbTalukaName.SelectedValue);
                objQL.SP_State_District_Area_Master_By_Id(cmbCityVillageName);
            }
        }

        private void Fill_Area()
        {
            if (cmbContryName.SelectedIndex > -1 && cmbStateName.SelectedIndex > -1 && cmbDistrictName.SelectedIndex > -1 && cmbTalukaName.SelectedIndex > -1 && cmbCityVillageName.SelectedIndex > -1)
            {
                objPC.SearchType = "Area";
                objPC.SearchId = Convert.ToInt32(cmbCityVillageName.SelectedValue);
                objQL.SP_State_District_Area_Master_By_Id(cmbAreaName);
            }
        }

        private void btnAddContry_Click(object sender, EventArgs e)
        {
            CountryMaster objForm = new CountryMaster();
            objForm.ShowDialog(this);
            objQL.Fill_Master_ComboBox(cmbContryName, "contrymaster");
            cmbStateName.SelectedIndex = -1;
            cmbDistrictName.SelectedIndex = -1;
            cmbTalukaName.SelectedIndex = -1;
            cmbCityVillageName.SelectedIndex = -1;
        }

        private void btnAddState_Click(object sender, EventArgs e)
        {
            StateMaster objForm = new StateMaster();
            objForm.ShowDialog(this);
            Fill_State();
        }

        private void btnAddDistrict_Click(object sender, EventArgs e)
        {
            DistrictMaster objForm = new DistrictMaster();
            objForm.ShowDialog(this);
            Fill_District();
        }

        private void btnAddTaluka_Click(object sender, EventArgs e)
        {
            TalukaMaster objForm = new TalukaMaster();
            objForm.ShowDialog(this);
            Fill_Taluka();
        }

        private void btnAddCityVillage_Click(object sender, EventArgs e)
        {
            CityVillageMaster objForm = new CityVillageMaster();
            objForm.ShowDialog(this);
            Fill_CityVillage();
        }

        private void btnAddArea_Click(object sender, EventArgs e)
        {
            AreaMaster objForm = new AreaMaster();
            objForm.ShowDialog(this);
            Fill_Area();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (objPC.DeleteFlagUR == 1)
            {
                try
                {
                    DialogResult dr = objRL.Delete_Record_Show_Message();
                    if (dr == System.Windows.Forms.DialogResult.Yes)
                    {
                        FlagDelete = true;
                        SaveDB();
                    }
                }
                catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
                finally { GC.Collect(); }
            }
            else
            {
                objRL.ShowMessage(24, 4);
                return;
            }
        }

        private void cmbContryName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_State();
        }

        private void cmbStateName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_District();
        }

        private void cmbDistrictName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_Taluka();
        }

        private void cmbTalukaName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_CityVillage();
        }

        private void cmbCityVillageName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_Area();
        }

        private void cmbAreaName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetPincode();
        }

        private void GetPincode()
        {
            if (cmbAreaName.SelectedIndex > -1)
            {
                objPC.AreaId = Convert.ToInt32(cmbAreaName.SelectedValue);
                txtPincode.Text =Convert.ToString(objQL.SP_Get_Pincode_By_CityVillageId());
            }
        }

        private void btnDocuments_Click(object sender, EventArgs e)
        {
            if (TableId != 0)
            {
                objPC.FormName = this.Name;
                objPC.FormHeader = BusinessResources.LBL_HEADER_COMPANYPROFILE;
                objPC.TableId = TableId;
                Documents objForm = new Documents();
                objForm.ShowDialog(this);
            }

        }

        private void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            Get_File();
        }

        string FileName = string.Empty, SourcePath = string.Empty, DestinationPath = string.Empty;

        private void Get_File()
        {
            FileName = string.Empty; SourcePath = string.Empty; DestinationPath = string.Empty;

            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Choose Image File";
                openFileDialog.InitialDirectory =
                             Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                openFileDialog.Filter = "Image Files (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pbEmployeePhoto.Image = new Bitmap(openFileDialog.FileName);
                    
                }
                // store file path in some field or textbox...
                txtImagePath.Text = openFileDialog.FileName;
            }

            //OpenFileDialog opnfd = new OpenFileDialog();
            //opnfd.Filter = "Files (*.jpg;*.jpeg;.*.png;)|*.jpg;*.jpeg;.*.png";
            //if (opnfd.ShowDialog() == DialogResult.OK)
            //{
            //    SourcePath = opnfd.FileName;
            //    FileName = Path.GetFileName(SourcePath);
            //    pbEmployeePhoto.Image = new Bitmap(opnfd.FileName);
            //}
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            //objBL.Connect();
            //// Write to database like this - image is LONGBLOB type
            ////string sql = "INSERT INTO imagetable (image) VALUES (@file)";
            //string sql = "UPDATE companyprofile SET CompanyLogo=@CompanyLogo WHERE CompanyId =" + MaxCompanyId + ";";
            //// remember 'using' statements to efficiently release unmanaged resources
            //using (var conn = new MySqlConnection(objBL.conString))
            //{
            //    conn.Open();
            //    using (var cmd = new MySqlCommand(sql, conn))
            //    {
            //        // parameterize query to safeguard against sql injection attacks, etc. 
            //        cmd.Parameters.AddWithValue("@CompanyLogo", File.ReadAllBytes(txtImagePath.Text));
            //        int R= cmd.ExecuteNonQuery();
            //    }
            //}

            //FileStream fs; BinaryReader br;
            //byte[] ImageData;
            //fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //br = new BinaryReader(fs);
            //ImageData = br.ReadBytes((int)fs.Length);
            //br.Close();
            //fs.Close();


            //objBL.Connect();
            //MySqlCommand command = new MySqlCommand(objBL.conString, objBL.objCon);
            //command.CommandText = "UPDATE companyprofile SET CompanyLogo=@CompanyLogo WHERE CompanyId =" + MaxCompanyId + ";";
            //byte[] data = imageToByte(pbEmployeePhoto.Image);
            //MySqlParameter blob = new MySqlParameter("@CompanyLogo", MySqlDbType.LongBlob, data.Length);

            //command.Parameters.Add("@CompanyLogo", MySqlDbType.LongBlob);
            //command.Parameters["@CompanyLogo"].Value = ImageData;


            //blob.Value = data;
            ////command.Parameters.Add(blob);
            //int R=command.ExecuteNonQuery();
            //objBL.objCon.Close();

            //MySqlCommand cmd = new MySqlCommand("insert into Fn_Pictures(Images,Email)values(?Images,'" + txte + "')", cn);
            //MySqlParameter parImage = new MySqlParameter();
            //parImage.ParameterName = "?Images";
            //parImage.MySqlDbType = MySqlDbType.MediumBlob;
            //parImage.Size = 3000000;
            //parImage.Value = ImageData;//here you should put your byte []

            //cmd.Parameters.Add(parImage);
            //cmd.ExecuteNonQuery();
        }

        private void tpLogo_Click(object sender, EventArgs e)
        {

          
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    sql = new SqlConnection(@"Data Source=PC-PC\PC;Initial Catalog=Test;Integrated Security=True");
        //    cmd = new SqlCommand();
        //    cmd.Connection = sql;
        //    cmd.CommandText = ("select Image from Entry where EntryID =@EntryID");
        //    cmd.Parameters.AddWithValue("@EntryID", Convert.ToInt32(textBox1.Text));
        //}

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            //byte[] buffer = (byte[])rd.GetValue(3);
            //using (var memStream = new MemoryStream(buffer))
            //{
            //    var ic = new System.Drawing.ImageConverter();
            //    pbGambar1.Image = (System.Drawing.Image)ic.ConvertFrom(stream.ReadAllBytes());
            //}

            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private byte[] ImageToByteArray(string ImageFile)
        {
            FileStream stream = new FileStream(
                  ImageFile, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);

            // Convert image to byte array.
            byte[] photo = reader.ReadBytes((int)stream.Length);

            return photo;
        }

        //private byte[] ImageToByteArray(string ImageFile)
        //{
        //    FileStream stream = new FileStream(
        //          ImageFile, FileMode.Open, FileAccess.Read);
        //    BinaryReader reader = new BinaryReader(stream);

        //    // Convert image to byte array.
        //    byte[] photo = reader.ReadBytes((int)stream.Length);

        //    return photo;
        //}

        //public Image byteArrayToImage(byte[] byteBLOBData)
        //{

        //    System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
        //    Image img = (Image)converter.ConvertFrom(byteBLOBData);

        //    return img;

        //    //Image returnImage;

        //    ////MemoryStream ms = new MemoryStream(byteBLOBData);
        //    ////headshot.Headshot = System.Drawing.Image.FromStream(ms);
        //    //using (var ms = new MemoryStream(byteBLOBData))
        //    //{
        //    //    returnImage = System.Drawing.Image.FromStream(ms);
        //    //}
        //    ////Image returnImage = Image.FromStream(ms);
        //    //return returnImage;
        //}

        private void RetriveImage()
        {
            objBL.Connect();
            // read image from database like this
            //string sql = "SELECT image FROM imagetable WHERE ID = @ID";

            //string sql = "select CompanyLogo from companyprofile where CompanyId=@CompanyId and CompanyLogo IS NOT null"; // =" + MaxCompanyId + ";";
            //using (var conn = new MySqlConnection(objBL.conString))
            //{
            //    conn.Open();
            //    using (var cmd = new MySqlCommand(sql, conn))
            //    {
            //        cmd.Parameters.AddWithValue("@CompanyId", MaxCompanyId);

            //        byte[] bytes = (byte[])cmd.ExecuteScalar();

            //        //byte[] imageBytes = (byte[])dr["headshot"];

            //        if (bytes != null)
            //        {
            //            using (var byteStream = new MemoryStream(bytes))
            //            {
            //                pbEmployeePhoto.Image = new Bitmap(byteStream);
            //            }

            //            //using (var ms = new MemoryStream(bytes))
            //            //{
            //            //    pbEmployeePhoto.Image = System.Drawing.Image.FromStream(ms);
            //            //}

            //            //MemoryStream ms = new MemoryStream(bytes);
            //            //ms.Seek(0, SeekOrigin.Begin);
            //            //Bitmap bmp = new Bitmap(ms);
            //            //pbEmployeePhoto.Image = bmp;
            //        }
            //    }
            //}

            //DataSet ds = new DataSet();
            //objBL.Connect();
            //MySqlCommand command = new MySqlCommand(objBL.conString, objBL.objCon);
            //command.CommandText = "select CompanyLogo from companyprofile where CompanyId =" + MaxCompanyId + ";";
            //MySqlDataAdapter da = new MySqlDataAdapter(command);
            //da.Fill(ds);

            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    byte[] img = (byte[])ds.Tables[0].Rows[0]["CompanyLogo"];
            //    //byte[] img = ImageToByteArray(ds.Tables[0].Rows[0]["CompanyLogo"].ToString());
            //    pbEmployeePhoto.Image = byteArrayToImage(img);

            //    //byte[] buffer = (byte[])ds.Tables[0].Rows[0]["CompanyLogo"];
            //    //using (var memStream = new MemoryStream(buffer))
            //    //{
            //    //    var ic = new System.Drawing.ImageConverter();
            //    //    pbEmployeePhoto.Image = (System.Drawing.Image)ic.ConvertFrom(memStream.ReadByte());
            //    //}
            //}



            //var da = new MySqlDataAdapter(command);
            //var ds = new DataSet();
            //da.Fill(ds);
            //int count = ds.Tables[0].Rows.Count;

            //byte[] img = (byte[])ds.Tables[0].Rows[0]["CompanyLogo"];
            //pbEmployeePhoto.Image = byteArrayToImage(img);

            //pbEmployeePhoto.Image = ByteToImage(img);


            //if (count > 0)
            //{
            //    var data = (Byte[])ds.Tables[0].Rows[count - 1]["CompanyLogo"];
            //    var stream = new MemoryStream(data);
            //    pbEmployeePhoto.Image = Image.FromStream(stream);
            //} 
        }

        //private void RetriveImage()
        //{
        //    //objBL.Connect();
        //    // read image from database like this
        //    //string sql = "SELECT image FROM imagetable WHERE ID = @ID";
        //    byte[] bytes = null;

        //    string sql = "select CompanyLogo from companyprofile where CompanyId=@CompanyId and CompanyLogo IS NOT null"; // =" + MaxCompanyId + ";";

        //    objBL.Connect();

        //    objBL.Query = sql;
        //    DataTable dt = new DataTable();
        //    dt = objBL.ReturnDataTable();

        //    MySqlCommand cmd = new MySqlCommand(sql,objBL.objCon);

        //   // cmd.CommandText = sql;
        //    MySqlDataReader myReader;
        //    myReader = cmd.ExecuteReader();  //stop here
        //    try
        //    {
        //        while (myReader.Read())
        //        {
        //            bytes = (byte[])myReader["CompanyLogo"];
        //        }

        //        if (bytes != null)
        //        {
        //            using (var byteStream = new MemoryStream(bytes))
        //            {
        //                pbEmployeePhoto.Image = new Bitmap(byteStream);
        //            }

        //            //using (var ms = new MemoryStream(bytes))
        //            //{
        //            //    pbEmployeePhoto.Image = System.Drawing.Image.FromStream(ms);
        //            //}

        //            //MemoryStream ms = new MemoryStream(bytes);
        //            //ms.Seek(0, SeekOrigin.Begin);
        //            //Bitmap bmp = new Bitmap(ms);
        //            //pbEmployeePhoto.Image = bmp;
        //        }
        //    }
        //    finally
        //    {
        //        Console.WriteLine("Yolo");
        //        objBL.objCon.Close();
        //    }



        //    //string sql = "select CompanyLogo from companyprofile where CompanyId=@CompanyId and CompanyLogo IS NOT null"; // =" + MaxCompanyId + ";";
        //    //MySqlDataReader myReader;

        //    //using (var conn = new MySqlConnection(objBL.conString))
        //    //{
        //    //    conn.Open();
        //    //    using (var cmd = new MySqlCommand(sql, conn))
        //    //    {
        //    //        byte[] bytes = null;
        //    //        myReader = cmd.ExecuteReader();  //stop here

        //    //        try
        //    //        {
        //    //            while (myReader.Read())
        //    //            {
        //    //                //Console.WriteLine(myReader.GetString(0));
        //    //                bytes = (byte[])myReader["CompanyLogo"];
        //    //            }

        //    //            if (bytes != null)
        //    //            {
        //    //                using (var byteStream = new MemoryStream(bytes))
        //    //                {
        //    //                    pbEmployeePhoto.Image = new Bitmap(byteStream);
        //    //                }

        //    //                //using (var ms = new MemoryStream(bytes))
        //    //                //{
        //    //                //    pbEmployeePhoto.Image = System.Drawing.Image.FromStream(ms);
        //    //                //}

        //    //                //MemoryStream ms = new MemoryStream(bytes);
        //    //                //ms.Seek(0, SeekOrigin.Begin);
        //    //                //Bitmap bmp = new Bitmap(ms);
        //    //                //pbEmployeePhoto.Image = bmp;
        //    //            }
        //    //        }
        //    //        finally
        //    //        {
        //    //            //Console.WriteLine("Yolo");
        //    //            conn.Close();
        //    //        }

        //    //    }
        //    //}
        //}

        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;

        }


        //public void UploadImage(Image img)
        //{
        //    OpenConnection();
        //    MySqlCommand command = new MySqlCommand("", conn);
        //    command.CommandText = "UPDATE User SET UserImage = '@UserImage' WHERE UserID = '" + UserID.globalUserID + "';";
        //    byte[] data = imageToByte(img);
        //    MySqlParameter blob = new MySqlParameter("@UserImage", MySqlDbType.Blob, data.Length);
        //    blob.Value = data;

        //    command.Parameters.Add(blob);

        //    command.ExecuteNonQuery();
        //    CloseConnection();
        //}

        public byte[] imageToByte(Image img)
        {
            using (var ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
    }
}
