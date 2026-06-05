using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLayerUtility;
using SPApplication;
using SPApplication.Authentication;
using System.IO;
using SPApplication.ListForms;
using System.Data.OleDb;

namespace SPApplication
{
    public partial class MenuSettings : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        ErrorProvider objEP = new ErrorProvider();
        RedundancyLogics objRL = new RedundancyLogics(); DesignLayer objDL = new DesignLayer();
        ToolTip objTT = new ToolTip();

        public MenuSettings()
        {
            InitializeComponent();
            objDL.Set_List_Design(lblHeader, btnExit, lbReportList, BusinessResources.LBL_HEADER_SETTINGSLIST);
        }

        //private const int CS_DropShadow = 0x00020000;
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ClassStyle |= CS_DropShadow;
        //        return cp;
        //    }
        //}

      

        private void lbReportList_Click(object sender, EventArgs e)
        {
            Select_Report();
        }

        private void lbReportList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Select_Report();
        }

        private void Select_Report()
        {
            if (lbReportList.Items.Count > 0)
            {
                if (lbReportList.Text == "Change Password")
                {
                    ChangePassword objForm = new ChangePassword();
                    objForm.ShowDialog(this);
                }
                else if (lbReportList.Text == "Backup")
                {
                    //DBBackup();
                    DataBackup objForm = new DataBackup();
                    objForm.ShowDialog(this);
                }
                else if (lbReportList.Text == "Existing Database Backup")
                {
                    //DBBackup();
                    DatabaseMigration();
                }
                else
                    MessageBox.Show("Enter Valid selection");
            }
        }

        string case_no_A = string.Empty;
        DateTime case_dt_A;
        string treatment_A = string.Empty;
        string prev_bal_A = string.Empty;
        string fees_A = string.Empty;
        string paid_A = string.Empty;
        string balance = string.Empty;
        string doctor_id_A = string.Empty;
        string del_status_A = string.Empty;
        string Patient_id_A = string.Empty;
        string Medicine_id_A = string.Empty;


        private void DatabaseMigration()
        {
            string AccessConString = string.Empty;
            AccessConString = @"D:\STL\bitbucket_laxmi_clinic\LaxmiClinic_Latest6.5.18\Doctor.mdb";
            OleDbConnection objAccessCon = new OleDbConnection(AccessConString);
            objAccessCon.Open();

            OleDbCommand cmd=new OleDbCommand("select * from case_details",objAccessCon);
            OleDbDataAdapter objDA = new OleDbDataAdapter(cmd);

            DataSet ds = new DataSet();
            objDA.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if(!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i][""])))
                        case_no_A = string.Empty;


                    DateTime case_dt_A;
                    string treatment_A = string.Empty;
                    string prev_bal_A = string.Empty;
                    string fees_A = string.Empty;
                    string paid_A = string.Empty;
                    string balance = string.Empty;
                    string doctor_id_A = string.Empty;
                    string del_status_A = string.Empty;
                    string Patient_id_A = string.Empty;
                    string Medicine_id_A = string.Empty;
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
       
        protected void DBBackup()
        {
            string DateF = DateTime.Now.Date.ToString("dd-MMM-yyyy");
            string FileName = "ConstructionDB-" + DateF + ".mdb";

            SaveFileDialog sf = new SaveFileDialog();
            // sf.Filter = "Access Database files (*.mdb)";

            sf.Filter = "Access files (*.mdb)|*.mdb|All files (*.*)|*.*";

            // Feed the dummy name to the save dialog
            sf.FileName = FileName;

            if (sf.ShowDialog() == DialogResult.OK)
            {
                string RPath = objBL.conString;
                string savePath = Path.GetDirectoryName(sf.FileName);
                string FilePath = RPath + "ConstructionDB.mdb";

                FileInfo FIDBFile = new FileInfo(FilePath);
                FileName = "" + savePath + "\\" + FileName;

                if (FIDBFile.Exists == true)
                {
                    FileInfo fiNew = new FileInfo(FileName);
                    fiNew.Delete();
                    FIDBFile.CopyTo(FileName);
                }
                else
                    FIDBFile.CopyTo(FileName);

                MessageBox.Show("Database backup successfully");
            }
        }

        private void MenuSettings_Load(object sender, EventArgs e)
        {

        }
    }
}
