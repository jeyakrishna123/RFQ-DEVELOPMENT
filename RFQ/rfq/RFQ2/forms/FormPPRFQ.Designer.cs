namespace RFQ2.forms
{
    partial class FormPPRFQ
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboMatlNbr = new System.Windows.Forms.ComboBox();
            this.cboRfqRefNbr = new System.Windows.Forms.ComboBox();
            this.cboVendorId = new System.Windows.Forms.ComboBox();
            this.dgvMaster = new System.Windows.Forms.DataGridView();
            this.dgID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgRFQRef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgSAPMatl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgVendorId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgUOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgConversion_Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCOrgin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgLeadTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgVendorQuote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPrice_Break_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPrice_Break_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPrice_Break_3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPrice_Break_4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPrice_Break_5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPrice_Break_10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPrice_Break_25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPrice_Break_50 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPrice_Break_100 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCreaedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgModDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTotalRows = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.pbSearch = new System.Windows.Forms.PictureBox();
            this.pbAddNew = new System.Windows.Forms.PictureBox();
            this.lblId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaster)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddNew)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(-31, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 24);
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
            this.label3.Location = new System.Drawing.Point(161, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 24);
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
            this.label4.Location = new System.Drawing.Point(353, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(221, 24);
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
            this.cboMatlNbr.Location = new System.Drawing.Point(-31, 26);
            this.cboMatlNbr.Margin = new System.Windows.Forms.Padding(2);
            this.cboMatlNbr.Name = "cboMatlNbr";
            this.cboMatlNbr.Size = new System.Drawing.Size(221, 34);
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
            this.cboRfqRefNbr.Location = new System.Drawing.Point(161, 26);
            this.cboRfqRefNbr.Margin = new System.Windows.Forms.Padding(2);
            this.cboRfqRefNbr.Name = "cboRfqRefNbr";
            this.cboRfqRefNbr.Size = new System.Drawing.Size(221, 34);
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
            this.cboVendorId.Location = new System.Drawing.Point(353, 26);
            this.cboVendorId.Margin = new System.Windows.Forms.Padding(2);
            this.cboVendorId.Name = "cboVendorId";
            this.cboVendorId.Size = new System.Drawing.Size(221, 34);
            this.cboVendorId.TabIndex = 5;
            this.cboVendorId.SelectedIndexChanged += new System.EventHandler(this.cboVendorId_SelectedIndexChanged);
            // 
            // dgvMaster
            // 
            this.dgvMaster.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMaster.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgID,
            this.dgRFQRef,
            this.dgSAPMatl,
            this.dgVendorId,
            this.dgUOM,
            this.dgConversion_Qty,
            this.dgCOrgin,
            this.dgLeadTime,
            this.dgVendorQuote,
            this.dgCurrency,
            this.dgPrice_Break_1,
            this.dgPrice_Break_2,
            this.dgPrice_Break_3,
            this.dgPrice_Break_4,
            this.dgPrice_Break_5,
            this.dgPrice_Break_10,
            this.dgPrice_Break_25,
            this.dgPrice_Break_50,
            this.dgPrice_Break_100,
            this.dgStatus,
            this.dgRemarks,
            this.dgCreaedDate,
            this.dgModDate});
            this.dgvMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMaster.Location = new System.Drawing.Point(17, 132);
            this.dgvMaster.Margin = new System.Windows.Forms.Padding(2);
            this.dgvMaster.Name = "dgvMaster";
            this.dgvMaster.RowHeadersWidth = 51;
            this.dgvMaster.RowTemplate.Height = 24;
            this.dgvMaster.Size = new System.Drawing.Size(737, 305);
            this.dgvMaster.TabIndex = 2;
            this.dgvMaster.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMaster_CellClick);
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
            // dgRFQRef
            // 
            this.dgRFQRef.DataPropertyName = "RFQ_Refer";
            this.dgRFQRef.HeaderText = "RFQ Ref";
            this.dgRFQRef.MinimumWidth = 6;
            this.dgRFQRef.Name = "dgRFQRef";
            this.dgRFQRef.Width = 150;
            // 
            // dgSAPMatl
            // 
            this.dgSAPMatl.DataPropertyName = "OrderedPart";
            this.dgSAPMatl.HeaderText = "SAP Material Part";
            this.dgSAPMatl.MinimumWidth = 6;
            this.dgSAPMatl.Name = "dgSAPMatl";
            this.dgSAPMatl.Width = 150;
            // 
            // dgVendorId
            // 
            this.dgVendorId.DataPropertyName = "Vendor_ID";
            this.dgVendorId.HeaderText = "Vendor Id";
            this.dgVendorId.MinimumWidth = 6;
            this.dgVendorId.Name = "dgVendorId";
            this.dgVendorId.Width = 80;
            // 
            // dgUOM
            // 
            this.dgUOM.DataPropertyName = "uom";
            this.dgUOM.HeaderText = "UOM";
            this.dgUOM.MinimumWidth = 6;
            this.dgUOM.Name = "dgUOM";
            this.dgUOM.Width = 80;
            // 
            // dgConversion_Qty
            // 
            this.dgConversion_Qty.DataPropertyName = "Conversion_Qty";
            this.dgConversion_Qty.HeaderText = "Conversion Qty";
            this.dgConversion_Qty.MinimumWidth = 6;
            this.dgConversion_Qty.Name = "dgConversion_Qty";
            this.dgConversion_Qty.Width = 125;
            // 
            // dgCOrgin
            // 
            this.dgCOrgin.DataPropertyName = "Country_Of_Origin";
            this.dgCOrgin.HeaderText = "CO";
            this.dgCOrgin.MinimumWidth = 6;
            this.dgCOrgin.Name = "dgCOrgin";
            this.dgCOrgin.Width = 80;
            // 
            // dgLeadTime
            // 
            this.dgLeadTime.DataPropertyName = "LeadTime";
            this.dgLeadTime.HeaderText = "Lead Time";
            this.dgLeadTime.MinimumWidth = 6;
            this.dgLeadTime.Name = "dgLeadTime";
            this.dgLeadTime.Width = 80;
            // 
            // dgVendorQuote
            // 
            this.dgVendorQuote.DataPropertyName = "Quotation";
            this.dgVendorQuote.HeaderText = "Vendor Quote";
            this.dgVendorQuote.MinimumWidth = 6;
            this.dgVendorQuote.Name = "dgVendorQuote";
            this.dgVendorQuote.Width = 125;
            // 
            // dgCurrency
            // 
            this.dgCurrency.DataPropertyName = "currency";
            this.dgCurrency.HeaderText = "Currency";
            this.dgCurrency.MinimumWidth = 6;
            this.dgCurrency.Name = "dgCurrency";
            this.dgCurrency.Width = 80;
            // 
            // dgPrice_Break_1
            // 
            this.dgPrice_Break_1.DataPropertyName = "Price_Break_1";
            this.dgPrice_Break_1.HeaderText = "Price Break 1";
            this.dgPrice_Break_1.MinimumWidth = 6;
            this.dgPrice_Break_1.Name = "dgPrice_Break_1";
            this.dgPrice_Break_1.Width = 80;
            // 
            // dgPrice_Break_2
            // 
            this.dgPrice_Break_2.DataPropertyName = "Price_Break_2";
            this.dgPrice_Break_2.HeaderText = "Price Break 2";
            this.dgPrice_Break_2.MinimumWidth = 6;
            this.dgPrice_Break_2.Name = "dgPrice_Break_2";
            this.dgPrice_Break_2.Width = 80;
            // 
            // dgPrice_Break_3
            // 
            this.dgPrice_Break_3.DataPropertyName = "Price_Break_3";
            this.dgPrice_Break_3.HeaderText = "Price Break_3";
            this.dgPrice_Break_3.MinimumWidth = 6;
            this.dgPrice_Break_3.Name = "dgPrice_Break_3";
            this.dgPrice_Break_3.Width = 80;
            // 
            // dgPrice_Break_4
            // 
            this.dgPrice_Break_4.DataPropertyName = "Price_Break_4";
            this.dgPrice_Break_4.HeaderText = "Price Break_4";
            this.dgPrice_Break_4.MinimumWidth = 6;
            this.dgPrice_Break_4.Name = "dgPrice_Break_4";
            this.dgPrice_Break_4.Width = 125;
            // 
            // dgPrice_Break_5
            // 
            this.dgPrice_Break_5.DataPropertyName = "Price_Break_5";
            this.dgPrice_Break_5.HeaderText = "Price Break_5";
            this.dgPrice_Break_5.MinimumWidth = 6;
            this.dgPrice_Break_5.Name = "dgPrice_Break_5";
            this.dgPrice_Break_5.Width = 125;
            // 
            // dgPrice_Break_10
            // 
            this.dgPrice_Break_10.DataPropertyName = "Price_Break_10";
            this.dgPrice_Break_10.HeaderText = "Price Break_10";
            this.dgPrice_Break_10.MinimumWidth = 6;
            this.dgPrice_Break_10.Name = "dgPrice_Break_10";
            this.dgPrice_Break_10.Width = 125;
            // 
            // dgPrice_Break_25
            // 
            this.dgPrice_Break_25.DataPropertyName = "Price_Break_25";
            this.dgPrice_Break_25.HeaderText = "Price Break_25";
            this.dgPrice_Break_25.MinimumWidth = 6;
            this.dgPrice_Break_25.Name = "dgPrice_Break_25";
            this.dgPrice_Break_25.Width = 125;
            // 
            // dgPrice_Break_50
            // 
            this.dgPrice_Break_50.DataPropertyName = "Price_Break_50";
            this.dgPrice_Break_50.HeaderText = "Price Break_50";
            this.dgPrice_Break_50.MinimumWidth = 6;
            this.dgPrice_Break_50.Name = "dgPrice_Break_50";
            this.dgPrice_Break_50.Width = 125;
            // 
            // dgPrice_Break_100
            // 
            this.dgPrice_Break_100.DataPropertyName = "Price_Break_100";
            this.dgPrice_Break_100.HeaderText = "Price Break_100";
            this.dgPrice_Break_100.MinimumWidth = 6;
            this.dgPrice_Break_100.Name = "dgPrice_Break_100";
            this.dgPrice_Break_100.Width = 125;
            // 
            // dgStatus
            // 
            this.dgStatus.DataPropertyName = "Status";
            this.dgStatus.HeaderText = "Status";
            this.dgStatus.MinimumWidth = 6;
            this.dgStatus.Name = "dgStatus";
            this.dgStatus.ReadOnly = true;
            this.dgStatus.Width = 125;
            // 
            // dgRemarks
            // 
            this.dgRemarks.DataPropertyName = "remarks";
            this.dgRemarks.HeaderText = "Remarks";
            this.dgRemarks.MinimumWidth = 6;
            this.dgRemarks.Name = "dgRemarks";
            this.dgRemarks.Width = 150;
            // 
            // dgCreaedDate
            // 
            this.dgCreaedDate.DataPropertyName = "CreatedDate";
            this.dgCreaedDate.HeaderText = "Created Date";
            this.dgCreaedDate.MinimumWidth = 6;
            this.dgCreaedDate.Name = "dgCreaedDate";
            this.dgCreaedDate.ReadOnly = true;
            this.dgCreaedDate.Width = 125;
            // 
            // dgModDate
            // 
            this.dgModDate.DataPropertyName = "ModifiedDate";
            this.dgModDate.HeaderText = "Mod Date";
            this.dgModDate.MinimumWidth = 6;
            this.dgModDate.Name = "dgModDate";
            this.dgModDate.ReadOnly = true;
            this.dgModDate.Width = 125;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnExportExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportExcel.Font = new System.Drawing.Font("High Tower Text", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Location = new System.Drawing.Point(123, 2);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(131, 41);
            this.btnExportExcel.TabIndex = 0;
            this.btnExportExcel.Text = "Export";
            this.btnExportExcel.UseVisualStyleBackColor = false;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.Font = new System.Drawing.Font("High Tower Text", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(393, 2);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(131, 41);
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
            this.lblTotalRows.Location = new System.Drawing.Point(528, 0);
            this.lblTotalRows.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalRows.Name = "lblTotalRows";
            this.lblTotalRows.Size = new System.Drawing.Size(86, 45);
            this.lblTotalRows.TabIndex = 2;
            this.lblTotalRows.Text = "Rows";
            this.lblTotalRows.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Firebrick;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("High Tower Text", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(737, 49);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quotation Data Manual Updater for PP RFQ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnExportExcel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnClose, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblTotalRows, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnDelete, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(17, 441);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(737, 45);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnDelete.Font = new System.Drawing.Font("High Tower Text", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(258, 2);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(130, 39);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.dgvMaster, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(771, 488);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel3.ColumnCount = 10;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.31579F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 225F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.31579F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 225F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.31579F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 225F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.05263F));
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
            this.tableLayoutPanel3.Location = new System.Drawing.Point(17, 67);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(737, 61);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // pbSearch
            // 
            this.pbSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSearch.Image = global::RFQ2.Properties.Resources.search;
            this.pbSearch.Location = new System.Drawing.Point(616, 2);
            this.pbSearch.Margin = new System.Windows.Forms.Padding(2);
            this.pbSearch.Name = "pbSearch";
            this.tableLayoutPanel3.SetRowSpan(this.pbSearch, 2);
            this.pbSearch.Size = new System.Drawing.Size(71, 57);
            this.pbSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSearch.TabIndex = 6;
            this.pbSearch.TabStop = false;
            this.pbSearch.Click += new System.EventHandler(this.pbSearch_Click);
            // 
            // pbAddNew
            // 
            this.pbAddNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbAddNew.Image = global::RFQ2.Properties.Resources.add_icon;
            this.pbAddNew.Location = new System.Drawing.Point(691, 2);
            this.pbAddNew.Margin = new System.Windows.Forms.Padding(2);
            this.pbAddNew.Name = "pbAddNew";
            this.tableLayoutPanel3.SetRowSpan(this.pbAddNew, 2);
            this.pbAddNew.Size = new System.Drawing.Size(71, 57);
            this.pbAddNew.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAddNew.TabIndex = 7;
            this.pbAddNew.TabStop = false;
            this.pbAddNew.Click += new System.EventHandler(this.pbAddNew_Click);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblId.Location = new System.Drawing.Point(2, 0);
            this.lblId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(1, 24);
            this.lblId.TabIndex = 8;
            this.lblId.Text = "ID";
            this.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormPPRFQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 488);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormPPRFQ";
            this.Text = "PPRFQ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPPRFQ_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaster)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddNew)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboMatlNbr;
        private System.Windows.Forms.ComboBox cboRfqRefNbr;
        private System.Windows.Forms.ComboBox cboVendorId;
        private System.Windows.Forms.PictureBox pbSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridView dgvMaster;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTotalRows;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgRFQRef;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgSAPMatl;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgVendorId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgUOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgConversion_Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCOrgin;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgLeadTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgVendorQuote;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPrice_Break_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPrice_Break_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPrice_Break_3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPrice_Break_4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPrice_Break_5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPrice_Break_10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPrice_Break_25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPrice_Break_50;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPrice_Break_100;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCreaedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgModDate;
        private System.Windows.Forms.PictureBox pbAddNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblId;
    }
}