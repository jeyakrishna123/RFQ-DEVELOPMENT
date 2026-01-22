namespace HalliburtonRFQ
{
    partial class RequestPart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RequestPart));
            this.btnRequest = new System.Windows.Forms.Button();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonSeparator1 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonSeparator2 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonOrbRecentItem1 = new System.Windows.Forms.RibbonOrbRecentItem();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.rbtnNew = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.rbtnRequestPart = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.rbtnClose = new System.Windows.Forms.RibbonButton();
            this.ribbonLabel1 = new System.Windows.Forms.RibbonLabel();
            this.ribbonLabel2 = new System.Windows.Forms.RibbonLabel();
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton3 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton4 = new System.Windows.Forms.RibbonButton();
            this.New = new System.Windows.Forms.RibbonButton();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpNewRequest = new System.Windows.Forms.TabPage();
            this.tpMyRequest = new System.Windows.Forms.TabPage();
            this.dgvPartNumber = new System.Windows.Forms.DataGridView();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPartNumber = new System.Windows.Forms.ComboBox();
            this.lblRequest = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlRequest = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tpNewRequest.SuspendLayout();
            this.tpMyRequest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRequest
            // 
            this.btnRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRequest.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRequest.Location = new System.Drawing.Point(13, 12);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(89, 28);
            this.btnRequest.TabIndex = 38;
            this.btnRequest.Text = "Request";
            this.btnRequest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRequest.UseVisualStyleBackColor = true;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(238, 33);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(157, 20);
            this.dtpFrom.TabIndex = 52;
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(238, 59);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(157, 20);
            this.dtpTo.TabIndex = 51;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(567, 58);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 46;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(189, 62);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(20, 13);
            this.lblTo.TabIndex = 43;
            this.lblTo.Text = "To";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(189, 39);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(30, 13);
            this.lblFrom.TabIndex = 42;
            this.lblFrom.Text = "From";
            // 
            // ribbon1
            // 
            this.ribbon1.CaptionBarVisible = false;
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.ribbonSeparator1);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.ribbonSeparator2);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.RecentItems.Add(this.ribbonOrbRecentItem1);
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 92);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2010;
            this.ribbon1.OrbVisible = false;
            // 
            // 
            // 
            this.ribbon1.QuickAccessToolbar.Value = "Req";
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(714, 98);
            this.ribbon1.TabIndex = 42;
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(6, 2, 20, 0);
            this.ribbon1.TabSpacing = 3;
            this.ribbon1.Text = "Requisation Form";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue_2010;
            // 
            // ribbonSeparator1
            // 
            this.ribbonSeparator1.Name = "ribbonSeparator1";
            // 
            // ribbonSeparator2
            // 
            this.ribbonSeparator2.Name = "ribbonSeparator2";
            // 
            // ribbonOrbRecentItem1
            // 
            this.ribbonOrbRecentItem1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbRecentItem1.Image")));
            this.ribbonOrbRecentItem1.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbRecentItem1.LargeImage")));
            this.ribbonOrbRecentItem1.Name = "ribbonOrbRecentItem1";
            this.ribbonOrbRecentItem1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbRecentItem1.SmallImage")));
            this.ribbonOrbRecentItem1.Text = "ribbonOrbRecentItem1";
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Panels.Add(this.ribbonPanel1);
            this.ribbonTab1.Panels.Add(this.ribbonPanel2);
            this.ribbonTab1.Panels.Add(this.ribbonPanel3);
            this.ribbonTab1.Text = "Action";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.rbtnNew);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Text = "";
            // 
            // rbtnNew
            // 
            this.rbtnNew.Image = ((System.Drawing.Image)(resources.GetObject("rbtnNew.Image")));
            this.rbtnNew.LargeImage = ((System.Drawing.Image)(resources.GetObject("rbtnNew.LargeImage")));
            this.rbtnNew.Name = "rbtnNew";
            this.rbtnNew.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnNew.SmallImage")));
            this.rbtnNew.Text = "New";
            this.rbtnNew.Click += new System.EventHandler(this.rbtnNew_Click);
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.Items.Add(this.rbtnRequestPart);
            this.ribbonPanel2.Name = "ribbonPanel2";
            this.ribbonPanel2.Text = "";
            // 
            // rbtnRequestPart
            // 
            this.rbtnRequestPart.Image = ((System.Drawing.Image)(resources.GetObject("rbtnRequestPart.Image")));
            this.rbtnRequestPart.LargeImage = ((System.Drawing.Image)(resources.GetObject("rbtnRequestPart.LargeImage")));
            this.rbtnRequestPart.Name = "rbtnRequestPart";
            this.rbtnRequestPart.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnRequestPart.SmallImage")));
            this.rbtnRequestPart.Text = "Request";
            this.rbtnRequestPart.Click += new System.EventHandler(this.rbtnRequestPart_Click);
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.Items.Add(this.rbtnClose);
            this.ribbonPanel3.Name = "ribbonPanel3";
            this.ribbonPanel3.Text = "";
            // 
            // rbtnClose
            // 
            this.rbtnClose.Image = ((System.Drawing.Image)(resources.GetObject("rbtnClose.Image")));
            this.rbtnClose.LargeImage = ((System.Drawing.Image)(resources.GetObject("rbtnClose.LargeImage")));
            this.rbtnClose.Name = "rbtnClose";
            this.rbtnClose.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnClose.SmallImage")));
            this.rbtnClose.Text = "Close";
            this.rbtnClose.Click += new System.EventHandler(this.rbtnClose_Click);
            // 
            // ribbonLabel1
            // 
            this.ribbonLabel1.Name = "ribbonLabel1";
            // 
            // ribbonLabel2
            // 
            this.ribbonLabel2.Name = "ribbonLabel2";
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.Image")));
            this.ribbonButton1.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.LargeImage")));
            this.ribbonButton1.Name = "ribbonButton1";
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            // 
            // ribbonButton3
            // 
            this.ribbonButton3.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.Image")));
            this.ribbonButton3.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.LargeImage")));
            this.ribbonButton3.Name = "ribbonButton3";
            this.ribbonButton3.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.SmallImage")));
            this.ribbonButton3.Text = "Close";
            // 
            // ribbonButton4
            // 
            this.ribbonButton4.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton4.Image")));
            this.ribbonButton4.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton4.LargeImage")));
            this.ribbonButton4.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButton4.Name = "ribbonButton4";
            this.ribbonButton4.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton4.SmallImage")));
            this.ribbonButton4.Text = "";
            // 
            // New
            // 
            this.New.Image = ((System.Drawing.Image)(resources.GetObject("New.Image")));
            this.New.LargeImage = ((System.Drawing.Image)(resources.GetObject("New.LargeImage")));
            this.New.Name = "New";
            this.New.SmallImage = ((System.Drawing.Image)(resources.GetObject("New.SmallImage")));
            this.New.Text = "Close";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStatus.Location = new System.Drawing.Point(428, 33);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 75;
            this.lblStatus.Text = "Status";
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(485, 30);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(157, 21);
            this.cbStatus.TabIndex = 74;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.BackColor = System.Drawing.Color.Transparent;
            this.chkAll.Location = new System.Drawing.Point(485, 64);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(67, 17);
            this.chkAll.TabIndex = 73;
            this.chkAll.Text = "Show All";
            this.chkAll.UseVisualStyleBackColor = false;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpNewRequest);
            this.tabControl1.Controls.Add(this.tpMyRequest);
            this.tabControl1.Location = new System.Drawing.Point(8, 100);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(706, 360);
            this.tabControl1.TabIndex = 76;
            // 
            // tpNewRequest
            // 
            this.tpNewRequest.Controls.Add(this.dgvPartNumber);
            this.tpNewRequest.Controls.Add(this.txtQuantity);
            this.tpNewRequest.Controls.Add(this.label2);
            this.tpNewRequest.Controls.Add(this.cbPartNumber);
            this.tpNewRequest.Controls.Add(this.lblRequest);
            this.tpNewRequest.Controls.Add(this.btnAdd);
            this.tpNewRequest.Location = new System.Drawing.Point(4, 22);
            this.tpNewRequest.Name = "tpNewRequest";
            this.tpNewRequest.Padding = new System.Windows.Forms.Padding(3);
            this.tpNewRequest.Size = new System.Drawing.Size(698, 334);
            this.tpNewRequest.TabIndex = 0;
            this.tpNewRequest.Text = "New Request";
            this.tpNewRequest.UseVisualStyleBackColor = true;
            // 
            // tpMyRequest
            // 
            this.tpMyRequest.Controls.Add(this.pnlRequest);
            this.tpMyRequest.Location = new System.Drawing.Point(4, 22);
            this.tpMyRequest.Name = "tpMyRequest";
            this.tpMyRequest.Padding = new System.Windows.Forms.Padding(3);
            this.tpMyRequest.Size = new System.Drawing.Size(698, 334);
            this.tpMyRequest.TabIndex = 1;
            this.tpMyRequest.Text = "My Request";
            this.tpMyRequest.UseVisualStyleBackColor = true;
            // 
            // dgvPartNumber
            // 
            this.dgvPartNumber.AllowUserToAddRows = false;
            this.dgvPartNumber.AllowUserToDeleteRows = false;
            this.dgvPartNumber.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPartNumber.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvPartNumber.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvPartNumber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPartNumber.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvPartNumber.Location = new System.Drawing.Point(6, 34);
            this.dgvPartNumber.Name = "dgvPartNumber";
            this.dgvPartNumber.ReadOnly = true;
            this.dgvPartNumber.RowHeadersVisible = false;
            this.dgvPartNumber.Size = new System.Drawing.Size(685, 295);
            this.dgvPartNumber.TabIndex = 51;
            this.dgvPartNumber.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPartNumber_CellContentClick);
            this.dgvPartNumber.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPartNumber_CellMouseEnter);
            // 
            // txtQuantity
            // 
            this.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuantity.Location = new System.Drawing.Point(371, 10);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(158, 20);
            this.txtQuantity.TabIndex = 50;
            this.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(287, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "No. Of Quantity";
            // 
            // cbPartNumber
            // 
            this.cbPartNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPartNumber.FormattingEnabled = true;
            this.cbPartNumber.Location = new System.Drawing.Point(96, 10);
            this.cbPartNumber.Name = "cbPartNumber";
            this.cbPartNumber.Size = new System.Drawing.Size(184, 21);
            this.cbPartNumber.TabIndex = 48;
            // 
            // lblRequest
            // 
            this.lblRequest.AutoSize = true;
            this.lblRequest.Location = new System.Drawing.Point(24, 13);
            this.lblRequest.Name = "lblRequest";
            this.lblRequest.Size = new System.Drawing.Size(66, 13);
            this.lblRequest.TabIndex = 47;
            this.lblRequest.Text = "Part Number";
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnAdd.Location = new System.Drawing.Point(531, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(32, 25);
            this.btnAdd.TabIndex = 52;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlRequest
            // 
            this.pnlRequest.AutoScroll = true;
            this.pnlRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRequest.Location = new System.Drawing.Point(3, 3);
            this.pnlRequest.Name = "pnlRequest";
            this.pnlRequest.Size = new System.Drawing.Size(692, 328);
            this.pnlRequest.TabIndex = 54;
            // 
            // RequestPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 458);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.ribbon1);
            this.Controls.Add(this.btnRequest);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RequestPart";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Requisition Form";
            this.Load += new System.EventHandler(this.RequestPart_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpNewRequest.ResumeLayout(false);
            this.tpNewRequest.PerformLayout();
            this.tpMyRequest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton rbtnNew;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonButton rbtnRequestPart;
        private System.Windows.Forms.RibbonButton ribbonButton1;
        private System.Windows.Forms.RibbonLabel ribbonLabel1;
        private System.Windows.Forms.RibbonLabel ribbonLabel2;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator1;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonButton ribbonButton3;
        private System.Windows.Forms.RibbonOrbRecentItem ribbonOrbRecentItem1;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator2;
        private System.Windows.Forms.RibbonButton ribbonButton4;
        private System.Windows.Forms.RibbonButton New;
        private System.Windows.Forms.RibbonButton rbtnClose;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpNewRequest;
        private System.Windows.Forms.TabPage tpMyRequest;
        private System.Windows.Forms.DataGridView dgvPartNumber;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPartNumber;
        private System.Windows.Forms.Label lblRequest;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel pnlRequest;
    }
}