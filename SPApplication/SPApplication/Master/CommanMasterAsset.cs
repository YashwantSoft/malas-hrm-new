using BusinessLayerUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPApplication.Master
{
    public partial class CommanMasterAsset : Form
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
        string TableName_Form = string.Empty;

        public CommanMasterAsset()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_ASSETCOMMANMASTER);
            objRL.CommanAssetMaster(cmbMasterType, "MasterType");
            TableName_Form = objPC.CommanMasterTable;
            cmbMasterType.Text = TableName_Form.ToString();
            //cmbMasterType.Enabled = false;
        }

        public CommanMasterAsset(string MasterType)
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, MasterType);
            objRL.CommanAssetMaster(cmbMasterType, "MasterType");
            TableName_Form = MasterType;
            cmbMasterType.Text = TableName_Form.ToString();
            cmbMasterType.Enabled = false;
            SetColumn();
        }
        
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ClearAll()
        {
            TableId = 0;
            DeleteFlag = false;
            objEP.Clear();
            //cmbMasterType.SelectedIndex = -1;
            txtColumnValue.Text = "";
            lblColumnName.Text = "";
            txtColumnValue.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteFlag = false;
                SaveDB();
            }
            catch (Exception ex1) { MessageBox.Show(ex1.ToString()); }
            finally { GC.Collect(); }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteFlag = true;
                SaveDB();
            }
            catch (Exception ex1) { MessageBox.Show(ex1.ToString()); }
            finally { GC.Collect(); }
        }

        private void CommanMaster_Load(object sender, EventArgs e)
        {
            ClearAll();
            //FillGrid();
        }

        //BusinessUnitMaster
        //OSMaster
        //

        string ColumnValue = string.Empty;

        private void SaveDB()
        {
            try
            {
                if (!Validation())
                {
                    ColumnValue = txtColumnValue.Text;

                    if (TableId != 0)
                    {
                        if (DeleteFlag)
                        {
                            objBL.Query = "update "+TableName+" set CancelTag=1 where ID=" + TableId + "";
                            ExecuteType = "Delete";
                        }
                        else
                        {
                            objBL.Query = "update " + TableName + " set "+ColumnName+"='" + ColumnValue.Replace("'", "''") + "' where ID=" + TableId + " and CancelTag=0";
                            ExecuteType = "Update";
                        }
                    }
                    else
                    {
                        objBL.Query = "insert into " + TableName + "(" + ColumnName + ") values('" + ColumnValue.Replace("'", "''") + "')";
                        ExecuteType = "Save";
                    }

                    int Result = objBL.Function_ExecuteNonQuery();
                    if (Result > 0)
                    {
                        if (ExecuteType == "Save")
                            objRL.ShowMessage(7, 1);
                        else if (ExecuteType == "Update")
                            objRL.ShowMessage(8, 1);
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
            catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
            finally { GC.Collect(); }
        }

        private bool Validation()
        {
            objEP.Clear();
            if (cmbMasterType.Text == "")
            {
                objEP.SetError(cmbMasterType, "Select Master Type");
                cmbMasterType.Focus();
                return true;
            }
            else if (txtColumnValue.Text == "")
            {
                objEP.SetError(txtColumnValue, "Enter Column Value");
                cmbMasterType.Focus();
                return true;
            }
            else
                return false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //ClearAll();
                TableId = 0;
                txtColumnValue.Text = "";
                btnDelete.Enabled = true;
                TableId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtColumnValue.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
            finally { GC.Collect(); }
        }

        string WhereClause = string.Empty, MainQuery = string.Empty, OrderByClause = string.Empty;

        private void FillGrid()
        {
            if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR || BusinessLayer.Designation == "IT HEAD" || BusinessLayer.Department == "INFORMATION TECHNOLOGY")
            {
                dataGridView1.DataSource = null;

                DataSet ds = new DataSet();

                try
                {
                    if (SearchFlag)
                        WhereClause = " and "+ColumnName+" like '%" + txtSearch.Text + "%'";

                    if (string.IsNullOrEmpty(WhereClause))
                        WhereClause = string.Empty;

                    if(TableName =="commanassetmaster")
                        ColumnName1 = "CommanAssetMasterId";

                    MainQuery = "select " + ColumnName1 + "," + ColumnName + " from " + TableName + " where " + ColumnName + " NOT in('') and CancelTag=0 order by " + ColumnName + " asc";
                    OrderByClause = ""; // " order by ID asc";

                    objBL.Query = MainQuery + WhereClause + OrderByClause;
                    ds = objBL.ReturnDataSet();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //0 VM.ID as [Vendor Code],
                        //1 VM.ColumnName

                        lblTotalCount.Text = "Total Count-" + ds.Tables[0].Rows.Count;
                        dataGridView1.DataSource = ds.Tables[0];
                        
                        dataGridView1.Columns[0].Width = 150;
                        dataGridView1.Columns[1].Width = 700;
                    }
                }
                catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
                finally { GC.Collect(); }
            }
        }

        bool SearchFlag = false;

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
                SearchFlag = true;
            else
                SearchFlag = false;

            FillGrid();
        }

        string TableName = string.Empty, ColumnName = string.Empty, ColumnName1=string.Empty;

        private void SetColumn()
        {
            //TN_AssetType	    Asset Type	
            //TN_BusinessUnit	Business Unit	
            //TN_Department	    Department	
            //TN_Designation	Designation	
            //TN_HDDSSDSize	    HDDSSDSize	
            //TN_HDDSSDType	    HDDSSDType	
            //TN_Make	        Make	
            //TN_Model	        Model	
            //TN_OfficeVersion	Office Version	
            //TN_OSBit	        OS Bit	
            //TN_OSName	        OS Name	
            //TN_Processor	    Processor	
            //TN_RAM	        RAM	
            //TN_Screen	        Screen	
            //TN_Software	    Software	
            //TN_Upgrade	    Upgrade	
            

            TableName = string.Empty; 
            ColumnName = string.Empty;

            if (cmbMasterType.SelectedIndex > -1)
            {
                TableName_Form = cmbMasterType.Text;

                if (TableName_Form == BusinessResources.TN_AssetType)
                {
                    TableName = "assettypemaster";
                    ColumnName = "AssetType";
                    ColumnName1 = "AssetTypeId";
                }
                else if (TableName_Form == BusinessResources.TN_BusinessUnit)
                {
                    TableName = "locationmaster";
                    ColumnName = "LocationName";
                    ColumnName1 = "LocationId";
                }
                else if (TableName_Form == BusinessResources.TN_Department)
                {
                    TableName = "DepartmentMaster";
                    ColumnName = "Department";
                    ColumnName1 = "DepartmentId";
                }
                else if (TableName_Form == BusinessResources.TN_Designation)
                {
                    TableName = "designationmaster";
                    ColumnName = "Department";
                    ColumnName1 = "DesignationId";
                }
                else if (TableName_Form == BusinessResources.TN_Make)
                {
                    TableName = "makemaster";
                    ColumnName = "MakeName";
                    ColumnName1 = "MakeId";
                }
                else if (TableName_Form == BusinessResources.TN_OSName)
                {
                    TableName = "osmaster";
                    ColumnName = "OSName";
                    ColumnName1 = "OSMasterId";
                }
                else if (TableName_Form == BusinessResources.TN_HDDSSDSize)
                {
                    TableName = "commanassetmaster";
                    ColumnName = "HDDSSDSize";
                }
                else if (TableName_Form == BusinessResources.TN_HDDSSDType)
                {
                    TableName = "commanassetmaster";
                    ColumnName = "HDDSSDType";
                }
              
                else if (TableName_Form == BusinessResources.TN_Model)
                {
                    TableName = "commanassetmaster";
                    ColumnName = "Model";
                }
                else if (TableName_Form == BusinessResources.TN_OfficeVersion)
                {
                    TableName = "commanassetmaster";
                    ColumnName = "OfficeVersion";
                }
                else if (TableName_Form == BusinessResources.TN_OSBit)
                {
                    TableName = "commanassetmaster";
                    ColumnName = "OSType";
                }
                else if (TableName_Form == BusinessResources.TN_Processor)
                {
                    TableName = "commanassetmaster";
                    ColumnName = "Processor";
                }
                else if (TableName_Form == BusinessResources.TN_RAM)
                {
                    TableName = "commanassetmaster";
                    ColumnName = "RAM";
                }
                else if (TableName_Form == BusinessResources.TN_Screen)
                {
                    TableName = "commanassetmaster";
                    ColumnName = "Screen";
                }
                else if (TableName_Form == BusinessResources.TN_Software)
                {
                    TableName = "commanassetmaster";
                    ColumnName = "Softwares";
                }
                else if (TableName_Form == BusinessResources.TN_Upgrade)
                {
                    TableName = "commanassetmaster";
                    ColumnName = "Upgrade";
                }
                else
                {
                    TableName = string.Empty;
                    ColumnName = string.Empty;
                }
                FillGrid();
            }
        }

        private void cmbMasterType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbMasterType.SelectedIndex > -1)
            {
                SetColumn();
            }
        }
    }
}
