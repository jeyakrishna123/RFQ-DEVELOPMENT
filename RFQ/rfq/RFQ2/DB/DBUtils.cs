using RFQ2.Global;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFQ2.DB
{
    class DBUtils
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        public static SqlConnection getSQLConnection()
        {

            SqlConnection cnn = null;
            try
            {
                //string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                //Response.Write("DB Connection String = " + connStr);
                string connStr = MYGlobal.getCString();
                cnn = new SqlConnection(connStr);
                cnn.Open();
            }
            catch (Exception ex)
            {
                log.Info("Connection failed " + ex);
                return null;
            }

            return cnn;
        }

        public static ArrayList getAllMaterials(String foORpp)
        {
            ArrayList al = new ArrayList();
            String stored_proc = "";
            String COL = "";
            if (foORpp.Equals("FO"))
            {
                stored_proc = "SP_FO_FRQ_LINER";
                COL = "SAP Material Number";
            }
            else if (foORpp.Equals("PP"))
            {
                stored_proc = "SP_PP_RFQ_LINER";
                COL = "OrderedPart";
            }

                try
            {
                using (SqlConnection cnn = new SqlConnection(MYGlobal.getCString()))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(stored_proc, cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@ACTION", 1));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                String mat = (string)reader[COL];
                                al.Add(mat);
                            }
                        }
                    }
                }
            }catch(Exception ee)
            {
                log.Error("Exceptoin in  getAllMaterials(): " + ee.Message);
            }
            return al;
        }

        public static ArrayList getAllRFQRef(String foORpp, String matlNbr)
        {
            ArrayList al = new ArrayList();
            String stored_proc = "";
            String COL = "";
            if (foORpp.Equals("FO"))
            {
                stored_proc = "SP_FO_FRQ_LINER";
                COL = "RFQ refer";
            }
            else if (foORpp.Equals("PP"))
            {
                stored_proc = "SP_PP_RFQ_LINER";
                COL = "RFQ_Refer";
            }


            try
            {
                using (SqlConnection cnn = new SqlConnection(MYGlobal.getCString()))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(stored_proc, cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@ACTION", 2));
                        cmd.Parameters.Add(new SqlParameter("@MATL_NBR", matlNbr));


                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                String mat = (string)reader[COL];
                                al.Add(mat);
                            }
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                log.Error("Exceptoin in  getAllMaterials(): " + ee.Message);
            }
            return al;
        }


        public static ConfigDao getConfigDao(int cid, String key)
        {
            ConfigDao dao = null;
            using (SqlConnection cnn = new SqlConnection(MYGlobal.getCString()))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_GET_ALL_CONFIGS", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (cid >0)
                    {
                        cmd.Parameters.Add(new SqlParameter("@ConfigID", cid));
                    }

                    if (key != null)
                    {
                        cmd.Parameters.Add(new SqlParameter("@ConfigKey", key));
                    }

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dao = new ConfigDao();
                            dao.ConfigID = Convert.ToInt32(reader["ConfigID"]);
                            dao.ConfigKey = (String)reader["ConfigKey"];
                            dao.ConfigVal = (String)reader["ConfigValue"];
                            return dao;
                        }
                    }

                }
            }
            return dao;
        }

        public static ArrayList getAllVendor(String foORpp,  String matlNbr, String rfqRef)
        {
            ArrayList al = new ArrayList();
            String stored_proc = "";
            String COL = "";
            if (foORpp.Equals(MYGlobal.TYPE_FO))
            {
                stored_proc = "SP_FO_FRQ_LINER";
                COL = "Vendor ID";
            }
            else if (foORpp.Equals(MYGlobal.TYPE_PP))
            {
                stored_proc = "SP_PP_RFQ_LINER";
                COL = "Vendor_ID";
            }


            try
            {
                using (SqlConnection cnn = new SqlConnection(MYGlobal.getCString()))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(stored_proc, cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@ACTION", 3));
                        cmd.Parameters.Add(new SqlParameter("@MATL_NBR", matlNbr));
                        cmd.Parameters.Add(new SqlParameter("@RFQ_REF_NBR", rfqRef));


                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                String mat = (string)reader[COL];
                                al.Add(mat);
                            }
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                log.Error("Exceptoin in  getAllMaterials(): " + ee.Message);
            }
            return al;
        }



        public static ArrayList getAllFORFQLiner(String matlNbr, String rfqRef, String vendorId)
        {
            ArrayList al = new ArrayList();

            try
            {
                using (SqlConnection cnn = new SqlConnection(MYGlobal.getCString()))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_FO_FRQ_LINER", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@ACTION", 4));
                        cmd.Parameters.Add(new SqlParameter("@MATL_NBR", matlNbr));
                        cmd.Parameters.Add(new SqlParameter("@RFQ_REF_NBR", rfqRef));
                        cmd.Parameters.Add(new SqlParameter("@VENDOR_ID", vendorId));


                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                String mat = (string)reader["Vendor ID"];
                                al.Add(mat);
                            }
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                log.Error("Exceptoin in  getAllMaterials(): " + ee.Message);
            }
            return al;
        }
         

        public static bool doDeleteFO(int id)
        {
            bool result = false;
            string sql = "delete from  tbl_FO_RFQ_Liner where id="+id;
            try
            {
                using (SqlConnection cnn = new SqlConnection(MYGlobal.getCString()))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.CommandType = CommandType.Text;
                        // cmd.Parameters.Add(new SqlParameter("@ACTION", 4));

                       int rows =  cmd.ExecuteNonQuery();
                        log.Info("Rows " + rows);
                        return true;
                    }
                }
            }
            catch (Exception ee)
            {
                log.Error("Exceptoin in  doDeleteFO(): " + ee.Message);
            }
            return result;
        }


        public static bool doDeletePP(int id)
        {
            bool result = false;
            string sql = "delete from  tbl_PP_RFQ_Liner where id=" + id;
            try
            {
                using (SqlConnection cnn = new SqlConnection(MYGlobal.getCString()))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.CommandType = CommandType.Text;
                        // cmd.Parameters.Add(new SqlParameter("@ACTION", 4));

                       int rows =  cmd.ExecuteNonQuery();
                        log.Info("Rows " + rows);
                        return true;
                    }
                }
            }
            catch (Exception ee)
            {
                log.Error("Exceptoin in  doDeletePP(): " + ee.Message);
            }
            return result;
        }


        public static bool doDeletePPHeader()
        {
            bool result = false;
            string sql = " delete FROM  [tbl_PP_RFQ_Header] where RFQ_Refer is null and batch is null and MRPController is null ";
            try
            {
                using (SqlConnection cnn = new SqlConnection(MYGlobal.getCString()))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.CommandType = CommandType.Text;
                        // cmd.Parameters.Add(new SqlParameter("@ACTION", 4));

                        int rows = cmd.ExecuteNonQuery();
                        log.Info("Rows deleted " + rows);
                        return true;
                    }
                }
            }
            catch (Exception ee)
            {
                log.Error("Exceptoin in  doDeletePPHeader(): " + ee.Message);
            }
            return result;
        }


        public static bool doDeleteFOHeader()
        {
            bool result = false;
            string sql = " delete   FROM  [tbl_FO_RFQ_Header] where [RFQ Refer] is null  and [SAP Material Number] is null and MRPController is null ";
            try
            {
                using (SqlConnection cnn = new SqlConnection(MYGlobal.getCString()))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.CommandType = CommandType.Text;
                        // cmd.Parameters.Add(new SqlParameter("@ACTION", 4));

                        int rows = cmd.ExecuteNonQuery();
                        log.Info("Rows deleted " + rows);
                        return true;
                    }
                }
            }
            catch (Exception ee)
            {
                log.Error("Exceptoin in  doDeleteFOHeader(): " + ee.Message);
            }
            return result;
        }


    }
}
