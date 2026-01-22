using HalliburtonRFQ.Common;
using HalliburtonRFQ.DAL;
using NestedDatagridview;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HalliburtonRFQ
{
    public partial class RequestApproval : Form
    {

        protected Microsoft.Office.Interop.Outlook.Application App;
        DAL_CreateRequest objDAL_Createrequest = new DAL_CreateRequest();
        MasterControl masterDetail;
        ScreenResolutionResize _form_resize;
        CommonDetails objCommonDetails = new CommonDetails();
        public RequestApproval(Microsoft.Office.Interop.Outlook.Application _app)
        {
            App = _app;
            InitializeComponent();
            _form_resize = new ScreenResolutionResize(this);
            this.Load += _Load;
            this.Resize += _Resize;
        }
        private void SetLableProperty()
        {
            List<Label> lstLable = new List<Label>();
            
            lstLable.Add(lblComment);

            objCommonDetails.LableProperty(lstLable, rbnSend);
        }
        private void _Load(object sender, EventArgs e)
        {
            _form_resize._get_initial_size();
        }

        private void _Resize(object sender, EventArgs e)
        {
            _form_resize._resize();
        }


        private void RequestApproval_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                RequestApproval objRequestApproval = new RequestApproval(null);
                if ((objRequestApproval = (RequestApproval)IsFormAlreadyOpen(typeof(RequestApproval))) != null)
                {
                    objRequestApproval.Dispose();
                }
            }
            catch
            {

            }
        }

        public static Form IsFormAlreadyOpen(Type FormType)
        {

            foreach (Form OpenForm in Application.OpenForms)
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



        private void LoadPendingRequestPartNumber()
        {

            try
            {
                pnlRequest.Controls.Clear();
               
                DataSet dsRequest = new DataSet();
               
                    dsRequest = objDAL_Createrequest.FetchPendingRequest();
               
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
                    masterDetail.ReadOnly = false;

                    masterDetail.Columns["ReqNumber"].ReadOnly = true;
                    masterDetail.Columns["RequestorName"].ReadOnly = true;
                    masterDetail.Columns["RequestDate"].ReadOnly = true;
                    masterDetail.Columns["RequestorMail"].ReadOnly = true;
                    masterDetail.Columns["Status"].ReadOnly = true;

                    masterDetail.Dock = DockStyle.Fill;
                    masterDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    if (masterDetail.Rows.Count > 0 && masterDetail.Columns.Count > 0)
                    {
                        foreach (DataGridViewRow dgvrow in masterDetail.Rows)
                        {
                            if (Convert.ToString(dgvrow.Cells["Status"].Value) == "Pending")// Or your condition 
                            {
                                dgvrow.Cells["Status"].Style.BackColor = Color.Yellow;
                                dgvrow.Cells["Select"].ReadOnly = false;

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

                    if (dsRequest.Tables[0].Rows.Count == 0)
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
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void RequestApproval_Load(object sender, EventArgs e)
        {
            try
            {
                LoadPendingRequestPartNumber();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbtnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                Requestupdate(2);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string Requestupdate(int intStatus)
        {
            string strStatus = string.Empty;
            DataSet dsRequest = new DataSet();
            try
            {
                string strUserName = string.Empty;
                Microsoft.Office.Interop.Outlook.Application application = new Microsoft.Office.Interop.Outlook.Application();
                
                Microsoft.Office.Interop.Outlook.Accounts accounts = application.Session.Accounts;


                foreach (Microsoft.Office.Interop.Outlook.Account account in accounts)
                {

                    strUserName = account.UserName;
                }

                masterDetail.EndEdit();
                DataTable dtRequest = new DataTable();
                dtRequest.Columns.AddRange(new DataColumn[2] { new DataColumn("ReqID", typeof(Int64)),

                            new DataColumn("Status",typeof(int)) });

                foreach (DataGridViewRow row in masterDetail.Rows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells["Select"].Value);
                    if (isSelected)
                    {

                        dtRequest.Rows.Add(Convert.ToInt64(row.Cells["ReqID"].Value), intStatus);
                    }
                }


                if (dtRequest.Rows.Count==0)
                {
                    MessageBox.Show("Please Choose atleast one to Approve/Reject", "Select", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return strStatus;
                }
                else if (intStatus == 3)
                {
                    if(string.IsNullOrEmpty(txtComments.Text)==true)
                    {
                        MessageBox.Show("Please Enter Comments", "Reject Reason", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return strStatus;
                    }
                    dsRequest = objDAL_Createrequest.RequestUpdate(strUserName,txtComments.Text, intStatus, dtRequest);
                }
                else
                {
                    dsRequest = objDAL_Createrequest.RequestUpdate(strUserName, txtComments.Text, intStatus, dtRequest);

                }

                if(dsRequest.Tables.Count>0)
                {
                    MessageBox.Show(Convert.ToString(dsRequest.Tables[0].Rows[0]["Status"]), "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPendingRequestPartNumber();
                }

            }
            catch (Exception)
            {

                throw;
            }
            return strStatus;
        }

        private void rbtnReject_Click(object sender, EventArgs e)
        {
            try
            {
                Requestupdate(3);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
