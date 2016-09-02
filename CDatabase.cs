using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ASyncAwaitTest
{
    class CDatabase
    {
        // USE CUSTOM CLASS TO RETURN DATA
        public class CDatabaseResult
        {
            public bool Success;
            public String Result;
            public Object Data;
        }
        public Task<CDatabaseResult> GetTextDataToCustomClassAsync(string sConnectionString, string sSQL)
        {
            //Return task based on datatype
            return Task<CDatabaseResult>.Factory.StartNew(() =>
            {
                try
                {
                    //GET DATA
                    string sData = string.Empty;
                    using (SqlConnection newConnection = new SqlConnection(sConnectionString))
                    {
                        newConnection.Open();
                        
                        SqlCommand command = new SqlCommand(sSQL, newConnection);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            string sLine = string.Empty;
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                if (sLine.Length == 0) { sLine += reader[i]; } else { sLine += "\t" + reader[i]; }
                            }
                            if (sData.Length == 0) { sData += sLine; } else { sData += "\r\n" + sLine; }
                        }

                      

                        newConnection.Close();
                    }

                    CDatabaseResult result = new CDatabaseResult()
                    {
                        Data = sData,
                        Success = true
                    };

                    return result;
                }
                catch (Exception ex)
                {
                    CDatabaseResult result = new CDatabaseResult()
                    {
                        Result = "GetData Error: " + ex.Message,
                        Success = false
                    };
                    return result;
                }
            });
        }

        //EXECUTE ASYNC
        public Task<int> ExecuteAsync(string sConnectionString, string sSQL)
        {
            //Return task based on datatype
            return Task<int>.Factory.StartNew(() =>
            {
                try
                {
                    int iNumberOfRecordsProcessed = 0;

                    using (SqlConnection newConnection = new SqlConnection(sConnectionString))
                    {
                        newConnection.Open();

                        using (SqlCommand newCommand = new SqlCommand())
                        {
                            var _with1 = newCommand;
                            _with1.Connection = newConnection;
                            _with1.CommandType = CommandType.Text;
                            _with1.CommandText = sSQL;
                            iNumberOfRecordsProcessed = _with1.ExecuteNonQuery();
                        }


                        newConnection.Close();
                    }

                    return iNumberOfRecordsProcessed;
                }
                catch (SqlException ex)
                {
                    throw ex; //Return to caller to let them handle
                }
            });
        }

        // RETURN DATASET
        public Task<DataSet> GetDataSetAsync(string sConnectionString, string sSQL)
        {
            DataSet myDataSet;
            //Return task based on datatype
            return Task<DataSet>.Factory.StartNew(() =>
            {
                try
                {
                    using (SqlConnection newConnection = new SqlConnection(sConnectionString))
                    {
                        newConnection.Open();

                        // Get the dataset
                        using (SqlDataAdapter mySQLAdapter = new SqlDataAdapter(sSQL, newConnection))
                        {

                            var sqlAdapter = mySQLAdapter;
                            myDataSet = new DataSet();
                            sqlAdapter.Fill(myDataSet);

                        }

                        newConnection.Close();
                    }

                    return myDataSet;
                }
                catch (SqlException ex)
                {
                    throw ex; //Return to caller to let them handle
                }
            });
        }
    }
}
