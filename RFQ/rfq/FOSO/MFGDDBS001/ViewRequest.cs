using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;
using NestedDatagridview;
using HalliburtonRFQ.DAL;
using HalliburtonRFQ.Common;
/**
 * Not in use
 */
namespace HalliburtonRFQ
{
    public partial class ViewRequest : Form
    {
        protected Microsoft.Office.Interop.Outlook.Application App;
        DAL_CreateRequest objDAL_Createrequest = new DAL_CreateRequest();
        ScreenResolutionResize _form_resize;
        CommonDetails objCommonDetails = new CommonDetails();
        public ViewRequest(Microsoft.Office.Interop.Outlook.Application _app)
        {
            App = _app;
            InitializeComponent();
            _form_resize = new ScreenResolutionResize(this);
            this.Load += _Load;
            this.Resize += _Resize;
            SetLableProperty();

            chkAll.BackColor = System.Drawing.Color.Transparent;
            chkAll.Parent = ribbon1;

        }

        private void SetLableProperty()
        {
            List<Label> lstLable = new List<Label>();
            lstLable.Add(lblFrom);
            lstLable.Add(lblTo);
            lstLable.Add(lblStatus);


            objCommonDetails.LableProperty(lstLable, ribbon1);
        }

        #region Screen Resolution Setting
        private void _Load(object sender, EventArgs e)
        {
            _form_resize._get_initial_size();
        }

        private void _Resize(object sender, EventArgs e)
        {
            _form_resize._resize();
        }
        #endregion

        private void ViewRequest_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ViewRequest objViewRequest = new ViewRequest(null);
                if ((objViewRequest = (ViewRequest)IsFormAlreadyOpen(typeof(ViewRequest))) != null)
                {
                    objViewRequest.Dispose();
                }
            }
            catch
            {

            }
        }

        public static Form IsFormAlreadyOpen(Type FormType)
        {

            foreach (Form OpenForm in System.Windows.Forms.Application.OpenForms)
            {
                if (OpenForm.GetType() == FormType)
                    return OpenForm;
            }
            return null;

        }

        private void rbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                
                LoadRequest();
                
            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if(chkAll.Checked)
                {
                    dtpFrom.Enabled = false;
                    dtpTo.Enabled = false;
                    cbStatus.Enabled = false;
                }
                else
                {
                    dtpFrom.Enabled = true;
                    dtpTo.Enabled = true;
                    cbStatus.Enabled = true;
                }
            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewRequest_Load(object sender, EventArgs e)
        {
            try
            {
                chkAll.Checked = true;
                FetchStatus();
                LoadRequest();
            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
        }

        private void LoadRequest()
        {
            try
            {
                pnlRequest.Controls.Clear();
                MasterControl masterDetail;
                DataSet dsRequest = new DataSet();
                if (chkAll.Checked)
                {
                    dsRequest = objDAL_Createrequest.LoadRequestPartNumber(null, null, null,null);
                }
                else
                {
                    dsRequest = objDAL_Createrequest.LoadRequestPartNumber(null, dtpFrom.Value, dtpTo.Value,cbStatus.SelectedValue.ToString());

                }


                if (dsRequest.Tables.Count > 1)
                {
                    DataRelation relBookingMNI;
                    relBookingMNI = new DataRelation("tblRequestHeaderTotblRequestLiner", dsRequest.Tables[0].Columns["ReqID"], dsRequest.Tables[1].Columns["ReqID"]);
                    dsRequest.Relations.Add(relBookingMNI);
                    masterDetail = new MasterControl(ref dsRequest);
                    pnlRequest.Controls.Add(masterDetail);

                    masterDetail.setParentSource(dsRequest.Tables[0].TableName, "ReqID");
                    masterDetail.childView.Add(dsRequest.Tables[1].TableName, "Request PartNumber");

                    masterDetail.Columns["ReqID"].Visible = false;
                    masterDetail.Dock = DockStyle.Fill;
                    masterDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    if (masterDetail.Rows.Count > 0 && masterDetail.Columns.Count > 0)
                    {
                        foreach (DataGridViewRow dgvrow in masterDetail.Rows)
                        {
                            if (Convert.ToString(dgvrow.Cells["Status"].Value) == "Pending")
                            {
                                dgvrow.Cells["Status"].Style.BackColor = Color.Yellow;
                            }
                            else if (Convert.ToString(dgvrow.Cells["Status"].Value) == "Approved")
                            {
                                dgvrow.Cells["Status"].Style.BackColor = Color.Green;
                            }
                            else if (Convert.ToString(dgvrow.Cells["Status"].Value) == "Rejected")
                            {
                                dgvrow.Cells["Status"].Style.BackColor = Color.Red;
                            }
                        }
                    }
                            if (dsRequest.Tables[0].Rows.Count==0)
                    {
                        Label lblStatus = new Label();
                        lblStatus.Text = "No Records Found";
                        lblStatus.Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
                        lblStatus.AutoSize = true;
                        lblStatus.Dock = DockStyle.Fill;
                        lblStatus.TextAlign = ContentAlignment.MiddleCenter;
                        pnlRequest.Controls.Add(lblStatus);
                    }

                }
            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }


        //-----------------------------------------------------------------
        ///   Method Name:    FetchStatus
        ///   Description:    TO BIND LIST OF STATUS
        ///   Author:        PRAKASH                    Date: 27-06-2019
        ///   Notes:          <Notes>
        ///   Revision History:
        ///   Name:           Date:        Description:

        ///-----------------------------------------------------------------
        private void FetchStatus()
        {
            try
            {
                DataSet dsStatus = new DataSet();

                dsStatus = objDAL_Createrequest.FetchStatus();
                if (dsStatus.Tables.Count > 0)
                {
                    DataRow row = dsStatus.Tables[0].NewRow();
                    row["StatusName"] = "All";
                    dsStatus.Tables[0].Rows.InsertAt(row, 0);
                    cbStatus.DataSource = dsStatus.Tables[0];
                    cbStatus.DisplayMember = "StatusName";
                    cbStatus.ValueMember = "ID";

                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
