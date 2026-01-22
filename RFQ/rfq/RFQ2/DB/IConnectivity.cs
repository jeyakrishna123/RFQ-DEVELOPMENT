using System;
using System.Data;
using System.Data.SqlClient;

namespace RFQ2.DB
{
    interface IConnectivity : IDisposable
    {
		DataSet RunQueryDataSet(string query, string tableName);
		DataSet RunQueryDataSet(string query, ParameterCollection parameters, string tableName);
		IDataReader RunStoredProcedureReader(string procedureName, ParameterCollection parameters);
		IDataReader RunQueryReader(string query);
		IDataReader RunQueryReader(string query, ParameterCollection parameters);
		DataSet RunStoredProcedureDataSet(string procedureName, ParameterCollection parameters, string tableName);
		object RunStoredProcedureScalar(string procedureName, ParameterCollection parameters);
		object RunStoredProcedureScalar(string procedureName, ParameterCollection parameters, SqlTransaction ObjTransation);
		int RunNonQuery(string query);
		int RunNonQuery(string query, ParameterCollection parameters);
		object RunQueryScalar(string query);
		object RunQueryScalar(string query, ParameterCollection parameters);
		//KK:13-Sep-2006 following three methods added
		IDataReader RunStoredProcedureReader(string procedureName, ParameterCollection parameters, SqlTransaction ObjTransation);
		//DH:21-Sep-2006 following  Transaction in Below Methods
		IDataReader RunQueryReader(string query, SqlTransaction ObjTransation);
		IDataReader RunQueryReader(string query, ParameterCollection parameters, SqlTransaction ObjTransation);

		int RunNonQuery(string query, SqlTransaction ObjTransation);
		int RunNonQuery(string query, ParameterCollection parameters, SqlTransaction ObjTransation);

		void Fill(string query, DataTable dataTable);
		void Fill(string query, ParameterCollection parameters, DataTable dataTable);

		void FillStoredProcedure(string procedureName, DataTable dataTable);
		void FillStoredProcedure(string procedureName, ParameterCollection parameters, DataTable dataTable);

		void Connect();
		void Disconnect();


		string[] GetTables();
		bool TableExists(string tableName);


		IDbConnection Connection { get; }
	}
}
