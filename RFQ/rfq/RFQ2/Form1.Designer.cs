namespace RFQ2
{
    partial class Desktop
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Desktop));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblHid = new System.Windows.Forms.Label();
            this.lblDB = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnUpdateFoso = new System.Windows.Forms.Button();
            this.btnUpdateTkpp = new System.Windows.Forms.Button();
            this.btnMoveEmail = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnVendorMgmt = new System.Windows.Forms.Button();
            this.btnReadRFQ = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.txtMoveEmailHistory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Lavender;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel2.SetColumnSpan(this.tableLayoutPanel1, 2);
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 282F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.Controls.Add(this.lblTime, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDate, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblHid, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDB, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 558);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1124, 57);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTime.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(871, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(216, 57);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "time";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDate.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(649, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(216, 57);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "date";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHid
            // 
            this.lblHid.AutoSize = true;
            this.lblHid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHid.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHid.Location = new System.Drawing.Point(353, 0);
            this.lblHid.Name = "lblHid";
            this.lblHid.Size = new System.Drawing.Size(290, 57);
            this.lblHid.TabIndex = 2;
            this.lblHid.Text = "hid";
            this.lblHid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDB
            // 
            this.lblDB.AutoSize = true;
            this.lblDB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDB.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDB.Location = new System.Drawing.Point(71, 0);
            this.lblDB.Name = "lblDB";
            this.lblDB.Size = new System.Drawing.Size(276, 57);
            this.lblDB.TabIndex = 3;
            this.lblDB.Text = "DB";
            this.lblDB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::RFQ2.Properties.Resources.favicon;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(62, 51);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnUpdateFoso
            // 
            this.btnUpdateFoso.BackColor = System.Drawing.Color.DarkGreen;
            this.btnUpdateFoso.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnUpdateFoso.FlatAppearance.BorderSize = 2;
            this.btnUpdateFoso.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Purple;
            this.btnUpdateFoso.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateFoso.ForeColor = System.Drawing.Color.Transparent;
            this.btnUpdateFoso.Location = new System.Drawing.Point(3, 151);
            this.btnUpdateFoso.Name = "btnUpdateFoso";
            this.btnUpdateFoso.Size = new System.Drawing.Size(436, 55);
            this.btnUpdateFoso.TabIndex = 5;
            this.btnUpdateFoso.Text = "Update FOSO";
            this.btnUpdateFoso.UseVisualStyleBackColor = false;
            this.btnUpdateFoso.Click += new System.EventHandler(this.btnUpdateFoso_Click);
            // 
            // btnUpdateTkpp
            // 
            this.btnUpdateTkpp.BackColor = System.Drawing.Color.DarkGreen;
            this.btnUpdateTkpp.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnUpdateTkpp.FlatAppearance.BorderSize = 2;
            this.btnUpdateTkpp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Purple;
            this.btnUpdateTkpp.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateTkpp.ForeColor = System.Drawing.Color.Transparent;
            this.btnUpdateTkpp.Location = new System.Drawing.Point(3, 214);
            this.btnUpdateTkpp.Name = "btnUpdateTkpp";
            this.btnUpdateTkpp.Size = new System.Drawing.Size(436, 55);
            this.btnUpdateTkpp.TabIndex = 6;
            this.btnUpdateTkpp.Text = "Update TKPP";
            this.btnUpdateTkpp.UseVisualStyleBackColor = false;
            this.btnUpdateTkpp.Click += new System.EventHandler(this.btnUpdateTkpp_Click);
            // 
            // btnMoveEmail
            // 
            this.btnMoveEmail.BackColor = System.Drawing.Color.DarkGreen;
            this.btnMoveEmail.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnMoveEmail.FlatAppearance.BorderSize = 2;
            this.btnMoveEmail.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Purple;
            this.btnMoveEmail.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveEmail.ForeColor = System.Drawing.Color.Transparent;
            this.btnMoveEmail.Location = new System.Drawing.Point(3, 340);
            this.btnMoveEmail.Name = "btnMoveEmail";
            this.btnMoveEmail.Size = new System.Drawing.Size(436, 55);
            this.btnMoveEmail.TabIndex = 7;
            this.btnMoveEmail.Text = "Move Email (Manual)";
            this.btnMoveEmail.UseVisualStyleBackColor = false;
            this.btnMoveEmail.Visible = false;
            this.btnMoveEmail.Click += new System.EventHandler(this.btnMoveEmail_Click_1);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 450F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1130, 618);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.btnUpdateTkpp, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.btnUpdateFoso, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnVendorMgmt, 0, 3);
           // this.tableLayoutPanel3.Controls.Add(this.btnMoveEmail, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.btnReadRFQ, 0, 4);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 6;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(444, 549);
            this.tableLayoutPanel3.TabIndex = 8;
            //this.tableLayoutPanel3.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel3_Paint);
            // 
            // btnVendorMgmt
            // 
            this.btnVendorMgmt.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnVendorMgmt.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnVendorMgmt.FlatAppearance.BorderSize = 2;
            this.btnVendorMgmt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Purple;
            this.btnVendorMgmt.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVendorMgmt.ForeColor = System.Drawing.Color.Transparent;
            this.btnVendorMgmt.Location = new System.Drawing.Point(3, 277);
            this.btnVendorMgmt.Name = "btnVendorMgmt";
            this.btnVendorMgmt.Size = new System.Drawing.Size(436, 55);
            this.btnVendorMgmt.TabIndex = 9;
            this.btnVendorMgmt.Text = "Vendor Mgmt";
            this.btnVendorMgmt.UseVisualStyleBackColor = false;
            this.btnVendorMgmt.Click += new System.EventHandler(this.btnVendorMgmt_Click);
            // 
            // btnReadRFQ
            // 
            this.btnReadRFQ.BackColor = System.Drawing.Color.DarkGreen;
            this.btnReadRFQ.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnReadRFQ.FlatAppearance.BorderSize = 2;
            this.btnReadRFQ.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Purple;
            this.btnReadRFQ.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadRFQ.ForeColor = System.Drawing.Color.Transparent;
            this.btnReadRFQ.Location = new System.Drawing.Point(3, 403);
            this.btnReadRFQ.Name = "btnReadRFQ";
            this.btnReadRFQ.Size = new System.Drawing.Size(436, 49);
            this.btnReadRFQ.TabIndex = 8;
            this.btnReadRFQ.Text = "Read RFQ Email";
            this.btnReadRFQ.UseVisualStyleBackColor = false;
            this.btnReadRFQ.Click += new System.EventHandler(this.btnReadRFQ_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.txtMoveEmailHistory, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(453, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(674, 549);
            this.tableLayoutPanel4.TabIndex = 9;
            // 
            // txtMoveEmailHistory
            // 
            this.txtMoveEmailHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMoveEmailHistory.Location = new System.Drawing.Point(3, 66);
            this.txtMoveEmailHistory.Multiline = true;
            this.txtMoveEmailHistory.Name = "txtMoveEmailHistory";
            this.txtMoveEmailHistory.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMoveEmailHistory.Size = new System.Drawing.Size(668, 455);
            this.txtMoveEmailHistory.TabIndex = 9;
            this.txtMoveEmailHistory.ReadOnly = true;
            
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(668, 63);
            this.label1.TabIndex = 10;
            this.label1.Text = "Auto Move Email history";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 3600000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // Desktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(1130, 618);
            this.Controls.Add(this.tableLayoutPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Desktop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RFQ v2.1.6";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Desktop_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblHid;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblDB;
        private System.Windows.Forms.Button btnUpdateFoso;
        private System.Windows.Forms.Button btnUpdateTkpp;
        private System.Windows.Forms.Button btnMoveEmail;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox txtMoveEmailHistory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Button btnReadRFQ;
        private System.Windows.Forms.Button btnVendorMgmt;
    }
}

