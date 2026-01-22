using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Outlook = Microsoft.Office.Interop.Outlook;
using HtmlAgilityPack;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.Data;
using HalliburtonRFQ.DAL;
using HalliburtonRFQ.Common;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Outlook;
using System.Drawing;
using System.Diagnostics;
using DocumentFormat.OpenXml.Bibliography;
using System.ComponentModel;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
//using Microsoft.Office.Interop.Outlook;

namespace HalliburtonRFQ
{
    public partial class HalliburtonRibbon
    {
        DataTable dtsource = new DataTable();
        MailGenerate objMailGenerate = new MailGenerate();
        private string vendorPath = string.Empty;
        private string SentRFQPath = string.Empty;
        private string ReceivedQuotationPath = string.Empty;
        //private string AttachmentsPath = string.Empty;
        StreamWriter sw = null;
        string LogRFQ;
        string logpath;
        string Subject;
        string vendorattachpath, vendorQuote;
        string receivedMailMessage;
        int rcount = 0;
        int scount = 1;
        bool mailSent = false;
        string prevvendorid=string.Empty;
        String[] strlist = { "" };
        DataTable dtcpyemailtemplate;
        bool isReadRFQFolder = false;
        int hdrrcount = 0;
        string RFQRefNum = string.Empty;
        bool isPriceBreakNumber;
        ExceptionHandler handler = new ExceptionHandler();
        SqlConnection con;
        SqlDataReader sdr;
        string[] arrFolderPath = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", };
        int fcnt;
        int noofrecs;
        OutlookRibbonLogger outlookRibbonLogger;
        string strconfigExcelPath = string.Empty;
        string strconfigExcelSheet = string.Empty;
        string strconfigSentRFQPath = string.Empty;
        string[] rfqRefer;
        private string vendorcategory = string.Empty;
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        #region Not in use 
        private static void ReleaseComObject(object obj)
        {
            if (obj != null)
            {
                Marshal.ReleaseComObject(obj);
                obj = null;
            }
        }
        public static void DisplayAccountInformation()
        {
            Outlook.Application application = new Outlook.Application();
            // The Namespace Object (Session) has a collection of accounts.
            Outlook.Accounts accounts = application.Session.Accounts;

            // Concatenate a message with information about all accounts.
            StringBuilder builder = new StringBuilder();

            // Loop over all accounts and print detail account information.
            // All properties of the Account object are read-only.
            foreach (Outlook.Account account in accounts)
            {

                // The DisplayName property represents the friendly name of the account.
                builder.AppendFormat("DisplayName: {0}\n", account.DisplayName);

                // The UserName property provides an account-based context to determine identity.
                builder.AppendFormat("UserName: {0}\n", account.UserName);

                // The SmtpAddress property provides the SMTP address for the account.
                builder.AppendFormat("SmtpAddress: {0}\n", account.SmtpAddress);

                // The AccountType property indicates the type of the account.
                builder.Append("AccountType: ");
                switch (account.AccountType)
                {

                    case Outlook.OlAccountType.olExchange:
                        builder.AppendLine("Exchange");
                        break;

                    case Outlook.OlAccountType.olHttp:
                        builder.AppendLine("Http");
                        break;

                    case Outlook.OlAccountType.olImap:
                        builder.AppendLine("Imap");
                        break;

                    case Outlook.OlAccountType.olOtherAccount:
                        builder.AppendLine("Other");
                        break;

                    case Outlook.OlAccountType.olPop3:
                        builder.AppendLine("Pop3");
                        break;
                }

                builder.AppendLine();
            }

            // Display the account information.
            System.Windows.Forms.MessageBox.Show(builder.ToString());
        }

        private RequestPart objRequest = null;

        private RequestApproval objRequestApproval = null;

        private SendRFQ objSendRFQ = null;

        private ViewRequest objViewRequest = null;

        private Quote_Comparision objQuote_Comparision = null;
        private void rbtnRequest_Click(object sender, RibbonControlEventArgs e)
        {

            try
            {
                if (objRequest == null)
                {
                    objRequest = new RequestPart(Globals.ThisAddIn.Application);
                }

                if (objRequest.IsDisposed)
                    objRequest = new RequestPart(Globals.ThisAddIn.Application);
                objRequest.Show();
            }
            catch (System.Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.ToString());
            }
        }

        private void rbtnReview_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                if (objRequestApproval == null)
                {
                    objRequestApproval = new RequestApproval(Globals.ThisAddIn.Application);
                }

                if (objRequestApproval.IsDisposed)
                    objRequestApproval = new RequestApproval(Globals.ThisAddIn.Application);
                objRequestApproval.Show();
            }
            catch (System.Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.ToString());
            }
        }

        private void rbtnSendRFQ_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                if (objSendRFQ == null)
                {
                    objSendRFQ = new SendRFQ(Globals.ThisAddIn.Application);
                }

                if (objSendRFQ.IsDisposed)
                    objSendRFQ = new SendRFQ(Globals.ThisAddIn.Application);

                objSendRFQ.Show();
            }
            catch (System.Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.ToString());
            }
        }

        private void rbtnViewRequest_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                if (objViewRequest == null)
                {
                    objViewRequest = new ViewRequest(Globals.ThisAddIn.Application);
                }
                if (objViewRequest.IsDisposed)
                    objViewRequest = new ViewRequest(Globals.ThisAddIn.Application);
                objViewRequest.Show();
            }
            catch (System.Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.ToString());
            }
        }

        private void rbtnComparision_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                try
                {
                    if (objQuote_Comparision == null)
                    {
                        objQuote_Comparision = new Quote_Comparision(Globals.ThisAddIn.Application);
                    }
                    if (objQuote_Comparision.IsDisposed)
                        objQuote_Comparision = new Quote_Comparision(Globals.ThisAddIn.Application);
                    objQuote_Comparision.Show();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }

        private void btnSend_FO_RFQ_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                LogRFQ = System.Configuration.ConfigurationManager.AppSettings["LogRFQ"];
                DAL_FO_RFQ objDAL_FO_RFQ = new DAL_FO_RFQ();
                DataSet dsSQL = new DataSet();
                DataTable dtSQL = new DataTable();
                DataTable dtFilter_Final = new DataTable();

                DataTable dtLiner_Filter = new DataTable();
                DataTable dtHeader = new DataTable();
                DataTable dtLiner = new DataTable();

                DataTable dtTK_Header = new DataTable();

                List<DataColumn> headerToBeDeletedCols = new List<DataColumn>();
                List<DataColumn> linerToBeDeletedCols = new List<DataColumn>();
                
                Dictionary<string, string> configValues = new Dictionary<string, string>();


                DataTable dt = new DataTable();
                DataTable dtLinerFilter = new DataTable();

                
                string excelPath = string.Empty;
                string excelSheet = string.Empty;
                string sentRFQPath = string.Empty;
                try
                {
                    DataTable configValuesdt = objDAL_FO_RFQ.getConfig();
                    configValues = configValuesdt.AsEnumerable()
                            .ToDictionary<DataRow, string, string>(row => row[0].ToString(),
                                            row => row[1].ToString());

                    excelPath = configValues["FOSO_ExcelPath"];
                    excelSheet = configValues["FOSO_ExcelSheet"];
                    sentRFQPath = configValues["FOSOSentRFQ"];
                }
                catch(System.Data.SqlClient.SqlException ex) {
                    throw ex;

                }

                Assignvalues(excelPath, excelSheet);

                if (LogRFQ == "1")
                {
                    logpath = LogOptions.CreateLogFile();
                    LogOptions.Log(logpath, LogCategory.OutlookRibbon, "Records pulled from Excel" + DateTime.Now);
                }

                //dtsource=RFQ copied from excel (RFQ Tool)
                if (dtsource.Rows.Count > 0)
                {
                    
                    dsSQL = objDAL_FO_RFQ.FO_RFQ_Fetch_LinerDetails();
                    dtSQL = dsSQL.Tables[0];
                   
                    var filter = from firstDt in dtsource.AsEnumerable()
                                 where !(from secondDt in dtSQL.AsEnumerable() select secondDt["SAP Material Number"]).Contains(firstDt["SAP Material Number"].ToString())
                                 select firstDt;
                    if (LogRFQ == "1")
                    {
                        LogOptions.Log(logpath, LogCategory.OutlookRibbon, "Excel records should not contain liner details records" + filter);
                    }
                    if (filter.Count() == 0)
                    {
                        MessageBox.Show("No RFQ available");
                    }
                    else
                    {
                        dtFilter_Final = filter.CopyToDataTable();

                        if (dtFilter_Final.Rows.Count > 0)
                        {
                            
                            SendRFQ_FOSO objSendRFQ_FOSO = new SendRFQ_FOSO(dtFilter_Final);
                            objSendRFQ_FOSO.ShowDialog();

                            if ((objSendRFQ_FOSO.dtnew != null) && (objSendRFQ_FOSO.dtnew.Rows.Count > 0))
                            {
                                dt = objSendRFQ_FOSO.dtnew;
                                if (dt.Rows.Count > 0)
                                {

                                    dtHeader = dt.Copy();
                                    dtLiner = dt.Copy();
                                    //To have a place holder in udt header table to insert today's date in CreatedDate and ModifiedDate columns
                                    dtHeader.Columns.Add("CreatedDate", typeof(DateTime));
                                    dtHeader.Columns.Add("ModifiedDate", typeof(DateTime));

                                    foreach (DataColumn column in dtHeader.Columns)
                                    {
                                        if (column.ColumnName.Contains("V Quote") || column.ColumnName.Contains("V#") || column.ColumnName.Contains("Remarks") || column.ColumnName.Contains("UOM") || column.ColumnName.Contains("Price Scale"))
                                        {
                                            headerToBeDeletedCols.Add(column);
                                        }

                                    }
                                    foreach (DataColumn col in headerToBeDeletedCols)
                                    {
                                        dtHeader.Columns.Remove(col);
                                        dtHeader.AcceptChanges();
                                    }

                                    foreach (DataColumn column in dtLiner.Columns)
                                    {
                                        if (!(column.ColumnName.Contains("V Quote") || column.ColumnName.Contains("V#") || column.ColumnName.Contains("Remarks") || column.ColumnName.Contains("UOM") || column.ColumnName.Contains("Price Scale") || column.ColumnName.Contains("SAP Material Number") || column.ColumnName.Contains("RFQ refer")))
                                        {
                                            linerToBeDeletedCols.Add(column);
                                        }

                                    }
                                    foreach (DataColumn col in linerToBeDeletedCols)
                                    {
                                        dtLiner.Columns.Remove(col);
                                        dtLiner.AcceptChanges();
                                    }
                                    
                                    dtLinerFilter.Columns.Add("SAP Material Number");
                                    dtLinerFilter.Columns.Add("RFQ refer"); 
                                    dtLinerFilter.Columns.Add("VendorID");
                                    dtLinerFilter.Columns.Add("Vendor Quote");
                                    dtLinerFilter.Columns.Add("UOM");
                                    dtLinerFilter.Columns.Add("Price Scale(1-3)");
                                    dtLinerFilter.Columns.Add("Price Scale(4-9)");
                                    dtLinerFilter.Columns.Add("Price Scale(>=10)");                               
                                    dtLinerFilter.Columns.Add("CreatedDate", typeof(DateTime));
                                    dtLinerFilter.Columns.Add("ModifiedDate", typeof(DateTime));


                                    for (int i = 0; i < dtLiner.Rows.Count; i++)
                                    {
                                        for (int j = 1; j <= 5; j++)
                                        {

                                           if (dtLiner.Rows[i]["V#" + (j) + ""].ToString() != String.Empty)
                                           {
                                                dtLinerFilter.Rows.Add();
                                                dtLinerFilter.Rows[dtLinerFilter.Rows.Count - 1]["VendorID"] = dtLiner.Rows[i]["V#" + (j) + ""];
                                                dtLinerFilter.Rows[dtLinerFilter.Rows.Count - 1]["Vendor Quote"] = dtLiner.Rows[i]["V Quote-V#" + (j) + ""];
                                                dtLinerFilter.Rows[dtLinerFilter.Rows.Count - 1]["Price Scale(1-3)"] = dtLiner.Rows[i]["Price Scale-V#" + (j) + "(1-3)"];
                                                dtLinerFilter.Rows[dtLinerFilter.Rows.Count - 1]["Price Scale(4-9)"] = dtLiner.Rows[i]["Price Scale-V#" + (j) + "(4-9)"];
                                                dtLinerFilter.Rows[dtLinerFilter.Rows.Count - 1]["Price Scale(>=10)"] = dtLiner.Rows[i]["Price Scale-V#" + (j) + "(>=10)"];
                                                dtLinerFilter.Rows[dtLinerFilter.Rows.Count - 1]["SAP Material Number"] =
                                                    dtLiner.Rows[i]["SAP Material Number"];
                                                
                                                dtLinerFilter.Rows[dtLinerFilter.Rows.Count - 1]["UOM"] = dtLiner.Rows[i]["UOM"];
                                                dtLinerFilter.Rows[dtLinerFilter.Rows.Count - 1]["RFQ refer"] = dtLiner.Rows[i]["RFQ refer"];
                                           }

                                        }
                                    }
                                    dtLinerFilter.AcceptChanges();

                                }

                                DataTable dtTemplate = new DataTable();
                                dtTemplate = dtLinerFilter.Copy();

                                // New columns to be sent in mail
                                dtTemplate.Columns.Add("Country Of Origin", typeof(System.String));
                                dtTemplate.Columns.Add("Order Quantity", typeof(System.String));
                                dtTemplate.Columns.Add("Currency", typeof(System.String));
                                dtTemplate.Columns.Add("Remarks", typeof(System.String));
                                dtTemplate.Columns.Add("Lead Time", typeof(System.String));

                                //Header Columns to be sent in mail
                                dtTemplate.Columns.Add("Description", typeof(System.String));
                                dtTemplate.Columns.Add("Scope of Work", typeof(System.String));
                                dtTemplate.Columns.Add("Drawing", typeof(System.String));
                                dtTemplate.Columns.Add("REV", typeof(System.String));
                                dtTemplate.Columns.Add("LG", typeof(System.String));
                                dtTemplate.Columns.Add("Material Assigned", typeof(System.String));
                                dtTemplate.Columns.Add("Deadline", typeof(System.String));

                                foreach (DataRow dr in dtTemplate.Rows)
                                {
                                    foreach (DataRow htrw in dtHeader.Rows)
                                    {
                                        if ((dr["SAP Material Number"].ToString() == htrw["SAP Material Number"].ToString()) && (dr["RFQ refer"].ToString() == htrw["RFQ refer"].ToString()))
                                        {
                                            dr["Description"] = htrw["Description"].ToString();
                                            dr["Scope of Work"] = htrw["Scope of Work"].ToString();
                                            dr["Drawing"] = htrw["Drawing"].ToString();
                                            dr["REV"] = htrw["REV"].ToString();
                                            dr["LG"] = htrw["LG"].ToString();
                                            dr["Material Assigned"] = htrw["Material Assigned"].ToString();
                                            dr["Deadline"] = htrw["Deadline"].ToString();
                                        }
                                    }
                                }
                                dtTemplate.Columns.Remove("CreatedDate");
                                dtTemplate.Columns.Remove("ModifiedDate");
                                dtTemplate.AcceptChanges();
                                sendFOSOMails(dtTemplate, sentRFQPath);

                                //TK Header and Liner tables persisted with the values from dtHeader and dtLinerFilter datatables
                                dtTK_Header = objDAL_FO_RFQ.FO_RFQ_Save(dtHeader, dtLinerFilter);
                            }
                            /*
                            else
                            {
                                MessageBox.Show("No Record Selected");
                            }
                            */
                        }
                        else
                        {
                            MessageBox.Show("There is no RFQ available for selection");
                        }
                    }

                }  
            }
            catch (System.Exception ex)
            {
                string Errormsg = ex.GetType().Name.ToString();
                handler.Register(ex);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }
       }

        #endregion

        private void sendFOSOMails(DataTable dtmail, string SentRFQPath)
        {
            DataTable dtMailSent = new DataTable();
            DataTable FilteredRFQLiner = dtmail.Copy();
            DAL_FO_RFQ objDAL_FO_RFQ = new DAL_FO_RFQ();
            string strBody = String.Empty;
            String mailSavePath = String.Empty;
            //SentRFQPath = System.Configuration.ConfigurationManager.AppSettings["SentRFQPath"];
            //Adding mailsent status to dtmailsent
            dtMailSent.Columns.Add("SAP Material Number");
            dtMailSent.Columns.Add("VendorID");
            dtMailSent.Columns.Add("RFQ refer");
            dtMailSent.Columns.Add("Status");

            if (FilteredRFQLiner.Rows.Count > 0) 
            {
                DataSet dsRFQStatus = new DataSet();
                string strUserName = string.Empty, strSmtpAddress = string.Empty;
                Microsoft.Office.Interop.Outlook.Application application = new Microsoft.Office.Interop.Outlook.Application();
                Microsoft.Office.Interop.Outlook.Accounts accounts = application.Session.Accounts;
                foreach (Microsoft.Office.Interop.Outlook.Account account in accounts)
                {
                    strUserName = account.UserName;
                    strSmtpAddress = account.SmtpAddress;
                }

                foreach (DataRow dr in FilteredRFQLiner.Rows)
                {
                    DataSet ds_Vendor_Email = objDAL_FO_RFQ.FO_RFQ_Fetch_Vendor_Email(dr["VendorID"].ToString());

                    if (LogRFQ == "1")
                        LogOptions.Log(logpath, LogCategory.OutlookRibbon, "ds_Vendor_Email count" + ds_Vendor_Email.Tables[0].Rows.Count);

                    if (ds_Vendor_Email.Tables[0].Rows.Count > 0)
                    {

                        if (string.IsNullOrEmpty(Convert.ToString(ds_Vendor_Email.Tables[0].Rows[0]["Email"])) != true)
                        {
                            String[] strlist = { "" };
                            string str = "";
                            if ((Convert.ToString(ds_Vendor_Email.Tables[0].Rows[0]["Email"]).Contains(";")))
                            {
                                String[] separator = { ";" };
                                str = Convert.ToString(ds_Vendor_Email.Tables[0].Rows[0]["Email"]);
                                strlist = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                            }
                            else
                            {
                                strlist[0] = ds_Vendor_Email.Tables[0].Rows[0]["Email"].ToString();
                            }
                            
                            //Check if the RFQ refer contains FO or SO and save the sent mails in the respective folder
                            if (dr["RFQ refer"].ToString().Contains("FO"))
                            {
                                mailSavePath = SentRFQPath + @"\FO";
                            }
                            else if (dr["RFQ refer"].ToString().Contains("SO"))
                            {
                                mailSavePath = SentRFQPath + @"\SO";
                            }

                            if (LogRFQ == "1")
                            {

                                LogOptions.Log(logpath, LogCategory.OutlookRibbon, "RFQ REF" + dr["RFQ refer"].ToString());
                                LogOptions.Log(logpath, LogCategory.OutlookRibbon, "SentRFQPath" + SentRFQPath);
                            }
                            if (!Directory.Exists(mailSavePath))
                            {
                               Directory.CreateDirectory(mailSavePath);
                                    
                               if (LogRFQ == "1")
                               {
                                     LogOptions.Log(logpath, LogCategory.OutlookRibbon, "SentRFQPath folder doesn't exist.. hence created ");
                                          
                               }
                            }

                            string strSubject = dr["RFQ refer"].ToString() + "-" + dr["VendorID"].ToString();

                            DataTable dtemailtemplate = FilteredRFQLiner.Copy();

                            dtemailtemplate = dtemailtemplate.AsEnumerable()
                            .Where(r => r.Field<string>("VendorID") == dr["VendorID"].ToString() && r.Field<string>("RFQ refer") == dr["RFQ refer"].ToString())
                            .Distinct().CopyToDataTable();


                            if (dtMailSent.Rows.Count == 0)
                            {
                                SendRFQMails(strSubject, strlist, dtemailtemplate, mailSavePath);
                            }
                            else
                            {
                                bool isMailSent = dtMailSent.AsEnumerable().Where(r => r.Field<string>("VendorID") == dr["VendorID"].ToString() && r.Field<string>("RFQ refer") == dr["RFQ refer"].ToString()).Count() > 0;

                                if (!isMailSent)
                                {
                                    SendRFQMails(strSubject, strlist, dtemailtemplate, mailSavePath);

                                }
                            }
                            DataRow dtmrow = dtMailSent.NewRow();

                            dtmrow["VendorID"] = dr["VendorID"];
                            dtmrow["RFQ refer"] = dr["RFQ refer"];
                            dtmrow["status"] = "MailSent";
                            dtMailSent.Rows.Add(dtmrow);
                            dtMailSent.AcceptChanges();


                            if (LogRFQ == "1")
                            {
                                LogOptions.Log(logpath, LogCategory.OutlookRibbon, "dtMailSent  SAVED SUCCESSFULLY");
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Vendor Not Found for Material Number : " + dr["SAP Material Number"].ToString());
                        if (LogRFQ == "1")
                            LogOptions.Log(logpath, LogCategory.OutlookRibbon, "Vendor Not Found for Material Number" + dr["SAP Material Number"].ToString());
                    }

                }
            }
        }

        private void SendRFQMails(string strSubject, string[] strlist, DataTable dtemailtemplate, string mailSavePath)
        {
            try
            {
                
                string strBody = objMailGenerate.GetBodyContent_FOSO(dtemailtemplate);

                if (LogRFQ == "1")
                {
                     Utils.showLog( "Mail Body generated");
                    LogOptions.Log(logpath, LogCategory.OutlookRibbon, "Mail Body generated");
                }

                Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
                Microsoft.Office.Interop.Outlook.MailItem mailItem = (Microsoft.Office.Interop.Outlook.MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
                Microsoft.Office.Interop.Outlook.NameSpace oNameSpace = oApp.GetNamespace("MAPI");
                Microsoft.Office.Interop.Outlook.MAPIFolder oFolder = oNameSpace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderSentMail);

                mailItem.Subject = strSubject;

                Microsoft.Office.Interop.Outlook.Recipients oRecips = mailItem.Recipients;
                List<string> sTORecipsList = new List<string>();
                List<string> sCCRecipsList = new List<string>();
                //Array.Clear(strlist, 0, strlist.Length);
                // sTORecipsList = strlist.ToList();
                String[] strlist1 = { "" };
                strlist1[0] = "limton@inovatrik.com";
                sTORecipsList = strlist1.ToList();
                Utils.showLog("recipien SendRFQMails mailItem.Recipients list"+ mailItem.Recipients);
                string strUserName = string.Empty;
                Microsoft.Office.Interop.Outlook.Application application = new Microsoft.Office.Interop.Outlook.Application();
                Microsoft.Office.Interop.Outlook.Accounts accounts = application.Session.Accounts;
                foreach (Microsoft.Office.Interop.Outlook.Account account in accounts)
                {
                    strUserName = account.UserName;

                }
                String[] strlist2 = { "" };
                strlist2[0] = (strUserName == "itdeptsen@outlook.com") ? "exoplan33@gmail.com" : strUserName;
                sTORecipsList = strlist2.ToList();

                if (LogRFQ == "1")
                {
                    LogOptions.Log(logpath, LogCategory.OutlookRibbon, "Mail Recepient Count" + sTORecipsList.Count.ToString());
                }
                
                
                if (sTORecipsList.Count > 0)
                {
                    int i = 1;
                    foreach (string t in sTORecipsList) 
                    {
                         if (i == 1)
                         {
                            Microsoft.Office.Interop.Outlook.Recipient oTORecip = oRecips.Add(t);
                            oTORecip.Type = (int)Microsoft.Office.Interop.Outlook.OlMailRecipientType.olTo;
                            oTORecip.Resolve();
                         }
                        else
                        {
                            Microsoft.Office.Interop.Outlook.Recipient oCCRecip = oRecips.Add(t);
                            oCCRecip.Type = (int)Microsoft.Office.Interop.Outlook.OlMailRecipientType.olCC;
                            oCCRecip.Resolve();
                        }
                        i++;
                    }
                    

                }
                mailItem.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatHTML;
                mailItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceNormal;
                mailItem.Display(false);
                var signature = mailItem.HTMLBody;
                mailItem.HTMLBody = strBody;
           

                if (Directory.Exists(mailSavePath))
                {
                
                    // mailItem.SaveAs(mailSavePath + @"\" + strSubject + ".msg", Microsoft.Office.Interop.Outlook.OlSaveAsType.olMSG);
                     mailItem.SaveAs(mailSavePath + @"\" + strSubject + " " + DateTime.Now.ToString().Replace("/", "-").Replace(":", "-") + ".msg",     Microsoft.Office.Interop.Outlook.OlSaveAsType.olMSG);

                    if (LogRFQ == "1")
                    {
                        LogOptions.Log(logpath, LogCategory.OutlookRibbon, "mailItem  saved in  SentRFQPath");
                    }
              
                }
                else
                {
                    if (LogRFQ == "1")
                    {
                        LogOptions.Log(logpath, LogCategory.OutlookRibbon, "SentRFQ directory does not exist");
                    }
                }
                mailItem.SaveSentMessageFolder = oFolder;
                mailItem.Send();
                mailItem = null;
                oApp = null;

                if (LogRFQ == "1")
                {
                   
                    LogOptions.Log(logpath, LogCategory.OutlookRibbon, "mail  sent successfully");
                }
           
            }
            catch (System.Exception ex)
            {
               MessageBox.Show(ex.ToString());
                throw;
            }
        }

        private void Assignvalues(string filePath, string excelSheet)
        {
            try
            {
                using (XLWorkbook workBook = new XLWorkbook(filePath))
                {
                    IXLWorksheet workSheet = workBook.Worksheet(excelSheet);
                    dtsource = new DataTable();

                    bool firstRow = true;
                    foreach (IXLRow row in workSheet.Rows())
                    {
                        if (firstRow)
                        {
                            foreach (IXLCell cell in row.Cells())
                            {
                                dtsource.Columns.Add(cell.Value.ToString());
                                if (LogRFQ == "1")
                                {
                                    logpath = LogOptions.CreateLogFile();
                                    LogOptions.Log(logpath, LogCategory.OutlookRibbon, "dtsourcecolmns" + cell.Value.ToString());
                                    
                                }
                            }
                            firstRow = false;
                        }
                        else
                        {
                            dtsource.Rows.Add();
                            int i = 0;
                            if (LogRFQ == "1")
                            {
                                logpath = LogOptions.CreateLogFile();
                                LogOptions.Log(logpath, LogCategory.OutlookRibbon, "dtsourcecolmnscount" + dtsource.Columns.Count.ToString());
                            }
                                //foreach (IXLCell cell in row.Cells())
                                foreach (IXLCell cell in row.Cells(1, dtsource.Columns.Count))
                                {
                                
                                    if(!cell.IsEmpty())
                                    {
                                         dtsource.Rows[dtsource.Rows.Count - 1][i] = cell.Value.ToString();
                                    }                                
                                
                                    i++;
                                
                                }
                        }
                    }
                }
                if (LogRFQ == "1")
                {
                    logpath = LogOptions.CreateLogFile();
                    LogOptions.Log(logpath, LogCategory.OutlookRibbon, "finaldtsourcerowscount" + dtsource.Rows.Count.ToString());
                    
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }


        private void rbtnReadRFQ_Click(object sender, RibbonControlEventArgs e)
        {
            ReadMail_FOSO();
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

        private void rbtnReview_Click_1(object sender, RibbonControlEventArgs e)
        {

        }

        private void rbtnFOSOTemplate_Click(object sender, RibbonControlEventArgs e)
        {
            FOSOTemplate_Edior te = new FOSOTemplate_Edior();
            te.Show();
        }

        private void ReadMail_FOSO()
        {
            //this method will select all mail items in inbox by default and checks for subject if it contains reply or forward RFQ mails and save to the respective vendor folders
            StreamWriter sw = null;
            DAL_FO_RFQ objDAL_FO_RFQ = new DAL_FO_RFQ();
            string path = @"C:\Users\Public\Documents\" + "\\LogReadFORFQFlow";
            string priceScale1ErrMsg = "Invalid Price Scale Value (1-3)";
            string priceScale2ErrMsg = "Invalid Price Scale Value (4-9)";
            string priceScale3ErrMsg = "Invalid Price Scale Value (>=10)";
            string noQuoteErrMsg = "No Vendor Quote available";
            string diffQuoteErrMsg = "Quotation number not same across all the part numbers";
            string RFQRefNum = String.Empty;
            string initialQuoteNo = String.Empty;
            string noQuote = "NoQuote";
            
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = path + @"\LogReadFORFQFlow.txt";
            
            if (!File.Exists(filepath))
            {
                sw = File.CreateText(filepath);
               
            }
            else
            {
                sw = File.AppendText(filepath);
            }

           // string[] attachmentarr;
           // string attachmentreffile;
            Outlook.Application application = new Outlook.Application();

            Outlook.MAPIFolder inBox = (Outlook.MAPIFolder)application.
                ActiveExplorer().Session.GetDefaultFolder
                (Outlook.OlDefaultFolders.olFolderInbox);

            sw.WriteLine("inbox " + DateTime.Now.ToString());
            Outlook.Items items = (Outlook.Items)inBox.Items;
            
            Outlook.MailItem moveMail = null;
            Outlook.MAPIFolder readRFQFolder;
           
            items.Restrict("[UnRead] = true");
            
            List<Outlook.MailItem> lstMailItem = new List<Outlook.MailItem>();
            

            if (items != null)
            {
                
                Outlook.MAPIFolder rootFolder = (Outlook.MAPIFolder)inBox.Parent;
                readRFQFolder = rootFolder.Folders["Read_RFQ"];
                MessageBox.Show("Moving RFQ mails to VendorPath is inProgress...Click OK");
              

                foreach (object eMail in items)
                {
                    try
                    {
                        DataTable receivedMaildt = new DataTable();
                        moveMail = eMail as Outlook.MailItem;
                        //       MessageBox.Show("FirstmoveMail" + moveMail);
                        if (moveMail != null)
                        {
                            string titleSubject = (string)moveMail.Subject;

                            Subject = titleSubject.ToLower().Trim();


                            //string fwdMailSubject = " FWD: RFQ";
                            //string fwdMailSubject1 = " FW: RFQ";
                            //string repMailSubject = " Re: RFQ";
                             
                            string fwdMailSubject = "[External] FWD: RFQ";
                            string fwdMailSubject1 = "[External] FW: RFQ";
                            string repMailSubject = "[External] Re: RFQ";

                            if (sw is null)
                            {
                                
                                sw.WriteLine("sw null ");
                            }
                            sw.WriteLine(scount + " Subject " + Subject);
                            sw.WriteLine("Fwd Mail Subject " + fwdMailSubject);
                            sw.WriteLine("Reply Mail Subject " + repMailSubject);
                            sw.WriteLine();
                            decimal priceScale1;
                            decimal priceScale2;
                            decimal priceScale3;
                            DataTable dt = new DataTable();
                            if (!string.IsNullOrEmpty(Subject) && !string.IsNullOrWhiteSpace(Subject))
                            {
                                if (Subject.Contains(fwdMailSubject.ToLower()) || Subject.Contains(repMailSubject.ToLower()) || Subject.Contains(fwdMailSubject1.ToLower()))
                                {
                                    if (rcount == 0)
                                    {
                                        rcount = 1;
                                    }
                                    sw.WriteLine(rcount + " subject contains forward or re mails");
                                  
                                    ((Microsoft.Office.Interop.Outlook.MailItem)moveMail).SaveAs(@"C:\Users\Public\Documents\Sample.html", Microsoft.Office.Interop.Outlook.OlSaveAsType.olHTML);
                                    string html = System.IO.File.ReadAllText(@"C:\Users\Public\Documents\Sample.html");
                                    sw.WriteLine("Samplehtml created");
                                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                                    doc.LoadHtml(html);
                                    sw.WriteLine("LoadHtml created");
                                    bool firstRow = true;
                                   
                                    var isTABLEExist = doc.DocumentNode.Descendants("table").Any();
                                    sw.WriteLine("isTABLEExist" + isTABLEExist);
                                    if (isTABLEExist)
                                    {
                                        sw.WriteLine("Going Inside isTABLEExist" + isTABLEExist);

                                        if (doc.DocumentNode.SelectSingleNode("//table[@id='FOSO_Table']") != null)
                                        {

                                            sw.WriteLine("Table has value");
                                        }
                                        else
                                        {
                                            sw.WriteLine("Table is null");
                                        }

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
                                                        sw.WriteLine("Data - " + td.InnerText);
                                                        receivedMaildt.Columns.Add(td.InnerText.Trim().Replace("\r\n", "").Replace("  ", "").Replace("   ", "").Replace("&gt;", ">").Trim());

                                                    }
                                                }
                                            }

                                            //Loop in through the table to fetch the data updated by the vendors
                                            foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table[@id='FOSO_Table']"))
                                            {

                                                foreach (HtmlNode row in table.SelectNodes("tr"))
                                                {
                                                    int i = 0;
                                                    receivedMaildt.Rows.Add();
                                                    foreach (HtmlNode td in row.SelectNodes("td[@id='tdTbodys']"))
                                                    {
                                                        sw.WriteLine("Data - " + td.InnerText);
                                                        if (receivedMaildt.Columns.Count > 0)
                                                        {
                                                            receivedMaildt.Rows[receivedMaildt.Rows.Count - 1][i] = td.InnerText.Trim().Replace("\r\n", "").Trim();
                                                            i++;
                                                        }

                                                    }
                                                }
                                            }
                                            receivedMaildt.AcceptChanges();
                                        } 

                                    }
                                   
                                    if (firstRow)
                                    {
                                        sw.WriteLine("dt not created");
                                    }


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

                                        sw.WriteLine("Received Mail Data created" + receivedMaildt.Rows.Count.ToString());
                                        
                                        sw.WriteLine("Received Mail copied data" + dtRFQReceived.Rows.Count.ToString());
                                        String vendorMailId = moveMail.SenderEmailAddress.ToString();
                                        String subject = moveMail.Subject.ToString();
                                        string sep = ": ";
                                        int separatorIndex = subject.IndexOf(sep);
                                        if (separatorIndex >= 0)
                                        {
                                            RFQRefNum = subject.Substring(separatorIndex + sep.Length);
                                            RFQRefNum = RFQRefNum.Substring(0, RFQRefNum.LastIndexOf("-"));
                                        }

                                        string vendorCode = subject.Substring(subject.LastIndexOf('-') + 1);

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
                                                    sw.WriteLine("ReceivedQuotationPath folder not available");
                                                    Directory.CreateDirectory(ReceivedQuotationPath);
                                                    sw.WriteLine("ReceivedQuotationPath folder created");
                                                }

                                            }
                                            else
                                            {
                                                sw.WriteLine("Received Quotations Folder path is empty in table tblVendor");
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

                                            if (i==1)
                                            {
                                                initialQuoteNo = dr["Quotation number"].ToString();
                                            }
                                            else
                                            {
                                                if(!vendorQuote.Equals(initialQuoteNo))
                                                {
                                                    errorList.Add(diffQuoteErrMsg);
                                                }
                                            }
                                            
                                            if (string.IsNullOrEmpty(initialQuoteNo) != true)
                                            {
                                                if (!mailSaved)
                                                {
                                                    receivedMailMessage = ReceivedQuotationPath + @"\" + initialQuoteNo.Trim() + "_Dated " + DateTime.Now.ToString("MM/dd/yyyy").Replace("/", "-") + "_Time " + DateTime.Now.ToString("HH:mm:ss tt").Replace(":", "-") + ".msg";
                                                    sw.WriteLine("receivedMailMessage " + receivedMailMessage);
                                                    moveMail.SaveAs(receivedMailMessage.Trim(), Microsoft.Office.Interop.Outlook.OlSaveAsType.olMSG);
                                                    mailSaved = true;
                                                    sw.WriteLine("Mail saved inReceivedQuotationPath" + receivedMailMessage);

                                                }
                                            }
                                            else
                                            {
                                                if (!mailSaved)
                                                {
                                                    receivedMailMessage = ReceivedQuotationPath + @"\" + noQuote + "_Dated " + DateTime.Now.ToString("MM/dd/yyyy").Replace("/", "-") + "_Time " + DateTime.Now.ToString("HH:mm:ss tt").Replace(":", "-") + ".msg";
                                                    sw.WriteLine("receivedMailMessage " + receivedMailMessage);
                                                    moveMail.SaveAs(receivedMailMessage.Trim(), Microsoft.Office.Interop.Outlook.OlSaveAsType.olMSG);
                                                    mailSaved = true;
                                                    sw.WriteLine("Mail saved inReceivedQuotationPath" + receivedMailMessage);

                                                }

                                            }
                                            if(string.IsNullOrEmpty(dr["Quotation number"].ToString()) == true)
                                            {
                                                errorList.Add(noQuoteErrMsg);
                                            }

                                            String[] errorArray = errorList.ToArray();

                                            dtLinerDetails.Rows[dtLinerDetails.Rows.Count - 1]["ErrorStatus"] = String.Join(";", errorArray);
                                            dtLinerDetails.AcceptChanges();

                                            sw.WriteLine("usp_UPD_TK_RFQLiner SP executed");
                                            i++;

                                        }
                                        objDAL_FO_RFQ.FO_RFQ_UpdateLinerDetails(dtLinerDetails);
                                    }
                                    else
                                    {
                                        sw.WriteLine("datable is empty-no records from sample html");
                                    }
                                    lstMailItem.Add(moveMail);
                                    rcount++;
                                }//subject contains re or fwd msg

                            }//subject is not empty
                            scount++;

                        }//movemail not null
                    }
                    catch (System.Exception ex)
                    {
                        
                        sw.WriteLine("Error: " + ex.Message);
                    }
                }//for loop of all inbox items
                sw.WriteLine("lstMailItem count" + lstMailItem.Count().ToString());

                if (lstMailItem.Count > 0)
                {
                    foreach (var MailItem in lstMailItem)
                    {
                        sw.WriteLine("BEFORE MOVING...");
                        MailItem.Move(readRFQFolder);
                        sw.WriteLine("MAILS MOVED SUCCESSFULLY TO READ RFQ FOLDER");
                    }
                    MessageBox.Show("Mails moved successfully");
                }
                else
                {
                    MessageBox.Show("No Replied RFQ mails in your InBox");
                    sw.WriteLine("No Replied RFQ mails in your InBox");
                }


                //MessageBox.Show("Total Forward or Reply mails of RFQ : " + rcount);
                sw.WriteLine("Total Forward or Reply mails of RFQ : " + rcount);
            }
            else
            {
                MessageBox.Show("inboxitemsNULL");
                sw.WriteLine("inboxitemsNULL");
            }

            if (sw != null)
            {
                sw.WriteLine("sw closed ");
                sw.Close();
                //  MessageBox.Show("sw closed");
            }
 
        }

        private void rbtnTKPPReadRFQ_Click(object sender, RibbonControlEventArgs e)
        {
            ReadMail_PP();
        }
        private void ReadMail_PP()
        {
            //this method will default select all mail items in inbox and checks for subject contains reply or forward mails of RFQ and send to respective vendor folders                          

            StreamWriter sw = null;
            string path = @"C:\Users\Public\Documents\" + "\\LogReadFORFQFlow";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = path + @"\LogReadFORFQFlow.txt";
             
             
            try
            {
                //MessageBox.Show(filepath);
                if (!File.Exists(filepath))
                {
                    sw = File.CreateText(filepath);
                }
                else
                {
                    sw = File.AppendText(filepath);
                }
            }
            catch (System.Exception ee)
            {

            }


            try
            {

                Outlook.Application application = new Outlook.Application();

                Outlook.MAPIFolder inBox = (Outlook.MAPIFolder)application.
                    ActiveExplorer().Session.GetDefaultFolder
                    (Outlook.OlDefaultFolders.olFolderInbox);
                //            MessageBox.Show("inbox");
                sw.WriteLine(getCurrentTime() + " inbox " + DateTime.Now.ToString());
                Outlook.Items items = (Outlook.Items)inBox.Items;
                //MessageBox.Show("inboxitems");
                Outlook.MailItem moveMail = null;
                Outlook.MAPIFolder readRFQFolder;
                //Outlook.MAPIFolder Readmail = (Outlook.MAPIFolder)application.
                //   ActiveExplorer().Session.GetDefaultFolder
                //   (Outlook.OlDefaultFolders.olFolderInbox).Folders["Read_RFQ"];
                // Outlook.MAPIFolder Readmail = null;
                //MessageBox.Show("moveMailnull");
                items.Restrict("[UnRead] = true");
                //MessageBox.Show("itemsrestrict");
                //  Outlook.MAPIFolder destFolder = inBox.Folders["Read_RFQ"];
                List<Outlook.MailItem> lstMailItem = new List<Outlook.MailItem>();
                //application.ActiveExplorer().CurrentFolder = inBox.
                //Folders["Read_RFQ"];
                //application.ActiveExplorer().CurrentFolder.Display();
                //MessageBox.Show("CurrentFolder");
                if (items != null)
                {
                    // MessageBox.Show("applicationActiveExplorer");
                    //application.ActiveExplorer().CurrentFolder = inBox.Folders["Read_RFQ"];
                    //MessageBox.Show("applicationActiveExplorer1");
                    //application.ActiveExplorer().CurrentFolder.Display();
                    Outlook.MAPIFolder rootFolder = (Outlook.MAPIFolder)inBox.Parent;
                    readRFQFolder = rootFolder.Folders["Read_RFQ"];
                    isReadRFQFolder = true;
                    MessageBox.Show("Moving RFQ mails to VendorPath is inProgress...Click OK");
                    //  MessageBox.Show("inboxitemscount" + items.Count.ToString());

                    foreach (object eMail in items)
                    {
                        try
                        {
                            moveMail = eMail as Outlook.MailItem;
                            if (moveMail != null)
                            {
                                string titleSubject = (string)moveMail.Subject;
                                Subject = titleSubject.ToLower().Trim();
                                string fwdMailSubject = "RFQ";

                                //string fwdMailSubject1 = "FW: RFQ";
                               // string repMailSubject = "Re: RFQ"; //un comment by shunmugam 21-12-2023 bcoz mail subject contains Re: RFQ 
                               // string extREMailSubject = "[External] RE: RFQ";
                                //string extFwMailSubject = "[External] FW: RFQ";
                               // string extFwdMailSubject = "[External] FWD: RFQ";
                                if (sw is null)
                                {
                                    //MessageBox.Show("sw null");
                                    sw.WriteLine("sw null ");
                                }
                                // sw.WriteLine(scount + " Subject " + Subject);
                                //sw.WriteLine("Fwd Mail Subject " + fwdMailSubject);
                                //sw.WriteLine("Reply Mail Subject " + repMailSubject);
                                // sw.WriteLine();
                                decimal price1 = 0;
                                decimal price2 = 0;
                                decimal price3 = 0;
                                decimal price4 = 0;
                                decimal price5 = 0;
                                decimal price10 = 0;
                                decimal price25 = 0;
                                decimal price50 = 0;
                                decimal price100 = 0;

                                hdrrcount = 0;
                                DataTable dt = new DataTable();
                                if (!string.IsNullOrEmpty(Subject) && !string.IsNullOrWhiteSpace(Subject))
                                {
                                    if (Subject.Contains(fwdMailSubject.ToLower())  )
                                    {
                                        String html_msg = moveMail.HTMLBody;

                                        sw.WriteLine(scount + " Subject " + Subject);
                                        sw.WriteLine(scount + " msg html " + html_msg);


                                        if (rcount == 0)
                                        {
                                            rcount = 1;
                                        }
                                        sw.WriteLine(rcount + " subject contains forward or re mails");
                                        string vendorCode = titleSubject.Substring(titleSubject.LastIndexOf('-') + 1);


                                        /*((Microsoft.Office.Interop.Outlook.MailItem)moveMail).SaveAs(@"C:\Users\Public\Documents\Sample.html", Microsoft.Office.Interop.Outlook.OlSaveAsType.olHTML);
                                        string html = System.IO.File.ReadAllText(@"C:\Users\Public\Documents\Sample.html");
                                        sw.WriteLine("Samplehtml created");*/

                                        //Read starts here
                                        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();


                                        doc.LoadHtml(html_msg);
                                        sw.WriteLine("LoadHtml created");
                                        bool firstRow = true;

                                        var isTABLEExist = doc.DocumentNode.Descendants("table").Any();
                                        sw.WriteLine(getCurrentTime() + "isTABLEExist" + isTABLEExist);
                                        if (isTABLEExist)
                                        {
                                            sw.WriteLine(getCurrentTime() + "Going Inside isTABLEExist //table[@class='MsoNormalTable'] " + isTABLEExist);

                                            ////table[@id='TK_Table']
                                            if (doc.DocumentNode.SelectSingleNode("//table[@class='MsoNormalTable']") != null)
                                            {

                                                sw.WriteLine(getCurrentTime() + "Table has value");
                                            }
                                            else
                                            {
                                                if (doc.DocumentNode.SelectSingleNode("//table[contains(@id, 'TK_Table')]") != null)
                                                {
                                                    sw.WriteLine(getCurrentTime() + "Table has value");
                                                }

                                                sw.WriteLine(getCurrentTime() + "Table is null, cant find TK_Table");
                                            }

                                            var nodes = doc.DocumentNode.SelectNodes("//table[contains(@id, 'TK_Table')]");
                                            if (nodes != null)
                                            {
                                                //Loop in through the table to fetch the header column names
                                                foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table[contains(@id, 'TK_Table')]//thead"))
                                                {
                                                    foreach (HtmlNode row in table.SelectNodes("tr"))
                                                    {
                                                        try
                                                        {
                                                            //"th//span[@class='thead']
                                                            foreach (HtmlNode td in row.SelectNodes("td//p[@class='MsoNormal']"))
                                                            {
                                                                sw.WriteLine("Data - " + td.InnerText);
                                                                if (td.InnerText.Trim() == "Mandatory to fill up" || td.InnerText.Trim() == "PRICE BREAKS")
                                                                {

                                                                }
                                                                else
                                                                {
                                                                    dt.Columns.Add(td.InnerText.Trim().Replace("\r\n", "").Replace("  ", "").Replace("   ", "").Replace("&gt;", ">").Replace("&nbsp;", " ").Trim());
                                                                }


                                                            }
                                                        }
                                                        catch (System.Exception ee)
                                                        {
                                                            sw.WriteLine(getCurrentTime() + "  - " + ee.Message);
                                                            continue;
                                                        }
                                                    }
                                                }

                                                //Loop in through the table to fetch the data updated by the vendors
                                                if (doc.DocumentNode.SelectNodes("//table[contains(@id, 'TK_Table')]//tbody") != null)
                                                {
                                                    foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table[contains(@id, 'TK_Table')]//tbody"))
                                                    // foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table[@id='TK_Table']"))
                                                    {

                                                        foreach (HtmlNode row in table.SelectNodes("tr"))
                                                        {
                                                            try
                                                            {
                                                                int i = 0;
                                                                dt.Rows.Add();
                                                                //if (row.SelectNodes("td[@id='tdTbodys']") !=null)
                                                                //{
                                                                foreach (HtmlNode td in row.SelectNodes("td"))
                                                                {

                                                                    sw.WriteLine(getCurrentTime() + "Data - " + td.InnerText);
                                                                    if (dt.Columns.Count > 0)
                                                                    {
                                                                        dt.Rows[dt.Rows.Count - 1][i] = td.InnerText.Trim().Replace("\r\n", "").Replace("&nbsp;", "").Trim();
                                                                        i++;
                                                                    }

                                                                }
                                                                //}
                                                                //else
                                                                //{
                                                                //    if (row.SelectNodes("td//p[@class='MsoNormal']") != null)
                                                                //    {
                                                                //        foreach (HtmlNode td in row.SelectNodes("td//p[@class='MsoNormal']"))
                                                                //        {
                                                                //            sw.WriteLine(getCurrentTime() + "Data - " + td.InnerText);
                                                                //            if (dt.Columns.Count > 0)
                                                                //            {
                                                                //                dt.Rows[dt.Rows.Count - 1][i] = td.InnerText.Trim().Replace("\r\n", "").Trim();
                                                                //                i++;
                                                                //            }
                                                                //        }
                                                                //    }
                                                                //}

                                                            }
                                                            catch (System.Exception ee)
                                                            {
                                                                sw.WriteLine(getCurrentTime() + "  - " + ee.Message);
                                                                continue;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (doc.DocumentNode.SelectNodes("//table[@id='TK_Table']") != null)
                                                    {
                                                        foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table[@id='TK_Table']"))
                                                        // foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table[@id='TK_Table']"))
                                                        {

                                                            foreach (HtmlNode row in table.SelectNodes("tr"))
                                                            {
                                                                try
                                                                {
                                                                    int i = 0;
                                                                    dt.Rows.Add();
                                                                    //if (row.SelectNodes("td[@id='tdTbodys']") !=null)
                                                                    //{
                                                                    foreach (HtmlNode td in row.SelectNodes("td"))
                                                                    {

                                                                        sw.WriteLine(getCurrentTime() + "Data - " + td.InnerText);
                                                                        if (dt.Columns.Count > 0)
                                                                        {
                                                                            dt.Rows[dt.Rows.Count - 1][i] = td.InnerText.Trim().Replace("\r\n", "").Replace("&nbsp;", "").Trim();
                                                                            i++;
                                                                        }

                                                                    }
                                                                    //}
                                                                    //else
                                                                    //{
                                                                    //    if (row.SelectNodes("td//p[@class='MsoNormal']") != null)
                                                                    //    {
                                                                    //        foreach (HtmlNode td in row.SelectNodes("td//p[@class='MsoNormal']"))
                                                                    //        {
                                                                    //            sw.WriteLine(getCurrentTime() + "Data - " + td.InnerText);
                                                                    //            if (dt.Columns.Count > 0)
                                                                    //            {
                                                                    //                dt.Rows[dt.Rows.Count - 1][i] = td.InnerText.Trim().Replace("\r\n", "").Trim();
                                                                    //                i++;
                                                                    //            }
                                                                    //        }
                                                                    //    }
                                                                    //}

                                                                }
                                                                catch (System.Exception ee)
                                                                {
                                                                    sw.WriteLine(getCurrentTime() + "  - " + ee.Message);
                                                                    continue;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }

                                                dt.AcceptChanges();
                                            }

                                        }
                                        if (firstRow)
                                        {
                                            sw.WriteLine(getCurrentTime() + "dt not created");
                                        }

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

                                            //   sw.WriteLine("dtRFQReceived created" + dtRFQReceived.Rows.Count.ToString());
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
                                                    sw.WriteLine(getCurrentTime() + "dtRFQReceived.Rows.Count greater than 0");
                                                    sw.WriteLine(getCurrentTime() + "Ordered Part Number" + dtRFQReceived.Rows[r]["Part Number"].ToString());

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
                                                        sw.WriteLine(getCurrentTime() + "price1" + price1);
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
                                                        sw.WriteLine(getCurrentTime() + "price2" + price2);
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
                                                        sw.WriteLine("price3" + price3);
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
                                                        sw.WriteLine(getCurrentTime() + "price4" + price4);
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
                                                        sw.WriteLine("price5" + price5);
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
                                                        sw.WriteLine(getCurrentTime() + "price10" + price10);
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
                                                        sw.WriteLine("price25" + price25);
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
                                                        sw.WriteLine(getCurrentTime() + "price50" + price50);
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
                                                        sw.WriteLine("price100" + price100);
                                                    }
                                                    /*
                                                    var key = "o14ca5898c4e4133bbce2sg2315a2024";
                                                    var readerstring = string.Empty;
                                                    using (StreamReader reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "SystemConfig.xml.txt"))
                                                    {
                                                        string body = reader.ReadToEnd();
                                                        readerstring = body;
                                                    }
                                                    string decrypted_con = DecryptString(key, readerstring);
                                                    string connectionString = decrypted_con;
                                                    */
                                                     string connectionString = ConfigurationManager.AppSettings["DefaultConnection"].ToString();
                                                    
 
                                                    SqlConnection con1;
                                                    SqlDataAdapter adapter;
                                                    DataSet ds1 = new DataSet();
                                                    DataSet ds1SQL = new DataSet();
                                                    string ID = string.Empty;
                                                    try
                                                    {
                                                        //create connection object
                                                        con1 = new SqlConnection(connectionString);
                                                        //create query string(SELECT QUERY)
                                                        String query = "select  ID  from tbl_PP_RFQ_Liner where RFQ_Refer='" + RFQRefNum + "' AND  Vendor_ID='" + vendorCode.ToString() + "' AND  OrderedPart='" + dtRFQReceived.Rows[r]["Part Number"].ToString() + "' ";
                                                        con1.Open();
                                                        //Adapter bind to query and connection object
                                                        adapter = new SqlDataAdapter(query, con1);
                                                        //fill the dataset
                                                        adapter.Fill(ds1);
                                                        ds1SQL = ds1;
                                                        ID = ds1SQL.Tables[0].Rows[0]["ID"].ToString();

                                                    }
                                                    catch (System.Exception ex)
                                                    {
                                                        sw.WriteLine("----------------- Error Start -------------------");
                                                        sw.WriteLine(String.Concat(ex.StackTrace, ex.Message));

                                                        if (ex.InnerException != null)
                                                        {
                                                            sw.WriteLine("Inner Exception");
                                                            sw.WriteLine(String.Concat(ex.InnerException.StackTrace, ex.InnerException.Message));
                                                        }
                                                        sw.WriteLine("----------------- Error End -------------------");
                                                        throw ex;
                                                    }

                                                    con = new SqlConnection(connectionString);
                                                    // MessageBox.Show("19");
                                                    sw.WriteLine("con created");
                                                    DataSet ds = new DataSet();
                                                    sw.WriteLine("bef open con state" + con.State);
                                                    sw.WriteLine("con connectionstring" + con.ConnectionString);
                                                    con.Open();
                                                    //MessageBox.Show("20");
                                                    sw.WriteLine("after open con state" + con.State);
                                                    sw.WriteLine("connection open");
                                                    SqlCommand cmd = new SqlCommand("SP_UPD_PP_RFQ_LINER", con);
                                                    cmd.CommandType = CommandType.StoredProcedure;
                                                    if (!string.IsNullOrEmpty(dtRFQReceived.Rows[r]["Quotation #"].ToString()))
                                                    {
                                                        vendorQuote = dtRFQReceived.Rows[r]["Quotation #"].ToString();
                                                    }
                                                    cmd.Parameters.AddWithValue("@ID", ID);
                                                    cmd.Parameters.AddWithValue("@OrderedPart", dtRFQReceived.Rows[r]["Part Number"].ToString());
                                                    cmd.Parameters.AddWithValue("@Vendor_ID", vendorCode.ToString());
                                                    cmd.Parameters.AddWithValue("@QUOTE", dtRFQReceived.Rows[r]["Quotation #"].ToString());
                                                    cmd.Parameters.AddWithValue("@PB1", (price1.ToString() == "0" ) ? null : price1.ToString()  );
                                                    cmd.Parameters.AddWithValue("@PB2", (price2.ToString() == "0") ? null : price2.ToString() );
                                                    cmd.Parameters.AddWithValue("@PB3", (price3.ToString() == "0") ? null : price3.ToString() );
                                                    cmd.Parameters.AddWithValue("@PB4", (price4.ToString() == "0") ? null : price4.ToString() );
                                                    cmd.Parameters.AddWithValue("@PB5", (price5.ToString() == "0") ? null : price5.ToString() );
                                                    cmd.Parameters.AddWithValue("@PB10", (price10.ToString() == "0") ? null : price10.ToString());
                                                    cmd.Parameters.AddWithValue("@PB25", (price25.ToString() == "0") ? null : price25.ToString() );
                                                    cmd.Parameters.AddWithValue("@PB50", (price50.ToString() == "0") ? null : price50.ToString() );
                                                    cmd.Parameters.AddWithValue("@PB100", (price100.ToString() == "0") ? null : price100.ToString() );
                                                   // cmd.Parameters.AddWithValue("@pricebreakstatus", dtRFQReceived.Rows[r]["pricebreakstatus"].ToString());
                                                    cmd.Parameters.AddWithValue("@REM", dtRFQReceived.Rows[r]["Remarks"].ToString().Replace("&nbsp;", "").Trim().ToString() );
                                                    cmd.Parameters.AddWithValue("@LTIME", dtRFQReceived.Rows[r]["Lead Time in days"].ToString());
                                                    cmd.Parameters.AddWithValue("@UOM", dtRFQReceived.Rows[r]["UOM"].ToString());
                                                    cmd.Parameters.AddWithValue("@CQTY", dtRFQReceived.Rows[r]["Conversion Qty"].ToString());
                                                    cmd.Parameters.AddWithValue("@CO", dtRFQReceived.Rows[r]["COO"].ToString());
                                                    cmd.Parameters.AddWithValue("@CURRENCY", dtRFQReceived.Rows[r]["Currency"].ToString());
                                                    cmd.Parameters.AddWithValue("@MDATE", DateTime.Now);
                                                    cmd.Parameters.AddWithValue("@RFQ_Refer", RFQRefNum);

                                                    cmd.ExecuteNonQuery();
                                                    sw.WriteLine("SP_UPD_PP_RFQ_LINER executed");
                                                }//dtRFQReceived for loop
                                                 //bool isMailSent = dtMailSent.AsEnumerable().Where(r => r.Field<string>("Vendor_ID") == dr["Vendor_ID"].ToString() && r.Field<string>("RFQ_refer") == dr["RFQ_refer"].ToString()).Count() > 0;
                                                 //   vendorQuote = dtRFQReceived.AsEnumerable().Where(r => r.Field<string>("Quotation#") != "").ToString();
                                                 //if (!string.IsNullOrEmpty(dtRFQReceived.Rows[r]["Quotation#"].ToString()))
                                                 //{
                                                 //    vendorQuote = dtRFQReceived.Rows[r]["Quotation#"].ToString();
                                                 //}
                                                 // sw.WriteLine("vendorQuote" + vendorQuote);

                                                sw.WriteLine(getCurrentTime() + "vendorcode " + vendorCode.ToString());
                                                //Adde by Rajan on 2/8/2020 to get vendor path by passing email
                                                //SqlCommand cmd1 = new SqlCommand("usp_FETCH_Vendor_Path", con);
                                                //cmd1.CommandType = CommandType.StoredProcedure;
                                                //cmd1.Parameters.AddWithValue("@VendorEmail", moveMail.SenderEmailAddress.ToString());
                                                //object objval = cmd1.ExecuteScalar();

                                                //Modified by Rajan on 17/09/2020 after releasing to client,since client has multiple folders for same mail id also possible

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
                                                            vendorattachpath = @"C:\Users\Public\Documents\";
                                                            // Read All Attachements of RFQ FOLDER
                                                            var attachments = moveMail.Attachments;
                                                            sw.WriteLine("noofrecs1");
                                                            //  sw.WriteLine("vendorattachpath " + vendorattachpath);
                                                            //Added by Rajan on 2/8/2020
                                                            if (!String.IsNullOrEmpty(vendorattachpath))
                                                            {
                                                                //MessageBox.Show("22");
                                                                //   sw.WriteLine("Goes inside vendorattachpath");
                                                                ReceivedQuotationPath = vendorattachpath + @"\ReceivedQuotation";

                                                                sw.WriteLine("ReceivedQuotationPath" + ReceivedQuotationPath);
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
                                                                        sw.WriteLine(getCurrentTime() + "vendor attachpath exist but receivedquotationpath not exist, so created");
                                                                    }

                                                                    //  receivedMailMessage = ReceivedQuotationPath + @"\" + Subject.Trim().Replace(": ", "-") + " " + DateTime.Now.ToString().Replace("/", "-").Replace(":", "-") + ".msg";

                                                                    if (!string.IsNullOrEmpty(vendorQuote))
                                                                    {
                                                                        receivedMailMessage = ReceivedQuotationPath + @"\" + vendorQuote.Trim() + "_Dated " + DateTime.Now.ToString("MM/dd/yyyy").Replace("/", "-") + "_Time " + DateTime.Now.ToString("HH:mm:ss tt").Replace(":", "-") + ".msg";
                                                                        moveMail.SaveAs(receivedMailMessage.Trim(), Microsoft.Office.Interop.Outlook.OlSaveAsType.olMSG);
                                                                        sw.WriteLine("Mail saved inReceivedQuotationPath" + receivedMailMessage);
                                                                        lstMailItem.Add(moveMail);
                                                                    }
                                                                    else
                                                                    {
                                                                        receivedMailMessage = ReceivedQuotationPath + @"\" + "NoVendorQuote" + "_Dated " + DateTime.Now.ToString("MM/dd/yyyy").Replace("/", "-") + "_Time " + DateTime.Now.ToString("HH:mm:ss tt").Replace(":", "-") + ".msg";
                                                                        moveMail.SaveAs(receivedMailMessage.Trim(), Microsoft.Office.Interop.Outlook.OlSaveAsType.olMSG);
                                                                        sw.WriteLine("Mail saved inReceivedQuotationPath" + receivedMailMessage);
                                                                        //MessageBox.Show("VendorQuote is Empty ,Mail Not saved");
                                                                        sw.WriteLine("VendorQuote is Empty ");
                                                                        lstMailItem.Add(moveMail);
                                                                    }
                                                                    sw.WriteLine();
                                                                }//Vendorattachpath dir exist
                                                            }
                                                            else
                                                            {
                                                                sw.WriteLine(getCurrentTime() + "2Vendor folder PATH IS EMPTY");
                                                            }
                                                        }
                                                    }//single folder path for vendor
                                                    else if (noofrecs > 1)
                                                    {
                                                        for (int a = 0; a < arrFolderPath.Count(); a++)
                                                        {
                                                            if (arrFolderPath[a] != "")
                                                            {
                                                                vendorattachpath = arrFolderPath[a];
                                                                // Read All Attachements of RFQ FOLDER
                                                                var attachments = moveMail.Attachments;
                                                                sw.WriteLine(getCurrentTime() + "noofrecsgreaterthan1");
                                                                //    sw.WriteLine("attachments created");
                                                                //     sw.WriteLine("vendorattachpath " + vendorattachpath);
                                                                //Added by Rajan on 2/8/2020
                                                                if (!String.IsNullOrEmpty(vendorattachpath))
                                                                {
                                                                    //MessageBox.Show("22");
                                                                    //  sw.WriteLine("Goes inside vendorattachpath");
                                                                    ReceivedQuotationPath = vendorattachpath + @"\ReceivedQuotation";

                                                                    sw.WriteLine("ReceivedQuotationPath" + ReceivedQuotationPath);
                                                                    //ONLY receivedquotationpath is created,removed sentrfq and attachments path
                                                                    if (!Directory.Exists(vendorattachpath))
                                                                    {
                                                                        Directory.CreateDirectory(vendorattachpath);
                                                                        Directory.CreateDirectory(ReceivedQuotationPath);
                                                                        sw.WriteLine("vendorattachpath created");
                                                                        sw.WriteLine("ReceivedQuotationPath created");
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
                                                                            sw.WriteLine("Mail saved inReceivedQuotationPath" + receivedMailMessage);
                                                                            lstMailItem.Add(moveMail);
                                                                        }
                                                                        else
                                                                        {
                                                                            //MessageBox.Show("VendorQuote is Empty ,Mail Not saved");
                                                                            receivedMailMessage = ReceivedQuotationPath + @"\" + "NoQuote" + "_Dated " + DateTime.Now.ToString("MM/dd/yyyy").Replace("/", "-") + "_Time " + DateTime.Now.ToString("HH:mm:ss tt").Replace(":", "-") + ".msg";
                                                                            moveMail.SaveAs(receivedMailMessage.Trim(), Microsoft.Office.Interop.Outlook.OlSaveAsType.olMSG);
                                                                            sw.WriteLine("Mail saved inReceivedQuotationPath" + receivedMailMessage);
                                                                            sw.WriteLine("VendorQuote is Empty");
                                                                            lstMailItem.Add(moveMail);
                                                                        }
                                                                        sw.WriteLine();
                                                                    }//Vendorattachpath dir exist
                                                                }
                                                                else
                                                                {
                                                                    sw.WriteLine("2Vendor PATH IS EMPTY");
                                                                }
                                                            }
                                                        }//multiple folder path for loop
                                                    }//NOOFRECS >1 ,multiple folder path for same vendor
                                                    else if (noofrecs == 0)
                                                    {
                                                        MessageBox.Show("FolderPath not exist for this vendor in Database");
                                                        //  sw.WriteLine("Folder not exist for this vendor in Database");
                                                    }

                                                    if (sdr != null)
                                                    {
                                                        sdr.Close();
                                                    }
                                                    if (con != null)
                                                    {
                                                        con.Close();
                                                    }
                                                }

                                                //   sw.WriteLine("vendorattachpath created" + vendorattachpath);
                                            }//dtRFQReceived count >0
                                        }
                                        else
                                        {
                                            sw.WriteLine(getCurrentTime() + "datable is empty-no records from sample html");
                                        }//dt not null

                                        rcount++;
                                    }//subject contains re or fwd msg

                                }//subject is not empty
                                scount++;

                            }//movemail not null
                        }
                        catch (System.Exception ex)
                        {
                            fcnt = 0;
                            // MessageBox.Show(ex.Message);
                            sw.WriteLine(getCurrentTime() + "Error: " + ex.Message);
                        }
                    }//for loop of all inbox items
                    sw.WriteLine(getCurrentTime() + "lstMailItem count" + lstMailItem.Count().ToString());

                    if (lstMailItem.Count > 0)
                    {
                        foreach (var MailItem in lstMailItem)
                        {
                            sw.WriteLine("BEFORE MOVING...");
                            MailItem.Move(readRFQFolder);
                            sw.WriteLine("MAILS MOVED SUCCESSFULLY TO READ RFQ FOLDER");
                        }
                        MessageBox.Show("Mail moved successfully");
                    }
                    else
                    {
                        MessageBox.Show("No Replied RFQ mails in your InBox");
                        sw.WriteLine("No Replied RFQ mails in your InBox");
                    }
                    //MessageBox.Show("Total Forward or Reply mails of RFQ : " + rcount);
                    sw.WriteLine("Total Forward or Reply mails of RFQ : " + rcount);
                }
                else
                {
                    MessageBox.Show("No Items in inbox");
                    sw.WriteLine(getCurrentTime() + "inboxitemsNULL");
                }

                if (sw != null)
                {
                    sw.WriteLine(getCurrentTime() + "sw closed ");
                    sw.Close();
                    //  MessageBox.Show("sw closed");
                }

            }
            catch (System.Exception readex)
            {
                if (!isReadRFQFolder)
                {
                    MessageBox.Show("Please check Read_RFQ folder is created inside the Inbox,If so create it outside the Inbox");
                }

            }

        }

        private String getCurrentTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
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

        private void rbtnTKPPTemplate_Click(object sender, RibbonControlEventArgs e)
        {
            Template_Edior te = new Template_Edior();
            te.Show();
        }

        private void btnSend_TKPP_RFQ_Click(object sender, RibbonControlEventArgs e)
        {

            doSendRFQ();
        }

        private void Assignvalues(string filePath)
        {
            try
            {
                using (XLWorkbook workBook = new XLWorkbook(filePath))
                {
                    if (!String.IsNullOrEmpty(strconfigExcelSheet))
                    {
                        //IXLWorksheet workSheet = workBook.Worksheet(System.Configuration.ConfigurationManager.AppSettings["ExcelSheet"]);
                        IXLWorksheet workSheet = workBook.Worksheet(strconfigExcelSheet);

                        dtsource = new DataTable();

                        bool firstRow = true;
                        foreach (IXLRow row in workSheet.Rows())
                        {
                            if (firstRow)
                            {
                                foreach (IXLCell cell in row.Cells())
                                {
                                    dtsource.Columns.Add(cell.Value.ToString());

                                    log.Info("dtsourcecolmns" + cell.Value.ToString());
                                }
                                firstRow = false;
                            }
                            else
                            {
                                dtsource.Rows.Add();
                                int i = 0;


                                log.Info("dtsourcecolmnscount" + dtsource.Columns.Count.ToString());

                                //foreach (IXLCell cell in row.Cells())
                                foreach (IXLCell cell in row.Cells(1, dtsource.Columns.Count))
                                {


                                    log.Info("firstdtsourcerowscount" + dtsource.Rows.Count.ToString());
                                    log.Info("ival" + i.ToString());
                                    log.Info("cellvalue" + cell.Value.ToString());
                                    log.Info("iscellempty" + cell.IsEmpty());

                                    if (!cell.IsEmpty())
                                    {
                                        dtsource.Rows[dtsource.Rows.Count - 1][i] = cell.Value.ToString();
                                    }
                                    i++;
                                }
                            }

                        }
                    }


                }

                log.Info("finaldtsourcerowscount" + dtsource.Rows.Count.ToString());


            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }

        public static DataTable GetDistinctRecords(DataTable dt, string[] Columns)
        {
            DataTable dtUniqRecords = new DataTable();
            dtUniqRecords = dt.DefaultView.ToTable(true, Columns);
            return dtUniqRecords;
        }

        private void doSendRFQ()
        {
            try
            {
                //  vendorPath = System.Configuration.ConfigurationManager.AppSettings["SentRFQPath"];
                DAL_FO_RFQ objDAL_FO_RFQ = new DAL_FO_RFQ();
                DataSet dsSQL = new DataSet();
                DataTable dtSQL = new DataTable();
                DataTable dtFilter_Final = new DataTable();
                try
                {
                    DataTable configValuesdt = objDAL_FO_RFQ.getConfig();
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw ex;

                }
               
                strconfigExcelPath = objDAL_FO_RFQ.Fetch_ConfigValues("ExcelPath");
                strconfigExcelSheet = objDAL_FO_RFQ.Fetch_ConfigValues("ExcelSheet");
                strconfigSentRFQPath = objDAL_FO_RFQ.Fetch_ConfigValues("SentRFQPath");
                LogRFQ = objDAL_FO_RFQ.Fetch_ConfigValues("LogRFQPP");
             

                //Assignvalues(System.Configuration.ConfigurationManager.AppSettings["ExcelPath"]);
                if (!string.IsNullOrEmpty(strconfigExcelPath))
                {
                    Assignvalues(strconfigExcelPath);
                }
                //  MessageBox.Show("1" + logpath);
                log.Info("Records pulled from EXcel" + DateTime.Now);

                //dtsource=RFQ copied from excel (RFQ Tool-Addition information)
                if (dtsource.Rows.Count > 0)
                {
                    string connectionString = ConfigurationManager.AppSettings["DefaultConnection"].ToString();
                    String query1 = "select Batch  from tbl_PP_RFQ_Header group by Batch ";

                    System.Data.DataSet dataSet = new System.Data.DataSet();
                    try
                    {
                        // Establish a connection
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            // Create a data adapter with the query and connection
                            using (SqlDataAdapter adapter1 = new SqlDataAdapter(query1, connection))
                            {
                                // Fill the DataSet
                                adapter1.Fill(dataSet);
                                dsSQL = dataSet;
 
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }


                   

                    SqlConnection con;
                    SqlDataAdapter adapter;
                    DataSet ds = new DataSet();
                    try
                    {
                        //create connection object
                        con = new SqlConnection(connectionString);
                        //create query string(SELECT QUERY)
                        String query = "select   Batch  from tbl_PP_RFQ_Header group by batch ";
                        // String query = "select distinct Batch  from tbl_PP_RFQ_Header";
                        con.Open();
                        //Adapter bind to query and connection object
                        adapter = new SqlDataAdapter(query, con);
                        //fill the dataset
                        adapter.Fill(ds);
                        dsSQL = ds;
                   

                    }
                    catch (System.Exception ex)
                    {
                        throw ex;
                    }
                    

                    //dsSQL= objDAL_FO_RFQ.PP_RFQ_Fetch_LinerDetails();
                    dtSQL = dsSQL.Tables[0];

                    //  MessageBox.Show("3" + logpath);
                    log.Info("dtSQL record count " + dtSQL.Rows.Count);

                    var filter = from firstDt in dtsource.AsEnumerable().Where(r1 => r1["Batch"].ToString().Trim() != "")
                                    where !(from secondDt in dtSQL.AsEnumerable() select secondDt["Batch"]).Contains(firstDt["Batch"].ToString())
                                 select firstDt;
              
                    //MessageBox.Show("4" + logpath);
                    log.Info("Excel records should not contain liner details records" + filter);
                    if (filter.Count() == 0)
                    {
                        MessageBox.Show("No RFQ available");
                    }
                    else
                    {
                        dtFilter_Final = filter.CopyToDataTable();

                        if (dtFilter_Final.Rows.Count > 0)
                        {
                            if (LogRFQ == "1")
                            {
                                //MessageBox.Show("5" + logpath);
                                log.Info(logpath + "    dtFilter_Final record count greater 0");
                            }
                            SendRFQ_TKPP objSendRFQ_FOSO = new SendRFQ_TKPP(dtFilter_Final);
                            
                            objSendRFQ_FOSO.ShowDialog();
                            //if ((objSendRFQ_FOSO.dtnew != null)
                            //Added by Rajan on 29/7/2020 issue:Previously it throws error if no records selected in grid,
                            //now added condition as record existed then proceed with sending email otherwise throw 
                            //message as "No Record Selected"
                            if ((objSendRFQ_FOSO.dtnew != null) && (objSendRFQ_FOSO.dtnew.Rows.Count > 0))
                            {
                                DataTable dtLiner_Filter = new DataTable();
                                DataTable dtHeader = new DataTable();
                                DataTable dtLiner = new DataTable();
                                DataTable dtMailSent = new DataTable();
                                StringBuilder sbHeader = new StringBuilder();
                                StringBuilder sbLiner = new StringBuilder();
                                DataTable dt = new DataTable();
                                dt = objSendRFQ_FOSO.dtnew;

                                //Adding mailsent status to dtmailsent
                                //dtMailSent.Columns.Add("SAP Material Number");
                                dtMailSent.Columns.Add("Vendor_ID");
                                dtMailSent.Columns.Add("RFQ_refer");
                                dtMailSent.Columns.Add("Status");

                                if (LogRFQ == "1")
                                    log.Info("dt Records selected");

                                if (dt.Rows.Count > 0)
                                {
                                    if (LogRFQ == "1")
                                        log.Info("dt.Rows.Count greater 0");

                                    System.Data.DataView view = new System.Data.DataView(dt);
                                    foreach (DataColumn columname in dt.Columns)
                                    {
                                        if (columname.ColumnName.Contains("Batch") || columname.ColumnName.Contains("V#") || columname.ColumnName.Contains("Ordered Part") || columname.ColumnName.Contains("Part Description") || columname.ColumnName.Contains("Vendor") || columname.ColumnName.Contains("RFQ Refer") || columname.ColumnName.Contains("Vendor ID") || columname.ColumnName.Contains("Remarks") || columname.ColumnName.Contains("Price_Break_1") || columname.ColumnName.Contains("Price_Break_2") || columname.ColumnName.Contains("Price_Break_3") || columname.ColumnName.Contains("Price_Break_4") || columname.ColumnName.Contains("Price_Break_5") || columname.ColumnName.Contains("Price_Break_10") || columname.ColumnName.Contains("Price_Break_25") || columname.ColumnName.Contains("Price_Break_50") || columname.ColumnName.Contains("Price_Break_100") || columname.ColumnName.Contains("RFQ Deadline") || columname.ColumnName.Contains("UOM"))
                                        {
                                            sbLiner.Append(columname + ",");
                                        }
                                        if (!columname.ColumnName.Contains("V#") && !columname.ColumnName.Contains("Unit Price") && !columname.ColumnName.Contains("Price_Break") && !columname.ColumnName.Contains("Remarks") && !columname.ColumnName.Contains("Vendor ID") && !columname.ColumnName.Contains("UOM"))
                                        {
                                            sbHeader.Append(columname + ",");
                                        }
                                    }

                                   

                                    if (LogRFQ == "1")
                                    {
                                        log.Info("sbHeader cols" + sbHeader.ToString());
                                        log.Info("sbLINER cols" + sbLiner.ToString());
                                    }

                                    string[] dtHeader_Array = sbHeader.ToString().Split(',');
                                    dtHeader_Array = dtHeader_Array.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                                    string[] dtLiner_Array = sbLiner.ToString().Split(',');
                                    dtLiner_Array = dtLiner_Array.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                                    //copies dtlinerarray to dtliner table
                                    dtLiner = view.ToTable("dtLiner", false, dtLiner_Array);
                                    if (LogRFQ == "1")
                                        log.Info("dtLiner rows count" + dtLiner.Rows.Count);

                                    //copies dtheaderarray to dtheadertable
                                    dtHeader = view.ToTable("dtHeader", false, dtHeader_Array);
                                    dtHeader.Columns.Add("CreatedDate", typeof(DateTime));
                                    dtHeader.Columns.Add("ModifiedDate", typeof(DateTime));
                                    string strColCreatedDate = "CreatedDate";
                                    DataColumn colNewCreatedDate = new DataColumn(strColCreatedDate, typeof(DateTime));
                                    colNewCreatedDate.DefaultValue = DateTime.Now;
                                    dtHeader.Columns.Remove(strColCreatedDate);
                                    dtHeader.Columns.Add(colNewCreatedDate);
                                    string strColModifiedDate = "ModifiedDate";
                                    DataColumn colNewModifiedDate = new DataColumn(strColModifiedDate, typeof(DateTime));
                                    colNewModifiedDate.DefaultValue = DateTime.Now;
                                    dtHeader.Columns.Remove(strColModifiedDate);
                                    dtHeader.Columns.Add(colNewModifiedDate);

                                    if (LogRFQ == "1")
                                        log.Info("dtHeader rows count" + dtHeader.Rows.Count);

                                    //dtLiner_Filter.Columns.Add("RFQ Date");
                                    //dtLiner_Filter.Columns.Add("Requester");
                                    dtHeader.AcceptChanges();
                                    dtLiner_Filter.Columns.Add("Batch");
                                    dtLiner_Filter.Columns.Add("RFQ_refer");
                                    dtLiner_Filter.Columns.Add("Ordered Part");
                                    dtLiner_Filter.Columns.Add("Vendor_ID");
                                    dtLiner_Filter.Columns.Add("UOM");
                                    dtLiner_Filter.Columns.Add("Conversion_Qty");
                                    dtLiner_Filter.Columns.Add("Country_Of_Origin");
                                    dtLiner_Filter.Columns.Add("LeadTime");
                                    dtLiner_Filter.Columns.Add("Quotation");
                                    dtLiner_Filter.Columns.Add("Currency");
                                    dtLiner_Filter.Columns.Add("RFQ Deadline");
                                    dtLiner_Filter.Columns.Add("Price_Break_1");
                                    dtLiner_Filter.Columns.Add("Price_Break_2");
                                    dtLiner_Filter.Columns.Add("Price_Break_3");
                                    dtLiner_Filter.Columns.Add("Price_Break_4");
                                    dtLiner_Filter.Columns.Add("Price_Break_5");
                                    dtLiner_Filter.Columns.Add("Price_Break_10");
                                    dtLiner_Filter.Columns.Add("Price_Break_25");
                                    dtLiner_Filter.Columns.Add("Price_Break_50");
                                    dtLiner_Filter.Columns.Add("Price_Break_100");
                                    dtLiner_Filter.Columns.Add("Remarks");
                                    dtLiner_Filter.Columns.Add("CreatedDate", typeof(DateTime));
                                    dtLiner_Filter.Columns.Add("ModifiedDate", typeof(DateTime));
                                    dtLiner_Filter.Columns["CreatedDate"].DefaultValue = DateTime.Now;
                                    dtLiner_Filter.Columns["ModifiedDate"].DefaultValue = DateTime.Now;
                                    dtLiner_Filter.Columns["Remarks"].DefaultValue = "";
                                    if (LogRFQ == "1")
                                    {
                                        log.Info("dtLiner_Filter columns added");
                                        log.Info("dtLiner Rows" + dtLiner.Rows.Count.ToString());
                                    }

                                    foreach (DataRow dr in dtLiner.Rows)
                                    {
                                        DataRow dtrow1 = dtLiner_Filter.NewRow();
                                        DataRow dtrow2 = dtLiner_Filter.NewRow();
                                        DataRow dtrow3 = dtLiner_Filter.NewRow();
                                        DataRow dtrow4 = dtLiner_Filter.NewRow();
                                        DataRow dtrow5 = dtLiner_Filter.NewRow();
                                        DataRow dtrow6 = dtLiner_Filter.NewRow();
                                        DataRow dtrow7 = dtLiner_Filter.NewRow();
                                        DataRow dtrow8 = dtLiner_Filter.NewRow();
                                        DataRow dtrow9 = dtLiner_Filter.NewRow();
                                        DataRow dtrow10 = dtLiner_Filter.NewRow();
                                        for (int j = 0; j < 10; j++)
                                        {
                                            foreach (DataColumn dc in dtLiner.Columns)
                                            {
                                                if (j == 0 && string.IsNullOrEmpty(dr["V#1"].ToString()) != true && (dc.ColumnName.Contains("Batch") || dc.ColumnName.Contains("V#1") || dc.ColumnName.Contains("Ordered Part") || dc.ColumnName.Contains("Part Description") || dc.ColumnName.Contains("Vendor") || dc.ColumnName.Contains("RFQ Refer") || dc.ColumnName.Contains("Vendor ID") || dc.ColumnName.Contains("Remarks") || dc.ColumnName.Contains("Price_Break_1") || dc.ColumnName.Contains("Price_Break_2") || dc.ColumnName.Contains("Price_Break_3") || dc.ColumnName.Contains("Price_Break_4") || dc.ColumnName.Contains("Price_Break_5") || dc.ColumnName.Contains("Price_Break_10") || dc.ColumnName.Contains("Price_Break_25") || dc.ColumnName.Contains("Price_Break_50") || dc.ColumnName.Contains("Price_Break_100") || dc.ColumnName.Contains("UOM")))
                                                {
                                                    if (dc.ColumnName == "Ordered Part")
                                                    {
                                                        dtrow1["Ordered Part"] = dr["Ordered Part"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "Batch")
                                                    {
                                                       
                                                        dtrow1["Batch"] = dr["Batch"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "RFQ Refer")
                                                    {
                                                        dtrow1["RFQ_refer"] = dr["RFQ Refer"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "V#1")
                                                    {
                                                        dtrow1["Vendor_ID"] = dr["V#1"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "Remarks")
                                                    {
                                                        dtrow1["Remarks"] = dr["Remarks"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "UOM")
                                                    {
                                                        dtrow1["UOM"] = dr["UOM"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_1")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_1"].ToString()) != true)
                                                        {
                                                            dtrow1["Price_Break_1"] = Convert.ToDecimal(dr["Price_Break_1"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow1["Price_Break_1"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_2")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_2"].ToString()) != true)
                                                        {
                                                            dtrow1["Price_Break_2"] = Convert.ToDecimal(dr["Price_Break_2"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow1["Price_Break_2"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_3")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_3"].ToString()) != true)
                                                        {
                                                            dtrow1["Price_Break_3"] = Convert.ToDecimal(dr["Price_Break_3"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow1["Price_Break_3"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_4")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_4"].ToString()) != true)
                                                        {
                                                            dtrow1["Price_Break_4"] = Convert.ToDecimal(dr["Price_Break_4"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow1["Price_Break_4"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_5")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_5"].ToString()) != true)
                                                        {
                                                            dtrow1["Price_Break_5"] = Convert.ToDecimal(dr["Price_Break_5"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow1["Price_Break_5"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_10")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_10"].ToString()) != true)
                                                        {
                                                            dtrow1["Price_Break_10"] = Convert.ToDecimal(dr["Price_Break_10"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow1["Price_Break_10"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_25")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_25"].ToString()) != true)
                                                        {
                                                            dtrow1["Price_Break_25"] = Convert.ToDecimal(dr["Price_Break_25"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow1["Price_Break_25"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_50")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_50"].ToString()) != true)
                                                        {
                                                            dtrow1["Price_Break_50"] = Convert.ToDecimal(dr["Price_Break_50"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow1["Price_Break_50"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_100")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_100"].ToString()) != true)
                                                        {
                                                            dtrow1["Price_Break_100"] = Convert.ToDecimal(dr["Price_Break_100"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow1["Price_Break_100"] = 0.00;
                                                        }
                                                    }
                                                }
                                                else if (j == 1 && string.IsNullOrEmpty(dr["V#2"].ToString()) != true && (dc.ColumnName.Contains("Batch") || dc.ColumnName.Contains("V#2") || dc.ColumnName.Contains("Ordered Part") || dc.ColumnName.Contains("Part Description") || dc.ColumnName.Contains("Vendor") || dc.ColumnName.Contains("RFQ Refer") || dc.ColumnName.Contains("Vendor ID") || dc.ColumnName.Contains("Remarks") || dc.ColumnName.Contains("Price_Break_1") || dc.ColumnName.Contains("Price_Break_2") || dc.ColumnName.Contains("Price_Break_3") || dc.ColumnName.Contains("Price_Break_4") || dc.ColumnName.Contains("Price_Break_5") || dc.ColumnName.Contains("Price_Break_10") || dc.ColumnName.Contains("Price_Break_25") || dc.ColumnName.Contains("Price_Break_50") || dc.ColumnName.Contains("Price_Break_100") || dc.ColumnName.Contains("UOM")))
                                                {
                                                    if (dc.ColumnName == "Ordered Part")
                                                    {
                                                        dtrow2["Ordered Part"] = dr["Ordered Part"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "Batch")
                                                    {

                                                        dtrow2["Batch"] = dr["Batch"].ToString();
                                                    }
                                                    //else if (dc.ColumnName == "Part Description")
                                                    //{
                                                    //    dtrow2["Part Description"] = dr["Part Description"].ToString();
                                                    //}
                                                    //else if (dc.ColumnName == "Vendor")
                                                    //{
                                                    //    dtrow2["Vendor"] = dr["Vendor"].ToString();
                                                    //}
                                                    else if (dc.ColumnName == "RFQ Refer")
                                                    {
                                                        dtrow2["RFQ_refer"] = dr["RFQ Refer"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "V#2")
                                                    {
                                                        dtrow2["Vendor_ID"] = dr["V#2"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "Remarks")
                                                    {
                                                        dtrow2["Remarks"] = dr["Remarks"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "UOM")
                                                    {
                                                        dtrow2["UOM"] = dr["UOM"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_1")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_1"].ToString()) != true)
                                                        {
                                                            dtrow2["Price_Break_1"] = Convert.ToDecimal(dr["Price_Break_1"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow2["Price_Break_1"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_2")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_2"].ToString()) != true)
                                                        {
                                                            dtrow2["Price_Break_2"] = Convert.ToDecimal(dr["Price_Break_2"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow2["Price_Break_2"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_3")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_3"].ToString()) != true)
                                                        {
                                                            dtrow2["Price_Break_3"] = Convert.ToDecimal(dr["Price_Break_3"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow2["Price_Break_3"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_4")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_4"].ToString()) != true)
                                                        {
                                                            dtrow2["Price_Break_4"] = Convert.ToDecimal(dr["Price_Break_4"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow2["Price_Break_4"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_5")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_5"].ToString()) != true)
                                                        {
                                                            dtrow2["Price_Break_5"] = Convert.ToDecimal(dr["Price_Break_5"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow2["Price_Break_5"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_10")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_10"].ToString()) != true)
                                                        {
                                                            dtrow2["Price_Break_10"] = Convert.ToDecimal(dr["Price_Break_10"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow2["Price_Break_10"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_25")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_25"].ToString()) != true)
                                                        {
                                                            dtrow2["Price_Break_25"] = Convert.ToDecimal(dr["Price_Break_25"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow2["Price_Break_25"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_50")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_50"].ToString()) != true)
                                                        {
                                                            dtrow2["Price_Break_50"] = Convert.ToDecimal(dr["Price_Break_50"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow2["Price_Break_50"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_100")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_100"].ToString()) != true)
                                                        {
                                                            dtrow2["Price_Break_100"] = Convert.ToDecimal(dr["Price_Break_100"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow2["Price_Break_100"] = 0.00;
                                                        }
                                                    }
                                                }
                                                else if (j == 2 && string.IsNullOrEmpty(dr["V#3"].ToString()) != true && (dc.ColumnName.Contains("Batch") || dc.ColumnName.Contains("V#3") || dc.ColumnName.Contains("Ordered Part") || dc.ColumnName.Contains("Part Description") || dc.ColumnName.Contains("Vendor") || dc.ColumnName.Contains("RFQ Refer") || dc.ColumnName.Contains("Vendor ID") || dc.ColumnName.Contains("Remarks") || dc.ColumnName.Contains("Price_Break_1") || dc.ColumnName.Contains("Price_Break_2") || dc.ColumnName.Contains("Price_Break_3") || dc.ColumnName.Contains("Price_Break_4") || dc.ColumnName.Contains("Price_Break_5") || dc.ColumnName.Contains("Price_Break_10") || dc.ColumnName.Contains("Price_Break_25") || dc.ColumnName.Contains("Price_Break_50") || dc.ColumnName.Contains("Price_Break_100") || dc.ColumnName.Contains("UOM")))
                                                {
                                                    if (dc.ColumnName == "Ordered Part")
                                                    {
                                                        dtrow3["Ordered Part"] = dr["Ordered Part"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "Batch")
                                                    {
                                    

                                                        dtrow3["Batch"] = dr["Batch"].ToString();
                                                    }
                                                    //else if (dc.ColumnName == "Part Description")
                                                    //{
                                                    //    dtrow3["Part Description"] = dr["Part Description"].ToString();
                                                    //}
                                                    //else if (dc.ColumnName == "Vendor")
                                                    //{
                                                    //    dtrow3["Vendor"] = dr["Vendor"].ToString();
                                                    //}
                                                    else if (dc.ColumnName == "RFQ Refer")
                                                    {
                                                        dtrow3["RFQ_refer"] = dr["RFQ Refer"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "V#3")
                                                    {
                                                        dtrow3["Vendor_ID"] = dr["V#3"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "Remarks")
                                                    {
                                                        dtrow3["Remarks"] = dr["Remarks"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "UOM")
                                                    {
                                                        dtrow3["UOM"] = dr["UOM"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_1")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_1"].ToString()) != true)
                                                        {
                                                            dtrow3["Price_Break_1"] = Convert.ToDecimal(dr["Price_Break_1"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow3["Price_Break_1"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_2")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_2"].ToString()) != true)
                                                        {
                                                            dtrow3["Price_Break_2"] = Convert.ToDecimal(dr["Price_Break_2"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow3["Price_Break_2"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_3")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_3"].ToString()) != true)
                                                        {
                                                            dtrow3["Price_Break_3"] = Convert.ToDecimal(dr["Price_Break_3"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow3["Price_Break_3"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_4")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_4"].ToString()) != true)
                                                        {
                                                            dtrow3["Price_Break_4"] = Convert.ToDecimal(dr["Price_Break_4"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow3["Price_Break_4"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_5")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_5"].ToString()) != true)
                                                        {
                                                            dtrow3["Price_Break_5"] = Convert.ToDecimal(dr["Price_Break_5"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow3["Price_Break_5"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_10")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_10"].ToString()) != true)
                                                        {
                                                            dtrow3["Price_Break_10"] = Convert.ToDecimal(dr["Price_Break_10"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow3["Price_Break_10"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_25")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_25"].ToString()) != true)
                                                        {
                                                            dtrow3["Price_Break_25"] = Convert.ToDecimal(dr["Price_Break_25"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow3["Price_Break_25"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_50")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_50"].ToString()) != true)
                                                        {
                                                            dtrow3["Price_Break_50"] = Convert.ToDecimal(dr["Price_Break_50"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow3["Price_Break_50"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_100")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_100"].ToString()) != true)
                                                        {
                                                            dtrow3["Price_Break_100"] = Convert.ToDecimal(dr["Price_Break_100"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow3["Price_Break_100"] = 0.00;
                                                        }
                                                    }
                                                }
                                                else if (j == 3 && string.IsNullOrEmpty(dr["V#4"].ToString()) != true && (dc.ColumnName.Contains("Batch") || dc.ColumnName.Contains("V#4") || dc.ColumnName.Contains("Ordered Part") || dc.ColumnName.Contains("Part Description") || dc.ColumnName.Contains("Vendor") || dc.ColumnName.Contains("RFQ Refer") || dc.ColumnName.Contains("Vendor ID") || dc.ColumnName.Contains("Remarks") || dc.ColumnName.Contains("Price_Break_1") || dc.ColumnName.Contains("Price_Break_2") || dc.ColumnName.Contains("Price_Break_3") || dc.ColumnName.Contains("Price_Break_4") || dc.ColumnName.Contains("Price_Break_5") || dc.ColumnName.Contains("Price_Break_10") || dc.ColumnName.Contains("Price_Break_25") || dc.ColumnName.Contains("Price_Break_50") || dc.ColumnName.Contains("Price_Break_100") || dc.ColumnName.Contains("UOM")))
                                                {
                                                    if (dc.ColumnName == "Ordered Part")
                                                    {
                                                        dtrow4["Ordered Part"] = dr["Ordered Part"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "Batch")
                                                    {

                                                     
                                                        dtrow4["Batch"] = dr["Batch"].ToString();
                                                    }
                                                    //else if (dc.ColumnName == "Part Description")
                                                    //{
                                                    //    dtrow4["Part Description"] = dr["Part Description"].ToString();
                                                    //}
                                                    //else if (dc.ColumnName == "Vendor")
                                                    //{
                                                    //    dtrow4["Vendor"] = dr["Vendor"].ToString();
                                                    //}
                                                    else if (dc.ColumnName == "RFQ Refer")
                                                    {
                                                        dtrow4["RFQ_refer"] = dr["RFQ Refer"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "V#4")
                                                    {
                                                        dtrow4["Vendor_ID"] = dr["V#4"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "Remarks")
                                                    {
                                                        dtrow4["Remarks"] = dr["Remarks"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "UOM")
                                                    {
                                                        dtrow4["UOM"] = dr["UOM"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_1")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_1"].ToString()) != true)
                                                        {
                                                            dtrow4["Price_Break_1"] = Convert.ToDecimal(dr["Price_Break_1"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow4["Price_Break_1"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_2")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_2"].ToString()) != true)
                                                        {
                                                            dtrow4["Price_Break_2"] = Convert.ToDecimal(dr["Price_Break_2"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow4["Price_Break_2"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_3")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_3"].ToString()) != true)
                                                        {
                                                            dtrow4["Price_Break_3"] = Convert.ToDecimal(dr["Price_Break_3"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow4["Price_Break_3"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_4")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_4"].ToString()) != true)
                                                        {
                                                            dtrow4["Price_Break_4"] = Convert.ToDecimal(dr["Price_Break_4"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow4["Price_Break_4"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_5")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_5"].ToString()) != true)
                                                        {
                                                            dtrow4["Price_Break_5"] = Convert.ToDecimal(dr["Price_Break_5"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow4["Price_Break_5"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_10")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_10"].ToString()) != true)
                                                        {
                                                            dtrow4["Price_Break_10"] = Convert.ToDecimal(dr["Price_Break_10"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow4["Price_Break_10"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_25")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_25"].ToString()) != true)
                                                        {
                                                            dtrow4["Price_Break_25"] = Convert.ToDecimal(dr["Price_Break_25"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow4["Price_Break_25"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_50")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_50"].ToString()) != true)
                                                        {
                                                            dtrow4["Price_Break_50"] = Convert.ToDecimal(dr["Price_Break_50"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow4["Price_Break_50"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_100")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_100"].ToString()) != true)
                                                        {
                                                            dtrow4["Price_Break_100"] = Convert.ToDecimal(dr["Price_Break_100"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow4["Price_Break_100"] = 0.00;
                                                        }
                                                    }
                                                }
                                                else if (j == 4 && string.IsNullOrEmpty(dr["V#5"].ToString()) != true && (dc.ColumnName.Contains("Batch") || dc.ColumnName.Contains("V#5") || dc.ColumnName.Contains("Ordered Part") || dc.ColumnName.Contains("Part Description") || dc.ColumnName.Contains("Vendor") || dc.ColumnName.Contains("RFQ Refer") || dc.ColumnName.Contains("Vendor ID") || dc.ColumnName.Contains("Remarks") || dc.ColumnName.Contains("Price_Break_1") || dc.ColumnName.Contains("Price_Break_2") || dc.ColumnName.Contains("Price_Break_3") || dc.ColumnName.Contains("Price_Break_4") || dc.ColumnName.Contains("Price_Break_5") || dc.ColumnName.Contains("Price_Break_10") || dc.ColumnName.Contains("Price_Break_25") || dc.ColumnName.Contains("Price_Break_50") || dc.ColumnName.Contains("Price_Break_100") || dc.ColumnName.Contains("UOM")))
                                                {
                                                    if (dc.ColumnName == "Ordered Part")
                                                    {
                                                        dtrow5["Ordered Part"] = dr["Ordered Part"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "Batch")
                                                    {
                                                

                                                        dtrow5["Batch"] = dr["Batch"].ToString();
                                                    }
                                                    //else if (dc.ColumnName == "Part Description")
                                                    //{
                                                    //    dtrow5["Part Description"] = dr["Part Description"].ToString();
                                                    //}
                                                    //else if (dc.ColumnName == "Vendor")
                                                    //{
                                                    //    dtrow5["Vendor"] = dr["Vendor"].ToString();
                                                    //}
                                                    else if (dc.ColumnName == "RFQ Refer")
                                                    {
                                                        dtrow5["RFQ_refer"] = dr["RFQ Refer"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "V#5")
                                                    {
                                                        dtrow5["Vendor_ID"] = dr["V#5"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "Remarks")
                                                    {
                                                        dtrow5["Remarks"] = dr["Remarks"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "UOM")
                                                    {
                                                        dtrow5["UOM"] = dr["UOM"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_1")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_1"].ToString()) != true)
                                                        {
                                                            dtrow5["Price_Break_1"] = Convert.ToDecimal(dr["Price_Break_1"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow5["Price_Break_1"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_2")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_2"].ToString()) != true)
                                                        {
                                                            dtrow5["Price_Break_2"] = Convert.ToDecimal(dr["Price_Break_2"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow5["Price_Break_2"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_3")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_3"].ToString()) != true)
                                                        {
                                                            dtrow5["Price_Break_3"] = Convert.ToDecimal(dr["Price_Break_3"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow5["Price_Break_3"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_4")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_4"].ToString()) != true)
                                                        {
                                                            dtrow5["Price_Break_4"] = Convert.ToDecimal(dr["Price_Break_4"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow5["Price_Break_4"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_5")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_5"].ToString()) != true)
                                                        {
                                                            dtrow5["Price_Break_5"] = Convert.ToDecimal(dr["Price_Break_5"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow5["Price_Break_5"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_10")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_10"].ToString()) != true)
                                                        {
                                                            dtrow5["Price_Break_10"] = Convert.ToDecimal(dr["Price_Break_10"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow5["Price_Break_10"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_25")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_25"].ToString()) != true)
                                                        {
                                                            dtrow5["Price_Break_25"] = Convert.ToDecimal(dr["Price_Break_25"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow5["Price_Break_25"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_50")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_50"].ToString()) != true)
                                                        {
                                                            dtrow5["Price_Break_50"] = Convert.ToDecimal(dr["Price_Break_50"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow5["Price_Break_50"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_100")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_100"].ToString()) != true)
                                                        {
                                                            dtrow5["Price_Break_100"] = Convert.ToDecimal(dr["Price_Break_100"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow5["Price_Break_100"] = 0.00;
                                                        }
                                                    }
                                                }
                                                else if (j == 5 && string.IsNullOrEmpty(dr["V#6"].ToString()) != true && (dc.ColumnName.Contains("Batch") || dc.ColumnName.Contains("V#6") || dc.ColumnName.Contains("Ordered Part") || dc.ColumnName.Contains("Part Description") || dc.ColumnName.Contains("Vendor") || dc.ColumnName.Contains("RFQ Refer") || dc.ColumnName.Contains("Vendor ID") || dc.ColumnName.Contains("Remarks") || dc.ColumnName.Contains("Price_Break_1") || dc.ColumnName.Contains("Price_Break_2") || dc.ColumnName.Contains("Price_Break_3") || dc.ColumnName.Contains("Price_Break_4") || dc.ColumnName.Contains("Price_Break_5") || dc.ColumnName.Contains("Price_Break_10") || dc.ColumnName.Contains("Price_Break_25") || dc.ColumnName.Contains("Price_Break_50") || dc.ColumnName.Contains("Price_Break_100") || dc.ColumnName.Contains("UOM")))
                                                {
                                                    if (dc.ColumnName == "Ordered Part")
                                                    {
                                                        dtrow6["Ordered Part"] = dr["Ordered Part"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "Batch")
                                                    {

                                                        dtrow6["Batch"] = dr["Batch"].ToString();
                                                    }
                                                    //else if (dc.ColumnName == "Part Description")
                                                    //{
                                                    //    dtrow5["Part Description"] = dr["Part Description"].ToString();
                                                    //}
                                                    //else if (dc.ColumnName == "Vendor")
                                                    //{
                                                    //    dtrow5["Vendor"] = dr["Vendor"].ToString();
                                                    //}
                                                    else if (dc.ColumnName == "RFQ Refer")
                                                    {
                                                        dtrow6["RFQ_refer"] = dr["RFQ Refer"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "V#6")
                                                    {
                                                        dtrow6["Vendor_ID"] = dr["V#6"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "Remarks")
                                                    {
                                                        dtrow6["Remarks"] = dr["Remarks"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "UOM")
                                                    {
                                                        dtrow6["UOM"] = dr["UOM"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_1")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_1"].ToString()) != true)
                                                        {
                                                            dtrow6["Price_Break_1"] = Convert.ToDecimal(dr["Price_Break_1"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow6["Price_Break_1"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_2")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_2"].ToString()) != true)
                                                        {
                                                            dtrow6["Price_Break_2"] = Convert.ToDecimal(dr["Price_Break_2"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow6["Price_Break_2"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_3")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_3"].ToString()) != true)
                                                        {
                                                            dtrow6["Price_Break_3"] = Convert.ToDecimal(dr["Price_Break_3"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow6["Price_Break_3"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_4")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_4"].ToString()) != true)
                                                        {
                                                            dtrow6["Price_Break_4"] = Convert.ToDecimal(dr["Price_Break_4"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow6["Price_Break_4"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_5")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_5"].ToString()) != true)
                                                        {
                                                            dtrow6["Price_Break_5"] = Convert.ToDecimal(dr["Price_Break_5"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow6["Price_Break_5"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_10")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_10"].ToString()) != true)
                                                        {
                                                            dtrow6["Price_Break_10"] = Convert.ToDecimal(dr["Price_Break_10"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow6["Price_Break_10"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_25")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_25"].ToString()) != true)
                                                        {
                                                            dtrow6["Price_Break_25"] = Convert.ToDecimal(dr["Price_Break_25"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow6["Price_Break_25"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_50")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_50"].ToString()) != true)
                                                        {
                                                            dtrow6["Price_Break_50"] = Convert.ToDecimal(dr["Price_Break_50"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow6["Price_Break_50"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_100")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_100"].ToString()) != true)
                                                        {
                                                            dtrow6["Price_Break_100"] = Convert.ToDecimal(dr["Price_Break_100"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow6["Price_Break_100"] = 0.00;
                                                        }
                                                    }
                                                }
                                                else if (j == 6 && string.IsNullOrEmpty(dr["V#7"].ToString()) != true && (dc.ColumnName.Contains("Batch") || dc.ColumnName.Contains("V#7") || dc.ColumnName.Contains("Ordered Part") || dc.ColumnName.Contains("Part Description") || dc.ColumnName.Contains("Vendor") || dc.ColumnName.Contains("RFQ Refer") || dc.ColumnName.Contains("Vendor ID") || dc.ColumnName.Contains("Remarks") || dc.ColumnName.Contains("Price_Break_1") || dc.ColumnName.Contains("Price_Break_2") || dc.ColumnName.Contains("Price_Break_3") || dc.ColumnName.Contains("Price_Break_4") || dc.ColumnName.Contains("Price_Break_5") || dc.ColumnName.Contains("Price_Break_10") || dc.ColumnName.Contains("Price_Break_25") || dc.ColumnName.Contains("Price_Break_50") || dc.ColumnName.Contains("Price_Break_100") || dc.ColumnName.Contains("UOM")))
                                                {
                                                    if (dc.ColumnName == "Ordered Part")
                                                    {
                                                        dtrow7["Ordered Part"] = dr["Ordered Part"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "Batch")
                                                    {
                                                        dtrow7["Batch"] = dr["Batch"].ToString();
                                                    }
                                                    //else if (dc.ColumnName == "Part Description")
                                                    //{
                                                    //    dtrow5["Part Description"] = dr["Part Description"].ToString();
                                                    //}
                                                    //else if (dc.ColumnName == "Vendor")
                                                    //{
                                                    //    dtrow5["Vendor"] = dr["Vendor"].ToString();
                                                    //}
                                                    else if (dc.ColumnName == "RFQ Refer")
                                                    {
                                                        dtrow7["RFQ_refer"] = dr["RFQ Refer"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "V#7")
                                                    {
                                                        dtrow7["Vendor_ID"] = dr["V#7"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "Remarks")
                                                    {
                                                        dtrow7["Remarks"] = dr["Remarks"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "UOM")
                                                    {
                                                        dtrow7["UOM"] = dr["UOM"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_1")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_1"].ToString()) != true)
                                                        {
                                                            dtrow7["Price_Break_1"] = Convert.ToDecimal(dr["Price_Break_1"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow7["Price_Break_1"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_2")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_2"].ToString()) != true)
                                                        {
                                                            dtrow7["Price_Break_2"] = Convert.ToDecimal(dr["Price_Break_2"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow7["Price_Break_2"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_3")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_3"].ToString()) != true)
                                                        {
                                                            dtrow7["Price_Break_3"] = Convert.ToDecimal(dr["Price_Break_3"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow7["Price_Break_3"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_4")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_4"].ToString()) != true)
                                                        {
                                                            dtrow7["Price_Break_4"] = Convert.ToDecimal(dr["Price_Break_4"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow7["Price_Break_4"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_5")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_5"].ToString()) != true)
                                                        {
                                                            dtrow7["Price_Break_5"] = Convert.ToDecimal(dr["Price_Break_5"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow7["Price_Break_5"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_10")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_10"].ToString()) != true)
                                                        {
                                                            dtrow7["Price_Break_10"] = Convert.ToDecimal(dr["Price_Break_10"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow7["Price_Break_10"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_25")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_25"].ToString()) != true)
                                                        {
                                                            dtrow7["Price_Break_25"] = Convert.ToDecimal(dr["Price_Break_25"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow7["Price_Break_25"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_50")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_50"].ToString()) != true)
                                                        {
                                                            dtrow7["Price_Break_50"] = Convert.ToDecimal(dr["Price_Break_50"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow7["Price_Break_50"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_100")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_100"].ToString()) != true)
                                                        {
                                                            dtrow7["Price_Break_100"] = Convert.ToDecimal(dr["Price_Break_100"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow7["Price_Break_100"] = 0.00;
                                                        }
                                                    }
                                                }
                                                else if (j == 7 && string.IsNullOrEmpty(dr["V#8"].ToString()) != true && (dc.ColumnName.Contains("Batch") || dc.ColumnName.Contains("V#8") || dc.ColumnName.Contains("Ordered Part") || dc.ColumnName.Contains("Part Description") || dc.ColumnName.Contains("Vendor") || dc.ColumnName.Contains("RFQ Refer") || dc.ColumnName.Contains("Vendor ID") || dc.ColumnName.Contains("Remarks") || dc.ColumnName.Contains("Price_Break_1") || dc.ColumnName.Contains("Price_Break_2") || dc.ColumnName.Contains("Price_Break_3") || dc.ColumnName.Contains("Price_Break_4") || dc.ColumnName.Contains("Price_Break_5") || dc.ColumnName.Contains("Price_Break_10") || dc.ColumnName.Contains("Price_Break_25") || dc.ColumnName.Contains("Price_Break_50") || dc.ColumnName.Contains("Price_Break_100") || dc.ColumnName.Contains("UOM")))
                                                {
                                                    if (dc.ColumnName == "Ordered Part")
                                                    {
                                                        dtrow8["Ordered Part"] = dr["Ordered Part"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "Batch")
                                                    {

                                                        dtrow8["Batch"] = dr["Batch"].ToString();
                                                    }
                                                    //else if (dc.ColumnName == "Part Description")
                                                    //{
                                                    //    dtrow5["Part Description"] = dr["Part Description"].ToString();
                                                    //}
                                                    //else if (dc.ColumnName == "Vendor")
                                                    //{
                                                    //    dtrow5["Vendor"] = dr["Vendor"].ToString();
                                                    //}
                                                    else if (dc.ColumnName == "RFQ Refer")
                                                    {
                                                        dtrow8["RFQ_refer"] = dr["RFQ Refer"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "V#8")
                                                    {
                                                        dtrow8["Vendor_ID"] = dr["V#8"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "Remarks")
                                                    {
                                                        dtrow8["Remarks"] = dr["Remarks"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "UOM")
                                                    {
                                                        dtrow8["UOM"] = dr["UOM"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_1")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_1"].ToString()) != true)
                                                        {
                                                            dtrow8["Price_Break_1"] = Convert.ToDecimal(dr["Price_Break_1"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow8["Price_Break_1"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_2")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_2"].ToString()) != true)
                                                        {
                                                            dtrow8["Price_Break_2"] = Convert.ToDecimal(dr["Price_Break_2"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow8["Price_Break_2"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_3")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_3"].ToString()) != true)
                                                        {
                                                            dtrow8["Price_Break_3"] = Convert.ToDecimal(dr["Price_Break_3"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow8["Price_Break_3"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_4")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_4"].ToString()) != true)
                                                        {
                                                            dtrow8["Price_Break_4"] = Convert.ToDecimal(dr["Price_Break_4"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow8["Price_Break_4"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_5")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_5"].ToString()) != true)
                                                        {
                                                            dtrow8["Price_Break_5"] = Convert.ToDecimal(dr["Price_Break_5"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow8["Price_Break_5"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_10")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_10"].ToString()) != true)
                                                        {
                                                            dtrow8["Price_Break_10"] = Convert.ToDecimal(dr["Price_Break_10"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow8["Price_Break_10"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_25")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_25"].ToString()) != true)
                                                        {
                                                            dtrow8["Price_Break_25"] = Convert.ToDecimal(dr["Price_Break_25"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow8["Price_Break_25"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_50")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_50"].ToString()) != true)
                                                        {
                                                            dtrow8["Price_Break_50"] = Convert.ToDecimal(dr["Price_Break_50"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow8["Price_Break_50"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_100")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_100"].ToString()) != true)
                                                        {
                                                            dtrow8["Price_Break_100"] = Convert.ToDecimal(dr["Price_Break_100"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow8["Price_Break_100"] = 0.00;
                                                        }
                                                    }
                                                }
                                                else if (j == 8 && string.IsNullOrEmpty(dr["V#9"].ToString()) != true && (dc.ColumnName.Contains("Batch") || dc.ColumnName.Contains("V#9") || dc.ColumnName.Contains("Ordered Part") || dc.ColumnName.Contains("Part Description") || dc.ColumnName.Contains("Vendor") || dc.ColumnName.Contains("RFQ Refer") || dc.ColumnName.Contains("Vendor ID") || dc.ColumnName.Contains("Remarks") || dc.ColumnName.Contains("Price_Break_1") || dc.ColumnName.Contains("Price_Break_2") || dc.ColumnName.Contains("Price_Break_3") || dc.ColumnName.Contains("Price_Break_4") || dc.ColumnName.Contains("Price_Break_5") || dc.ColumnName.Contains("Price_Break_10") || dc.ColumnName.Contains("Price_Break_25") || dc.ColumnName.Contains("Price_Break_50") || dc.ColumnName.Contains("Price_Break_100") || dc.ColumnName.Contains("UOM")))
                                                {
                                                    if (dc.ColumnName == "Ordered Part")
                                                    {
                                                        dtrow9["Ordered Part"] = dr["Ordered Part"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "Batch")
                                                    {

                                                        dtrow9["Batch"] = dr["Batch"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "RFQ Refer")
                                                    {
                                                        dtrow9["RFQ_refer"] = dr["RFQ Refer"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "V#9")
                                                    {
                                                        dtrow9["Vendor_ID"] = dr["V#9"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "Remarks")
                                                    {
                                                        dtrow9["Remarks"] = dr["Remarks"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "UOM")
                                                    {
                                                        dtrow9["UOM"] = dr["UOM"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_1")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_1"].ToString()) != true)
                                                        {
                                                            dtrow9["Price_Break_1"] = Convert.ToDecimal(dr["Price_Break_1"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow9["Price_Break_1"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_2")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_2"].ToString()) != true)
                                                        {
                                                            dtrow9["Price_Break_2"] = Convert.ToDecimal(dr["Price_Break_2"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow9["Price_Break_2"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_3")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_3"].ToString()) != true)
                                                        {
                                                            dtrow9["Price_Break_3"] = Convert.ToDecimal(dr["Price_Break_3"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow9["Price_Break_3"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_4")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_4"].ToString()) != true)
                                                        {
                                                            dtrow9["Price_Break_4"] = Convert.ToDecimal(dr["Price_Break_4"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow9["Price_Break_4"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_5")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_5"].ToString()) != true)
                                                        {
                                                            dtrow9["Price_Break_5"] = Convert.ToDecimal(dr["Price_Break_5"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow9["Price_Break_5"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_10")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_10"].ToString()) != true)
                                                        {
                                                            dtrow9["Price_Break_10"] = Convert.ToDecimal(dr["Price_Break_10"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow9["Price_Break_10"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_25")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_25"].ToString()) != true)
                                                        {
                                                            dtrow9["Price_Break_25"] = Convert.ToDecimal(dr["Price_Break_25"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow9["Price_Break_25"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_50")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_50"].ToString()) != true)
                                                        {
                                                            dtrow9["Price_Break_50"] = Convert.ToDecimal(dr["Price_Break_50"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow9["Price_Break_50"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_100")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_100"].ToString()) != true)
                                                        {
                                                            dtrow9["Price_Break_100"] = Convert.ToDecimal(dr["Price_Break_100"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow9["Price_Break_100"] = 0.00;
                                                        }
                                                    }
                                                }
                                                else if (j == 9 && string.IsNullOrEmpty(dr["V#10"].ToString()) != true && (dc.ColumnName.Contains("Batch") || dc.ColumnName.Contains("V#10") || dc.ColumnName.Contains("Ordered Part") || dc.ColumnName.Contains("Part Description") || dc.ColumnName.Contains("Vendor") || dc.ColumnName.Contains("RFQ Refer") || dc.ColumnName.Contains("Vendor ID") || dc.ColumnName.Contains("Remarks") || dc.ColumnName.Contains("Price_Break_1") || dc.ColumnName.Contains("Price_Break_2") || dc.ColumnName.Contains("Price_Break_3") || dc.ColumnName.Contains("Price_Break_4") || dc.ColumnName.Contains("Price_Break_5") || dc.ColumnName.Contains("Price_Break_10") || dc.ColumnName.Contains("Price_Break_25") || dc.ColumnName.Contains("Price_Break_50") || dc.ColumnName.Contains("Price_Break_100") || dc.ColumnName.Contains("UOM")))
                                                {
                                                    if (dc.ColumnName == "Ordered Part")
                                                    {
                                                        dtrow10["Ordered Part"] = dr["Ordered Part"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "Batch")
                                                    {

                                                        dtrow8["Batch"] = dr["Batch"].ToString();
                                                    }
                                                    //else if (dc.ColumnName == "Part Description")
                                                    //{
                                                    //    dtrow5["Part Description"] = dr["Part Description"].ToString();
                                                    //}
                                                    //else if (dc.ColumnName == "Vendor")
                                                    //{
                                                    //    dtrow5["Vendor"] = dr["Vendor"].ToString();
                                                    //}
                                                    else if (dc.ColumnName == "RFQ Refer")
                                                    {
                                                        dtrow10["RFQ_refer"] = dr["RFQ Refer"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "V#10")
                                                    {
                                                        dtrow10["Vendor_ID"] = dr["V#10"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "Remarks")
                                                    {
                                                        dtrow10["Remarks"] = dr["Remarks"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "UOM")
                                                    {
                                                        dtrow10["UOM"] = dr["UOM"].ToString();
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_1")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_1"].ToString()) != true)
                                                        {
                                                            dtrow10["Price_Break_1"] = Convert.ToDecimal(dr["Price_Break_1"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow10["Price_Break_1"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_2")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_2"].ToString()) != true)
                                                        {
                                                            dtrow10["Price_Break_2"] = Convert.ToDecimal(dr["Price_Break_2"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow10["Price_Break_2"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_3")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_3"].ToString()) != true)
                                                        {
                                                            dtrow10["Price_Break_3"] = Convert.ToDecimal(dr["Price_Break_3"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow10["Price_Break_3"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_4")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_4"].ToString()) != true)
                                                        {
                                                            dtrow10["Price_Break_4"] = Convert.ToDecimal(dr["Price_Break_4"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow10["Price_Break_4"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_5")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_5"].ToString()) != true)
                                                        {
                                                            dtrow10["Price_Break_5"] = Convert.ToDecimal(dr["Price_Break_5"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow10["Price_Break_5"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_10")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_10"].ToString()) != true)
                                                        {
                                                            dtrow10["Price_Break_10"] = Convert.ToDecimal(dr["Price_Break_10"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow10["Price_Break_10"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_25")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_25"].ToString()) != true)
                                                        {
                                                            dtrow10["Price_Break_25"] = Convert.ToDecimal(dr["Price_Break_25"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow10["Price_Break_25"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_50")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_50"].ToString()) != true)
                                                        {
                                                            dtrow10["Price_Break_50"] = Convert.ToDecimal(dr["Price_Break_50"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow10["Price_Break_50"] = 0.00;
                                                        }
                                                    }
                                                    else if (dc.ColumnName == "Price_Break_100")
                                                    {
                                                        if (string.IsNullOrEmpty(dr["Price_Break_100"].ToString()) != true)
                                                        {
                                                            dtrow10["Price_Break_100"] = Convert.ToDecimal(dr["Price_Break_100"]);
                                                        }
                                                        else
                                                        {
                                                            dtrow10["Price_Break_100"] = 0.00;
                                                        }
                                                    }
                                                }
                                            }
                                            if (j == 0 && string.IsNullOrEmpty(dtrow1["Vendor_ID"].ToString()) != true)
                                            {
                                                dtLiner_Filter.Rows.Add(dtrow1);
                                                if (LogRFQ == "1")
                                                    log.Info("dtLiner_filter rowsj0 added for each vendorid" + dtrow1["Vendor_ID"].ToString());

                                            }
                                            else if (j == 1 && string.IsNullOrEmpty(dtrow2["Vendor_ID"].ToString()) != true)
                                            {
                                                dtLiner_Filter.Rows.Add(dtrow2);
                                                if (LogRFQ == "1")
                                                    log.Info("dtLiner_filter rowsj1 added for each vendorid" + dtrow2["Vendor_ID"].ToString());

                                            }
                                            else if (j == 2 && string.IsNullOrEmpty(dtrow3["Vendor_ID"].ToString()) != true)
                                            {
                                                dtLiner_Filter.Rows.Add(dtrow3);
                                                if (LogRFQ == "1")
                                                    log.Info("dtLiner_filter rowsj2 added for each vendorid" + dtrow3["Vendor_ID"].ToString());
                                            }
                                            else if (j == 3 && string.IsNullOrEmpty(dtrow4["Vendor_ID"].ToString()) != true)
                                            {
                                                dtLiner_Filter.Rows.Add(dtrow4);
                                                if (LogRFQ == "1")
                                                    log.Info("dtLiner_filter rowsj3 added for each vendorid" + dtrow4["Vendor_ID"].ToString());

                                            }
                                            else if (j == 4 && string.IsNullOrEmpty(dtrow5["Vendor_ID"].ToString()) != true)
                                            {
                                                dtLiner_Filter.Rows.Add(dtrow5);
                                                if (LogRFQ == "1")
                                                    log.Info("dtLiner_filter rowsj4 added for each vendorid" + dtrow5["Vendor_ID"].ToString());

                                            }
                                            else if (j == 5 && string.IsNullOrEmpty(dtrow6["Vendor_ID"].ToString()) != true)
                                            {
                                                dtLiner_Filter.Rows.Add(dtrow6);
                                                if (LogRFQ == "1")
                                                    log.Info("dtLiner_filter rowsj4 added for each vendorid" + dtrow6["Vendor_ID"].ToString());

                                            }
                                            else if (j == 6 && string.IsNullOrEmpty(dtrow7["Vendor_ID"].ToString()) != true)
                                            {
                                                dtLiner_Filter.Rows.Add(dtrow7);
                                                if (LogRFQ == "1")
                                                    log.Info("dtLiner_filter rowsj4 added for each vendorid" + dtrow7["Vendor_ID"].ToString());

                                            }
                                            else if (j == 7 && string.IsNullOrEmpty(dtrow8["Vendor_ID"].ToString()) != true)
                                            {
                                                dtLiner_Filter.Rows.Add(dtrow8);
                                                if (LogRFQ == "1")
                                                    log.Info("dtLiner_filter rowsj4 added for each vendorid" + dtrow8["Vendor_ID"].ToString());

                                            }
                                            else if (j == 8 && string.IsNullOrEmpty(dtrow9["Vendor_ID"].ToString()) != true)
                                            {
                                                dtLiner_Filter.Rows.Add(dtrow9);
                                                if (LogRFQ == "1")
                                                    log.Info("dtLiner_filter rowsj4 added for each vendorid" + dtrow9["Vendor_ID"].ToString());

                                            }
                                            else if (j == 9 && string.IsNullOrEmpty(dtrow10["Vendor_ID"].ToString()) != true)
                                            {
                                                dtLiner_Filter.Rows.Add(dtrow10);
                                                if (LogRFQ == "1")
                                                    log.Info("dtLiner_filter rowsj4 added for each vendorid" + dtrow10["Vendor_ID"].ToString());

                                            }
                                        }
                                        dtLiner_Filter.AcceptChanges();
                                    }


                                    if (LogRFQ == "1")
                                        log.Info("dtLiner_Filter rows added");
                                }
                                DataTable dtTemplate = new DataTable();

                                dtTemplate = dtLiner_Filter.Copy();
                                //dtTemplate.Columns.Add("Batch", typeof(System.String));
                                dtTemplate.Columns.Add("PIC", typeof(System.String));
                                dtTemplate.Columns.Add("Part Description", typeof(System.String));
                                dtTemplate.Columns.Add("Order Quantity", typeof(System.String));
                                dtTemplate.AcceptChanges();

                                if (LogRFQ == "1")
                                {
                                    log.Info("dtLinerfilterFirstrowscount" + dtLiner_Filter.Rows.Count.ToString());
                                    log.Info("dtTemplateFirstrowscount" + dtTemplate.Rows.Count.ToString());
                                }
                                dtLiner_Filter.Columns.Remove("RFQ Deadline");
                                dtLiner_Filter.AcceptChanges();

                                DataSet dsFO_RFQ = new DataSet();
                                if (LogRFQ == "1")
                                {
                                    log.Info("Header rows count saved" + dtHeader.Rows.Count);
                                    log.Info("Liner table rows count saved" + dtLiner_Filter.Rows.Count);
                                }

                                if (LogRFQ == "1")
                                {
                                    log.Info("dtheadercolnamecount" + dtHeader.Columns.Count.ToString());
                                }

                                if (LogRFQ == "1")
                                {
                                    log.Info("dtLiner_Filtercolcount" + dtLiner_Filter.Columns.Count.ToString());
                                }

                                //dsFO_RFQ = objDAL_FO_RFQ.PP_RFQ_Save(dtHeader, dtLiner_Filter);Z

                                //This logic is to update batch,pic,part description in dtTemplate

                                var commonrecords = from rowA in dtHeader.AsEnumerable()
                                                    join rowB in dtTemplate.AsEnumerable()
                                                    on new
                                                    {
                                                        Batch = rowA.Field<string>("Batch"),
                                                        Part = rowA.Field<string>("Ordered Part")
                                                    } equals new
                                                    {
                                                        Batch = rowB.Field<string>("Batch"),
                                                        Part = rowB.Field<string>("Ordered Part")
                                                    }
                                                     into grp
                                                    //  on rowA.Field<string>("Batch") equals rowB.Field<string>("Batch")  into grp
                                                    from B in grp.DefaultIfEmpty()
                                                    select new { A = rowA, B };

                                foreach (var pair in commonrecords)
                                {
                                    if (pair.B != null )
                                    {
                                        pair.B["Batch"] = pair.A["Batch"];
                                        pair.B["PIC"] = pair.A["PIC"];
                                        pair.B["Part Description"] = pair.A["Part Description"];
                                        pair.B["Order Quantity"] = pair.A["Order Quantity"];
                                        pair.B["RFQ Deadline"] = pair.A["RFQ Deadline"];
                                    }
                                    else
                                    {
                                        //  pair.A["Part Description"] = "Null";
                                    }

                                }

                                DataTable FilteredRFQLiner = dtTemplate.Copy();

                                if (LogRFQ == "1")
                                    log.Info("dtTemplate copied to  FilteredRFQLinerrowscount" + FilteredRFQLiner.Rows.Count.ToString());

                                string[] selectedColumns = new[] { "Ordered Part", "UOM", "Country_of_Origin", "Conversion_Qty", "RFQ_Refer", "Vendor_ID", "LeadTime", "Quotation", "Currency", "Price_Break_1", "Price_Break_2", "Price_Break_3", "Price_Break_4", "Price_Break_5", "Price_Break_10", "Price_Break_25", "Price_Break_50", "Price_Break_100", "Remarks", "RFQ Deadline", "Batch", "PIC", "Part Description", "Order Quantity" };
                                FilteredRFQLiner = new DataView(FilteredRFQLiner).ToTable(false, selectedColumns);
                                //if (LogRFQ == "1")
                                //   log.Info( "selectedColumns filtered in  FilteredRFQLinerrowscount" + FilteredRFQLiner.Rows.Count);

                                foreach (DataRow dr in FilteredRFQLiner.Rows)
                                {
                                    DataSet dsRFQStatus = new DataSet();
                                    string strUserName = string.Empty, strSmtpAddress = string.Empty;
                                    Microsoft.Office.Interop.Outlook.Application application = new Microsoft.Office.Interop.Outlook.Application();
                                    Microsoft.Office.Interop.Outlook.Accounts accounts = application.Session.Accounts;
                                    foreach (Microsoft.Office.Interop.Outlook.Account account in accounts)
                                    {
                                        strUserName = account.UserName;
                                        strSmtpAddress = account.SmtpAddress;
                                    }

                                    if (LogRFQ == "1")
                                        log.Info("FilteredRFQLiner.Rows.Count" + FilteredRFQLiner.Rows.Count);
                                    if (FilteredRFQLiner.Rows.Count > 0)
                                    {
                                        if (LogRFQ == "1")
                                        {
                                            log.Info("FilteredRFQLiner.Rows.Count greater 0 and vendor id" + dr["Vendor_ID"].ToString());
                                            log.Info("SAPMATERIALNUMBER" + dr["Ordered Part"].ToString());
                                            log.Info("RFQ refer" + dr["RFQ_refer"].ToString());
                                        }
                                        //for each part number, vendorid is sent to liner table to fetch folderpath
                                        DataSet ds_Vendor_Email = objDAL_FO_RFQ.FO_RFQ_Fetch_Vendor_Email(dr["Vendor_ID"].ToString());
                                         Utils.showLog("mail  sent successfully"+ ds_Vendor_Email.Tables[0].Rows[0]["Email"]);
                                        if (LogRFQ == "1")
                                            log.Info("ds_Vendor_Email count" + ds_Vendor_Email.Tables[0].Rows.Count);

                                        if (ds_Vendor_Email.Tables[0].Rows.Count > 0)
                                        {
                                            if (LogRFQ == "1")
                                                log.Info("ds_Vendor_Email.Tables[0].Rows.Count");

                                            if (string.IsNullOrEmpty(Convert.ToString(ds_Vendor_Email.Tables[0].Rows[0]["Email"])) != true)
                                            {
                                                String[] strlist = { "" };
                                                string str = "";
                                                if ((Convert.ToString(ds_Vendor_Email.Tables[0].Rows[0]["Email"]).Contains(";")))
                                                {
                                                    String[] spearator = { ";" };
                                                    str = Convert.ToString(ds_Vendor_Email.Tables[0].Rows[0]["Email"]);
                                                      Utils.showLog("mail convert  sent successfully"+ ds_Vendor_Email.Tables[0].Rows[0]["Email"]);
                                                    strlist = str.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                                                }
                                                else
                                                {
                                                    
                                                      Utils.showLog("mail convert else  sent successfully"+ ds_Vendor_Email.Tables[0].Rows[0]["Email"]);
                                                    strlist[0] = ds_Vendor_Email.Tables[0].Rows[0]["Email"].ToString();
                                                     Utils.showLog("mail convert else strlist[0]  sent successfully"+   strlist[0] );
                                                }

                                                //Added by Rajan on 1/8/2020 
                                                //store vendor path
                                                if (ds_Vendor_Email.Tables[0].Rows[0]["FolderPath"] != null)
                                                {
                                                    if (!String.IsNullOrEmpty(ds_Vendor_Email.Tables[0].Rows[0]["FolderPath"].ToString()))
                                                    {
                                                        //   vendorPath = ds_Vendor_Email.Tables[0].Rows[0]["FolderPath"].ToString();

                                                        //vendorPath = System.Configuration.ConfigurationManager.AppSettings["SentRFQPath"];
                                                        if (!string.IsNullOrEmpty(strconfigSentRFQPath))
                                                        {
                                                            vendorPath = strconfigSentRFQPath;
                                                            rfqRefer = dr["RFQ_refer"].ToString().Split('-');
                                                            //SentRFQPath = vendorPath + @"\SentRFQ";
                                                            if (LogRFQ == "1")
                                                            {
                                                                log.Info("ds_Vendor_Emai FolderPath  entered");
                                                                log.Info("vendorPath" + vendorPath);
                                                                log.Info("ReceivedQuotationPath" + ReceivedQuotationPath);
                                                            }

                                                            if (!Directory.Exists(vendorPath))
                                                            {
                                                                Directory.CreateDirectory(vendorPath);
                                                                if (!Directory.Exists(rfqRefer[1].ToString()))
                                                                {
                                                                    Directory.CreateDirectory(rfqRefer[1].ToString());
                                                                }
                                                                if (LogRFQ == "1")
                                                                {
                                                                    log.Info("vendorPath  created");
                                                                    log.Info("ReceivedQuotationPath  created");
                                                                }
                                                            }
                                                            else if (Directory.Exists(vendorPath))
                                                            {
                                                                //if (!Directory.Exists(rfqRefer[1].ToString()))
                                                                //{
                                                                //    Directory.CreateDirectory(rfqRefer[1].ToString());
                                                                //}
                                                                vendorcategory = vendorPath + @"\" + rfqRefer[1].ToString();
                                                                //   mailItem.SaveAs(SentRFQPath);
                                                                if (!Directory.Exists(vendorcategory))
                                                                {
                                                                    Directory.CreateDirectory(vendorcategory);
                                                                }
                                                            }
                                                            //Added by Rajan on 9/9/2020 to fix the sentRFQ folder not created if vendorpath already exist
                                                            //if (Directory.Exists(vendorPath))
                                                            //{
                                                            //    if (!Directory.Exists(SentRFQPath))
                                                            //    {
                                                            //        Directory.CreateDirectory(SentRFQPath);
                                                            //        if (LogRFQ == "1")
                                                            //        {
                                                            //           log.Info( "sentrfq not exist, so created ");
                                                            //        }
                                                            //    }
                                                            //}
                                                        }
                                                        else
                                                        {
                                                            if (LogRFQ == "1")
                                                            {
                                                                log.Info("SENTRFQPATH IS EMPTY IN DATABASE");
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //MessageBox.Show("Vendor Folder Path not created for this Vendor " + dr["Vendor ID"].ToString() + " in Database");
                                                        if (LogRFQ == "1")
                                                            log.Info("FolderPath is empty in Tblvendor for this vendor " + dr["Vendor_ID"].ToString());
                                                    }
                                                }

                                                //var PartNumberlist = dtRFQ.AsEnumerable().Select(r => r.Field<string>("PartNumber")).ToArray();
                                                string strSubject = dr["RFQ_refer"].ToString();
                                                if (LogRFQ == "1")
                                                {
                                                    log.Info("strSubject :" + strSubject);
                                                    log.Info("vendor id :" + dr["Vendor_ID"].ToString());
                                                    log.Info("RFQ refer :" + dr["RFQ_refer"].ToString());
                                                }

                                                DataTable dtemailtemplate = FilteredRFQLiner.Copy();

                                                if (LogRFQ == "1")
                                                    log.Info("dtemailtemplate  COUNT" + dtemailtemplate.Rows.Count);

                                                //dtemailtemplate = dtemailtemplate.AsEnumerable()
                                                //.Where(r => r.Field<string>("Vendor_ID") == dr["Vendor_ID"].ToString() && r.Field<string>("RFQ_refer") == dr["RFQ_refer"].ToString())
                                                //.CopyToDataTable();
                                                //  string[] TobeDistinct = { "Vendor_ID", "RFQ_refer" };
                                                string[] TobeDistinct = new[] { "Batch", "PIC", "Ordered Part", "Part Description", "Order Quantity", "UOM", "Country_of_Origin", "Conversion_Qty", "LeadTime", "Quotation", "Currency", "Price_Break_1", "Price_Break_2", "Price_Break_3", "Price_Break_4", "Price_Break_5", "Price_Break_10", "Price_Break_25", "Price_Break_50", "Price_Break_100", "Remarks", "RFQ_Refer", "Vendor_ID", "RFQ Deadline" };
                                                DataTable dtDistinct = GetDistinctRecords(dtemailtemplate, TobeDistinct);

                                                //dtemailtemplate = dtemailtemplate.AsEnumerable().Distinct().Where(r => r.Field<string>("Vendor_ID") == dr["Vendor_ID"].ToString() && r.Field<string>("RFQ_refer") == dr["RFQ_refer"].ToString()).CopyToDataTable();
                                                //filters record based on same RFQ Reference and same vendor ID
                                                //Scenario 1:
                                                //Part-1011,Vendor:OCSSG,RFQRefer:RFQ011020-01
                                                //Part-1012,Vendor:OCSSG,RFQRefer:RFQ011020-01
                                            //Part-1013,Vendor:OCSSG,RFQRefer:RFQ011020-01

                                                dtemailtemplate = (from distinctrecs in dtDistinct.AsEnumerable()
                                                                 .Where(r => r.Field<string>("Vendor_ID") == dr["Vendor_ID"].ToString() && r.Field<string>("RFQ_refer") == dr["RFQ_refer"].ToString())
                                                                   select distinctrecs).Distinct().CopyToDataTable();


                                                if (LogRFQ == "1")
                                                    log.Info("dtMailSent" + dtMailSent.Rows.Count);

                                                if (dtMailSent.Rows.Count == 0)
                                                {
                                                    if (LogRFQ == "1")
                                                        log.Info("dtemailtemplate  created" + dtemailtemplate.Rows.Count);
                                                   
                                                    string strBody = objMailGenerate.GetBodyContent_PP(dtemailtemplate);

                                                    if (LogRFQ == "1")
                                                        log.Info("strBody  created");
                                                    Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
                                                    Microsoft.Office.Interop.Outlook.MailItem mailItem = (Microsoft.Office.Interop.Outlook.MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
                                                    Microsoft.Office.Interop.Outlook.NameSpace oNameSpace = oApp.GetNamespace("MAPI");
                                                    Microsoft.Office.Interop.Outlook.MAPIFolder oFolder = oNameSpace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderSentMail);

                                                    if (LogRFQ == "1")
                                                        log.Info("Outlook folders  created");
                                                    mailItem.Subject = strSubject + "-" + dr["Vendor_ID"].ToString();

                                                    Microsoft.Office.Interop.Outlook.Recipients oRecips = mailItem.Recipients;
                                                    List<string> sTORecipsList = new List<string>();
                                                    List<string> sCCRecipsList = new List<string>();
                                                    sTORecipsList = strlist.ToList();
                                                    Utils.showLog("sTORecipsList list"+  strlist[0] );
                                                    String[] strlist1 = { "" };
                                                    strlist1[0] =   strlist[0] ;
                                                    sTORecipsList = strlist1.ToList();

                                                  Utils.showLog("recipien list"+strlist1[0]);

                                                    if (LogRFQ == "1")
                                                        log.Info("sTORecipsList  created");
                                                    int i = 1;
                                                    foreach (string t in sTORecipsList)
                                                    {
                                                        if (sTORecipsList.Count > 0)
                                                        {
                                                            if (i == 1)
                                                            {
                                                                Microsoft.Office.Interop.Outlook.Recipient oTORecip = oRecips.Add(t);
                                                                oTORecip.Type = (int)Microsoft.Office.Interop.Outlook.OlMailRecipientType.olTo;
                                                                oTORecip.Resolve();
                                                            }
                                                            else
                                                            {
                                                                Microsoft.Office.Interop.Outlook.Recipient oCCRecip = oRecips.Add(t);
                                                                oCCRecip.Type = (int)Microsoft.Office.Interop.Outlook.OlMailRecipientType.olCC;
                                                                oCCRecip.Resolve();
                                                            }
                                                        }
                                                        i++;
                                                    }

                                                    if (mailItem.BodyFormat != OlBodyFormat.olFormatHTML)
                                                    {
                                                        // mailItem.GetInspector.CommandBars.ExecuteMso("MessageFormatHtml");
                                                        if (LogRFQ == "1")
                                                        {
                                                            log.Info("Not Body Format: " + mailItem.BodyFormat);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (LogRFQ == "1")
                                                        {
                                                            log.Info("Actual Body Format: " + mailItem.BodyFormat);
                                                            log.Info("HTMLBody content: " + strBody);
                                                        }

                                                    }

                                                    mailItem.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatHTML;
                                                    mailItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceNormal;
                                                    mailItem.Display(false);
                                                    var signature = mailItem.HTMLBody;
                                                    mailItem.HTMLBody = strBody;
                                                    //mailItem.HTMLBody = "<table border='1px solid blue' style='height:100%;'><thead><tr><th bgcolor = 'white' class='white' style='border:0px'></th><th bgcolor = 'white' class='white' style='border:0px'></th><th bgcolor = 'white' class='white' style='border:0px'></th><th bgcolor = 'white' class='white' style='border:0px'></th><th bgcolor = 'white' class='white' style='border:0px'></th><th bgcolor = 'red' class='white' colspan='15'>Mandatory to fill up</th></tr><tr><th bgcolor='#d0cece' rowspan='2'>Batch</th><th bgcolor='#d0cece' rowspan='2'>PIC</th><th bgcolor='#d0cece' rowspan='2'>Part number</th><th bgcolor='#d0cece' rowspan='2'>Part Description</th><th bgcolor='#d0cece' rowspan='2'>Quantity</th><th bgcolor = '#002060' class='white' rowspan='2'>UOM</th><th bgcolor = '#002060' class='white' rowspan='2'>COO</th><th bgcolor = '#002060' class='white' rowspan='2'>Conversion Qty</th><th bgcolor = '#002060' class='white' rowspan='2'>LeadTime in days</th><th bgcolor = '#002060' class='white' rowspan='2'>Quotation#</th><th bgcolor = '#002060' class='white' rowspan='2'>Currency</th><th bgcolor = '#002060' class='white' colspan='9'>PRICE BREAKS</th><th bgcolor = '#002060' class='white' rowspan='2'>Remarks</th></tr><tr><th bgcolor='#002060' class='white'>1</th><th bgcolor='#002060' class='white'>2</th><th bgcolor='#002060' class='white'>3 </th><th bgcolor='#002060' class='white'>4</th><th bgcolor='#002060' class='white'>5</th><th bgcolor='#002060' class='white'>10</th><th bgcolor='#002060' class='white'>25</th><th bgcolor='#002060' class='white'>50</th><th bgcolor='#002060' class='white'>100</th></tr></thead><tbody><tr><td  style='border:1px solid black;padding-left:4px;padding-right:4px;padding-top:4px;padding-bottom:3px'>1009</td><td  style='border:1px solid black;padding-left:4px;padding-right:4px;padding-top:4px;padding-bottom:3px'>Rosni</td><td  style='border:1px solid black;padding-left:4px;padding-right:4px;padding-top:4px;padding-bottom:3px'>789</td><td  style='border:1px solid black;padding-left:4px;padding-right:4px;padding-top:4px;padding-bottom:3px'>TRQ RING FOR 5.5 HS VLV</td><td  style='border:1px solid black;padding-left:4px;padding-right:4px;padding-top:4px;padding-bottom:3px'>1</td><td  style='border:1px solid black;padding-left:4px;padding-right:4px;padding-top:4px;padding-bottom:3px'></td><td  style='border:1px solid black;padding-left:4px;padding-right:4px;padding-top:4px;padding-bottom:3px'></td><td  style='border:1px solid black;padding-left:4px;padding-right:4px;padding-top:4px;padding-bottom:3px'></td><td  style='border:1px solid black;padding-left:4px;padding-right:4px;padding-top:4px;padding-bottom:3px'></td><td  style='border:1px solid black;padding-left:4px;padding-right:4px;padding-top:4px;padding-bottom:3px'></td><td  style='border:1px solid black;padding-left:4px;padding-right:4px;padding-top:4px;padding-bottom:3px'></td><td  style='border:1px solid black;padding-left:4px;padding-right:4px;padding-top:4px;padding-bottom:3px'>0</td><td  style='border:1px solid black;padding-left:4px;padding-right:4px;padding-top:4px;padding-bottom:3px'>0</td><td  style='border:1px solid black;padding-left:4px;padding-right:4px;padding-top:4px;padding-bottom:3px'>0</td><td  style='border:1px solid black;padding-left:4px;padding-right:4px;padding-top:4px;padding-bottom:3px'>0</td><td  style='border:1px solid black;padding-left:4px;padding-right:4px;padding-top:4px;padding-bottom:3px'>0</td><td  style='border:1px solid black;padding-left:4px;padding-right:4px;padding-top:4px;padding-bottom:3px'>0</td><td  style='border:1px solid black;padding-left:4px;padding-right:4px;padding-top:4px;padding-bottom:3px'>0</td><td  style='border:1px solid black;padding-left:4px;padding-right:4px;padding-top:4px;padding-bottom:3px'>0</td><td  style='border:1px solid black;padding-left:4px;padding-right:4px;padding-top:4px;padding-bottom:3px'>0</td><td  style='border:1px solid black;padding-left:4px;padding-right:4px;padding-top:4px;padding-bottom:3px'></td></tr></tbody></table>";
                                                    //mailItem.HTMLBody = "";

                                                    if (LogRFQ == "1")
                                                    {
                                                        log.Info("HTMLBody  created");
                                                        log.Info("After Body Format: " + mailItem.BodyFormat);
                                                    }

                                                    if (Directory.Exists(vendorPath))
                                                    {
                                                        vendorcategory = vendorPath + @"\" + rfqRefer[1].ToString();
                                                        //   mailItem.SaveAs(SentRFQPath);
                                                        if (!Directory.Exists(vendorcategory))
                                                        {
                                                            Directory.CreateDirectory(vendorcategory);
                                                        }
                                                        //Added by Rajan on 18/9/2020 to change the subject format given by the client
                                                        strSubject = strSubject + "-" + dr["Vendor_ID"].ToString();
                                                        if (LogRFQ == "1")
                                                        {
                                                            log.Info("vendorcategory  created" + vendorcategory);
                                                            log.Info("strSubject" + strSubject);
                                                        }


                                                        mailItem.SaveAs(vendorcategory + @"\" + strSubject + ".msg", Microsoft.Office.Interop.Outlook.OlSaveAsType.olMSG);
                                                        //mailItem.SaveAs(SentRFQPath + @"\" + strSubject + " " + DateTime.Now.ToString().Replace("/", "-").Replace(":", "-") + ".msg", Microsoft.Office.Interop.Outlook.OlSaveAsType.olMSG);

                                                        if (LogRFQ == "1")
                                                            log.Info("mailItem  saved in  SentRFQPath" + vendorcategory + @"\" + strSubject + ".msg");
                                                        //   MessageBox.Show("SAP Material Number : " + dr["SAP Material Number"].ToString());
                                                        //MessageBox.Show("EMAIL : " + ds_Vendor_Email.Tables[0].Rows[0]["Email"]);
                                                    }
                                                    else
                                                    {
                                                        if (LogRFQ == "1")
                                                            log.Info("vendorPath directory not exist in network folder");
                                                    }
                                                    mailItem.SaveSentMessageFolder = oFolder;
                                                    mailItem.Send();
                                                    mailItem = null;
                                                    oApp = null;

                                                    if (LogRFQ == "1")
                                                        log.Info("mail  SEND SUCCESSFULLY");

                                                    DataRow dtmrow = dtMailSent.NewRow();

                                                    dtmrow["Vendor_ID"] = dr["Vendor_ID"];
                                                    dtmrow["RFQ_Refer"] = dr["RFQ_Refer"];
                                                    dtmrow["status"] = "MailSent";
                                                    dtMailSent.Rows.Add(dtmrow);
                                                    dtMailSent.AcceptChanges();
                                                    if (LogRFQ == "1")
                                                        log.Info("dtMailSent TABLE SAVED SUCCESS");
                                                }
                                                else
                                                {
                                                    bool isMailSent = dtMailSent.AsEnumerable().Where(r => r.Field<string>("Vendor_ID") == dr["Vendor_ID"].ToString() && r.Field<string>("RFQ_refer") == dr["RFQ_refer"].ToString()).Count() > 0;

                                                    if (LogRFQ == "1")
                                                    {
                                                        log.Info("isMailSent" + isMailSent);
                                                        log.Info("VENDOR ID" + dr["Vendor_ID"].ToString());
                                                        log.Info("RFQ REFER" + dr["RFQ_refer"].ToString());
                                                    }
                                                    if (!isMailSent)
                                                    {
                                                        if (LogRFQ == "1")
                                                            log.Info("dtemailtemplate  created" + dtemailtemplate.Rows.Count);
                                                    
                                                        string strBody = objMailGenerate.GetBodyContent_PP(dtemailtemplate);

                                                        if (LogRFQ == "1")
                                                            log.Info("strBody  created");
                                                        Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
                                                        Microsoft.Office.Interop.Outlook.MailItem mailItem = (Microsoft.Office.Interop.Outlook.MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
                                                        Microsoft.Office.Interop.Outlook.NameSpace oNameSpace = oApp.GetNamespace("MAPI");
                                                        Microsoft.Office.Interop.Outlook.MAPIFolder oFolder = oNameSpace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderSentMail);

                                                        if (LogRFQ == "1")
                                                            log.Info("Outlook folders  created");

                                                        mailItem.Subject = strSubject + "-" + dr["Vendor_ID"].ToString();

                                                        Microsoft.Office.Interop.Outlook.Recipients oRecips = mailItem.Recipients;
                                                        List<string> sTORecipsList = new List<string>();
                                                        List<string> sCCRecipsList = new List<string>();
                                                        sTORecipsList = strlist.ToList();

                                                        String[] strlist1 = { "" };
                                                         Utils.showLog("recipien SendRFQMails mailItem.Recipients list"+   strlist[0]);
                                                        strlist1[0] =   strlist[0];
                                                        sTORecipsList = strlist1.ToList();

                                                        Utils.showLog("recipien SendRFQMails mailItem.Recipients list"+   strlist[0]);
 

                                                        if (LogRFQ == "1")
                                                            log.Info("sTORecipsList  created");
                                                        int i = 1;
                                                        foreach (string t in sTORecipsList)
                                                        {
                                                            if (sTORecipsList.Count > 0)
                                                            {
                                                                if (i == 1)
                                                                {
                                                                    Microsoft.Office.Interop.Outlook.Recipient oTORecip = oRecips.Add(t);
                                                                    oTORecip.Type = (int)Microsoft.Office.Interop.Outlook.OlMailRecipientType.olTo;
                                                                    oTORecip.Resolve();
                                                                }
                                                                else
                                                                {
                                                                    Microsoft.Office.Interop.Outlook.Recipient oCCRecip = oRecips.Add(t);
                                                                    oCCRecip.Type = (int)Microsoft.Office.Interop.Outlook.OlMailRecipientType.olCC;
                                                                    oCCRecip.Resolve();
                                                                }
                                                            }
                                                            i++;
                                                        }

                                                        if (mailItem.BodyFormat != OlBodyFormat.olFormatHTML)
                                                        {
                                                            // mailItem.GetInspector.CommandBars.ExecuteMso("MessageFormatHtml");
                                                            if (LogRFQ == "1")
                                                            {
                                                                log.Info("Bef Body Format: " + mailItem.BodyFormat);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (LogRFQ == "1")
                                                            {
                                                                log.Info("Actual Body Format: " + mailItem.BodyFormat);
                                                                log.Info("dtmailsent1HTMLBody content: " + strBody);
                                                            }
                                                        }
                                                        mailItem.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatHTML;
                                                        mailItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceNormal;

                                                        mailItem.Display(false);
                                                        var signature = mailItem.HTMLBody;
                                                        mailItem.HTMLBody = strBody;

                                                        if (LogRFQ == "1")
                                                        {
                                                            log.Info("HTMLBody  created");
                                                            log.Info("Aft Body Format: " + mailItem.BodyFormat);
                                                        }

                                                        if (Directory.Exists(vendorPath))
                                                        {
                                                            vendorcategory = vendorPath + @"\" + rfqRefer[1].ToString();
                                                            //   mailItem.SaveAs(SentRFQPath);
                                                            if (!Directory.Exists(vendorcategory))
                                                            {
                                                                Directory.CreateDirectory(vendorcategory);
                                                            }
                                                            //Added by Rajan on 18/9/2020 to change the subject format given by the client
                                                            strSubject = strSubject + "-" + dr["Vendor_ID"].ToString();

                                                            if (LogRFQ == "1")
                                                            {
                                                                log.Info("vendorcategory  created" + vendorcategory);
                                                                log.Info("strSubject " + strSubject);
                                                            }


                                                            mailItem.SaveAs(vendorcategory + @"\" + strSubject + ".msg", Microsoft.Office.Interop.Outlook.OlSaveAsType.olMSG);
                                                            //mailItem.SaveAs(SentRFQPath + @"\" + strSubject + " " + DateTime.Now.ToString().Replace("/", "-").Replace(":", "-") + ".msg", Microsoft.Office.Interop.Outlook.OlSaveAsType.olMSG);

                                                            if (LogRFQ == "1")
                                                                log.Info("mailItem  saved in  SentRFQPath" + vendorcategory + @"\" + strSubject + ".msg");
                                                        }
                                                        else
                                                        {
                                                            if (LogRFQ == "1")
                                                                log.Info("SentRFQPath directory not exist");
                                                        }
                                                        mailItem.SaveSentMessageFolder = oFolder;
                                                        mailItem.Send();
                                                        mailItem = null;
                                                        oApp = null;

                                                        if (LogRFQ == "1")
                                                            log.Info("mail  SEND SUCCESSFULLY");

                                                        DataRow dtmrow = dtMailSent.NewRow();
                                                        dtmrow["Vendor_ID"] = dr["Vendor_ID"];
                                                        dtmrow["RFQ_Refer"] = dr["RFQ_Refer"];
                                                        dtmrow["status"] = "MailSent";
                                                        dtMailSent.Rows.Add(dtmrow);
                                                        dtMailSent.AcceptChanges();
                                                        if (LogRFQ == "1")
                                                            log.Info("dtMailSent  SAVED SUCCESSFULLY");
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Vendor Not Found for OrderedPart : " + dr["Ordered Part"].ToString());
                                            if (LogRFQ == "1")
                                                log.Info("Vendor Not Found for OrderedPart" + dr["Ordered Part"].ToString());
                                        }
                                    }
                                }//FilteredRFQLiner for loop
                                 //Added by Rajan on 28/9/2020 to save data in header and liner table after RFQ mail sent

                                dtLiner_Filter.Columns.Remove("Batch");
                                // dtLiner_Filter.Rows[0].Delete();
                                dtLiner_Filter.AcceptChanges();

                                DataTable dtLiner_Filter_ = new DataTable();
                                dtLiner_Filter_ = dtLiner_Filter.Copy();
                                dtLiner_Filter_.Clear();
                                if (dtLiner_Filter.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dtLiner_Filter.Rows.Count; i++)
                                    {
                                        try
                                        {
                                            var PB1 = dtLiner_Filter.Rows[i]["Price_Break_1"];
                                            var PB2 = dtLiner_Filter.Rows[i]["Price_Break_2"];
                                            var PB3 = dtLiner_Filter.Rows[i]["Price_Break_3"];
                                            var PB4 = dtLiner_Filter.Rows[i]["Price_Break_4"];
                                            var PB5 = dtLiner_Filter.Rows[i]["Price_Break_5"];
                                            var PB10 = dtLiner_Filter.Rows[i]["Price_Break_10"];
                                            var PB25 = dtLiner_Filter.Rows[i]["Price_Break_25"];
                                            var PB50 = dtLiner_Filter.Rows[i]["Price_Break_50"];
                                            var PB100 = dtLiner_Filter.Rows[i]["Price_Break_100"];

                                            SqlCommand cmd = new SqlCommand("SP_UPD_PP_RFQ_LINER", con);
                                            cmd.CommandType = CommandType.StoredProcedure;
                                            cmd.Parameters.AddWithValue("@ID", 0);
                                            cmd.Parameters.AddWithValue("@OrderedPart", dtLiner_Filter.Rows[i]["Ordered Part"].ToString() );
                                            cmd.Parameters.AddWithValue("@Vendor_ID", dtLiner_Filter.Rows[i]["Vendor_ID"].ToString());
                                            cmd.Parameters.AddWithValue("@QUOTE", dtLiner_Filter.Rows[i]["Quotation"].ToString());
                                            cmd.Parameters.AddWithValue("@PB1", (PB1.ToString() == "0") ? null : PB1.ToString() );
                                            cmd.Parameters.AddWithValue("@PB2", (PB2.ToString() == "0") ? null : PB2.ToString());
                                            cmd.Parameters.AddWithValue("@PB3", (PB3.ToString() == "0") ? null : PB3.ToString());
                                            cmd.Parameters.AddWithValue("@PB4", (PB4.ToString() == "0") ? null : PB4.ToString());
                                            cmd.Parameters.AddWithValue("@PB5", (PB5.ToString() == "0") ? null : PB5.ToString());
                                            cmd.Parameters.AddWithValue("@PB10", (PB10.ToString() == "0") ? null : PB10.ToString());
                                            cmd.Parameters.AddWithValue("@PB25", (PB25.ToString() == "0") ? null : PB25.ToString());
                                            cmd.Parameters.AddWithValue("@PB50", (PB50.ToString() == "0") ? null : PB50.ToString());
                                            cmd.Parameters.AddWithValue("@PB100", (PB100.ToString() == "0") ? null : PB100.ToString());
                                            // cmd.Parameters.AddWithValue("@pricebreakstatus", dtRFQReceived.Rows[r]["pricebreakstatus"].ToString());
                                            cmd.Parameters.AddWithValue("@REM", dtLiner_Filter.Rows[i]["Remarks"].ToString().Replace("&nbsp;","").Trim().ToString() );
                                            cmd.Parameters.AddWithValue("@LTIME", dtLiner_Filter.Rows[i]["LeadTime"].ToString());
                                            cmd.Parameters.AddWithValue("@UOM", dtLiner_Filter.Rows[i]["UOM"].ToString());
                                            cmd.Parameters.AddWithValue("@CQTY", dtLiner_Filter.Rows[i]["Conversion_Qty"].ToString());
                                            cmd.Parameters.AddWithValue("@CO", dtLiner_Filter.Rows[i]["Country_Of_Origin"].ToString());
                                            cmd.Parameters.AddWithValue("@CURRENCY", dtLiner_Filter.Rows[i]["Currency"].ToString());
                                            cmd.Parameters.AddWithValue("@MDATE", DateTime.Now);
                                            cmd.Parameters.AddWithValue("@RFQ_Refer", dtLiner_Filter.Rows[i]["RFQ_refer"].ToString());

                                            cmd.ExecuteNonQuery();

                                        }
                                        catch (System.Exception ex)
                                        {
                                            throw ex;
                                        }

                                    }
                                }

                                        dsFO_RFQ = objDAL_FO_RFQ.PP_RFQ_Save(dtHeader, dtLiner_Filter_);
                            }
                           /* else
                            {
                                MessageBox.Show("No Record Selected");
                            }*/
                        }
                        else
                        {
                            MessageBox.Show("There is no RFQ Quote available.");
                        }
                    }


                }
                if (sw != null)
                {
                    sw.Close();
                    if (LogRFQ == "1")
                        log.Info("streamwriter closed in try block");
                }
            }
            catch (System.Exception ex)
            {
                if (sw != null)
                {
                    sw.Close();

                    if (LogRFQ == "1")
                        log.Info("streamwriter closed in catch block");
                }
                string Errormsg = ex.GetType().Name.ToString();
                handler.Register(ex);
               // MessageBox.Show(ex.ToString());
               
            }
        }
    
}
}
