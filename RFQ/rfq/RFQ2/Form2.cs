using Microsoft.Office.Interop.Outlook;
using RFQ2.DB;
using RFQ2.forms;
using RFQ2.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application = Microsoft.Office.Interop.Outlook.Application;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.IO;
using HtmlAgilityPack;
using System.Data.SqlClient;

namespace RFQ2
{
    public partial class Form2 : Form
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Form2()
        {
            InitializeComponent();
            label12.Text = Environment.UserName;
             MYGlobal.getCString();
            label11.Text = "DB: " + MYGlobal.USE_DB;
          
        }
        private void moveEmail()
        {

            ConfigDao dao = DBUtils.getConfigDao(10, null);
            // sent_path = dao.ConfigVal;


            /*DialogResult res = MessageBox.Show("This will copy RFQ mails from your sent folder to "+ dao.ConfigVal + ", Is that ok ? ", "RFQ Sent emails ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.No)
            {
                return;
            }*/

            try
            {
                Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
                //Microsoft.Office.Interop.Outlook.MailItem mailItem = (Microsoft.Office.Interop.Outlook.MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
                Microsoft.Office.Interop.Outlook.NameSpace oNameSpace = oApp.GetNamespace("MAPI");
                Microsoft.Office.Interop.Outlook.MAPIFolder oFolder = oNameSpace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderSentMail);
                // MAPIFolder inBox = this.Application.ActiveExplorer().Session.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
                Items items = oFolder.Items;
                int count = 0;
                int exists_count = 0;
                int cnt = 0;
                int fo_count = 0;
                int so_count = 0;
                int tk_count = 0;
                int pp_count = 0;
                int rfq_count = 0;

                // if subje contains = -FO- , -PP-, -SO-, -TK-


                // foreach (Microsoft.Office.Interop.Outlook.MailItem mail in items)
                for (int x = 0; x <= items.Count; x++)
                {

                    String save_path = dao.ConfigVal + "\\";// + getToday() + "\\";
                    String body = "";
                    try
                    {
                        Microsoft.Office.Interop.Outlook.MailItem mail = (MailItem)items[x];
                        // Microsoft.Office.Interop.Outlook.Recipients oRecips = mail.Recipients;
                        body = mail.Subject;
                        if (body.Contains("RFQ"))
                        {
                            log.Info(cnt + "  Email subject : " + body + "\b\b");
                        }

                        //======== just count all sent folder emails ======
                        count = count + 1;
                        cnt = cnt + 1;


                        if (count == 5)
                        {
                            // return;
                        }

                        if (body.Contains("RE:"))
                        {
                            continue;
                        }

                        if (body.Contains("FW:"))
                        {
                            continue;
                        }


                        body = body.Replace("", "");
                        body = body.Replace("RE: ", "");
                        body = body.Replace("FW: ", "");
                        body = body.Trim();

                        if (body.Contains("RFQ"))
                        {

                            if (body.Contains("-FO-"))
                            {
                                save_path = save_path + "FO\\";
                                fo_count = fo_count + 1;
                            }
                            else if (body.Contains("-PP-"))
                            {
                                pp_count = pp_count + 1;
                                save_path = save_path + "PP\\";

                            }
                            else if (body.Contains("-SO-"))
                            {
                                save_path = save_path + "SO\\";
                                so_count = so_count + 1;

                            }
                            else if (body.Contains("-TK-"))
                            {
                                tk_count = tk_count + 1;
                                save_path = save_path + "TK\\";
                            }



                            if (!Directory.Exists(save_path))
                            {
                                DirectoryInfo di = Directory.CreateDirectory(save_path);
                                log.Info("Created dir " + di.FullName);
                            }


                            String file = save_path + body + ".msg";
                            log.Info("to be saved " + file);
                            if (!File.Exists(file))
                            {
                                mail.SaveAs(file, OlSaveAsType.olMSG);
                                log.Info("Mail saved " + file);
                                rfq_count = rfq_count + 1;
                            }
                            else
                            {
                                log.Info("File " + file + " already exists \n");
                                exists_count = exists_count + 1;
                            }


                            //mail.Delete();
                        }

                    }
                    catch (System.Exception eex)
                    {
                        log.Info("eex : " + eex.Message + " body = "+ body);
                        continue;
                    }
                }//for

                lbl_totalfo_mails.Text = "0";
                lbl_so_emails.Text = "0";
                lbl_pp_emails.Text = "0";
                lbl_tot_tkmails.Text = "0";
                lbl_tot_sentfolder.Text = "0";
                lbl_tot_avail.Text = "0";

                lbl_totalfo_mails.Text = fo_count.ToString();
                lbl_so_emails.Text = so_count.ToString();
                lbl_pp_emails.Text = pp_count.ToString();
                lbl_tot_tkmails.Text = tk_count.ToString();
                lbl_tot_sentfolder.Text = count.ToString();
                lbl_tot_avail.Text = exists_count.ToString();
                String result = "Total [ " + rfq_count + " ] Mails saved to " + dao.ConfigVal + " \r\n Total FO Emails=" + fo_count + ", \r\n Total SO Emails=" + so_count
                     + ", \r\n Total PP EMails=" + pp_count + ", \r\n Total TK Emails=" + tk_count + ", \r\n Total Emails in Sent folder =" + count + ", \r\n Total Exists=" + exists_count;

                appendHistory(result);
                appendHistory("-----------------");
            }
            catch (System.Exception ee)
            {
                log.Error("Error " + ee.Message);
                appendHistory("Error " + ee.Message);
            }
        }
        private void appendHistory(String msg)
        {
            emailhistory.AppendText("\r\n" + msg);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            moveEmail();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadFORFQ();
        }
        private FormFOFRQ frm = null;
        //private Form2 frms = null;
        private FormPPRFQ ppRfq = null;

        private void loadFORFQ()
        {
            if (frm == null)
            {
                frm = new FormFOFRQ();
                frm.Visible = true;
            }
            else
            {
                 frm.Show();
                MessageBox.Show("FO RFQ already Opened");
            }
            //frms.Show();
        }
        private void loadPPRFQ()
        {
            if (ppRfq == null)
            {
                ppRfq = new FormPPRFQ();
                ppRfq.Visible = true;
            }
            else
            {
                ppRfq.Show();
                MessageBox.Show("TKPP RFQ already Opened");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadPPRFQ();
        }
        FormVendorMgmt ven = null;
        private void doLoadVendor()
        {

            if (ven == null)
            {
                ven = new FormVendorMgmt();
                ven.Show();
            }
            else
            {
                MessageBox.Show("Vendor mgmt already opened ");
                ven.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            doLoadVendor();
        }
        private DataTable doFOSOParse(DataTable dt, HtmlAgilityPack.HtmlDocument doc)
        {
            var nodes = doc.DocumentNode.SelectNodes("//table[@id='FOSO_Table']");
            if (nodes != null)
            {
                //Loop in through the table to fetch the header column names
                foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table[@id='FOSO_Table']//thead"))
                {
                    foreach (HtmlNode row in table.SelectNodes("tr[@id='tr']"))
                    {
                        foreach (HtmlNode td in row.SelectNodes("td//span[@class='thead']"))
                        {
                            log.Info("Data - " + td.InnerText);
                            dt.Columns.Add(td.InnerText.Trim().Replace("\r\n", "").Replace("  ", "").Replace("   ", "").Replace("&gt;", ">").Trim());

                        }
                    }
                }


                //Loop in through the table to fetch the data updated by the vendors
                foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table[@id='FOSO_Table']"))
                {

                    foreach (HtmlNode row in table.SelectNodes("tr"))
                    {
                        int i = 0;
                        dt.Rows.Add();
                        foreach (HtmlNode td in row.SelectNodes("td[@id='tdTbodys']"))
                        {
                            log.Info("Data - " + td.InnerText);
                            if (dt.Columns.Count > 0)
                            {
                                dt.Rows[dt.Rows.Count - 1][i] = td.InnerText.Trim().Replace("\r\n", "").Trim();
                                i++;
                            }

                        }
                    }
                }
                dt.AcceptChanges();

            }//if

            return dt;
        }



        private DataTable doTKParse(DataTable dt, HtmlAgilityPack.HtmlDocument doc)
        {
            var nodes = doc.DocumentNode.SelectNodes("//table[@id='TK_Table']");
            if (nodes != null)
            {
                //Loop in through the table to fetch the header column names
                foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table[@id='TK_Table']//thead"))
                {
                    foreach (HtmlNode row in table.SelectNodes("tr"))
                    {
                        foreach (HtmlNode td in row.SelectNodes("td//span[@class='thead']"))
                        {
                            log.Info("Data-1 = " + td.InnerText);
                            dt.Columns.Add(td.InnerText.Trim().Replace("\r\n", "").Replace("  ", "").Replace("   ", "").Replace("&gt;", ">").Trim());

                        }
                    }
                }//foreach


                foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table[@id='TK_Table']//tbody"))
                {
                    if (table.SelectNodes("tr") != null)
                    {
                        foreach (HtmlNode row in table.SelectNodes("tr"))
                        {
                            if (row != null)
                            {
                                int i = 0;
                                dt.Rows.Add();
                                foreach (HtmlNode td in row.SelectNodes("td[@id='tdTbodys']"))
                                {
                                    log.Info("Data-2 =  " + td.InnerText);
                                    if (dt.Columns.Count > 0)
                                    {
                                        dt.Rows[dt.Rows.Count - 1][i] = td.InnerText.Trim().Replace("\r\n", "").Trim();
                                        i++;
                                    }

                                }
                            }

                        }
                    }

                }
                dt.AcceptChanges();

            }//Nodes

            return dt;
        }
        MSSql objDAL_FO_RFQ = new MSSql();
        private string ReceivedQuotationPath = string.Empty;
        string priceScale1ErrMsg = "Invalid Price Scale Value (1-3)";
        string priceScale2ErrMsg = "Invalid Price Scale Value (4-9)";
        string priceScale3ErrMsg = "Invalid Price Scale Value (>=10)";
        string noQuoteErrMsg = "No Vendor Quote available";
        string diffQuoteErrMsg = "Quotation number not same across all the part numbers";

        string initialQuoteNo = String.Empty;
        string noQuote = "NoQuote";

        private void parseFOSOEmail(DataTable receivedMaildt, string titleSubject, string vendorCode, Outlook.MailItem moveMail)
        {
            decimal priceScale1;
            decimal priceScale2;
            decimal priceScale3;


            if (receivedMaildt.Rows.Count > 0)
            {
                DataTable dtRFQReceived = new DataTable();
                dtRFQReceived = receivedMaildt.Copy();
                DataTable dtLinerDetails = new DataTable();
                dtLinerDetails.Columns.Add("RFQ refer");
                dtLinerDetails.Columns.Add("Material Number");
                dtLinerDetails.Columns.Add("Vendor ID");
                dtLinerDetails.Columns.Add("Country_Of_Origin");
                dtLinerDetails.Columns.Add("Order_Quantity");
                dtLinerDetails.Columns.Add("Vendor Quote");
                dtLinerDetails.Columns.Add("UOM");
                dtLinerDetails.Columns.Add("LeadTime");
                dtLinerDetails.Columns.Add("Currency");
                dtLinerDetails.Columns.Add("Price_Scale(1-3)");
                dtLinerDetails.Columns.Add("Price_Scale(4-9)");
                dtLinerDetails.Columns.Add("Price_Scale(>=10)");
                dtLinerDetails.Columns.Add("Remarks");
                dtLinerDetails.Columns.Add("ErrorStatus");

                log.Info("Received Mail Data created" + receivedMaildt.Rows.Count.ToString());

                log.Info("Received Mail copied data" + dtRFQReceived.Rows.Count.ToString());
                String vendorMailId = moveMail.SenderEmailAddress.ToString();
                String subject = moveMail.Subject.ToString();
                string sep = ": ";
                int separatorIndex = subject.IndexOf(sep);
                if (separatorIndex >= 0)
                {
                    RFQRefNum = subject.Substring(separatorIndex + sep.Length);
                    RFQRefNum = RFQRefNum.Substring(0, RFQRefNum.LastIndexOf("-"));
                }

                // string vendorCode = subject.Substring(subject.LastIndexOf('-') + 1);

                //Fetch the received mail folder path of the vendor from tblVendor table
                DataTable ds_Vendor_Email = objDAL_FO_RFQ.FO_RFQ_Fetch_Vendor_Email(vendorCode).Tables[0];
                if (ds_Vendor_Email.Rows.Count > 0)
                {

                    if (string.IsNullOrEmpty(Convert.ToString(ds_Vendor_Email.Rows[0]["FolderPath"])) != true)
                    {
                        vendorattachpath = ds_Vendor_Email.Rows[0]["FolderPath"].ToString();
                        ReceivedQuotationPath = vendorattachpath + @"\ReceivedQuotation";
                        if (!Directory.Exists(ReceivedQuotationPath))
                        {
                            log.Info("ReceivedQuotationPath folder not available");
                            Directory.CreateDirectory(ReceivedQuotationPath);
                            log.Info("ReceivedQuotationPath folder created");
                        }

                    }
                    else
                    {
                        log.Info("Received Quotations Folder path is empty in table tblVendor");
                    }
                }


                int i = 1;
                bool mailSaved = false;
                foreach (DataRow dr in dtRFQReceived.Rows)
                {
                    List<string> errorList = new List<string>();

                    if (isDecimal(dr["Price Scale (1-3)"].ToString()))
                    {
                        priceScale1 = Convert.ToDecimal(dr["Price Scale (1-3)"].ToString());
                    }
                    else
                    {
                        priceScale1 = 0;
                        errorList.Add(priceScale1ErrMsg);
                    }
                    if (isDecimal(dr["Price Scale (4-9)"].ToString()))
                    {
                        priceScale2 = Convert.ToDecimal(dr["Price Scale (4-9)"].ToString());
                    }
                    else
                    {
                        priceScale2 = 0;
                        errorList.Add(priceScale2ErrMsg);
                    }
                    if (isDecimal(dr["Price Scale (>=10)"].ToString()))
                    {
                        priceScale3 = Convert.ToDecimal(dr["Price Scale (>=10)"].ToString());
                    }
                    else
                    {
                        priceScale3 = 0;
                        errorList.Add(priceScale3ErrMsg);
                    }

                    dtLinerDetails.Rows.Add();
                    dtLinerDetails.Rows[dtLinerDetails.Rows.Count - 1]["RFQ refer"] = RFQRefNum;
                    dtLinerDetails.Rows[dtLinerDetails.Rows.Count - 1]["Material Number"] = dr["Material Number"].ToString();
                    dtLinerDetails.Rows[dtLinerDetails.Rows.Count - 1]["Vendor ID"] = vendorCode;
                    dtLinerDetails.Rows[dtLinerDetails.Rows.Count - 1]["Country_Of_Origin"] = dr["Country Of Origin"].ToString();
                    dtLinerDetails.Rows[dtLinerDetails.Rows.Count - 1]["Order_Quantity"] = dr["Order Quantity"].ToString();
                    dtLinerDetails.Rows[dtLinerDetails.Rows.Count - 1]["Vendor Quote"] = dr["Quotation number"].ToString();
                    dtLinerDetails.Rows[dtLinerDetails.Rows.Count - 1]["UOM"] = dr["UOM"].ToString();
                    dtLinerDetails.Rows[dtLinerDetails.Rows.Count - 1]["LeadTime"] = dr["Lead Time (days)"].ToString();

                    dtLinerDetails.Rows[dtLinerDetails.Rows.Count - 1]["Currency"] = dr["Currency"].ToString();
                    dtLinerDetails.Rows[dtLinerDetails.Rows.Count - 1]["Price_Scale(1-3)"] = priceScale1;
                    dtLinerDetails.Rows[dtLinerDetails.Rows.Count - 1]["Price_Scale(4-9)"] = priceScale2;
                    dtLinerDetails.Rows[dtLinerDetails.Rows.Count - 1]["Price_Scale(>=10)"] = priceScale3;
                    dtLinerDetails.Rows[dtLinerDetails.Rows.Count - 1]["Remarks"] = dr["Remarks"].ToString();

                    vendorQuote = dr["Quotation number"].ToString();

                    if (i == 1)
                    {
                        initialQuoteNo = dr["Quotation number"].ToString();
                    }
                    else
                    {
                        if (!vendorQuote.Equals(initialQuoteNo))
                        {
                            errorList.Add(diffQuoteErrMsg);
                        }
                    }

                    if (string.IsNullOrEmpty(initialQuoteNo) != true)
                    {
                        if (!mailSaved)
                        {
                            receivedMailMessage = ReceivedQuotationPath + @"\" + initialQuoteNo.Trim() + "_Dated " + DateTime.Now.ToString("MM/dd/yyyy").Replace("/", "-") + "_Time " + DateTime.Now.ToString("HH:mm:ss tt").Replace(":", "-") + ".msg";
                            log.Info("receivedMailMessage " + receivedMailMessage);
                            moveMail.SaveAs(receivedMailMessage.Trim(), Microsoft.Office.Interop.Outlook.OlSaveAsType.olMSG);
                            mailSaved = true;
                            log.Info("Mail saved inReceivedQuotationPath" + receivedMailMessage);

                        }
                    }
                    else
                    {
                        if (!mailSaved)
                        {
                            receivedMailMessage = ReceivedQuotationPath + @"\" + noQuote + "_Dated " + DateTime.Now.ToString("MM/dd/yyyy").Replace("/", "-") + "_Time " + DateTime.Now.ToString("HH:mm:ss tt").Replace(":", "-") + ".msg";
                            log.Info("receivedMailMessage " + receivedMailMessage);
                            moveMail.SaveAs(receivedMailMessage.Trim(), Microsoft.Office.Interop.Outlook.OlSaveAsType.olMSG);
                            mailSaved = true;
                            log.Info("Mail saved inReceivedQuotationPath" + receivedMailMessage);

                        }

                    }
                    if (string.IsNullOrEmpty(dr["Quotation number"].ToString()) == true)
                    {
                        errorList.Add(noQuoteErrMsg);
                    }

                    String[] errorArray = errorList.ToArray();

                    dtLinerDetails.Rows[dtLinerDetails.Rows.Count - 1]["ErrorStatus"] = String.Join(";", errorArray);
                    dtLinerDetails.AcceptChanges();

                    log.Info("usp_UPD_TK_RFQLiner SP executed");
                    i++;

                }
                objDAL_FO_RFQ.FO_RFQ_UpdateLinerDetails(dtLinerDetails);
            }
        }

        public bool isDecimal(string value)
        {

            try
            {
                Decimal.Parse(value);
                return true;
            }
            catch
            {
                return false;
            }
        }



        bool isPriceBreakNumber;
        string vendorattachpath, vendorQuote;
        string receivedMailMessage;//, rfqReference;

     //   string folderpath;
        string strconfigExcelPath = string.Empty;
        string strconfigExcelSheet = string.Empty;
        string strconfigSentRFQPath = string.Empty;
        string RFQRefNum = string.Empty;
        SqlConnection con;
        SqlDataReader sdr;

        private void parseTKPPEmail(DataTable dt, string titleSubject, string vendorCode, Outlook.MailItem moveMail)
        {
            log.Info("Parse Email ");
            decimal price1 = 0;
            decimal price2 = 0;
            decimal price3 = 0;
            decimal price4 = 0;
            decimal price5 = 0;
            decimal price10 = 0;
            decimal price25 = 0;
            decimal price50 = 0;
            decimal price100 = 0;
            int fcnt = 0;
            int noofrecs;
            string[] arrFolderPath = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", };
            DataTable dtRFQReceived = new DataTable();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    // sw.WriteLine("dt created" + dt.Rows.Count.ToString());
                    dtRFQReceived = dt.Copy();
                    dtRFQReceived.Columns.Add("pricebreakstatus");
                    dtRFQReceived.AcceptChanges();
                }

                vendorattachpath = string.Empty;

                if (dtRFQReceived.Rows.Count > 0)
                {
                    string sep = ": ";
                    int separatorIndex = titleSubject.IndexOf(sep);
                    if (separatorIndex >= 0)
                    {
                        RFQRefNum = titleSubject.Substring(separatorIndex + sep.Length);
                        RFQRefNum = RFQRefNum.Substring(0, RFQRefNum.LastIndexOf("-"));
                    }
                    vendorQuote = string.Empty;
                    for (int r = 0; r <= dtRFQReceived.Rows.Count - 1; r++)
                    {
                        // MessageBox.Show("18");
                        log.Info("dtRFQReceived.Rows.Count greater than 0");
                        log.Info("Ordered Part Number" + dtRFQReceived.Rows[r]["Part Number"].ToString());

                        //need to check price1,price2... is text or number,if any one of it is text then dont update price breaks
                        //in database instead update status column in liner table as input string is not in correct format
                        //and save that mail in receivedquotation path and also move it to READ_RFQ FOLDER(the process
                        //should continue,just update status in database)
                        //isPriceBreakNumber= CheckPriceBreakisNumber(dtRFQReceived.Rows[r]["Price_Break_1"].ToString(), dtRFQReceived.Rows[r]["Price_Break_2"].ToString(), dtRFQReceived.Rows[r]["Price_Break_3"].ToString(), dtRFQReceived.Rows[r]["Price_Break_4"].ToString(), dtRFQReceived.Rows[r]["Price_Break_5"].ToString(), dtRFQReceived.Rows[r]["Price_Break_10"].ToString(), dtRFQReceived.Rows[r]["Price_Break_25"].ToString(), dtRFQReceived.Rows[r]["Price_Break_50"].ToString(), dtRFQReceived.Rows[r]["Price_Break_100"].ToString());
                        isPriceBreakNumber = CheckPriceBreakisNumber(dtRFQReceived.Rows[r]["1"].ToString());

                        if (!isPriceBreakNumber)
                        {
                            price1 = 0;
                            dtRFQReceived.Rows[r]["pricebreakstatus"] = "Input string is not in correct format for price1";
                            //update status column in liner table
                        }
                        else
                        {
                            price1 = dtRFQReceived.Rows[r]["1"].ToString() == "" ? 0 : Convert.ToDecimal(dtRFQReceived.Rows[r]["1"].ToString());
                            log.Info("price1" + price1);
                        }
                        isPriceBreakNumber = CheckPriceBreakisNumber(dtRFQReceived.Rows[r]["2"].ToString());
                        if (!isPriceBreakNumber)
                        {
                            price2 = 0;
                            //Added by Rajan on 5/10/2020 to fix :if client enters other than integer or decimal value in
                            //price column then reason gets updated in pricebreakstatus in database
                            dtRFQReceived.Rows[r]["pricebreakstatus"] = "Input string is not in correct format for price2";
                        }
                        else
                        {
                            price2 = dtRFQReceived.Rows[r]["2"].ToString() == "" ? 0 : Convert.ToDecimal(dtRFQReceived.Rows[r]["2"].ToString());
                            log.Info("price2" + price2);
                        }

                        isPriceBreakNumber = CheckPriceBreakisNumber(dtRFQReceived.Rows[r]["3"].ToString());
                        if (!isPriceBreakNumber)
                        {
                            price3 = 0;
                            dtRFQReceived.Rows[r]["pricebreakstatus"] = "Input string is not in correct format for price3";
                            //update status column in liner table
                        }
                        else
                        {
                            price3 = dtRFQReceived.Rows[r]["3"].ToString() == "" ? 0 : Convert.ToDecimal(dtRFQReceived.Rows[r]["3"].ToString());
                            log.Info("price3" + price3);
                        }

                        isPriceBreakNumber = CheckPriceBreakisNumber(dtRFQReceived.Rows[r]["4"].ToString());
                        if (!isPriceBreakNumber)
                        {
                            price4 = 0;
                            dtRFQReceived.Rows[r]["pricebreakstatus"] = "Input string is not in correct format for price4";
                            //update status column in liner table
                        }
                        else
                        {
                            price4 = dtRFQReceived.Rows[r]["4"].ToString() == "" ? 0 : Convert.ToDecimal(dtRFQReceived.Rows[r]["4"].ToString());
                            log.Info("price4" + price4);
                        }
                        isPriceBreakNumber = CheckPriceBreakisNumber(dtRFQReceived.Rows[r]["5"].ToString());
                        if (!isPriceBreakNumber)
                        {
                            price5 = 0;
                            dtRFQReceived.Rows[r]["pricebreakstatus"] = "Input string is not in correct format for price5";
                            //update status column in liner table
                        }
                        else
                        {
                            price5 = dtRFQReceived.Rows[r]["5"].ToString() == "" ? 0 : Convert.ToDecimal(dtRFQReceived.Rows[r]["5"].ToString());
                            log.Info("price5" + price5);
                        }
                        isPriceBreakNumber = CheckPriceBreakisNumber(dtRFQReceived.Rows[r]["10"].ToString());
                        if (!isPriceBreakNumber)
                        {
                            price10 = 0;
                            dtRFQReceived.Rows[r]["pricebreakstatus"] = "Input string is not in correct format for price10";
                            //update status column in liner table
                        }
                        else
                        {
                            price10 = dtRFQReceived.Rows[r]["10"].ToString() == "" ? 0 : Convert.ToDecimal(dtRFQReceived.Rows[r]["10"].ToString());
                            log.Info("price10" + price10);
                        }
                        isPriceBreakNumber = CheckPriceBreakisNumber(dtRFQReceived.Rows[r]["25"].ToString());
                        if (!isPriceBreakNumber)
                        {
                            price25 = 0;
                            dtRFQReceived.Rows[r]["pricebreakstatus"] = "Input string is not in correct format for price25";
                            //update status column in liner table
                        }
                        else
                        {
                            price25 = dtRFQReceived.Rows[r]["25"].ToString() == "" ? 0 : Convert.ToDecimal(dtRFQReceived.Rows[r]["25"].ToString());
                            log.Info("price25" + price25);
                        }
                        isPriceBreakNumber = CheckPriceBreakisNumber(dtRFQReceived.Rows[r]["50"].ToString());
                        if (!isPriceBreakNumber)
                        {
                            price50 = 0;
                            dtRFQReceived.Rows[r]["pricebreakstatus"] = "Input string is not in correct format for price50";
                            //update status column in liner table
                        }
                        else
                        {
                            price50 = dtRFQReceived.Rows[r]["50"].ToString() == "" ? 0 : Convert.ToDecimal(dtRFQReceived.Rows[r]["50"].ToString());
                            log.Info("price50" + price50);
                        }
                        isPriceBreakNumber = CheckPriceBreakisNumber(dtRFQReceived.Rows[r]["100"].ToString());
                        if (!isPriceBreakNumber)
                        {
                            price100 = 0;
                            dtRFQReceived.Rows[r]["pricebreakstatus"] = "Input string is not in correct format for price100";
                            //update status column in liner table
                        }
                        else
                        {
                            price100 = dtRFQReceived.Rows[r]["100"].ToString() == "" ? 0 : Convert.ToDecimal(dtRFQReceived.Rows[r]["100"].ToString());
                            log.Info("price100" + price100);
                        }

                        string connectionString = MYGlobal.getCString();
                        con = new SqlConnection(connectionString);

                        // MessageBox.Show("19");
                        log.Info("con created");
                        DataSet ds = new DataSet();
                        log.Info("bef open con state" + con.State);
                        log.Info("con connectionstring" + con.ConnectionString);
                        con.Open();
                        //MessageBox.Show("20");
                        log.Info("after open con state" + con.State);
                        log.Info("connection open");
                        SqlCommand cmd = new SqlCommand("usp_UPD_PP_RFQ", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (!string.IsNullOrEmpty(dtRFQReceived.Rows[r]["Quotation #"].ToString()))
                        {
                            vendorQuote = dtRFQReceived.Rows[r]["Quotation #"].ToString();
                        }
                        cmd.Parameters.AddWithValue("@OrderedPart", dtRFQReceived.Rows[r]["Part Number"].ToString());
                        cmd.Parameters.AddWithValue("@VendorCode", vendorCode.ToString());
                        cmd.Parameters.AddWithValue("@Quotation", dtRFQReceived.Rows[r]["Quotation #"].ToString());
                        cmd.Parameters.AddWithValue("@Price_Break_1", price1);
                        cmd.Parameters.AddWithValue("@Price_Break_2", price2);
                        cmd.Parameters.AddWithValue("@Price_Break_3", price3);
                        cmd.Parameters.AddWithValue("@Price_Break_4", price4);
                        cmd.Parameters.AddWithValue("@Price_Break_5", price5);
                        cmd.Parameters.AddWithValue("@Price_Break_10", price10);
                        cmd.Parameters.AddWithValue("@Price_Break_25", price25);
                        cmd.Parameters.AddWithValue("@Price_Break_50", price50);
                        cmd.Parameters.AddWithValue("@Price_Break_100", price100);
                        cmd.Parameters.AddWithValue("@pricebreakstatus", dtRFQReceived.Rows[r]["pricebreakstatus"].ToString());
                        cmd.Parameters.AddWithValue("@Remarks", dtRFQReceived.Rows[r]["Remarks"].ToString());
                        cmd.Parameters.AddWithValue("@LeadTime", dtRFQReceived.Rows[r]["Lead Time in days"].ToString());
                        cmd.Parameters.AddWithValue("@UOM", dtRFQReceived.Rows[r]["UOM"].ToString());
                        cmd.Parameters.AddWithValue("@Conversion_Qty", dtRFQReceived.Rows[r]["Conversion Qty"].ToString());
                        cmd.Parameters.AddWithValue("@Country_of_Origin", dtRFQReceived.Rows[r]["COO"].ToString());
                        cmd.Parameters.AddWithValue("@Currency", dtRFQReceived.Rows[r]["Currency"].ToString());
                        cmd.Parameters.AddWithValue("@RFQ_Refer", RFQRefNum);

                        cmd.ExecuteNonQuery();
                        log.Info("usp_UPD_FO_RFQ executed \n\n");
                    }//dtRFQReceived for loop


                    log.Info("vendorcode " + vendorCode.ToString());
                    if (!string.IsNullOrEmpty(vendorCode.ToString()))
                    {
                        SqlCommand cmd1 = new SqlCommand("usp_FETCH_Vendor_Path", con);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@VendorCode", vendorCode.ToString());
                        //  object objval = cmd1.ExecuteScalar();

                        sdr = cmd1.ExecuteReader();

                        while (sdr.Read())
                        {
                            if (sdr.HasRows)
                            {
                                if (!string.IsNullOrEmpty(sdr["FolderPath"].ToString()))
                                    arrFolderPath[fcnt] = (string)sdr["FolderPath"];
                            }
                            fcnt++;
                        }
                        fcnt = 0;

                        noofrecs = arrFolderPath.Count(s => s != "");

                        if (noofrecs == 1)
                        {
                            if (arrFolderPath[0] != "")
                            {
                                vendorattachpath = arrFolderPath[0];
                                // Read All Attachements of RFQ FOLDER
                                var attachments = moveMail.Attachments;
                                log.Info("noofrecs1");
                                //  sw.WriteLine("vendorattachpath " + vendorattachpath);
                                //Added by Rajan on 2/8/2020
                                if (!String.IsNullOrEmpty(vendorattachpath))
                                {
                                    //MessageBox.Show("22");
                                    //   sw.WriteLine("Goes inside vendorattachpath");
                                    ReceivedQuotationPath = vendorattachpath + @"\ReceivedQuotation";

                                    log.Info("ReceivedQuotationPath" + ReceivedQuotationPath);
                                    if (!Directory.Exists(vendorattachpath))
                                    {
                                        Directory.CreateDirectory(vendorattachpath);
                                        Directory.CreateDirectory(ReceivedQuotationPath);
                                        //   sw.WriteLine("vendorattachpath created");
                                        //    sw.WriteLine("ReceivedQuotationPath created");
                                    }
                                    //ONLY receivedquotationpath is created,removed sentrfq and attachments path
                                    if (Directory.Exists(vendorattachpath))
                                    {
                                        if (!Directory.Exists(ReceivedQuotationPath))
                                        {
                                            Directory.CreateDirectory(ReceivedQuotationPath);
                                            log.Info("vendor attachpath exist but receivedquotationpath not exist, so created");
                                        }

                                        //  receivedMailMessage = ReceivedQuotationPath + @"\" + Subject.Trim().Replace(": ", "-") + " " + DateTime.Now.ToString().Replace("/", "-").Replace(":", "-") + ".msg";

                                        if (!string.IsNullOrEmpty(vendorQuote))
                                        {
                                            receivedMailMessage = ReceivedQuotationPath + @"\" + vendorQuote.Trim() + "_Dated " + DateTime.Now.ToString("MM/dd/yyyy").Replace("/", "-") + "_Time " + DateTime.Now.ToString("HH:mm:ss tt").Replace(":", "-") + ".msg";
                                            moveMail.SaveAs(receivedMailMessage.Trim(), Microsoft.Office.Interop.Outlook.OlSaveAsType.olMSG);
                                            log.Info("Mail saved inReceivedQuotationPath" + receivedMailMessage);
                                            // lstMailItem.Add(moveMail);
                                        }
                                        else
                                        {
                                            receivedMailMessage = ReceivedQuotationPath + @"\" + "NoVendorQuote" + "_Dated " + DateTime.Now.ToString("MM/dd/yyyy").Replace("/", "-") + "_Time " + DateTime.Now.ToString("HH:mm:ss tt").Replace(":", "-") + ".msg";
                                            moveMail.SaveAs(receivedMailMessage.Trim(), Microsoft.Office.Interop.Outlook.OlSaveAsType.olMSG);
                                            log.Info("Mail saved inReceivedQuotationPath" + receivedMailMessage);
                                            //MessageBox.Show("VendorQuote is Empty ,Mail Not saved");
                                            log.Info("VendorQuote is Empty ");
                                            //lstMailItem.Add(moveMail);
                                        }
                                        log.Info("");
                                    }//Vendorattachpath dir exist
                                }
                                else
                                {
                                    log.Info("2Vendor folder PATH IS EMPTY");
                                }
                            }
                        }

                        else if (noofrecs > 1)
                        {
                            for (int a = 0; a < arrFolderPath.Count(); a++)
                            {
                                if (arrFolderPath[a] != "")
                                {
                                    vendorattachpath = arrFolderPath[a];
                                    // Read All Attachements of RFQ FOLDER
                                    var attachments = moveMail.Attachments;
                                    log.Info("noofrecsgreaterthan1");
                                    //    sw.WriteLine("attachments created");
                                    //     sw.WriteLine("vendorattachpath " + vendorattachpath);
                                    //Added by Rajan on 2/8/2020
                                    if (!String.IsNullOrEmpty(vendorattachpath))
                                    {
                                        //MessageBox.Show("22");
                                        //  sw.WriteLine("Goes inside vendorattachpath");
                                        ReceivedQuotationPath = vendorattachpath + @"\ReceivedQuotation";

                                        log.Info("ReceivedQuotationPath" + ReceivedQuotationPath);
                                        //ONLY receivedquotationpath is created,removed sentrfq and attachments path
                                        if (!Directory.Exists(vendorattachpath))
                                        {
                                            Directory.CreateDirectory(vendorattachpath);
                                            Directory.CreateDirectory(ReceivedQuotationPath);
                                            log.Info("vendorattachpath created");
                                            log.Info("ReceivedQuotationPath created");
                                        }
                                        if (Directory.Exists(vendorattachpath))
                                        {
                                            if (!Directory.Exists(ReceivedQuotationPath))
                                            {
                                                Directory.CreateDirectory(ReceivedQuotationPath);
                                                //     sw.WriteLine("vendor attachpath exist but receivedquotationpath not exist, so created");
                                            }

                                            //  receivedMailMessage = ReceivedQuotationPath + @"\" + Subject.Trim().Replace(": ", "-") + " " + DateTime.Now.ToString().Replace("/", "-").Replace(":", "-") + ".msg";
                                            //All part numbers use same vendorquote
                                            if (!string.IsNullOrEmpty(vendorQuote))
                                            {
                                                receivedMailMessage = ReceivedQuotationPath + @"\" + vendorQuote.Trim() + "_Dated " + DateTime.Now.ToString("MM/dd/yyyy").Replace("/", "-") + "_Time " + DateTime.Now.ToString("HH:mm:ss tt").Replace(":", "-") + ".msg";
                                                moveMail.SaveAs(receivedMailMessage.Trim(), Microsoft.Office.Interop.Outlook.OlSaveAsType.olMSG);
                                                log.Info("Mail saved inReceivedQuotationPath" + receivedMailMessage);
                                                //lstMailItem.Add(moveMail);
                                            }
                                            else
                                            {
                                                //MessageBox.Show("VendorQuote is Empty ,Mail Not saved");
                                                receivedMailMessage = ReceivedQuotationPath + @"\" + "NoQuote" + "_Dated " + DateTime.Now.ToString("MM/dd/yyyy").Replace("/", "-") + "_Time " + DateTime.Now.ToString("HH:mm:ss tt").Replace(":", "-") + ".msg";
                                                moveMail.SaveAs(receivedMailMessage.Trim(), Microsoft.Office.Interop.Outlook.OlSaveAsType.olMSG);
                                                log.Info("Mail saved inReceivedQuotationPath" + receivedMailMessage);
                                                log.Info("VendorQuote is Empty");
                                                //lstMailItem.Add(moveMail);
                                            }
                                            log.Info("");
                                        }//Vendorattachpath dir exist
                                    }
                                    else
                                    {
                                        log.Info("2Vendor PATH IS EMPTY");
                                    }
                                }
                            }//multiple folder path for loop
                        }//NOOFRECS >1 ,multiple folder path for same vendor
                        else if (noofrecs == 0)
                        {
                            MessageBox.Show("FolderPath not exist for this vendor in Database");
                            //  sw.WriteLine("Folder not exist for this vendor in Database");
                        }



                    }

                }
            }
        }

        Boolean CheckPriceBreakisNumber(string price)
        {
            //if price1 isnumeric return price1,if price2 isnumeric return price2
            var isPriceNumeric = int.TryParse(price.ToString(), out int n);
            var isPriceDecimal = true;

            if (!isPriceNumeric)
            {
                //Added by Rajan on 5/10/2020 for the following fix: 
                //To allow decimal value in price column, the following condition have been added.
                isPriceDecimal = Decimal.TryParse(price.ToString(), out decimal r);
                if (isPriceDecimal)
                {
                    return true;
                }
                return false;
            }
            return true;

        }
       // bool isReadRFQFolder = false;
        string Subject;
       // int hdrrcount = 0;
        int rcount = 0;

        private void button5_Click(object sender, EventArgs e)
        {
            doReadEmail();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label19.Text = DateTime.Now.ToString("MM-dd-yyyy");
            label18.Text = DateTime.Now.ToString("HH:mm:ss:tt");
        }

        //int scount = 1;
        private void doReadEmail()
        {
            Outlook.Application application = new Outlook.Application();
            Outlook.MailItem moveMail = null;
            Outlook.MAPIFolder inBox = (Outlook.MAPIFolder)application.
                ActiveExplorer().Session.GetDefaultFolder
                (Outlook.OlDefaultFolders.olFolderInbox);

            Outlook.Items items = (Outlook.Items)inBox.Items;
            Outlook.MAPIFolder readRFQFolder;

            items.Restrict("[UnRead] = true");
            List<Outlook.MailItem> lstMailItem = new List<Outlook.MailItem>();


            if (items != null)
            {
                Outlook.MAPIFolder rootFolder = (Outlook.MAPIFolder)inBox.Parent;
                readRFQFolder = rootFolder.Folders["Read_RFQ"];
               // this.isReadRFQFolder = true;

                foreach (object eMail in items)
                {
                    moveMail = eMail as Outlook.MailItem;


                    if (moveMail != null)
                    {
                        string titleSubject = (string)moveMail.Subject;
                        Recipients from_e = moveMail.Recipients;

                        if (titleSubject != null || titleSubject.Length < 1)
                        {
                            titleSubject = "";
                        }
                        else
                        {
                            Subject = titleSubject.ToLower().Trim();
                        }


                        string extREMailSubject = "[External] RE: RFQ";
                        string extFwMailSubject = "[External] FW: RFQ";
                        string extFwdMailSubject = "[External] FWD: RFQ";




                       // hdrrcount = 0;
                        DataTable dt = new DataTable();

                        if (!string.IsNullOrEmpty(Subject) && !string.IsNullOrWhiteSpace(Subject))
                        {
                            if (Subject.Contains(extREMailSubject.ToLower()) || Subject.Contains(extFwMailSubject.ToLower()) || Subject.Contains(extFwdMailSubject.ToLower()))
                            {
                                log.Info("RFQ Mail found in Inbox from_e=" + from_e + " , Subject=" + Subject + "\n");
                                if (rcount == 0)
                                {
                                    rcount = 1;
                                }

                                string vendorCode = titleSubject.Substring(titleSubject.LastIndexOf('-') + 1);

                                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                                String html_body = moveMail.HTMLBody;
                                doc.LoadHtml(moveMail.HTMLBody);

                               // bool firstRow = true;

                                var isTABLEExist = doc.DocumentNode.Descendants("table").Any();
                                if (isTABLEExist)
                                {
                                    if (doc.DocumentNode.SelectSingleNode("//table[@id='TK_Table']") != null)
                                    {
                                        log.Info("Got TK_Table");
                                        //log.Info("html_body " + html_body);
                                        dt = doTKParse(dt, doc);

                                        parseTKPPEmail(dt, titleSubject, vendorCode, moveMail);
                                    }

                                    else if (doc.DocumentNode.SelectSingleNode("//table[@id='FOSO_Table']") != null)
                                    {

                                        log.Info("GOT FOSO_Table \n\n\n ======================================\n\n\n");
                                        dt = doFOSOParse(dt, doc);

                                        parseFOSOEmail(dt, titleSubject, vendorCode, moveMail);
                                    }
                                    else
                                    {
                                        log.Info("TK_Table OR FOSO_Table is null");
                                    }

                                    // doTKParse(dt, doc);


                                }//table exists

                            }
                        }
                    }
                }
            }
        }
    }
}
