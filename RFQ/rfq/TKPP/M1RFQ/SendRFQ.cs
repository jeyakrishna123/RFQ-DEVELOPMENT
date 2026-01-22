using HalliburtonRFQ.Common;
using HalliburtonRFQ.DAL;
using NestedDatagridview;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HalliburtonRFQ
{
    public partial class SendRFQ : Form
    {
        protected Microsoft.Office.Interop.Outlook.Application App;
        ScreenResolutionResize _form_resize;
        CommonGridStyle obCommonGridStyle = new CommonGridStyle();
        DAL_CreateRequest objDAL_Createrequest = new DAL_CreateRequest();
        MailGenerate objMailGenerate = new MailGenerate();
        MasterControl masterDetail;
        DataSet dsRequest = new DataSet();
        CommonDetails objCommonDetails = new CommonDetails();
        public SendRFQ(Microsoft.Office.Interop.Outlook.Application _app)
        {
            App = _app;
            InitializeComponent();
           
            _form_resize = new ScreenResolutionResize(this);
            this.Load += _Load;
            this.Resize += _Resize;
            obCommonGridStyle.ApplyGridStyle(dgvPartNumber);
            SetLableProperty();
        }


        private void SetLableProperty()
        {
            List<Label> lstLable = new List<Label>();
            lstLable.Add(lblApproverName);
            lstLable.Add(lblReqName);
            lstLable.Add(lblReqnumber);
            lstLable.Add(lblRequestDate);
            lstLable.Add(lblStatus);
            lstLable.Add(lblReviewDate);

            objCommonDetails.LableProperty(lstLable, ribbon1);
        }
        private void _Load(object sender, EventArgs e)
        {
            _form_resize._get_initial_size();
        }

        private void _Resize(object sender, EventArgs e)
        {
            _form_resize._resize();
        }
        private void SendRFQ_Load(object sender, EventArgs e)
        {
            try
            {
                
                LoadRequestPartNumber();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void rbtnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPartNumber.Rows.Count > 0)
                {
                    DataTable dtRFQ = new DataTable();
                    dtRFQ = (DataTable)dgvPartNumber.DataSource;

                    DataTable FilteredRFQLiner = dtRFQ;

                    string[] selectedColumns = new[] {"SNo", "PartNumber",  "Qty","Price", "ShippingDate" };

                    FilteredRFQLiner = new DataView(FilteredRFQLiner).ToTable(false, selectedColumns);

                    foreach (DataRow drVendor in dsRequest.Tables[2].Rows) // search whole table
                    {

                        DataSet dsRFQStatus = new DataSet();
                      

                        string strUserName = string.Empty, strSmtpAddress = string.Empty;
                        Microsoft.Office.Interop.Outlook.Application application = new Microsoft.Office.Interop.Outlook.Application();
                       
                        Microsoft.Office.Interop.Outlook.Accounts accounts = application.Session.Accounts;


                        foreach (Microsoft.Office.Interop.Outlook.Account account in accounts)
                        {
                            strUserName = account.UserName;
                            strSmtpAddress = account.SmtpAddress;
                        }

                        dsRFQStatus = objDAL_Createrequest.QuotationSend_Save(Convert.ToInt64(cbRequest.SelectedValue),Convert.ToInt64(drVendor["VendorID"]), strUserName, strSmtpAddress, FilteredRFQLiner);
                        if (dsRFQStatus.Tables.Count > 0)
                        {
                           
                            if (Convert.ToString(dsRFQStatus.Tables[0].Rows[0]["Status"])=="1")
                            {


                                if (string.IsNullOrEmpty(Convert.ToString(drVendor["Email"])) != true)
                                {
                                    var PartNumberlist = dtRFQ.AsEnumerable().Select(r => r.Field<string>("PartNumber")).ToArray();
                                    string strSubject = "REQUEST FOR QUOTE SUPPLIER~" + dsRFQStatus.Tables[0].Rows[0]["RFQNumber"].ToString() + " :- Part:" + string.Join(",", PartNumberlist);
                                    string strBody = objMailGenerate.GetBodyContent(dtRFQ);

                                    Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
                                    Microsoft.Office.Interop.Outlook.MailItem mailItem = (Microsoft.Office.Interop.Outlook.MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
                                    Microsoft.Office.Interop.Outlook.NameSpace oNameSpace = oApp.GetNamespace("MAPI");
                                    Microsoft.Office.Interop.Outlook.MAPIFolder oFolder = oNameSpace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderSentMail);
                                    mailItem.Subject = strSubject;
                                    mailItem.To = Convert.ToString(drVendor["Email"]);

                                    mailItem.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatHTML;
                                    //mailItem.HTMLBody = strBody;
                                    mailItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceNormal;
                                    mailItem.Display(false);
                                    /*Add default signature Start */
                                    var signature = mailItem.HTMLBody;
                                    mailItem.HTMLBody = strBody + signature;
                                    /*Add default signature End */
                                    mailItem.SaveSentMessageFolder = oFolder;                                   
                                    mailItem.Send();
                                    mailItem = null;
                                    oApp = null;
                                }

                            }

                            
                           
                        }

                        }
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        
        



        private void SendRFQ_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                SendRFQ objSendRFQ = new SendRFQ(null);
                if ((objSendRFQ = (SendRFQ)IsFormAlreadyOpen(typeof(SendRFQ))) != null)
                {
                    objSendRFQ.Dispose();
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


        private void LoadRequestPartNumber()
        {

            try
            {
               
                dsRequest = objDAL_Createrequest.LoadRequestPartNumber(null, null, null, "2");
              
                if (dsRequest.Tables.Count > 1)
                {
                    DataRow row = dsRequest.Tables[0].NewRow();
                    row["ReqNumber"] = "<--- Select --->";
                    dsRequest.Tables[0].Rows.InsertAt(row, 0);
                    cbRequest.DataSource = dsRequest.Tables[0];
                    cbRequest.DisplayMember = "ReqNumber";
                    cbRequest.ValueMember = "ReqID";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void cbRequest_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbRequest.SelectedIndex > 0)
                {

                    //Request Header Details

                    //IEnumerable<DataRow> queryRequestHeader =
                    //       from RequestHeader in dsRequest.Tables[0].AsEnumerable()
                    //       where RequestHeader.Field<Int64>("ReqID") == Convert.ToInt64(cbRequest.SelectedValue.ToString())
                    //       select RequestHeader;
                    DataRow[] queryRequestHeader = dsRequest.Tables[0].Select("ReqID="+ Convert.ToInt64(cbRequest.SelectedValue.ToString()));
                    if (queryRequestHeader.Count() > 0)
                    {
                        DataTable FilteredRequestHeader = queryRequestHeader.CopyToDataTable();

                        txtRequestDate.Text = Convert.ToString(FilteredRequestHeader.Rows[0]["RequestDate"]);
                        txtRequestorName.Text = Convert.ToString(FilteredRequestHeader.Rows[0]["RequestorName"]);
                        txtReviewedDate.Text = Convert.ToString(FilteredRequestHeader.Rows[0]["ReviewedBy"]);
                        txtApproverName.Text = Convert.ToString(FilteredRequestHeader.Rows[0]["DateOfReview"]);

                        txtStatus.Text = Convert.ToString(FilteredRequestHeader.Rows[0]["Status"]);
                    }
                    //Request Liner Details

                    IEnumerable<DataRow> queryRequestLiner =
                            from RequestLiner in dsRequest.Tables[1].AsEnumerable()
                            where RequestLiner.Field<Int64>("ReqID") == Convert.ToInt64(cbRequest.SelectedValue.ToString())
                            select RequestLiner;

                    if (queryRequestLiner.Count() > 0)
                    {
                        DataTable FilteredRequestLiner = queryRequestLiner.CopyToDataTable();

                        string[] selectedColumns = new[] { "PartNumber", "Description", "Qty" };

                        FilteredRequestLiner = new DataView(FilteredRequestLiner).ToTable(false, selectedColumns);

                        DataTable dtRequestSend = new DataTable(FilteredRequestLiner.TableName);
                        DataColumn dcSNo = new DataColumn("SNo");
                        dcSNo.AutoIncrement = true;
                        dcSNo.AutoIncrementSeed = 1;
                        dcSNo.AutoIncrementStep = 1;
                        dcSNo.DataType = typeof(Int32);
                        dtRequestSend.Columns.Add(dcSNo);

                        dtRequestSend.BeginLoadData();

                        DataTableReader dtRequestGenearate = new DataTableReader(FilteredRequestLiner);
                        dtRequestSend.Load(dtRequestGenearate);

                        dtRequestSend.EndLoadData();
                        dtRequestSend.Columns.Add("Price", typeof(long));
                        dtRequestSend.Columns.Add("ShippingDate", typeof(DateTime));
                        
                        if (dtRequestSend.Rows.Count > 0)
                        {
                            dgvPartNumber.DataSource = dtRequestSend;
                        }
                    }
            }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPartNumber_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
