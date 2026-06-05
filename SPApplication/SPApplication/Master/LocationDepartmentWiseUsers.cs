using BusinessLayerUtility;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Windows.Forms;

namespace SPApplication.HR
{
    public partial class LocationDepartmentWiseUsers : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0, LocationId = 0;

        string DepartmentConcat = string.Empty, InchargeConcat = string.Empty;
        int FinalApprovalId = 0, HRApprovalId = 0;

        public LocationDepartmentWiseUsers()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_LOCATIONANDDEPARTMENTWISEUSERS);
            objRL.Get_UserRights_By_MenuName(BusinessResources.LBL_HEADER_MASTER);
            objQL.Fill_Master_ComboBox(cmbLocation, "locationmaster");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
            cmbLocation.SelectedIndex = -1;
        }

        private void ClearAll()
        {
            objEP.Clear();
            txtSearch.Text = "";
            FlagDelete = false;
            cmbInchargeName.SelectedIndex = -1;
            Unchecked_CheckedListBox(clbDepartment);
            //Unchecked_CheckedListBox(clbIncharge);
            cmbManager.SelectedIndex = -1;
            cmbHRApproval.SelectedIndex = -1;
            clbDepartment.DataSource = null;
            //clbIncharge.DataSource = null;
            FlagDelete = false; FlagExist = false; SearchFlag = false;
            btnDelete.Enabled = false;
            RowCount_Grid = 0; CurrentRowIndex = 0; TableId = 0; Result = 0; LocationId = 0;
            clbDepartment.DataSource = null;
        }

        private void Unchecked_CheckedListBox(CheckedListBox clb)
        {
            foreach (int i in clb.CheckedIndices)
            {
                clb.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private bool Validation()
        {
            objEP.Clear();

            if (cmbLocation.SelectedIndex == -1)
            {
                objEP.SetError(cmbLocation, "Select Location");
                cmbLocation.Focus();
                return true;
            }
            else if (cmbManager.SelectedIndex == -1)
            {
                objEP.SetError(cmbManager, "Select Final Approval");
                cmbManager.Focus();
                return true;
            }
            else if (cmbHRApproval.SelectedIndex == -1)
            {
                objEP.SetError(cmbHRApproval, "Select HR Approval");
                cmbHRApproval.Focus();
                return true;
            }
            else
                return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (objPC.AddFlag == 1)
            {
                try
                {
                    FlagDelete = false;
                    SaveDB();
                }
                catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
                finally { GC.Collect(); }
            }
            else
            {
                objRL.ShowMessage(24, 4);
                return;
            }
        }

        int clbID = 0;

        private string Set_Concat_Values(CheckedListBox clb)
        {
            string ConcatString = string.Empty;

            foreach (object itemChecked in clb.CheckedItems)
            {
                DataRowView castedItem = itemChecked as DataRowView;
                int? id = Convert.ToInt32(castedItem[0]);
                clbID = (int)id;
                ConcatString += clbID.ToString() + ",";
            }

            //INConcat = INConcat.Remove(INConcat.Length - 1);

            //for (int i = 0; i <= (clb.Items.Count - 1); i++)
            //{
            //    if (clb.GetItemChecked(i))
            //    {
            //        ConcatString += clb.Items[i].ToString() + ",";
            //    }
            //}

            if (!string.IsNullOrEmpty(Convert.ToString(ConcatString)))
                ConcatString = ConcatString.Remove(ConcatString.Length - 1);

            return ConcatString;
        }

        int DepartmentId_Checked = 0;
        int InchargeId = 0, PlantHeadId = 0, HRId = 0;
        private void SaveDB()
        {
            if (!Validation())
            {
                InchargeId = 0; PlantHeadId = 0; HRId = 0;
                InchargeId = Convert.ToInt32(cmbInchargeName.SelectedValue);
                //Delete Query
                objBL.Query = "delete from locationwisedepartmentusers where LocationId=" + objPC.LocationId + " and InchargeId=" + InchargeId + " and CancelTag=0";
                Result = objBL.Function_ExecuteNonQuery();
                
                foreach (object itemChecked in clbDepartment.CheckedItems)
                {
                    DataRowView castedItem = itemChecked as DataRowView;
                    int? id = Convert.ToInt32(castedItem[0]);
                    DepartmentId_Checked = (int)id;

                    if (DepartmentId_Checked != 0)
                    {
                        // objPC.ShiftGroupShiftId = TableId;
                        objPC.LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
                        objPC.DepartmentId = DepartmentId_Checked; //Convert.ToInt32(cmbShiftsGroup.SelectedValue);

                        InchargeId = Convert.ToInt32(cmbInchargeName.SelectedValue);
                        PlantHeadId = Convert.ToInt32(cmbManager.SelectedValue);
                        HRId = Convert.ToInt32(cmbHRApproval.SelectedValue);

                        objPC.UserId = BusinessLayer.LoginId_Static;

                        objBL.Query = "insert into locationwisedepartmentusers(LocationId,DepartmentId,InchargeId,PlantHeadId,HRId) values(" + objPC.LocationId + "," + objPC.DepartmentId + "," + InchargeId + "," + PlantHeadId + "," + HRId + ")";
                        Result = objBL.Function_ExecuteNonQuery();

                        //DataSet ds = new DataSet();
                        //objBL.Query = "select LocationId,DepartmentId from locationwisedepartmentusers where LocationId=" + objPC.LocationId + " and DepartmentId=" + objPC.DepartmentId + " and CancelTag=0";
                        //ds = objBL.ReturnDataSet();
                        //if (ds.Tables[0].Rows.Count > 0)
                        //{
                        //    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][0].ToString())))
                        //    {
                        //        objBL.Query = "update locationwisedepartmentusers set InchargeId=" + InchargeId + ",PlantHeadId=" + PlantHeadId + ",HRId=" + HRId + " where LocationId=" + objPC.LocationId + " and DepartmentId=" + objPC.DepartmentId + " and CancelTag=0";
                        //        Result = objBL.Function_ExecuteNonQuery();
                        //    }
                        //}
                        //else
                        //{
                        //    objBL.Query = "insert into locationwisedepartmentusers(LocationId,DepartmentId,InchargeId,PlantHeadId,HRId) values(" + objPC.LocationId + "," + objPC.DepartmentId + "," + InchargeId + "," + PlantHeadId + "," + HRId + ")";
                        //    Result = objBL.Function_ExecuteNonQuery();
                        //}
                    }
                }

                if (Result > 0)
                {
                    objRL.ShowMessage(7, 1);
                    FillGrid();
                }



                //DepartmentConcat = Set_Concat_Values(clbDepartment);
                ////InchargeConcat = Set_Concat_Values(clbIncharge);
                //FinalApprovalId = Convert.ToInt32(cmbManager.SelectedValue);
                //HRApprovalId = Convert.ToInt32(cmbHRApproval.SelectedValue);

                //objPC.ApprovalLevelId = TableId;
                //objPC.LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
                //objPC.InchargeId = Convert.ToInt32(cmbInchargeName.SelectedValue);
                //objPC.DepartmentId_S = DepartmentConcat;
                //objPC.InchargeId_S = InchargeConcat;
                //objPC.PlantHeadId = Convert.ToInt32(cmbManager.SelectedValue);
                //objPC.HRApprovalId = Convert.ToInt32(cmbHRApproval.SelectedValue);
                //Result = objQL.SP_ApprovalLevel_Insert_Update_Delete();

                //if (Result > 0)
                //{
                //    objRL.ShowMessage(7, 1);
                //    FillGrid();
                //}
            }
        }

        private void Approval_Level_Master_Load(object sender, EventArgs e)
        {
            cmbLocation.SelectedIndex = -1;
            ClearAll();
            FillGrid();
        }

        private void cmbLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ClearAll();
            FillDepartment();
            FillEmployees();
        }

        private void Fill_Department_By_GroupId()
        {
            DataSet ds = new DataSet();
            //objPC.LocationId = TableId;
            ds = objQL.SP_LocationWiseDepartment_Get_Department_By_LocationId();
            if (ds.Tables[0].Rows.Count > 0)
            {
                clbDepartment.DataSource = ds.Tables[0];
                clbDepartment.DisplayMember = "Department";
                clbDepartment.ValueMember = "DepartmentId";
            }
        }

        private void FillDepartment()
        {
            if (cmbLocation.SelectedIndex > -1)
            {
                LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
                //objRL.Fill_Department_CheckedListBox_By_Location(clbDepartment, LocationId);
                objPC.LocationId = LocationId;
                Fill_Department_By_GroupId();
            }
        }

        private void FillEmployees()
        {
            if (cmbLocation.SelectedIndex > -1)
            {
                //cmbInchargeName.DataSource = null;
                //cmbManager.DataSource = null;

                objQL.WhereClause_V = string.Empty;

                LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
                objPC.LocationId = LocationId;

                objQL.WhereClause_V = " and DM.DesignationCategory IN ('" + BusinessResources.USER_TYPE_SENIOROFFICER + "','" + BusinessResources.USER_TYPE_MANAGER + "','" + BusinessResources.USER_TYPE_HROFFICER + "','" + BusinessResources.USER_TYPE_ADMINISTRATOR + "','" + BusinessResources.USER_TYPE_OFFICER + "', 'EXECUTIVE','HOD')";
                objQL.SP_Employees_Get_By_All(cmbInchargeName);

                objQL.WhereClause_V = string.Empty;
                objQL.WhereClause_V = " and DM.DesignationCategory IN ('" + BusinessResources.USER_TYPE_MANAGER + "','" + BusinessResources.USER_TYPE_HROFFICER + "','" + BusinessResources.USER_TYPE_ADMINISTRATOR + "', 'EXECUTIVE','HOD')";
                objQL.SP_Employees_Get_By_All(cmbManager);

                objQL.WhereClause_V = string.Empty;
                //objQL.WhereClause_V = " and DM.DesignationCategory IN ('" + BusinessResources.USER_TYPE_HROFFICER + "','" + BusinessResources.USER_TYPE_ADMINISTRATOR + "')";

                
                objQL.WhereClause_V = " and D.Department IN('TIME OFFICE') and DM.DesignationCategory IN ('HOD','" + BusinessResources.USER_TYPE_ADMINISTRATOR + "','EXECUTIVE')";
                //objQL.WhereClause_V = " and D.Department='" + BusinessResources.Department_HR + "' and DM.DesignationCategory IN ('" + BusinessResources.USER_TYPE_HROFFICER + "','" + BusinessResources.USER_TYPE_ADMINISTRATOR + "')";
                objQL.SP_Employees_Get_By_All(cmbHRApproval);

                //------------------------------------------------------------------------
                //old code
                //objQL.WhereClause_V = " and DM.Designation IN ('" + BusinessResources.USER_TYPE_ADMIN + "','" + BusinessResources.USER_TYPE_OFFICER + "','" + BusinessResources.USER_TYPE_MANAGER + "','" + BusinessResources.USER_TYPE_INCHARGE + "')";
                //objQL.SP_Employees_Get_By_All(cmbInchargeName);

                //objQL.WhereClause_V = string.Empty;
                //objQL.WhereClause_V = " and DM.Designation IN ('" + BusinessResources.USER_TYPE_ADMIN + "','" + BusinessResources.USER_TYPE_OFFICER + "','" + BusinessResources.USER_TYPE_MANAGER + "')";
                //objQL.SP_Employees_Get_By_All(cmbManager);

                //objQL.WhereClause_V = string.Empty;
                //objQL.WhereClause_V = " and D.Department='" + BusinessResources.Department_HR + "' and DM.Designation IN ('" + BusinessResources.USER_TYPE_ADMIN + "','" + BusinessResources.USER_TYPE_OFFICER + "','" + BusinessResources.USER_TYPE_MANAGER + "')";
                //objQL.SP_Employees_Get_By_All(cmbHRApproval);

                //-----------------------------------------------------------------------------------------


                //objPC.UserType = Convert.ToString(BusinessResources.USER_TYPE_INCHARGE);
                //objQL.SP_Employees_ComboBox_By_LocationId_UserType(cmbInchargeName);

                //objQL.SP_Employees_Get_By_All(BusinessResources.SearchBy_Designation, BusinessResources.USER_TYPE_INCHARGE, cmbInchargeName,"");

                //objQL.SP_Employees_FillBy_LocationAndUserType(cmbInchargeName);

                //objQL.SP_Employees_ComboBox_By_LocationId_UserType(cmbInchargeName);
                //objPC.UserType = Convert.ToString(BusinessResources.USER_TYPE_PLANTHEAD);
                //objPC.UserType = Convert.ToString(BusinessResources.USER_TYPE_MANAGER);
                //cmbManager.DataSource = null;
                //objQL.SP_Employees_FillBy_LocationAndUserType(cmbManager);

                //objQL.SP_Employees_Get_By_All(cmbManager);

                //objPC.UserType = Convert.ToString(BusinessResources.USER_TYPE_OFFICER);
                // objQL.SP_Employees_FillBy_LocationAndUserType(cmbHRApproval);

                //objQL.SP_Employees_Get_By_All(BusinessResources.SearchBy_Designation, BusinessResources.USER_TYPE_OFFICER, cmbHRApproval, BusinessResources.Department_HR);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (objPC.DeleteFlagUR == 1)
            {
                try
                {
                    DialogResult dr = objRL.Delete_Record_Show_Message();
                    if (dr == System.Windows.Forms.DialogResult.Yes)
                    {
                        FlagDelete = true;
                        SaveDB();
                    }
                }
                catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
                finally { GC.Collect(); }
            }
            else
            {
                objRL.ShowMessage(24, 4);
                return;
            }
        }

        protected void FillGrid()
        {
            lblTotalCount.Text = "";
            dataGridView1.DataSource = null;
            DataSet ds = new DataSet();
            objPC.Department = txtSearch.Text;

            if (!SearchFlag)
                objPC.SearchFlag = false;
            else
                objPC.SearchFlag = true;

            //ds = objQL.SP_ApprovalLevel_FillGrid();

            ds = objQL.SP_LocationWiseDepartmentUsers_FillGrid();


            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTotalCount.Text = "Total-" + ds.Tables[0].Rows.Count;
                //0 wd.LocationWiseDepartmentId,
                //1 lwd.LocationId,
                //2 LM.LocationName as 'Location Name',
                //3 lwd.DepartmentId,
                //4 d.Department,
                //5 lwd.InchargeId, 
                //6 E.EmployeeName as 'Incharge Name',
                //7 lwd.PlantHeadId,
                //8 E1.EmployeeName as 'Manager',
                //9 lwd.HRId,
                //10 E2.EmployeeName as 'HR Approval'

                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                //dataGridView1.Columns[10].Visible = false;

                dataGridView1.Columns[2].Width = 200;
                dataGridView1.Columns[4].Width = 200;
                dataGridView1.Columns[6].Width = 200;
                dataGridView1.Columns[8].Width = 200;
                dataGridView1.Columns[10].Width = 200;
                //dataGridView1.Columns[10].Width = 120;
                //dataGridView1.Columns[11].Width = 100;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
                SearchFlag = true;
            else
                SearchFlag = false;

            FillGrid();
        }

        string ConcatString = string.Empty;
        string CheckBoxListSelectedValue = string.Empty;

        List<int> objItem = new List<int>();

        private void Fill_Department_By_GroupId_Grid()
        {
            DataSet ds = new DataSet();
            objPC.LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
            ds = objQL.SP_LocationWiseDepartment_FillGrid_DepartmentName();
            if (ds.Tables[0].Rows.Count > 0)
            {
                //0 SGS.ShiftGroupId,
                //1 SG.ShiftGroupFName 
                //2 SGS.ShiftId

                objItem = new List<int>();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["DepartmentId"])))
                    {
                        int Iid = Convert.ToInt32(ds.Tables[0].Rows[i]["DepartmentId"].ToString());
                        objItem.Add(Iid);
                    }
                }

                //foreach (object itemChecked in clbShift.CheckedItems)
                //{
                //    DataRowView castedItem = itemChecked as DataRowView;
                //    int? id = Convert.ToInt32(castedItem[0]);
                //    ShiftId_Checked = (int)id;
                //    if (objItem.Contains(ShiftId_Checked))
                //        clbShift.SetItemChecked(i, true);
                //}

                int value = 0;
                for (int i = 0; i < clbDepartment.Items.Count; i++)
                {
                    DataRowView castedItem = clbDepartment.Items[i] as DataRowView;
                    int? id = Convert.ToInt32(castedItem[0]);
                    DepartmentId_Checked = (int)id;
                    //DataRowView view = clbShift.Items[i] as DataRowView;
                    //value = (int)view["ShiftId"];

                    //if (objItem[i].ToString() == DepatmentValue.ToString())
                    //    clbDepartment.SetItemChecked(i, true);

                    if (objItem.Contains(DepatmentValue))
                        clbDepartment.SetItemChecked(i, true);
                }
            }
            //else
            //    objRL.Fill_Supervisor_CheckedListBox(clbShift);
        }

        int DepatmentValue = 0;
        private void Set_CheckBox(CheckedListBox clb)
        {
            int value = 0;
            List<string> listStrLineElements = CheckBoxListSelectedValue.Split(',').ToList();

            for (int i = 0; i < clb.Items.Count; i++)
            {
                DataRowView view = clb.Items[i] as DataRowView;
                //value = (int)[0];
                int? id = Convert.ToInt32(view[0]);
                if (listStrLineElements.Contains(id.ToString()))
                    clb.SetItemChecked(i, true);
            }

            //foreach (var listItem in clb.Items)
            //{
            //    if (listStrLineElements.Contains((int.Parse(listItem.se.se.Value))))
            //    {
            //        listItem.Selected = true;
            //    }
            //}


            //foreach (ListItem listitem in clb.Items)
            //{
            //    DataRowView castedItem = listitem as DataRowView;
            //    int? id = Convert.ToInt32(castedItem[0]);
            //    clbID = (int)id;
            //}

            //for (int j = 0; j < listStrLineElements.Count; j++)
            //{
            //    //for (int i = 0; i < clb.Items.Count; i++)
            //    //{

            //    //}

            //    foreach (object icheck in clb.Items)
            //    {
            //        DataRowView castedItem = icheck as DataRowView;
            //        int? id = Convert.ToInt32(castedItem[0]);
            //        clbID = (int)id;


            //        if (clbID == Convert.ToInt32(listStrLineElements[j].ToString()))
            //            clb.SetItemChecked(0, true);


            //    }

            //    //if (clb.Items[i].ToString() == listStrLineElements[j].ToString())
            //    //    clb.SetItemChecked(i, true);
            //}

            //for (int count = 0; count < clb.Items.Count; count++)
            //{
            //    if (listStrLineElements.Contains(clb.SelectedValue.ToString()))
            //    {
            //        clb.SetItemChecked(count, true);
            //    }
            //}



            //List<string> listStrLineElements = line.Split(',').ToList();

            //for (int i = 0; i < clb.Items.Count; i++)
            //{
            //    for (int j = 0; j < listStrLineElements.Count; j++)
            //    {
            //        if (clb.Items[i].ToString() == listStrLineElements[j].ToString())
            //            clb.SetItemChecked(i, true);
            //    }
            //}
        }



        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (objPC.ViewFlag == 1)
            {
                try
                {
                    CheckBoxListSelectedValue = string.Empty;

                    RowCount_Grid = dataGridView1.Rows.Count;
                    CurrentRowIndex = dataGridView1.CurrentRow.Index;

                    if (RowCount_Grid >= 0 && CurrentRowIndex >= 0)
                    {
                        ClearAll();

                        //0 wd.LocationWiseDepartmentId,
                        //1 lwd.LocationId,
                        //2 LM.LocationName as 'Location Name',
                        //3 lwd.DepartmentId,
                        //4 d.Department,
                        //5 lwd.InchargeId, 
                        //6 E.EmployeeName as 'Incharge Name',
                        //7 lwd.PlantHeadId,
                        //8 E1.EmployeeName as 'Manager',
                        //9 lwd.HRId,
                        //10 E2.EmployeeName as 'HR Approval'

                        btnDelete.Enabled = true;
                        TableId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                        cmbLocation.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        FillEmployees();
                        cmbInchargeName.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                        FillDepartment();
                        cmbManager.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                        cmbHRApproval.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                        DepatmentValue = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                        //Fill_Department_By_GroupId_Grid();

                        int InchargeId= Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value);

                        DataSet dsDeptEmployee = new DataSet();
                        objBL.Query = "select DepartmentId from locationwisedepartmentusers where InchargeId=" + InchargeId + " and LocationId=" + objPC.LocationId + " and CancelTag=0";
                        dsDeptEmployee = objBL.ReturnDataSet();

                        if (dsDeptEmployee.Tables[0].Rows.Count >0)
                        {
                            for(int i=0;i< dsDeptEmployee.Tables[0].Rows.Count;i++)
                            {
                                int DepartmentIdEmployee= Convert.ToInt32(dsDeptEmployee.Tables[0].Rows[i]["DepartmentId"]);


                                for (int j = 0; j < clbDepartment.Items.Count; j++)
                                {
                                    DataRowView castedItem = clbDepartment.Items[j] as DataRowView;
                                    int? id = Convert.ToInt32(castedItem[0]);
                                    int DepartmentIdCheckList = (int)id;

                                    //if (objItem.Contains(DepatmentValue))

                                        if(DepartmentIdCheckList == DepartmentIdEmployee)
                                            clbDepartment.SetItemChecked(j, true);

                                }


                                }
                        }


                        //CheckBoxListSelectedValue = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(); 
                        //Set_CheckBox(clbDepartment);
                        //CheckBoxListSelectedValue = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                        // Set_CheckBox(clbIncharge);
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
    }
}
