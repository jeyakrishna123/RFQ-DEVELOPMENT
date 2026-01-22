using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using WebTools.DbConnectivity;
using System.Data;

namespace HalliburtonRFQ.DAL
{
    public class DAL_FO_RFQ
    {
        MsSqlConnectivity MsSql = new MsSqlConnectivity(Connection.ConnectionDetails.GetConnection());
        public DataTable FO_RFQ_Save(DataTable dtHeader,DataTable dtLiner)
        {

            ParameterCollection objParam = new ParameterCollection();
            try
            {
                objParam.Add("@udt_FO_RFQ_Header", dtHeader);
                objParam.Add("@udt_FO_RFQ_Liner", dtLiner);              
                return MsSql.RunStoredProcedureDataTable("usp_INS_FO_RFQ", objParam, "FO_RFQ");
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

        public DataSet FO_RFQ_Fetch_Vendor_Email(string vendcode)
        {

            ParameterCollection objParam = new ParameterCollection();
            try
            {
                objParam.Add("@VENDOR_CODE", vendcode);
                return MsSql.RunStoredProcedureDataSet("usp_FETCH_Vendor_Email", objParam, "Vendor_Email");
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
        public DataSet FO_RFQ_Check(string SAPMaterialNumber)
        {

            ParameterCollection objParam = new ParameterCollection();
            try
            {
                objParam.Add("@SAPMaterialNumber", SAPMaterialNumber);
                return MsSql.RunStoredProcedureDataSet("usp_FO_RFQ_Check", objParam, "FO_RFQ_Check");
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

        public DataSet FO_RFQ_Fetch_LinerDetails()
        {

            ParameterCollection objParam = new ParameterCollection();
            try
            {
                
                return MsSql.RunStoredProcedureDataSet("usp_FETCH_FO_RFQ_Liner", objParam, "FO_RFQ_Liner");
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

        public void FO_RFQ_UpdateLinerDetails(DataTable dtLiner)
        {
            ParameterCollection objParam = new ParameterCollection();
            try
            {
                objParam.Add("@udt_Vendor_UPD_FO_RFQ_Liner", dtLiner);

                MsSql.updLinerStoredProcedure("[usp_UPD_FO_RFQ]", objParam);
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

        public DataTable getConfig()
        {
            ParameterCollection objParam = new ParameterCollection();
            try
            {
                return MsSql.RunStoredProcedureDataTable("usp_fetch_ConfigValues", objParam, "CommonConfig");
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
