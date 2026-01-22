using HalliburtonRFQ.Common;
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
    public partial class Template_Edior : Form
    {
        OutlookRibbonLogger outlookRibbonLogger;
        public Template_Edior()
        {
            InitializeComponent();
        }

        private void Template_Edior_Load(object sender, EventArgs e)
        {

            //label1.Text = AppDomain.CurrentDomain.BaseDirectory;
            using (StreamReader reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\Template\\RFQ_TKPP_MailTemplate.html"))
            {
               string body = reader.ReadToEnd();
                richTextBox1.Text = body;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string htmltext = richTextBox1.Text;
            StreamWriter reader;// = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Template\\RFQ_TKPP_MailTemplate.html",false);
            using (reader = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Template\\RFQ_TKPP_MailTemplate.html", false))
            {
                reader.Write("");

            }
            reader.Close();
            // string input = reader.ReadToEnd();
            var filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Template\\RFQ_TKPP_MailTemplate.html";
           // StreamReader reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\Template\\RFQ_TKPP_MailTemplate.html");
            using (StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Template\\RFQ_TKPP_MailTemplate.html", true))
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + "\\Template\\RFQ_TKPP_MailTemplate.html");
            }
            catch(Exception ex)
            {
                outlookRibbonLogger.Log(AppDomain.CurrentDomain.BaseDirectory + "\\Log\\"+ DateTime.Today.ToString("dd-MM-yy") + ".txt", ex.ToString()  );
            }


           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

            Template_Edior te = new Template_Edior();
            te.Dispose();
            te.Hide();
            te.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
