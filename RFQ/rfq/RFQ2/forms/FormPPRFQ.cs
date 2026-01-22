using RFQ2.DB;
using RFQ2.Global;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFQ2.forms
{
    public partial class FormPPRFQ : Form
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public FormPPRFQ()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            loadMaterialNumber();
        }

        // where [SAP Material Number] = @MATL_NBR and[RFQ refer]=@RFQ_REF_NBR and[Vendor ID] = @VENDOR_ID";
        private void loadDataGrid()
        {

            String SQL = "select [ID],[RFQ_Refer],[OrderedPart],[Vendor_ID],[UOM] ,[Conversion_Qty],[Country_Of_Origin],[LeadTime] ,[Quotation] " +
                ",[Currency],[Price_Break_1],[Price_Break_2] ,[Price_Break_3] ,[Price_Break_4],[Price_Break_5] ,[Price_Break_10] " +
                ",[Price_Break_25],[Price_Break_50] ,[Price_Break_100] ,[Status],[Remarks],[CreatedDate] ,[ModifiedDate] " +
                " from tbl_PP_RFQ_Liner";


            using (SqlConnection sqlCon = new SqlConnection(MYGlobal.getCString()))
            {
                sqlCon.Open();

                String matlNbr = "";
                String rfqRef = "";
                String vendorId = "";

                matlNbr = (String)cboMatlNbr.Text;
                rfqRef = (String)cboRfqRefNbr.Text;
                vendorId = (String)cboVendorId.Text;

                log.Info("matlNbr=" + matlNbr + ", rfqRef=" + ", vendorId=" + vendorId);

                if (matlNbr.Length > 0)
                {
                    if (SQL.Contains(" where "))
                    {
                        SQL = SQL + " and OrderedPart='" + matlNbr + "'";
                    }
                    else
                    {
                        SQL = SQL + " where OrderedPart='" + matlNbr + "'";
                    }
                }

                if (rfqRef.Length > 0)
                {
                    if (SQL.Contains(" where "))
                    {
                        SQL = SQL + " and RFQ_Refer='" + rfqRef + "'";
                    }
                    else
                    {
                        SQL = SQL + " where RFQ_Refer='" + rfqRef + "'";
                    }
                }

                if (vendorId.Length > 0)
                {
                    if (SQL.Contains(" where "))
                    {
                        SQL = SQL + " and Vendor_ID='" + vendorId + "'";
                    }
                    else
                    {
                        SQL = SQL + " where Vendor_ID='" + vendorId + "'";
                    }
                }



                //  SQL = SQL + " where [SAP Material Number]='"+ matlNbr + "' and [RFQ refer]='"+rfqRef + "' and [Vendor ID]='"+ vendorId+"'";

                log.Info("SQL = " + SQL);

                using (SqlDataAdapter sqlDa = new SqlDataAdapter(SQL, sqlCon))
                {
                    //using data table
                    DataTable dt = new DataTable();
                    sqlDa.Fill(dt);
                    dgvMaster.DataSource = dt;
                    dgvMaster.Cursor = Cursors.Default;

                    int rowscount = dgvMaster.Rows.Count;
                    lblTotalRows.Text = "Rows:" + (rowscount - 1);
                    for (int i = 0; i < rowscount; i++)
                    {

                    }
                }

            }
        }


        private void loadMaterialNumber()
        {
            ArrayList al = DBUtils.getAllMaterials(MYGlobal.TYPE_PP);
            cboMatlNbr.Items.Clear();
            cboMatlNbr.Items.AddRange(al.ToArray());
        }

        private void loadRFQRef()
        {
            cboRfqRefNbr.Text = "";
            cboRfqRefNbr.Items.Clear();

            //also clear vendor
            cboVendorId.Text = "";
            cboVendorId.Items.Clear();


            String mnum = (String)cboMatlNbr.SelectedItem;
            log.Info("Selected material num:" + mnum);
            ArrayList al = DBUtils.getAllRFQRef(MYGlobal.TYPE_PP, mnum);
            if (al.Count > 0)
            {
                log.Info("got total Ref :" + al.Count);
                cboRfqRefNbr.Items.AddRange(al.ToArray());
            }


        }

        private void loadVendor()
        {
            cboVendorId.Text = "";
            cboVendorId.Items.Clear();


            String mnum = (String)cboMatlNbr.SelectedItem;
            log.Info("Selected material num:" + mnum);

            String rfqRef = (String)cboRfqRefNbr.SelectedItem;
            log.Info("Selected rfq ref:" + rfqRef);

            ArrayList al = DBUtils.getAllVendor(MYGlobal.TYPE_PP, mnum, rfqRef);
            if (al.Count > 0)
            {
                log.Info("gotvendor :" + al.Count);
                cboVendorId.Items.AddRange(al.ToArray());
            }

        }


        private void cboMatlNbr_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadRFQRef();
        }

        private void cboRfqRefNbr_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadVendor();
        }

        private void cboVendorId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddNewLine_Click(object sender, EventArgs e)
        {

        }

        private void doCellValChanged(DataGridViewCellEventArgs e)
        {
            if (dgvMaster.CurrentRow != null)
            {
                DataGridViewRow dgvRow = dgvMaster.CurrentRow;
                int col_index = e.ColumnIndex;
                int row_index = e.RowIndex;

                DataGridViewCell c_cell = dgvMaster.CurrentCell;

                using (SqlConnection sqlCon = new SqlConnection(MYGlobal.getCString()))
                {
                    sqlCon.Open();

                    SqlCommand sqlcmd = new SqlCommand("[SP_UPD_PP_RFQ_LINER]", sqlCon);
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;

                        try
                        {
                            log.Info("doCellValChanged ");
                            if (dgvRow.Cells["dgID"].Value == DBNull.Value)
                            {
                                //do nothing insert, its auto gen
                                sqlcmd.Parameters.AddWithValue("@ID", 0);

                            }
                            else
                            {
                                sqlcmd.Parameters.AddWithValue("@ID", Convert.ToInt32(dgvRow.Cells["dgID"].Value == DBNull.Value ? "" : dgvRow.Cells["dgID"].Value.ToString()));
                            }

                             sqlcmd.Parameters.AddWithValue("@UOM", dgvRow.Cells["dgUOM"].Value == DBNull.Value ? null : dgvRow.Cells["dgUOM"].Value.ToString());
                                                     
                            sqlcmd.Parameters.AddWithValue("@CQTY", dgvRow.Cells["dgConversion_Qty"].Value == DBNull.Value ? null : dgvRow.Cells["dgConversion_Qty"].Value.ToString());
                            sqlcmd.Parameters.AddWithValue("@CO", dgvRow.Cells["dgCOrgin"].Value == DBNull.Value ? null : dgvRow.Cells["dgCOrgin"].Value.ToString());
                            sqlcmd.Parameters.AddWithValue("@LTIME", dgvRow.Cells["dgLeadTime"].Value == DBNull.Value ? null : dgvRow.Cells["dgLeadTime"].Value.ToString());
                            sqlcmd.Parameters.AddWithValue("@QUOTE", dgvRow.Cells["dgVendorQuote"].Value == DBNull.Value ? null : dgvRow.Cells["dgVendorQuote"].Value.ToString());
                            sqlcmd.Parameters.AddWithValue("@CURRENCY", dgvRow.Cells["dgCurrency"].Value == DBNull.Value ? null : dgvRow.Cells["dgCurrency"].Value.ToString());

                           /* if (dgvRow.Cells["dgRFQRef"].Value != DBNull.Value)
                            {
                                sqlcmd.Parameters.AddWithValue("@RFQ_Refer", (dgvRow.Cells["dgRFQRef"].Value.ToString()));
                            }

                            if (dgvRow.Cells["dgSAPMatl"].Value != DBNull.Value)
                            {
                                sqlcmd.Parameters.AddWithValue("@OrderedPart", (dgvRow.Cells["dgSAPMatl"].Value.ToString()));
                            }

                            if (dgvRow.Cells["dgVendorId"].Value != DBNull.Value)
                            {
                                sqlcmd.Parameters.AddWithValue("@Vendor_ID", (dgvRow.Cells["dgVendorId"].Value.ToString()));
                            }*/
                                                        

                            if (dgvRow.Cells["dgPrice_Break_1"].Value != DBNull.Value)
                            {
                                sqlcmd.Parameters.AddWithValue("@PB1", Convert.ToDecimal(dgvRow.Cells["dgPrice_Break_1"].Value.ToString()));
                            }

                            if (dgvRow.Cells["dgPrice_Break_2"].Value != DBNull.Value)
                            {
                                sqlcmd.Parameters.AddWithValue("@PB2", Convert.ToDecimal(dgvRow.Cells["dgPrice_Break_2"].Value.ToString()));
                            }

                            if (dgvRow.Cells["dgPrice_Break_3"].Value != DBNull.Value)
                            {
                                sqlcmd.Parameters.AddWithValue("@PB3", Convert.ToDecimal(dgvRow.Cells["dgPrice_Break_3"].Value.ToString()));
                            }

                            if (dgvRow.Cells["dgPrice_Break_4"].Value != DBNull.Value)
                            {
                                sqlcmd.Parameters.AddWithValue("@PB4", Convert.ToDecimal(dgvRow.Cells["dgPrice_Break_4"].Value.ToString()));
                            }

                            if (dgvRow.Cells["dgPrice_Break_5"].Value != DBNull.Value)
                            {
                                sqlcmd.Parameters.AddWithValue("@PB5", Convert.ToDecimal(dgvRow.Cells["dgPrice_Break_5"].Value.ToString()));
                            }

                            
                            if (dgvRow.Cells["dgPrice_Break_10"].Value != DBNull.Value)
                            {
                                sqlcmd.Parameters.AddWithValue("@PB10", Convert.ToDecimal(dgvRow.Cells["dgPrice_Break_10"].Value.ToString()));
                            }

                            if (dgvRow.Cells["dgPrice_Break_25"].Value != DBNull.Value)
                            {
                                sqlcmd.Parameters.AddWithValue("@PB25", Convert.ToDecimal(dgvRow.Cells["dgPrice_Break_25"].Value.ToString()));
                            }

                            if (dgvRow.Cells["dgPrice_Break_50"].Value != DBNull.Value)
                            {
                                sqlcmd.Parameters.AddWithValue("@PB50", Convert.ToDecimal(dgvRow.Cells["dgPrice_Break_50"].Value.ToString()));
                            }

                            if (dgvRow.Cells["dgPrice_Break_100"].Value != DBNull.Value)
                            {
                                sqlcmd.Parameters.AddWithValue("@PB100", Convert.ToDecimal(dgvRow.Cells["dgPrice_Break_100"].Value.ToString()));
                            }

                            sqlcmd.Parameters.AddWithValue("@REM", dgvRow.Cells["dgRemarks"].Value == DBNull.Value ? "" : dgvRow.Cells["dgRemarks"].Value.ToString());
                             sqlcmd.Parameters.AddWithValue("@MDATE", DateTime.Now);


                            //======== DONE =============
                            int rows = sqlcmd.ExecuteNonQuery();

                            log.Info("Affected rows = " + rows);

                            //close sqlcmd
                            sqlcmd.Dispose();
                            //========================


                            loadDataGrid();

                            //settin it in the same cell after saving
                            dgvMaster.CurrentCell = dgvMaster.Rows[row_index].Cells[col_index];
                        }
                        catch (Exception ex)
                        {
                            log.Error("errpr " + ex.Message);
                            MessageBox.Show("errpr " + ex.Message);
                        }

                    }

                }

            }
        }

        private void dgvMaster_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            doCellValChanged(e);
        }

        private void pbSearch_Click(object sender, EventArgs e)
        {
            loadDataGrid();
        }

        private void FormPPRFQ_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Parent = null;
            e.Cancel = true;
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            MYGlobal.export2Excel(dgvMaster, "TKPP RFQ");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void pbAddNew_Click(object sender, EventArgs e)
        {
            FormAddPPRfq frm = new FormAddPPRfq("PP");
            frm.ShowDialog();

            loadMaterialNumber();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lblId.Text.Length < 1)
            {
                MessageBox.Show("Please select a material to delete.");
                return;
            } 

            DialogResult res = MessageBox.Show("Are you sure to delete the selected row ? ", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {

                bool bb = DBUtils.doDeletePP(Convert.ToInt32(lblId.Text));
                if (bb)
                {
                    MessageBox.Show("Deleted successfully ");
                    cboMatlNbr.Text = "";
                    loadMaterialNumber();
                    //loadDataGrid();
                   dgvMaster.DataSource = null;

                    dgvMaster.Rows.Clear();
                    return;
                }
                else
                {
                    MessageBox.Show("Delete failed. ");
                    return;
                }
            }
        }

        private void masterRowClick()
        {
            DataGridViewRow dgvRow = dgvMaster.CurrentRow;

            int id = 0;

            if (dgvRow.Cells["dgID"].Value != DBNull.Value)
            {
                id = (int)dgvRow.Cells["dgID"].Value;
            }

            lblId.Text = "" + id;


        }

        private void dgvMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            masterRowClick();
        }
    }
}
