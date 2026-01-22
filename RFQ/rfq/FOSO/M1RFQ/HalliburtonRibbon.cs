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
//using Microsoft.Office.Interop.Outlook;

namespace HalliburtonRFQ
{
    public partial class HalliburtonFOSORibbon
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
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        #region  Not in Use
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

        private void rbtnReview_Click_1(object sender, RibbonControlEventArgs e)
        {

        }

        #endregion


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

                DataTable configValuesdt = objDAL_FO_RFQ.getConfig();


                configValues = configValuesdt.AsEnumerable()
                        .ToDictionary<DataRow, string, string>(row => row[0].ToString(),
                                        row => row[1].ToString());

                string excelPath = configValues["FOSO_ExcelPath"];
                string excelSheet = configValues["FOSO_ExcelSheet"];
                string sentRFQPath = configValues["FOSOSentRFQ"];

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

                    var dt1Rows = dtsource.AsEnumerable();
                    var dt2Rows = dtSQL.AsEnumerable();
                    string[] compareColumns = { "SAP Material Number", "RFQ refer" };

                    var differences = dt1Rows
                        .Where(r1 => !dt2Rows.Any(r2 =>
                            compareColumns.All(col => r1[col].Equals(r2[col]))
                        ));

                    var filter = from firstDt in dtsource.AsEnumerable()
                                 where (from secondDt in dtSQL.AsEnumerable() select secondDt["SAP Material Number"]).Contains(firstDt["SAP Material Number"].ToString())
                                 select firstDt;
                    if (LogRFQ == "1")
                    {
                        LogOptions.Log(logpath, LogCategory.OutlookRibbon, "Excel records should not contain liner details records" + filter);
                    }
                    if (differences.Count() == 0)
                    {
                        MessageBox.Show("No RFQ available");
                    }
                    else
                    {
                        dtFilter_Final = differences.CopyToDataTable();
                        //dtFilter_Final = filter.CopyToDataTable();

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
                           /* else
                            {
                                MessageBox.Show("No Record Selected");
                            }*/
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
                

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }
       }
       
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
                            if(dr["RFQ refer"].ToString().Contains("FO"))
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
                sTORecipsList = strlist.ToList();

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
                             
                            string repMailSubject = "RFQ";

                            if (sw is null)
                            {
                                
                                sw.WriteLine("sw null ");
                            }
                            sw.WriteLine(scount + " Subject " + Subject);
                            sw.WriteLine("Reply Mail Subject " + repMailSubject);
                            sw.WriteLine();
                            decimal priceScale1;
                            decimal priceScale2;
                            decimal priceScale3;
                            DataTable dt = new DataTable();
                            if (!string.IsNullOrEmpty(Subject) && !string.IsNullOrWhiteSpace(Subject))
                            {
                                if (Subject.Contains(repMailSubject.ToLower()) && (Subject.Contains("-SO-".ToLower()) || Subject.Contains("-FO-".ToLower())))
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

                                        if (doc.DocumentNode.SelectSingleNode("//table[contains(@id, 'FOSO_Table')]") != null)
                                        {

                                            sw.WriteLine("Table has value");
                                        }
                                        else
                                        {
                                            sw.WriteLine("Table is null");
                                        }
                                        string titleDOC = (string)moveMail.ToString();
                                        var nodes = doc.DocumentNode.SelectNodes("//table[contains(@id, 'FOSO_Table')]");
                                        if (nodes != null)
                                        {
                                            //Loop in through the table to fetch the header column names
                                            foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table[contains(@id, 'FOSO_Table')]//thead"))
                                            {
                                                foreach (HtmlNode row in table.SelectNodes("tr[contains(@id, 'tr')]"))
                                                {
                                                    foreach (HtmlNode td in row.SelectNodes("td//span[contains(@class,'thead')]"))
                                                    {
                                                        sw.WriteLine("Data - " + td.InnerText);
                                                        receivedMaildt.Columns.Add(td.InnerText.Trim().Replace("\r\n", "").Replace("  ", "").Replace("   ", "").Replace("&gt;", ">").Replace("&nbsp;", " ").Trim());

                                                    }
                                                }
                                            }

                                            //Loop in through the table to fetch the data updated by the vendors
                                            foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table[contains(@id,'FOSO_Table')]"))
                                            {

                                                foreach (HtmlNode row in table.SelectNodes("tr"))
                                                {
                                                    int i = 0;
                                                    receivedMaildt.Rows.Add();
                                                    foreach (HtmlNode td in row.SelectNodes("td[contains(@id,'tdTbodys')]"))
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
                                            dtLinerDetails.Rows[dtLinerDetails.Rows.Count - 1]["Price_Scale(1-3)"] = (priceScale1.ToString() == "0") ? null : priceScale1.ToString();
                                            dtLinerDetails.Rows[dtLinerDetails.Rows.Count - 1]["Price_Scale(4-9)"] = (priceScale2.ToString() == "0") ? null : priceScale2.ToString();
                                            dtLinerDetails.Rows[dtLinerDetails.Rows.Count - 1]["Price_Scale(>=10)"] = (priceScale3.ToString() == "0") ? null : priceScale3.ToString();
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
                                        if (RFQRefNum != "")
                                        {
                                            lstMailItem.Add(moveMail);
                                            rcount++;
                                            RFQRefNum = string.Empty;
                                        }

                                    }
                                    else
                                    {
                                        sw.WriteLine("datable is empty-no records from sample html");
                                    }
                                   // lstMailItem.Add(moveMail);
                                   // rcount++;
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
    }
}
