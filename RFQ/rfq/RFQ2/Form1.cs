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
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using Microsoft.Office.Interop.Excel;

namespace RFQ2
{
    public partial class Desktop : Form
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Desktop()
        {
            InitializeComponent();
            lblHid.Text = Environment.UserName;
            MYGlobal.getCString();
            lblDB.Text = "DB: "+MYGlobal.USE_DB;
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
                this.Enabled = false;
                frm.FormClosed += (s, args) => this.Enabled = true;
                frm.VisibleChanged += (s, args) => this.Visible = true;
            }
            else
            {
                //MessageBox.Show("FO RFQ already Opened");
                this.Enabled = false;
                frm.FormClosed += (s, args) => this.Enabled = true;
                frm.VisibleChanged += (s, args) => this.Visible = true;
                frm.Show();
               
            }
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


        private void pbFORFQ_Click(object sender, EventArgs e)
        {
           
        }

        public bool CheckCustomFolderExisits()
        {
            Microsoft.Office.Interop.Outlook._Application outlookObj = new Microsoft.Office.Interop.Outlook.Application();

            
            string folderPath = outlookObj.Session.DefaultStore.GetRootFolder().FolderPath  + @"\AIA";

            log.Info("folderPath = " + folderPath);

            Microsoft.Office.Interop.Outlook.MAPIFolder fldContacts = (Microsoft.Office.Interop.Outlook.MAPIFolder)outlookObj.Session.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olPublicFoldersAllPublicFolders);
            //VERIFYING THE CUSTOM SUB FOLDER IN CONTACTS FOLDER IN OUT LOOK.  
            foreach (Microsoft.Office.Interop.Outlook.MAPIFolder subFolder in fldContacts.Folders)
            {
                log.Info("subFolder = " + subFolder.Name);

                if (subFolder.Name == "AIA")
                {
                    MessageBox.Show("Got the folder BUS ");
                    return true;
                }
                else
                {
                   // return false;
                }
                    
            }
            return false;
        }


        private void moveEmail( )
        {
                          
           ConfigDao dao= DBUtils.getConfigDao(10, null);
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
               for (int x=0;x<=items.Count;x++)
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
                            log.Info("to be saved " + file );
                            if (!File.Exists(file))
                            {
                                mail.SaveAs(file, OlSaveAsType.olMSG);
                                log.Info("Mail saved " + file );
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

               String result =  "Total [ "+ rfq_count + " ] Mails saved to " + dao.ConfigVal + " \r\n Total FO Emails=" + fo_count + ", \r\n Total SO Emails=" + so_count 
                    + ", \r\n Total PP EMails=" + pp_count + ", \r\n Total TK Emails=" + tk_count + ", \r\n Total Emails in Sent folder =" + count + ", \r\n Total Exists=" + exists_count;

                appendHistory(result);
                appendHistory("-----------------");
            }
            catch(System.Exception ee)
            {
                log.Error("Error " + ee.Message);
                appendHistory("Error "+ ee.Message);
            }
        }

        private String getToday()
        {
           return DateTime.Now.ToString("yyyyMMdd");
        }


        private void btnMoveEmail_Click(object sender, EventArgs e)
        {
           
        }

        private void pbPPRFQ_Click(object sender, EventArgs e)
        {
           
            
        }

        private void pbMoveEmail_Click(object sender, EventArgs e)
        {
          
        }

        private void pbTkppMoveEmail_Click(object sender, EventArgs e)
        {
            moveEmail( );
        }

        private void Desktop_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure to Close, If you close the app the Auto move email wont work ?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (res == DialogResult.Yes)
            {
                this.Dispose();
                Environment.Exit(0);
            }
            else
            {
                //this.Hide();
                //this.Parent = null;
                e.Cancel = true;
                return;
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void setDateTime()
        {
            lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            setDateTime();
        }

        private void btnUpdateFoso_Click(object sender, EventArgs e)
        {
            loadFORFQ();
        }

        private void btnUpdateTkpp_Click(object sender, EventArgs e)
        {
            loadPPRFQ();
        }

        private void btnMoveEmail_Click_1(object sender, EventArgs e)
        {
            btnMoveEmail.Enabled = false;
            moveEmail( );
            btnMoveEmail.Enabled = true;
        }

        private String getNow()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void appendHistory(String msg)
        {
            txtMoveEmailHistory.AppendText("\r\n"+msg );
        }
        bool astarted = false;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (!astarted)
            {
                astarted = true;
                string msg = " Auto move email started";
                log.Info(getNow() + msg);
                appendHistory(getNow()+ msg);
            }
            else
            {
                string msg = " Wakeup!  Moving email now";
                log.Info(getNow() + msg);
                appendHistory(getNow() + msg);
                
                //move email
                btnMoveEmail.Enabled = false;
               // moveEmail();
                btnMoveEmail.Enabled = true;

            }
      }

        private void timer3_Tick(object sender, EventArgs e)
        {

            if (!astarted)
            {
                astarted = true;
                string msg = " Auto move email started";
                log.Info(getNow() + msg);
                appendHistory(getNow() + msg);

                btnMoveEmail.Enabled = false;
                //moveEmail();
                btnMoveEmail.Enabled = true;
            }
            timer2.Enabled = true;
            timer3.Enabled = false;
        }

       // bool isReadRFQFolder = false;
        string Subject;
       // int hdrrcount = 0;
       // int rcount = 0;
       // int scount = 1;

  

    public bool IsOutlookRunning()
    {
        try
        {
                Outlook.Application outlookApp = null;
            try
            {
                // Try to get the running Outlook application
                outlookApp = (Outlook.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Outlook.Application");
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                // Outlook is not running
                return false;
            }

            // Outlook is running
            return true;
        }
        catch (System.Exception ex)
        {
                // Handle exceptions if necessary
                log.Info("----------------- Error Start -------------------");
                log.Info(string.Concat(ex.StackTrace, ex.Message));
                if (ex.InnerException != null)
                {
                    log.Info("Inner Exception");
                    log.Info(string.Concat(ex.InnerException.StackTrace, ex.InnerException.Message));
                }
                log.Info("----------------- Error End -------------------");
                return false;
        }
    }

    private void doReadEmail()
    {
        appendHistory(getNow() + " Reading your outlook mail started..");
        Outlook.MAPIFolder inBox = null;
        Outlook.Items items = null;
        Outlook.MAPIFolder readRFQFolder = null;
        Outlook.Application outlookApp = null;
        Outlook.NameSpace outlookNamespace = null;
        List <Outlook.MailItem> lstMailItem = new List<Outlook.MailItem>();
        try
        {
            // Attempt to create an instance of Outlook
             outlookApp = new Outlook.Application();
            // Access the inbox
             outlookNamespace = outlookApp.GetNamespace("MAPI");
            var isRunning = IsOutlookRunning();
            if (isRunning)
            {
                inBox = (Outlook.MAPIFolder)outlookApp.ActiveExplorer().Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
                appendHistory(getNow() + " Reading your active outlook mail inbox");
            }
            else
            {
                inBox = outlookNamespace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
                appendHistory(getNow() + " Reading your offline outlook mail inbox");
            }
            items = (Outlook.Items)inBox.Items;
            Outlook.MAPIFolder rootFolder = (Outlook.MAPIFolder)inBox.Parent;
            readRFQFolder = rootFolder.Folders["Read_RFQ"];
            items.Restrict("[UnRead] = true");
        }
        catch (System.Runtime.InteropServices.COMException)
        {
           log.Info("Error: Microsoft Outlook is not installed on this system.");
                MessageBox.Show("Microsoft Outlook is not installed on this system.");

        }

        try
        {
            
            if (items != null)
            {
                int cnt = 0, rfq_count = 0;
                int fo_success_count = 0, so_success_count = 0, tk_success_count = 0, pp_success_count = 0;
                int fo_failed_count = 0, so_failed_count = 0, tk_failed_count = 0, pp_failed_count = 0;

                //this.isReadRFQFolder = true;
                List<string> errorList = new List<string>();
                string repMailSubject = "RFQ";
                foreach (object eMail in items)
                {
                    Outlook.MailItem moveMail = null;
                    moveMail = eMail as Outlook.MailItem;
                    bool moved = false;
                    if (moveMail != null)
                    {
                        cnt++;
                        string titleSubject = (string)moveMail.Subject;                       
                        if (string.IsNullOrEmpty(titleSubject) || titleSubject.Length < 1)
                        {
                            Subject = "";
                        }
                        else
                        {
                            Subject = titleSubject.ToLower().Trim();
                        }
                        
                        System.Data.DataTable dt = new System.Data.DataTable();

                        if (!string.IsNullOrEmpty(Subject) && !string.IsNullOrWhiteSpace(Subject))
                        {
                            if (Subject.Contains(repMailSubject.ToLower()) && (Subject.Contains("-TK-".ToLower()) || Subject.Contains("-PP-".ToLower()) || Subject.Contains("-SO-".ToLower()) || Subject.Contains("-FO-".ToLower())))
                            {
                                rfq_count++;
                                string vendorCode = titleSubject.Substring(titleSubject.LastIndexOf('-') + 1);
                                //((Microsoft.Office.Interop.Outlook.MailItem)moveMail).SaveAs(@"C:\Users\Public\Documents\Sample.html", Microsoft.Office.Interop.Outlook.OlSaveAsType.olHTML);
                                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                                String html_body = moveMail.HTMLBody;
                                doc.LoadHtml(html_body);

                                var isTABLEExist = doc.DocumentNode.Descendants("table").Any();
                                if (isTABLEExist)
                                {
                                    try
                                    {
                                        if (doc.DocumentNode.SelectSingleNode("//table[contains(@id,'TK_Table')]") != null)
                                        {
                                            log.Info("Got TK_Table");
                                            dt = doTKParse(dt, doc);
                                            moved = parseTKPPEmail(dt, titleSubject, vendorCode, moveMail, readRFQFolder);
                                            dt.Clear();
                                            if (Subject.Contains("-PP-".ToLower()) )
                                            {
                                                if(moved) pp_success_count++;
                                                if(!moved) pp_failed_count++;
                                            }

                                            if (Subject.Contains("-TK-".ToLower()) )
                                            {
                                                if (moved) tk_success_count++;
                                                if (!moved) tk_failed_count++;
                                            }
                                            if (moved) lstMailItem.Add(moveMail);
                                        }

                                        if (doc.DocumentNode.SelectSingleNode("//table[contains(@id,'FOSO_Table')]") != null)
                                        {
                                            log.Info("GOT FOSO_Table ");
                                            dt = doFOSOParse(dt, doc);
                                            moved = parseFOSOEmail(dt, titleSubject, vendorCode, moveMail, readRFQFolder);
                                            dt.Clear();
                                            if (Subject.Contains("-FO-".ToLower()) )
                                            {
                                                if (moved) fo_success_count++;
                                                if (!moved) fo_failed_count++;
                                            }
                                            if (Subject.Contains("-SO-".ToLower()) )
                                            {
                                                if (moved) so_success_count++;
                                                if (!moved) so_failed_count++;
                                            }
                                            if (moved) lstMailItem.Add(moveMail);
                                        }
                                    }
                                    catch (System.Exception ex)
                                    {
                                        dt.Clear();
                                        if (Subject.Contains("-FO-".ToLower()))
                                            fo_failed_count++;
                                        if (Subject.Contains("-SO-".ToLower()))
                                            so_failed_count++;
                                        if (Subject.Contains("-PP-".ToLower()))
                                            pp_failed_count++;
                                        if (Subject.Contains("-TK-".ToLower()))
                                            tk_failed_count++;

                                        log.Info("----------------- Error Start -------------------");
                                        log.Info(string.Concat(ex.StackTrace, ex.Message));
                                        if (ex.InnerException != null)
                                        {
                                            log.Info("Inner Exception");
                                            log.Info(string.Concat(ex.InnerException.StackTrace, ex.InnerException.Message));
                                        }
                                        log.Info("----------------- Error End -------------------");
                                        appendHistory(getNow() + " Error with subject: (" + titleSubject+" ) Reason: "+ ex.Message);
                                    }
                                    // doTKParse(dt, doc);


                                }//table exists

                            }
                        }
                    }
                }
                List<string> resultList = new List<string>();
                if (rfq_count > 0)
                {
                    resultList.Add("The total number of mails Read from Inbox is [ " + cnt + " ], Found [ " + rfq_count + " ] RFQ Mails.");
                    resultList.Add("----------- Moving Mails Started-----------");
                    resultList.Add("Total moved FO mails " + fo_success_count + " and failed " + fo_failed_count);
                    resultList.Add("Total moved SO mails " + so_success_count + " and failed " + so_failed_count);
                    resultList.Add("Total moved TK mails " + tk_success_count + " and failed " + tk_failed_count);
                    resultList.Add("Total moved PP mails " + pp_success_count + " and failed " + pp_failed_count);
                    resultList.Add("-----------Read RFQ Emails End-----------");
                    string result = string.Join(Environment.NewLine+" ", resultList);
                    appendHistory(result);
                }
                else
                {
                    appendHistory(getNow() + " --------No RFQ mails in your InBox--------- ");
                }

            }
            else
            { 
                appendHistory(getNow() + " --------No RFQ mails in your InBox--------- ");
            }
        }
        finally
        {
            if (lstMailItem.Count > 0)
            {
                foreach(MailItem mailItem in lstMailItem)
                {
                    mailItem.Move(readRFQFolder);
                }
            }
            // Release the COM object
            if (items != null)
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(items);
                items = null;
            }
        }
        // Release COM objects
        System.Runtime.InteropServices.Marshal.ReleaseComObject(inBox);
        System.Runtime.InteropServices.Marshal.ReleaseComObject(outlookNamespace);
        System.Runtime.InteropServices.Marshal.ReleaseComObject(outlookApp);
    }


        private System.Data.DataTable doFOSOParse(System.Data.DataTable dt, HtmlAgilityPack.HtmlDocument doc)
        {

            var nodes = doc.DocumentNode.SelectNodes("//table[contains(@id, 'FOSO_Table')]");
            if (nodes != null)
            {
                var thead = doc.DocumentNode.SelectNodes("//table[contains(@id, 'FOSO_Table')]//thead");
                if (thead != null) {
                    //Loop in through the table to fetch the header column names
                    foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table[contains(@id, 'FOSO_Table')]//thead"))
                    {
                        foreach (HtmlNode row in table.SelectNodes("tr[contains(@id, 'tr')]"))
                        {
                            var headerrow = row.SelectNodes("td//span[contains(@class,'thead')]");
                            if (headerrow != null)
                            {
                                foreach (HtmlNode td in row.SelectNodes("td//span[contains(@class,'thead')]"))
                                {
                                    log.Info("Data - " + td.InnerText);
                                    dt.Columns.Add(td.InnerText.Trim().Replace("\r\n", "").Replace("  ", "").Replace("   ", "").Replace("&gt;", ">").Replace("&nbsp;", " ").Trim());

                                }
                            }
                            else
                            {
                                foreach (HtmlNode td in row.SelectNodes("td"))
                                {
                                    log.Info("Data - " + td.InnerText);
                                    dt.Columns.Add(td.InnerText.Trim().Replace("\r\n", "").Replace("  ", "").Replace("   ", "").Replace("&gt;", ">").Replace("&nbsp;", " ").Trim());

                                }
                            }
                        }
                    }
                    //Loop in through the table to fetch the data updated by the vendors
                    foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table[contains(@id,'FOSO_Table')]//tbody"))
                    {

                        foreach (HtmlNode row in table.SelectNodes("tr"))
                        {
                            int i = 0;
                            dt.Rows.Add();
                            foreach (HtmlNode td in row.SelectNodes("td[contains(@id,'tdTbodys')]"))
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

                }
                else
                {
                    foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table[contains(@id, 'FOSO_Table')]//tbody"))
                    {
                        var row = doc.DocumentNode.SelectSingleNode("//table[contains(@id, 'FOSO_Table')]//tbody/tr[2]");
                        if(row !=null)
                        {
                            foreach (HtmlNode td in row.SelectNodes("td"))
                            {
                                log.Info("Data - " + td.InnerText);
                                dt.Columns.Add(td.InnerText.Trim().Replace("\r\n", "").Replace("  ", "").Replace("   ", "").Replace("&gt;", ">").Replace("&nbsp;", " ").Trim());

                            }
                        }

                        foreach (HtmlNode rowData in table.SelectNodes("tr").Skip(2))
                        {
                            int i = 0;
                            dt.Rows.Add();
                            foreach (HtmlNode td in rowData.SelectNodes("td"))
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
                }

               
                dt.AcceptChanges();
            }
            /*
            var nodes = doc.DocumentNode.SelectNodes("//table[contains(@id,'FOSO_Table')]");
            if (nodes != null)
            {
                //Loop in through the table to fetch the header column names
                foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table[contains(@id,'FOSO_Table')]//thead"))
                {
                    foreach (HtmlNode row in table.SelectNodes("tr[contains(@id,'tr')]"))
                    {
                        foreach (HtmlNode td in row.SelectNodes("td//span[contains(@class,'thead')]"))
                        {
                            log.Info("Data - " + td.InnerText);
                            dt.Columns.Add(td.InnerText.Trim().Replace("\r\n", "").Replace("  ", "").Replace("   ", "").Replace("&gt;", ">").Replace("&nbsp;", " ").Trim());

                        }
                    }
                }


                //Loop in through the table to fetch the data updated by the vendors
                foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table[contains(@id,'FOSO_Table')]"))
                {

                    foreach (HtmlNode row in table.SelectNodes("tr"))
                    {
                        int i = 0;
                        dt.Rows.Add();
                        foreach (HtmlNode td in row.SelectNodes("td[contains(@id,'tdTbodys')]"))
                        {
                            log.Info("Data - " + td.InnerText);
                            if (dt.Columns.Count > 0)
                            {
                                dt.Rows[dt.Rows.Count - 1][i] = td.InnerText.Trim().Replace("\r\n", "").Replace("&nbsp;", " ").Trim();
                                i++;
                            }

                        }
                    }
                }
                dt.AcceptChanges();

            }//if
            */
            return dt;
        }

        private String getCurrentTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private System.Data.DataTable doTKParse(System.Data.DataTable dt, HtmlAgilityPack.HtmlDocument doc)
        {
            var nodes = doc.DocumentNode.SelectNodes("//table[contains(@id,'TK_Table')]");
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
                                log.Info("Data - " + td.InnerText);
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
                            log.Info(getCurrentTime() + "  - " + ee.Message);
                            continue;
                        }
                    }
                }
                /*
                foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table[contains(@id,'TK_Table')]//thead"))
                {
                    foreach (HtmlNode row in table.SelectNodes("tr"))
                    {
                        foreach (HtmlNode td in row.SelectNodes("td//span[contains(@class,'thead')]"))
                        {
                            log.Info("Data-1 = " + td.InnerText);
                            dt.Columns.Add(td.InnerText.Trim().Replace("\r\n", "").Replace("  ", "").Replace("   ", "").Replace("&gt;", ">").Replace("&nbsp;", " ").Trim());

                        }
                    }
                }//foreach
                */
                var data = doc.DocumentNode.SelectNodes("//table[contains(@id, 'TK_Table')]//tbody");
                if (data != null)
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
                                foreach (HtmlNode td in row.SelectNodes("td"))
                                {
                                    log.Info(getCurrentTime() + "Data - " + td.InnerText);
                                    if (dt.Columns.Count > 0)
                                    {
                                        dt.Rows[dt.Rows.Count - 1][i] = td.InnerText.Trim().Replace("\r\n", "").Replace("&nbsp;", " ").Trim();
                                        i++;
                                    }
                                }
                            }
                            catch (System.Exception ee)
                            {
                                log.Info(getCurrentTime() + "  - " + ee.Message);
                                continue;
                            }
                        }
                    }
                }
                else
                {
                    foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table[contains(@id, 'TK_Table')]"))
                    // foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table[@id='TK_Table']"))
                    {
                        foreach (HtmlNode row in table.SelectNodes("tr"))
                        {
                            try
                            {
                                int i = 0;
                                dt.Rows.Add();
                                foreach (HtmlNode td in row.SelectNodes("td"))
                                {
                                    log.Info(getCurrentTime() + "Data - " + td.InnerText);
                                    if (dt.Columns.Count > 0)
                                    {
                                        dt.Rows[dt.Rows.Count - 1][i] = td.InnerText.Trim().Replace("\r\n", "").Replace("&nbsp;", " ").Trim();
                                        i++;
                                    }
                                }
                            }
                            catch (System.Exception ee)
                            {
                                log.Info(getCurrentTime() + "  - " + ee.Message);
                                continue;
                            }
                        }
                    }
                }
                /*
                foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table[contains(@id,'TK_Table')]//tbody"))
                {
                    if (table.SelectNodes("tr") != null)
                    {
                        foreach (HtmlNode row in table.SelectNodes("tr"))
                        {
                            if (row != null)
                            {
                                int i = 0;
                                dt.Rows.Add();
                                foreach (HtmlNode td in row.SelectNodes("td[contains(@id,'tdTbodys')]"))
                                {
                                    log.Info("Data-2 =  " + td.InnerText);
                                    if (dt.Columns.Count > 0)
                                    {
                                        dt.Rows[dt.Rows.Count - 1][i] = td.InnerText.Trim().Replace("\r\n", "").Replace("&nbsp;", " ").Trim();
                                        i++;
                                    }

                                }
                            }

                        }
                    }

                }
                */

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

        private bool parseFOSOEmail(System.Data.DataTable receivedMaildt, string titleSubject, string vendorCode, Outlook.MailItem moveMail, Outlook.MAPIFolder readRFQFolder)
        {
            decimal priceScale1;
            decimal priceScale2;
            decimal priceScale3;
            bool mailSaved = false;
            if (receivedMaildt.Rows.Count > 0)
            {
                System.Data.DataTable dtRFQReceived = new System.Data.DataTable();
                dtRFQReceived = receivedMaildt.Copy();
                System.Data.DataTable dtLinerDetails = new System.Data.DataTable();
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
                System.Data.DataTable ds_Vendor_Email = objDAL_FO_RFQ.FO_RFQ_Fetch_Vendor_Email(vendorCode).Tables[0];
                if (ds_Vendor_Email.Rows.Count > 0)
                {

                    if (string.IsNullOrEmpty(Convert.ToString(ds_Vendor_Email.Rows[0]["FolderPath"])) != true)
                    {
                        vendorattachpath = ds_Vendor_Email.Rows[0]["FolderPath"].ToString();
                        ReceivedQuotationPath = vendorattachpath + @"\ReceivedQuotation";
                        string ENV = MYGlobal.GetSettingValue("ENV");
                        if (ENV == "Local")
                        {
                            ReceivedQuotationPath = @"D:\ReceivedQuotation";
                        }
                        try
                        {
                            if (!Directory.Exists(ReceivedQuotationPath))
                            {
                                log.Info("ReceivedQuotationPath folder not available");
                                Directory.CreateDirectory(ReceivedQuotationPath);
                                log.Info("ReceivedQuotationPath folder created");
                            }
                        }
                        catch (System.Exception ex)
                        {
                            log.Info("----------------- Error Start -------------------");
                            log.Info(String.Concat(ex.StackTrace, ex.Message));
                            if (ex.InnerException != null)
                            {
                                log.Info("Inner Exception");
                                log.Info(String.Concat(ex.InnerException.StackTrace, ex.InnerException.Message));
                            }
                            log.Info("----------------- Error End -------------------");
                            throw new System.Exception("Vendor Folder Path is not Found.");

                        }

                    }
                    else
                    {
                        log.Info("Received Quotations Folder path is empty in table tblVendor");
                    }
                }


                int i = 1;
                
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
                if (RFQRefNum != "")
                {
                   
                    RFQRefNum = string.Empty;
                }
            }

            return mailSaved;
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

        //string folderpath;
        string strconfigExcelPath = string.Empty;
        string strconfigExcelSheet = string.Empty;
        string strconfigSentRFQPath = string.Empty;
        string RFQRefNum = string.Empty;
        SqlConnection con;
        SqlDataReader sdr;

        public bool parseTKPPEmail(System.Data.DataTable dt, string titleSubject, string vendorCode, Outlook.MailItem moveMail, Outlook.MAPIFolder readRFQFolder)
        {
            log.Info("Parse Email ");
            decimal price1 = 0, price2 = 0, price3 = 0, price4 = 0, price5 = 0, price10 = 0, price25 = 0, price50 = 0, price100 = 0;
            int fcnt=0;
            int noofrecs;
            bool moved = false;
            vendorattachpath = string.Empty;
            vendorQuote = string.Empty;
            string[] arrFolderPath = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", };
            System.Data.DataTable dtRFQReceived = new System.Data.DataTable();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    dtRFQReceived = dt.Copy();
                    dtRFQReceived.Columns.Add("pricebreakstatus");
                    dtRFQReceived.AcceptChanges();
                }
                if (dtRFQReceived.Rows.Count > 0)
                {
                    string sep = ": ";
                    int separatorIndex = titleSubject.IndexOf(sep);
                    if (separatorIndex >= 0)
                    {
                        RFQRefNum = titleSubject.Substring(separatorIndex + sep.Length);
                        RFQRefNum = RFQRefNum.Substring(0, RFQRefNum.LastIndexOf("-"));
                    }
                    
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
                        }
                        else
                        {
                            price100 = dtRFQReceived.Rows[r]["100"].ToString() == "" ? 0 : Convert.ToDecimal(dtRFQReceived.Rows[r]["100"].ToString());
                            log.Info("price100" + price100);
                        }

                        string connectionString = MYGlobal.getCString();

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
                            log.Info("----------------- Error Start -------------------");
                            log.Info(String.Concat(ex.StackTrace, ex.Message));

                            if (ex.InnerException != null)
                            {
                                log.Info("Inner Exception");
                                log.Info(String.Concat(ex.InnerException.StackTrace, ex.InnerException.Message));
                            }
                            log.Info("----------------- Error End -------------------");
                            throw new System.Exception("Record Not Found in Database.");
                        }
                        try
                        {
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
                            // SqlCommand cmd = new SqlCommand("usp_UPD_PP_RFQ", con);
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
                            cmd.Parameters.AddWithValue("@PB1", (price1.ToString() == "0") ? null : price1.ToString());
                            cmd.Parameters.AddWithValue("@PB2", (price2.ToString() == "0") ? null : price2.ToString());
                            cmd.Parameters.AddWithValue("@PB3", (price3.ToString() == "0") ? null : price3.ToString());
                            cmd.Parameters.AddWithValue("@PB4", (price4.ToString() == "0") ? null : price4.ToString());
                            cmd.Parameters.AddWithValue("@PB5", (price5.ToString() == "0") ? null : price5.ToString());
                            cmd.Parameters.AddWithValue("@PB10", (price10.ToString() == "0") ? null : price10.ToString());
                            cmd.Parameters.AddWithValue("@PB25", (price25.ToString() == "0") ? null : price25.ToString());
                            cmd.Parameters.AddWithValue("@PB50", (price50.ToString() == "0") ? null : price50.ToString());
                            cmd.Parameters.AddWithValue("@PB100", (price100.ToString() == "0") ? null : price100.ToString());
                            cmd.Parameters.AddWithValue("@REM", dtRFQReceived.Rows[r]["Remarks"].ToString());
                            cmd.Parameters.AddWithValue("@LTIME", dtRFQReceived.Rows[r]["Lead Time in days"].ToString());
                            cmd.Parameters.AddWithValue("@UOM", dtRFQReceived.Rows[r]["UOM"].ToString());
                            cmd.Parameters.AddWithValue("@CQTY", dtRFQReceived.Rows[r]["Conversion Qty"].ToString());
                            cmd.Parameters.AddWithValue("@CO", dtRFQReceived.Rows[r]["COO"].ToString());
                            cmd.Parameters.AddWithValue("@CURRENCY", dtRFQReceived.Rows[r]["Currency"].ToString());
                            cmd.Parameters.AddWithValue("@MDATE", DateTime.Now);
                            cmd.Parameters.AddWithValue("@RFQ_Refer", RFQRefNum);
                            /*
                            cmd.Parameters.AddWithValue("@OrderedPart", dtRFQReceived.Rows[r]["Part Number"].ToString());
                            cmd.Parameters.AddWithValue("@VendorCode", vendorCode.ToString());
                            cmd.Parameters.AddWithValue("@Quotation", dtRFQReceived.Rows[r]["Quotation #"].ToString());
                            cmd.Parameters.AddWithValue("@Price_Break_1", (price1.ToString() == "0") ? null : price1.ToString() );
                            cmd.Parameters.AddWithValue("@Price_Break_2", (price2.ToString() == "0") ? null : price2.ToString() );
                            cmd.Parameters.AddWithValue("@Price_Break_3", (price3.ToString() == "0") ? null : price3.ToString());
                            cmd.Parameters.AddWithValue("@Price_Break_4", (price4.ToString() == "0") ? null : price4.ToString());
                            cmd.Parameters.AddWithValue("@Price_Break_5", (price5.ToString() == "0") ? null : price5.ToString());
                            cmd.Parameters.AddWithValue("@Price_Break_10", (price10.ToString() == "0") ? null : price10.ToString());
                            cmd.Parameters.AddWithValue("@Price_Break_25", (price25.ToString() == "0") ? null : price25.ToString());
                            cmd.Parameters.AddWithValue("@Price_Break_50", (price50.ToString() == "0") ? null : price50.ToString());
                            cmd.Parameters.AddWithValue("@Price_Break_100", (price100.ToString() == "0") ? null : price100.ToString());
                            cmd.Parameters.AddWithValue("@pricebreakstatus", dtRFQReceived.Rows[r]["pricebreakstatus"].ToString());
                            cmd.Parameters.AddWithValue("@Remarks", dtRFQReceived.Rows[r]["Remarks"].ToString());
                            cmd.Parameters.AddWithValue("@LeadTime", dtRFQReceived.Rows[r]["Lead Time in days"].ToString());
                            cmd.Parameters.AddWithValue("@UOM", dtRFQReceived.Rows[r]["UOM"].ToString());
                            cmd.Parameters.AddWithValue("@Conversion_Qty", dtRFQReceived.Rows[r]["Conversion Qty"].ToString());
                            cmd.Parameters.AddWithValue("@Country_of_Origin", dtRFQReceived.Rows[r]["COO"].ToString());
                            cmd.Parameters.AddWithValue("@Currency", dtRFQReceived.Rows[r]["Currency"].ToString());
                            cmd.Parameters.AddWithValue("@RFQ_Refer", RFQRefNum);
                            */
                            cmd.ExecuteNonQuery();
                            log.Info("SP_UPD_PP_RFQ_LINER executed \n\n");
                        }
                        catch (System.Exception ex)
                        {
                            log.Info("----------------- Error Start -------------------");
                            log.Info(String.Concat(ex.StackTrace, ex.Message));

                            if (ex.InnerException != null)
                            {
                                log.Info("Inner Exception");
                                log.Info(String.Concat(ex.InnerException.StackTrace, ex.InnerException.Message));
                            }
                            log.Info("----------------- Error End -------------------");
                            throw new System.Exception("Record Not Found in Database.");
                        }
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
                                if (!String.IsNullOrEmpty(vendorattachpath))
                                {
                                    ReceivedQuotationPath = vendorattachpath + @"\ReceivedQuotation";
                                    string ENV = MYGlobal.GetSettingValue("ENV");
                                    if(ENV == "Local")
                                    {
                                        ReceivedQuotationPath =  @"D:\ReceivedQuotation";
                                    }
                                    log.Info("ReceivedQuotationPath" + ReceivedQuotationPath);
                                    try
                                    {
                                        if (!Directory.Exists(vendorattachpath))
                                        {
                                            Directory.CreateDirectory(vendorattachpath);
                                            Directory.CreateDirectory(ReceivedQuotationPath);
                                        }
                                    }
                                    catch (System.Exception ex)
                                    {
                                        log.Info("----------------- Error Start -------------------");
                                        log.Info(String.Concat(ex.StackTrace, ex.Message));

                                        if (ex.InnerException != null)
                                        {
                                            log.Info("Inner Exception");
                                            log.Info(String.Concat(ex.InnerException.StackTrace, ex.InnerException.Message));
                                        }
                                        log.Info("----------------- Error End -------------------");
                                        throw new System.Exception("Vendor Attachement Path is not Found.");
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
                                            moved = true;
                                        }
                                        else
                                        {
                                            receivedMailMessage = ReceivedQuotationPath + @"\" + "NoVendorQuote" + "_Dated " + DateTime.Now.ToString("MM/dd/yyyy").Replace("/", "-") + "_Time " + DateTime.Now.ToString("HH:mm:ss tt").Replace(":", "-") + ".msg";
                                            moveMail.SaveAs(receivedMailMessage.Trim(), Microsoft.Office.Interop.Outlook.OlSaveAsType.olMSG);
                                            log.Info("Mail saved inReceivedQuotationPath" + receivedMailMessage);
                                            //MessageBox.Show("VendorQuote is Empty ,Mail Not saved");
                                            log.Info("VendorQuote is Empty ");
                                            moved = true;
                                        }
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
 
                                    if (!String.IsNullOrEmpty(vendorattachpath))
                                    {
                                        ReceivedQuotationPath = vendorattachpath + @"\ReceivedQuotation";
                                        string ENV = MYGlobal.GetSettingValue("ENV");
                                        if (ENV == "Local")
                                        {
                                            ReceivedQuotationPath = @"D:\ReceivedQuotation";
                                        }
                                        log.Info("ReceivedQuotationPath" + ReceivedQuotationPath);
                                        //ONLY receivedquotationpath is created,removed sentrfq and attachments path
                                        try
                                        {
                                            if (!Directory.Exists(vendorattachpath))
                                            {
                                                Directory.CreateDirectory(vendorattachpath);
                                                Directory.CreateDirectory(ReceivedQuotationPath);
                                                log.Info("vendorattachpath created");
                                                log.Info("ReceivedQuotationPath created");
                                            }
                                        }
                                        catch (System.Exception ex)
                                        {
                                            log.Info("----------------- Error Start -------------------");
                                            log.Info(String.Concat(ex.StackTrace, ex.Message));

                                            if (ex.InnerException != null)
                                            {
                                                log.Info("Inner Exception");
                                                log.Info(String.Concat(ex.InnerException.StackTrace, ex.InnerException.Message));
                                            }
                                            log.Info("----------------- Error End -------------------");
                                            throw new System.Exception("Vendor Attachement Path is not Found.");
                                        }
                                        if (Directory.Exists(vendorattachpath))
                                        {
                                            if (!Directory.Exists(ReceivedQuotationPath))
                                            {
                                                Directory.CreateDirectory(ReceivedQuotationPath);
                                            }

                                            //  receivedMailMessage = ReceivedQuotationPath + @"\" + Subject.Trim().Replace(": ", "-") + " " + DateTime.Now.ToString().Replace("/", "-").Replace(":", "-") + ".msg";
                                            //All part numbers use same vendorquote
                                            if (!string.IsNullOrEmpty(vendorQuote))
                                            {
                                                receivedMailMessage = ReceivedQuotationPath + @"\" + vendorQuote.Trim() + "_Dated " + DateTime.Now.ToString("MM/dd/yyyy").Replace("/", "-") + "_Time " + DateTime.Now.ToString("HH:mm:ss tt").Replace(":", "-") + ".msg";
                                                moveMail.SaveAs(receivedMailMessage.Trim(), Microsoft.Office.Interop.Outlook.OlSaveAsType.olMSG);
                                                log.Info("Mail saved inReceivedQuotationPath" + receivedMailMessage);
                                                moved = true;
                                            }
                                            else
                                            {
                                                //MessageBox.Show("VendorQuote is Empty ,Mail Not saved");
                                                receivedMailMessage = ReceivedQuotationPath + @"\" + "NoQuote" + "_Dated " + DateTime.Now.ToString("MM/dd/yyyy").Replace("/", "-") + "_Time " + DateTime.Now.ToString("HH:mm:ss tt").Replace(":", "-") + ".msg";
                                                moveMail.SaveAs(receivedMailMessage.Trim(), Microsoft.Office.Interop.Outlook.OlSaveAsType.olMSG);
                                                log.Info("Mail saved inReceivedQuotationPath" + receivedMailMessage);
                                                log.Info("VendorQuote is Empty");
                                                moved = true;
                                            }
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
                        }
                    }
                }               
            }
            return moved;
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


        private void doReadEmailMine()
        {
            int count = 0;
            try
            {
                Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
                Microsoft.Office.Interop.Outlook.NameSpace oNameSpace = oApp.GetNamespace("MAPI");
                Microsoft.Office.Interop.Outlook.MAPIFolder oFolder = oNameSpace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);
                Items items = oFolder.Items;
                int cnt = 0;
                log.Info(" items count " + items.Count);
                if (items.Count > 0)
                {
                    // for (int x = 0; x < items.Count; x++)
                    // foreach (MailItem mail in items)
                    foreach (Object _obj in items)
                    {
                        try
                        {
                            if (_obj is MailItem)
                            {
                                String subject = "";
                                 Microsoft.Office.Interop.Outlook.MailItem mail = (MailItem)_obj;
                                subject = mail.Subject;

                                subject = subject.Replace("", "");
                                subject = subject.Replace("RE: ", "");
                                subject = subject.Replace("FW: ", "");
                                subject = subject.Trim();
                                //log.Info("Subject = " + subject + "\n");
                                String body = mail.HTMLBody;
                                //subject.Contains("[EXTERNAL]") &&
                                if (subject.Contains("[EXTERNAL]") && subject.Contains("RFQ"))
                                {
                                    count = count + 1;
                                    log.Info(cnt + "  Email subject : " + subject + "\b\b" + ", Body=" + body + "========== \n");

                                   // var htmlDoc = new HtmlDocument();
                                   // htmlDoc.LoadHtml(html);
                                }
                            }
                        }catch(System.Exception ee)
                        {
                            log.Error("Mes error : " + ee.Message);
                        }
                    }
                }
            }catch(System.Exception ee)
            {
                log.Error("Main error " + ee.Message);
            }

            log.Info(" Read done : " + count);
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

        private void btnVendorMgmt_Click(object sender, EventArgs e)
        {
            doLoadVendor();
        }


        private void readMailStruct()
        {
            Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
            //Microsoft.Office.Interop.Outlook.MailItem mailItem = (Microsoft.Office.Interop.Outlook.MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
            Microsoft.Office.Interop.Outlook.NameSpace oNameSpace = oApp.GetNamespace("MAPI");
            Microsoft.Office.Interop.Outlook.MAPIFolder oFolder = oNameSpace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderSentMail);
            Items items = oFolder.Items;
            int cnt = 0;
            for (int x = 0; x < items.Count; x++)
            {
                String subject = "";
                Microsoft.Office.Interop.Outlook.MailItem mail = (MailItem)items[x];
                subject = mail.Subject;
                if (subject.Contains("RFQ"))
                {
                    log.Info(cnt + "  Email subject : " + subject + "\b\b");
                }
            }
        }


        private async void btnReadRFQ_Click(object sender, EventArgs e)
        {
            btnReadRFQ.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            this.Enabled = false;
            await Task.Delay(100);
            doReadEmail();
            await Task.Delay(100);
            btnReadRFQ.Enabled = true;
            this.Enabled = true;
            this.Cursor = Cursors.Default;
        }
    }
}
