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

namespace SPApplication.Report
{
    public partial class LocationDepartmentWiseUsersReport : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();

        PropertyClass objPC = new PropertyClass();
        AttendanceLogics objAL = new AttendanceLogics();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0, LocationId = 0;

        int SrNo = 1;
        string MainQuery = string.Empty;
        string WhereClause = string.Empty;
        DateTime dtInTime, dtOutTime;

        private void LocationDepartmentWiseUsersReport_Load(object sender, EventArgs e)
        {

        }

        TimeSpan TOT;
        public LocationDepartmentWiseUsersReport()
        {
            InitializeComponent();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void btnReport_Click(object sender, EventArgs e)
        {

        }
        private void ClearAll()
        {
            cbSelectAllLocation.Checked = true;
            cbSelectAllDepartment.Checked = true;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
    }
}
