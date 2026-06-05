using BusinessLayerUtility;

using SPApplication.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPApplication.HR
{
    public partial class ContractorMaster : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0;

        public ContractorMaster()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_CONTRACTORMASTER);
            objRL.Get_UserRights_By_MenuName(BusinessResources.LBL_HEADER_MASTER);
            btnDocuments.BackColor = objDL.GetBackgroundColor();
            btnDocuments.ForeColor = objDL.GetForeColor();
            objDL.SetPlusButtonDesign(btnAddContry);
            objDL.SetPlusButtonDesign(btnAddState);
            objDL.SetPlusButtonDesign(btnAddDistrict);
            objDL.SetPlusButtonDesign(btnAddTaluka);
            objDL.SetPlusButtonDesign(btnAddCityVillage);
            objDL.SetPlusButtonDesign(btnAddArea);
            objDL.SetPlusButtonDesign(btnAddBank);

            objQL.Fill_Master_ComboBox(cmbContryName, "contrymaster");

            //objQL.PulseId = 10;
            //MessageBox.Show(objQL.PulseId.ToString());

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
            TableId = 0;
            FlagDelete = false;
            objEP.Clear();
            txtRegisterNo.Text = "";
            txtVendorNumber.Text = "";
            txtContractorName.Text = "";
            txtAddress.Text = "";
            cmbContryName.SelectedIndex = -1;
            cmbStateName.SelectedIndex = -1;
            cmbDistrictName.SelectedIndex = -1;
            cmbTalukaName.SelectedIndex = -1;
            cmbCityVillageName.SelectedIndex = -1;
            cmbAreaName.SelectedIndex = -1;
            txtPincode.Text = "";
            txtProprietorName.Text = "";
            txtMobileNumber.Text = "";
            txtEmailAddress.Text = "";
            dtpJoiningDate.Value = DateTime.Now.Date;
            txtGSTIN.Text = "";
            txtPFEstablishmentID.Text = "";
            txtESICEstablishmentID.Text = "";
            txtLWFNo.Text = "";
            txtPTRCNO.Text = "";
            txtPTECNO.Text = "";
            dtpContactRenewalDate.Value = DateTime.Now.Date;
            txtLabourLicenseNo.Text = "";
            txtTotalEmployeeAsPerLicense.Text = "";
            txtUdyogAadharNo.Text = "";
            txtAadharNo.Text = "";
            txtPANNumber.Text = "";
            cmbPaymentMode.SelectedIndex = -1;
            cmbBank.SelectedIndex = -1;
            txtAccountNo.Text = "";
            txtBranchName.Text = "";
            txtMICRNo.Text = "";
            txtIFSCode.Text = "";
            txtSearch.Text = "";
            FlagDelete = false;
            btnDelete.Enabled = false;
        }

        private bool Validation()
        {
            if (txtRegisterNo.Text == "")
            {
                txtRegisterNo.Focus();
                objEP.SetError(txtRegisterNo, "Enter Register No ");
                return false;
            }
            else if (txtContractorName.Text == "")
            {
                txtContractorName.Focus();
                objEP.SetError(txtContractorName, "Enter Constractor Name");
                return false;
            }
            else if (txtAddress.Text == "")
            {
                txtAddress.Focus();
                objEP.SetError(txtAddress, "Enter Address ");
                return false;
            }
            else if (txtProprietorName.Text == "")
            {
                txtProprietorName.Focus();
                objEP.SetError(txtProprietorName, "Enter Proprietor Name ");
                return false;
            }
            else if (txtMobileNumber.Text == "")
            {
                txtMobileNumber.Focus();
                objEP.SetError(txtMobileNumber, "Enter Mobile Number ");
                return false;
            }
            else if (txtEmailAddress.Text == "")
            {
                txtEmailAddress.Focus();
                objEP.SetError(txtEmailAddress, "Enter  Email Address ");
                return false;
            }
            else if (dtpJoiningDate.Text == "")
            {
                dtpJoiningDate.Focus();
                objEP.SetError(dtpJoiningDate, "Enter Joining Date ");
                return false;
            }
            else if (txtGSTIN.Text == "")
            {
                txtGSTIN.Focus();
                objEP.SetError(txtGSTIN, "Enter GSTIN ");
                return false;
            }
            else if (txtPFEstablishmentID.Text == "")
            {
                txtPFEstablishmentID.Focus();
                objEP.SetError(txtPFEstablishmentID, "Enter PF Establishment ID ");
                return false;
            }
            else if (txtESICEstablishmentID.Text == "")
            {
                txtESICEstablishmentID.Focus();
                objEP.SetError(txtESICEstablishmentID, "Enter ESIC Establishment ID ");
                return false;
            }
            else if (txtPTRCNO.Text == "")
            {
                txtPTRCNO.Focus();
                objEP.SetError(txtPTRCNO, "Enter PTRC NO");
                return false;
            }
            else if (txtPTECNO.Text == "")
            {
                txtPTECNO.Focus();
                objEP.SetError(txtPTECNO, "Enter PTEC NO ");
                return false;
            }
            else if (dtpContactRenewalDate.Text == "")
            {
                dtpContactRenewalDate.Focus();
                objEP.SetError(dtpContactRenewalDate, "Enter Contact Renewal Date ");
                return false;
            }
            else if (txtLabourLicenseNo.Text == "")
            {
                txtLabourLicenseNo.Focus();
                objEP.SetError(txtLabourLicenseNo, "Enter Labour License No ");
                return false;
            }
            else if (txtTotalEmployeeAsPerLicense.Text == "")
            {
                txtTotalEmployeeAsPerLicense.Focus();
                objEP.SetError(txtTotalEmployeeAsPerLicense, "Enter Total Employee As Per License ");
                return false;
            }
            else if (txtUdyogAadharNo.Text == "")
            {
                txtUdyogAadharNo.Focus();
                objEP.SetError(txtUdyogAadharNo, "Enter Udyog Aadhar No ");
                return false;
            }
            else if (txtAadharNo.Text == "")
            {
                txtAadharNo.Focus();
                objEP.SetError(txtAadharNo, "Enter Aadhar No ");
                return false;
            }
            else if (txtPANNumber.Text == "")
            {
                txtPANNumber.Focus();
                objEP.SetError(txtPANNumber, "Enter PAN Number ");
                return false;
            }
            else if (cmbPaymentMode.SelectedIndex == -1)
            {
                cmbPaymentMode.Focus();
                objEP.SetError(cmbPaymentMode, "Select Payment Mode ");
                return false;
            }
            else if (cmbBank.SelectedIndex == -1)
            {
                cmbBank.Focus();
                objEP.SetError(cmbBank, "select Bank ");
                return false;
            }
            else if (txtAccountNo.Text == "")
            {
                txtAccountNo.Focus();
                objEP.SetError(txtAccountNo, "Enter Account No ");
                return false;
            }
            else if (txtBranchName.Text == "")
            {
                txtBranchName.Focus();
                objEP.SetError(txtBranchName, "Enter Branch Name ");
                return false;
            }
            else if (txtMICRNo.Text == "")
            {
                txtMICRNo.Focus();
                objEP.SetError(txtMICRNo, "Enter MICR No ");
                return false;
            }
            else if (txtIFSCode.Text == "")
            {
                txtIFSCode.Focus();
                objEP.SetError(txtIFSCode, "Enter IFSc  Code ");
                return false;
            }
            else
                return false;
        }

        private void Contractor_Master_Load(object sender, EventArgs e)
        {
            ClearAll();
            FillGrid();
        }

        private void txtContractorId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtRegisterNo.Focus();
        }

        private void txtContractorName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtAddress.Focus();
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtProprietorName.Focus();
        }

        private void txtProprietorName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtMobileNumber.Focus();
        }

        private void txtEmailAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dtpJoiningDate.Focus();
        }

        private void dtpJoiningDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtGSTIN.Focus();
        }

        private void txtGSTIN_KeyDown(object sender, KeyEventArgs e)
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
                txtPTRCNO.Focus();
        }

        private void txtPTRCNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPTECNO.Focus();
        }

        private void txtPTECNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dtpContactRenewalDate.Focus();
        }

        private void dtpContactRenewalDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtLabourLicenseNo.Focus();
        }

        private void txtLabourLicenseNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtTotalEmployeeAsPerLicense.Focus();
        }

        private void txtRegisterNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtContractorName.Focus();
        }

        private void txtMobileNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtEmailAddress.Focus();
        }

        private void txtTotalEmployeeAsPerLicense_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtUdyogAadharNo.Focus();
        }

        private void txtUdyogAadharNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtAadharNo.Focus();

        }

        private void txtAadharNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPANNumber.Focus();
        }

        private void txtPANNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbPaymentMode.Focus();
        }

        private void cmbPaymentMode_KeyDown(object sender, KeyEventArgs e)
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
                txtMICRNo.Focus();
        }

        private void txtMICRNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtIFSCode.Focus();
        }

        private void txtIFSCode_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //    clbDocument.Focus();
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

        protected void SaveDB()
        {
            if (!Validation())
            {
                objPC.ContractorId = TableId;
                objPC.RegisterNo = txtRegisterNo.Text;
                objPC.VendorNumber = txtVendorNumber.Text;
                objPC.ContractorName = txtContractorName.Text;
                objPC.Address = txtAddress.Text;
                objPC.AreaId = Convert.ToInt32(cmbAreaName.SelectedValue);
                objPC.ProprietorName = txtProprietorName.Text;
                objPC.MobileNumber = txtMobileNumber.Text;
                objPC.EmailId = txtEmailAddress.Text;
                objPC.JoiningDate = Convert.ToDateTime(dtpJoiningDate.Value);
                objPC.GSTIN = txtGSTIN.Text;
                objPC.PFEstablishmentID = txtPFEstablishmentID.Text;
                objPC.ESICEstablishmentID = txtESICEstablishmentID.Text;
                objPC.LWFNo = txtLWFNo.Text;
                objPC.PTRCNo = txtPTRCNO.Text;
                objPC.PTECNo = txtPTECNO.Text;
                objPC.ContractRenewalDate = Convert.ToDateTime(dtpContactRenewalDate.Value);
                objPC.LabourLicenseNo = txtLabourLicenseNo.Text;
                objPC.TotalEmployeeAsPerLicense = txtTotalEmployeeAsPerLicense.Text;
                objPC.UdyogAadharNo = txtUdyogAadharNo.Text;
                objPC.AadharNo = txtAadharNo.Text;
                objPC.PANCardNumber = txtPANNumber.Text;
                objPC.PaymentMode = cmbPaymentMode.Text;
                objPC.BankName = cmbBank.Text;
                objPC.AccountNo = txtAccountNo.Text;
                objPC.BranchName = txtBranchName.Text;
                objPC.MICRNo = txtMICRNo.Text;
                objPC.IFSCCode = txtIFSCode.Text;
                objPC.UserId = BusinessLayer.LoginId_Static;
                objPC.DeleteFlag = FlagDelete;

                Result = objQL.SP_ContractorMaster_Insert_Update_Delete();
                if (Result > 0)
                {
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
            ds = objQL.SP_ContractorMaster_FillGrid();
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTotalCount.Text = "Total-" + ds.Tables[0].Rows.Count;
                //0 C.ContractorId,
                //1 C.RegisterNo as "Register No", 
                //2 C.ContractorName as "Contractor Name", 
                //3 C.Address,  
                //4 AM.ContryId,
                //5 CM.ContryName as 'Contry Name',
                //6 AM.StateId,
                //7 SM.StateName as 'State Name',
                //8 AM.DistrictId,
                //9 DM.DistrictName as 'District Name',
                //10 AM.TalukaId,
                //11 TM.TalukaName as 'Taluka Name',
                //12 AM.CityVillageId,
                //13 CVM.CityVillageName as 'City/Village Name',
                //14 C.AreaId, 
                //15 AM.AreaName as 'Area Name',
                //16 C.EmailId,
                //17 C.ProprietorName as "Proprietor Name",
                //18 C.MobileNumber as "Mobile Number", 
                //19 C.EmailId, 
                //C.JoiningDate as "Joinng Date", 
                //C.GSTIN, 
                //C.PFEstablishmentID as "PF Istablishment ID", 
                //C.ESICEstablishmentID  as "ESIC Establishment ID", 
                //C.PTRCNo,
                //C.PTECNo, 
                //C.ContractRenewalDate, 
                //C.LabourLicenseNo, 
                //C.TotalEmployeeAsPerLicense, 
                //C.UdyogAadharNo,
                //C.AadharNo, 
                //C.PANCardNumber, 
                //C.PaymentMode, 
                //C.BankName, 
                //C.AccountNo, 
                //C.BranchName,
                //C.MICRNo, 
                //C.IFSCCode

                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[15].Visible = false;

                dataGridView1.Columns[14].Width = 120;

                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    dataGridView1.Columns[i].Width = 150;
                }
                //dataGridView1.Columns[4].Width = 120;
                //dataGridView1.Columns[6].Width = 120;
                //dataGridView1.Columns[8].Width = 120;
                //dataGridView1.Columns[10].Width = 120;
                //dataGridView1.Columns[11].Width = 100;
                //}
            }
        }

        private void btnDocuments_Click(object sender, EventArgs e)
        {
            if (TableId != 0)
            {
                objPC.FormName = this.Name;
                objPC.FormHeader = BusinessResources.LBL_HEADER_CONTRACTORMASTER;
                objPC.TableId = TableId;
                Documents objForm = new Documents();
                objForm.ShowDialog(this);
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
                txtPincode.Text = Convert.ToString(objQL.SP_Get_Pincode_By_CityVillageId());
            }
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (objPC.ViewFlag == 1)
            {
                try
                {
                    RowCount_Grid = dataGridView1.Rows.Count;
                    CurrentRowIndex = dataGridView1.CurrentRow.Index;

                    if (RowCount_Grid >= 0 && CurrentRowIndex >= 0)
                    {
                        ClearAll();
                        //0	C.ContractorId,
                        //1	C.RegisterNo as "Register No", 
                        //2	C.VendorNumber as "Vendor Number",
                        //3	C.ContractorName as "Contractor Name", 
                        //4	C.Address,  
                        //5	AM.ContryId,
                        //6	CM.ContryName as 'Contry Name',
                        //7	AM.StateId,
                        //8	SM.StateName as 'State Name',
                        //9	AM.DistrictId,
                        //10	DM.DistrictName as 'District Name',
                        //11	AM.TalukaId,
                        //12	TM.TalukaName as 'Taluka Name',
                        //13	AM.CityVillageId,
                        //14	CVM.CityVillageName as 'City/Village Name',
                        //15	C.AreaId, 
                        //16	AM.AreaName as 'Area Name',
                        //17	C.ProprietorName as "Proprietor Name",
                        //18	C.MobileNumber as "Mobile Number", 
                        //19	C.EmailId, 
                        //20	C.JoiningDate as "Joinng Date", 
                        //21	C.GSTIN, 
                        //22	C.PFEstablishmentID as "PF Istablishment ID", 
                        //23	C.ESICEstablishmentID  as "ESIC Establishment ID", 
                        //24	C.LWFNo as "LWF No",
                        //25	C.PTRCNo,
                        //26	C.PTECNo, 
                        //27	C.ContractRenewalDate, 
                        //28	C.LabourLicenseNo, 
                        //29	C.TotalEmployeeAsPerLicense, 
                        //30	C.UdyogAadharNo,
                        //31	C.AadharNo, 
                        //32	C.PANCardNumber, 
                        //33	C.PaymentMode, 
                        //34	C.BankName, 
                        //35	C.AccountNo, 
                        //36	C.BranchName,
                        //37	C.MICRNo, 
                        //38	C.IFSCCode


                        btnDelete.Enabled = true;
                        TableId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                        txtRegisterNo.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtVendorNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        objPC.ContractorName = txtContractorName.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                        txtAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                        cmbContryName.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                        Fill_State();
                        cmbStateName.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                        Fill_District();
                        cmbDistrictName.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                        Fill_Taluka();
                        cmbTalukaName.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
                        Fill_CityVillage();
                        cmbCityVillageName.Text = dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString();
                        Fill_Area();
                        cmbAreaName.Text = dataGridView1.Rows[e.RowIndex].Cells[16].Value.ToString();
                        GetPincode();
                        txtProprietorName.Text = dataGridView1.Rows[e.RowIndex].Cells[17].Value.ToString();
                        txtMobileNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[18].Value.ToString();
                        txtEmailAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[19].Value.ToString();
                        //.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[19].Value.ToString());
                        txtGSTIN.Text = dataGridView1.Rows[e.RowIndex].Cells[21].Value.ToString();
                        txtPFEstablishmentID.Text = dataGridView1.Rows[e.RowIndex].Cells[22].Value.ToString();
                        txtESICEstablishmentID.Text = dataGridView1.Rows[e.RowIndex].Cells[23].Value.ToString();
                        txtLWFNo.Text = dataGridView1.Rows[e.RowIndex].Cells[24].Value.ToString();
                        txtPTRCNO.Text = dataGridView1.Rows[e.RowIndex].Cells[25].Value.ToString();
                        txtPTECNO.Text = dataGridView1.Rows[e.RowIndex].Cells[26].Value.ToString();
                        // dtpContactRenewalDate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[27].Value.ToString());
                        txtLabourLicenseNo.Text = dataGridView1.Rows[e.RowIndex].Cells[28].Value.ToString();
                        txtTotalEmployeeAsPerLicense.Text = dataGridView1.Rows[e.RowIndex].Cells[29].Value.ToString();
                        txtUdyogAadharNo.Text = dataGridView1.Rows[e.RowIndex].Cells[30].Value.ToString();
                        txtAadharNo.Text = dataGridView1.Rows[e.RowIndex].Cells[31].Value.ToString();
                        txtPANNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[32].Value.ToString();
                        cmbPaymentMode.Text = dataGridView1.Rows[e.RowIndex].Cells[33].Value.ToString();
                        cmbBank.Text = dataGridView1.Rows[e.RowIndex].Cells[34].Value.ToString();
                        txtAccountNo.Text = dataGridView1.Rows[e.RowIndex].Cells[35].Value.ToString();
                        txtBranchName.Text = dataGridView1.Rows[e.RowIndex].Cells[36].Value.ToString();
                        txtMICRNo.Text = dataGridView1.Rows[e.RowIndex].Cells[37].Value.ToString();
                        txtIFSCode.Text = dataGridView1.Rows[e.RowIndex].Cells[38].Value.ToString();
                    }
                }
                catch (Exception ex1)
                {
                    objRL.ErrorMessge(ex1.ToString());
                    return;
                }
                finally
                {
                    GC.Collect();
                }
            }
            else
            {
                objRL.ShowMessage(24, 4);
                return;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
                SearchFlag = true;
            else
                SearchFlag = false;

            FillGrid();
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
    }
}
