namespace HalliburtonRFQ
{
    partial class Quote_Comparision
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Quote_Comparision));
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.rt_Action = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.rbtn_Refresh = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.rbtn_Close = new System.Windows.Forms.RibbonButton();
            this.cbReqnumber = new System.Windows.Forms.ComboBox();
            this.lblReqnumber = new System.Windows.Forms.Label();
            this.lblRequestDate = new System.Windows.Forms.Label();
            this.txtRequestDate = new System.Windows.Forms.TextBox();
            this.txtReviewedDate = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblReviewDate = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtApproverName = new System.Windows.Forms.TextBox();
            this.lblApproverName = new System.Windows.Forms.Label();
            this.txtRequestorName = new System.Windows.Forms.TextBox();
            this.lblReqName = new System.Windows.Forms.Label();
            this.pnlRequest = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // ribbon1
            // 
            this.ribbon1.BackColor = System.Drawing.SystemColors.Control;
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
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 72);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2010;
            this.ribbon1.OrbVisible = false;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(799, 118);
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Tabs.Add(this.rt_Action);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 2, 20, 0);
            this.ribbon1.TabSpacing = 3;
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue_2010;
            // 
            // rt_Action
            // 
            this.rt_Action.Name = "rt_Action";
            this.rt_Action.Panels.Add(this.ribbonPanel1);
            this.rt_Action.Panels.Add(this.ribbonPanel2);
            this.rt_Action.Text = "Action";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.rbtn_Refresh);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Text = "";
            // 
            // rbtn_Refresh
            // 
            this.rbtn_Refresh.Image = global::HalliburtonRFQ.Properties.Resources.refresh;
            this.rbtn_Refresh.LargeImage = global::HalliburtonRFQ.Properties.Resources.refresh;
            this.rbtn_Refresh.Name = "rbtn_Refresh";
            this.rbtn_Refresh.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtn_Refresh.SmallImage")));
            this.rbtn_Refresh.Text = "Refresh";
            this.rbtn_Refresh.Click += new System.EventHandler(this.rbtn_Refresh_Click);
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.Items.Add(this.rbtn_Close);
            this.ribbonPanel2.Name = "ribbonPanel2";
            this.ribbonPanel2.Text = "";
            // 
            // rbtn_Close
            // 
            this.rbtn_Close.Image = global::HalliburtonRFQ.Properties.Resources.rejected_3;
            this.rbtn_Close.LargeImage = global::HalliburtonRFQ.Properties.Resources.rejected_3;
            this.rbtn_Close.Name = "rbtn_Close";
            this.rbtn_Close.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtn_Close.SmallImage")));
            this.rbtn_Close.Text = "Close";
            this.rbtn_Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // cbReqnumber
            // 
            this.cbReqnumber.BackColor = System.Drawing.SystemColors.Window;
            this.cbReqnumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReqnumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbReqnumber.FormattingEnabled = true;
            this.cbReqnumber.Location = new System.Drawing.Point(229, 35);
            this.cbReqnumber.Name = "cbReqnumber";
            this.cbReqnumber.Size = new System.Drawing.Size(227, 21);
            this.cbReqnumber.TabIndex = 22;
            this.cbReqnumber.SelectedIndexChanged += new System.EventHandler(this.cbReqnumber_SelectedIndexChanged);
            // 
            // lblReqnumber
            // 
            this.lblReqnumber.AutoSize = true;
            this.lblReqnumber.Location = new System.Drawing.Point(136, 43);
            this.lblReqnumber.Name = "lblReqnumber";
            this.lblReqnumber.Size = new System.Drawing.Size(87, 13);
            this.lblReqnumber.TabIndex = 21;
            this.lblReqnumber.Text = "Request Number";
            // 
            // lblRequestDate
            // 
            this.lblRequestDate.AutoSize = true;
            this.lblRequestDate.Location = new System.Drawing.Point(136, 69);
            this.lblRequestDate.Name = "lblRequestDate";
            this.lblRequestDate.Size = new System.Drawing.Size(73, 13);
            this.lblRequestDate.TabIndex = 25;
            this.lblRequestDate.Text = "Request Date";
            // 
            // txtRequestDate
            // 
            this.txtRequestDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRequestDate.Enabled = false;
            this.txtRequestDate.Location = new System.Drawing.Point(229, 62);
            this.txtRequestDate.Name = "txtRequestDate";
            this.txtRequestDate.Size = new System.Drawing.Size(227, 20);
            this.txtRequestDate.TabIndex = 26;
            // 
            // txtReviewedDate
            // 
            this.txtReviewedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReviewedDate.Enabled = false;
            this.txtReviewedDate.Location = new System.Drawing.Point(229, 88);
            this.txtReviewedDate.Name = "txtReviewedDate";
            this.txtReviewedDate.Size = new System.Drawing.Size(227, 20);
            this.txtReviewedDate.TabIndex = 27;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Location = new System.Drawing.Point(462, 43);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 28;
            this.lblStatus.Text = "Status";
            // 
            // lblReviewDate
            // 
            this.lblReviewDate.AutoSize = true;
            this.lblReviewDate.Location = new System.Drawing.Point(137, 95);
            this.lblReviewDate.Name = "lblReviewDate";
            this.lblReviewDate.Size = new System.Drawing.Size(81, 13);
            this.lblReviewDate.TabIndex = 29;
            this.lblReviewDate.Text = "Reviewed Date";
            // 
            // txtStatus
            // 
            this.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStatus.Enabled = false;
            this.txtStatus.Location = new System.Drawing.Point(555, 38);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(241, 20);
            this.txtStatus.TabIndex = 30;
            // 
            // txtApproverName
            // 
            this.txtApproverName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApproverName.Enabled = false;
            this.txtApproverName.Location = new System.Drawing.Point(555, 88);
            this.txtApproverName.Name = "txtApproverName";
            this.txtApproverName.Size = new System.Drawing.Size(241, 20);
            this.txtApproverName.TabIndex = 31;
            // 
            // lblApproverName
            // 
            this.lblApproverName.AutoSize = true;
            this.lblApproverName.Location = new System.Drawing.Point(462, 95);
            this.lblApproverName.Name = "lblApproverName";
            this.lblApproverName.Size = new System.Drawing.Size(81, 13);
            this.lblApproverName.TabIndex = 32;
            this.lblApproverName.Text = "Approver Name";
            // 
            // txtRequestorName
            // 
            this.txtRequestorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRequestorName.Enabled = false;
            this.txtRequestorName.Location = new System.Drawing.Point(555, 62);
            this.txtRequestorName.Name = "txtRequestorName";
            this.txtRequestorName.Size = new System.Drawing.Size(241, 20);
            this.txtRequestorName.TabIndex = 36;
            // 
            // lblReqName
            // 
            this.lblReqName.AutoSize = true;
            this.lblReqName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblReqName.Location = new System.Drawing.Point(462, 69);
            this.lblReqName.Name = "lblReqName";
            this.lblReqName.Size = new System.Drawing.Size(87, 13);
            this.lblReqName.TabIndex = 35;
            this.lblReqName.Text = "Requestor Name";
            // 
            // pnlRequest
            // 
            this.pnlRequest.Location = new System.Drawing.Point(0, 124);
            this.pnlRequest.Name = "pnlRequest";
            this.pnlRequest.Size = new System.Drawing.Size(796, 342);
            this.pnlRequest.TabIndex = 37;
            // 
            // Quote_Comparision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 475);
            this.Controls.Add(this.pnlRequest);
            this.Controls.Add(this.txtRequestorName);
            this.Controls.Add(this.lblReqName);
            this.Controls.Add(this.lblApproverName);
            this.Controls.Add(this.txtApproverName);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.lblReviewDate);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtReviewedDate);
            this.Controls.Add(this.txtRequestDate);
            this.Controls.Add(this.lblRequestDate);
            this.Controls.Add(this.cbReqnumber);
            this.Controls.Add(this.lblReqnumber);
            this.Controls.Add(this.ribbon1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Quote_Comparision";
            this.ShowIcon = false;
            this.Text = "Quote Comparision";
            this.Load += new System.EventHandler(this.Quote_Comparision_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab rt_Action;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton rbtn_Refresh;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonButton rbtn_Close;
        private System.Windows.Forms.ComboBox cbReqnumber;
        private System.Windows.Forms.Label lblReqnumber;
        private System.Windows.Forms.Label lblRequestDate;
        private System.Windows.Forms.TextBox txtRequestDate;
        private System.Windows.Forms.TextBox txtReviewedDate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblReviewDate;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtApproverName;
        private System.Windows.Forms.Label lblApproverName;
        private System.Windows.Forms.TextBox txtRequestorName;
        private System.Windows.Forms.Label lblReqName;
        private System.Windows.Forms.Panel pnlRequest;
    }
}