using System;
using System.Data;
using System.Data.SqlClient;

namespace RFQ2.DB
{
	public  abstract class BaseConnectivity : IConnectivity
    {
        

        protected BaseConnectivity()
        {
        }
		public abstract void Connect();
		public abstract void Disconnect();

		public abstract DataSet RunQueryDataSet(string query, string tableName);
		public abstract DataSet RunQueryDataSet(string query, ParameterCollection parameters, string tableName);
		public abstract IDataReader RunStoredProcedureReader(string procedureName, ParameterCollection parameters);
		public abstract IDataReader RunQueryReader(string query);
		public abstract IDataReader RunQueryReader(string query, ParameterCollection parameters);
		public abstract DataSet RunStoredProcedureDataSet(string procedureName, ParameterCollection parameters, string tableName);
		public abstract DataTable RunStoredProcedureDataTable(string procedureName, ParameterCollection parameters, string tableName);
		public abstract object RunStoredProcedureScalar(string procedureName, ParameterCollection parameters);
		public abstract object RunStoredProcedureScalar(string procedureName, ParameterCollection parameters, SqlTransaction ObjTransation);
		public abstract int RunNonQuery(string query);
		public abstract int RunNonQuery(string query, ParameterCollection parameters);
		public abstract object RunQueryScalar(string query);
		public abstract object RunQueryScalar(string query, ParameterCollection parameters);
		public abstract void Fill(string query, DataTable dataTable);
		public abstract void Fill(string query, ParameterCollection parameters, DataTable dataTable);
		public abstract void FillStoredProcedure(string procedureName, DataTable dataTable);
		public abstract void FillStoredProcedure(string procedureName, ParameterCollection parameters, DataTable dataTable);
		//KK:13-Sep-2006 following three methods added
		public abstract IDataReader RunStoredProcedureReader(string procedureName, ParameterCollection parameters, SqlTransaction ObjTransation);
		//DH:13-Sep-2006 following three methods added
		public abstract IDataReader RunQueryReader(string query, SqlTransaction ObjTransation);
		public abstract IDataReader RunQueryReader(string query, ParameterCollection parameters, SqlTransaction ObjTransation);

		public abstract int RunNonQuery(string query, SqlTransaction ObjTransation);
		public abstract int RunNonQuery(string query, ParameterCollection parameters, SqlTransaction ObjTransation);



		public abstract string[] GetTables();
		public abstract bool TableExists(string tableName);

		public abstract IDbConnection Connection { get; }

		public abstract void Dispose();
	}
}
