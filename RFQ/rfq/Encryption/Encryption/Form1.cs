using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encryption
{
   
    public partial class Form1 : Form
    {
        public class Items
        {
            public string Name {  get; set; }
            public string Value {  get; set; }
        }
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("o14ca5898c4e4133bbce2sg2315a2024"); // 16 bytes key for AES-128
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("THIS IS MYIV4321"); // 16 bytes IV
        private string SelectedAuth = string.Empty;
        private int  SelectedAuthI = int.MinValue;
        public Form1()
        {
            InitializeComponent();
            cmb_auth.SelectedIndexChanged += cmb_auth_SelectedIndexChanged;
            cmb_auth.SelectedItem = cmb_auth.Items[0];
            SelectedAuth = cmb_auth.SelectedItem.ToString();
            SelectedAuthI = cmb_auth.SelectedIndex;
           

        }
        private void cmb_auth_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedAuth = cmb_auth.SelectedItem.ToString();
            SelectedAuthI = cmb_auth.SelectedIndex;
            if(SelectedAuthI != 0)
            {
                lbl_user.Enabled = false;
                lbl_pwd.Enabled = false;
                txt_userid.Enabled = false;
                txt_pwd.Enabled = false;
                txt_userid.Text = string.Empty;
                txt_pwd.Text = string.Empty;
            }
            else
            {
                lbl_user.Enabled = true;
                lbl_pwd.Enabled = true;
                txt_userid.Enabled = true;
                txt_pwd.Enabled = true;
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                var txt_sqls= txt_sql.Text.Trim();
                var db = txt_db.Text.Trim();
                var uid = txt_userid.Text.Trim();
                var pwd = txt_pwd.Text.Trim();
                string constring = string.Empty;
                var dataList = new List<Items>();
                dataList.Add(new Items { Name = "SQL Server Name", Value = txt_sqls });
                dataList.Add(new Items { Name = "Database Name", Value = db });
                dataList.Add(new Items { Name = "Database User", Value = uid });
                dataList.Add(new Items { Name = "Password", Value = pwd });
                string Msg = "Cannot Encrypt:\r\n\r\nFill the Following Fields: \r\n";
                int s = 1;
                if (!string.IsNullOrEmpty(txt_sqls) && !string.IsNullOrEmpty(db) && !string.IsNullOrEmpty(SelectedAuth))
                {

                    if (SelectedAuthI == 0)
                    {
                        if (!string.IsNullOrEmpty(uid) && !string.IsNullOrEmpty(pwd))
                        {
                            constring = string.Join(";", $"Data Source={txt_sqls}", $"Initial Catalog={db}", $"User ID={uid}", $"Password={pwd.Replace("&", "&amp;")}") + ";";
                        }
                        else
                        {
                            for (int i = 0; i < dataList.Count ; i++)
                            {
                                if (string.IsNullOrEmpty(dataList[i].Value))
                                {
                                    Msg += $"{s}.{dataList[i].Name}\r\n";
                                    s++;
                                }
                            }
                            MessageBox.Show(Msg, "Please fill", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        constring = string.Join(";", $"Data Source={txt_sqls}", $"Initial Catalog={db}", $"Integrated Security=true") + ";";
                    }
                    if (!string.IsNullOrEmpty(constring))
                    {
                        var encrtypted_text = Encrypt(constring);
                        txt_con.Text = encrtypted_text;
                        txt_plain.Text = constring;
                        ExpandDetailsPanel();
                    }
                    else
                    {
                        txt_con.Text = constring;
                        txt_plain.Text = constring;
                        CollapseDetailsPanel();
                    }
                }
                else
                {
                    if (SelectedAuthI == 0)
                    {
                        for (int i = 0; i < dataList.Count; i++)
                        {
                            if (string.IsNullOrEmpty(dataList[i].Value))
                            {
                                Msg += $"{s}.{dataList[i].Name}\r\n";
                                s++;
                            }
                        }
                        MessageBox.Show(Msg, "Please fill", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        for (int i = 0; i < dataList.Count-2; i++)
                        {
                            if (string.IsNullOrEmpty(dataList[i].Value))
                            {
                                Msg += $"{s}.{dataList[i].Name}\r\n";
                                s++;
                            }
                        }
                        MessageBox.Show(Msg, "Please fill", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }


            }
            catch (Exception eve)
            {
                MessageBox.Show(eve.Message);
            }

        }

        public static string Encrypt(string plainText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(
                        memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(cryptoStream))
                        {
                            writer.Write(plainText);
                        }
                    }
                    return Convert.ToBase64String(memoryStream.ToArray());
                }
            }
        }

        // Decrypt a string using AES
        public static string Decrypt(string cipherText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;

                using (MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(
                        memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cryptoStream))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
        }

        private void btn_plain_Click(object sender, EventArgs e)
        {
            // Check if the TextBox has any text
            if (!string.IsNullOrEmpty(txt_plain.Text))
            {
                Clipboard.SetText(txt_plain.Text); // Copy text to clipboard
            }
        }

        private void btn_enc_Click(object sender, EventArgs e)
        {
            // Check if the TextBox has any text
            if (!string.IsNullOrEmpty(txt_con.Text))
            {
                Clipboard.SetText(txt_con.Text); // Copy text to clipboard
            }
        }

     

        private void ExpandDetailsPanel()
        {
            this.gpBox_details.Visible = true;
        }

        private void CollapseDetailsPanel()
        {
            this.gpBox_details.Visible = false;
        }

        private void btn_clr_Click(object sender, EventArgs e)
        {
            this.gpBox_details.Visible = false;
            string constring = string.Empty;
            txt_sql.Text = constring ;
            txt_db.Text = constring;
            txt_userid.Text = constring;
            txt_pwd.Text = constring;

            lbl_user.Enabled = true;
            lbl_pwd.Enabled = true;
            txt_userid.Enabled = true;
            txt_pwd.Enabled = true;

            txt_con.Text = constring;
            txt_plain.Text = constring;
            cmb_auth.SelectedItem = cmb_auth.Items[0];
            SelectedAuth = cmb_auth.SelectedItem.ToString();
            SelectedAuthI = cmb_auth.SelectedIndex;
            this.AutoSize = true;
            this.Size = new System.Drawing.Size(433, 316);
        }

        private void dtxt_clear_Click(object sender, EventArgs e)
        {
            rich_txt_enc.Clear();
            rich_txt_plain.Clear();

        }

        private void dtxt_copy_Click(object sender, EventArgs e)
        {
            // Check if the TextBox has any text
            if (!string.IsNullOrEmpty(rich_txt_plain.Text))
            {
                Clipboard.SetText(rich_txt_plain.Text); // Copy text to clipboard
            }
        }

        private void dtxt_submit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rich_txt_enc.Text))
            {
                try
                {
                    var plain_text = Decrypt(rich_txt_enc.Text);
                    rich_txt_plain.Text = plain_text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Enter Valid Encrypt string.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }
    }
}
