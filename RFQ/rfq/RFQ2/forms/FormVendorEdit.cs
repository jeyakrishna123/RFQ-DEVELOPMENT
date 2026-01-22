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
    public partial class FormVendorEdit : Form
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        long vendorId = 0;
        String VendorCode = string.Empty;
        string VendorName = string.Empty;
        string Email = string.Empty;
        string PersonContact = string.Empty;
        string Country = string.Empty;
        string FolderPath = string.Empty;


        private String action = "edit";

        public FormVendorEdit(long vendorId, String VendorCode, string VendorName, string Email, string PersonContact, string Country, string FolderPath)
        {
            this.vendorId = vendorId;
            this.VendorCode = VendorCode;
            this.VendorName = VendorName;
            this.Email = Email;
            this.PersonContact = PersonContact;
            this.Country = Country;
            this.FolderPath = FolderPath;


            action = "edit";
            InitializeComponent();


            txtContact.Text = this.PersonContact;
            txtCountry.Text = this.Country;
            txtEmail.Text = this.Email;
            txtFolderPath.Text = this.FolderPath;
            txtVendorCode.Text = this.VendorCode;
            txtVendorId.Text = this.vendorId+"";
            txtVendorName.Text = this.VendorName;

            txtVendorCode.Enabled = false;
            txtVendorId.Enabled = false;
            btnAddNew.Visible = false;
        }

        public FormVendorEdit()
        {
            InitializeComponent();
            action = "add";
            btnAddNew.PerformClick();
        }



        private void doSave()
        { //txtCountry.Text
            if (txtEmail.Text.Length < 5)
            {
                MessageBox.Show("Email error ");
                return;
            }

            if (txtCountry.Text.Length < 1)
            {
                MessageBox.Show("Country error ");
                return;
            }

            if (txtFolderPath.Text.Length < 5)
            {
                MessageBox.Show("Folder Path error ");
                return;
            }


            if (action == "edit")
            {
                doUpdate();
            }
            else
            {
                doAdd();
            }
        }

        private void doAdd()
        {
            string sql = "insert into tblVendor values(@VendorID, @VendorCode,@VendorName,@Email,@PersonContact, " +
                " @Country, @FolderPath ) ";

            try
            {
                using (SqlConnection cnn = new SqlConnection(MYGlobal.getCString()))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        try
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Add(new SqlParameter("@VendorID", txtVendorId.Text));
                            cmd.Parameters.Add(new SqlParameter("@VendorCode", txtVendorCode.Text));
                            cmd.Parameters.Add(new SqlParameter("@VendorName", txtVendorName.Text));
                            cmd.Parameters.Add(new SqlParameter("@Email", txtEmail.Text));
                            cmd.Parameters.Add(new SqlParameter("@PersonContact", txtContact.Text));
                            cmd.Parameters.Add(new SqlParameter("@Country", txtCountry.Text));
                            cmd.Parameters.Add(new SqlParameter("@FolderPath", txtFolderPath.Text));

                            int rows = cmd.ExecuteNonQuery();
                            log.Info("Aff rows " + rows);
                            MessageBox.Show("Add new success");
                            btnAddNew.PerformClick();
                        }catch(Exception ee)
                        {
                            log.Error("Error "+ee.Message);
                            MessageBox.Show("Add new failed "+ee.Message);
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                log.Error("Exceptoin in  doAdd(): " + ee.Message);
            }
        }


        private void doUpdate()
        {
            string sql = "update [tblVendor] set VendorName=@VendorName,Email=@Email, PersonContact=@PersonContact, " +
                " Country=@Country, FolderPath=@FolderPath where VendorID=@VendorID";

           

            try
            {
                using (SqlConnection cnn = new SqlConnection(MYGlobal.getCString()))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        try
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Add(new SqlParameter("@VendorName", txtVendorName.Text));
                            cmd.Parameters.Add(new SqlParameter("@Email", txtEmail.Text));
                            cmd.Parameters.Add(new SqlParameter("@PersonContact", txtContact.Text));
                            cmd.Parameters.Add(new SqlParameter("@Country", txtCountry.Text));
                            cmd.Parameters.Add(new SqlParameter("@FolderPath", txtFolderPath.Text));
                            cmd.Parameters.Add(new SqlParameter("@VendorID",  this.vendorId));
                            int rows = cmd.ExecuteNonQuery();
                            log.Info("Aff rows " + rows);
                            MessageBox.Show("update success");
                            this.Visible = false;
                        }catch(Exception ee)
                        {
                            MessageBox.Show("update failed "+ee.Message);
                            return;
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                log.Error("Exceptoin in  getAllMaterials(): " + ee.Message);
            }
        }

        private void doAddNew()
        {           
            action = "add";
            doClear();
        }

        private void doClear()
        {
            txtContact.Text = "";
            txtCountry.Text = "";
            txtEmail.Text = "";
            txtFolderPath.Text = "";
            txtVendorCode.Text = "";
            txtVendorId.Text = "";
            txtVendorName.Text = "";
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            doAddNew();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            doSave();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry can not delete a vendor ");
        }
    }
}
