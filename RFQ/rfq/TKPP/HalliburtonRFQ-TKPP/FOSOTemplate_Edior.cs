using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalliburtonRFQ
{
    public partial class FOSOTemplate_Edior : Form
    {
        public FOSOTemplate_Edior()
        {
            InitializeComponent();
        }

        private void FOSOTemplate_Edior_Load(object sender, EventArgs e)
        {

            //label1.Text = AppDomain.CurrentDomain.BaseDirectory;
            using (StreamReader reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\Template\\RFQ_FOSO_MailTemplate.html"))
            {
               string body = reader.ReadToEnd();
                editorBox.Text = body;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string htmltext = editorBox.Text;
            StreamWriter reader;// = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Template\\RFQ_TKPP_MailTemplate.html",false);
            using (reader = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Template\\RFQ_FOSO_MailTemplate.html", false))
            {
                reader.Write("");
            }
            reader.Close();
            // string input = reader.ReadToEnd();
            var filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Template\\RFQ_FOSO_MailTemplate.html.html";
           // StreamReader reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\Template\\RFQ_TKPP_MailTemplate.html");
            using (StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Template\\RFQ_FOSO_MailTemplate.html", true))
            {
                {
                    //string output = input.Replace(word, replacement);
                    writer.Write(htmltext);
                }
                writer.Close();
            }
            MessageBox.Show("Template Updated Successfully");
          

            //var document = new HtmlAgilityPack.HtmlDocument(filepath);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + "\\Template\\RFQ_FOSO_MailTemplate.html");
            }
            catch(Exception ex)
            {

            }
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

            FOSOTemplate_Edior te = new FOSOTemplate_Edior();
            te.Dispose();
            te.Hide();
            te.Close();
        }

        private void editorBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
