using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalliburtonRFQ.Common
{
   public class MailGenerate
    {
        public string GetBodyContent(DataTable dtRequest)
        {
            string body = string.Empty;
            try
            {
                //Building an HTML string.
                StringBuilder html = new StringBuilder();

                //Table start.
                html.Append("<table>");

                //Building the Header row.
                html.Append("<thead><tr>");
                foreach (DataColumn column in dtRequest.Columns)
                {
                    html.Append("<th>");
                    html.Append(column.ColumnName);
                    html.Append("</th>");
                }
                html.Append("</tr></thead><tbody>");

                //Building the Data rows.
                foreach (DataRow row in dtRequest.Rows)
                {
                    html.Append("<tr>");
                    foreach (DataColumn column in dtRequest.Columns)
                    {
                        html.Append("<td>");
                        html.Append(row[column.ColumnName]);
                        html.Append("</td>");
                    }
                    html.Append("</tr>");
                }

                //Table end.
                html.Append("</tbody></table>");

               
                using (StreamReader reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\Template\\RFQMailTemplate.html"))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{RequestPart}", html.ToString());
                string strBidding = string.Empty, strSignature = string.Empty;
                strBidding = System.DateTime.Now.AddDays(3).ToString("dd/MMMM/yyyy");
                strBidding = strBidding.Replace("-", "/");

                body = body.Replace("{BiddingDeadLine}", strBidding);
                //strSignature = ReadSignature();
                if(string.IsNullOrEmpty(strSignature)!=true)
                {
                    body = body.Replace("{Signature}", strSignature);
                }
                else
                {
                    body = body.Replace("{Signature}", "");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return body;
        }

        public string GetBodyContent_FOSO(DataTable dtRequest)
        {
            string Deadline = dtRequest.Rows[0]["Deadline"].ToString();
            dtRequest.Columns.Remove("VendorID");
            dtRequest.Columns.Remove("RFQ refer");
            dtRequest.Columns.Remove("Deadline");
            dtRequest.AcceptChanges();
            string body = string.Empty;
            try
            {
       
                StringBuilder html = new StringBuilder();

                foreach (DataRow row in dtRequest.Rows)
                {
                    html.Append("<tr>");

                    html.Append("<td valign='top' id='tdTbodys'>" + row["SAP Material Number"] + "</td>");
                    html.Append("<td valign='top' id=''>" + row["Description"] + "</td>");
                    html.Append("<td valign='top' id=''><pre>" + row["Scope of Work"] + "</pre></td>");
                    html.Append("<td valign='top' id=''>" + row["Drawing"] + "</td>");
                    html.Append("<td valign='top' id=''>" + row["REV"] + "</td>");
                    html.Append("<td valign='top' id=''>" + row["LG"] + "</td>");
                    html.Append("<td valign='top' id=''>" + row["Material Assigned"] + "</td>");
                    html.Append("<td valign='top' id='tdTbodys'>" + row["Country Of Origin"] + "</td>");
                    html.Append("<td valign='top' id='tdTbodys'>" + row["Order Quantity"] + "</td>");
                    html.Append("<td valign='top' id='tdTbodys'>" + row["Vendor Quote"] + "</td>");
                    html.Append("<td valign='top' id='tdTbodys'>" + row["Lead Time"] + "</td>");
                    html.Append("<td valign='top' id='tdTbodys'>" + row["UOM"] + "</td>");
                    html.Append("<td valign='top' id='tdTbodys'>" + row["Currency"] + "</td>");
                    html.Append("<td valign='top' id='tdTbodys'>" + row["Price Scale(1-3)"] + "</td>");
                    html.Append("<td valign='top' id='tdTbodys'>" + row["Price Scale(4-9)"] + "</td>");
                    html.Append("<td valign='top' id='tdTbodys'>" + row["Price Scale(>=10)"] + "</td>");
                    html.Append("<td valign='top' id='tdTbodys'>" + row["Remarks"] + "</td>");

                    html.Append("</tr>");
                }

                using (StreamReader reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\Template\\RFQ_FOSO_MailTemplate.html"))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{RequestPart}", html.ToString());
             
                body = body.Replace("{DDMMYY}", Deadline);
                string strSignature = ReadSignature();
                if (string.IsNullOrEmpty(strSignature) != true)
                {
                    body = body.Replace("{Signature}", strSignature);
                }
                else
                {
                    body = body.Replace("{Signature}", "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return body;
        }

        private string ReadSignature()
        {
            string appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Signatures";
            string signature = string.Empty;
            DirectoryInfo diInfo = new DirectoryInfo(appDataDir);

            if (diInfo.Exists)
            {
                FileInfo[] fiSignature = diInfo.GetFiles("*.htm");

                if (fiSignature.Length > 0)
                {
                    StreamReader sr = new StreamReader(fiSignature[0].FullName, Encoding.Default);
                    signature = sr.ReadToEnd();

                    if (!string.IsNullOrEmpty(signature))
                    {
                        string fileName = fiSignature[0].Name.Replace(fiSignature[0].Extension, string.Empty);
                        signature = signature.Replace(fileName + "_files/", appDataDir + "/" + fileName + "_files/");
                    }
                }
            }
            return signature;
        }
    }
}
