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
    public partial class ReportDataView : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        ErrorProvider objEP = new ErrorProvider();
        RedundancyLogics objRL = new RedundancyLogics(); DesignLayer objDL = new DesignLayer();
        QueryLayer objQL = new QueryLayer();


        public ReportDataView()
        {
            InitializeComponent();
        }

        private void ReportDataView_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            ds = objQL.SP_ReportData_ViewAll();

            if (ds.Tables[0].Rows.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
        }
    }
}
