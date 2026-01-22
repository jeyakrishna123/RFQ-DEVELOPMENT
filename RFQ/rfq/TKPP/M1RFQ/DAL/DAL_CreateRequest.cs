using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using WebTools.DbConnectivity;

using HalliburtonRFQ.Connection;

namespace HalliburtonRFQ.DAL
{
     
    public class DAL_CreateRequest
    {
         static string  strdbMyconn;
         public DAL_CreateRequest()
        {
            
        }
       

        MsSqlConnectivity MsSql = new MsSqlConnectivity(ConnectionDetails.GetConnection());

     
        //public DataSet LoadRequstaionNO()
        //{
        //    try
        //    {
        //        ParameterCollection param = new ParameterCollection();
        //        return MsSql.RunStoredProcedureDataSet("usp_RequstionNumber_RunningID", param, "loadtask");

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

        public DataSet FetchPartNumber()
        {
            ParameterCollection objParam = new ParameterCollection();
            try
            {


                return MsSql.RunStoredProcedureDataSet("usp_FetchPartNumber", objParam, "PartNumber");

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                MsSql.Dispose();
            }
        }
        public DataSet FetchStatus()
        {
            ParameterCollection objParam = new ParameterCollection();
            try
            {


                return MsSql.RunStoredProcedureDataSet("usp_FetchStatus", objParam, "PartNumber");

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                MsSql.Dispose();
            }
        }
        public DataSet RequestHeader_Save(string strRequestorName,string strRequestorMail,DataTable dtRequestLine)
        {

            ParameterCollection objParam = new ParameterCollection();
            try
            {
                objParam.Add("@RequestorName", strRequestorName);
                objParam.Add("@RequestorMail", strRequestorMail);
                objParam.Add("@RequestLiner", dtRequestLine);
               return MsSql.RunStoredProcedureDataSet("usp_InsertUpdateRequestPartNumber", objParam, "PartNumber");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                MsSql.Dispose();
            }

        }

        public DataSet LoadRequestPartNumber(string strRequestorMail,DateTime? ReqFrom, DateTime? ReqTo,string Status)
        {

            ParameterCollection objParam = new ParameterCollection();
            try
            {
                
                objParam.Add("@RequestorMail", strRequestorMail);
                objParam.Add("@FromDate", ReqFrom);

                objParam.Add("@ToDate", ReqTo);
                objParam.Add("@Status", Status);
                return MsSql.RunStoredProcedureDataSet("usp_FetchRequestPartNumber", objParam, "PartNumber");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                MsSql.Dispose();
            }

        }

        public DataSet FetchPendingRequest()
        {
            ParameterCollection objParam = new ParameterCollection();
            try
            {


                return MsSql.RunStoredProcedureDataSet("usp_FetchPendingRequestPartNumber", objParam, "PartNumber");

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                MsSql.Dispose();
            }
        }


        public DataSet RequestUpdate(string strRequestReviewedBy,  string Comments,int intStatus,DataTable dtRequest)
        {

            ParameterCollection objParam = new ParameterCollection();
            try
            {

                objParam.Add("@ReviewedBy", strRequestReviewedBy);

                objParam.Add("@Status", intStatus);
                objParam.Add("@Comments", Comments);
                objParam.Add("@RequestHeader", dtRequest);
                return MsSql.RunStoredProcedureDataSet("usp_RequestStatusUpdate", objParam, "PartNumber");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                MsSql.Dispose();
            }

        }



        public DataSet QuotationSend_Save(long ReqID,long VendorID,string strSenderName, string strSenderMail, DataTable dtRFQLine)
        {

            ParameterCollection objParam = new ParameterCollection();
            try
            {
                objParam.Add("@ReqID", ReqID);
                objParam.Add("@VendorID", VendorID);
                objParam.Add("@SenderName", strSenderName);
                objParam.Add("@SenderMail", strSenderMail);
                
                objParam.Add("@RFQLiner", dtRFQLine);
                return MsSql.RunStoredProcedureDataSet("usp_InsertRFQPartNumber", objParam, "PartNumber");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                MsSql.Dispose();
            }

        }



        public DataSet QuotationComparisonReport(long ReqID)
        {

            ParameterCollection objParam = new ParameterCollection();
            try
            {
                objParam.Add("@ReqID", ReqID);
              
                return MsSql.RunStoredProcedureDataSet("usp_GetComparedProducts", objParam, "PartNumber");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                MsSql.Dispose();
            }

        }



        public DataSet FetchReceivedRFQ()
        {
            ParameterCollection objParam = new ParameterCollection();
            try
            {


                return MsSql.RunStoredProcedureDataSet("usp_FetchReceivedRFQ", objParam, "PartNumber");

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                MsSql.Dispose();
            }
        }



        public DataSet RFQUpdate(string strRFQNumber,  DataTable dtRFQ)
        {

            ParameterCollection objParam = new ParameterCollection();
            try
            {

                objParam.Add("@RFQNumber", strRFQNumber);

                
                objParam.Add("@RFQLiner", dtRFQ);
                return MsSql.RunStoredProcedureDataSet("usp_RFQPriceUpdate", objParam, "PartNumber");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                MsSql.Dispose();
            }

        }
    }
}
