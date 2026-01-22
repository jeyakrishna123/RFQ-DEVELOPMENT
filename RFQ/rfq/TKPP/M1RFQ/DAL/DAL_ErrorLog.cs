using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using WebTools.DbConnectivity;

using HalliburtonRFQ.Connection;


namespace DAL
{
    public class DAL_ErrorLog
    {
      //  static string dbconn, dbMyconn;
        public DAL_ErrorLog()
        {
          
        }
       

        MsSqlConnectivity MsSql = new MsSqlConnectivity(ConnectionDetails.GetConnection());
        //MsSqlConnectivity MsSql = new MsSqlConnectivity(dbconn);

        //public void InsertErrorLog(BEL.BEL_ErrorLog BEL_ErrorLog)
        //{
        //    ParameterCollection ErrorLog = new ParameterCollection();
        //    try
        //    {
        //        ErrorLog.Add("@UserID", BEL_ErrorLog.loginuserId);
        //        ErrorLog.Add("@FormName", BEL_ErrorLog.formName);
        //        ErrorLog.Add("@MethodName", BEL_ErrorLog.methodName);
        //        ErrorLog.Add("@ErrorMessage", BEL_ErrorLog.errorMessage);

        //        DataSet ds = new DataSet();
        //        ds = MsSql.RunStoredProcedureDataSet("usp_INSERT_Tbl_ErrorLog", ErrorLog, "Error");

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        MsSql.Dispose();
        //    }
        //}

       





    }
}