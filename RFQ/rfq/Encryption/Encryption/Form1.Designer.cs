
using System.Drawing;
using System.Windows.Forms;

namespace Encryption
{

    partial class Form1
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
            this.lbl_server = new System.Windows.Forms.Label();
            this.lbl_db = new System.Windows.Forms.Label();
            this.lbl_user = new System.Windows.Forms.Label();
            this.lbl_pwd = new System.Windows.Forms.Label();
            this.txt_sql = new System.Windows.Forms.TextBox();
            this.txt_db = new System.Windows.Forms.TextBox();
            this.txt_userid = new System.Windows.Forms.TextBox();
            this.txt_pwd = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.lbl_encrypted = new System.Windows.Forms.Label();
            this.cmb_auth = new System.Windows.Forms.ComboBox();
            this.lbl_auth = new System.Windows.Forms.Label();
            this.lbl_plain = new System.Windows.Forms.Label();
            this.btn_plain = new System.Windows.Forms.Button();
            this.btn_enc = new System.Windows.Forms.Button();
            this.gpBox_connect = new System.Windows.Forms.GroupBox();
            this.txt_plain = new System.Windows.Forms.RichTextBox();
            this.txt_con = new System.Windows.Forms.RichTextBox();
            this.gpBox_details = new System.Windows.Forms.GroupBox();
            this.btn_clr = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dtxt_copy = new System.Windows.Forms.Button();
            this.rich_txt_plain = new System.Windows.Forms.RichTextBox();
            this.dtxt_submit = new System.Windows.Forms.Button();
            this.dtxt_clear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rich_txt_enc = new System.Windows.Forms.RichTextBox();
            this.gpBox_connect.SuspendLayout();
            this.gpBox_details.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_server
            // 
            this.lbl_server.AutoSize = true;
            this.lbl_server.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_server.Location = new System.Drawing.Point(15, 46);
            this.lbl_server.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_server.Name = "lbl_server";
            this.lbl_server.Size = new System.Drawing.Size(141, 20);
            this.lbl_server.TabIndex = 0;
            this.lbl_server.Text = "SQL Server Name:";
            // 
            // lbl_db
            // 
            this.lbl_db.AutoSize = true;
            this.lbl_db.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_db.Location = new System.Drawing.Point(15, 106);
            this.lbl_db.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_db.Name = "lbl_db";
            this.lbl_db.Size = new System.Drawing.Size(129, 20);
            this.lbl_db.TabIndex = 1;
            this.lbl_db.Text = "Database Name:";
            // 
            // lbl_user
            // 
            this.lbl_user.AutoSize = true;
            this.lbl_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_user.Location = new System.Drawing.Point(15, 211);
            this.lbl_user.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_user.Name = "lbl_user";
            this.lbl_user.Size = new System.Drawing.Size(121, 20);
            this.lbl_user.TabIndex = 2;
            this.lbl_user.Text = "Database User:";
            // 
            // lbl_pwd
            // 
            this.lbl_pwd.AutoSize = true;
            this.lbl_pwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pwd.Location = new System.Drawing.Point(15, 271);
            this.lbl_pwd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_pwd.Name = "lbl_pwd";
            this.lbl_pwd.Size = new System.Drawing.Size(82, 20);
            this.lbl_pwd.TabIndex = 3;
            this.lbl_pwd.Text = "Password:";
            // 
            // txt_sql
            // 
            this.txt_sql.Location = new System.Drawing.Point(237, 43);
            this.txt_sql.Margin = new System.Windows.Forms.Padding(0);
            this.txt_sql.Multiline = true;
            this.txt_sql.Name = "txt_sql";
            this.txt_sql.Size = new System.Drawing.Size(320, 40);
            this.txt_sql.TabIndex = 4;
            // 
            // txt_db
            // 
            this.txt_db.Location = new System.Drawing.Point(237, 103);
            this.txt_db.Margin = new System.Windows.Forms.Padding(0);
            this.txt_db.Multiline = true;
            this.txt_db.Name = "txt_db";
            this.txt_db.Size = new System.Drawing.Size(320, 40);
            this.txt_db.TabIndex = 5;
            // 
            // txt_userid
            // 
            this.txt_userid.Location = new System.Drawing.Point(237, 204);
            this.txt_userid.Margin = new System.Windows.Forms.Padding(0);
            this.txt_userid.Multiline = true;
            this.txt_userid.Name = "txt_userid";
            this.txt_userid.Size = new System.Drawing.Size(320, 40);
            this.txt_userid.TabIndex = 6;
            // 
            // txt_pwd
            // 
            this.txt_pwd.Location = new System.Drawing.Point(237, 264);
            this.txt_pwd.Margin = new System.Windows.Forms.Padding(0);
            this.txt_pwd.Multiline = true;
            this.txt_pwd.Name = "txt_pwd";
            this.txt_pwd.Size = new System.Drawing.Size(320, 40);
            this.txt_pwd.TabIndex = 7;
            // 
            // btn_save
            // 
            this.btn_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_save.Location = new System.Drawing.Point(304, 336);
            this.btn_save.Margin = new System.Windows.Forms.Padding(0);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(111, 35);
            this.btn_save.TabIndex = 8;
            this.btn_save.Text = "Encrypt";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // lbl_encrypted
            // 
            this.lbl_encrypted.AutoSize = true;
            this.lbl_encrypted.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_encrypted.Location = new System.Drawing.Point(35, 192);
            this.lbl_encrypted.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_encrypted.Name = "lbl_encrypted";
            this.lbl_encrypted.Size = new System.Drawing.Size(119, 20);
            this.lbl_encrypted.TabIndex = 10;
            this.lbl_encrypted.Text = "Encrypted Text:";
            // 
            // cmb_auth
            // 
            this.cmb_auth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_auth.FormattingEnabled = true;
            this.cmb_auth.Items.AddRange(new object[] {
            "SQL Server Authentication",
            "Windows Authentication"});
            this.cmb_auth.Location = new System.Drawing.Point(237, 155);
            this.cmb_auth.Name = "cmb_auth";
            this.cmb_auth.Size = new System.Drawing.Size(320, 33);
            this.cmb_auth.TabIndex = 11;
            this.cmb_auth.SelectionChangeCommitted += new System.EventHandler(this.cmb_auth_SelectedIndexChanged);
            // 
            // lbl_auth
            // 
            this.lbl_auth.AutoSize = true;
            this.lbl_auth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_auth.Location = new System.Drawing.Point(19, 155);
            this.lbl_auth.Name = "lbl_auth";
            this.lbl_auth.Size = new System.Drawing.Size(116, 20);
            this.lbl_auth.TabIndex = 12;
            this.lbl_auth.Text = "Authentication:";
            // 
            // lbl_plain
            // 
            this.lbl_plain.AutoSize = true;
            this.lbl_plain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_plain.Location = new System.Drawing.Point(35, 78);
            this.lbl_plain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_plain.Name = "lbl_plain";
            this.lbl_plain.Size = new System.Drawing.Size(81, 20);
            this.lbl_plain.TabIndex = 14;
            this.lbl_plain.Text = "Plain Text:";
            // 
            // btn_plain
            // 
            this.btn_plain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_plain.Location = new System.Drawing.Point(490, 62);
            this.btn_plain.Name = "btn_plain";
            this.btn_plain.Size = new System.Drawing.Size(75, 36);
            this.btn_plain.TabIndex = 15;
            this.btn_plain.Text = "Copy";
            this.btn_plain.UseVisualStyleBackColor = true;
            this.btn_plain.Click += new System.EventHandler(this.btn_plain_Click);
            // 
            // btn_enc
            // 
            this.btn_enc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_enc.Location = new System.Drawing.Point(490, 176);
            this.btn_enc.Name = "btn_enc";
            this.btn_enc.Size = new System.Drawing.Size(75, 36);
            this.btn_enc.TabIndex = 16;
            this.btn_enc.Text = "Copy";
            this.btn_enc.UseVisualStyleBackColor = true;
            this.btn_enc.Click += new System.EventHandler(this.btn_enc_Click);
            // 
            // gpBox_connect
            // 
            this.gpBox_connect.Controls.Add(this.lbl_auth);
            this.gpBox_connect.Controls.Add(this.cmb_auth);
            this.gpBox_connect.Controls.Add(this.txt_pwd);
            this.gpBox_connect.Controls.Add(this.txt_userid);
            this.gpBox_connect.Controls.Add(this.txt_db);
            this.gpBox_connect.Controls.Add(this.txt_sql);
            this.gpBox_connect.Controls.Add(this.lbl_pwd);
            this.gpBox_connect.Controls.Add(this.lbl_user);
            this.gpBox_connect.Controls.Add(this.lbl_db);
            this.gpBox_connect.Controls.Add(this.lbl_server);
            this.gpBox_connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpBox_connect.Location = new System.Drawing.Point(10, 6);
            this.gpBox_connect.Name = "gpBox_connect";
            this.gpBox_connect.Size = new System.Drawing.Size(591, 324);
            this.gpBox_connect.TabIndex = 17;
            this.gpBox_connect.TabStop = false;
            this.gpBox_connect.Text = "Connection Properties";
            // 
            // txt_plain
            // 
            this.txt_plain.Location = new System.Drawing.Point(165, 35);
            this.txt_plain.Name = "txt_plain";
            this.txt_plain.ReadOnly = true;
            this.txt_plain.Size = new System.Drawing.Size(319, 96);
            this.txt_plain.TabIndex = 18;
            this.txt_plain.Text = "";
            // 
            // txt_con
            // 
            this.txt_con.Location = new System.Drawing.Point(165, 149);
            this.txt_con.Name = "txt_con";
            this.txt_con.ReadOnly = true;
            this.txt_con.Size = new System.Drawing.Size(319, 96);
            this.txt_con.TabIndex = 19;
            this.txt_con.Text = "";
            // 
            // gpBox_details
            // 
            this.gpBox_details.AutoSize = true;
            this.gpBox_details.Controls.Add(this.txt_plain);
            this.gpBox_details.Controls.Add(this.txt_con);
            this.gpBox_details.Controls.Add(this.lbl_encrypted);
            this.gpBox_details.Controls.Add(this.lbl_plain);
            this.gpBox_details.Controls.Add(this.btn_plain);
            this.gpBox_details.Controls.Add(this.btn_enc);
            this.gpBox_details.Location = new System.Drawing.Point(10, 377);
            this.gpBox_details.Name = "gpBox_details";
            this.gpBox_details.Size = new System.Drawing.Size(591, 270);
            this.gpBox_details.TabIndex = 20;
            this.gpBox_details.TabStop = false;
            this.gpBox_details.Text = "Connection String:";
            this.gpBox_details.Visible = false;
            // 
            // btn_clr
            // 
            this.btn_clr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_clr.Location = new System.Drawing.Point(175, 336);
            this.btn_clr.Name = "btn_clr";
            this.btn_clr.Size = new System.Drawing.Size(102, 35);
            this.btn_clr.TabIndex = 21;
            this.btn_clr.Text = "Clear";
            this.btn_clr.UseVisualStyleBackColor = true;
            this.btn_clr.Click += new System.EventHandler(this.btn_clr_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.ItemSize = new System.Drawing.Size(100, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(622, 705);
            this.tabControl1.TabIndex = 22;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.gpBox_connect);
            this.tabPage1.Controls.Add(this.btn_clr);
            this.tabPage1.Controls.Add(this.btn_save);
            this.tabPage1.Controls.Add(this.gpBox_details);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(614, 667);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Encrypt";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dtxt_copy);
            this.tabPage2.Controls.Add(this.rich_txt_plain);
            this.tabPage2.Controls.Add(this.dtxt_submit);
            this.tabPage2.Controls.Add(this.dtxt_clear);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.rich_txt_enc);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(614, 667);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Decrypt";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dtxt_copy
            // 
            this.dtxt_copy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtxt_copy.Location = new System.Drawing.Point(253, 494);
            this.dtxt_copy.Name = "dtxt_copy";
            this.dtxt_copy.Size = new System.Drawing.Size(105, 42);
            this.dtxt_copy.TabIndex = 5;
            this.dtxt_copy.Text = "Copy";
            this.dtxt_copy.UseVisualStyleBackColor = true;
            this.dtxt_copy.Click += new System.EventHandler(this.dtxt_copy_Click);
            // 
            // rich_txt_plain
            // 
            this.rich_txt_plain.Location = new System.Drawing.Point(27, 293);
            this.rich_txt_plain.Name = "rich_txt_plain";
            this.rich_txt_plain.ReadOnly = true;
            this.rich_txt_plain.Size = new System.Drawing.Size(566, 162);
            this.rich_txt_plain.TabIndex = 4;
            this.rich_txt_plain.Text = "";
            // 
            // dtxt_submit
            // 
            this.dtxt_submit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtxt_submit.Location = new System.Drawing.Point(320, 219);
            this.dtxt_submit.Name = "dtxt_submit";
            this.dtxt_submit.Size = new System.Drawing.Size(112, 41);
            this.dtxt_submit.TabIndex = 3;
            this.dtxt_submit.Text = "Plain Text";
            this.dtxt_submit.UseVisualStyleBackColor = true;
            this.dtxt_submit.Click += new System.EventHandler(this.dtxt_submit_Click);
            // 
            // dtxt_clear
            // 
            this.dtxt_clear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtxt_clear.Location = new System.Drawing.Point(195, 219);
            this.dtxt_clear.Name = "dtxt_clear";
            this.dtxt_clear.Size = new System.Drawing.Size(75, 41);
            this.dtxt_clear.TabIndex = 2;
            this.dtxt_clear.Text = "Clear";
            this.dtxt_clear.UseVisualStyleBackColor = true;
            this.dtxt_clear.Click += new System.EventHandler(this.dtxt_clear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Encrypted Text:";
            // 
            // rich_txt_enc
            // 
            this.rich_txt_enc.Location = new System.Drawing.Point(27, 71);
            this.rich_txt_enc.Name = "rich_txt_enc";
            this.rich_txt_enc.Size = new System.Drawing.Size(567, 114);
            this.rich_txt_enc.TabIndex = 0;
            this.rich_txt_enc.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(622, 713);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Encrypt the SQL Connection String";
            this.gpBox_connect.ResumeLayout(false);
            this.gpBox_connect.PerformLayout();
            this.gpBox_details.ResumeLayout(false);
            this.gpBox_details.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }
 
        #endregion

        private System.Windows.Forms.Label lbl_server;
        private System.Windows.Forms.Label lbl_db;
        private System.Windows.Forms.Label lbl_user;
        private System.Windows.Forms.Label lbl_pwd;
        private System.Windows.Forms.TextBox txt_sql;
        private System.Windows.Forms.TextBox txt_db;
        private System.Windows.Forms.TextBox txt_userid;
        private System.Windows.Forms.TextBox txt_pwd;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label lbl_encrypted;
        private System.Windows.Forms.ComboBox cmb_auth;
        private System.Windows.Forms.Label lbl_auth;
        private System.Windows.Forms.Label lbl_plain;
        private System.Windows.Forms.Button btn_plain;
        private System.Windows.Forms.Button btn_enc;
        private System.Windows.Forms.GroupBox gpBox_connect;
        private System.Windows.Forms.RichTextBox txt_plain;
        private System.Windows.Forms.RichTextBox txt_con;
        private System.Windows.Forms.GroupBox gpBox_details;
        private Button btn_clr;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button dtxt_submit;
        private Button dtxt_clear;
        private Label label1;
        private RichTextBox rich_txt_enc;
        private Button dtxt_copy;
        private RichTextBox rich_txt_plain;
    }
}

