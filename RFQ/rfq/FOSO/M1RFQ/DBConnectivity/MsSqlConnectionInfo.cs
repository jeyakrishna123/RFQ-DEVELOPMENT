using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Configuration;
/*
****************************************************************************
*
' Name      :   MsSqlConnectionInfo.cs
' Type      :   C# File
' Screen Id : 
' Arguments :
'------------------------------------------------------------------------------
' Name              Type        Description
' ----              ----        -----------
'------------------------------------------------------------------------------
' Return value :
' Called by    :
' Description  :
' Modification History :
'------------------------------------------------------------------------------
' Date                  Version             By              Reason
' ----                  -------             ---				------
' 29-Mar-2013           V1.0                Ibrahim          New
'--------------------------------------------------------------------------------
*/

namespace WebTools.DbConnectivity
{
    /// <summary>
    /// Extends Base Connectivity Info
    /// Provides information for MsSql Connection.
    /// </summary>
    public class MsSqlConnectionInfo : BaseConnectionInfo
    {
        int _timeout = 0;
        public MsSqlConnectionInfo()
            : base()
        {
            // Default MS SQL port
            if (Port == 0)
                Port = 1433;
        }
        public MsSqlConnectionInfo(int timeout)
            : base()
        {
            if (Port == 0)
                Port = 1433;
            _timeout = timeout;

        }
        public string WorkstationID
        {
            get
            {
                return workstationID;
            }
            set
            {
                workstationID = value;
            }
        }

        public string GetConnectionString()
        {
            string connectionString = ConfigurationManager.AppSettings["DefaultConnection"].ToString();
            //string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            return connectionString;
        }
        public string GetConnectionString1()
        {
            StringBuilder connString = new StringBuilder();
            connString.Append("Data Source=").Append(this.HostName);
            connString.Append(";initial catalog=").Append(this.DatabaseName);
            //connString.Append(";Integrated Security=True");
            connString.Append(";user id=").Append(this.UserName);
            connString.Append(";password=").Append(this.Password);
            return connString.ToString();
        }

        private string workstationID = Environment.MachineName;
    }
}
