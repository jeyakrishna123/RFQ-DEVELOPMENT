using RFQ2.DB;
using RFQ2.Global;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFQ2.forms
{
    public partial class FormFOFRQ : Form
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        public FormFOFRQ()
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

            String SQL = "SELECT [ID],[SAP Material Number] as sap_matl_nbr,[RFQ refer] as reqref,[Vendor ID] as venid,[Country_Of_Origin] as co,[Order_Quantity] as qty,[Vendor Quote] as venquote" +
           ",[UOM] as uom,[Currency] as currency,[Price Scale (1-3)] as ps123,[Price Scale (4-9)] as ps429," +
           " [Price Scale (>=10)] as psgt10,[Remarks] as remarks,[LeadTime] as leadtime,[ErrorStatus] as error,[CreatedDate] as crtdate,[ModifiedDate]  as modate" +
           " FROM [tbl_FO_RFQ_Liner] ";


            using (SqlConnection sqlCon = new SqlConnection(MYGlobal.getCString()))
            {
                sqlCon.Open();

                String matlNbr = "";
                String rfqRef = "";
                String vendorId = "";

                matlNbr = (String)cboMatlNbr.Text;
                rfqRef = (String)cboRfqRefNbr.Text;
                vendorId = (String)cboVendorId.Text;

                log.Info("matlNbr="+ matlNbr + ", rfqRef="+ ", vendorId="+ vendorId);

                if (matlNbr.Length > 0)
                {
                    if(SQL.Contains(" where "))
                    {
                        SQL = SQL + " and [SAP Material Number]='" + matlNbr + "'";
                    }
                    else
                    {
                        SQL = SQL + " where [SAP Material Number]='" + matlNbr + "'";
                    }
                }

                if (rfqRef.Length > 0)
                {
                    if (SQL.Contains(" where "))
                    {
                        SQL = SQL + " and [RFQ refer]='" + rfqRef + "'";
                    }
                    else
                    {
                        SQL = SQL + " where [RFQ refer]='" + rfqRef + "'";
                    }
                }

                if (vendorId.Length > 0)
                {
                    if (SQL.Contains(" where "))
                    {
                        SQL = SQL + " and [Vendor ID]='" + vendorId + "'";
                    }
                    else
                    {
                        SQL = SQL + " where [Vendor ID]='" + vendorId + "'";
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
            ArrayList al = DBUtils.getAllMaterials(MYGlobal.TYPE_FO);
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


            String mnum = (String) cboMatlNbr.SelectedItem;
            log.Info("Selected material num:" + mnum);
            ArrayList al = DBUtils.getAllRFQRef(MYGlobal.TYPE_FO, mnum);
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

            ArrayList al = DBUtils.getAllVendor(MYGlobal.TYPE_FO, mnum, rfqRef);
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
            MYGlobal.export2Excel(dgvMaster, "FOSO RFQ");
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

                    SqlCommand sqlcmd = new SqlCommand("SP_UPD_FO_RFQ_LINER", sqlCon);
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

                            sqlcmd.Parameters.AddWithValue("@COO", dgvRow.Cells["dgCOrgin"].Value == DBNull.Value ? null : dgvRow.Cells["dgCOrgin"].Value.ToString());
                            sqlcmd.Parameters.AddWithValue("@ORD_QTY", dgvRow.Cells["dgOrdQty"].Value == DBNull.Value ? null : dgvRow.Cells["dgOrdQty"].Value.ToString());
                            sqlcmd.Parameters.AddWithValue("@VND_QOTE", dgvRow.Cells["dgVendorQuote"].Value == DBNull.Value ? null : dgvRow.Cells["dgVendorQuote"].Value.ToString());
                            sqlcmd.Parameters.AddWithValue("@UOM", dgvRow.Cells["dgUOM"].Value == DBNull.Value ? null : dgvRow.Cells["dgUOM"].Value.ToString());
                            sqlcmd.Parameters.AddWithValue("@CURRENCY", dgvRow.Cells["dgCurrency"].Value == DBNull.Value ? null : dgvRow.Cells["dgCurrency"].Value.ToString());

                            if (dgvRow.Cells["dgPS123"].Value != DBNull.Value)
                            {
                                decimal ff = (decimal)dgvRow.Cells["dgPS123"].Value;
                                log.Info("FF = " + ff);
                                sqlcmd.Parameters.AddWithValue("@PS123", ff );
                            }


                            if (dgvRow.Cells["dgPS429"].Value != DBNull.Value)
                            {
                                decimal ff = (decimal)dgvRow.Cells["dgPS429"].Value;
                                sqlcmd.Parameters.AddWithValue("@PS429", ff);
                            }

                            if (dgvRow.Cells["dgPSGt10"].Value != DBNull.Value)
                            {
                                decimal ff = (decimal)dgvRow.Cells["dgPSGt10"].Value;
                                sqlcmd.Parameters.AddWithValue("@PSGT10", ff);
                            }


                            // sqlcmd.Parameters.AddWithValue("@PS123", dgvRow.Cells["dgPS123"].Value == DBNull.Value ? null : dgvRow.Cells["dgPS123"].Value.ToString());
                            //sqlcmd.Parameters.AddWithValue("@PS429", dgvRow.Cells["dgPS429"].Value == DBNull.Value ? null : dgvRow.Cells["dgPS429"].Value.ToString());
                            //sqlcmd.Parameters.AddWithValue("@PSGT10", dgvRow.Cells["dgPSGt10"].Value == DBNull.Value ? null : dgvRow.Cells["dgPSGt10"].Value.ToString());

                            sqlcmd.Parameters.AddWithValue("@REM", dgvRow.Cells["dgRemarks"].Value == DBNull.Value ? null : dgvRow.Cells["dgRemarks"].Value.ToString());
                            sqlcmd.Parameters.AddWithValue("@LTIME", dgvRow.Cells["dgLeadTime"].Value == DBNull.Value ? null : dgvRow.Cells["dgLeadTime"].Value.ToString());
                            sqlcmd.Parameters.AddWithValue("@MOD_DATE", DateTime.Now);

                            //======== DONE =============
                            int rows = sqlcmd.ExecuteNonQuery();

                            log.Info("Affected rows = " + rows);

                            //close sqlcmd
                            sqlcmd.Dispose();
                            //========================                                                                               

                            
                        }catch(Exception ex)
                        {
                            log.Error("Error = " + ex.Message);
                            MessageBox.Show("errpr "+ex.Message);
                        }

                        loadDataGrid();
                        //settin it in the same cell after saving
                        dgvMaster.CurrentCell = dgvMaster.Rows[row_index].Cells[col_index];


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

        private void FormFOFRQ_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            foreach (Form f in Application.OpenForms)
            {
                if (f is Desktop)
                {
                    //Desktop is activated. Close it
                    f.Enabled = true;
                    f.Visible = true;
                    break;
                }
                
            }
                
            e.Cancel = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Hide();
            foreach (Form f in Application.OpenForms)
            {
                if (f is Desktop)
                {
                    //Desktop is activated. Close it
                    f.Enabled = true;
                    f.Visible = true;
                    break;
                }

            }
        }

        private void pbAddNew_Click(object sender, EventArgs e)
        {
            FormAddPPRfq frm = new FormAddPPRfq("FO");
            frm.ShowDialog();

            loadMaterialNumber();
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lblId.Text == "0" || lblId.Text == "ID")
            {
                MessageBox.Show("Please select a material to delete.");
                return;
            }

          DialogResult res =  MessageBox.Show("Are you sure to delete the selected row ? ", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {

               bool bb =  DBUtils.doDeleteFO( Convert.ToInt32(lblId.Text));
                if (bb)
                {
                    MessageBox.Show("Deleted successfully ");
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
            DataGridViewCell IDCell = dgvRow.Cells["dgID"];
            if (IDCell.Value != null)
            {

                if (dgvRow.Cells["dgID"].Value != DBNull.Value || dgvRow.Cells["dgID"].Value != null)
                {
                    id = (int)dgvRow.Cells["dgID"].Value;
                }

                lblId.Text = "" + id;
            }

        }

        private void dgvMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            masterRowClick();
        }


        private void deleteEmptyFOROws( )
        {
            if (lblId.Text == "0" || lblId.Text == "ID")
            {
                MessageBox.Show("Please select a material to delete.");
                return;
            }

            DialogResult res = MessageBox.Show("Are you sure to delete the selected row ? ", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {

                bool bb = DBUtils.doDeleteFO(Convert.ToInt32(lblId.Text));
                if (bb)
                {
                    MessageBox.Show("Deleted successfully ");
                    return;
                }
                else
                {
                    MessageBox.Show("Delete failed. ");
                    return;
                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dgvMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
