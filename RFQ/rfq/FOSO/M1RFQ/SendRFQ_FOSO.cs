using HalliburtonRFQ.Common;
using HalliburtonRFQ.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using System.IO;

/**
 * WOrking
 */
namespace HalliburtonRFQ
{
    public partial class SendRFQ_FOSO : Form
    {
        DataTable dtsource = new DataTable();
        public DataTable dtnew { get; set; }
        MailGenerate objMailGenerate = new MailGenerate();
        DAL_FO_RFQ objDAL_FO_RFQ = new DAL_FO_RFQ();
        CheckBox headerCheckBox = new CheckBox();
        StreamWriter sw = null;
        string LogRFQ;
        string logpath;
        public SendRFQ_FOSO(DataTable dt)
        {
            InitializeComponent();
            dtsource = dt;
            LogRFQ = System.Configuration.ConfigurationManager.AppSettings["LogRFQ"];
        }
        bool isSelected;
        private void rbtnSend_Click(object sender, EventArgs e)
        {
            try
            {            
                
                DataTable dtLiner_Filter = new DataTable();
                DataTable dtHeader = new DataTable();
                DataTable dtLiner = new DataTable();
                
                if (LogRFQ == "1")
                {
                  
                    LogOptions.Log(logpath,LogCategory.SendRFQButton, "SenddRFQ-FOSO dtsource.Rows.Count  greater 0" + dtsource.Rows.Count);                    
                }
                if (dtsource.Rows.Count > 0)
                {                                     
                    DataTable dt = new DataTable();
                    if (LogRFQ == "1")
                    {
                       
                        LogOptions.Log(logpath,LogCategory.SendRFQButton, "Grid Columns:" );
                    }
                    
                    int c = 1;
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        if (column.Name != "checkBoxColumn")
                        {
                            dt.Columns.Add(column.Name);                          
                            c++;
                        }
                    }
                        
                            
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        //  bool isSelected = Convert.ToBoolean(row.Cells["checkBoxColumn"].Value);
                        //DataGridViewCheckBoxCell chkchecking = row.Cells[0] as DataGridViewCheckBoxCell;
                        //bool isSelected = Convert.ToBoolean(chkchecking.Value);
                        //bool isSelected = Convert.ToBoolean(row.Cells["checkBoxColumn"].Value);
                        //Added by Rajan on 29/7/2020 to fix for selecting single record in grid

                        if ((row.Cells["checkBoxColumn"].Selected) && (row.Cells["checkBoxColumn"].IsInEditMode)) 
                        {
                             isSelected = true;
                           
                        }

                        if (!row.Cells["checkBoxColumn"].Selected)
                        {
                           if  (!row.Cells["checkBoxColumn"].IsInEditMode)
                                {
                                if (row.Cells["checkBoxColumn"].Value != null)
                                {
                                    if (row.Cells["checkBoxColumn"].Value.ToString() == "True")
                                    {
                                        isSelected = true;
                                        
                                        if (LogRFQ == "1")
                                        {  
                                            LogOptions.Log(logpath,LogCategory.SendRFQButton, "2ifcheckBoxColumn " + isSelected);
                                        }
                                    }
                                }
                                else
                                {
                                    isSelected = false;
                                }
                                    
                            }
                        }
                            
                        //bool isSelected = Convert.ToBoolean(row.Cells["checkBoxColumn"].Selected);
                        //string SAPMaterialNumber = Convert.ToString(row.Cells["SAP Material Number"].Value);
                        //DataSet ds = objDAL_FO_RFQ.FO_RFQ_Check(SAPMaterialNumber);

                        if (isSelected)
                        {

                            dt.Rows.Add(row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value, row.Cells[4].Value, row.Cells[5].Value, row.Cells[6].Value, row.Cells[7].Value, row.Cells[8].Value, row.Cells[9].Value, row.Cells[10].Value, row.Cells[11].Value, row.Cells[12].Value, row.Cells[13].Value, row.Cells[14].Value, row.Cells[15].Value, row.Cells[16].Value, row.Cells[17].Value, row.Cells[18].Value, row.Cells[19].Value, row.Cells[20].Value, row.Cells[21].Value, row.Cells[22].Value, row.Cells[23].Value, row.Cells[24].Value, row.Cells[25].Value, row.Cells[26].Value, row.Cells[27].Value, row.Cells[28].Value, row.Cells[29].Value, row.Cells[30].Value, row.Cells[31].Value, row.Cells[32].Value, row.Cells[33].Value, row.Cells[34].Value, row.Cells[35].Value, row.Cells[36].Value, row.Cells[37].Value, row.Cells[38].Value, row.Cells[39].Value, row.Cells[40].Value, row.Cells[41].Value, row.Cells[42].Value, row.Cells[43].Value, row.Cells[44].Value, row.Cells[45].Value, row.Cells[46].Value, row.Cells[47].Value, row.Cells[48].Value, row.Cells[49].Value, row.Cells[50].Value, row.Cells[51].Value, row.Cells[52].Value, row.Cells[53].Value, row.Cells[54].Value, row.Cells[55].Value, row.Cells[56].Value, row.Cells[57].Value, row.Cells[58].Value, row.Cells[59].Value, row.Cells[60].Value, row.Cells[61].Value, row.Cells[62].Value);

                        }                      
                    }
                    dt.AcceptChanges();                  
                    dtnew = dt;

                    if (LogRFQ == "1")
                    {
                     //   MessageBox.Show("8" + logpath);
                        LogOptions.Log(logpath,LogCategory.SendRFQButton, "dtnew created" + dtnew.Rows.Count.ToString());
                    }
                        this.Close();

                    if(sw !=null)
                    {
                        sw.Close();
                    }
                    //after selecting PO's goes to  btnSend_FO_RFQ_Click in ribbon bar
                }
            }
            catch (Exception ex)
            {
                if (sw != null)
                {
                    sw.Close();
                }
                MessageBox.Show(ex.ToString());
                throw ex;
            }
        }
        private void HeaderCheckBox_Clicked(object sender, EventArgs e)
        {
            //Necessary to end the edit mode of the Cell.
            dataGridView1.EndEdit();

            //Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell checkBox = (row.Cells["checkBoxColumn"] as DataGridViewCheckBoxCell);
                checkBox.Value = headerCheckBox.Checked;
            }
        }
        private void SendRFQ_FOSO_Load(object sender, EventArgs e)
        {
            try
            {
                if (dtsource.Rows.Count > 0)
                {
                  
                    dataGridView1.DataSource = dtsource;
                    if (LogRFQ == "1")
                    {
                        logpath = LogOptions.CreateRFQGridLogFile();
                     //   MessageBox.Show("1" + logpath);
                        LogOptions.Log(logpath,LogCategory.SendRFQButton, "Load time" + DateTime.Now);
                        LogOptions.Log(logpath,LogCategory.SendRFQButton, "Dtsource count assigned to datagridview1 is" + dtsource.Rows.Count);
                    }
                    
                    Point headerCellLocation = this.dataGridView1.GetCellDisplayRectangle(0, -1, true).Location;

                    //Place the Header CheckBox in the Location of the Header Cell.
                    headerCheckBox.Location = new Point(headerCellLocation.X + 8, headerCellLocation.Y + 2);
                    headerCheckBox.BackColor = Color.White;
                    headerCheckBox.Size = new Size(18, 18);

                    //Assign Click event to the Header CheckBox.
                    headerCheckBox.Click += new EventHandler(HeaderCheckBox_Clicked);
                    dataGridView1.Controls.Add(headerCheckBox);

                    //Add a CheckBox Column to the DataGridView at the first position.
                    DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                    checkBoxColumn.HeaderText = "";
                    checkBoxColumn.Width = 30;
                    checkBoxColumn.Name = "checkBoxColumn";
                    dataGridView1.Columns.Insert(0, checkBoxColumn);

                    //Assign Click event to the DataGridView Cell.
                    dataGridView1.CellContentClick += new DataGridViewCellEventHandler(DataGridView_CellClick);
                    if (sw !=null)
                    {
                        sw.Close();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Check to ensure that the row CheckBox is clicked.
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                //Loop to verify whether all row CheckBoxes are checked or not.
                bool isChecked = true;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["checkBoxColumn"].EditedFormattedValue) == false)
                    {
                        isChecked = false;
                        break;
                    }
                }
                headerCheckBox.Checked = isChecked;
            }
        }
        private void rbtnClose_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
