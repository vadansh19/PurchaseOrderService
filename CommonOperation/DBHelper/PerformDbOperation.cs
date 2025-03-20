using CommonOperation.CommonHelper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CommonOperation
{
    public class PerformDbOperation
    {
        /// <summary>
        /// Declare connection string
        /// </summary>
        private readonly string connectionString = string.Empty;

        public PerformDbOperation(string _connectionString)
        {
            connectionString = _connectionString;
        }

        /// <summary>
        /// Connect database using connection string
        /// </summary>
        ///<returns>Returns an open SqlConnection</returns>
        public SqlConnection GetDBConnection()
        {
            SqlConnection con = new SqlConnection(connectionString);
            return con;
        }

        /// <summary>
        /// Return data table based on procedure and parameters
        /// </summary>
        /// <param name="procedureName">Stored procedure name</param>
        /// <param name="parameters">List of SQL parameters</param>
        /// <returns>Returns a DataTable</returns>
        public DataTable ReturnDataTable(string procedureName, List<SqlParameter> parameters = null)
        {
            DataTable dtData = new DataTable();

            using (SqlConnection con = GetDBConnection())
            {
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }

                    using (SqlCommand sqlCommand = new SqlCommand(procedureName, con))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.CommandTimeout = 180;

                        if (parameters != null)
                        {
                            sqlCommand.Parameters.AddRange(parameters.ToArray());
                        }

                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            sqlDataAdapter.Fill(dtData);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // LogMessages.PrintException(ex);
                    throw ex;
                }
                finally
                {
                    if (con.State != ConnectionState.Closed)
                        con.Close();
                }
            }

            return dtData;
        }

        /// <summary>
        /// Return data set based on procedure and parameters
        /// </summary>
        /// <param name="procedureName">Stored procedure name</param>
        /// <param name="parameters">List of SQL parameters</param>
        /// <returns>Returns a DataSet</returns>
        public DataSet ReturnDataSet(string procedureName, List<SqlParameter> parameters = null)
        {
            DataSet dsData = new DataSet();

            using (SqlConnection con = GetDBConnection())
            {
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }

                    using (SqlCommand sqlCommand = new SqlCommand(procedureName, con))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.CommandTimeout = 180;

                        if (parameters != null)
                        {
                            sqlCommand.Parameters.AddRange(parameters.ToArray());
                        }

                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            sqlDataAdapter.Fill(dsData);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // LogMessages.PrintException(ex);
                    throw ex;
                }
                finally
                {
                    if (con.State != ConnectionState.Closed)
                        con.Close();
                }
            }

            return dsData;
        }

        /// <summary>
        /// To execute a non-query command
        /// </summary>
        /// <param name="procedureName">Stored procedure name</param>
        /// <param name="parameters">List of SQL parameters</param>
        /// <param name="timeOut">Optional command timeout</param>
        public void ExecuteNonQuery(string procedureName, List<SqlParameter> parameters, int? timeOut = null)
        {
            using (SqlConnection con = GetDBConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand(procedureName, con))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    if (timeOut != null)
                    {
                        sqlCommand.CommandTimeout = Convert.ToInt32(timeOut);
                    }

                    if (parameters != null)
                    {
                        sqlCommand.Parameters.AddRange(parameters.ToArray());
                    }

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    try
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (con.State != ConnectionState.Closed)
                            con.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Returns a single value from the database.
        /// </summary>
        /// <typeparam name="T">The type of the value to return.</typeparam>
        /// <param name="procedureName">The name of the stored procedure to execute.</param>
        /// <param name="parameters">The list of parameters for the stored procedure.</param>
        /// <returns>The single value returned by the database query.</returns>

        public T ExecuteScaler<T>(string procedureName, List<SqlParameter> parameters)
        {
            T result = default;

            using (SqlConnection con = GetDBConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand(procedureName, con))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        sqlCommand.Parameters.AddRange(parameters.ToArray());
                    }

                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }

                    try
                    {
                        result = (T)sqlCommand.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        // LogMessages.PrintException(ex);
                        throw ex;
                    }
                    finally
                    {
                        if (con.State != ConnectionState.Closed)
                        {
                            con.Close();
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Inserts or updates records using the ExecuteNonQuery method with a passed data table.
        /// </summary>
        /// <param name="procedureName">The name of the stored procedure to execute.</param>
        /// <param name="paramName">The name of the parameter for the data table.</param>
        /// <param name="dt">The data table containing records to be inserted or updated.</param>
        public void BulkInsertUpdate(string procedureName, string paramName, DataTable dt)
        {
            using (SqlConnection con = GetDBConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand(procedureName, con))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@" + paramName, dt);

                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }

                    sqlCommand.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Executes a query written in a stored procedure.
        /// </summary>
        /// <param name="procedureName">The name of the stored procedure to execute.</param>
        /// <param name="parameters">The list of parameters to pass to the stored procedure.</param>
        /// <param name="fault">Outputs any error related to the FaultContract.</param>
        /// <param name="timeOut">The timeout duration for the command (optional).</param>
        public void ExecureNonQuery(string procedureName, List<SqlParameter> parameters, out FaultContract fault, int? timeOut = null)
        {
            fault = null;

            using (SqlConnection con = GetDBConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand(procedureName, con))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    if (timeOut != null)
                    {
                        sqlCommand.CommandTimeout = Convert.ToInt32(timeOut);
                    }

                    if (parameters != null)
                    {
                        sqlCommand.Parameters.AddRange(parameters.ToArray());
                    }

                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }

                    try
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (con.State != ConnectionState.Closed)
                        {
                            con.Close();
                        }
                    }
                }
            }
        }
    }
}
