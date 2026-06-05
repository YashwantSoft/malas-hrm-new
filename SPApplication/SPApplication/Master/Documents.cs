using BusinessLayerUtility;

using SPApplication.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPApplication.Master
{
    public partial class Documents : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0;

        string FormName = string.Empty;
        int FormId = 0;

        public Documents()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_DOCUMENTS + " of " + objPC.FormHeader);
            btnBrowse.BackColor = objDL.GetBackgroundColor();
            btnBrowse.ForeColor = objDL.GetForeColor();
            objDL.SetPlusButtonDesign(btnAddDocuments);
            objQL.SP_DocumentMaster_Select_ComboBox(cmbDocumentName);
            TableId = objPC.TableId;
        }

        private void ClearAll()
        {
            cmbDocumentName.SelectedIndex = -1;
            //txtDocumentsFor.Text = "";
            dtpDate.Value = DateTime.Now.Date;
            txtFileName.Text = "";
            txtFilePath.Text = "";
            txtDocumentsFor.Text = objPC.FormName;
            cmbDocumentName.Focus();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (!ValidationBrowseFile())
            {
                Get_File();
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }

        private void Documents_Load(object sender, EventArgs e)
        {
            ClearAll();
            Fill_Files();
        }

        private bool ValidationBrowseFile()
        {
            objEP.Clear();
            if (objPC.TableId == 0)
            {
                txtDocumentsFor.Focus();
                objEP.SetError(txtDocumentsFor, "Enter Table Id");
                return true;
            }
            else if (txtDocumentsFor.Text == "")
            {
                txtDocumentsFor.Focus();
                objEP.SetError(txtDocumentsFor, "Enter Documents For");
                return true;
            }
            else if (cmbDocumentName.SelectedIndex == -1)
            {
                cmbDocumentName.Focus();
                objEP.SetError(cmbDocumentName, "Select Document Name");
                return true;
            }
            else
                return false;
        }

        private bool Validation()
        {
            objEP.Clear();
            if (objPC.TableId == 0)
            {
                txtDocumentsFor.Focus();
                objEP.SetError(txtDocumentsFor, "Enter Table Id");
                return true;
            }
            else if (txtDocumentsFor.Text == "")
            {
                txtDocumentsFor.Focus();
                objEP.SetError(txtDocumentsFor, "Enter Documents For");
                return true;
            }
            else if (cmbDocumentName.SelectedIndex == -1)
            {
                cmbDocumentName.Focus();
                objEP.SetError(cmbDocumentName, "Select Document Name");
                return true;
            }
            else if (txtFileName.Text == "")
            {
                txtFileName.Focus();
                objEP.SetError(txtFileName, "Enter File Name");
                return true;
            }
            else if (txtFilePath.Text == "")
            {
                txtFilePath.Focus();
                objEP.SetError(txtFilePath, "Enter File Path");
                return true;
            }
            else
                return false;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Validation())
            {
                AddFiles();
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }

        string FileName = string.Empty, SourcePath = string.Empty, DestinationPath = string.Empty;

        private void Get_File()
        {
            FileName = string.Empty; SourcePath = string.Empty; DestinationPath = string.Empty;
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Files (*.pdf;*.jpg;*.jpeg;.*.png;)|*.pdf;*.jpg;*.jpeg;.*.png";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                SourcePath = opnfd.FileName;
                FileName = Path.GetFileName(SourcePath);
                txtFileName.Text = FileName.ToString();
                txtFilePath.Text = SourcePath.ToString();
                //pictureBox1.Image = new Bitmap(opnfd.FileName);
            }
        }

        string FileNameInsert = string.Empty;
        string FilePathInsert = string.Empty;
        string FilePathMain = string.Empty;


        private void CopyPasteFile()
        {
            if (TableId > 0)
            {
                //DestinationPath = objRL.GetPath("DocumentsPath") + "\\" + objPC.FormId + "\\" + TableId + "\\";

                DestinationPath = objRL.GetPath_DocumentsMain(TableId);
                DirectoryInfo objDI = new DirectoryInfo(Path.GetFullPath(DestinationPath));

                if (!Directory.Exists(Path.GetFullPath(DestinationPath)))
                    objDI.Create();
                else
                {
                    string[] files = Directory.GetFiles(DestinationPath);
                    foreach (string file in files)
                    {
                        if (file == DestinationPath + FileName)
                            File.Delete(file);
                    }
                }

                File.Copy(FilePathMain, DestinationPath + Path.GetFileName(FilePathMain));
            }

            //string[] filePaths = Directory.GetFiles(SourcePath);

            //foreach (var filename in filePaths)
            //{
            //    string file = filename.ToString();
            //    //Do your job with "file"  
            //    string str = DestinationPath+file.ToString(), Replace(SourcePath);
            //    if (!File.Exists(str))  
            //    {  
            //        File.Copy(file , str);  
            //    }
            //}
        }

        private void Fill_Files()
        {
            dgvItemRow = 0;
            dgvFiles.Rows.Clear();
            DataSet ds = new DataSet();
            objPC.FormId = objQL.SP_FormMaster_Get_FormId();
            objPC.TableId = TableId;
            ds = objQL.SP_UploadDocuments_Select();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dgvFiles.Rows.Add();
                    dgvFiles.Rows[dgvItemRow].Cells["clmDocumentName"].Value = ds.Tables[0].Rows[i]["Document Name"].ToString();
                    dgvFiles.Rows[dgvItemRow].Cells["clmDocumentPath"].Value = ds.Tables[0].Rows[i]["DocumentPath"].ToString();
                    dgvFiles.Rows[dgvItemRow].Cells["clmFileName"].Value = ds.Tables[0].Rows[i]["DocumentName"].ToString();
                    dgvFiles.Rows[dgvItemRow].Cells["clmView"].Value = "View";

                    
                    dgvFiles.Rows[dgvItemRow].Cells["clmDelete"].Value = "Delete";

                    if (objPC.FormNameProfile == "Profile")
                        dgvFiles.Columns["clmDelete"].Visible = false;

                    //dgvFiles.Rows[dgvItemRow].Cells["clmFlag"].Value = "1";
                    dgvFiles.Rows[dgvItemRow].Cells["clmId"].Value = ds.Tables[0].Rows[i]["UploadDocumentId"].ToString();
                    dgvItemRow++;
                    SrNo_Add();
                }
            }
        }

        static int dgvItemRow;
        int FlagValue = 0;
        
        private void AddFiles()
        {
            objPC.UploadDocumentId = 0;
            objPC.FormId = objQL.SP_FormMaster_Get_FormId();
            objPC.TableId = TableId;
            objPC.DocumentId = Convert.ToInt32(cmbDocumentName.SelectedValue);

            if (!objQL.SP_UploadDocuments_CheckExist())
            {
                FilePathMain = SourcePath;
                CopyPasteFile();

                objPC.EntryDate = dtpDate.Value;
                objPC.DocumentPath = DestinationPath;
                objPC.DocumentName = txtFileName.Text;
                objPC.DeleteFlag = false;
                objPC.UploadDocumentId = 0;
                int R = objQL.SP_UploadDocuments_Save();

                if (R > 0)
                {
                    Fill_Files();
                    ClearAll();
                }
                ////dgvFiles.Rows.Clear();
                //dgvItemRow = dgvFiles.Rows.Count;

                //dgvFiles.Rows.Add();
                //dgvFiles.Rows[dgvItemRow].Cells["clmDocumentName"].Value = cmbDocumentName.Text.ToString();
                //dgvFiles.Rows[dgvItemRow].Cells["clmFileName"].Value = txtFileName.Text;
                //dgvFiles.Rows[dgvItemRow].Cells["clmDocumentPath"].Value = SourcePath;
                //dgvFiles.Rows[dgvItemRow].Cells["clmView"].Value = "View";
                //dgvFiles.Rows[dgvItemRow].Cells["clmDelete"].Value = "Delete";

                //FlagValue = 0;

                //dgvFiles.Rows[dgvItemRow].Cells["clmFlag"].Value = FlagValue.ToString();

                //FileNameInsert = string.Empty;
                //FilePathInsert = string.Empty;

                //if (!string.IsNullOrEmpty(Convert.ToString(dgvFiles.Rows[dgvItemRow].Cells["clmFileName"].Value)))
                //    FileNameInsert = Convert.ToString(dgvFiles.Rows[dgvItemRow].Cells["clmFileName"].Value.ToString());
                //if (!string.IsNullOrEmpty(Convert.ToString(dgvFiles.Rows[dgvItemRow].Cells["clmFlag"].Value)))
                //    FlagValue = Convert.ToInt32(dgvFiles.Rows[dgvItemRow].Cells["clmFlag"].Value.ToString());

                //if (!string.IsNullOrEmpty(Convert.ToString(dgvFiles.Rows[dgvItemRow].Cells["clmDocumentPath"].Value)))
                //{
                //    if (FlagValue == 0)
                //    {
                //        FilePathMain = Convert.ToString(dgvFiles.Rows[dgvItemRow].Cells["clmDocumentPath"].Value.ToString());
                //        CopyPasteFile();
                //    }
                //    else
                //        DestinationPath = Convert.ToString(dgvFiles.Rows[dgvItemRow].Cells["clmDocumentPath"].Value);
                //}
                
                //dgvItemRow++;
                //SrNo_Add();
            }
            else
            {
                objRL.ShowMessage(12, 4);
                return;
            }
        }

        private void SrNo_Add()
        {
            if (dgvFiles.Rows.Count > 0)
            {
                int SrNo = 1;
                for (int i = 0; i < dgvFiles.Rows.Count; i++)
                {
                    dgvFiles.Rows[i].Cells["clmSrNo"].Value = SrNo.ToString();
                    SrNo++;
                }
            }
            lblTotalItemCount.Text = "Total Item Count: " + dgvFiles.Rows.Count.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgvFiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvFiles.CurrentCell.ColumnIndex == 5)
                {
                    DialogResult dr;
                    dr = objRL.Delete_Record_Show_Message();
                    if (dr == DialogResult.Yes)
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(dgvFiles.Rows[e.RowIndex].Cells["clmId"].Value)))
                        {
                            objPC.DeleteFlag = true;
                            objPC.UploadDocumentId = Convert.ToInt32(dgvFiles.Rows[e.RowIndex].Cells["clmId"].Value);
                            //DestinationPath = dgvFiles.Rows[e.RowIndex].Cells["clmDocumentPath"].Value.ToString();
                            FileName = dgvFiles.Rows[e.RowIndex].Cells["clmFileName"].Value.ToString();

                            DestinationPath = objRL.GetPath_DocumentsMain(TableId);
                            FilePathInsert = DestinationPath + FileName;

                            int R = objQL.SP_UploadDocuments_Save();

                            if (R > 0)
                            {
                                string[] files = Directory.GetFiles(DestinationPath);
                                    foreach (string file in files)
                                    {
                                        if (file == FilePathInsert)
                                            File.Delete(file);
                                    }
                                 
                                Fill_Files();
                                objRL.ShowMessage(9, 1);
                                ClearAll();
                            }
                        }
                    }
                }

                if (dgvFiles.CurrentCell.ColumnIndex == 4)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(dgvFiles.Rows[e.RowIndex].Cells["clmFileName"].Value)))
                    {
                        DestinationPath = Convert.ToString(dgvFiles.Rows[e.RowIndex].Cells["clmDocumentPath"].Value.ToString());
                        FileName = Convert.ToString(dgvFiles.Rows[e.RowIndex].Cells["clmFileName"].Value.ToString());


                        //DestinationPath = DestinationPath  + FileName;
                        DestinationPath = objRL.GetPath_DocumentsMain(TableId) + FileName;
                        System.Diagnostics.Process.Start(DestinationPath);
                    }
                }
            }
            catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
            finally { GC.Collect(); }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void btnAddDocuments_Click(object sender, EventArgs e)
        {
            DocumentsMaster objForm = new DocumentsMaster();
            objForm.ShowDialog(this);
            objQL.SP_DocumentMaster_Select_ComboBox(cmbDocumentName);
        }
    }
}
