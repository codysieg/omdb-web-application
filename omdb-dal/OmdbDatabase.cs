using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

using Dapper;

namespace omdb_dal
{
    public class OmdbDatabase
    {
        public string ConnectionString;

        public OmdbDatabase(string connectionString){
            ConnectionString = connectionString;
        }

        public IDbConnection GetDatabase()
        {
            SqlConnection connection = new SqlConnection(this.ConnectionString);
            connection.Open();
            return connection;
        }

        protected void DapperNonQuery(string storedProcedureName, DynamicParameters parameters)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Execute(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected T DapperItemQuery<T>(string storedProcedureName, DynamicParameters parameters)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(ConnectionString))
                {
                    return connection.Query<T>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected List<T> DapperListQuery<T>(string storedProcedureName, DynamicParameters parameters)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(ConnectionString))
                {
                    if (parameters == null)
                    {
                        return connection.Query<T>(storedProcedureName, commandType: CommandType.StoredProcedure).AsList<T>();
                    }
                    return connection.Query<T>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure).AsList<T>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}


