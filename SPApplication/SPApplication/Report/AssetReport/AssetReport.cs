using BusinessLayerUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPApplication.Report.AssetReport
{
    public partial class AssetReport : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        int TableId = 0, Result = 0;
        bool FlagDelete = false;
        bool FlagUpdate = false;

        string ColumnNames_V = string.Empty, TableNames_V = string.Empty, OrderBy_V = string.Empty, GroupBy_V = string.Empty;

        public AssetReport()
        {
            InitializeComponent();
            objDL.Set_Report_Design(this, lblHeader, btnView, btnReport, btnClear, btnExit, BusinessResources.LBL_HEADER_ASSETREPORT);
            objQL.Fill_Master_ComboBox(cmbLocation, "locationmaster");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmbLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbLocation.SelectedIndex > -1)
            {
                objPC.LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
                objRL.Fill_Department_CheckedListBox_By_Location_Asset(clbDepartment);
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            cmbLocation.SelectedIndex = -1;
            cbSelectAll.Checked = false;
            cbSelectAllDepartment.Checked = false;
            clbDepartment.DataSource = null;
            cmbLocation.Focus();
        }

        private void cbDepartment_CheckedChanged(object sender, EventArgs e)
        {
            GB_Settings(gbDepartment, clbDepartment, cbDepartment, cbSelectAllDepartment);
        }

        private void GB_Settings(GroupBox gb, CheckedListBox clb, CheckBox cb, CheckBox cbSelectAll)
        {
            if (cb.Checked)
            {
                gb.Enabled = true;

                for (int i = 0; i < clb.Items.Count; i++)
                {
                    if (cbSelectAll.Checked)
                        clb.SetItemChecked(i, true);
                    else
                        clb.SetItemChecked(i, false);
                }
            }
            else
            {
                cbSelectAll.Checked = false;
                gb.Enabled = false;
                for (int i = 0; i < clb.Items.Count; i++)
                {
                    clb.SetItemChecked(i, false);
                }
            }
        }

        private void cbSelectAllDepartment_CheckedChanged(object sender, EventArgs e)
        {
            GB_Settings(gbDepartment, clbDepartment, cbDepartment, cbSelectAllDepartment);
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
                 
            }
            else
            {
                gbSearch.Visible = true;
                cmbSearchBy.SelectedIndex = -1;
                cmbSearchBy.Enabled = true;
            }
        }
        string WhereClause = string.Empty;
        private void cmbSearch_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbSearch.SelectedIndex > -1)
            {
                if (cmbSearchBy.SelectedIndex > -1)
                {
                    if (!cbSelectAll.Checked)
                        GetColumnName_Search();
                    else
                        WhereClause = string.Empty;
                }
            }
        }

        
        bool IDTextFlag = false;
        double TotalCost = 0;

        string TableName = string.Empty, SearchColumnName = string.Empty, TblObj = string.Empty, TableClause = string.Empty, WhereBasic = string.Empty;

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

                if (cmbSearch.SelectedIndex > -1)
                {
                    if (IDTextFlag)
                        WhereClause = " and " + TblObj + SearchColumnName + " =" + cmbSearch.SelectedValue + "";
                    else
                        WhereClause = " and " + TblObj + SearchColumnName + " ='" + cmbSearch.Text + "'";
                }
            }
        }

        private void AssetReport_Load(object sender, EventArgs e)
        {

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (!Validation())
                FillGrid();
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }

        private bool Validation()
        {
            bool FlagReturn = false;
            objEP.Clear();

            if (!FlagReturn)
            {
                if (cmbLocation.SelectedIndex == -1)
                {
                    cmbLocation.Focus();
                    objEP.SetError(cmbLocation, "Select Location");
                    FlagReturn = true;
                }
                else
                    FlagReturn = false;
            }

            if (!FlagReturn)
            {
                if (cbDepartment.Checked)
                {
                    if (!cbSelectAllDepartment.Checked)
                    {
                        if (clbDepartment.CheckedItems.Count == 0)
                        {
                            clbDepartment.Focus();
                            objEP.SetError(clbDepartment, "Select Department");
                            FlagReturn = true;
                        }
                        else
                            FlagReturn = false;
                    }
                    else
                        FlagReturn = false;
                }
            }
            if (!FlagReturn)
            {
                if (cbSelectAll.Checked)
                {
                    if (cmbSearchBy.SelectedIndex == -1)
                    {
                        cmbSearchBy.Focus();
                        objEP.SetError(cmbSearchBy, "Select Search By");
                        FlagReturn = true;
                    }
                    else if (cmbSearch.SelectedIndex == -1)
                    {
                        cmbSearch.Focus();
                        objEP.SetError(cmbSearch, "Select Search");
                        FlagReturn = true;
                    }
                    else
                        FlagReturn = false;
                }
            }
            return FlagReturn;
        }

        string PSColumn = string.Empty, PSInnerJoinClause = string.Empty, PSInvoice = string.Empty, PSSC = string.Empty, PSSCHead = string.Empty, MainQuery = string.Empty, OrderByClause = string.Empty, UserClause = string.Empty;
        double TotalUpgradeCost = 0;

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
                        dataGridView1.Columns[8].Visible = false;
                        dataGridView1.Columns[10].Visible = false;
                        dataGridView1.Columns[14].Visible = false;
                        dataGridView1.Columns[15].Visible = false;
                        dataGridView1.Columns[16].Visible = false;
                        dataGridView1.Columns[18].Visible = false;
                        dataGridView1.Columns[20].Visible = false;
                         
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
                        btnReport.Visible = true;
                    }
                }
                catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
                finally { GC.Collect(); }
            }
        }
    }
}
