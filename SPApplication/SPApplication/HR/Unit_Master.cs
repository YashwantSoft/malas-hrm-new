using BusinessLayerUtility;
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
    public partial class Unit_Master : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        public Unit_Master()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_UNITMASTER);
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
            txtUnitId.Text = "";
            txtUnitName.Text = "";
            txtContactPerson.Text = "";
            txtExtensionNo.Text = "";
            txtMobileNumber.Text = "";
            txtDiscription.Text = "";
            txtSearch.Text = "";
        }

      
        private void btnSave_Click(object sender, EventArgs e)
        {
            string R = string.Empty;
            
            txtContactPerson.Text = R;
        }
    }
}
