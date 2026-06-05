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
    public partial class Leave_Approval : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        public Leave_Approval()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_LEAVEAPPROVALMASTER);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            objEP.Clear();
            txtUnitId.Text = "";
            txtUnitNumber.Text = "";
            txtEmployeName.Text = "";
            txtLeaveID.Text = "";
            txtLeave.Text = "";
            txtReason.Text = "";
            txtApprovalTo.Text = "";
            txtApprovalStatus.Text = "";
            txtSearch.Text = "";
            
        }
    }
}
