using RFQ2.Global;
using System;
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
    public partial class FormVendorMgmt : Form
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public FormVendorMgmt()
        {
            InitializeComponent();

            init();
            //txt_search.Text = "Search";
            //txt_search.GotFocus += RemoveText;
            //txt_search.LostFocus += AddText;
           
        }
        public void RemoveText(object sender, EventArgs e)
        {
            if (txt_search.Text == "Search")
            {
                txt_search.Text = "";
            }
        }
       
        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_search.Text))
                txt_search.Text = "Search";
        }
        public void init()
        {
            doSearch();
        }
       

        private void doSearch()
        {
            lblTotalRows.Text = "0";
             


            string sql = "  select * from tblVendor order by VendorName ";


           /* if (material_num != null)
            {
                if (sql.Contains("where"))
                {
                    sql = sql + " and materil_num='" + material_num + "'";
                }
                else
                {
                    sql = sql + " where materil_num='" + material_num + "'";
                }
            }*/

          //  sql = sql + " order by id desc";

            using (SqlConnection sqlCon = new SqlConnection(MYGlobal.getCString()))
            {
                log.Info("doSearch() sql = " + sql);

                sqlCon.Open();

                using (SqlCommand cmd = new SqlCommand(sql, sqlCon))
                {
                    cmd.CommandType = CommandType.Text;
                    //params

                    // cmd.Parameters.Add(new SqlParameter("@ACTION", 1));
                    using (SqlDataAdapter sqlDa = new SqlDataAdapter(cmd))
                    {
                        //using data table
                        DataTable dt = new DataTable();
                        sqlDa.Fill(dt);
                        dgvMaster.DataSource = dt;
                        dgvMaster.Cursor = Cursors.Default;

                        int rowscount = dgvMaster.Rows.Count;
                        if (rowscount == 0)
                        {
                            MessageBox.Show("Couldnt fine this material , Do you want to import this material info ?");
                        }

                        lblTotalRows.Text = "" + (rowscount - 1);
                        for (int i = 0; i < rowscount; i++)
                        {
                            //cells_count
                            int cells_count = dgvMaster.Rows[i].Cells.Count;

                            /* String sts = (String)dgvMaster.Rows[i].Cells["dgToolStatus"].Value;
                             if (sts != null)
                             {
                                 if (sts.Equals("IN"))
                                 {
                                     dgvMaster.Rows[i].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Bold);
                                     dgvMaster.Rows[i].DefaultCellStyle.BackColor = Color.PaleGreen;
                                     dgvMaster.Rows[i].DefaultCellStyle.ForeColor = Color.DarkGreen;
                                 }
                             }*/
                        }
                    }
                }
            }

            if (lblTotalRows.Text == "0")
            {
                MessageBox.Show("Couldnt find this material in local database, Do you want to import this material info ?");
            }

        }

        private void doClick(DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvRow = dgvMaster.CurrentRow;

            long vid = 0L;
            String VendorCode = string.Empty;
            string VendorName = string.Empty;
            string Email = string.Empty;
            string PersonContact = string.Empty;
            string Country = string.Empty;
            string FolderPath = string.Empty;

            try
            {
                if (dgvRow.Cells["dgvVendorId"].Value != DBNull.Value)
                {
                    vid = (long)dgvRow.Cells["dgvVendorId"].Value; 
                }

                if (dgvRow.Cells["dgvVendorCode"].Value != DBNull.Value)
                {
                    VendorCode = (string)dgvRow.Cells["dgvVendorCode"].Value;
                }

                if (dgvRow.Cells["dgvVendorName"].Value != DBNull.Value)
                {
                    VendorName = (string)dgvRow.Cells["dgvVendorName"].Value;
                }

                if (dgvRow.Cells["dgvEmail"].Value != DBNull.Value)
                {
                    Email = (string)dgvRow.Cells["dgvEmail"].Value;
                }

                if (dgvRow.Cells["dgvPersonContact"].Value != DBNull.Value)
                {
                    PersonContact = (string)dgvRow.Cells["dgvPersonContact"].Value;
                }

                if (dgvRow.Cells["dgvCountry"].Value != DBNull.Value)
                {
                    Country = (string)dgvRow.Cells["dgvCountry"].Value;
                }

                if (dgvRow.Cells["dgvFolderPath"].Value != DBNull.Value)
                {
                    FolderPath = (string)dgvRow.Cells["dgvFolderPath"].Value;
                }
                FormVendorEdit vv = new FormVendorEdit(vid, VendorCode, VendorName, Email, PersonContact, Country, FolderPath);
                vv.ShowDialog();

                doSearch();
            }
            catch(Exception ee)
            {
                log.Info(ee.Message);
            }
           
        }

        private void dgvMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            doClick(e);
        }

        private void pbAddNewVendor_Click(object sender, EventArgs e)
        {
            FormVendorEdit vv = new FormVendorEdit();
            vv.ShowDialog();

            doSearch(); 
        }

        private void FormVendorMgmt_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Parent = null;
            e.Cancel = true;
        }
        
      

       

        private void btn_click(object sender, EventArgs e)
        {
            string searchValue = txt_search.Text;

            //dgvMaster.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                //foreach (DataGridViewRow row in dgvMaster.Rows)
                //{
                //    if (row.Cells[2].Value.ToString().ToLower().Contains(searchValue.ToLower()))
                //    {
                //        row.Selected = true;
                //        break;
                //    }
                //}
                if(!string.IsNullOrEmpty(txt_search.Text))
                {
                    BindingSource bs = new BindingSource();
                    bs.DataSource = dgvMaster.DataSource;
                    var search = txt_search.Text;
                    var columnsList = dgvMaster.Columns.Cast<DataGridViewColumn>()
                        .Where(x => x.Visible && x.ValueType == typeof(string))
                        .Select(x => x.DataPropertyName);
                    var filter = string.Join(" OR ", columnsList.Select(x => $"{x} like '%{search}%'"));

                    bs.Filter = filter;
                }
                else
                {
                    doSearch();
                }
               
            }
            catch (Exception ex)
            {
                log.Info("----------------- Error Start -------------------");
                log.Info(string.Concat(ex.StackTrace, ex.Message));
                if (ex.InnerException != null)
                {
                    log.Info("Inner Exception");
                    log.Info(string.Concat(ex.InnerException.StackTrace, ex.InnerException.Message));
                }
                log.Info("----------------- Error End -------------------");
                //MessageBox.Show(exc.Message);
            }
        }

        //private void txt_search_TextChanged(object sender, EventArgs e)
        //{

        //    foreach (System.Windows.Forms.DataGridViewRow r in dgvMaster.Rows)
        //    {
        //        if (r.Cells[5].Value != null)
        //        {
        //            if ((r.Cells[5].Value).ToString().ToUpper().Contains(txt_search.Text.ToUpper()))
        //            {
        //                dgvMaster.Rows[r.Index].Visible = true;
        //                dgvMaster.Rows[r.Index].Selected = true;
        //            }
        //            else
        //            {
        //                //dgvMaster.CurrentCell = null;
        //                //dgvMaster.Rows[r.Index].Visible = false;
        //            }
        //        }

        //    }
        //}
    }
}
