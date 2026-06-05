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
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;

namespace SPApplication.Authentication
{
    public partial class ESSLData : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics(); 
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        ESSLDataUtility objEDU = new ESSLDataUtility();
        string DataType = string.Empty, Database = string.Empty;

        public ESSLData()
        {
            InitializeComponent();
            objDL.SetDesign3Buttons(this, lblHeader, btnSave, btnClear, btnExit, BusinessResources.LBL_HEADER_ESSLRECORDS);
            btnSave.Text = BusinessResources.BTN_ESSL;
        }

        private void ESSLRecords_Load(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            GetReport();
        }
        
        private void GetReport()
        {
            if (cmbDatabase.SelectedIndex > -1 && cmbDataType.SelectedIndex > -1)
            {
                try
                {
                    Database = cmbDatabase.Text;
                    DataType = cmbDataType.Text;
                    using (new SPApplication.OPD.Appointment.CursorWait())
                    {
                        DataSet ds = new DataSet();
                        if (cmbDatabase.SelectedIndex > -1)
                        {
                            objEDU.Get_ESSL_Data_Existing_Database(Database, DataType,dataGridView1);
                        }
                    }
                }
                catch (Exception ex1)
                {

                }
            }
        }

        private void ClearAll()
        {
            DataType = string.Empty;
            Database = string.Empty;
            dtpDate.Value = DateTime.Now;
            cmbDatabase.SelectedIndex = -1;
            cmbDataType.SelectedIndex = -1;
            cmbDatabase.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
    }
}
