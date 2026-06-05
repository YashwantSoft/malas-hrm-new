using BusinessLayerUtility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace voucher
{
    public partial class EmployeeEarnings : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0;

        string MainQuery = string.Empty, OrderClause = string.Empty, WhereClause = string.Empty;
        public EmployeeEarnings()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, "Earnings");
        }

        private void ClearAll()
        {
            objEP.Clear();
            TableId = 0;
            GridFlag = false;
            txtEmployeeName.Text = "";
            lbEmployee.DataSource = null;

            dtpDate.Value = DateTime.Now.Date;
            txtEmployeeName.Clear();
            txtAmount.Clear();
            txtNarration.Clear();
            cmbEarningsFor.SelectedIndex = -1;
            txtEmployeeName.Focus();
            lbEmployee.Visible = false;
            objRL.Fill_Employee_ListBox(lbEmployee, txtEmployeeName.Text, "All");
            txtEmployeeName.Focus();
        }

        private bool Validation()
        {
            objEP.Clear();
            if (EmployeeId == 0)
            {
                txtEmployeeName.Focus();
                objEP.SetError(txtEmployeeName, "Select Employee Name");
                objEP.SetError(lbEmployee, "Select Employee Name");
                return true;
            }
            else if (cmbEarningsFor.SelectedIndex == -1)
            {
                txtAmount.Focus();
                objEP.SetError(cmbEarningsFor, " Select Deduction For");
                return true;
            }
            else if (txtAmount.Text == "")
            {
                txtAmount.Focus();
                objEP.SetError(txtAmount, " Enter Amount");
                return true;
            }
            else if (txtNarration.Text == "")
            {
                txtNarration.Focus();
                objEP.SetError(txtNarration, " Enter Narration");
                return true;
            }
            else
                return false;
        }
        protected bool CheckExist()
        {
            if (TableId == 0)
            {
                DataSet ds = new DataSet();
                objBL.Query = "select EarningsId from Earnings where CancelTag=0 and EmployeeId=" + EmployeeId + " and EarningsDate='" + dtpDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD)+ "' and EarningsFor='" + cmbEarningsFor.Text+"' "; 
                ds = objBL.ReturnDataSet();

                if (ds.Tables[0].Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        protected void SaveDB()
        {
            if (!Validation())
            {
                if (CheckExist())
                {
                    objRL.ShowMessage(12, 4);
                    return;
                }

                if (TableId != 0)
                {
                    if (!FlagDelete)
                        objBL.Query = "update Earnings set EmployeeId=" + EmployeeId + ",EarningsDate='" + dtpDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "',EarningsFor='" + cmbEarningsFor.Text + "',Amount='"+txtAmount.Text+"',Narration='" + txtNarration.Text + "',FinancialYearId="+objPC.FinancialYearId+",ModifiedUserId=" + BusinessLayer.LoginId_Static + " where DeductionId=" + TableId + "";
                    else
                        objBL.Query = "update Earnings set CancelTag=1 where EarningsId=" + TableId + " ";
                }
                else
                    objBL.Query = "insert into Earnings(EmployeeId,EarningsDate,EarningsFor,Amount,Narration,FinancialYearId,UserId) values(" + EmployeeId + ",'" + dtpDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "','" + cmbEarningsFor.Text + "','"+txtAmount.Text+"','" + txtNarration.Text + "',"+objPC.FinancialYearId+"," + BusinessLayer.LoginId_Static + ")";

                Result = objBL.Function_ExecuteNonQuery();

                if (Result > 0)
                {
                    if (!FlagDelete)
                        objRL.ShowMessage(7, 1);
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

        protected void FillGrid()
        {
            MainQuery = string.Empty;  WhereClause = string.Empty; OrderClause = string.Empty;
            lblTotalCount.Text = "";
            dataGridView1.DataSource = null;
            DataSet ds = new DataSet();
            objPC.JobProfile = txtSearch.Text;

            if (!SearchFlag)
                objPC.SearchFlag = false;
            else
                objPC.SearchFlag = true;

            MainQuery = "select D.EarningsId,D.EmployeeId,CONCAT(E.EmployeeName,'- Code-',E.EmployeeCode) as 'EmployeeName-Code',D.EarningsDate as 'Date',D.EarningsFor as 'Earnings For',D.Amount,D.Narration from Earnings D inner join employees E on E.EmployeeId=D.EmployeeId where D.CancelTag=0 and E.CancelTag=0 and D.FinancialYearId=" + objPC.FinancialYearId+" ";

            if (SearchFlag && txtSearch.Text != "")
                WhereClause = " and E.EmployeeName LIKE '%" + txtSearch.Text + "%'";

            OrderClause = " order by D.EarningsDate desc ";

            objBL.Query = MainQuery + WhereClause + OrderClause;

            ds = objBL.ReturnDataSet();
             
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTotalCount.Text = "Total-" + ds.Tables[0].Rows.Count;

                //0 D.DeductionId,
                //1 D.EmployeeId,
                //2 CONCAT(E.EmployeeName,'- Code-',E.EmployeeCode) as 'EmployeeName-Code'
                //3 D.DeductionDate as 'Date',
                //4 D.DeductionFor as 'Deduction For',
                //5 D.Amount
                //6 D.Narration

                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                
                dataGridView1.Columns[2].Width = 400;
                dataGridView1.Columns[3].Width = 150;
                dataGridView1.Columns[4].Width = 150;
                dataGridView1.Columns[5].Width = 150;
                dataGridView1.Columns[6].Width = 200;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FlagDelete = false;
            SaveDB();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
           DialogResult dr= objRL.Delete_Record_Show_Message();
           if (dr == DialogResult.Yes)
           {
                FlagDelete = true;
                SaveDB();
           }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
         
        private void lbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {

            //if (lbEmployee.SelectedValue != null)
            //{
            //    int employeeId = Convert.ToInt32(lbEmployee.SelectedValue);
            //    MessageBox.Show("Selected Employee ID: " + employeeId);
            //}
            //else
            //    return;

            //if (lbEmployee.SelectedItem == null)
            //    return;

            //string employeeName = lbEmployee.SelectedItem.ToString();
            //txtEmployeeName.Text = employeeName;

            //int selectedEmployeeId = (int)lbEmployee.SelectedValue;
            //string selectedEmployeeName = lbEmployee.Text;

            //lbEmployee.Visible = false;   // hide after select

            //richTextBox1.Clear();

            //using (MySqlConnection con = objBL.ReturnConnection())
            //{
            //    con.Open();
            //    string query = @"SELECT EmployeeId, EmployeeCode, EmployeeName, DOB 
            //             FROM employees
            //             WHERE EmployeeId = @EmployeeId
            //             ORDER BY EmployeeName asc, EmployeeCode asc";

            //    using (MySqlCommand cmd = new MySqlCommand(query, con))
            //    {
            //        //cmd.Parameters.AddWithValue("@EmployeeCode", employeeName);
            //        cmd.Parameters.AddWithValue("@EmployeeId", selectedEmployeeId);

            //        using (MySqlDataReader dr = cmd.ExecuteReader())
            //        {
            //            while (dr.Read())
            //            {
            //                richTextBox1.AppendText(
            //                    "Employee Name : " + employeeName + "\n" +
            //                    "Date          : " + Convert.ToDateTime(dr["received_date"]).ToShortDateString() + "\n" +
            //                    "Time          : " + dr["received_time"].ToString() + "\n" +
            //                    "Received Type : " + dr["received_type"].ToString() + "\n" +
            //                    "Amount        : " + dr["amount"].ToString() + "\n" +
            //                    "Narration     : " + dr["narration"].ToString() + "\n" +
            //                    "--------------------------------------\n"
            //                );
            //            }
            //        }
            //    }
            //}
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            ClearAll();
            FillGrid();
        }

        private void lbEmployee_Click(object sender, EventArgs e)
        {
            GetEmployeeDetails();
        }

        private void lbEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                GetEmployeeDetails();
            }
        }
        private void LoadEmployeeTransactions()
        {
            using (MySqlConnection con = objBL.ReturnConnection())
            {
                con.Open();
                string query = @"SELECT EmployeeId, EmployeeCode, EmployeeName 
                         FROM employees
                         ORDER BY EmployeeName asc";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                    // Hide the id column (internal use only)
                    if (dataGridView1.Columns["id"] != null)
                        dataGridView1.Columns["id"].Visible = true;

                    // Adjust column headers
                    dataGridView1.Columns["employee_name"].HeaderText = "Employee Name";
                    dataGridView1.Columns["received_date"].HeaderText = "Date";
                    dataGridView1.Columns["received_time"].HeaderText = "Time";
                    dataGridView1.Columns["received_type"].HeaderText = "Received Type";
                    dataGridView1.Columns["amount"].HeaderText = "Amount";
                    dataGridView1.Columns["narration"].HeaderText = "Narration";

                    // Add row numbers
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
                    }
                    dataGridView1.AutoResizeRowHeadersWidth(
                        DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
                    );

                    // Optional: make grid read-only to prevent editing directly
                    dataGridView1.ReadOnly = true;
                }
            }
        }
        
        private void LoadEmployeeNames()
        {
            lbEmployee.Items.Clear();

            using (MySqlConnection con = objBL.ReturnConnection())
            {
                con.Open();
                string query = @"SELECT DISTINCT EmployeeName,EmployeeId 
                         FROM employees 
                         ORDER BY EmployeeName asc";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //lbEmployee.Items.Add(dr["EmployeeName"].ToString());
                        lbEmployee.Items.Add($"{dr["EmployeeId"]}|{dr["EmployeeName"]}");

                        //lbEmployee.Items.Add(new Employee
                        //{
                        //    EmployeeId = Convert.ToInt32(dr["EmployeeId"]),
                        //    EmployeeName = dr["EmployeeName"].ToString()
                        //});
                    }

                    lbEmployee.DisplayMember = "EmployeeName"; // what user sees
                    lbEmployee.ValueMember = "EmployeeId";
                }
            }

            
        }
        

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (objPC.ViewFlag == 1)
            {
                try
                {
                    RowCount_Grid = dataGridView1.Rows.Count;
                    CurrentRowIndex = dataGridView1.CurrentRow.Index;

                    if (RowCount_Grid >= 0 && CurrentRowIndex >= 0)
                    {
                        ClearAll();

                        //0 D.DeductionId,
                        //1 D.EmployeeId,
                        //2 CONCAT(E.EmployeeName,'- Code-',E.EmployeeCode) as 'EmployeeName-Code'
                        //3 D.DeductionDate as 'Date',
                        //4 D.DeductionFor as 'Deduction For',
                        //5 D.Amount
                        //6 D.Narration

                        btnDelete.Enabled = true;
                        GridFlag = true;
                        TableId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value)));
                        EmployeeId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value)));
                        lbEmployee.Visible = false;
                        GetEmployeeDetails();
                        dtpDate.Value = Convert.ToDateTime(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value));
                        cmbEarningsFor.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value));
                        txtAmount.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[5].Value));
                        txtNarration.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[6].Value));
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
            else
            {
                objRL.ShowMessage(24, 4);
                return;
            }
        }

        private void txtEmployeeName_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtEmployeeName.Text != "" && lbEmployee.Items.Count > 0)
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                {
                    lbEmployee.SelectedIndex = 0;
                    lbEmployee.Focus();
                }
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtAmount);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
                SearchFlag = true;
            else
                SearchFlag = false;

            FillGrid();
        }

        private void cmbDeductionFor_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode ==Keys.Enter)
                txtAmount.Focus();
        }

        private void dtpDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbEarningsFor.Focus();
        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtNarration.Focus();
        }

        private void txtNarration_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSave.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int EmployeeId = 0; bool GridFlag = false;
        private void GetEmployeeDetails()
        {
            rtbEmployee.Text = "";
            if (EmployeeId == 0)
            {
                if (lbEmployee.SelectedIndex > -1)
                {
                    EmployeeId = 0;
                    
                    EmployeeId = Convert.ToInt32(lbEmployee.SelectedValue);
                    objRL.Fill_Employee_Details_RichTextBox(rtbEmployee, EmployeeId);
                    lbEmployee.Visible = false;
                    dtpDate.Focus();
                }
            }
            else if(GridFlag && EmployeeId!=0)
                objRL.Fill_Employee_Details_RichTextBox(rtbEmployee, EmployeeId);
            else
            {
                rtbEmployee.Text = "";
                rtbEmployee.Visible = true;
                lbEmployee.Visible = true;
            }

        }
         

        private void txtEmployeeName_TextChanged(object sender, EventArgs e)
        {
            if(!GridFlag)
            {
                EmployeeId = 0;
                rtbEmployee.Text = "";
            }
                
            if (!string.IsNullOrWhiteSpace(Convert.ToString(txtEmployeeName.Text)))
                objRL.Fill_Employee_ListBox(lbEmployee, txtEmployeeName.Text, "Text");
            else
                objRL.Fill_Employee_ListBox(lbEmployee, txtEmployeeName.Text, "All");

            //string search = txtEmployeeName.Text.Trim().ToLower();

            //if (string.IsNullOrWhiteSpace(search))
            //{
            //    lbEmployee.Visible = true;
            //    return;
            //}

            //lbEmployee.Items.Clear();

            //using (MySqlConnection con = objBL.ReturnConnection())
            //{
            //    con.Open();
            //    string query = @"SELECT DISTINCT EmployeeName,EmployeeId
            //             FROM employees
            //             WHERE EmployeeName LIKE @EmployeeName
            //             ORDER BY EmployeeName asc";

            //    using (MySqlCommand cmd = new MySqlCommand(query, con))
            //    {
            //        cmd.Parameters.AddWithValue("@EmployeeName", search + "%");

            //        using (MySqlDataReader dr = cmd.ExecuteReader())
            //        {
            //            while (dr.Read())
            //            {
            //                lbEmployee.Items.Add(dr["EmployeeName"].ToString());
            //            }
            //        }
            //    }
            //}

            //lbEmployee.Visible = lbEmployee.Items.Count > 0;
        }

    }
}








