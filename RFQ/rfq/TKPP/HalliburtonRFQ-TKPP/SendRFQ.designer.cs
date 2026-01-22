namespace HalliburtonRFQ
{
    partial class SendRFQ
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendRFQ));
            this.lblReqnumber = new System.Windows.Forms.Label();
            this.cbRequest = new System.Windows.Forms.ComboBox();
            this.lblReqName = new System.Windows.Forms.Label();
            this.txtRequestorName = new System.Windows.Forms.TextBox();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonOrbMenuItem1 = new System.Windows.Forms.RibbonOrbMenuItem();
            this.ribbonOrbOptionButton1 = new System.Windows.Forms.RibbonOrbOptionButton();
            this.ribbonOrbOptionButton2 = new System.Windows.Forms.RibbonOrbOptionButton();
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.Action = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.rbtnSend = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.rbtnClose = new System.Windows.Forms.RibbonButton();
            this.txtRequestDate = new System.Windows.Forms.TextBox();
            this.lblRequestDate = new System.Windows.Forms.Label();
            this.dgvPartNumber = new System.Windows.Forms.DataGridView();
            this.txtReviewedDate = new System.Windows.Forms.TextBox();
            this.lblReviewDate = new System.Windows.Forms.Label();
            this.txtApproverName = new System.Windows.Forms.TextBox();
            this.lblApproverName = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // lblReqnumber
            // 
            this.lblReqnumber.AutoSize = true;
            this.lblReqnumber.Location = new System.Drawing.Point(168, 62);
            this.lblReqnumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReqnumber.Name = "lblReqnumber";
            this.lblReqnumber.Size = new System.Drawing.Size(130, 20);
            this.lblReqnumber.TabIndex = 19;
            this.lblReqnumber.Text = "Request Number";
            // 
            // cbRequest
            // 
            this.cbRequest.BackColor = System.Drawing.SystemColors.Window;
            this.cbRequest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRequest.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbRequest.FormattingEnabled = true;
            this.cbRequest.Location = new System.Drawing.Point(308, 57);
            this.cbRequest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbRequest.Name = "cbRequest";
            this.cbRequest.Size = new System.Drawing.Size(302, 28);
            this.cbRequest.TabIndex = 20;
            this.cbRequest.SelectedIndexChanged += new System.EventHandler(this.cbRequest_SelectedIndexChanged);
            // 
            // lblReqName
            // 
            this.lblReqName.AutoSize = true;
            this.lblReqName.Location = new System.Drawing.Point(620, 97);
            this.lblReqName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReqName.Name = "lblReqName";
            this.lblReqName.Size = new System.Drawing.Size(130, 20);
            this.lblReqName.TabIndex = 21;
            this.lblReqName.Text = "Requestor Name";
            // 
            // txtRequestorName
            // 
            this.txtRequestorName.Enabled = false;
            this.txtRequestorName.Location = new System.Drawing.Point(759, 92);
            this.txtRequestorName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRequestorName.Name = "txtRequestorName";
            this.txtRequestorName.Size = new System.Drawing.Size(364, 26);
            this.txtRequestorName.TabIndex = 22;
            // 
            // ribbon1
            // 
            this.ribbon1.CaptionBarVisible = false;
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.ribbonOrbMenuItem1);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.OptionItems.Add(this.ribbonOrbOptionButton1);
            this.ribbon1.OrbDropDown.OptionItems.Add(this.ribbonOrbOptionButton2);
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 116);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2010;
            this.ribbon1.OrbVisible = false;
            // 
            // 
            // 
            this.ribbon1.QuickAccessToolbar.Items.Add(this.ribbonButton1);
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(1136, 162);
            this.ribbon1.TabIndex = 25;
            this.ribbon1.Tabs.Add(this.Action);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 2, 20, 0);
            this.ribbon1.TabSpacing = 3;
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue_2010;
            // 
            // ribbonOrbMenuItem1
            // 
            this.ribbonOrbMenuItem1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonOrbMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem1.Image")));
            this.ribbonOrbMenuItem1.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem1.LargeImage")));
            this.ribbonOrbMenuItem1.Name = "ribbonOrbMenuItem1";
            this.ribbonOrbMenuItem1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem1.SmallImage")));
            this.ribbonOrbMenuItem1.Text = "ribbonOrbMenuItem1";
            // 
            // ribbonOrbOptionButton1
            // 
            this.ribbonOrbOptionButton1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbOptionButton1.Image")));
            this.ribbonOrbOptionButton1.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbOptionButton1.LargeImage")));
            this.ribbonOrbOptionButton1.Name = "ribbonOrbOptionButton1";
            this.ribbonOrbOptionButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbOptionButton1.SmallImage")));
            this.ribbonOrbOptionButton1.Text = "ribbonOrbOptionButton1";
            // 
            // ribbonOrbOptionButton2
            // 
            this.ribbonOrbOptionButton2.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbOptionButton2.Image")));
            this.ribbonOrbOptionButton2.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbOptionButton2.LargeImage")));
            this.ribbonOrbOptionButton2.Name = "ribbonOrbOptionButton2";
            this.ribbonOrbOptionButton2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbOptionButton2.SmallImage")));
            this.ribbonOrbOptionButton2.Text = "ribbonOrbOptionButton2";
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.Image")));
            this.ribbonButton1.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.LargeImage")));
            this.ribbonButton1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButton1.Name = "ribbonButton1";
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            this.ribbonButton1.Text = "ribbonButton1";
            // 
            // Action
            // 
            this.Action.Name = "Action";
            this.Action.Panels.Add(this.ribbonPanel1);
            this.Action.Panels.Add(this.ribbonPanel2);
            this.Action.Text = "Action";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.rbtnSend);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Text = "";
            // 
            // rbtnSend
            // 
            this.rbtnSend.Image = ((System.Drawing.Image)(resources.GetObject("rbtnSend.Image")));
            this.rbtnSend.LargeImage = ((System.Drawing.Image)(resources.GetObject("rbtnSend.LargeImage")));
            this.rbtnSend.Name = "rbtnSend";
            this.rbtnSend.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnSend.SmallImage")));
            this.rbtnSend.Text = "Send";
            this.rbtnSend.Click += new System.EventHandler(this.rbtnSend_Click);
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.Items.Add(this.rbtnClose);
            this.ribbonPanel2.Name = "ribbonPanel2";
            this.ribbonPanel2.Text = "";
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
            // txtRequestDate
            // 
            this.txtRequestDate.Enabled = false;
            this.txtRequestDate.Location = new System.Drawing.Point(306, 92);
            this.txtRequestDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRequestDate.Name = "txtRequestDate";
            this.txtRequestDate.Size = new System.Drawing.Size(302, 26);
            this.txtRequestDate.TabIndex = 28;
            // 
            // lblRequestDate
            // 
            this.lblRequestDate.AutoSize = true;
            this.lblRequestDate.Location = new System.Drawing.Point(166, 97);
            this.lblRequestDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRequestDate.Name = "lblRequestDate";
            this.lblRequestDate.Size = new System.Drawing.Size(109, 20);
            this.lblRequestDate.TabIndex = 27;
            this.lblRequestDate.Text = "Request Date";
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
            this.dgvPartNumber.Location = new System.Drawing.Point(0, 171);
            this.dgvPartNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvPartNumber.Name = "dgvPartNumber";
            this.dgvPartNumber.ReadOnly = true;
            this.dgvPartNumber.RowHeadersVisible = false;
            this.dgvPartNumber.RowHeadersWidth = 62;
            this.dgvPartNumber.Size = new System.Drawing.Size(1136, 389);
            this.dgvPartNumber.TabIndex = 46;
            this.dgvPartNumber.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPartNumber_CellContentClick);
            // 
            // txtReviewedDate
            // 
            this.txtReviewedDate.Enabled = false;
            this.txtReviewedDate.Location = new System.Drawing.Point(308, 126);
            this.txtReviewedDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtReviewedDate.Name = "txtReviewedDate";
            this.txtReviewedDate.Size = new System.Drawing.Size(302, 26);
            this.txtReviewedDate.TabIndex = 50;
            // 
            // lblReviewDate
            // 
            this.lblReviewDate.AutoSize = true;
            this.lblReviewDate.Location = new System.Drawing.Point(168, 131);
            this.lblReviewDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReviewDate.Name = "lblReviewDate";
            this.lblReviewDate.Size = new System.Drawing.Size(117, 20);
            this.lblReviewDate.TabIndex = 49;
            this.lblReviewDate.Text = "Reviewed Date";
            // 
            // txtApproverName
            // 
            this.txtApproverName.Enabled = false;
            this.txtApproverName.Location = new System.Drawing.Point(760, 128);
            this.txtApproverName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtApproverName.Name = "txtApproverName";
            this.txtApproverName.Size = new System.Drawing.Size(364, 26);
            this.txtApproverName.TabIndex = 48;
            // 
            // lblApproverName
            // 
            this.lblApproverName.AutoSize = true;
            this.lblApproverName.Location = new System.Drawing.Point(621, 132);
            this.lblApproverName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApproverName.Name = "lblApproverName";
            this.lblApproverName.Size = new System.Drawing.Size(119, 20);
            this.lblApproverName.TabIndex = 47;
            this.lblApproverName.Text = "Approver Name";
            // 
            // txtStatus
            // 
            this.txtStatus.Enabled = false;
            this.txtStatus.Location = new System.Drawing.Point(760, 57);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(364, 26);
            this.txtStatus.TabIndex = 52;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(621, 62);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(56, 20);
            this.lblStatus.TabIndex = 51;
            this.lblStatus.Text = "Status";
            // 
            // SendRFQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 562);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtReviewedDate);
            this.Controls.Add(this.lblReviewDate);
            this.Controls.Add(this.txtApproverName);
            this.Controls.Add(this.lblApproverName);
            this.Controls.Add(this.dgvPartNumber);
            this.Controls.Add(this.txtRequestDate);
            this.Controls.Add(this.lblRequestDate);
            this.Controls.Add(this.txtRequestorName);
            this.Controls.Add(this.lblReqName);
            this.Controls.Add(this.cbRequest);
            this.Controls.Add(this.lblReqnumber);
            this.Controls.Add(this.ribbon1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SendRFQ";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Send Request For Quotation";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SendRFQ_FormClosed);
            this.Load += new System.EventHandler(this.SendRFQ_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReqnumber;
        private System.Windows.Forms.ComboBox cbRequest;
        private System.Windows.Forms.Label lblReqName;
        private System.Windows.Forms.TextBox txtRequestorName;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonButton ribbonButton1;
        private System.Windows.Forms.RibbonTab Action;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton rbtnSend;
        private System.Windows.Forms.RibbonOrbMenuItem ribbonOrbMenuItem1;
        private System.Windows.Forms.RibbonOrbOptionButton ribbonOrbOptionButton1;
        private System.Windows.Forms.RibbonOrbOptionButton ribbonOrbOptionButton2;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonButton rbtnClose;
        private System.Windows.Forms.TextBox txtRequestDate;
        private System.Windows.Forms.Label lblRequestDate;
        private System.Windows.Forms.DataGridView dgvPartNumber;
        private System.Windows.Forms.TextBox txtReviewedDate;
        private System.Windows.Forms.Label lblReviewDate;
        private System.Windows.Forms.TextBox txtApproverName;
        private System.Windows.Forms.Label lblApproverName;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label lblStatus;
    }
}