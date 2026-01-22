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
    public partial class FormAddPPRfq : Form
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string FO_OR_KK = string.Empty;
        public FormAddPPRfq(string FO_OR_KK)
        {
            InitializeComponent();
            this.FO_OR_KK = FO_OR_KK;
        }

        private void pbSave_Click(object sender, EventArgs e)
        {
           DialogResult res= MessageBox.Show("Are you sure to save?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                string stored_procedure = string.Empty;
                if (FO_OR_KK.Equals("FO"))
                {
                    stored_procedure = "[SP_UPD_FO_RFQ_LINER]";
                }
                else
                {
                    stored_procedure = "[SP_UPD_PP_RFQ_LINER]";
                }

                using (SqlConnection sqlCon = new SqlConnection(MYGlobal.getCString()))
                {
                    sqlCon.Open();

                    SqlCommand sqlcmd = new SqlCommand(stored_procedure, sqlCon);
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;

                        try
                        {
                            string matlNum = txtMatlNum.Text;
                            string vendId = txtVendorId.Text;
                            string rfqRef = txtRFQNo.Text;

                            if (matlNum.Length < 1)
                            {
                                MessageBox.Show("Material number cant be null");
                                return;

                            }

                            if (vendId.Length < 1)
                            {
                                MessageBox.Show("Vendor ID cant be null");
                                return;

                            }

                            if (rfqRef.Length < 1)
                            {
                                MessageBox.Show("RFQ Ref cant be null");
                                return;

                            }


                            sqlcmd.Parameters.AddWithValue("@ID", 0);
                            sqlcmd.Parameters.AddWithValue("@RFQ_Refer", rfqRef);
                            sqlcmd.Parameters.AddWithValue("@OrderedPart", matlNum);
                            sqlcmd.Parameters.AddWithValue("@Vendor_ID", vendId);

                            sqlcmd.Parameters.AddWithValue("@MDATE", DateTime.Now);


                            //======== DONE =============
                            int rows = sqlcmd.ExecuteNonQuery();

                            log.Info("Affected rows = " + rows);

                            //close sqlcmd
                            sqlcmd.Dispose();
                            //========================


                            DialogResult res4 = MessageBox.Show("Added successfully, Do you want to add more", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (res4 == DialogResult.Yes)
                            {
                                txtVendorId.Text = "";
                            }
                            else
                            {
                                this.Close();
                            }


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
    }
}
