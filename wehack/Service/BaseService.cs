using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wehack.Service
{
    public class BaseService
    {
        protected static List<TReturnType> ExecuteReader<TReturnType>(string connectionName, string storedProcName, Func<IDataRecord, TReturnType> delegateFunction, List<SqlParameter> collection = null)
        {
            List<TReturnType> results = null;

            string connectionPath = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            SqlConnection connect = new SqlConnection(connectionPath);

            try
            {
                connect.Open();

                SqlCommand command = new SqlCommand(storedProcName, connect);
                command.CommandTimeout = 1000;
                command.CommandType = CommandType.StoredProcedure;

                if (collection != null)
                {
                    collection.ForEach(x => command.Parameters.Add(x));
                }

                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    if (results == null)
                    {
                        results = new List<TReturnType>();
                    }
                    results.Add(delegateFunction((IDataRecord)reader));
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connect.Close();
                connect.Dispose();
            }

            return results;
        }

        protected static void ExecuteNonQuery(string connectionName, string storedProcName, List<SqlParameter> collection = null)
        {
            string connectionPath = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            SqlConnection connect = new SqlConnection(connectionPath);

            try
            {
                connect.Open();

                SqlCommand command = new SqlCommand(storedProcName, connect);
                command.CommandTimeout = 1000;
                command.CommandType = CommandType.StoredProcedure;

                if (collection != null)
                {
                    collection.ForEach(x => command.Parameters.Add(x));
                }

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connect.Close();
                connect.Dispose();
            }
        }

        protected static SqlParameter CreateParameter(string pName, Object pValue, SqlDbType pType, ParameterDirection pDrxn)
        {
            SqlParameter parameter = new SqlParameter(pName, pValue);
            parameter.SqlDbType = pType;
            parameter.Direction = pDrxn;

            return parameter;
        }
    }
}
