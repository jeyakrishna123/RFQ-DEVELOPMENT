using HalliburtonRFQ.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
                    html.Append("<td valign='top' width='520' id=''>" + row["Description"] + "</td>");
                    html.Append("<td valign='top' width='520' id=''>" + row["Scope of Work"] + "</td>");
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

        string LogRFQ = string.Empty;
        string logpath = string.Empty;
        public string GetBodyContent_PP(DataTable dtRequest)
        {
            DAL_FO_RFQ objDAL_FO_RFQ = new DAL_FO_RFQ();
            //LogRFQ = System.Configuration.ConfigurationManager.AppSettings["LogRFQPP"];
            LogRFQ = objDAL_FO_RFQ.Fetch_ConfigValues("LogRFQPP");
            if (LogRFQ == "1")
            {
                logpath = LogOptions.CreateLogFile();
                LogOptions.Log(logpath, LogCategory.OutlookRibbon, "Log file appended in GetBodyContentPP");
            }
            string Deadline = dtRequest.Rows[0]["RFQ Deadline"].ToString();
            dtRequest.Columns.Remove("Vendor_ID");
            dtRequest.Columns.Remove("RFQ_refer");
            dtRequest.Columns.Remove("RFQ Deadline");
            dtRequest.AcceptChanges();
            string body = string.Empty;
            try
            {
                //dtRequest.Columns.Remove("RFQ refer");
                //dtRequest.AcceptChanges();
                //Building an HTML string.
                StringBuilder html = new StringBuilder();


                foreach (DataRow row in dtRequest.Rows)
                {
                    var Price_Break_1 = row["Price_Break_1"].ToString();
                    var Price_Break_2 = row["Price_Break_2"].ToString();
                    var Price_Break_3 = row["Price_Break_3"].ToString();
                    var Price_Break_4 = row["Price_Break_4"].ToString();
                    var Price_Break_5 = row["Price_Break_5"].ToString();
                    var Price_Break_10 = row["Price_Break_10"].ToString();
                    var Price_Break_25 = row["Price_Break_25"].ToString();
                    var Price_Break_50 = row["Price_Break_50"].ToString();
                    var Price_Break_100 = row["Price_Break_100"].ToString();
                    if (Price_Break_1 == "0")
                    {
                        Price_Break_1 = "";
                    }
                    if (Price_Break_2 == "0")
                    {
                        Price_Break_2 = "";
                    }
                    if (Price_Break_3 == "0")
                    {
                        Price_Break_3 = "";
                    }
                    if (Price_Break_4 == "0")
                    {
                        Price_Break_4 = "";
                    }
                    if (Price_Break_5 == "0")
                    {
                        Price_Break_5 = "";
                    }
                    if (Price_Break_10 == "0")
                    {
                        Price_Break_10 = "";
                    }
                    if (Price_Break_25 == "0")
                    {
                        Price_Break_25 = "";
                    }
                    if (Price_Break_50 == "0")
                    {
                        Price_Break_50 = "";
                    }
                    if (Price_Break_100 == "0")
                    {
                        Price_Break_100 = "";
                    }
                    html.Append("<tr>");

                    html.Append("<td valign='top'  style='border: 1px solid #736c6c; text-align: center;padding: 0px 0px;min-width: 30px;'>" + row["Batch"] + "</td>");
                    html.Append("<td valign='top' id='' style='border: 1px solid #736c6c; text-align: center;padding: 0px 0px;min-width: 30px;'>" + row["PIC"] + "</td>");
                    html.Append("<td valign='top'  id='td_Tbodys' style='border: 1px solid #736c6c; text-align: center;padding: 0px 0px;min-width: 30px;'>" + row["Ordered Part"] + "</td>");
                    html.Append("<td valign='top' id='' style='border: 1px solid #736c6c; text-align: justify;padding:5px;padding-top: 0;font-family: arial, sans-serif;min-width: 30px;max-width:100px;'><pre style='font-family: arial, sans-serif;'>" + row["Part Description"] + "</pre></td>");
                    html.Append("<td valign='top' id='' style='border: 1px solid #736c6c; text-align: center;padding: 0px 0px;min-width: 30px;'>" + row["Order Quantity"] + "</td>");
                    html.Append("<td valign='top' id='tdTbodys' style='border: 1px solid #736c6c; text-align: center;padding: 0px 0px;min-width: 30px;'>" + row["UOM"] + "</td>");
                    html.Append("<td valign='top' id='tdTbodys' style='border: 1px solid #736c6c; text-align: center;padding: 0px 0px;min-width: 30px;'>" + row["Country_Of_Origin"] + "</td>");
                    html.Append("<td valign='top' id='tdTbodys' style='border: 1px solid #736c6c; text-align: center;padding: 0px 0px;min-width: 30px;'>" + row["Conversion_Qty"] + "</td>");
                    html.Append("<td valign='top' id='tdTbodys' style='border: 1px solid #736c6c; text-align: center;padding: 0px 0px;min-width: 30px;'>" + row["LeadTime"] + "</td>");
                    html.Append("<td valign='top' id='tdTbodys' style='border: 1px solid #736c6c; text-align: center;padding: 0px 0px;min-width: 30px;'>" + row["Quotation"] + "</td>");
                    html.Append("<td valign='top' id='tdTbodys' style='border: 1px solid #736c6c; text-align: center;padding: 0px 0px;min-width: 30px;'>" + row["Currency"] + "</td>");
                    html.Append("<td valign='top' id='tdTbodys' style='border: 1px solid #736c6c; text-align: center;padding: 0px 0px;min-width: 30px;'>" + Price_Break_1 + "</td>");
                    html.Append("<td valign='top' id='tdTbodys' style='border: 1px solid #736c6c; text-align: center;padding: 0px 0px;min-width: 30px;'>" + Price_Break_2 + "</td>");
                    html.Append("<td valign='top' id='tdTbodys' style='border: 1px solid #736c6c; text-align: center;padding: 0px 0px;min-width: 30px;'>" + Price_Break_3 + "</td>");
                    html.Append("<td valign='top' id='tdTbodys' style='border: 1px solid #736c6c; text-align: center;padding: 0px 0px;min-width: 30px;'>" + Price_Break_4 + "</td>");
                    html.Append("<td valign='top' id='tdTbodys' style='border: 1px solid #736c6c; text-align: center;padding: 0px 0px;min-width: 30px;'>" + Price_Break_5 + "</td>");
                    html.Append("<td valign='top' id='tdTbodys' style='border: 1px solid #736c6c; text-align: center;padding: 0px 0px;min-width: 30px;'>" + Price_Break_10 + "</td>");
                    html.Append("<td valign='top' id='tdTbodys' style='border: 1px solid #736c6c; text-align: center;padding: 0px 0px;min-width: 30px;'>" + Price_Break_25 + "</td>");
                    html.Append("<td valign='top' id='tdTbodys' style='border: 1px solid #736c6c; text-align: center;padding: 0px 0px;min-width: 30px;'>" + Price_Break_50 + "</td>");
                    html.Append("<td valign='top' id='tdTbodys' style='border: 1px solid #736c6c; text-align: center;padding: 0px 0px;min-width: 30px;'>" + Price_Break_100 + "</td>");
                    html.Append("<td valign='top' id='tdTbodys' style='border: 1px solid #736c6c; text-align: center;padding: 0px 0px;min-width: 30px;'>" + row["Remarks"] + "</td>");

                    html.Append("</tr>");
                }

                using (StreamReader reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\Template\\RFQ_TKPP_MailTemplate.html"))
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
                if (LogRFQ == "1")
                {
                    LogOptions.Log(logpath, LogCategory.OutlookRibbon, "html" + html.ToString());
                    LogOptions.Log(logpath, LogCategory.OutlookRibbon, "Body for table created ");
                }
                if (objDAL_FO_RFQ != null)
                {
                    objDAL_FO_RFQ = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (LogRFQ == "1")
                {
                    LogOptions.Log(logpath, LogCategory.OutlookRibbon, "Error in GetbodycontentPP table creation");
                }
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
