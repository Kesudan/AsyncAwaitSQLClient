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
            public string Result;
            public object Data;
        }
        public Task<CDatabaseResult> GetTextDataToCustomClassAsync(string sConnectionString, string sSQL, params SqlParameter[] parameters)
        {
            //Return task based on datatype
            return Task.Run(() =>
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
                    //Catch exception and return as error in class object
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
        public async Task<int> ExecuteAsync(string sConnectionString, string sSQL, params SqlParameter[] parameters)
        {
            try
            {
                using (var newConnection = new SqlConnection(sConnectionString))
                using (var newCommand = new SqlCommand(sSQL, newConnection))
                {
                    newCommand.CommandType = CommandType.Text;
                    if (parameters != null) newCommand.Parameters.AddRange(parameters);

                    await newConnection.OpenAsync().ConfigureAwait(false);
                    return await newCommand.ExecuteNonQueryAsync().ConfigureAwait(false);
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        // RETURN DATASET
        public Task<DataSet> GetDataSetAsync(string sConnectionString, string sSQL, params SqlParameter[] parameters)
        {
            return Task.Run(() =>
            {
                try
                {
                    using (var newConnection = new SqlConnection(sConnectionString))
                    using (var mySQLAdapter = new SqlDataAdapter(sSQL, newConnection))
                    {
                        mySQLAdapter.SelectCommand.CommandType = CommandType.Text;
                        if (parameters != null) mySQLAdapter.SelectCommand.Parameters.AddRange(parameters);

                        DataSet myDataSet = new DataSet();
                        mySQLAdapter.Fill(myDataSet);
                        return myDataSet;
                    }
                }
                catch (SqlException)
                {
                    throw; //Return to caller to let them handle
                }
            });
        }
    }
}

