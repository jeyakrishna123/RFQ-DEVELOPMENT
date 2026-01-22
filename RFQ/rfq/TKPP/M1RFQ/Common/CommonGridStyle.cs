using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalliburtonRFQ.Common
{
 public   class CommonGridStyle
    {


        //-----------------------------------------------------------------
        ///   Method Name:    GetCellStyle
        ///   Description:    TO APPLY GRIDVIEW STYLE
        ///   Author:        PRAKASH                    Date: 25-06-2019
        ///   Notes:          <Notes>
        ///   Revision History:
        ///   Name:           Date:        Description:

        ///-----------------------------------------------------------------
        public DataGridViewCellStyle GetCellStyle(string StyleType)
        {
            System.Windows.Forms.DataGridViewCellStyle AppliedgridCellStyle = new DataGridViewCellStyle();
            try
            {
                if (StyleType == "ColumnHeadersDefaultCellStyle")
                {
                    System.Windows.Forms.DataGridViewCellStyle gridCellStyle = new System.Windows.Forms.DataGridViewCellStyle()
                    {
                        Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft,
                        BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(79)), System.Convert.ToInt32(System.Convert.ToByte(129)), System.Convert.ToInt32(System.Convert.ToByte(189))),
                        Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0)),
                        ForeColor = System.Drawing.SystemColors.ControlLightLight,
                        SelectionBackColor = System.Drawing.SystemColors.Highlight,
                        SelectionForeColor = System.Drawing.SystemColors.HighlightText,
                        WrapMode = System.Windows.Forms.DataGridViewTriState.True
                    };

                    AppliedgridCellStyle = gridCellStyle;
                }
                else if (StyleType == "DefaultCellStyle")
                {
                    System.Windows.Forms.DataGridViewCellStyle gridCellStyle = new System.Windows.Forms.DataGridViewCellStyle()
                    {
                        Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft,
                        BackColor = System.Drawing.SystemColors.ControlLightLight,
                        Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0)),
                        ForeColor = System.Drawing.SystemColors.ControlText,
                        SelectionBackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(155)), System.Convert.ToInt32(System.Convert.ToByte(187)), System.Convert.ToInt32(System.Convert.ToByte(89))),
                        SelectionForeColor = System.Drawing.SystemColors.HighlightText,
                        WrapMode = System.Windows.Forms.DataGridViewTriState.False
                    };

                    AppliedgridCellStyle = gridCellStyle;
                }
                else if (StyleType == "RowHeadersDefaultCellStyle")
                {
                    System.Windows.Forms.DataGridViewCellStyle gridCellStyle = new System.Windows.Forms.DataGridViewCellStyle()
                    {
                        Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft,
                        BackColor = System.Drawing.Color.Lavender,
                        Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0)),
                        ForeColor = System.Drawing.SystemColors.WindowText,
                        SelectionBackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(155)), System.Convert.ToInt32(System.Convert.ToByte(187)), System.Convert.ToInt32(System.Convert.ToByte(89))),
                        SelectionForeColor = System.Drawing.SystemColors.HighlightText,
                        WrapMode = System.Windows.Forms.DataGridViewTriState.True
                    };

                    AppliedgridCellStyle = gridCellStyle;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return AppliedgridCellStyle;
        }

        public void ApplyGridStyle(DataGridView DataGridView)
        {
            try
            {
               
                DataGridView.EnableHeadersVisualStyles = false;
                DataGridView.ColumnHeadersHeight = 25;
                DataGridView.GridColor = System.Drawing.SystemColors.GradientInactiveCaption;
                DataGridView.ColumnHeadersDefaultCellStyle = GetCellStyle("ColumnHeadersDefaultCellStyle");
                DataGridView.DefaultCellStyle = GetCellStyle("DefaultCellStyle");
                DataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
                DataGridView.RowHeadersDefaultCellStyle = GetCellStyle("RowHeadersDefaultCellStyle");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
