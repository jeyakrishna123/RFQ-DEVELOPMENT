namespace HalliburtonRFQ
{
    partial class HalliburtonFOSORibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public HalliburtonFOSORibbon()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HalliburtonFOSORibbon));
            this.RtblFOSO = this.Factory.CreateRibbonTab();
            this.RlblQuotationFOSO = this.Factory.CreateRibbonGroup();
            this.RbtnSend_FOSO = this.Factory.CreateRibbonButton();
            this.RbtnReadFOSO = this.Factory.CreateRibbonButton();
            this.RbtnFOSOTemplate = this.Factory.CreateRibbonButton();
            this.RtblFOSO.SuspendLayout();
            this.RlblQuotationFOSO.SuspendLayout();
            this.SuspendLayout();
            // 
            // RtblFOSO
            // 
            this.RtblFOSO.Groups.Add(this.RlblQuotationFOSO);
            this.RtblFOSO.Label = "FOSO";
            this.RtblFOSO.Name = "RtblFOSO";
            // 
            // RlblQuotationFOSO
            // 
            this.RlblQuotationFOSO.Items.Add(this.RbtnSend_FOSO);
            this.RlblQuotationFOSO.Items.Add(this.RbtnReadFOSO);
            this.RlblQuotationFOSO.Items.Add(this.RbtnFOSOTemplate);
            this.RlblQuotationFOSO.Label = "Quotation";
            this.RlblQuotationFOSO.Name = "RlblQuotationFOSO";
            // 
            // RbtnSend_FOSO
            // 
            this.RbtnSend_FOSO.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.RbtnSend_FOSO.Description = "Send FO RFQ";
            this.RbtnSend_FOSO.Image = ((System.Drawing.Image)(resources.GetObject("RbtnSend_FOSO.Image")));
            this.RbtnSend_FOSO.Label = "Send FOSO";
            this.RbtnSend_FOSO.Name = "RbtnSend_FOSO";
            this.RbtnSend_FOSO.ShowImage = true;
            this.RbtnSend_FOSO.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnSend_FO_RFQ_Click);
            // 
            // RbtnReadFOSO
            // 
            this.RbtnReadFOSO.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.RbtnReadFOSO.Image = ((System.Drawing.Image)(resources.GetObject("RbtnReadFOSO.Image")));
            this.RbtnReadFOSO.Label = "Read FOSO";
            this.RbtnReadFOSO.Name = "RbtnReadFOSO";
            this.RbtnReadFOSO.ShowImage = true;
            this.RbtnReadFOSO.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.rbtnReadRFQ_Click);
            // 
            // RbtnFOSOTemplate
            // 
            this.RbtnFOSOTemplate.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.RbtnFOSOTemplate.Description = "Template FOSO";
            this.RbtnFOSOTemplate.Image = ((System.Drawing.Image)(resources.GetObject("RbtnFOSOTemplate.Image")));
            this.RbtnFOSOTemplate.Label = "Template";
            this.RbtnFOSOTemplate.Name = "RbtnFOSOTemplate";
            this.RbtnFOSOTemplate.ShowImage = true;
            this.RbtnFOSOTemplate.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.rbtnFOSOTemplate_Click);
            // 
            // HalliburtonFOSORibbon
            // 
            this.Name = "HalliburtonFOSORibbon";
            this.RibbonType = "Microsoft.Outlook.Explorer";
            this.Tabs.Add(this.RtblFOSO);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.RtblFOSO.ResumeLayout(false);
            this.RtblFOSO.PerformLayout();
            this.RlblQuotationFOSO.ResumeLayout(false);
            this.RlblQuotationFOSO.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab RtblFOSO;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup RlblQuotationFOSO;
      //  internal Microsoft.Office.Tools.Ribbon.RibbonButton rbtnRequest;
      //  internal Microsoft.Office.Tools.Ribbon.RibbonButton rbtnReview;
      //  internal Microsoft.Office.Tools.Ribbon.RibbonButton rbtnSendRFQ;
      //  internal Microsoft.Office.Tools.Ribbon.RibbonButton rbtnViewRequest;
      //  internal Microsoft.Office.Tools.Ribbon.RibbonButton rbtnComparision;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton RbtnSend_FOSO;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton RbtnFOSOTemplate;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton RbtnReadFOSO;
    }

    partial class ThisRibbonCollection
    {
        internal HalliburtonFOSORibbon Ribbon1
        {
            get { return this.GetRibbon<HalliburtonFOSORibbon>(); }
        }
    }
}
