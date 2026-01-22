using HalliburtonRFQ.Common;
using HalliburtonRFQ.DAL;
using NestedDatagridview;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HalliburtonRFQ
{
    public partial class RequestPart : Form
    {


        protected Microsoft.Office.Interop.Outlook.Application App;

        CommonGridStyle obCommonGridStyle = new CommonGridStyle();
        ScreenResolutionResize _form_resize;
        DAL_CreateRequest objDAL_Createrequest = new DAL_CreateRequest();
        CommonDetails objCommonDetails = new CommonDetails();
        DataTable dtDefault = new DataTable();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RequestPart));

        public RequestPart(Microsoft.Office.Interop.Outlook.Application _app)
        {
            App = _app;
            InitializeComponent();

           
            LoadDefault();
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
        private void LoadDefault()
        {
            DataTable dtRequest = new DataTable();
            dtRequest.Columns.AddRange(new DataColumn[3] { new DataColumn("SNo", typeof(string)),
                            new DataColumn("PartNumber", typeof(string)),
                            new DataColumn("Qty",typeof(int)) });
           

            dgvPartNumber.DataSource = dtRequest;

            obCommonGridStyle.ApplyGridStyle(dgvPartNumber);


            DataGridViewImageColumn dgvdelbut = new DataGridViewImageColumn();
            dgvdelbut.Image = ((System.Drawing.Image)(resources.GetObject("DeleteImage.Image"))); 
            dgvdelbut.Width = 20;

            dgvdelbut.HeaderText = "Action";
            dgvdelbut.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPartNumber.Columns.Add(dgvdelbut);
        }
        private void _Load(object sender, EventArgs e)
        {
            _form_resize._get_initial_size();
        }

        private void _Resize(object sender, EventArgs e)
        {
            _form_resize._resize();
        }
        private void RequestPart_Load(object sender, EventArgs e)
        {

            try
            {
                FetchPartNumber();
                FetchStatus();
                chkAll.Checked = true;
                LoadMyRequestPartNumber();

                dtDefault = (DataTable)dgvPartNumber.DataSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                                              

        }
       


       

        //-----------------------------------------------------------------
        ///   Method Name:    FetchPartNumber
        ///   Description:    TO BIND LIST OF PART NUMBER
        ///   Author:        PRAKASH                    Date: 20-06-2019
        ///   Notes:          <Notes>
        ///   Revision History:
        ///   Name:           Date:        Description:

        ///-----------------------------------------------------------------
        private void FetchPartNumber()
        {
            try
            {
                DataSet dsPartNumber = new DataSet();
                
                dsPartNumber = objDAL_Createrequest.FetchPartNumber();
                if (dsPartNumber.Tables.Count > 0)
                {
                    DataRow row = dsPartNumber.Tables[0].NewRow();
                    row["PartNumber"] = "<-Select PartNumber->";
                    dsPartNumber.Tables[0].Rows.InsertAt(row, 0);
                    cbPartNumber.DataSource = dsPartNumber.Tables[0];
                    cbPartNumber.DisplayMember = "PartNumber";
                    cbPartNumber.ValueMember = "PartNumber";

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private void RequestPart_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                RequestPart objRequestPart = new RequestPart(null);
                if ((objRequestPart = (RequestPart)IsFormAlreadyOpen(typeof(RequestPart))) != null)
                {
                    objRequestPart.Dispose();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validate())
                {
                    
                    int intSNo = 0;
                    DataGridViewRow Dgvrow = new DataGridViewRow();
                    DataTable dtRowAdd = (DataTable)dgvPartNumber.DataSource;
                    if (dtRowAdd.Rows.Count == 0)
                    {
                        intSNo++;
                    }

                    else
                    {
                        intSNo = (dtRowAdd.Rows.Count) + 1;
                    }


                    bool bFound = false;
                    foreach (DataRow row in dtRowAdd.Rows)
                    {
                        if ((string)row["PartNumber"] == Convert.ToString(cbPartNumber.SelectedValue))
                        {
                            if (string.IsNullOrEmpty(Convert.ToString(row["Qty"])) != true)
                            {
                                int intQuantity = Convert.ToInt32(row["Qty"]) + Convert.ToInt32(txtQuantity.Text);

                                row["Qty"] = intQuantity;
                                bFound = true;
                            }
                            break;
                        }
                        
                    }
                    
                    if (!bFound)
                    {
                        dgvPartNumber.AllowUserToAddRows = true;
                        dtRowAdd.Rows.Add(intSNo.ToString(), Convert.ToString(cbPartNumber.SelectedValue), Convert.ToInt32(txtQuantity.Text));
                        dgvPartNumber.AllowUserToAddRows = false;
                    }
                    
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void rbtnNew_Click(object sender, EventArgs e)
        {
            try
            {
                txtQuantity.Text = "";
                dgvPartNumber.DataSource = dtDefault;

                cbPartNumber.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPartNumber_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
              
                if (e.ColumnIndex == 0)
                {
                    
                    DataTable dtRowAdd = (DataTable)dgvPartNumber.DataSource;

                    dtRowAdd.Rows.RemoveAt(dgvPartNumber.CurrentRow.Index);


                    int i = 1;
                    foreach (DataRow row in dtRowAdd.Rows)
                    {
                        row["SNO"] = i;
                        i++;
                    }
                    dgvPartNumber.DataSource = dtRowAdd;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
               
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private bool Validate()
        {
            bool IsValid = true;
            try
            {
                if(cbPartNumber.SelectedIndex==0)
                {
                    MessageBox.Show("Please Select PartNumber","Validation",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    IsValid = false;
                }
                else if(string.IsNullOrEmpty( txtQuantity.Text)==true)
                {
                    MessageBox.Show("Please Enter Quantity", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    IsValid = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return IsValid;
        }

        private void dgvPartNumber_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

               if (e.ColumnIndex < 0 || e.RowIndex < 0)
                {
                    return;
                }
                var dataGridView = (sender as DataGridView);
               
                if (e.ColumnIndex == 3)
                    dataGridView.Cursor = Cursors.Hand;
               
            }
            catch (Exception ex) 
            {

                MessageBox.Show(ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbtnRequestPart_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvPartNumber.Rows.Count>0)
                {
                    DataSet dsRequestStatus = new DataSet();
                    DataTable dtRequest = new DataTable();
                    dtRequest.Columns.AddRange(new DataColumn[3] { new DataColumn("SNo", typeof(string)),
                            new DataColumn("PartNumber", typeof(string)),
                            new DataColumn("Qty",typeof(int)) });
                    dtRequest = (DataTable)dgvPartNumber.DataSource;
                    

                    string strUserName=string.Empty, strSmtpAddress = string.Empty;
                    Microsoft.Office.Interop.Outlook.Application application = new Microsoft.Office.Interop.Outlook.Application();
                    // The Namespace Object (Session) has a collection of accounts.
                    Microsoft.Office.Interop.Outlook.Accounts accounts = application.Session.Accounts;

                   
                    foreach (Microsoft.Office.Interop.Outlook.Account account in accounts)
                    {
                        strUserName =account.UserName;
                        strSmtpAddress=account.SmtpAddress;
                    }
                    
                    dsRequestStatus= objDAL_Createrequest.RequestHeader_Save(strUserName, strSmtpAddress, dtRequest);
                    if(dsRequestStatus.Tables.Count>0)
                    {
                        MessageBox.Show(Convert.ToString(dsRequestStatus.Tables[0].Rows[0]["Status"]), "Request Status",MessageBoxButtons.OK, MessageBoxIcon.Information);

                        chkAll.Checked = true;
                        LoadMyRequestPartNumber();

                    }
                    }
                else
                {
                    MessageBox.Show("Please atleast add one PartNumber","Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMyRequestPartNumber()
        {

            try
            {
                pnlRequest.Controls.Clear();
                MasterControl masterDetail;
                DataSet dsRequest = new DataSet();
                string strSmtpAddress = string.Empty;
                Microsoft.Office.Interop.Outlook.Application application = new Microsoft.Office.Interop.Outlook.Application();
                // The Namespace Object (Session) has a collection of accounts.
                Microsoft.Office.Interop.Outlook.Accounts accounts = application.Session.Accounts;


                foreach (Microsoft.Office.Interop.Outlook.Account account in accounts)
                {

                    strSmtpAddress = account.SmtpAddress;
                }
                if (chkAll.Checked)
                {
                    dsRequest = objDAL_Createrequest.LoadRequestPartNumber(strSmtpAddress, null,null, null);
                }
                else
                {
                    dsRequest = objDAL_Createrequest.LoadRequestPartNumber(strSmtpAddress, dtpFrom.Value, dtpTo.Value, cbStatus.SelectedValue.ToString());
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
                    masterDetail.ScrollBars = ScrollBars.Both;
                    if (masterDetail.Rows.Count > 0 && masterDetail.Columns.Count > 0)
                    {
                        foreach (DataGridViewRow dgvrow in masterDetail.Rows)
                        {
                            if (Convert.ToString(dgvrow.Cells["Status"].Value) == "Pending")// Or your condition 
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
            catch (Exception ex )
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadMyRequestPartNumber();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAll.Checked)
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
    }
}
