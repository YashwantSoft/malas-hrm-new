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
    public partial class FinancialYearMaster : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        ErrorProvider objEP = new ErrorProvider();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        bool FlagDelete = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableID = 0, Result = 0;
        bool SearchTag = false;

        public FinancialYearMaster()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, "Financial Year Master");
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            FlagDelete = true;
            SaveDB();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FlagDelete = false;
            SaveDB();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        int IsPrimary = 0;
        string FinancialYear = string.Empty;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                RowCount_Grid = dataGridView1.Rows.Count;
                CurrentRowIndex = dataGridView1.CurrentRow.Index;

                if (RowCount_Grid >= 0 && CurrentRowIndex >= 0)
                {
                    ClearAll();
                    //0 ID,
                    //1 FromDate as [From Date],
                    //2 ToDate as [To Date],
                    //3 PrimaryFlag as [Primary]
                    //4 FinancialYear as [Financial Year]

                    btnDelete.Enabled = true;
                    TableID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                    dtpFromDate.Value =Convert.ToDateTime(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value)));
                    dtpToDate.Value = Convert.ToDateTime(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value)));
                    IsPrimary = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value)));
                    txtFinancialYear.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value));

                    if (IsPrimary == 1)
                        cbIsPrimary.Checked = true;
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
        private void ClearAll()
        {
            IsPrimary = 0;
            TableID = 0;
            objEP.Clear();
            dtpFromDate.Value = DateTime.Now.Date;
            dtpToDate.Value = DateTime.Now.Date;
            cbIsPrimary.Checked = false;
        }
        protected bool Validation()
        {
            objEP.Clear();

            if (dtpFromDate.Value.Date > dtpToDate.Value.Date)
            {
                dtpToDate.Focus();
                objEP.SetError(dtpToDate, "Enter Valid Date");
                return true;
            }
            else
                return false;
        }
        protected bool CheckExist()
        {
            DataSet ds = new DataSet();
            objBL.Query = "select FinancialYearId from FinancialYearMaster where CancelTag=0 and FromDate='" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and ToDate='" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and FinancialYearId !=" + TableID + "";
            //objBL.Query = "select ID from BidderMaster where CancelTag=0 and BidderName='" + txtBidderName.Text + "' and MobileNo='" + txtMobileNo.Text + "' and  ID <> " + TableID + "";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }
        protected void FillGrid()
        {
            dataGridView1.DataSource = null;
            DataSet ds = new DataSet();
            objBL.Query = "select FinancialYearId,FromDate as 'From Date',ToDate as 'To Date',PrimaryFlag as 'Primary',FinancialYear as 'Financial Year' from FinancialYearMaster where CancelTag=0";
           
            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
            {
                //0 ID,
                //1 FromDate as [From Date],
                //2 ToDate as [To Date],
                //3 PrimaryFlag as [Primary]
                //4 FinancialYear as [Financial Year]

                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[1].Width = 120;
                dataGridView1.Columns[2].Width = 120;
                dataGridView1.Columns[4].Width = 300;
                lblTotalCount.Text = "Total Count: " + ds.Tables[0].Rows.Count;
            }
        }
        private void Get_Financial_Year()
        {
            txtFinancialYear.Text = "";
            FinancialYear = dtpFromDate.Value.ToString(BusinessResources.DATEFORMATDDMMMYYYY) + " - " + dtpToDate.Value.ToString(BusinessResources.DATEFORMATDDMMMYYYY);
            txtFinancialYear.Text = FinancialYear.ToString();
        }
        protected void SaveDB()
        {
            if (!Validation())
            {
                Get_Financial_Year();

                if (cbIsPrimary.Checked)
                    IsPrimary = 1;

                Result = 0;
                if (!FlagDelete)
                {
                    if (CheckExist())
                    {
                        objRL.ShowMessage(12, 9);
                        return;
                    }
                }

                if (TableID != 0)
                    if (FlagDelete)
                        objBL.Query = "update FinancialYearMaster set CancelTag=1 where ID=" + TableID + "";
                    else
                        objBL.Query = "update FinancialYearMaster set FromDate='" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "',ToDate='" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "',PrimaryFlag=" + IsPrimary + ",FinancialYear='" + FinancialYear + "',UserId=" + BusinessLayer.LoginId_Static + " where FinancialYearId=" + TableID + "";
                else
                    objBL.Query = "insert into FinancialYearMaster(FromDate,ToDate,PrimaryFlag,FinancialYear,UserId) values('" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "','" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'," + IsPrimary + ",'" + FinancialYear + "'," + BusinessLayer.LoginId_Static + ")";

                Result = objBL.Function_ExecuteNonQuery();
                if (Result > 0)
                {
                    if (FlagDelete)
                        objRL.ShowMessage(9, 1);
                    else
                        objRL.ShowMessage(7, 1);

                    ClearAll();
                    FillGrid();
                }
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }
        private void FinancialYearMaster_Load(object sender, EventArgs e)
        {
            ClearAll();
            FillGrid();
        }
        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            Get_Financial_Year();
        }
    }
}
