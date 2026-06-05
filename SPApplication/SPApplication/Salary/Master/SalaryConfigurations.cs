using BusinessLayerUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPApplication.Salary.Master
{
    public partial class SalaryConfigurations : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0;

        public SalaryConfigurations()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, "SALARY CONFIGURATIONS");
            objRL.Fill_Contractor_IN_Attendance(cmbContractorName);
        }

        private void PFConfigurations_Load(object sender, EventArgs e)
        {
            ClearAll();
            FillGrid();
        }

        private void ClearAll()
        {
            objEP.Clear();
            TableId = 0;
            txtRuleName.Text = "";
            cmbContractorName.SelectedIndex = -1;
            cbIsCash.Checked = false;
            cbIsPT.Checked = false;

            txtBasicPer.Text = "";
            txtHRAPer.Text = "";
            txtEPFPensionPFPerEmployee.Text = "";
            txtEPFPensionPFPerEmployer.Text = "";
            txtPFFixAmount.Text = "";
            txtPFFixAmountLimit.Text = "";

            cbIsEsic.Checked = false;
            txtEsicEmployeeContributions.Text = "";
            txtEsicEmployerContributions.Text = "";
            txtEsicLimit.Text = "";

            cbIsLWF.Checked = false;
            txtLWFEmployeeShare.Text = "";
            txtLWFEmployerShare.Text = "";
            txtLWFLimit.Text = "";

            txtRemarks.Text = "";
            GetID();
            txtRuleName.Focus();
        }

        private void GetID()
        {
           txtHeaderNumber.Text=Convert.ToString(objRL.ReturnMaxID_Increase("SalaryConfigurations", "ContractorId"));
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FlagDelete = true;
            SaveDB();
        }

        private void cbIsEsic_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIsEsic.Checked)
            {
                IsEsic = 1;
                gbEsicConfiguration.Visible = true;
            }
            else
            {
                IsEsic = 0;
                gbEsicConfiguration.Visible = false;
            }
                
        }

        private void cbIsPF_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIsPF.Checked)
            {
                IsPF = 1;
                gbPFCalculations.Visible = true;
                cbEmployer.Visible = true;
            }
            else
            {
                IsPF = 0;
                gbPFCalculations.Visible = false;
                cbEmployer.Visible = false;
            }
                
        }

        private void cbIsLWF_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIsLWF.Checked)
            {
                IsLWF = 1;
                gbLWFConfiguration.Visible = true;
            }
            else
            {
                IsLWF = 0;
                gbLWFConfiguration.Visible = false;
            }
        }

        private void txtBasicDAPer_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtBasicPer);
        }

        private void txtHRAPer_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtHRAPer);
        }

        private void cbIsCash_CheckedChanged(object sender, EventArgs e)
        {
            if(!cbIsCash.Checked)
            {
                IsCash = 1;
                gbStatutoryConfiguration.Visible = true;
            }
            else
            {
                IsCash = 0;
                gbStatutoryConfiguration.Visible = false;
            }
        }

        private void txtEPFPensionPFPerEmployer_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtEPFPensionPFPerEmployer);
        }

        private void txtPFFixAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtPFFixAmount);
        }

        private void txtPFFixAmountLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtPFFixAmountLimit);
        }

        private void txtEsicEmployeeContributions_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtEsicEmployeeContributions);
        }

        private void txtEsicEmployerContributions_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtEsicEmployerContributions);
        }

        private void txtEsicLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtEsicLimit);
        }

        private void txtLWFEmployeeShare_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtLWFEmployeeShare);
        }

        private void txtLWFEmployerShare_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtLWFEmployerShare);
        }

        private void txtLWFLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtLWFLimit);
        }

        string EmpDesignation = string.Empty;
        string EmpDepartment = string.Empty;

        int SearchId = 0, LocationId = 0;

        private void cbIsPT_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIsPT.Checked)
            {
                IsPT = 1;
            }
            else
            {
                IsPT = 0;
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

                        //0 SC.ContractorId,
                        //1 CM.ContractorName,
                        //2 SC.RuleName,
                        //3 SC.IsCash,
                        //4 SC.IsPT,
                        //5 SC.BasicPer,
                        //6 SC.HRAPer,
                        //7 SC.DAPer,
                        //8 SC.TransportAllowancePer,
                        //9 SC.MedicalAllowancesPer,
                        //10 SC.SpecialAllowancePer,
                        //11 SC.EductionAllowancesPer,
                        //12 SC.ConveyanceAllowancesPer,
                        //13 SC.OtherAllowancesPer,
                        //14 SC.IsPF,
                        //15 SC.EPFProvidentFundPerEmployee,
                        //16 SC.EPSPensionSchemePerEmployee,
                        //17 SC.EPFPensionPFPerEmployee,
                        //18 SC.PFFixAmount,
                        //19 SC.PFFixAmountLimit,
                        //20 SC.EPFProvidentFundPerEmployer,
                        //21 SC.EPSPensionSchemePerEmployer,
                        //22 SC.EPFPensionPFPerEmployer,
                        //23 SC.EPFAdministratonCharges,
                        //24 SC.IsEsic,
                        //25 SC.EsicEmployeeContributions,
                        //26 SC.EsicEmployerContributions,
                        //27 SC.EsicLimit,
                        //28 SC.IsLWF,
                        //29 SC.LWFEmployeeShare,
                        //30 SC.LWFEmployerShare,
                        //31 SC.LWFLimit,
                        //32 SC.Commission,
                        //33 SC.Factor,
                        //34 SC.OTRate,
                        //35 SC.Remarks

                        btnDelete.Enabled = true;
                        TableId =  objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value)));
                        cmbContractorName.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value));
                        txtRuleName.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value));
                        IsCash = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value)));
                        IsPT = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value)));

                        if (IsPT == 1)
                            cbIsPT.Checked = true;

                            txtBasicPer.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[5].Value));
                        txtHRAPer.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[6].Value));
                        txtDearnessAllowanceDAPer.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[7].Value));
                        txtTransportAllowancePer.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[8].Value));
                        txtMedicalAllowancesPer.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[9].Value));
                        txtSpecialAllowancePer.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[10].Value));
                        txtEductionAllowancesPer.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[11].Value));
                        txtConveyanceAllowancesPer.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[12].Value));
                        txtOtherAllowancesPer.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[13].Value));

                        IsPF = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[14].Value)));
                        if(IsPF == 1)
                        {
                            gbPFCalculations.Visible = true;
                            cbIsPF.Checked = true;
                            txtEPFProvidentFundPerEmployee.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[15].Value));
                            txtEPSPensionSchemePerEmployee.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[16].Value));
                            txtEPFPensionPFPerEmployee.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[17].Value));
                            txtPFFixAmount.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[18].Value));
                            txtPFFixAmountLimit.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[19].Value));

                            txtEPFProvidentFundPerEmployer.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[20].Value));
                            txtEPSPensionSchemePerEmployer.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[21].Value));
                            txtEPFPensionPFPerEmployer.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[22].Value));
                            txtEPFAdministratonCharges.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[23].Value));
                        }
                        else
                        {
                            gbPFCalculations.Visible = false;
                            cbIsPF.Checked = false;
                        }
                        //txtBasicDAPer.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[8].Value));
                        
                        IsEsic = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[24].Value)));
                        if (IsEsic == 1)
                        {
                            gbEsicConfiguration.Visible = true;
                            cbIsEsic.Checked = true;
                            txtEsicEmployeeContributions.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[25].Value));
                            txtEsicEmployerContributions.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[26].Value));
                            txtEsicLimit.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[27].Value));
                        }
                        else
                        {
                            gbEsicConfiguration.Visible = false;
                        }

                        IsLWF = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[28].Value)));
                        if (IsLWF == 1)
                        {
                            gbLWFConfiguration.Visible = true;
                            cbIsLWF.Checked = true;
                            txtLWFEmployeeShare.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[29].Value));
                            txtLWFEmployerShare.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[30].Value));
                            txtLWFLimit.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[31].Value));
                        }
                        else
                        {
                            gbLWFConfiguration.Visible = false;
                            cbIsLWF.Checked = false;
                        }

                        txtCommission.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[32].Value));
                        txtFactor.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[33].Value));
                        txtOTRate.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[34].Value));
                        txtRemarks.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[35].Value));
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

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void gbEsicConfiguration_Enter(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPFEmployeeContributions_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtEPFPensionPFPerEmployee);
        }

        private bool Validation()
        {
            if (txtRuleName.Text == "")
            {
                txtRuleName.Focus();
                objEP.SetError(txtRuleName, " Enter Job Profile");
                return true;
            }
            else if (cmbContractorName.SelectedIndex ==-1)
            {
                cmbContractorName.Focus();
                objEP.SetError(cmbContractorName, " Select Contractor Name");
                return true;
            }
            else if (!cbIsCash.Checked)
            {
                if (txtBasicPer.Text == "")
                {
                    txtBasicPer.Focus();
                    objEP.SetError(txtBasicPer, " Enter Basic DA Per");
                    return true;
                }
                else if (txtHRAPer.Text == "")
                {
                    txtHRAPer.Focus();
                    objEP.SetError(txtHRAPer, " Enter  HRA Per");
                    return true;
                }
                else if (cbIsPF.Checked)
                {
                    if (txtEPFPensionPFPerEmployee.Text == "")
                    {
                        txtEPFPensionPFPerEmployee.Focus();
                        objEP.SetError(txtEPFPensionPFPerEmployee, " Enter PF Employee Contributions");
                        return true;
                    }
                    else if (txtEPFPensionPFPerEmployer.Text == "")
                    {
                        txtEPFPensionPFPerEmployer.Focus();
                        objEP.SetError(txtEPFPensionPFPerEmployer, " Enter PF Employer Contributions");
                        return true;
                    }
                   else if (txtPFFixAmount.Text == "")
                    {
                        txtPFFixAmount.Focus();
                        objEP.SetError(txtPFFixAmount, " Enter PF FixAmount");
                        return true;
                    }
                    else if (txtPFFixAmountLimit.Text == "")
                    {
                        txtPFFixAmountLimit.Focus();
                        objEP.SetError(txtPFFixAmountLimit, " Enter PF Fix Amount Limit");
                        return true;
                    }
                    else
                        return false;
                }
                else if (cbIsEsic.Checked)
                {
                    if (txtEsicEmployeeContributions.Text == "")
                    {
                        txtEsicEmployeeContributions.Focus();
                        objEP.SetError(txtEsicEmployeeContributions, " Enter Esic Employee Contributions");
                        return true;
                    }
                    else if (txtEsicEmployerContributions.Text == "")
                    {
                        txtEsicEmployerContributions.Focus();
                        objEP.SetError(txtEsicEmployerContributions, " Enter Esic Employer Contributions");
                        return true;
                    }
                    else if (txtEsicLimit.Text == "")
                    {
                        txtEsicLimit.Focus();
                        objEP.SetError(txtEsicLimit, " Enter Esic Limit");
                        return true;
                    }
                    else
                        return false;
                }
                else if (cbIsLWF.Checked)
                {
                    if (txtLWFEmployeeShare.Text == "")
                    {
                        txtLWFEmployeeShare.Focus();
                        objEP.SetError(txtLWFEmployeeShare, " Enter LWF Employee Share");
                        return true;
                    }
                    else if (txtLWFEmployerShare.Text == "")
                    {
                        txtLWFEmployerShare.Focus();
                        objEP.SetError(txtLWFEmployerShare, " Enter LWF Employer Share");
                        return true;
                    }
                    else if (txtLWFLimit.Text == "")
                    {
                        txtLWFLimit.Focus();
                        objEP.SetError(txtLWFLimit, " Enter LWF Limit");
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }
        protected bool CheckExist()
        {
            if (TableId == 0)
            {
                DataSet ds = new DataSet();
                objBL.Query = "select ContractorId from salaryconfigurations where CancelTag=0 and ContractorId=" + cmbContractorName.SelectedValue + " ";// and ContractorId !=" + TableId + "";
                ds = objBL.ReturnDataSet();

                if (ds.Tables[0].Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        int IsCash = 0, IsPT = 0, IsPF=0, IsEsic=0, IsLWF=0;
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
                        objBL.Query = "update SalaryConfigurations set RuleName='" + txtRuleName.Text + "',BasicDAPer='" + txtBasicPer.Text + "',IsCash=" + IsCash + ",IsPT=" + IsPT + ",BasicPer='" + txtBasicPer.Text + "',HRAPer='" + txtHRAPer.Text + "',DAPer='" + txtDearnessAllowanceDAPer.Text + "',TransportAllowancePer='" + txtTransportAllowancePer.Text + "',MedicalAllowancesPer='" + txtMedicalAllowancesPer.Text + "',SpecialAllowancePer='" + txtSpecialAllowancePer.Text + "',EductionAllowancesPer='" + txtEductionAllowancesPer.Text + "',ConveyanceAllowancesPer='" + txtConveyanceAllowancesPer.Text + "',OtherAllowancesPer='" + txtOtherAllowancesPer.Text + "',IsPF=" + IsPF + ",EPFProvidentFundPerEmployee='" + txtEPFProvidentFundPerEmployee.Text + "',EPSPensionSchemePerEmployee='" + txtEPSPensionSchemePerEmployee.Text + "',EPFPensionPFPerEmployee='" + txtEPFPensionPFPerEmployee.Text + "',PFFixAmount='" + txtPFFixAmount.Text + "',PFFixAmountLimit='" + txtPFFixAmountLimit.Text + "',EPFProvidentFundPerEmployer='" + txtEPFProvidentFundPerEmployer.Text + "',EPSPensionSchemePerEmployer='" + txtEPSPensionSchemePerEmployer.Text + "',EPFPensionPFPerEmployer='" + txtEPFPensionPFPerEmployer.Text + "',EPFAdministratonCharges='" + txtEPFAdministratonCharges.Text + "',IsEsic=" + IsEsic + ",EsicEmployeeContributions='" + txtEsicEmployeeContributions.Text + "',EsicEmployerContributions='" + txtEsicEmployerContributions.Text + "',EsicLimit='" + txtEsicLimit.Text + "',IsLWF=" + IsLWF + ",LWFEmployeeShare='" + txtLWFEmployeeShare.Text + "',LWFEmployerShare='" + txtLWFEmployerShare.Text + "',LWFLimit='" + txtLWFLimit.Text + "',Commission='" + txtCommission.Text + "',Factor='" + txtFactor.Text + "',OTRate='" + txtOTRate.Text + "',Remarks='" + txtRemarks.Text + "',ModifiedUserId=" + BusinessLayer.LoginId_Static + " where ContractorId=" + TableId + "";
                    else
                        objBL.Query = "update SalaryConfigurations set CancelTag=1 where ContractorId=" + TableId + " ";
                }
                else
                    objBL.Query = "insert into SalaryConfigurations(ContractorId,RuleName,IsCash,IsPT,BasicPer,HRAPer,DAPer,TransportAllowancePer,MedicalAllowancesPer,SpecialAllowancePer,EductionAllowancesPer,ConveyanceAllowancesPer,OtherAllowancesPer,IsPF,EPFProvidentFundPerEmployee,EPSPensionSchemePerEmployee,EPFPensionPFPerEmployee,PFFixAmount,PFFixAmountLimit,EPFProvidentFundPerEmployer,EPSPensionSchemePerEmployer,EPFPensionPFPerEmployer,EPFAdministratonCharges,IsEsic,EsicEmployeeContributions,EsicEmployerContributions,EsicLimit,IsLWF,LWFEmployeeShare,LWFEmployerShare,LWFLimit,Commission,Factor,OTRate,Remarks,UserId) values(" + cmbContractorName.SelectedValue + ",'" + txtRuleName.Text + "'," + IsCash + "," + IsPT + ",'" + txtBasicPer.Text + "','" + txtHRAPer.Text + "','" + txtDearnessAllowanceDAPer.Text + "','" + txtTransportAllowancePer.Text + "','" + txtMedicalAllowancesPer.Text + "','" + txtSpecialAllowancePer.Text + "','" + txtEductionAllowancesPer.Text + "','" + txtConveyanceAllowancesPer.Text + "','" + txtOtherAllowancesPer.Text + "'," + IsPF + ",'" + txtEPFProvidentFundPerEmployee.Text + "','" + txtEPSPensionSchemePerEmployee.Text + "','" + txtEPFPensionPFPerEmployee.Text + "','" + txtPFFixAmount.Text + "','" + txtPFFixAmountLimit.Text + "','" + txtEPFProvidentFundPerEmployer.Text + "','" + txtEPSPensionSchemePerEmployer.Text + "','" + txtEPFPensionPFPerEmployer.Text + "','" + txtEPFAdministratonCharges.Text + "'," + IsEsic + ",'" + txtEsicEmployeeContributions.Text + "','" + txtEsicEmployerContributions.Text + "','" + txtEsicLimit.Text + "'," + IsLWF + ",'" + txtLWFEmployeeShare.Text + "','" + txtLWFEmployerShare.Text + "','" + txtLWFLimit.Text + "','" + txtCommission.Text + "','" + txtFactor.Text + "','" + txtOTRate.Text + "','" + txtRemarks.Text + "'," + BusinessLayer.LoginId_Static + ")";

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
            lblTotalCount.Text = "";
            dataGridView1.DataSource = null;
            DataSet ds = new DataSet();
            objPC.JobProfile = txtSearch.Text;

            if (!SearchFlag)
                objPC.SearchFlag = false;
            else
                objPC.SearchFlag = true;

            objBL.Query = "select SC.ContractorId as 'Head Number',CM.ContractorName as 'Contractor Name',SC.RuleName as 'Rule Name',SC.IsCash,SC.IsPT,SC.BasicPer,SC.HRAPer,SC.DAPer,SC.TransportAllowancePer,SC.MedicalAllowancesPer,SC.SpecialAllowancePer,SC.EductionAllowancesPer,SC.ConveyanceAllowancesPer,SC.OtherAllowancesPer,SC.IsPF,SC.EPFProvidentFundPerEmployee,SC.EPSPensionSchemePerEmployee,SC.EPFPensionPFPerEmployee,SC.PFFixAmount,SC.PFFixAmountLimit,SC.EPFProvidentFundPerEmployer,SC.EPSPensionSchemePerEmployer,SC.EPFPensionPFPerEmployer,SC.EPFAdministratonCharges,SC.IsEsic,SC.EsicEmployeeContributions,SC.EsicEmployerContributions,SC.EsicLimit,SC.IsLWF,SC.LWFEmployeeShare,SC.LWFEmployerShare,SC.LWFLimit,SC.Commission,SC.Factor,SC.OTRate,SC.Remarks from salaryconfigurations SC inner join contractormaster CM on CM.ContractorId=SC.ContractorId where CM.CancelTag=0 and SC.CancelTag=0";

            ds = objBL.ReturnDataSet();
            //ds = objQL.SP_JobProfileMaster_FillGrid();

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTotalCount.Text = "Total-" + ds.Tables[0].Rows.Count;

                //0 SC.ContractorId,
                //1 CM.ContractorName,
                //2 SC.RuleName,
                //3 SC.IsCash,
                //4 SC.IsPT,
                //5 SC.BasicPer,
                //6 SC.HRAPer,
                //7 SC.DAPer,
                //8 SC.TransportAllowancePer,
                //9 SC.MedicalAllowancesPer,
                //10 SC.SpecialAllowancePer,
                //11 SC.EductionAllowancesPer,
                //12 SC.ConveyanceAllowancesPer,
                //13 SC.OtherAllowancesPer,
                //14 SC.IsPF,
                //15 SC.EPFProvidentFundPerEmployee,
                //16 SC.EPSPensionSchemePerEmployee,
                //17 SC.EPFPensionPFPerEmployee,
                //18 SC.PFFixAmount,
                //19 SC.PFFixAmountLimit,
                //20 SC.EPFProvidentFundPerEmployer,
                //21 SC.EPSPensionSchemePerEmployer,
                //22 SC.EPFPensionPFPerEmployer,
                //23 SC.EPFAdministratonCharges,
                //24 SC.IsEsic,
                //25 SC.EsicEmployeeContributions,
                //26 SC.EsicEmployerContributions,
                //27 SC.EsicLimit,
                //28 SC.IsLWF,
                //29 SC.LWFEmployeeShare,
                //30 SC.LWFEmployerShare,
                //31 SC.LWFLimit,
                //32 SC.Commission,
                //33 SC.Factor,
                //34 SC.OTRate,
                //35 SC.Remarks

                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[17].Visible = false;
                
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[2].Width = 150;
            }
        }
    }
}
