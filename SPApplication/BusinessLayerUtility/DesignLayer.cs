using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BusinessLayerUtility
{
    public class DesignLayer
    {
        public Color GetBackgroundColor()
        {
            Color color = System.Drawing.ColorTranslator.FromHtml(BusinessResources.BACKGROUND_COLOUR);
            return color;
        }

        public Color GetForeColor()
        {
            Color color = System.Drawing.ColorTranslator.FromHtml(BusinessResources.FORE_COLOUR);
            return color;
        }

        public void SetButtonDesign(Button btn, string setText)
        {
            btn.BackColor = GetBackgroundColor();
            btn.ForeColor = GetForeColor();
            btn.Font = new System.Drawing.Font("Calibri", 10.00F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn.Size = new System.Drawing.Size(75, 30);
            btn.Text = setText.ToString();
        }

        public void SetButtonDesign_SmallSize(Button btn, string setText)
        {
            btn.BackColor = GetBackgroundColor();
            btn.ForeColor = GetForeColor();
            btn.Font = new System.Drawing.Font("Calibri", 10.00F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn.Size = new System.Drawing.Size(55, 23);
            btn.Text = setText.ToString();
        }

        public void SetPlusButtonDesign(Button btn)
        {
            btn.BackColor = GetBackgroundColor();
            btn.ForeColor = GetForeColor();
            // btn.Font = new System.Drawing.Font("Calibri", 10.00F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn.Size = new System.Drawing.Size(20, 20);
            btn.Text = BusinessResources.BTN_PLUS;
        }

        public void SetLabelDesign(Label lbl, string LableText)
        {
            lbl.BackColor = GetBackgroundColor();
            lbl.ForeColor = GetForeColor();
            lbl.Text = LableText.ToString();
        }

        public void SetLabelDesign_ForeColor(Label lbl, string LableText)
        {
            lbl.ForeColor = GetBackgroundColor();
            lbl.Text = LableText.ToString();
        }

        public void SetDesignMaster(Form frm, Label lbl, Button btnSave, Button btnClear, Button btnDelete, Button btnExit, string LableText)
        {
            SetLabelDesign(lbl, LableText);

            // DataGridView dgv = frm.Controls.Find("dataGridView1", true).FirstOrDefault() as  DataGridView;
            //if (dgv != null)
            //    dgv.DefaultCellStyle.SelectionBackColor = GetBackgroundColor();

            SetButtonDesign(btnSave, BusinessResources.BTN_SAVE);
            SetButtonDesign(btnClear, BusinessResources.BTN_CLEAR);
            SetButtonDesign(btnDelete, BusinessResources.BTN_DELETE);
            SetButtonDesign(btnExit, BusinessResources.BTN_EXIT);
        }

        public void SetDesign3Buttons(Form frm, Label lbl, Button btnSave, Button btnClear, Button btnExit, string LableText)
        {
            SetLabelDesign(lbl, LableText);

            //DataGridView dgv = frm.Controls.Find("dataGridView1", true).FirstOrDefault() as DataGridView;
            //if (dgv != null)
            //    dgv.DefaultCellStyle.SelectionBackColor = GetBackgroundColor();

            SetButtonDesign(btnSave, BusinessResources.BTN_SAVE);
            SetButtonDesign(btnClear, BusinessResources.BTN_CLEAR);
            SetButtonDesign(btnExit, BusinessResources.BTN_EXIT);
        }

        public void SetButtonDesign_ManualSize(Button btn, string setText)
        {
            btn.BackColor = GetBackgroundColor();
            btn.ForeColor = GetForeColor();
            btn.Font = new System.Drawing.Font("Calibri", 10.00F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //btn.Size = new System.Drawing.Size(75, 30);
            btn.Text = setText.ToString();
        }

        public void SetBackForeColour_Button(Button btn)
        {
            btn.BackColor = GetBackgroundColor();
            btn.ForeColor = GetForeColor();
        }

        public void Set_Report_Design(Form frm, Label lbl, Button btnView, Button btnReport, Button btnClear, Button btnExit, string LableText)
        {
            SetLabelDesign(lbl, LableText);
            SetButtonDesign(btnView, BusinessResources.BTN_VIEW);
            SetButtonDesign(btnReport, BusinessResources.BTN_REPORT);
            SetButtonDesign(btnClear, BusinessResources.BTN_CLEAR);
            SetButtonDesign(btnExit, BusinessResources.BTN_EXIT);
        }

        public void Set_List_Design(Label lbl, Button btnExit, ListBox lb, string LableText)
        {
            SetLabelDesign(lbl, LableText);
            lb.ForeColor = GetBackgroundColor();
            SetButtonDesign(btnExit, BusinessResources.BTN_EXIT);
        }
        public void Set_Approval_Colour(Label lbl)
        {
            var statusColorMap = new Dictionary<string, string>
            {
                { BusinessResources.LS_Pending, BusinessResources.LS_Pending_Color },
                { BusinessResources.LS_HRApproved, BusinessResources.LS_HRApproved_Color },
                { BusinessResources.LS_ManagerApproved, BusinessResources.LS_Manager_Color },
                { BusinessResources.LS_Remarks, BusinessResources.LS_Remarks_Color },
                { BusinessResources.LS_Completed, BusinessResources.LS_Completed_Color }
            };

            if (statusColorMap.TryGetValue(lbl.Text, out string colorCode))
            {
                lbl.BackColor = System.Drawing.ColorTranslator.FromHtml(colorCode);
            }
            else
            {
                lbl.BackColor = System.Drawing.Color.Gray;
            }
        }
    }
}
