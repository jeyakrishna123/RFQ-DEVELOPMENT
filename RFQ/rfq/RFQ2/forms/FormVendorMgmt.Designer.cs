
namespace RFQ2.forms
{
    partial class FormVendorMgmt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVendorMgmt));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvMaster = new System.Windows.Forms.DataGridView();
            this.dgvVendorId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvVendorCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvVendorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPersonContact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvFolderPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotalRows = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.pbAddNewVendor = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaster)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddNewVendor)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvMaster, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalRows, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1089, 599);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvMaster
            // 
            this.dgvMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvVendorId,
            this.dgvVendorCode,
            this.dgvVendorName,
            this.dgvEmail,
            this.dgvPersonContact,
            this.dgvCountry,
            this.dgvFolderPath});
            this.dgvMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMaster.Location = new System.Drawing.Point(2, 43);
            this.dgvMaster.Margin = new System.Windows.Forms.Padding(2);
            this.dgvMaster.Name = "dgvMaster";
            this.dgvMaster.RowHeadersWidth = 51;
            this.dgvMaster.RowTemplate.Height = 24;
            this.dgvMaster.Size = new System.Drawing.Size(1085, 530);
            this.dgvMaster.TabIndex = 0;
            this.dgvMaster.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMaster_CellClick);
            // 
            // dgvVendorId
            // 
            this.dgvVendorId.DataPropertyName = "VendorID";
            this.dgvVendorId.HeaderText = "Vendor Id";
            this.dgvVendorId.MinimumWidth = 6;
            this.dgvVendorId.Name = "dgvVendorId";
            this.dgvVendorId.ReadOnly = true;
            // 
            // dgvVendorCode
            // 
            this.dgvVendorCode.DataPropertyName = "VendorCode";
            this.dgvVendorCode.HeaderText = "Vendor Code";
            this.dgvVendorCode.MinimumWidth = 6;
            this.dgvVendorCode.Name = "dgvVendorCode";
            this.dgvVendorCode.ReadOnly = true;
            this.dgvVendorCode.Width = 80;
            // 
            // dgvVendorName
            // 
            this.dgvVendorName.DataPropertyName = "VendorName";
            this.dgvVendorName.HeaderText = "Vendor Name";
            this.dgvVendorName.MinimumWidth = 6;
            this.dgvVendorName.Name = "dgvVendorName";
            this.dgvVendorName.ReadOnly = true;
            this.dgvVendorName.Width = 200;
            // 
            // dgvEmail
            // 
            this.dgvEmail.DataPropertyName = "Email";
            this.dgvEmail.HeaderText = "Email";
            this.dgvEmail.MinimumWidth = 6;
            this.dgvEmail.Name = "dgvEmail";
            this.dgvEmail.ReadOnly = true;
            this.dgvEmail.Width = 300;
            // 
            // dgvPersonContact
            // 
            this.dgvPersonContact.DataPropertyName = "PersonContact";
            this.dgvPersonContact.HeaderText = "Person Contact";
            this.dgvPersonContact.MinimumWidth = 6;
            this.dgvPersonContact.Name = "dgvPersonContact";
            this.dgvPersonContact.ReadOnly = true;
            this.dgvPersonContact.Width = 125;
            // 
            // dgvCountry
            // 
            this.dgvCountry.DataPropertyName = "Country";
            this.dgvCountry.HeaderText = "Country";
            this.dgvCountry.MinimumWidth = 6;
            this.dgvCountry.Name = "dgvCountry";
            this.dgvCountry.ReadOnly = true;
            // 
            // dgvFolderPath
            // 
            this.dgvFolderPath.DataPropertyName = "FolderPath";
            this.dgvFolderPath.HeaderText = "Folder Path";
            this.dgvFolderPath.MinimumWidth = 6;
            this.dgvFolderPath.Name = "dgvFolderPath";
            this.dgvFolderPath.ReadOnly = true;
            this.dgvFolderPath.Width = 350;
            // 
            // lblTotalRows
            // 
            this.lblTotalRows.AutoSize = true;
            this.lblTotalRows.Location = new System.Drawing.Point(2, 575);
            this.lblTotalRows.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalRows.Name = "lblTotalRows";
            this.lblTotalRows.Size = new System.Drawing.Size(35, 13);
            this.lblTotalRows.TabIndex = 1;
            this.lblTotalRows.Text = "label1";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.11111F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.88889F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txt_search, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.pbAddNewVendor, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.button1, 4, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(767, 37);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Firebrick;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("High Tower Text", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(483, 37);
            this.label1.TabIndex = 3;
            this.label1.Text = "Vendor Management";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_search
            // 
            this.txt_search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_search.Location = new System.Drawing.Point(530, 3);
            this.txt_search.Multiline = true;
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(192, 31);
            this.txt_search.TabIndex = 9;
            // 
            // pbAddNewVendor
            // 
            this.pbAddNewVendor.Image = global::RFQ2.Properties.Resources.add_icon;
            this.pbAddNewVendor.Location = new System.Drawing.Point(489, 2);
            this.pbAddNewVendor.Margin = new System.Windows.Forms.Padding(2);
            this.pbAddNewVendor.Name = "pbAddNewVendor";
            this.pbAddNewVendor.Size = new System.Drawing.Size(36, 33);
            this.pbAddNewVendor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAddNewVendor.TabIndex = 8;
            this.pbAddNewVendor.TabStop = false;
            this.pbAddNewVendor.Click += new System.EventHandler(this.pbAddNewVendor_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(748, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(16, 29);
            this.button1.TabIndex = 10;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn_click);
            // 
            // FormVendorMgmt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 599);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormVendorMgmt";
            this.Text = "FormVendorMgmt";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormVendorMgmt_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaster)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddNewVendor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvMaster;
        private System.Windows.Forms.Label lblTotalRows;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvVendorId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvVendorCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvVendorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPersonContact;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCountry;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvFolderPath;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbAddNewVendor;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Button button1;
    }
}