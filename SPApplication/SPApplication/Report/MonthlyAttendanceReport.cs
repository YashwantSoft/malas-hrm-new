
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
    public partial class MonthlyAttendanceReport : Form
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

        public MonthlyAttendanceReport()
        {
            InitializeComponent();
            objDL.Set_Report_Design(this, lblHeader, btnView, btnReport, btnClear, btnExit, BusinessResources.LBL_MONTHLY_ATTENDANCE_REPORT);
            objQL.Fill_Master_ComboBox(cmbMonth, "monthmaster");
            cmbYear.Text = Convert.ToString(DateTime.Now.Year);
            cmbMonth.Text = Convert.ToString(objRL.GetMonthName(DateTime.Now.Month));
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            
        }

        private void btnView_Click(object sender, EventArgs e)
        {
          //  GetReport();

            GetNewReport();
        }

        private void GetNewReport()
        {
            if (cmbMonth.SelectedIndex > -1 && cmbYear.SelectedIndex > -1)
            {
                MNumber = objRL.GetMonthNumber(Convert.ToString(cmbMonth.Text));
                YearC = Convert.ToInt32(cmbYear.Text);
                Dt = 01;

                string SetDate = YearC + "/" + MNumber + "/" + Dt.ToString();
                DataSet ds = new DataSet();
                objPC.AttendanceDate = Convert.ToDateTime(SetDate);

                objPC.AYear = Convert.ToInt32(cmbYear.Text);
                objPC.AMonth = MNumber;

                ds = objQL.SP_AttendanceMonthlyData_MonthlyReport();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.DataSource = ds.Tables[0];



                    int RIN = 0;
                    DateTime dt;

                    //for (int i = 6; i < dataGridView1.Columns.Count; i++)
                    //{
                    //    if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[RIN].Cells[i].Value)))
                    //    {
                    //        dt = Convert.ToDateTime(dataGridView1.Rows[RIN].Cells[i].Value.ToString());
                    //        dataGridView1.Rows[RIN].Cells[i].Value = dt.ToString("HH:mm");
                    //    }
                    //    if (i>6 && i % 2 == 0)
                    //    {
                    //        i += 2;
                         
                    //    }
                    //    if(i ==196)
                    //        RIN++;
                    //}

                    //for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    //{
                    //    //DateTime dt = Convert.ToDateTime(dataGridView1.Rows[i].Cells[96].Value.ToString());

                    //    //dataGridView1.Rows[i].Cells[96].Value = dt.ToString("HH:mm");
                    //}
                }
            }
        }


        private void ClearAll()
        {
            dataGridView1.DataSource = null;
            cmbYear.SelectedIndex = -1;
            cmbMonth.SelectedIndex = -1;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void AttendanceReport_Load(object sender, EventArgs e)
        {

        }

        int MNumber = 0;
        int YearC = 0;
        int Dt = 0;

        private void GetReport()
        {
            if (cmbMonth.SelectedIndex > -1 && cmbYear.SelectedIndex > -1)
            {
                MNumber = objRL.GetMonthNumber(Convert.ToString(cmbMonth.Text));
                YearC = Convert.ToInt32(cmbYear.Text);
                Dt = 01;

                string SetDate = YearC + "/" + MNumber + "/" + Dt.ToString();
                DataSet ds = new DataSet();
                objPC.AttendanceDate = Convert.ToDateTime(SetDate);
                ds = objQL.SP_MonthlyAttendanceReport();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
        }
    }
}
