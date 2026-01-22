using System.Windows.Forms;
using System;
using System.Drawing;

namespace RFQ2.forms
{
   
    partial class FormFOFRQ
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFOFRQ));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDeleteEmptyRows = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTotalRows = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvMaster = new System.Windows.Forms.DataGridView();
            this.dgID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgSAPMatl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgRFQRef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgVendorId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCOrgin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgOrdQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgVendorQuote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgUOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPS123 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPS429 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPSGt10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgLeadTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgErrorStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCreaedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgModDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboMatlNbr = new System.Windows.Forms.ComboBox();
            this.cboRfqRefNbr = new System.Windows.Forms.ComboBox();
            this.cboVendorId = new System.Windows.Forms.ComboBox();
            this.pbSearch = new System.Windows.Forms.PictureBox();
            this.pbAddNew = new System.Windows.Forms.PictureBox();
            this.lblId = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaster)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddNew)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.dgvMaster, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1580, 683);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Firebrick;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("High Tower Text", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(25, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1530, 75);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quotation Data Manual Updater for FOSO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 202F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 202F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 202F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnDeleteEmptyRows, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnExportExcel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnClose, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblTotalRows, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnDelete, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(25, 611);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1530, 69);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnDeleteEmptyRows
            // 
            this.btnDeleteEmptyRows.BackColor = System.Drawing.Color.OrangeRed;
            this.btnDeleteEmptyRows.Font = new System.Drawing.Font("High Tower Text", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteEmptyRows.ForeColor = System.Drawing.Color.White;
            this.btnDeleteEmptyRows.Location = new System.Drawing.Point(3, 3);
            this.btnDeleteEmptyRows.Name = "btnDeleteEmptyRows";
            this.btnDeleteEmptyRows.Size = new System.Drawing.Size(294, 60);
            this.btnDeleteEmptyRows.TabIndex = 5;
            this.btnDeleteEmptyRows.Text = "Delete Empty Rows";
            this.btnDeleteEmptyRows.UseVisualStyleBackColor = false;
            this.btnDeleteEmptyRows.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnExportExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportExcel.Font = new System.Drawing.Font("High Tower Text", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Location = new System.Drawing.Point(397, 3);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(196, 63);
            this.btnExportExcel.TabIndex = 0;
            this.btnExportExcel.Text = "Export";
            this.btnExportExcel.UseVisualStyleBackColor = false;
            this.btnExportExcel.Click += new System.EventHandler(this.btnAddNewLine_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.Font = new System.Drawing.Font("High Tower Text", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(801, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(196, 63);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTotalRows
            // 
            this.lblTotalRows.AutoSize = true;
            this.lblTotalRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalRows.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRows.ForeColor = System.Drawing.Color.Purple;
            this.lblTotalRows.Location = new System.Drawing.Point(1003, 0);
            this.lblTotalRows.Name = "lblTotalRows";
            this.lblTotalRows.Size = new System.Drawing.Size(129, 69);
            this.lblTotalRows.TabIndex = 2;
            this.lblTotalRows.Text = "Rows";
            this.lblTotalRows.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnDelete.Font = new System.Drawing.Font("High Tower Text", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(599, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(195, 60);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvMaster
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SaddleBrown;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMaster.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgID,
            this.dgSAPMatl,
            this.dgRFQRef,
            this.dgVendorId,
            this.dgCOrgin,
            this.dgOrdQty,
            this.dgVendorQuote,
            this.dgUOM,
            this.dgCurrency,
            this.dgPS123,
            this.dgPS429,
            this.dgPSGt10,
            this.dgRemarks,
            this.dgLeadTime,
            this.dgErrorStatus,
            this.dgCreaedDate,
            this.dgModDate});
            this.dgvMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMaster.Location = new System.Drawing.Point(25, 203);
            this.dgvMaster.Name = "dgvMaster";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMaster.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMaster.RowHeadersWidth = 51;
            this.dgvMaster.RowTemplate.Height = 24;
            this.dgvMaster.Size = new System.Drawing.Size(1530, 402);
            this.dgvMaster.TabIndex = 2;
            this.dgvMaster.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMaster_CellClick);
            this.dgvMaster.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMaster_CellContentClick);
            this.dgvMaster.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMaster_CellValueChanged);
            // 
            // dgID
            // 
            this.dgID.DataPropertyName = "ID";
            this.dgID.HeaderText = "ID";
            this.dgID.MinimumWidth = 6;
            this.dgID.Name = "dgID";
            this.dgID.ReadOnly = true;
            this.dgID.Visible = false;
            this.dgID.Width = 125;
            // 
            // dgSAPMatl
            // 
            this.dgSAPMatl.DataPropertyName = "sap_matl_nbr";
            this.dgSAPMatl.HeaderText = "SAP Material";
            this.dgSAPMatl.MinimumWidth = 6;
            this.dgSAPMatl.Name = "dgSAPMatl";
            this.dgSAPMatl.ReadOnly = true;
            this.dgSAPMatl.Width = 150;
            // 
            // dgRFQRef
            // 
            this.dgRFQRef.DataPropertyName = "reqref";
            this.dgRFQRef.HeaderText = "RFQ Ref";
            this.dgRFQRef.MinimumWidth = 6;
            this.dgRFQRef.Name = "dgRFQRef";
            this.dgRFQRef.ReadOnly = true;
            this.dgRFQRef.Width = 150;
            // 
            // dgVendorId
            // 
            this.dgVendorId.DataPropertyName = "venid";
            this.dgVendorId.HeaderText = "Vendor Id";
            this.dgVendorId.MinimumWidth = 6;
            this.dgVendorId.Name = "dgVendorId";
            this.dgVendorId.ReadOnly = true;
            this.dgVendorId.Width = 80;
            // 
            // dgCOrgin
            // 
            this.dgCOrgin.DataPropertyName = "co";
            this.dgCOrgin.HeaderText = "COO";
            this.dgCOrgin.MinimumWidth = 6;
            this.dgCOrgin.Name = "dgCOrgin";
            this.dgCOrgin.Width = 80;
            // 
            // dgOrdQty
            // 
            this.dgOrdQty.DataPropertyName = "qty";
            this.dgOrdQty.HeaderText = "Ord Qty";
            this.dgOrdQty.MinimumWidth = 6;
            this.dgOrdQty.Name = "dgOrdQty";
            this.dgOrdQty.Width = 60;
            // 
            // dgVendorQuote
            // 
            this.dgVendorQuote.DataPropertyName = "venquote";
            this.dgVendorQuote.HeaderText = "Vendor Quote";
            this.dgVendorQuote.MinimumWidth = 6;
            this.dgVendorQuote.Name = "dgVendorQuote";
            this.dgVendorQuote.Width = 125;
            // 
            // dgUOM
            // 
            this.dgUOM.DataPropertyName = "uom";
            this.dgUOM.HeaderText = "UOM";
            this.dgUOM.MinimumWidth = 6;
            this.dgUOM.Name = "dgUOM";
            this.dgUOM.Width = 80;
            // 
            // dgCurrency
            // 
            this.dgCurrency.DataPropertyName = "currency";
            this.dgCurrency.HeaderText = "Currency";
            this.dgCurrency.MinimumWidth = 6;
            this.dgCurrency.Name = "dgCurrency";
            this.dgCurrency.Width = 80;
            // 
            // dgPS123
            // 
            this.dgPS123.DataPropertyName = "ps123";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.dgPS123.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgPS123.HeaderText = "Price Scale (1-3)";
            this.dgPS123.MinimumWidth = 6;
            this.dgPS123.Name = "dgPS123";
            this.dgPS123.Width = 80;
            // 
            // dgPS429
            // 
            this.dgPS429.DataPropertyName = "ps429";
            this.dgPS429.HeaderText = "Price Scale (4-9)";
            this.dgPS429.MinimumWidth = 6;
            this.dgPS429.Name = "dgPS429";
            this.dgPS429.Width = 80;
            // 
            // dgPSGt10
            // 
            this.dgPSGt10.DataPropertyName = "psgt10";
            this.dgPSGt10.HeaderText = "Price Scale (GT10)";
            this.dgPSGt10.MinimumWidth = 6;
            this.dgPSGt10.Name = "dgPSGt10";
            this.dgPSGt10.Width = 80;
            // 
            // dgRemarks
            // 
            this.dgRemarks.DataPropertyName = "remarks";
            this.dgRemarks.HeaderText = "Remarks";
            this.dgRemarks.MinimumWidth = 6;
            this.dgRemarks.Name = "dgRemarks";
            this.dgRemarks.Width = 150;
            // 
            // dgLeadTime
            // 
            this.dgLeadTime.DataPropertyName = "leadtime";
            this.dgLeadTime.HeaderText = "Lead Time";
            this.dgLeadTime.MinimumWidth = 6;
            this.dgLeadTime.Name = "dgLeadTime";
            this.dgLeadTime.Width = 80;
            // 
            // dgErrorStatus
            // 
            this.dgErrorStatus.DataPropertyName = "error";
            this.dgErrorStatus.HeaderText = "Error Status";
            this.dgErrorStatus.MinimumWidth = 6;
            this.dgErrorStatus.Name = "dgErrorStatus";
            this.dgErrorStatus.ReadOnly = true;
            this.dgErrorStatus.Width = 125;
            // 
            // dgCreaedDate
            // 
            this.dgCreaedDate.DataPropertyName = "crtdate";
            this.dgCreaedDate.HeaderText = "Created Date";
            this.dgCreaedDate.MinimumWidth = 6;
            this.dgCreaedDate.Name = "dgCreaedDate";
            this.dgCreaedDate.ReadOnly = true;
            this.dgCreaedDate.Width = 125;
            // 
            // dgModDate
            // 
            this.dgModDate.DataPropertyName = "modate";
            this.dgModDate.HeaderText = "Mod Date";
            this.dgModDate.MinimumWidth = 6;
            this.dgModDate.Name = "dgModDate";
            this.dgModDate.ReadOnly = true;
            this.dgModDate.Width = 125;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel3.ColumnCount = 10;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 338F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 338F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 338F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label3, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.label4, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.cboMatlNbr, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.cboRfqRefNbr, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.cboVendorId, 5, 1);
            this.tableLayoutPanel3.Controls.Add(this.pbSearch, 7, 0);
            this.tableLayoutPanel3.Controls.Add(this.pbAddNew, 8, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblId, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(25, 103);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1530, 94);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(61, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(332, 37);
            this.label2.TabIndex = 0;
            this.label2.Text = "SAP Material Number";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(457, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(332, 37);
            this.label3.TabIndex = 1;
            this.label3.Text = "RFQ Reference NO.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(853, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(332, 37);
            this.label4.TabIndex = 2;
            this.label4.Text = "Vendor ID";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboMatlNbr
            // 
            this.cboMatlNbr.BackColor = System.Drawing.Color.MediumBlue;
            this.cboMatlNbr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboMatlNbr.Font = new System.Drawing.Font("High Tower Text", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMatlNbr.ForeColor = System.Drawing.Color.White;
            this.cboMatlNbr.FormattingEnabled = true;
            this.cboMatlNbr.Location = new System.Drawing.Point(61, 40);
            this.cboMatlNbr.Name = "cboMatlNbr";
            this.cboMatlNbr.Size = new System.Drawing.Size(332, 45);
            this.cboMatlNbr.TabIndex = 3;
            this.cboMatlNbr.SelectedIndexChanged += new System.EventHandler(this.cboMatlNbr_SelectedIndexChanged);
            // 
            // cboRfqRefNbr
            // 
            this.cboRfqRefNbr.BackColor = System.Drawing.Color.MediumBlue;
            this.cboRfqRefNbr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboRfqRefNbr.Font = new System.Drawing.Font("High Tower Text", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRfqRefNbr.ForeColor = System.Drawing.Color.White;
            this.cboRfqRefNbr.FormattingEnabled = true;
            this.cboRfqRefNbr.Location = new System.Drawing.Point(457, 40);
            this.cboRfqRefNbr.Name = "cboRfqRefNbr";
            this.cboRfqRefNbr.Size = new System.Drawing.Size(332, 45);
            this.cboRfqRefNbr.TabIndex = 4;
            this.cboRfqRefNbr.SelectedIndexChanged += new System.EventHandler(this.cboRfqRefNbr_SelectedIndexChanged);
            // 
            // cboVendorId
            // 
            this.cboVendorId.BackColor = System.Drawing.Color.MediumBlue;
            this.cboVendorId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboVendorId.Font = new System.Drawing.Font("High Tower Text", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboVendorId.ForeColor = System.Drawing.Color.White;
            this.cboVendorId.FormattingEnabled = true;
            this.cboVendorId.Location = new System.Drawing.Point(853, 40);
            this.cboVendorId.Name = "cboVendorId";
            this.cboVendorId.Size = new System.Drawing.Size(332, 45);
            this.cboVendorId.TabIndex = 5;
            this.cboVendorId.SelectedIndexChanged += new System.EventHandler(this.cboVendorId_SelectedIndexChanged);
            // 
            // pbSearch
            // 
            this.pbSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSearch.Image = global::RFQ2.Properties.Resources.search;
            this.pbSearch.Location = new System.Drawing.Point(1248, 3);
            this.pbSearch.Name = "pbSearch";
            this.tableLayoutPanel3.SetRowSpan(this.pbSearch, 2);
            this.pbSearch.Size = new System.Drawing.Size(106, 88);
            this.pbSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSearch.TabIndex = 6;
            this.pbSearch.TabStop = false;
            this.pbSearch.Click += new System.EventHandler(this.pbSearch_Click);
            // 
            // pbAddNew
            // 
            this.pbAddNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbAddNew.Image = global::RFQ2.Properties.Resources.add_icon;
            this.pbAddNew.Location = new System.Drawing.Point(1360, 3);
            this.pbAddNew.Name = "pbAddNew";
            this.tableLayoutPanel3.SetRowSpan(this.pbAddNew, 2);
            this.pbAddNew.Size = new System.Drawing.Size(106, 88);
            this.pbAddNew.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAddNew.TabIndex = 7;
            this.pbAddNew.TabStop = false;
            this.pbAddNew.Click += new System.EventHandler(this.pbAddNew_Click);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblId.Location = new System.Drawing.Point(3, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(52, 37);
            this.lblId.TabIndex = 8;
            this.lblId.Text = "ID";
            this.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblId.Visible = false;
            // 
            // FormFOFRQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1580, 683);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormFOFRQ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RFQ - FOSO";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormFOFRQ_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaster)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddNew)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvMaster;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboMatlNbr;
        private System.Windows.Forms.ComboBox cboRfqRefNbr;
        private System.Windows.Forms.ComboBox cboVendorId;
        private System.Windows.Forms.Label lblTotalRows;
        private System.Windows.Forms.PictureBox pbSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgSAPMatl;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgRFQRef;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgVendorId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCOrgin;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgOrdQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgVendorQuote;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgUOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPS123;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPS429;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPSGt10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgLeadTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgErrorStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCreaedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgModDate;
        private System.Windows.Forms.PictureBox pbAddNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Button btnDeleteEmptyRows;
    }
}