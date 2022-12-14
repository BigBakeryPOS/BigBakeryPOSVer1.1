using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;


namespace DataLayer
{
    public class DBAccess
    {
       
        #region Identifiers Declaration ---------------------------
        private IDataReader iDataReader;
        private Dictionary<string, string> sqlParamValues;
        private List<string> sqlParamNames;
        private string queryId;
        private string queryType;
        private string connnectionString;
       // private string connnectionString2;
        private string connnectionStringMain;
        private string Ennama;

        public string E;
        #endregion

        #region Constructor ---------------------------------------

        public string whre(string place)
        {
            E = place;
            return place;
           
           
        }



        public DBAccess()
        {

            connnectionString = ConfigurationManager.ConnectionStrings["Server"].ConnectionString;
            connnectionStringMain = ConfigurationManager.ConnectionStrings["MainServer"].ConnectionString;

          
        }

        #endregion

        #region Public Properties ---------------------------------

        public string QueryId
        {
            get { return queryId; }
            set { sqlParamValues = null; sqlParamNames = null; queryId = value; }
        }

        public string QueryType
        {
            get { return queryType; }
            set { queryType = value; }
        }

        #endregion

        #region Execute Data Reader -------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IDataReader ExecuteDataReader()
        {
            try
            {
                SqlConnection dbConnection = new SqlConnection(connnectionString);
                SqlCommand dbCommand = GetDbCommand(dbConnection);

                dbConnection.Open();
                iDataReader = dbCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return iDataReader;
        }
        #endregion

        #region ExecuteDataSet
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet ExecuteDataSet()
        {
            DataSet dataSet = new DataSet();
            try
            {

                using (SqlConnection dbConnection = new SqlConnection(connnectionString))
                {
                    SqlCommand dbCommand = GetDbCommand(dbConnection);
                    dbCommand.CommandTimeout = 0;
                    SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);
                    dbDataAdapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataSet;
        }
        #endregion


        #region InlineExecuteScalar
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object InlineExecuteScalar(string sQry)
        {
            object scalarValue = null;
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(connnectionString))
                {
                    // SqlCommand dbCommand = GetDbCommand(dbConnection);
                    //dbConnection.BeginTransaction();
                    SqlCommand dbCommand = new SqlCommand(sQry, dbConnection);
                    //dbCommand.CommandText = sQry;
                    dbCommand.CommandTimeout = 0;
                    dbConnection.Open();

                    scalarValue = dbCommand.ExecuteScalar();
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return scalarValue;
        }
        #endregion

        #region ExecuteScalar
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object ExecuteScalar()
        {
            object scalarValue = null;
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(connnectionString))
                {
                    SqlCommand dbCommand = GetDbCommand(dbConnection);
                    dbCommand.CommandTimeout = 0;
                    dbConnection.Open();
                    scalarValue = dbCommand.ExecuteScalar();
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return scalarValue;
        }
        #endregion

        #region ExecuteNonQuery
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int ExecuteNonQuery()
        {
            int recordsAffected = 0;
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(connnectionString))
                {
                    SqlCommand dbCommand = GetDbCommand(dbConnection);
                    dbCommand.CommandTimeout = 0;
                    dbConnection.Open();
                    recordsAffected = dbCommand.ExecuteNonQuery();
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return recordsAffected;
        }
        #endregion

        #region GetDbCommand
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private SqlCommand GetDbCommand(SqlConnection dbConnection)
        {
            SqlCommand dbCommand = null;
            try
            {
                if (QueryId == string.Empty)
                    throw new Exception("QueryID is empty");

                dbCommand = new SqlCommand(QueryId, dbConnection);

                //if (QueryType == Constants.InlineQuery)
                //    dbCommand.CommandType = CommandType.Text;
                //else if (QueryType == Constants.StoredProcedure)
                    dbCommand.CommandType = CommandType.StoredProcedure;

                if (sqlParamNames != null)
                {
                    for (int paramsCount = 0; paramsCount < sqlParamNames.Count; paramsCount++)
                    {
                        string parameterName = sqlParamNames[paramsCount];
                        string parameterValue = sqlParamValues[parameterName];
                        SqlParameter dbParam = new SqlParameter(parameterName, parameterValue);
                        dbCommand.Parameters.Add(dbParam);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dbCommand;
        }
        #endregion

        #region AddParameters
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="paramValue"></param>
        public void AddParameters(string paramName, string paramValue)
        {
            if (sqlParamValues == null || sqlParamNames == null)
            {
                sqlParamValues = new Dictionary<string, string>();
                sqlParamNames = new List<string>();
            }

            sqlParamNames.Add(paramName);
            sqlParamValues.Add(paramName, paramValue);
        }
        #endregion


        #region InlineExecuteDataSet
       
        public DataSet InlineExecuteDataSet(string sQry)
        {
            DataSet dataSet = new DataSet();
            try
            {

                using (SqlConnection dbConnection = new SqlConnection(connnectionString))
                {
                    SqlCommand dbCommand = GetDbCommand(dbConnection);
                    dbCommand.CommandTimeout = 0;
                    SqlDataAdapter dbDataAdapter = new SqlDataAdapter(sQry, dbConnection);
                    dbDataAdapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataSet;
        }
        //public DataSet InlineExecuteDataSetLocal(string sQry)
        //{
        //    DataSet dataSet = new DataSet();
        //    try
        //    {

        //        using (SqlConnection dbConnection = new SqlConnection(connnectionString2))
        //        {
        //            SqlCommand dbCommand = GetDbCommand(dbConnection);
        //            dbCommand.CommandTimeout = 0;
        //            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(sQry, dbConnection);
        //            dbDataAdapter.Fill(dataSet);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return dataSet;
        //}
        public DataSet InlineExecuteDataSetMain(string sQry)
        {
            DataSet dataSet = new DataSet();
            try
            {

                using (SqlConnection dbConnection = new SqlConnection(connnectionStringMain))
                {
                    SqlCommand dbCommand = GetDbCommand(dbConnection);
                    dbCommand.CommandTimeout = 0;
                    SqlDataAdapter dbDataAdapter = new SqlDataAdapter(sQry, dbConnection);
                    dbDataAdapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return dataSet;
        }

        #endregion


        #region InlineExecuteNonQuery
       
        public int InlineExecuteNonQuery(string sQry)
        {
            int recordsAffected = 0;
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(connnectionString))
                {
                    SqlCommand dbCommand = new SqlCommand(sQry, dbConnection);
                    dbCommand.CommandTimeout = 0;
                    dbConnection.Open();
                    recordsAffected = dbCommand.ExecuteNonQuery();
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {
              // throw ex;
              //  this.LogError(ex);
            }

            return recordsAffected;
        }
        public int InlineExecuteNonQuery1(string sQry, string sourceBS)
        {
            int recordsAffected = 0;
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(connnectionString))
                {
                    SqlCommand dbCommand = new SqlCommand(sQry, dbConnection);
                    dbCommand.CommandTimeout = 0;
                    dbConnection.Open();
                    recordsAffected = dbCommand.ExecuteNonQuery();
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {
                // throw ex;
                this.LogError(ex, sourceBS);
            }

            return recordsAffected;
        }
        private void LogError(Exception ex, string source1)
        {
            int recordsAffected = 0;
            string Logtime = DateTime.Now.ToString("dd/MM/yyyy");
            string LogMsg = ex.Message.ToString();
            string LogStack = ex.StackTrace.ToString();
            string LogSource = ex.Source.ToString();
            string LogBSSource = source1;
            string LogTargetSite = ex.TargetSite.ToString().ToString();
            string sQry = "insert into tblErrorLog(LogTime,LogMsg,LogStack,LogSource,LogTargetSite) values ('" + Logtime + "','" + LogMsg + "','" + LogStack + "','" + LogSource + "','" + LogTargetSite + "')";
            using (SqlConnection dbConnection = new SqlConnection(connnectionString))
            {
                SqlCommand dbCommand = new SqlCommand(sQry, dbConnection);
                dbCommand.CommandTimeout = 0;
                dbConnection.Open();
                recordsAffected = dbCommand.ExecuteNonQuery();
                dbConnection.Close();
            }
        }
        public int InlineExecuteNonQueryServer(string sQry)
        {
            int recordsAffected = 0;
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(connnectionStringMain))
                {
                    SqlCommand dbCommand = new SqlCommand(sQry, dbConnection);
                    dbCommand.CommandTimeout = 0;
                    dbConnection.Open();
                    recordsAffected = dbCommand.ExecuteNonQuery();
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return recordsAffected;
        }

        //public int InlineExecuteNonQueryLocal(string sQry)
        //{
        //    int recordsAffected = 0;
        //    try
        //    {
        //        using (SqlConnection dbConnection = new SqlConnection(connnectionString2))
        //        {
        //            SqlCommand dbCommand = new SqlCommand(sQry, dbConnection);
        //            dbCommand.CommandTimeout = 0;
        //            dbConnection.Open();
        //            recordsAffected = dbCommand.ExecuteNonQuery();
        //            dbConnection.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return recordsAffected;
        //}
        public int InlineExecuteNonQueryMain(string sQry)
        {
            int recordsAffected = 0;
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(connnectionStringMain))
                {
                    SqlCommand dbCommand = new SqlCommand(sQry, dbConnection);
                    dbCommand.CommandTimeout = 0;
                    dbConnection.Open();
                    recordsAffected = dbCommand.ExecuteNonQuery();
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return recordsAffected;
        }

        #endregion
    }
}
