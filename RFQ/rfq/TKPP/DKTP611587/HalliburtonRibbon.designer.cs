namespace HalliburtonRFQ
{
    partial class HalliburtonRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public HalliburtonRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HalliburtonRibbon));
            this.tabTKPP = this.Factory.CreateRibbonTab();
            this.RlblTKPPQuotation = this.Factory.CreateRibbonGroup();
            this.btnSend_TKPP_RFQ = this.Factory.CreateRibbonButton();
            this.rbtnTKPPReadRFQ = this.Factory.CreateRibbonButton();
            this.rbtnTKPPTemplate = this.Factory.CreateRibbonButton();
            this.tabTKPP.SuspendLayout();
            this.RlblTKPPQuotation.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabTKPP
            // 
            this.tabTKPP.Groups.Add(this.RlblTKPPQuotation);
            this.tabTKPP.Label = "TKPP";
            this.tabTKPP.Name = "tabTKPP";
            // 
            // RlblTKPPQuotation
            // 
            this.RlblTKPPQuotation.Items.Add(this.btnSend_TKPP_RFQ);
            this.RlblTKPPQuotation.Items.Add(this.rbtnTKPPReadRFQ);
            this.RlblTKPPQuotation.Items.Add(this.rbtnTKPPTemplate);
            this.RlblTKPPQuotation.Label = "Quotation";
            this.RlblTKPPQuotation.Name = "RlblTKPPQuotation";
            // 
            // btnSend_TKPP_RFQ
            // 
            this.btnSend_TKPP_RFQ.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnSend_TKPP_RFQ.Description = "Send TKPP";
            this.btnSend_TKPP_RFQ.Image = ((System.Drawing.Image)(resources.GetObject("btnSend_TKPP_RFQ.Image")));
            this.btnSend_TKPP_RFQ.Label = "Send TKPP..";
            this.btnSend_TKPP_RFQ.Name = "btnSend_TKPP_RFQ";
            this.btnSend_TKPP_RFQ.ShowImage = true;
            this.btnSend_TKPP_RFQ.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnSend_TKPP_RFQ_Click);
            // 
            // rbtnTKPPReadRFQ
            // 
            this.rbtnTKPPReadRFQ.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.rbtnTKPPReadRFQ.Image = ((System.Drawing.Image)(resources.GetObject("rbtnTKPPReadRFQ.Image")));
            this.rbtnTKPPReadRFQ.Label = "Read TKPP";
            this.rbtnTKPPReadRFQ.Name = "rbtnTKPPReadRFQ";
            this.rbtnTKPPReadRFQ.ShowImage = true;
            this.rbtnTKPPReadRFQ.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.rbtnTKPPReadRFQ_Click);
            // 
            // rbtnTKPPTemplate
            // 
            this.rbtnTKPPTemplate.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.rbtnTKPPTemplate.Image = ((System.Drawing.Image)(resources.GetObject("rbtnTKPPTemplate.Image")));
            this.rbtnTKPPTemplate.Label = "Template";
            this.rbtnTKPPTemplate.Name = "rbtnTKPPTemplate";
            this.rbtnTKPPTemplate.ShowImage = true;
            this.rbtnTKPPTemplate.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.rbtnTKPPTemplate_Click);
            // 
            // HalliburtonRibbon
            // 
            this.Name = "HalliburtonRibbon";
            this.RibbonType = "Microsoft.Outlook.Explorer";
            this.Tabs.Add(this.tabTKPP);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tabTKPP.ResumeLayout(false);
            this.tabTKPP.PerformLayout();
            this.RlblTKPPQuotation.ResumeLayout(false);
            this.RlblTKPPQuotation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

      //  internal Microsoft.Office.Tools.Ribbon.RibbonTab tabFOSO;
      //  internal Microsoft.Office.Tools.Ribbon.RibbonGroup RlblQuotation;
      //  internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSend_FOSO;
      //  internal Microsoft.Office.Tools.Ribbon.RibbonButton rbtnReadRFQ;
       // internal Microsoft.Office.Tools.Ribbon.RibbonButton rbtnFOSOTemplate;

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabTKPP;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup RlblTKPPQuotation;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSend_TKPP_RFQ;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton rbtnTKPPReadRFQ;
      //  internal Microsoft.Office.Tools.Ribbon.RibbonButton rbtnTKPPReview;
     //   internal Microsoft.Office.Tools.Ribbon.RibbonButton rbtnTKPPSendRFQ;
      //  internal Microsoft.Office.Tools.Ribbon.RibbonButton rbtnTKPPViewRequest;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton rbtnTKPPTemplate;
    }

    partial class ThisRibbonCollection
    {
        internal HalliburtonRibbon Ribbon1
        {
            get { return this.GetRibbon<HalliburtonRibbon>(); }
        }
    }
}
