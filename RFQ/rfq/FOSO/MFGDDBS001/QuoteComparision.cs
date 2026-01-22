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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalliburtonRFQ
{
    public partial class Quote_Comparision : Form
    {
        protected Microsoft.Office.Interop.Outlook.Application App;
        ScreenResolutionResize _form_resize;
        CommonGridStyle obCommonGridStyle = new CommonGridStyle();
        DAL_CreateRequest objDAL_Createrequest = new DAL_CreateRequest();
        CommonDetails objCommonDetails = new CommonDetails();
        MasterControl masterDetail;
        public Quote_Comparision(Microsoft.Office.Interop.Outlook.Application _app)
        {
            App = _app;
            InitializeComponent();

            _form_resize = new ScreenResolutionResize(this);
            this.Load += _Load;
            this.Resize += _Resize;
           
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
        private void Quote_Comparision_Load(object sender, EventArgs e)
        {
            try
            {
                LoadReceivedRFQ();
            }
            catch (Exception ex)
            {

                throw;
            }
          
        }

        private void LoadReceivedRFQ()
        {

            try
            {

             DataSet   dsReceivedRFQ = objDAL_Createrequest.FetchReceivedRFQ();

                if (dsReceivedRFQ.Tables.Count > 0)
                {
                    DataRow row = dsReceivedRFQ.Tables[0].NewRow();
                    row["ReqNumber"] = "<--- Select --->";
                    dsReceivedRFQ.Tables[0].Rows.InsertAt(row, 0);
                    cbReqnumber.DataSource = dsReceivedRFQ.Tables[0];
                    cbReqnumber.DisplayMember = "ReqNumber";
                    cbReqnumber.ValueMember = "ReqID";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void cbReqnumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet dsComparision = new DataSet();
                if (cbReqnumber.SelectedIndex > 0)
                {
                    dsComparision = objDAL_Createrequest.QuotationComparisonReport(Convert.ToInt64(cbReqnumber.SelectedValue));


                    if (dsComparision.Tables.Count > 0)
                    {
                        if (dsComparision.Tables[0].Rows.Count > 0)
                        {
                            txtRequestDate.Text = Convert.ToString(dsComparision.Tables[0].Rows[0]["RequestDate"]);
                            txtRequestorName.Text = Convert.ToString(dsComparision.Tables[0].Rows[0]["RequestorName"]);
                            txtReviewedDate.Text = Convert.ToString(dsComparision.Tables[0].Rows[0]["ReviewedBy"]);
                            txtApproverName.Text = Convert.ToString(dsComparision.Tables[0].Rows[0]["DateOfReview"]);

                            txtStatus.Text = Convert.ToString(dsComparision.Tables[0].Rows[0]["Status"]);
                        }
                        else
                        {
                            txtRequestDate.Text = "";
                            txtRequestorName.Text = "";
                            txtReviewedDate.Text = "";
                            txtApproverName.Text = "";

                            txtStatus.Text = "";
                        }


                        LoadPendingRequestPartNumber(dsComparision);



                    }
                    else
                    {
                        txtRequestDate.Text = "";
                        txtRequestorName.Text = "";
                        txtReviewedDate.Text = "";
                        txtApproverName.Text = "";

                        txtStatus.Text = "";
                        
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void LoadPendingRequestPartNumber(DataSet dsComparision)
        {

            try
            {
                pnlRequest.Controls.Clear();

            

                if (dsComparision.Tables.Count > 1)
                {
                    DataRelation relBookingMNI;
                    relBookingMNI = new DataRelation("tblRFQHeaderTotblRFQLiner", dsComparision.Tables[1].Columns["RFQID"], dsComparision.Tables[2].Columns["RFQID"]);
                    dsComparision.Relations.Add(relBookingMNI);
                    masterDetail = new MasterControl(ref dsComparision);
                    pnlRequest.Controls.Add(masterDetail);

                    masterDetail.setParentSource(dsComparision.Tables[1].TableName, "RFQID");
                    masterDetail.childView.Add(dsComparision.Tables[2].TableName, "Quotation");

                   

                    masterDetail.Dock = DockStyle.Fill;
                    masterDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                   

                    if (dsComparision.Tables[1].Rows.Count == 0)
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

        private void rbtn_Refresh_Click(object sender, EventArgs e)
        {
            try
            {
                LoadReceivedRFQ();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        

        //private void dgvComparison_DataSourceChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        double sum1 = 0.00d, sum2 = 0.00d, sum3 = 0.00d;
        //        for (int i = 0; i < dgvComparison.Rows.Count; i++)
        //        {
        //            if (dgvComparison[3, i].Value != DBNull.Value)
        //                sum1 += Convert.ToDouble(dgvComparison[3, i].Value);
        //            if (dgvComparison[4, i].Value != DBNull.Value)
        //                sum2 += Convert.ToDouble(dgvComparison[4, i].Value);
        //            if (dgvComparison[5, i].Value != DBNull.Value)
        //                sum3 += Convert.ToDouble(dgvComparison[5, i].Value);
        //        }



        //        DataTable dt = new DataTable();
        //        dt = (DataTable)dgvComparison.DataSource;
        //        dt.NewRow();
        //        dt.Rows.Add("", "Grand Total", DBNull.Value, sum1, sum2, sum3);
        //        dgvComparison.DataSource = dt;
        //        this.dgvComparison.Columns[3].DefaultCellStyle.Format = "N2";
        //        this.dgvComparison.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        //        this.dgvComparison.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        //        this.dgvComparison.Columns[4].DefaultCellStyle.Format = "N2";
        //        this.dgvComparison.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        //        this.dgvComparison.Columns[5].DefaultCellStyle.Format = "N2";
        //        this.dgvComparison.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
    }
}
